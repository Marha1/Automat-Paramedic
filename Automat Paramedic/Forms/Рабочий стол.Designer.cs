namespace Automat_Paramedic
{
    partial class Рабочий_стол
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
            desktopPanel = new Primitives.BufferedPanel();
            SuspendLayout();
            // 
            // desktopPanel
            // 
            desktopPanel.Location = new Point(0, 0);
            desktopPanel.Name = "desktopPanel";
            desktopPanel.Size = new Size(200, 100);
            desktopPanel.TabIndex = 0;
            // 
            // Рабочий_стол
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Рабочий_стол";
            Text = "Рабочий_стол";
            WindowState = FormWindowState.Maximized;
            Load += Рабочий_стол_Load;
            ResumeLayout(false);
        }
    }

        #endregion
}

 