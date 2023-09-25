using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;


namespace KontrolaKadi
{
    public class StopWatch : Panel
    {
    
        private Gui MotherForm { get; set; }
        Color AlertBackColor = Color.Red;
        Color ActiveBackColor = Color.Green;
        Color PausedBackColor = Color.Yellow;
        Color NormalColor;
        public bool AlertState = false;

        private TextBox textBox1;
        private Button btnOK;
        private BtnOpomnik btnOpomnik;

        private BtnSetPause btnPause;

        private bool prisotnostiSarze = false;

        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label4;
        private Label label3;
        private Label label2;
        const string dflttime = "0:00:00";
        const string dflttimeFormat = @"h\:mm\:ss";
        const string dflttimeFormat2 = @"HH\:mm\:ss";

        const string OKstring = "OK";
        const string EDITstring = "Edit";

        Task WriteToTable_Task;
        List<string> buff = new List<string>();

        const string dflt = "Vpišite ID sarže...";

        System.Diagnostics.Stopwatch stpwach;

        System.Windows.Forms.Timer frmtmr = new System.Windows.Forms.Timer();
        WatchThread overtimeWatcher = new WatchThread();

        TimeSpan dtm;
        TimeSpan target;
        TimeSpan pause;

        readonly TimeSpan sec = new TimeSpan(0, 0, 1);

        private byte sarzaPrisotna = 0; // 2 - Prisotna;   1 - Ravnokar odstranjena;    0 - čas pavze je potekel, sarža je odsotna 
        private DateTime lastTimePrisotna;

        private bool editMode = false;
        private int panelMaxWidth = 135;

        DateTime lastStarted;
        long startUserId;

        DateTime lastStopped;
        long stopUserId;

        DateTime lastPaused;
        long pausedUserId;
               
        WatchThread LoggerThread;
        WatchThread SarzaPrisotnaChecker = new WatchThread();        

        public int KadID { get; set; }
        int loggingPeriod;

        LogMaker.SarzaOrientedLog Log;

        bool alerted = false;
        bool urgentAlertInProgress = false;

