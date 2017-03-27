using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uOrder
{
    class AutoClosingMessageBox
    {
        System.Threading.Timer _timer;
        String _message;
        public AutoClosingMessageBox(string title, string message, int timeout)
        {
            _message = message;
            _timer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timer)
                System.Windows.MessageBox.Show(title, message);
        }
        public static void Show(string title, string message, int timeout)
        {
            new AutoClosingMessageBox(title, message, timeout);
        }
        public void OnTimerElapsed(Object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _message);
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }
}