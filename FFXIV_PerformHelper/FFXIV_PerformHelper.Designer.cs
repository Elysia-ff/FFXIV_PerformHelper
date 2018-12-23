using System;

namespace FFXIV_PerformHelper
{
    partial class FFXIV_PerformHelper
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.directoryText = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.codeList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bpmText = new System.Windows.Forms.TextBox();
            this.strText = new System.Windows.Forms.Label();
            this.codeComboBox = new System.Windows.Forms.ComboBox();
            this.octaveComboBox = new System.Windows.Forms.ComboBox();
            this.durationText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.removeBtn = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.newFileBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.locationXTextBox = new System.Windows.Forms.TextBox();
            this.locationYTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.noteSpeedTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.startDelayTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // directoryText
            // 
            this.directoryText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.directoryText.Location = new System.Drawing.Point(12, 12);
            this.directoryText.Name = "directoryText";
            this.directoryText.ReadOnly = true;
            this.directoryText.Size = new System.Drawing.Size(418, 21);
            this.directoryText.TabIndex = 1;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(436, 10);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse..";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(12, 45);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(499, 23);
            this.playBtn.TabIndex = 3;
            this.playBtn.Text = "PLAY";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // codeList
            // 
            this.codeList.ColumnWidth = 50;
            this.codeList.FormattingEnabled = true;
            this.codeList.HorizontalScrollbar = true;
            this.codeList.ItemHeight = 12;
            this.codeList.Location = new System.Drawing.Point(12, 128);
            this.codeList.MultiColumn = true;
            this.codeList.Name = "codeList";
            this.codeList.ScrollAlwaysVisible = true;
            this.codeList.Size = new System.Drawing.Size(499, 40);
            this.codeList.TabIndex = 4;
            this.codeList.SelectedIndexChanged += new System.EventHandler(this.CodeList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name :";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(61, 101);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(324, 21);
            this.nameText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "BPM :";
            // 
            // bpmText
            // 
            this.bpmText.Location = new System.Drawing.Point(437, 101);
            this.bpmText.Name = "bpmText";
            this.bpmText.Size = new System.Drawing.Size(74, 21);
            this.bpmText.TabIndex = 8;
            this.bpmText.Validating += new System.ComponentModel.CancelEventHandler(this.BPMText_Validating);
            // 
            // strText
            // 
            this.strText.AutoSize = true;
            this.strText.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.strText.Location = new System.Drawing.Point(50, 222);
            this.strText.Name = "strText";
            this.strText.Size = new System.Drawing.Size(22, 20);
            this.strText.TabIndex = 9;
            this.strText.Text = "C";
            // 
            // codeComboBox
            // 
            this.codeComboBox.DropDownWidth = 60;
            this.codeComboBox.FormattingEnabled = true;
            this.codeComboBox.Location = new System.Drawing.Point(120, 222);
            this.codeComboBox.Name = "codeComboBox";
            this.codeComboBox.Size = new System.Drawing.Size(60, 20);
            this.codeComboBox.TabIndex = 10;
            this.codeComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.CodeComboBox_Validating);
            // 
            // octaveComboBox
            // 
            this.octaveComboBox.FormattingEnabled = true;
            this.octaveComboBox.Location = new System.Drawing.Point(186, 222);
            this.octaveComboBox.Name = "octaveComboBox";
            this.octaveComboBox.Size = new System.Drawing.Size(60, 20);
            this.octaveComboBox.TabIndex = 12;
            this.octaveComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.OctaveComboBox_Validating);
            // 
            // durationText
            // 
            this.durationText.Location = new System.Drawing.Point(252, 221);
            this.durationText.Name = "durationText";
            this.durationText.Size = new System.Drawing.Size(60, 21);
            this.durationText.TabIndex = 13;
            this.durationText.Validating += new System.ComponentModel.CancelEventHandler(this.DurationText_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "beat";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 74);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(499, 8);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 15;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(438, 175);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(74, 23);
            this.removeBtn.TabIndex = 16;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // insertBtn
            // 
            this.insertBtn.Location = new System.Drawing.Point(358, 175);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(74, 23);
            this.insertBtn.TabIndex = 17;
            this.insertBtn.Text = "Insert";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(278, 175);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(74, 23);
            this.addBtn.TabIndex = 18;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 383);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(499, 23);
            this.saveBtn.TabIndex = 19;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(358, 219);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(74, 23);
            this.applyBtn.TabIndex = 20;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(438, 219);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(74, 23);
            this.resetBtn.TabIndex = 21;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // newFileBtn
            // 
            this.newFileBtn.Location = new System.Drawing.Point(12, 413);
            this.newFileBtn.Name = "newFileBtn";
            this.newFileBtn.Size = new System.Drawing.Size(499, 23);
            this.newFileBtn.TabIndex = 22;
            this.newFileBtn.Text = "New File";
            this.newFileBtn.UseVisualStyleBackColor = true;
            this.newFileBtn.Click += new System.EventHandler(this.NewFileBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "Location";
            // 
            // locationXTextBox
            // 
            this.locationXTextBox.Location = new System.Drawing.Point(694, 10);
            this.locationXTextBox.Name = "locationXTextBox";
            this.locationXTextBox.Size = new System.Drawing.Size(45, 21);
            this.locationXTextBox.TabIndex = 24;
            this.locationXTextBox.TextChanged += new System.EventHandler(this.LocationXTextBox_TextChanged);
            // 
            // locationYTextBox
            // 
            this.locationYTextBox.Location = new System.Drawing.Point(745, 10);
            this.locationYTextBox.Name = "locationYTextBox";
            this.locationYTextBox.Size = new System.Drawing.Size(45, 21);
            this.locationYTextBox.TabIndex = 25;
            this.locationYTextBox.TextChanged += new System.EventHandler(this.LocationYTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(540, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "Note Speed";
            // 
            // noteSpeedTextBox
            // 
            this.noteSpeedTextBox.Location = new System.Drawing.Point(694, 43);
            this.noteSpeedTextBox.Name = "noteSpeedTextBox";
            this.noteSpeedTextBox.Size = new System.Drawing.Size(96, 21);
            this.noteSpeedTextBox.TabIndex = 27;
            this.noteSpeedTextBox.TextChanged += new System.EventHandler(this.NoteSpeedTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(540, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "Start Delay";
            // 
            // startDelayTextBox
            // 
            this.startDelayTextBox.Location = new System.Drawing.Point(694, 76);
            this.startDelayTextBox.Name = "startDelayTextBox";
            this.startDelayTextBox.Size = new System.Drawing.Size(96, 21);
            this.startDelayTextBox.TabIndex = 29;
            this.startDelayTextBox.TextChanged += new System.EventHandler(this.StartDelayTextBox_TextChanged);
            // 
            // FFXIV_PerformHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startDelayTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.noteSpeedTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.locationYTextBox);
            this.Controls.Add(this.locationXTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.newFileBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.durationText);
            this.Controls.Add(this.octaveComboBox);
            this.Controls.Add(this.codeComboBox);
            this.Controls.Add(this.strText);
            this.Controls.Add(this.bpmText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codeList);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.directoryText);
            this.Controls.Add(this.label1);
            this.Name = "FFXIV_PerformHelper";
            this.Text = "FFXIV Perform Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox directoryText;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.ListBox codeList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bpmText;
        private System.Windows.Forms.Label strText;
        private System.Windows.Forms.ComboBox codeComboBox;
        private System.Windows.Forms.ComboBox octaveComboBox;
        private System.Windows.Forms.TextBox durationText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button newFileBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox locationXTextBox;
        private System.Windows.Forms.TextBox locationYTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox noteSpeedTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox startDelayTextBox;
    }
}

