namespace WindowsFormsApp1
{
    partial class Form1
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
            this.selectDirectoryBtn = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.getCRCBtn = new System.Windows.Forms.Button();
            this.compareCRCBtn = new System.Windows.Forms.Button();
            this.dataLabel = new System.Windows.Forms.Label();
            this.compareLabel = new System.Windows.Forms.Label();
            this.saveSRCTextBox = new System.Windows.Forms.RichTextBox();
            this.currentCRCTextBox = new System.Windows.Forms.RichTextBox();
            this.saveResultBtn = new System.Windows.Forms.Button();
            this.saveLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectDirectoryBtn
            // 
            this.selectDirectoryBtn.Location = new System.Drawing.Point(13, 280);
            this.selectDirectoryBtn.Margin = new System.Windows.Forms.Padding(4);
            this.selectDirectoryBtn.Name = "selectDirectoryBtn";
            this.selectDirectoryBtn.Size = new System.Drawing.Size(191, 48);
            this.selectDirectoryBtn.TabIndex = 0;
            this.selectDirectoryBtn.Text = "Выбрать директорию";
            this.selectDirectoryBtn.UseVisualStyleBackColor = true;
            this.selectDirectoryBtn.Click += new System.EventHandler(this.selectDirectoryBtn_Click);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(114, 507);
            this.directoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(0, 16);
            this.directoryLabel.TabIndex = 1;
            // 
            // getCRCBtn
            // 
            this.getCRCBtn.Location = new System.Drawing.Point(359, 280);
            this.getCRCBtn.Margin = new System.Windows.Forms.Padding(4);
            this.getCRCBtn.Name = "getCRCBtn";
            this.getCRCBtn.Size = new System.Drawing.Size(191, 48);
            this.getCRCBtn.TabIndex = 2;
            this.getCRCBtn.Text = "Получить CRC";
            this.getCRCBtn.UseVisualStyleBackColor = true;
            this.getCRCBtn.Click += new System.EventHandler(this.getCRCBtn_Click);
            // 
            // compareCRCBtn
            // 
            this.compareCRCBtn.Location = new System.Drawing.Point(932, 280);
            this.compareCRCBtn.Margin = new System.Windows.Forms.Padding(4);
            this.compareCRCBtn.Name = "compareCRCBtn";
            this.compareCRCBtn.Size = new System.Drawing.Size(191, 48);
            this.compareCRCBtn.TabIndex = 3;
            this.compareCRCBtn.Text = "Сравнить CRC";
            this.compareCRCBtn.UseVisualStyleBackColor = true;
            this.compareCRCBtn.Click += new System.EventHandler(this.compareCRCBtn_Click);
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(502, 507);
            this.dataLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(0, 16);
            this.dataLabel.TabIndex = 4;
            // 
            // compareLabel
            // 
            this.compareLabel.AutoSize = true;
            this.compareLabel.Location = new System.Drawing.Point(873, 507);
            this.compareLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.compareLabel.Name = "compareLabel";
            this.compareLabel.Size = new System.Drawing.Size(0, 16);
            this.compareLabel.TabIndex = 7;
            // 
            // saveSRCTextBox
            // 
            this.saveSRCTextBox.Location = new System.Drawing.Point(13, 13);
            this.saveSRCTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.saveSRCTextBox.Name = "saveSRCTextBox";
            this.saveSRCTextBox.Size = new System.Drawing.Size(537, 262);
            this.saveSRCTextBox.TabIndex = 8;
            this.saveSRCTextBox.Text = "";
            // 
            // currentCRCTextBox
            // 
            this.currentCRCTextBox.Location = new System.Drawing.Point(586, 16);
            this.currentCRCTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.currentCRCTextBox.Name = "currentCRCTextBox";
            this.currentCRCTextBox.Size = new System.Drawing.Size(537, 259);
            this.currentCRCTextBox.TabIndex = 9;
            this.currentCRCTextBox.Text = "";
            // 
            // saveResultBtn
            // 
            this.saveResultBtn.Enabled = false;
            this.saveResultBtn.Location = new System.Drawing.Point(586, 282);
            this.saveResultBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveResultBtn.Name = "saveResultBtn";
            this.saveResultBtn.Size = new System.Drawing.Size(191, 44);
            this.saveResultBtn.TabIndex = 10;
            this.saveResultBtn.Text = "Сохранить сравнение";
            this.saveResultBtn.UseVisualStyleBackColor = true;
            this.saveResultBtn.Click += new System.EventHandler(this.saveResultBtn_Click);
            // 
            // saveLabel
            // 
            this.saveLabel.AutoSize = true;
            this.saveLabel.Location = new System.Drawing.Point(502, 646);
            this.saveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saveLabel.Name = "saveLabel";
            this.saveLabel.Size = new System.Drawing.Size(0, 16);
            this.saveLabel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 334);
            this.Controls.Add(this.saveLabel);
            this.Controls.Add(this.saveResultBtn);
            this.Controls.Add(this.currentCRCTextBox);
            this.Controls.Add(this.saveSRCTextBox);
            this.Controls.Add(this.compareLabel);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.compareCRCBtn);
            this.Controls.Add(this.getCRCBtn);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.selectDirectoryBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectDirectoryBtn;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Button getCRCBtn;
        private System.Windows.Forms.Button compareCRCBtn;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.Label compareLabel;
        private System.Windows.Forms.RichTextBox saveSRCTextBox;
        private System.Windows.Forms.RichTextBox currentCRCTextBox;
        private System.Windows.Forms.Button saveResultBtn;
        private System.Windows.Forms.Label saveLabel;
    }
}

