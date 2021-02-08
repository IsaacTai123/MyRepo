
namespace WhiteList
{
    partial class Form1
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
            this.inputValue = new System.Windows.Forms.TextBox();
            this.checkWhitelist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputValue
            // 
            this.inputValue.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.inputValue.Location = new System.Drawing.Point(60, 27);
            this.inputValue.Name = "inputValue";
            this.inputValue.Size = new System.Drawing.Size(298, 27);
            this.inputValue.TabIndex = 0;
            // 
            // checkWhitelist
            // 
            this.checkWhitelist.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkWhitelist.Location = new System.Drawing.Point(129, 84);
            this.checkWhitelist.Name = "checkWhitelist";
            this.checkWhitelist.Size = new System.Drawing.Size(154, 23);
            this.checkWhitelist.TabIndex = 1;
            this.checkWhitelist.Text = "Check Whitelist";
            this.checkWhitelist.UseVisualStyleBackColor = true;
            this.checkWhitelist.Click += new System.EventHandler(this.checkWhitelist_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 141);
            this.Controls.Add(this.checkWhitelist);
            this.Controls.Add(this.inputValue);
            this.Name = "Form1";
            this.Text = "Whitelist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputValue;
        private System.Windows.Forms.Button checkWhitelist;
    }
}

