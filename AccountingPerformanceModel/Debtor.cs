using System;
using System.Collections.Generic;
using System.ComponentModel;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Description("Должник")]
    public class Debtor
    {
        public Guid IdDebtor { get; set; } = Guid.NewGuid();


        [Description("Ф.И.О."), DataLookup("IdStudent", "Students")]
        public Guid IdStudent { get; set; }

        [Description("Группа"), DataLookup("IdStudyGroup", "StudyGroups")]
        public Guid IdStudyGroup { get; set; }

        [Description("Семестр"), DataLookup("IdSemester", "Semesters")]
        public Guid IdSemester { get; set; }

        [Description("Предмет"), DataLookup("IdMatter", "Matters")]
        public Guid IdMatter { get; set; }
    }

    [Description("Должники")]
    public class Debtors : List<Debtor> { }
}
