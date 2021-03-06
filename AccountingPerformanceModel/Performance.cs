﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Serializable]
    [Description("Успеваемость")]
    public class Performance : IComparable<Performance>
    {

        public Guid IdPerformance { get; set; } = Guid.NewGuid();

        [Description("Семестр"), DataLookup("IdSemester", "Semesters"), TableFilterable]
        public Guid IdSemester { get; set; }

        [Description("Предмет"), DataLookup("IdMatter", "Matters"), TextSize(400)]
        public Guid IdMatter { get; set; }

        [Description("Оценка")]
        public Grade Grade { get; set; }

        [Description("Студент"), DataLookup("IdStudent", "Students"), TableBrowsable(false), TableFilterable]
        public Guid IdStudent { get; set; }

        public int CompareTo(Performance other)
        {
            return string.Compare(this.ToString(), other.ToString());
        }

        public override string ToString()
        {
            return $" {Helper.StudentById(this.IdStudent)}, семестр {Helper.SemesterById(this.IdSemester)}, {Helper.MatterById(this.IdMatter)}";
        }
    }

    [Serializable]
    [Description("Успеваемости")]
    public class Performances : List<Performance>
    {
        [NonSerialized]
        public bool Loaded;

        // -- [NonSerialized]
        // -- public bool Changed;

        public new void Add(Performance item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Успеваемость \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdPerformance", "P" + item.IdPerformance.ToString() },
                        { "IdSemester", "P" + item.IdSemester.ToString() },
                        { "IdMatter", "P" + item.IdMatter.ToString() },
                        { "Grade", item.Grade },
                        { "IdStudent", "P" + item.IdStudent.ToString() }
                    };
            server.InsertInto("Performances", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public void ChangeTo(Performance old, Performance anew)
        {
            if (old.IdPerformance != anew.IdPerformance &&
                base.FindAll(x => x.IdStudent != anew.IdStudent &&
                                  x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Успеваемость \"{anew}\" уже существует!");
            old.IdSemester = anew.IdSemester;
            old.IdMatter = anew.IdMatter;
            old.Grade = anew.Grade;
            old.IdStudent = anew.IdStudent;
            base.Sort();
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdPerformance", "P" + anew.IdPerformance.ToString() },
                        { "IdSemester", "P" + anew.IdSemester.ToString() },
                        { "IdMatter", "P" + anew.IdMatter.ToString() },
                        { "Grade", anew.Grade },
                        { "IdStudent", "P" + anew.IdStudent.ToString() }
                    };
            server.UpdateInto("Performances", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public new void Remove(Performance item)
        {
            if (Helper.PerformanceUsed(item.IdPerformance))
                throw new Exception($"Успеваемость \"{item}\" ещё используются!");
            base.Remove(item);
            // -- Changed = true;
            // добавлено 29.06.2019
            if (!Loaded) return;
            var server = new OleDbServer { Connection = Helper.ConnectionString };
            var columns = new Dictionary<string, object>
                    {
                        { "IdPerformance", "P" + item.IdPerformance.ToString() },
                    };
            server.DeleteInto("Performances", columns);
            if (!string.IsNullOrWhiteSpace(server.LastError))
                throw new Exception(server.LastError);
        }

        public List<Performance> FilteredByStudentSemester(Guid idStudent, Guid idSemester)
        {
            return this.Where(item => item.IdStudent == idStudent && item.IdSemester == idSemester).ToList();
        }
    }

}
