using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Threading;

namespace KontrolaKadi
{
    public partial class Kad : Panel
    {
        public int TypeOfKad { get; set; }
        
        private Label labelShowname = new Label();

        public int GuiID = -1;
        public string Urgency = "none";

        public string Showname { get { return showname; } set { showname = value; labelShowname.Text = value; } }
        private string showname;

        public Color ControlsColor;       
        public Color ForegroundColor = Color.White;  // can change        
        public Color BackgroundColor { get; set; } // panel background color
                
        private SolidBrush DatagridBorderBrush;
        public SmartDatagrid Main_datagrid; // Main datagrid displayed inside menu
        private Rectangle Main_datagrid_rect;
        private Label Main_datagrid_Label;
        public SmartDatagrid Schedule_datagrid; // Schedule displayed inside menu
        private Rectangle Schedule_datagrid_rect;
        private Label Schedule_datagrid_Label;
        private SmartDatagrid Schedule_datagrid_Status;
        private Font Font15;

        public Datagrid Out_datagrid; // datagrid displayed on homescreen
        public GetValueForOutDatagrid valuesforOutDatagrid = new GetValueForOutDatagrid();

        private Pen Pen;
        private Brush Brush;
        private Font Font20;

        
        public Panel MotherPanel { get; set; }
        public Gui MotherForm { get; set; }
        public int ID { get; set; }
        public int BelongsToGUI_ID { get; set; }

        public Color NameColor_Enabled { get { return nameColor_Enabled; } set { nameColor_Enabled = value; GetTextColorDisabled(); NameColor = NameColor_Disabled; } } // set this on startup
        private Color nameColor_Enabled;
        public Color NameColor_Disabled { get; private set; } // calculated
        public Color NameColor { get; private set; } // use this trough out the program

       

        public Color KadColor_Enabled { get { return kadColor_Enabled; } set { kadColor_Enabled = value; GetBackColorDisabled(); } } // set this on startup
        private Color kadColor_Enabled;
        public Color KadColor_Disabled { get; private set; } // calculated
        public Color KadColor { get; private set; } // use this trough out the program

        private Label IDshow { get; set; }        
        private Button BtnBack { get; set; }
        private ColorDialog colorpicker;
        private Button BtnPickColor { get; set; }
                
        private static Bitmap KadDrawing = new Bitmap(Properties.Resources.Kad_konstrukcija);
        private int KadDrawing_X = 70;
        private int KadDrawing_Y = 90;

        public StopWatch stopWatch;

        public int WarningLevel = 0; // 0= no warnings  1= warning  2= error       
        public int MusslaufActive { get; set; } = 0; // 0= automatic mode  1= musslauf active / manual override
        public bool heaterActive = false;     

        DateTime now = new DateTime();
        DateTime target = new DateTime();

        public Thread WarningLevelAssessor;
        public bool hasSchedule;
        public bool hasStopwatch;
        public int hasChart;

        public bool isTimeEnabled = false;  // updates only with polling trough some methods
        public bool isEnabled = false;      // updates only with polling trough some methods


        public Kad(int ID, Gui Parent)
        {
            BelongsToGUI_ID = Parent.GuiID;

            List<Int16> checkbuff1 = new List<Int16>();
            Int16 buff;
            try
            {
                // check for XML consistency
                for (int i = 1; i < FormControl.Form_gui.Length; i++)
                {
                    buff = Convert.ToInt16(XML_handler.settingsXML.Element("root").Element("GUI" + i).Element("Kad" + ID).Element("TypeOf_Kad").Value);
                    checkbuff1.Add(buff);
                }

                checkbuff1.RemoveAll(x => x == -1); // removes all objects that are not be shown on this gui (just for checking) 
                if (checkbuff1.Count > 1)
                {
                    throw new Exception("Kad " + ID + " obstaja na več kot enem GUI-u. Prosim popravite XML datoteko da bo vrednost \"TypeOf_Kad\" nastavljena na -1 pri vseh razen na enem GUI-u.");
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Error has ocurded while checking if any object exists on two or more GUI's at the same time. Error message folows: " + ex.Message);
            }

            if (BelongsToGUI_ID == 0)
            {
                return;
            }
            this.ID = ID;
            this.MotherForm = Parent;
            this.BackColor = BackgroundColor;            

            try
            {
                hasSchedule = Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("GUI" + BelongsToGUI_ID).Element("Kad" + ID).Element("HasSchedule").Value); 
            }
            catch
            { hasSchedule = true; }

            try
            {
                hasStopwatch = Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("GUI" + BelongsToGUI_ID).Element("Kad" + ID).Element("HasStopwatch").Value); 
            }
            catch
            { hasStopwatch = true; }

