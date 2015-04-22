namespace Arduino_Project
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonBaseline = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSet = new System.Windows.Forms.Button();
            this.TimeMax = new System.Windows.Forms.NumericUpDown();
            this.TimeMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPortActivity = new System.Windows.Forms.TextBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonAutoDetect = new System.Windows.Forms.Button();
            this.COMPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxTimerInfo = new System.Windows.Forms.TextBox();
            this.buttonPauseTimer = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AutoStartTimerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.End0 = new System.Windows.Forms.MaskedTextBox();
            this.Begin0 = new System.Windows.Forms.MaskedTextBox();
            this.StartTimer0 = new System.Windows.Forms.Button();
            this.Period0 = new System.Windows.Forms.MaskedTextBox();
            this.AutoCheckBox1 = new System.Windows.Forms.CheckBox();
            this.StartTimer1 = new System.Windows.Forms.Button();
            this.End1 = new System.Windows.Forms.MaskedTextBox();
            this.Begin1 = new System.Windows.Forms.MaskedTextBox();
            this.Period1 = new System.Windows.Forms.MaskedTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.checkBoxSound = new System.Windows.Forms.CheckBox();
            this.baselineCount = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeMin)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.AutoStartTimerLayout.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baselineCount)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(382, 372);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(93, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start Single Test";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStop.Location = new System.Drawing.Point(12, 372);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 354);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.AutoScrollMinSize = new System.Drawing.Size(400, 300);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.baselineCount);
            this.tabPage1.Controls.Add(this.buttonBaseline);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.buttonSet);
            this.tabPage1.Controls.Add(this.TimeMax);
            this.tabPage1.Controls.Add(this.TimeMin);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxPortActivity);
            this.tabPage1.Controls.Add(this.buttonHelp);
            this.tabPage1.Controls.Add(this.buttonTest);
            this.tabPage1.Controls.Add(this.buttonAutoDetect);
            this.tabPage1.Controls.Add(this.COMPort);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(455, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Setup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonBaseline
            // 
            this.buttonBaseline.Location = new System.Drawing.Point(341, 109);
            this.buttonBaseline.Name = "buttonBaseline";
            this.buttonBaseline.Size = new System.Drawing.Size(104, 24);
            this.buttonBaseline.TabIndex = 23;
            this.buttonBaseline.Text = "Run Baseline Test";
            this.buttonBaseline.UseVisualStyleBackColor = true;
            this.buttonBaseline.Click += new System.EventHandler(this.buttonBaseline_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(129, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "seconds";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Random Test Interval for all tests";
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(180, 106);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(39, 23);
            this.buttonSet.TabIndex = 19;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // TimeMax
            // 
            this.TimeMax.Location = new System.Drawing.Point(85, 107);
            this.TimeMax.Name = "TimeMax";
            this.TimeMax.Size = new System.Drawing.Size(40, 20);
            this.TimeMax.TabIndex = 18;
            this.TimeMax.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // TimeMin
            // 
            this.TimeMin.Location = new System.Drawing.Point(17, 107);
            this.TimeMin.Name = "TimeMin";
            this.TimeMin.Size = new System.Drawing.Size(40, 20);
            this.TimeMin.TabIndex = 17;
            this.TimeMin.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port Activity and Setup Information";
            // 
            // textBoxPortActivity
            // 
            this.textBoxPortActivity.Location = new System.Drawing.Point(6, 174);
            this.textBoxPortActivity.Multiline = true;
            this.textBoxPortActivity.Name = "textBoxPortActivity";
            this.textBoxPortActivity.ReadOnly = true;
            this.textBoxPortActivity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPortActivity.Size = new System.Drawing.Size(443, 148);
            this.textBoxPortActivity.TabIndex = 5;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(326, 37);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonHelp.TabIndex = 4;
            this.buttonHelp.Text = "Help Info";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(232, 37);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 3;
            this.buttonTest.Text = "Test Port";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonAutoDetect
            // 
            this.buttonAutoDetect.BackColor = System.Drawing.Color.Transparent;
            this.buttonAutoDetect.Location = new System.Drawing.Point(139, 37);
            this.buttonAutoDetect.Name = "buttonAutoDetect";
            this.buttonAutoDetect.Size = new System.Drawing.Size(75, 23);
            this.buttonAutoDetect.TabIndex = 2;
            this.buttonAutoDetect.Text = "Auto Detect";
            this.buttonAutoDetect.UseVisualStyleBackColor = false;
            this.buttonAutoDetect.Click += new System.EventHandler(this.buttonAutoDetect_Click);
            // 
            // COMPort
            // 
            this.COMPort.FormattingEnabled = true;
            this.COMPort.Location = new System.Drawing.Point(7, 39);
            this.COMPort.Name = "COMPort";
            this.COMPort.Size = new System.Drawing.Size(112, 21);
            this.COMPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select COM port for Arduino device";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.textBoxTimerInfo);
            this.tabPage4.Controls.Add(this.buttonPauseTimer);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.buttonAddRow);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.AutoStartTimerLayout);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(455, 328);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Auto-Start Timers";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(294, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 30);
            this.label12.TabIndex = 10;
            this.label12.Text = "Enter all times as min:sec\r\nup to 99:99 for 1 hr 40 min";
            // 
            // textBoxTimerInfo
            // 
            this.textBoxTimerInfo.Location = new System.Drawing.Point(6, 260);
            this.textBoxTimerInfo.Multiline = true;
            this.textBoxTimerInfo.Name = "textBoxTimerInfo";
            this.textBoxTimerInfo.ReadOnly = true;
            this.textBoxTimerInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTimerInfo.Size = new System.Drawing.Size(443, 62);
            this.textBoxTimerInfo.TabIndex = 9;
            // 
            // buttonPauseTimer
            // 
            this.buttonPauseTimer.Location = new System.Drawing.Point(297, 231);
            this.buttonPauseTimer.Name = "buttonPauseTimer";
            this.buttonPauseTimer.Size = new System.Drawing.Size(148, 23);
            this.buttonPauseTimer.TabIndex = 8;
            this.buttonPauseTimer.Text = "Pause Current Timer";
            this.buttonPauseTimer.UseVisualStyleBackColor = true;
            this.buttonPauseTimer.Click += new System.EventHandler(this.buttonPauseTimer_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "(video length)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(105, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 26);
            this.label9.TabIndex = 6;
            this.label9.Text = "A single test will be randomly\r\nstarted between Begin and End.";
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(6, 231);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(75, 23);
            this.buttonAddRow.TabIndex = 4;
            this.buttonAddRow.Text = "Add Row";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(196, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Test End";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(105, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Test Begin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Period";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoStartTimerLayout
            // 
            this.AutoStartTimerLayout.BackColor = System.Drawing.Color.Transparent;
            this.AutoStartTimerLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.AutoStartTimerLayout.ColumnCount = 5;
            this.AutoStartTimerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.AutoStartTimerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.AutoStartTimerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.AutoStartTimerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.AutoStartTimerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.AutoStartTimerLayout.Controls.Add(this.End0, 2, 0);
            this.AutoStartTimerLayout.Controls.Add(this.Begin0, 1, 0);
            this.AutoStartTimerLayout.Controls.Add(this.StartTimer0, 4, 0);
            this.AutoStartTimerLayout.Controls.Add(this.Period0, 0, 0);
            this.AutoStartTimerLayout.Controls.Add(this.AutoCheckBox1, 3, 1);
            this.AutoStartTimerLayout.Controls.Add(this.StartTimer1, 4, 1);
            this.AutoStartTimerLayout.Controls.Add(this.End1, 2, 1);
            this.AutoStartTimerLayout.Controls.Add(this.Begin1, 1, 1);
            this.AutoStartTimerLayout.Controls.Add(this.Period1, 0, 1);
            this.AutoStartTimerLayout.Location = new System.Drawing.Point(6, 56);
            this.AutoStartTimerLayout.Name = "AutoStartTimerLayout";
            this.AutoStartTimerLayout.RowCount = 2;
            this.AutoStartTimerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.AutoStartTimerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.AutoStartTimerLayout.Size = new System.Drawing.Size(443, 100);
            this.AutoStartTimerLayout.TabIndex = 0;
            // 
            // End0
            // 
            this.End0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.End0.Location = new System.Drawing.Point(180, 16);
            this.End0.Mask = "00:00";
            this.End0.Name = "End0";
            this.End0.Size = new System.Drawing.Size(81, 20);
            this.End0.TabIndex = 4;
            this.End0.Text = " 230";
            // 
            // Begin0
            // 
            this.Begin0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Begin0.Location = new System.Drawing.Point(92, 16);
            this.Begin0.Mask = "00:00";
            this.Begin0.Name = "Begin0";
            this.Begin0.Size = new System.Drawing.Size(81, 20);
            this.Begin0.TabIndex = 3;
            this.Begin0.Text = "  30";
            // 
            // StartTimer0
            // 
            this.StartTimer0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTimer0.Location = new System.Drawing.Point(356, 14);
            this.StartTimer0.Name = "StartTimer0";
            this.StartTimer0.Size = new System.Drawing.Size(83, 23);
            this.StartTimer0.TabIndex = 1;
            this.StartTimer0.Text = "Start Timer";
            this.StartTimer0.UseVisualStyleBackColor = true;
            // 
            // Period0
            // 
            this.Period0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Period0.Location = new System.Drawing.Point(4, 16);
            this.Period0.Mask = "00:00";
            this.Period0.Name = "Period0";
            this.Period0.Size = new System.Drawing.Size(81, 20);
            this.Period0.TabIndex = 2;
            this.Period0.Text = " 300";
            // 
            // AutoCheckBox1
            // 
            this.AutoCheckBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AutoCheckBox1.AutoSize = true;
            this.AutoCheckBox1.Checked = true;
            this.AutoCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoCheckBox1.Location = new System.Drawing.Point(268, 55);
            this.AutoCheckBox1.Name = "AutoCheckBox1";
            this.AutoCheckBox1.Size = new System.Drawing.Size(68, 43);
            this.AutoCheckBox1.TabIndex = 0;
            this.AutoCheckBox1.Text = "Autostart\r\nafter\r\nprevious";
            this.AutoCheckBox1.UseVisualStyleBackColor = true;
            // 
            // StartTimer1
            // 
            this.StartTimer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTimer1.Location = new System.Drawing.Point(356, 65);
            this.StartTimer1.Name = "StartTimer1";
            this.StartTimer1.Size = new System.Drawing.Size(83, 23);
            this.StartTimer1.TabIndex = 5;
            this.StartTimer1.Text = "Start Timer";
            this.StartTimer1.UseVisualStyleBackColor = true;
            // 
            // End1
            // 
            this.End1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.End1.Location = new System.Drawing.Point(180, 67);
            this.End1.Mask = "00:00";
            this.End1.Name = "End1";
            this.End1.Size = new System.Drawing.Size(81, 20);
            this.End1.TabIndex = 6;
            // 
            // Begin1
            // 
            this.Begin1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Begin1.Location = new System.Drawing.Point(92, 67);
            this.Begin1.Mask = "00:00";
            this.Begin1.Name = "Begin1";
            this.Begin1.Size = new System.Drawing.Size(81, 20);
            this.Begin1.TabIndex = 7;
            // 
            // Period1
            // 
            this.Period1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Period1.Location = new System.Drawing.Point(4, 67);
            this.Period1.Mask = "00:00";
            this.Period1.Name = "Period1";
            this.Period1.Size = new System.Drawing.Size(81, 20);
            this.Period1.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonLoad);
            this.tabPage2.Controls.Add(this.buttonSave);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBoxLog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(455, 328);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Testing Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(295, 15);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(375, 15);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Reaction Time Log";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(9, 46);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(440, 276);
            this.textBoxLog.TabIndex = 0;
            this.textBoxLog.Text = ",,,\r\nDate,Time,Reaction Time,\r\n,,,";
            // 
            // checkBoxSound
            // 
            this.checkBoxSound.AutoSize = true;
            this.checkBoxSound.Location = new System.Drawing.Point(155, 376);
            this.checkBoxSound.Name = "checkBoxSound";
            this.checkBoxSound.Size = new System.Drawing.Size(177, 17);
            this.checkBoxSound.TabIndex = 3;
            this.checkBoxSound.Text = "Play Sound when any test starts";
            this.checkBoxSound.UseVisualStyleBackColor = true;
            // 
            // baselineCount
            // 
            this.baselineCount.Location = new System.Drawing.Point(371, 89);
            this.baselineCount.Name = "baselineCount";
            this.baselineCount.Size = new System.Drawing.Size(35, 20);
            this.baselineCount.TabIndex = 24;
            this.baselineCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(249, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "Baseline test repeats";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(405, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 15);
            this.label14.TabIndex = 26;
            this.label14.Text = "times.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 407);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.checkBoxSound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Reaction Time Tester";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeMin)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.AutoStartTimerLayout.ResumeLayout(false);
            this.AutoStartTimerLayout.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baselineCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox COMPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonAutoDetect;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPortActivity;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxSound;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel AutoStartTimerLayout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox AutoCheckBox1;
        private System.Windows.Forms.Button StartTimer0;
        private System.Windows.Forms.MaskedTextBox Period0;
        private System.Windows.Forms.MaskedTextBox End0;
        private System.Windows.Forms.MaskedTextBox Begin0;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button StartTimer1;
        private System.Windows.Forms.MaskedTextBox End1;
        private System.Windows.Forms.MaskedTextBox Begin1;
        private System.Windows.Forms.MaskedTextBox Period1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonPauseTimer;
        private System.Windows.Forms.TextBox textBoxTimerInfo;
        private System.Windows.Forms.NumericUpDown TimeMin;
        private System.Windows.Forms.NumericUpDown TimeMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button buttonBaseline;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown baselineCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}

