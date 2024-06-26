namespace AnnounceMaker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_richTextBox = new System.Windows.Forms.RichTextBox();
            this.m_mainMenu = new System.Windows.Forms.MenuStrip();
            this.m_serialPortPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_openSerialPortItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_closeSerialPortItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_settingsPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_generalSettingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_communicationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_aboutPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_generalPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_statusStrip = new System.Windows.Forms.StatusStrip();
            this.m_toolStripStatusLabelWorkingType = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_toolStripStatusLabelWorkStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_toolStripStatusLabelSerialPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_toolStripStatusLabelSerialPortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_serialPort = new System.IO.Ports.SerialPort(this.components);
           
            this.m_groupBoxAmplifier = new System.Windows.Forms.GroupBox();
            this.m_buttonFirst = new System.Windows.Forms.Button();
            this.m_buttonPlay = new System.Windows.Forms.Button();
            this.m_buttonSecond = new System.Windows.Forms.Button();
            this.m_buttonSixth = new System.Windows.Forms.Button();
            this.m_buttonThird = new System.Windows.Forms.Button();
            this.m_buttonFifth = new System.Windows.Forms.Button();
            this.m_buttonFourth = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.m_mainMenu.SuspendLayout();
            this.m_statusStrip.SuspendLayout();
            this.m_groupBoxAmplifier.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_richTextBox
            // 
            this.m_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.m_richTextBox.Location = new System.Drawing.Point(12, 27);
            this.m_richTextBox.Name = "m_richTextBox";
            this.m_richTextBox.Size = new System.Drawing.Size(637, 518);
            this.m_richTextBox.TabIndex = 2;
            this.m_richTextBox.Text = "";
            this.m_richTextBox.TextChanged += new System.EventHandler(this.m_richTextBox_TextChanged);
            // 
            // m_mainMenu
            // 
            this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_serialPortPopup,
            this.m_settingsPopup,
            this.m_aboutPopup});
            this.m_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.m_mainMenu.Name = "m_mainMenu";
            this.m_mainMenu.Size = new System.Drawing.Size(661, 24);
            this.m_mainMenu.TabIndex = 13;
            this.m_mainMenu.Text = "menuStrip1";
            // 
            // m_serialPortPopup
            // 
            this.m_serialPortPopup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_openSerialPortItem,
            this.m_closeSerialPortItem});
            this.m_serialPortPopup.Name = "m_serialPortPopup";
            this.m_serialPortPopup.Size = new System.Drawing.Size(63, 20);
            this.m_serialPortPopup.Text = "Seri Port";
            // 
            // m_openSerialPortItem
            // 
            this.m_openSerialPortItem.Name = "m_openSerialPortItem";
            this.m_openSerialPortItem.Size = new System.Drawing.Size(100, 22);
            this.m_openSerialPortItem.Text = "Aç";
            this.m_openSerialPortItem.Click += new System.EventHandler(this.m_openSerialPortItem_Click);
            // 
            // m_closeSerialPortItem
            // 
            this.m_closeSerialPortItem.Name = "m_closeSerialPortItem";
            this.m_closeSerialPortItem.Size = new System.Drawing.Size(100, 22);
            this.m_closeSerialPortItem.Text = "Kapa";
            this.m_closeSerialPortItem.Click += new System.EventHandler(this.m_closeSerialPortItem_Click);
            // 
            // m_settingsPopup
            // 
            this.m_settingsPopup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_generalSettingsItem,
            this.m_communicationItem});
            this.m_settingsPopup.Name = "m_settingsPopup";
            this.m_settingsPopup.Size = new System.Drawing.Size(56, 20);
            this.m_settingsPopup.Text = "Ayarlar";
            this.m_settingsPopup.Click += new System.EventHandler(this.m_settingsPopup_Click);
            // 
            // m_generalSettingsItem
            // 
            this.m_generalSettingsItem.Image = global::AnnounceMaker.Properties.Resources._185096_settings_icon;
            this.m_generalSettingsItem.Name = "m_generalSettingsItem";
            this.m_generalSettingsItem.Size = new System.Drawing.Size(118, 22);
            this.m_generalSettingsItem.Text = "Genel";
            this.m_generalSettingsItem.Click += new System.EventHandler(this.m_generalSettingsItem_Click);
            // 
            // m_communicationItem
            // 
            this.m_communicationItem.Image = global::AnnounceMaker.Properties.Resources._8675347_fluent_serial_port_regular_icon;
            this.m_communicationItem.Name = "m_communicationItem";
            this.m_communicationItem.Size = new System.Drawing.Size(118, 22);
            this.m_communicationItem.Text = "Seri Port";
            this.m_communicationItem.Click += new System.EventHandler(this.m_communicationItem_Click);
            // 
            // m_aboutPopup
            // 
            this.m_aboutPopup.Name = "m_aboutPopup";
            this.m_aboutPopup.Size = new System.Drawing.Size(69, 20);
            this.m_aboutPopup.Text = "Hakkında";
            this.m_aboutPopup.Click += new System.EventHandler(this.m_aboutPopup_Click);
            // 
            // m_generalPopup
            // 
            this.m_generalPopup.Name = "m_generalPopup";
            this.m_generalPopup.Size = new System.Drawing.Size(32, 19);
            // 
            // m_statusStrip
            // 
            this.m_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolStripStatusLabelWorkingType,
            this.m_toolStripStatusLabelWorkStatus,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.m_toolStripStatusLabelSerialPort,
            this.m_toolStripStatusLabelSerialPortStatus});
            this.m_statusStrip.Location = new System.Drawing.Point(0, 617);
            this.m_statusStrip.Name = "m_statusStrip";
            this.m_statusStrip.Size = new System.Drawing.Size(661, 22);
            this.m_statusStrip.TabIndex = 30;
            this.m_statusStrip.Text = "statusStrip1";
            // 
            // m_toolStripStatusLabelWorkingType
            // 
            this.m_toolStripStatusLabelWorkingType.Name = "m_toolStripStatusLabelWorkingType";
            this.m_toolStripStatusLabelWorkingType.Size = new System.Drawing.Size(93, 17);
            this.m_toolStripStatusLabelWorkingType.Text = "Servis Durumu : ";
            // 
            // m_toolStripStatusLabelWorkStatus
            // 
            this.m_toolStripStatusLabelWorkStatus.BackColor = System.Drawing.Color.Red;
            this.m_toolStripStatusLabelWorkStatus.Name = "m_toolStripStatusLabelWorkStatus";
            this.m_toolStripStatusLabelWorkStatus.Size = new System.Drawing.Size(24, 17);
            this.m_toolStripStatusLabelWorkStatus.Text = "NA";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // m_toolStripStatusLabelSerialPort
            // 
            this.m_toolStripStatusLabelSerialPort.Name = "m_toolStripStatusLabelSerialPort";
            this.m_toolStripStatusLabelSerialPort.Size = new System.Drawing.Size(60, 17);
            this.m_toolStripStatusLabelSerialPort.Text = "Seri Port : ";
            // 
            // m_toolStripStatusLabelSerialPortStatus
            // 
            this.m_toolStripStatusLabelSerialPortStatus.BackColor = System.Drawing.Color.Red;
            this.m_toolStripStatusLabelSerialPortStatus.Name = "m_toolStripStatusLabelSerialPortStatus";
            this.m_toolStripStatusLabelSerialPortStatus.Size = new System.Drawing.Size(24, 17);
            this.m_toolStripStatusLabelSerialPortStatus.Text = "NA";
            // 
            // m_serialPort
            // 
            this.m_serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.m_serialPort_DataReceived);
            // 
            // m_groupBoxAmplifier
            // 
            this.m_groupBoxAmplifier.Controls.Add(this.m_buttonFirst);
            this.m_groupBoxAmplifier.Controls.Add(this.m_buttonPlay);
            this.m_groupBoxAmplifier.Controls.Add(this.m_buttonSecond);
            this.m_groupBoxAmplifier.Controls.Add(this.m_buttonSixth);
            this.m_groupBoxAmplifier.Controls.Add(this.m_buttonThird);
            this.m_groupBoxAmplifier.Controls.Add(this.m_buttonFifth);
            this.m_groupBoxAmplifier.Controls.Add(this.m_buttonFourth);
            this.m_groupBoxAmplifier.Location = new System.Drawing.Point(12, 551);
            this.m_groupBoxAmplifier.Name = "m_groupBoxAmplifier";
            this.m_groupBoxAmplifier.Size = new System.Drawing.Size(637, 63);
            this.m_groupBoxAmplifier.TabIndex = 37;
            this.m_groupBoxAmplifier.TabStop = false;
            this.m_groupBoxAmplifier.Text = "Amfi Test";
            // 
            // m_buttonFirst
            // 
            this.m_buttonFirst.BackgroundImage = global::AnnounceMaker.Properties.Resources.firstchannel;
            this.m_buttonFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonFirst.Location = new System.Drawing.Point(6, 19);
            this.m_buttonFirst.Name = "m_buttonFirst";
            this.m_buttonFirst.Size = new System.Drawing.Size(38, 35);
            this.m_buttonFirst.TabIndex = 0;
            this.m_buttonFirst.UseVisualStyleBackColor = true;
            this.m_buttonFirst.Click += new System.EventHandler(this.channelButtons_Click);
            // 
            // m_buttonPlay
            // 
            this.m_buttonPlay.BackgroundImage = global::AnnounceMaker.Properties.Resources.images;
            this.m_buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonPlay.Location = new System.Drawing.Point(593, 19);
            this.m_buttonPlay.Name = "m_buttonPlay";
            this.m_buttonPlay.Size = new System.Drawing.Size(38, 35);
            this.m_buttonPlay.TabIndex = 36;
            this.m_buttonPlay.UseVisualStyleBackColor = true;
            this.m_buttonPlay.Click += new System.EventHandler(this.m_buttonPlay_Click);
            // 
            // m_buttonSecond
            // 
            this.m_buttonSecond.BackgroundImage = global::AnnounceMaker.Properties.Resources.secondchannel;
            this.m_buttonSecond.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonSecond.Location = new System.Drawing.Point(50, 19);
            this.m_buttonSecond.Name = "m_buttonSecond";
            this.m_buttonSecond.Size = new System.Drawing.Size(38, 35);
            this.m_buttonSecond.TabIndex = 31;
            this.m_buttonSecond.UseVisualStyleBackColor = true;
            this.m_buttonSecond.Click += new System.EventHandler(this.channelButtons_Click);
            // 
            // m_buttonSixth
            // 
            this.m_buttonSixth.BackgroundImage = global::AnnounceMaker.Properties.Resources.sixthchannel;
            this.m_buttonSixth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonSixth.Location = new System.Drawing.Point(226, 19);
            this.m_buttonSixth.Name = "m_buttonSixth";
            this.m_buttonSixth.Size = new System.Drawing.Size(38, 35);
            this.m_buttonSixth.TabIndex = 35;
            this.m_buttonSixth.UseVisualStyleBackColor = true;
            this.m_buttonSixth.Click += new System.EventHandler(this.channelButtons_Click);
            // 
            // m_buttonThird
            // 
            this.m_buttonThird.BackgroundImage = global::AnnounceMaker.Properties.Resources.thirdchannel;
            this.m_buttonThird.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonThird.Location = new System.Drawing.Point(94, 19);
            this.m_buttonThird.Name = "m_buttonThird";
            this.m_buttonThird.Size = new System.Drawing.Size(38, 35);
            this.m_buttonThird.TabIndex = 32;
            this.m_buttonThird.UseVisualStyleBackColor = true;
            this.m_buttonThird.Click += new System.EventHandler(this.channelButtons_Click);
            // 
            // m_buttonFifth
            // 
            this.m_buttonFifth.BackgroundImage = global::AnnounceMaker.Properties.Resources.fifthchannel;
            this.m_buttonFifth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonFifth.Location = new System.Drawing.Point(182, 19);
            this.m_buttonFifth.Name = "m_buttonFifth";
            this.m_buttonFifth.Size = new System.Drawing.Size(38, 35);
            this.m_buttonFifth.TabIndex = 34;
            this.m_buttonFifth.UseVisualStyleBackColor = true;
            this.m_buttonFifth.Click += new System.EventHandler(this.channelButtons_Click);
            // 
            // m_buttonFourth
            // 
            this.m_buttonFourth.BackgroundImage = global::AnnounceMaker.Properties.Resources.fourthchannel;
            this.m_buttonFourth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonFourth.Location = new System.Drawing.Point(138, 19);
            this.m_buttonFourth.Name = "m_buttonFourth";
            this.m_buttonFourth.Size = new System.Drawing.Size(38, 35);
            this.m_buttonFourth.TabIndex = 33;
            this.m_buttonFourth.UseVisualStyleBackColor = true;
            this.m_buttonFourth.Click += new System.EventHandler(this.channelButtons_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(661, 639);
            this.Controls.Add(this.m_statusStrip);
            this.Controls.Add(this.m_mainMenu);
            this.Controls.Add(this.m_richTextBox);
            this.Controls.Add(this.m_groupBoxAmplifier);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Announce Maker v1.2";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.m_mainMenu.ResumeLayout(false);
            this.m_mainMenu.PerformLayout();
            this.m_statusStrip.ResumeLayout(false);
            this.m_statusStrip.PerformLayout();
            this.m_groupBoxAmplifier.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.RichTextBox m_richTextBox;
        private System.Windows.Forms.MenuStrip m_mainMenu;
        private System.Windows.Forms.ToolStripMenuItem m_settingsPopup;
        private System.Windows.Forms.ToolStripMenuItem m_generalSettingsItem;
        private System.Windows.Forms.ToolStripMenuItem m_communicationItem;
        private System.Windows.Forms.StatusStrip m_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelWorkingType;
        internal System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelWorkStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelSerialPort;
        private System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelSerialPortStatus;
        private System.Windows.Forms.ToolStripMenuItem m_serialPortPopup;
        private System.Windows.Forms.ToolStripMenuItem m_openSerialPortItem;
        private System.Windows.Forms.ToolStripMenuItem m_closeSerialPortItem;
        private System.Windows.Forms.GroupBox m_groupBoxAmplifier;
        public System.IO.Ports.SerialPort m_serialPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button m_buttonFirst;
        private System.Windows.Forms.Button m_buttonPlay;
        private System.Windows.Forms.Button m_buttonSecond;
        private System.Windows.Forms.Button m_buttonSixth;
        private System.Windows.Forms.Button m_buttonThird;
        private System.Windows.Forms.Button m_buttonFifth;
        private System.Windows.Forms.Button m_buttonFourth;
        private System.Windows.Forms.ToolStripMenuItem m_aboutPopup;
        private System.Windows.Forms.ToolStripMenuItem m_generalPopup;
    }
}

