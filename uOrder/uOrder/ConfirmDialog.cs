using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uOrder
{
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog(String message, String buttonName)
        {
            InitializeComponent();
            label1.Text = message;
            button1.Text = buttonName;
        }

        public ConfirmDialog(String message, String buttonName, String buttonName2)
        {
            InitializeComponent();
            label1.Text = message;
            button1.Text = buttonName;
            button3.Visible = true;
            button3.Text = buttonName2;
        }
        private void ConfirmDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
