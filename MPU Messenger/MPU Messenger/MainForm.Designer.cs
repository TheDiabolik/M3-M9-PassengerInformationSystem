namespace MPUMessenger
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
            this.m_backgroundWorkerGetVariablesInformation = new System.ComponentModel.BackgroundWorker();
            this.m_backgroundWorkerTimerGetVariablesInformation = new System.Windows.Forms.Timer(this.components);
            this.m_groupBoxVehicleMovement = new System.Windows.Forms.GroupBox();
            this.m_textBoxMileageKm = new System.Windows.Forms.TextBox();
            this.m_textBoxSpeed = new System.Windows.Forms.TextBox();
            this.m_labelMileageKm = new System.Windows.Forms.Label();
            this.m_labelSpeed = new System.Windows.Forms.Label();
            this.m_textBoxDistanceCounter = new System.Windows.Forms.TextBox();
            this.m_labelDistanceCounter = new System.Windows.Forms.Label();
            this.m_labelA1VehicleDoorStatus = new System.Windows.Forms.Label();
            this.m_groupBoxVehicleDoorStatus = new System.Windows.Forms.GroupBox();
            this.m_labelC1VehicleDoorStatus = new System.Windows.Forms.Label();
            this.m_labelB1VehicleDoorStatus = new System.Windows.Forms.Label();
            this.m_labelA2VehicleDoorStatus = new System.Windows.Forms.Label();
            this.m_pictureBoxB1VehicleDoor = new System.Windows.Forms.PictureBox();
            this.m_pictureBoxC1VehicleDoor = new System.Windows.Forms.PictureBox();
            this.m_pictureBoxA2VehicleDoor = new System.Windows.Forms.PictureBox();
            this.m_pictureBoxA1VehicleDoor = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_labelTLRightDrsReleased = new System.Windows.Forms.Label();
            this.m_pictureBoxTLRightDrsReleased = new System.Windows.Forms.PictureBox();
            this.m_labelTLLeftDrsReleased = new System.Windows.Forms.Label();
            this.m_pictureBoxTLLeftDrsReleased = new System.Windows.Forms.PictureBox();
            this.m_labelOpenDoorsRight = new System.Windows.Forms.Label();
            this.m_labelOpenDoorsLeft = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_pictureBoxOpenDoorsLeft = new System.Windows.Forms.PictureBox();
            this.m_pictureBoxOpenDoorsRight = new System.Windows.Forms.PictureBox();
            this.m_backgroundWorkerAddVariables = new System.ComponentModel.BackgroundWorker();
            this.m_backgroundWorkerTimerAddVariables = new System.Windows.Forms.Timer(this.components);
            this.m_backgroundWorkerTimerAddTraceDefinition = new System.Windows.Forms.Timer(this.components);
            this.m_backgroundWorkerAddTraceDefinition = new System.ComponentModel.BackgroundWorker();
            this.m_mainMenu = new System.Windows.Forms.MenuStrip();
            this.m_settingsPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_communicationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_aboutPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_labelDistanceCounterReset = new System.Windows.Forms.Label();
            this.m_radioButtonDistanceCounterResetTrue = new System.Windows.Forms.RadioButton();
            this.m_radioButtonDistanceCounterResetFalse = new System.Windows.Forms.RadioButton();
            this.m_groupBoxDistanceCounter = new System.Windows.Forms.GroupBox();
            this.m_buttonSetVariable = new System.Windows.Forms.Button();
            this.m_buttonStopAnnouncement = new System.Windows.Forms.Button();
            this.m_buttonPlayAnnouncement = new System.Windows.Forms.Button();
            this.m_buttonReleaseDistanceCounterReset = new System.Windows.Forms.Button();
            this.m_buttonSendDistanceCounterReset = new System.Windows.Forms.Button();
            this.m_statusStrip = new System.Windows.Forms.StatusStrip();
            this.m_toolStripStatusLabelConnectedMPU = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_toolStripStatusLabelMPUName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_toolStripStatusLabelMPUStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_toolStripStatusLabelMPUBehavior = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_toolStripStatusLabelWorkingType = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_toolStripStatusLabelWorkStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_richTextBox = new System.Windows.Forms.RichTextBox();
            this.m_groupBoxVehicleMovement.SuspendLayout();
            this.m_groupBoxVehicleDoorStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxB1VehicleDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxC1VehicleDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxA2VehicleDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxA1VehicleDoor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxTLRightDrsReleased)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxTLLeftDrsReleased)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxOpenDoorsLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxOpenDoorsRight)).BeginInit();
            this.m_mainMenu.SuspendLayout();
            this.m_groupBoxDistanceCounter.SuspendLayout();
            this.m_statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_backgroundWorkerGetVariablesInformation
            // 
            this.m_backgroundWorkerGetVariablesInformation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_backgroundWorker_DoWork);
            // 
            // m_backgroundWorkerTimerGetVariablesInformation
            // 
            this.m_backgroundWorkerTimerGetVariablesInformation.Interval = 175;
            this.m_backgroundWorkerTimerGetVariablesInformation.Tick += new System.EventHandler(this.m_backgroundWorkerTimer_Tick);
            // 
            // m_groupBoxVehicleMovement
            // 
            this.m_groupBoxVehicleMovement.Controls.Add(this.m_textBoxMileageKm);
            this.m_groupBoxVehicleMovement.Controls.Add(this.m_textBoxSpeed);
            this.m_groupBoxVehicleMovement.Controls.Add(this.m_labelMileageKm);
            this.m_groupBoxVehicleMovement.Controls.Add(this.m_labelSpeed);
            this.m_groupBoxVehicleMovement.Location = new System.Drawing.Point(12, 27);
            this.m_groupBoxVehicleMovement.Name = "m_groupBoxVehicleMovement";
            this.m_groupBoxVehicleMovement.Size = new System.Drawing.Size(442, 71);
            this.m_groupBoxVehicleMovement.TabIndex = 2;
            this.m_groupBoxVehicleMovement.TabStop = false;
            this.m_groupBoxVehicleMovement.Text = "Kilometraj Bilgileri";
            // 
            // m_textBoxMileageKm
            // 
            this.m_textBoxMileageKm.Location = new System.Drawing.Point(329, 29);
            this.m_textBoxMileageKm.Name = "m_textBoxMileageKm";
            this.m_textBoxMileageKm.ReadOnly = true;
            this.m_textBoxMileageKm.Size = new System.Drawing.Size(103, 20);
            this.m_textBoxMileageKm.TabIndex = 14;
            // 
            // m_textBoxSpeed
            // 
            this.m_textBoxSpeed.Location = new System.Drawing.Point(117, 29);
            this.m_textBoxSpeed.Name = "m_textBoxSpeed";
            this.m_textBoxSpeed.ReadOnly = true;
            this.m_textBoxSpeed.Size = new System.Drawing.Size(103, 20);
            this.m_textBoxSpeed.TabIndex = 11;
            // 
            // m_labelMileageKm
            // 
            this.m_labelMileageKm.AutoSize = true;
            this.m_labelMileageKm.Location = new System.Drawing.Point(267, 32);
            this.m_labelMileageKm.Name = "m_labelMileageKm";
            this.m_labelMileageKm.Size = new System.Drawing.Size(56, 13);
            this.m_labelMileageKm.TabIndex = 5;
            this.m_labelMileageKm.Text = "Araç Km : ";
            this.m_labelMileageKm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelSpeed
            // 
            this.m_labelSpeed.AutoSize = true;
            this.m_labelSpeed.Location = new System.Drawing.Point(6, 32);
            this.m_labelSpeed.Name = "m_labelSpeed";
            this.m_labelSpeed.Size = new System.Drawing.Size(94, 13);
            this.m_labelSpeed.TabIndex = 3;
            this.m_labelSpeed.Text = "Araç Hızı(km/sa) : ";
            this.m_labelSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_textBoxDistanceCounter
            // 
            this.m_textBoxDistanceCounter.Location = new System.Drawing.Point(117, 23);
            this.m_textBoxDistanceCounter.Name = "m_textBoxDistanceCounter";
            this.m_textBoxDistanceCounter.ReadOnly = true;
            this.m_textBoxDistanceCounter.Size = new System.Drawing.Size(103, 20);
            this.m_textBoxDistanceCounter.TabIndex = 12;
            // 
            // m_labelDistanceCounter
            // 
            this.m_labelDistanceCounter.AutoSize = true;
            this.m_labelDistanceCounter.Location = new System.Drawing.Point(35, 26);
            this.m_labelDistanceCounter.Name = "m_labelDistanceCounter";
            this.m_labelDistanceCounter.Size = new System.Drawing.Size(65, 13);
            this.m_labelDistanceCounter.TabIndex = 4;
            this.m_labelDistanceCounter.Text = "Mesafe(m) : ";
            this.m_labelDistanceCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelA1VehicleDoorStatus
            // 
            this.m_labelA1VehicleDoorStatus.AutoSize = true;
            this.m_labelA1VehicleDoorStatus.Location = new System.Drawing.Point(26, 35);
            this.m_labelA1VehicleDoorStatus.Name = "m_labelA1VehicleDoorStatus";
            this.m_labelA1VehicleDoorStatus.Size = new System.Drawing.Size(120, 13);
            this.m_labelA1VehicleDoorStatus.TabIndex = 7;
            this.m_labelA1VehicleDoorStatus.Text = "A1 Aracı Kapı Durumu : ";
            this.m_labelA1VehicleDoorStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_groupBoxVehicleDoorStatus
            // 
            this.m_groupBoxVehicleDoorStatus.Controls.Add(this.m_labelC1VehicleDoorStatus);
            this.m_groupBoxVehicleDoorStatus.Controls.Add(this.m_labelB1VehicleDoorStatus);
            this.m_groupBoxVehicleDoorStatus.Controls.Add(this.m_labelA2VehicleDoorStatus);
            this.m_groupBoxVehicleDoorStatus.Controls.Add(this.m_pictureBoxB1VehicleDoor);
            this.m_groupBoxVehicleDoorStatus.Controls.Add(this.m_labelA1VehicleDoorStatus);
            this.m_groupBoxVehicleDoorStatus.Controls.Add(this.m_pictureBoxC1VehicleDoor);
            this.m_groupBoxVehicleDoorStatus.Controls.Add(this.m_pictureBoxA2VehicleDoor);
            this.m_groupBoxVehicleDoorStatus.Controls.Add(this.m_pictureBoxA1VehicleDoor);
            this.m_groupBoxVehicleDoorStatus.Location = new System.Drawing.Point(468, 28);
            this.m_groupBoxVehicleDoorStatus.Name = "m_groupBoxVehicleDoorStatus";
            this.m_groupBoxVehicleDoorStatus.Size = new System.Drawing.Size(434, 124);
            this.m_groupBoxVehicleDoorStatus.TabIndex = 8;
            this.m_groupBoxVehicleDoorStatus.TabStop = false;
            this.m_groupBoxVehicleDoorStatus.Text = "Kapı Bilgileri";
            // 
            // m_labelC1VehicleDoorStatus
            // 
            this.m_labelC1VehicleDoorStatus.AutoSize = true;
            this.m_labelC1VehicleDoorStatus.Location = new System.Drawing.Point(232, 76);
            this.m_labelC1VehicleDoorStatus.Name = "m_labelC1VehicleDoorStatus";
            this.m_labelC1VehicleDoorStatus.Size = new System.Drawing.Size(120, 13);
            this.m_labelC1VehicleDoorStatus.TabIndex = 10;
            this.m_labelC1VehicleDoorStatus.Text = "C1 Aracı Kapı Durumu : ";
            this.m_labelC1VehicleDoorStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelB1VehicleDoorStatus
            // 
            this.m_labelB1VehicleDoorStatus.AutoSize = true;
            this.m_labelB1VehicleDoorStatus.Location = new System.Drawing.Point(232, 35);
            this.m_labelB1VehicleDoorStatus.Name = "m_labelB1VehicleDoorStatus";
            this.m_labelB1VehicleDoorStatus.Size = new System.Drawing.Size(120, 13);
            this.m_labelB1VehicleDoorStatus.TabIndex = 9;
            this.m_labelB1VehicleDoorStatus.Text = "B1 Aracı Kapı Durumu : ";
            this.m_labelB1VehicleDoorStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelA2VehicleDoorStatus
            // 
            this.m_labelA2VehicleDoorStatus.AutoSize = true;
            this.m_labelA2VehicleDoorStatus.Location = new System.Drawing.Point(26, 82);
            this.m_labelA2VehicleDoorStatus.Name = "m_labelA2VehicleDoorStatus";
            this.m_labelA2VehicleDoorStatus.Size = new System.Drawing.Size(120, 13);
            this.m_labelA2VehicleDoorStatus.TabIndex = 8;
            this.m_labelA2VehicleDoorStatus.Text = "A2 Aracı Kapı Durumu : ";
            this.m_labelA2VehicleDoorStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_pictureBoxB1VehicleDoor
            // 
            this.m_pictureBoxB1VehicleDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictureBoxB1VehicleDoor.Image = ((System.Drawing.Image)(resources.GetObject("m_pictureBoxB1VehicleDoor.Image")));
            this.m_pictureBoxB1VehicleDoor.Location = new System.Drawing.Point(379, 35);
            this.m_pictureBoxB1VehicleDoor.Name = "m_pictureBoxB1VehicleDoor";
            this.m_pictureBoxB1VehicleDoor.Size = new System.Drawing.Size(38, 35);
            this.m_pictureBoxB1VehicleDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxB1VehicleDoor.TabIndex = 3;
            this.m_pictureBoxB1VehicleDoor.TabStop = false;
            // 
            // m_pictureBoxC1VehicleDoor
            // 
            this.m_pictureBoxC1VehicleDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictureBoxC1VehicleDoor.Image = ((System.Drawing.Image)(resources.GetObject("m_pictureBoxC1VehicleDoor.Image")));
            this.m_pictureBoxC1VehicleDoor.Location = new System.Drawing.Point(379, 76);
            this.m_pictureBoxC1VehicleDoor.Name = "m_pictureBoxC1VehicleDoor";
            this.m_pictureBoxC1VehicleDoor.Size = new System.Drawing.Size(38, 35);
            this.m_pictureBoxC1VehicleDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxC1VehicleDoor.TabIndex = 2;
            this.m_pictureBoxC1VehicleDoor.TabStop = false;
            // 
            // m_pictureBoxA2VehicleDoor
            // 
            this.m_pictureBoxA2VehicleDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictureBoxA2VehicleDoor.Image = ((System.Drawing.Image)(resources.GetObject("m_pictureBoxA2VehicleDoor.Image")));
            this.m_pictureBoxA2VehicleDoor.Location = new System.Drawing.Point(171, 76);
            this.m_pictureBoxA2VehicleDoor.Name = "m_pictureBoxA2VehicleDoor";
            this.m_pictureBoxA2VehicleDoor.Size = new System.Drawing.Size(38, 35);
            this.m_pictureBoxA2VehicleDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxA2VehicleDoor.TabIndex = 1;
            this.m_pictureBoxA2VehicleDoor.TabStop = false;
            // 
            // m_pictureBoxA1VehicleDoor
            // 
            this.m_pictureBoxA1VehicleDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictureBoxA1VehicleDoor.Image = ((System.Drawing.Image)(resources.GetObject("m_pictureBoxA1VehicleDoor.Image")));
            this.m_pictureBoxA1VehicleDoor.Location = new System.Drawing.Point(171, 35);
            this.m_pictureBoxA1VehicleDoor.Name = "m_pictureBoxA1VehicleDoor";
            this.m_pictureBoxA1VehicleDoor.Size = new System.Drawing.Size(38, 35);
            this.m_pictureBoxA1VehicleDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxA1VehicleDoor.TabIndex = 0;
            this.m_pictureBoxA1VehicleDoor.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_labelTLRightDrsReleased);
            this.groupBox1.Controls.Add(this.m_pictureBoxTLRightDrsReleased);
            this.groupBox1.Controls.Add(this.m_labelTLLeftDrsReleased);
            this.groupBox1.Controls.Add(this.m_pictureBoxTLLeftDrsReleased);
            this.groupBox1.Location = new System.Drawing.Point(468, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 88);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kapı Serbestlik Durumu";
            // 
            // m_labelTLRightDrsReleased
            // 
            this.m_labelTLRightDrsReleased.AutoSize = true;
            this.m_labelTLRightDrsReleased.Location = new System.Drawing.Point(240, 34);
            this.m_labelTLRightDrsReleased.Name = "m_labelTLRightDrsReleased";
            this.m_labelTLRightDrsReleased.Size = new System.Drawing.Size(109, 13);
            this.m_labelTLRightDrsReleased.TabIndex = 9;
            this.m_labelTLRightDrsReleased.Text = "Sağ Kapılar Serbest : ";
            this.m_labelTLRightDrsReleased.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_pictureBoxTLRightDrsReleased
            // 
            this.m_pictureBoxTLRightDrsReleased.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictureBoxTLRightDrsReleased.Image = global::MPUMessenger.Properties.Resources.doorcancelrelease_rotate;
            this.m_pictureBoxTLRightDrsReleased.Location = new System.Drawing.Point(379, 34);
            this.m_pictureBoxTLRightDrsReleased.Name = "m_pictureBoxTLRightDrsReleased";
            this.m_pictureBoxTLRightDrsReleased.Size = new System.Drawing.Size(38, 35);
            this.m_pictureBoxTLRightDrsReleased.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxTLRightDrsReleased.TabIndex = 3;
            this.m_pictureBoxTLRightDrsReleased.TabStop = false;
            // 
            // m_labelTLLeftDrsReleased
            // 
            this.m_labelTLLeftDrsReleased.AutoSize = true;
            this.m_labelTLLeftDrsReleased.Location = new System.Drawing.Point(36, 34);
            this.m_labelTLLeftDrsReleased.Name = "m_labelTLLeftDrsReleased";
            this.m_labelTLLeftDrsReleased.Size = new System.Drawing.Size(105, 13);
            this.m_labelTLLeftDrsReleased.TabIndex = 7;
            this.m_labelTLLeftDrsReleased.Text = "Sol Kapılar Serbest : ";
            this.m_labelTLLeftDrsReleased.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_pictureBoxTLLeftDrsReleased
            // 
            this.m_pictureBoxTLLeftDrsReleased.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictureBoxTLLeftDrsReleased.Image = global::MPUMessenger.Properties.Resources.doorcancelrelease_rotate;
            this.m_pictureBoxTLLeftDrsReleased.Location = new System.Drawing.Point(171, 34);
            this.m_pictureBoxTLLeftDrsReleased.Name = "m_pictureBoxTLLeftDrsReleased";
            this.m_pictureBoxTLLeftDrsReleased.Size = new System.Drawing.Size(38, 35);
            this.m_pictureBoxTLLeftDrsReleased.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxTLLeftDrsReleased.TabIndex = 0;
            this.m_pictureBoxTLLeftDrsReleased.TabStop = false;
            // 
            // m_labelOpenDoorsRight
            // 
            this.m_labelOpenDoorsRight.AutoSize = true;
            this.m_labelOpenDoorsRight.Location = new System.Drawing.Point(28, 88);
            this.m_labelOpenDoorsRight.Name = "m_labelOpenDoorsRight";
            this.m_labelOpenDoorsRight.Size = new System.Drawing.Size(70, 13);
            this.m_labelOpenDoorsRight.TabIndex = 10;
            this.m_labelOpenDoorsRight.Text = "Sağ Kapılar : ";
            this.m_labelOpenDoorsRight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelOpenDoorsLeft
            // 
            this.m_labelOpenDoorsLeft.AutoSize = true;
            this.m_labelOpenDoorsLeft.Location = new System.Drawing.Point(32, 35);
            this.m_labelOpenDoorsLeft.Name = "m_labelOpenDoorsLeft";
            this.m_labelOpenDoorsLeft.Size = new System.Drawing.Size(66, 13);
            this.m_labelOpenDoorsLeft.TabIndex = 8;
            this.m_labelOpenDoorsLeft.Text = "Sol Kapılar : ";
            this.m_labelOpenDoorsLeft.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_pictureBoxOpenDoorsLeft);
            this.groupBox2.Controls.Add(this.m_labelOpenDoorsRight);
            this.groupBox2.Controls.Add(this.m_labelOpenDoorsLeft);
            this.groupBox2.Controls.Add(this.m_pictureBoxOpenDoorsRight);
            this.groupBox2.Location = new System.Drawing.Point(251, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 142);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kapı Durumu";
            // 
            // m_pictureBoxOpenDoorsLeft
            // 
            this.m_pictureBoxOpenDoorsLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictureBoxOpenDoorsLeft.Image = ((System.Drawing.Image)(resources.GetObject("m_pictureBoxOpenDoorsLeft.Image")));
            this.m_pictureBoxOpenDoorsLeft.Location = new System.Drawing.Point(123, 31);
            this.m_pictureBoxOpenDoorsLeft.Name = "m_pictureBoxOpenDoorsLeft";
            this.m_pictureBoxOpenDoorsLeft.Size = new System.Drawing.Size(38, 35);
            this.m_pictureBoxOpenDoorsLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxOpenDoorsLeft.TabIndex = 1;
            this.m_pictureBoxOpenDoorsLeft.TabStop = false;
            // 
            // m_pictureBoxOpenDoorsRight
            // 
            this.m_pictureBoxOpenDoorsRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictureBoxOpenDoorsRight.Image = ((System.Drawing.Image)(resources.GetObject("m_pictureBoxOpenDoorsRight.Image")));
            this.m_pictureBoxOpenDoorsRight.Location = new System.Drawing.Point(123, 88);
            this.m_pictureBoxOpenDoorsRight.Name = "m_pictureBoxOpenDoorsRight";
            this.m_pictureBoxOpenDoorsRight.Size = new System.Drawing.Size(38, 35);
            this.m_pictureBoxOpenDoorsRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxOpenDoorsRight.TabIndex = 2;
            this.m_pictureBoxOpenDoorsRight.TabStop = false;
            // 
            // m_backgroundWorkerAddVariables
            // 
            this.m_backgroundWorkerAddVariables.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_backgroundWorkerAddVariables_DoWork);
            // 
            // m_backgroundWorkerTimerAddVariables
            // 
            this.m_backgroundWorkerTimerAddVariables.Interval = 1000;
            this.m_backgroundWorkerTimerAddVariables.Tick += new System.EventHandler(this.m_backgroundWorkerTimerAddVariables_Tick);
            // 
            // m_backgroundWorkerTimerAddTraceDefinition
            // 
            this.m_backgroundWorkerTimerAddTraceDefinition.Tick += new System.EventHandler(this.m_backgroundWorkerTimerAddTraceDefinition_Tick);
            // 
            // m_backgroundWorkerAddTraceDefinition
            // 
            this.m_backgroundWorkerAddTraceDefinition.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_backgroundWorkerAddTraceDefinition_DoWork);
            // 
            // m_mainMenu
            // 
            this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_settingsPopup,
            this.m_aboutPopup});
            this.m_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.m_mainMenu.Name = "m_mainMenu";
            this.m_mainMenu.Size = new System.Drawing.Size(914, 24);
            this.m_mainMenu.TabIndex = 12;
            this.m_mainMenu.Text = "menuStrip1";
            // 
            // m_settingsPopup
            // 
            this.m_settingsPopup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_communicationItem});
            this.m_settingsPopup.Name = "m_settingsPopup";
            this.m_settingsPopup.Size = new System.Drawing.Size(56, 20);
            this.m_settingsPopup.Text = "Ayarlar";
            // 
            // m_communicationItem
            // 
            this.m_communicationItem.Name = "m_communicationItem";
            this.m_communicationItem.Size = new System.Drawing.Size(137, 22);
            this.m_communicationItem.Text = "Haberleşme";
            this.m_communicationItem.Click += new System.EventHandler(this.m_communicationItem_Click);
            // 
            // m_aboutPopup
            // 
            this.m_aboutPopup.Name = "m_aboutPopup";
            this.m_aboutPopup.Size = new System.Drawing.Size(69, 20);
            this.m_aboutPopup.Text = "Hakkında";
            this.m_aboutPopup.Click += new System.EventHandler(this.m_aboutPopup_Click);
            // 
            // m_labelDistanceCounterReset
            // 
            this.m_labelDistanceCounterReset.AutoSize = true;
            this.m_labelDistanceCounterReset.Location = new System.Drawing.Point(23, 63);
            this.m_labelDistanceCounterReset.Name = "m_labelDistanceCounterReset";
            this.m_labelDistanceCounterReset.Size = new System.Drawing.Size(77, 13);
            this.m_labelDistanceCounterReset.TabIndex = 15;
            this.m_labelDistanceCounterReset.Text = "Sayaç Reset : ";
            this.m_labelDistanceCounterReset.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_radioButtonDistanceCounterResetTrue
            // 
            this.m_radioButtonDistanceCounterResetTrue.AutoSize = true;
            this.m_radioButtonDistanceCounterResetTrue.Checked = true;
            this.m_radioButtonDistanceCounterResetTrue.Location = new System.Drawing.Point(117, 59);
            this.m_radioButtonDistanceCounterResetTrue.Name = "m_radioButtonDistanceCounterResetTrue";
            this.m_radioButtonDistanceCounterResetTrue.Size = new System.Drawing.Size(47, 17);
            this.m_radioButtonDistanceCounterResetTrue.TabIndex = 16;
            this.m_radioButtonDistanceCounterResetTrue.TabStop = true;
            this.m_radioButtonDistanceCounterResetTrue.Text = "True";
            this.m_radioButtonDistanceCounterResetTrue.UseVisualStyleBackColor = true;
            this.m_radioButtonDistanceCounterResetTrue.CheckedChanged += new System.EventHandler(this.m_radioButtonDistanceCounterResetTrue_CheckedChanged);
            // 
            // m_radioButtonDistanceCounterResetFalse
            // 
            this.m_radioButtonDistanceCounterResetFalse.AutoSize = true;
            this.m_radioButtonDistanceCounterResetFalse.Location = new System.Drawing.Point(170, 59);
            this.m_radioButtonDistanceCounterResetFalse.Name = "m_radioButtonDistanceCounterResetFalse";
            this.m_radioButtonDistanceCounterResetFalse.Size = new System.Drawing.Size(50, 17);
            this.m_radioButtonDistanceCounterResetFalse.TabIndex = 16;
            this.m_radioButtonDistanceCounterResetFalse.TabStop = true;
            this.m_radioButtonDistanceCounterResetFalse.Text = "False";
            this.m_radioButtonDistanceCounterResetFalse.UseVisualStyleBackColor = true;
            // 
            // m_groupBoxDistanceCounter
            // 
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_buttonSetVariable);
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_buttonStopAnnouncement);
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_buttonPlayAnnouncement);
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_buttonReleaseDistanceCounterReset);
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_textBoxDistanceCounter);
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_buttonSendDistanceCounterReset);
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_labelDistanceCounter);
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_labelDistanceCounterReset);
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_radioButtonDistanceCounterResetFalse);
            this.m_groupBoxDistanceCounter.Controls.Add(this.m_radioButtonDistanceCounterResetTrue);
            this.m_groupBoxDistanceCounter.Location = new System.Drawing.Point(12, 104);
            this.m_groupBoxDistanceCounter.Name = "m_groupBoxDistanceCounter";
            this.m_groupBoxDistanceCounter.Size = new System.Drawing.Size(233, 142);
            this.m_groupBoxDistanceCounter.TabIndex = 18;
            this.m_groupBoxDistanceCounter.TabStop = false;
            this.m_groupBoxDistanceCounter.Text = "Mesafe Sayacı";
            // 
            // m_buttonSetVariable
            // 
            this.m_buttonSetVariable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonSetVariable.Location = new System.Drawing.Point(94, 93);
            this.m_buttonSetVariable.Name = "m_buttonSetVariable";
            this.m_buttonSetVariable.Size = new System.Drawing.Size(38, 35);
            this.m_buttonSetVariable.TabIndex = 21;
            this.m_buttonSetVariable.Text = "U";
            this.m_buttonSetVariable.UseVisualStyleBackColor = true;
            this.m_buttonSetVariable.Click += new System.EventHandler(this.m_buttonSetVariable_Click);
            // 
            // m_buttonStopAnnouncement
            // 
            this.m_buttonStopAnnouncement.BackgroundImage = global::MPUMessenger.Properties.Resources.music_stop_256x256;
            this.m_buttonStopAnnouncement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonStopAnnouncement.Location = new System.Drawing.Point(50, 93);
            this.m_buttonStopAnnouncement.Name = "m_buttonStopAnnouncement";
            this.m_buttonStopAnnouncement.Size = new System.Drawing.Size(38, 35);
            this.m_buttonStopAnnouncement.TabIndex = 20;
            this.m_buttonStopAnnouncement.UseVisualStyleBackColor = true;
            this.m_buttonStopAnnouncement.Click += new System.EventHandler(this.m_buttonAnnouncement_Click);
            // 
            // m_buttonPlayAnnouncement
            // 
            this.m_buttonPlayAnnouncement.BackgroundImage = global::MPUMessenger.Properties.Resources.play_outline_256x256;
            this.m_buttonPlayAnnouncement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonPlayAnnouncement.Location = new System.Drawing.Point(6, 93);
            this.m_buttonPlayAnnouncement.Name = "m_buttonPlayAnnouncement";
            this.m_buttonPlayAnnouncement.Size = new System.Drawing.Size(38, 35);
            this.m_buttonPlayAnnouncement.TabIndex = 19;
            this.m_buttonPlayAnnouncement.UseVisualStyleBackColor = true;
            this.m_buttonPlayAnnouncement.Click += new System.EventHandler(this.m_buttonAnnouncement_Click);
            // 
            // m_buttonReleaseDistanceCounterReset
            // 
            this.m_buttonReleaseDistanceCounterReset.BackgroundImage = global::MPUMessenger.Properties.Resources._2931171_download_import_save_down_storage_icon;
            this.m_buttonReleaseDistanceCounterReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonReleaseDistanceCounterReset.Location = new System.Drawing.Point(138, 93);
            this.m_buttonReleaseDistanceCounterReset.Name = "m_buttonReleaseDistanceCounterReset";
            this.m_buttonReleaseDistanceCounterReset.Size = new System.Drawing.Size(38, 35);
            this.m_buttonReleaseDistanceCounterReset.TabIndex = 18;
            this.m_buttonReleaseDistanceCounterReset.UseVisualStyleBackColor = true;
            this.m_buttonReleaseDistanceCounterReset.Click += new System.EventHandler(this.m_buttonDistanceCounterReset_Click);
            // 
            // m_buttonSendDistanceCounterReset
            // 
            this.m_buttonSendDistanceCounterReset.BackgroundImage = global::MPUMessenger.Properties.Resources.outlined_send_message_svgrepo_com;
            this.m_buttonSendDistanceCounterReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonSendDistanceCounterReset.Location = new System.Drawing.Point(182, 93);
            this.m_buttonSendDistanceCounterReset.Name = "m_buttonSendDistanceCounterReset";
            this.m_buttonSendDistanceCounterReset.Size = new System.Drawing.Size(38, 35);
            this.m_buttonSendDistanceCounterReset.TabIndex = 17;
            this.m_buttonSendDistanceCounterReset.UseVisualStyleBackColor = true;
            this.m_buttonSendDistanceCounterReset.Click += new System.EventHandler(this.m_buttonDistanceCounterReset_Click);
            // 
            // m_statusStrip
            // 
            this.m_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolStripStatusLabelConnectedMPU,
            this.m_toolStripStatusLabelMPUName,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.m_toolStripStatusLabelMPUStatus,
            this.m_toolStripStatusLabelMPUBehavior,
            this.toolStripStatusLabel3,
            this.m_toolStripStatusLabelWorkingType,
            this.m_toolStripStatusLabelWorkStatus});
            this.m_statusStrip.Location = new System.Drawing.Point(0, 772);
            this.m_statusStrip.Name = "m_statusStrip";
            this.m_statusStrip.Size = new System.Drawing.Size(914, 24);
            this.m_statusStrip.TabIndex = 29;
            this.m_statusStrip.Text = "statusStrip1";
            // 
            // m_toolStripStatusLabelConnectedMPU
            // 
            this.m_toolStripStatusLabelConnectedMPU.Name = "m_toolStripStatusLabelConnectedMPU";
            this.m_toolStripStatusLabelConnectedMPU.Size = new System.Drawing.Size(100, 19);
            this.m_toolStripStatusLabelConnectedMPU.Text = "Bağlanılan MPU : ";
            // 
            // m_toolStripStatusLabelMPUName
            // 
            this.m_toolStripStatusLabelMPUName.Name = "m_toolStripStatusLabelMPUName";
            this.m_toolStripStatusLabelMPUName.Size = new System.Drawing.Size(24, 19);
            this.m_toolStripStatusLabelMPUName.Text = "NA";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 19);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 19);
            // 
            // m_toolStripStatusLabelMPUStatus
            // 
            this.m_toolStripStatusLabelMPUStatus.Name = "m_toolStripStatusLabelMPUStatus";
            this.m_toolStripStatusLabelMPUStatus.Size = new System.Drawing.Size(89, 19);
            this.m_toolStripStatusLabelMPUStatus.Text = "MPU Durumu : ";
            // 
            // m_toolStripStatusLabelMPUBehavior
            // 
            this.m_toolStripStatusLabelMPUBehavior.BackColor = System.Drawing.SystemColors.Control;
            this.m_toolStripStatusLabelMPUBehavior.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.m_toolStripStatusLabelMPUBehavior.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.m_toolStripStatusLabelMPUBehavior.Name = "m_toolStripStatusLabelMPUBehavior";
            this.m_toolStripStatusLabelMPUBehavior.Size = new System.Drawing.Size(66, 19);
            this.m_toolStripStatusLabelMPUBehavior.Text = "Undefined";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 19);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // m_toolStripStatusLabelWorkingType
            // 
            this.m_toolStripStatusLabelWorkingType.Name = "m_toolStripStatusLabelWorkingType";
            this.m_toolStripStatusLabelWorkingType.Size = new System.Drawing.Size(93, 19);
            this.m_toolStripStatusLabelWorkingType.Text = "Çalışma Modu : ";
            // 
            // m_toolStripStatusLabelWorkStatus
            // 
            this.m_toolStripStatusLabelWorkStatus.Name = "m_toolStripStatusLabelWorkStatus";
            this.m_toolStripStatusLabelWorkStatus.Size = new System.Drawing.Size(24, 19);
            this.m_toolStripStatusLabelWorkStatus.Text = "NA";
            // 
            // m_richTextBox
            // 
            this.m_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.m_richTextBox.Location = new System.Drawing.Point(12, 252);
            this.m_richTextBox.Name = "m_richTextBox";
            this.m_richTextBox.Size = new System.Drawing.Size(890, 518);
            this.m_richTextBox.TabIndex = 1;
            this.m_richTextBox.Text = "";
            this.m_richTextBox.TextChanged += new System.EventHandler(this.m_richTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(914, 796);
            this.Controls.Add(this.m_statusStrip);
            this.Controls.Add(this.m_groupBoxDistanceCounter);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_groupBoxVehicleDoorStatus);
            this.Controls.Add(this.m_groupBoxVehicleMovement);
            this.Controls.Add(this.m_richTextBox);
            this.Controls.Add(this.m_mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.m_mainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPU Messenger v1.2";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.m_groupBoxVehicleMovement.ResumeLayout(false);
            this.m_groupBoxVehicleMovement.PerformLayout();
            this.m_groupBoxVehicleDoorStatus.ResumeLayout(false);
            this.m_groupBoxVehicleDoorStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxB1VehicleDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxC1VehicleDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxA2VehicleDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxA1VehicleDoor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxTLRightDrsReleased)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxTLLeftDrsReleased)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxOpenDoorsLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxOpenDoorsRight)).EndInit();
            this.m_mainMenu.ResumeLayout(false);
            this.m_mainMenu.PerformLayout();
            this.m_groupBoxDistanceCounter.ResumeLayout(false);
            this.m_groupBoxDistanceCounter.PerformLayout();
            this.m_statusStrip.ResumeLayout(false);
            this.m_statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerGetVariablesInformation;
        private System.Windows.Forms.GroupBox m_groupBoxVehicleMovement;
        private System.Windows.Forms.Label m_labelA1VehicleDoorStatus;
        private System.Windows.Forms.Label m_labelMileageKm;
        private System.Windows.Forms.Label m_labelDistanceCounter;
        private System.Windows.Forms.Label m_labelSpeed;
        private System.Windows.Forms.GroupBox m_groupBoxVehicleDoorStatus;
        private System.Windows.Forms.Label m_labelA2VehicleDoorStatus;
        private System.Windows.Forms.Label m_labelC1VehicleDoorStatus;
        private System.Windows.Forms.Label m_labelB1VehicleDoorStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label m_labelOpenDoorsRight;
        private System.Windows.Forms.Label m_labelTLRightDrsReleased;
        private System.Windows.Forms.Label m_labelOpenDoorsLeft;
        private System.Windows.Forms.Label m_labelTLLeftDrsReleased;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.PictureBox m_pictureBoxB1VehicleDoor;
        public System.Windows.Forms.PictureBox m_pictureBoxC1VehicleDoor;
        public System.Windows.Forms.PictureBox m_pictureBoxA2VehicleDoor;
        public System.Windows.Forms.PictureBox m_pictureBoxA1VehicleDoor;
        public System.Windows.Forms.PictureBox m_pictureBoxTLRightDrsReleased;
        public System.Windows.Forms.PictureBox m_pictureBoxOpenDoorsRight;
        public System.Windows.Forms.PictureBox m_pictureBoxOpenDoorsLeft;
        public System.Windows.Forms.PictureBox m_pictureBoxTLLeftDrsReleased;
        public System.Windows.Forms.TextBox m_textBoxMileageKm;
        public System.Windows.Forms.TextBox m_textBoxDistanceCounter;
        public System.Windows.Forms.TextBox m_textBoxSpeed;
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerAddVariables;
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerAddTraceDefinition;
        private System.Windows.Forms.MenuStrip m_mainMenu;
        private System.Windows.Forms.ToolStripMenuItem m_settingsPopup;
        private System.Windows.Forms.ToolStripMenuItem m_communicationItem;
        private System.Windows.Forms.Button m_buttonSendDistanceCounterReset;
        private System.Windows.Forms.Label m_labelDistanceCounterReset;
        private System.Windows.Forms.GroupBox m_groupBoxDistanceCounter;
        public System.Windows.Forms.RadioButton m_radioButtonDistanceCounterResetFalse;
        public System.Windows.Forms.RadioButton m_radioButtonDistanceCounterResetTrue;
        private System.Windows.Forms.Button m_buttonReleaseDistanceCounterReset;
        private System.Windows.Forms.StatusStrip m_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelConnectedMPU;
        private System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelWorkingType;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelWorkStatus;
        public System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelMPUName;
        public System.Windows.Forms.Timer m_backgroundWorkerTimerGetVariablesInformation;
        public System.Windows.Forms.Timer m_backgroundWorkerTimerAddVariables;
        public System.Windows.Forms.Timer m_backgroundWorkerTimerAddTraceDefinition;
        private System.Windows.Forms.Button m_buttonStopAnnouncement;
        private System.Windows.Forms.Button m_buttonPlayAnnouncement;
        private System.Windows.Forms.Button m_buttonSetVariable;
        private System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelMPUStatus;
        public System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabelMPUBehavior;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        public System.Windows.Forms.RichTextBox m_richTextBox;
        private System.Windows.Forms.ToolStripMenuItem m_aboutPopup;
    }
}

