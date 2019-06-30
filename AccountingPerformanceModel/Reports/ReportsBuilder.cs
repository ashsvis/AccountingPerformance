using AccountingPerformanceModel;
using System.Drawing;
using System.Linq;
using ViewGenerator;

namespace Reports
{
    /// <summary>
    /// Построитель отчетов
    /// </summary>
    public static class ReportsBuilder
    {
        /// <summary>
        /// Отчет "Отчёт об успеваемости студента за {semester} семестр"
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static Report GetStudentPerformance(Root root, Semester semester, Student student)
        {
            var caption = $"Отчёт об успеваемости студента за {semester} семестр";
            var report = new Report
            {
                Caption = caption
            };
            report.ReportColumns.Add(new ReportColumn("Предмет", 500), new ReportColumn("Оценка", 200));
            // добавляем строки в отчет
            foreach (var item in root.Performances.Where(x => x.IdSemester == semester.IdSemester && x.IdStudent == student.IdStudent))
            {
                report.ReportRows.Add(0, $"{Helper.MatterById(item.IdMatter)}", 
                                         $"{EnumConverter.GetName(item.Grade)}");
            }
            // определение обработчика печати страницы отчета
            report.PrintPage = (o, e, rect, offset) => 
            {
                SizeF strSize = new SizeF();
                var strPoint = offset;
                // Печать данных студента
                strPoint.X = rect.X + 50;
                var data = new[] { student.ToString(), Helper.GetStudyGroupById(student.IdStudyGroup).ToString() };
                using (var headerfont = new Font("Arial", 12, FontStyle.Bold))
                using (var sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    for (var i = 0; i < data.Length; i++)
                    {
                        var width = i == 0 ? 500 : 200;
                        strSize = e.Graphics.MeasureString(data[i], headerfont);
                        var r = new Rectangle(Point.Ceiling(strPoint),
                            new Size(width, (int)strSize.Height));
                        using (var rowfont = new Font("Arial", 12, FontStyle.Bold))
                        {
                            e.Graphics.DrawString(i == 0 ? "Ф.И.О.:" : "Группа:", rowfont, Brushes.Black, r, sf);
                        }
                        r.Offset(70, 0);
                        e.Graphics.DrawString(data[i], headerfont, Brushes.Red, r, sf);
                        strPoint.X += width;
                    }
                }
                strPoint.Y += strSize.Height + 10;
                // Печать заголовка таблицы
                strPoint.X = rect.X + 50;
                using (var headerfont = new Font("Arial", 12, FontStyle.Bold))
                using (var sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    foreach (var header in report.ReportColumns)
                    {
                        strSize = e.Graphics.MeasureString(header.Text, headerfont);
                        var r = new Rectangle(Point.Ceiling(strPoint),
                            new Size(header.Width, (int)strSize.Height));
                        e.Graphics.DrawString(header.Text, headerfont, Brushes.Black, r, sf);
                        strPoint.X += header.Width;
                    }
                }
                // Печать строк таблицы
                strPoint.Y += strSize.Height + 10;
                using (var rowfont = new Font("Arial", 12, FontStyle.Regular))
                using (var sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    foreach (var row in report.ReportRows)
                    {
                        strPoint.X = rect.X + 50;
                        string value; // здесь будет значение
                        for (var i = 0; i < report.ReportColumns.Count; i++)
                        {
                            value = row.Items[i];
                            var r = new Rectangle(Point.Ceiling(strPoint),
                                new Size(report.ReportColumns[i].Width, (int)strSize.Height));
                            e.Graphics.DrawString(value, rowfont, Brushes.Black, r, sf);
                            strPoint.X += report.ReportColumns[i].Width;
                        }
                        strPoint.Y += strSize.Height;
                    }
                }
            };
            return report;
        }

    }
}
