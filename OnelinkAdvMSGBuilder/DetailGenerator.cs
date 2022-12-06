using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnelinkAdvMSGBuilder
{
    class DetailGenerator
    {
        Logger info = new Logger();
        private TcpClient client;
        private NetworkStream stream;
        WorkerClass wr = new WorkerClass();

        public void Execute(string ip, string port, string cvka, string cvkb, string pan, string pin, string servicecode)
        {
            string command = string.Empty;
            string result = string.Empty;
            string cvv2 = string.Empty;
            string icvv = string.Empty;
            string commandoutput = string.Empty;
            string pinlen = pin.Length.ToString();
            string exp1 = pan.Substring(17, 2);
            string exp2 = pan.Substring(19, 2);
            info.log("HSM IP:"+ip);
            info.log("HSM Port : " + port);
            info.log("CVKA : " + cvka);
            info.log("CVKB : " + cvkb);
            info.log("PAN : " + pan);
            info.log("PIN : " + pin);
            info.log("SERVICE CODE : " + servicecode);
            info.log("Generating Pinoffset");
            Connect(ip, port);

            command = "0000BA" + pin + pan.Substring(3,12);
            info.log("Command for Pin Offset : "+command);
            commandoutput = SendRequest(command);
            result = commandoutput.Substring(8);
            DisplayPinOffset(result);
            info.log("PinOffset : " + result);
            command = "0001CW" + cvka +cvkb+ pan.Substring(0, 16)+";"+exp1+exp2 +servicecode;
            info.log("Command for ICVV Offset : " + command);
            commandoutput = SendRequest(command);
            result = commandoutput.Substring(8);
            DisplayICVV(result);
            info.log("ICVV : "+result);

            command = "0001CW" + cvka + cvkb + pan.Substring(0, 16) + ";" + exp2 + exp1 + "000";
            info.log("Command for CVV2 Offset : " + command);
            commandoutput = SendRequest(command);
            result = commandoutput.Substring(8);
            DisplayCVV2(result);
            info.log("CVV2 : " + result);
            //wr.GenerateConData();
            //wr.GenerateConnectionString();
            //wr.OpenConnection();


            // command = "";
            // string pinresp = SendRequest(command);
            // Thread.Sleep(500);


            //wr.CloseConnection();
            Disconnect();
        }

      

        private void Connect(string ip, string port)
        {
            try
            {
                this.client = new TcpClient(ip, int.Parse(port));
                this.stream = this.client.GetStream();
            }
            catch (ArgumentNullException ex)
            {
                
                info.log(ex.Message);
            }
            catch (SocketException ex)
            {
                
                info.log(ex.Message);
            }
        }

        private void Disconnect()
        {
            try
            {
                this.stream.Close();
                this.client.Close();
            }
            catch (ArgumentNullException ex)
            {
                
                info.log(ex.Message);
            }
            catch (SocketException ex)
            {
                
                info.log(ex.Message);
            }
        }

        private string SendRequest(string request)
        {
            string txtResponse = string.Empty;
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes("  " + request);
                bytes[0] = (byte)0;
                bytes[1] = (byte)request.Length;
                this.stream.Write(bytes, 0, bytes.Length);
                byte[] numArray = new byte[256];
                string empty = string.Empty;
                int count = this.stream.Read(numArray, 0, numArray.Length);
                txtResponse = Encoding.ASCII.GetString(numArray, 0, count).Substring(2);

            }
            catch (ArgumentNullException ex)
            {
                info.log(ex.Message);
            }
            catch (SocketException ex)
            {
                info.log(ex.Message);
            }
            return txtResponse;
        }

        public void DisplayPinOffset(string txt)
        {
            TextBox t = Application.OpenForms["Form1"].Controls["txtOffset"] as TextBox;
            t.Text = "";
            t.Text=txt;
        }
        public void DisplayICVV(string txt)
        {
            TextBox t = Application.OpenForms["Form1"].Controls["txtIcvv"] as TextBox;
            t.Text="";
            t.Text = txt;
        }
        public void DisplayCVV2(string txt)
        {
            TextBox t = Application.OpenForms["Form1"].Controls["txtCvv2"] as TextBox;
            t.Text="";
            t.Text = txt;
        }

    }
}
