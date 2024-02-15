namespace MPUMessenger
{
    partial class CommunicationSettingsModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicationSettingsModal));
            this.m_radioButtonClient = new System.Windows.Forms.RadioButton();
            this.m_radioButtonMPU = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.m_radioButtonSingle = new System.Windows.Forms.RadioButton();
            this.m_radioButtonRedundant = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_labelConnectedMPUName = new System.Windows.Forms.Label();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonSave = new System.Windows.Forms.Button();
            this.m_checkBoxLogWrite = new System.Windows.Forms.CheckBox();
            this.m_checkBoxVehicleInfo = new System.Windows.Forms.CheckBox();
            this.m_checkBoxRedundancyStatus = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_checkBoxConnectMPU = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_textBoxMPUMessageTimeout = new System.Windows.Forms.TextBox();
            this.m_labelMPUMessageTimeout = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_radioButtonClient
            // 
            this.m_radioButtonClient.AutoSize = true;
            this.m_radioButtonClient.Location = new System.Drawing.Point(311, 26);
            this.m_radioButtonClient.Margin = new System.Windows.Forms.Padding(2);
            this.m_radioButtonClient.Name = "m_radioButtonClient";
            this.m_radioButtonClient.Size = new System.Drawing.Size(78, 17);
            this.m_radioButtonClient.TabIndex = 15;
            this.m_radioButtonClient.TabStop = true;
            this.m_radioButtonClient.Text = "MPU_RED";
            this.m_radioButtonClient.UseVisualStyleBackColor = true;
            // 
            // m_radioButtonMPU
            // 
            this.m_radioButtonMPU.AutoSize = true;
            this.m_radioButtonMPU.Location = new System.Drawing.Point(230, 26);
            this.m_radioButtonMPU.Margin = new System.Windows.Forms.Padding(2);
            this.m_radioButtonMPU.Name = "m_radioButtonMPU";
            this.m_radioButtonMPU.Size = new System.Drawing.Size(49, 17);
            this.m_radioButtonMPU.TabIndex = 14;
            this.m_radioButtonMPU.TabStop = true;
            this.m_radioButtonMPU.Text = "MPU";
            this.m_radioButtonMPU.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Çalışma Modu : ";
            // 
            // m_radioButtonSingle
            // 
            this.m_radioButtonSingle.AutoSize = true;
            this.m_radioButtonSingle.Location = new System.Drawing.Point(212, 3);
            this.m_radioButtonSingle.Name = "m_radioButtonSingle";
            this.m_radioButtonSingle.Size = new System.Drawing.Size(48, 17);
            this.m_radioButtonSingle.TabIndex = 20;
            this.m_radioButtonSingle.TabStop = true;
            this.m_radioButtonSingle.Text = "Tekil";
            this.m_radioButtonSingle.UseVisualStyleBackColor = true;
            // 
            // m_radioButtonRedundant
            // 
            this.m_radioButtonRedundant.AutoSize = true;
            this.m_radioButtonRedundant.Location = new System.Drawing.Point(293, 3);
            this.m_radioButtonRedundant.Name = "m_radioButtonRedundant";
            this.m_radioButtonRedundant.Size = new System.Drawing.Size(60, 17);
            this.m_radioButtonRedundant.TabIndex = 21;
            this.m_radioButtonRedundant.TabStop = true;
            this.m_radioButtonRedundant.Text = "Yedekli";
            this.m_radioButtonRedundant.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_radioButtonRedundant);
            this.panel1.Controls.Add(this.m_radioButtonSingle);
            this.panel1.Location = new System.Drawing.Point(18, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 21);
            this.panel1.TabIndex = 22;
            // 
            // m_labelConnectedMPUName
            // 
            this.m_labelConnectedMPUName.AutoSize = true;
            this.m_labelConnectedMPUName.Location = new System.Drawing.Point(46, 31);
            this.m_labelConnectedMPUName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelConnectedMPUName.Name = "m_labelConnectedMPUName";
            this.m_labelConnectedMPUName.Size = new System.Drawing.Size(101, 13);
            this.m_labelConnectedMPUName.TabIndex = 23;
            this.m_labelConnectedMPUName.Text = "Haberleşilen MPU : ";
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Image = global::MPUMessenger.Properties.Resources.apply;
            this.m_buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonApply.Location = new System.Drawing.Point(309, 213);
            this.m_buttonApply.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(83, 48);
            this.m_buttonApply.TabIndex = 17;
            this.m_buttonApply.Text = "Uygula";
            this.m_buttonApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // m_buttonSave
            // 
            this.m_buttonSave.Image = global::MPUMessenger.Properties.Resources.save;
            this.m_buttonSave.Location = new System.Drawing.Point(220, 213);
            this.m_buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonSave.Name = "m_buttonSave";
            this.m_buttonSave.Size = new System.Drawing.Size(83, 48);
            this.m_buttonSave.TabIndex = 16;
            this.m_buttonSave.Text = "Kaydet";
            this.m_buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonSave.UseVisualStyleBackColor = true;
            this.m_buttonSave.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // m_checkBoxLogWrite
            // 
            this.m_checkBoxLogWrite.AutoSize = true;
            this.m_checkBoxLogWrite.Location = new System.Drawing.Point(21, 230);
            this.m_checkBoxLogWrite.Name = "m_checkBoxLogWrite";
            this.m_checkBoxLogWrite.Size = new System.Drawing.Size(93, 17);
            this.m_checkBoxLogWrite.TabIndex = 28;
            this.m_checkBoxLogWrite.Text = "Logları Kaydet";
            this.m_checkBoxLogWrite.UseVisualStyleBackColor = true;
            // 
            // m_checkBoxVehicleInfo
            // 
            this.m_checkBoxVehicleInfo.AutoSize = true;
            this.m_checkBoxVehicleInfo.Location = new System.Drawing.Point(264, 24);
            this.m_checkBoxVehicleInfo.Name = "m_checkBoxVehicleInfo";
            this.m_checkBoxVehicleInfo.Size = new System.Drawing.Size(125, 17);
            this.m_checkBoxVehicleInfo.TabIndex = 29;
            this.m_checkBoxVehicleInfo.Text = "Araç Bilgilerini Göster";
            this.m_checkBoxVehicleInfo.UseVisualStyleBackColor = true;
            // 
            // m_checkBoxRedundancyStatus
            // 
            this.m_checkBoxRedundancyStatus.AutoSize = true;
            this.m_checkBoxRedundancyStatus.Location = new System.Drawing.Point(18, 24);
            this.m_checkBoxRedundancyStatus.Name = "m_checkBoxRedundancyStatus";
            this.m_checkBoxRedundancyStatus.Size = new System.Drawing.Size(175, 17);
            this.m_checkBoxRedundancyStatus.TabIndex = 30;
            this.m_checkBoxRedundancyStatus.Text = "Yed. Servisi Haberleşme Göster";
            this.m_checkBoxRedundancyStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_labelMPUMessageTimeout);
            this.groupBox1.Controls.Add(this.m_textBoxMPUMessageTimeout);
            this.groupBox1.Controls.Add(this.m_checkBoxConnectMPU);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.m_radioButtonMPU);
            this.groupBox1.Controls.Add(this.m_radioButtonClient);
            this.groupBox1.Controls.Add(this.m_labelConnectedMPUName);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 128);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MPU Bilgileri";
            // 
            // m_checkBoxConnectMPU
            // 
            this.m_checkBoxConnectMPU.AutoSize = true;
            this.m_checkBoxConnectMPU.Location = new System.Drawing.Point(251, 101);
            this.m_checkBoxConnectMPU.Name = "m_checkBoxConnectMPU";
            this.m_checkBoxConnectMPU.Size = new System.Drawing.Size(138, 17);
            this.m_checkBoxConnectMPU.TabIndex = 29;
            this.m_checkBoxConnectMPU.Text = "Açılışta MPU\'ya Bağlan ";
            this.m_checkBoxConnectMPU.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_checkBoxVehicleInfo);
            this.groupBox2.Controls.Add(this.m_checkBoxRedundancyStatus);
            this.groupBox2.Location = new System.Drawing.Point(3, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 62);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Arayüz İşlemleri";
            // 
            // m_textBoxMPUMessageTimeout
            // 
            this.m_textBoxMPUMessageTimeout.Location = new System.Drawing.Point(230, 74);
            this.m_textBoxMPUMessageTimeout.Name = "m_textBoxMPUMessageTimeout";
            this.m_textBoxMPUMessageTimeout.Size = new System.Drawing.Size(159, 20);
            this.m_textBoxMPUMessageTimeout.TabIndex = 30;
            // 
            // m_labelMPUMessageTimeout
            // 
            this.m_labelMPUMessageTimeout.AutoSize = true;
            this.m_labelMPUMessageTimeout.Location = new System.Drawing.Point(15, 77);
            this.m_labelMPUMessageTimeout.Name = "m_labelMPUMessageTimeout";
            this.m_labelMPUMessageTimeout.Size = new System.Drawing.Size(132, 13);
            this.m_labelMPUMessageTimeout.TabIndex = 31;
            this.m_labelMPUMessageTimeout.Text = "MPU Timeout Süresi(ms) : ";
            // 
            // CommunicationSettingsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(429, 269);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_checkBoxLogWrite);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_buttonSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CommunicationSettingsModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Haberleşme Ayarları";
            this.Load += new System.EventHandler(this.CommunicationSettingsModal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton m_radioButtonClient;
        private System.Windows.Forms.RadioButton m_radioButtonMPU;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton m_radioButtonSingle;
        private System.Windows.Forms.RadioButton m_radioButtonRedundant;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_labelConnectedMPUName;
        private System.Windows.Forms.CheckBox m_checkBoxLogWrite;
        private System.Windows.Forms.CheckBox m_checkBoxVehicleInfo;
        private System.Windows.Forms.CheckBox m_checkBoxRedundancyStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox m_checkBoxConnectMPU;
        private System.Windows.Forms.Label m_labelMPUMessageTimeout;
        private System.Windows.Forms.TextBox m_textBoxMPUMessageTimeout;
    }
}