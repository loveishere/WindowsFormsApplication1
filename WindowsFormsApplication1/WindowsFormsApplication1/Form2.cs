﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public IReceiveMsg irev;
        private void Form2_Load(object sender, EventArgs e)
        {
            //irev = new Form1();
        }

        internal void ShowText(string text)
        {
            this.richTextBox1.Text = text;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            irev.Recieve(this.richTextBox2.Text);
        }
    }
}