        public StopWatch(int kadID, Gui gui)
        {
            KadID = kadID;
            MotherForm = gui;
            NormalColor = BackColor;

            try
            {
                loggingPeriod = Convert.ToInt32(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("LogPeriod_Sarza").Value);
            }
            catch (Exception)
            {
                loggingPeriod = 30;
            }
             


            this.groupBox2 = new GroupBox();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.label12 = new Label();
            this.label13 = new Label();
            this.groupBox1 = new GroupBox();
            this.btnOK = new Button();
            this.btnOpomnik = new BtnOpomnik(MotherForm, KadID);
            this.btnPause = new BtnSetPause(MotherForm, KadID);
            this.textBox1 = new TextBox();            

            // 
            // panel1
            // 
            Controls.Add(this.groupBox2);
            Controls.Add(this.groupBox1);
            Controls.Add(this.btnOpomnik);
            Controls.Add(this.btnPause);
            Size = new System.Drawing.Size(panelMaxWidth, 270);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.label4);
            groupBox2.Controls.Add(this.label3);
            groupBox2.Controls.Add(this.label2);
            groupBox2.Controls.Add(this.label1);
            groupBox2.Controls.Add(this.label10);
            groupBox2.Controls.Add(this.label11);
            groupBox2.Controls.Add(this.label12);
            groupBox2.Controls.Add(this.label13);
            groupBox2.Location = new System.Drawing.Point(3, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(panelMaxWidth - 6, 135);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "sec";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "h";
            //  
            // label1 - stopwatch time
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 24F);
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(panelMaxWidth - 20, 48);            
            this.label1.Text = "0:00:00";
            // 
            // label10 - target time
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14F);           
            this.label10.Location = new System.Drawing.Point(25, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(panelMaxWidth - 30, 30);           
            this.label10.Text = "0:00:00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Nastavljen čas:";
            // 
            // label13 - pause time
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 14F);
            this.label13.Location = new System.Drawing.Point(25, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(panelMaxWidth - 30, 30);
            this.label13.Text = "0:00:00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 33);
            this.label12.TabIndex = 5;
            this.label12.Text = "Dovoljena pavza:";

            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(panelMaxWidth - 6, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(6, 38);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(groupBox1.Width - 12, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = OKstring;
            this.btnOK.UseVisualStyleBackColor = true;
            btnOK.Enabled = false;
            btnOK.Click += BtnOK_Click;
            // 
            // btnOpomnik
            // 
            this.btnOpomnik.Location = new System.Drawing.Point(btnOK.Location.X + 1, groupBox2.Bottom + 5);
            this.btnOpomnik.Name = "btnOpomnik";
            this.btnOpomnik.Size = btnOK.Size;
            this.btnOpomnik.TabIndex = 1;
            this.btnOpomnik.Text = "Nastavi opomnik";
            this.btnOpomnik.UseVisualStyleBackColor = true;
            btnOpomnik.Enabled = true;
            btnOpomnik.Click += BtnOpomnik_Click;
            btnOpomnik.StopWatchReference = this;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(btnOpomnik.Location.X, btnOpomnik.Bottom + 5);
            this.btnPause.Name = "btnOpomnik";
            this.btnPause.Size = btnOK.Size;
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Nastavi pavzo";
            this.btnPause.UseVisualStyleBackColor = true;
            btnPause.Enabled = true;
            btnPause.Click += btnPause_Click;
            btnPause.StopWatchReference = this;


            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(groupBox1.Width - 12, 20);
            this.textBox1.TabIndex = 1;
            textBox1.Enabled = false;
            textBox1.Text = dflt;
            textBox1.KeyPress += TextBox1_KeyPress;
            textBox1.LostFocus += TextBox1_LostFocus;
            textBox1.TextChanged += TextBox1_TextChanged;

            setTargetTime();
            setPauseTime();


            frmtmr.Interval = 333;
            frmtmr.Tick += Frmtmr_Tick;
            frmtmr.Start();

            stpwach = System.Diagnostics.Stopwatch.StartNew();
            stpwach.Reset();

            SarzaPrisotnaChecker.Thread = new Thread(() => CheckInfoContinuosly());
            SarzaPrisotnaChecker.Start("SarzaPrisotnaChecker Thread", ApartmentState.MTA);

            
        }

        public void setTargetTime()
        {
            target = new TimeSpan(0, 0, 0);
            btnOpomnik.dateTimePicker.Value = DateTimePicker.MinimumDateTime;
            try
            {
                target = target.Add(TimeSpan.FromSeconds(int.Parse(XML_handler.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + KadID).Element("AlertTime1").Value.Replace("\"", ""))));
                btnOpomnik.dateTimePicker.Value = btnOpomnik.dateTimePicker.Value.Add(target);
            }
            catch
            {
                target = target.Add(TimeSpan.FromSeconds(5));
                btnOpomnik.dateTimePicker.Value = btnOpomnik.dateTimePicker.Value.Add(target);
            }

            label10.Text = target.ToString(dflttimeFormat);
        }

        public void setPauseTime()
        {
            pause = new TimeSpan(0, 0, 0);
            btnPause.dateTimePicker.Value = DateTimePicker.MinimumDateTime;
            try
            {
                pause = pause.Add(TimeSpan.FromSeconds(int.Parse(XML_handler.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + KadID).Element("PauseTime1").Value.Replace("\"", ""))));
                btnPause.dateTimePicker.Value = btnPause.dateTimePicker.Value.Add(pause);
            }
            catch
            {
                pause = pause.Add(TimeSpan.FromSeconds(60));
                btnPause.dateTimePicker.Value = btnPause.dateTimePicker.Value.Add(pause);
            }

            label13.Text = pause.ToString(dflttimeFormat);
        }

