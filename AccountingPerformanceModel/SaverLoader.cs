using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace AccountingPerformanceModel
{
    /// <summary>
    /// Класс поддержки чтения/записи конфигурации в файл на локальном диске
    /// </summary>
    public static class SaverLoader
    {
        /// <summary>
        /// Метод загрузки сохранённой ранее конфигурации из локального файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Root LoadFromFile(string fileName)
        {
            using (var fs = File.OpenRead(fileName))
            using (var zip = new GZipStream(fs, CompressionMode.Decompress))
            {
                var formatter = new BinaryFormatter();
                return (Root)formatter.Deserialize(zip);
            }
        }

        /// <summary>
        /// Метод сохранения конфигурации в файл на локальном диске
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="root"></param>
        public static void SaveToFile(string fileName, Root root)
        {
            using (var fs = File.Create(fileName))
            using (var zip = new GZipStream(fs, CompressionMode.Compress))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(zip, root);
            }
        }

        /// <summary>
        /// Метод загрузки сохранённой ранее конфигурации из базы данных
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static Root LoadFromBase(string connection)
        {
            var root = new Root();
            var server = new OleDbServer { Connection = connection };
            // предметы
            var dataSet = server.GetRows("Matters");
            if (dataSet.Tables.Count > 0)
                foreach (var row in dataSet.Tables[0].Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Length != 2) continue;
                    root.Matters.Add(new Matter
                    {
                        IdMatter = Guid.Parse(row.ItemArray[0].ToString().Substring(1)),
                        Name = row.ItemArray[1].ToString()
                    });
                }
            root.Matters.Changed = false;
            OperationResult = server.LastError;
            if (!string.IsNullOrWhiteSpace(OperationResult)) return root;
            // специальности
            dataSet = server.GetRows("Specialities");
            if (dataSet.Tables.Count > 0)
                foreach (var row in dataSet.Tables[0].Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Length != 3) continue;
                    root.Specialities.Add(new Speciality
                    {
                        IdSpeciality = Guid.Parse(row.ItemArray[0].ToString().Substring(1)),
                        Name = row.ItemArray[1].ToString(),
                        Number = int.Parse(row.ItemArray[2].ToString())
                    });
                }
            root.Specialities.Changed = false;
            OperationResult = server.LastError;
            if (!string.IsNullOrWhiteSpace(OperationResult)) return root;
            // специализации
            dataSet = server.GetRows("Specializations");
            if (dataSet.Tables.Count > 0)
                foreach (var row in dataSet.Tables[0].Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Length != 3) continue;
                    root.Specializations.Add(new Specialization
                    {
                        IdSpecialization = Guid.Parse(row.ItemArray[0].ToString().Substring(1)),
                        Name = row.ItemArray[1].ToString(),
                        IdSpeciality = Guid.Parse(row.ItemArray[2].ToString().Substring(1))
                    });
                }
            root.Specializations.Changed = false;
            OperationResult = server.LastError;
            if (!string.IsNullOrWhiteSpace(OperationResult)) return root;
            // курсы предметов
            dataSet = server.GetRows("MattersCourses");
            if (dataSet.Tables.Count > 0)
                foreach (var row in dataSet.Tables[0].Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Length != 7) continue;
                    root.MattersCourses.Add(new MattersCourse
                    {
                        IdMattersCourse = Guid.Parse(row.ItemArray[0].ToString().Substring(1)),
                        IdSpeciality = Guid.Parse(row.ItemArray[1].ToString().Substring(1)),
                        IdSpecialization = Guid.Parse(row.ItemArray[2].ToString().Substring(1)),
                        IdMatter = Guid.Parse(row.ItemArray[3].ToString().Substring(1)),
                        CourseType = (CourseType)Enum.Parse(typeof(CourseType), row.ItemArray[4].ToString()),
                        RatingSystem = (RatingSystem)Enum.Parse(typeof(RatingSystem), row.ItemArray[5].ToString()),
                        HoursCount = float.Parse(row.ItemArray[6].ToString())
                    });
                }
            root.MattersCourses.Changed = false;
            OperationResult = server.LastError;
            if (!string.IsNullOrWhiteSpace(OperationResult)) return root;
            // семестры
            dataSet = server.GetRows("Semesters");
            if (dataSet.Tables.Count > 0)
                foreach (var row in dataSet.Tables[0].Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Length != 2) continue;
                    root.Semesters.Add(new Semester
                    {
                        IdSemester = Guid.Parse(row.ItemArray[0].ToString().Substring(1)),
                        Number = int.Parse(row.ItemArray[1].ToString())
                    });
                }
            root.Semesters.Changed = false;
            OperationResult = server.LastError;
            if (!string.IsNullOrWhiteSpace(OperationResult)) return root;
            // учебные группы
            dataSet = server.GetRows("StudyGroups");
            if (dataSet.Tables.Count > 0)
                foreach (var row in dataSet.Tables[0].Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Length != 5) continue;
                    root.StudyGroups.Add(new StudyGroup
                    {
                        IdStudyGroup = Guid.Parse(row.ItemArray[0].ToString().Substring(1)),
                        Number = row.ItemArray[1].ToString(),
                        TrainingPeriod = float.Parse(row.ItemArray[2].ToString()),
                        IdSpeciality = Guid.Parse(row.ItemArray[3].ToString().Substring(1)),
                        IdSpecialization = Guid.Parse(row.ItemArray[4].ToString().Substring(1))
                    });
                }
            root.StudyGroups.Changed = false;
            OperationResult = server.LastError;
            if (!string.IsNullOrWhiteSpace(OperationResult)) return root;
            // успеваемости
            dataSet = server.GetRows("Performances");
            if (dataSet.Tables.Count > 0)
                foreach (var row in dataSet.Tables[0].Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Length != 5) continue;
                    root.Performances.Add(new Performance
                    {
                        IdPerformance = Guid.Parse(row.ItemArray[0].ToString().Substring(1)),
                        IdSemester = Guid.Parse(row.ItemArray[1].ToString().Substring(1)),
                        IdMatter = Guid.Parse(row.ItemArray[2].ToString().Substring(1)),
                        Grade = (Grade)Enum.Parse(typeof(Grade), row.ItemArray[3].ToString()),
                        IdStudent = Guid.Parse(row.ItemArray[4].ToString().Substring(1))
                    });
                }
            root.Performances.Changed = false;
            OperationResult = server.LastError;
            if (!string.IsNullOrWhiteSpace(OperationResult)) return root;
            // студенты
            dataSet = server.GetRows("Students");
            if (dataSet.Tables.Count > 0)
                foreach (var row in dataSet.Tables[0].Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Length != 13) continue;
                    var buff = (byte[])row.ItemArray[9];
                    root.Students.Add(new Student
                    {
                        IdStudent = Guid.Parse(row.ItemArray[0].ToString().Substring(1)),
                        FullName = row.ItemArray[1].ToString(),
                        BirthDay = DateTime.Parse(row.ItemArray[2].ToString()),
                        EducationCertificate = row.ItemArray[3].ToString(),
                        ReceiptDate = DateTime.Parse(row.ItemArray[4].ToString()),
                        Address = row.ItemArray[5].ToString(),
                        PhoneNumber = row.ItemArray[6].ToString(),
                        SocialStatus = row.ItemArray[7].ToString(),
                        Notes = row.ItemArray[8].ToString(),
                        Photo = buff,
                        IdSpeciality = Guid.Parse(row.ItemArray[10].ToString().Substring(1)),
                        IdSpecialization = Guid.Parse(row.ItemArray[11].ToString().Substring(1)),
                        IdStudyGroup = Guid.Parse(row.ItemArray[12].ToString().Substring(1))
                    });
                }
            root.Students.Changed = false;
            OperationResult = server.LastError;
            if (!string.IsNullOrWhiteSpace(OperationResult)) return root;

            return root;
        }

        /// <summary>
        /// Свойство для хранения результата (текста ошибки) последней операции
        /// </summary>
        public static string OperationResult { get; private set; } = string.Empty;

        /// <summary>
        /// Метод сохранения конфигурации в базу данных
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="root"></param>
        public static void SaveToBase(string connection, Root root)
        {
            var server = new OleDbServer { Connection = connection };
            // предметы
            if (root.Matters.Changed)
            {
                server.DeleteInto("Matters");
                OperationResult = server.LastError;
                foreach (var item in root.Matters)
                {
                    var columns = new Dictionary<string, object>
                    {
                        { "IdMatter", "P" + item.IdMatter.ToString() },
                        { "Name", item.Name }
                    };
                    if (server.KeyRecordExists("Matters", "IdMatter", item.IdMatter))
                        server.UpdateInto("Matters", columns);
                    else
                        server.InsertInto("Matters", columns);
                    OperationResult = server.LastError;
                }
                root.Matters.Changed = false;
            }
            // специальности
            if (root.Specialities.Changed)
            {
                server.DeleteInto("Specialities");
                OperationResult = server.LastError;
                foreach (var item in root.Specialities)
                {
                    var columns = new Dictionary<string, object>
                    {
                        { "IdSpeciality", "P" + item.IdSpeciality.ToString() },
                        { "Name", item.Name },
                        { "Number", item.Number }
                    };
                    if (server.KeyRecordExists("Specialities", "IdSpeciality", item.IdSpeciality))
                        server.UpdateInto("Specialities", columns);
                    else
                        server.InsertInto("Specialities", columns);
                    OperationResult = server.LastError;
                }
                root.Specialities.Changed = false;
            }
            // специализации
            if (root.Specializations.Changed)
            {
                server.DeleteInto("Specializations");
                OperationResult = server.LastError;
                foreach (var item in root.Specializations)
                {
                    var columns = new Dictionary<string, object>
                    {
                        { "IdSpecialization", "P" + item.IdSpecialization.ToString() },
                        { "Name", item.Name },
                        { "IdSpeciality", "P" + item.IdSpeciality.ToString() }
                    };
                    if (server.KeyRecordExists("Specializations", "IdSpecialization", item.IdSpecialization))
                        server.UpdateInto("Specializations", columns);
                    else
                        server.InsertInto("Specializations", columns);
                    OperationResult = server.LastError;
                }
                root.Specializations.Changed = false;
            }
            // курсы предметов
            if (root.MattersCourses.Changed)
            {
                server.DeleteInto("MattersCourses");
                OperationResult = server.LastError;
                foreach (var item in root.MattersCourses)
                {
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
                    if (server.KeyRecordExists("MattersCourses", "IdMattersCourse", item.IdMattersCourse))
                        server.UpdateInto("MattersCourses", columns);
                    else
                        server.InsertInto("MattersCourses", columns);
                    OperationResult = server.LastError;
                }
                root.MattersCourses.Changed = false;
            }
            // семестры
            if (root.Semesters.Changed)
            {
                server.DeleteInto("Semesters");
                OperationResult = server.LastError;
                foreach (var item in root.Semesters)
                {
                    var columns = new Dictionary<string, object>
                    {
                        { "IdSemester", "P" + item.IdSemester.ToString() },
                        { "Number", item.Number }
                    };
                    if (server.KeyRecordExists("Semesters", "IdSemester", item.IdSemester))
                        server.UpdateInto("Semesters", columns);
                    else
                        server.InsertInto("Semesters", columns);
                    OperationResult = server.LastError;
                }
                root.Semesters.Changed = false;
            }
            // учебные группы
            if (root.StudyGroups.Changed)
            {
                server.DeleteInto("StudyGroups");
                OperationResult = server.LastError;
                foreach (var item in root.StudyGroups)
                {
                    var columns = new Dictionary<string, object>
                    {
                        { "IdStudyGroup", "P" + item.IdStudyGroup.ToString() },
                        { "Number", item.Number },
                        { "TrainingPeriod", item.TrainingPeriod },
                        { "IdSpeciality", "P" + item.IdSpeciality.ToString() },
                        { "IdSpecialization", "P" + item.IdSpecialization.ToString() }
                    };
                    if (server.KeyRecordExists("StudyGroups", "IdStudyGroup", item.IdStudyGroup))
                        server.UpdateInto("StudyGroups", columns);
                    else
                        server.InsertInto("StudyGroups", columns);
                    OperationResult = server.LastError;
                }
                root.StudyGroups.Changed = false;
            }
            // успеваемости
            if (root.Performances.Changed)
            {
                server.DeleteInto("Performances");
                OperationResult = server.LastError;
                foreach (var item in root.Performances)
                {
                    var columns = new Dictionary<string, object>
                    {
                        { "IdPerformance", "P" + item.IdPerformance.ToString() },
                        { "IdSemester", "P" + item.IdSemester.ToString() },
                        { "IdMatter", "P" + item.IdMatter.ToString() },
                        { "Grade", item.Grade },
                        { "IdStudent", "P" + item.IdStudent.ToString() }
                    };
                    if (server.KeyRecordExists("Performances", "IdPerformance", item.IdPerformance))
                        server.UpdateInto("Performances", columns);
                    else
                        server.InsertInto("Performances", columns);
                    OperationResult = server.LastError;
                }
                root.Performances.Changed = false;
            }
            // студенты
            if (root.Students.Changed)
            {
                server.DeleteInto("Students");
                OperationResult = server.LastError;
                foreach (var item in root.Students)
                {
                    var columns = new Dictionary<string, object>
                    {
                        { "IdStudent", "P" + item.IdStudent.ToString() },
                        { "FullName", item.FullName },
                        { "BirthDay", item.BirthDay },
                        { "EducationCertificate", item.EducationCertificate },
                        { "ReceiptDate", item.ReceiptDate },
                        { "Address", item.Address },
                        { "PhoneNumber", item.PhoneNumber },
                        { "SocialStatus", item.SocialStatus },
                        { "Notes", item.Notes },
                        { "Photo", item.Photo ?? new byte[] { } },
                        { "IdSpeciality", "P" + item.IdSpeciality.ToString() },
                        { "IdSpecialization", "P" + item.IdSpecialization.ToString() },
                        { "IdStudyGroup", "P" + item.IdStudyGroup.ToString() }
                    };
                    if (server.KeyRecordExists("Students", "IdStudent", item.IdStudent))
                        server.UpdateInto("Students", columns);
                    else
                        server.InsertInto("Students", columns);
                    OperationResult = server.LastError;
                }
                root.Students.Changed = false;
            }
        }

    }
}
