using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Sharp7;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Threading;

namespace KontrolaKadi
{


    public partial class Settings : Form
    {

        /*

       BLOCK	VM ADDRESS START	VM ADDRESS END	FIELD LENGTH (BYTE)
       I	        1024	        1031	            8
       AI	        1032	        1063	            32
       Q	        1064	        1071	            8
       AQ	        1072	        1103	            32
       M	        1104	        1117	            14
       AM	        1118	        1245	            128
       NI	        1246	        1261	            16
       NAI     	1262	        1389	            128
       NQ	        1390	        1405	            16
       NAQ	        1406	        1469	            64

      */




        public static bool FormMustBeHidden = false;

        public bool restart = false;

        
        public int WatchdogRetries = 1;


        public Settings()
        {

            
            
            try
            {
                InitializeComponent();                
                Show();
                Hide();

                textBoxPathXML.Text = XML_handler.Path;
                this.Icon = Properties.Resources.oa;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            
        }


        // Browse button XML

        private void ButtonBrowseXML_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ShowDialog1));
            t.Name = "BrowseXML Thread";
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }

        // path to XML changed
        private void TextBoxPathXML_TextChanged(object sender, EventArgs e)
        {
           
        }

        // Reload button XML
        private void ButtonReloadXML_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #region CheckBoxLOGO_EN_CheckedChanged

        private void CheckBoxLOGO_EN1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN1.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO1").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO1").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();

            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 1, textBoxPathLOG.Text);
            }

        }

        private void CheckBoxLOGO_EN2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN2.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO2").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO2").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 2, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN3.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO3").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO3").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 3, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN4.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO4").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO4").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 4, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN5.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO5").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO5").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 5, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN6.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO6").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO6").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 6, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN7_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN7.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO7").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO7").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 7, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN8.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO8").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO8").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 8, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN9_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN9.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO9").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO9").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 9, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN10_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN10.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO10").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO10").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 10, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN11_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN11.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO11").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO11").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 11, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN12_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN12.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO12").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO12").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 12, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN13_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN13.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO13").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO13").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 13, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN14_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN14.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO14").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO14").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 14, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN15_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN15.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO15").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO15").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 15, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN16_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN16.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO16").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO16").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 16, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN17_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN17.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO17").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO17").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 17, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN18_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN18.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO18").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO18").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 18, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN19_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN19.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO19").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO19").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 19, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxLOGO_EN20_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxLOGO_EN20.Checked)
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO20").Element("enabled").SetValue("true");
                }
                else
                {
                    XML_handler.settingsXML.Element("root").Element("LOGO20").Element("enabled").SetValue("false");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 20, textBoxPathLOG.Text);
            }
        }


        #endregion CheckBoxLOGO_EN_CheckedChanged

        #region btnConnect

        private void BtnConnectLOGO1_Click(object sender, EventArgs e)
        {
            ConnectAsync(1);
        }


        private void BtnConnectLOGO2_Click(object sender, EventArgs e)
        {
            ConnectAsync(2);
        }

        private void BtnConnectLOGO3_Click(object sender, EventArgs e)
        {
            ConnectAsync(3);
        }

        private void BtnConnectLOGO4_Click(object sender, EventArgs e)
        {
            ConnectAsync(4);
        }

        private void BtnConnectLOGO5_Click(object sender, EventArgs e)
        {
            ConnectAsync(5);
        }

        private void BtnConnectLOGO6_Click(object sender, EventArgs e)
        {
            ConnectAsync(6);
        }

        private void BtnConnectLOGO7_Click(object sender, EventArgs e)
        {
            ConnectAsync(7);
        }

        private void BtnConnectLOGO8_Click(object sender, EventArgs e)
        {
            ConnectAsync(8);
        }

        private void BtnConnectLOGO9_Click(object sender, EventArgs e)
        {
            ConnectAsync(9);
        }

        private void BtnConnectLOGO10_Click(object sender, EventArgs e)
        {
            ConnectAsync(10);
        }

        private void BtnConnectLOGO11_Click(object sender, EventArgs e)
        {
            ConnectAsync(11);
        }

        private void BtnConnectLOGO12_Click(object sender, EventArgs e)
        {
            ConnectAsync(12);
        }

        private void BtnConnectLOGO13_Click(object sender, EventArgs e)
        {
            ConnectAsync(13);
        }

        private void BtnConnectLOGO14_Click(object sender, EventArgs e)
        {
            ConnectAsync(14);
        }

        private void BtnConnectLOGO15_Click(object sender, EventArgs e)
        {
            ConnectAsync(15);
        }

        private void BtnConnectLOGO16_Click(object sender, EventArgs e)
        {
            ConnectAsync(16);
        }

        private void BtnConnectLOGO17_Click(object sender, EventArgs e)
        {
            ConnectAsync(17);
        }

        private void BtnConnectLOGO18_Click(object sender, EventArgs e)
        {
            ConnectAsync(18);
        }

        private void BtnConnectLOGO19_Click(object sender, EventArgs e)
        {
            ConnectAsync(19);
        }

        private void BtnConnectLOGO20_Click(object sender, EventArgs e)
        {
            ConnectAsync(20);
        }


        #endregion btnConnect

        #region btnDisconnect

        private void BtnDisconnectLOGO1_Click(object sender, EventArgs e)
        {
            DisconnectAsync(1);
        }
        private void BtnDisconnectLOGO2_Click(object sender, EventArgs e)
        {
            DisconnectAsync(2);
        }
        private void BtnDisconnectLOGO3_Click(object sender, EventArgs e)
        {
            DisconnectAsync(3);
        }
        private void BtnDisconnectLOGO4_Click(object sender, EventArgs e)
        {
            DisconnectAsync(4);
        }
        private void BtnDisconnectLOGO5_Click(object sender, EventArgs e)
        {
            DisconnectAsync(5);
        }
        private void BtnDisconnectLOGO6_Click(object sender, EventArgs e)
        {
            DisconnectAsync(6);
        }
        private void BtnDisconnectLOGO7_Click(object sender, EventArgs e)
        {
            DisconnectAsync(7);
        }
        private void BtnDisconnectLOGO8_Click(object sender, EventArgs e)
        {
            DisconnectAsync(8);
        }
        private void BtnDisconnectLOGO9_Click(object sender, EventArgs e)
        {
            DisconnectAsync(9);
        }
        private void BtnDisconnectLOGO10_Click(object sender, EventArgs e)
        {
            DisconnectAsync(10);
        }
        private void BtnDisconnectLOGO11_Click(object sender, EventArgs e)
        {
            DisconnectAsync(11);
        }
        private void BtnDisconnectLOGO12_Click(object sender, EventArgs e)
        {
            DisconnectAsync(12);
        }
        private void BtnDisconnectLOGO13_Click(object sender, EventArgs e)
        {
            DisconnectAsync(13);
        }
        private void BtnDisconnectLOGO14_Click(object sender, EventArgs e)
        {
            DisconnectAsync(14);
        }
        private void BtnDisconnectLOGO15_Click(object sender, EventArgs e)
        {
            DisconnectAsync(15);
        }
        private void BtnDisconnectLOGO16_Click(object sender, EventArgs e)
        {
            DisconnectAsync(16);
        }
        private void BtnDisconnectLOGO17_Click(object sender, EventArgs e)
        {
            DisconnectAsync(17);
        }
        private void BtnDisconnectLOGO18_Click(object sender, EventArgs e)
        {
            DisconnectAsync(18);
        }
        private void BtnDisconnectLOGO19_Click(object sender, EventArgs e)
        {
            DisconnectAsync(19);
        }
        private void BtnDisconnectLOGO20_Click(object sender, EventArgs e)
        {
            DisconnectAsync(20);
        }

        #endregion btnDisconnect

        #region ENWatchdog

        private void CheckBoxWatchdogENLOGO1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO1").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO1.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 1, textBoxPathLOG.Text);
            }

        }

        private void CheckBoxWatchdogENLOGO2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO2").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO2.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 2, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO3").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO3.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 3, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO4").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO4.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 4, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO5").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO5.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 5, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO6").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO6.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 6, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO7_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO7").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO7.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 7, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO8").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO8.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 8, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO9_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO9").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO9.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 9, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO10_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO10").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO10.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 10, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO11_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO11").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO11.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 11, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO12_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO12").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO12.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 12, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO13_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO13").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO13.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 13, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO14_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO14").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO14.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 14, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO15_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO15").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO15.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 15, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO16_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO16").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO16.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 16, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO17_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO17").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO17.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 17, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO18_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO18").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO18.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 18, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO19_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO19").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO19.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 19, textBoxPathLOG.Text);
            }
        }

        private void CheckBoxWatchdogENLOGO20_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XML_handler.settingsXML.Element("root").Element("LOGO20").Element("watchdogEN").SetValue(CheckBoxWatchdogENLOGO20.Checked);
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 20, textBoxPathLOG.Text);
            }
        }


        #endregion ENWatchdog

        #region AddressWatchdog


        private void TextBoxWatchdogAddressLOGO1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO1").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO1.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 1, textBoxPathLOG.Text);
            }

        }

        private void TextBoxWatchdogAddressLOGO2_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO2").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO2.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 2, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO3_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO3").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO3.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 3, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO4_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO4").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO4.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 4, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO5_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO5").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO5.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 5, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO6_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO6").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO6.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 6, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO7_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO7").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO7.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 7, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO8_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO8").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO8.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 8, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO9_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO9").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO9.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 9, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO10_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO10").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO10.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 10, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO11_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO11").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO11.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 11, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO12_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO12").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO12.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 12, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO13_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO13").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO13.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 13, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO14_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO14").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO14.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 14, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO15_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO15").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO15.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 15, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO16_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO16").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO16.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 16, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO17_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO17").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO17.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 17, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO18_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO18").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO18.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 18, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO19_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO19").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO19.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 19, textBoxPathLOG.Text);
            }
        }

        private void TextBoxWatchdogAddressLOGO20_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO20").Element("watchdogAddress").SetValue(TextBoxWatchdogAddressLOGO20.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {

                WL("Error while changing settings - XML file entry is corupted (entry: LOGO watchdogEN): " + ex.Message, 20, textBoxPathLOG.Text);
            }
        }


        #endregion

        #region RWcycle        

        private void TextBoxRWcycLOGO1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO1").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO1.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex ) { WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 1, textBoxPathLOG.Text); }
        }


        private void TextBoxRWcycLOGO2_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO2").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO2.Text);
               XML_handler.SaveXML();

                FormControl.Form_settings.TextBoxRWcycLOGO2.Text = TextBoxRWcycLOGO2.Text;
            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 2, textBoxPathLOG.Text); }


        }

        private void TextBoxRWcycLOGO3_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO3").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO3.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 3, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO4_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO4").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO4.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 4, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO5_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO5").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO5.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 5, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO6_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO6").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO6.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 6, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO7_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO7").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO7.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 7, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO8_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO8").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO8.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 8, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO9_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO9").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO9.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 9, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO10_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO10").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO10.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 10, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO11_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO11").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO11.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 11, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO12_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO12").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO12.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 12, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO13_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO13").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO13.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 13, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO14_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO14").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO14.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 14, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO15_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO15").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO15.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 15, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO16_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO16").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO16.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 16, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO17_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO17").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO17.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 17, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO18_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO18").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO18.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 18, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO19_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO19").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO19.Text);
               XML_handler.SaveXML();


            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 19, textBoxPathLOG.Text); }
        }

        private void TextBoxRWcycLOGO20_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("LOGO20").Element("ReadWriteCycle").SetValue(TextBoxRWcycLOGO20.Text);
               XML_handler.SaveXML();
                
            }
            catch (Exception ex){ WL("Error while changing settings - XML file entry is corupted (entry: LOGO enabled): " + ex.Message, 20, textBoxPathLOG.Text); }


        }




        #endregion

        // button open XML
        private void ButtonOpenXML_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(textBoxPathXML.Text);
                WL("XML file was opend", 0, textBoxPathLOG.Text);
            }
            catch (Exception ex)
            {
                WL("Can not open XML File - check that path is valid or that file exists: " + ex.Message, -1, textBoxPathLOG.Text);
            }
        }

        // Browse button LOG
        public void ButtonBrowseLOG_Click(object sender, EventArgs e)
        {

            Thread t = new Thread(new ThreadStart(ShowDialog2));
            t.Name = "BrowseLOG Thread";
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }

        // button open LOG
        private void ButtonOpenLOG_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(textBoxPathLOG.Text);
                WL("Log file was opend", 0, textBoxPathLOG.Text);
            }
            catch (Exception ex)
            {
                WL("Can not open Log File - check that path is valid or that file exists: " + ex.Message, -1, textBoxPathLOG.Text);
            }
        }

        // path to LOG changed
        private void TextBoxPathLOG_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("GENERAL").Element("logFilePath").SetValue(textBoxPathLOG.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                var message = "Error writing logFilePath to XML file: ";
                MessageBox.Show(message + ex.Message);
                WL(message + ex.Message, -1, textBoxPathLOG.Text);
            }

        }

        // Browse button User Actions LOG
        public void ButtonBrowseUALOG_Click(object sender, EventArgs e)
        {

            Thread t = new Thread(new ThreadStart(ShowDialog3));
            t.Name = "BrowseUserActionsLOG Thread";
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }

        // button open User Actions LOG
        private void ButtonOpenUALOG_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(textBoxPathUALOG.Text);
                WL("User Actions Log file was opend", 0, textBoxPathUALOG.Text);
            }
            catch (Exception ex)
            {
                WL("Can not open User Actions Log File - check that path is valid or that file exists: " + ex.Message, -1, textBoxPathUALOG.Text);
            }
        }

        // path to User Actions LOG changed
        private void TextBoxPathUALOG_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("GENERAL").Element("UserActionsFilePath").SetValue(textBoxPathUALOG.Text);
               XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                var message = "Error writing UserActionsFilePath to XML file: ";
                MessageBox.Show(message + ex.Message);
                WL(message + ex.Message, -1, textBoxPathLOG.Text);
            }
        }

        // button open Temperature LOG
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(textBoxPathTemperatureLog.Text);
                WL("User Actions Log file was opend", 0, textBoxPathTemperatureLog.Text);
            }
            catch (Exception ex)
            {
                WL("Can not open Temperature Log File - check that path is valid or that file exists: " + ex.Message, -1, textBoxPathTemperatureLog.Text);
            }
        }

        // Browse button Temperatures LOG
        private void button3_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ShowDialog3));
            t.Name = "BrowseTemperatureLOG Thread";
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }
        // path to Temperature LOG changed
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               XML_handler.settingsXML.Element("root").Element("GENERAL").Element("TemperatureLogFilePath").SetValue(textBoxPathTemperatureLog.Text);
               XML_handler.SaveXML();
                
            }
            catch (Exception ex)
            {
                var message = "Error writing TemperatureLogFilePath to XML file: ";
                MessageBox.Show(message + ex.Message);
                WL(message + ex.Message, -1, textBoxPathLOG.Text);
            }
        }


        // button connect all
        private void ButtonConnectALL_Click(object sender, EventArgs e)
        {
            bool skip = false;
            if (sender != null)
            {
                if (sender.GetType().Equals(typeof(string)))
                {
                    string sender_ = (string)sender;
                    if (sender_ == "Skip UpdateFieldsXML")
                    {
                        skip = true;
                    }
                }
            }

            if (!skip)
            {
                UpdateFieldsXML(); // do not update if bool sender is true
            }
            object device = new object[1];

            if (CheckBoxLOGO_EN1.Checked) { BtnConnectLOGO1_Click(device = (int)1, null); }
            if (CheckBoxLOGO_EN2.Checked) { BtnConnectLOGO2_Click(device = (int)2, null); }
            if (CheckBoxLOGO_EN3.Checked) { BtnConnectLOGO3_Click(device = (int)3, null); }
            if (CheckBoxLOGO_EN4.Checked) { BtnConnectLOGO4_Click(device = (int)4, null); }
            if (CheckBoxLOGO_EN5.Checked) { BtnConnectLOGO5_Click(device = (int)5, null); }
            if (CheckBoxLOGO_EN6.Checked) { BtnConnectLOGO6_Click(device = (int)6, null); }
            if (CheckBoxLOGO_EN7.Checked) { BtnConnectLOGO7_Click(device = (int)7, null); }
            if (CheckBoxLOGO_EN8.Checked) { BtnConnectLOGO8_Click(device = (int)8, null); }
            if (CheckBoxLOGO_EN9.Checked) { BtnConnectLOGO9_Click(device = (int)9, null); }
            if (CheckBoxLOGO_EN10.Checked) { BtnConnectLOGO10_Click(device = (int)10, null); }
            if (CheckBoxLOGO_EN11.Checked) { BtnConnectLOGO11_Click(device = (int)11, null); }
            if (CheckBoxLOGO_EN12.Checked) { BtnConnectLOGO12_Click(device = (int)12, null); }
            if (CheckBoxLOGO_EN13.Checked) { BtnConnectLOGO13_Click(device = (int)13, null); }
            if (CheckBoxLOGO_EN14.Checked) { BtnConnectLOGO14_Click(device = (int)14, null); }
            if (CheckBoxLOGO_EN15.Checked) { BtnConnectLOGO15_Click(device = (int)15, null); }
            if (CheckBoxLOGO_EN16.Checked) { BtnConnectLOGO16_Click(device = (int)16, null); }
            if (CheckBoxLOGO_EN17.Checked) { BtnConnectLOGO17_Click(device = (int)17, null); }
            if (CheckBoxLOGO_EN18.Checked) { BtnConnectLOGO18_Click(device = (int)18, null); }
            if (CheckBoxLOGO_EN19.Checked) { BtnConnectLOGO19_Click(device = (int)19, null); }
            if (CheckBoxLOGO_EN20.Checked) { BtnConnectLOGO20_Click(device = (int)20, null); }
        }

        // button disconnect all
        public void ButtonDisconnectALL_Click(object sender, EventArgs e)
        {
            if (CheckBoxLOGO_EN1.Checked) { BtnDisconnectLOGO1_Click(null, null); }
            if (CheckBoxLOGO_EN2.Checked) { BtnDisconnectLOGO2_Click(null, null); }
            if (CheckBoxLOGO_EN3.Checked) { BtnDisconnectLOGO3_Click(null, null); }
            if (CheckBoxLOGO_EN4.Checked) { BtnDisconnectLOGO4_Click(null, null); }
            if (CheckBoxLOGO_EN5.Checked) { BtnDisconnectLOGO5_Click(null, null); }
            if (CheckBoxLOGO_EN6.Checked) { BtnDisconnectLOGO6_Click(null, null); }
            if (CheckBoxLOGO_EN7.Checked) { BtnDisconnectLOGO7_Click(null, null); }
            if (CheckBoxLOGO_EN8.Checked) { BtnDisconnectLOGO8_Click(null, null); }
            if (CheckBoxLOGO_EN9.Checked) { BtnDisconnectLOGO9_Click(null, null); }
            if (CheckBoxLOGO_EN10.Checked) { BtnDisconnectLOGO10_Click(null, null); }
            if (CheckBoxLOGO_EN11.Checked) { BtnDisconnectLOGO11_Click(null, null); }
            if (CheckBoxLOGO_EN12.Checked) { BtnDisconnectLOGO12_Click(null, null); }
            if (CheckBoxLOGO_EN13.Checked) { BtnDisconnectLOGO13_Click(null, null); }
            if (CheckBoxLOGO_EN14.Checked) { BtnDisconnectLOGO14_Click(null, null); }
            if (CheckBoxLOGO_EN15.Checked) { BtnDisconnectLOGO15_Click(null, null); }
            if (CheckBoxLOGO_EN16.Checked) { BtnDisconnectLOGO16_Click(null, null); }
            if (CheckBoxLOGO_EN17.Checked) { BtnDisconnectLOGO17_Click(null, null); }
            if (CheckBoxLOGO_EN18.Checked) { BtnDisconnectLOGO18_Click(null, null); }
            if (CheckBoxLOGO_EN19.Checked) { BtnDisconnectLOGO19_Click(null, null); }
            if (CheckBoxLOGO_EN20.Checked) { BtnDisconnectLOGO20_Click(null, null); }
        }

        private void CheckBoxAutoconnect_CheckedChanged(object sender, EventArgs e)
        {
           XML_handler.settingsXML.Element("root").Element("GENERAL").Element("AutoConnect").SetValue(checkBoxAutoconnect.Checked.ToString());
           XML_handler.SaveXML();
        }


        // after form shows up
        // after form shows up
        // after form shows up
        public void SettingsAfterjobs()
        {

            FormControl.Form_settings.TextBoxWatchdogAddressLOGO1 = TextBoxWatchdogAddressLOGO1;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO2 = TextBoxWatchdogAddressLOGO2;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO3 = TextBoxWatchdogAddressLOGO3;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO4 = TextBoxWatchdogAddressLOGO4;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO5 = TextBoxWatchdogAddressLOGO5;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO6 = TextBoxWatchdogAddressLOGO6;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO7 = TextBoxWatchdogAddressLOGO7;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO8 = TextBoxWatchdogAddressLOGO8;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO9 = TextBoxWatchdogAddressLOGO9;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO10 = TextBoxWatchdogAddressLOGO10;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO11 = TextBoxWatchdogAddressLOGO11;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO12 = TextBoxWatchdogAddressLOGO12;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO13 = TextBoxWatchdogAddressLOGO13;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO14 = TextBoxWatchdogAddressLOGO14;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO15 = TextBoxWatchdogAddressLOGO15;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO16 = TextBoxWatchdogAddressLOGO16;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO17 = TextBoxWatchdogAddressLOGO17;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO18 = TextBoxWatchdogAddressLOGO18;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO19 = TextBoxWatchdogAddressLOGO19;
            FormControl.Form_settings.TextBoxWatchdogAddressLOGO20 = TextBoxWatchdogAddressLOGO20;

            textBoxPathXML.Text = XML_handler.Path;

            // log file
            try
            {
                textBoxPathLOG.Text =XML_handler.settingsXML.Element("root").Element("GENERAL").Element("logFilePath").Value;
            }

            catch
            {
                MessageBox.Show("Error reading path to Log file from XML. Please provide valid LOG file (or path). Application will now close. ");
                Environment.Exit(0);
            }

            // user actions log file
            try
            {
                textBoxPathUALOG.Text =XML_handler.settingsXML.Element("root").Element("GENERAL").Element("UserActionsFilePath").Value;
            }

            catch
            {
                MessageBox.Show("Error reading path to User Actions Log file from XML. Please provide valid LOG file (or path). Application will now close. ");
                Environment.Exit(0);
            }

            // temperature log file
            try
            {
                textBoxPathTemperatureLog.Text =XML_handler.settingsXML.Element("root").Element("GENERAL").Element("TemperatureLogFilePath").Value;
            }

            catch
            {
                MessageBox.Show("Error reading path to Temperature log file from XML. Please provide valid CSV file (or path). Application will now close. ");
                Environment.Exit(0);
            }

            // show devices
            try
            {
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO1").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO1); CheckBoxLOGO_EN1.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO2").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO2); CheckBoxLOGO_EN2.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO3").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO3); CheckBoxLOGO_EN3.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO4").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO4); CheckBoxLOGO_EN4.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO5").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO5); CheckBoxLOGO_EN5.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO6").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO6); CheckBoxLOGO_EN6.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO7").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO7); CheckBoxLOGO_EN7.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO8").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO8); CheckBoxLOGO_EN8.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO9").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO9); CheckBoxLOGO_EN9.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO10").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO10); CheckBoxLOGO_EN10.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO11").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO11); CheckBoxLOGO_EN11.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO12").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO12); CheckBoxLOGO_EN12.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO13").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO13); CheckBoxLOGO_EN13.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO14").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO14); CheckBoxLOGO_EN14.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO15").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO15); CheckBoxLOGO_EN15.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO16").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO16); CheckBoxLOGO_EN16.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO17").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO17); CheckBoxLOGO_EN17.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO18").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO18); CheckBoxLOGO_EN18.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO19").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO19); CheckBoxLOGO_EN19.Hide(); }
                if (!Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("LOGO20").Element("show").Value)) { tabControl1.TabPages.Remove(tabPageLOGO20); CheckBoxLOGO_EN20.Hide(); }


                WL("GUI was loaded successfully", 0, textBoxPathLOG.Text);
            }
            catch (Exception ex)
            {
                WL("Error while loading GUI - XML file entry is corupted (show): " + ex.Message, -1, textBoxPathLOG.Text);
            }

            try
            {
                WatchdogRetries = int.Parse(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("WatchdogRetries").Value);
            }
            catch (Exception ex)
            {
                WL("Error while loading configuration - XML file entry is corupted (WatchdogRetries): " + ex.Message, -1, textBoxPathLOG.Text);
            }
                        
            
            // Load Values to FormControl.bt1
            FormControl.bt1.WatchdogRetries = WatchdogRetries;

            #region Load Values to bt



            textBoxDeviceIPLOGO1.Text =XML_handler.settingsXML.Element("root").Element("LOGO1").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO2.Text =XML_handler.settingsXML.Element("root").Element("LOGO2").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO3.Text =XML_handler.settingsXML.Element("root").Element("LOGO3").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO4.Text =XML_handler.settingsXML.Element("root").Element("LOGO4").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO5.Text =XML_handler.settingsXML.Element("root").Element("LOGO5").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO6.Text =XML_handler.settingsXML.Element("root").Element("LOGO6").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO7.Text =XML_handler.settingsXML.Element("root").Element("LOGO7").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO8.Text =XML_handler.settingsXML.Element("root").Element("LOGO8").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO9.Text =XML_handler.settingsXML.Element("root").Element("LOGO9").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO10.Text =XML_handler.settingsXML.Element("root").Element("LOGO10").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO11.Text =XML_handler.settingsXML.Element("root").Element("LOGO11").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO12.Text =XML_handler.settingsXML.Element("root").Element("LOGO12").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO13.Text =XML_handler.settingsXML.Element("root").Element("LOGO13").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO14.Text =XML_handler.settingsXML.Element("root").Element("LOGO14").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO15.Text =XML_handler.settingsXML.Element("root").Element("LOGO15").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO16.Text =XML_handler.settingsXML.Element("root").Element("LOGO16").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO17.Text =XML_handler.settingsXML.Element("root").Element("LOGO17").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO18.Text =XML_handler.settingsXML.Element("root").Element("LOGO18").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO19.Text =XML_handler.settingsXML.Element("root").Element("LOGO19").Element("serverIP").Value.Replace("\"", "");
            textBoxDeviceIPLOGO20.Text =XML_handler.settingsXML.Element("root").Element("LOGO20").Element("serverIP").Value.Replace("\"", "");




            FormControl.bt1.WatchdogEnabled[1] = CheckBoxWatchdogENLOGO1.Checked;
            FormControl.bt1.WatchdogEnabled[2] = CheckBoxWatchdogENLOGO2.Checked;
            FormControl.bt1.WatchdogEnabled[3] = CheckBoxWatchdogENLOGO3.Checked;
            FormControl.bt1.WatchdogEnabled[4] = CheckBoxWatchdogENLOGO4.Checked;
            FormControl.bt1.WatchdogEnabled[5] = CheckBoxWatchdogENLOGO5.Checked;
            FormControl.bt1.WatchdogEnabled[6] = CheckBoxWatchdogENLOGO6.Checked;
            FormControl.bt1.WatchdogEnabled[7] = CheckBoxWatchdogENLOGO7.Checked;
            FormControl.bt1.WatchdogEnabled[8] = CheckBoxWatchdogENLOGO8.Checked;
            FormControl.bt1.WatchdogEnabled[9] = CheckBoxWatchdogENLOGO9.Checked;
            FormControl.bt1.WatchdogEnabled[10] = CheckBoxWatchdogENLOGO10.Checked;
            FormControl.bt1.WatchdogEnabled[11] = CheckBoxWatchdogENLOGO11.Checked;
            FormControl.bt1.WatchdogEnabled[12] = CheckBoxWatchdogENLOGO12.Checked;
            FormControl.bt1.WatchdogEnabled[13] = CheckBoxWatchdogENLOGO13.Checked;
            FormControl.bt1.WatchdogEnabled[14] = CheckBoxWatchdogENLOGO14.Checked;
            FormControl.bt1.WatchdogEnabled[15] = CheckBoxWatchdogENLOGO15.Checked;
            FormControl.bt1.WatchdogEnabled[16] = CheckBoxWatchdogENLOGO16.Checked;
            FormControl.bt1.WatchdogEnabled[17] = CheckBoxWatchdogENLOGO17.Checked;
            FormControl.bt1.WatchdogEnabled[18] = CheckBoxWatchdogENLOGO18.Checked;
            FormControl.bt1.WatchdogEnabled[19] = CheckBoxWatchdogENLOGO19.Checked;
            FormControl.bt1.WatchdogEnabled[20] = CheckBoxWatchdogENLOGO20.Checked;
                        
            #endregion



            //AUTOCONNECT

            if (checkBoxAutoconnect.Checked)
            {
                WL("Autoconnect at startup", 0, textBoxPathLOG.Text);

                object o = (string)"Skip UpdateFieldsXML";
                ButtonConnectALL_Click(o, null);

            }

            // Worker for populating values
            Thread Populator = new Thread(new ThreadStart(Populate));
            Populator.Name = "Populator";
            Populator.IsBackground = true;
            Populator.Start();

        }


        // open form GUI
        private void BtnOpenGUI_click(object sender, EventArgs e)
        {
            FormControl.ShowForm_Gui();
            FormControl.HideForm_Settings();

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormControl.HideForm_Settings();
            e.Cancel = true;
        }


        public void ShowDialog1()
        {
            OpenFileDialog d1 = new OpenFileDialog();
            d1.Title = "Select XML configuration file";
            d1.Filter = "XML files (*.xml)|*.xml";

            try
            {
                if (d1.ShowDialog() == DialogResult.OK)
                {
                    this.Invoke(new MethodInvoker(delegate { textBoxPathXML.Text = d1.FileName; ; })); ;
                    this.Invoke(new MethodInvoker(delegate { UpdateFieldsXML(); })); ;
                    WL("Browse for XML file finished", 0, textBoxPathLOG.Text);
                }
                else
                {
                    WL("No changes were made while browsing for XML file", 0, textBoxPathLOG.Text);
                }

            }

            catch (Exception ex)
            {

                WL("Error opening Browse dialog: " + ex.Message, -1, textBoxPathLOG.Text);
            }

        }

        // Log file selection
        public void ShowDialog2()
        {
            OpenFileDialog d2 = new OpenFileDialog();
            d2.Title = "Select LOG configuration file";
            d2.Filter = "TXT files (*.txt)|*.txt";

            if (d2.ShowDialog() == DialogResult.OK)
            {
                d2.Title = "Please select LOG file";
                this.Invoke(new MethodInvoker(delegate { textBoxPathLOG.Text = d2.FileName; }));
                WL("Browse for Log file finished", 0, textBoxPathLOG.Text);
            }
            else
            {
                WL("No changes were made while browsing for Log file", 0, textBoxPathLOG.Text);
                return;
            }
        }

        // User actions Log file selection
        public void ShowDialog3()
        {
            OpenFileDialog d2 = new OpenFileDialog();
            d2.Title = "Select CSV configuration file";
            d2.Filter = "CSV files (*.csv)|*.csv";

            if (d2.ShowDialog() == DialogResult.OK)
            {
                d2.Title = "Please select User actions LOG file";
                this.Invoke(new MethodInvoker(delegate { textBoxPathUALOG.Text = d2.FileName; }));
                WL("Browse for Log file finished", 0, textBoxPathUALOG.Text);
            }
            else
            {
                WL("No changes were made while browsing for User Actions Log file", 0, textBoxPathUALOG.Text);
                return;
            }
        }



        public static bool HasDuplicates(List<string> text)
        {

            for (int i = 0; i < text.Count; i++)
            {
                for (int ii = 0; ii < text.Count; ii++)
                {
                    if (i != ii)
                    {
                        if (text[i] == text[ii])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        private void WL(string text, int errCode, string pathToLogFile)
        {

            var message = DateTime.Now.ToString();



            if (errCode > 0)
            {
                message = message + " - LOGO!" + errCode + ": " + text;
            }
            else if (errCode == S7Consts.err_OK)
            {
                message = message + " - Info" + ": " + text;
            }
            else if (errCode == S7Consts.err_typeError)
            {
                message = message + " - ERRROR" + ": " + text;

                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { debug.BackColor = Color.Red; }));
                }
                else
                {
                    debug.BackColor = Color.Red;
                }

            }
            else if (errCode == S7Consts.err_watchdogDoesntChange)
            {
                message = Environment.NewLine + message + " - !!! CRITTICAL ERRROR !!!" + ": " + text + Environment.NewLine;
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { debug.BackColor = Color.Red; }));
                }
                else
                {
                    debug.BackColor = Color.Red;
                }


            }

            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { debug.AppendText(message + Environment.NewLine); }));
            }
            else
            {
                debug.AppendText(message + Environment.NewLine);
            }

            Console.WriteLine(message);

            try
            {
                FormControl.sw_Main.WriteLine(message);
                FormControl.sw_Main.Flush();
            }

            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { debug.AppendText(DateTime.Now.ToString() + " - Error" + ": " + "Error writing to log file: " + ex.Message + Environment.NewLine); }));
                }
                else
                {
                    debug.AppendText(DateTime.Now.ToString() + " - Error" + ": " + "Error writing to log file: " + ex.Message + Environment.NewLine);
                }
                Console.WriteLine(DateTime.Now.ToString() + " - Error" + ": " + "Error writing to log file: " + ex.Message);
            }

        }

        public void ConnectAsync(int device)
        {
            List<object> list = new List<object>();
            object obj = new object();

            switch (device)
            {
                case 1: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO1.Enabled = false; CheckBoxWatchdogENLOGO1.Enabled = false; break;
                case 2: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO2.Enabled = false; TextBoxWatchdogAddressLOGO2.Enabled = false; break;
                case 3: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO3.Enabled = false; TextBoxWatchdogAddressLOGO3.Enabled = false; break;
                case 4: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO4.Enabled = false; TextBoxWatchdogAddressLOGO4.Enabled = false; break;
                case 5: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO5.Enabled = false; TextBoxWatchdogAddressLOGO5.Enabled = false; break;
                case 6: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO6.Enabled = false; TextBoxWatchdogAddressLOGO6.Enabled = false; break;
                case 7: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO7.Enabled = false; TextBoxWatchdogAddressLOGO7.Enabled = false; break;
                case 8: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO8.Enabled = false; TextBoxWatchdogAddressLOGO8.Enabled = false; break;
                case 9: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO9.Enabled = false; TextBoxWatchdogAddressLOGO9.Enabled = false; break;
                case 10: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO10.Enabled = false; TextBoxWatchdogAddressLOGO10.Enabled = false; break;
                case 11: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO12.Enabled = false; TextBoxWatchdogAddressLOGO12.Enabled = false; break;
                case 13: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO13.Enabled = false; TextBoxWatchdogAddressLOGO13.Enabled = false; break;
                case 14: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO14.Enabled = false; TextBoxWatchdogAddressLOGO14.Enabled = false; break;
                case 15: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO15.Enabled = false; TextBoxWatchdogAddressLOGO15.Enabled = false; break;
                case 16: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO16.Enabled = false; TextBoxWatchdogAddressLOGO16.Enabled = false; break;
                case 17: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO17.Enabled = false; TextBoxWatchdogAddressLOGO17.Enabled = false; break;
                case 18: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO18.Enabled = false; TextBoxWatchdogAddressLOGO18.Enabled = false; break;
                case 19: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO19.Enabled = false; TextBoxWatchdogAddressLOGO19.Enabled = false; break;
                case 20: if (!FormControl.bt1.BackgroundWorker[device].IsBusy) { obj = (int)device; list.Add(obj); FormControl.bt1.BackgroundWorker[device].RunWorkerAsync(); } TextBoxWatchdogAddressLOGO20.Enabled = false; TextBoxWatchdogAddressLOGO20.Enabled = false; break;
                default: FormControl.bt1.WL("Internal Error Switch statement does not support this device (message source: ConectAsync() method)", device); break;
            }

        }

        public void DisconnectAsync(int device)
        {
            switch (device)
            {
                case 1: FormControl.bt1.WL("Disconected by the user", 1); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();   CheckBoxWatchdogENLOGO1.Enabled = true; TextBoxWatchdogAddressLOGO1.Enabled = true; break;
                case 2: FormControl.bt1.WL("Disconected by the user", 2); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();   CheckBoxWatchdogENLOGO2.Enabled = true; TextBoxWatchdogAddressLOGO2.Enabled = true; break;
                case 3: FormControl.bt1.WL("Disconected by the user", 3); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();   CheckBoxWatchdogENLOGO3.Enabled = true; TextBoxWatchdogAddressLOGO3.Enabled = true; break;
                case 4: FormControl.bt1.WL("Disconected by the user", 4); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();   CheckBoxWatchdogENLOGO4.Enabled = true; TextBoxWatchdogAddressLOGO4.Enabled = true; break;
                case 5: FormControl.bt1.WL("Disconected by the user", 5); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();   CheckBoxWatchdogENLOGO5.Enabled = true; TextBoxWatchdogAddressLOGO5.Enabled = true; break;
                case 6: FormControl.bt1.WL("Disconected by the user", 6); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();   CheckBoxWatchdogENLOGO6.Enabled = true; TextBoxWatchdogAddressLOGO6.Enabled = true; break;
                case 7: FormControl.bt1.WL("Disconected by the user", 7); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();   CheckBoxWatchdogENLOGO7.Enabled = true; TextBoxWatchdogAddressLOGO7.Enabled = true; break;
                case 8: FormControl.bt1.WL("Disconected by the user", 8); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();   CheckBoxWatchdogENLOGO8.Enabled = true; TextBoxWatchdogAddressLOGO8.Enabled = true; break;
                case 9: FormControl.bt1.WL("Disconected by the user", 9); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();   CheckBoxWatchdogENLOGO9.Enabled = true; TextBoxWatchdogAddressLOGO9.Enabled = true; break;
                case 10: FormControl.bt1.WL("Disconected by the user", 10); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO10.Enabled = true; TextBoxWatchdogAddressLOGO10.Enabled = true; break;
                case 11: FormControl.bt1.WL("Disconected by the user", 11); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO11.Enabled = true; TextBoxWatchdogAddressLOGO11.Enabled = true; break;
                case 12: FormControl.bt1.WL("Disconected by the user", 12); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO12.Enabled = true; TextBoxWatchdogAddressLOGO12.Enabled = true; break;
                case 13: FormControl.bt1.WL("Disconected by the user", 13); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO13.Enabled = true; TextBoxWatchdogAddressLOGO13.Enabled = true; break;
                case 14: FormControl.bt1.WL("Disconected by the user", 14); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO14.Enabled = true; TextBoxWatchdogAddressLOGO14.Enabled = true; break;
                case 15: FormControl.bt1.WL("Disconected by the user", 15); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO15.Enabled = true; TextBoxWatchdogAddressLOGO15.Enabled = true; break;
                case 16: FormControl.bt1.WL("Disconected by the user", 16); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO16.Enabled = true; TextBoxWatchdogAddressLOGO16.Enabled = true; break;
                case 17: FormControl.bt1.WL("Disconected by the user", 17); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO17.Enabled = true; TextBoxWatchdogAddressLOGO17.Enabled = true; break;
                case 18: FormControl.bt1.WL("Disconected by the user", 18); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO18.Enabled = true; TextBoxWatchdogAddressLOGO18.Enabled = true; break;
                case 19: FormControl.bt1.WL("Disconected by the user", 19); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO19.Enabled = true; TextBoxWatchdogAddressLOGO19.Enabled = true; break;
                case 20: FormControl.bt1.WL("Disconected by the user", 20); this.Invoke(new MethodInvoker(delegate { FormControl.bt1.BackgroundWorker[device].CancelAsync(); })); FormControl.bt1.LOGO[device].Disconnect();  CheckBoxWatchdogENLOGO20.Enabled = true; TextBoxWatchdogAddressLOGO20.Enabled = true; break;
                default: FormControl.bt1.WL("Internal Error Switch statement does not support this device (message source: DisconectAsync() method)", device); break;
            }


        }

        public void Populate()
        {

            DateTime time1;
            DateTime time2;
            double refreshOriginalVal = 500;
            double refreshCalculated = 500;

            MethodInvoker mi = (new MethodInvoker(delegate
            {
                labelWatchdogRuning1.Text = FormControl.bt1.watchdogLabel[1].Text;
                labelWatchdogRuning2.Text = FormControl.bt1.watchdogLabel[2].Text;
                labelWatchdogRuning3.Text = FormControl.bt1.watchdogLabel[3].Text;
                labelWatchdogRuning4.Text = FormControl.bt1.watchdogLabel[4].Text;
                labelWatchdogRuning5.Text = FormControl.bt1.watchdogLabel[5].Text;
                labelWatchdogRuning6.Text = FormControl.bt1.watchdogLabel[6].Text;
                labelWatchdogRuning7.Text = FormControl.bt1.watchdogLabel[7].Text;
                labelWatchdogRuning8.Text = FormControl.bt1.watchdogLabel[8].Text;
                labelWatchdogRuning9.Text = FormControl.bt1.watchdogLabel[9].Text;
                labelWatchdogRuning10.Text = FormControl.bt1.watchdogLabel[10].Text;
                labelWatchdogRuning11.Text = FormControl.bt1.watchdogLabel[11].Text;
                labelWatchdogRuning12.Text = FormControl.bt1.watchdogLabel[12].Text;
                labelWatchdogRuning13.Text = FormControl.bt1.watchdogLabel[13].Text;
                labelWatchdogRuning14.Text = FormControl.bt1.watchdogLabel[14].Text;
                labelWatchdogRuning15.Text = FormControl.bt1.watchdogLabel[15].Text;
                labelWatchdogRuning16.Text = FormControl.bt1.watchdogLabel[16].Text;
                labelWatchdogRuning17.Text = FormControl.bt1.watchdogLabel[17].Text;
                labelWatchdogRuning18.Text = FormControl.bt1.watchdogLabel[18].Text;
                labelWatchdogRuning19.Text = FormControl.bt1.watchdogLabel[19].Text;
                labelWatchdogRuning20.Text = FormControl.bt1.watchdogLabel[20].Text;

            }));

            try
            {
                refreshOriginalVal = int.Parse(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("SettingsMenuRefreshrate").Value);
                if (refreshOriginalVal > 1000 || refreshOriginalVal < 100)
                {
                    refreshOriginalVal = 1000;
                    FormControl.bt1.WL("GUI Refresh rate is not a suitable value (must not be >1000 or <100). Default value of 1000ms is set.(message source: Form Settings)", -1);
                }
            }
            catch (Exception)
            {
                FormControl.bt1.WL("GUI Refresh rate entry can not be found in XML file provided. Default value of 500ms is set.(message source: Form Settings)", -1);
            }

            while (true)
            {
                try
                {
                    time1 = DateTime.Now;

                    this.Invoke(mi);
                    //Application.DoEvents();

                    time2 = DateTime.Now;
                    refreshCalculated = refreshOriginalVal - (time2 - time1).TotalMilliseconds;
                    if (refreshCalculated < 1) { refreshCalculated = 1; }
                    if (refreshCalculated > 3000) { refreshCalculated = 3000; }
                    Thread.Sleep(Convert.ToInt32(refreshCalculated));

                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public string GetRWcycle(int device)
        {
            if (device == 1) { return TextBoxRWcycLOGO1.Text; }
            if (device == 2) { return TextBoxRWcycLOGO2.Text; }
            if (device == 3) { return TextBoxRWcycLOGO3.Text; }
            if (device == 4) { return TextBoxRWcycLOGO4.Text; }
            if (device == 5) { return TextBoxRWcycLOGO5.Text; }
            if (device == 6) { return TextBoxRWcycLOGO6.Text; }
            if (device == 7) { return TextBoxRWcycLOGO7.Text; }
            if (device == 8) { return TextBoxRWcycLOGO8.Text; }
            if (device == 9) { return TextBoxRWcycLOGO9.Text; }
            if (device == 10) { return TextBoxRWcycLOGO10.Text; }
            if (device == 11) { return TextBoxRWcycLOGO11.Text; }
            if (device == 12) { return TextBoxRWcycLOGO12.Text; }
            if (device == 13) { return TextBoxRWcycLOGO13.Text; }
            if (device == 14) { return TextBoxRWcycLOGO14.Text; }
            if (device == 15) { return TextBoxRWcycLOGO15.Text; }
            if (device == 16) { return TextBoxRWcycLOGO16.Text; }
            if (device == 17) { return TextBoxRWcycLOGO17.Text; }
            if (device == 18) { return TextBoxRWcycLOGO18.Text; }
            if (device == 19) { return TextBoxRWcycLOGO19.Text; }
            if (device == 20) { return TextBoxRWcycLOGO20.Text; }

            else
            {
                return "ERR";
            }

        }

        private void generatePC_WD_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_Generate_PC.Checked)
                {
                   XML_handler.settingsXML.Element("root").Element("GENERAL").Element("GeneratePC_WD").SetValue("true");
                }
                else
                {
                   XML_handler.settingsXML.Element("root").Element("GENERAL").Element("GeneratePC_WD").SetValue("false");
                }
               XML_handler.SaveXML();

            }
            catch (Exception ex)
            {
                WL("Error while changing settings - XML file entry is corupted (entry: GeneratePC_WD): " + ex.Message, 0, textBoxPathLOG.Text);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                textboxCode.Text = cd.Color.ToArgb().ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = "Restarting..";
            button4.Enabled = false;
            ButtonDisconnectALL_Click(null, null);
            Application.DoEvents();

            FormControl.CloseApp_Preparation();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            XML_handler.SaveXML();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}



