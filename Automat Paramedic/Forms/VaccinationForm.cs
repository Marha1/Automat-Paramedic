using Automat_Paramedic.Models;
using Automat_Paramedic.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automat_Paramedic.Forms
{
    public partial class VaccinationForm : Form
    {
        private readonly VaccinationRepository _vaccinationRepository;

        public VaccinationForm()
        {
            InitializeComponent();
            _vaccinationRepository = new VaccinationRepository();
            CustomizeDataGridView();
        }

        private async void VaccinationForm_Load(object sender, EventArgs e)
        {
            await LoadVaccinationRecordsAsync();
        }
        private void CustomizeDataGridView()
        {
            dataGridViewVaccination.EnableHeadersVisualStyles = false;
            dataGridViewVaccination.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridViewVaccination.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewVaccination.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewVaccination.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewVaccination.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewVaccination.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVaccination.RowHeadersVisible = false;
            dataGridViewVaccination.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private async Task LoadVaccinationRecordsAsync()
        {
            var records = await _vaccinationRepository.GetAllAsync();
            dataGridViewVaccination.DataSource = records;
            UpdateColumnHeaders();
        }
        private void UpdateColumnHeaders()
        {
            dataGridViewVaccination.Columns["PatientName"].HeaderText = "Имя пациента";
            dataGridViewVaccination.Columns["VaccineName"].HeaderText = "Название вакцины";
            dataGridViewVaccination.Columns["VaccinationDate"].HeaderText = "Дата вакцинации";
            dataGridViewVaccination.Columns["NextVaccinationDate"].HeaderText = "Следующая вакцинация";
            dataGridViewVaccination.Columns["Id"].Visible = false; 
        }

        private async void btnAddRecord_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return; 

            var newRecord = new VaccinationRecord
            {
                PatientName = txtPatientName.Text,
                VaccineName = txtVaccineName.Text,
                VaccinationDate = dtpVaccinationDate.Value.ToUniversalTime(),
                NextVaccinationDate = dtpNextVaccinationDate.Value.ToUniversalTime()
            };

            await _vaccinationRepository.AddAsync(newRecord);
            MessageBox.Show("Запись добавлена!");

            await LoadVaccinationRecordsAsync();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                MessageBox.Show("Имя пациента не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtVaccineName.Text))
            {
                MessageBox.Show("Название вакцины не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtpNextVaccinationDate.Value < dtpVaccinationDate.Value)
            {
                MessageBox.Show("Дата следующей вакцинации должна быть позже текущей даты вакцинации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private async void btnCheckNotifications_Click(object sender, EventArgs e)
        {
            // Проверка уведомлений
            var upcomingVaccinations = await _vaccinationRepository.GetUpcomingVaccinationsAsync();

            if (upcomingVaccinations.Any())
            {
                foreach (var record in upcomingVaccinations)
                {
                    MessageBox.Show($"Пациенту {record.PatientName} необходимо сделать прививку {record.VaccineName} до {record.NextVaccinationDate.ToShortDateString()}");
                }
            }
            else
            {
                MessageBox.Show("Нет предстоящих вакцинаций.");
            }
        }
    }
}