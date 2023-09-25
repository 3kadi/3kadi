using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sharp7;
using Linq = System.Xml.Linq;

namespace KontrolaKadi
{
    public partial class Settings : Form
    {
        #region UPDATE_FIELDS

        public void UpdateFieldsXML()
        {
            try
            {                
                var root = XML_handler.settingsXML.Element("root");
                                
                UpdateFieldsAll();

                #region find duplicates
                List<string> IPs = new List<string>();

                if (CheckBoxLOGO_EN1.Checked) { if (textBoxDeviceIPLOGO1.Text != "") { IPs.Add(textBoxDeviceIPLOGO1.Text); } }
                if (CheckBoxLOGO_EN2.Checked) { if (textBoxDeviceIPLOGO2.Text != "") { IPs.Add(textBoxDeviceIPLOGO2.Text); } }
                if (CheckBoxLOGO_EN3.Checked) { if (textBoxDeviceIPLOGO3.Text != "") { IPs.Add(textBoxDeviceIPLOGO3.Text); } }
                if (CheckBoxLOGO_EN4.Checked) { if (textBoxDeviceIPLOGO4.Text != "") { IPs.Add(textBoxDeviceIPLOGO4.Text); } }
                if (CheckBoxLOGO_EN5.Checked) { if (textBoxDeviceIPLOGO5.Text != "") { IPs.Add(textBoxDeviceIPLOGO5.Text); } }
                if (CheckBoxLOGO_EN6.Checked) { if (textBoxDeviceIPLOGO6.Text != "") { IPs.Add(textBoxDeviceIPLOGO6.Text); } }
                if (CheckBoxLOGO_EN7.Checked) { if (textBoxDeviceIPLOGO7.Text != "") { IPs.Add(textBoxDeviceIPLOGO7.Text); } }
                if (CheckBoxLOGO_EN8.Checked) { if (textBoxDeviceIPLOGO8.Text != "") { IPs.Add(textBoxDeviceIPLOGO8.Text); } }
                if (CheckBoxLOGO_EN9.Checked) { if (textBoxDeviceIPLOGO9.Text != "") { IPs.Add(textBoxDeviceIPLOGO9.Text); } }
                if (CheckBoxLOGO_EN10.Checked) { if (textBoxDeviceIPLOGO10.Text != "") { IPs.Add(textBoxDeviceIPLOGO10.Text); } }
                if (CheckBoxLOGO_EN11.Checked) { if (textBoxDeviceIPLOGO11.Text != "") { IPs.Add(textBoxDeviceIPLOGO11.Text); } }
                if (CheckBoxLOGO_EN12.Checked) { if (textBoxDeviceIPLOGO12.Text != "") { IPs.Add(textBoxDeviceIPLOGO12.Text); } }
                if (CheckBoxLOGO_EN13.Checked) { if (textBoxDeviceIPLOGO13.Text != "") { IPs.Add(textBoxDeviceIPLOGO13.Text); } }
                if (CheckBoxLOGO_EN14.Checked) { if (textBoxDeviceIPLOGO14.Text != "") { IPs.Add(textBoxDeviceIPLOGO14.Text); } }
                if (CheckBoxLOGO_EN15.Checked) { if (textBoxDeviceIPLOGO15.Text != "") { IPs.Add(textBoxDeviceIPLOGO15.Text); } }
                if (CheckBoxLOGO_EN16.Checked) { if (textBoxDeviceIPLOGO16.Text != "") { IPs.Add(textBoxDeviceIPLOGO16.Text); } }
                if (CheckBoxLOGO_EN17.Checked) { if (textBoxDeviceIPLOGO17.Text != "") { IPs.Add(textBoxDeviceIPLOGO17.Text); } }
                if (CheckBoxLOGO_EN18.Checked) { if (textBoxDeviceIPLOGO18.Text != "") { IPs.Add(textBoxDeviceIPLOGO18.Text); } }
                if (CheckBoxLOGO_EN19.Checked) { if (textBoxDeviceIPLOGO19.Text != "") { IPs.Add(textBoxDeviceIPLOGO19.Text); } }
                if (CheckBoxLOGO_EN20.Checked) { if (textBoxDeviceIPLOGO20.Text != "") { IPs.Add(textBoxDeviceIPLOGO20.Text); } }

                if (HasDuplicates(IPs))
                { FormControl.bt1.WL("Duplicated IP adresses found in configuration file. this can lead to unexpected behaviour. Please change IP adresses so each device will have unique IP adress and then restart the application.", -1); }

                
                #endregion

                checkBoxAutoconnect.Checked = Convert.ToBoolean(root.Element("GENERAL").Element("AutoConnect").Value.Replace("\"", ""));
                checkBox_Generate_PC.Checked = Convert.ToBoolean(root.Element("GENERAL").Element("GeneratePC_WD").Value.Replace("\"", ""));
                XML_handler.SaveXML();

            }
            catch (Exception e)
            {

                FormControl.bt1.WL("Error updating fields on form: " + e.Message ,-1);
            }

            try
            {
                XML_handler.settingsXML = Linq.XDocument.Load(textBoxPathXML.Text);
                var root = XML_handler.settingsXML.Element("root");

                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate 
                    {
                        textBoxPathLOG.Text = root.Element("GENERAL").Element("logFilePath").Value.Replace("\"", "");
                        textBoxPathUALOG.Text = root.Element("GENERAL").Element("UserActionsFilePath").Value.Replace("\"", "");

                    }));
                }
                else
                { 
                    textBoxPathLOG.Text = root.Element("GENERAL").Element("logFilePath").Value.Replace("\"", "");
                    textBoxPathUALOG.Text = root.Element("GENERAL").Element("UserActionsFilePath").Value.Replace("\"", "");
                }
                XML_handler.SaveXML();
            }
            catch (Exception ex)
            {
                FormControl.bt1.WL("Error updating fields on form (paths to log files): " + ex.Message, -1);
            }


        }

        private void UpdateFieldsLOGO1(Linq.XElement config)
        {
            CheckBoxLOGO_EN1.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO1.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[1].IpAddress = textBoxDeviceIPLOGO1.Text;

            textBoxLocalTSAPLOGO1.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[1].LocalTSAP = textBoxLocalTSAPLOGO1.Text;

            textBoxRemoteTSAPLOGO1.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[1].RemoteTSAP = textBoxRemoteTSAPLOGO1.Text;

            

            TextBoxWatchdogAddressLOGO1.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO1.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false"); }

        }

        private void UpdateFieldsLOGO2(Linq.XElement config)
        {
            CheckBoxLOGO_EN2.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO2.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[2].IpAddress = textBoxDeviceIPLOGO2.Text;

            textBoxLocalTSAPLOGO2.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[2].LocalTSAP = textBoxLocalTSAPLOGO2.Text;

            textBoxRemoteTSAPLOGO2.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[2].RemoteTSAP = textBoxRemoteTSAPLOGO2.Text;

            

            TextBoxWatchdogAddressLOGO2.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO2.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO3(Linq.XElement config)
        {
            CheckBoxLOGO_EN3.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO3.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[3].IpAddress = textBoxDeviceIPLOGO3.Text;

            textBoxLocalTSAPLOGO3.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[3].LocalTSAP = textBoxLocalTSAPLOGO3.Text;

            textBoxRemoteTSAPLOGO3.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[3].RemoteTSAP = textBoxRemoteTSAPLOGO3.Text;

            

            TextBoxWatchdogAddressLOGO3.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO3.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO4(Linq.XElement config)
        {
            CheckBoxLOGO_EN4.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO4.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[4].IpAddress = textBoxDeviceIPLOGO4.Text;

            textBoxLocalTSAPLOGO4.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[4].LocalTSAP = textBoxLocalTSAPLOGO4.Text;

            textBoxRemoteTSAPLOGO4.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[4].RemoteTSAP = textBoxRemoteTSAPLOGO4.Text;

            

            TextBoxWatchdogAddressLOGO4.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO4.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO5(Linq.XElement config)
        {
            CheckBoxLOGO_EN5.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO5.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[5].IpAddress = textBoxDeviceIPLOGO5.Text;

            textBoxLocalTSAPLOGO5.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[5].LocalTSAP = textBoxLocalTSAPLOGO5.Text;

            textBoxRemoteTSAPLOGO5.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[5].RemoteTSAP = textBoxRemoteTSAPLOGO5.Text;

            

            TextBoxWatchdogAddressLOGO5.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO5.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }
        }

        private void UpdateFieldsLOGO6(Linq.XElement config)
        {
            CheckBoxLOGO_EN6.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            CheckBoxLOGO_EN6.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO6.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[6].IpAddress = textBoxDeviceIPLOGO6.Text;

            textBoxLocalTSAPLOGO6.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[6].LocalTSAP = textBoxLocalTSAPLOGO6.Text;

            textBoxRemoteTSAPLOGO6.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[6].RemoteTSAP = textBoxRemoteTSAPLOGO6.Text;

            

            TextBoxWatchdogAddressLOGO6.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO6.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }
        }

        private void UpdateFieldsLOGO7(Linq.XElement config)
        {
            CheckBoxLOGO_EN7.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            CheckBoxLOGO_EN7.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO7.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[7].IpAddress = textBoxDeviceIPLOGO7.Text;

            textBoxLocalTSAPLOGO7.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[7].LocalTSAP = textBoxLocalTSAPLOGO7.Text;

            textBoxRemoteTSAPLOGO7.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[7].RemoteTSAP = textBoxRemoteTSAPLOGO7.Text;

            

            TextBoxWatchdogAddressLOGO7.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO7.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO8(Linq.XElement config)
        {
            CheckBoxLOGO_EN8.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO8.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[8].IpAddress = textBoxDeviceIPLOGO8.Text;

            textBoxLocalTSAPLOGO8.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[8].LocalTSAP = textBoxLocalTSAPLOGO8.Text;

            textBoxRemoteTSAPLOGO8.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[8].RemoteTSAP = textBoxRemoteTSAPLOGO8.Text;

            

            TextBoxWatchdogAddressLOGO8.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO8.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO9(Linq.XElement config)
        {
            CheckBoxLOGO_EN9.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO9.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[9].IpAddress = textBoxDeviceIPLOGO9.Text;

            textBoxLocalTSAPLOGO9.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[9].LocalTSAP = textBoxLocalTSAPLOGO9.Text;

            textBoxRemoteTSAPLOGO9.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[9].RemoteTSAP = textBoxRemoteTSAPLOGO9.Text;

            

            TextBoxWatchdogAddressLOGO9.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO9.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO10(Linq.XElement config)
        {
            CheckBoxLOGO_EN10.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO10.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[10].IpAddress = textBoxDeviceIPLOGO10.Text;

            textBoxLocalTSAPLOGO10.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[10].LocalTSAP = textBoxLocalTSAPLOGO10.Text;

            textBoxRemoteTSAPLOGO10.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[10].RemoteTSAP = textBoxRemoteTSAPLOGO10.Text;

            

            TextBoxWatchdogAddressLOGO10.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO10.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO11(Linq.XElement config)
        {
            CheckBoxLOGO_EN11.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO11.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[11].IpAddress = textBoxDeviceIPLOGO11.Text;

            textBoxLocalTSAPLOGO11.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[11].LocalTSAP = textBoxLocalTSAPLOGO11.Text;

            textBoxRemoteTSAPLOGO11.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[11].RemoteTSAP = textBoxRemoteTSAPLOGO11.Text;

            

            TextBoxWatchdogAddressLOGO11.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO11.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO12(Linq.XElement config)
        {
            CheckBoxLOGO_EN12.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO12.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[12].IpAddress = textBoxDeviceIPLOGO12.Text;

            textBoxLocalTSAPLOGO12.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[12].LocalTSAP = textBoxLocalTSAPLOGO12.Text;

            textBoxRemoteTSAPLOGO12.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[12].RemoteTSAP = textBoxRemoteTSAPLOGO12.Text;

            

            TextBoxWatchdogAddressLOGO12.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO12.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO13(Linq.XElement config)
        {
            CheckBoxLOGO_EN13.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO13.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[13].IpAddress = textBoxDeviceIPLOGO13.Text;

            textBoxLocalTSAPLOGO13.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[13].LocalTSAP = textBoxLocalTSAPLOGO13.Text;

            textBoxRemoteTSAPLOGO13.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[13].RemoteTSAP = textBoxRemoteTSAPLOGO13.Text;

            

            TextBoxWatchdogAddressLOGO13.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO13.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO14(Linq.XElement config)
        {
            CheckBoxLOGO_EN14.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO14.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[14].IpAddress = textBoxDeviceIPLOGO14.Text;

            textBoxLocalTSAPLOGO14.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[14].LocalTSAP = textBoxLocalTSAPLOGO14.Text;

            textBoxRemoteTSAPLOGO14.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[14].RemoteTSAP = textBoxRemoteTSAPLOGO14.Text;

            

            TextBoxWatchdogAddressLOGO14.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO14.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO15(Linq.XElement config)
        {
            CheckBoxLOGO_EN15.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO15.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[15].IpAddress = textBoxDeviceIPLOGO15.Text;

            textBoxLocalTSAPLOGO15.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[15].LocalTSAP = textBoxLocalTSAPLOGO15.Text;

            textBoxRemoteTSAPLOGO15.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[15].RemoteTSAP = textBoxRemoteTSAPLOGO15.Text;

            

            TextBoxWatchdogAddressLOGO15.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO15.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO16(Linq.XElement config)
        {
            CheckBoxLOGO_EN16.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO16.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[16].IpAddress = textBoxDeviceIPLOGO16.Text;

            textBoxLocalTSAPLOGO16.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[16].LocalTSAP = textBoxLocalTSAPLOGO16.Text;

            textBoxRemoteTSAPLOGO16.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[16].RemoteTSAP = textBoxRemoteTSAPLOGO16.Text;

            

            TextBoxWatchdogAddressLOGO16.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO16.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO17(Linq.XElement config)
        {
            CheckBoxLOGO_EN17.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO17.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[17].IpAddress = textBoxDeviceIPLOGO17.Text;

            textBoxLocalTSAPLOGO17.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[17].LocalTSAP = textBoxLocalTSAPLOGO17.Text;

            textBoxRemoteTSAPLOGO17.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[17].RemoteTSAP = textBoxRemoteTSAPLOGO17.Text;

            

            TextBoxWatchdogAddressLOGO17.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO17.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO18(Linq.XElement config)
        {
            CheckBoxLOGO_EN18.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO18.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[18].IpAddress = textBoxDeviceIPLOGO18.Text;

            textBoxLocalTSAPLOGO18.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[18].LocalTSAP = textBoxLocalTSAPLOGO18.Text;

            textBoxRemoteTSAPLOGO18.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[18].RemoteTSAP = textBoxRemoteTSAPLOGO18.Text;

            

            TextBoxWatchdogAddressLOGO18.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO18.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO19(Linq.XElement config)
        {
            CheckBoxLOGO_EN19.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO19.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[19].IpAddress = textBoxDeviceIPLOGO19.Text;

            textBoxLocalTSAPLOGO19.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[19].LocalTSAP = textBoxLocalTSAPLOGO19.Text;

            textBoxRemoteTSAPLOGO19.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[19].RemoteTSAP = textBoxRemoteTSAPLOGO19.Text;

            

            TextBoxWatchdogAddressLOGO19.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO19.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }

        }

        private void UpdateFieldsLOGO20(Linq.XElement config)
        {
            CheckBoxLOGO_EN20.Checked = Convert.ToBoolean(config.Element("enabled").Value.Replace("\"", ""));

            textBoxDeviceIPLOGO20.Text = config.Element("serverIP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[20].IpAddress = textBoxDeviceIPLOGO20.Text;

            textBoxLocalTSAPLOGO20.Text = config.Element("localTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[20].LocalTSAP = textBoxLocalTSAPLOGO20.Text;

            textBoxRemoteTSAPLOGO20.Text = config.Element("remoteTSAP").Value.Replace("\"", "");
            FormControl.bt1.LOGOConnection[20].RemoteTSAP = textBoxRemoteTSAPLOGO20.Text;

            

            TextBoxWatchdogAddressLOGO20.Text = config.Element("watchdogAddress").Value.Replace("\"", "");
            TextBoxRWcycLOGO20.Text = config.Element("ReadWriteCycle").Value.Replace("\"", "");

            if (!Convert.ToBoolean(config.Element("show").Value.Replace("\"", ""))) { config.Element("enabled").SetValue("false");   }
            
        }



        #endregion UPDATE_FIELDS

        public void UpdateFieldsAll()
        {
            var root = XML_handler.settingsXML.Element("root");

            UpdateFieldsLOGO1(root.Element("LOGO1"));
            UpdateFieldsLOGO2(root.Element("LOGO2"));
            UpdateFieldsLOGO3(root.Element("LOGO3"));
            UpdateFieldsLOGO4(root.Element("LOGO4"));
            UpdateFieldsLOGO5(root.Element("LOGO5"));
            UpdateFieldsLOGO6(root.Element("LOGO6"));
            UpdateFieldsLOGO7(root.Element("LOGO7"));
            UpdateFieldsLOGO8(root.Element("LOGO8"));
            UpdateFieldsLOGO9(root.Element("LOGO9"));
            UpdateFieldsLOGO10(root.Element("LOGO10"));
            UpdateFieldsLOGO11(root.Element("LOGO11"));
            UpdateFieldsLOGO12(root.Element("LOGO12"));
            UpdateFieldsLOGO13(root.Element("LOGO13"));
            UpdateFieldsLOGO14(root.Element("LOGO14"));
            UpdateFieldsLOGO15(root.Element("LOGO15"));
            UpdateFieldsLOGO16(root.Element("LOGO16"));
            UpdateFieldsLOGO17(root.Element("LOGO17"));
            UpdateFieldsLOGO18(root.Element("LOGO18"));
            UpdateFieldsLOGO19(root.Element("LOGO19"));
            UpdateFieldsLOGO20(root.Element("LOGO20"));
        }
        

    }
}
