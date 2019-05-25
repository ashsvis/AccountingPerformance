using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Serializable]
    [Description("Учебная группа")]
    public class StudyGroup : IComparable<StudyGroup>
    {
        public Guid IdStudyGroup { get; set; } = Guid.NewGuid();

        [Description("Номер группы"), TextSize(50), DataNotEmpty]
        public string Number { get; set; }

        [Description("Срок обучения"), DataRange(5.0)]
        public Single TrainingPeriod { get; set; }

        [Description("Специальность"), DataLookup("IdSpeciality", "Specialities"), TableBrowsable(false), TableFilterable]
        public Guid IdSpeciality { get; set; }

        [Description("Специализация"), DataLookup("IdSpecialization", "Specializations"), TableBrowsable(false), TableFilterable]
        public Guid IdSpecialization { get; set; }

        public int CompareTo(StudyGroup other)
        {
            return string.Compare(this.ToString(), other.ToString());
        }

        public override string ToString()
        {
            return $"{Number}";
        }
    }

    [Serializable]
    [Description("Учебные группы")]
    public class StudyGroups : List<StudyGroup>
    {
        [NonSerialized]
        public bool Changed;

        public new void Add(StudyGroup item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Группа \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            Changed = true;
        }

        public void ChangeTo(StudyGroup old, StudyGroup anew)
        {
            if (base.FindAll(x => x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Группа \"{anew}\" уже существует!");
            old.Number = anew.Number;
            old.TrainingPeriod = anew.TrainingPeriod;
            old.IdSpeciality = anew.IdSpeciality;
            old.IdSpecialization = anew.IdSpecialization;
            base.Sort();
            Changed = true;
        }

        public new void Remove(StudyGroup item)
        {
            if (Helper.StudyGroupUsed(item.IdSpecialization))
                throw new Exception($"Группа \"{item}\" ещё используется!");
            base.Remove(item);
            Changed = true;
        }

        public List<StudyGroup> FilteredBySpecialityAndSpecialization(Guid idSpeciality, Guid idSpecialization)
        {
            return this.Where(item => item.IdSpeciality == idSpeciality && item.IdSpecialization == idSpecialization).ToList();
        }
    }

}
