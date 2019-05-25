using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Serializable]
    [Description("Специализация")]
    public class Specialization : IComparable<Specialization>
    {
        public Guid IdSpecialization { get; set; } = Guid.NewGuid();

        [Description("Наименование специализации"), TextSize(200), DataNotEmpty]
        public string Name { get; set; }

        [Description("Специальность"), DataLookup("IdSpeciality", "Specialities"), TableBrowsable(false), TableFilterable]
        public Guid IdSpeciality { get; set; }

        public int CompareTo(Specialization other)
        {
            return string.Compare(this.ToString(), other.ToString());
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    [Serializable]
    [Description("Специализации")]
    public class Specializations : List<Specialization>
    {
        [NonSerialized]
        public bool Changed;

        public new void Add(Specialization item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Специализация \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            Changed = true;
        }

        public void ChangeTo(Specialization old, Specialization anew)
        {
            if (base.FindAll(x => x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Специализация \"{anew}\" уже существует!");
            old.Name = anew.Name;
            old.IdSpeciality = anew.IdSpeciality;
            base.Sort();
            Changed = true;
        }

        public new void Remove(Specialization item)
        {
            if (Helper.SpecializationUsed(item.IdSpecialization))
                throw new Exception($"Специализация \"{item}\" ещё используется!");
            base.Remove(item);
            Changed = true;
        }

        public List<Specialization> FilteredBySpeciality(Guid idSpeciality)
        {
            return this.Where(item => item.IdSpeciality == idSpeciality).ToList();
        }

    }
}
