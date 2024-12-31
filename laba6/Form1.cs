using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<CRCFile> crcFiles;
        string directoryPath;
        const string nameOfSavedJson = "saved_crc.json";

        public Form1()
        {
            InitializeComponent();
            crcFiles = new List<CRCFile>();
        }


        private void selectDirectoryBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    directoryPath = folderDialog.SelectedPath;
                    directoryLabel.Text = "Директория: " + folderDialog.SelectedPath;
                }
            }
        }

        private void getCRCBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(directoryPath))
            {
                try
                {
                    FillingInCRCList();

                    string jsonResult = JsonSerializer.Serialize(crcFiles, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                    File.WriteAllText(nameOfSavedJson, jsonResult);

                    dataLabel.Text = $"Данные можно получить в {nameOfSavedJson}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка получения CRC: {ex.Message}", "Получить CRC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Данной директории не существует", "Получить CRC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillingInCRCList() 
        {
            crcFiles.Clear();

            string[] files = Directory.GetFiles(directoryPath);

            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string crc = CRCFile.CalculateCRC(filePath);

                CRCFile fileInfo = new CRCFile
                {
                    FileName = fileName,
                    CRC32 = crc
                };

                crcFiles.Add(fileInfo);
            }

        }

        private void compareCRCBtn_Click(object sender, EventArgs e)
        {
            saveSRCTextBox.Text = "";
            currentCRCTextBox.Text = "";

            string savedCrc = File.ReadAllText(nameOfSavedJson);

            saveSRCTextBox.Text += "Сохраненный CRC\n";
            saveSRCTextBox.Text += savedCrc;

            string currentCrc = "";

            if (Directory.Exists(directoryPath))
            {
                try
                {
                  
                    FillingInCRCList();

                    currentCrc = JsonSerializer.Serialize(crcFiles, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                    currentCRCTextBox.Text += "Текущий CRC\n";
                    currentCRCTextBox.Text += currentCrc;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сравнения CRC: {ex.Message}", "Сравнить CRC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Данной директории не существует", "Сравнить CRC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (savedCrc == currentCrc)
            {
                compareLabel.Text = "В директории не произошло изменение CRC";
                compareLabel.ForeColor = Color.Green;
            }
            else
            {
                compareLabel.Text = "В директории произошло изменение CRC";
                compareLabel.ForeColor = Color.Red;
            }

            saveResultBtn.Enabled = true;
            
        }

        private void saveResultBtn_Click(object sender, EventArgs e)
        {
            saveResultBtn.Enabled = false;

            try
            {
                string savedComparisonFileName = "save.txt";
                string savedСomparisonFilePath = Directory.GetCurrentDirectory() +$"\\{savedComparisonFileName}";


                string result = $"{saveSRCTextBox.Text}\n{currentCRCTextBox.Text}";

                File.WriteAllText(savedСomparisonFilePath, result);

                saveLabel.Text = $"Данные о сравнении можно получить в {savedComparisonFileName}";
                saveLabel.ForeColor = Color.Green;
            }
            catch 
            {
                MessageBox.Show("Ошибка сохранения сравнения", "Сохранить сравнение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
