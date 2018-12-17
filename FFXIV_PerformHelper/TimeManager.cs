using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIV_PerformHelper
{
    public class TimeManager
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);

        public double DeltaTime { get; private set; }

        private DateTime prevDate;

        public delegate void UpdateHandler();
        public event UpdateHandler OnUpdate;

        public TimeManager()
        {
            Application.Idle += Application_Idle;
        }

        public void Reset()
        {
            prevDate = DateTime.UtcNow;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                DateTime now = DateTime.UtcNow;
                TimeSpan timeSpan = now - prevDate;
                DeltaTime = timeSpan.TotalSeconds;
                prevDate = now;

                OnUpdate?.Invoke();
            }
        }

        private bool IsApplicationIdle()
        {
            return PeekMessage(out NativeMessage result, IntPtr.Zero, 0, 0, 0) == 0;
        }
    }
}
