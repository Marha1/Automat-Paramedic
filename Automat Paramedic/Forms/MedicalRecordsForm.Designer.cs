namespace Automat_Paramedic.Forms
{
    partial class MedicalRecordsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView;
        private TextBox txtFullName;
        private DateTimePicker dtpDateOfBirth;
        private TextBox txtChronicDiseases;
        private TextBox txtAllergies;
        private TextBox txtVaccinations;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
        private TextBox txtSearch;
        private Button btnSearch;
        private ComboBox cmbExportType;
        private Button btnExport;
        private Button btnView;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicalRecordsForm));
            dataGridView = new DataGridView();
            txtFullName = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            txtChronicDiseases = new TextBox();
            txtAllergies = new TextBox();
            txtVaccinations = new TextBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            cmbExportType = new ComboBox();
            btnExport = new Button();
            btnView = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(800, 250);
            dataGridView.TabIndex = 0;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(10, 30);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(200, 27);
            txtFullName.TabIndex = 1;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(10, 80);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(200, 27);
            dtpDateOfBirth.TabIndex = 2;
            // 
            // txtChronicDiseases
            // 
            txtChronicDiseases.Location = new Point(220, 30);
            txtChronicDiseases.Name = "txtChronicDiseases";
            txtChronicDiseases.Size = new Size(200, 27);
            txtChronicDiseases.TabIndex = 3;
            // 
            // txtAllergies
            // 
            txtAllergies.Location = new Point(220, 80);
            txtAllergies.Name = "txtAllergies";
            txtAllergies.Size = new Size(200, 27);
            txtAllergies.TabIndex = 4;
            // 
            // txtVaccinations
            // 
            txtVaccinations.Location = new Point(430, 30);
            txtVaccinations.Name = "txtVaccinations";
            txtVaccinations.Size = new Size(200, 27);
            txtVaccinations.TabIndex = 5;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.LightGreen;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Location = new Point(430, 80);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Создать";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.LightSkyBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(530, 80);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(630, 80);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 9;
            label1.Text = "ФИО";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 60);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 10;
            label2.Text = "Дата рождения";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(220, 10);
            label3.Name = "label3";
            label3.Size = new Size(162, 20);
            label3.TabIndex = 11;
            label3.Text = "Хронические заболевания";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(220, 60);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 12;
            label4.Text = "Аллергии";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(430, 10);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 13;
            label5.Text = "Прививки";
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 250);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtFullName);
            panel2.Controls.Add(dtpDateOfBirth);
            panel2.Controls.Add(txtChronicDiseases);
            panel2.Controls.Add(txtAllergies);
            panel2.Controls.Add(txtVaccinations);
            panel2.Controls.Add(btnCreate);
            panel2.Controls.Add(btnUpdate);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnView);
            panel2.Controls.Add(cmbExportType);
            panel2.Controls.Add(btnExport);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(btnSearch);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 250);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 200);
            panel2.TabIndex = 15;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(10, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 27);
            txtSearch.TabIndex = 16;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(220, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 27);
            btnSearch.TabIndex = 17;
            btnSearch.Text = "Поиск";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbExportType
            // 
            cmbExportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExportType.FormattingEnabled = true;
            cmbExportType.Items.AddRange(new object[] { "CSV", "Печать" });
            cmbExportType.Location = new Point(10, 120);
            cmbExportType.Name = "cmbExportType";
            cmbExportType.Size = new Size(120, 28);
            cmbExportType.TabIndex = 18;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(140, 120);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 29);
            btnExport.TabIndex = 19;
            btnExport.Text = "Экспорт";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnView
            // 
            btnView.Location = new Point(630, 120);
            btnView.Name = "btnView";
            btnView.Size = new Size(94, 29);
            btnView.TabIndex = 20;
            btnView.Text = "Просмотр";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // MedicalRecordsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MedicalRecordsForm";
            Text = "Медкарты";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }
    }
}