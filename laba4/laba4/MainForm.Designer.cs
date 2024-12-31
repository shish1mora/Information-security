namespace laba4
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.accessRightsDataGridView = new System.Windows.Forms.DataGridView();
            this.nameResource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessRigths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.getFromFileBtn = new System.Windows.Forms.Button();
            this.saveToFileBtn = new System.Windows.Forms.Button();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addUserBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.countUsersTextBox = new System.Windows.Forms.TextBox();
            this.generateMatrixBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accessRightsDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.accessRightsDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(260, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 554);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список прав пользователя";
            // 
            // accessRightsDataGridView
            // 
            this.accessRightsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accessRightsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameResource,
            this.accessRigths});
            this.accessRightsDataGridView.Location = new System.Drawing.Point(7, 22);
            this.accessRightsDataGridView.Name = "accessRightsDataGridView";
            this.accessRightsDataGridView.RowHeadersWidth = 51;
            this.accessRightsDataGridView.RowTemplate.Height = 24;
            this.accessRightsDataGridView.Size = new System.Drawing.Size(515, 526);
            this.accessRightsDataGridView.TabIndex = 0;
            // 
            // nameResource
            // 
            this.nameResource.HeaderText = "Название ресурса";
            this.nameResource.MinimumWidth = 6;
            this.nameResource.Name = "nameResource";
            this.nameResource.Width = 170;
            // 
            // accessRigths
            // 
            this.accessRigths.HeaderText = "Назначенные права доступа";
            this.accessRigths.MinimumWidth = 6;
            this.accessRigths.Name = "accessRigths";
            this.accessRigths.Width = 170;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.generateMatrixBtn);
            this.groupBox2.Controls.Add(this.countUsersTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.getFromFileBtn);
            this.groupBox2.Controls.Add(this.saveToFileBtn);
            this.groupBox2.Controls.Add(this.usersListBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.addUserBtn);
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 554);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа с пользователями";
            // 
            // getFromFileBtn
            // 
            this.getFromFileBtn.Location = new System.Drawing.Point(9, 509);
            this.getFromFileBtn.Name = "getFromFileBtn";
            this.getFromFileBtn.Size = new System.Drawing.Size(214, 39);
            this.getFromFileBtn.TabIndex = 4;
            this.getFromFileBtn.Text = "Извлечь из файла";
            this.getFromFileBtn.UseVisualStyleBackColor = true;
            this.getFromFileBtn.Click += new System.EventHandler(this.getFromFileBtn_Click);
            // 
            // saveToFileBtn
            // 
            this.saveToFileBtn.Location = new System.Drawing.Point(9, 452);
            this.saveToFileBtn.Name = "saveToFileBtn";
            this.saveToFileBtn.Size = new System.Drawing.Size(214, 39);
            this.saveToFileBtn.TabIndex = 3;
            this.saveToFileBtn.Text = "Сохранить в файл";
            this.saveToFileBtn.UseVisualStyleBackColor = true;
            this.saveToFileBtn.Click += new System.EventHandler(this.saveToFileBtn_Click);
            // 
            // usersListBox
            // 
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.ItemHeight = 16;
            this.usersListBox.Location = new System.Drawing.Point(9, 241);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(214, 196);
            this.usersListBox.TabIndex = 2;
            this.usersListBox.SelectedIndexChanged += new System.EventHandler(this.usersListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пользователи";
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(7, 31);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(216, 57);
            this.addUserBtn.TabIndex = 0;
            this.addUserBtn.Text = "Добавить";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количество пользователей";
            // 
            // countUsersTextBox
            // 
            this.countUsersTextBox.Location = new System.Drawing.Point(9, 123);
            this.countUsersTextBox.Name = "countUsersTextBox";
            this.countUsersTextBox.Size = new System.Drawing.Size(214, 22);
            this.countUsersTextBox.TabIndex = 6;
            // 
            // generateMatrixBtn
            // 
            this.generateMatrixBtn.Location = new System.Drawing.Point(9, 152);
            this.generateMatrixBtn.Name = "generateMatrixBtn";
            this.generateMatrixBtn.Size = new System.Drawing.Size(214, 58);
            this.generateMatrixBtn.TabIndex = 7;
            this.generateMatrixBtn.Text = "Сгенерировать матрицу доступа ";
            this.generateMatrixBtn.UseVisualStyleBackColor = true;
            this.generateMatrixBtn.Click += new System.EventHandler(this.generateMatrixBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Реализация дискреционной модели политики безопасности";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accessRightsDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.DataGridView accessRightsDataGridView;
        private System.Windows.Forms.Button getFromFileBtn;
        private System.Windows.Forms.Button saveToFileBtn;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameResource;
        private System.Windows.Forms.DataGridViewTextBoxColumn accessRigths;
        private System.Windows.Forms.Button generateMatrixBtn;
        private System.Windows.Forms.TextBox countUsersTextBox;
        private System.Windows.Forms.Label label2;
    }
}

