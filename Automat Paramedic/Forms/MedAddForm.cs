using Automat_Paramedic.Models;
using Automat_Paramedic.Repository;
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
    public partial class MedAddForm : Form
    {
        private readonly Action _refreshDataGrid;
        private readonly MedicineRepository _medicineRepository;

        public MedAddForm(Action refreshDataGrid)
        {
            InitializeComponent();
            _refreshDataGrid = refreshDataGrid;
            _medicineRepository = new MedicineRepository();
        }

        private void MedAddForm_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                    !string.IsNullOrEmpty(textBox3.Text) && numericUpDown1.Value != 0)
                {
                   
                    
                        var med = new Medicine()
                        {
                            Name = textBox1.Text,
                            Manufacturer = textBox2.Text,
                            Quantity = (int)numericUpDown1.Value,
                            ExpirationDate = dateTimePicker1.Value.ToUniversalTime(),
                            Description = textBox3.Text,
                        };
                    await  _medicineRepository.AddAsync(med);

                        MessageBox.Show("Добавлено!");

                        _refreshDataGrid?.Invoke();
                   
                }
                else
                {
                    MessageBox.Show("Укажите все данные");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
