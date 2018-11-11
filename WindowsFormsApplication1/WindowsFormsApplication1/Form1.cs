using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form,IReceiveMsg
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 form2 = null;
        Thread mainThread;
        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.irev = this;
            form2.Show();
            mainThread = new Thread(() =>
            {
               while (true)
                {

                    this.Invoke(new Action(()=> { this.timer1.Enabled = true; }));
                    Thread.Sleep(100);
                    this.Invoke(new Action<RichTextBox,string>((RichTextBox rtb, string str)=> { rtb.Text += str; }),new object[] { this.richTextBox1,"11111111111\r\n"});
                    this.Invoke(new Action(()=> {
                        TextBox tb = new TextBox();
                        tb.Text = "111111111111";
                        this.Controls.Add(tb);
                    }));
                }
            });
            mainThread.Start();
            this.timer1.Enabled = true;
        }

        delegate void ShowTextDelegate(RichTextBox rtb, string str);
        public void ShowText(RichTextBox rtb, string str)
        {
            ShowTextDelegate std = new ShowTextDelegate(ShowText);
            if (rtb.InvokeRequired)
            {
                rtb.Invoke(std, new object[] { rtb, str });
            }
            else
            {
                rtb.Text += str;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.richTextBox1.Text += "Hello World\r\n";
            this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
            this.richTextBox1.ScrollToCaret();
            this.timer1.Stop();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = this.richTextBox1.Text;
            form2.ShowText(text);
        }

        public void Recieve(string text)
        {
            this.richTextBox2.Text = text;
        }
    }
}
