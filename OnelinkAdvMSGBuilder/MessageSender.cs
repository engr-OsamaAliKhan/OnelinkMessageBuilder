using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnelinkAdvMSGBuilder
{
    class MessageSender
    {
        
        
        Logger info = new Logger();
        private Socket tmpSocket;
        public AsyncCallback AsynCommCallBack;
        public AsyncCallback AsyncSocketCallBack;
        private Socket CommunicationSocket;
        

        public void ConnectButtonTxt(string txt)
        {
            Button t = Application.OpenForms["Form1"].Controls["button1"] as Button;
            t.Text = txt;
        }
        public void SendMessage(string msg)
        {

            if (!this.CommunicationSocket.Connected)
            {
                info.log("Sockets not Connected!");
            }
            else
            {
                byte[] numArray1 = new byte[9999];
                int length = 0;
                numArray1[length] = (byte)0;
                bool flag = false;
                for (int index1 = 0; index1 < msg.Length; ++index1)
                {
                    for (int index2 = 0; index2 < 16; ++index2)
                    {
                        try
                        {
                            if (msg.Substring(6 + index1 + index2 * 3, 2).CompareTo("  ") == 0)
                            {
                                flag = true;
                                break;
                            }
                            numArray1[length++] = Convert.ToByte(this.GetASCII(msg.Substring(6 + index1 + index2 * 3, 2)));
                        }
                        catch
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        while (index1 < msg.Length && msg[index1] != '\n')
                            ++index1;
                        if (index1 == msg.Length)
                            break;
                    }
                    else
                        break;
                }
                int num1 = 0;
                byte[] buffer;
                int num2;
                string op = "Insert";
                switch (op)
                {
                    case "Insert":
                        buffer = new byte[length + 2];
                        num2 = 0;
                        byte[] numArray2 = buffer;
                        int index3 = num1;
                        int num3 = index3 + 1;
                        int num4 = (int)Convert.ToByte(length / 256);
                        numArray2[index3] = (byte)num4;
                        byte[] numArray3 = buffer;
                        int index4 = num3;
                        num1 = index4 + 1;
                        int num5 = (int)Convert.ToByte(length % 256);
                        numArray3[index4] = (byte)num5;
                        break;
                    case "Modify":
                        buffer = new byte[length];
                        num2 = 2;
                        byte[] numArray4 = buffer;
                        int index5 = num1;
                        int num6 = index5 + 1;
                        int num7 = (int)Convert.ToByte((length - 2) / 256);
                        numArray4[index5] = (byte)num7;
                        byte[] numArray5 = buffer;
                        int index6 = num6;
                        num1 = index6 + 1;
                        int num8 = (int)Convert.ToByte((length - 2) % 256);
                        numArray5[index6] = (byte)num8;
                        break;
                    default:
                        buffer = new byte[length];
                        num2 = 0;
                        break;
                }
                for (int index7 = num2; index7 < length; ++index7)
                    buffer[num1++] = numArray1[index7];
                this.CommunicationSocket.Send(buffer);
                info.log("Sent " + (object)length + " bytes in Request Message");
                
            }
        }


        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                RichTextBox msgrecievebox = Application.OpenForms["Form1"].Controls["richTextBox3"] as RichTextBox;
                SocketPacket asyncState = (SocketPacket)asyn.AsyncState;
                int byteCount = asyncState.m_currentSocket.EndReceive(asyn);
                char[] chars = new char[byteCount];
                Encoding.ASCII.GetDecoder().GetChars(asyncState.dataBuffer, 0, byteCount, chars, 0, true);
                string str1 = new string(chars);
                msgrecievebox.Text = "";
                msgrecievebox.Text += "Received Message: ";
                string str2 = "";
                if (str1.Length < 5)
                {
                    info.log("Connection Terminated");
                    this.CloseSockets();
                }
                else
                {
                    if (str1.Length > 30)
                    {
                        for (int index = 0; index < chars.Length; ++index)
                        {
                            if (index % 16 == 0)
                            {
                                if (str2.Length != 0)
                                {
                                    //RichTextBox richTextBox2 = this.richTextBox2;
                                    msgrecievebox.Text = msgrecievebox.Text + " " + str2;
                                    str2 = "";
                                }
                                msgrecievebox.Text += "\nDATA: ";
                            }
                            //RichTextBox richTextBox2_1 = this.richTextBox2;
                            msgrecievebox.Text = msgrecievebox.Text + string.Format("{0:x2}", (object)Convert.ToByte(asyncState.dataBuffer[index])) + " ";
                            //str2 += (string)(object)Convert.ToChar(asyncState.dataBuffer[index]);
                            str2 += Convert.ToChar(asyncState.dataBuffer[index]).ToString();
                        }
                    }
                    if (str1.Length > 2 && str1.Substring(2, str1.Length - 2).CompareTo("ARE_YOU_ALIVE") == 0)
                    {
                        byte[] buffer = new byte["ARE_YOU_ALIVE".Length + 2];
                        buffer[0] = Convert.ToByte("ARE_YOU_ALIVE".Length / 256);
                        buffer[1] = Convert.ToByte("ARE_YOU_ALIVE".Length % 256);
                        for (int index = 0; index < "ARE_YOU_ALIVE".Length; ++index)
                            buffer[index + 2] = Convert.ToByte("ARE_YOU_ALIVE"[index]);
                        this.CommunicationSocket.Send(buffer);
                    }
                    this.WaitForData(asyncState.m_currentSocket);
                }
            }
            catch (ObjectDisposedException ex)
            {
                info.log("Connection forcibly closed");
                this.CloseSockets();
            }
            catch (SocketException ex)
            {
                info.log(ex.Message);
                this.CloseSockets();
            }
        }



        public void WaitForData(Socket soc)
        {
            try
            {
                if (this.AsyncSocketCallBack == null)
                    this.AsyncSocketCallBack = new AsyncCallback(this.OnDataReceived);
                SocketPacket state = new SocketPacket();
                state.m_currentSocket = soc;
                soc.BeginReceive(state.dataBuffer, 0, state.dataBuffer.Length, SocketFlags.None, this.AsyncSocketCallBack, (object)state);
            }
            catch (SocketException ex)
            {
                info.log(ex.Message);
                this.CloseSockets();
            }
        }



        public void CloseSockets()
        {
            if (this.CommunicationSocket != null)
            {
                this.CommunicationSocket.Close();
                ConnectButtonTxt("Connect");
               
            }
            if (this.tmpSocket == null)
                return;
            this.tmpSocket.Close();
        }




        public void StartCommunication(string linkip,string linkport)
        {
            string mode = "Server";
            try
            {
                this.CloseSockets();
                if (mode.CompareTo("Server") == 0)
                {
                    this.tmpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.tmpSocket.Bind((EndPoint)new IPEndPoint(IPAddress.Any, int.Parse(linkport)));
                    this.tmpSocket.Listen(10);
                    this.tmpSocket.BeginAccept(new AsyncCallback(this.OnClientConnect), (object)null);
                    info.log("Waiting for Connection on " + this.GetIP() + ":" + linkport);
                    ConnectButtonTxt("Disconnect");
                    

                }
                else
                {
                    this.CommunicationSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(linkip), int.Parse(linkport));
                    info.log("Connecting to " + linkip + ":" + linkport);
                    this.CommunicationSocket.Connect((EndPoint)remoteEP);
                    if (this.CommunicationSocket.Connected)
                    {
                        info.log("Connection to Remote Server established Successfully!");
                        ConnectButtonTxt("Disconnect");
                        this.WaitForData(this.CommunicationSocket);
                    }
                }
            }
            catch (SocketException ex)
            {
                info.log(ex.Message);
                this.CloseSockets();
            }
            catch (FormatException ex)
            {
                info.log(ex.Message);
                if (linkip.Length != 0)
                    ;
                this.CloseSockets();
            }
        }

        private string GetIP()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            string str = "";
            IPAddress[] addressList = hostEntry.AddressList;
            int index = 0;
            if (addressList[0].ToString()=="::1")
            {
                index = 1;
            }
            
            return index < addressList.Length ? addressList[index].ToString() : str;
        }


        public int GetASCII(string HEX)
        {
            int num1 = 0;
            int num2;
            switch (HEX[0])
            {
                case 'A':
                case 'a':
                    num2 = num1 + 160;
                    break;
                case 'B':
                case 'b':
                    num2 = num1 + 176;
                    break;
                case 'C':
                case 'c':
                    num2 = num1 + 192;
                    break;
                case 'D':
                case 'd':
                    num2 = num1 + 208;
                    break;
                case 'E':
                case 'e':
                    num2 = num1 + 224;
                    break;
                case 'F':
                case 'f':
                    num2 = num1 + 240;
                    break;
                default:
                    num2 = num1 + ((int)HEX[0] - 48) * 16;
                    break;
            }
            int ascii;
            switch (HEX[1])
            {
                case 'A':
                case 'a':
                    ascii = num2 + 10;
                    break;
                case 'B':
                case 'b':
                    ascii = num2 + 11;
                    break;
                case 'C':
                case 'c':
                    ascii = num2 + 12;
                    break;
                case 'D':
                case 'd':
                    ascii = num2 + 13;
                    break;
                case 'E':
                case 'e':
                    ascii = num2 + 14;
                    break;
                case 'F':
                case 'f':
                    ascii = num2 + 15;
                    break;
                default:
                    ascii = num2 + ((int)HEX[1] - 48);
                    break;
            }
            return ascii;
        }

        public void OnClientConnect(IAsyncResult asyn)
    {
      try
      {
        if (asyn == null)
          return;
        this.CommunicationSocket = this.tmpSocket.EndAccept(asyn);
        this.WaitForData(this.CommunicationSocket);
        info.log("Client " + this.CommunicationSocket.RemoteEndPoint.ToString() + " Connected Successfully!");
        
      }
      catch (ObjectDisposedException ex)
      {
        info.log("Sockets Connection has been Closed!");
        this.CloseSockets();
      }
      catch (SocketException ex)
      {
                info.log(ex.Message);
        this.CloseSockets();
      }
      catch (ArgumentException ex)
      {
        info.log(ex.Message);
        this.CloseSockets();
      }
    }



    }


    public class SocketPacket
    {
        public Socket m_currentSocket;
        public byte[] dataBuffer = new byte[2048];
    }
}
