using System;
using System.ComponentModel;

namespace AccountingPerformanceModel
{
    [Serializable]
    public enum RatingSystem
    {
        [Description("экзамен")]
        Экзамен,
        [Description("зачет")]
        Зачёт
    }
}