            try
            {
                hasChart = Convert.ToInt16(XML_handler.settingsXML.Element("root").Element("GUI" + BelongsToGUI_ID).Element("Kad" + ID).Element("ChartType").Value); 
            }
            catch
            { hasChart = 0; }

            if (hasChart > 0)
            {
                InitialiseCharts();
            }

           
            Pen = new Pen(ControlsColor, 1F);
            Brush = new SolidBrush(ControlsColor);
            Font20 = new Font(FontFamily.GenericSansSerif, 20, (FontStyle.Bold));
                       
            labelShowname.TextAlign = ContentAlignment.MiddleCenter;
            labelShowname.Font = Font20;
            labelShowname.ForeColor = ForegroundColor;
            labelShowname.BackColor = Color.FromArgb(-16695460);
            labelShowname.Height = 64; // afeects other controls
            

            BtnBack = new Button
            {
                Text = "",
                BackColor = ControlsColor,
                Location = new Point(5, 5),
                Height = labelShowname.Height - 10
            };
            BtnBack.Width = BtnBack.Height;
            BtnBack.BackgroundImage = Properties.Resources.Back;
            BtnBack.BackgroundImageLayout = ImageLayout.Stretch;

            BtnPickColor = new Button
            {
                BackColor = ControlsColor,
                Width = 40
            };
            BtnPickColor.Height = BtnPickColor.Width;
            BtnPickColor.BackgroundImage = Properties.Resources.SelectColorIcon;
            BtnPickColor.BackColor = ControlsColor;
            BtnPickColor.BackgroundImageLayout = ImageLayout.Stretch;
                        
            colorpicker = new ColorDialog();
            KadColor = KadColor_Disabled;

            DatagridBorderBrush = new SolidBrush(labelShowname.BackColor);

            
            // in datagrid
            Font15 = new Font(FontFamily.GenericSansSerif, 15, (FontStyle.Bold));
            Main_datagrid = new SmartDatagrid(MotherForm, ID);
            Main_datagrid_rect = new Rectangle();
            Main_datagrid_Label = new Label() {Text = "Nastavitve", AutoSize = true , BackColor = Color.Transparent, ForeColor = labelShowname.ForeColor, Font = Font15};

            if (hasSchedule)
            {
                Schedule_datagrid = new SmartDatagrid(MotherForm, ID);
                Schedule_datagrid_rect = new Rectangle();
                Schedule_datagrid_Label = new Label() { Text = "Urnik", AutoSize = true, BackColor = Color.Transparent, ForeColor = labelShowname.ForeColor, Font = Font15 };
                Schedule_datagrid_Status = new SmartDatagrid(MotherForm, ID);

            }

            // Custom content

