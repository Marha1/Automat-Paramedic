using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;


namespace Automat_Paramedic.Forms
{
    public partial class GoogleExplorerForm : Form
    {
        public GoogleExplorerForm()
        {
            InitializeComponent();
            InitializeBrowser();
        }

        private async void InitializeBrowser()
        {
            var webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(webView);
            await webView.EnsureCoreWebView2Async(null);
            webView.Source = new Uri("https://www.google.com");
        }

        private void GoogleExplorerForm_Load(object sender, EventArgs e)
        {

        }
    }

}
