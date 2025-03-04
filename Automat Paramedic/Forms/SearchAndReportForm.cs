using Automat_Paramedic.Models;
using Automat_Paramedic.Repository;
using Automat_Paramedic.Service;
using System.Globalization;

namespace Automat_Paramedic.Forms
{
    public partial class SearchAndReportForm : Form
    {
        private readonly MedicalRecordRepository _medicalRecordRepo;
        private readonly AppointmentRepository _appointmentRepo;
        private readonly VaccinationRepository _vaccinationRepo;

        public SearchAndReportForm()
        {
            InitializeComponent();
            _medicalRecordRepo = new MedicalRecordRepository();
            _appointmentRepo = new AppointmentRepository();
            _vaccinationRepo = new VaccinationRepository();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Настройка элементов управления
            btnSearch.Click += BtnSearch_Click;
            btnGenerateReport.Click += BtnGenerateReport_Click;
            btnPrint.Click += BtnPrint_Click;

            // Добавление столбцов в DataGridView
            dataGridViewResults.Columns.Add("Type", "Тип записи");
            dataGridViewResults.Columns.Add("FullName", "ФИО");
            dataGridViewResults.Columns.Add("Date", "Дата");
            dataGridViewResults.Columns.Add("Details1", "Детали 1");
            dataGridViewResults.Columns.Add("Details2", "Детали 2");
            dataGridViewResults.Columns.Add("Details3", "Детали 3");
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст или дату в формате {dd.MM.yyyy} для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Проверяем, является ли введенный текст датой
                bool isDate = DateTime.TryParseExact(searchText, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime searchDate);

                if (isDate)
                {
                    // Если это дата, проверяем корректность формата
                    if (searchText.Length != 10 || searchText[2] != '.' || searchText[5] != '.')
                    {
                        MessageBox.Show("Неверный формат даты. Используйте формат {dd.MM.yyyy}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var medicalRecords = await _medicalRecordRepo.GetAllAsync();
                var appointments = await _appointmentRepo.GetAllWithMedicineAsync();
                var vaccinations = await _vaccinationRepo.GetUpcomingVaccinationsAsync();

                // Фильтрация данных
                List<Appointment> filteredAppointments;
                List<VaccinationRecord> filteredVaccinations;

                if (isDate)
                {
                    // Фильтрация по дате
                    medicalRecords = medicalRecords
                        .Where(r => r.DateOfBirth.Date == searchDate.Date)
                        .ToList();

                    filteredAppointments = appointments
                        .Where(a => a.Date.Date == searchDate.Date)
                        .ToList();

                    filteredVaccinations = vaccinations
                        .Where(v => v.VaccinationDate.Date == searchDate.Date)
                        .ToList();
                }
                else
                {
                    // Обычный поиск по тексту
                    filteredAppointments = appointments
                        .Where(a => a.FullName.ToLower().Contains(searchText) ||
                                     a.Group.ToLower().Contains(searchText) ||
                                     (a.Medicine?.Name.ToLower().Contains(searchText) ?? false) ||
                                     a.Recommendations.ToLower().Contains(searchText) ||
                                     a.Treatment.ToLower().Contains(searchText))
                        .ToList();

                    filteredVaccinations = vaccinations
                        .Where(v => v.PatientName.ToLower().Contains(searchText) ||
                                     v.VaccineName.ToLower().Contains(searchText))
                        .ToList();
                }

                // Отображение результатов
                DisplayResults(medicalRecords, filteredAppointments, filteredVaccinations);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayResults(List<MedicalRecord> medicalRecords, List<Appointment> appointments, List<VaccinationRecord> vaccinations)
        {
            // Очистка предыдущих результатов
            dataGridViewResults.Rows.Clear();

            // Отображение медицинских записей
            foreach (var record in medicalRecords)
            {
                dataGridViewResults.Rows.Add(
                    "Медкарта",
                    record.FullName,
                    record.DateOfBirth.ToString("dd.MM.yyyy"),
                    record.ChronicDiseases,
                    record.Allergies,
                    record.Vaccinations
                );
            }

            // Отображение обращений
            foreach (var appointment in appointments)
            {
                dataGridViewResults.Rows.Add(
                    "Обращение",
                    appointment.FullName,
                    appointment.Date.ToString("dd.MM.yyyy"),
                    appointment.Medicine?.Name,
                    appointment.Recommendations,
                    appointment.Treatment
                );
            }

            // Отображение вакцинаций
            foreach (var vaccination in vaccinations)
            {
                dataGridViewResults.Rows.Add(
                    "Вакцинация",
                    vaccination.PatientName,
                    vaccination.VaccinationDate,
                    vaccination.NextVaccinationDate.ToString("dd.MM.yyyy"),
                    vaccination.VaccineName,
                    "-",
                    "-"
                );
            }
        }

        private async void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                var medicalRecords = await _medicalRecordRepo.GetByFilter("");
                var appointments = await _appointmentRepo.GetAllWithMedicineAsync();
                var vaccinations = await _vaccinationRepo.GetUpcomingVaccinationsAsync();

                // Формирование отчета
                var report = new List<MedicalRecord>();
                foreach (var record in medicalRecords)
                {
                    report.Add(record);
                }

                // Экспорт в CSV
                ExportService.ExportToCSV(report);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var medicalRecords = await _medicalRecordRepo.GetByFilter("");
                var appointments = await _appointmentRepo.GetAllWithMedicineAsync();
                var vaccinations = await _vaccinationRepo.GetUpcomingVaccinationsAsync();

                // Формирование данных для печати
                var recordsToPrint = new List<MedicalRecord>();
                foreach (var record in medicalRecords)
                {
                    recordsToPrint.Add(record);
                }

                // Печать
                ExportService.Print(recordsToPrint);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchAndReportForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}