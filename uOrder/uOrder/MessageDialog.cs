﻿using System;
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
    public partial class MessageDialog : Form
    {
        public MessageDialog(String message)
        {
            InitializeComponent();
            label1.Text = message;
        }

        private void MessageDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
