using CSVGenerator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CSVGenerator
{
    public partial class FormMain : Form
    {
        private const string FILE_NAME = "CSV_{0:dd_MM_yyyy_HH_mm_ss}.csv";
        public FormMain()
        {
            InitializeComponent();
        }

        private void m_buttonSelectDirectory_Click(object sender, EventArgs e)
        {
            var dialogResult = m_folderBrowserDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            m_textBoxDirectory.Text = m_folderBrowserDialog.SelectedPath;
            m_buttonGenerateCSV.Enabled = true;
        }

        private void m_buttonGenerateCSV_Click(object sender, EventArgs e)
        {
            var filePath = Path.Combine(m_textBoxDirectory.Text, string.Format(FILE_NAME, DateTime.Now));
            var personList = GenerateData();
            using (var csvGenerator = new Core.CSVGenerator<PersonModel>(filePath))
            {
                csvGenerator.WriteContent(personList);
            }
        }

        private List<PersonModel> GenerateData()
        {
            return new List<PersonModel>(new[]
            {
                new PersonModel()
                {
                    Id = 1,
                    Name = "Lance Armstrong",
                    BirthDate = new DateTime(1971, 8, 17),
                    Salary = 80000.12m
                },
                  new PersonModel()
                {
                    Id = 2,
                    Name = "Alberto Contador",
                    BirthDate = new DateTime(1982, 12, 6),
                    Salary = 120000.45m
                },
                    new PersonModel()
                {
                    Id = 3,
                    Name = "Chris Froome",
                    BirthDate = new DateTime(1985, 5, 20),
                    Salary = 140000.98m
                },
                    new PersonModel()
                {
                    Id = 4,
                    Name = "Cadel Evans",
                    BirthDate = new DateTime(1985, 5, 20),
                    Salary = 88745.98m
                },
                    new PersonModel()
                {
                    Id = 5,
                    Name = "Nairo Quintana",
                    BirthDate = new DateTime(1990, 2, 4),
                    Salary = 146342.98m
                },
                    new PersonModel()
                {
                    Id = 6,
                    Name = "Spartacus",
                    BirthDate = new DateTime(1981, 3, 18),
                    Salary = 128754m
                },
                    new PersonModel()
                {
                    Id = 6,
                    BirthDate = new DateTime(1991, 3, 11),
                    Salary = 20000.18m
                }
            });
        }
    }
}
