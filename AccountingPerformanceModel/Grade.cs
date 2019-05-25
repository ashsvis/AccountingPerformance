using System;
using System.ComponentModel;

namespace AccountingPerformanceModel
{
    [Serializable]
    public enum Grade
    {
        [Description("3")]
        Три,
        [Description("4")]
        Четыре,
        [Description("5")]
        Пять,
        [Description("зачёт")]
        Зачёт,
        [Description("незачёт")]
        Незачёт
    }

}
