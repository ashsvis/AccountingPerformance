using AccountingPerformanceModel;
using System.Linq;
using System.Windows.Forms;

namespace AccountingPerformanceView
{
    /// <summary>
    /// ФОрма перевода студента
    /// </summary>
    public partial class MoveStudentToGroupForm : Form
    {
        Root _root;
        Student _student;

        /// <summary>
        /// Конструктор формы, инициализация
        /// </summary>
        /// <param name="root"></param>
        /// <param name="student"></param>
        public MoveStudentToGroupForm(Root root, Student student)
        {
            InitializeComponent();
            _root = root;
            _student = student;
            tbStudent.Text = student.FullName;
            // заполнение списка специальностей
            foreach (var item in _root.Specialities)
            {
                cbSpecialities.Items.Add(item);
                if (item.IdSpeciality == student.IdSpeciality)
                    cbSpecialities.SelectedItem = item;
            }
            // заполнение списка специализаций
            foreach (var item in _root.Specializations.Where(x => x.IdSpeciality == _student.IdSpeciality))
            {
                cbSpecializations.Items.Add(item);
                if (item.IdSpecialization == student.IdSpecialization)
                    cbSpecializations.SelectedItem = item;
            }
            // заполнение списка групп
            foreach (var item in _root.StudyGroups.Where(x => x.IdSpeciality == _student.IdSpeciality && 
                                                              x.IdSpecialization == _student.IdSpecialization))
            {
                cbStudyGroups.Items.Add(item);
                if (item.IdStudyGroup == student.IdStudyGroup)
                    cbStudyGroups.SelectedItem = item;
            }
        }

        /// <summary>
        /// Заполение списка специальностей при открытии селектора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSpecialities_DropDown(object sender, System.EventArgs e)
        {
            var speciality = (Speciality)cbSpecialities.SelectedItem;
            cbSpecialities.Items.Clear();
            foreach (var item in _root.Specialities)
                cbSpecialities.Items.Add(item);
            cbSpecialities.SelectedItem = speciality;
        }

        /// <summary>
        /// Выбрали специальность
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSpecialities_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            cbSpecializations.SelectedItem = null;
            cbStudyGroups.SelectedItem = null;
            btnMove.Enabled = false;
        }

        /// <summary>
        /// Заполение списка специализаций при открытии селектора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSpecializations_DropDown(object sender, System.EventArgs e)
        {
            // получаем выбранную специальность
            var speciality = (Speciality)cbSpecialities.SelectedItem;
            // получаем выбранную специализацию
            var specialization = (Specialization)cbSpecializations.SelectedItem;
            // очищаем список специализаций
            cbSpecializations.Items.Clear();
            if (speciality == null) return;
            // заполняем список специализаций только для выбранной специальности
            foreach (var item in _root.Specializations.Where(x => x.IdSpeciality == speciality.IdSpeciality))
                cbSpecializations.Items.Add(item);
            cbSpecializations.SelectedItem = specialization;
        }

        /// <summary>
        /// Выбрали специализацию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSpecializations_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            cbStudyGroups.SelectedItem = null;
            btnMove.Enabled = false;
        }

        /// <summary>
        /// Заполение списка групп при открытии селектора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbStudyGroups_DropDown(object sender, System.EventArgs e)
        {
            // получаем выбранную специальность
            var speciality = (Speciality)cbSpecialities.SelectedItem;
            // получаем выбранную специализацию
            var specialization = (Specialization)cbSpecializations.SelectedItem;
            // получаем выбранную специализацию
            var group = (StudyGroup)cbStudyGroups.SelectedItem;
            cbStudyGroups.Items.Clear();
            // заполняем список специализаций только для выбранной специальности и специализации
            foreach (var item in _root.StudyGroups.Where(x => x.IdSpeciality == speciality.IdSpeciality && 
                                                              x.IdSpecialization == specialization.IdSpecialization))
                cbStudyGroups.Items.Add(item);
            cbStudyGroups.SelectedItem = group;
        }

        /// <summary>
        /// Выбрали группу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbStudyGroups_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            btnMove.Enabled = true;
        }

        /// <summary>
        /// Метод обновления данных студента
        /// </summary>
        /// <param name="student"></param>
        public void Update(Student student)
        {
            // получаем выбранную специальность
            var speciality = (Speciality)cbSpecialities.SelectedItem;
            // получаем выбранную специализацию
            var specialization = (Specialization)cbSpecializations.SelectedItem;
            // получаем выбранную специализацию
            var group = (StudyGroup)cbStudyGroups.SelectedItem;
            if (speciality == null || specialization == null || group == null) return;
            // установка новых привязок для студента
            student.IdSpeciality = speciality.IdSpeciality;
            student.IdSpecialization = specialization.IdSpecialization;
            student.IdStudyGroup = group.IdStudyGroup;
        }
    }
}
