using System;

namespace CSVGenerator.Model
{
    public class PersonModel
    {
        [Core.CSVColumn("ID", 0)]
        public int Id { get; set; }

        [Core.CSVColumn("Name", 1, ValueIfNull = "Unnamed ciclyst")]
        public string Name { get; set; }

        [Core.CSVColumn("Birthdate", 3, Format = Core.CSVGenerator.DATE_FORMAT)]
        public DateTime BirthDate { get; set; }

        [Core.CSVColumn("Salary", 2, Format = Core.CSVGenerator.DECIMAL_FORMAT)]
        public decimal Salary { get; set; }

        [Core.CSVColumn("Age", 4)]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                return BirthDate > today.AddYears(-age) ? --age : age;
            }
        }
    }
}
