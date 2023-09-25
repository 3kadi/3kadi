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
    public partial class BackroundTasks
    {

        public bool InitialisationComplete = false;

        public Form[] Gui { get; set; }
        public Form Settings { get; set; }        
        public int WatchdogRetries { get; set; }

        public Misc.SmartThread[] BackgroundWorker = new Misc.SmartThread[21];

        
        public BackgroundWorker Watchdog_PC;

        public ushort Watchdog_PC_value = 0;

        public Prop1 Prop1 { get; set; }
        public Prop2 Prop2 { get; set; }        
        public Prop3 Prop3 { get; set; }
        public Prop4 Prop4 { get; set; }
        public Prop5 Prop5 { get; set; }
        public Prop6 Prop6 { get; set; }
        public Prop7 Prop7 { get; set; }
        public Prop8 Prop8 { get; set; }

        
        public S7Client[] LOGO = new S7Client[21];


        public Connection[] LOGOConnection = new Connection[21];

        public Label[] watchdogLabel = new Label[21];        
                
               
        public BackroundTasks(XDocument settingsXML)
        {
            Gui = new Form[3];
            try
            {
                for (int i = 1; i < LOGO.Length; i++)
                {
                    LOGO[i] = new S7Client(i);

                    LOGOConnection[i] = new Connection
                    {
                        IpAddress = settingsXML.Element("root").Element("LOGO" + i).Element("serverIP").Value.Replace("\"", ""),
                        LocalTSAP = settingsXML.Element("root").Element("LOGO" + i).Element("localTSAP").Value.Replace("\"", ""),
                        RemoteTSAP = settingsXML.Element("root").Element("LOGO" + i).Element("remoteTSAP").Value.Replace("\"", ""),
                        errcodeLOGO = 0,
                        connectionStatusLOGO = (int)Connection.Status.NotInitialised
                    };

                    LOGO[i].SetConnectionParams(LOGOConnection[i].IpAddress, LOGOConnection[i].LocalTSAP_asushort, LOGOConnection[i].RemoteTSAP_asushort);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initialising background tasks. Please check XML file path and all entries with folowing names: serverIP, localTSAP, remoteTSAP. Error message: "+ ex.Message + "Application will now close.");
                Environment.Exit(0);
            }
              
            
            Prop1 = new Prop1(LOGO[1]); 
            Prop2 = new Prop2(LOGO[2]);            
            Prop3 = new Prop3(LOGO[3]);
            Prop4 = new Prop4(LOGO[4]);
            Prop5 = new Prop5(LOGO[5]);
            Prop6 = new Prop6(LOGO[6]);
            Prop7 = new Prop7(LOGO[7]);
            Prop8 = new Prop8(LOGO[8]);



        }

        public void StartBackgroundTasks()
        {
            Watchdog_PC = new BackgroundWorker();
                   

            for (int i = 1; i < watchdogLabel.Length; i++)
            {
                watchdogLabel[i] = new Label();
            }

            
            for (int i = 1; i < BackgroundWorker.Length -1; i++)
            {
                

                try
                {
                    if (XML_handler.settingsXML.Element("root").Element("LOGO" + i).Element("enabled").Value.ToLower() == true.ToString().ToLower())
                    {
                        int tmpi = i;
                        BackgroundWorker[i] = new Misc.SmartThread(() => BackgroundWorker1_DoWork(tmpi));                        
                        BackgroundWorker[i].Start("Loop - PLC " + tmpi, ApartmentState.MTA,ThreadPriority.Normal,true);
                        Thread.Sleep(10);                        
                    }
                }
                catch (Exception ex)
                {
                    FormControl.bt1.WL("Cant load PLC loop thread correctly. reason: "+ ex.Message, -2);                   
                }
                              
            }


            Watchdog_PC.DoWork += new DoWorkEventHandler(Watchdog_PC_DoWork);
                        
        }
        
        
        public void BackgroundWorker1_DoWork(int device)
        {
            while (!FormControl.allowbttorun)
            {
                Thread.Sleep(50);               
            }

            Thread.Sleep(device * device *10);

            WL("Connecting...", device);
            LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Connecting;

            Thread.Sleep(100);
            
            DateTime time1;
            DateTime time2;
            
            int thisVal = 1;
            int prevVal = 0;
            int FailCnt = 0;
            int olderr = 0;
            int delayms = 1000;
            string progress = "";
            
            
            S7Client tmpClient = LOGO[device];
            string watchdogAddr = "";
            int errCode = S7Consts.err_OK;
            string RWcyc = "1000";
            bool firstWDattemptSucc = false;
            string RWcyc_old = "";

            int failCntr = 0;

            if (IfDisconnectProcedure(device)) { return; }

            try
            {
                switch (device)
                {
                    case 1:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO1.Text; break;
                    case 2:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO2.Text; break;
                    case 3:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO3.Text; break;
                    case 4:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO4.Text; break;
                    case 5:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO5.Text; break;
                    case 6:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO6.Text; break;
                    case 7:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO7.Text; break;
                    case 8:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO8.Text; break;
                    case 9:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO9.Text; break;
                    case 10:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO10.Text; break;
                    case 11: watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO11.Text; break;
                    case 12:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO12.Text; break;
                    case 13:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO13.Text; break;
                    case 14:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO14.Text; break;
                    case 15:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO15.Text; break;
                    case 16:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO16.Text; break;
                    case 17:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO17.Text; break;
                    case 18:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO18.Text; break;
                    case 19:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO19.Text; break;
                    case 20:  watchdogAddr = FormControl.Form_settings.TextBoxWatchdogAddressLOGO20.Text; break;
                    default:
                        WL("Internal Error Switch statement does not support this device", -2); LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Error; break;

                }

                if (IfDisconnectProcedure(device)) { return; }
               
                    errCode = LOGO[device].Connect();                 

                if (IfDisconnectProcedure(device)) { return; }

                if ((errCode) == 0)
                {                    
                    WL("Connected", LOGO[device].deviceID);
                    LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Connected;
                }
                else
                {
                    WL(LOGO[device].ErrorText(errCode), LOGO[device].deviceID);
                    LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Error;
                }
            }
            catch (Exception ex)
            {
                WL("Internal fatal error on first connection attempt: " + ex.Message, device);
                LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Error;
            }


            


            try
            {
                time1 = DateTime.Now;
                while (true)
                {
                    
                    try
                    {
                        if (IfDisconnectProcedure(device)) { return; }

                        

                        switch (device)
                        {
                            case 1: PROGRAM1(Prop1); RWcyc = FormControl.Form_settings.TextBoxRWcycLOGO1.Text; break;
                            case 2: PROGRAM2(Prop2); RWcyc = FormControl.Form_settings.TextBoxRWcycLOGO2.Text; break;
                            case 3: PROGRAM3(Prop3); RWcyc = FormControl.Form_settings.TextBoxRWcycLOGO3.Text; break;
                            case 4: PROGRAM4(Prop4); RWcyc = FormControl.Form_settings.TextBoxRWcycLOGO4.Text; break;
                            case 5: PROGRAM5(Prop5); RWcyc = FormControl.Form_settings.TextBoxRWcycLOGO5.Text; break;
                            case 6: PROGRAM6(Prop6); RWcyc = FormControl.Form_settings.TextBoxRWcycLOGO6.Text; break;
                            case 7: PROGRAM7(Prop7); RWcyc = FormControl.Form_settings.TextBoxRWcycLOGO7.Text; break;
                            case 8: PROGRAM8(Prop8); RWcyc = FormControl.Form_settings.TextBoxRWcycLOGO8.Text; break;


                            default:
                                WL("Internal Error: Switch statement does not support this device", -2); LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Error; break;

                        }
                    }
                    catch (Exception ex)
                    {
                        WL("Error: Retrieving data from PLC failed. Message source: Program looptrough inside background worker: " + ex.Message, device);
                    }
                      
                    try
                    {
                        if (IfDisconnectProcedure(device)) { return; }

                        errCode = Watchdog(LOGO[device], watchdogAddr, ref progress, ref thisVal, ref prevVal, WatchdogRetries, ref FailCnt);

                        if (IfDisconnectProcedure(device)) { return; }

                        if (errCode != 0 && olderr != errCode)
                        {
                            WL(LOGO[device].ErrorText(errCode), device);
                            LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Warning;
                        }
                        else
                        {
                            if (!firstWDattemptSucc)
                            {
                                switch (device)
                                {
                                    case 1: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO1.Text) + "ms", LOGO[device].deviceID); break;
                                    case 2: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO2.Text) + "ms", LOGO[device].deviceID); break;
                                    case 3: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO3.Text) + "ms", LOGO[device].deviceID); break;
                                    case 4: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO4.Text) + "ms", LOGO[device].deviceID); break;
                                    case 5: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO5.Text) + "ms", LOGO[device].deviceID); break;
                                    case 6: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO6.Text) + "ms", LOGO[device].deviceID); break;
                                    case 7: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO7.Text) + "ms", LOGO[device].deviceID); break;
                                    case 8: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO8.Text) + "ms", LOGO[device].deviceID); break;
                                    case 9: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO9.Text) + "ms", LOGO[device].deviceID); break;
                                    case 10: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO10.Text) + "ms", LOGO[device].deviceID); break;
                                    case 11: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO11.Text) + "ms", LOGO[device].deviceID); break;
                                    case 12: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO12.Text) + "ms", LOGO[device].deviceID); break;
                                    case 13: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO13.Text) + "ms", LOGO[device].deviceID); break;
                                    case 14: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO14.Text) + "ms", LOGO[device].deviceID); break;
                                    case 15: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO15.Text) + "ms", LOGO[device].deviceID); break;
                                    case 16: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO16.Text) + "ms", LOGO[device].deviceID); break;
                                    case 17: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO17.Text) + "ms", LOGO[device].deviceID); break;
                                    case 18: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO18.Text) + "ms", LOGO[device].deviceID); break;
                                    case 19: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO19.Text) + "ms", LOGO[device].deviceID); break;
                                    case 20: WL("Watchdog started successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO20.Text) + "ms", LOGO[device].deviceID); break;
                                    default:
                                        break;
                                }
                                
                                firstWDattemptSucc = true;
                            }
                            else if (RWcyc_old != RWcyc)
                            {
                                switch (device)
                                {
                                    case 1: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO1.Text) + "ms", LOGO[device].deviceID); break;
                                    case 2: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO2.Text) + "ms", LOGO[device].deviceID); break;
                                    case 3: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO3.Text) + "ms", LOGO[device].deviceID); break;
                                    case 4: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO4.Text) + "ms", LOGO[device].deviceID); break;
                                    case 5: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO5.Text) + "ms", LOGO[device].deviceID); break;
                                    case 6: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO6.Text) + "ms", LOGO[device].deviceID); break;
                                    case 7: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO7.Text) + "ms", LOGO[device].deviceID); break;
                                    case 8: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO8.Text) + "ms", LOGO[device].deviceID); break;
                                    case 9: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO9.Text) + "ms", LOGO[device].deviceID); break;
                                    case 10: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO10.Text) + "ms", LOGO[device].deviceID); break;
                                    case 11: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO11.Text) + "ms", LOGO[device].deviceID); break;
                                    case 12: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO12.Text) + "ms", LOGO[device].deviceID); break;
                                    case 13: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO13.Text) + "ms", LOGO[device].deviceID); break;
                                    case 14: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO14.Text) + "ms", LOGO[device].deviceID); break;
                                    case 15: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO15.Text) + "ms", LOGO[device].deviceID); break;
                                    case 16: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO16.Text) + "ms", LOGO[device].deviceID); break;
                                    case 17: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO17.Text) + "ms", LOGO[device].deviceID); break;
                                    case 18: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO18.Text) + "ms", LOGO[device].deviceID); break;
                                    case 19: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO19.Text) + "ms", LOGO[device].deviceID); break;
                                    case 20: WL("Watchdog changed successfully - Period (Frequency) is " + int.Parse(FormControl.Form_settings.TextBoxRWcycLOGO20.Text) + "ms", LOGO[device].deviceID); break;
                                    default:
                                        break;
                                }                                
                            }

                        }

                        if (errCode == (int)Connection.Status.Connected && olderr == errCode)
                        {
                            LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Connected;
                        }

                        RWcyc_old = RWcyc;
                        olderr = errCode;

                        if (IfDisconnectProcedure(device)) { return; }
                    }
                    catch (Exception ex)
                    {

                        WL("Error: Watchdog failed. Message source: Program looptrough inside background worker: " + ex.Message, device);
                    }

                    try
                    {
                        if (olderr != 0)
                        {
                            time2 = DateTime.Now.AddMilliseconds(3000);
                            LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Connecting;

                            // prevent to many reconnection attempts
                            while (time2 > DateTime.Now)
                            {                                
                                Thread.Sleep(100);
                                if (IfDisconnectProcedure(device)) { return; }

                            }

                            Reconnect(LOGO[device]);
                            if (IfDisconnectProcedure(device)) { return; }

                        }
                        else
                        {
                            
                            try
                            {
                                delayms = int.Parse(RWcyc);
                            }
                            catch (Exception ex)
                            {
                                WL("Could not calculate or read Read-Write cycle.. 1000ms is used : " + ex.Message, device);
                                delayms = 1000;
                                LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Warning;
                            }

                            time2 = DateTime.Now;

                            if (time2 > time1.AddMilliseconds(delayms))
                            {                                
                                if (failCntr >= 10)
                                {
                                    WL("Read-Write cycle is taking " + (int)(time2 - time1).TotalMilliseconds + "ms to complete (Cycle is set to be " + delayms + "ms ). Please extend Read-Write cycle", device);
                                    LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Warning;
                                    failCntr = 0;
                                }
                                else
                                {
                                    failCntr++;
                                }
                            }
                            else
                            {
                                while (DateTime.Now < time1.AddMilliseconds(delayms))
                                {
                                    if (IfDisconnectProcedure(device)) { return; }                                    
                                    Thread.Sleep(10);
                                }
                                failCntr = 0;
                            }
                            time1 = DateTime.Now;
                        }
                        if (IfDisconnectProcedure(device)) { return; }

                        LOGOConnection[device].errcodeLOGO = errCode;
                        watchdogLabel[device].Text = progress;


                        if (IfDisconnectProcedure(device)) { return; }
                    }
                    catch (Exception ex)
                    {
                        WL("Error: R/W Cycle manager stopped. Message source: Program looptrough inside background worker: " + ex.Message, device);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                WL("Internal fatal error in background worker thread, Connection will be terminated: " + ex.Message, device);
                LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Error;
                return;
            }
                   
        }

        private bool IfDisconnectProcedure(int device)
        {
            if (BackgroundWorker[device] == null)
            {
                return true;
            }
            if (BackgroundWorker[device].CanelationPending)
            {
                LOGOConnection[device].connectionStatusLOGO = (int)Connection.Status.Error;
                watchdogLabel[device].Text = "";                
                return true;
            }
            else { return false; }
        }

        private int Watchdog(S7Client Client, string typeAndAdress, ref string Progress, ref int thisValue, ref int previousValue, int CanFail_timesWithoutError, ref int CanFailCnt)
        {
            int err = 0;

            // watchdog function

            thisValue = Connection.PLCread(Client, typeAndAdress, out err);
            if (err != 0 || thisValue <= 0) // if there is an error
            {
                previousValue = thisValue;
                Progress = "ERR";
                CanFailCnt = 0;
                if (err == 0)
                {
                    err = S7Consts.err_watchdogDoesntChange;
                }
                return err;
            }
            else // if there is no error
            {
                if (thisValue == previousValue) // value of watchdog does not change...
                {
                    CanFailCnt++;
                    if (CanFailCnt >= CanFail_timesWithoutError) // ...does not change multiple times ( fail counter ++ )
                    {
                        Progress = "ERR";
                        previousValue = thisValue;
                        CanFailCnt = 0;
                        return -2;
                    }
                    else // waiting for fail counter to announce an error
                    {
                        return 0;
                    }

                }
                else
                {
                    Progress = "Running: " + thisValue.ToString();
                    previousValue = thisValue;
                    CanFailCnt = 0;
                    return err;
                }
            }


        }

        public void RunPCWatchdog()
        {
            if (!Watchdog_PC.IsBusy)
            {
                Watchdog_PC.RunWorkerAsync();
            }
            
        }

        public void Watchdog_PC_DoWork(object sender, EventArgs e)
        {            
            bool en = false;            
            bool firstpass = true;

            try
            {
                en = Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("GeneratePC_WD").Value);
                FormControl.Form_settings.Invoke(
                    new MethodInvoker(delegate
                    {
                        FormControl.Form_settings.checkBox_Generate_PC.Checked = en;
                        //XML_handler.SaveXML();
                    }));

            }
            catch
            {
                WL("Unable to get \"GeneratePC_WD\" value from XML file. PC Watchdog generator is now disabled.", -1);
                en = false;
            }
            
            try
            {
                while (true)
                {
                    if (FormControl.Form_settings.checkBox_Generate_PC.Checked)
                    {                        
                        if (en == true)
                        {
                            if (Watchdog_PC_value >= 8)
                            {
                                Watchdog_PC_value = 1;
                            }

                            Watchdog_PC_value++;                          
                            FormControl.bt1.Prop1.Watchdog_PC_value.Value = (short)Watchdog_PC_value;
                            if (firstpass)
                            {
                                if (Settings.InvokeRequired)
                                {
                                    Settings.Invoke(new MethodInvoker(delegate { WL("PC Watchdog is now running", 0); }));
                                }
                                else
                                {
                                    WL("PC Watchdog is now running", 0);
                                }

                                firstpass = false;
                            }
                           
                                                                                            
                        }
                        else
                        {
                            Watchdog_PC_value = 0;                            
                            Thread.Sleep(3000);
                            try
                            {
                                en = Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("GENERAL").Element("GeneratePC_WD").Value);
                            }
                            catch
                            {
                                en = false;
                            }

                        }

                        
                    }
                    else
                    {
                        Watchdog_PC_value = 0;
                    }
                                       
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {

                WL("PC Watchdog has encountered an error and must be stopped: " + ex.Message, -2);
            }
            

        }


        public void WL(string text, int deviceNumber)
        {
            var message = "";
                        
            if (deviceNumber > 0) // Device number
            {
                message = DateTime.Now.ToString() + " - LOGO!" + deviceNumber + ": " + text;
            }
            else if (deviceNumber == 0)
            {
                message = DateTime.Now.ToString() + " - Info" + ": " + text;
            }
            else if (deviceNumber == -1)
            {
                message = DateTime.Now.ToString() + " - ERRROR" + ": " + text;
                if (FormControl.Form_settings.InvokeRequired)
                {
                    FormControl.Form_settings.Invoke(new MethodInvoker(delegate { FormControl.Form_settings.debug.BackColor = Color.Red; }));
                }
                else
                {
                    FormControl.Form_settings.debug.BackColor = Color.Red;
                }

            }
            else if (deviceNumber == -2) // Critical error
            {
                message = Environment.NewLine + DateTime.Now.ToString() + " - !!! CRITTICAL ERRROR !!!" + ": " + text + Environment.NewLine;
                if (Settings.InvokeRequired)
                {
                    Settings.Invoke(new MethodInvoker(delegate { FormControl.Form_settings.debug.BackColor = Color.Red; }));
                }
                else
                {
                    FormControl.Form_settings.debug.BackColor = Color.Red;
                }
            }


            
                try
                {
                    Settings.Invoke(new MethodInvoker(delegate { FormControl.Form_settings.debug.AppendText(message + Environment.NewLine); }));
                }
                catch (Exception ex)
                {
                MessageBox.Show("Error writing message to log and/or Debug Console. Message was: message. Reason for failure is: " + ex.Message);
                }
           
            // LOG to file

            try
            {

                FormControl.sw_Main.WriteLine(message); FormControl.sw_Main.Flush();

            }
            catch (Exception)
            {


                if (Settings.InvokeRequired)
                {
                    Settings.Invoke(new MethodInvoker(delegate { FormControl.Form_settings.debug.AppendText(DateTime.Now.ToString() + " - Info/Error" + ": " + "Error writing to log file - Check log file path and restart the application" + Environment.NewLine); }));
                }
                else
                {
                    FormControl.Form_settings.debug.AppendText(DateTime.Now.ToString() + " - Info/Error" + ": " + "Error writing to log file - Check log file path and restart the application" + Environment.NewLine);
                }
            }


            Console.WriteLine(message);

        }


        public void Reconnect(S7Client Client)
        {
            int id = Client.deviceID;
            int err;

            LOGOConnection[Client.deviceID].connectionStatusLOGO = (int)Connection.Status.Connecting;
            err = Client.Disconnect();
            System.Threading.Thread.Sleep(100);
            err = Client.Connect();
            if ((err) == 0)
            {
                WL("Connected again", Client.deviceID);
                LOGOConnection[Client.deviceID].connectionStatusLOGO = (int)Connection.Status.Connected;
            }
            else
            {
                WL("Connection failed. Trying to reconnect", Client.deviceID);
            }


        }

              
        
    }
}
