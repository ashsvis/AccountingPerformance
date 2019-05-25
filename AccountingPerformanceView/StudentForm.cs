using AccountingPerformanceModel;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ViewGenerator;

namespace AccountingPerformanceView
{
    public partial class StudentForm : Form
    {
        Form _owner;
        Root _root;
        Speciality _speciality;
        Specialization _specialization;
        Student _student;
        Semester _semester;

        public StudentForm(Form owner, Root root)
        {
            InitializeComponent();
            _owner = owner;
            _root = root;
            _semester = root.Semesters.FirstOrDefault(x => x.Number == 1);
            foreach (var item in _root.Semesters)
                cbSemester.Items.Add(item);
            cbSemester.SelectedItem = _semester;
            panel1.Enabled = _semester != null;
        }

        /// <summary>
        /// Прячем форму при закрытии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        /// <summary>
        /// Построение интерфейса
        /// </summary>
        /// <param name="speciality"></param>
        /// <param name="specialization"></param>
        /// <param name="student"></param>
        public void Build(Speciality speciality, Specialization specialization, Student student)
        {
            _speciality = speciality;
            _specialization = specialization;
            _student = student;
            UpdateFields(speciality, specialization, student);
            gbStudyProgress.Enabled = btnNew.Enabled = btnDelete.Enabled = student != null;
            // показать таблицу успеваемости
            UpdatePerformanceTable(student);
        }

        /// <summary>
        /// Подключение таблицы успеваемости
        /// </summary>
        /// <param name="student"></param>
        private void UpdatePerformanceTable(Student student)
        {
            if (_student != null)
            {
                var panel = GridPanelBuilder.BuildPropertyPanel(_root, new Performance(), _root.Performances,
                     _root.Performances.FilteredByStudentSemester(student.IdStudent, _semester.IdSemester),
                                   new[] { "IdStudent", "IdSemester" },
                                   new[] { student.IdStudent, _semester.IdSemester });
                panel1.Controls.Add(panel);
                // предыдущую панель убираем
                if (panel1.Controls.Count > 1)
                    panel1.Controls.RemoveAt(0);
            }
        }

        /// <summary>
        /// Заполнение значениями редакторов ввода
        /// </summary>
        /// <param name="speciality"></param>
        /// <param name="specialization"></param>
        /// <param name="student"></param>
        private void UpdateFields(Speciality speciality, Specialization specialization, Student student)
        {
            var std = student ?? new Student()
            {
                IdSpeciality = speciality.IdSpeciality,
                IdSpecialization = specialization.IdSpecialization
            };

            tbFullName.Text = std.FullName;
            dtpBirthDay.Value = std.BirthDay < dtpBirthDay.MinDate ? DateTime.Now : std.BirthDay;
            tbEducationCertificate.Text = std.EducationCertificate;
            dtpReceiptDate.Value = std.ReceiptDate < dtpReceiptDate.MinDate ? DateTime.Now : std.ReceiptDate;
            tbAddress.Text = std.Address;
            tbPhoneNumber.Text = std.PhoneNumber;
            cbSocialStatus.Text = std.SocialStatus;
            tbNotes.Text = std.Notes;
            if (std.Photo != null && std.Photo.Length > 0)
                pbPhoto.Image = Helper.CreateImage(std.Photo);
            else
                pbPhoto.Image = null;

            btnApply.Enabled = false;
        }

        /// <summary>
        /// Обработчик кнопки "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик для создания заготовки новой записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            _student = null;
            UpdateFields(_speciality, _specialization, null);
            gbStudyProgress.Enabled = btnDelete.Enabled = false;
        }

        /// <summary>
        /// Обработчик изменений данных в полях редакторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbFullName_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnNew.Enabled = btnDelete.Enabled = false;
        }

        /// <summary>
        /// Обработчик кнопки "Применить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            var std = _student ?? new Student()
            {
                IdSpeciality = _speciality.IdSpeciality,
                IdSpecialization = _specialization.IdSpecialization
            };
            try
            {
                if (string.IsNullOrWhiteSpace(tbFullName.Text))
                {
                    var caption = "Ф.И.О.";
                    throw new Exception($"Свойство \"{caption}\":{Environment.NewLine}Ожидалось не пустое значение свойства");
                }
                std.FullName = tbFullName.Text;
                std.BirthDay = dtpBirthDay.Value;
                if (string.IsNullOrWhiteSpace(tbEducationCertificate.Text))
                {
                    var caption = "Аттестат";
                    throw new Exception($"Свойство \"{caption}\":{Environment.NewLine}Ожидалось не пустое значение свойства");
                }
                std.EducationCertificate = tbEducationCertificate.Text;
                std.ReceiptDate = dtpReceiptDate.Value;
                if (string.IsNullOrWhiteSpace(tbAddress.Text))
                {
                    var caption = "Адрес";
                    throw new Exception($"Свойство \"{caption}\":{Environment.NewLine}Ожидалось не пустое значение свойства");
                }
                std.Address = tbAddress.Text;
                std.PhoneNumber = tbPhoneNumber.Text;
                std.SocialStatus = cbSocialStatus.Text;
                std.Notes = tbNotes.Text;
                std.Photo = pbPhoto.Image != null ? Helper.CreateByteArray(pbPhoto.Image) : null;

                var found = _root.Students.Any(item => item.IdStudent == std.IdStudent);
                if (found)
                    _root.Students.ChangeTo(_student, std);
                else
                {
                    _student = std;
                    _root.Students.Add(std);
                    UpdatePerformanceTable(std);
                }
                btnApply.Enabled = false;
                btnNew.Enabled = btnDelete.Enabled = true;
                (_owner as UpdateData)?.UpdateStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту запись?", "Удаление записи о студенте",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            _root.Students.Remove(_student);
            _student = null;
            UpdateFields(_speciality, _specialization, null);
            gbStudyProgress.Enabled = btnDelete.Enabled = false;
            (_owner as UpdateData)?.UpdateStudents();
            Close();
        }

        /// <summary>
        /// Обработчик кнопки "Выбрать фото"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = @"Все файлы (.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            var image = Image.FromFile(dlg.FileName);
            pbPhoto.Image = image;
            btnApply.Enabled = true;
        }

        /// <summary>
        /// Заполнение списка номеров семестров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSemester_DropDown(object sender, EventArgs e)
        {
            cbSemester.Items.Clear();
            foreach (var item in _root.Semesters)
                cbSemester.Items.Add(item);
            cbSemester.SelectedItem = _root.Semesters.FirstOrDefault(x => x.Number == 1);
        }

        /// <summary>
        /// Номер семестра выбран
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSemester_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _semester = (Semester)cbSemester.SelectedItem;
            // обновляем таблицу успеваемости студента по номеру семестра
            var panel = GridPanelBuilder.BuildPropertyPanel(_root, new Performance(), _root.Performances,
                 _root.Performances.FilteredByStudentSemester(_student.IdStudent, _semester.IdSemester),
                               new[] { "IdStudent", "IdSemester" },
                               new[] { _student.IdStudent, _semester.IdSemester });
            panel1.Controls.Add(panel);
            // предыдущую панель убираем
            if (panel1.Controls.Count > 1)
                panel1.Controls.RemoveAt(0);
            panel1.Enabled = true;
        }
    }
}
