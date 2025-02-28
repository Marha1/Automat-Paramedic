namespace Automat_Paramedic.Forms
{
    partial class SearchAndReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchAndReportForm));
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnGenerateReport = new Button();
            btnPrint = new Button();
            dataGridViewResults = new DataGridView();
            lblSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Montserrat", 10, FontStyle.Regular);
            txtSearch.Location = new Point(120, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 30);
            txtSearch.TabIndex = 0;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.BackColor = Color.FromArgb(45, 45, 45);
            txtSearch.ForeColor = Color.White;
            txtSearch.Padding = new Padding(10);
            txtSearch.Margin = new Padding(10);
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 123, 255); // Синий цвет
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Montserrat", 10, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(450, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 35);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍 Поиск";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 86, 179);
            btnSearch.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 133);
            btnSearch.Click += BtnSearch_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.FromArgb(40, 167, 69); // Зеленый цвет
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Montserrat", 10, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(570, 20);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 35);
            btnGenerateReport.TabIndex = 2;
            btnGenerateReport.Text = "📊 Отчет";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(33, 136, 56);
            btnGenerateReport.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 102, 42);
            btnGenerateReport.Click += BtnGenerateReport_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(220, 53, 69); // Красный цвет
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Montserrat", 10, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(740, 20);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(100, 35);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "🖨️ Печать";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatAppearance.MouseOverBackColor = Color.FromArgb(183, 44, 57);
            btnPrint.FlatAppearance.MouseDownBackColor = Color.FromArgb(137, 33, 43);
            btnPrint.Click += BtnPrint_Click;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.BackgroundColor = Color.FromArgb(30, 30, 30);
            dataGridViewResults.BorderStyle = BorderStyle.None;
            dataGridViewResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(52, 58, 64), // Темно-серый цвет
                ForeColor = Color.White,
                Font = new Font("Montserrat", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dataGridViewResults.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White,
                Font = new Font("Montserrat", 9),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dataGridViewResults.EnableHeadersVisualStyles = false;
            dataGridViewResults.GridColor = Color.FromArgb(60, 60, 60);
            dataGridViewResults.Location = new Point(20, 70);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.RowHeadersVisible = false;
            dataGridViewResults.RowHeadersWidth = 51;
            dataGridViewResults.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewResults.RowTemplate.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewResults.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridViewResults.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewResults.RowTemplate.Height = 30;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.Size = new Size(820, 360);
            dataGridViewResults.TabIndex = 4;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Montserrat", 10, FontStyle.Bold);
            lblSearch.ForeColor = Color.White;
            lblSearch.Location = new Point(20, 23);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(77, 20);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Поиск по:";
            // 
            // SearchAndReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30); // Темный фон
            ClientSize = new Size(860, 450);
            Controls.Add(lblSearch);
            Controls.Add(dataGridViewResults);
            Controls.Add(btnPrint);
            Controls.Add(btnGenerateReport);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Font = new Font("Montserrat", 9, FontStyle.Regular);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SearchAndReportForm";
            Text = "Поиск и отчеты";
            Load += SearchAndReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnGenerateReport;
        private Button btnPrint;
        private DataGridView dataGridViewResults;
        private Label lblSearch;
    }
}