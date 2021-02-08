
namespace FormUI
{
    partial class Dashboard
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
            this.PeopleFoundListBox = new System.Windows.Forms.ListBox();
            this.LastNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FirstNameInsText = new System.Windows.Forms.TextBox();
            this.LastNameInsText = new System.Windows.Forms.TextBox();
            this.emailAddressInsText = new System.Windows.Forms.TextBox();
            this.PhoneNumberInsText = new System.Windows.Forms.TextBox();
            this.firstNameInsLabel = new System.Windows.Forms.Label();
            this.LastNameInsLabel = new System.Windows.Forms.Label();
            this.emailAddresslnsLabel = new System.Windows.Forms.Label();
            this.PhoneNumberInsLabel = new System.Windows.Forms.Label();
            this.InsertRecordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PeopleFoundListBox
            // 
            this.PeopleFoundListBox.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PeopleFoundListBox.FormattingEnabled = true;
            this.PeopleFoundListBox.ItemHeight = 16;
            this.PeopleFoundListBox.Location = new System.Drawing.Point(12, 117);
            this.PeopleFoundListBox.Name = "PeopleFoundListBox";
            this.PeopleFoundListBox.Size = new System.Drawing.Size(406, 276);
            this.PeopleFoundListBox.TabIndex = 0;
            // 
            // LastNameText
            // 
            this.LastNameText.Location = new System.Drawing.Point(117, 32);
            this.LastNameText.Name = "LastNameText";
            this.LastNameText.Size = new System.Drawing.Size(301, 23);
            this.LastNameText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Last Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FirstNameInsText
            // 
            this.FirstNameInsText.Location = new System.Drawing.Point(561, 136);
            this.FirstNameInsText.Name = "FirstNameInsText";
            this.FirstNameInsText.Size = new System.Drawing.Size(301, 23);
            this.FirstNameInsText.TabIndex = 4;
            // 
            // LastNameInsText
            // 
            this.LastNameInsText.Location = new System.Drawing.Point(561, 180);
            this.LastNameInsText.Name = "LastNameInsText";
            this.LastNameInsText.Size = new System.Drawing.Size(301, 23);
            this.LastNameInsText.TabIndex = 5;
            // 
            // emailAddressInsText
            // 
            this.emailAddressInsText.Location = new System.Drawing.Point(561, 218);
            this.emailAddressInsText.Name = "emailAddressInsText";
            this.emailAddressInsText.Size = new System.Drawing.Size(301, 23);
            this.emailAddressInsText.TabIndex = 6;
            // 
            // PhoneNumberInsText
            // 
            this.PhoneNumberInsText.Location = new System.Drawing.Point(561, 261);
            this.PhoneNumberInsText.Name = "PhoneNumberInsText";
            this.PhoneNumberInsText.Size = new System.Drawing.Size(301, 23);
            this.PhoneNumberInsText.TabIndex = 7;
            // 
            // firstNameInsLabel
            // 
            this.firstNameInsLabel.AutoSize = true;
            this.firstNameInsLabel.Location = new System.Drawing.Point(452, 145);
            this.firstNameInsLabel.Name = "firstNameInsLabel";
            this.firstNameInsLabel.Size = new System.Drawing.Size(76, 14);
            this.firstNameInsLabel.TabIndex = 8;
            this.firstNameInsLabel.Text = "First Name";
            // 
            // LastNameInsLabel
            // 
            this.LastNameInsLabel.AutoSize = true;
            this.LastNameInsLabel.Location = new System.Drawing.Point(452, 189);
            this.LastNameInsLabel.Name = "LastNameInsLabel";
            this.LastNameInsLabel.Size = new System.Drawing.Size(74, 14);
            this.LastNameInsLabel.TabIndex = 9;
            this.LastNameInsLabel.Text = "Last Name";
            // 
            // emailAddresslnsLabel
            // 
            this.emailAddresslnsLabel.AutoSize = true;
            this.emailAddresslnsLabel.Location = new System.Drawing.Point(452, 227);
            this.emailAddresslnsLabel.Name = "emailAddresslnsLabel";
            this.emailAddresslnsLabel.Size = new System.Drawing.Size(99, 14);
            this.emailAddresslnsLabel.TabIndex = 10;
            this.emailAddresslnsLabel.Text = "Email Address";
            // 
            // PhoneNumberInsLabel
            // 
            this.PhoneNumberInsLabel.AutoSize = true;
            this.PhoneNumberInsLabel.Location = new System.Drawing.Point(452, 270);
            this.PhoneNumberInsLabel.Name = "PhoneNumberInsLabel";
            this.PhoneNumberInsLabel.Size = new System.Drawing.Size(103, 14);
            this.PhoneNumberInsLabel.TabIndex = 11;
            this.PhoneNumberInsLabel.Text = "Phome Number";
            // 
            // InsertRecordButton
            // 
            this.InsertRecordButton.Location = new System.Drawing.Point(635, 333);
            this.InsertRecordButton.Name = "InsertRecordButton";
            this.InsertRecordButton.Size = new System.Drawing.Size(75, 23);
            this.InsertRecordButton.TabIndex = 12;
            this.InsertRecordButton.Text = "Insert";
            this.InsertRecordButton.UseVisualStyleBackColor = true;
            this.InsertRecordButton.Click += new System.EventHandler(this.InsertRecordButton_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 592);
            this.Controls.Add(this.InsertRecordButton);
            this.Controls.Add(this.PhoneNumberInsLabel);
            this.Controls.Add(this.emailAddresslnsLabel);
            this.Controls.Add(this.LastNameInsLabel);
            this.Controls.Add(this.firstNameInsLabel);
            this.Controls.Add(this.PhoneNumberInsText);
            this.Controls.Add(this.emailAddressInsText);
            this.Controls.Add(this.LastNameInsText);
            this.Controls.Add(this.FirstNameInsText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LastNameText);
            this.Controls.Add(this.PeopleFoundListBox);
            this.Font = new System.Drawing.Font("PMingLiU", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "Dashboard";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PeopleFoundListBox;
        private System.Windows.Forms.TextBox LastNameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox FirstNameInsText;
        private System.Windows.Forms.TextBox LastNameInsText;
        private System.Windows.Forms.TextBox emailAddressInsText;
        private System.Windows.Forms.TextBox PhoneNumberInsText;
        private System.Windows.Forms.Label firstNameInsLabel;
        private System.Windows.Forms.Label LastNameInsLabel;
        private System.Windows.Forms.Label emailAddresslnsLabel;
        private System.Windows.Forms.Label PhoneNumberInsLabel;
        private System.Windows.Forms.Button InsertRecordButton;
    }
}