        MethodInvoker m, m2;
        private bool CheckInfoContinuosly()
        {
            var urgency = "none"; 

            while (true)
            {
                Thread.Sleep(100);
                if (this.IsHandleCreated)
                {
                    break;
                }
            }

            m = new MethodInvoker(delegate
            {
                if (dtm >= target && prisotnostiSarze)
                {
                    BackColor = AlertBackColor; AlertState = true;                   
                }                
            });


            var buff = "";
            var buff2 = "";

            m2 = new MethodInvoker(delegate
            {
                if (prisotnostiSarze)
                {
                    lastTimePrisotna = DateTime.Now;
                }

                if (prisotnostiSarze && sarzaPrisotna < 2) // on status change  false --> true
                {


                    if (sarzaPrisotna == 0)
                    {
                        ResumeTiming(buff, buff2); // if stopwach paused do not reset time
                        WriteDataPonovnoVstavljena(textBox1.Text, label1.Text);
                    }

                    else
                    {
                        buff2 = label1.Text;
                        buff = textBox1.Text;
                        textBox1.Text = dflt;
                        textBox1.Enabled = true;
                        btnOK.Text = OKstring;

                        StartNewTiming(buff, buff2); // if stopwach was stopped for specified time do reset time
                        WriteDataVstavljena(textBox1.Text, label1.Text);
                    }
                    sarzaPrisotna = 2;
                    MotherForm.UpdateGui();

                }

                else if ((DateTime.Now - lastTimePrisotna).TotalSeconds >= btnPause.GetSecondsTotal() && sarzaPrisotna == 0 && !prisotnostiSarze) //  stop timing
                {
                    WriteDataOdstranjena(textBox1.Text, label1.Text);
                    sarzaPrisotna = 1;
                    StopTiming();
                    BackColor = NormalColor;
                    AlertState = false;
                    MotherForm.UpdateGui();
                }

                else if (!prisotnostiSarze && sarzaPrisotna == 2) // on status change  true --> false --- pause stopwatch 
                {
                    WriteDataPavzirana(textBox1.Text, label1.Text);
                    sarzaPrisotna = 0;
                    PauseTiming();
                    BackColor = PausedBackColor;
                    MotherForm.UpdateGui();

                }


            });

            while (true)
            {
                

                switch (KadID)
                {
                    case 1: prisotnostiSarze = FormControl.bt1.Prop2.PrisotnostSarze1.Value; break;
                    case 2: prisotnostiSarze = FormControl.bt1.Prop2.PrisotnostSarze2.Value; break;
                    case 3: prisotnostiSarze = FormControl.bt1.Prop2.PrisotnostSarze3.Value; break;
                    case 4: prisotnostiSarze = FormControl.bt1.Prop2.PrisotnostSarze4.Value; break;
                    case 5: prisotnostiSarze = FormControl.bt1.Prop2.PrisotnostSarze5.Value; break;
                    case 6: prisotnostiSarze = FormControl.bt1.Prop3.PrisotnostSarze6.Value; break;
                    case 7: prisotnostiSarze = FormControl.bt1.Prop4.PrisotnostSarze7.Value; break;
                    case 8: prisotnostiSarze = FormControl.bt1.Prop4.PrisotnostSarze8.Value; break;
                    case 9: prisotnostiSarze = FormControl.bt1.Prop5.PrisotnostSarze9.Value; break;
                    case 10: prisotnostiSarze = FormControl.bt1.Prop6.PrisotnostSarze10.Value; break;
                    case 11: prisotnostiSarze = FormControl.bt1.Prop8.PrisotnostSarze11.Value; break;
                    case 12: prisotnostiSarze = FormControl.bt1.Prop6.PrisotnostSarze12.Value; break;
                    case 13: prisotnostiSarze = FormControl.bt1.Prop6.PrisotnostSarze13.Value; break;
                    case 14: prisotnostiSarze = FormControl.bt1.Prop6.PrisotnostSarze14.Value; break;
                    case 15: prisotnostiSarze = FormControl.bt1.Prop7.PrisotnostSarze15.Value; break;
                    case 16: prisotnostiSarze = FormControl.bt1.Prop7.PrisotnostSarze16.Value; break;
                    case 17: prisotnostiSarze = FormControl.bt1.Prop7.PrisotnostSarze17.Value; break;
                    case 18: prisotnostiSarze = FormControl.bt1.Prop7.PrisotnostSarze18.Value; break;
                    case 19: prisotnostiSarze = FormControl.bt1.Prop8.PrisotnostSarze19.Value; break;
                    default: FormControl.bt1.WL("Data requested does not exsist. Message source: getSarzaPrisotna() method.", -1); return false;
                }

               
                Invoke(m2);               
                Invoke(m);

                urgency = getUrgency(KadID);

                if (!alerted && dtm >= target && prisotnostiSarze && urgency == "urgent") // Piskaj drugače za urgent mode
                {
                    FormControl.bt1.Prop1.BuzzFromPC_Urgent.SendPulse();
                    alerted = true;
                    urgentAlertInProgress = true;
                }
                else if (!alerted && dtm >= target && prisotnostiSarze && urgency == "normal") // Piskaj drugače za normal mode
                {
                    FormControl.bt1.Prop1.BuzzFromPC_Normal.SendPulse();
                    alerted = true;
                }
                else if (urgentAlertInProgress && !alerted && dtm >= target && !prisotnostiSarze && urgency == "urgent")
                {
                    FormControl.bt1.Prop1.BuzzFromPC_Stop.SendPulse();
                    urgentAlertInProgress = false;
                }

                Thread.Sleep(500);
                
            }
        }

