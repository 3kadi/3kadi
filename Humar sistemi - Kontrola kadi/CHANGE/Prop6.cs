using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace KontrolaKadi
{
    public class Prop6
    {

        public Sharp7.S7Client Client { get; set; }
        public bool firsTimeSync = true;

        public bool canWriteToPLC = false;
        public bool canReadFromPLC = true;

        public int Cntr { get; set; }

        // KAD 12
        public bool ALARM_Any_12 { get; private set; } = false;
        public bool MUSS_Any_12 { get; private set; } = false;

        public DatagridTypes.Histereza cb1_1 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb2_1 = new DatagridTypes.Delta();
        public DatagridTypes.Delta cb3_10 = new DatagridTypes.Delta();
        public DatagridTypes.TempSet ts1_1 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.TempSet ts2_1 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.MussLauf m1_1 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m2_1 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m3_1 = new DatagridTypes.MussLauf();
        public DatagridTypes.PwrSet p1_1 = new DatagridTypes.PwrSet(500, 3800, 100);
        public DatagridTypes.PwrSet p2_1 = new DatagridTypes.PwrSet(100, 1500, 100);
        public DatagridTypes.PwrSet p3_1 = new DatagridTypes.PwrSet(0, 1500, 100);

        public DatagridTypes.CheckBox chk1_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk2_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk3_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk4_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk5_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk6_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk7_1 = new DatagridTypes.CheckBox();

        public DatagridTypes.CheckBox en1_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.PhSet phs1_1 = new DatagridTypes.PhSet();
        public DatagridTypes.PhSet phs2_1 = new DatagridTypes.PhSet();

        public DatagridTypes.TimeSelector td1_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp1_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td2_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp2_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td3_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp3_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td4_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp4_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td5_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp5_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td6_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp6_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td7_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp7_1 = new DatagridTypes.TimeSelector();

        // KAD 10
        public bool ALARM_Any_10 { get; private set; } = false;
        public bool MUSS_Any_10 { get; private set; } = false;

        // KAD 14
        public bool ALARM_Any_14 { get; private set; } = false;
        public bool MUSS_Any_14 { get; private set; } = false;

        public DatagridTypes.Histereza cb1_2 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb2_2 = new DatagridTypes.Delta();
        public DatagridTypes.Delta cb3_12 = new DatagridTypes.Delta();
        public DatagridTypes.TempSet ts1_2 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.TempSet ts2_2 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.MussLauf m1_2 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m2_2 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m3_2 = new DatagridTypes.MussLauf();
        public DatagridTypes.PwrSet p1_2 = new DatagridTypes.PwrSet(500, 3800, 100);
        public DatagridTypes.PwrSet p2_2 = new DatagridTypes.PwrSet(100, 1500, 100);
        public DatagridTypes.PwrSet p3_2 = new DatagridTypes.PwrSet(0, 1500, 100);

        public DatagridTypes.CheckBox chk1_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk2_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk3_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk4_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk5_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk6_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk7_2 = new DatagridTypes.CheckBox();

        public DatagridTypes.CheckBox en1_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.PhSet phs1_2 = new DatagridTypes.PhSet();
        public DatagridTypes.PhSet phs2_2 = new DatagridTypes.PhSet();

        public DatagridTypes.TimeSelector td1_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp1_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td2_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp2_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td3_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp3_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td4_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp4_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td5_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp5_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td6_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp6_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td7_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp7_2 = new DatagridTypes.TimeSelector();

        // KAD 13
        public bool ALARM_Any_13 { get; private set; } = false;
        public bool MUSS_Any_13 { get; private set; } = false;

        // Public properties - AutoRetrieveable / Writable

        // CHANGE FROM HERE


        // KAD 12
        public PlcVars.Bit Nivo12;
        public PlcVars.Bit DelovanjeGrelca12;
        public PlcVars.TemperatureShow Temperatura112;
        public PlcVars.TemperatureShow Temperatura212;
        public PlcVars.PhShow Ph12;
        public PlcVars.Word Histereza1_12;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla12;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla12;
        public PlcVars.WordForCheckBox Pon_EN_12; public PlcVars.TimeSet timeSetD1_12; public PlcVars.TimeSet timeSetP1_12;
        public PlcVars.WordForCheckBox Tor_EN_12; public PlcVars.TimeSet timeSetD2_12; public PlcVars.TimeSet timeSetP2_12;
        public PlcVars.WordForCheckBox Sre_EN_12; public PlcVars.TimeSet timeSetD3_12; public PlcVars.TimeSet timeSetP3_12;
        public PlcVars.WordForCheckBox Čet_EN_12; public PlcVars.TimeSet timeSetD4_12; public PlcVars.TimeSet timeSetP4_12;
        public PlcVars.WordForCheckBox Pet_EN_12; public PlcVars.TimeSet timeSetD5_12; public PlcVars.TimeSet timeSetP5_12;
        public PlcVars.WordForCheckBox Sob_EN_12; public PlcVars.TimeSet timeSetD6_12; public PlcVars.TimeSet timeSetP6_12;
        public PlcVars.WordForCheckBox Ned_EN_12; public PlcVars.TimeSet timeSetD7_12; public PlcVars.TimeSet timeSetP7_12;
        public PlcVars.Word DeltaOn1_12;
        public PlcVars.Bit Alarmzarazlikotemperature12;
        public PlcVars.Bit Urniki_CikelAktiven12;
        public PlcVars.Bit DelovanjeMesanja12;
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
        public PlcVars.Word DeltaOn2_12;
        public PlcVars.Bit Alarmzatemperaturo12;


        // KAD 10
        public PlcVars.Bit PrisotnostSarze10;


        // KAD 14
        public PlcVars.Bit Nivo14;
        public PlcVars.Bit DelovanjeGrelca14;
        public PlcVars.TemperatureShow Temperatura114;
        public PlcVars.TemperatureShow Temperatura214;
        public PlcVars.PhShow Ph14;
        public PlcVars.Word Histereza1_14;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla14;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla14;
        public PlcVars.WordForCheckBox Pon_EN_14; public PlcVars.TimeSet timeSetD1_14; public PlcVars.TimeSet timeSetP1_14;
        public PlcVars.WordForCheckBox Tor_EN_14; public PlcVars.TimeSet timeSetD2_14; public PlcVars.TimeSet timeSetP2_14;
        public PlcVars.WordForCheckBox Sre_EN_14; public PlcVars.TimeSet timeSetD3_14; public PlcVars.TimeSet timeSetP3_14;
        public PlcVars.WordForCheckBox Čet_EN_14; public PlcVars.TimeSet timeSetD4_14; public PlcVars.TimeSet timeSetP4_14;
        public PlcVars.WordForCheckBox Pet_EN_14; public PlcVars.TimeSet timeSetD5_14; public PlcVars.TimeSet timeSetP5_14;
        public PlcVars.WordForCheckBox Sob_EN_14; public PlcVars.TimeSet timeSetD6_14; public PlcVars.TimeSet timeSetP6_14;
        public PlcVars.WordForCheckBox Ned_EN_14; public PlcVars.TimeSet timeSetD7_14; public PlcVars.TimeSet timeSetP7_14;
        public PlcVars.Word DeltaOn1_14;
        public PlcVars.Bit Alarmzarazlikotemperature14;
        public PlcVars.Bit Urniki_CikelAktiven14;
        public PlcVars.Bit DelovanjeMesanja14;
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
        public PlcVars.Word DeltaOn2_14;
        public PlcVars.Bit Alarmzatemperaturo14;
        public PlcVars.Word WATCHDOG;


        // KAD 13
        public PlcVars.Bit PrisotnostSarze13;


        // CHANGE TO HERE

        public Prop6(Sharp7.S7Client client)
        {
            Client = client;
            WATCHDOG = new PlcVars.Word(Client, "DW 262", "", "", false);

            // KAD 12
            Nivo12 = new PlcVars.Bit(Client, "bit at 10.0", Misc.Checkmark, Misc.Crossmark, false);
            DelovanjeGrelca12 = new PlcVars.Bit(Client, "bit at 11.0", Misc.Checkmark, Misc.Crossmark, false);
            Temperatura112 = new PlcVars.TemperatureShow(Client, "W 12", "", "°C", 0, 0.1F, false);
            Temperatura212 = new PlcVars.TemperatureShow(Client, "W 14", "", "°C", 0, 0.1F, false);
            Ph12 = new PlcVars.PhShow(Client, "W 16", "Ph = ", "", 0, 0.1F, false);
            Histereza1_12 = new PlcVars.Word(Client, "W 18", "", "°C", true);
            TemperaturaAktivnegaCikla12 = new PlcVars.TemperatureShow(Client, "W 22", "", "°C", 0, 0.1F, true);
            TemperaturaPasivnegaCikla12 = new PlcVars.TemperatureShow(Client, "W 24", "", "°C", 0, 0.1F, true);
            DeltaOn1_12 = new PlcVars.Word(Client, "W 70", "", "°C", true);
            Alarmzarazlikotemperature12 = new PlcVars.Bit(Client, "bit at 72.0", "ALARM", "OK", false);
            Urniki_CikelAktiven12 = new PlcVars.Bit(Client, "bit at 73.0", "Aktivno", "Ni aktivno", false);            
            DelovanjeMesanja12 = new PlcVars.Bit(Client, "bit at 76.0", Misc.Checkmark, Misc.Crossmark, false);
            MUSS_FiltracijskaCrpalka12 = new PlcVars.Bit(Client, "bit at 82.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            MUSS_Grelec12 = new PlcVars.Bit(Client, "bit at 83.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            PrisotnostSarze12 = new PlcVars.Bit(Client, "bit at 90.0", "Prisotna", "Ni Prisotna", false);            
            MocGrelca12 = new PlcVars.PowerShow(Client, "W 140", "", "W", 0, 1, true);
            MocFiltracijskeCrpalke12 = new PlcVars.PowerShow(Client, "W 144", "", "W", 0, 1, true);
            PhOverLimitForAlarm12 = new PlcVars.PhShow(Client, "W 146", "", "", 0, 0.1F, true);
            PhUnderLimitForAlarm12 = new PlcVars.PhShow(Client, "W 148", "", "", 0, 0.1F, true);
            AlarmPh12 = new PlcVars.Bit(Client, "bit at 150.0", "ALARM", "OK", false);
            CanStartGrelec12 = new PlcVars.Bit(Client, "bit at 158.0", "Pripravljen", "Čaka", false);
            CanStartCrpalka12 = new PlcVars.Bit(Client, "bit at 172.0", "Pripravljen", "Čaka", false);  
            SkupnaPorabaKadi12 = new PlcVars.Word(Client, "W 180", "", "W", false);
            DeltaOn2_12 = new PlcVars.Word(Client, "W 184", "", "°C", true);
            Alarmzatemperaturo12 = new PlcVars.Bit(Client, "bit at 186.0", "ALARM", "OK", false);

            Pon_EN_12 = new PlcVars.WordForCheckBox(Client, "W 56", true); timeSetD1_12 = new PlcVars.TimeSet(Client, "W 28", true); timeSetP1_12 = new PlcVars.TimeSet(Client, "W 42", true);
            Tor_EN_12 = new PlcVars.WordForCheckBox(Client, "W 58", true); timeSetD2_12 = new PlcVars.TimeSet(Client, "W 30", true); timeSetP2_12 = new PlcVars.TimeSet(Client, "W 44", true);
            Sre_EN_12 = new PlcVars.WordForCheckBox(Client, "W 60", true); timeSetD3_12 = new PlcVars.TimeSet(Client, "W 32", true); timeSetP3_12 = new PlcVars.TimeSet(Client, "W 46", true);
            Čet_EN_12 = new PlcVars.WordForCheckBox(Client, "W 62", true); timeSetD4_12 = new PlcVars.TimeSet(Client, "W 34", true); timeSetP4_12 = new PlcVars.TimeSet(Client, "W 48", true);
            Pet_EN_12 = new PlcVars.WordForCheckBox(Client, "W 64", true); timeSetD5_12 = new PlcVars.TimeSet(Client, "W 36", true); timeSetP5_12 = new PlcVars.TimeSet(Client, "W 50", true);
            Sob_EN_12 = new PlcVars.WordForCheckBox(Client, "W 66", true); timeSetD6_12 = new PlcVars.TimeSet(Client, "W 38", true); timeSetP6_12 = new PlcVars.TimeSet(Client, "W 52", true);
            Ned_EN_12 = new PlcVars.WordForCheckBox(Client, "W 68", true); timeSetD7_12 = new PlcVars.TimeSet(Client, "W 40", true); timeSetP7_12 = new PlcVars.TimeSet(Client, "W 54", true);


            // KAD 10
            PrisotnostSarze10 = new PlcVars.Bit(Client, "bit at 391.0", "Prisotna", "Ni Prisotna", false);

            // KAD 14
            Nivo14 = new PlcVars.Bit(Client, "bit at 310.0", Misc.Checkmark, Misc.Crossmark, false);
            DelovanjeGrelca14 = new PlcVars.Bit(Client, "bit at 311.0", Misc.Checkmark, Misc.Crossmark, false);
            Temperatura114 = new PlcVars.TemperatureShow(Client, "W 312", "", "°C", 0, 0.1F, false);
            Temperatura214 = new PlcVars.TemperatureShow(Client, "W 314", "", "°C", 0, 0.1F, false);
            Ph14 = new PlcVars.PhShow(Client, "W 316", "Ph = ", "", 0, 0.1F, false);
            Histereza1_14 = new PlcVars.Word(Client, "W 318", "", "°C", true);
            TemperaturaAktivnegaCikla14 = new PlcVars.TemperatureShow(Client, "W 322", "", "°C", 0, 0.1F, true);
            TemperaturaPasivnegaCikla14 = new PlcVars.TemperatureShow(Client, "W 324", "", "°C", 0, 0.1F, true);
            DeltaOn1_14 = new PlcVars.Word(Client, "W 370", "", "°C", true);
            Alarmzarazlikotemperature14 = new PlcVars.Bit(Client, "bit at 372.0", "ALARM", "OK", false);
            Urniki_CikelAktiven14 = new PlcVars.Bit(Client, "bit at 373.0", "Aktivno", "Ni aktivno", false);
            DelovanjeMesanja14 = new PlcVars.Bit(Client, "bit at 376.0", Misc.Crossmark, Misc.Crossmark, false);
            MUSS_FiltracijskaCrpalka14 = new PlcVars.Bit(Client, "bit at 382.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            MUSS_Grelec14 = new PlcVars.Bit(Client, "bit at 383.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            PrisotnostSarze14 = new PlcVars.Bit(Client, "bit at 390.0", "Prisotna", "Ni Prisotna", false);
            MocGrelca14 = new PlcVars.PowerShow(Client, "W 440", "", "W", 0, 1, true);
            MocFiltracijskeCrpalke14 = new PlcVars.PowerShow(Client, "W 444", "", "W", 0, 1, true);
            PhOverLimitForAlarm14 = new PlcVars.PhShow(Client, "W 446", "", "", 0, 0.1F, true);
            PhUnderLimitForAlarm14 = new PlcVars.PhShow(Client, "W 448", "", "", 0, 0.1F, true);
            AlarmPh14 = new PlcVars.Bit(Client, "bit at 450.0", "ALARM", "OK", false);
            CanStartGrelec14 = new PlcVars.Bit(Client, "bit at 458.0", "Pripravljen", "Čaka", false);
            CanStartCrpalka14 = new PlcVars.Bit(Client, "bit at 472.0", "Pripravljen", "Čaka", false);
            SkupnaPorabaKadi14 = new PlcVars.Word(Client, "W 480", "", "W", false);
            DeltaOn2_14 = new PlcVars.Word(Client, "W 484", "", "°C", true);
            Alarmzatemperaturo14 = new PlcVars.Bit(Client, "bit at 486.0", "ALARM", "OK", false);

            Pon_EN_14 = new PlcVars.WordForCheckBox(Client, "W 356", true); timeSetD1_14 = new PlcVars.TimeSet(Client, "W 328", true); timeSetP1_14 = new PlcVars.TimeSet(Client, "W 342", true);
            Tor_EN_14 = new PlcVars.WordForCheckBox(Client, "W 358", true); timeSetD2_14 = new PlcVars.TimeSet(Client, "W 330", true); timeSetP2_14 = new PlcVars.TimeSet(Client, "W 344", true);
            Sre_EN_14 = new PlcVars.WordForCheckBox(Client, "W 360", true); timeSetD3_14 = new PlcVars.TimeSet(Client, "W 332", true); timeSetP3_14 = new PlcVars.TimeSet(Client, "W 346", true);
            Čet_EN_14 = new PlcVars.WordForCheckBox(Client, "W 362", true); timeSetD4_14 = new PlcVars.TimeSet(Client, "W 334", true); timeSetP4_14 = new PlcVars.TimeSet(Client, "W 348", true);
            Pet_EN_14 = new PlcVars.WordForCheckBox(Client, "W 364", true); timeSetD5_14 = new PlcVars.TimeSet(Client, "W 336", true); timeSetP5_14 = new PlcVars.TimeSet(Client, "W 350", true);
            Sob_EN_14 = new PlcVars.WordForCheckBox(Client, "W 366", true); timeSetD6_14 = new PlcVars.TimeSet(Client, "W 338", true); timeSetP6_14 = new PlcVars.TimeSet(Client, "W 352", true);
            Ned_EN_14 = new PlcVars.WordForCheckBox(Client, "W 368", true); timeSetD7_14 = new PlcVars.TimeSet(Client, "W 340", true); timeSetP7_14 = new PlcVars.TimeSet(Client, "W 354", true);


            // KAD 13
            PrisotnostSarze13 = new PlcVars.Bit(Client, "bit at 91.0", "Prisotna", "Ni Prisotna", false);

        }


        // add datagrid elements for submenu
        public void DatagridRowsInSubmenu_12(SmartDatagrid datagrid)
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

                r = datagrid.Rows.Add("Mešanje: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;
                                
                r = datagrid.Rows.Add("Poraba Kadi: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Histereza: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb1_1;
                                
                r = datagrid.Rows.Add("Delta T za Alarm razlike: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb2_1;

                r = datagrid.Rows.Add("Alarm razlike Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Delta T za Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb3_10;

                r = datagrid.Rows.Add("Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Vklop grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1_1;               

                r = datagrid.Rows.Add("Vklop mešanja: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m3_1;

                r = datagrid.Rows.Add("Moč grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1_1;
                                
                r = datagrid.Rows.Add("Moč fil.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p3_1;

                r = datagrid.Rows.Add("Ph: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;
                                
                r = datagrid.Rows.Add("Limit Ph zg.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs1_1;

                r = datagrid.Rows.Add("Limit Ph sp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs2_1;

                r = datagrid.Rows.Add("Alarm Ph.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                //comboboxes


                // CHANGE TO HERE

            }
        }

        public void DatagridRowsInSubmenu_10(SmartDatagrid datagrid)
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

        // add datagrid elements for submenu
        public void DatagridRowsInSubmenu_14(SmartDatagrid datagrid)
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

                r = datagrid.Rows.Add("Mešanje: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Poraba Kadi: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Histereza: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb1_2;

                r = datagrid.Rows.Add("Delta T za Alarm razlike: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb2_2;

                r = datagrid.Rows.Add("Alarm razlike Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Delta T za Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb3_12;

                r = datagrid.Rows.Add("Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Vklop grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1_2;

                r = datagrid.Rows.Add("Vklop mešanja: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m3_2;

                r = datagrid.Rows.Add("Moč grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1_2;

                r = datagrid.Rows.Add("Moč fil.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p3_2;

                r = datagrid.Rows.Add("Ph: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Limit Ph zg.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs1_2;

                r = datagrid.Rows.Add("Limit Ph sp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs2_2;

                r = datagrid.Rows.Add("Alarm Ph.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                //comboboxes


                // CHANGE TO HERE

            }
        }

        public void DatagridRowsInSubmenu_13(SmartDatagrid datagrid)
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

        public void AddRowsToScheduleDatagrid_12(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
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
                datagrid[1, r] = td1_1; datagrid[2, r] = tp1_1;
                datagrid[3, r] = chk1_1;
                r = datagrid.Rows.Add("Tor: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td2_1; datagrid[2, r] = tp2_1;
                datagrid[3, r] = chk2_1;
                r = datagrid.Rows.Add("Sre: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td3_1; datagrid[2, r] = tp3_1;
                datagrid[3, r] = chk3_1;
                r = datagrid.Rows.Add("Čet: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td4_1; datagrid[2, r] = tp4_1;
                datagrid[3, r] = chk4_1;
                r = datagrid.Rows.Add("Pet: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td5_1; datagrid[2, r] = tp5_1;
                datagrid[3, r] = chk5_1;
                r = datagrid.Rows.Add("Sob: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td6_1; datagrid[2, r] = tp6_1;
                datagrid[3, r] = chk6_1;
                r = datagrid.Rows.Add("Ned: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td7_1; datagrid[2, r] = tp7_1;
                datagrid[3, r] = chk7_1;

                r = Statusdatagrid.Rows.Add("Status: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = true;

                r = Statusdatagrid.Rows.Add("Temp.Aktivnega cikla: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = false;
                Statusdatagrid[1, r] = ts1_1;

                r = Statusdatagrid.Rows.Add("Temp.Pasivnega cikla: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = false;
                Statusdatagrid[1, r] = ts2_1;

                // CHANGE TO HERE

            }
        }

        public void AddRowsToScheduleDatagrid_10(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
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


        public void AddRowsToScheduleDatagrid_14(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
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
                datagrid[1, r] = td1_2; datagrid[2, r] = tp1_2;
                datagrid[3, r] = chk1_2;
                r = datagrid.Rows.Add("Tor: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td2_2; datagrid[2, r] = tp2_2;
                datagrid[3, r] = chk2_2;
                r = datagrid.Rows.Add("Sre: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td3_2; datagrid[2, r] = tp3_2;
                datagrid[3, r] = chk3_2;
                r = datagrid.Rows.Add("Čet: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td4_2; datagrid[2, r] = tp4_2;
                datagrid[3, r] = chk4_2;
                r = datagrid.Rows.Add("Pet: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td5_2; datagrid[2, r] = tp5_2;
                datagrid[3, r] = chk5_2;
                r = datagrid.Rows.Add("Sob: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td6_2; datagrid[2, r] = tp6_2;
                datagrid[3, r] = chk6_2;
                r = datagrid.Rows.Add("Ned: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td7_2; datagrid[2, r] = tp7_2;
                datagrid[3, r] = chk7_2;

                r = Statusdatagrid.Rows.Add("Status: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = true;

                r = Statusdatagrid.Rows.Add("Temp.Aktivnega cikla: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = false;
                Statusdatagrid[1, r] = ts1_2;

                r = Statusdatagrid.Rows.Add("Temp.Pasivnega cikla: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = false;
                Statusdatagrid[1, r] = ts2_2;

                // CHANGE TO HERE

            }
        }

        public void AddRowsToScheduleDatagrid_13(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
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

        public void UpdateValues_12(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
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
                        Ph12.SyncWithPC(Main_datagrid[1, 16]);
                        Histereza1_12.SyncWithPC(Main_datagrid[1, 7]);  
                        
                        DeltaOn1_12.SyncWithPC(Main_datagrid[1, 8]);
                        Alarmzarazlikotemperature12.SyncWithPC(Main_datagrid[1, 9]);

                        DeltaOn2_12.SyncWithPC(Main_datagrid[1, 10]);
                        Alarmzatemperaturo12.SyncWithPC(Main_datagrid[1, 11]);

                        DelovanjeMesanja12.SyncWithPC(Main_datagrid[1, 5]);
                        MUSS_Grelec12.SyncWithPC(Main_datagrid[1, 12]);
                        PrisotnostSarze12.SyncWithPC(Main_datagrid[1, 0]);                        
                        MUSS_FiltracijskaCrpalka12.SyncWithPC(Main_datagrid[1, 13]);
                        MocGrelca12.SyncWithPC(Main_datagrid[1, 14]);
                        PhOverLimitForAlarm12.SyncWithPC(Main_datagrid[1, 17]);
                        PhUnderLimitForAlarm12.SyncWithPC(Main_datagrid[1, 18]);
                        AlarmPh12.SyncWithPC(Main_datagrid[1, 19]);
                        //CanStartGrelec10.SyncWithPC(Main_datagrid[1, ]);
                        //CanStartCrpalka10.SyncWithPC(Main_datagrid[1, ];                        
                        MocFiltracijskeCrpalke12.SyncWithPC(Main_datagrid[1, 15]);
                        SkupnaPorabaKadi12.SyncWithPC(Main_datagrid[1, 6]);

                        Urniki_CikelAktiven12.SyncWithPC(Statusdatagrid[1, 0]);
                        TemperaturaAktivnegaCikla12.SyncWithPC(Statusdatagrid[1, 1]);
                        TemperaturaPasivnegaCikla12.SyncWithPC(Statusdatagrid[1, 2]);
                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {
                        Pon_EN_12.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN_12.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN_12.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN_12.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN_12.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN_12.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN_12.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1_12.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2_12.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3_12.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4_12.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5_12.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6_12.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7_12.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1_12.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2_12.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3_12.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4_12.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5_12.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6_12.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7_12.SyncWithPC(Shedule_datagrid[2, 6], 1);

                        // END CHANGE
                    }
                    
                }
                WarningLevelAssesment_Kad12();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        public void UpdateValues_10(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze10.SyncWithPC(Main_datagrid[1, 0]);


                        // END CHANGE

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                    }


                }
                WarningLevelAssesment_Kad10();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }


        public void UpdateValues_14(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
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
                        Ph14.SyncWithPC(Main_datagrid[1, 16]);
                        Histereza1_14.SyncWithPC(Main_datagrid[1, 7]); 
                        
                        DeltaOn1_14.SyncWithPC(Main_datagrid[1, 8]);
                        Alarmzarazlikotemperature14.SyncWithPC(Main_datagrid[1, 9]);

                        DeltaOn2_14.SyncWithPC(Main_datagrid[1, 10]);
                        Alarmzatemperaturo14.SyncWithPC(Main_datagrid[1, 11]);

                        DelovanjeMesanja14.SyncWithPC(Main_datagrid[1, 5]);
                        MUSS_Grelec14.SyncWithPC(Main_datagrid[1, 12]);
                        PrisotnostSarze14.SyncWithPC(Main_datagrid[1, 0]);                        
                        MUSS_FiltracijskaCrpalka14.SyncWithPC(Main_datagrid[1, 13]);
                        MocGrelca14.SyncWithPC(Main_datagrid[1, 14]);
                        PhOverLimitForAlarm14.SyncWithPC(Main_datagrid[1, 17]);
                        PhUnderLimitForAlarm14.SyncWithPC(Main_datagrid[1, 18]);
                        AlarmPh14.SyncWithPC(Main_datagrid[1, 19]);
                        //CanStartGrelec12.SyncWithPC(Main_datagrid[1, ]);
                        //CanStartCrpalka12.SyncWithPC(Main_datagrid[1, ];                        
                        MocFiltracijskeCrpalke14.SyncWithPC(Main_datagrid[1, 15]);
                        SkupnaPorabaKadi14.SyncWithPC(Main_datagrid[1, 6]);

                        Urniki_CikelAktiven14.SyncWithPC(Statusdatagrid[1, 0]);
                        TemperaturaAktivnegaCikla14.SyncWithPC(Statusdatagrid[1, 1]);
                        TemperaturaPasivnegaCikla14.SyncWithPC(Statusdatagrid[1, 2]);
                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {
                        Pon_EN_14.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN_14.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN_14.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN_14.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN_14.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN_14.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN_14.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1_14.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2_14.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3_14.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4_14.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5_14.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6_14.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7_14.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1_14.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2_14.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3_14.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4_14.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5_14.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6_14.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7_14.SyncWithPC(Shedule_datagrid[2, 6], 1);

                        // END CHANGE
                    }


                }
                WarningLevelAssesment_Kad14();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        public void UpdateValues_13(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze13.SyncWithPC(Main_datagrid[1, 0]);


                        // END CHANGE

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                    }


                }
                WarningLevelAssesment_Kad13();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }
        private void WarningLevelAssesment_Kad12()
        {
            if (AlarmPh12.Value || Alarmzarazlikotemperature12.Value || Alarmzatemperaturo12.Value || !Nivo12.Value)
            {
                ALARM_Any_12 = true;                
            }
            else
            {
                ALARM_Any_12 = false;               
            }

            if (MUSS_FiltracijskaCrpalka12.Value || MUSS_Grelec12.Value)
            {
                MUSS_Any_12 = true;
            }
            else
            {
                MUSS_Any_12 = false;
            }
        }

        private void WarningLevelAssesment_Kad10()
        {
            ALARM_Any_10 = false;
            MUSS_Any_10 = false;
        }

        private void WarningLevelAssesment_Kad14()
        {
            if (AlarmPh14.Value || Alarmzarazlikotemperature14.Value || Alarmzatemperaturo14.Value || !Nivo14.Value)
            {
                ALARM_Any_14 = true;               
            }
            else
            {
                ALARM_Any_14 = false;                
            }

            if (MUSS_FiltracijskaCrpalka14.Value || MUSS_Grelec14.Value)
            {
                MUSS_Any_14 = true;
            }
            else
            {
                MUSS_Any_14 = false;
            }
        }
        private void WarningLevelAssesment_Kad13()
        {
            ALARM_Any_13 = false;
            MUSS_Any_13 = false;
        }
    }
}
