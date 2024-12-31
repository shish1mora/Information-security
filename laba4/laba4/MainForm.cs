using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace laba4
{
    public partial class MainForm : Form
    {

        private static List<User> users = new List<User>();
        private static string pathToFile = Directory.GetCurrentDirectory() + "\\accessRigths.txt";


        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(User user)
        {
            InitializeComponent();
            users.Add(user);
        }



        private void addUserBtn_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addUsersToListBox();
        }


        private void usersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usersListBox.SelectedItem != null)
            {
                accessRightsDataGridView.Rows.Clear();

                accessRightsDataGridView.Rows.Add("Файловый сервер", users[usersListBox.SelectedIndex].rights.fileServer.ToString());
                accessRightsDataGridView.Rows.Add("Сервер баз данных", users[usersListBox.SelectedIndex].rights.databaseServer.ToString());
                accessRightsDataGridView.Rows.Add("Сервер документов", users[usersListBox.SelectedIndex].rights.documentServer.ToString());
                accessRightsDataGridView.Rows.Add("Web-сервер", users[usersListBox.SelectedIndex].rights.webServer.ToString());
            }
        }

        private void saveToFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var file = File.Create(pathToFile);
                file.Close();

                using (var textWriter = new StreamWriter(pathToFile))
                {
                    foreach (User user in users)
                    {
                        textWriter.WriteLine(user.ToString());
                    }
                }

                MessageBox.Show("Пользователи сохранены в файл!", "Сохранить в файл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения данных в файл", "Сохранить в файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getFromFileBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены,что хотите извлечь данные о пользователях из файла? Введенные данные исчезнут", "Извлечь из файла", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (File.Exists(pathToFile))
                {
                    clearDataAboutUsers();

                    using (var streamReader = new StreamReader(pathToFile))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string line = streamReader.ReadLine();

                            string name = line.Substring(0, line.IndexOf(':'));
                            string[] rights = line.Substring(line.IndexOf(':') + 1).Split(';');


                            AccessRights accessRights = new AccessRights((Right)Enum.Parse(typeof(Right), rights[0]), (Right)Enum.Parse(typeof(Right), rights[1]), (Right)Enum.Parse(typeof(Right), rights[2]), (Right)Enum.Parse(typeof(Right), rights[3]));
                            users.Add(new User(name, accessRights));
                        }
                    }

                    addUsersToListBox();
                }
                else
                {
                    MessageBox.Show("Файл с данными о пользователях не существует", "Извлечь из файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void addUsersToListBox()
        {
            foreach (User user in users)
            {
                usersListBox.Items.Add(user.name);
            }
        }

        private void clearDataAboutUsers() 
        {
            users.Clear();
            usersListBox.Items.Clear();
            accessRightsDataGridView.Rows.Clear();
        }

        private void generateMatrixBtn_Click(object sender, EventArgs e)
        {
            int countUsers;
            if (int.TryParse(countUsersTextBox.Text, out countUsers))
            {
                if (countUsers > 0)
                {
                    clearDataAboutUsers();
                    Random random = new Random();

                    for (int i = 0; i < countUsers; i++) 
                    {
                        string name = "Пользователь №" + (i + 1).ToString();
                        AccessRights accessRights = new AccessRights((Right)random.Next(0, 5), (Right)random.Next(0, 5), (Right)random.Next(0, 5), (Right)random.Next(0, 5));

                        users.Add(new User(name, accessRights));
                    }

                    users.Add(new User("Администратор", new AccessRights(laba4.Right.Administrator, laba4.Right.Administrator, laba4.Right.Administrator, laba4.Right.Administrator)));

                    addUsersToListBox();
                    //countUsersTextBox.Text = "";
                }
                else 
                {
                    MessageBox.Show("Для генерации матрицы необходимо количество пользователей > 0", "Сгенерировать матрицу доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else 
            {
                MessageBox.Show("Необходимо ввести число", "Сгенерировать матрицу доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
