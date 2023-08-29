using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;


namespace Humar_sistemi___Kontrola_kadi
{

    // Dinamical graphics only
    public partial class TestGui : Form
    {
        public int GuiID { get; private set; }
        public FormControl FormControl { get; set; }
        private Rectangle rectTop; // only for color separation on top of the form
        private Color rectTopColor = Color.FromArgb(90, 90, 90);
        private SolidBrush rectTopBrush;

        //settings

        bool drawingInProgress = false;

        public Color controlsColor = Color.LightGray;
        XElement settings;
        Kad[] kadi = new Kad[21];

        Button btnSettings = new Button();
        Button btnLogedInAs = new Button();
        Button btnLogoff = new Button();

        public XDocument settingsXML;
        public int StKadi;
        public int MaxHeightKad;
        public float RatioKad;
        public float RatioPause;

        // init 
        public MyPanel panel = new MyPanel();
        Label[] vars;
        int varsSizePX = 30;
        Font varsFont = new Font(FontFamily.GenericSansSerif,12,FontStyle.Bold);

        Rectangle _PanelBorders;
        Rectangle[] _Containers = new Rectangle[21];
        bool[] _bordered = new bool[21];
        //Button[] _Buttons = new Button[21];
        float _ContainerHeight;
        float _ContainerHeightOffset;
        float _ContainerHeightOffset2;
        int fromPaneltoElavator;
        float _ALLContainersWidth;
        float[] _ContainerWidth = new float[21];
        float _ContainerPause;
        float _StartOffsetX = 50;
        float[] _WidthMultiplyer = new float[21];        
        float _newStart;
        float _paintXoffset = 90;

        Brush _RectBrush;
        Rectangle _RectBorders;
        float _SubContainerHeight;
        float _SubContainerX_location;
        float _SubContainerHeightOffset;
        float _SubContainerWidth;
        float _SubContainerY_location;


        Brush _UnderlineBrush;
        Rectangle _UnderlineRect;
        float _UnderTitleRect_X;
        float _UnderTitleRect_Y;
        float _UnderTitleRect_W;
        float _UnderTitleRect_H;

        Point topOfGrapics;
        Rectangle bottNumGraphicRect;
        StringFormat sf = new StringFormat();  
        Brush NameBrush;

        Pen borderFormPen = Pens.Transparent; // only for debug graphics
        Pen HoverborderFormPen;
        Pen HoverborderFormPen1 = new Pen(Brushes.Blue,1);
        Pen HoverborderFormPen2 = Pens.Transparent;

        Pen borderKadPen = Pens.Black;
        private int SUMOFRatioPauses;
        Bitmap KadKonstrukcija = new Bitmap(Properties.Resources.Kad___konstrukcija);
        Bitmap KadKonstrukcijaPosirjena = new Bitmap(Properties.Resources.Kad___konstrukcija_Posirjena);
        Bitmap KadKonstrukcijaDvojnaL = new Bitmap(Properties.Resources.Kad___konstrukcija_dvojna_L);
        Bitmap KadKonstrukcijaDvojnaR = new Bitmap(Properties.Resources.Kad___konstrukcija_dvojna_R);
        
        Rectangle elavator;
        bool paintElavator;
        int elavatorHorizontalProgress;
        int elavatorVerticalProgress;
        Point[] centers = new Point[21];

        private static Bitmap warningIcon = Properties.Resources.warning_icon_24;
        private static Bitmap errorIcon = Properties.Resources.warning_icon_png_1;        

        public ConnectedButton[] btnConnected = new ConnectedButton[21];
        StartedButton btnStarted;
        Font font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);        
        Rectangle rectConnName = new Rectangle();

        int topcontrolsHeight = 40;
        int topcontrolsFromTop = 10;
        int topcontrolsSpacing = 10;

        Brush blackBrush = Brushes.Black;
        Pen blackPen;
        Point tmpCenter = new Point();
        Rectangle _UnderlineRectString;

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
        DateTime LastRedraw;