            try
            {
                AddRowsToMainDatagrid(Main_datagrid, ID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error has ocurded while adding rows to datagrid (Main_datagrid / ID: " + ID + " ). Error could be result of improper settings in XML file. Please make sure that same objects are not part of multiple GUI's. Error message follows: " + ex.Message);                
            }

            try
            {AddRowsToScheduleDatagrid(Schedule_datagrid, Schedule_datagrid_Status, ID);}
            catch (Exception ex)
            {
                throw new Exception("Error has ocurded while adding rows to datagrid (Schedule_datagrid / ID: "+ ID +" ). Error could be result of improper settings in XML file. Please make sure that same objects are not part of multiple GUI's. Error message follows: " + ex.Message);
            }

            

            Controls.Add(IDshow);
            Controls.Add(BtnBack);
            Controls.Add(BtnPickColor);
            Controls.Add(labelShowname);
            Controls.Add(Main_datagrid);
            Controls.Add(Main_datagrid_Label);

            if (hasSchedule)
            {
                Controls.Add(Schedule_datagrid);
                Controls.Add(Schedule_datagrid_Status);
                Controls.Add(Schedule_datagrid_Label);
            }


            this.Height = MotherForm.Height;
            this.Width = MotherForm.Width;
            BtnBack.Click += new EventHandler(BackClicked);
            BtnPickColor.Click += new EventHandler(ColorPickerClicked);
            MotherForm.Resize += new EventHandler(OnResize);
                        
            this.VisibleChanged += new EventHandler(RedrawEvent);

            this.SetStyle(ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
                                  

            WarningLevelAssessor = new Thread(new ThreadStart(WarningLevelAssessor_DoWork))
            {
                Name = "WarningLevelAssessor Thread",
                IsBackground = true
            };
            WarningLevelAssessor.Start();
                        
            this.Paint += Redraw;           

            if (hasStopwatch)
            {
                stopWatch = new StopWatch(ID, MotherForm);
            }                       

            MotherForm.Load += MotherForm_Load;

            this.Click += Kad_Click;

        }

        private void Kad_Click(object sender, EventArgs e)
        {
            var ev = (MouseEventArgs)e;
            if (ev.Button == MouseButtons.Right)
            {
                BackClicked(null, null);
            }
        }

        private void MotherForm_Load(object sender, EventArgs e)
        {
            // Load values to comboboxes after Load
            selectValueForCB();

            cb_chartX_rangeMin.SelectedIndexChanged += Cb_chartX_rangeMin_SelectedIndexChanged;
            cb_chartX_rangeMax.SelectedIndexChanged += Cb_chartX_rangeMax_SelectedIndexChanged;

            chartArea1.AxisY.Maximum = Convert.ToInt32(cb_chartX_rangeMax.SelectedValue);
            chartArea1.AxisY.Minimum = Convert.ToInt32(cb_chartX_rangeMin.SelectedValue);
        }

        void selectValueForCB()
        {
            try
            {
                for (int i = 0; i < cb_chartX_rangeMin.Items.Count; i++)
                {
                    if (cb_chartX_rangeMin.Items[i].ToString() == XML_handler.settingsXML.Element("root").Element("GUI" + BelongsToGUI_ID).Element("Kad" + ID).Element("ChartYfrom").Value)
                    {
                        cb_chartX_rangeMin.SelectedIndex = i;
                    }
                }
            }
            catch
            { cb_chartX_rangeMin.SelectedText = "0"; }

            try
            {
                for (int i = 0; i < cb_chartX_rangeMax.Items.Count; i++)
                {
                    if (cb_chartX_rangeMax.Items[i].ToString() == XML_handler.settingsXML.Element("root").Element("GUI" + BelongsToGUI_ID).Element("Kad" + ID).Element("ChartYto").Value)
                    {
                        cb_chartX_rangeMax.SelectedIndex = i;
                    }
                }
            }
            catch
            { cb_chartX_rangeMax.SelectedText = "70"; }
        }

        private void GetBackColorDisabled() // Changes Kad Color
        {
            
            double f;
            double L;
            double r = KadColor_Enabled.R;
            double g = KadColor_Enabled.G;
            double b = KadColor_Enabled.B;
            double a = KadColor_Enabled.A;
            double new_r;
            double new_g;
            double new_b;
            double new_a;

            
                f = 0.5; // desaturate by 
                L = 0.3 * r + 0.6 * g + 0.1 * b;               
                new_r = r + f * (L - r);
                new_g = g + f * (L - g);
                new_b = b + f * (L - b);
                new_a = a * 0.7;

            KadColor_Disabled = Color.FromArgb(Misc.ToInt(new_a) , Misc.ToInt(new_r), Misc.ToInt(new_g), Misc.ToInt(new_b));

        }

        private void GetTextColorDisabled() // Changes Kad Text Color
        {

            double f;
            double L;
            double r = NameColor_Enabled.R;
            double g = NameColor_Enabled.G;
            double b = NameColor_Enabled.B;
            double a = NameColor_Enabled.A;
            double new_r;
            double new_g;
            double new_b;
            double new_a;


            f = 0.5; // desaturate by 
            L = 0.3 * r + 0.6 * g + 0.1 * b;
            new_r = r + f * (L - r);
            new_g = g + f * (L - g);
            new_b = b + f * (L - b);
            new_a = a * 0.7;

            NameColor_Disabled = Color.FromArgb(Misc.ToInt(new_a), Misc.ToInt(new_r), Misc.ToInt(new_g), Misc.ToInt(new_b));

        }

        private void WarningLevelAssessor_DoWork()
        {
            bool buff = false;
            while (true)
            {
                try
                {
                    // show warning if ...
                    if (stopWatch != null)
                    {
                        buff = GetThisAlarm(ID);
                        
                        if (buff)
                        {
                            WarningLevel = 2;
                        }
                        else if (stopWatch.AlertState == true && buff == false)
                        {
                            WarningLevel = 1;
                        }
                        else if (stopWatch.AlertState == false && buff == false)
                        {
                            WarningLevel = 0;
                        }

                        // Musslauf
                        if (GetThisMusslauf(ID))
                        {
                            MusslaufActive = 1;
                        }
                        else
                        {
                            MusslaufActive = 0;
                        }
                                               

                    }
                    
                    Thread.Sleep(100);
                }
                catch 
                {
                    Thread.Sleep(1000);
                }
                
            }
        }

        public bool GetThisEnabled()
        {
           
            short buff;
            switch (this.ID)
            {
                case 1: buff = FormControl.bt1.Prop1.EN_Kad1.Value; break;
                case 2: buff = FormControl.bt1.Prop1.EN_Kad2.Value; break;
                case 3: buff = FormControl.bt1.Prop1.EN_Kad3.Value; break; 
                case 4: buff = FormControl.bt1.Prop1.EN_Kad4.Value; break;
                case 5: buff = FormControl.bt1.Prop1.EN_Kad5.Value; break;
                case 6: buff = FormControl.bt1.Prop1.EN_Kad6.Value; break;
                case 7: buff = FormControl.bt1.Prop1.EN_Kad7.Value; break;
                case 8: buff = FormControl.bt1.Prop1.EN_Kad8.Value; break; 
                case 9: buff = FormControl.bt1.Prop1.EN_Kad9.Value; break;
                case 10: buff = FormControl.bt1.Prop1.EN_Kad10.Value; break; 
                case 11: buff = FormControl.bt1.Prop1.EN_Kad11.Value; break;
                case 12: buff = FormControl.bt1.Prop1.EN_Kad12.Value; break;
                case 13: buff = FormControl.bt1.Prop1.EN_Kad13.Value; break;
                case 14: buff = FormControl.bt1.Prop1.EN_Kad14.Value; break;
                case 15: buff = FormControl.bt1.Prop1.EN_Kad15.Value; break;
                case 16: buff = FormControl.bt1.Prop1.EN_Kad16.Value; break;
                case 17: buff = FormControl.bt1.Prop1.EN_Kad17.Value; break;
                case 18: buff = FormControl.bt1.Prop1.EN_Kad18.Value; break;
                case 19: buff = FormControl.bt1.Prop1.EN_Kad19.Value; break;
                default:
                    FormControl.bt1.WL("Switch Statement does not support this ID. Message source: getThisEnabled() method", -1);
                    return false;                                        
            }

            if (MotherForm.btnStarted.StartedStatus != (int)StartedButton.StatedStatus.Started)
            {
                buff = 0;
            }

            if (buff > 0)
            {                
                isEnabled = true;
            }
            else
            {
                isEnabled = false;
            }
            DecideAndSetStateColor();
            return isEnabled;
        }

        public bool GetThisTimeEnabled(bool setColors)
        {
            bool buff;

            switch (ID)
            {
                case 1: buff = FormControl.bt1.Prop2.Urniki_CikelAktiven1.Value; break;
                case 2: buff = FormControl.bt1.Prop2.Urniki_CikelAktiven2.Value; break;
                case 3: buff = true; break;
                case 4: buff = true; break;
                case 5: buff = true; break;
                case 6: buff = FormControl.bt1.Prop3.Urniki_CikelAktiven6.Value; break;
                case 7: buff = FormControl.bt1.Prop4.Urniki_CikelAktiven7.Value; break;
                case 8: buff = true; break;
                case 9: buff = FormControl.bt1.Prop5.Urniki_CikelAktiven9.Value; break;
                case 10: buff = true; break;
                case 11: buff = FormControl.bt1.Prop8.Urniki_CikelAktiven11.Value; break;
                case 12: buff = FormControl.bt1.Prop6.Urniki_CikelAktiven12.Value; break;
                case 13: buff = true; break;
                case 14: buff = FormControl.bt1.Prop6.Urniki_CikelAktiven14.Value; break;
                case 15: buff = FormControl.bt1.Prop7.Urniki_CikelAktiven15.Value; break;
                case 16: buff = true; break;
                case 17: buff = FormControl.bt1.Prop7.Urniki_CikelAktiven17.Value; break;
                case 18: buff = true; break;
                case 19: buff = FormControl.bt1.Prop8.Urniki_CikelAktiven19.Value; break;
                default:
                    FormControl.bt1.WL("Switch Statement does not support this ID. Message source: getThisEnabled() method", -1);
                    return false;
            }


            if (buff)
            {
                if (setColors)
                {
                    isTimeEnabled = true;
                    DecideAndSetStateColor();
                }
                return true;
            }
            else
            {
                if (setColors)
                {
                    isTimeEnabled = false;
                    DecideAndSetStateColor();
                }
                return false;
            }            

        }

        public void DecideAndSetStateColor()
        {
            if (isTimeEnabled && isEnabled)
            {
                KadColor = KadColor_Enabled;                
            }
            else
            {
                KadColor = KadColor_Disabled;                
            }
        }

        private static bool GetThisAlarm(int KadID)
        {

            switch (KadID)
            {
                case 1: return FormControl.bt1.Prop2.ALARM_Any_1; 
                case 2: return FormControl.bt1.Prop2.ALARM_Any_2;
                case 3: return FormControl.bt1.Prop2.ALARM_Any_3;
                case 4: return FormControl.bt1.Prop2.ALARM_Any_4;
                case 5: return FormControl.bt1.Prop2.ALARM_Any_5;
                case 6: return FormControl.bt1.Prop3.ALARM_Any_6;
                case 7: return FormControl.bt1.Prop4.ALARM_Any_7;
                case 8: return FormControl.bt1.Prop4.ALARM_Any_8;
                case 9: return FormControl.bt1.Prop5.ALARM_Any_9;
                case 10: return FormControl.bt1.Prop6.ALARM_Any_10;
                case 11: return FormControl.bt1.Prop8.ALARM_Any_11;
                case 12: return FormControl.bt1.Prop6.ALARM_Any_12;
                case 13: return FormControl.bt1.Prop6.ALARM_Any_13;
                case 14: return FormControl.bt1.Prop6.ALARM_Any_14;
                case 15: return FormControl.bt1.Prop7.ALARM_Any_15;
                case 16: return FormControl.bt1.Prop7.ALARM_Any_16;
                case 17: return FormControl.bt1.Prop7.ALARM_Any_17;
                case 18: return FormControl.bt1.Prop7.ALARM_Any_18;
                case 19: return FormControl.bt1.Prop8.ALARM_Any_19;                
                default: FormControl.bt1.WL("Switch Statement does not support this ID. Message source: getThisAlarm() method", -1);
                    return false;
            }
        }

        private static bool GetThisMusslauf(int KadID)
        {

            switch (KadID)
            {
                case 1: return FormControl.bt1.Prop2.MUSS_Any_1;
                case 2: return FormControl.bt1.Prop2.MUSS_Any_2;
                case 3: return FormControl.bt1.Prop2.MUSS_Any_3;
                case 4: return FormControl.bt1.Prop2.MUSS_Any_4;
                case 5: return FormControl.bt1.Prop2.MUSS_Any_5;
                case 6: return FormControl.bt1.Prop3.MUSS_Any_6;
                case 7: return FormControl.bt1.Prop4.MUSS_Any_7;
                case 8: return FormControl.bt1.Prop4.MUSS_Any_8;
                case 9: return FormControl.bt1.Prop5.MUSS_Any_9;
                case 10: return FormControl.bt1.Prop6.MUSS_Any_10;
                case 11: return FormControl.bt1.Prop8.MUSS_Any_11;
                case 12: return FormControl.bt1.Prop6.MUSS_Any_12;
                case 13: return FormControl.bt1.Prop6.MUSS_Any_13;
                case 14: return FormControl.bt1.Prop6.MUSS_Any_14;
                case 15: return FormControl.bt1.Prop7.MUSS_Any_15;
                case 16: return FormControl.bt1.Prop7.MUSS_Any_16;
                case 17: return FormControl.bt1.Prop7.MUSS_Any_17;
                case 18: return FormControl.bt1.Prop7.MUSS_Any_18;
                case 19: return FormControl.bt1.Prop8.MUSS_Any_19;
                default:
                    FormControl.bt1.WL("Switch Statement does not support this ID. Message source: getThisMusslauf() method", -1);
                    return false;
            }
        }

        public bool GetThisHeaterActive()
        {           
            switch (ID)
            {
                case 1: return FormControl.bt1.Prop2.DelovanjeGrelca1.Value;
                case 2: return FormControl.bt1.Prop2.DelovanjeGrelca2.Value;
                case 3: return false;
                case 4: return false;
                case 5: return false;
                case 6: return false;
                case 7: return FormControl.bt1.Prop4.DelovanjeGrelca7.Value;
                case 8: return false;
                case 9: return false;
                case 10: return false;
                case 11: return FormControl.bt1.Prop8.DelovanjeGrelca11.Value;
                case 12: return FormControl.bt1.Prop6.DelovanjeGrelca12.Value;
                case 13: return false;
                case 14: return FormControl.bt1.Prop6.DelovanjeGrelca14.Value;
                case 15: return FormControl.bt1.Prop7.DelovanjeGrelca15.Value;
                case 16: return false;
                case 17: return FormControl.bt1.Prop7.DelovanjeGrelca17.Value;
                case 18: return false;
                case 19: return FormControl.bt1.Prop8.DelovanjeGrelca19.Value;                
                default:
                    FormControl.bt1.WL("Switch Statement does not support this ID. Message source: GetThisHeaterActive() method", -1);
                    return false;
            }
        }

        public bool GetThisWaterLevelWarning()
        {
            switch (ID)
            {
                case 1: return !FormControl.bt1.Prop2.Nivo1.Value;
                case 2: return !FormControl.bt1.Prop2.Nivo2.Value;
                case 3: return false;
                case 4: return false;
                case 5: return false;
                case 6: return false;
                case 7: return !FormControl.bt1.Prop4.Nivo7.Value;
                case 8: return false;
                case 9: return false;
                case 10: return false;
                case 11: return !FormControl.bt1.Prop8.Nivo11.Value;
                case 12: return !FormControl.bt1.Prop6.Nivo12.Value;
                case 13: return false;
                case 14: return !FormControl.bt1.Prop6.Nivo14.Value;
                case 15: return !FormControl.bt1.Prop7.Nivo15.Value;
                case 16: return false;
                case 17: return !FormControl.bt1.Prop7.Nivo17.Value;
                case 18: return false;
                case 19: return !FormControl.bt1.Prop8.Nivo19.Value;
                default:
                    FormControl.bt1.WL("Switch Statement does not support this ID. Message source: GetThisHeaterActive() method", -1);
                    return false;
            }
        }

        private void Redraw(object sender, PaintEventArgs e)
        {
            this.Height = MotherForm.Height;
            this.Width = MotherForm.Width;
            
            BtnPickColor.Location = new Point(this.Right - BtnPickColor.Width -20, 5);
            
            labelShowname.Top = this.Top;
            labelShowname.Left = this.Left;
            labelShowname.Width = this.Width;            
            
            float width = PaintKad(e, 400, KadDrawing_X, KadDrawing_Y, KadColor);

            PaintDatagrids(e, KadDrawing_X + width + 100, KadDrawing_Y + 30, 15);

            if (hasChart > 0)
            {
                ChartOfTemperature.Size = new Size(this.Width, 350);

                cbChartRange.Location = new Point(10,10);
                

                cb_chartX_rangeMin.Location = new Point(70,40);
                cb_chartX_rangeMin.Width = cbChartRange.Width - 60;
                lbl_chartX_rangeMin.Location = new Point(10, 45);

                cb_chartX_rangeMax.Location = new Point(70,70);
                cb_chartX_rangeMax.Width = cbChartRange.Width - 60;
                lbl_chartX_rangeMax.Location = new Point(10, 75);

                gbChartControls.BringToFront();
                
            }

            
        }
        private void RedrawEvent(object sender, EventArgs e)
        {
           
                MotherForm.UpdateGui();
            

        }
        private void OnResize(object sender, EventArgs e)
        {
           
                MotherForm.UpdateGui();
                                   
        }

        private static float PaintKad(PaintEventArgs e, float height, float X, float Y, Color color)
        {            
            SolidBrush brush = new SolidBrush(color);

            // set dimensions for picture
            float _SubContainerHeight = (height);
            float _SubContainerY_location = Y + (50);
            float _SubContainerWidth = (height) * (0.5F);
            float _SubContainerX_location = X + (1);

            e.Graphics.DrawImage(KadDrawing, X, Y, _SubContainerWidth, _SubContainerHeight);

            // set dimensions for colored rectangle inside picture
            _SubContainerHeight = (height * 0.75F);
             _SubContainerY_location = Y + (90);
             _SubContainerWidth = (height) * (0.38F);
             _SubContainerX_location = X + (24);

            Rectangle _RectBorders = new Rectangle(Misc.ToInt(_SubContainerX_location), Misc.ToInt(_SubContainerY_location), Misc.ToInt(_SubContainerWidth), Misc.ToInt(_SubContainerHeight));
            e.Graphics.FillRectangle(brush, _RectBorders);
            
           
            return _SubContainerWidth;
        }
        

        //----------------------------------------------------------------------------
        // Events
        //----------------------------------------------------------------------------

        private void BackClicked(object sender, EventArgs e)
        {            
            this.Visible = false;
            MotherPanel.Visible = true;            
            MotherPanel.Focus();
            MotherForm.UpdateGui();
        }

        
        private void ColorPickerClicked(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Now you will choose back color. Click cancel to keep current color.");
                if (colorpicker.ShowDialog() == DialogResult.OK)
                {    
                    MotherForm.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + ID).Element("KadColor").Value = colorpicker.Color.ToArgb().ToString();
                    XML_handler.SaveXML();
                    KadColor_Enabled = colorpicker.Color;
                }

                MessageBox.Show("Now you will choose text color. Click cancel to keep current color.");
                if (colorpicker.ShowDialog() == DialogResult.OK)
                {       
                    MotherForm.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + ID).Element("NameColor").Value = colorpicker.Color.ToArgb().ToString();
                    XML_handler.SaveXML();
                    NameColor_Enabled = colorpicker.Color;                    
                }
                MotherForm.UpdateGui();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during color change or save: " + ex.Message);
            }

           
        }



    }
}
