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
        public bool Loaded;

        // -- [NonSerialized]
        // -- public bool Changed;

        public new void Add(Specialization item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Специализация \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdSpecialization", "P" + item.IdSpecialization.ToString() },
                        { "Name", item.Name },
                        { "IdSpeciality", "P" + item.IdSpeciality.ToString() }
                    };
            server.InsertInto("Specializations", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public void ChangeTo(Specialization old, Specialization anew)
        {
            if (old.IdSpecialization != anew.IdSpecialization &&
                base.FindAll(x => x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Специализация \"{anew}\" уже существует!");
            old.Name = anew.Name;
            old.IdSpeciality = anew.IdSpeciality;
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdSpecialization", "P" + anew.IdSpecialization.ToString() },
                        { "Name", anew.Name },
                        { "IdSpeciality", "P" + anew.IdSpeciality.ToString() }
                    };
            server.UpdateInto("Specializations", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public new void Remove(Specialization item)
        {
            if (Helper.SpecializationUsed(item.IdSpecialization))
                throw new Exception($"Специализация \"{item}\" ещё используется!");
            base.Remove(item);
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdSpecialization", "P" + item.IdSpecialization.ToString() },
                    };
            server.DeleteInto("Specializations", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public List<Specialization> FilteredBySpeciality(Guid idSpeciality)
        {
            return this.Where(item => item.IdSpeciality == idSpeciality).ToList();
        }

    }
}
