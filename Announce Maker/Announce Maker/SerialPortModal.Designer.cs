namespace AnnounceMaker
{
    partial class SerialPortModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialPortModal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.m_comboBoxParity = new System.Windows.Forms.ComboBox();
            this.m_comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.m_comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.m_comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.m_labelStopBits = new System.Windows.Forms.Label();
            this.m_labelDataBits = new System.Windows.Forms.Label();
            this.m_labelParity = new System.Windows.Forms.Label();
            this.m_labelBaudRate = new System.Windows.Forms.Label();
            this.m_labelCom = new System.Windows.Forms.Label();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.m_comboBoxStopBits);
            this.groupBox1.Controls.Add(this.m_comboBoxParity);
            this.groupBox1.Controls.Add(this.m_comboBoxDataBits);
            this.groupBox1.Controls.Add(this.m_comboBoxBaudRate);
            this.groupBox1.Controls.Add(this.m_comboBoxPortName);
            this.groupBox1.Controls.Add(this.m_labelStopBits);
            this.groupBox1.Controls.Add(this.m_labelDataBits);
            this.groupBox1.Controls.Add(this.m_labelParity);
            this.groupBox1.Controls.Add(this.m_labelBaudRate);
            this.groupBox1.Controls.Add(this.m_labelCom);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 175);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seri Port";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // m_comboBoxStopBits
            // 
            this.m_comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxStopBits.FormattingEnabled = true;
            this.m_comboBoxStopBits.Items.AddRange(new object[] {
            "Yok",
            "1",
            "1.5",
            "2"});
            this.m_comboBoxStopBits.Location = new System.Drawing.Point(134, 131);
            this.m_comboBoxStopBits.Name = "m_comboBoxStopBits";
            this.m_comboBoxStopBits.Size = new System.Drawing.Size(121, 21);
            this.m_comboBoxStopBits.TabIndex = 12;
            // 
            // m_comboBoxParity
            // 
            this.m_comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxParity.FormattingEnabled = true;
            this.m_comboBoxParity.Items.AddRange(new object[] {
            "Yok",
            "Tek",
            "Çift",
            "İşaret",
            "Boşluk"});
            this.m_comboBoxParity.Location = new System.Drawing.Point(134, 104);
            this.m_comboBoxParity.Name = "m_comboBoxParity";
            this.m_comboBoxParity.Size = new System.Drawing.Size(121, 21);
            this.m_comboBoxParity.TabIndex = 8;
            // 
            // m_comboBoxDataBits
            // 
            this.m_comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxDataBits.FormattingEnabled = true;
            this.m_comboBoxDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.m_comboBoxDataBits.Location = new System.Drawing.Point(134, 77);
            this.m_comboBoxDataBits.Name = "m_comboBoxDataBits";
            this.m_comboBoxDataBits.Size = new System.Drawing.Size(121, 21);
            this.m_comboBoxDataBits.TabIndex = 9;
            // 
            // m_comboBoxBaudRate
            // 
            this.m_comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxBaudRate.FormattingEnabled = true;
            this.m_comboBoxBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.m_comboBoxBaudRate.Location = new System.Drawing.Point(134, 50);
            this.m_comboBoxBaudRate.Name = "m_comboBoxBaudRate";
            this.m_comboBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.m_comboBoxBaudRate.TabIndex = 10;
            // 
            // m_comboBoxPortName
            // 
            this.m_comboBoxPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxPortName.FormattingEnabled = true;
            this.m_comboBoxPortName.Location = new System.Drawing.Point(134, 23);
            this.m_comboBoxPortName.Name = "m_comboBoxPortName";
            this.m_comboBoxPortName.Size = new System.Drawing.Size(121, 21);
            this.m_comboBoxPortName.TabIndex = 11;
            // 
            // m_labelStopBits
            // 
            this.m_labelStopBits.AutoSize = true;
            this.m_labelStopBits.Location = new System.Drawing.Point(33, 131);
            this.m_labelStopBits.Name = "m_labelStopBits";
            this.m_labelStopBits.Size = new System.Drawing.Size(61, 13);
            this.m_labelStopBits.TabIndex = 3;
            this.m_labelStopBits.Text = "Dur Bitleri : ";
            // 
            // m_labelDataBits
            // 
            this.m_labelDataBits.AutoSize = true;
            this.m_labelDataBits.Location = new System.Drawing.Point(32, 77);
            this.m_labelDataBits.Name = "m_labelDataBits";
            this.m_labelDataBits.Size = new System.Drawing.Size(62, 13);
            this.m_labelDataBits.TabIndex = 4;
            this.m_labelDataBits.Text = "Veri Bitleri : ";
            // 
            // m_labelParity
            // 
            this.m_labelParity.AutoSize = true;
            this.m_labelParity.Location = new System.Drawing.Point(52, 104);
            this.m_labelParity.Name = "m_labelParity";
            this.m_labelParity.Size = new System.Drawing.Size(42, 13);
            this.m_labelParity.TabIndex = 5;
            this.m_labelParity.Text = "Parity : ";
            // 
            // m_labelBaudRate
            // 
            this.m_labelBaudRate.AutoSize = true;
            this.m_labelBaudRate.Location = new System.Drawing.Point(27, 50);
            this.m_labelBaudRate.Name = "m_labelBaudRate";
            this.m_labelBaudRate.Size = new System.Drawing.Size(67, 13);
            this.m_labelBaudRate.TabIndex = 6;
            this.m_labelBaudRate.Text = "Baud Rate : ";
            // 
            // m_labelCom
            // 
            this.m_labelCom.AutoSize = true;
            this.m_labelCom.Location = new System.Drawing.Point(54, 23);
            this.m_labelCom.Name = "m_labelCom";
            this.m_labelCom.Size = new System.Drawing.Size(40, 13);
            this.m_labelCom.TabIndex = 7;
            this.m_labelCom.Text = "COM : ";
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Image = global::AnnounceMaker.Properties.Resources.apply;
            this.m_buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonApply.Location = new System.Drawing.Point(184, 192);
            this.m_buttonApply.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(83, 48);
            this.m_buttonApply.TabIndex = 79;
            this.m_buttonApply.Text = "Uygula";
            this.m_buttonApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // m_buttonSave
            // 
            this.m_buttonSave.Image = global::AnnounceMaker.Properties.Resources.save;
            this.m_buttonSave.Location = new System.Drawing.Point(95, 192);
            this.m_buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonSave.Name = "m_buttonSave";
            this.m_buttonSave.Size = new System.Drawing.Size(83, 48);
            this.m_buttonSave.TabIndex = 78;
            this.m_buttonSave.Text = "Kaydet";
            this.m_buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonSave.UseVisualStyleBackColor = true;
            this.m_buttonSave.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // SerialPortModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(306, 249);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SerialPortModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seri Port Ayarları";
            this.Load += new System.EventHandler(this.SerialPortModal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox m_comboBoxStopBits;
        private System.Windows.Forms.ComboBox m_comboBoxParity;
        private System.Windows.Forms.ComboBox m_comboBoxDataBits;
        private System.Windows.Forms.ComboBox m_comboBoxBaudRate;
        private System.Windows.Forms.ComboBox m_comboBoxPortName;
        private System.Windows.Forms.Label m_labelStopBits;
        private System.Windows.Forms.Label m_labelDataBits;
        private System.Windows.Forms.Label m_labelParity;
        private System.Windows.Forms.Label m_labelBaudRate;
        private System.Windows.Forms.Label m_labelCom;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonSave;
    }
}