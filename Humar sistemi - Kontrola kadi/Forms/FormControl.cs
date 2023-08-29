using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.Xml.Linq;
using System.Threading;

namespace KontrolaKadi
{

    public partial class FormControl : Form
    {
        public static XML_handler Xml_handler;
        public static StreamWriter sw_Main;
        public static StreamWriter sw_UserActions;
        public static Settings Form_settings;
        public static Gui[] Form_gui = new Gui[3];
        public static BackroundTasks bt1;
        public static bool Form_settings_IsShown;
        public static bool Form_gui_IsShown;
        public static Identify identify;
        public static Context con;
         public static Image backgrndImage = Properties.Resources.background_image;
        public static bool allowbttorun = false;
        public static bool LogoffModeEnabled = false;


        public FormControl(Context con_)
        {
            con = con_;
            identify = new Identify();

            // XML file load
            Xml_handler = new XML_handler();
            

            //Log file load
            string LogFilePath = "ERR";
            var a = (XML_handler.settingsXML.Element("root").Element("GENERAL").Element("logFilePath").Value.Replace("\"", ""));
            try
            {
                if (File.Exists(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("logFilePath").Value.Replace("\"", "")))
                {
                    LogFilePath = XML_handler.settingsXML.Element("root").Element("GENERAL").Element("logFilePath").Value.Replace("\"", "");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Application needs Log file to save log entries. Please provide Log file now. You can create empty *.txt file and use it for loging.");
                    OpenFileDialog d2 = new OpenFileDialog
                    {
                        Title = "Select Log file (*.txt)",
                        Filter = "TXT files (*.txt)|*.txt"
                    };


                    if (d2.ShowDialog() == DialogResult.OK)
                    {
                        if (d2.CheckFileExists)
                        {
                            LogFilePath = d2.FileName;
                            XML_handler.settingsXML.Element("root").Element("GENERAL").Element("logFilePath").Value = LogFilePath;
                            d2.Dispose();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Log file is not valid. Check path and file noted in xml configuration file: " + Properties.Settings.Default.PathXML + " Application will now close." + Environment.NewLine + " Error message: " + e.Message);
                Environment.Exit(0);
            }

            try
            {
                if (LogFilePath == "" || LogFilePath == null || LogFilePath == "ERR")
                {
                    throw new Exception();
                }
                else
                {
                    sw_Main = new StreamWriter(LogFilePath, true, Encoding.UTF8);
                    sw_Main.WriteLine(Environment.NewLine + Environment.NewLine + "Streamwriter was initialised.");
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Problem ocurded while initialising streamwriter." + Environment.NewLine + " Error message: " + e.Message + Environment.NewLine + "Application will now close.");
                Environment.Exit(0);
            }


            // UserActionsLog CsvFile load
            string UserActionsFilePath = "ERR";
            try
            {
                if (File.Exists(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("UserActionsFilePath").Value.Replace("\"", "")))
                {
                    UserActionsFilePath = XML_handler.settingsXML.Element("root").Element("GENERAL").Element("UserActionsFilePath").Value.Replace("\"", "");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Application needs UserActionsLog file to save User action entries. Please provide Log file now. You can create empty *.csv file and use it for loging.");
                    OpenFileDialog d2 = new OpenFileDialog
                    {
                        Title = "Select UserActionsLog file (*.csv)",
                        Filter = "CSV files (*.csv)|*.csv"
                    };


                    if (d2.ShowDialog() == DialogResult.OK)
                    {
                        if (d2.CheckFileExists)
                        {
                            UserActionsFilePath = d2.FileName;
                            XML_handler.settingsXML.Element("root").Element("GENERAL").Element("UserActionsFilePath").Value = UserActionsFilePath;
                            d2.Dispose();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("UserActionsLog file is not valid. Check path and file noted in xml configuration file: " + Properties.Settings.Default.PathXML + " Application will now close." + Environment.NewLine + " Error message: " + e.Message);
                Environment.Exit(0);
            }

            try
            {
                if (UserActionsFilePath == "" || UserActionsFilePath == null || UserActionsFilePath == "ERR")
                {
                    throw new Exception();
                }
                else
                {
                    sw_UserActions = new StreamWriter(UserActionsFilePath,  true, Encoding.UTF8);                   
                    sw_UserActions.WriteLine(Environment.NewLine + Environment.NewLine + DateTime.Now.ToString() + ";;;Streamwriter was initialised.");
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Problem ocurded while initialising streamwriter." + Environment.NewLine + " Error message: " + e.Message + Environment.NewLine + "Application will now close.");
                Environment.Exit(0);
            }


            // Temperature Log CsvFile load
            string TemperatureLogFilePath = "ERR";
            try
            {
                if (File.Exists(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("TemperatureLogFilePath").Value.Replace("\"", "")))
                {
                    TemperatureLogFilePath = XML_handler.settingsXML.Element("root").Element("GENERAL").Element("TemperatureLogFilePath").Value.Replace("\"", "");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Application needs Temperature Log file to save Temperature hystory entries. Please provide Log file now. You can create empty *.csv file and use it for loging.");
                    OpenFileDialog d2 = new OpenFileDialog
                    {
                        Title = "Select Temperature Log file (*.csv)",
                        Filter = "CSV files (*.csv)|*.csv"
                    };


                    if (d2.ShowDialog() == DialogResult.OK)
                    {
                        if (d2.CheckFileExists)
                        {
                            TemperatureLogFilePath = d2.FileName;
                            XML_handler.settingsXML.Element("root").Element("GENERAL").Element("TemperatureLogFilePath").Value = TemperatureLogFilePath;
                            d2.Dispose();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("TemperatureLogFilePath file is not valid. Check path and file noted in xml configuration file: " + Properties.Settings.Default.PathXML + " Application will now close." + Environment.NewLine + " Error message: " + e.Message);
                Environment.Exit(0);
            }


            // Sarza Log Folder
            string SarzaLogFolderPath = "ERR";
            try
            {
                if (Directory.Exists(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("SarzaLogFolderPath").Value.Replace("\"", "")))
                {
                    SarzaLogFolderPath = XML_handler.settingsXML.Element("root").Element("GENERAL").Element("SarzaLogFolderPath").Value.Replace("\"", "");
                }
                else
                {                    
                    LogMaker.SarzaOrientedLog.doesPathExsist(SarzaLogFolderPath);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("SarzaLogFolderPath file is not valid. Check path noted in xml configuration file: " + Properties.Settings.Default.PathXML + " Application will now close." + Environment.NewLine + " Error message: " + e.Message);
                Environment.Exit(0);
            }

            InitializeComponent();

            XML_handler.settingsXML.Save(Properties.Settings.Default.PathXML);
        }

        private void ShowOnMonitor(int monitor, Gui gui)
        {
            Screen[] screens = Screen.AllScreens;

            var screen = GetScreen(monitor);
            var currentScreen = GetCurrentScreen(gui);
            gui.WindowState = FormWindowState.Maximized;
            gui.Left = screen.WorkingArea.Left;
            gui.Top = screen.WorkingArea.Top;
            gui.Width = screen.WorkingArea.Width;
            gui.Height = screen.WorkingArea.Height;
        }

        public static Screen GetCurrentScreen(Gui window)
        {
            var parentArea = new Rectangle(window.Left, window.Top, window.Width, window.Height);
            return Screen.FromRectangle(parentArea);
        }

        public static Screen GetScreen(int requestedScreen)
        {
            var screens = Screen.AllScreens;
            var mainScreen = 0;
            if (screens.Length > 1 && mainScreen < screens.Length)
            {
                return screens[requestedScreen];
            }
            return screens[0];
        }


        public static void HideForm_Settings()
        {
            HideForm(Form_settings);
        }

        public static void ShowForm_Settings()
        {
            Form_settings.Visible = true;
        }

        public static void HideForm_Gui()
        {
            HideForm(Form_gui, true);
        }

        public static void HideForm_Gui(bool exitApp)
        {
            if (!exitApp)
            {
                HideForm(Form_gui, exitApp);
            }
            
        }

        public static void ShowForm_Gui()
        {
            Form_gui[1].Visible = true;
            Form_gui[2].Visible = true;
        }

        public static void ShowForm_Gui(int gui_id)
        {
            if (gui_id == 1)
            {
                Form_gui[1].Visible = true;
            }
            if (gui_id == 2)
            {
                Form_gui[2].Visible = true;
            }            
        }

        public static void ExitApp(Form[] WhitchFormAreYouHiding)
        {

            if (System.Windows.Forms.MessageBox.Show(Form_gui[1], "Do you realy want to quit application?", "Quit application?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                for (int i = 1; i < WhitchFormAreYouHiding.Length; i++)
                {
                    WhitchFormAreYouHiding[i].Visible = false;
                }
                CloseApp_Preparation();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Environment.Exit(0);
            }
            else
            {
                for (int i = 1; i < WhitchFormAreYouHiding.Length; i++)
                {
                    WhitchFormAreYouHiding[i].Visible = true;
                }
            }

        }

        public static void ExitApp(Form WhitchFormAreYouHiding)
        {

            if (System.Windows.Forms.MessageBox.Show(Form_gui[1], "Do you realy want to quit application?", "Quit application?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                WhitchFormAreYouHiding.Visible = false;

                FormControl.CloseApp_Preparation();
                Environment.Exit(0);
            }
            else
            {

                WhitchFormAreYouHiding.Visible = true;

            }

        }

        public static void HideForm(Form[] WhitchFormAreYouHiding, bool exitapp)
        {
            int cnt = 0;
            for (int i = 1; i < WhitchFormAreYouHiding.Length; i++)
            {
                WhitchFormAreYouHiding[i].Visible = false;
            }
            if (Form_settings.Visible) { cnt++; }

            for (int i = 1; i < Form_gui.Length; i++)
            {
                if (Form_gui[i].Visible) { cnt++; }
            }

            if (cnt <= 0 && exitapp)
            {
                ExitApp(WhitchFormAreYouHiding);
            }
        }

        public static void HideForm(Form WhitchFormAreYouHiding)
        {
            if (FormControl.con.Restart)
            {
                return;
            }

            int cnt = 0;

            WhitchFormAreYouHiding.Visible = false;

            if (Form_settings.Visible) { cnt++; }

            for (int i = 1; i < Form_gui.Length; i++)
            {
                if (Form_gui[i].Visible) { cnt++; }
            }

            if (cnt <= 0)
            {
                ExitApp(WhitchFormAreYouHiding);
            }
        }


        public void Starter_DoWork()
        {
            Invoke(new MethodInvoker(delegate { this.progressBar1.Value = 5; }));
             System.Windows.Forms.Application.DoEvents();

            // forms init

            try
            {
                Form_settings = new Settings();


            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Settings were not initialised: " + ex);
                System.Windows.Forms.MessageBox.Show("ERROR: Settings were not initialised: " + ex);
            }


            Invoke(new MethodInvoker(delegate { this.progressBar1.Value = 10; }));
            System.Windows.Forms.Application.DoEvents();

            try
            {

                if (File.Exists(Properties.Settings.Default.PathXML))
                {
                    XML_handler.settingsXML = XDocument.Load(Properties.Settings.Default.PathXML);
                }
                else
                {
                    throw new Exception("XML file is not valid!");
                }


                try
                {
                    bt1 = new BackroundTasks(XML_handler.settingsXML)
                    {
                        Settings = Form_settings
                    };
                    bt1.StartBackgroundTasks();
                    bt1.WL("Settings form and background tasks were initialised ", 0);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error has ocurded while trying to start background tasks: " + ex.Message + " Application will now close!");
                    Environment.Exit(0);
                }

                Form_settings.SettingsAfterjobs();

                Invoke(new MethodInvoker(delegate { this.progressBar1.Value = 20; }));
                System.Windows.Forms.Application.DoEvents();

                Form_gui[1] = new Gui(XML_handler.settingsXML, 1) { FormControl = this };
                Invoke(new MethodInvoker(delegate { this.progressBar1.Value = 40; }));
                System.Windows.Forms.Application.DoEvents();

                Form_gui[2] = new Gui(XML_handler.settingsXML, 2) { FormControl = this };

                bt1.WL("GUI was initialised", 0);

                Invoke(new MethodInvoker(delegate { this.progressBar1.Value = 50; }));
                System.Windows.Forms.Application.DoEvents();

                ShowOnMonitor(0, Form_gui[1]);
                ShowOnMonitor(1, Form_gui[2]);

                bt1.Gui[1] = Form_gui[1];
                bt1.Gui[2] = Form_gui[2];

            }
            catch (Exception ex)
            {
                bt1.WL("GUI was not initialised properly: " + ex.Message, -2);
                System.Windows.Forms.MessageBox.Show("GUI was not initialised properly. Application will now close: " + ex.Message);
                Environment.Exit(0);
            }

           

            System.Windows.Forms.Application.DoEvents();
            Invoke(new MethodInvoker(delegate { this.progressBar1.Value = 70; }));
            System.Windows.Forms.Application.DoEvents();
            identify.Logoff();
            while (true)
            {
                if (identify.GetPermision(1))
                {
                    break;
                }
                else
                {
                    while (true)
                    {
                        identify.ShowIDDialog();
                        if (identify.GetPermision(1))
                        {
                            break;
                        }
                        identify.ShowPermissionError();
                    }
                }

            }
            Form_settings.Show();
            Form_gui[1].Show();
            Form_gui[2].Show();
            Form_settings.Hide();
            Invoke(new MethodInvoker(delegate { TopMost = true; }));
                                      
                Invoke(new MethodInvoker(delegate { this.progressBar1.Value+=5; }));
                System.Windows.Forms.Application.DoEvents();
           

            Invoke(new MethodInvoker(delegate { this.progressBar1.Value = 90; }));
            
              
               
            bt1.Prop1.UpdatePowerConsumption.Start();
            allowbttorun = true;            

            Thread clsSplsh = new Thread(closeSplash);
            clsSplsh.Start();

            bt1.InitialisationComplete = true;

            System.Windows.Forms.Application.Run();
        }

        private void closeSplash()
        {
            Thread.Sleep(100);
            System.Windows.Forms.Application.DoEvents();
            Thread.Sleep(100);
            Invoke(new MethodInvoker(delegate { this.progressBar1.Value = 100; }));
            System.Windows.Forms.Application.DoEvents();
            Thread.Sleep(500);
            Invoke(new MethodInvoker(delegate { this.Hide(); }));// Hide spalshscrreen   
        }

        private void FormControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public static void CloseApp_Preparation()
        {
            Gui.WL_UserAction("Application is exiting", true);

            sw_Main.Flush();
            sw_Main.Close();

            sw_UserActions.Flush();
            sw_UserActions.Close();

            //settingsXML.Save(Form_settings.textBoxPathXML.Text);
                        
            con.Restart = true;
            con.ExitThread();
           
        }

    }
}
