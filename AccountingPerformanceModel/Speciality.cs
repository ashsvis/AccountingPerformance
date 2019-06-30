using System;
using System.Collections.Generic;
using System.ComponentModel;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Serializable]
    [Description("Специальность")]
    public class Speciality : IComparable<Speciality>
    {
        public Guid IdSpeciality { get; set; } = Guid.NewGuid();

        [Description("Наименование специальности"), TextSize(200), DataNotEmpty]
        public string Name { get; set; }

        [Description("Номер")]
        public int Number { get; set; }

        public int CompareTo(Speciality other)
        {
            return string.Compare(this.ToString(), other.ToString());
        }

        public override string ToString()
        {
            return $"{Name} ({Number})";
        }
    }

    [Serializable]
    [Description("Специальности")]
    public class Specialities : List<Speciality>
    {
        [NonSerialized]
        public bool Loaded;

        // -- [NonSerialized]
        // -- public bool Changed;

        public new void Add(Speciality item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Специальность \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdSpeciality", "P" + item.IdSpeciality.ToString() },
                        { "Name", item.Name },
                        { "Number", item.Number }
                    };
            server.InsertInto("Specialities", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public void ChangeTo(Speciality old, Speciality anew)
        {
            if (old.IdSpeciality != anew.IdSpeciality &&
                base.FindAll(x => x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Специальность \"{anew}\" уже существует!");
            old.Name = anew.Name;
            old.Number = anew.Number;
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdSpeciality", "P" + anew.IdSpeciality.ToString() },
                        { "Name", anew.Name },
                        { "Number", anew.Number }
                    };
            server.UpdateInto("Specialities", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public new void Remove(Speciality item)
        {
            if (Helper.SpecialityUsed(item.IdSpeciality))
                throw new Exception($"Специальность \"{item}\" ещё используется!");
            base.Remove(item);
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdSpeciality", "P" + item.IdSpeciality.ToString() },
                    };
            server.DeleteInto("Specialities", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }
    }
}
