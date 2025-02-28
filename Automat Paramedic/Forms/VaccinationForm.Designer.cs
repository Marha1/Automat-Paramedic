namespace Automat_Paramedic.Forms
{
    partial class VaccinationForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dataGridViewVaccination;
        private Label lblPatientName;
        private TextBox txtPatientName;
        private Label lblVaccineName;
        private TextBox txtVaccineName;
        private Label lblVaccinationDate;
        private DateTimePicker dtpVaccinationDate;
        private Label lblNextVaccinationDate;
        private DateTimePicker dtpNextVaccinationDate;
        private Button btnAddRecord;
        private Button btnCheckNotifications;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaccinationForm));
            dataGridViewVaccination = new DataGridView();
            lblPatientName = new Label();
            txtPatientName = new TextBox();
            lblVaccineName = new Label();
            txtVaccineName = new TextBox();
            lblVaccinationDate = new Label();
            dtpVaccinationDate = new DateTimePicker();
            lblNextVaccinationDate = new Label();
            dtpNextVaccinationDate = new DateTimePicker();
            btnAddRecord = new Button();
            btnCheckNotifications = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVaccination).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewVaccination
            // 
            dataGridViewVaccination.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewVaccination.Location = new Point(12, 12);
            dataGridViewVaccination.Name = "dataGridViewVaccination";
            dataGridViewVaccination.RowHeadersWidth = 51;
            dataGridViewVaccination.Size = new Size(776, 250);
            dataGridViewVaccination.TabIndex = 0;
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Location = new Point(12, 280);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(112, 20);
            lblPatientName.TabIndex = 1;
            lblPatientName.Text = "Имя пациента:";
            // 
            // txtPatientName
            // 
            txtPatientName.Location = new Point(163, 277);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new Size(200, 27);
            txtPatientName.TabIndex = 2;
            // 
            // lblVaccineName
            // 
            lblVaccineName.AutoSize = true;
            lblVaccineName.Location = new Point(12, 320);
            lblVaccineName.Name = "lblVaccineName";
            lblVaccineName.Size = new Size(145, 20);
            lblVaccineName.TabIndex = 3;
            lblVaccineName.Text = "Название вакцины:";
            // 
            // txtVaccineName
            // 
            txtVaccineName.Location = new Point(163, 317);
            txtVaccineName.Name = "txtVaccineName";
            txtVaccineName.Size = new Size(200, 27);
            txtVaccineName.TabIndex = 4;
            // 
            // lblVaccinationDate
            // 
            lblVaccinationDate.AutoSize = true;
            lblVaccinationDate.Location = new Point(12, 360);
            lblVaccinationDate.Name = "lblVaccinationDate";
            lblVaccinationDate.Size = new Size(133, 20);
            lblVaccinationDate.TabIndex = 5;
            lblVaccinationDate.Text = "Дата вакцинации:";
            // 
            // dtpVaccinationDate
            // 
            dtpVaccinationDate.Location = new Point(151, 355);
            dtpVaccinationDate.Name = "dtpVaccinationDate";
            dtpVaccinationDate.Size = new Size(200, 27);
            dtpVaccinationDate.TabIndex = 6;
            // 
            // lblNextVaccinationDate
            // 
            lblNextVaccinationDate.AutoSize = true;
            lblNextVaccinationDate.Location = new Point(12, 400);
            lblNextVaccinationDate.Name = "lblNextVaccinationDate";
            lblNextVaccinationDate.Size = new Size(216, 20);
            lblNextVaccinationDate.TabIndex = 7;
            lblNextVaccinationDate.Text = "Дата следующей вакцинации:";
            // 
            // dtpNextVaccinationDate
            // 
            dtpNextVaccinationDate.Location = new Point(234, 400);
            dtpNextVaccinationDate.Name = "dtpNextVaccinationDate";
            dtpNextVaccinationDate.Size = new Size(200, 27);
            dtpNextVaccinationDate.TabIndex = 8;
            // 
            // btnAddRecord
            // 
            btnAddRecord.Location = new Point(400, 280);
            btnAddRecord.Name = "btnAddRecord";
            btnAddRecord.Size = new Size(150, 40);
            btnAddRecord.TabIndex = 9;
            btnAddRecord.Text = "Добавить запись";
            btnAddRecord.UseVisualStyleBackColor = true;
            btnAddRecord.Click += btnAddRecord_Click;
            // 
            // btnCheckNotifications
            // 
            btnCheckNotifications.Location = new Point(400, 340);
            btnCheckNotifications.Name = "btnCheckNotifications";
            btnCheckNotifications.Size = new Size(150, 40);
            btnCheckNotifications.TabIndex = 10;
            btnCheckNotifications.Text = "Проверить уведомления";
            btnCheckNotifications.UseVisualStyleBackColor = true;
            btnCheckNotifications.Click += btnCheckNotifications_Click;
            // 
            // VaccinationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCheckNotifications);
            Controls.Add(btnAddRecord);
            Controls.Add(dtpNextVaccinationDate);
            Controls.Add(lblNextVaccinationDate);
            Controls.Add(dtpVaccinationDate);
            Controls.Add(lblVaccinationDate);
            Controls.Add(txtVaccineName);
            Controls.Add(lblVaccineName);
            Controls.Add(txtPatientName);
            Controls.Add(lblPatientName);
            Controls.Add(dataGridViewVaccination);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VaccinationForm";
            Text = "Журнал вакцинации";
            Load += VaccinationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewVaccination).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}