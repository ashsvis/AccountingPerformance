using System;
using System.Collections.Generic;
using System.ComponentModel;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Serializable]
    [Description("Предмет")]
    public class Matter : IComparable<Matter>
    {
        public Guid IdMatter { get; set; } = Guid.NewGuid();

        [Description("Название предмета"), TextSize(200), DataNotEmpty]
        public string Name { get; set; }

        public int CompareTo(Matter other)
        {
            return string.Compare(this.ToString(), other.ToString());
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    [Serializable]
    [Description("Предметы")]
    public class Matters : List<Matter>
    {
        [NonSerialized]
        public bool Loaded;

        // -- [NonSerialized]
        // -- public bool Changed;

        public new void Add(Matter item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Предмет \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdMatter", "P" + item.IdMatter.ToString() },
                        { "Name", item.Name }
                    };
            server.InsertInto("Matters", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public void ChangeTo(Matter old, Matter anew)
        {
            if (old.IdMatter != anew.IdMatter &&
                base.FindAll(x => x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Предмет \"{anew}\" уже существует!");
            old.Name = anew.Name;
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdMatter", "P" + anew.IdMatter.ToString() },
                        { "Name", anew.Name }
                    };
            server.UpdateInto("Matters", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public new void Remove(Matter item)
        {
            if (Helper.MatterUsed(item.IdMatter))
                throw new Exception($"Предмет \"{item}\" ещё используется!");
            base.Remove(item);
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdMatter", "P" + item.IdMatter.ToString() },
                    };
            server.DeleteInto("Matters", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }
    }
}
