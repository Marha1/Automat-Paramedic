using Automat_Paramedic.Repository;
using Automat_Paramedic.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automat_Paramedic
{
    public partial class Form1 : Form
    {
        private readonly ApplicationContextFactory _contextFactory;
        private readonly string _username = "Medic";
        private readonly EmailService _emailService;

        private PictureBox loader;
        private TextBox txtPassword;
        private Label lblError;
        private Button btnLogin;

        public Form1()
        {
            _contextFactory = new ApplicationContextFactory();
            InitializeComponent();
            _emailService = new EmailService(_contextFactory);
            this.DoubleBuffered = true;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            await SetupUIAsync();
        }

        private async Task SetupUIAsync()
        {
            var images = await Task.WhenAll(
                LoadImageAsync("back_auth.jpg"),
                LoadImageAsync("avatar.jpg"),
                LoadImageAsync("ZZ5H.gif"),
                LoadImageAsync("windows_15242.png")
            );

            this.BackgroundImage = images[0];
            this.BackgroundImageLayout = ImageLayout.Stretch;

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Аватар
            var avatar = CreatePictureBox(images[1], new Size(100, 100), new Point(centerX - 50, centerY - 120));
            Controls.Add(avatar);

            // Имя пользователя
            var lblUsername = CreateLabel(_username, new Font("Segoe UI", 12, FontStyle.Bold), centerX, centerY - 50);
            Controls.Add(lblUsername);

            // Поле ввода пароля
            txtPassword = new TextBox
            {
                PasswordChar = '*',
                Size = new Size(200, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(centerX - 100, centerY)
            };
            Controls.Add(txtPassword);

            var lblForgotPassword = new LinkLabel
            {
                Text = "Забыли пароль?",
                Location = new Point(txtPassword.Left, txtPassword.Bottom + 5),
                AutoSize = true,
                ForeColor = Color.LightGray,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Cursor = Cursors.Hand
            };
            lblForgotPassword.Click += LblForgotPassword_Click;
            Controls.Add(lblForgotPassword);

            // Добавляем эффект при наведении
            lblForgotPassword.MouseEnter += (s, e) => lblForgotPassword.ForeColor = Color.White;
            lblForgotPassword.MouseLeave += (s, e) => lblForgotPassword.ForeColor = Color.LightGray;
            // Гифка загрузки
            loader = CreatePictureBox(images[2], new Size(32, 32), new Point(centerX - 16, centerY + 50));
            loader.Visible = false;
            Controls.Add(loader);

            // Кнопка входа
             btnLogin = new Button
            {
                Text = "→",
                Size = new Size(50, 35), 
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(51, 153, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold), 
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(txtPassword.Right + 10, txtPassword.Top) 
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 122, 204);
            btnLogin.Click += BtnLogin_Click;
            Controls.Add(btnLogin);

            // Сообщение об ошибке
            lblError = CreateLabel("Неверный пароль!", new Font("Segoe UI", 10, FontStyle.Bold), centerX, centerY + 140);
            lblError.ForeColor = Color.Red;
            lblError.Visible = false;
            Controls.Add(lblError);

            // Подпись "Windows 7 by marhal"
            var lblFooter = CreateLabel("Windows 7 by Marhal", new Font("Segoe UI", 10, FontStyle.Bold), centerX, this.ClientSize.Height - 50);
            Controls.Add(lblFooter);

            // Иконка Windows 7
            var windowsIcon = CreatePictureBox(images[3], new Size(20, 20), new Point(lblFooter.Left - 25, lblFooter.Top));
            Controls.Add(windowsIcon);
        }
        private async void LblForgotPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // Запрашиваем email пользователя
                string email = Microsoft.VisualBasic.Interaction.InputBox(
                    "Введите ваш email для восстановления пароля:",
                    "Восстановление пароля",
                    "");

                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Почта не может быть пустой");
                    return;
                }

                loader.Visible = true;
                btnLogin.Enabled = false;
                txtPassword.Enabled = false;

                // Используем существующий сервис
                bool result = await _emailService.SendResetPasswordEmailAsync (email);

                if (result)
                {
                    MessageBox.Show("Инструкции по восстановлению пароля были отправлены на вашу почту.",
                                  "Письмо отправлено",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось отправить письмо. Проверьте правильность email или обратитесь к администратору.",
                                  "Ошибка",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            finally
            {
                loader.Visible = false;
                btnLogin.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            txtPassword.Visible = false;
            loader.Visible = true;
            btnLogin.Visible = false;   
            lblError.Visible = false;
            ((Button)sender).Enabled = false;

            await Task.Delay(2000); 

            bool isValid = await CheckPassword(txtPassword.Text);

            txtPassword.Visible = true;
            loader.Visible = false;
            ((Button)sender).Enabled = true;

            if (isValid)
            {
                MessageBox.Show($"Добро пожаловать, {_username}!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);


                var form = new Рабочий_стол();
                form.ShowDialog();
                
                this.Hide();
            }
            else
            {
                lblError.Visible = true;
                btnLogin.Visible = true;
                txtPassword.Clear();
            }
        }

        private async Task<Image> LoadImageAsync(string path)
        {
            return await Task.Run(() => Image.FromFile(path));
        }

        private async Task<bool> CheckPassword(string password)
        {
            using var _application = _contextFactory.CreateDbContext();
            return await _application.Users.AnyAsync(u => u.Login == _username && u.password == password);
        }

        private PictureBox CreatePictureBox(Image image, Size size, Point location)
        {
            return new PictureBox
            {
                Image = image,
                Size = size,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Location = location
            };
        }

        private Label CreateLabel(string text, Font font, int centerX, int posY)
        {
            var label = new Label
            {
                Text = text,
                Font = font,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = true
            };

            label.Left = centerX - (label.PreferredWidth / 2);
            label.Top = posY;

            return label;
        }
    }
}
