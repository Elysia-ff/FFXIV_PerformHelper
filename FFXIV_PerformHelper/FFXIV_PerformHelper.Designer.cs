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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.locationXTextBox = new System.Windows.Forms.TextBox();
            this.locationYTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.noteSpeedTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.startDelayTextBox = new System.Windows.Forms.TextBox();
            this.resetSettingBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cSharpTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.highCTextBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.bFlatTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.gSharpTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.gTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.fSharpTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.fTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.eTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.eFlatTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.saveSettingBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.codeList.TabIndex = 7;
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
            this.nameText.ReadOnly = true;
            this.nameText.Size = new System.Drawing.Size(324, 21);
            this.nameText.TabIndex = 5;
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
            this.bpmText.ReadOnly = true;
            this.bpmText.Size = new System.Drawing.Size(74, 21);
            this.bpmText.TabIndex = 6;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 74);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(499, 8);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "Location";
            // 
            // locationXTextBox
            // 
            this.locationXTextBox.Location = new System.Drawing.Point(291, 210);
            this.locationXTextBox.Name = "locationXTextBox";
            this.locationXTextBox.Size = new System.Drawing.Size(45, 21);
            this.locationXTextBox.TabIndex = 18;
            this.locationXTextBox.TextChanged += new System.EventHandler(this.LocationXTextBox_TextChanged);
            // 
            // locationYTextBox
            // 
            this.locationYTextBox.Location = new System.Drawing.Point(342, 210);
            this.locationYTextBox.Name = "locationYTextBox";
            this.locationYTextBox.Size = new System.Drawing.Size(45, 21);
            this.locationYTextBox.TabIndex = 19;
            this.locationYTextBox.TextChanged += new System.EventHandler(this.LocationYTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "Note Speed";
            // 
            // noteSpeedTextBox
            // 
            this.noteSpeedTextBox.Location = new System.Drawing.Point(104, 17);
            this.noteSpeedTextBox.Name = "noteSpeedTextBox";
            this.noteSpeedTextBox.Size = new System.Drawing.Size(96, 21);
            this.noteSpeedTextBox.TabIndex = 21;
            this.noteSpeedTextBox.TextChanged += new System.EventHandler(this.NoteSpeedTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "Start Delay";
            // 
            // startDelayTextBox
            // 
            this.startDelayTextBox.Location = new System.Drawing.Point(104, 42);
            this.startDelayTextBox.Name = "startDelayTextBox";
            this.startDelayTextBox.Size = new System.Drawing.Size(96, 21);
            this.startDelayTextBox.TabIndex = 22;
            this.startDelayTextBox.TextChanged += new System.EventHandler(this.StartDelayTextBox_TextChanged);
            // 
            // resetSettingBtn
            // 
            this.resetSettingBtn.Location = new System.Drawing.Point(276, 412);
            this.resetSettingBtn.Name = "resetSettingBtn";
            this.resetSettingBtn.Size = new System.Drawing.Size(235, 23);
            this.resetSettingBtn.TabIndex = 40;
            this.resetSettingBtn.Text = "Reset Settings";
            this.resetSettingBtn.UseVisualStyleBackColor = true;
            this.resetSettingBtn.Click += new System.EventHandler(this.ResetSettingBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "C";
            // 
            // cTextBox
            // 
            this.cTextBox.Location = new System.Drawing.Point(54, 17);
            this.cTextBox.Name = "cTextBox";
            this.cTextBox.Size = new System.Drawing.Size(44, 21);
            this.cTextBox.TabIndex = 24;
            this.cTextBox.TextChanged += new System.EventHandler(this.CTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(112, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "C＃";
            // 
            // cSharpTextBox
            // 
            this.cSharpTextBox.Location = new System.Drawing.Point(156, 17);
            this.cSharpTextBox.Name = "cSharpTextBox";
            this.cSharpTextBox.Size = new System.Drawing.Size(44, 21);
            this.cSharpTextBox.TabIndex = 25;
            this.cSharpTextBox.TextChanged += new System.EventHandler(this.CSharpTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.noteSpeedTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.startDelayTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 72);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.heightTextBox);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.widthTextBox);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.highCTextBox);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.bTextBox);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.bFlatTextBox);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.aTextBox);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.gSharpTextBox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.gTextBox);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.fSharpTextBox);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.fTextBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.eTextBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.eFlatTextBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dTextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cTextBox);
            this.groupBox2.Controls.Add(this.cSharpTextBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 135);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sheet";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(372, 98);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(44, 21);
            this.heightTextBox.TabIndex = 38;
            this.heightTextBox.TextChanged += new System.EventHandler(this.HeightTextBox_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(328, 101);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 12);
            this.label22.TabIndex = 60;
            this.label22.Text = "Height";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(262, 98);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(44, 21);
            this.widthTextBox.TabIndex = 37;
            this.widthTextBox.TextChanged += new System.EventHandler(this.WidthText_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(218, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 12);
            this.label21.TabIndex = 58;
            this.label21.Text = "Width";
            // 
            // highCTextBox
            // 
            this.highCTextBox.Location = new System.Drawing.Point(54, 98);
            this.highCTextBox.Name = "highCTextBox";
            this.highCTextBox.Size = new System.Drawing.Size(44, 21);
            this.highCTextBox.TabIndex = 36;
            this.highCTextBox.TextChanged += new System.EventHandler(this.HighCTextBox_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 101);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 12);
            this.label20.TabIndex = 56;
            this.label20.Text = "↑C";
            // 
            // bTextBox
            // 
            this.bTextBox.Location = new System.Drawing.Point(372, 71);
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(44, 21);
            this.bTextBox.TabIndex = 35;
            this.bTextBox.TextChanged += new System.EventHandler(this.BTextBox_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(328, 74);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 12);
            this.label19.TabIndex = 54;
            this.label19.Text = "B";
            // 
            // bFlatTextBox
            // 
            this.bFlatTextBox.Location = new System.Drawing.Point(262, 71);
            this.bFlatTextBox.Name = "bFlatTextBox";
            this.bFlatTextBox.Size = new System.Drawing.Size(44, 21);
            this.bFlatTextBox.TabIndex = 34;
            this.bFlatTextBox.TextChanged += new System.EventHandler(this.BFlatTextBox_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(218, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 12);
            this.label18.TabIndex = 52;
            this.label18.Text = "B♭";
            // 
            // aTextBox
            // 
            this.aTextBox.Location = new System.Drawing.Point(156, 71);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.Size = new System.Drawing.Size(44, 21);
            this.aTextBox.TabIndex = 33;
            this.aTextBox.TextChanged += new System.EventHandler(this.ATextBox_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(112, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 12);
            this.label17.TabIndex = 50;
            this.label17.Text = "A";
            // 
            // gSharpTextBox
            // 
            this.gSharpTextBox.Location = new System.Drawing.Point(54, 71);
            this.gSharpTextBox.Name = "gSharpTextBox";
            this.gSharpTextBox.Size = new System.Drawing.Size(44, 21);
            this.gSharpTextBox.TabIndex = 32;
            this.gSharpTextBox.TextChanged += new System.EventHandler(this.GSharpTextBox_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 12);
            this.label16.TabIndex = 48;
            this.label16.Text = "G＃";
            // 
            // gTextBox
            // 
            this.gTextBox.Location = new System.Drawing.Point(372, 44);
            this.gTextBox.Name = "gTextBox";
            this.gTextBox.Size = new System.Drawing.Size(44, 21);
            this.gTextBox.TabIndex = 31;
            this.gTextBox.TextChanged += new System.EventHandler(this.GTextBox_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(328, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 12);
            this.label15.TabIndex = 46;
            this.label15.Text = "G";
            // 
            // fSharpTextBox
            // 
            this.fSharpTextBox.Location = new System.Drawing.Point(262, 44);
            this.fSharpTextBox.Name = "fSharpTextBox";
            this.fSharpTextBox.Size = new System.Drawing.Size(44, 21);
            this.fSharpTextBox.TabIndex = 30;
            this.fSharpTextBox.TextChanged += new System.EventHandler(this.FSharpTextBox_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(218, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 12);
            this.label14.TabIndex = 44;
            this.label14.Text = "F＃";
            // 
            // fTextBox
            // 
            this.fTextBox.Location = new System.Drawing.Point(156, 44);
            this.fTextBox.Name = "fTextBox";
            this.fTextBox.Size = new System.Drawing.Size(44, 21);
            this.fTextBox.TabIndex = 29;
            this.fTextBox.TextChanged += new System.EventHandler(this.FTextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(112, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 12);
            this.label13.TabIndex = 42;
            this.label13.Text = "F";
            // 
            // eTextBox
            // 
            this.eTextBox.Location = new System.Drawing.Point(54, 44);
            this.eTextBox.Name = "eTextBox";
            this.eTextBox.Size = new System.Drawing.Size(44, 21);
            this.eTextBox.TabIndex = 28;
            this.eTextBox.TextChanged += new System.EventHandler(this.ETextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 12);
            this.label12.TabIndex = 40;
            this.label12.Text = "E";
            // 
            // eFlatTextBox
            // 
            this.eFlatTextBox.Location = new System.Drawing.Point(372, 17);
            this.eFlatTextBox.Name = "eFlatTextBox";
            this.eFlatTextBox.Size = new System.Drawing.Size(44, 21);
            this.eFlatTextBox.TabIndex = 27;
            this.eFlatTextBox.TextChanged += new System.EventHandler(this.EFlatTextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(328, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 12);
            this.label11.TabIndex = 38;
            this.label11.Text = "E♭";
            // 
            // dTextBox
            // 
            this.dTextBox.Location = new System.Drawing.Point(262, 17);
            this.dTextBox.Name = "dTextBox";
            this.dTextBox.Size = new System.Drawing.Size(44, 21);
            this.dTextBox.TabIndex = 26;
            this.dTextBox.TextChanged += new System.EventHandler(this.DTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "D";
            // 
            // saveSettingBtn
            // 
            this.saveSettingBtn.Location = new System.Drawing.Point(10, 412);
            this.saveSettingBtn.Name = "saveSettingBtn";
            this.saveSettingBtn.Size = new System.Drawing.Size(233, 23);
            this.saveSettingBtn.TabIndex = 39;
            this.saveSettingBtn.Text = "Save Settings";
            this.saveSettingBtn.UseVisualStyleBackColor = true;
            this.saveSettingBtn.Click += new System.EventHandler(this.SaveSettingBtn_Click);
            // 
            // FFXIV_PerformHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(521, 448);
            this.Controls.Add(this.saveSettingBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resetSettingBtn);
            this.Controls.Add(this.locationYTextBox);
            this.Controls.Add(this.locationXTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox locationXTextBox;
        private System.Windows.Forms.TextBox locationYTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox noteSpeedTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox startDelayTextBox;
        private System.Windows.Forms.Button resetSettingBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox cSharpTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox dTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox eFlatTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox eTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox fTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox fSharpTextBox;
        private System.Windows.Forms.TextBox gTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox gSharpTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox bFlatTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox highCTextBox;
        private System.Windows.Forms.Button saveSettingBtn;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox heightTextBox;
    }
}

