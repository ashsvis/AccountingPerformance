using AccountingPerformanceModel;
using Microsoft.Office.Interop.Excel;
using Reports;
using System;
using System.Linq;
using System.Windows.Forms;
using ViewGenerator;

namespace AccountingPerformanceView
{
    public partial class SelectSemesterForm : Form
    {
        Root _root;
        Student _student;
        StudyGroup _group;
        bool byGroup;

        public SelectSemesterForm(Root root, Student student)
        {
            InitializeComponent();
            _root = root;
            _student = student;
            // селектор семестров, добавляем только те, в которых сдавал студент
            var semester = root.Semesters.FirstOrDefault(x => x.Number == 1);
            foreach (var item in root.Semesters)
                if (root.Performances.Any(x => x.IdSemester == item.IdSemester && x.IdStudent == student.IdStudent))
                    cbSemesters.Items.Add(item);
            cbSemesters.SelectedItem = semester;
            btnToReport.Enabled = btnToExcel.Enabled = cbSemesters.Items.Count > 0;
            byGroup = false;
        }

        public SelectSemesterForm(Root root, StudyGroup group)
        { 
            InitializeComponent();
            _root = root;
            _group = group;
            // селектор семестров, добавляем только те, в которых сдавала группа студентов
            var semester = root.Semesters.FirstOrDefault(x => x.Number == 1);
            var students = root.Students.Where(x => x.IdStudyGroup == group.IdStudyGroup);
            foreach (var item in root.Semesters)
                if (root.Performances.Any(x => x.IdSemester == item.IdSemester && students.Count() > 0))
                    cbSemesters.Items.Add(item);
            cbSemesters.SelectedItem = semester;
            btnToExcel.Enabled = cbSemesters.Items.Count > 0;
            byGroup = true;
        }

        private void btnToReport_Click(object sender, System.EventArgs e)
        {
            var semester = (Semester)cbSemesters.SelectedItem;
            if (semester == null || _student == null) return;
            // показываем окно первого отчета
            new ReportsForm(ReportsBuilder.GetStudentPerformance(_root, semester, _student)).ShowDialog();
            Close();
        }

        private void btnToExcel_Click(object sender, System.EventArgs e)
        {
            var semester = (Semester)cbSemesters.SelectedItem;
            var t = Type.Missing;
            if (byGroup)
            {
                if (semester == null || _group == null) return;
                var xl1 = new Microsoft.Office.Interop.Excel.Application();
                xl1.Visible = true;
                var book = xl1.Workbooks.Add(t);
                var lists = book.Worksheets;
                Worksheet list = lists.Item[1];
                var cell = xl1.Selection.Cells;
                list.Range["C1", t].Value2 = $"Отчет об успеваемости группы {_group} за {semester} семестр";
                var col = 6;
                foreach (var performances in _root.Performances.Where(x => x.IdSemester == semester.IdSemester)
                                                       .GroupBy(x => x.IdMatter))
                {
                    var cource = _root.MattersCourses.FirstOrDefault(x => x.IdMatter == performances.Key &&
                                                                          x.IdSpeciality == _group.IdSpeciality &&
                                                                          x.IdSpecialization == _group.IdSpecialization);
                    list.Cells[4, col].Value2 = $"{Helper.MatterById(performances.Key)} ({cource?.HoursCount})";
                    list.Cells[4, col].WrapText = true;
                    var row = 5;
                    foreach (var performance in performances)
                    {
                        var student = Helper.GetStudentById(performance.IdStudent);
                        if (student.IdStudyGroup != _group.IdStudyGroup) continue;
                        list.Range[$"A{row}", t].Value2 = student.ToString();
                        list.Cells[row, col].Value2 = EnumConverter.GetName(performance.Grade);
                        row++;
                    }
                    col++;
                }
            }
            else
            {
                if (semester == null || _student == null) return;
                var report = ReportsBuilder.GetStudentPerformance(_root, semester, _student);
                var xl1 = new Microsoft.Office.Interop.Excel.Application();
                xl1.Visible = true;
                var book = xl1.Workbooks.Add(t);
                var lists = book.Worksheets;
                Worksheet list = lists.Item[1];
                var cell = xl1.Selection.Cells;
                list.Range["C1", t].Value2 = report.Caption;
                list.Range["A3", t].Value2 = "Ф.И.О.:";
                list.Range["B3", t].Value2 = _student.FullName;
                list.Range["H3", t].Value2 = "Группа:";
                list.Range["I3", t].Value2 = Helper.StudyGroupById(_student.IdStudyGroup);
                list.Range["A6", t].Value2 = report.ReportColumns[0].Text;
                list.Range["H6", t].Value2 = report.ReportColumns[1].Text;
                for (var i = 0; i < report.ReportRows.Count; i++)
                {
                    list.Range[$"A{i + 8}", t].Value2 = report.ReportRows[i].Items[0];
                    list.Range[$"H{i + 8}", t].Value2 = report.ReportRows[i].Items[1];
                }
            }
            Close();
        }
    }
}
