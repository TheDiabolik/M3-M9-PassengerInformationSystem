namespace AnnounceMaker
{
    partial class SettingsModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsModal));
            this.m_groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.m_tabControl = new System.Windows.Forms.TabControl();
            this.m_tabPageM3Lines = new System.Windows.Forms.TabPage();
            this.m_buttonM3PrivateFilePath = new System.Windows.Forms.Button();
            this.m_labelStationM3FilePath = new System.Windows.Forms.Label();
            this.m_textBoxM3PrivateFilePath = new System.Windows.Forms.TextBox();
            this.m_textBoxM3StationFilePath = new System.Windows.Forms.TextBox();
            this.m_labelM3PrivateFilePath = new System.Windows.Forms.Label();
            this.m_buttonStationM3FilePath = new System.Windows.Forms.Button();
            this.m_tabPageM9 = new System.Windows.Forms.TabPage();
            this.m_buttonM9PrivateFilePath = new System.Windows.Forms.Button();
            this.m_labelStationM9FilePath = new System.Windows.Forms.Label();
            this.m_textBoxM9PrivateFilePath = new System.Windows.Forms.TextBox();
            this.m_textBoxM9StationFilePath = new System.Windows.Forms.TextBox();
            this.m_labelM9PrivateFilePath = new System.Windows.Forms.Label();
            this.m_buttonStationM9FilePath = new System.Windows.Forms.Button();
            this.m_radioButtonAsyncAnnouncement = new System.Windows.Forms.RadioButton();
            this.m_radioButtonSyncAnnouncement = new System.Windows.Forms.RadioButton();
            this.m_checkBoxLogWrite = new System.Windows.Forms.CheckBox();
            this.m_checkBoxConnectRedundancyService = new System.Windows.Forms.CheckBox();
            this.m_checkBoxRedundancyStatus = new System.Windows.Forms.CheckBox();
            this.m_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonSave = new System.Windows.Forms.Button();
            this.m_groupBoxSettings.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_tabPageM3Lines.SuspendLayout();
            this.m_tabPageM9.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_groupBoxSettings
            // 
            this.m_groupBoxSettings.Controls.Add(this.m_tabControl);
            this.m_groupBoxSettings.Controls.Add(this.m_radioButtonAsyncAnnouncement);
            this.m_groupBoxSettings.Controls.Add(this.m_radioButtonSyncAnnouncement);
            this.m_groupBoxSettings.Controls.Add(this.m_checkBoxLogWrite);
            this.m_groupBoxSettings.Controls.Add(this.m_checkBoxConnectRedundancyService);
            this.m_groupBoxSettings.Controls.Add(this.m_checkBoxRedundancyStatus);
            this.m_groupBoxSettings.Location = new System.Drawing.Point(12, 12);
            this.m_groupBoxSettings.Name = "m_groupBoxSettings";
            this.m_groupBoxSettings.Size = new System.Drawing.Size(586, 164);
            this.m_groupBoxSettings.TabIndex = 1;
            this.m_groupBoxSettings.TabStop = false;
            this.m_groupBoxSettings.Text = "Ayarlar";
            // 
            // m_tabControl
            // 
            this.m_tabControl.Controls.Add(this.m_tabPageM3Lines);
            this.m_tabControl.Controls.Add(this.m_tabPageM9);
            this.m_tabControl.Location = new System.Drawing.Point(6, 19);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(573, 114);
            this.m_tabControl.TabIndex = 20;
            // 
            // m_tabPageM3Lines
            // 
            this.m_tabPageM3Lines.Controls.Add(this.m_buttonM3PrivateFilePath);
            this.m_tabPageM3Lines.Controls.Add(this.m_labelStationM3FilePath);
            this.m_tabPageM3Lines.Controls.Add(this.m_textBoxM3PrivateFilePath);
            this.m_tabPageM3Lines.Controls.Add(this.m_textBoxM3StationFilePath);
            this.m_tabPageM3Lines.Controls.Add(this.m_labelM3PrivateFilePath);
            this.m_tabPageM3Lines.Controls.Add(this.m_buttonStationM3FilePath);
            this.m_tabPageM3Lines.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageM3Lines.Name = "m_tabPageM3Lines";
            this.m_tabPageM3Lines.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageM3Lines.Size = new System.Drawing.Size(565, 88);
            this.m_tabPageM3Lines.TabIndex = 0;
            this.m_tabPageM3Lines.Text = "M3 Anonslar Dosya Yolu";
            this.m_tabPageM3Lines.UseVisualStyleBackColor = true;
            // 
            // m_buttonM3PrivateFilePath
            // 
            this.m_buttonM3PrivateFilePath.Location = new System.Drawing.Point(505, 48);
            this.m_buttonM3PrivateFilePath.Name = "m_buttonM3PrivateFilePath";
            this.m_buttonM3PrivateFilePath.Size = new System.Drawing.Size(25, 21);
            this.m_buttonM3PrivateFilePath.TabIndex = 42;
            this.m_buttonM3PrivateFilePath.Text = "...";
            this.m_buttonM3PrivateFilePath.UseVisualStyleBackColor = true;
            this.m_buttonM3PrivateFilePath.Click += new System.EventHandler(this.m_buttonPrivateFilePath_Click);
            // 
            // m_labelStationM3FilePath
            // 
            this.m_labelStationM3FilePath.AutoSize = true;
            this.m_labelStationM3FilePath.Location = new System.Drawing.Point(40, 22);
            this.m_labelStationM3FilePath.Name = "m_labelStationM3FilePath";
            this.m_labelStationM3FilePath.Size = new System.Drawing.Size(101, 13);
            this.m_labelStationM3FilePath.TabIndex = 37;
            this.m_labelStationM3FilePath.Text = "İstasyon Anonsları : ";
            // 
            // m_textBoxM3PrivateFilePath
            // 
            this.m_textBoxM3PrivateFilePath.Location = new System.Drawing.Point(173, 48);
            this.m_textBoxM3PrivateFilePath.Name = "m_textBoxM3PrivateFilePath";
            this.m_textBoxM3PrivateFilePath.ReadOnly = true;
            this.m_textBoxM3PrivateFilePath.Size = new System.Drawing.Size(326, 20);
            this.m_textBoxM3PrivateFilePath.TabIndex = 41;
            // 
            // m_textBoxM3StationFilePath
            // 
            this.m_textBoxM3StationFilePath.Location = new System.Drawing.Point(173, 22);
            this.m_textBoxM3StationFilePath.Name = "m_textBoxM3StationFilePath";
            this.m_textBoxM3StationFilePath.ReadOnly = true;
            this.m_textBoxM3StationFilePath.Size = new System.Drawing.Size(326, 20);
            this.m_textBoxM3StationFilePath.TabIndex = 38;
            // 
            // m_labelM3PrivateFilePath
            // 
            this.m_labelM3PrivateFilePath.AutoSize = true;
            this.m_labelM3PrivateFilePath.Location = new System.Drawing.Point(60, 48);
            this.m_labelM3PrivateFilePath.Name = "m_labelM3PrivateFilePath";
            this.m_labelM3PrivateFilePath.Size = new System.Drawing.Size(81, 13);
            this.m_labelM3PrivateFilePath.TabIndex = 40;
            this.m_labelM3PrivateFilePath.Text = "Özel Anonslar : ";
            // 
            // m_buttonStationM3FilePath
            // 
            this.m_buttonStationM3FilePath.Location = new System.Drawing.Point(505, 22);
            this.m_buttonStationM3FilePath.Name = "m_buttonStationM3FilePath";
            this.m_buttonStationM3FilePath.Size = new System.Drawing.Size(25, 21);
            this.m_buttonStationM3FilePath.TabIndex = 39;
            this.m_buttonStationM3FilePath.Text = "...";
            this.m_buttonStationM3FilePath.UseVisualStyleBackColor = true;
            this.m_buttonStationM3FilePath.Click += new System.EventHandler(this.m_buttonFilePath_Click);
            // 
            // m_tabPageM9
            // 
            this.m_tabPageM9.Controls.Add(this.m_buttonM9PrivateFilePath);
            this.m_tabPageM9.Controls.Add(this.m_labelStationM9FilePath);
            this.m_tabPageM9.Controls.Add(this.m_textBoxM9PrivateFilePath);
            this.m_tabPageM9.Controls.Add(this.m_textBoxM9StationFilePath);
            this.m_tabPageM9.Controls.Add(this.m_labelM9PrivateFilePath);
            this.m_tabPageM9.Controls.Add(this.m_buttonStationM9FilePath);
            this.m_tabPageM9.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageM9.Name = "m_tabPageM9";
            this.m_tabPageM9.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageM9.Size = new System.Drawing.Size(565, 88);
            this.m_tabPageM9.TabIndex = 1;
            this.m_tabPageM9.Text = "M9 Anonslar Dosya Yolu";
            this.m_tabPageM9.UseVisualStyleBackColor = true;
            // 
            // m_buttonM9PrivateFilePath
            // 
            this.m_buttonM9PrivateFilePath.Location = new System.Drawing.Point(505, 48);
            this.m_buttonM9PrivateFilePath.Name = "m_buttonM9PrivateFilePath";
            this.m_buttonM9PrivateFilePath.Size = new System.Drawing.Size(25, 21);
            this.m_buttonM9PrivateFilePath.TabIndex = 48;
            this.m_buttonM9PrivateFilePath.Text = "...";
            this.m_buttonM9PrivateFilePath.UseVisualStyleBackColor = true;
            this.m_buttonM9PrivateFilePath.Click += new System.EventHandler(this.m_buttonM9PrivateFilePath_Click);
            // 
            // m_labelStationM9FilePath
            // 
            this.m_labelStationM9FilePath.AutoSize = true;
            this.m_labelStationM9FilePath.Location = new System.Drawing.Point(40, 22);
            this.m_labelStationM9FilePath.Name = "m_labelStationM9FilePath";
            this.m_labelStationM9FilePath.Size = new System.Drawing.Size(101, 13);
            this.m_labelStationM9FilePath.TabIndex = 43;
            this.m_labelStationM9FilePath.Text = "İstasyon Anonsları : ";
            // 
            // m_textBoxM9PrivateFilePath
            // 
            this.m_textBoxM9PrivateFilePath.Location = new System.Drawing.Point(173, 48);
            this.m_textBoxM9PrivateFilePath.Name = "m_textBoxM9PrivateFilePath";
            this.m_textBoxM9PrivateFilePath.ReadOnly = true;
            this.m_textBoxM9PrivateFilePath.Size = new System.Drawing.Size(326, 20);
            this.m_textBoxM9PrivateFilePath.TabIndex = 47;
            // 
            // m_textBoxM9StationFilePath
            // 
            this.m_textBoxM9StationFilePath.Location = new System.Drawing.Point(173, 22);
            this.m_textBoxM9StationFilePath.Name = "m_textBoxM9StationFilePath";
            this.m_textBoxM9StationFilePath.ReadOnly = true;
            this.m_textBoxM9StationFilePath.Size = new System.Drawing.Size(326, 20);
            this.m_textBoxM9StationFilePath.TabIndex = 44;
            // 
            // m_labelM9PrivateFilePath
            // 
            this.m_labelM9PrivateFilePath.AutoSize = true;
            this.m_labelM9PrivateFilePath.Location = new System.Drawing.Point(60, 48);
            this.m_labelM9PrivateFilePath.Name = "m_labelM9PrivateFilePath";
            this.m_labelM9PrivateFilePath.Size = new System.Drawing.Size(81, 13);
            this.m_labelM9PrivateFilePath.TabIndex = 46;
            this.m_labelM9PrivateFilePath.Text = "Özel Anonslar : ";
            // 
            // m_buttonStationM9FilePath
            // 
            this.m_buttonStationM9FilePath.Location = new System.Drawing.Point(505, 22);
            this.m_buttonStationM9FilePath.Name = "m_buttonStationM9FilePath";
            this.m_buttonStationM9FilePath.Size = new System.Drawing.Size(25, 21);
            this.m_buttonStationM9FilePath.TabIndex = 45;
            this.m_buttonStationM9FilePath.Text = "...";
            this.m_buttonStationM9FilePath.UseVisualStyleBackColor = true;
            this.m_buttonStationM9FilePath.Click += new System.EventHandler(this.m_buttonStationM9FilePath_Click);
            // 
            // m_radioButtonAsyncAnnouncement
            // 
            this.m_radioButtonAsyncAnnouncement.AutoSize = true;
            this.m_radioButtonAsyncAnnouncement.Location = new System.Drawing.Point(485, 135);
            this.m_radioButtonAsyncAnnouncement.Name = "m_radioButtonAsyncAnnouncement";
            this.m_radioButtonAsyncAnnouncement.Size = new System.Drawing.Size(90, 17);
            this.m_radioButtonAsyncAnnouncement.TabIndex = 33;
            this.m_radioButtonAsyncAnnouncement.TabStop = true;
            this.m_radioButtonAsyncAnnouncement.Text = "Async. Anons";
            this.m_radioButtonAsyncAnnouncement.UseVisualStyleBackColor = true;
            // 
            // m_radioButtonSyncAnnouncement
            // 
            this.m_radioButtonSyncAnnouncement.AutoSize = true;
            this.m_radioButtonSyncAnnouncement.Location = new System.Drawing.Point(382, 134);
            this.m_radioButtonSyncAnnouncement.Name = "m_radioButtonSyncAnnouncement";
            this.m_radioButtonSyncAnnouncement.Size = new System.Drawing.Size(86, 17);
            this.m_radioButtonSyncAnnouncement.TabIndex = 33;
            this.m_radioButtonSyncAnnouncement.TabStop = true;
            this.m_radioButtonSyncAnnouncement.Text = "Senk. Anons";
            this.m_radioButtonSyncAnnouncement.UseVisualStyleBackColor = true;
            // 
            // m_checkBoxLogWrite
            // 
            this.m_checkBoxLogWrite.AutoSize = true;
            this.m_checkBoxLogWrite.Location = new System.Drawing.Point(10, 135);
            this.m_checkBoxLogWrite.Name = "m_checkBoxLogWrite";
            this.m_checkBoxLogWrite.Size = new System.Drawing.Size(93, 17);
            this.m_checkBoxLogWrite.TabIndex = 29;
            this.m_checkBoxLogWrite.Text = "Logları Kaydet";
            this.m_checkBoxLogWrite.UseVisualStyleBackColor = true;
            // 
            // m_checkBoxConnectRedundancyService
            // 
            this.m_checkBoxConnectRedundancyService.AutoSize = true;
            this.m_checkBoxConnectRedundancyService.Location = new System.Drawing.Point(115, 135);
            this.m_checkBoxConnectRedundancyService.Name = "m_checkBoxConnectRedundancyService";
            this.m_checkBoxConnectRedundancyService.Size = new System.Drawing.Size(136, 17);
            this.m_checkBoxConnectRedundancyService.TabIndex = 32;
            this.m_checkBoxConnectRedundancyService.Text = "Açılışta Servise Bağlan ";
            this.m_checkBoxConnectRedundancyService.UseVisualStyleBackColor = true;
            // 
            // m_checkBoxRedundancyStatus
            // 
            this.m_checkBoxRedundancyStatus.AutoSize = true;
            this.m_checkBoxRedundancyStatus.Location = new System.Drawing.Point(261, 135);
            this.m_checkBoxRedundancyStatus.Name = "m_checkBoxRedundancyStatus";
            this.m_checkBoxRedundancyStatus.Size = new System.Drawing.Size(103, 17);
            this.m_checkBoxRedundancyStatus.TabIndex = 31;
            this.m_checkBoxRedundancyStatus.Text = "Servis Bildirimleri";
            this.m_checkBoxRedundancyStatus.UseVisualStyleBackColor = true;
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Image = global::AnnounceMaker.Properties.Resources.apply;
            this.m_buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonApply.Location = new System.Drawing.Point(504, 181);
            this.m_buttonApply.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(83, 48);
            this.m_buttonApply.TabIndex = 19;
            this.m_buttonApply.Text = "Uygula";
            this.m_buttonApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // m_buttonSave
            // 
            this.m_buttonSave.Image = global::AnnounceMaker.Properties.Resources.save;
            this.m_buttonSave.Location = new System.Drawing.Point(415, 181);
            this.m_buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonSave.Name = "m_buttonSave";
            this.m_buttonSave.Size = new System.Drawing.Size(83, 48);
            this.m_buttonSave.TabIndex = 18;
            this.m_buttonSave.Text = "Kaydet";
            this.m_buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonSave.UseVisualStyleBackColor = true;
            this.m_buttonSave.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // SettingsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(611, 238);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_buttonSave);
            this.Controls.Add(this.m_groupBoxSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.SettingsModal_Load);
            this.m_groupBoxSettings.ResumeLayout(false);
            this.m_groupBoxSettings.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabPageM3Lines.ResumeLayout(false);
            this.m_tabPageM3Lines.PerformLayout();
            this.m_tabPageM9.ResumeLayout(false);
            this.m_tabPageM9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox m_groupBoxSettings;
        private System.Windows.Forms.FolderBrowserDialog m_folderBrowserDialog;
        private System.Windows.Forms.CheckBox m_checkBoxConnectRedundancyService;
        private System.Windows.Forms.CheckBox m_checkBoxRedundancyStatus;
        private System.Windows.Forms.CheckBox m_checkBoxLogWrite;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonSave;
        private System.Windows.Forms.RadioButton m_radioButtonAsyncAnnouncement;
        private System.Windows.Forms.RadioButton m_radioButtonSyncAnnouncement;
        private System.Windows.Forms.TabControl m_tabControl;
        private System.Windows.Forms.TabPage m_tabPageM3Lines;
        private System.Windows.Forms.Button m_buttonM3PrivateFilePath;
        private System.Windows.Forms.Label m_labelStationM3FilePath;
        private System.Windows.Forms.TextBox m_textBoxM3PrivateFilePath;
        private System.Windows.Forms.TextBox m_textBoxM3StationFilePath;
        private System.Windows.Forms.Label m_labelM3PrivateFilePath;
        private System.Windows.Forms.Button m_buttonStationM3FilePath;
        private System.Windows.Forms.TabPage m_tabPageM9;
        private System.Windows.Forms.Button m_buttonM9PrivateFilePath;
        private System.Windows.Forms.Label m_labelStationM9FilePath;
        private System.Windows.Forms.TextBox m_textBoxM9PrivateFilePath;
        private System.Windows.Forms.TextBox m_textBoxM9StationFilePath;
        private System.Windows.Forms.Label m_labelM9PrivateFilePath;
        private System.Windows.Forms.Button m_buttonStationM9FilePath;
    }
}