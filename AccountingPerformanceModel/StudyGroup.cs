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
        public bool Loaded;

        // -- [NonSerialized]
        // -- public bool Changed;

        public new void Add(StudyGroup item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Группа \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdStudyGroup", "P" + item.IdStudyGroup.ToString() },
                        { "Number", item.Number },
                        { "TrainingPeriod", item.TrainingPeriod },
                        { "IdSpeciality", "P" + item.IdSpeciality.ToString() },
                        { "IdSpecialization", "P" + item.IdSpecialization.ToString() }
                    };
            server.InsertInto("StudyGroups", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public void ChangeTo(StudyGroup old, StudyGroup anew)
        {
            if (old.IdStudyGroup != anew.IdStudyGroup &&
                base.FindAll(x => x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Группа \"{anew}\" уже существует!");
            old.Number = anew.Number;
            old.TrainingPeriod = anew.TrainingPeriod;
            old.IdSpeciality = anew.IdSpeciality;
            old.IdSpecialization = anew.IdSpecialization;
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdStudyGroup", "P" + anew.IdStudyGroup.ToString() },
                        { "Number", anew.Number },
                        { "TrainingPeriod", anew.TrainingPeriod },
                        { "IdSpeciality", "P" + anew.IdSpeciality.ToString() },
                        { "IdSpecialization", "P" + anew.IdSpecialization.ToString() }
                    };
            server.UpdateInto("StudyGroups", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public new void Remove(StudyGroup item)
        {
            if (Helper.StudyGroupUsed(item.IdSpecialization))
                throw new Exception($"Группа \"{item}\" ещё используется!");
            base.Remove(item);
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdStudyGroup", "P" + item.IdStudyGroup.ToString() },
                    };
            server.DeleteInto("StudyGroups", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public List<StudyGroup> FilteredBySpecialityAndSpecialization(Guid idSpeciality, Guid idSpecialization)
        {
            return this.Where(item => item.IdSpeciality == idSpeciality && item.IdSpecialization == idSpecialization).ToList();
        }
    }

}
