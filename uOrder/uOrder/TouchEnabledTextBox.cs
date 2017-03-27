using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace uOrder
{
     class TouchEnabledTextBox 
    {

        public TouchEnabledTextBox()
        {
            this.GotTouchCapture += TouchEnabledTextBox_GotTouchCapture;
        }

        public Action<object, TouchEventArgs> GotTouchCapture { get; private set; }

        private void TouchEnabledTextBox_GotTouchCapture(object sender, System.Windows.Input.TouchEventArgs e)
        {
            string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";
            Process.Start(touchKeyboardPath);
        }
    }
}
