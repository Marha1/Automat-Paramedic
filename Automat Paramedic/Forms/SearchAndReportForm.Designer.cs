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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            txtSearch.BackColor = Color.FromArgb(45, 45, 45);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Microsoft Sans Serif", 10F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(120, 20);
            txtSearch.Margin = new Padding(10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 19);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 123, 255);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 133);
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 86, 179);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(450, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 35);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍 Поиск";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.FromArgb(40, 167, 69);
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 102, 42);
            btnGenerateReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(33, 136, 56);
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(570, 20);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 35);
            btnGenerateReport.TabIndex = 2;
            btnGenerateReport.Text = "📊 Отчет";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += BtnGenerateReport_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(220, 53, 69);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatAppearance.MouseDownBackColor = Color.FromArgb(137, 33, 43);
            btnPrint.FlatAppearance.MouseOverBackColor = Color.FromArgb(183, 44, 57);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(740, 20);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(100, 35);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "🖨️ Печать";
            btnPrint.UseVisualStyleBackColor = false;
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
            dataGridViewResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            lblSearch.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.White;
            lblSearch.Location = new Point(20, 23);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(99, 20);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Поиск по:";
            // 
            // SearchAndReportForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(860, 450);
            Controls.Add(lblSearch);
            Controls.Add(dataGridViewResults);
            Controls.Add(btnPrint);
            Controls.Add(btnGenerateReport);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Font = new Font("Microsoft Sans Serif", 9F);
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