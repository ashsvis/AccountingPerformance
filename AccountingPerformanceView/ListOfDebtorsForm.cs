using AccountingPerformanceModel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ViewGenerator;

namespace AccountingPerformanceView
{
    public partial class ListOfDebtorsForm : Form
    {
        Form _form;
        Root _root;
        Debtors _debtors;
        Student _student;

        public ListOfDebtorsForm(Form form, Root root)
        {
            InitializeComponent();
            _form = form;
            _root = root;
            _debtors = new Debtors();
        }

        private void ListOfDebtorsForm_Activated(object sender, EventArgs e)
        {
            _debtors.Clear();
            // проходим по всем семестрам, начиная с меньшего номера
            foreach (var semester in _root.Semesters.OrderBy(x => x.Number))
            {
                // смотрим в списке успеваемости для данного семестра
                foreach (var performances in _root.Performances.Where(x => x.IdSemester == semester.IdSemester)
                                                 .GroupBy(x => x.IdStudent).OrderBy(x => x.Key.ToString()))
                    foreach (var item in performances.Where(x => x.Grade == Grade.Незачёт))
                    {
                        if (_root.Students.FirstOrDefault(x => x.IdStudent == item.IdStudent) == null) continue;
                        // заполняем список должников
                        _debtors.Add(new Debtor
                        {
                            IdStudent = item.IdStudent,
                            IdStudyGroup = Helper.GetStudentGroupId(item.IdStudent),
                            IdSemester = item.IdSemester,
                            IdMatter = item.IdMatter
                        });
                    }
            }
            // заполняем таблицу фильтрованными значениями
            var panel = GridPanelBuilder.BuildPropertyPanel(_root, new Debtor(), _debtors);
            GridPanelBuilder.HideButtonsPanel(panel);
            panel.GridSelectedChanged += Panel_GridSelectedChanged;
            panel1.Controls.Add(panel);
            // предыдущую панель убираем
            if (panel1.Controls.Count > 1)
                panel1.Controls.RemoveAt(0);
            panel1.Enabled = true;
        }

        /// <summary>
        /// Выбор в таблице изменился
        /// </summary>
        /// <param name="obj"></param>
        private void Panel_GridSelectedChanged(object obj)
        {
            var debtor = (Debtor)obj;
            _student = debtor != null ? _root.Students.FirstOrDefault(item => item.IdStudent == debtor.IdStudent) : null;
            btnStudent.Enabled = _student != null;
        }

        /// <summary>
        /// Прячем форму при закрытии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListOfDebtorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Делаем форму о студенте видимой
        /// </summary>
        private void EnshureStudentFormVisible()
        {
            // если ранее не показывался, то создаем новое окно
            if (MainForm.StudentForm == null)
                MainForm.StudentForm = new StudentForm(this, _root);
            // показываем окно 
            MainForm.ShowForm(MainForm.StudentForm);
        }

        /// <summary>
        /// Пытаемся показать форму студента-должника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStudent_Click(object sender, EventArgs e)
        {
            if (_student == null) return;
            EnshureStudentFormVisible();
            // получаем выбранную специальность
            var speciality = _root.Specialities.FirstOrDefault(x => x.IdSpeciality == _student.IdSpeciality);
            // получаем выбранную специализацию
            var specialization = _root.Specializations.FirstOrDefault(x => x.IdSpecialization == _student.IdSpecialization);
            // если один из фильтров не выбран, выходим
            if (speciality == null || specialization == null) return;
            MainForm.StudentForm.Build(speciality, specialization, _student);
        }
    }
}
