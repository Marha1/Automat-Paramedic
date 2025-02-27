namespace Automat_Paramedic.Forms
{
    partial class MedicinesJournal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicinesJournal));
            dataGridViewMedicines = new DataGridView();
            dataGridViewExpiredMedicines = new DataGridView();
            dataGridViewLowStockMedicines = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxQuantity = new TextBox();
            comboBoxTransactionType = new ComboBox();
            buttonAddTransaction = new Button();
            textBoxNotes = new TextBox();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMedicines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpiredMedicines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLowStockMedicines).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMedicines
            // 
            dataGridViewMedicines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMedicines.Location = new Point(16, 38);
            dataGridViewMedicines.Margin = new Padding(4, 5, 4, 5);
            dataGridViewMedicines.Name = "dataGridViewMedicines";
            dataGridViewMedicines.RowHeadersWidth = 51;
            dataGridViewMedicines.Size = new Size(800, 231);
            dataGridViewMedicines.TabIndex = 0;
            // 
            // dataGridViewExpiredMedicines
            // 
            dataGridViewExpiredMedicines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExpiredMedicines.Location = new Point(16, 308);
            dataGridViewExpiredMedicines.Margin = new Padding(4, 5, 4, 5);
            dataGridViewExpiredMedicines.Name = "dataGridViewExpiredMedicines";
            dataGridViewExpiredMedicines.RowHeadersWidth = 51;
            dataGridViewExpiredMedicines.Size = new Size(800, 231);
            dataGridViewExpiredMedicines.TabIndex = 1;
            // 
            // dataGridViewLowStockMedicines
            // 
            dataGridViewLowStockMedicines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLowStockMedicines.Location = new Point(16, 577);
            dataGridViewLowStockMedicines.Margin = new Padding(4, 5, 4, 5);
            dataGridViewLowStockMedicines.Name = "dataGridViewLowStockMedicines";
            dataGridViewLowStockMedicines.RowHeadersWidth = 51;
            dataGridViewLowStockMedicines.Size = new Size(800, 231);
            dataGridViewLowStockMedicines.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 3;
            label1.Text = "Все лекарства";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 283);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(220, 20);
            label2.TabIndex = 4;
            label2.Text = "Лекарства с истекшим сроком";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 552);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(210, 20);
            label3.TabIndex = 5;
            label3.Text = "Лекарства с низким запасом";
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(868, 74);
            textBoxQuantity.Margin = new Padding(4, 5, 4, 5);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(132, 27);
            textBoxQuantity.TabIndex = 7;
            // 
            // comboBoxTransactionType
            // 
            comboBoxTransactionType.FormattingEnabled = true;
            comboBoxTransactionType.Items.AddRange(new object[] { "Поступление", "Расход" });
            comboBoxTransactionType.Location = new Point(867, 131);
            comboBoxTransactionType.Margin = new Padding(4, 5, 4, 5);
            comboBoxTransactionType.Name = "comboBoxTransactionType";
            comboBoxTransactionType.Size = new Size(132, 28);
            comboBoxTransactionType.TabIndex = 8;
            // 
            // buttonAddTransaction
            // 
            buttonAddTransaction.Location = new Point(841, 234);
            buttonAddTransaction.Margin = new Padding(4, 5, 4, 5);
            buttonAddTransaction.Name = "buttonAddTransaction";
            buttonAddTransaction.Size = new Size(188, 35);
            buttonAddTransaction.TabIndex = 9;
            buttonAddTransaction.Text = "Добавить транзакцию";
            buttonAddTransaction.UseVisualStyleBackColor = true;
            buttonAddTransaction.Click += async (s, e) => await buttonAddTransaction_Click(s, e);
            // 
            // textBoxNotes
            // 
            textBoxNotes.Location = new Point(867, 189);
            textBoxNotes.Margin = new Padding(4, 5, 4, 5);
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.Size = new Size(132, 27);
            textBoxNotes.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(868, 164);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 11;
            label4.Text = "Примечание";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(867, 38);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(90, 20);
            label6.TabIndex = 13;
            label6.Text = "Количество";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(867, 106);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(109, 20);
            label7.TabIndex = 14;
            label7.Text = "Тип операции";
            // 
            // button1
            // 
            button1.Location = new Point(824, 398);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(232, 35);
            button1.TabIndex = 15;
            button1.Text = "Добавить новый препарат";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MedicinesJournal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 846);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(textBoxNotes);
            Controls.Add(buttonAddTransaction);
            Controls.Add(comboBoxTransactionType);
            Controls.Add(textBoxQuantity);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewLowStockMedicines);
            Controls.Add(dataGridViewExpiredMedicines);
            Controls.Add(dataGridViewMedicines);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "MedicinesJournal";
            Text = "Журнал лекарственных средств";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMedicines).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpiredMedicines).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLowStockMedicines).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMedicines;
        private System.Windows.Forms.DataGridView dataGridViewExpiredMedicines;
        private System.Windows.Forms.DataGridView dataGridViewLowStockMedicines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.ComboBox comboBoxTransactionType;
        private System.Windows.Forms.Button buttonAddTransaction;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Button button1;
    }
}