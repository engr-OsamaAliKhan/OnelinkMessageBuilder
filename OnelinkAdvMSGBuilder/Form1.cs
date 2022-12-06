using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnelinkAdvMSGBuilder
{
    public partial class Form1 : Form
    {
       
        string ip = string.Empty;
        string port = string.Empty;
        string filename = string.Empty;
        WorkerClass wr = new WorkerClass();
        DetailGenerator dg = new DetailGenerator();
        MessageSender ms = new MessageSender();
        string[] msglines;
        public Form1()
        {
            
            InitializeComponent();
            //Filling Dropdown
            string[] files=wr.FilesFromDirectory();
            foreach (string file in files)
            {
                comboBox1.Items.Add(Path.GetFileName(file));
            }
            string[] encodings = { "UTF7", "UTF8","UTF32","ASCII","HEX" };
            foreach (string encode in encodings)
            {
                encodingbox.Items.Add(encode);
            }

            string[] runmodes = {"Client","Server" };
            foreach (string mode in runmodes) {
                runmode.Items.Add(mode);
            }
            //setting Text
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string file = comboBox1.Text;
            string[] lines = wr.DisplayXliMessage(file);

            foreach(string line in lines)
            {
                richTextBox1.AppendText(line+"\n");
            }

            




        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = comboBox1.Text;
            msglines = richTextBox1.Text.Split('\n');
            wr.ReadTXTFile(filename, msglines);
            richTextBox2.Clear();
            string[] lines = wr.DisplayGeneratedMessage();

            foreach (string line in lines)
            {
                richTextBox2.AppendText(line + "\n");
            }


           msglines = new string[] { };
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string ip = hsmip.Text;
                string port = hsmport.Text;
                string cvka = txtcvkA.Text;
                string key = string.Empty;
                string cvkb = txtcvkB.Text;
                string pan = txtPan.Text;
                string pin = txtPin.Text;
                string servicecode = txtservice.Text;
                if (cvka == "" || cvkb == ""){

                    key = wr.GetKey(pan);

                    cvka = key.Substring(0,16);
                    cvkb = key.Substring(16,16);

                }

               


                dg.Execute(ip, port, cvka, cvkb, pan, pin, servicecode);
            }
            
        
        }




        public void logger(string txt)
        {
            loggerbox.AppendText(txt+"\n");
        }

        private void txtPan_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPan.Text))
            {
                e.Cancel = true;
               txtPan.Focus();
                errorProvider1.SetError(txtPan, "REL_ID should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPan, "");
            }
        }

        private void txtPin_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPin.Text))
            {
               e.Cancel = true;
               txtPin.Focus();
                errorProvider1.SetError(txtPin, "PIN should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPin, "");
            }
        }

        private void txtservice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtservice.Text))
            {
                e.Cancel = true;
               txtservice.Focus();
                errorProvider1.SetError(txtservice, "Service Code should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtservice, "");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="Connect") {

                ms.StartCommunication(txtLinkIP.Text, txtlinkport.Text);

            }
            else
            {
                ms.CloseSockets();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
            Button.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ms.SendMessage(richTextBox2.Text);
        }
    }
}
