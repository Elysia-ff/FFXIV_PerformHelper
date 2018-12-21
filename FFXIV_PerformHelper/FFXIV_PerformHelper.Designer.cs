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
            this.codeList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.codeList.ColumnWidth = 30;
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
            // 
            // strText
            // 
            this.strText.AutoSize = true;
            this.strText.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.strText.Location = new System.Drawing.Point(22, 188);
            this.strText.Name = "strText";
            this.strText.Size = new System.Drawing.Size(22, 20);
            this.strText.TabIndex = 9;
            this.strText.Text = "C";
            // 
            // codeComboBox
            // 
            this.codeComboBox.DropDownWidth = 60;
            this.codeComboBox.FormattingEnabled = true;
            this.codeComboBox.Location = new System.Drawing.Point(110, 188);
            this.codeComboBox.Name = "codeComboBox";
            this.codeComboBox.Size = new System.Drawing.Size(60, 20);
            this.codeComboBox.TabIndex = 10;
            // 
            // octaveComboBox
            // 
            this.octaveComboBox.FormattingEnabled = true;
            this.octaveComboBox.Location = new System.Drawing.Point(176, 188);
            this.octaveComboBox.Name = "octaveComboBox";
            this.octaveComboBox.Size = new System.Drawing.Size(60, 20);
            this.octaveComboBox.TabIndex = 12;
            // 
            // durationText
            // 
            this.durationText.Location = new System.Drawing.Point(242, 187);
            this.durationText.Name = "durationText";
            this.durationText.Size = new System.Drawing.Size(60, 21);
            this.durationText.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "beat";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 74);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(497, 8);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 15;
            // 
            // FFXIV_PerformHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
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

        private void InitializeItems()
        {
            codeComboBox.Items.AddRange(new object[]
            {
                MusicDefine.CodeStr[(int)MusicDefine.Code.C],
                MusicDefine.CodeStr[(int)MusicDefine.Code.CSharp],
                MusicDefine.CodeStr[(int)MusicDefine.Code.D],
                MusicDefine.CodeStr[(int)MusicDefine.Code.EFlat],
                MusicDefine.CodeStr[(int)MusicDefine.Code.E],
                MusicDefine.CodeStr[(int)MusicDefine.Code.F],
                MusicDefine.CodeStr[(int)MusicDefine.Code.FSharp],
                MusicDefine.CodeStr[(int)MusicDefine.Code.G],
                MusicDefine.CodeStr[(int)MusicDefine.Code.GSharp],
                MusicDefine.CodeStr[(int)MusicDefine.Code.A],
                MusicDefine.CodeStr[(int)MusicDefine.Code.BFlat],
                MusicDefine.CodeStr[(int)MusicDefine.Code.B],
                MusicDefine.Code.REST.ToString(),
            });

            octaveComboBox.Items.AddRange(MusicDefine.OctaveStr);
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            if (sheetData == null)
                return;

            Play();
        }

        private void CodeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = codeList.SelectedIndex;
            SheetData.Note note = GetNote(idx);

            strText.Text = note.str;
            codeComboBox.SelectedItem = (note.code == MusicDefine.Code.REST) ? note.code.ToString() : MusicDefine.CodeStr[(int)note.code];
            octaveComboBox.SelectedItem = MusicDefine.OctaveStr[(int)note.octave];
            durationText.Text = note.duration.ToString();
        }

        private System.Windows.Forms.ProgressBar progressBar;
    }
}

