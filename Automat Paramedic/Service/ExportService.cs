using Automat_Paramedic.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Automat_Paramedic.Service
{
    public static class ExportService
    {
        private static List<MedicalRecord> _recordsToPrint;
        private static int _currentPrintIndex;

        public static void ExportToCSV(List<MedicalRecord> records)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Сохранить как CSV",
                    DefaultExt = "csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";",
                        Encoding = Encoding.UTF8
                    };

                    using (var writer = new StreamWriter(saveFileDialog.FileName, false, new UTF8Encoding(true)))
                    using (var csv = new CsvWriter(writer, config))
                    {
                        csv.WriteField("ФИО");
                        csv.WriteField("Дата рождения");
                        csv.WriteField("Хронические заболевания");
                        csv.WriteField("Аллергии");
                        csv.WriteField("Прививки");
                        csv.NextRecord();

                        foreach (var record in records)
                        {
                            csv.WriteField(record.FullName);
                            csv.WriteField($"=\"{record.DateOfBirth:dd.MM.yyyy}\"");
                            csv.WriteField(record.ChronicDiseases);
                            csv.WriteField(record.Allergies);
                            csv.WriteField(record.Vaccinations);
                            csv.NextRecord();
                        }
                    }
                    MessageBox.Show("Данные успешно экспортированы в CSV.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Print(List<MedicalRecord> records)
        {
            try
            {
                _recordsToPrint = records;
                _currentPrintIndex = 0;

                var printDocument = new PrintDocument();
                printDocument.PrintPage += PrintPageHandler;

                var printDialog = new PrintDialog { Document = printDocument };
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    MessageBox.Show("Данные успешно отправлены на печать.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            var font = new Font("Arial", 10);
            var brush = Brushes.Black;
            float yPos = 50;
            float xPos = 50;
            int count = 0;
            float[] columnWidths = { 150, 120, 200, 100, 100 };
            string[] headers = { "ФИО", "Дата рождения", "Хронические заболевания", "Аллергии", "Прививки" };

            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.DrawString(headers[i], font, brush, xPos, yPos);
                xPos += columnWidths[i];
            }
            yPos += font.GetHeight() + 10;

            while (_currentPrintIndex < _recordsToPrint.Count && count < 50)
            {
                xPos = 50;
                var record = _recordsToPrint[_currentPrintIndex];
                string[] fields =
                {
                    record.FullName,
                    record.DateOfBirth.ToString("dd.MM.yyyy"),
                    TrimText(record.ChronicDiseases, 30),
                    TrimText(record.Allergies, 15),
                    TrimText(record.Vaccinations, 15)
                };

                for (int i = 0; i < fields.Length; i++)
                {
                    e.Graphics.DrawString(fields[i], font, brush, xPos, yPos);
                    xPos += columnWidths[i];
                }

                yPos += font.GetHeight() + 5;
                count++;
                _currentPrintIndex++;
            }

            e.HasMorePages = _currentPrintIndex < _recordsToPrint.Count;
        }

        private static string TrimText(string text, int maxLength)
        {
            return string.IsNullOrEmpty(text) ? "" : text.Length > maxLength ? text.Substring(0, maxLength) + "..." : text;
        }
    }
}
