using System;
using System.Collections;

namespace AccountingPerformanceModel
{
    /// <summary>
    /// Корневой класс модели, содержит списки (таблицы) сущностей
    /// </summary>
    [Serializable]
    public class Root
    {
        public Matters Matters { get; set; }
        public Specialities Specialities { get; set; }
        public Specializations Specializations { get; set; }
        public MattersCourses MattersCourses { get; set; }
        public StudyGroups StudyGroups { get; set; }
        public Students Students { get; set; }
        public Performances Performances { get; set; }
        public Semesters Semesters { get; set; }

        public Root()
        {
            RegistryTables();
        }

        public void RegistryTables()
        {
            Tables.Clear();

            if (Matters == null) Matters = new Matters();
            RegistryTable("Matters", new Matter(), Matters);
            if (Specialities == null) Specialities = new Specialities();
            RegistryTable("Specialities", new Speciality(), Specialities);
            if (Specializations == null) Specializations = new Specializations();
            RegistryTable("Specializations", new Specialization(), Specializations);
            if (MattersCourses == null) MattersCourses = new MattersCourses();
            RegistryTable("MattersCourses", new MattersCourse(), MattersCourses);
            if (StudyGroups == null) StudyGroups = new StudyGroups();
            RegistryTable("StudyGroups", new StudyGroup(), StudyGroups);
            if (Students == null) Students = new Students();
            RegistryTable("Students", new Student(), Students);
            if (Performances == null) Performances = new Performances();
            RegistryTable("Performances", new Performance(), Performances);
            if (Semesters == null) Semesters = new Semesters();
            RegistryTable("Semesters", new Semester(), Semesters);

        }

        public Hashtable Tables { get; private set; } = new Hashtable();

        private void RegistryTable(string name, object item, object table)
        {
            if (Tables.ContainsKey(name)) return;
            Tables[name] = new TableInfo
            {
                TableName = name,
                Table = table,
                Item = item
            };
        }
    }

    [Serializable]
    public class TableInfo
    {
        public string TableName { get; set; }
        public object Table { get; set; }
        public object Item { get; set; }
    }
}
