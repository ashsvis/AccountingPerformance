﻿using System;
using System.ComponentModel;

namespace AccountingPerformanceModel
{
    [Serializable]
    public enum Grade
    {
        [Description("2")]
        Два,
        [Description("3")]
        Три,
        [Description("4")]
        Четыре,
        [Description("5")]
        Пять,
        [Description("зачет")]
        Зачёт,
        [Description("незачет")]
        Незачёт,
        // добавлено новое состояние
        [Description("(не сдавал)")]
        Нет,
    }

}
