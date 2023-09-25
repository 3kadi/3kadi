using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;


namespace KontrolaKadi
{

    // Dinamical graphics only
    public partial class Gui : Form
    {


        DateTime d2;           
        public bool resizeNeeded = true;

        public int GuiID { get; private set; }
        public FormControl FormControl { get; set; }
        public Rectangle rectTop; // only for color separation on top of the form
        public Color rectTopColor = Color.FromArgb(-16695460);
        private SolidBrush rectTopBrush;

        bool GuiDisabled_NoConnection;
        public PanelStat panelStat;
        private Rectangle InvalidationRect;

        //settings
        
        public Color controlsColor = Color.LightGray;
        XElement settings;
        public Kad[] kadi = new Kad[21];

        Button btnSettings = new Button();
        Button btnLogedInAs = new Button();
        Button btnLogoff = new Button();
        Button btnSwitchGui = new Button();

        public XDocument settingsXML;
        public int StKadi;
        public int MaxHeightKad;
        public float RatioKad;
        public float RatioPause;

        // init 
        public MyPanel panel = new MyPanel();

        int varsSizePX = 30;
        Font varsFont = new Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold);

        Rectangle _PanelBorders;
        Rectangle[] _Containers = new Rectangle[21];
        bool[] _bordered = new bool[21];
        bool[] _bordered2 = new bool[21];

        int _ContainerHeight;
        int _ContainerHeightOffset;
        int _ContainerHeightOffset2;
        int fromPaneltoElavator;
        float _ALLContainersWidth;
        float[] _ContainerWidth = new float[21];
        float _ContainerPause;

        float[] _WidthMultiplyer = new float[21];
        float[] _newStart = new float[21];
        float _paintXoffset = 90;

        Brush[] _RectBrush = new Brush[21];
        Rectangle[] _RectBorders = new Rectangle[21];
        Rectangle[] SarzaBorders = new Rectangle[21];
        float[] _SubContainerHeight = new float[21];
        float[] _SubContainerX_location = new float[21];
        float[] _SubContainerHeightOffset = new float[21];
        float[] _SubContainerWidth = new float[21];
        float[] _SubContainerY_location = new float[21];


        Brush _UnderlineBrush;
        Rectangle _UnderlineRect;
        float _UnderTitleRect_X;
        float _UnderTitleRect_Y;
        float _UnderTitleRect_W;
        float _UnderTitleRect_H;

        Point topOfGrapics;
        Rectangle bottNumGraphicRect;
        StringFormat sf = new StringFormat();
        Brush[] NameBrush = new Brush[21];

        Pen borderFormPen = Pens.Black; // only for debug graphics
        Pen HoverborderFormPen;
        Pen HoverborderFormPen1 = new Pen(Brushes.Blue, 1);
        Pen HoverborderFormPen2 = Pens.Transparent;

        Pen borderKadPen = Pens.Black;
        private int SUMOFRatioPauses;
        Bitmap KadKonstrukcija = new Bitmap(Properties.Resources.Kad_konstrukcija);
        Bitmap KadKonstrukcijaPosirjena = new Bitmap(Properties.Resources.Kad_konstrukcija_Posirjena);
        Bitmap KadKonstrukcijaDvojnaL = new Bitmap(Properties.Resources.Kad_konstrukcija_dvojna_L);
        Bitmap KadKonstrukcijaDvojnaR = new Bitmap(Properties.Resources.Kad_konstrukcija_dvojna_R);

        Rectangle elavator;
        bool paintElavator;
        int elavatorHorizontalProgress;

        Point[] centers = new Point[21];

        private static Bitmap warningIcon = Properties.Resources.warning_icon_24;
        private static Bitmap errorIcon = Properties.Resources.warning_icon_png_1;
        private static Bitmap MussIcon = Properties.Resources.manual_ctrl;
        private static Bitmap TimeDisabledIcon = Properties.Resources.SYTK_ura;
        private static Bitmap HeaterActiveIcon = Properties.Resources.SYTK_grelec;
        private static Bitmap WaterLevelIcon = Properties.Resources.SYTK_R_nivo;

        public ConnectedButton[] btnConnected = new ConnectedButton[21];
        public StartedButton btnStarted;
        Font[] font = new Font[21];
        public static Font fontClock = new Font(FontFamily.GenericSansSerif, 28, FontStyle.Bold);
        Rectangle[] rectConnName = new Rectangle[21];

        private Label ClockShow = new Label()
        {
            Location = new Point(300, 11),
            Font = fontClock,
            Size = new Size(200, 50),
            Text = PropComm.NA,
            ForeColor = Color.WhiteSmoke
        };

        int topcontrolsHeight = 44;
        int topcontrolsFromTop = 10;
        int topcontrolsSpacing = 10;

        Brush blackBrush = Brushes.Black;
        Pen blackPen;
        Point tmpCenter = new Point();
        Rectangle _UnderlineRectString1;
        public Rectangle[] _UnderlineRectString2 = new Rectangle[21];
        SolidBrush IDshowBrush_Enabled = new SolidBrush(Color.FromArgb(-13446866)); // enabled
        SolidBrush IDshowBrush_Disabled = new SolidBrush(Color.FromArgb(-2030588)); // disabled
        SolidBrush IDshowBrush_TimeDisabled = new SolidBrush(Color.FromArgb(-2971116)); // disabled
        SolidBrush IDshowBrush_Enabled_hvr;
        SolidBrush IDshowBrush_Disabled_hvr;
        SolidBrush IDshowBrush_TimeDisabled_hvr;
        Pen IDshowBrush_Border;

        public static int refreshOriginalVal; // gui refreshrate  only for some elements

        int previousObjectLeft; // button positioning help
        int skipPause;
        float dif;
        float sumOfWidthMultipliers;

        Rectangle elavatorRect;
        Brush elevatorBrush = Brushes.Black;
        Pen elevatorPen;
        float xElavator;
        Rectangle warnRect = new Rectangle();
        Rectangle mussRect = new Rectangle();
        Rectangle[] HeaterRect = new Rectangle[21];
        Rectangle[] WaterLevelRect = new Rectangle[21];
        Rectangle[] TimeDisabledRect = new Rectangle[21];

        Point start;
        Point end;

        public SmartDatagrid MaxConsumptionGUI1;
        public SmartDatagrid MaxConsumptionGUI2;

        MainsVoltageError MainsErr;

