using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace KontrolaKadi
{
    public class Prop15
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



        public PlcVars.Bit Nivo14;
        public PlcVars.Bit DelovanjeGrelca14;
        public PlcVars.TemperatureShow Temperatura114;
        public PlcVars.TemperatureShow Temperatura214;
        public PlcVars.PhShow Ph14;
        public PlcVars.Word Histereza1_14;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla14;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla14;
        public PlcVars.WordForCheckBox Pon_EN; public PlcVars.TimeSet timeSetD1; public PlcVars.TimeSet timeSetP1;
        public PlcVars.WordForCheckBox Tor_EN; public PlcVars.TimeSet timeSetD2; public PlcVars.TimeSet timeSetP2;
        public PlcVars.WordForCheckBox Sre_EN; public PlcVars.TimeSet timeSetD3; public PlcVars.TimeSet timeSetP3;
        public PlcVars.WordForCheckBox Čet_EN; public PlcVars.TimeSet timeSetD4; public PlcVars.TimeSet timeSetP4;
        public PlcVars.WordForCheckBox Pet_EN; public PlcVars.TimeSet timeSetD5; public PlcVars.TimeSet timeSetP5;
        public PlcVars.WordForCheckBox Sob_EN; public PlcVars.TimeSet timeSetD6; public PlcVars.TimeSet timeSetP6;
        public PlcVars.WordForCheckBox Ned_EN; public PlcVars.TimeSet timeSetD7; public PlcVars.TimeSet timeSetP7;
        public PlcVars.Word DeltaOn14;
        public PlcVars.Bit Alarmzarazlikotemperature14;
        public PlcVars.Bit Urniki_CikelAktiven14;
        public PlcVars.Bit DelovanjeFilterCrpalke14;
        public PlcVars.Bit MUSS_Grelec14;
        public PlcVars.Bit PrisotnostSarze14;
        public PlcVars.Bit MUSS_FiltracijskaCrpalka14;
        public PlcVars.PowerShow MocGrelca14;
        public PlcVars.PhShow PhOverLimitForAlarm14;
        public PlcVars.PhShow PhUnderLimitForAlarm14;
        public PlcVars.Bit AlarmPh14;
        public PlcVars.Bit CanStartGrelec14;
        public PlcVars.Bit CanStartCrpalka14;
        public PlcVars.PowerShow MocFiltracijskeCrpalke14;
        public PlcVars.Word SkupnaPorabaKadi14;
        

        // CHANGE TO HERE

        public Prop15(Sharp7.S7Client client)
        {
             Client = client;
             Nivo14= new PlcVars.Bit(Client, "bit at 10.0", "OK", "NAPAKA", false);
             DelovanjeGrelca14= new PlcVars.Bit(Client, "bit at 11.0", Misc.Checkmark, Misc.Crossmark, false);
             Temperatura114= new PlcVars.TemperatureShow(Client, "W 12", "", "°C", 0, 0.1F, false);
             Temperatura214 = new PlcVars.TemperatureShow(Client, "W 14", "", "°C", 0, 0.1F, false);
             Ph14= new PlcVars.PhShow(Client, "W 16", "Ph = ", "", 0, 0.1F, false);
             Histereza1_14= new PlcVars.Word(Client, "W 18", "", "°C", true);
             TemperaturaAktivnegaCikla14= new PlcVars.TemperatureShow(Client, "W 22", "", "°C", 0, 0.1F, true);
             TemperaturaPasivnegaCikla14 = new PlcVars.TemperatureShow(Client, "W 24", "", "°C", 0, 0.1F, true);
             DeltaOn14= new PlcVars.Word(Client, "W 70", "", "°C", true);
             Alarmzarazlikotemperature14= new PlcVars.Bit(Client, "bit at 72.0", "ALARM", "OK", false);
             Urniki_CikelAktiven14= new PlcVars.Bit(Client, "bit at 73.0", "Aktivno", "Ni aktivno", false);             
             DelovanjeFilterCrpalke14= new PlcVars.Bit(Client, "bit at 76.0", "Aktivno", "Ni aktivno", false);
             MUSS_Grelec14= new PlcVars.Bit(Client, "bit at 83.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
             PrisotnostSarze14= new PlcVars.Bit(Client, "bit at 90.0", "Prisotna", "Ni Prisotna", false);                         
             MUSS_FiltracijskaCrpalka14= new PlcVars.Bit(Client, "bit at 82.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
             MocGrelca14= new PlcVars.PowerShow(Client, "W 140", "", "W", 0, 1, true);
             PhOverLimitForAlarm14= new PlcVars.PhShow(Client, "W 146", "Ph ", "", 0, 0.1F, true);
             PhUnderLimitForAlarm14= new PlcVars.PhShow(Client, "W 148", "Ph ", "", 0, 0.1F, true);
             AlarmPh14= new PlcVars.Bit(Client, "bit at 150.0", "ALARM", "OK", false);
             CanStartGrelec14= new PlcVars.Bit(Client, "bit at 172.0", "Pripravljen", "Čaka", false);
             CanStartCrpalka14= new PlcVars.Bit(Client, "bit at 158.0", "Pripravljen", "Čaka", false);
             MocFiltracijskeCrpalke14= new PlcVars.PowerShow(Client, "W 144", "", "W", 0, 1, true);
             SkupnaPorabaKadi14= new PlcVars.Word(Client, "W 180", "", "", false);
                                     

            Pon_EN = new PlcVars.WordForCheckBox(Client, "W 56", true); timeSetD1 = new PlcVars.TimeSet(Client, "W 28", true); timeSetP1 = new PlcVars.TimeSet(Client, "W 42", true);
            Tor_EN = new PlcVars.WordForCheckBox(Client, "W 58", true); timeSetD2 = new PlcVars.TimeSet(Client, "W 30", true); timeSetP2 = new PlcVars.TimeSet(Client, "W 44", true);
            Sre_EN = new PlcVars.WordForCheckBox(Client, "W 60", true); timeSetD3 = new PlcVars.TimeSet(Client, "W 32", true); timeSetP3 = new PlcVars.TimeSet(Client, "W 46", true);
            Čet_EN = new PlcVars.WordForCheckBox(Client, "W 62", true); timeSetD4 = new PlcVars.TimeSet(Client, "W 34", true); timeSetP4 = new PlcVars.TimeSet(Client, "W 48", true);
            Pet_EN = new PlcVars.WordForCheckBox(Client, "W 64", true); timeSetD5 = new PlcVars.TimeSet(Client, "W 36", true); timeSetP5 = new PlcVars.TimeSet(Client, "W 50", true);
            Sob_EN = new PlcVars.WordForCheckBox(Client, "W 66", true); timeSetD6 = new PlcVars.TimeSet(Client, "W 38", true); timeSetP6 = new PlcVars.TimeSet(Client, "W 52", true);
            Ned_EN = new PlcVars.WordForCheckBox(Client, "W 68", true); timeSetD7 = new PlcVars.TimeSet(Client, "W 40", true); timeSetP7 = new PlcVars.TimeSet(Client, "W 54", true);
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
                        Nivo14.SyncWithPC(Main_datagrid[1, 3]);
                        DelovanjeGrelca14.SyncWithPC(Main_datagrid[1, 4]);
                        Temperatura114.SyncWithPC(Main_datagrid[1, 1]);
                        Temperatura214.SyncWithPC(Main_datagrid[1, 2]);
                        Ph14.SyncWithPC(Main_datagrid[1, 17]);
                        Histereza1_14.SyncWithPC(Main_datagrid[1, 8]);
                        TemperaturaAktivnegaCikla14.SyncWithPC(Main_datagrid[1, 9]);
                        TemperaturaPasivnegaCikla14.SyncWithPC(Main_datagrid[1, 10]);
                        DeltaOn14.SyncWithPC(Main_datagrid[1, 11]);
                        Alarmzarazlikotemperature14.SyncWithPC(Main_datagrid[1, 12]);
                        Urniki_CikelAktiven14.SyncWithPC(Main_datagrid[1, 6]);
                        DelovanjeFilterCrpalke14.SyncWithPC(Main_datagrid[1, 5]);
                        MUSS_Grelec14.SyncWithPC(Main_datagrid[1, 13]);
                        PrisotnostSarze14.SyncWithPC(Main_datagrid[1, 0]);
                        MUSS_FiltracijskaCrpalka14.SyncWithPC(Main_datagrid[1, 14]);
                        MocGrelca14.SyncWithPC(Main_datagrid[1, 15]);
                        PhOverLimitForAlarm14.SyncWithPC(Main_datagrid[1, 18]);
                        PhUnderLimitForAlarm14.SyncWithPC(Main_datagrid[1, 19]);
                        AlarmPh14.SyncWithPC(Main_datagrid[1, 20]);
                        //CanStartGrelec14.SyncWithPC(Main_datagrid[1, 0]);      
                        //CanStartCrpalka14.SyncWithPC(Main_datagrid[1, 0]);                     
                        MocFiltracijskeCrpalke14.SyncWithPC(Main_datagrid[1, 16]);
                        SkupnaPorabaKadi14.SyncWithPC(Main_datagrid[1, 7]);

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
