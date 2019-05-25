using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewGenerator;

namespace AccountingPerformanceModel
{
    [Serializable]
    [Description("Преподаватель")]
    public class Teacher : IComparable<Teacher>
    {
        public Guid IdTeacher { get; set; } = Guid.NewGuid();

        [Description("Ф.И.О."), TextSize(300), DataNotEmpty]
        public string FullName { get; set; }

        [Description("Предмет"), DataLookup("IdMatter", "Matters"), TextSize(400)]
        public Guid IdMatter { get; set; }

        [Description("Логин"), TextSize(210)]
        public string Login { get; set; }

        [Description("Пароль"), DataPassword]
        public string Password { get; set; }

        public int CompareTo(Teacher other)
        {
            return string.Compare(this.FullName, other.FullName);
        }

        public override string ToString()
        {
            return $"{FullName}";
        }
    }

    [Serializable]
    [Description("Преподаватели")]
    public class Teachers : List<Teacher>
    {
        [NonSerialized]
        public bool Changed;

        public new void Add(Teacher item)
        {
            if (base.Exists(x => x.ToString().Trim() == item.ToString().Trim()))
                throw new Exception($"Преподаватель \"{item}\" уже существует!");
            base.Add(item);
            base.Sort();
            Changed = true;
        }

        public void ChangeTo(Teacher old, Teacher anew)
        {
            if (base.FindAll(x => x.ToString().Trim() == anew.ToString().Trim()).Count > 0)
                throw new Exception($"Преподаватель \"{anew}\" уже существует!");
            old.FullName = anew.FullName;
            old.IdMatter = anew.IdMatter;
            old.Login = anew.Login;
            old.Password = anew.Password;
            base.Sort();
            Changed = true;
        }

        public new void Remove(Teacher item)
        {
            if (Helper.MatterUsed(item.IdMatter))
                throw new Exception($"Преподаватель \"{item}\" ещё используется!");
            base.Remove(item);
            Changed = true;
        }
    }
}
