using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Timers;
using System.Media;
using System.Diagnostics;


namespace Arduino_Project
{
    public partial class Form1 : Form
    {
        //Get the current directory of the program:
        private string filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        //
        ArduinoController arduino;
        string ENDL = Environment.NewLine+" "; //text boxes are weird with new lines
        bool wasEarly = false; //pressed button too soon check
        bool isReady = false; //ready to read from COM port
        bool isDone = true; //used for the auto-timed tests, since tests will have consecutive runs
        bool isEnd = false; // not used
        bool isStarted = false; //prevents starting multiple times, which is mostly harmless
        bool useMinutes = true;
        bool useSound = false;
        int autoTimer = 0; // 0 means no auto testing
        int periodTimer = 0;
        bool periodStarted = false;
        System.Timers.Timer aTimer, pTimer;
        bool isBaseline = false;
        int minTime = 2;
        int maxTime = 5;
        Random random;
        int nextIndex = 0;
        bool pauseToggle = true;
        bool disablePause = true;
        int periodNum = 0; //used when using auto-start timers
        Stopwatch pauseTimer;
        
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            arduino = new ArduinoController();
            random = new Random();
            //autoDetectArduino(); //creates start-up lag
            textBoxLog.Text = ",,,,,"+ENDL+"Date,Time,Reaction Time,Pressed Early,Type,RandStart,RandEnd,Period,Begin,End,"+ENDL+",,,,,";
            textBoxLog.VisibleChanged +=new EventHandler(textBox_ScrollToBottom);
            textBoxPortActivity.TextChanged += new EventHandler(textBox_ScrollToBottom);
            textBoxPortActivity.VisibleChanged += new EventHandler(textBox_ScrollToBottom);
            checkBoxSound.CheckedChanged += new EventHandler(updateLabels);
            TimeMin.ValueChanged += new EventHandler(updateLabels);
            TimeMax.ValueChanged += new EventHandler(updateLabels);
            baselineCount.ValueChanged += new EventHandler(updateLabels);
            //
            initializeTimerLayout();
        }

        void numericUpDownPeriod_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void autoDetectArduino()
        {
            COMPort.Items.Clear();
            string[] ports = arduino.SetComPort();
            for (int i = 0; i < ports.Length; i++)
                COMPort.Items.Add(ports[i]);
            if (arduino.portFound)
            {
                isReady = true;
                openComPort(arduino.comPort);
                updatePortActivity("Connected"+ENDL);
            }
        }
        private void openComPort(SerialPort comPort)
        {
            COMPort.SelectedItem = comPort.PortName;
            comPort.DataReceived += new SerialDataReceivedEventHandler(ComPortHandler);
            comPort.Open();
        }
        private string portStringHolder = "";
        private void ComPortHandler(object senderPort, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500); //give the port a chance to finish
            //the sender object will always be a port
            SerialPort port = (SerialPort)senderPort;
            string s = getPortText(port);
            portStringHolder += s;
            updatePortActivity(s);
            if (portStringHolder.Contains("ARDUINO_STOPPING"))
            {
                //ensures that a canceled test doesn't affect the next test
                wasEarly = false;
                portStringHolder = portStringHolder.After("ARDUINO_STOPPING");
            }
            if (portStringHolder.Contains("ARDUINO_READY"))
            {
                isReady = true;
            }
            if (portStringHolder.Contains("ARDUINO_STARTING"))
            {
                portStringHolder = portStringHolder.After("ARDUINO_STARTING");
                isStarted = true;
                isDone = false;
                if(useSound){
                    //SystemSounds.Beep.Play();
                    Console.Beep();
                }
                //need to make it thread safe. not worth the hassle
                //tabControl1.SelectedIndex = 1;
            }
            if (portStringHolder.Contains("ARDUINO_END"))
            {
                isEnd = true;
            }
            if (portStringHolder.Contains("ARDUINO_EARLY"))
            {
                wasEarly = true;
            }
            if (portStringHolder.Contains("ARDUINO_TIME"))
            {
                DateTime datetime = DateTime.Now;
                string reactionTime = portStringHolder.Between("ARDUINO_TIME", "END").Trim();
                string logText = "\n" + datetime.ToString("MM/dd/yy,hh:mm:ss") + "," + reactionTime + ",";
                logText += minTime.ToString() + "," + maxTime.ToString() + ",";
                if (wasEarly)
                    logText += "Yes,";
                else
                    logText += "No,";
                if (isBaseline)
                    logText += "B,\n";
                else if (periodNum > 0)
                {
                    logText += "P" + periodNum + ",";
                    logText += layoutRows[periodNum - 1].Period.Text + ",";
                    logText += layoutRows[periodNum - 1].Begin.Text + ",";
                    logText += layoutRows[periodNum - 1].End.Text + ",\n";
                }
                else
                    logText += "T,\n";

                updateReactionLog(logText);
                portStringHolder = portStringHolder.After("END");
                wasEarly = false;
            }
            if (portStringHolder.Contains("ARDUINO_DONE"))
            {
                portStringHolder = portStringHolder.After("ARDUINO_DONE");
                isStarted = false;
                isDone = true;
                if (isBaseline)
                {
                    isBaseline = false;
                    arduino.ArduinoSetTestCount(1);
                }
                if (autoTimer != 0)
                {
                    //!Invoke(new AutoStartDelegate(AutoStartTimer));
                }
            }
            
