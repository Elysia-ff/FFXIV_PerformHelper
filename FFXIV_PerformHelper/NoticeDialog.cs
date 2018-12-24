using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIV_PerformHelper
{
    public partial class NoticeDialog : Form
    {
        private static NoticeDialog instance;

        public const string validatingError = "입력된 값이 유효하지 않습니다.";

        public NoticeDialog()
        {
            InitializeComponent();

            instance = this;
        }

        public void SetMessage(string msg)
        {
            messageTextBox.Text = msg;
        }

        public static DialogResult Show(string msg)
        {
            instance.SetMessage(msg);

            return instance.ShowDialog();
        }

        public static DialogResult ShowValidatingError()
        {
            return Show(validatingError);
        }
    }
}