        private string getUrgency(int KadID)
        {
            try
            {
                if (MotherForm.GuiID == 1)
                {
                    var kad = MotherForm.kadi[KadID];
                    return kad.Urgency;
                }

                if (MotherForm.GuiID == 2)
                {
                    var kad = MotherForm.kadi[KadID-9]; // -9 is offset for array
                    return kad.Urgency;
                }

                return "normal";

            }
            catch (Exception)
            {
                return "normal";
            }
           
        }

        private void Logger(int ID, int logEvery_X_sec)
        {
            var f = FormControl.bt1;
            DateTime dt1;
            string buff1 = null, buff2 = null, buff3 = null, buff4 = null, buff5 = null, buff6 = null;

            while (true)
            {                
                dt1 = DateTime.Now.Add(TimeSpan.FromSeconds(logEvery_X_sec));

                switch (ID)
                {
                    case 1:
                        buff1 = f.Prop2.Temperatura11.Value;
                        buff2 = f.Prop2.Temperatura21.Value;
                        buff4 = f.Prop2.Alarmzatemperaturo1.Value.ToString();
                        buff5 = f.Prop2.Alarmzarazlikotemperature1.Value.ToString();
                        buff6 = f.Prop2.Nivo1.Value.ToString();
                        break;

                    case 2:
                        buff1 = f.Prop2.Temperatura12.Value;
                        buff2 = f.Prop2.Temperatura22.Value;
                        buff4 = f.Prop2.Alarmzatemperaturo2.Value.ToString();
                        buff5 = f.Prop2.Alarmzarazlikotemperature2.Value.ToString();
                        buff6 = f.Prop2.Nivo2.Value.ToString();
                        break;

                    case 3: break;
                    case 4: break;
                    case 5: break;

                    case 6:
                        buff1 = f.Prop3.Temperatura16.Value;
                        buff2 = f.Prop3.Temperatura26.Value; break;

                    case 7:
                        buff1 = f.Prop4.Temperatura17.Value;
                        buff2 = f.Prop4.Temperatura27.Value;
                        buff3 = f.Prop4.Ph7.Value;
                        buff4 = f.Prop4.Alarmzatemperaturo7.Value.ToString();
                        buff5 = f.Prop4.Alarmzarazlikotemperature7.Value.ToString();
                        buff6 = f.Prop4.Nivo7.Value.ToString();
                        break;

                    case 8: break;

                    case 9:
                        buff1 = f.Prop5.Temperatura19.Value;
                        buff2 = f.Prop5.Temperatura29.Value; break;         
                        
                    case 10: break;

                        ////

                    case 11:
                        buff1 = f.Prop8.Temperatura111.Value;
                        buff4 = f.Prop8.Alarmzatemperaturo11.Value.ToString();
                        buff6 = f.Prop8.Nivo11.Value.ToString();
                        break;

                    case 12:
                        buff1 = f.Prop6.Temperatura112.Value;
                        buff2 = f.Prop6.Temperatura212.Value;
                        buff3 = f.Prop6.Ph12.Value;
                        buff4 = f.Prop6.Alarmzatemperaturo12.Value.ToString();
                        buff5 = f.Prop6.Alarmzarazlikotemperature12.Value.ToString();
                        buff6 = f.Prop6.Nivo12.Value.ToString();
                        break;

                    case 13: break;

                    case 14:
                        buff1 = f.Prop6.Temperatura114.Value;
                        buff2 = f.Prop6.Temperatura214.Value;
                        buff3 = f.Prop6.Ph14.Value;
                        buff4 = f.Prop6.Alarmzatemperaturo14.Value.ToString();
                        buff5 = f.Prop6.Alarmzarazlikotemperature14.Value.ToString();
                        buff6 = f.Prop6.Nivo14.Value.ToString();
                        break;    
                        
                    case 15:
                        buff1 = f.Prop7.Temperatura115.Value;
                        buff2 = f.Prop7.Temperatura215.Value;
                        buff3 = f.Prop7.Ph15.Value;
                        buff4 = f.Prop7.Alarmzatemperaturo15.Value.ToString();
                        buff5 = f.Prop7.Alarmzarazlikotemperature15.Value.ToString();
                        buff6 = f.Prop7.Nivo15.Value.ToString();
                        break;

                    case 16: break;

                    case 17:
                        buff1 = f.Prop7.Temperatura117.Value;
                        buff2 = f.Prop7.Temperatura217.Value;
                        buff3 = f.Prop7.Ph17.Value;
                        buff4 = f.Prop7.Alarmzatemperaturo17.Value.ToString();
                        buff5 = f.Prop7.Alarmzarazlikotemperature17.Value.ToString();
                        buff6 = f.Prop7.Nivo17.Value.ToString();
                        break;

                    case 18: break;
                    
                    case 19:
                        buff1 = f.Prop8.Temperatura119.Value;
                        buff2 = f.Prop8.Temperatura219.Value;
                        buff4 = f.Prop8.Alarmzatemperaturo19.Value.ToString();
                        buff6 = f.Prop8.Nivo19.Value.ToString();
                        break;

                    default: FormControl.bt1.WL("Error Retrieving data for logging. Source logger() method. (" + ID + ").", 0); return;

                }

                Log.addValues(buff1, buff2, buff3, buff4, buff5, buff6);

                while (DateTime.Now <= dt1)
                {
                    Thread.Sleep(100);
                }
            }           
        }

