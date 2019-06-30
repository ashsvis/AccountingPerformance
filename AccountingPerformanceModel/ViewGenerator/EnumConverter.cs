using System;

namespace ViewGenerator
{
    /// <summary>
    /// Получение описаний элементов перечислений
    /// </summary>
    public static class EnumConverter
    {
        public static string GetName(Enum item)
        {
            object[] attribs = item.GetType()
                .GetField(item.ToString())
                .GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

            if (attribs != null && attribs.Length > 0)
                return ((System.ComponentModel.DescriptionAttribute)attribs[attribs.Length - 1]).Description;

            return item.ToString();
        }
    }
}