        public TestGui(XDocument settingsXML, int ID)
        {
            GuiID = ID;
            rectTop = new Rectangle();
            rectTopBrush = new SolidBrush(rectTopColor);
            rectTop.Height = 60; // afeects other controls

            blackPen = new Pen(blackBrush, 3);

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
            elavatorVerticalProgress = 0;

            MinimumSize = new Size(700, 500);

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            topOfGrapics = new Point();
            bottNumGraphicRect = new Rectangle();


            try
            {
                settings = settingsXML.Element("root").Element("GUI" + GuiID);

                // S E T T I N G S 
                StKadi = int.Parse(settings.Element("StKadi").Value.Replace("\"", ""));           // koliko kadi je potrebno prikazati na gui
                MaxHeightKad = int.Parse(settings.Element("MaxHeightKad").Value.Replace("\"", ""));     // največja dovoljena višina
                RatioKad = 1.7F;       // razmerje višina širina
                RatioPause = float.Parse(settings.Element("RatioPause").Value.Replace("\"", ""))/100F; // širina presledka do naslednje kadi reletivna na višino kadi
                RowHeadersWidth = int.Parse(settings.Element("RowHeadersWidth").Value.Replace("\"", ""));
                _UnderlineBrush = Brushes.LightGray;
                refreshOriginalVal = int.Parse(settingsXML.Element("root").Element("GENERAL").Element("GUIrefreshrate").Value);

                paintElavator = bool.Parse(settings.Element("paintElavator").Value.Replace("\"", ""));
                panel.BackColor = Color.FromArgb(int.Parse(settings.Element("GuiBackgroundColor").Value.Replace("\"", "")));
                                

                for (int i = 1; i < _ContainerWidth.Length; i++)
                {
                    kadi[i] = new Kad(i, this);
                    _WidthMultiplyer[i] = float.Parse(settings.Element("Kad" + i).Element("WidthMultiplyer").Value.Replace("\"", "")) / 100;
                    kadi[i].TypeOfKad = int.Parse(settings.Element("Kad" + i).Element("TypeOf_Kad").Value.Replace("\"", ""));                    
                    kadi[i].KadColor = Color.FromArgb(int.Parse(settings.Element("Kad" + i).Element("KadColor").Value.Replace("\"", "")));
                    kadi[i].NameColor = Color.FromArgb(int.Parse(settings.Element("Kad" + i).Element("NameColor").Value.Replace("\"", "")));
                    kadi[i].Showname = settings.Element("Kad" + i).Element("Name").Value.Replace("\"", "");
                    kadi[i].BackColor = panel.BackColor;                    
                    _bordered[i] = false;
                    
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
                panel.Resize += panel_Redraw;
                panel.Paint += panel_Paint;

                panel.MouseClick += new MouseEventHandler(OnMouseClick);
                panel.MouseMove += new MouseEventHandler(OnMouseHover);

                btnSettings.Height = topcontrolsHeight;
                btnSettings.BackColor = Button.DefaultBackColor;
                btnSettings.Text = "Settings";
                this.btnSettings.Click += this.button1_Click_1;

                btnLogoff.BackColor = Button.DefaultBackColor;
                btnLogoff.Height = topcontrolsHeight;
                btnLogoff.Width = 100;
                btnLogoff.Text = "Logoff";
                this.btnLogoff.Click += this.buttonLogoff;

                btnLogedInAs.BackColor = Button.DefaultBackColor;
                btnLogedInAs.Height = topcontrolsHeight;
                btnLogedInAs.Width = 250;
                this.btnLogedInAs.Click += this.buttonLogin;
                          
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
                            btnConnected[cnt].refreshOriginalVal = refreshOriginalVal;
                            cnt++;
                        }
                    }
                }
                else
                {
                    throw new Exception("There is no connection enabled in XML file. Please open XML file and enable at least one connection.");
                }


                btnStarted = new StartedButton(GuiID, Convert.ToInt16(topcontrolsHeight * 1F), Convert.ToInt16(topcontrolsHeight * 1.25F), panel.Top + topcontrolsFromTop);
                btnStarted.Location = new Point(5, topcontrolsFromTop);
                btnStarted.Showname = settingsXML.Element("root").Element("GUI" + GuiID).Element("GuiName").Value;

