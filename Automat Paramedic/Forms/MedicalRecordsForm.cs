using Automat_Paramedic.Models;
using Automat_Paramedic.Repository;
using Automat_Paramedic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Automat_Paramedic.Forms
{
    public partial class MedicalRecordsForm : Form
    {
        private readonly MedicalRecordRepository _repository;
        private List<MedicalRecord> _medicalRecords;
        private MedicalRecord _selectedRecord;

        public MedicalRecordsForm()
        {
            InitializeComponent();
            _repository = new MedicalRecordRepository();
            LoadDataAsync();
            InitializeDataGridView();
        }

        private async void LoadDataAsync()
        {
            _medicalRecords = await _repository.GetAllAsync();
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = _medicalRecords;

            dataGridView.Columns["FullName"].HeaderText = "ФИО";
            dataGridView.Columns["DateOfBirth"].HeaderText = "Дата рождения";
            dataGridView.Columns["ChronicDiseases"].HeaderText = "Хронические заболевания";
            dataGridView.Columns["Allergies"].HeaderText = "Аллергии";
            dataGridView.Columns["Vaccinations"].HeaderText = "Прививки";

            dataGridView.Columns["DateOfBirth"].DefaultCellStyle.Format = "dd.MM.yyyy";

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.Columns["Id"].Visible = false;

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void InitializeDataGridView()
        {
            dataGridView.CellClick += dataGridView_CellClick;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRecord = dataGridView.Rows[e.RowIndex].DataBoundItem as MedicalRecord;
                if (selectedRecord != null)
                {
                    _selectedRecord = selectedRecord;
                    LoadSelectedRecord();

                    Console.WriteLine($"Выбрана запись: {_selectedRecord.FullName}");
                }
            }
        }

        private void ShowRecordDetails(MedicalRecord record)
        {
            var detailsForm = new RecordDetailsForm(record);
            detailsForm.ShowDialog();
        }

        private void LoadSelectedRecord()
        {
            if (_selectedRecord != null)
            {
                txtFullName.Text = _selectedRecord.FullName;
                dtpDateOfBirth.Value = _selectedRecord.DateOfBirth.ToLocalTime();
                txtChronicDiseases.Text = _selectedRecord.ChronicDiseases;
                txtAllergies.Text = _selectedRecord.Allergies;
                txtVaccinations.Text = _selectedRecord.Vaccinations;
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text)  ||
                dtpDateOfBirth.Value == DateTime.MinValue)
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newRecord = new MedicalRecord
            {
                FullName = txtFullName.Text.Trim(),
                DateOfBirth = dtpDateOfBirth.Value.ToUniversalTime(),
                ChronicDiseases = txtChronicDiseases.Text.Trim(),
                Allergies = txtAllergies.Text.Trim(),
                Vaccinations = txtVaccinations.Text.Trim()
            };

            await _repository.AddAsync(newRecord);
             LoadDataAsync();
            ClearForm();
        }


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
            {
                _selectedRecord.FullName = txtFullName.Text;
                _selectedRecord.DateOfBirth = dtpDateOfBirth.Value.ToUniversalTime();
                _selectedRecord.ChronicDiseases = txtChronicDiseases.Text;
                _selectedRecord.Allergies = txtAllergies.Text;
                _selectedRecord.Vaccinations = txtVaccinations.Text;

                await _repository.UpdateAsync(_selectedRecord);
                LoadDataAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
            {
                await _repository.DeleteAsync(_selectedRecord);
                LoadDataAsync();
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
            txtChronicDiseases.Clear();
            txtAllergies.Clear();
            txtVaccinations.Clear();
            _selectedRecord = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.ToLower(); // Исправлено: используем txtSearch.Text
            var filteredRecords = _medicalRecords
                .Where(r => r.FullName.ToLower().Contains(searchText))
                .ToList();

            dataGridView.DataSource = null;
            dataGridView.DataSource = filteredRecords;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cmbExportType.SelectedItem != null && cmbExportType.SelectedItem.ToString() == "CSV")
            {
                ExportService.ExportToCSV(_medicalRecords);
            }
            else if (cmbExportType.SelectedItem != null && cmbExportType.SelectedItem.ToString() == "Печать")
            {
                ExportService.Print(_medicalRecords);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
            {
                ShowRecordDetails(_selectedRecord);
            }
            else
            {
                MessageBox.Show("Выберите запись для просмотра.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}