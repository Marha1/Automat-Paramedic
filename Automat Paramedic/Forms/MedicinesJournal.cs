using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automat_Paramedic.Repository;
using Automat_Paramedic.Models;
using Automat_Paramedic.Primitives;
using System.ComponentModel;

namespace Automat_Paramedic.Forms
{
    public partial class MedicinesJournal : Form
    {
        private readonly MedicineRepository _medicineRepository;
        private readonly NotifyIcon _notifyIcon;
        private int selectedMedicineId = -1; // Переменная для хранения выбранного ID
        private BindingList<Medicine> _medicines;


        public MedicinesJournal()
        {
            InitializeComponent();
            _medicineRepository = new MedicineRepository();
            _notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true,
                BalloonTipTitle = "Уведомление о лекарствах",
                BalloonTipText = "Проверьте лекарства с истекшим сроком годности.",
                BalloonTipIcon = ToolTipIcon.Info
            };

            LoadData();
            CheckExpiredMedicines();
        }

        private  async void LoadData()
        {
            await LoadMedicines();
            await LoadExpiredMedicines();
            await LoadLowStockMedicines();
        }


        private async Task LoadMedicines()
        {
            try
            {
                var medicines = await _medicineRepository.GetAllAsync();

                // Очищаем DataGridView
                dataGridViewMedicines.Columns.Clear();
                dataGridViewMedicines.Rows.Clear();

                // Добавляем колонки
                dataGridViewMedicines.Columns.Add("Id", "ID");
                dataGridViewMedicines.Columns.Add("Name", "Название");
                dataGridViewMedicines.Columns.Add("Quantity", "Количество");
                dataGridViewMedicines.Columns.Add("ExpirationDate", "Срок годности");
                dataGridViewMedicines.Columns.Add("Description", "Описание");
                dataGridViewMedicines.Columns.Add("Manufacturer", "Производитель");

                // Добавляем кнопку "Выбрать"
                var selectButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Select",
                    HeaderText = "Выбрать",
                    Text = "Выбрать",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewMedicines.Columns.Add(selectButtonColumn);

                // Заполняем DataGridView данными
                foreach (var medicine in medicines)
                {
                    dataGridViewMedicines.Rows.Add(
                        medicine.Id,
                        medicine.Name,
                        medicine.Quantity,
                        medicine.ExpirationDate.ToShortDateString(),
                        medicine.Description,
                        medicine.Manufacturer
                    );
                }

                // Настраиваем внешний вид
                CustomizeDataGridView(dataGridViewMedicines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке лекарств: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async Task LoadExpiredMedicines()
        {
            try
            {
                var expiredMedicines = await _medicineRepository.GetExpiredMedicinesAsync();

                // Очищаем DataGridView
                dataGridViewExpiredMedicines.Columns.Clear();
                dataGridViewExpiredMedicines.Rows.Clear();

                // Добавляем колонки
                dataGridViewExpiredMedicines.Columns.Add("Id", "ID");
                dataGridViewExpiredMedicines.Columns.Add("Name", "Название");
                dataGridViewExpiredMedicines.Columns.Add("Quantity", "Количество");
                dataGridViewExpiredMedicines.Columns.Add("ExpirationDate", "Срок годности");
                dataGridViewExpiredMedicines.Columns.Add("Description", "Описание");
                dataGridViewExpiredMedicines.Columns.Add("Manufacturer", "Производитель");

                // Заполняем DataGridView данными
                foreach (var medicine in expiredMedicines)
                {
                    dataGridViewExpiredMedicines.Rows.Add(
                        medicine.Id,
                        medicine.Name,
                        medicine.Quantity,
                        medicine.ExpirationDate.ToShortDateString(),
                        medicine.Description,
                        medicine.Manufacturer
                    );
                }

                // Настраиваем внешний вид
                CustomizeDataGridView(dataGridViewExpiredMedicines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке просроченных лекарств: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadLowStockMedicines()
        {
            try
            {
                var lowStockMedicines = await _medicineRepository.GetLowStockMedicinesAsync();

                // Очищаем DataGridView
                dataGridViewLowStockMedicines.Columns.Clear();
                dataGridViewLowStockMedicines.Rows.Clear();

                // Добавляем колонки
                dataGridViewLowStockMedicines.Columns.Add("Id", "ID");
                dataGridViewLowStockMedicines.Columns.Add("Name", "Название");
                dataGridViewLowStockMedicines.Columns.Add("Quantity", "Количество");
                dataGridViewLowStockMedicines.Columns.Add("ExpirationDate", "Срок годности");
                dataGridViewLowStockMedicines.Columns.Add("Description", "Описание");
                dataGridViewLowStockMedicines.Columns.Add("Manufacturer", "Производитель");

                // Заполняем DataGridView данными
                foreach (var medicine in lowStockMedicines)
                {
                    dataGridViewLowStockMedicines.Rows.Add(
                        medicine.Id,
                        medicine.Name,
                        medicine.Quantity,
                        medicine.ExpirationDate.ToShortDateString(),
                        medicine.Description,
                        medicine.Manufacturer
                    );
                }

                // Настраиваем внешний вид
                CustomizeDataGridView(dataGridViewLowStockMedicines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке лекарств с низким запасом: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CustomizeDataGridView(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.CellClick += DataGridView_CellClick;
        }


        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewMedicines.Columns["Select"].Index)
            {
                var row = dataGridViewMedicines.Rows[e.RowIndex];
                selectedMedicineId = Convert.ToInt32(row.Cells["Id"].Value);
                MessageBox.Show($"Выбрано лекарство с ID: {selectedMedicineId}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async void CheckExpiredMedicines()
        {
            try
            {
                var expiredMedicines = await _medicineRepository.GetExpiredMedicinesAsync();
                if (expiredMedicines.Any())
                {
                    _notifyIcon.ShowBalloonTip(5000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке просроченных лекарств: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task buttonAddTransaction_Click(object sender, EventArgs e)
        {
            if (selectedMedicineId == -1)
            {
                MessageBox.Show("Выберите лекарство из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Некорректное количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var medicine = await _medicineRepository.GetByIdAsync(selectedMedicineId);
            if (medicine.ExpirationDate <= DateTime.UtcNow)
            {
                MessageBox.Show("Нельзя назначить просроченное лекарство.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var transaction = new MedicineTransaction
            {
                MedicineId = selectedMedicineId,
                Quantity = quantity,
                Type = comboBoxTransactionType.SelectedIndex == 0 ? TransactionType.Incoming : TransactionType.Outgoing,
                TransactionDate = DateTime.UtcNow,
                Notes = textBoxNotes.Text
            };

            try
            {
                await _medicineRepository.AddTransactionAsync(transaction);
                Update(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении транзакции: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Update()
        {
            dataGridViewMedicines.Columns.Clear();
            dataGridViewMedicines.Rows.Clear();
            //
            dataGridViewLowStockMedicines.Rows.Clear();
            dataGridViewLowStockMedicines.Columns.Clear();
            //
            dataGridViewExpiredMedicines.Rows.Clear();
            dataGridViewExpiredMedicines.Columns.Clear();

            LoadData();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Clear();
            comboBoxTransactionType.SelectedIndex = -1;
            textBoxNotes.Clear(); // Очищаем поле примечания
        }

        private void dataGridViewMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверяем, что выбрана строка, а не заголовок
            {
                DataGridViewRow row = dataGridViewMedicines.Rows[e.RowIndex];
                selectedMedicineId = Convert.ToInt32(row.Cells["Id"].Value); // Сохраняем выбранный ID
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _notifyIcon.Dispose();
            base.OnFormClosing(e);
        }


        private void MedicinesJournal_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addForm = new MedAddForm(LoadData);
            addForm.ShowDialog();
        }
    }
}