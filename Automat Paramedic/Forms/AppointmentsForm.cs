using Automat_Paramedic.Models;
using Automat_Paramedic.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Automat_Paramedic.Forms
{
    public partial class AppointmentsForm : Form
    {
        private BindingList<Appointment> _appointments;
        private Appointment _selectedAppointment;
        private readonly MedicineRepository _medicineRepository;
        private readonly AppointmentRepository _appointmentRepository;


        public AppointmentsForm()
        {
            InitializeComponent();
            _medicineRepository = new MedicineRepository();
            _appointmentRepository = new AppointmentRepository();
            LoadAppointments();
            LoadMedicines(); 
        }

        private async void LoadMedicines()
        {
            try
            {
                var medicines = await _medicineRepository.GetAllAsync();
                comboBoxMedicines.DataSource = medicines;
                comboBoxMedicines.DisplayMember = "Name"; // Отображаем название лекарства
                comboBoxMedicines.ValueMember = "Id"; // Используем Id для выбора
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке лекарств: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
        }

        private async void LoadAppointments()
        {
            
                var appointments = await _appointmentRepository.GetAllAsync();

                dataGridView.Columns.Clear();
                dataGridView.Rows.Clear();

                dataGridView.Columns.Add("FullName", "Фио");
                dataGridView.Columns.Add("Group", "Группа");
                dataGridView.Columns.Add("Date", "Дата обращения");
                dataGridView.Columns.Add("Symptoms", "Симптомы");
                dataGridView.Columns.Add("Treatment", "Лечение");
                dataGridView.Columns.Add("Recommendations", "Рекомендации");
                dataGridView.Columns.Add("Medicine", "Назначенное лекарство");


                var selectButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Select",
                    HeaderText = "Выбрать",
                    Text = "Выбрать",
                    UseColumnTextForButtonValue = true
                };
                dataGridView.Columns.Add(selectButtonColumn);
                foreach (var appointment in appointments)
                {
                    dataGridView.Rows.Add(
                         appointment.FullName,
                        appointment.Group,
                        appointment.Date.ToLocalTime().ToString("yyyy-MM-dd HH:mm"),
                        appointment.Symptoms,
                        appointment.Treatment,
                        appointment.Recommendations,
                        appointment.Medicine?.Name ?? "Не назначено"
                    );
                }
                CustomizeDataGridView();

            
        }


      

        private void CustomizeDataGridView()
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.CellContentClick += DataGridView_CellContentClick;

        }

        private async void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
               
                    var fullName = dataGridView.Rows[e.RowIndex].Cells["FullName"].Value?.ToString();
                    var group = dataGridView.Rows[e.RowIndex].Cells["Group"].Value?.ToString();
                    var appointment = await _appointmentRepository.GetByFullNameAndGroupAsync(fullName, group);

                    if (appointment != null)
                    {
                        _selectedAppointment = appointment;
                        LoadSelectedAppointment();
                    }
            }
        }

        private void LoadSelectedAppointment()
        {
            if (_selectedAppointment != null)
            {
                textBox1.Text = _selectedAppointment.FullName;
                textBox2.Text = _selectedAppointment.Group;
                dtpDate.Value = _selectedAppointment.Date;
                txtSymptoms.Text = _selectedAppointment.Symptoms;
                txtTreatment.Text = _selectedAppointment.Treatment;
                txtRecommendations.Text = _selectedAppointment.Recommendations;
                comboBoxMedicines.SelectedValue = _selectedAppointment.MedicineId; 
            }
        }





        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

           
            var newAppointment = new Appointment
            {
                FullName = textBox1.Text,
                Group = textBox2.Text,
                Date = dtpDate.Value.ToUniversalTime(),
                Symptoms = txtSymptoms.Text,
                Treatment = txtTreatment.Text,
                Recommendations = txtRecommendations.Text,
                MedicineId = (int)comboBoxMedicines.SelectedValue
            };

               await  _appointmentRepository.AddAsync(newAppointment);
            

            LoadAppointments();
            ClearForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность всех данных");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedAppointment != null)
            {
                _selectedAppointment.FullName = textBox1.Text;
                _selectedAppointment.Group = textBox2.Text;
                _selectedAppointment.Date = dtpDate.Value;
                _selectedAppointment.Symptoms = txtSymptoms.Text;
                _selectedAppointment.Treatment = txtTreatment.Text;
                _selectedAppointment.Recommendations = txtRecommendations.Text;
                _selectedAppointment.MedicineId = (int)comboBoxMedicines.SelectedValue;

                
                  await  _appointmentRepository.UpdateAsync(_selectedAppointment);                
                LoadAppointments();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedAppointment != null)
            {
                
                 await   _appointmentRepository.DeleteAsync(_selectedAppointment);
               
                _appointments.Remove(_selectedAppointment);
                LoadAppointments();
                ClearForm();
            }
        }

        private void ClearForm()
        {
            dtpDate.Value = DateTime.Now;
            txtSymptoms.Clear();
            txtTreatment.Clear();
            txtRecommendations.Clear();
            comboBoxMedicines.SelectedIndex = -1;
            _selectedAppointment = null;
        }

        private void AppointmentsForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}