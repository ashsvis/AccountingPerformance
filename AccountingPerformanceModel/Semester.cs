using System;
using System.Collections.Generic;
using System.ComponentModel;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Serializable]
    [Description("Семестр")]
    public class Semester : IComparable<Semester>
    {
        public Guid IdSemester { get; set; } = Guid.NewGuid();

        [Description("Номер семестра"), DataRange(1, 12)]
        public int Number { get; set; }

        public int CompareTo(Semester other)
        {
            return this.Number < other.Number ? -1 : this.Number > other.Number ? 1 : 0;
        }

        public override string ToString()
        {
            return $"{Number}";
        }
    }

    [Serializable]
    [Description("Семестры")]
    public class Semesters : List<Semester>
    {
        [NonSerialized]
        public bool Changed;

        public new void Add(Semester item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Семестр \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            Changed = true;
        }

        public void ChangeTo(Semester old, Semester anew)
        {
            if (base.FindAll(x => x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Семестр \"{anew}\" уже существует!");
            old.Number = anew.Number;
            base.Sort();
            Changed = true;
        }

        public new void Remove(Semester item)
        {
            if (Helper.SemesterUsed(item.IdSemester))
                throw new Exception($"Семестр \"{item}\" ещё используется!");
            base.Remove(item);
            Changed = true;
        }
    }
}