        private void Frmtmr_Tick(object sender, EventArgs e)
        {
            if (stpwach.IsRunning)
            {
                dtm = stpwach.Elapsed;
                label1.Text = dtm.ToString(dflttimeFormat);                
            }            
        }

        public void SetWidth(int width)
        {
            if (width <= panelMaxWidth)
            {
                this.Width = width;
            }
            else
            {
                this.Width = panelMaxWidth;
            }
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text != dflt)
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (editMode == false)
            {
                textBox1.Enabled = false;
                btnOK.Text = EDITstring;
                editMode = true;
                Thread.Sleep(100);
            }
            else if (editMode == true)
            {
                textBox1.Enabled = true;
                btnOK.Text = OKstring;
                editMode = false;
                Thread.Sleep(100);
            }
        }
        private void BtnOpomnik_Click(object sender, EventArgs e)
        {
            btnOpomnik.ShowForm();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnPause.ShowForm();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Contains(dflt))
            {
                textBox1.Clear();
            }

            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back; // allows only backspace and numeric

            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnOK_Click(null, null);
            }

        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = dflt;
            }
        }

       

        private void StartNewTiming(string oldSarzaID, string oldTime)
        {
            try
            {
                if (label1.Text != dflttime && Log != null)
                {
                    Log.createLogFileForPrevious(startUserId, stopUserId, KadID.ToString(), oldSarzaID, lastStarted, lastStopped, oldTime, btnOpomnik.dateTimePicker.Value.ToString(dflttimeFormat2));
                }
                Log = new LogMaker.SarzaOrientedLog();
            }
            catch (Exception ex)
            {
                FormControl.bt1.WL("Creation of log file was unsuccessful. Reason: " + ex.Message, -1);
            }
            
            btnOpomnik.Enabled = false;

            dtm = new TimeSpan(0, 0, 0);
            label1.Text = dflttime;

            lastStarted = DateTime.Now;
            startUserId = FormControl.identify.GetIDLogedInUser();

            stpwach.Reset();

            LoggerThread = new WatchThread()
            {
                Thread = new Thread(() => Logger(KadID, loggingPeriod))
            };

            LoggerThread.Start("LoggerThread", ApartmentState.MTA);
            alerted = false;

            stpwach.Start();
            BackColor = ActiveBackColor;


        }

        private void ResumeTiming(string oldSarzaID, string oldTime)
        {
            stpwach.Start();
            BackColor = ActiveBackColor;
        }


        private void StopTiming()
        {            
            btnOpomnik.Enabled = true;
            lastStopped = DateTime.Now;
            stopUserId = FormControl.identify.GetIDLogedInUser();
            stpwach.Stop();
            BackColor = NormalColor;
            alerted = false;            
        }

        private void PauseTiming()
        {
            lastPaused = DateTime.Now;
            pausedUserId = FormControl.identify.GetIDLogedInUser();
            stpwach.Stop();
            BackColor = PausedBackColor;            
        }



        public void WriteDataVstavljena(string IDsarza, string timeDuration)
        {
            buff.Clear();
            if (label1.Text != string.Empty && label1.Text != null && label1.Text.Length > 2)
            {
                WriteToTable_Task = new Task(new Action(WriteToTableVstavljena));

                if (textBox1.Text != dflt && textBox1.Text != string.Empty && textBox1.Text != null && textBox1.Text.Length > 0)
                {
                    buff.Add(IDsarza);
                }
                else
                {
                    buff.Add(UnknownID());
                }
                buff.Add(timeDuration);
                WriteToTable_Task.Start();
            }
        }

        public void WriteDataPonovnoVstavljena(string IDsarza, string timeDuration)
        {
            buff.Clear();
            if (label1.Text != string.Empty && label1.Text != null && label1.Text.Length > 2)
            {
                WriteToTable_Task = new Task(new Action(WriteToTablePonovnoVstavljena));

                if (textBox1.Text != dflt && textBox1.Text != string.Empty && textBox1.Text != null && textBox1.Text.Length > 0)
                {
                    buff.Add(IDsarza);
                }
                else
                {
                    buff.Add(UnknownID());
                }
                buff.Add(timeDuration);
                WriteToTable_Task.Start();
            }
        }

        public void WriteDataOdstranjena(string IDsarza, string timeDuration)
        {
            buff.Clear();
            if (label1.Text != string.Empty && label1.Text != null && label1.Text.Length > 2)
            {
                WriteToTable_Task = new Task(new Action(WriteToTableOdstranjena));

                if (textBox1.Text != dflt && textBox1.Text != string.Empty && textBox1.Text != null && textBox1.Text.Length > 0)
                {
                    buff.Add(IDsarza);
                }
                else
                {
                    buff.Add(UnknownID());
                }
                buff.Add(timeDuration);

                if (timeDuration != dflttime)
                {
                    WriteToTable_Task.Start();
                }                
            }
        }

        public void WriteDataPavzirana(string IDsarza, string atTime)
        {
            buff.Clear();
            if (label1.Text != string.Empty && label1.Text != null && label1.Text.Length > 2)
            {
                WriteToTable_Task = new Task(new Action(WriteToTablePavza));

                if (textBox1.Text != dflt && textBox1.Text != string.Empty && textBox1.Text != null && textBox1.Text.Length > 0)
                {
                    buff.Add(IDsarza);
                }
                else
                {
                    buff.Add(UnknownID());
                }
                buff.Add(atTime);

                WriteToTable_Task.Start();
            }
        }


        public void WriteToTableOdstranjena()
        {
            try
            {
                Gui.WL_UserAction("Sarža z Identom " + buff[0] + " je bila odstranjena po pretečenem času: " + buff[1] + " " +
                    "s kadi z ID " + KadID, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing data to table: " + ex.Message);
            }
        }

        public void WriteToTableVstavljena()
        {
            try
            {
                Gui.WL_UserAction("Sarža z Identom " + buff[0] + " je bila vstavljena ob času: " + buff[1] + " " +
                    "s kadi z ID " + KadID, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing data to table: " + ex.Message);
            }
        }

        public void WriteToTablePonovnoVstavljena()
        {
            try
            {
                Gui.WL_UserAction("Sarža z Identom " + buff[0] + " je bila ponovno vstavljena ob času: " + buff[1] + " " +
                    "s kadi z ID " + KadID, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing data to table: " + ex.Message);
            }
        }

        public void WriteToTablePavza()
        {
            try
            {
                Gui.WL_UserAction("Sarža z Identom " + buff[0] + " je bila pavzirana ob času: " + buff[1] + " " +
                    "s kadi z ID " + KadID, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing data to table: " + ex.Message);
            }
        }

        public string UnknownID()
        {
            return "UNKNOWN ID!"; // TODO - avtomatsko generiranje imen za saržo
        }

        public class BtnOpomnik : Button
        {
            private Gui MotherForm { get; set; }
            private int ID { get; set; }
            public Form OpomnikSetForm = new Form();
            public DateTimePicker dateTimePicker = new DateTimePicker();
            Label label = new Label();
            Button OKbtn = new Button();
            Button Cancelbtn = new Button();
            public StopWatch StopWatchReference;

            public BtnOpomnik(Gui _MotherForm, int _ID)
            {
                MotherForm = _MotherForm;
                ID = _ID;

                OpomnikSetForm.ControlBox = false;
                dateTimePicker.Format = DateTimePickerFormat.Time;
                dateTimePicker.Location = new Point(180, 68);
                dateTimePicker.Name = "dateTimePicker1";
                dateTimePicker.Size = new Size(69, 20);
                dateTimePicker.TabIndex = 0;
                try
                {
                    dateTimePicker.Value = DateTimePicker.MinimumDateTime + TimeSpan.FromSeconds(int.Parse(XML_handler.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + ID).Element("AlertTime1").Value));
                }
                catch (Exception ex)
                {
                    FormControl.bt1.WL("Failed to read from XML, AlertTime1 parameter" + ex.Message, -1);
                    dateTimePicker.Value = DateTimePicker.MinimumDateTime.Add(TimeSpan.FromMinutes(30));
                }
                dateTimePicker.ShowUpDown = true;

                dateTimePicker.Top = 40;
                dateTimePicker.Left = 20;
                dateTimePicker.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20);


                label.Text = "Izberite nov čas za opomnik: ";
                label.Top = 10;
                label.Left = 10;
                label.Height = 20;
                label.Width = 220;
                label.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);

                OKbtn.Top = 100;
                OKbtn.Left = 10;
                OKbtn.Width = 100;
                OKbtn.Height = 50;
                OKbtn.Text = "OK";
                OKbtn.Font = label.Font;

                Cancelbtn.Top = OKbtn.Top;
                Cancelbtn.Left = OKbtn.Right + 20;
                Cancelbtn.Width = OKbtn.Width;
                Cancelbtn.Height = OKbtn.Height;
                Cancelbtn.Text = "Cancel";
                Cancelbtn.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);

                OpomnikSetForm.Width = OKbtn.Left + OKbtn.Width + (Cancelbtn.Left - OKbtn.Right) + Cancelbtn.Width + OKbtn.Left + 20;
                OpomnikSetForm.Height = OKbtn.Bottom + 40;
                dateTimePicker.Width = OpomnikSetForm.Width - 60;

                OpomnikSetForm.Controls.Add(OKbtn);
                OpomnikSetForm.Controls.Add(Cancelbtn);
                OpomnikSetForm.Controls.Add(label);
                OpomnikSetForm.Controls.Add(dateTimePicker);

                OpomnikSetForm.LostFocus += SetTemps_form_LostFocus;
                OKbtn.Click += OKbtn_Click;
                Cancelbtn.Click += Cancelbtn_Click;

            }

            private void OKbtn_Click(object sender, EventArgs e)
            {
                try
                {
                    XML_handler.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + ID).Element("AlertTime1").Value = (dateTimePicker.Value - DateTimePicker.MinimumDateTime).TotalSeconds.ToString();
                    XML_handler.SaveXML();
                    StopWatchReference.setTargetTime();
                }
                catch (Exception ex)
                {
                    FormControl.bt1.WL("Failed to set/ write to XML AlertTime1 parameter" + ex.Message, -1);
                    dateTimePicker.Value = DateTimePicker.MinimumDateTime.Add(TimeSpan.FromSeconds(60));
                }
                                              
                Cancelbtn_Click(null, null);
            }

            private void Cancelbtn_Click(object sender, EventArgs e)
            {
                OpomnikSetForm.Hide();
            }

            private void SetTemps_form_LostFocus(object sender, EventArgs e)
            {
                OpomnikSetForm.Focus();
            }

            public void ShowForm()
            {
                Misc.ShowFormOnCenterOfActiveScreen(Form.ActiveForm, OpomnikSetForm);
            }

        }

        public class BtnSetPause : Button
        {
            private Gui MotherForm { get; set; }
            private int ID { get; set; }
            public Form PavzaSetFormSetForm = new Form();
            public DateTimePicker dateTimePicker = new DateTimePicker();
            Label label = new Label();
            Button OKbtn = new Button();
            Button Cancelbtn = new Button();
            public StopWatch StopWatchReference;

            public BtnSetPause(Gui _MotherForm, int _ID)
            {
                MotherForm = _MotherForm;
                ID = _ID;

                PavzaSetFormSetForm.ControlBox = false;
                dateTimePicker.Format = DateTimePickerFormat.Time;
                dateTimePicker.Location = new Point(180, 68);
                dateTimePicker.Name = "dateTimePicker1";
                dateTimePicker.Size = new Size(69, 20);
                dateTimePicker.TabIndex = 0;
                dateTimePicker.ShowUpDown = true;
                try
                {
                    dateTimePicker.Value = DateTimePicker.MinimumDateTime + TimeSpan.FromSeconds(int.Parse(XML_handler.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + ID).Element("PauseTime1").Value));
                }
                catch (Exception ex)
                {
                    FormControl.bt1.WL("Failed to read from XML, PauseTime1 parameter" + ex.Message, -1);
                }
                

                dateTimePicker.Top = 40;
                dateTimePicker.Left = 20;
                dateTimePicker.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20);


                label.Text = "Izberite čas pavze: ";
                label.Top = 10;
                label.Left = 10;
                label.Height = 20;
                label.Width = 220;
                label.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);

                OKbtn.Top = 100;
                OKbtn.Left = 10;
                OKbtn.Width = 100;
                OKbtn.Height = 50;
                OKbtn.Text = "OK";
                OKbtn.Font = label.Font;

                Cancelbtn.Top = OKbtn.Top;
                Cancelbtn.Left = OKbtn.Right + 20;
                Cancelbtn.Width = OKbtn.Width;
                Cancelbtn.Height = OKbtn.Height;
                Cancelbtn.Text = "Cancel";
                Cancelbtn.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);

                PavzaSetFormSetForm.Width = OKbtn.Left + OKbtn.Width + (Cancelbtn.Left - OKbtn.Right) + Cancelbtn.Width + OKbtn.Left + 20;
                PavzaSetFormSetForm.Height = OKbtn.Bottom + 40;
                dateTimePicker.Width = PavzaSetFormSetForm.Width - 60;

                PavzaSetFormSetForm.Controls.Add(OKbtn);
                PavzaSetFormSetForm.Controls.Add(Cancelbtn);
                PavzaSetFormSetForm.Controls.Add(label);
                PavzaSetFormSetForm.Controls.Add(dateTimePicker);



                PavzaSetFormSetForm.LostFocus += SetTemps_form_LostFocus;
                OKbtn.Click += OKbtn_Click;
                Cancelbtn.Click += Cancelbtn_Click;

            }

            private void OKbtn_Click(object sender, EventArgs e)
            {
                try
                {
                    XML_handler.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + ID).Element("PauseTime1").Value = (dateTimePicker.Value - DateTimePicker.MinimumDateTime).TotalSeconds.ToString();
                    XML_handler.SaveXML();
                    StopWatchReference.setPauseTime();                    
                }
                catch (Exception ex)
                {
                    FormControl.bt1.WL("Failed to set/ write to XML PauseTime1 parameter" + ex.Message, -1);   
                }
                
                Cancelbtn_Click(null, null);
            }

            private void Cancelbtn_Click(object sender, EventArgs e)
            {
                PavzaSetFormSetForm.Hide();
            }

            private void SetTemps_form_LostFocus(object sender, EventArgs e)
            {
                PavzaSetFormSetForm.Focus();
            }

            public void ShowForm()
            {
                Misc.ShowFormOnCenterOfActiveScreen(Form.ActiveForm, PavzaSetFormSetForm);
            }

            public double GetSecondsTotal()
            {
                return (dateTimePicker.Value - DateTimePicker.MinimumDateTime).TotalSeconds;
            }

        }

        class WatchThread
        {
            public bool canelationPending = false; // Check manualy outside
            public Thread Thread; // Provide outside

            public WatchThread()
            {

            }

            public void Start(string ThreadName, ApartmentState apartmentState)
            {
                canelationPending = false;
                Thread.SetApartmentState(apartmentState);
                Thread.Name = ThreadName;
                Thread.Start();
            }

            public void Stop()
            {
                canelationPending = true;
                var cnt = 0;
                Thread.Sleep(50);
                while (canelationPending == true && Thread.IsAlive)
                {
                    Thread.Sleep(50);
                    if (cnt >= 10)
                    {
                        Thread.Abort();
                        FormControl.bt1.WL("Thread " + Thread.Name + "was closed by force.", 0);
                    }
                }
            }
        }

        private byte SetPrisotna(bool prisotna)
        {
            if (prisotna)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
