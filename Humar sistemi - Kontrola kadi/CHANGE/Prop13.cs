using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace KontrolaKadi
{
    public class Prop13
    {

        public Sharp7.S7Client Client { get; set; }
        public bool firsTimeSync = true;

        public bool canWriteToPLC = false;
        public bool canReadFromPLC = true;

        public int Cntr { get; set; }


        public DatagridTypes.Histereza cb1 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb2 = new DatagridTypes.Delta();
        public DatagridTypes.TempSet ts1 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.TempSet ts2 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.MussLauf m1 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m2 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m3 = new DatagridTypes.MussLauf();
        public DatagridTypes.PwrSet p1 = new DatagridTypes.PwrSet(500, 3800, 100);
        public DatagridTypes.PwrSet p2 = new DatagridTypes.PwrSet(100, 1500, 100);
        public DatagridTypes.PwrSet p3 = new DatagridTypes.PwrSet(100, 1500, 100);

        public DatagridTypes.CheckBox chk1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk3 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk4 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk5 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk6 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk7 = new DatagridTypes.CheckBox();

        public DatagridTypes.CheckBox en1 = new DatagridTypes.CheckBox();
        public DatagridTypes.PhSet phs1 = new DatagridTypes.PhSet();
        public DatagridTypes.PhSet phs2 = new DatagridTypes.PhSet();

        public DatagridTypes.TimeSelector td1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp3 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td4 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp4 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td5 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp5 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td6 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp6 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td7 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp7 = new DatagridTypes.TimeSelector();





        // Public properties - AutoRetrieveable / Writable

        // CHANGE FROM HERE

        
        
        public PlcVars.Bit Nivo12;
        public PlcVars.Bit DelovanjeGrelca12;
        public PlcVars.TemperatureShow Temperatura112;
        public PlcVars.TemperatureShow Temperatura212;
        public PlcVars.PhShow Ph12;
        public PlcVars.Word Histereza1_12;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla12;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla12;
        public PlcVars.WordForCheckBox Pon_EN; public PlcVars.TimeSet timeSetD1; public PlcVars.TimeSet timeSetP1;
        public PlcVars.WordForCheckBox Tor_EN; public PlcVars.TimeSet timeSetD2; public PlcVars.TimeSet timeSetP2;
        public PlcVars.WordForCheckBox Sre_EN; public PlcVars.TimeSet timeSetD3; public PlcVars.TimeSet timeSetP3;
        public PlcVars.WordForCheckBox Čet_EN; public PlcVars.TimeSet timeSetD4; public PlcVars.TimeSet timeSetP4;
        public PlcVars.WordForCheckBox Pet_EN; public PlcVars.TimeSet timeSetD5; public PlcVars.TimeSet timeSetP5;
        public PlcVars.WordForCheckBox Sob_EN; public PlcVars.TimeSet timeSetD6; public PlcVars.TimeSet timeSetP6;
        public PlcVars.WordForCheckBox Ned_EN; public PlcVars.TimeSet timeSetD7; public PlcVars.TimeSet timeSetP7;
        public PlcVars.Word DeltaOn12;
        public PlcVars.Bit Alarmzarazlikotemperature12;
        public PlcVars.Bit Urniki_CikelAktiven12;
        public PlcVars.Bit DelovanjeFilterCrpalke12;
        public PlcVars.Bit MUSS_Grelec12;
        public PlcVars.Bit PrisotnostSarze12;       
        public PlcVars.Bit MUSS_FiltracijskaCrpalka12;
        public PlcVars.PowerShow MocGrelca12;
        public PlcVars.PhShow PhOverLimitForAlarm12;
        public PlcVars.PhShow PhUnderLimitForAlarm12;
        public PlcVars.Bit AlarmPh12;
        public PlcVars.Bit CanStartGrelec12;
        public PlcVars.Bit CanStartCrpalka12; 
        public PlcVars.PowerShow MocFiltracijskeCrpalke12;
        public PlcVars.Word SkupnaPorabaKadi12;
        

        // CHANGE TO HERE

        public Prop13(Sharp7.S7Client client)
        {
             Client = client;
             Nivo12 = new PlcVars.Bit(Client, "bit at 310.0", "OK", "NAPAKA", false);
             DelovanjeGrelca12 = new PlcVars.Bit(Client, "bit at 311.0", Misc.Checkmark, Misc.Crossmark, false);
             Temperatura112 = new PlcVars.TemperatureShow(Client, "W 312", "", "°C", 0, 0.1F, false);
             Temperatura212 = new PlcVars.TemperatureShow(Client, "W 314", "", "°C", 0, 0.1F, false);
             Ph12 = new PlcVars.PhShow(Client, "W 316", "Ph = ", "", 0, 0.1F, false);
             Histereza1_12 = new PlcVars.Word(Client, "W 318", "", "°C", true);
             TemperaturaAktivnegaCikla12 = new PlcVars.TemperatureShow(Client, "W 322", "", "°C", 0, 0.1F, true);
             TemperaturaPasivnegaCikla12 = new PlcVars.TemperatureShow(Client, "W 324", "", "°C", 0, 0.1F, true);
             DeltaOn12 = new PlcVars.Word(Client, "W 370", "", "°C", true);
             Alarmzarazlikotemperature12 = new PlcVars.Bit(Client, "bit at 372.0", "ALARM", "OK", false);
             Urniki_CikelAktiven12 = new PlcVars.Bit(Client, "bit at 373.0", "Aktivno", "Ni aktivno", false);             
             DelovanjeFilterCrpalke12 = new PlcVars.Bit(Client, "bit at 376.0", "Aktivno", "Ni aktivno", false);
             MUSS_Grelec12 = new PlcVars.Bit(Client, "bit at 383.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
             PrisotnostSarze12 = new PlcVars.Bit(Client, "bit at 390.0", "Prisotna", "Ni Prisotna", false);                         
             MUSS_FiltracijskaCrpalka12 = new PlcVars.Bit(Client, "bit at 382.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
             MocGrelca12 = new PlcVars.PowerShow(Client, "W 440", "", "W", 0, 1, true);
             PhOverLimitForAlarm12 = new PlcVars.PhShow(Client, "W 446", "Ph ", "", 0, 0.1F, true);
             PhUnderLimitForAlarm12 = new PlcVars.PhShow(Client, "W 448", "Ph ", "", 0, 0.1F, true);
             AlarmPh12 = new PlcVars.Bit(Client, "bit at 450.0", "ALARM", "OK", false);
             CanStartGrelec12 = new PlcVars.Bit(Client, "bit at 472.0", "Pripravljen", "Čaka", false);
             CanStartCrpalka12 = new PlcVars.Bit(Client, "bit at 458.0", "Pripravljen", "Čaka", false);
             MocFiltracijskeCrpalke12 = new PlcVars.PowerShow(Client, "W 444", "", "W", 0, 1, true);
             SkupnaPorabaKadi12 = new PlcVars.Word(Client, "W 480", "", "", false);
                                     

            Pon_EN = new PlcVars.WordForCheckBox(Client, "W 356", true); timeSetD1 = new PlcVars.TimeSet(Client, "W 328", true); timeSetP1 = new PlcVars.TimeSet(Client, "W 342", true);
            Tor_EN = new PlcVars.WordForCheckBox(Client, "W 358", true); timeSetD2 = new PlcVars.TimeSet(Client, "W 330", true); timeSetP2 = new PlcVars.TimeSet(Client, "W 344", true);
            Sre_EN = new PlcVars.WordForCheckBox(Client, "W 360", true); timeSetD3 = new PlcVars.TimeSet(Client, "W 332", true); timeSetP3 = new PlcVars.TimeSet(Client, "W 346", true);
            Čet_EN = new PlcVars.WordForCheckBox(Client, "W 362", true); timeSetD4 = new PlcVars.TimeSet(Client, "W 334", true); timeSetP4 = new PlcVars.TimeSet(Client, "W 348", true);
            Pet_EN = new PlcVars.WordForCheckBox(Client, "W 364", true); timeSetD5 = new PlcVars.TimeSet(Client, "W 336", true); timeSetP5 = new PlcVars.TimeSet(Client, "W 350", true);
            Sob_EN = new PlcVars.WordForCheckBox(Client, "W 366", true); timeSetD6 = new PlcVars.TimeSet(Client, "W 338", true); timeSetP6 = new PlcVars.TimeSet(Client, "W 352", true);
            Ned_EN = new PlcVars.WordForCheckBox(Client, "W 368", true); timeSetD7 = new PlcVars.TimeSet(Client, "W 340", true); timeSetP7 = new PlcVars.TimeSet(Client, "W 354", true);
        }


        // add datagrid elements for submenu
        public void DatagridRowsInSubmenu(SmartDatagrid datagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Vrednost", "Vrednost"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable;



                // CHANGE FROM HERE (only show values)
                r = datagrid.Rows.Add("Sarža: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Temp. 1: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Temp. 2: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Nivo: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Ogrevanje: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Filtracija: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Status: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Poraba Kadi: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Histereza: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb1;

                r = datagrid.Rows.Add("Temp.Aktivnega cikla: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = ts1;

                r = datagrid.Rows.Add("Temp.Pasivnega cikla: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = ts2;

                r = datagrid.Rows.Add("Delta T za Alarm: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb2;

                r = datagrid.Rows.Add("Alarm razlike Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Vklop grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1;

                r = datagrid.Rows.Add("Vklop fil.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m3;

                r = datagrid.Rows.Add("Moč grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1;

                r = datagrid.Rows.Add("Moč fil.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p3;

                r = datagrid.Rows.Add("Ph: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;

                r = datagrid.Rows.Add("Limit Ph zg.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs1;

                r = datagrid.Rows.Add("Limit Ph sp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs2;

                r = datagrid.Rows.Add("Alarm Ph.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                //comboboxes


                // CHANGE TO HERE

            }
        }

        public void AddRowsToScheduleDatagrid(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
        {

            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Dan", "Dan"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 60;
                r = datagrid.Columns.Add("Vklop", "Vklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Izklop", "Izklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("EN", "EN"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 40;

                
                // CHANGE FROM HERE (only show values)
                r = datagrid.Rows.Add("Pon: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td1; datagrid[2, r] = tp1;
                datagrid[3, r] = chk1;
                r = datagrid.Rows.Add("Tor: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td2; datagrid[2, r] = tp2;
                datagrid[3, r] = chk2;
                r = datagrid.Rows.Add("Sre: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td3; datagrid[2, r] = tp3;
                datagrid[3, r] = chk3;
                r = datagrid.Rows.Add("Čet: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td4; datagrid[2, r] = tp4;
                datagrid[3, r] = chk4;
                r = datagrid.Rows.Add("Pet: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td5; datagrid[2, r] = tp5;
                datagrid[3, r] = chk5;
                r = datagrid.Rows.Add("Sob: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td6; datagrid[2, r] = tp6;
                datagrid[3, r] = chk6;
                r = datagrid.Rows.Add("Ned: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td7; datagrid[2, r] = tp7;
                datagrid[3, r] = chk7;

                //comboboxes


                // CHANGE TO HERE

            }
        }


        public void UpdateValues(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC                     
                        Nivo12.SyncWithPC(Main_datagrid[1, 3]);
                        DelovanjeGrelca12.SyncWithPC(Main_datagrid[1, 4]);
                        Temperatura112.SyncWithPC(Main_datagrid[1, 1]);
                        Temperatura212.SyncWithPC(Main_datagrid[1, 2]);
                        Ph12.SyncWithPC(Main_datagrid[1, 17]);
                        Histereza1_12.SyncWithPC(Main_datagrid[1, 8]);
                        TemperaturaAktivnegaCikla12.SyncWithPC(Main_datagrid[1, 9]);
                        TemperaturaPasivnegaCikla12.SyncWithPC(Main_datagrid[1, 10]);
                        DeltaOn12.SyncWithPC(Main_datagrid[1, 11]);
                        Alarmzarazlikotemperature12.SyncWithPC(Main_datagrid[1, 12]);
                        Urniki_CikelAktiven12.SyncWithPC(Main_datagrid[1, 6]);
                        DelovanjeFilterCrpalke12.SyncWithPC(Main_datagrid[1, 5]);
                        MUSS_Grelec12.SyncWithPC(Main_datagrid[1, 13]);
                        PrisotnostSarze12.SyncWithPC(Main_datagrid[1, 0]);
                        MUSS_FiltracijskaCrpalka12.SyncWithPC(Main_datagrid[1, 14]);
                        MocGrelca12.SyncWithPC(Main_datagrid[1, 15]);
                        PhOverLimitForAlarm12.SyncWithPC(Main_datagrid[1, 18]);
                        PhUnderLimitForAlarm12.SyncWithPC(Main_datagrid[1, 19]);
                        AlarmPh12.SyncWithPC(Main_datagrid[1, 20]);
                        //CanStartGrelec112.SyncWithPC(Main_datagrid[1, 0]);      
                        //CanStartCrpalka112.SyncWithPC(Main_datagrid[1, 0]);                     
                        MocFiltracijskeCrpalke12.SyncWithPC(Main_datagrid[1, 16]);
                        SkupnaPorabaKadi12.SyncWithPC(Main_datagrid[1, 7]);

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {
                        Pon_EN.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7.SyncWithPC(Shedule_datagrid[2, 6], 1);

                        // END CHANGE
                    }


                }
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

    }
}
