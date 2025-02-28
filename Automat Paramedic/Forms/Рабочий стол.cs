using Automat_Paramedic.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Diagnostics;
using Automat_Paramedic.Service;

namespace Automat_Paramedic
{
    public partial class Рабочий_стол : Form
    {
        private Panel desktopPanel;
        private Panel taskbar;
        private PictureBox volumeIcon; // Значок динамика
        private Label clockLabel;
        private PictureBox internetIcon;
        private System.Windows.Forms.Timer timer;
        private Point _dragStartPoint; // Точка начала перетаскивания
        private Panel _draggedPanel; // Перемещаемая панель иконки
        private bool _isDragging = false; // Флаг для отслеживания перетаскивания
        private List<Form> openPrograms; // Список открытых программ
        private Dictionary<Form, Panel> programIcons; // Теперь словарь хранит Panel

        // Переменные для хранения позиции последней иконки
        private int _lastIconX = 10; // Начальная позиция по X
        private int _lastIconY = 10; // Начальная позиция по Y
        private const int IconSpacing = 10; // Отступ между иконками

        // Размеры иконки интернета
        private Size internetIconSizeConnected = new Size(23, 23); // Размер иконки при подключенном интернете
        private Size internetIconSizeDisconnected = new Size(25, 25); // Размер иконки при отключенном интернете

        // Кнопка "Пуск" и меню
        private Button startButton; // Кнопка "Пуск"
        private ContextMenuStrip startMenu; // Контекстное меню для кнопки "Пуск"

        public Рабочий_стол()
        {
            InitializeComponent();
            IsMdiContainer = true;
            InitializeDesktopUI();
            InitializeTaskbar();
            InitializeClock();
            InitializeStartButton();
            programIcons = new Dictionary<Form, Panel>();
            openPrograms = new List<Form>();
        }

        private void InitializeDesktopUI()
        {
            try
            {
                desktopPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    BackgroundImageLayout = ImageLayout.Stretch
                };
                desktopPanel.BackgroundImage = Image.FromFile("background1.jpg");

                this.Controls.Add(desktopPanel);
                AddAppIcons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки интерфейса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image LoadHighQualityButtonImage(string path, int width, int height)
        {
            if (!File.Exists(path)) return null;
            using (var srcImage = Image.FromFile(path))
            {
                var newImage = new Bitmap(width, height);
                using (var g = Graphics.FromImage(newImage))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(srcImage, 0, 0, width, height);
                }
                return newImage;
            }
        }

        private void AddAppIcons()
        {
            AddAppIcon("Медкарты", "medcards.png", typeof(MedicalRecordsForm));
            AddAppIcon("Журнал медикаментов", "medicines.png", typeof(MedicinesJournal));
            AddAppIcon("Google Chrome", "google.png", typeof(GoogleExplorerForm));
            AddAppIcon("Обращения", "request.png", typeof(AppointmentsForm));
            AddAppIcon("Вакцинация", "vac.png", typeof(VaccinationForm));
            AddAppIcon("Поиск и Отчеты", "report.png", typeof(SearchAndReportForm));

        }

        private void AddAppIcon(string text, string iconPath, Type formType)
        {
            string fullPath = Path.Combine(Application.StartupPath, iconPath);
            if (!File.Exists(fullPath))
            {
                MessageBox.Show($"Файл {fullPath} не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Panel iconPanel = new Panel
            {
                Size = new Size(80, 100),
                BackColor = Color.Transparent,
                Location = new Point(_lastIconX, _lastIconY),
                Tag = formType
            };

            _lastIconX += iconPanel.Width + IconSpacing;

            if (_lastIconX + iconPanel.Width > desktopPanel.ClientSize.Width)
            {
                _lastIconX = 10;
                _lastIconY += iconPanel.Height + IconSpacing;
            }

            iconPanel.MouseDown += Icon_MouseDown;
            iconPanel.MouseMove += Icon_MouseMove;
            iconPanel.MouseUp += Icon_MouseUp;

            PictureBox pictureBox = new PictureBox
            {
                Image = LoadHighQualityButtonImage(fullPath, 48, 48),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(48, 48),
                Cursor = Cursors.Hand,
                Location = new Point(16, 10),
                BackColor = Color.Transparent
            };

            Label label = new Label
            {
                Text = text,
                ForeColor = Color.White,
                AutoSize = false,
                Width = 80,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Location = new Point(0, 60),
                BackColor = Color.Transparent
            };

            pictureBox.MouseDown += (s, e) => Icon_MouseDown(iconPanel, e);
            pictureBox.MouseMove += (s, e) => Icon_MouseMove(iconPanel, e);
            pictureBox.MouseUp += (s, e) => Icon_MouseUp(iconPanel, e);

            label.MouseDown += (s, e) => Icon_MouseDown(iconPanel, e);
            label.MouseMove += (s, e) => Icon_MouseMove(iconPanel, e);
            label.MouseUp += (s, e) => Icon_MouseUp(iconPanel, e);

            iconPanel.Controls.Add(pictureBox);
            iconPanel.Controls.Add(label);
            desktopPanel.Controls.Add(iconPanel);

            pictureBox.Click += (s, e) => OpenChildForm(formType);
            label.Click += (s, e) => OpenChildForm(formType);
        }

        private void Icon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _draggedPanel = sender as Panel;
                if (_draggedPanel != null)
                {
                    _dragStartPoint = e.Location;
                    _isDragging = false;
                    _draggedPanel.Capture = true;
                }
            }
        }

