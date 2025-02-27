using Automat_Paramedic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automat_Paramedic.Forms
{
    public partial class RecordDetailsForm : Form
    {
        public RecordDetailsForm(MedicalRecord record)
        {
            InitializeComponent();
            LoadRecordDetails(record);

        }

        private void RecordDetailsForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadRecordDetails(MedicalRecord record)
        {
            lblFullName.Text = "Фио:"+record.FullName;
            lblDateOfBirth.Text = "Дата Рождения:"+record.DateOfBirth.ToShortDateString();
            lblChronicDiseases.Text = "Хронические заболевания:"+record.ChronicDiseases;
            lblAllergies.Text = "Аллергия:"+record.Allergies;
            lblVaccinations.Text = "Прививки"+record.Vaccinations;
        }
    }
}
