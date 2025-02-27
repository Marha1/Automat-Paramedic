using Automat_Paramedic.Repository;
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

        public Form1()
        {
            _contextFactory = new ApplicationContextFactory();
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Открываем форму во весь экран
            this.WindowState = FormWindowState.Maximized;

            // Асинхронная инициализация интерфейса
            await SetupUIAsync();
        }

        private async Task SetupUIAsync()
        {
            // Настройка формы
            this.BackgroundImage = await LoadImageAsync("back_auth.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FormBorderStyle = FormBorderStyle.None;

            // Центрирование элементов по вертикали
            int centerY = this.ClientSize.Height / 2;

            // Аватар пользователя
            PictureBox avatar = new PictureBox
            {
                Image = await LoadImageAsync("avatar.jpg"),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent // Прозрачный фон
            };
            avatar.Location = new Point((this.ClientSize.Width - avatar.Width) / 2, centerY - 120); // Центрирование по горизонтали и вертикали
            Controls.Add(avatar);

            // Имя пользователя
            Label lblUsername = new Label
            {
                Text = _username,
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent // Прозрачный фон
            };
            lblUsername.Location = new Point((this.ClientSize.Width - lblUsername.Width) / 2, centerY - 50); // Центрирование по горизонтали и вертикали
            Controls.Add(lblUsername);

            // Поле для ввода пароля
            TextBox txtPassword = new TextBox
            {
                PasswordChar = '*',
                Size = new Size(200, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtPassword.Location = new Point((this.ClientSize.Width - txtPassword.Width) / 2, centerY); // Центрирование по горизонтали и вертикали
            Controls.Add(txtPassword);

            // Гифка загрузки (увеличиваем размер и центрируем)
            PictureBox loader = new PictureBox
            {
                Image = await LoadImageAsync("Iphone-spinner-2.gif"),
                Size = new Size(64, 64), // Увеличиваем размер гифки
                Visible = false,
                BackColor = Color.Transparent // Прозрачный фон
            };
            loader.Location = new Point((this.ClientSize.Width - loader.Width) / 2, centerY + 50); // Центрирование по горизонтали и вертикали
            Controls.Add(loader);

            // Кнопка входа
            Button btnLogin = new Button
            {
                Text = "→",
                Size = new Size(40, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(51, 153, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter // Выравнивание текста по центру
            };
            btnLogin.Location = new Point((this.ClientSize.Width - btnLogin.Width) / 2, centerY + 100); // Центрирование по горизонтали и вертикали
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 122, 204);
            Controls.Add(btnLogin);

            // Сообщение об ошибке
            Label lblError = new Label
            {
                Text = "Неверный пароль!",
                AutoSize = true,
                ForeColor = Color.Red,
                Visible = false,
                BackColor = Color.Transparent // Прозрачный фон
            };
            lblError.Location = new Point((this.ClientSize.Width - lblError.Width) / 2, centerY + 140); // Центрирование по горизонтали и вертикали
            Controls.Add(lblError);

            // Подпись внизу
            Label lblFooter = new Label
            {
                Text = "Windows 7 by marhal",
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent // Прозрачный фон
            };
            lblFooter.Location = new Point((this.ClientSize.Width - lblFooter.Width) / 2, this.ClientSize.Height - 50); // Внизу по центру
            Controls.Add(lblFooter);

            // Иконка Windows 7
            PictureBox windowsIcon = new PictureBox
            {
                Image = await LoadImageAsync("windows_15242.png"),
                Size = new Size(20, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent // Прозрачный фон
            };
            windowsIcon.Location = new Point(lblFooter.Left - windowsIcon.Width - 5, lblFooter.Top); // Слева от подписи
            Controls.Add(windowsIcon);

            // Обработчик клика по кнопке входа
            btnLogin.Click += async (sender, e) =>
            {
                // Скрываем TextBox и показываем GIF
                txtPassword.Visible = false;
                loader.Visible = true;
                btnLogin.Enabled = false;
                lblError.Visible = false;

                // Задержка 1.5-2 секунды
                await Task.Delay(1500); // 1.5 секунды

                // Проверяем пароль
                bool isValid = await CheckPassword(txtPassword.Text);

                // Возвращаем TextBox и скрываем GIF
                txtPassword.Visible = true;
                loader.Visible = false;
                btnLogin.Enabled = true;

                if (isValid)
                {
                    MessageBox.Show($"Добро пожаловать, {_username}!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    lblError.Visible = true;
                    txtPassword.Clear();
                }
            };
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
    }
}