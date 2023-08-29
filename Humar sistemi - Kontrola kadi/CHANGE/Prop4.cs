using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace KontrolaKadi
{
    public class Prop4
    {

        public Sharp7.S7Client Client { get; set; }
        public bool firsTimeSync = true;

        public bool canWriteToPLC = false;
        public bool canReadFromPLC = true;

        public int Cntr { get; set; }

        // KAD 7
        public bool ALARM_Any_7 { get; private set; } = false;
        public bool MUSS_Any_7 { get; private set; } = false;

        public DatagridTypes.Histereza cb1 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb2 = new DatagridTypes.Delta();
        public DatagridTypes.Delta cb3_7 = new DatagridTypes.Delta();
        
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

        public DatagridTypes.TimeDurationSec pl1 = new DatagridTypes.TimeDurationSec("00:01", "59:59");
        public DatagridTypes.TimeDurationSec pl2 = new DatagridTypes.TimeDurationSec("00:01", "59:59");

        public DatagridTypes.TimeSelector td1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp3 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td4 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp4 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td5 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp5 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td6 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp6 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td7 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp7 = new DatagridTypes.TimeSelector();

        // KAD 8
        public bool ALARM_Any_8 { get; private set; } = false;
        public bool MUSS_Any_8 { get; private set; } = false;

        // Public properties - AutoRetrieveable / Writable

        // CHANGE FROM HERE


        // KAD 8

        public PlcVars.Bit Nivo7;
        public PlcVars.Bit DelovanjeGrelca7;
        public PlcVars.TemperatureShow Temperatura17;
        public PlcVars.TemperatureShow Temperatura27;
        public PlcVars.PhShow Ph7;
        public PlcVars.Word Histereza1_7;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla7;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla7;
        public PlcVars.WordForCheckBox Pon_EN_7; public PlcVars.TimeSet timeSetD1_7; public PlcVars.TimeSet timeSetP1_7;
        public PlcVars.WordForCheckBox Tor_EN_7; public PlcVars.TimeSet timeSetD2_7; public PlcVars.TimeSet timeSetP2_7;
        public PlcVars.WordForCheckBox Sre_EN_7; public PlcVars.TimeSet timeSetD3_7; public PlcVars.TimeSet timeSetP3_7;
        public PlcVars.WordForCheckBox Čet_EN_7; public PlcVars.TimeSet timeSetD4_7; public PlcVars.TimeSet timeSetP4_7;
        public PlcVars.WordForCheckBox Pet_EN_7; public PlcVars.TimeSet timeSetD5_7; public PlcVars.TimeSet timeSetP5_7;
        public PlcVars.WordForCheckBox Sob_EN_7; public PlcVars.TimeSet timeSetD6_7; public PlcVars.TimeSet timeSetP6_7;
        public PlcVars.WordForCheckBox Ned_EN_7; public PlcVars.TimeSet timeSetD7_7; public PlcVars.TimeSet timeSetP7_7;
        public PlcVars.Word DeltaOn1_7;
        public PlcVars.Bit Alarmzarazlikotemperature7;
        public PlcVars.Bit Urniki_CikelAktiven7;
        public PlcVars.Bit DelovanjeCrpalkeZaCasDolivanje7;
        public PlcVars.Bit DelovanjeFilterCrpalke7;
        public PlcVars.Bit MUSS_Grelec7;
        public PlcVars.Bit PrisotnostSarze7;
        public PlcVars.BitForCheckBox EN_CasDolivanje7;
        public PlcVars.Bit MUSS_CrpalkaZaCasDolivanje7;
        public PlcVars.Bit MUSS_FiltracijskaCrpalka7;
        public PlcVars.TimeSet CrpalkaZaCasDolivanjeOnDelay7;
        public PlcVars.TimeSet CrpalkaZaCasDolivanjeOffDelay7;
        public PlcVars.PowerShow MocGrelca7;
        public PlcVars.PhShow PhOverLimitForAlarm7;
        public PlcVars.PhShow PhUnderLimitForAlarm7;
        public PlcVars.Bit AlarmPh7;
        public PlcVars.Bit CanStartGrelec7;
        public PlcVars.Bit CanStartCrpalkaZaCasDolivanje7;
        public PlcVars.Bit CanStartFiltracijskaCrpalka7;
        public PlcVars.PowerShow MocCrpalkeZaCasDolivanje7;
        public PlcVars.PowerShow MocFiltracijskeCrpalke7;
        public PlcVars.Word SkupnaPorabaKadi7;
        public PlcVars.Word WATCHDOG;
        public PlcVars.Word DeltaOn2_7;
        public PlcVars.Bit Alarmzatemperaturo7;


        // KAD 8
        public PlcVars.Bit PrisotnostSarze8;


        // CHANGE TO HERE

        public Prop4(Sharp7.S7Client client)
        {
            Client = client;
            WATCHDOG = new PlcVars.Word(Client, "DW 254", "", "", false);

            // KAD 7
            Nivo7 = new PlcVars.Bit(Client, "bit at 10.0", Misc.Checkmark, Misc.Crossmark, false);
            DelovanjeGrelca7 = new PlcVars.Bit(Client, "bit at 11.0", Misc.Checkmark, Misc.Crossmark, false);
            Temperatura17 = new PlcVars.TemperatureShow(Client, "W 12", "", "°C", 0, 0.1F, false);
            Temperatura27 = new PlcVars.TemperatureShow(Client, "W 14", "", "°C", 0, 0.1F, false);
            Ph7 = new PlcVars.PhShow(Client, "W 16", "Ph = ", "", 0, 0.1F, false);
            Histereza1_7 = new PlcVars.Word(Client, "W 18", "", "°C", true);
            TemperaturaAktivnegaCikla7 = new PlcVars.TemperatureShow(Client, "W 22", "", "°C", 0, 0.1F, true);
            TemperaturaPasivnegaCikla7 = new PlcVars.TemperatureShow(Client, "W 24", "", "°C", 0, 0.1F, true);
            DeltaOn1_7 = new PlcVars.Word(Client, "W 70", "", "°C", true);
            Alarmzarazlikotemperature7 = new PlcVars.Bit(Client, "bit at 72.0", "ALARM", "OK", false);
            Urniki_CikelAktiven7 = new PlcVars.Bit(Client, "bit at 73.0", "Aktivno", "Ni aktivno", false);
            DelovanjeCrpalkeZaCasDolivanje7 = new PlcVars.Bit(Client, "bit at 74.0", "Aktivno", "Ni aktivno", false);
            DelovanjeFilterCrpalke7 = new PlcVars.Bit(Client, "bit at 76.0", "Aktivno", "Ni aktivno", false);
            MUSS_Grelec7 = new PlcVars.Bit(Client, "bit at 83.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            PrisotnostSarze7 = new PlcVars.Bit(Client, "bit at 90.0", "Prisotna", "Ni Prisotna", false);
            EN_CasDolivanje7 = new PlcVars.BitForCheckBox(Client, "bit at 92.0", true);
            MUSS_CrpalkaZaCasDolivanje7 = new PlcVars.Bit(Client, "bit at 94.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            MUSS_FiltracijskaCrpalka7 = new PlcVars.Bit(Client, "bit at 96.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            CrpalkaZaCasDolivanjeOnDelay7 = new PlcVars.TimeSet(Client, "W 98", true);
            CrpalkaZaCasDolivanjeOffDelay7 = new PlcVars.TimeSet(Client, "W 100", true);
            MocGrelca7 = new PlcVars.PowerShow(Client, "W 140", "", "W", 0, 1, true);
            PhOverLimitForAlarm7 = new PlcVars.PhShow(Client, "W 142", "", "", 0, 0.1F, true);
            PhUnderLimitForAlarm7 = new PlcVars.PhShow(Client, "W 144", "", "", 0, 0.1F, true);
            AlarmPh7 = new PlcVars.Bit(Client, "bit at 144.0", "ALARM", "OK", false);
            CanStartGrelec7 = new PlcVars.Bit(Client, "bit at 170.0", "Pripravljen", "Čaka", false);
            CanStartCrpalkaZaCasDolivanje7 = new PlcVars.Bit(Client, "bit at 150.0", "Pripravljen", "Čaka", false);
            CanStartFiltracijskaCrpalka7 = new PlcVars.Bit(Client, "bit at 152.0", "Pripravljen", "Čaka", false);
            MocCrpalkeZaCasDolivanje7 = new PlcVars.PowerShow(Client, "W 172", "", "W", 0, 1, true);
            MocFiltracijskeCrpalke7 = new PlcVars.PowerShow(Client, "W 174", "", "W", 0, 1, true);
            SkupnaPorabaKadi7 = new PlcVars.Word(Client, "W 180", "", "W", false);
            DeltaOn2_7 = new PlcVars.Word(Client, "W 184", "", "°C", true);
            Alarmzatemperaturo7 = new PlcVars.Bit(Client, "bit at 186.0", "ALARM", "OK", false);

            Pon_EN_7 = new PlcVars.WordForCheckBox(Client, "W 56", true); timeSetD1_7 = new PlcVars.TimeSet(Client, "W 28", true); timeSetP1_7 = new PlcVars.TimeSet(Client, "W 42", true);
            Tor_EN_7 = new PlcVars.WordForCheckBox(Client, "W 58", true); timeSetD2_7 = new PlcVars.TimeSet(Client, "W 30", true); timeSetP2_7 = new PlcVars.TimeSet(Client, "W 44", true);
            Sre_EN_7 = new PlcVars.WordForCheckBox(Client, "W 60", true); timeSetD3_7 = new PlcVars.TimeSet(Client, "W 32", true); timeSetP3_7 = new PlcVars.TimeSet(Client, "W 46", true);
            Čet_EN_7 = new PlcVars.WordForCheckBox(Client, "W 62", true); timeSetD4_7 = new PlcVars.TimeSet(Client, "W 34", true); timeSetP4_7 = new PlcVars.TimeSet(Client, "W 48", true);
            Pet_EN_7 = new PlcVars.WordForCheckBox(Client, "W 64", true); timeSetD5_7 = new PlcVars.TimeSet(Client, "W 36", true); timeSetP5_7 = new PlcVars.TimeSet(Client, "W 50", true);
            Sob_EN_7 = new PlcVars.WordForCheckBox(Client, "W 66", true); timeSetD6_7 = new PlcVars.TimeSet(Client, "W 38", true); timeSetP6_7 = new PlcVars.TimeSet(Client, "W 52", true);
            Ned_EN_7 = new PlcVars.WordForCheckBox(Client, "W 68", true); timeSetD7_7 = new PlcVars.TimeSet(Client, "W 40", true); timeSetP7_7 = new PlcVars.TimeSet(Client, "W 54", true);


            // KAD 8
            PrisotnostSarze8 = new PlcVars.Bit(Client, "bit at 91.0", "Prisotna", "Ni Prisotna", false);



        }


        // add datagrid elements for submenu
        public void DatagridRowsInSubmenu_7(SmartDatagrid datagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 200;
                r = datagrid.Columns.Add("Vrednost", "Vrednost"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable;

                               

                // CHANGE FROM HERE (only show values)
                r = datagrid.Rows.Add("Sarža: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Temp. 1: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Temp. 2: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Nivo: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Ogrevanje: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Delovanje čas.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Filtracija: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;
                                
                r = datagrid.Rows.Add("Poraba Kadi: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Histereza: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb1;
                                
                r = datagrid.Rows.Add("Delta T za Alarm razlike: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb2;

                r = datagrid.Rows.Add("Alarm razlike Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Delta T za Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb3_7;

                r = datagrid.Rows.Add("Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Vklop grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1;

                r = datagrid.Rows.Add("Vklop čas.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m2;

                r = datagrid.Rows.Add("Vklop fil.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m3;

                r = datagrid.Rows.Add("Moč grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1;

                r = datagrid.Rows.Add("Moč čas.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p2;

                r = datagrid.Rows.Add("Moč fil.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p3;

                r = datagrid.Rows.Add("Ph: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Omogoči čas. črpal.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = en1;

                r = datagrid.Rows.Add("Pulz čas. črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = pl1;

                r = datagrid.Rows.Add("Pavza čas. črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = pl2;

                r = datagrid.Rows.Add("Limit Ph zg.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs1;

                r = datagrid.Rows.Add("Limit Ph sp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs2;

                r = datagrid.Rows.Add("Alarm Ph.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                //comboboxes


                // CHANGE TO HERE

            }
        }

        public void DatagridRowsInSubmenu_8(SmartDatagrid datagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 200;
                r = datagrid.Columns.Add("Vrednost", "Vrednost"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable;

                // CHANGE FROM HERE (only show values)
                r = datagrid.Rows.Add("Sarža: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;





                // CHANGE TO HERE
            }
        }

        public void AddRowsToScheduleDatagrid_7(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
        {

            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Dan", "Dan"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 60;
                r = datagrid.Columns.Add("Vklop", "Vklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Izklop", "Izklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("EN", "EN"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 40;

                r = Statusdatagrid.Columns.Add("Status", "Status"); Statusdatagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; Statusdatagrid.Columns[r].Width = 140; Statusdatagrid.ColumnHeadersVisible = false;
                r = Statusdatagrid.Columns.Add("Status_", "Status_"); Statusdatagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; Statusdatagrid.Columns[r].Width = 340 - Statusdatagrid.Columns[r-1].Width; Statusdatagrid.ColumnHeadersVisible = false;


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

                r = Statusdatagrid.Rows.Add("Status: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = true;

                r = Statusdatagrid.Rows.Add("Temp.Aktivnega cikla: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = false;
                Statusdatagrid[1, r] = ts1;

                r = Statusdatagrid.Rows.Add("Temp.Pasivnega cikla: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = false;
                Statusdatagrid[1, r] = ts2;

                // CHANGE TO HERE

            }
        }

        public void AddRowsToScheduleDatagrid_8(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Dan", "Dan"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 60;
                r = datagrid.Columns.Add("Vklop", "Vklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Izklop", "Izklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("EN", "EN"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 40;


                // CHANGE FROM HERE (only show values)

                //comboboxes


                // CHANGE TO HERE
            }

        }


        public void UpdateValues_7(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC                     
                        Nivo7.SyncWithPC(Main_datagrid[1, 3]);
                        DelovanjeGrelca7.SyncWithPC(Main_datagrid[1, 4]);
                        Temperatura17.SyncWithPC(Main_datagrid[1, 1]);
                        Temperatura27.SyncWithPC(Main_datagrid[1, 2]);
                        Ph7.SyncWithPC(Main_datagrid[1, 19]);
                        Histereza1_7.SyncWithPC(Main_datagrid[1, 8]);  
                        
                        DeltaOn1_7.SyncWithPC(Main_datagrid[1, 9]);
                        Alarmzarazlikotemperature7.SyncWithPC(Main_datagrid[1, 10]);

                        DeltaOn2_7.SyncWithPC(Main_datagrid[1, 11]);
                        Alarmzatemperaturo7.SyncWithPC(Main_datagrid[1, 12]);

                        DelovanjeCrpalkeZaCasDolivanje7.SyncWithPC(Main_datagrid[1, 5]);
                        DelovanjeFilterCrpalke7.SyncWithPC(Main_datagrid[1, 6]);
                        MUSS_Grelec7.SyncWithPC(Main_datagrid[1, 13]);
                        PrisotnostSarze7.SyncWithPC(Main_datagrid[1, 0]);
                        EN_CasDolivanje7.SyncWithPC(Main_datagrid[1, 20]);
                        MUSS_CrpalkaZaCasDolivanje7.SyncWithPC(Main_datagrid[1, 14]);
                        MUSS_FiltracijskaCrpalka7.SyncWithPC(Main_datagrid[1, 15]);
                        MocGrelca7.SyncWithPC(Main_datagrid[1, 16]);
                        CrpalkaZaCasDolivanjeOnDelay7.SyncWithPC(Main_datagrid[1, 21], 1);
                        CrpalkaZaCasDolivanjeOffDelay7.SyncWithPC(Main_datagrid[1, 22], 1);
                        PhOverLimitForAlarm7.SyncWithPC(Main_datagrid[1, 23]);
                        PhUnderLimitForAlarm7.SyncWithPC(Main_datagrid[1, 24]);
                        AlarmPh7.SyncWithPC(Main_datagrid[1, 25]);
                        //CanStartGrelec7.SyncWithPC(Main_datagrid[1, 0]);
                        MocCrpalkeZaCasDolivanje7.SyncWithPC(Main_datagrid[1, 17]);
                        MocFiltracijskeCrpalke7.SyncWithPC(Main_datagrid[1, 18]);
                        SkupnaPorabaKadi7.SyncWithPC(Main_datagrid[1, 7]);

                        Urniki_CikelAktiven7.SyncWithPC(Statusdatagrid[1, 0]);
                        TemperaturaAktivnegaCikla7.SyncWithPC(Statusdatagrid[1, 1]);
                        TemperaturaPasivnegaCikla7.SyncWithPC(Statusdatagrid[1, 2]);
                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {
                        Pon_EN_7.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN_7.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN_7.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN_7.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN_7.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN_7.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN_7.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1_7.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2_7.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3_7.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4_7.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5_7.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6_7.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7_7.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1_7.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2_7.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3_7.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4_7.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5_7.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6_7.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7_7.SyncWithPC(Shedule_datagrid[2, 6], 1);

                        // END CHANGE
                    }                    
                }
                WarningLevelAssesment_Kad7();                
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        public void UpdateValues_8(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze8.SyncWithPC(Main_datagrid[1, 0]);


                        // END CHANGE

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                    }


                }
                WarningLevelAssesment_Kad8();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }
        private void WarningLevelAssesment_Kad7()
        {
            if (Alarmzarazlikotemperature7.Value || AlarmPh7.Value || Alarmzatemperaturo7.Value || !Nivo7.Value)
            {
                ALARM_Any_7 = true;                
            }
            else
            {
                ALARM_Any_7 = false;                
            }
            if (MUSS_CrpalkaZaCasDolivanje7.Value || MUSS_FiltracijskaCrpalka7.Value || MUSS_Grelec7.Value)
            {
                MUSS_Any_7 = true;
            }
            else
            {
                MUSS_Any_7 = false;
            }
        }

        private void WarningLevelAssesment_Kad8()
        {
            ALARM_Any_8 = false;
            MUSS_Any_8 = false;
        }        
    }
}