        private void Icon_MouseMove(object sender, MouseEventArgs e)
        {
            if (_draggedPanel != null && e.Button == MouseButtons.Left)
            {
                if (!_isDragging && (Math.Abs(e.X - _dragStartPoint.X) > 5 || Math.Abs(e.Y - _dragStartPoint.Y) > 5))
                {
                    _isDragging = true;
                    desktopPanel.SuspendLayout(); // Остановить обновление интерфейса
                }

                if (_isDragging)
                {
                    Point cursorPosition = desktopPanel.PointToClient(Cursor.Position);
                    int newX = cursorPosition.X - _dragStartPoint.X;
                    int newY = cursorPosition.Y - _dragStartPoint.Y;

                    newX = Math.Max(0, Math.Min(newX, desktopPanel.ClientSize.Width - _draggedPanel.Width));
                    newY = Math.Max(0, Math.Min(newY, desktopPanel.ClientSize.Height - _draggedPanel.Height));

                    _draggedPanel.Location = new Point(newX, newY);
                }
            }
        }


        private void Icon_MouseUp(object sender, MouseEventArgs e)
        {
            if (_draggedPanel != null)
            {
                _draggedPanel.Capture = false;

                if (!_isDragging)
                {
                    OpenChildForm((Type)_draggedPanel.Tag);
                }

                _draggedPanel = null;
                _isDragging = false;
            }
        }

