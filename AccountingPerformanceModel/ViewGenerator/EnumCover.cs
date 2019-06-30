using System;

namespace ViewGenerator
{
    public class EnumCover
    {
        public Enum Item { get; set; }
        public override string ToString()
        {
            return EnumConverter.GetName(Item);
        }
    }
}
