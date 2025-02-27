namespace Automat_Paramedic.Forms
{
    partial class AppointmentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView;
        private DateTimePicker dtpDate;
        private TextBox txtSymptoms;
        private TextBox txtTreatment;
        private TextBox txtRecommendations;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxMedicines;
        private Label label5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentsForm));
            dataGridView = new DataGridView();
            dtpDate = new DateTimePicker();
            txtSymptoms = new TextBox();
            txtTreatment = new TextBox();
            txtRecommendations = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxMedicines = new ComboBox();
            label5 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            textBox2 = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(776, 250);
            dataGridView.TabIndex = 0;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(450, 381);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 27);
            dtpDate.TabIndex = 1;
            // 
            // txtSymptoms
            // 
            txtSymptoms.Location = new Point(220, 383);
            txtSymptoms.Name = "txtSymptoms";
            txtSymptoms.Size = new Size(200, 27);
            txtSymptoms.TabIndex = 2;
            // 
            // txtTreatment
            // 
            txtTreatment.Location = new Point(220, 283);
            txtTreatment.Name = "txtTreatment";
            txtTreatment.Size = new Size(200, 27);
            txtTreatment.TabIndex = 3;
            // 
            // txtRecommendations
            // 
            txtRecommendations.Location = new Point(220, 330);
            txtRecommendations.Name = "txtRecommendations";
            txtRecommendations.Size = new Size(200, 27);
            txtRecommendations.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(450, 280);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(560, 280);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 30);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(670, 280);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(450, 360);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 8;
            label1.Text = "Дата:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(220, 360);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 9;
            label2.Text = "Симптомы:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(220, 265);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 10;
            label3.Text = "Лечение:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(220, 310);
            label4.Name = "label4";
            label4.Size = new Size(115, 20);
            label4.TabIndex = 11;
            label4.Text = "Рекомендации:";
            // 
            // comboBoxMedicines
            // 
            comboBoxMedicines.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMedicines.FormattingEnabled = true;
            comboBoxMedicines.Location = new Point(450, 330);
            comboBoxMedicines.Name = "comboBoxMedicines";
            comboBoxMedicines.Size = new Size(200, 28);
            comboBoxMedicines.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(450, 310);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 13;
            label5.Text = "Лекарство:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 288);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 27);
            textBox1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 265);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 15;
            label6.Text = "Фио:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 341);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 27);
            textBox2.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 318);
            label7.Name = "label7";
            label7.Size = new Size(61, 20);
            label7.TabIndex = 17;
            label7.Text = "Группа:";
            // 
            // AppointmentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(comboBoxMedicines);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtRecommendations);
            Controls.Add(txtTreatment);
            Controls.Add(txtSymptoms);
            Controls.Add(dtpDate);
            Controls.Add(dataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AppointmentsForm";
            Text = "Учет обращений";
            Load += AppointmentsForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBox1;
        private Label label6;
        private TextBox textBox2;
        private Label label7;
    }
}