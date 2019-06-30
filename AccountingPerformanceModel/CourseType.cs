using System;
using System.ComponentModel;

namespace AccountingPerformanceModel
{
    [Serializable]
    public enum CourseType
    {
        [Description("лекция")]
        Лекция,
        [Description("практика")]
        Практика,
        [Description("курсовая")]
        Курсовая
    }
}
