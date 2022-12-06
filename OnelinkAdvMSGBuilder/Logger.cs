using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnelinkAdvMSGBuilder
{
    class Logger
    {
        public void log(string txt)
        {
            RichTextBox t = Application.OpenForms["Form1"].Controls["loggerbox"] as RichTextBox;
            t.AppendText(txt+"\n");
            t.SelectionStart = t.Text.Length;
            t.Focus();
        }
    }
}