        public Gui(XDocument settingsXML, int ID)
        {            
            GuiID = ID;
            this.Icon = Properties.Resources.oa;

            rectTop = new Rectangle();
            rectTopBrush = new SolidBrush(rectTopColor);
            rectTop.Height = 65; // afeects other controls

            ClockShow.BackColor = rectTopColor;

            blackPen = new Pen(blackBrush, 3);

            MaxConsumptionGUI1 = new SmartDatagrid(this, 200);
            MaxConsumptionGUI1.Width = MaxConsumptionGUI1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + MaxConsumptionGUI1.RowTemplate.DividerHeight * (MaxConsumptionGUI1.ColumnCount + 1) + 4;
            MaxConsumptionGUI1.Height = (MaxConsumptionGUI1.Rows.GetRowCount(DataGridViewElementStates.None)) * MaxConsumptionGUI1.RowTemplate.Height + MaxConsumptionGUI1.Rows.GetRowCount(DataGridViewElementStates.None) * MaxConsumptionGUI1.RowTemplate.DividerHeight + 2 + MaxConsumptionGUI1.ColumnHeadersHeight;


            MaxConsumptionGUI2 = new SmartDatagrid(this, 200);
            MaxConsumptionGUI2.Width = MaxConsumptionGUI2.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + MaxConsumptionGUI2.RowTemplate.DividerHeight * (MaxConsumptionGUI2.ColumnCount + 1) + 4;
            MaxConsumptionGUI2.Height = (MaxConsumptionGUI2.Rows.GetRowCount(DataGridViewElementStates.None)) * MaxConsumptionGUI2.RowTemplate.Height + MaxConsumptionGUI2.Rows.GetRowCount(DataGridViewElementStates.None) * MaxConsumptionGUI2.RowTemplate.DividerHeight + 2 + MaxConsumptionGUI2.ColumnHeadersHeight;

            MaxConsumptionGUI1.Location = new Point(rectTop.X + 80, rectTop.Y + 11);
            MaxConsumptionGUI2.Location = new Point(rectTop.X + 80, rectTop.Y + 11);

            MainsErr = new MainsVoltageError(this);

            if (GuiID == 1)
            {
                FormControl.bt1.Prop1.DatagridRowsInMenuGUI1(MaxConsumptionGUI1);
                Controls.Add(MaxConsumptionGUI1);
                Controls.Add(ClockShow);
                Controls.Add(MainsErr);
            }

            if (GuiID == 2)
            {
                FormControl.bt1.Prop1.DatagridRowsInMenuGUI2(MaxConsumptionGUI2);
                Controls.Add(MaxConsumptionGUI2);
                Controls.Add(ClockShow);
                Controls.Add(MainsErr);
            }


            try
            {
                this.settingsXML = settingsXML;
                FormControl.identify.settingsXML = settingsXML;
            }

            catch (Exception e)
            {
                MessageBox.Show("Error while loading Xml file. Chech that file is valid. Application will now close." + Environment.NewLine + Environment.NewLine + e.Message);
                Environment.Exit(0);
            }

            elavatorHorizontalProgress = 0;

            MinimumSize = new Size(700, 500);

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            topOfGrapics = new Point();
            bottNumGraphicRect = new Rectangle();

            try
            {
                Text = Application.ProductName + "(" +
                    XML_handler.settingsXML.Element("root").Element("GUI" + GuiID).Element("GuiName").Value +
                    ")";
            }
            catch
            {
                Text = Application.ProductName + "(" +
                    "GUI" +
                    ")";
            }


            try
            {
                settings = settingsXML.Element("root").Element("GUI" + GuiID);



                // S E T T I N G S 

                MaxHeightKad = int.Parse(settings.Element("MaxHeightKad").Value.Replace("\"", ""));     // največja dovoljena višina
                RatioKad = 1.7F;       // razmerje višina širina
                RatioPause = float.Parse(settings.Element("RatioPause").Value.Replace("\"", "")) / 100F; // širina presledka do naslednje kadi reletivna na višino kadi
                _UnderlineBrush = Brushes.LightGray;
                refreshOriginalVal = int.Parse(settingsXML.Element("root").Element("GENERAL").Element("GUIrefreshrate").Value);

                paintElavator = bool.Parse(settings.Element("paintElavator").Value.Replace("\"", ""));
                //panel.BackColor = Color.FromArgb(int.Parse(settings.Element("GuiBackgroundColor").Value.Replace("\"", "")));
                panel.BackgroundImage = FormControl.backgrndImage;
                panel.BackgroundImageLayout = ImageLayout.Stretch;
                
                Int16 buff;
                int cnt = 1;
                for (int i = 1; i < kadi.Length; i++)
                {
                    buff = Convert.ToInt16(XML_handler.settingsXML.Element("root").Element("GUI" + GuiID).Element("Kad" + i).Element("TypeOf_Kad").Value);
                    if (buff > -1)
                    {
                        kadi[cnt] = new Kad(i, this);                        
                        _WidthMultiplyer[cnt] = float.Parse(settings.Element("Kad" + i).Element("WidthMultiplyer").Value) / 100;
                        kadi[cnt].TypeOfKad = int.Parse(settings.Element("Kad" + i).Element("TypeOf_Kad").Value);
                        kadi[cnt].KadColor_Enabled = Color.FromArgb(int.Parse(settings.Element("Kad" + i).Element("KadColor").Value));
                        kadi[cnt].NameColor_Enabled = Color.FromArgb(int.Parse(settings.Element("Kad" + i).Element("NameColor").Value));
                        kadi[cnt].Showname = settings.Element("Kad" + i).Element("Name").Value;
                        kadi[cnt].BackColor = panel.BackColor;
                        kadi[cnt].BackgroundImage = FormControl.backgrndImage;
                        kadi[cnt].BackgroundImageLayout = ImageLayout.Stretch;
                        kadi[cnt].GuiID = GuiID;
                        kadi[cnt].Urgency = settings.Element("Kad" + i).Element("EndOfTimeSignaling").Value;
                        _bordered[cnt] = false;
                        _bordered2[cnt] = false;
                        cnt++;
                    }
                }
                StKadi = cnt - 1;


                for (int i = 1; i < StKadi + 1; i++)
                {
                    kadi[i].MotherForm = this;

                    try
                    {
                        InitializeDatagrid(kadi[i]);

                        if (kadi[i].hasStopwatch)
                        {
                            kadi[i].stopWatch.Top = kadi[i].Out_datagrid.Bottom + 20;
                            kadi[i].stopWatch.Left = kadi[i].Out_datagrid.Left;
                            panel.Controls.Add(kadi[i].stopWatch);
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error have ocurded while adding elements to Datagrid on position " + i + ": " + ex.Message + Environment.NewLine + "Application will now close!");
                        Environment.Exit(0);
                    }
                }


                // END S E T T I N G S 


                InitializeComponent();


                for (int i = 1; i < StKadi + 1; i++)
                {
                    Controls.Add(kadi[i]);
                    kadi[i].MotherPanel = panel;
                    kadi[i].Visible = false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error have ocurded while trying to retrieve some critical settings from XML file while initialising GUI Form: " + ex.Message + Environment.NewLine + "Application will now close!");
                Environment.Exit(0);

            }

            // S E T T I N G S  - non critical


            try
            {
                panel.Resize += Panel_Resize;
                panel.Paint += Panel_Paint;
                             
                panel.MouseClick += new MouseEventHandler(OnMouseClick);
                panel.MouseMove += new MouseEventHandler(OnMouseHover);

                btnSettings.Height = topcontrolsHeight;
                btnSettings.BackColor = Button.DefaultBackColor;
                btnSettings.Text = "Settings";
                this.btnSettings.Click += this.Button1_Click_1;

                btnLogoff.BackColor = Button.DefaultBackColor;
                btnLogoff.Height = topcontrolsHeight;
                btnLogoff.Width = 100;
                btnLogoff.Text = "Logoff";
                this.btnLogoff.Click += this.ButtonLogoff;

                btnSwitchGui.BackColor = Button.DefaultBackColor;
                btnSwitchGui.Height = topcontrolsHeight;
                btnSwitchGui.Width = 100;
                btnSwitchGui.Text = "Menjaj ekran";
                this.btnSwitchGui.Click += BtnSwitchGui_Click;

                btnLogedInAs.BackColor = Button.DefaultBackColor;
                btnLogedInAs.Height = topcontrolsHeight;
                btnLogedInAs.Width = 250;
                this.btnLogedInAs.Click += this.ButtonLogin;

                IDshowBrush_Enabled_hvr = new SolidBrush(Misc.ColorBrightener(IDshowBrush_Enabled.Color, 1.5m, 1.5m, 1.5m)); // enabled hovered
                IDshowBrush_Disabled_hvr = new SolidBrush(Misc.ColorBrightener(IDshowBrush_Disabled.Color, 1.5m, 1.5m, 1.5m)); // disabled hovered
                IDshowBrush_TimeDisabled_hvr = new SolidBrush(Misc.ColorBrightener(IDshowBrush_TimeDisabled.Color, 1.2m, 1.3m, 1.3m)); // Time disabled hovered

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error have ocurded while trying to retrieve non critical settings from XML file after initialising GUI Form: " + ex.Message + Environment.NewLine + "Application will now close!");
                Environment.Exit(0);
            }


            try
            {
                var cnt = 0;

                for (int i = 1; i < btnConnected.Length; i++)
                {
                    if (Convert.ToBoolean(settingsXML.Element("root").Element("LOGO" + i).Element("enabled").Value))
                    {
                        cnt++;
                    }
                }


                if (cnt > 0)
                {
                    for (int i = 1; i < btnConnected.Length; i++)
                    {
                        if (Convert.ToBoolean(settingsXML.Element("root").Element("LOGO" + i).Element("enabled").Value))
                        {
                            btnConnected[cnt] = new ConnectedButton(i, Convert.ToInt16(topcontrolsHeight * 0.75F), Convert.ToInt16(topcontrolsHeight * 1.25F), panel.Top + topcontrolsFromTop);
                            panel.Controls.Add(btnConnected[cnt]);
                            btnConnected[cnt].RefreshOriginalVal = refreshOriginalVal;
                            cnt++;
                        }
                    }
                }
                else
                {
                    throw new Exception("There is no connection enabled in XML file. Please open XML file and enable at least one connection.");
                }


                btnStarted = new StartedButton(GuiID, Convert.ToInt16(topcontrolsHeight * 1F), Convert.ToInt16(topcontrolsHeight * 1.25F), panel.Top + topcontrolsFromTop)
                {
                    Location = new Point(5, topcontrolsFromTop),
                    Showname = settingsXML.Element("root").Element("GUI" + GuiID).Element("GuiName").Value
                };

                panel.Controls.Add(btnSettings);
                
                try
                {
                    FormControl.LogoffModeEnabled = Convert.ToBoolean(settingsXML.Element("root").Element("GENERAL").Element("LogoffEnabled").Value);
                }
                catch 
                {  }

                if (FormControl.LogoffModeEnabled)
                {
                    panel.Controls.Add(btnLogoff);
                }

                panel.Controls.Add(btnLogedInAs);
                panel.Controls.Add(btnStarted);

                panel.Controls.Add(btnSwitchGui);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error have ocurded while procesing additional settings, some related with XML config file: " + ex.Message + Environment.NewLine + "Application will now close!");
                Environment.Exit(0);
            }

            panelStat = new PanelStat();

            Controls.Add(panel);
            panel.Controls.Add(panelStat);            

            Thread GuiRefresher = new Thread(new ThreadStart(GuiRefresher_method))
            {
                Name = "GuiRefresher Thread",
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
                
            };
            GuiRefresher.SetApartmentState(ApartmentState.MTA);
            GuiRefresher.Start();

            

            Thread DisablePanelDisplayWhileNotStarted = new Thread(new ThreadStart(DisablePanelDisplayWhileNotStarted_DoWork))
            {
                Name = "DisablePanelDisplayWhileNotStarted Thread",
                IsBackground = true
            };
            
            DisablePanelDisplayWhileNotStarted.Start();


            BackColor = panel.BackColor;
            ResizeBegin += (s, e) => { SuspendLayout(); };
            ResizeEnd += (s, e) => { ResumeLayout(true); };

            panel.MouseLeave += Gui_LostFocus;
                        
        }

        private void BtnSwitchGui_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var gui = (Gui)btn.Parent.Parent;
            var gui_id = gui.GuiID;
            if (gui_id == 1)
            {
                FormControl.HideForm_Gui(false);
                FormControl.ShowForm_Gui(2);
            }
            if (gui_id == 2)
            {
                FormControl.HideForm_Gui(false);
                FormControl.ShowForm_Gui(1);
            }
           
        }


        // Pool refreshing
        public void GuiRefresher_method()
        {
            try
            {
                var mi = new MethodInvoker(delegate { UpdateGui(); });
                DateTime dt1;
                while (true)
                {                    

                    if (FormControl.bt1.InitialisationComplete && IsHandleCreated)
                    {
                        dt1 = DateTime.Now;
                        Invoke(mi);
                        while ((int)(DateTime.Now - d2).TotalMilliseconds < refreshOriginalVal)
                        {
                            Thread.Sleep(50);
                        }                        
                    }
                    else
                    {
                        resizeNeeded = true;
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                FormControl.bt1.WL("Gui Refresher has been terminated unexpectedly. Please restart application. Cause: " + ex.Message, -2);
            }

        }//

       // use instead Invalidate()
        public void UpdateGui()
        {
            UpdateGui(true);
        }

        public void UpdateGui(bool resizeNeeded)
        {
            if (FormControl.bt1.InitialisationComplete)
            {
                this.resizeNeeded = resizeNeeded; 
                panel.Invalidate(InvalidationRect, false);
            }
        }


        //       //       //       //
        //       //       //       //
        //       //       //       //

        // repaint on resize
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
                                                           
            if (resizeNeeded)
            {
                // topmost rectangle with diferent background (for buttons)
                rectTop.Y = panel.Top;
                rectTop.X = panel.Left;
                rectTop.Width = Convert.ToInt16(panel.Width);                
            }
            e.Graphics.FillRectangle(rectTopBrush, rectTop);

           
            previousObjectLeft = 0; ; // button positioning help
            if (resizeNeeded)
            {               

                // buttons on top
                btnSettings.Left = panel.Right - btnSettings.Width - topcontrolsSpacing;
                btnSettings.Top = topcontrolsFromTop;

                btnSwitchGui.Left = btnLogedInAs.Left - btnSwitchGui.Width - 530;
                btnSwitchGui.Top = topcontrolsFromTop;

                btnLogoff.Left = btnSettings.Left - btnLogoff.Width - topcontrolsSpacing;
                btnLogoff.Top = topcontrolsFromTop;

                btnLogedInAs.Left = btnLogoff.Left - btnLogedInAs.Width - topcontrolsSpacing;
                btnLogedInAs.Top = topcontrolsFromTop;
                btnLogedInAs.Text = LogedInLabelMaker();

                previousObjectLeft = btnLogedInAs.Left;
                previousObjectLeft = previousObjectLeft - 15;
            }

            // buttons on top
            try
            {
                for (int i = btnConnected.Length - 1; i >= 1; i--)
                {
                    if (btnConnected[i] != null)
                    {

                        if (resizeNeeded)
                        {
                            btnConnected[i].Left = previousObjectLeft - btnConnected[i].Width - topcontrolsSpacing;
                            topcontrolsSpacing = 5;

                            previousObjectLeft = btnConnected[i].Left;
                            rectConnName[i].X = btnConnected[i].Left;
                            rectConnName[i].Y = btnConnected[i].Bottom;
                            rectConnName[i].Height = btnLogedInAs.Height - btnConnected[i].Height;
                            rectConnName[i].Width = btnConnected[i].Width;
                        }   
                        
                        TextRenderer.DrawText(e.Graphics, btnConnected[i].Showname, Misc.MeasureString(e, rectConnName[i], btnConnected[i].Showname, 10, FontStyle.Bold), rectConnName[i], Color.White, TextFormatFlags.HorizontalCenter);
                    }

                    if (FormControl.bt1.Prop1.NapajanjeOK.Value == 1)
                    {
                        MainsErr.Hide();
                    }
                    else
                    {
                        MainsErr.Show();
                    }
                   
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Buttons with connection info can not be initialised properly! : " + ex.Message);
            }


            try
            {
                if (resizeNeeded)
                {
                    fromPaneltoElavator = rectTop.Bottom + 40; // offset for dinamic drawings

                    // Containers for graphics manager
                    _PanelBorders = panel.ClientRectangle;
                    _PanelBorders.Inflate(-1, -1);
                }
                    e.Graphics.DrawRectangle(borderFormPen, _PanelBorders);

                // other dinamic Content               

                if (resizeNeeded)
                {
                    if (StKadi > 20) { StKadi = 20; }
                    if (StKadi < 1) { StKadi = 1; }

                    skipPause = 0;
                    SUMOFRatioPauses = StKadi + 1;
                    for (int i = 1; i < StKadi + 1; i++)
                    {
                        if (kadi[i].TypeOfKad == 3)
                        {
                            skipPause++;
                            i++; // skip next entry
                        }
                    }

                    
                        _ContainerPause = ((_PanelBorders.Width - _paintXoffset) / StKadi) * RatioPause; // spaces between containers
                        _ALLContainersWidth = (_PanelBorders.Width) - (_ContainerPause * StKadi - skipPause * _ContainerPause) - (_paintXoffset + 10); // width of all containers
                        _ContainerHeight = Misc.ToInt(_ALLContainersWidth / SUMOFRatioPauses * RatioKad); // height of all containers



                        //limits max height of drawing
                        if (_ContainerHeight > MaxHeightKad)
                        {
                            dif = MaxHeightKad / _ContainerHeight;
                            _ContainerHeight = MaxHeightKad;
                            _ALLContainersWidth = _ALLContainersWidth - (_ALLContainersWidth * dif);
                            _ContainerPause = _ContainerPause - (_ContainerPause * dif);
                        }
                        _ContainerHeightOffset = fromPaneltoElavator + (_ContainerHeight / 10) + _ContainerHeight / 4;
                    

                    // calculates custom widths
                    sumOfWidthMultipliers = 0;
                    for (int i = 1; i < SUMOFRatioPauses; i++)
                    {
                        sumOfWidthMultipliers = sumOfWidthMultipliers + _WidthMultiplyer[i];
                    }


                    //calculates width to display for every container
                    for (int i = 1; i < SUMOFRatioPauses; i++)
                    {
                        _ContainerWidth[i] = _ALLContainersWidth / sumOfWidthMultipliers * _WidthMultiplyer[i];
                        if (_ContainerWidth[i] / _WidthMultiplyer[i] >= _ContainerHeight / RatioKad)
                        {
                            _ContainerWidth[i] = (_ContainerHeight / RatioKad) * _WidthMultiplyer[i];
                        }
                    }
                    // offset for drawing
                    _ContainerHeightOffset2 = _ContainerHeightOffset;

                    _newStart[0] = _PanelBorders.X + _paintXoffset + _ContainerPause / 3;


                }

                

                for (int i = 1; i <= StKadi; i++)
                {
                    if (kadi[i] != null)
                    {
                        kadi[i].GetThisTimeEnabled(true);
                    }                    
                }

                for (int i = 1; i < SUMOFRatioPauses; i++)
                {
                                           
                    
                    if (kadi[i].TypeOfKad == 0) // empty drawing
                    {
                        if (resizeNeeded)
                        {
                            _Containers[i] = new Rectangle(Misc.ToInt(_newStart[i-1]), (_PanelBorders.Y + _ContainerHeightOffset2), Misc.ToInt(_ContainerWidth[i]), _ContainerHeight);
                            _newStart[i] = _newStart[i - 1] + _Containers[i].Width + _ContainerPause;
                            _SubContainerHeightOffset[i] = _Containers[i].Height / 4.5F;
                            _SubContainerHeight[i] = (_Containers[i].Height - _SubContainerHeightOffset[i]) * 0.97F;
                            _SubContainerY_location[i] = _Containers[i].Y + _SubContainerHeightOffset[i];
                            _SubContainerWidth[i] = (_Containers[i].Width) * 0.75F;
                            _SubContainerX_location[i] = (_Containers[i].X) + _SubContainerWidth[i] * 0.175F;
                            _RectBorders[i] = new Rectangle(Misc.ToInt(_SubContainerX_location[i]), Misc.ToInt(_SubContainerY_location[i]), Misc.ToInt(_SubContainerWidth[i]), Misc.ToInt(_SubContainerHeight[i]));
                            

                            font[i] = new Font(FontFamily.GenericSansSerif, bottNumGraphicRect.Height * 0.07F, FontStyle.Bold);
                        }

                        _RectBrush[i] = new SolidBrush(kadi[i].KadColor);
                    }

                    else if (kadi[i].TypeOfKad == 1) // normal drawing
                    {
                        if (resizeNeeded)
                        {
                            _Containers[i] = new Rectangle(Misc.ToInt(_newStart[i - 1]), (_PanelBorders.Y + _ContainerHeightOffset2), Misc.ToInt(_ContainerWidth[i]), _ContainerHeight);
                            _newStart[i] = _newStart[i - 1] + _Containers[i].Width + _ContainerPause;
                            NameBrush[i] = new SolidBrush(kadi[i].NameColor);
                            _SubContainerHeightOffset[i] = _Containers[i].Height / 4.5F;
                            _SubContainerHeight[i] = (_Containers[i].Height - _SubContainerHeightOffset[i]) * 0.97F;
                            _SubContainerY_location[i] = _Containers[i].Y + _SubContainerHeightOffset[i];
                            _SubContainerWidth[i] = (_Containers[i].Width) * 0.75F;
                            _SubContainerX_location[i] = (_Containers[i].X) + _SubContainerWidth[i] * 0.173F;
                            _RectBorders[i] = new Rectangle(Misc.ToInt(_SubContainerX_location[i]), Misc.ToInt(_SubContainerY_location[i]), Misc.ToInt(_SubContainerWidth[i]), Misc.ToInt(_SubContainerHeight[i]));
                            
                            font[i] = new Font(FontFamily.GenericSansSerif, _Containers[i].Height * 0.1F, FontStyle.Bold);
                        }

                        _RectBrush[i] = new SolidBrush(kadi[i].KadColor);

                        if (_bordered[i])
                            {
                                HoverborderFormPen = HoverborderFormPen1;
                            }
                            else
                            {
                                HoverborderFormPen = HoverborderFormPen2;
                            }
                            
                                                
                        e.Graphics.DrawRectangle(HoverborderFormPen, _Containers[i]);
                        
                           

                        // fill containers with garphics

                        e.Graphics.DrawImage(KadKonstrukcija, _Containers[i]);

                       
                            
                        
                                                
                        e.Graphics.FillRectangle(_RectBrush[i], _RectBorders[i]);

                        
                            topOfGrapics = Misc.RectangleGetCenter(_RectBorders[i]);                        
                            bottNumGraphicRect = Misc.RectangleFromCenterPoint(topOfGrapics.X, topOfGrapics.Y, _RectBorders[i].Height / 2.3F, _RectBorders[i].Height / 2.9F);
                 
                                                
                        e.Graphics.DrawString(kadi[i].Showname, font[i], NameBrush[i], bottNumGraphicRect, sf);
                    }

                    else if (kadi[i].TypeOfKad == 2) // wide drawing
                    {
                        if (resizeNeeded)
                        {
                            _Containers[i] = new Rectangle(Misc.ToInt(_newStart[i - 1]), (_PanelBorders.Y + _ContainerHeightOffset2), Misc.ToInt(_ContainerWidth[i]), _ContainerHeight);
                            _newStart[i] = _newStart[i - 1] + _Containers[i].Width + _ContainerPause;
                            NameBrush[i] = new SolidBrush(kadi[i].NameColor);
                            _SubContainerHeightOffset[i] = _Containers[i].Height / 4.5F;
                            _SubContainerHeight[i] = (_Containers[i].Height - _SubContainerHeightOffset[i]) * 0.97F;
                            _SubContainerY_location[i] = _Containers[i].Y + _SubContainerHeightOffset[i];
                            _SubContainerWidth[i] = (_Containers[i].Width) * 0.835F;
                            _RectBorders[i] = new Rectangle(Misc.ToInt(_SubContainerX_location[i]), Misc.ToInt(_SubContainerY_location[i]), Misc.ToInt(_SubContainerWidth[i]), Misc.ToInt(_SubContainerHeight[i]));
                            _SubContainerX_location[i] = (_Containers[i].X) + _SubContainerWidth[i] * 0.1F;
                            _RectBorders[i] = new Rectangle(Misc.ToInt(_SubContainerX_location[i]), Misc.ToInt(_SubContainerY_location[i]), Misc.ToInt(_SubContainerWidth[i]), Misc.ToInt(_SubContainerHeight[i]));
                            _RectBorders[i] = new Rectangle(Misc.ToInt(_SubContainerX_location[i]), Misc.ToInt(_SubContainerY_location[i]), Misc.ToInt(_SubContainerWidth[i]), Misc.ToInt(_SubContainerHeight[i]));
                            
                            font[i] = new Font(FontFamily.GenericSansSerif, _Containers[i].Height * 0.10F, FontStyle.Bold);
                        }

                        _RectBrush[i] = new SolidBrush(kadi[i].KadColor);

                        if (_bordered[i])
                            {
                                HoverborderFormPen = HoverborderFormPen1;
                            }
                            else
                            {
                                HoverborderFormPen = HoverborderFormPen2;
                            }
                                                   
                        
                        e.Graphics.DrawRectangle(HoverborderFormPen, _Containers[i]);
                       
                            

                        // fill containers with garphics

                        e.Graphics.DrawImage(KadKonstrukcijaPosirjena, _Containers[i]);

                                                                      
                        e.Graphics.FillRectangle(_RectBrush[i], _RectBorders[i]);

                        topOfGrapics = Misc.RectangleGetCenter(_RectBorders[i]);
                        bottNumGraphicRect = Misc.RectangleFromCenterPoint(topOfGrapics.X, topOfGrapics.Y, _RectBorders[i].Height / 2.3F, _RectBorders[i].Height / 3F);
                    
                                                
                        e.Graphics.DrawString(kadi[i].Showname, font[i], NameBrush[i], bottNumGraphicRect, sf);
                    }

                    else if (kadi[i].TypeOfKad == 3) // double drawing
                    {
                        for (int ii = 0; ii < 2; ii++)
                        {
                            if (resizeNeeded)
                            {
                                _Containers[i] = new Rectangle(Misc.ToInt(_newStart[i - 1]), (_PanelBorders.Y + _ContainerHeightOffset2), Misc.ToInt(_ContainerWidth[i]), _ContainerHeight);
                                if (ii == 0) { _newStart[i] = _newStart[i - 1] + _Containers[i].Width + 0; }
                                if (ii == 1) { _newStart[i] = _newStart[i - 1] + _Containers[i].Width + _ContainerPause; }

                                NameBrush[i] = new SolidBrush(kadi[i].NameColor);
                                                                
                                _SubContainerHeightOffset[i] = _Containers[i].Height / 4.5F;
                                _SubContainerHeight[i] = (_Containers[i].Height - _SubContainerHeightOffset[i]) * 0.97F;
                                _SubContainerY_location[i] = _Containers[i].Y + _SubContainerHeightOffset[i];

                                if (ii == 0) { _SubContainerWidth[i] = (_Containers[i].Width) * 0.82F; }
                                if (ii == 1) { _SubContainerWidth[i] = (_Containers[i].Width) * 0.82F; }

                                if (ii == 0) { _SubContainerX_location[i] = (_Containers[i].X) + _SubContainerWidth[i] * 0.160F; }
                                if (ii == 1) { _SubContainerX_location[i] = (_Containers[i].X) + _SubContainerWidth[i] * 0.065F; }

                                _RectBorders[i] = new Rectangle(Misc.ToInt(_SubContainerX_location[i]), Misc.ToInt(_SubContainerY_location[i]), Misc.ToInt(_SubContainerWidth[i]), Misc.ToInt(_SubContainerHeight[i]));
                                

                                font[i] = new Font(FontFamily.GenericSansSerif, _Containers[i].Height * 0.1F, FontStyle.Bold);
                            }

                            _RectBrush[i] = new SolidBrush(kadi[i].KadColor);

                            if (ii == 0) { e.Graphics.DrawImage(KadKonstrukcijaDvojnaL, _Containers[i]); }
                            if (ii == 1) { e.Graphics.DrawImage(KadKonstrukcijaDvojnaR, _Containers[i]); }

                            e.Graphics.FillRectangle(_RectBrush[i], _RectBorders[i]);

                            topOfGrapics = Misc.RectangleGetCenter(_RectBorders[i]);
                            bottNumGraphicRect = Misc.RectangleFromCenterPoint(topOfGrapics.X, topOfGrapics.Y, _RectBorders[i].Height / 1.3F, _RectBorders[i].Height / 4);

                                                                       
                            e.Graphics.DrawString(kadi[i].Showname, font[i], NameBrush[i], bottNumGraphicRect, sf);

                            if (ii < 1) { i++; } 

                        }
                        if (_bordered[i - 1])
                        {
                            HoverborderFormPen = HoverborderFormPen1;
                        }
                        else
                        {
                            HoverborderFormPen = HoverborderFormPen2;
                        }
                        e.Graphics.DrawRectangle(HoverborderFormPen, _Containers[i - 1]);
                        if (_bordered[i])
                        {
                            HoverborderFormPen = HoverborderFormPen1;
                        }
                        else
                        {
                            HoverborderFormPen = HoverborderFormPen2;
                        }
                        e.Graphics.DrawRectangle(HoverborderFormPen, _Containers[i]);
                    }

                    
                }

                if (resizeNeeded)
                {
                    // UnderTitle rectangle with line
                    _UnderTitleRect_X = _Containers[1].X - _ContainerPause / 3 - _paintXoffset / 2;
                    _UnderTitleRect_Y = _Containers[1].Y + _Containers[1].Height + (_Containers[1].Height * 0.15F);
                    _UnderTitleRect_W = (_Containers[StKadi].X + _Containers[StKadi].Width - _Containers[1].X) + (_ContainerPause / 3) * 2 + _paintXoffset /2;
                    _UnderTitleRect_H = _ContainerHeight * 0.25F;

                    _UnderlineRect = new Rectangle(Misc.ToInt(_UnderTitleRect_X), Misc.ToInt(_UnderTitleRect_Y), Misc.ToInt(_UnderTitleRect_W), Misc.ToInt(_UnderTitleRect_H));
                }
                
                e.Graphics.FillRectangle(_UnderlineBrush, _UnderlineRect);

                // Numbers  

                if (resizeNeeded)
                {
                    font[0] = new Font(FontFamily.GenericSansSerif, _Containers[1].Height * 0.13F, FontStyle.Bold);
                }
                               

                for (int i = 1; i < SUMOFRatioPauses; i++)
                {
                    tmpCenter.X = Misc.RectangleGetCenter(_Containers[i]).X;
                    tmpCenter.Y = Misc.RectangleGetCenter(_UnderlineRect).Y;

                    _UnderlineRectString1 = Misc.RectangleFromCenterPoint(tmpCenter.X, tmpCenter.Y, _ContainerHeight / 3, Misc.ToInt(_UnderTitleRect_H * 0.75F));

                     if(!kadi[i].GetThisEnabled()) // if disabled
                    {
                        if (_bordered2[i])
                        {
                            e.Graphics.FillRectangle(IDshowBrush_Disabled_hvr, _UnderlineRectString1); // if disabled & hover
                            
                        }
                        else
                        {
                            e.Graphics.FillRectangle(IDshowBrush_Disabled, _UnderlineRectString1); // if disabled & no hover
                        }

                        // show crossed over
                        e.Graphics.DrawLine(blackPen, _UnderlineRectString1.X, _UnderlineRectString1.Y, (_UnderlineRectString1.X + _UnderlineRectString1.Width), (_UnderlineRectString1.Y + _UnderlineRectString1.Height));
                    }
                     
                    else if (!kadi[i].GetThisTimeEnabled(false)) // checks if schedule is disabling unit - sets colors implicitly)
                    {                       

                        if (_bordered2[i])
                        {
                            e.Graphics.FillRectangle(IDshowBrush_TimeDisabled_hvr, _UnderlineRectString1);  // if Time Disabled & hover
                        }
                        else
                        {
                            e.Graphics.FillRectangle(IDshowBrush_TimeDisabled, _UnderlineRectString1); // if Time Disabled & no hover
                        }

                        // show crossed over
                        //e.Graphics.DrawLine(blackPen, _UnderlineRectString1.X, _UnderlineRectString1.Y, (_UnderlineRectString1.X + _UnderlineRectString1.Width), (_UnderlineRectString1.Y + _UnderlineRectString1.Height));
                    }
                    else // if enabled
                    {
                        if (_bordered2[i])
                        {
                            e.Graphics.FillRectangle(IDshowBrush_Enabled_hvr, _UnderlineRectString1); // if enabled & hover
                        }
                        else
                        {
                            e.Graphics.FillRectangle(IDshowBrush_Enabled, _UnderlineRectString1);  // if enabled & no hover
                        }
                    }

                    IDshowBrush_Border = new Pen(Misc.ColorBrightener(IDshowBrush_Enabled_hvr.Color, 0.3m, 0.3m, 0.3m),2);
                    e.Graphics.DrawRectangle(IDshowBrush_Border, _UnderlineRectString1);

                    _UnderlineRectString2[i] = new Rectangle(_UnderlineRectString1.Location.X, _UnderlineRectString1.Location.Y + 3, _UnderlineRectString1.Width, _UnderlineRectString1.Height - 2);
                    e.Graphics.DrawString(kadi[i].ID.ToString(), font[0], blackBrush, _UnderlineRectString2[i], sf);

                    
                }

                // Line on the top of rectangle (below containers)   
                start = new Point(Misc.ToInt(_UnderTitleRect_X), Misc.ToInt(_UnderTitleRect_Y));
                end = new Point(Misc.ToInt(_UnderTitleRect_X + _UnderTitleRect_W), Misc.ToInt(_UnderTitleRect_Y));
                e.Graphics.DrawLine(blackPen, start, end);

                if (paintElavator)
                {
                    PaintElavator(start, end, e, elavatorHorizontalProgress);
                }

                PaintWarning(e);
                Sarza(e);

            }
            catch (Exception ex)
            {
                FormControl.bt1.WL("internal eroor painting graphics: " + ex.Message + ". " + ex.Source, 0);
            }

            if (resizeNeeded)
            {
                NestDatagrids();
                NestStopwatches();
                panelStat.NestStat();             
            }
            ClockShow.Text = FormControl.bt1.Prop1.LogoTimeShowOnly.Value_ClockForSiemensLogoFormat;

            // last      


           
                InvalidationRect = new Rectangle(
                rectTop.X + 1,
                rectTop.Y + rectTop.Height + 1,
               panel.Width - 2,
                panelStat.Location.Y - rectTop.Height -20);

            //e.Graphics.DrawRectangle(blackPen, InvalidationRect);

            resizeNeeded = false;
            d2 = DateTime.Now;
           
        }


        //  ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ...

        //  ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ...

        // Sarža
        private void Sarza(PaintEventArgs e)
        {
            bool draw = false;


            try
            {

                if (true)
                {
                    for (int i = 1; i < SUMOFRatioPauses; i++)
                    {
                        draw = false;

                        if (GuiID == 1)
                        {
                            switch (i)
                            {
                                case 1: if (FormControl.bt1.Prop2.PrisotnostSarze1.Value == true) { draw = true; }; break;
                                case 2: if (FormControl.bt1.Prop2.PrisotnostSarze2.Value == true) { draw = true; }; break;
                                case 3: if (FormControl.bt1.Prop2.PrisotnostSarze3.Value == true) { draw = true; }; break;
                                case 4: if (FormControl.bt1.Prop2.PrisotnostSarze4.Value == true) { draw = true; }; break;
                                case 5: if (FormControl.bt1.Prop2.PrisotnostSarze5.Value == true) { draw = true; }; break;
                                case 6: if (FormControl.bt1.Prop3.PrisotnostSarze6.Value == true) { draw = true; }; break;
                                case 7: if (FormControl.bt1.Prop4.PrisotnostSarze7.Value == true) { draw = true; }; break;
                                case 8: if (FormControl.bt1.Prop4.PrisotnostSarze8.Value == true) { draw = true; }; break;
                                case 9: if (FormControl.bt1.Prop5.PrisotnostSarze9.Value == true) { draw = true; }; break;
                                default: FormControl.bt1.WL("Switch Statement does not support this ID. Message source: Sarza() method", -1); break;
                            }
                        }

                        if (GuiID == 2)
                        {
                            switch (i)
                            {
                                case 1: if (FormControl.bt1.Prop6.PrisotnostSarze10.Value == true) { draw = true; }; break;
                                case 2: if (FormControl.bt1.Prop8.PrisotnostSarze11.Value == true) { draw = true; }; break;
                                case 3: if (FormControl.bt1.Prop6.PrisotnostSarze12.Value == true) { draw = true; }; break;
                                case 4: if (FormControl.bt1.Prop6.PrisotnostSarze13.Value == true) { draw = true; }; break;
                                case 5: if (FormControl.bt1.Prop6.PrisotnostSarze14.Value == true) { draw = true; }; break;
                                case 6: if (FormControl.bt1.Prop7.PrisotnostSarze15.Value == true) { draw = true; }; break;
                                case 7: if (FormControl.bt1.Prop7.PrisotnostSarze16.Value == true) { draw = true; }; break;
                                case 8: if (FormControl.bt1.Prop7.PrisotnostSarze17.Value == true) { draw = true; }; break;
                                case 9: if (FormControl.bt1.Prop7.PrisotnostSarze18.Value == true) { draw = true; }; break;
                                case 10: if (FormControl.bt1.Prop8.PrisotnostSarze19.Value == true) { draw = true; }; break;

                                default: FormControl.bt1.WL("Switch Statement does not support this ID. Message source: Sarza() method", -1); break;
                            }
                        }

                        if (resizeNeeded)
                        {
                            SarzaBorders[i] = new Rectangle(Misc.ToInt(_SubContainerX_location[i]), Misc.ToInt(_SubContainerY_location[i] - _SubContainerHeight[i] /6), Misc.ToInt(_SubContainerHeight[i] / 6.5F), Misc.ToInt(_SubContainerHeight[i] / 6.5F));
                        }                        
                            if (draw && kadi[i].TypeOfKad != 0)
                            {                                                             
                                e.Graphics.FillEllipse(Brushes.Green, SarzaBorders[i]);
                                
                            }              
                    }
                    
                }
            }
            catch (Exception ex)
            {
                FormControl.bt1.WL("Internal error: " + ex.Message, -2);
            }
                       
        }


        // elavator
        private void PaintElavator(Point startElavatorLine, Point endElavatorLine, PaintEventArgs e, int progress)
        {
            if (progress > 100) { progress = 100; }
            if (progress < 0) { progress = 0; }


            // paint elavator line                      
            startElavatorLine = new Point(Misc.ToInt(_UnderTitleRect_X), Misc.ToInt(_PanelBorders.Y + fromPaneltoElavator));
            endElavatorLine = new Point(Misc.ToInt(_UnderTitleRect_X + _UnderTitleRect_W), Misc.ToInt(_PanelBorders.Y + fromPaneltoElavator));
            e.Graphics.DrawLine(blackPen, startElavatorLine, endElavatorLine); // Line on the top of containers 

            // Creating steps for elavator
            int elevHeight = (_ContainerHeight / 5);
            for (int i = 1; i < StKadi + 1; i++)
            {
                centers[i] = Misc.RectangleGetCenter(_Containers[i]);
                centers[i].Y = Misc.ToInt(startElavatorLine.Y);
                elavatorRect = Misc.RectangleFromCenterPoint(centers[i].X, centers[i].Y, elevHeight / 4, elevHeight / 4);
                e.Graphics.FillRectangle(blackBrush, elavatorRect);
            }

            // paint elavator            
            elevatorBrush = Brushes.LightBlue;
            elevatorPen = new Pen(Brushes.Black, 2);
            xElavator = startElavatorLine.X + ((endElavatorLine.X - startElavatorLine.X - (_ContainerHeight / 4)) / 100) * progress;
            elavator = new Rectangle(Misc.ToInt(xElavator), startElavatorLine.Y - (elevHeight / 2), elevHeight, elevHeight);
            e.Graphics.FillRectangle(elevatorBrush, elavator); // paint elavator
            e.Graphics.DrawRectangle(elevatorPen, elavator);
            
        }

        private void PaintWarning(PaintEventArgs e)
        {

            for (int i = 1; i < StKadi+1; i++)
            {
                warnRect.Height = _Containers[i].Height / 3;
                warnRect.Width = warnRect.Height;
                warnRect.X = _Containers[i].X + ((_Containers[i].Width / 2) - warnRect.Width / 2);
                warnRect.Y = (_Containers[i].Y + (_Containers[i].Height)) - warnRect.Height;
                mussRect.Height = Convert.ToInt32(warnRect.Height * 0.7F);
                mussRect.Width = Convert.ToInt32(warnRect.Width * 0.5F);
                mussRect.X = warnRect.X;
                mussRect.Y = (_Containers[i].Y + (_Containers[i].Height / 4));

                if (kadi[i].GetThisEnabled() && kadi[i].GetThisTimeEnabled(false)) // if enabled
                {
                    if (kadi[i].WarningLevel == 1)
                    {
                        e.Graphics.DrawImage(warningIcon, warnRect);
                    }
                    else if (kadi[i].WarningLevel == 2)
                    {
                        e.Graphics.DrawImage(errorIcon, warnRect);
                    }                    
                }
                else if (kadi[i].GetThisTimeEnabled(false) == false)
                {
                    PaintTimeDisabledIcon(e, i);
                }

                if (kadi[i].MusslaufActive == 1) // if manual operation
                {
                    e.Graphics.DrawImage(MussIcon, mussRect);
                }

                PaintHeating(e, i); // heating icon when heater is active
                PaintWaterLevelWarning(e, i); // small warning symbol icon when water level is low

            }

        }

        private void PaintWaterLevelWarning(PaintEventArgs e, int i)
        {
            float scale = 0.15F;

            if (resizeNeeded)
            {
                WaterLevelRect[i] = new Rectangle(
                    Misc.ToInt(_SubContainerX_location[i] + Misc.ToInt(_SubContainerHeight[i] * scale * 2.1F)), // X
                    Misc.ToInt(_SubContainerY_location[i] - Misc.ToInt(_SubContainerHeight[i] * scale * 1.1F)), // Y
                    Misc.ToInt(_SubContainerHeight[i] * scale), // W
                    Misc.ToInt(_SubContainerHeight[i] * scale)); //H
            }
            if (kadi[i].GetThisWaterLevelWarning() && WaterLevelRect[i] != null)
            {
                e.Graphics.DrawImage(WaterLevelIcon, WaterLevelRect[i]);
            }
        }

        private void PaintHeating(PaintEventArgs e, int i)
        {
            float scale = 0.15F;

            if (resizeNeeded)
            {
                HeaterRect[i] = new Rectangle(
                    Misc.ToInt(_SubContainerX_location[i] + Misc.ToInt(_SubContainerHeight[i] * scale * 1.1F)),// X
                    Misc.ToInt(_SubContainerY_location[i] - Misc.ToInt(_SubContainerHeight[i] * scale*1.1F)),  // Y
                    Misc.ToInt(_SubContainerHeight[i] * scale), // W
                    Misc.ToInt(_SubContainerHeight[i]* scale)); //H
            }
            if (kadi[i].GetThisHeaterActive() && HeaterRect[i] != null)
            {
                e.Graphics.DrawImage(HeaterActiveIcon, HeaterRect[i]);
            }            
        }

        private void PaintTimeDisabledIcon(PaintEventArgs e, int i)
        {
            float scale = 0.25F;
            TimeDisabledRect[i] = new Rectangle(
                    Misc.ToInt(_SubContainerX_location[i] + _SubContainerHeight[i] * 0.03),// X
                    Misc.ToInt(_SubContainerY_location[i] + _SubContainerHeight[i] * 0.72),  // Y
                    Misc.ToInt(_SubContainerHeight[i] * scale), // W
                    Misc.ToInt(_SubContainerHeight[i] * scale)); //H

            if (TimeDisabledRect[i] != null)
            {
                e.Graphics.DrawImage(TimeDisabledIcon, TimeDisabledRect[i]);
            }
            
        }


        private void NestStopwatches()
        {
            if (kadi != null)
            {
                for (int i = 1; i < StKadi + 1; i++)
                {
                   
                    if (kadi[i].hasStopwatch)
                    {
                        if (!kadi[i].GetThisEnabled())
                        {
                            kadi[i].stopWatch.Hide();
                        }
                        else
                        {
                            kadi[i].stopWatch.Show();
                        }

                        kadi[i].stopWatch.Top = kadi[i].Out_datagrid.Bottom + 10;
                        kadi[i].stopWatch.SetWidth(kadi[i].Out_datagrid.Width);

                        if (kadi[i].stopWatch.Width < kadi[i].Out_datagrid.Width)
                        {
                            kadi[i].stopWatch.Left = kadi[i].Out_datagrid.Left + (kadi[i].Out_datagrid.Width - kadi[i].stopWatch.Width) / 2;
                        }
                        else
                        {
                            kadi[i].stopWatch.Left = kadi[i].Out_datagrid.Left;
                        }
                    }
                }
            }
        }

        

        private string LogedInLabelMaker()
        {
            var tmp = FormControl.identify.GetNameOfLogedInUser();
            if (tmp == "logged off")
            {
                return "Please Log in";
            }
            else
            {
                return "Loged in: " + FormControl.identify.GetNameOfLogedInUser();
            }

        }


        public static void WL_UserAction(string text, bool showToUserLog)
        {
            Int64 UserId = FormControl.identify.LoggedInID;
            string UserName = FormControl.identify.LogedInUserName;
            string message;

            // Log to log file
            try
            {
                message = DateTime.Now.ToString() + " - Eventlog" + ": CurrentUserID: " + UserId + " / " + UserName + " - " + text;

                FormControl.sw_Main.WriteLine(message); FormControl.sw_Main.Flush();
            }
            catch (Exception e)
            {
                MessageBox.Show("Log file error/Streamwriter error: " + e.Message);
            }

            // Log to csv file
            if (showToUserLog == true)
            {
                try
                {
                    FormControl.sw_UserActions.WriteLine(Environment.NewLine + DateTime.Now.ToString() + ";" + UserId + ";" + UserName + ";" + text); FormControl.sw_UserActions.Flush();
                }
                catch (Exception e)
                {
                    MessageBox.Show("UserActionsLog file error/Streamwriter error: " + e.Message);
                }
            }

        }

        private void DisablePanelDisplayWhileNotStarted_DoWork()
        {
            try
            {
                MethodInvoker m = new MethodInvoker(DisablePanelDisplayWhileNotStarted_Method);
                bool a;
                try
                {
                    a = Convert.ToBoolean(settingsXML.Element("root").Element("GENERAL").Element("DisableGuiOnLostConnection").Value);
                }
                catch
                {
                    a = true;
                }


                while (true)
                {
                    if (IsHandleCreated)
                    {
                        if (a)
                        {
                            Invoke(m);
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cant start DisablePanelDisplayWhileNotStarted_Method Thread. Error message folows: " + ex.Message);
            }

        }

        private void DisablePanelDisplayWhileNotStarted_Method()
        {
            try
            {
                if (btnStarted.StartedStatus != (int)StartedButton.StatedStatus.Started)
                {
                    if (panel.Visible == false && FormControl.Form_gui_IsShown)
                    {
                        MessageBox.Show("Povezava ni vzpostavljena, zato sta ogled in urejanje zaklenjena.");
                        panel.Visible = true;
                        for (int i = 1; i < StKadi + 1; i++)
                        {
                            kadi[i].Visible = false;
                        }
                    }
                    else
                    {
                        resizeNeeded = true;
                    }
                }
            }
            catch
            {
                Thread.Sleep(5000);
            }
        }


    }
}
