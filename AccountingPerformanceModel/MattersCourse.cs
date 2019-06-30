using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Serializable]
    [Description("Курс предметов")]
    public class MattersCourse : IComparable<MattersCourse>
    {
        public Guid IdMattersCourse { get; set; } = Guid.NewGuid();

        [Description("Специальность"), DataLookup("IdSpeciality", "Specialities"), TableBrowsable(false), TableFilterable]
        public Guid IdSpeciality { get; set; }

        [Description("Специализация"), DataLookup("IdSpecialization", "Specializations"), TableBrowsable(false), TableFilterable]
        public Guid IdSpecialization { get; set; }

        [Description("Наименование предмета"), DataLookup("IdMatter", "Matters"), TextSize(400)]
        public Guid IdMatter { get; set; }

        [Description("Тип курса")]
        public CourseType CourseType { get; set; }

        [Description("Система оценки")]
        public RatingSystem RatingSystem { get; set; }

        [Description("Кол-во часов/недель")]
        public Single HoursCount { get; set; }

        public int CompareTo(MattersCourse other)
        {
            return string.Compare(this.ToString(), other.ToString());
        }

        public override string ToString()
        {
            return $"{Helper.MatterById(this.IdMatter)} ({this.CourseType}/{this.RatingSystem})\n" +
                $"{Helper.SpecialityById(this.IdSpeciality)} ({Helper.SpecializationById(this.IdSpecialization)})";
        }
    }

    [Serializable]
    [Description("Курсы предметов")]
    public class MattersCourses : List<MattersCourse>
    {
        [NonSerialized]
        public bool Loaded;

        // -- [NonSerialized]
        // -- public bool Changed;

        public new void Add(MattersCourse item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Курс \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdMattersCourse", "P" + item.IdMatter.ToString() },
                        { "IdSpeciality", "P" + item.IdSpeciality.ToString() },
                        { "IdSpecialization", "P" + item.IdSpecialization.ToString() },
                        { "IdMatter", "P" + item.IdMatter.ToString() },
                        { "CourseType", item.CourseType },
                        { "RatingSystem", item.RatingSystem },
                        { "HoursCount", item.HoursCount }
                    };
            server.InsertInto("MattersCourses", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public void ChangeTo(MattersCourse old, MattersCourse anew)
        {
            if (old.IdMattersCourse != anew.IdMattersCourse &&
                base.FindAll(x => x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Курс \"{anew}\" уже существует!");
            old.IdSpeciality = anew.IdSpeciality;
            old.IdSpecialization = anew.IdSpecialization;
            old.IdMatter = anew.IdMatter;
            old.CourseType = anew.CourseType;
            old.RatingSystem = anew.RatingSystem;
            old.HoursCount = anew.HoursCount;
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdMattersCourse", "P" + anew.IdMatter.ToString() },
                        { "IdSpeciality", "P" + anew.IdSpeciality.ToString() },
                        { "IdSpecialization", "P" + anew.IdSpecialization.ToString() },
                        { "IdMatter", "P" + anew.IdMatter.ToString() },
                        { "CourseType", anew.CourseType },
                        { "RatingSystem", anew.RatingSystem },
                        { "HoursCount", anew.HoursCount }
                    };
            server.UpdateInto("MattersCourses", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public new void Remove(MattersCourse item)
        {
            if (Helper.MattersCourseUsed(item.IdMattersCourse))
                throw new Exception($"Курс \"{item}\" ещё используется!");
            base.Remove(item);
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdMattersCourse", "P" + item.IdMatter.ToString() },
                    };
            server.DeleteInto("MattersCourses", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public List<MattersCourse> FilteredBySpecialityAndSpecialization(Guid idSpeciality, Guid idSpecialization)
        {
            return this.Where(item => item.IdSpeciality == idSpeciality && item.IdSpecialization == idSpecialization).ToList();
        }
    }
}
