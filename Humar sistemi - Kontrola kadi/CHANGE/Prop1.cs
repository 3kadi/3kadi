using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace KontrolaKadi
{
    public class Prop1
    {
        public Sharp7.S7Client Client;
        public int Cntr { get; set; }

        public Thread UpdatePowerConsumption;

        public DatagridTypes.PwrSet p1 = new DatagridTypes.PwrSet(1000, 50000, 500);
        public DatagridTypes.PwrSet p2 = new DatagridTypes.PwrSet(1000, 50000, 500);

        // CHANGE FROM HERE 

        // SKUPNE VREDNOSTI
        public PlcVars.Bit EloxConnected;
        public PlcVars.Bit BarveConnected;
        public PlcVars.Word PC_Connected;
        public PlcVars.Word NapajanjeOK;

        public PlcVars.Word WATCHDOG_Logo1;
        public PlcVars.Word Watchdog_PC_value;
        public PlcVars.Bit BuzzFromPC_Normal;
        public PlcVars.Bit BuzzFromPC_Urgent;
        public PlcVars.Bit BuzzFromPC_Stop;

        public PlcVars.Word EloxPoraba,BarvePoraba;

        public PlcVars.Bit StartNetElox;
        public PlcVars.Bit StopNetElox;
        public PlcVars.Bit StartNetBarve;
        public PlcVars.Bit StopNetBarve;

        public PlcVars.PowerShow MaxPowerSet1;
        public PlcVars.PowerShow MaxPowerSet2;

        public PlcVars.TimeSet LogoTimeShowOnly;

        public PlcVars.Word EN_Kad1;
        public PlcVars.Word EN_Kad2;
        public PlcVars.Word EN_Kad6;
        public PlcVars.Word EN_Kad7;
        public PlcVars.Word EN_Kad9;
        public PlcVars.Word EN_Kad10;
        public PlcVars.Word EN_Kad12;
        public PlcVars.Word EN_Kad14;
        public PlcVars.Word EN_Kad16;
        public PlcVars.Word EN_Kad18;
        public PlcVars.Word EN_Kad19;

        public PlcVars.Word EN_Kad3;
        public PlcVars.Word EN_Kad4;
        public PlcVars.Word EN_Kad5;
        public PlcVars.Word EN_Kad8;
        public PlcVars.Word EN_Kad11;
        public PlcVars.Word EN_Kad13;
        public PlcVars.Word EN_Kad15;
        public PlcVars.Word EN_Kad17;


        // CHANGE TO HERE

        public Prop1(Sharp7.S7Client client)
        {
            Client = client;

            EloxConnected = new PlcVars.Bit(Client, "bit at 4.0", "Povezano", "Ni povezano", false);
            BarveConnected = new PlcVars.Bit(Client, "bit at 6.0", "Povezano", "Ni povezano", false);
            PC_Connected = new PlcVars.Word(Client, "W 42", "Povezan", "Ni povezan", false);
            NapajanjeOK = new PlcVars.Word(Client, "W 44", "Napaka napajanjalne napetosti", "Napajalna napetost OK", false);

            WATCHDOG_Logo1 = new PlcVars.Word(Client, "DW 274", "", "", false);
            BuzzFromPC_Normal = new PlcVars.Bit(Client, "bit at 248.0", "", "", true);
            BuzzFromPC_Urgent = new PlcVars.Bit(Client, "bit at 248.1", "", "", true);
            BuzzFromPC_Stop = new PlcVars.Bit(Client, "bit at 248.2", "", "", true);

            EloxPoraba = new PlcVars.Word(Client, "W 300", "", "", false);
            BarvePoraba = new PlcVars.Word(Client, "W 302", "", "", false);

            LogoTimeShowOnly = new PlcVars.TimeSet(Client, "W 988", false);

            try
            {
                Watchdog_PC_value = new PlcVars.Word(Client, XML_handler.settingsXML.Element("root").Element("GENERAL").Element("AddressPC_WD").Value, "", "", true);
            }
            catch (Exception)
            {
                Watchdog_PC_value = new PlcVars.Word(Client, "DW 278", "", "", true);
            }


            StartNetElox = new PlcVars.Bit(Client, "bit at 200.0", "True", "False", true);
            StopNetElox = new PlcVars.Bit(Client, "bit at 201.0", "True", "False", true);
            StartNetBarve = new PlcVars.Bit(Client, "bit at 202.0", "True", "False", true);
            StopNetBarve = new PlcVars.Bit(Client, "bit at 203.0", "True", "False", true);

            MaxPowerSet1 = new PlcVars.PowerShow(Client, "W 286", "", "W", 0, 1, true);
            MaxPowerSet2 = new PlcVars.PowerShow(Client, "W 286", "", "W", 0, 1, true);


            EN_Kad1 = new PlcVars.Word(Client, "W 210", "", "", true);
            EN_Kad2 = new PlcVars.Word(Client, "W 212", "", "", true);
            EN_Kad6 = new PlcVars.Word(Client, "W 214", "", "", true);
            EN_Kad7 = new PlcVars.Word(Client, "W 216", "", "", true);
            EN_Kad9 = new PlcVars.Word(Client, "W 218", "", "", true);
            EN_Kad12 = new PlcVars.Word(Client, "W 220", "", "", true);
            EN_Kad14 = new PlcVars.Word(Client, "W 222", "", "", true);
            EN_Kad15 = new PlcVars.Word(Client, "W 224", "", "", true);
            EN_Kad17 = new PlcVars.Word(Client, "W 226", "", "", true);
            EN_Kad18 = new PlcVars.Word(Client, "W 176", "", "", true);
            EN_Kad19 = new PlcVars.Word(Client, "W 230", "", "", true);

            EN_Kad3 = new PlcVars.Word(Client, "W 232", "", "", true);
            EN_Kad4 = new PlcVars.Word(Client, "W 234", "", "", true);
            EN_Kad5 = new PlcVars.Word(Client, "W 236", "", "", true);
            EN_Kad8 = new PlcVars.Word(Client, "W 238", "", "", true);
            EN_Kad11 = new PlcVars.Word(Client, "W 228", "", "", true);
            EN_Kad13 = new PlcVars.Word(Client, "W 242", "", "", true);
            EN_Kad10 = new PlcVars.Word(Client, "W 244", "", "", true);
            EN_Kad16 = new PlcVars.Word(Client, "W 246", "", "", true);



            UpdatePowerConsumption = new Thread(new ThreadStart(UpdateValuesContinuosly))
            {
                Name = "PowerMax Thread",
                IsBackground = true
            };
            
            
        }

        public bool GetENFromIndex(int index, Gui gui)
        {
            if (gui.GuiID == 1)
            {
                switch (index)
                {
                    case 1: if (EN_Kad1.Value > 0) { return true; } else { return false; };
                    case 2: if (EN_Kad2.Value > 0) { return true; } else { return false; };
                    case 3: if (EN_Kad3.Value > 0) { return true; } else { return false; };
                    case 4: if (EN_Kad4.Value > 0) { return true; } else { return false; };
                    case 5: if (EN_Kad5.Value > 0) { return true; } else { return false; };
                    case 6: if (EN_Kad6.Value > 0) { return true; } else { return false; };
                    case 7: if (EN_Kad7.Value > 0) { return true; } else { return false; };
                    case 8: if (EN_Kad8.Value > 0) { return true; } else { return false; };
                    case 9: if (EN_Kad9.Value > 0) { return true; } else { return false; };
                    default: FormControl.bt1.WL("No such device exists. Message source: getENFromIndex() Method. Index was " + index, -1); return false;
                }
            }

            else if (gui.GuiID == 2)
            {
                switch (index)
                {
                    case 1: if (EN_Kad10.Value > 0) { return true; } else { return false; };
                    case 2: if (EN_Kad11.Value > 0) { return true; } else { return false; };
                    case 3: if (EN_Kad12.Value > 0) { return true; } else { return false; };
                    case 4: if (EN_Kad13.Value > 0) { return true; } else { return false; };
                    case 5: if (EN_Kad14.Value > 0) { return true; } else { return false; };
                    case 6: if (EN_Kad15.Value > 0) { return true; } else { return false; };
                    case 7: if (EN_Kad16.Value > 0) { return true; } else { return false; };
                    case 8: if (EN_Kad17.Value > 0) { return true; } else { return false; };
                    case 9: if (EN_Kad18.Value > 0) { return true; } else { return false; };
                    case 10: if (EN_Kad19.Value > 0) { return true; } else { return false; };
                    default: FormControl.bt1.WL("No such device exists. Message source: getENFromIndex() Method. Index was " + index, -1); return false;
                }
            }

            else
            {
                throw new Exception("Gui demanded is not valid or doesn't exsist. Message source getENFromIndex() method.");
            }
                        
        }
                
        public void ToggleENFromIndex(int index, Gui gui)
        {           

            if (gui.GuiID == 1)
            {
                switch (index)
                {
                    
                    case 1: if (EN_Kad1.Value > 0) { EN_Kad1.Value = 0; Gui.WL_UserAction("User turned off Kad1", true); } else { EN_Kad1.Value = 1; Gui.WL_UserAction("User turned on Kad1", true); }; break;
                    case 2: if (EN_Kad2.Value > 0) { EN_Kad2.Value = 0; Gui.WL_UserAction("User turned off Kad2", true); } else { EN_Kad2.Value = 1; Gui.WL_UserAction("User turned on Kad2", true); }; break;
                    case 3: if (EN_Kad3.Value > 0) { EN_Kad3.Value = 0; Gui.WL_UserAction("User turned off Kad3", true); } else { EN_Kad3.Value = 1; Gui.WL_UserAction("User turned on Kad3", true); }; break;
                    case 4: if (EN_Kad4.Value > 0) { EN_Kad4.Value = 0; Gui.WL_UserAction("User turned off Kad4", true); } else { EN_Kad4.Value = 1; Gui.WL_UserAction("User turned on Kad4", true); }; break; 
                    case 5: if (EN_Kad5.Value > 0) { EN_Kad5.Value = 0; Gui.WL_UserAction("User turned off Kad5", true); } else { EN_Kad5.Value = 1; Gui.WL_UserAction("User turned on Kad5", true); }; break;
                    case 6: if (EN_Kad6.Value > 0) { EN_Kad6.Value = 0; Gui.WL_UserAction("User turned off Kad6", true); } else { EN_Kad6.Value = 1; Gui.WL_UserAction("User turned on Kad6", true); }; break; 
                    case 7: if (EN_Kad7.Value > 0) { EN_Kad7.Value = 0; Gui.WL_UserAction("User turned off Kad7", true); } else { EN_Kad7.Value = 1; Gui.WL_UserAction("User turned on Kad7", true); }; break;
                    case 8: if (EN_Kad8.Value > 0) { EN_Kad8.Value = 0; Gui.WL_UserAction("User turned off Kad8", true); } else { EN_Kad8.Value = 1; Gui.WL_UserAction("User turned on Kad8", true); }; break;
                    case 9: if (EN_Kad9.Value > 0) { EN_Kad9.Value = 0; Gui.WL_UserAction("User turned off Kad9", true); } else { EN_Kad9.Value = 1; Gui.WL_UserAction("User turned on Kad9", true); }; break;
                    default: FormControl.bt1.WL("No such device exists. Message source: getENFromIndex() Method. Index was " + index, -1); return;
                }                                
            }

           else if (gui.GuiID == 2)
            {
                switch (index)
                {
                    case 1: if (EN_Kad10.Value > 0) { EN_Kad10.Value = 0; Gui.WL_UserAction("User turned off Kad10", true); } else { EN_Kad10.Value = 1; Gui.WL_UserAction("User turned on Kad10", true); }; break;
                    case 2: if (EN_Kad11.Value > 0) { EN_Kad11.Value = 0; Gui.WL_UserAction("User turned off Kad11", true); } else { EN_Kad11.Value = 1; Gui.WL_UserAction("User turned on Kad11", true); }; break;
                    case 3: if (EN_Kad12.Value > 0) { EN_Kad12.Value = 0; Gui.WL_UserAction("User turned off Kad12", true); } else { EN_Kad12.Value = 1; Gui.WL_UserAction("User turned on Kad12", true); }; break;
                    case 4: if (EN_Kad13.Value > 0) { EN_Kad13.Value = 0; Gui.WL_UserAction("User turned off Kad13", true); } else { EN_Kad13.Value = 1; Gui.WL_UserAction("User turned on Kad13", true); }; break;
                    case 5: if (EN_Kad14.Value > 0) { EN_Kad14.Value = 0; Gui.WL_UserAction("User turned off Kad14", true); } else { EN_Kad14.Value = 1; Gui.WL_UserAction("User turned on Kad14", true); }; break;
                    case 6: if (EN_Kad15.Value > 0) { EN_Kad15.Value = 0; Gui.WL_UserAction("User turned off Kad15", true); } else { EN_Kad15.Value = 1; Gui.WL_UserAction("User turned on Kad15", true); }; break;
                    case 7: if (EN_Kad16.Value > 0) { EN_Kad16.Value = 0; Gui.WL_UserAction("User turned off Kad16", true); } else { EN_Kad16.Value = 1; Gui.WL_UserAction("User turned on Kad16", true); }; break;
                    case 8: if (EN_Kad17.Value > 0) { EN_Kad17.Value = 0; Gui.WL_UserAction("User turned off Kad17", true); } else { EN_Kad17.Value = 1; Gui.WL_UserAction("User turned on Kad17", true); }; break;
                    case 9: if (EN_Kad18.Value > 0) { EN_Kad18.Value = 0; Gui.WL_UserAction("User turned off Kad18", true); } else { EN_Kad18.Value = 1; Gui.WL_UserAction("User turned on Kad18", true); }; break;
                    case 10: if (EN_Kad19.Value > 0) { EN_Kad19.Value = 0; Gui.WL_UserAction("User turned off Kad19", true); } else { EN_Kad19.Value = 1; Gui.WL_UserAction("User turned on Kad19", true); }; break;
                    default: FormControl.bt1.WL("No such device exists. Message source: toggleENFromIndex() Method. Index was " + index, -1); return;
                }
            }

            else
            {
                throw new Exception("Gui demanded is not valid or doesn't exsist. Message source toggleENFromIndex() method.");
            }
        }

            // add datagrid elements for submenu
            public void DatagridRowsInMenuGUI1(SmartDatagrid datagrid)
        {

            int r;
                        
            r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 100;
            r = datagrid.Columns.Add("Value", "Value"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 90;
            datagrid.ColumnHeadersVisible = false;   
            
            r = datagrid.Rows.Add("Max. poraba: ", PropComm.NA); datagrid[0, r].ReadOnly = true;
            datagrid[1, r] = p1;

            r = datagrid.Rows.Add("Trenutna poraba: ", PropComm.NA); datagrid[0, r].ReadOnly = true;

            datagrid.Width = datagrid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + datagrid.RowTemplate.DividerHeight * (datagrid.ColumnCount + 1) + 4;
            datagrid.Height = (datagrid.Rows.GetRowCount(DataGridViewElementStates.None)) * datagrid.RowTemplate.Height + datagrid.Rows.GetRowCount(DataGridViewElementStates.None) * datagrid.RowTemplate.DividerHeight + 2 + 0;

            

        }

        public void DatagridRowsInMenuGUI2(SmartDatagrid datagrid)
        {
            int r;

            r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 100;
            r = datagrid.Columns.Add("Value", "Value"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 90;
            datagrid.ColumnHeadersVisible = false;

            r = datagrid.Rows.Add("Max. Poraba: ", PropComm.NA); datagrid[0, r].ReadOnly = true;
            datagrid[1, r] = p2;

            r = datagrid.Rows.Add("Trenutna poraba: ", PropComm.NA); datagrid[0, r].ReadOnly = true;

            datagrid.Width = datagrid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + datagrid.RowTemplate.DividerHeight * (datagrid.ColumnCount + 1) + 4;
            datagrid.Height = (datagrid.Rows.GetRowCount(DataGridViewElementStates.None)) * datagrid.RowTemplate.Height + datagrid.Rows.GetRowCount(DataGridViewElementStates.None) * datagrid.RowTemplate.DividerHeight + 2 + 0;


            


        }

        public void UpdateValuesContinuosly()
        {

            var datagrid1 = FormControl.Form_gui[1].MaxConsumptionGUI1;
            var datagrid2 = FormControl.Form_gui[2].MaxConsumptionGUI2;
            int valBuffer1 = 0;
            int valBuffer2 = 0;

                

            while (true)
            {
                try
                {
                    if (datagrid1 != null)
                    {
                        if (datagrid1.Rows.Count > 0)
                        {                            
                            MaxPowerSet1.SyncWithPC(datagrid1[1, 0]);                            
                            valBuffer1 = FormControl.Form_gui[1].panelStat.SkupnaPoraba;
                            datagrid1[1, 1].Value = " " + valBuffer1.ToString() + "W";
                        }
                    }

                    if (datagrid2 != null)
                    {
                        if (datagrid2.Rows.Count > 0)
                        {                            
                            MaxPowerSet2.SyncWithPC(datagrid2[1, 0]);                            
                            valBuffer2 = FormControl.Form_gui[2].panelStat.SkupnaPoraba;
                            datagrid2[1, 1].Value = " " + valBuffer2.ToString() + "W";
                        }
                    }
                    
                    Thread.Sleep(500);
                    
                }

                catch (Exception ex)
                {
                    FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
                }
            }
        }
    }
}