                panel.Controls.Add(btnSettings);
                panel.Controls.Add(btnLogoff);
                panel.Controls.Add(btnLogedInAs);
                panel.Controls.Add(btnStarted);
                                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error have ocurded while procesing additional settings, some related with XML config file: " + ex.Message + Environment.NewLine + "Application will now close!");
                Environment.Exit(0);
            }

            
            Controls.Add(panel);
            panel_Redraw(null,null);
            
        }


        // repaint on resize
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            drawingInProgress = true;
            
            // topmost rectangle with diferent background (for buttons)
            rectTop.Y = panel.Top;
            rectTop.X = panel.Left;
            rectTop.Width = Convert.ToInt16(panel.Width);
            e.Graphics.FillRectangle(rectTopBrush,rectTop); 
            
            previousObjectLeft = 0; ; // button positioning help

            // buttons on top
            btnSettings.Left = panel.Right - btnSettings.Width - topcontrolsSpacing;
            btnSettings.Top = topcontrolsFromTop;
            btnSettings.Update();

            btnLogoff.Left = btnSettings.Left - btnLogoff.Width - topcontrolsSpacing;
            btnLogoff.Top = topcontrolsFromTop;

            btnLogedInAs.Left = btnLogoff.Left - btnLogedInAs.Width - topcontrolsSpacing;
            btnLogedInAs.Top = topcontrolsFromTop;
            btnLogedInAs.Text = LogedInLabelMaker();

            previousObjectLeft = btnLogedInAs.Left;
            previousObjectLeft = previousObjectLeft - 15;

            // buttons on top
            try
            {
                for (int i = btnConnected.Length - 1; i >= 1; i--)
                {
                    if (btnConnected[i] != null)
                    {
                        btnConnected[i].Left = previousObjectLeft - btnConnected[i].Width - topcontrolsSpacing;
                        topcontrolsSpacing = 5;
                        previousObjectLeft = btnConnected[i].Left;
                        rectConnName.X = btnConnected[i].Left;
                        rectConnName.Y = btnConnected[i].Bottom;
                        rectConnName.Height = btnLogedInAs.Height - btnConnected[i].Height;
                        rectConnName.Width = btnConnected[i].Width;
                        TextRenderer.DrawText(e.Graphics, btnConnected[i].Showname, Misc.MeasureString(e, rectConnName, btnConnected[i].Showname, 10, FontStyle.Bold), rectConnName, Color.White, TextFormatFlags.HorizontalCenter);

                    }
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Buttons with connection info can not be initialised properly! : "+ ex.Message);                
            }


            try
            {
                fromPaneltoElavator = rectTop.Bottom + 40; // offset for dinamic drawings

                // Containers for graphics manager
                _PanelBorders = panel.ClientRectangle;
                _PanelBorders.Inflate(-1, -1);

                // other dinamic Content
                e.Graphics.DrawRectangle(borderFormPen, _PanelBorders);
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

                _ContainerPause = ((_PanelBorders.Width - _paintXoffset +10) / StKadi) * RatioPause; // spaces between containers
                _ALLContainersWidth = (_PanelBorders.Width) - (_ContainerPause * (1.0F * (StKadi - 1) - skipPause)) - (_paintXoffset +10); // width of all containers
                _ContainerHeight = _ALLContainersWidth / SUMOFRatioPauses * RatioKad; // height of all containers
                _ContainerHeightOffset = (fromPaneltoElavator / 2.5F + ((1 / _ContainerHeight) * 250)) + (_ContainerHeight / 5);

                //limits max height of drawing
                if (_ContainerHeight > MaxHeightKad)
                {
                    dif = MaxHeightKad / _ContainerHeight;
                    _ContainerHeight = MaxHeightKad;
                    _ALLContainersWidth = _ALLContainersWidth * dif - (_paintXoffset +10);
                    _ContainerHeightOffset = (fromPaneltoElavator / 2.5F + ((1 / _ContainerHeight) * 250)) + (_ContainerHeight / 5);
                }

                // calculates custom widths
                sumOfWidthMultipliers = 0;
                for (int i = 1; i < SUMOFRatioPauses; i++)
                {
                    sumOfWidthMultipliers = sumOfWidthMultipliers + _WidthMultiplyer[i];
                }

                //calculates width to display for every container
                for (int i = 1; i < SUMOFRatioPauses; i++)
                {
                    _ContainerWidth[i] = _ALLContainersWidth / sumOfWidthMultipliers * _WidthMultiplyer[i] ;
                    if (_ContainerWidth[i] / _WidthMultiplyer[i] >= _ContainerHeight / RatioKad)
                    {
                        _ContainerWidth[i] = (_ContainerHeight / RatioKad) * _WidthMultiplyer[i];
                    }
                }

                
                // offset for drawing
                _ContainerHeightOffset2 = _ContainerHeightOffset * 2F;
                
                // custom actions for each drawing type
                _newStart = _PanelBorders.X + _paintXoffset +10+ _ContainerPause /3;
                for (int i = 1; i < SUMOFRatioPauses; i++)
                {
                    if (kadi[i].TypeOfKad == 0) // empty drawing
                    {
                        
                        _Containers[i] = new Rectangle(Misc.toInt(_newStart), Misc.toInt(_PanelBorders.Y + _ContainerHeightOffset2), Misc.toInt(_ContainerWidth[i]), Misc.toInt(_ContainerHeight));
                        _newStart = _newStart + _Containers[i].Width + _ContainerPause;
                        
                        _SubContainerHeightOffset = _Containers[i].Height / 4.5F;
                        _SubContainerHeight = (_Containers[i].Height - _SubContainerHeightOffset) * 0.97F;
                        _SubContainerY_location = _Containers[i].Y + _SubContainerHeightOffset;
                        _SubContainerWidth = (_Containers[i].Width) * 0.75F;
                        _SubContainerX_location = (_Containers[i].X) + _SubContainerWidth * 0.175F;
                        _RectBorders = new Rectangle(Misc.toInt(_SubContainerX_location), Misc.toInt(_SubContainerY_location), Misc.toInt(_SubContainerWidth), Misc.toInt(_SubContainerHeight));
                        _RectBrush = new SolidBrush(kadi[i].KadColor);
                        topOfGrapics = Misc.RectangleGetCenter(_RectBorders);

                    }

                    else if (kadi[i].TypeOfKad == 1) // normal drawing
                    {
                        if (_bordered[i])
                        {
                            HoverborderFormPen = HoverborderFormPen1;
                        }
                        else
                        {
                            HoverborderFormPen = HoverborderFormPen2;
                        }
                        _Containers[i] = new Rectangle(Misc.toInt(_newStart), Misc.toInt(_PanelBorders.Y + _ContainerHeightOffset2), Misc.toInt(_ContainerWidth[i]), Misc.toInt(_ContainerHeight));
                        e.Graphics.DrawRectangle(HoverborderFormPen, _Containers[i]);
                        _newStart = _newStart + _Containers[i].Width + _ContainerPause;

                        // fill containers with garphics

                        e.Graphics.DrawImage(KadKonstrukcija, _Containers[i]);

                        _SubContainerHeightOffset = _Containers[i].Height / 4.5F;
                        _SubContainerHeight = (_Containers[i].Height - _SubContainerHeightOffset) * 0.97F;
                        _SubContainerY_location = _Containers[i].Y + _SubContainerHeightOffset;
                        _SubContainerWidth = (_Containers[i].Width) * 0.75F;
                        _SubContainerX_location = (_Containers[i].X) + _SubContainerWidth * 0.174F;
                        _RectBorders = new Rectangle(Misc.toInt(_SubContainerX_location), Misc.toInt(_SubContainerY_location), Misc.toInt(_SubContainerWidth), Misc.toInt(_SubContainerHeight));
                        _RectBrush = new SolidBrush(kadi[i].KadColor);
                        e.Graphics.FillRectangle(_RectBrush, _RectBorders);

                        topOfGrapics = Misc.RectangleGetCenter(_RectBorders);
                        
                        bottNumGraphicRect = Misc.RectangleFromCenterPoint(topOfGrapics.X, topOfGrapics.Y, _RectBorders.Height / 2.3F, _RectBorders.Height / 2.9F);
                        font = new Font(FontFamily.GenericSansSerif, bottNumGraphicRect.Height * 0.35F, FontStyle.Bold);
                        
                        NameBrush = new SolidBrush(kadi[i].NameColor);
                        e.Graphics.DrawString(kadi[i].Showname, font, NameBrush, bottNumGraphicRect, sf);
                    }

                    else if (kadi[i].TypeOfKad == 2) // wide drawing
                    {
                        if (_bordered[i])
                        {
                            HoverborderFormPen = HoverborderFormPen1;
                        }
                        else
                        {
                            HoverborderFormPen = HoverborderFormPen2;
                        }
                        _Containers[i] = new Rectangle(Misc.toInt(_newStart), Misc.toInt(_PanelBorders.Y + _ContainerHeightOffset2), Misc.toInt(_ContainerWidth[i]), Misc.toInt(_ContainerHeight));
                        e.Graphics.DrawRectangle(HoverborderFormPen, _Containers[i]);
                        _newStart = _newStart + _Containers[i].Width + _ContainerPause;

                        // fill containers with garphics

                        e.Graphics.DrawImage(KadKonstrukcijaPosirjena, _Containers[i]);

                        _SubContainerHeightOffset = _Containers[i].Height / 4.5F;
                        _SubContainerHeight = (_Containers[i].Height - _SubContainerHeightOffset) * 0.97F;
                        _SubContainerY_location = _Containers[i].Y + _SubContainerHeightOffset;
                        _SubContainerWidth = (_Containers[i].Width) * 0.835F;
                        _SubContainerX_location = (_Containers[i].X) + _SubContainerWidth * 0.1F;
                        _RectBorders = new Rectangle(Misc.toInt(_SubContainerX_location), Misc.toInt(_SubContainerY_location), Misc.toInt(_SubContainerWidth), Misc.toInt(_SubContainerHeight));
                        _RectBrush = new SolidBrush(kadi[i].KadColor);
                        e.Graphics.FillRectangle(_RectBrush, _RectBorders);

                        topOfGrapics = Misc.RectangleGetCenter(_RectBorders);
                        
                        bottNumGraphicRect = Misc.RectangleFromCenterPoint(topOfGrapics.X, topOfGrapics.Y, _RectBorders.Height / 2.3F, _RectBorders.Height / 3F);
                        font = new Font(FontFamily.GenericSansSerif, bottNumGraphicRect.Height * 0.37F, FontStyle.Bold);

                        NameBrush = new SolidBrush(kadi[i].NameColor);
                        e.Graphics.DrawString(kadi[i].Showname, font, NameBrush, bottNumGraphicRect, sf);
                    }

                    else if (kadi[i].TypeOfKad == 3) // double drawing
                    {
                        for (int ii = 0; ii < 2; ii++)
                        {

                            _Containers[i] = new Rectangle(Misc.toInt(_newStart), Misc.toInt(_PanelBorders.Y + _ContainerHeightOffset2), Misc.toInt(_ContainerWidth[i]), Misc.toInt(_ContainerHeight));


                            if (ii == 0) { _newStart = _newStart + _Containers[i].Width + 0; }
                            if (ii == 1) { _newStart = _newStart + _Containers[i].Width + _ContainerPause; }

                            // fill containers with garphics

                            if (ii == 0) { e.Graphics.DrawImage(KadKonstrukcijaDvojnaL, _Containers[i]); }
                            if (ii == 1) { e.Graphics.DrawImage(KadKonstrukcijaDvojnaR, _Containers[i]); }

                            _SubContainerHeightOffset = _Containers[i].Height / 4.5F;
                            _SubContainerHeight = (_Containers[i].Height - _SubContainerHeightOffset) * 0.97F;
                            _SubContainerY_location = _Containers[i].Y + _SubContainerHeightOffset;

                            if (ii == 0) { _SubContainerWidth = (_Containers[i].Width) * 0.82F; }
                            if (ii == 1) { _SubContainerWidth = (_Containers[i].Width) * 0.82F; }

                            if (ii == 0) { _SubContainerX_location = (_Containers[i].X) + _SubContainerWidth * 0.160F; }
                            if (ii == 1) { _SubContainerX_location = (_Containers[i].X) + _SubContainerWidth * 0.065F; }

                            _RectBorders = new Rectangle(Misc.toInt(_SubContainerX_location), Misc.toInt(_SubContainerY_location), Misc.toInt(_SubContainerWidth), Misc.toInt(_SubContainerHeight));
                            _RectBrush = new SolidBrush(kadi[i].KadColor);
                            e.Graphics.FillRectangle(_RectBrush, _RectBorders);

                            topOfGrapics = Misc.RectangleGetCenter(_RectBorders);

                            bottNumGraphicRect = Misc.RectangleFromCenterPoint(topOfGrapics.X, topOfGrapics.Y, _RectBorders.Height / 1.3F, _RectBorders.Height / 4);
                            font = new Font(FontFamily.GenericSansSerif, bottNumGraphicRect.Height * 0.5F, FontStyle.Bold);

                            NameBrush = new SolidBrush(kadi[i].NameColor);
                            e.Graphics.DrawString(kadi[i].Showname, font, NameBrush, bottNumGraphicRect, sf);

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

                    Sarza(e, true, i);
                }
                                

                // UnderTitle rectangle with line
                _UnderTitleRect_X = _Containers[1].X - _ContainerPause / 3 - _paintXoffset;
                _UnderTitleRect_Y = _Containers[1].Y + _Containers[1].Height + (_Containers[1].Height * 0.15F);
                _UnderTitleRect_W = (_Containers[StKadi].X + _Containers[StKadi].Width - _Containers[1].X) + (_ContainerPause / 3) *2 + _paintXoffset;
                _UnderTitleRect_H = _ContainerHeight * 0.25F;

                _UnderlineRect = new Rectangle(Misc.toInt(_UnderTitleRect_X), Misc.toInt(_UnderTitleRect_Y), Misc.toInt(_UnderTitleRect_W), Misc.toInt(_UnderTitleRect_H));
                e.Graphics.FillRectangle(_UnderlineBrush, _UnderlineRect);

                // Numbers
                blackBrush = Brushes.Black;
                blackPen = new Pen(blackBrush, 3);
                tmpCenter = new Point();

                font = new Font(FontFamily.GenericSansSerif, bottNumGraphicRect.Height * 0.5F, FontStyle.Bold);
                for (int i = 1; i < SUMOFRatioPauses; i++)
                {
                    tmpCenter.X = Misc.RectangleGetCenter(_Containers[i]).X;
                    tmpCenter.Y = Misc.RectangleGetCenter(_UnderlineRect).Y;

                    _UnderlineRectString = Misc.RectangleFromCenterPoint(tmpCenter.X, tmpCenter.Y, _ContainerHeight / 3F, Misc.toInt(_UnderTitleRect_H * 0.7F));

                    e.Graphics.DrawRectangle(borderFormPen, _UnderlineRectString);
                    e.Graphics.DrawString(i.ToString(), font, blackBrush, _UnderlineRectString, sf);

                }

                // Line on the top of rectangle (below containers)   
                Point start = new Point(Misc.toInt(_UnderTitleRect_X), Misc.toInt(_UnderTitleRect_Y));
                Point end = new Point(Misc.toInt(_UnderTitleRect_X + _UnderTitleRect_W), Misc.toInt(_UnderTitleRect_Y));
                e.Graphics.DrawLine(blackPen, start, end);

                if (paintElavator)
                {
                    PaintElavator(start, end, e, elavatorHorizontalProgress);
                }

                PaintWarning(e);

            }
            catch
            {}
                   
            

            NestDatagrids();
            
            // last
            drawingInProgress = false;
        }


        //  ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ...

        //  ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ... ...

        // Sarža
        private void Sarza(PaintEventArgs e, bool Draw, int ID)
        {
            try
            {
                if (FormControl.bt1.PrisotnostSarze[ID])
                {
                    _RectBorders = new Rectangle(Misc.toInt(_SubContainerX_location), Misc.toInt(_SubContainerY_location - (_SubContainerHeight / 7)), Misc.toInt(_SubContainerWidth), Misc.toInt(_SubContainerHeight / 6));
                    _RectBrush = new SolidBrush(kadi[ID].NameColor);
                    e.Graphics.FillRectangle(_RectBrush, _RectBorders);
                }
            }
            catch  { }
            
        }


        // elavator
        private void PaintElavator(Point startElavatorLine, Point endElavatorLine, PaintEventArgs e, int progress)
        {
            if (progress > 100) { progress = 100; }
            if (progress < 0) { progress = 0; }
            

            // paint elavator line                      
            startElavatorLine = new Point(Misc.toInt(_UnderTitleRect_X), Misc.toInt(_PanelBorders.Y + fromPaneltoElavator));
            endElavatorLine = new Point(Misc.toInt(_UnderTitleRect_X + _UnderTitleRect_W), Misc.toInt(_PanelBorders.Y + fromPaneltoElavator));
            e.Graphics.DrawLine(blackPen, startElavatorLine, endElavatorLine); // Line on the top of containers 

            // Creating steps for elavator
            int elevHeight = Misc.toInt(_ContainerHeight / 5F);
            for (int i = 1; i < StKadi + 1; i++)
            {
                centers[i] = Misc.RectangleGetCenter(_Containers[i]);
                centers[i].Y = Convert.ToInt16(startElavatorLine.Y);
                elavatorRect = Misc.RectangleFromCenterPoint(centers[i].X, centers[i].Y, elevHeight / 4F, elevHeight / 4F);
                e.Graphics.FillRectangle(blackBrush, elavatorRect);
            }

            // paint elavator            
             elevatorBrush = Brushes.LightBlue;
            elevatorPen = new Pen(Brushes.Black, 2);
            xElavator = startElavatorLine.X + ((endElavatorLine.X- startElavatorLine.X - Misc.toInt(_ContainerHeight / 4F)) /100F)*progress; 
            elavator = new Rectangle(Misc.toInt(xElavator), startElavatorLine.Y - (elevHeight / 2), elevHeight, elevHeight);
            e.Graphics.FillRectangle(elevatorBrush, elavator); // paint elavator
            e.Graphics.DrawRectangle(elevatorPen, elavator);
            
        }

        private void PaintWarning(PaintEventArgs e)
        {
            
            for (int i = 1; i < kadi.Length; i++)
            {    
                warnRect.Height = _Containers[i].Height / (4);
                warnRect.Width = warnRect.Height;
                warnRect.X = _Containers[i].X + ((_Containers[i].Width/2)- warnRect.Width/2);
                warnRect.Y = (_Containers[i].Y + (_Containers[i].Height)) - warnRect.Height;
                
                if (kadi[i].warningLevel == 1)
                {
                    e.Graphics.DrawImage(warningIcon, warnRect);
                }
                else if (kadi[i].warningLevel == 2)
                {
                    e.Graphics.DrawImage(errorIcon, warnRect);
                }
                else
                {
                    // draw nothing
                }

            }
            
        }

        private void panel_Redraw(object sender, EventArgs e)
        {
            // Graphic needs to be repainted when panel size changes   
            panel.Invalidate();
            LastRedraw = DateTime.Now;
        }
        
                         
        private string LogedInLabelMaker()
        {
            var tmp = FormControl.identify.getNameOfLogedInUser();
            if (tmp == "logged off")
            {
                return "Please Log in";
            }
            else
            {
                return "Loged in: " + FormControl.identify.getNameOfLogedInUser();
            }
           
        }

        
        public static void WL_UserActions(string text, bool showToUserLog)
        {
            Int64 UserId = FormControl.identify.loggedInID;
            string UserName = FormControl.identify.logedInUserName;
            string message;

            // Log to log file
            try
            {
                message = DateTime.Now.ToString() + " - Eventlog" + ": CurrentUserID: "+ UserId +" / "+ UserName + " - "+ text;

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
        
    }

}
