namespace laba4
{
    partial class AddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fileServerComboBox = new System.Windows.Forms.ComboBox();
            this.databaseServerComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.documentServerComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.webServerComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 52);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(361, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Право доступа к файловому серверу";
            // 
            // fileServerComboBox
            // 
            this.fileServerComboBox.FormattingEnabled = true;
            this.fileServerComboBox.Location = new System.Drawing.Point(14, 105);
            this.fileServerComboBox.Name = "fileServerComboBox";
            this.fileServerComboBox.Size = new System.Drawing.Size(361, 24);
            this.fileServerComboBox.TabIndex = 3;
            // 
            // databaseServerComboBox
            // 
            this.databaseServerComboBox.FormattingEnabled = true;
            this.databaseServerComboBox.Location = new System.Drawing.Point(13, 162);
            this.databaseServerComboBox.Name = "databaseServerComboBox";
            this.databaseServerComboBox.Size = new System.Drawing.Size(361, 24);
            this.databaseServerComboBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Право доступа к серверу баз данных ";
            // 
            // documentServerComboBox
            // 
            this.documentServerComboBox.FormattingEnabled = true;
            this.documentServerComboBox.Location = new System.Drawing.Point(14, 223);
            this.documentServerComboBox.Name = "documentServerComboBox";
            this.documentServerComboBox.Size = new System.Drawing.Size(361, 24);
            this.documentServerComboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Право доступа к серверу документов";
            // 
            // webServerComboBox
            // 
            this.webServerComboBox.FormattingEnabled = true;
            this.webServerComboBox.Location = new System.Drawing.Point(14, 281);
            this.webServerComboBox.Name = "webServerComboBox";
            this.webServerComboBox.Size = new System.Drawing.Size(361, 24);
            this.webServerComboBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Право доступа к web-серверу";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(13, 329);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(360, 40);
            this.addBtn.TabIndex = 10;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 400);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.webServerComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.documentServerComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.databaseServerComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fileServerComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление пользователя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUser_FormClosing);
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fileServerComboBox;
        private System.Windows.Forms.ComboBox databaseServerComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox documentServerComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox webServerComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addBtn;
    }
}