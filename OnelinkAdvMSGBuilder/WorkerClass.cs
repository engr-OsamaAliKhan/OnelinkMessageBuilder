using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace OnelinkAdvMSGBuilder
{
    class WorkerClass
    {
        Logger info = new Logger();
        string dir = string.Empty;
        string totalmsg = string.Empty;
        string line = string.Empty;
        string msgtype = string.Empty;
        string dbcon = string.Empty;
        string hp = string.Empty;
        string fileloc = string.Empty;
        string fileoutput = string.Empty;
        string bitmap = string.Empty;
        string initialhex = string.Empty;
        OracleConnection conn;
        string dbip = string.Empty;
        string dBPort = string.Empty;
        string dataSource = string.Empty;
        string dbUserId = string.Empty;
        string dbPassword = string.Empty;
        //private Socket tmpSocket;
        //private Socket CommunicationSocket;
        //public AsyncCallback AsynCommCallBack;
        //public AsyncCallback AsyncSocketCallBack;
        //private float FontSize;
        //private IDictionary<string, string> MessageMap = (IDictionary<string, string>)new Dictionary<string, string>();
        //private byte[] OutputBitMap;


        public string[] FilesFromDirectory()
        {
            dir = Environment.CurrentDirectory;
            fileloc = dir + "\\MessageFile\\";
            string[] files = Directory.GetFiles(fileloc);

            return files;
        }

        public string[] DisplayXliMessage(string filename)
        {
            string[] lines = File.ReadAllLines(fileloc + filename);

            return lines;
        }

        public string[] DisplayGeneratedMessage()
        {
            fileoutput = dir + "\\OutputFile\\";
            string[] lines = File.ReadAllLines(fileoutput + "file.txt");

            return lines;
        }

        public void ReadTXTFile(string fname,string[] str)
        {
            ComboBox encodebox = Application.OpenForms["Form1"].Controls["encodingbox"] as ComboBox;
            string encode=encodebox.Text;
            string path = Environment.CurrentDirectory;
            info.log(path + "/MessageFile/" + fname);
            // string[] lines = File.ReadAllLines(path + "\\MessageFile\\" + fname);
            info.log("Generating Config Data");
            GenerateConData();
            info.log("Generating Connection String");
            GenerateConnectionString();


            for (int i = 0; i < str.Length; i++)
            {

                line = str[i];

                if (line!="") {

                    if (line.Contains("BITMAP"))
                    {
                        string binarymap = ProcessLine(line); 
                        
                        var data = GetBytesFromBinaryString(binarymap);
                        string text = string.Empty;
                        if (encode.Equals("UTF7"))
                        {
                            text = Encoding.UTF7.GetString(data);
                        }
                        else if (encode.Equals("UTF8"))
                        {
                            text = Encoding.UTF8.GetString(data);

                        }
                        else if (encode.Equals("UTF32"))
                        {
                            text = Encoding.UTF32.GetString(data);

                        }
                        else if (encode.Equals("ASCII"))
                        {
                            text = Encoding.ASCII.GetString(data);

                        }
                        else
                        {
                            info.log("Encoding Does not Match");
                        }
                        info.log("bitmap data :" + text);
                        //string bitmap = BinaryStringToHexString(binarymap);
                        totalmsg += text;
                        
                        

                }
                else if (line.Contains("MSG_TYPE"))
                {
                        
                            totalmsg += ProcessLine(line);

                    
                }
                else
                {
                    string element = ElementIds(line);
                    info.log("data element " + element);
                    string lengthtyp = ExecuteQuery(element);
                    info.log("Length Type: " + lengthtyp);
                    CloseConnection();

                    if (lengthtyp == "FIX")
                    {
                        totalmsg += ProcessLine(line);

                    }
                    else if (lengthtyp == "VAR_LLL")
                    {
                        string data = ProcessLine(line);
                        int len = data.Length;
                        string ln = Pad_an_int(len, 3);
                        info.log("Paded Length : " + ln);
                        totalmsg += ln + data;

                    }
                    else if (lengthtyp == "VAR_LL")
                    {
                        string data = ProcessLine(line);
                        int len = data.Length;
                        string ln = Pad_an_int(len, 2);
                        info.log("Paded Length : " + ln);
                        totalmsg += ln + data;

                    }
                    else
                    {
                        info.log("Not matching Length");
                    }

                }

            }


            }

            info.log(totalmsg);
            //string hex=TextToHex(totalmsg);
            
            string hex = StringToHex(totalmsg);
            

            for (int i = 2; i <= hex.Length; i += 2)
            {
                hex = hex.Insert(i, " ");
                i++;
            }
            info.log(hex);
            WriteFileTXT(hex);
            hex = string.Empty;
            totalmsg = string.Empty;
        }


        public void GenerateConData()
        {

            dbip = ConfigurationManager.AppSettings["DBIP"];
            info.log(dbip);
            dBPort = ConfigurationManager.AppSettings["DBPort"];
            info.log(dBPort);
            dataSource = ConfigurationManager.AppSettings["DBSid"];
            info.log(dataSource);
            dbUserId = ConfigurationManager.AppSettings["DBUserName"];
            info.log(dbUserId);
            dbPassword = ConfigurationManager.AppSettings["DBPassword"];
            info.log(dbPassword);

        }


        public void GenerateConnectionString()
        {
            info.log("DB credentials : " + dbip + " " + dBPort + " " + dataSource + " " + dbUserId + " " + dbPassword);
            dbcon = "Data Source = (DESCRIPTION = " + "(ADDRESS = (PROTOCOL = TCP)(HOST = " + dbip + ")(PORT = " + dBPort + "))" +
                                 "(CONNECT_DATA = " +
                                 "(SERVICE_NAME = " + dataSource + " )" +
                                 ")" +
                                 ");User Id = " + dbUserId + "; Password = " + dbPassword + ";";
            info.log("Connection String : " + dbcon);

            conn = new OracleConnection(dbcon);



        }



        public string StringToHex(string hexstring)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char t in hexstring)
            {
                //Note: X for upper, x for lower case letters
                sb.Append(Convert.ToInt32(t).ToString("x2"));
            }
            return sb.ToString();
        }

        public string ProcessLine(string pline)
        {
            string nline = pline;
            int index = nline.IndexOf("=") + 2;
            int endIndex = nline.IndexOf("]");
            string newline = nline.Substring(index).Trim('[', ']');
            return newline;
        }

        public string ElementIds(string pline)
        {
            string nline = pline;
            //int index = nline.IndexOf("=") - 2;
            //int endIndex = nline.IndexOf("[");
            string newline = nline.Substring(3, 3);
            return newline;
        }

        public static string BinaryStringToHexString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return binary;

            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            // TODO: check all 1's or 0's... throw otherwise

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }


        public void WriteFileTXT(string txt)
        {
            string path = Environment.CurrentDirectory + "/OutputFile/file.txt";

            string[] pianist = txt.Split(' ');

            File.WriteAllText(path,"");
            string[] lines = File.ReadAllLines(dir + "/OutputFile/file.txt");

            for (int i = 0; i < pianist.Length; i++)
            {
                string text = pianist[i];
                if ((i + 1) % 16 == 0 && i != 1 && i != 0)
                {

                    File.AppendAllText(path, " " + text + Environment.NewLine + "DATA:");

                }
                else
                {
                    if (i == 0)
                    {
                        File.AppendAllText(path, "DATA:");
                    }
                    File.AppendAllText(path, " " + text);
                }
            }





        }



        static string Pad_an_int(int N, int P)
        {
            // string used in Format() method
            string s = "{0:";
            for (int i = 0; i < P; i++)
            {
                s += "0";
            }
            s += "}";

            // use of string.Format() method
            string value = string.Format(s, N);

            // return output
            return value;
        }


        public Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        public string TextToHex(string text)
        {
            byte[] bytes = Encoding.Default.GetBytes(text);
            string hexString = BitConverter.ToString(bytes);
            hexString = hexString.Replace("-", "");
            info.log(hexString);
            return hexString;

        }
        public string ExecuteQuery(string elementid)
        {
            string lengthType = string.Empty;
            try
            {

                OpenConnection();
                //QSelect(trantype, tstname, stan);
                hp = $"select DE_FORMAT from TBLCFGISOMESSAGEFIELDS where ENTITY in('0003','0046','0007') and DE_ID='{elementid}' and rownum=1";
                OracleCommand cmd1 = new OracleCommand(hp, conn);
                OracleDataReader rd1 = cmd1.ExecuteReader();

                while (rd1.Read())
                {

                    lengthType = rd1["DE_FORMAT"].ToString();
                }



                CloseConnection();

            }
            catch (Exception e)
            {
                info.log("EXCEPTION OCCUR : " + e.Message);
            }

            return lengthType;
        }

        public string GetKey(string pan)
        {
            string key = string.Empty;
            try
            {
                GenerateConData();
                GenerateConnectionString();
                OpenConnection();
                //QSelect(trantype, tstname, stan);
                hp= $"select GROUP_ID from TBLDEBITCARD where RELATIONSHIP_ID='{pan}'";
                OracleCommand cmd1 = new OracleCommand(hp, conn);
                OracleDataReader rd1 = cmd1.ExecuteReader();
                rd1.Read();
                string productid = rd1.GetValue(0).ToString();
                rd1.Close();
                hp = $"select KEY from TBLCFGPRODUCTKEYS where KEYType in('CVKA','CVKB') and product_id='{productid}'";
                OracleCommand cmd2 = new OracleCommand(hp, conn);
                OracleDataReader rd2 = cmd2.ExecuteReader();

               
                
                while (rd2.Read())
                {
                    key += rd2["KEY"].ToString();
                }
                



                CloseConnection();

            }
            catch (Exception e)
            {
                info.log("EXCEPTION OCCUR : " + e.Message);
            }

            return key;
        }



        public void CloseConnection()
        {
            conn.Close();
        }
        public void OpenConnection()
        {

            try
            {
                conn.Open();
                info.log("Connect Sucessfully");
            }
            catch (Exception e)
            {
                info.log("Issue while Connecting Database : " + e);
            }

        }



        //public void StartCommunication(string ip,string port)
        //{
        //    try
        //    {
        //        this.CloseSockets();
        //            this.tmpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //            this.tmpSocket.Bind((EndPoint)new IPEndPoint(IPAddress.Any, int.Parse(port)));
        //            this.tmpSocket.Listen(10);
        //            this.tmpSocket.BeginAccept(new AsyncCallback(this.OnClientConnect), (object)null);
        //            //this.AddNotify("Waiting for Connection on " + this.GetIP() + ":" + this.CommunicationPort.Text, Color.LightGreen);
        //            //this.ConnectButton.Text = "Stop Communication";
        //            //this.ConnectButton.Image = (Image)Resources.transmit_blue;



        //    }
        //    catch (SocketException ex)
        //    {
        //        this.AddNotify(ex.Message, Color.Red);
        //        this.CloseSockets();
        //    }
        //    catch (FormatException ex)
        //    {
        //        this.AddNotify(ex.Message, Color.Red);
        //        if (this.RemoteIP.Text.Length != 0)
        //            ;
        //        this.CloseSockets();
        //    }
        //}

        //public void CloseSockets()
        //{
        //    if (this.CommunicationSocket != null)
        //    {
        //        this.CommunicationSocket.Close();
        //        this.Connect.Text = "Start Communication";
        //        this.ConnectButton.Image = (Image)Resources.transmit;
        //    }
        //    if (this.tmpSocket == null)
        //        return;
        //    this.tmpSocket.Close();
        //}




        //public void OnClientConnect(IAsyncResult asyn)
        //{
        //    try
        //    {
        //        if (asyn == null)
        //            return;
        //        this.CommunicationSocket = this.tmpSocket.EndAccept(asyn);
        //        this.WaitForData(this.CommunicationSocket);
        //       // this.AddNotify("Client " + this.CommunicationSocket.RemoteEndPoint.ToString() + " Connected Successfully!", Color.Green);
        //        //this.ConnectButton.Text = "Stop Communication";
        //        //this.ConnectButton.Image = (Image)Resources.transmit_blue;
        //    }
        //    catch (ObjectDisposedException ex)
        //    {
        //        //this.AddNotify("Sockets Connection has been Closed!", Color.Red);
        //        this.CloseSockets();
        //    }
        //    catch (SocketException ex)
        //    {
        //        //this.AddNotify(ex.Message, Color.Red);
        //        this.CloseSockets();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        //this.AddNotify(ex.Message, Color.Red);
        //        this.CloseSockets();
        //    }
        //}

        //public void WaitForData(Socket soc)
        //{
        //    try
        //    {
        //        if (this.AsyncSocketCallBack == null)
        //            this.AsyncSocketCallBack = new AsyncCallback(this.OnDataReceived);
        //        Simpulator.Simpulator.SocketPacket state = new Simpulator.Simpulator.SocketPacket();
        //        state.m_currentSocket = soc;
        //        soc.BeginReceive(state.dataBuffer, 0, state.dataBuffer.Length, SocketFlags.None, this.AsyncSocketCallBack, (object)state);
        //    }
        //    catch (SocketException ex)
        //    {
        //        //this.AddNotify(ex.Message, Color.Red);
        //        this.CloseSockets();
        //    }
        //}



        //public void OnDataReceived(IAsyncResult asyn)
        //{
        //    try
        //    {
        //        Simpulator.Simpulator.SocketPacket asyncState = (Simpulator.Simpulator.SocketPacket)asyn.AsyncState;
        //        int byteCount = asyncState.m_currentSocket.EndReceive(asyn);
        //        char[] chars = new char[byteCount];
        //        Encoding.ASCII.GetDecoder().GetChars(asyncState.dataBuffer, 0, byteCount, chars, 0, true);
        //        string str1 = new string(chars);
        //        this.richTextBox2.Text = "";
        //        this.richTextBox2.Text += "Received Message: ";
        //        string str2 = "";
        //        if (str1.Length < 5)
        //        {
        //           // this.AddNotify("Connection Terminated", Color.Red);
        //            this.CloseSockets();
        //        }
        //        else
        //        {
        //            if (str1.Length > 30)
        //            {
        //                for (int index = 0; index < chars.Length; ++index)
        //                {
        //                    if (index % 16 == 0)
        //                    {
        //                        if (str2.Length != 0)
        //                        {
        //                            RichTextBox richTextBox2 = this.richTextBox2;
        //                            richTextBox2.Text = richTextBox2.Text + " " + str2;
        //                            str2 = "";
        //                        }
        //                        this.richTextBox2.Text += "\nDATA: ";
        //                    }
        //                    RichTextBox richTextBox2_1 = this.richTextBox2;
        //                    richTextBox2_1.Text = richTextBox2_1.Text + string.Format("{0:x2}", (object)Convert.ToByte(asyncState.dataBuffer[index])) + " ";
        //                    str2 += (string)(object)Convert.ToChar(asyncState.dataBuffer[index]);
        //                }
        //            }
        //            if (str1.Length > 2 && str1.Substring(2, str1.Length - 2).CompareTo("ARE_YOU_ALIVE") == 0)
        //            {
        //                byte[] buffer = new byte["ARE_YOU_ALIVE".Length + 2];
        //                buffer[0] = Convert.ToByte("ARE_YOU_ALIVE".Length / 256);
        //                buffer[1] = Convert.ToByte("ARE_YOU_ALIVE".Length % 256);
        //                for (int index = 0; index < "ARE_YOU_ALIVE".Length; ++index)
        //                    buffer[index + 2] = Convert.ToByte("ARE_YOU_ALIVE"[index]);
        //                this.CommunicationSocket.Send(buffer);
        //            }
        //            this.WaitForData(asyncState.m_currentSocket);
        //        }
        //    }
        //    catch (ObjectDisposedException ex)
        //    {
        //        //this.AddNotify("Connection forcibly closed", Color.Red);
        //        this.CloseSockets();
        //    }
        //    catch (SocketException ex)
        //    {
        //        //this.AddNotify(ex.Message, Color.Red);
        //        this.CloseSockets();
        //    }
        //}

        ////public void AddNotify(string NotifyText, Color NotifyColor)
        ////{
        ////    try
        ////    {
        ////        if (this.NotificationWindow.Text.Length > 10000)
        ////            this.NotificationWindow.Text = "";
        ////        this.NotificationWindow.AppendText(" - ");
        ////        this.NotificationWindow.SelectionStart = this.NotificationWindow.Text.Length - 3;
        ////        this.NotificationWindow.SelectionLength = 3;
        ////        this.NotificationWindow.SelectionColor = Color.WhiteSmoke;
        ////        this.NotificationWindow.ScrollToCaret();
        ////        this.NotificationWindow.AppendText(NotifyText);
        ////        this.NotificationWindow.SelectionStart = this.NotificationWindow.Text.Length - NotifyText.Length;
        ////        this.NotificationWindow.SelectionLength = NotifyText.Length;
        ////        this.NotificationWindow.SelectionColor = NotifyColor;
        ////        this.NotificationWindow.ScrollToCaret();
        ////        this.NotificationWindow.AppendText("\n");
        ////    }
        ////    catch (COMException ex)
        ////    {
        ////        this.AddNotify(ex.Message, Color.Red);
        ////    }
        ////}




    }
}
