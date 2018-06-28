namespace BackupIsabellaData
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
            this.addFileBtn = new System.Windows.Forms.Button();
            this.DataInfoTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addFileBtn
            // 
            this.addFileBtn.Location = new System.Drawing.Point(300, 37);
            this.addFileBtn.Name = "addFileBtn";
            this.addFileBtn.Size = new System.Drawing.Size(130, 32);
            this.addFileBtn.TabIndex = 0;
            this.addFileBtn.Text = "Add Data File";
            this.addFileBtn.UseVisualStyleBackColor = true;
            // 
            // DataInfoTxtBox
            // 
            this.DataInfoTxtBox.Location = new System.Drawing.Point(13, 121);
            this.DataInfoTxtBox.Multiline = true;
            this.DataInfoTxtBox.Name = "DataInfoTxtBox";
            this.DataInfoTxtBox.Size = new System.Drawing.Size(775, 317);
            this.DataInfoTxtBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataInfoTxtBox);
            this.Controls.Add(this.addFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addFileBtn;
        private System.Windows.Forms.TextBox DataInfoTxtBox;
    }
}