            if (portStringHolder.Length > 255)
            {
                portStringHolder = portStringHolder.Substring(200);
            }
            
        }

        delegate void AppendTextCallback(string text);
        private void updatePortActivity(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBoxPortActivity.InvokeRequired)
            {
                AppendTextCallback d = new AppendTextCallback(updatePortActivity);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                textBoxPortActivity.AppendText(text);
                textBoxPortActivity.Lines = textBoxPortActivity.Text.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            }
        }
        private void updateReactionLog(string text)
        {
            if (this.textBoxLog.InvokeRequired)
            {
                AppendTextCallback d = new AppendTextCallback(updateReactionLog);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                textBoxLog.AppendText(text);
                textBoxLog.Lines = textBoxLog.Text.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            }
        }

        public string getPortText(SerialPort port)
        {
            int count = port.BytesToRead;
            int intReturnASCII = 0;
            string returnMessage = "";
            while (count > 0)
            {
                intReturnASCII = port.ReadByte();
                returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                count--;
            }
            return returnMessage;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (isReady && !isStarted)
            {
                tabControl1.SelectedIndex = 2;
                arduino.ArduinoStart();
            }
            if(!isReady)
                MessageBox.Show("Device has not sent ready signal on COMport.");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (aTimer != null && autoTimer > 0)
            {
                aTimer.Enabled = false;
                autoTimer = 0;
                updatePortActivity(ENDL + "Auto-start timer stopped" + ENDL);
                if (periodStarted)
                {
                    pTimer.Enabled = false;
                    periodTimer = 0;
                }
            }
            if (isReady)
            {
                isReady = false;
                arduino.ArduinoStop();
            }
            else
            {
                MessageBox.Show("Device has not sent ready signal on COMport.");
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Please connect an Arduino to a USB port that has a DFRobot Input Shield (DFR0008 Version 1 [two buttons])\n2. Ensure that the program that was provided with this software is loaded onto the Arduino.\n3. Auto detect the port or enter the port name manually.","Help Info");
        }

        private void buttonAutoDetect_Click(object sender, EventArgs e)
        {
            autoDetectArduino();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            arduino.WriteToPort(16, 128, 0, 0, 4);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = filePath;
            saveFile.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                int err = saveLogFile(saveFile.FileName);
                if (err == 0)
                    return;
                else
                    MessageBox.Show("Could not save file");
            }
        }

        private int saveLogFile(string saveFile)
        {
            string[] lines = textBoxLog.Lines;
            using (StreamWriter sw = File.CreateText(saveFile))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if(lines[i].Trim() != "")
                        sw.WriteLine(lines[i]);
                }
            }
            return 0;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = filePath;
            openFile.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                int err = openLogFile(openFile.FileName);
                if (err == 0)
                    return;
                else
                    MessageBox.Show("Error Loading");
            }
        }

        private int openLogFile(string openFile)
        {
            using (StreamReader sr = new StreamReader(openFile))
            {
                textBoxLog.Clear();
                textBoxLog.AppendText(sr.ReadToEnd());
                textBoxLog.Lines = textBoxLog.Text.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            return 0;
        }

        public void updateLabels(object sender, System.EventArgs e)
        {
            //this changes the value, which calls this function:
            TimeMin.Value = Math.Max(Math.Floor(TimeMin.Value), 0);
            TimeMax.Value = Math.Max(Math.Floor(TimeMax.Value), TimeMin.Value+1);
            baselineCount.Value = Math.Max(Math.Floor(baselineCount.Value), 1);
            useSound = checkBoxSound.Checked;
            
        }
        public void textBox_ScrollToBottom(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Visible)
            {
                tb.SelectionStart = tb.TextLength;
                tb.ScrollToCaret();
            }
        }

        /*private void buttonStartTimer_Click(object sender, EventArgs e)
        {
            AutoStartTimer();
        }*/
        delegate void AutoStartDelegate();
        /*public void AutoStartTimer()
        {
            if (isDone && arduino.portFound)
            {
                periodTimer = Convert.ToInt32(numericUpDownPeriod.Value);
                autoTimer = trackBarTestTimer.Value;
                if (autoTimer <= 0)
                    return;

                if (!periodStarted && periodTimer > 0)
                {
                    periodStarted = true;
                    pTimer = new System.Timers.Timer();
                    pTimer.Elapsed += new ElapsedEventHandler(PeriodStopTest);
                    pTimer.SynchronizingObject = this;
                    pTimer.AutoReset = false;
                    pTimer.Interval = periodTimer * 60000;
                    pTimer.Enabled = true;
                }

                isDone = false;
                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(AutoStartTest);

                string s = ENDL + "Timer started. Watch device for the LED to turn on every " + trackBarTestTimer.Value;
                if (useMinutes)
                {
                    aTimer.Interval = autoTimer * 60000;
                    s += " minutes.";
                }
                else
                {
                    aTimer.Interval = autoTimer * 1000;
                    s += " seconds.";
                }
                aTimer.SynchronizingObject = this;
                aTimer.Enabled = true;
                updatePortActivity(s+ENDL);
            }
            else
            {
                updatePortActivity(ENDL + "Could not start auto-test timer. If you already started a timer, click the stop button." + ENDL);
                
            }
        }*/
        /*private static void AutoStartTest(object sender, ElapsedEventArgs e)
        {
            System.Timers.Timer senderTimer = (sender as System.Timers.Timer);
            Form1 parentForm = (senderTimer.SynchronizingObject as Form1);
            senderTimer.Stop();
            if(!parentForm.isStarted){
                parentForm.arduino.ArduinoStart();
            }
        }*/
        /*private static void PeriodStopTest(object sender, ElapsedEventArgs e)
        {
            System.Timers.Timer senderTimer = (sender as System.Timers.Timer);
            Form1 parentForm = (senderTimer.SynchronizingObject as Form1);
            senderTimer.Stop();
            senderTimer.Enabled = false;
            parentForm.aTimer.Stop();
            parentForm.aTimer.Enabled = false;
            parentForm.periodTimer = 0;
            parentForm.autoTimer = 0;
            parentForm.periodStarted = false;

            parentForm.arduino.ArduinoStop();
            MessageBox.Show("The testing period has ended.");
        }*/
        private void initializeTimerLayout()
        {
            if (AutoStartTimerLayout.RowCount <= 2)
            {
                
                layoutRows = new List<LayoutRow>();
                layoutRows.Add(new LayoutRow(0));
                layoutRows[0].Set(StartTimer0, Period0, Begin0, End0);
                layoutRows.Add(new LayoutRow(1));
                layoutRows[1].Set(StartTimer1, Period1, Begin1, End1, AutoCheckBox1);
                StartTimer0.Click += (sender2, e2) => StartTimer_Click(sender2, e2, layoutRows[0]);
                StartTimer1.Click += (sender2, e2) => StartTimer_Click(sender2, e2, layoutRows[1]);
            }
        }
        List<LayoutRow> layoutRows;
        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            if(AutoStartTimerLayout.RowCount <= 2){
                AutoStartTimerLayout.Height += 70;
                AutoStartTimerLayout.AutoScroll = true;
                AutoStartTimerLayout.Padding = new System.Windows.Forms.Padding(0, 5, System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, 10);

            }
            AutoStartTimerLayout.RowCount++;
            AutoStartTimerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            Button startTimer = createButtonST();
            MaskedTextBox periodMTB = createTimeField();
            MaskedTextBox beginMTB = createTimeField();
            MaskedTextBox endMTB = createTimeField();
            CheckBox autosetCB = createCheckBoxAS();
            int i = layoutRows.Count;
            layoutRows.Add(new LayoutRow(i));
            layoutRows[i].Set(startTimer, periodMTB, beginMTB, endMTB, autosetCB);
            AddRowControls(layoutRows[i], AutoStartTimerLayout);

            //attach the row to the click event
            startTimer.Click += (sender2, e2) => StartTimer_Click(sender, e, layoutRows[i]);
            
        }

        void StartTimer_Click(object sender, EventArgs e, LayoutRow row)
        {
            //MessageBox.Show(row.GetInfoString());
            startAutoTimer(row);
        }

        public void startAutoTimer(LayoutRow row)
        {
            disablePause = false;
            nextIndex = row.Index + 1;
            int begin = getSeconds(row.Begin.Text);
            int period = getSeconds(row.Period.Text);
            int end = getSeconds(row.End.Text);
            textBoxTimerInfo.AppendText("About to start timer " + (row.Index + 1) + "\n");

            if (period < maxTime)
            {
                textBoxTimerInfo.AppendText("Period time too low, setting to " + maxTime + " seconds.\n");
                period = maxTime;
            }
            if (begin > period - maxTime)
            {
                textBoxTimerInfo.AppendText("Begin time too large, setting to 1 second.\n");
                begin = 1;
            }
            if (end > period - maxTime)
            {
                textBoxTimerInfo.AppendText("End time too large, setting to " + (period - maxTime) + " seconds.\n");
                end = period - maxTime;
            }

            if (begin < 1)
                begin = 1;
            if (end < begin)
                end = begin;

            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(autoTimerElapsed);
            aTimer.SynchronizingObject = this;
            aTimer.Interval = random.Next(begin, end) * 1000;
            //textBoxTimerInfo.AppendText("random time = " + (random.Next(begin, end) * 1000) + "\n");
            textBoxTimerInfo.AppendText("Timer " + (row.Index + 1) + " Started.\n");
            periodNum = row.Index + 1;

            pTimer = new System.Timers.Timer();
            pTimer.Elapsed += new ElapsedEventHandler(periodTimerElapsed);
            pTimer.SynchronizingObject = this;
            pTimer.Interval = period * 1000;
            
            pauseTimer = new Stopwatch();
            pauseTimer.Start();
            aTimer.Start();
            pTimer.Start();
        }

        private static void autoTimerElapsed(object sender, ElapsedEventArgs e)
        {
            System.Timers.Timer senderTimer = (sender as System.Timers.Timer);
            Form1 parentForm = (senderTimer.SynchronizingObject as Form1);
            senderTimer.Stop();
            if (!parentForm.isStarted)
            {
                parentForm.isDone = false;
                parentForm.arduino.ArduinoStart();
            }
            else
            {
                parentForm.textBoxTimerInfo.AppendText("Auto-Start Timer has ended but device is already in a test.\n");
            }
        }

        private static void periodTimerElapsed(object sender, ElapsedEventArgs e)
        {
            System.Timers.Timer senderTimer = (sender as System.Timers.Timer);
            Form1 parentForm = (senderTimer.SynchronizingObject as Form1);
            senderTimer.Stop();
            if (!parentForm.isDone && parentForm.isStarted)
            {
                parentForm.textBoxTimerInfo.AppendText("Period has ended but waiting for test to complete. Checking again in 5 seconds.\n");
                System.Timers.Timer redoTimer = new System.Timers.Timer();
                redoTimer.Interval = 5000;
                redoTimer.SynchronizingObject = parentForm;
                redoTimer.Elapsed += periodTimerElapsed;
                redoTimer.Start();
                return;
            }
            parentForm.textBoxTimerInfo.AppendText("Period "+parentForm.nextIndex+" Complete.\n");
            parentForm.periodNum = 0;
            if (parentForm.layoutRows.Count-1 >= parentForm.nextIndex)
            {
                LayoutRow row = parentForm.layoutRows[parentForm.nextIndex];
                if (row.AutoCheckBox.Checked == true)
                {
                    parentForm.startAutoTimer(row);
                    return; //don't disable pause
                }
            }
            parentForm.disablePause = true;
        }

        public static int getSeconds(string Text)
        {
            int sec = 0;

            if (Text == null)
                return 0;
            if (IsNumber(Text.Before(":")))
                sec += Convert.ToInt32(Text.Before(":")) * 60;
            if (IsNumber(Text.After(":")))
                sec += Convert.ToInt32(Text.After(":"));
            return sec;
        }

        public static bool IsNumber(object Expression)
        {
            double retNum;
            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void AddRowControls(LayoutRow row, TableLayoutPanel layout)
        {
            layout.Controls.Add(row.Period, 0, layout.RowCount - 1);
            layout.Controls.Add(row.Begin, 1, layout.RowCount - 1);
            layout.Controls.Add(row.End, 2, layout.RowCount - 1);
            layout.Controls.Add(row.AutoCheckBox, 3, layout.RowCount - 1);
            layout.Controls.Add(row.StartTimer, 4, layout.RowCount - 1);
            layout.ScrollControlIntoView(row.StartTimer);
            layout.Focus();
        }
        private Button createButtonST()
        {
            Button startTimer = new Button();
            startTimer.Text = "Start Timer";
            startTimer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            return startTimer;
        }
        private MaskedTextBox createTimeField()
        {
            MaskedTextBox mtb = new MaskedTextBox("00:00");
            mtb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            return mtb;
        }
        private CheckBox createCheckBoxAS()
        {
            CheckBox cb = new CheckBox();
            cb.Text = AutoCheckBox1.Text;
            cb.Anchor = AnchorStyles.Left;
            cb.Checked = true;
            return cb;
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Device has not sent ready signal on COMport.");
                return;
            }
            if (isStarted)
            {
                updatePortActivity("\nWait for current test to end or hit the Stop button to set.");
                return;
            }
            arduino.ArduinoSetTimeMin((uint)TimeMin.Value);
            arduino.ArduinoSetTimeMax((uint)TimeMax.Value);
            minTime = (int)TimeMin.Value;
            maxTime = (int)TimeMax.Value;
        }

        private void buttonBaseline_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Device has not sent ready signal on COMport.");
                return;
            }
            if (isBaseline || isStarted)
            {
                updatePortActivity("\nCould not start baseline test. A test is already running.");
                return;
            }
            isBaseline = true;
            arduino.ArduinoSetTestCount((uint)baselineCount.Value);
            arduino.ArduinoStart();
            tabControl1.SelectedIndex = 2;
        }

        bool unpauseA = false;
        private void buttonPauseTimer_Click(object sender, EventArgs e)
        {
            if (pTimer == null || disablePause)
                return;
            pauseTimer.Stop();
            if (pauseToggle)
            {
                pauseToggle = false;
                if(aTimer.Enabled){
                    aTimer.Stop();
                    aTimer.Interval = Math.Max(1, aTimer.Interval-pauseTimer.ElapsedMilliseconds);
                    unpauseA = true;
                } else
                    unpauseA = false;
                pTimer.Stop();
                pTimer.Interval = Math.Max(1, pTimer.Interval-pauseTimer.ElapsedMilliseconds);
                buttonPauseTimer.Text = "Resume Current Timer";
                textBoxTimerInfo.AppendText("Timer Paused.\n");
            }
            else
            {
                pauseTimer = Stopwatch.StartNew();
                if(unpauseA)
                    aTimer.Start();
                pTimer.Start();
                pauseToggle = true;
                buttonPauseTimer.Text = "Pause Current Timer";
                textBoxTimerInfo.AppendText("Timer Resumed.\n");
            }

        }

    }
}
