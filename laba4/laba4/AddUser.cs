using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            SetRightsInComboBoxes();

            fileServerComboBox.SelectedIndex = 0;
            databaseServerComboBox.SelectedIndex = 0;
            documentServerComboBox.SelectedIndex = 0;
            webServerComboBox.SelectedIndex = 0;
        }

        private void SetRightsInComboBoxes() 
        {
            var rights = Enum.GetValues(typeof(Right));

            foreach (var right in rights)
            {
                fileServerComboBox.Items.Add(right);
                databaseServerComboBox.Items.Add(right);
                documentServerComboBox.Items.Add(right);
                webServerComboBox.Items.Add(right);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Необходимо ввести имя пользователя!", "Добавление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                AccessRights accessRights = new AccessRights((Right)fileServerComboBox.SelectedItem, (Right)databaseServerComboBox.SelectedItem, (Right)documentServerComboBox.SelectedItem, (Right)webServerComboBox.SelectedItem);

                User user = new User(nameTextBox.Text, accessRights);
                MainForm mainForm = new MainForm(user);
                mainForm.Show();
                this.Hide();
            }
        }

        private void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
