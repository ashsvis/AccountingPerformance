using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AccountingPerformanceModel
{
    /// <summary>
    /// Класс-помощник
    /// </summary>
    public static class Helper
    {
        private static Root _root;

        /// <summary>
        /// Запоминаем ссылку на корневой объект модели
        /// </summary>
        /// <param name="root"></param>
        public static void DefineRoot(Root root)
        {
            _root = root;
        }

        /// <summary>
        /// Строка подключения кбазе данных, добавлено 29.06.2019
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// Создание картинки из массива байт
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public static Image CreateImage(byte[] imageData)
        {
            Image image;
            using (MemoryStream inStream = new MemoryStream())
            {
                inStream.Write(imageData, 0, imageData.Length);
                image = Bitmap.FromStream(inStream);
            }
            return image;
        }

        /// <summary>
        /// Создание массива байт из картинки
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] CreateByteArray(Image image)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                image.Save(outStream, System.Drawing.Imaging.ImageFormat.Png);
                return outStream.ToArray();
            }
        }

        /// <summary>
        /// Получаем название семестра по его Id
        /// </summary>
        /// <param name="idSemester"></param>
        /// <returns></returns>
        public static string SemesterById(Guid idSemester)
        {
            var semester = _root.Semesters.FirstOrDefault(item => item.IdSemester == idSemester);
            return semester != null ? semester.ToString() : idSemester.ToString();
        }

        /// <summary>
        /// Определяем, что семестр используется в других таблицах
        /// </summary>
        /// <param name="idSemester"></param>
        /// <returns></returns>
        public static bool SemesterUsed(Guid idSemester)
        {
            return _root.Performances.Any(item => item.IdSemester == idSemester);
        }


        /// <summary>
        /// Определяем, что успеваемость используется в других таблицах
        /// </summary>
        /// <param name="idPerformance"></param>
        /// <returns></returns>
        public static bool PerformanceUsed(Guid idPerformance)
        {
            return false;
        }

        /// <summary>
        /// Получаем название группы по её Id
        /// </summary>
        /// <param name="idStudyGroup"></param>
        /// <returns></returns>
        public static string StudyGroupById(Guid idStudyGroup)
        {
            var agroup = _root.StudyGroups.FirstOrDefault(item => item.IdStudyGroup == idStudyGroup);
            return agroup != null ? agroup.ToString() : idStudyGroup.ToString();
        }

        /// <summary>
        /// Получаем название предмета по его Id
        /// </summary>
        /// <param name="idMatter"></param>
        /// <returns></returns>
        public static string MatterById(Guid idMatter)
        {
            var matter = _root.Matters.FirstOrDefault(item => item.IdMatter == idMatter);
            return matter != null ? matter.ToString() : idMatter.ToString();
        }

        /// <summary>
        /// Определяем, что предмет используется в других таблицах
        /// </summary>
        /// <param name="idMatter"></param>
        /// <returns></returns>
        public static bool MatterUsed(Guid idMatter)
        {
            return _root.MattersCourses.Any(item => item.IdMatter == idMatter) ||
                   _root.Performances.Any(item => item.IdMatter == idMatter) ||
                   _root.Teachers.Any(item => item.IdMatter == idMatter) ;
        }

        /// <summary>
        /// Получаем имя специальности по его Id
        /// </summary>
        /// <param name="idSpeciality"></param>
        /// <returns></returns>
        public static string SpecialityById(Guid idSpeciality)
        {
            var speciality = _root.Specialities.FirstOrDefault(item => item.IdSpeciality == idSpeciality);
            return speciality != null ? speciality.ToString() : idSpeciality.ToString();
        }

        /// <summary>
        /// Определяем, что специальность используется в других таблицах
        /// </summary>
        /// <param name="idSpeciality"></param>
        /// <returns></returns>
        public static bool SpecialityUsed(Guid idSpeciality)
        {
            return _root.Specializations.Any(item => item.IdSpeciality == idSpeciality) ||
                   _root.StudyGroups.Any(item => item.IdSpeciality == idSpeciality) ||
                   _root.Students.Any(item => item.IdSpeciality == idSpeciality) ||
                   _root.MattersCourses.Any(item => item.IdSpeciality == idSpeciality);
        }

        /// <summary>
        /// Получаем имя специальности по его Id
        /// </summary>
        /// <param name="idSpecialization"></param>
        /// <returns></returns>
        public static string SpecializationById(Guid idSpecialization)
        {
            var specialization = _root.Specializations.FirstOrDefault(item => item.IdSpecialization == idSpecialization);
            return specialization != null ? specialization.ToString() : idSpecialization.ToString();
        }

        /// <summary>
        /// Определяем, что специализация используется в других таблицах
        /// </summary>
        /// <param name="idSpecialization"></param>
        /// <returns></returns>
        public static bool SpecializationUsed(Guid idSpecialization)
        {
            return _root.StudyGroups.Any(item => item.IdSpecialization == idSpecialization) ||
                   _root.MattersCourses.Any(item => item.IdSpecialization == idSpecialization) ||
                   _root.Students.Any(item => item.IdSpecialization == idSpecialization);
        }

        /// <summary>
        /// Определяем, что курс используется в других таблицах
        /// </summary>
        /// <param name="idMattersCourse"></param>
        /// <returns></returns>
        public static bool MattersCourseUsed(Guid idMattersCourse)
        {
            return false;
        }

        /// <summary>
        /// Получаем название студента по его Id
        /// </summary>
        /// <param name="idStudent"></param>
        /// <returns></returns>
        public static string StudentById(Guid idStudent)
        {
            var student = _root.Students.FirstOrDefault(item => item.IdStudent == idStudent);
            return student != null ? student.ToString() : idStudent.ToString();
        }

        /// <summary>
        /// Получаем студента по его Id
        /// </summary>
        /// <param name="idStudent"></param>
        /// <returns></returns>
        public static Student GetStudentById(Guid idStudent)
        {
            return _root.Students.FirstOrDefault(item => item.IdStudent == idStudent);
        }

        /// <summary>
        /// Получаем Id группы студента по его Id
        /// </summary>
        /// <param name="idStudent"></param>
        /// <returns></returns>
        public static Guid GetStudentGroupId(Guid idStudent)
        {
            var student = _root.Students.FirstOrDefault(item => item.IdStudent == idStudent);
            return student != null ? student.IdStudyGroup : Guid.Empty;
        }

        /// <summary>
        /// Определяем, что данные студента используются в других таблицах
        /// </summary>
        /// <param name="idStudent"></param>
        /// <returns></returns>
        public static bool StudentUsed(Guid idStudent)
        {
            return _root.Performances.Any(item => item.IdStudent == idStudent);
        }

        /// <summary>
        /// Определяем, что группа используется в других таблицах
        /// </summary>
        /// <param name="idStudyGroup"></param>
        /// <returns></returns>
        public static bool StudyGroupUsed(Guid idStudyGroup)
        {
            return _root.Students.Any(item => item.IdStudyGroup == idStudyGroup);
        }

        /// <summary>
        /// Получаем группу по её Id
        /// </summary>
        /// <param name="idStudyGroup"></param>
        /// <returns></returns>
        public static StudyGroup GetStudyGroupById(Guid idStudyGroup)
        {
            return _root.StudyGroups.FirstOrDefault(item => item.IdStudyGroup == idStudyGroup);
        }

    }
}
