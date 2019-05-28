using AccountingPerformanceModel;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ViewGenerator;

namespace AccountingPerformanceView
{
    public partial class GroupPerformanceForm : Form
    {
        Root _root;
        Matter _matter;
        StudyGroup _group;
        Semester _semester;

        public GroupPerformanceForm(Root root)
        {
            InitializeComponent();
            _root = root;
            // селектор оценок
            foreach (var item in typeof(Grade).GetEnumValues())
            {
                var value = new EnumCover() { Item = (Grade)item };
                cbGrade.Items.Add(value);
            }
            // селектор предметов, добавляем только те, по которым сдавали
            foreach (var item in _root.Matters)
                if (_root.Performances.Any(x => x.IdMatter == item.IdMatter))
                    cbMatters.Items.Add(item);
            if (cbMatters.Items.Count > 0)
                cbMatters.SelectedItem = _matter = (Matter)cbMatters.Items[0];
            // селектор групп, добавляем "непустые" группы
            foreach (var item in _root.StudyGroups)
                if (_root.Students.Any(x => x.IdStudyGroup == item.IdStudyGroup))
                    cbStudyGroups.Items.Add(item);
            if (cbStudyGroups.Items.Count > 0)
                cbStudyGroups.SelectedItem = _group = (StudyGroup)cbStudyGroups.Items[0];
            // селектор семестров, добавляем только те, в которых сдавали
            _semester = root.Semesters.FirstOrDefault(x => x.Number == 1);
            foreach (var item in _root.Semesters)
                if (_root.Performances.Any(x => x.IdSemester == item.IdSemester))
                    cbSemesters.Items.Add(item);
            cbSemesters.SelectedItem = _semester;

            panel1.Enabled = _semester != null;
        }

        /// <summary>
        /// При выборе в любом селекторе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMatters_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            var matter = (Matter)cbMatters.SelectedItem;
            var studyGroup = (StudyGroup)cbStudyGroups.SelectedItem;
            var semester = (Semester)cbSemesters.SelectedItem;
            cbGrade.Visible = false;
            if (matter == null || studyGroup == null || semester == null) return;
            try
            {
                lvPerformance.BeginUpdate();
                lvPerformance.Items.Clear();
                // этот фрагмент заменен следующим фрагментом ниже
                //foreach (var item in _root.Performances.Where(x => x.IdMatter == matter.IdMatter &&
                //                                                   x.IdSemester == semester.IdSemester))
                //{
                //    var student = Helper.GetStudentById(item.IdStudent);
                //    if (student == null) continue;
                //    if (student.IdStudyGroup != studyGroup.IdStudyGroup) continue;
                //    var lvi = new ListViewItem(student.ToString());
                //    lvi.Tag = item;
                //    lvi.SubItems.Add(semester.ToString());
                //    lvi.SubItems.Add(EnumConverter.GetName(item.Grade));
                //    lvPerformance.Items.Add(lvi);
                //}
                // новая логика заполнения таблицы для выставления оценок группе по предмету
                foreach (var student in _root.Students.Where(x => x.IdStudyGroup == studyGroup.IdStudyGroup))
                {
                    var item = _root.Performances.FirstOrDefault(x => x.IdMatter == matter.IdMatter &&
                                                                      x.IdSemester == semester.IdSemester &&
                                                                      x.IdStudent == student.IdStudent);
                    if (item == null)
                    {
                        item = new Performance
                        {
                            IdStudent = student.IdStudent,
                            IdMatter = matter.IdMatter,
                            IdSemester = semester.IdSemester,
                            Grade = Grade.Нет
                        };
                        _root.Performances.Add(item);
                    }
                    var lvi = new ListViewItem(student.ToString());
                    lvi.Tag = item;
                    lvi.SubItems.Add(semester.ToString());
                    lvi.SubItems.Add(EnumConverter.GetName(item.Grade));
                    lvPerformance.Items.Add(lvi);
                }
            }
            finally
            {
                lvPerformance.EndUpdate();
            }
        }

        private void cbGrade_Leave(object sender, System.EventArgs e)
        {
            cbGrade.Visible = false;
        }

        private void lvPerformance_MouseMove(object sender, MouseEventArgs e)
        {
            var item = lvPerformance.GetItemAt(e.Location.X, e.Location.Y);
            if (item == null)
            {
                cbGrade.Visible = false;
                lvPerformance.FocusedItem = null;
                return;
            }
            var rect = lvPerformance.GetItemRect(item.Index, ItemBoundsPortion.ItemOnly);
            rect.Offset(lvPerformance.Columns[0].Width + lvPerformance.Columns[1].Width + 2, 0);
            rect.Width = lvPerformance.Columns[2].Width;
            if (rect.Contains(e.Location))
            {
                cbGrade.Location = rect.Location;
                cbGrade.Width = rect.Width;
                cbGrade.Visible = true;
                var performance = (Performance)item.Tag;
                lvPerformance.FocusedItem = item;
                cbGrade.Tag = performance;
                var cover = new EnumCover { Item = performance.Grade };
                foreach (var m in cbGrade.Items.Cast<EnumCover>())
                    if (m.Item.ToString() == cover.Item.ToString())
                        cbGrade.SelectedItem = m;
            }
            else
                cbGrade.Visible = false;
        }

        private void lvPerformance_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            cbGrade.Visible = false;
        }

        private void cbGrade_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            var performance = (Performance)cbGrade.Tag;
            performance.Grade = (Grade)((EnumCover)cbGrade.SelectedItem).Item;
            lvPerformance.FocusedItem.SubItems[2].Text = EnumConverter.GetName(performance.Grade);
        }

        /// <summary>
        /// Выдача ведомости семестровых оценок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScorecard_Click(object sender, System.EventArgs e)
        {
            var matter = (Matter)cbMatters.SelectedItem;
            var studyGroup = (StudyGroup)cbStudyGroups.SelectedItem;
            var semester = (Semester)cbSemesters.SelectedItem;
            if (matter == null || studyGroup == null || semester == null) return;
            try
            {
                var app = new Microsoft.Office.Interop.Word.Application();
                var filename = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Reports",
                                            "SemesterScorecard.docx");
                var oDoc = app.Documents.Add(filename);
                oDoc.Application.Visible = true;
                var course = semester.Number / 2 + 1;
                var semesterInCourse = semester.Number / course;
                oDoc.Bookmarks[$"matter"].Range.Text = matter.ToString();
                oDoc.Bookmarks[$"group"].Range.Text = studyGroup.ToString();
                oDoc.Bookmarks[$"course"].Range.Text = course.ToString();
                oDoc.Bookmarks[$"semester"].Range.Text = semesterInCourse.ToString();
                oDoc.Bookmarks[$"speciality"].Range.Text = Helper.SpecialityById(studyGroup.IdSpeciality);
                var row = 1;
                foreach (var item in _root.Performances.Where(x => x.IdMatter == matter.IdMatter &&
                                                   x.IdSemester == semester.IdSemester))
                {
                    var student = Helper.GetStudentById(item.IdStudent);
                    if (student == null) continue;
                    if (student.IdStudyGroup != studyGroup.IdStudyGroup) continue;
                    oDoc.Bookmarks[$"fio{row}"].Range.Text = student.FullName;
                    //oDoc.Bookmarks[$"grade{row}"].Range.Text = EnumConverter.GetName(item.Grade); - эта строка не нужна, оказывается
                    row++;
                }
                Application.OpenForms[0].SendToBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка");
            }

        }
    }
}
