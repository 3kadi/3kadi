using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KontrolaKadi
{
    public class PanelStat : Panel
    {       
        public int SkupnaPoraba = 0;
        public int SkupnaPorabaMax = 0;
        public float PorabaJoule = 0;

                        
        private Label labelSkupnaPoraba;
        private GroupBox groupBoxTrenutnaPoraba;
        public TextBox textBoxOdTegaElox;
        private Label labelodTegaElox;
        public TextBox textBoxSkupnaPoraba;
        public TextBox textBoxOdTegaBarve;
        private Label labelOdTegaBarve;
        private GroupBox groupBoxStatistika;
        private GroupBox groupBoxUporabno;
        private GroupBox groupBoxSkupnaPoraba;
        public TextBox textBoxDelovneUre;
        private Label labelDelovneUre;
        public TextBox textBoxStevecPorabe;
        private Label labelŠtevecPorabe;
        private Button btnShowLogFolder;
        private Button btnShowSearchEngine;
        private Button btnUtisajAlarm;

        private GroupBox zapiski;
        public CheckBox zapisek1Chk;
        public TextBox zapisek1;
        public CheckBox zapisek2Chk;
        public TextBox zapisek2;
        public CheckBox zapisek3Chk;
        public TextBox zapisek3;

        public PanelStat()
        {
            labelSkupnaPoraba = new Label();
            groupBoxTrenutnaPoraba = new GroupBox();
            textBoxSkupnaPoraba = new TextBox();
            textBoxOdTegaElox = new TextBox();
            labelodTegaElox = new Label();
            textBoxOdTegaBarve = new TextBox();
            labelOdTegaBarve = new Label();
            groupBoxStatistika = new GroupBox();
            groupBoxUporabno = new GroupBox();
            groupBoxSkupnaPoraba = new GroupBox();
            textBoxStevecPorabe = new TextBox();
            labelŠtevecPorabe = new Label();
            textBoxDelovneUre = new TextBox();
            labelDelovneUre = new Label();
            btnShowLogFolder = new Button();
            btnUtisajAlarm = new Button();
            btnShowSearchEngine = new Button();
            zapiski = new GroupBox();
            zapisek1Chk = new CheckBox();
            zapisek1 = new TextBox();
            zapisek2Chk = new CheckBox();
            zapisek2 = new TextBox();
            zapisek3Chk = new CheckBox();
            zapisek3 = new TextBox();

            // 
            // panelStat
            //                         
            this.Size = new Size(500, 139);

            // 
            // groupBoxStatistika
            //             
            this.groupBoxStatistika.Location = new Point(3, 3);
            this.groupBoxStatistika.Name = "groupBoxStatistika";
            this.groupBoxStatistika.Size = new Size(428, 126);
            this.groupBoxStatistika.TabIndex = 2;
            this.groupBoxStatistika.TabStop = false;
            this.groupBoxStatistika.Text = "Statistika";
            // 
            // groupBoxUporabno
            //             
            this.groupBoxUporabno.Location = new Point(groupBoxStatistika.Right + 3, groupBoxStatistika.Location.X);
            this.groupBoxUporabno.Name = "groupBoxUporabno";
            this.groupBoxUporabno.Size = new Size(300, 126);
            this.groupBoxUporabno.TabIndex = 2;
            this.groupBoxUporabno.TabStop = false;
            this.groupBoxUporabno.Text = "Uporabno";
            // 
            // groupBoxTrenutnaPoraba
            // 

            this.groupBoxTrenutnaPoraba.Name = "groupBoxTrenutnaPoraba";
            this.groupBoxTrenutnaPoraba.Size = new Size(206, 100);
            this.groupBoxTrenutnaPoraba.TabIndex = 1;
            this.groupBoxTrenutnaPoraba.TabStop = false;
            this.groupBoxTrenutnaPoraba.Text = "Trenutna Poraba";
            // 
            // groupBoxSkupnaPoraba
            //                   
            this.groupBoxSkupnaPoraba.Name = "groupBoxSkupnaPoraba";
            this.groupBoxSkupnaPoraba.Size = new Size(199, 100);
            this.groupBoxSkupnaPoraba.TabIndex = 12;
            this.groupBoxSkupnaPoraba.TabStop = false;
            this.groupBoxSkupnaPoraba.Text = "Poraba Skupaj";

            // 
            // labelSkupnaPoraba
            //             
            this.labelSkupnaPoraba.Location = new Point(6, 25);
            this.labelSkupnaPoraba.Name = "labelSkupnaPoraba";
            this.labelSkupnaPoraba.Size = new Size(86, 13);
            this.labelSkupnaPoraba.TabIndex = 0;
            this.labelSkupnaPoraba.Text = "Skupna poraba: ";
            // 
            // textBoxSkupnaPoraba
            // 

            this.textBoxSkupnaPoraba.Name = "textBoxSkupnaPoraba";
            this.textBoxSkupnaPoraba.Location = new System.Drawing.Point(94, 22);
            this.textBoxSkupnaPoraba.ReadOnly = true;
            this.textBoxSkupnaPoraba.Size = new Size(91, 20);
            this.textBoxSkupnaPoraba.TabIndex = 1;
            textBoxSkupnaPoraba.Enabled = false;
            // 
            // textBoxOdTegaElox
            // 
            this.textBoxOdTegaElox.Location = new Point(122, 47);
            this.textBoxOdTegaElox.Name = "textBoxOdTegaElox";
            this.textBoxOdTegaElox.ReadOnly = true;
            this.textBoxOdTegaElox.Size = new Size(63, 20);
            this.textBoxOdTegaElox.TabIndex = 3;
            textBoxOdTegaElox.Enabled = false;
            // 
            // labelodTegaElox
            // 
            this.labelodTegaElox.Location = new Point(42, 50);
            this.labelodTegaElox.Name = "labelodTegaElox";
            this.labelodTegaElox.Size = new Size(74, 13);
            this.labelodTegaElox.TabIndex = 2;
            this.labelodTegaElox.Text = "Od tega Elox: ";
            // 
            // textBoxOdTegaBarve
            // 
            this.textBoxOdTegaBarve.Location = new Point(122, 73);
            this.textBoxOdTegaBarve.Name = "textBoxOdTegaBarve";
            this.textBoxOdTegaBarve.ReadOnly = true;
            this.textBoxOdTegaBarve.Size = new Size(63, 20);
            this.textBoxOdTegaBarve.TabIndex = 5;
            textBoxOdTegaBarve.Enabled = false;
            // 
            // labelOdTegaBarve
            // 
            this.labelOdTegaBarve.Location = new Point(34, 76);
            this.labelOdTegaBarve.Name = "labelOdTegaBarve";
            this.labelOdTegaBarve.Size = new Size(82, 13);
            this.labelOdTegaBarve.TabIndex = 4;
            this.labelOdTegaBarve.Text = "Od tega Barve: ";
            // 
            // textBoxStevecPorabe
            // 
            this.textBoxStevecPorabe.Location = new Point(104, 22);
            this.textBoxStevecPorabe.Name = "textBoxStevecPorabe";
            this.textBoxStevecPorabe.ReadOnly = true;
            this.textBoxStevecPorabe.Size = new Size(81, 20);
            this.textBoxStevecPorabe.TabIndex = 13;
            textBoxStevecPorabe.Enabled = false;
            // 
            // labelŠtevecPorabe
            // 
            this.labelŠtevecPorabe.Location = new Point(6, 25);
            this.labelŠtevecPorabe.Name = "labelŠtevecPorabe";
            this.labelŠtevecPorabe.Size = new Size(83, 13);
            this.labelŠtevecPorabe.TabIndex = 12;
            this.labelŠtevecPorabe.Text = "Števec porabe: ";
            // 
            // textBoxDelovneUre
            // 
            this.textBoxDelovneUre.Location = new Point(104, 47);
            this.textBoxDelovneUre.Name = "textBoxDelovneUre";
            this.textBoxDelovneUre.ReadOnly = true;
            this.textBoxDelovneUre.Size = new Size(81, 20);
            this.textBoxDelovneUre.TabIndex = 15;
            textBoxDelovneUre.Enabled = false;
            // 
            // labelDelovneUre
            //  
            this.labelDelovneUre.Location = new Point(6, 50);
            this.labelDelovneUre.Name = "labelDelovneUre";
            this.labelDelovneUre.Size = new Size(71, 13);
            this.labelDelovneUre.TabIndex = 14;
            this.labelDelovneUre.Text = "Delovne ure: ";

            // 
            // btnUtisajAlarm
            //            
            this.btnUtisajAlarm.Location = new Point(10, 25 + 25 + 10 + 25 + 10);
            this.btnUtisajAlarm.Name = "btnUtisajAlarm";
            this.btnUtisajAlarm.Size = new Size(175, 21);
            this.btnUtisajAlarm.Text = "Utišaj alarm";
            // 
            // btnShowLogFolder
            //            
            this.btnShowSearchEngine.Location = new Point(10, 25 + 25 + 10);
            this.btnShowSearchEngine.Name = "btnShowSearchEngine";
            this.btnShowSearchEngine.Size = new Size(175, 21);
            this.btnShowSearchEngine.Text = "Odpri iskalnik";
            // 
            // btnShowLogFolder
            //             
            this.btnShowLogFolder.Location = new Point(10, 25);
            this.btnShowLogFolder.Name = "btnShowLogFolder";
            this.btnShowLogFolder.Size = new Size(175, 21);
            this.btnShowLogFolder.Text = "Odpri mapo z Dnevniki";
            // 
            // GroupboxZapiski
            //             
            zapiski.Location = new Point(groupBoxUporabno.Right + 10, groupBoxStatistika.Top);
            zapiski.Text = "Zapiski";
            zapiski.Size = groupBoxUporabno.Size;
            // 
            // CheckBoxZapisek1
            //             
            zapisek1Chk.Location = new Point(20, zapiski.Top + 22);
            zapisek1Chk.AutoSize = true;
            // 
            // TextboxZapisek1
            //             
            zapisek1.Location = new Point(50, zapiski.Top + 20);
            zapisek1.Width = zapiski.Width -10;
            var fontZapisek = zapisek1.Font;
            fontZapisek = new Font(fontZapisek, FontStyle.Bold);
            zapisek1.Font = fontZapisek;

            // 
            // CheckBoxZapisek2
            //             
            zapisek2Chk.Location = new Point(zapisek1Chk.Left, zapisek1Chk.Top + zapisek1.Height + 10);
            zapisek2Chk.AutoSize = true;
            // 
            // TextboxZapisek2
            //             
            zapisek2.Location = new Point(zapisek1.Left, zapisek1.Bottom + 10);
            zapisek2.Width = zapisek1.Width;
            zapisek2.Font = fontZapisek;
            // 
            // CheckBoxZapisek3
            //             
            zapisek3Chk.Location = new Point(zapisek1Chk.Left, zapisek2Chk.Top + zapisek1.Height + 10);
            zapisek3Chk.AutoSize = true;
            // 
            // TextboxZapisek3
            //             
            zapisek3.Location = new Point(zapisek1.Left, zapisek2.Bottom + 10);
            zapisek3.Width = zapisek1.Width;
            zapisek3.Font = fontZapisek;

                        
            groupBoxTrenutnaPoraba.Controls.Add(textBoxOdTegaBarve);
            groupBoxTrenutnaPoraba.Controls.Add(labelOdTegaBarve);
            groupBoxTrenutnaPoraba.Controls.Add(textBoxOdTegaElox);
            groupBoxTrenutnaPoraba.Controls.Add(labelodTegaElox);
            groupBoxTrenutnaPoraba.Controls.Add(labelSkupnaPoraba);
            groupBoxSkupnaPoraba.Controls.Add(textBoxDelovneUre);
            groupBoxSkupnaPoraba.Controls.Add(labelDelovneUre);
            groupBoxSkupnaPoraba.Controls.Add(textBoxStevecPorabe);
            groupBoxSkupnaPoraba.Controls.Add(labelŠtevecPorabe);
            Controls.Add(zapiski);
            zapiski.Controls.Add(zapisek1Chk);
            zapiski.Controls.Add(zapisek1);
            zapiski.Controls.Add(zapisek2Chk);
            zapiski.Controls.Add(zapisek2);
            zapiski.Controls.Add(zapisek3Chk);
            zapiski.Controls.Add(zapisek3);


            groupBoxStatistika.Controls.Add(groupBoxTrenutnaPoraba);
            groupBoxStatistika.Controls.Add(groupBoxSkupnaPoraba);
            Controls.Add(groupBoxStatistika);
            Controls.Add(groupBoxUporabno);          
            groupBoxUporabno.Controls.Add(btnShowLogFolder);
            groupBoxUporabno.Controls.Add(btnShowSearchEngine);
            groupBoxUporabno.Controls.Add(btnUtisajAlarm);

            btnShowLogFolder.Click += BtnShowLogFolder_Click;
            btnShowSearchEngine.Click += BtnShowSearchEngine_Click;
            btnUtisajAlarm.Click += BtnUtisajAlarm_Click;

            Thread t = new Thread(new ThreadStart(DoStatistics))
            {
                Name = "StatisticsMonitor Thread",
                IsBackground = true
            };
            t.SetApartmentState(ApartmentState.MTA);
            t.Start();

            zapisek1Chk.CheckedChanged += ZapisekChk_CheckedChanged1;
            zapisek2Chk.CheckedChanged += ZapisekChk_CheckedChanged2;
            zapisek3Chk.CheckedChanged += ZapisekChk_CheckedChanged3;

        }

        private void BtnUtisajAlarm_Click(object sender, EventArgs e)
        {
            FormControl.bt1.Prop1.BuzzFromPC_Stop.SendPulse();
            groupBoxUporabno.Focus();
        }

        private void ZapisekChk_CheckedChanged1(object sender, EventArgs e)
        {
            if (zapisek1Chk.Checked)
            {
                zapisek1.Enabled = false;
            }
            else
            {
                zapisek1.Enabled = true;
            }
            
        }

        private void ZapisekChk_CheckedChanged2(object sender, EventArgs e)
        {
            if (zapisek2Chk.Checked)
            {
                zapisek2.Enabled = false;
            }
            else
            {
                zapisek2.Enabled = true;
            }
        }

        private void ZapisekChk_CheckedChanged3(object sender, EventArgs e)
        {
            if (zapisek3Chk.Checked)
            {
                zapisek3.Enabled = false;
            }
            else
            {
                zapisek3.Enabled = true;
            }

        }

        private void BtnShowSearchEngine_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("SearchEngineRunScript").Value.Replace(@"\\", @"\"));
            }
            catch (Exception ex)
            {
                FormControl.bt1.WL("Cant find script / batch file or path specified in XML File. entry \"SearchEnginRunScript\" does not exist or XML file is Corrupted. Error message folows: " + ex.Message, -1);
            }

        }

        private void BtnShowLogFolder_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("SarzaLogFolderPath").Value.Replace(@"\\", @"\"));
            }
            catch (Exception ex)
            {
                FormControl.bt1.WL("Cant find folder or path specified in XML File. entry \"SarzaLogFolderPath\" does not exist or XML file is Corrupted. Error message folows: " + ex.Message, -1);
            }

        }

        public void NestStat()
        {
            Width = Parent.Width - 30;
            Location = new Point(Parent.Left + 10, Parent.Bottom - Size.Height - 10);
            Size = new Size(Parent.Size.Width - 20, 139);
            this.groupBoxTrenutnaPoraba.Location = new Point(groupBoxStatistika.Left + 6, groupBoxStatistika.Top + 10);
            this.groupBoxSkupnaPoraba.Location = new Point(groupBoxStatistika.Left + 218, groupBoxStatistika.Top + 10);
            zapiski.Width = Width - zapiski.Left - 20;
            zapisek1.Width = zapiski.Width - 60;
            zapisek2.Width = zapisek1.Width;
            zapisek3.Width = zapisek1.Width;

        }

        private void DoStatistics()
        {
            TimeSpan onesec = TimeSpan.FromSeconds(1);
            DateTime dt1;
            int cnt = 0;
            TimeSpan hrcnt = TimeSpan.Zero;

            //
            MethodInvoker m = new MethodInvoker(delegate
            {
                SkupnaPoraba = FormControl.bt1.Prop1.EloxPoraba.Value + FormControl.bt1.Prop1.BarvePoraba.Value;

                if (FormControl.Form_gui[1] != null && FormControl.Form_gui[1].IsHandleCreated && FormControl.Form_gui[2] != null && FormControl.Form_gui[2].IsHandleCreated)
                {
                    textBoxSkupnaPoraba.Text = SkupnaPoraba + "W";
                    textBoxOdTegaBarve.Text = FormControl.bt1.Prop1.BarvePoraba.Value + "W";
                    textBoxOdTegaElox.Text = FormControl.bt1.Prop1.EloxPoraba.Value + "W";
                    PorabaJoule = PorabaJoule + SkupnaPoraba;
                    textBoxStevecPorabe.Text = ((PorabaJoule / 3600000).ToString("F1") + "kWh");
                }

                hrcnt += TimeSpan.FromSeconds(1);


                if (cnt >= 60)
                {
                    cnt = 1;
                    try
                    {
                        textBoxDelovneUre.Text = hrcnt.Hours.ToString("F1") + "h";

                        XML_handler.settingsXML.Element("root").Element("STATS").Element("kwhTotal").Value = textBoxStevecPorabe.Text.Replace("kWh", "");
                        XML_handler.settingsXML.Element("root").Element("STATS").Element("hTotal").Value = hrcnt.Hours.ToString();
                        XML_handler.SaveXML();

                    }
                    catch (Exception ex)
                    {
                        FormControl.bt1.WL("Error writing statistics to XML file. Retry after 3min. Error message folows: " + ex.Message, -1);
                        cnt = -120; // prevents too many attempts
                    }
                }
                else
                {
                    cnt++;
                }

            });


            try
            {
                // delovne ure
                var tmp = XML_handler.settingsXML.Element("root").Element("STATS").Element("hTotal").Value;
                hrcnt = TimeSpan.FromHours(double.Parse(tmp));
                textBoxDelovneUre.Text = hrcnt.TotalHours.ToString() + "h";

                // Skupna poraba                
                textBoxStevecPorabe.Text = XML_handler.settingsXML.Element("root").Element("STATS").Element("kwhTotal").Value;
                tmp = textBoxStevecPorabe.Text.Replace("kWh", "");
                PorabaJoule = float.Parse(tmp) * 3600000;
            }
            catch (Exception e)
            {
                FormControl.bt1.WL("Error reading statistics from XML file. " + e.Message, -1);
            }

            // loop
            while (true)
            {
                dt1 = DateTime.Now;

                try
                {
                    if (IsHandleCreated)
                    {
                        Invoke(m);
                    }                    
                }
                catch (Exception)
                {
                    throw;
                }

                while (DateTime.Now < dt1 + onesec)
                {
                    Thread.Sleep(15);
                }
            }

        }

    }
}