        private void InitializeTaskbar()
        {
            try
            {
                taskbar = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    BackColor = Color.FromArgb(30, 30, 30)
                };

                clockLabel = new Label
                {
                    Dock = DockStyle.Right,
                    ForeColor = Color.White,
                    AutoSize = true,
                    Padding = new Padding(5, 10, 10, 10),
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Times new Roman", 8, FontStyle.Regular)
                };

                taskbar.Controls.Add(clockLabel);

                internetIcon = new PictureBox
                {
                    Size = internetIconSizeConnected,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = GetInternetIcon(false),
                };

                volumeIcon = new PictureBox
                {
                    Size = new Size(21, 21),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile("volume_on.png"),
                    Cursor = Cursors.Hand
                };

                UpdateInternetIconPosition();

                volumeIcon.Click += (s, e) => ShowVolumeMixer();

                taskbar.Controls.Add(internetIcon);
                taskbar.Controls.Add(volumeIcon);

                this.Controls.Add(taskbar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void ShowVolumeMixer()
        {
            VolumeMixerForm volumeMixer = new VolumeMixerForm(volumeIcon);
            volumeMixer.Show();
        }

        private void UpdateInternetIconPosition()
        {
            int iconX = clockLabel.Location.X - internetIcon.Width - 5;
            int iconY = (taskbar.Height - internetIcon.Height) / 2;

            internetIcon.Location = new Point(iconX, iconY);
            UpdateVolumeIconPosition();
        }

        private void UpdateVolumeIconPosition()
        {
            int iconX = internetIcon.Location.X - volumeIcon.Width - 10;
            int iconY = (taskbar.Height - volumeIcon.Height) / 2;

            volumeIcon.Location = new Point(iconX, iconY);
        }

        private void InitializeClock()
        {
            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += async (s, e) => await UpdateClock();
            timer.Start();
        }

        private async Task UpdateClock()
        {
            try
            {
                clockLabel.Text = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy") + " | " + GetCurrentInputLanguage();

                bool isConnected = await InternetService.CheckInternetConnectionAsync();
                internetIcon.Image = GetInternetIcon(isConnected);

                if (isConnected)
                {
                    internetIcon.Size = internetIconSizeConnected;
                }
                else
                {
                    internetIcon.Size = internetIconSizeDisconnected;
                }

                UpdateInternetIconPosition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetCurrentInputLanguage()
        {
            return InputLanguage.CurrentInputLanguage.LayoutName;
        }

        private Image GetInternetIcon(bool isConnected)
        {
            if (isConnected)
            {
                return Image.FromFile("internet_connected.png");
            }
            else
            {
                return Image.FromFile("internet_disconnected.png");
            }
        }

        private void AddProgramIcon(Form programForm)
        {
            Icon programIcon = programForm.Icon ?? SystemIcons.Application;
            Bitmap iconBitmap = new Bitmap(programIcon.ToBitmap(), new Size(32, 32));

            PictureBox taskbarIcon = new PictureBox
            {
                Size = new Size(32, 32),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = iconBitmap,
                Cursor = Cursors.Hand,
                Tag = programForm
            };

            Panel iconPanel = new Panel
            {
                Size = new Size(36, 36),
                BackColor = Color.Transparent,
                Padding = new Padding(2),
                Tag = programForm
            };

            taskbarIcon.Location = new Point(2, 2);
            iconPanel.Controls.Add(taskbarIcon);

            taskbarIcon.Click += (s, e) =>
            {
                if (programForm.WindowState == FormWindowState.Minimized)
                {
                    programForm.WindowState = FormWindowState.Normal;
                }
                programForm.BringToFront();
                programForm.Focus();
            };

            taskbarIcon.MouseEnter += (s, e) =>
            {
                iconPanel.BackColor = Color.FromArgb(50, 50, 50);
            };

            taskbarIcon.MouseLeave += (s, e) =>
            {
                iconPanel.BackColor = Color.Transparent;
            };

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem closeMenuItem = new ToolStripMenuItem("Закрыть программу");
            closeMenuItem.Click += (s, e) => programForm.Close();
            contextMenu.Items.Add(closeMenuItem);

            taskbarIcon.ContextMenuStrip = contextMenu;

            taskbar.Controls.Add(iconPanel);

            programIcons.Add(programForm, iconPanel);
            openPrograms.Add(programForm);

            UpdateTaskbarIconsPosition();
        }

        private void OpenChildForm(Type formType)
        {
            Form existingForm = openPrograms.FirstOrDefault(f => f.GetType() == formType);
            if (existingForm != null)
            {
                if (existingForm.WindowState == FormWindowState.Minimized)
                {
                    existingForm.WindowState = FormWindowState.Normal;
                }
                existingForm.BringToFront();
                existingForm.Focus();
                return;
            }

            Form childForm = (Form)Activator.CreateInstance(formType);
            childForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            childForm.FormClosed += ChildForm_FormClosed;

            childForm.Show();
            AddProgramIcon(childForm);
        }

        private void RemoveProgramIcon(Form programForm)
        {
            if (programIcons.ContainsKey(programForm))
            {
                Panel iconPanel = programIcons[programForm];
                taskbar.Controls.Remove(iconPanel);
                programIcons.Remove(programForm);
                openPrograms.Remove(programForm);

                UpdateTaskbarIconsPosition();
            }
        }

        private void UpdateTaskbarIconsPosition()
        {
            int startX = startButton.Right + 10;
            int startY = (taskbar.Height - 36) / 2;

            foreach (var iconPanel in programIcons.Values)
            {
                iconPanel.Location = new Point(startX, startY);
                startX += iconPanel.Width + 5;
            }
        }

        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RemoveProgramIcon((Form)sender);
        }

        private void InitializeStartButton()
        {
            startButton = new Button
            {
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Size = new Size(40, 40),
                Location = new Point(0, 0),
                Image = LoadHighQualityButtonImage("start_button.png", 40, 40),
                ImageAlign = ContentAlignment.MiddleCenter,
                Text = "",
                FlatAppearance = { BorderSize = 0 }
            };

            startButton.Paint += (s, e) =>
            {
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, startButton.Width - 1, startButton.Height - 1);
                    startButton.Region = new Region(path);
                }
            };

            startMenu = new ContextMenuStrip();
            startMenu.Items.Add("Перезагрузить компьютер", null, (s, e) => RebootComputer());
            startMenu.Items.Add("Выключить компьютер", null, (s, e) => ShutdownComputer());
            startMenu.Items.Add("Заблокировать ПК", null, (s, e) => LockComputer());

            startButton.Click += (s, e) => startMenu.Show(startButton, new Point(0, startButton.Height));

            taskbar.Controls.Add(startButton);
        }

        private void RebootComputer()
        {
            var result = MessageBox.Show("Вы уверены, что хотите перезагрузить компьютер?", "Перезагрузка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Process.Start("shutdown", "/r /t 0");
            }
        }

        private void ShutdownComputer()
        {
            var result = MessageBox.Show("Вы уверены, что хотите выключить компьютер?", "Выключение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Process.Start("shutdown", "/s /t 0");
            }
        }

        private void LockComputer()
        {
            this.Hide();
            var firstForm = new Form1();
            firstForm.Show();
        }

        private void Рабочий_стол_Load(object sender, EventArgs e)
        {
            
        }
    }
}