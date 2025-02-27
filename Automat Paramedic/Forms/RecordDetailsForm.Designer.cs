namespace Automat_Paramedic.Forms
{
    partial class RecordDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblFullName;
        private Label lblDateOfBirth;
        private Label lblChronicDiseases;
        private Label lblAllergies;
        private Label lblVaccinations;

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
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblChronicDiseases = new System.Windows.Forms.Label();
            this.lblAllergies = new System.Windows.Forms.Label();
            this.lblVaccinations = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(20, 20);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(42, 20);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "ФИО:";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(20, 60);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(116, 20);
            this.lblDateOfBirth.TabIndex = 1;
            this.lblDateOfBirth.Text = "Дата рождения:";
            // 
            // lblChronicDiseases
            // 
            this.lblChronicDiseases.AutoSize = true;
            this.lblChronicDiseases.Location = new System.Drawing.Point(20, 100);
            this.lblChronicDiseases.Name = "lblChronicDiseases";
            this.lblChronicDiseases.Size = new System.Drawing.Size(162, 20);
            this.lblChronicDiseases.TabIndex = 2;
            this.lblChronicDiseases.Text = "Хронические заболевания:";
            // 
            // lblAllergies
            // 
            this.lblAllergies.AutoSize = true;
            this.lblAllergies.Location = new System.Drawing.Point(20, 140);
            this.lblAllergies.Name = "lblAllergies";
            this.lblAllergies.Size = new System.Drawing.Size(74, 20);
            this.lblAllergies.TabIndex = 3;
            this.lblAllergies.Text = "Аллергии:";
            // 
            // lblVaccinations
            // 
            this.lblVaccinations.AutoSize = true;
            this.lblVaccinations.Location = new System.Drawing.Point(20, 180);
            this.lblVaccinations.Name = "lblVaccinations";
            this.lblVaccinations.Size = new System.Drawing.Size(74, 20);
            this.lblVaccinations.TabIndex = 4;
            this.lblVaccinations.Text = "Прививки:";
            // 
            // RecordDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.lblVaccinations);
            this.Controls.Add(this.lblAllergies);
            this.Controls.Add(this.lblChronicDiseases);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblFullName);
            this.Name = "RecordDetailsForm";
            this.Text = "Детали карточки";
            this.Load += new System.EventHandler(this.RecordDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}