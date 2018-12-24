namespace FFXIV_PerformHelper
{
    partial class NoticeDialog
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
            this.messageTextBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.AutoEllipsis = true;
            this.messageTextBox.Location = new System.Drawing.Point(10, 10);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(260, 85);
            this.messageTextBox.TabIndex = 0;
            this.messageTextBox.Text = "message";
            this.messageTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NoticeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(282, 104);
            this.Controls.Add(this.messageTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NoticeDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label messageTextBox;
    }
}