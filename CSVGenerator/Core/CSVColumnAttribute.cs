using System;

namespace CSVGenerator.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CSVColumnAttribute : Attribute
    {
        public string HeaderText { get; set; }
        public uint Order { get; set; }
        public string ValueIfNull { get; set; }
        public string Format { get; set; }
        public bool NewLineAfterPrint { get; set; }

        public CSVColumnAttribute(string headerText, uint order)
        {
            HeaderText = headerText;
            Order = order;
        }
    }
}
