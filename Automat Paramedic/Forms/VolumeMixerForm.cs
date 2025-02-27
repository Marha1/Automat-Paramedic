using NAudio.CoreAudioApi;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Automat_Paramedic.Forms
{
    public partial class VolumeMixerForm : Form
    {
        private MMDeviceEnumerator deviceEnumerator;
        private MMDevice defaultDevice;
        private PictureBox volumeIcon; // Значок динамика на панели задач

        public VolumeMixerForm(PictureBox volumeIcon)
        {
            InitializeComponent();
            this.volumeIcon = volumeIcon; // Передаем значок динамика
            InitializeMixer();
        }

        private void InitializeMixer()
        {
            // Инициализация аудиоустройства
            deviceEnumerator = new MMDeviceEnumerator();
            defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // Создаем TrackBar для регулировки громкости
            TrackBar volumeTrackBar = new TrackBar
            {
                Orientation = Orientation.Vertical,
                Minimum = 0,
                Maximum = 100,
                Value = (int)(defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100),
                TickFrequency = 10,
                Size = new Size(45, 150),
                Location = new Point(10, 10)
            };

            // Обработчик изменения громкости
            volumeTrackBar.Scroll += (s, e) =>
            {
                defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volumeTrackBar.Value / 100f;
            };

            // Создаем кнопку для отключения звука
            Button muteButton = new Button
            {
                Text = defaultDevice.AudioEndpointVolume.Mute ? "Включить звук" : "Отключить звук",
                Size = new Size(100, 30),
                Location = new Point(70, 10)
            };

            // Обработчик клика по кнопке
            muteButton.Click += (s, e) =>
            {
                defaultDevice.AudioEndpointVolume.Mute = !defaultDevice.AudioEndpointVolume.Mute;
                muteButton.Text = defaultDevice.AudioEndpointVolume.Mute ? "Включить звук" : "Отключить звук";

                // Обновляем значок динамика
                UpdateVolumeIcon();
            };

            // Добавляем элементы на форму
            this.Controls.Add(volumeTrackBar);
            this.Controls.Add(muteButton);

            // Настройка формы
            this.Size = new Size(200, 200);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Cursor.Position.X, Cursor.Position.Y - this.Height);
        }

        private void UpdateVolumeIcon()
        {
            if (defaultDevice.AudioEndpointVolume.Mute)
            {
                // Звук выключен
                volumeIcon.Image = Image.FromFile("volume_off.png"); // Путь к изображению "Звук выключен"
            }
            else
            {
                // Звук включен
                volumeIcon.Image = Image.FromFile("volume_on.png"); // Путь к изображению "Звук включен"
            }
        }

        private void VolumeMixerForm_Load(object sender, EventArgs e)
        {
            // При загрузке формы обновляем значок динамика
            UpdateVolumeIcon();
        }
    }
}