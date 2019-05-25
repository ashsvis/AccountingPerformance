﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Serializable]
    [Description("Студент")]
    public class Student : IComparable<Student>
    {
        public Guid IdStudent { get; set; } = Guid.NewGuid();

        [Description("Ф.И.О."), TextSize(300), DataNotEmpty]
        public string FullName { get; set; }

        [Description("Дата рождения")]
        public DateTime BirthDay { get; set; }

        [Description("Аттестат"), DataNotEmpty, TextSize(50)]
        public string EducationCertificate { get; set; }

        [Description("Дата поступления")]
        public DateTime ReceiptDate { get; set; }

        [Description("Адрес"), DataNotEmpty, TextSize(300)]
        public string Address { get; set; }

        [Description("Телефон"), TextSize(50)]
        public string PhoneNumber { get; set; }

        [Description("Социальный статус"), TextSize(50)]
        public string SocialStatus { get; set; }

        [Description("Дополнительная\nинформация"), TableBrowsable(false), TextSize(300, true, 60)]
        public string Notes { get; set; }

        [Description("Фотография"), TableBrowsable(false)]
        public byte[] Photo { get; set; }

        [Description("Специальность"), DataLookup("IdSpeciality", "Specialities"), TableBrowsable(false), TableFilterable]
        public Guid IdSpeciality { get; set; }

        [Description("Специализация"), DataLookup("IdSpecialization", "Specializations"), TableBrowsable(false), TableFilterable]
        public Guid IdSpecialization { get; set; }

        [Description("Учебная группа"), DataLookup("IdStudyGroup", "StudyGroups"), TableBrowsable(false), TableFilterable]
        public Guid IdStudyGroup { get; set; }

        public int CompareTo(Student other)
        {
            return string.Compare(string.Concat(this, $"{BirthDay.ToShortDateString()}"),
                                  string.Concat(other, $"{other.BirthDay.ToShortDateString()}"));
        }

        public override string ToString()
        {
            return $"{FullName}";
        }
    }

    [Serializable]
    [Description("Студенты")]
    public class Students : List<Student>
    {
        [NonSerialized]
        public bool Changed;

        public new void Add(Student item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Студент \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            Changed = true;
        }

        public void ChangeTo(Student old, Student anew)
        {
            if (base.FindAll(x => x.IdStudent != anew.IdStudent &&
                                  x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Студент \"{anew}\" уже существует!");
            old.FullName = anew.FullName;
            old.BirthDay = anew.BirthDay;
            old.EducationCertificate = anew.EducationCertificate;
            old.ReceiptDate = anew.ReceiptDate;
            old.Address = anew.Address;
            old.PhoneNumber = anew.PhoneNumber;
            old.SocialStatus = anew.SocialStatus;
            old.Notes = anew.Notes;
            old.Photo = anew.Photo.DeepClone();
            old.IdSpeciality = anew.IdSpeciality;
            old.IdSpecialization = anew.IdSpecialization;
            old.IdStudyGroup = anew.IdStudyGroup;
            base.Sort();
            Changed = true;
        }

        public new void Remove(Student item)
        {
            if (Helper.StudentUsed(item.IdStudent))
                throw new Exception($"Данные о студенте \"{item}\" ещё используются!");
            base.Remove(item);
            Changed = true;
        }

        public List<Student> FilteredBySpecialityAndSpecialization(Guid idSpeciality, Guid idSpecialization)
        {
            return this.Where(item => item.IdSpeciality == idSpeciality && item.IdSpecialization == idSpecialization).ToList();
        }

        public List<Student> FilteredBySpecialityAndSpecialization(Guid idSpeciality, Guid idSpecialization, Guid idStudyGroup)
        {
            return this.Where(item => item.IdSpeciality == idSpeciality &&
                              item.IdSpecialization == idSpecialization &&
                              item.IdStudyGroup == idStudyGroup).ToList();
        }
    }
}
