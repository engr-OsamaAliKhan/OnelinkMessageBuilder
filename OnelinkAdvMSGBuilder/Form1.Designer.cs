namespace OnelinkAdvMSGBuilder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.txtLinkIP = new System.Windows.Forms.TextBox();
            this.txtlinkport = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.hsmip = new System.Windows.Forms.TextBox();
            this.hsmport = new System.Windows.Forms.TextBox();
            this.btnconnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIcvv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCvv2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcvkA = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcvkB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.loggerbox = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtservice = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.encodingbox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.runmode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 69);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(723, 297);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(742, 69);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(316, 297);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.Location = new System.Drawing.Point(1064, 69);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(294, 297);
            this.richTextBox3.TabIndex = 2;
            this.richTextBox3.Text = "";
            // 
            // txtLinkIP
            // 
            this.txtLinkIP.Location = new System.Drawing.Point(12, 26);
            this.txtLinkIP.Name = "txtLinkIP";
            this.txtLinkIP.Size = new System.Drawing.Size(175, 20);
            this.txtLinkIP.TabIndex = 3;
            // 
            // txtlinkport
            // 
            this.txtlinkport.Location = new System.Drawing.Point(193, 26);
            this.txtlinkport.Name = "txtlinkport";
            this.txtlinkport.Size = new System.Drawing.Size(91, 20);
            this.txtlinkport.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(798, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 6;
            this.button2.Text = "Make MSG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Remote IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Port";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(541, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(879, 26);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 20);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // hsmip
            // 
            this.hsmip.Location = new System.Drawing.Point(969, 399);
            this.hsmip.Name = "hsmip";
            this.hsmip.Size = new System.Drawing.Size(131, 20);
            this.hsmip.TabIndex = 11;
            // 
            // hsmport
            // 
            this.hsmport.Location = new System.Drawing.Point(1184, 397);
            this.hsmport.Name = "hsmport";
            this.hsmport.Size = new System.Drawing.Size(63, 20);
            this.hsmport.TabIndex = 12;
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(1253, 397);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(98, 23);
            this.btnconnect.TabIndex = 13;
            this.btnconnect.Text = "Connect/Send";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(919, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "HSM IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1109, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "HSM PORT";
            // 
            // txtIcvv
            // 
            this.txtIcvv.Location = new System.Drawing.Point(1203, 430);
            this.txtIcvv.Name = "txtIcvv";
            this.txtIcvv.Size = new System.Drawing.Size(148, 20);
            this.txtIcvv.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1109, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "ICVV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1109, 456);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "CVV2";
            // 
            // txtCvv2
            // 
            this.txtCvv2.Location = new System.Drawing.Point(1203, 453);
            this.txtCvv2.Name = "txtCvv2";
            this.txtCvv2.Size = new System.Drawing.Size(148, 20);
            this.txtCvv2.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(919, 433);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "CVKA";
            // 
            // txtcvkA
            // 
            this.txtcvkA.Location = new System.Drawing.Point(969, 430);
            this.txtcvkA.Name = "txtcvkA";
            this.txtcvkA.Size = new System.Drawing.Size(114, 20);
            this.txtcvkA.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(919, 456);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "CVKB";
            // 
            // txtcvkB
            // 
            this.txtcvkB.Location = new System.Drawing.Point(969, 456);
            this.txtcvkB.Name = "txtcvkB";
            this.txtcvkB.Size = new System.Drawing.Size(114, 20);
            this.txtcvkB.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(919, 485);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "REL_ID";
            // 
            // txtPan
            // 
            this.txtPan.Location = new System.Drawing.Point(969, 482);
            this.txtPan.Name = "txtPan";
            this.txtPan.Size = new System.Drawing.Size(114, 20);
            this.txtPan.TabIndex = 24;
            this.txtPan.Validating += new System.ComponentModel.CancelEventHandler(this.txtPan_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1109, 485);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "PIN OFFSET";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(1203, 478);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(148, 20);
            this.txtOffset.TabIndex = 26;
            // 
            // loggerbox
            // 
            this.loggerbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loggerbox.ForeColor = System.Drawing.SystemColors.Window;
            this.loggerbox.Location = new System.Drawing.Point(13, 380);
            this.loggerbox.Name = "loggerbox";
            this.loggerbox.ReadOnly = true;
            this.loggerbox.Size = new System.Drawing.Size(887, 169);
            this.loggerbox.TabIndex = 28;
            this.loggerbox.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(919, 511);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "PIN";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(969, 508);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(114, 20);
            this.txtPin.TabIndex = 29;
            this.txtPin.Validating += new System.ComponentModel.CancelEventHandler(this.txtPin_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1111, 511);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "SERVICE CODE";
            // 
            // txtservice
            // 
            this.txtservice.Location = new System.Drawing.Point(1203, 508);
            this.txtservice.Name = "txtservice";
            this.txtservice.Size = new System.Drawing.Size(148, 20);
            this.txtservice.TabIndex = 31;
            this.txtservice.Validating += new System.ComponentModel.CancelEventHandler(this.txtservice_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(541, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Select Message";
            // 
            // encodingbox
            // 
            this.encodingbox.FormattingEnabled = true;
            this.encodingbox.Location = new System.Drawing.Point(670, 25);
            this.encodingbox.Name = "encodingbox";
            this.encodingbox.Size = new System.Drawing.Size(121, 21);
            this.encodingbox.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(667, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Encoding Type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(287, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Run Mode";
            // 
            // runmode
            // 
            this.runmode.FormattingEnabled = true;
            this.runmode.Location = new System.Drawing.Point(290, 25);
            this.runmode.Name = "runmode";
            this.runmode.Size = new System.Drawing.Size(121, 21);
            this.runmode.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1370, 555);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.runmode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.encodingbox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtservice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.loggerbox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtcvkB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtcvkA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCvv2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIcvv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnconnect);
            this.Controls.Add(this.hsmport);
            this.Controls.Add(this.hsmip);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtlinkport);
            this.Controls.Add(this.txtLinkIP);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EZDev";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.TextBox txtLinkIP;
        private System.Windows.Forms.TextBox txtlinkport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox hsmip;
        private System.Windows.Forms.TextBox hsmport;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIcvv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCvv2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcvkA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtcvkB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.RichTextBox loggerbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtservice;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox encodingbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox runmode;
    }
}

