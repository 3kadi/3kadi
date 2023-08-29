using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace KontrolaKadi
{
    public class Prop7
    {

        public Sharp7.S7Client Client { get; set; }
        public bool firsTimeSync = true;

        public bool canWriteToPLC = false;
        public bool canReadFromPLC = true;

        public int Cntr { get; set; }



        //KAD 18
        public bool ALARM_Any_18 { get; private set; } = false;
        public bool MUSS_Any_18{ get; private set; } = false;

        // KAD 15
        public bool ALARM_Any_15 { get; private set; } = false;
        public bool MUSS_Any_15 { get; private set; } = false;

        public DatagridTypes.Histereza cb1_1 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb2_1 = new DatagridTypes.Delta();
        public DatagridTypes.Delta cb3_14 = new DatagridTypes.Delta();
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



        // KAD 16
        public bool ALARM_Any_16 { get; private set; } = false;
        public bool MUSS_Any_16 { get; private set; } = false;

        // KAD 17
        public bool ALARM_Any_17 { get; private set; } = false;
        public bool MUSS_Any_17 { get; private set; } = false;

        public DatagridTypes.Histereza cb1_3 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb2_3 = new DatagridTypes.Delta();
        public DatagridTypes.Delta cb3_17 = new DatagridTypes.Delta();
        public DatagridTypes.TempSet ts1_3 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.TempSet ts2_3 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.MussLauf m1_3 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m2_3 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m3_3 = new DatagridTypes.MussLauf();
        public DatagridTypes.PwrSet p1_3 = new DatagridTypes.PwrSet(500, 3800, 100);
        public DatagridTypes.PwrSet p2_3 = new DatagridTypes.PwrSet(100, 1500, 100);
        public DatagridTypes.PwrSet p3_3 = new DatagridTypes.PwrSet(0, 1500, 100);

        public DatagridTypes.CheckBox chk1_3 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk2_3 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk3_3 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk4_3 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk5_3 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk6_3 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk7_3 = new DatagridTypes.CheckBox();

        public DatagridTypes.CheckBox en1_3 = new DatagridTypes.CheckBox();
        public DatagridTypes.PhSet phs1_3 = new DatagridTypes.PhSet();
        public DatagridTypes.PhSet phs2_3 = new DatagridTypes.PhSet();

        public DatagridTypes.TimeSelector td1_3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp1_3 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td2_3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp2_3 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td3_3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp3_3 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td4_3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp4_3 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td5_3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp5_3 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td6_3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp6_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td7_3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp7_2 = new DatagridTypes.TimeSelector();


        // Public properties - AutoRetrieveable / Writable

        // CHANGE FROM HERE

        // KAD 18
        public PlcVars.Bit PrisotnostSarze18;

        // KAD 15
        public PlcVars.Bit Nivo15;
        public PlcVars.Bit DelovanjeGrelca15;
        public PlcVars.TemperatureShow Temperatura115;
        public PlcVars.TemperatureShow Temperatura215;
        public PlcVars.PhShow Ph15;
        public PlcVars.Word Histereza1_15;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla15;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla15;
        public PlcVars.WordForCheckBox Pon_EN_15; public PlcVars.TimeSet timeSetD1_15; public PlcVars.TimeSet timeSetP1_15;
        public PlcVars.WordForCheckBox Tor_EN_15; public PlcVars.TimeSet timeSetD2_15; public PlcVars.TimeSet timeSetP2_15;
        public PlcVars.WordForCheckBox Sre_EN_15; public PlcVars.TimeSet timeSetD3_15; public PlcVars.TimeSet timeSetP3_15;
        public PlcVars.WordForCheckBox Čet_EN_15; public PlcVars.TimeSet timeSetD4_15; public PlcVars.TimeSet timeSetP4_15;
        public PlcVars.WordForCheckBox Pet_EN_15; public PlcVars.TimeSet timeSetD5_15; public PlcVars.TimeSet timeSetP5_15;
        public PlcVars.WordForCheckBox Sob_EN_15; public PlcVars.TimeSet timeSetD6_15; public PlcVars.TimeSet timeSetP6_15;
        public PlcVars.WordForCheckBox Ned_EN_15; public PlcVars.TimeSet timeSetD7_15; public PlcVars.TimeSet timeSetP7_15;
        public PlcVars.Word DeltaOn1_15;
        public PlcVars.Bit Alarmzarazlikotemperature15;
        public PlcVars.Bit Urniki_CikelAktiven15;
        public PlcVars.Bit DelovanjeMesanja15;
        public PlcVars.Bit MUSS_Grelec15;
        public PlcVars.Bit PrisotnostSarze15;
        public PlcVars.Bit MUSS_FiltracijskaCrpalka15;
        public PlcVars.PowerShow MocGrelca15;
        public PlcVars.PhShow PhOverLimitForAlarm15;
        public PlcVars.PhShow PhUnderLimitForAlarm15;
        public PlcVars.Bit AlarmPh15;
        public PlcVars.Bit CanStartGrelec15;
        public PlcVars.Bit CanStartCrpalka15;
        public PlcVars.PowerShow MocFiltracijskeCrpalke15;
        public PlcVars.Word SkupnaPorabaKadi15;
        public PlcVars.Word DeltaOn2_15;
        public PlcVars.Bit Alarmzatemperaturo15;

       
        // KAD 16
        public PlcVars.Bit PrisotnostSarze16;


        // KAD 17
        public PlcVars.Bit Nivo17;
        public PlcVars.Bit DelovanjeGrelca17;
        public PlcVars.TemperatureShow Temperatura117;
        public PlcVars.TemperatureShow Temperatura217;
        public PlcVars.PhShow Ph17;
        public PlcVars.Word Histereza1_17;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla17;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla17;
        public PlcVars.WordForCheckBox Pon_EN_17; public PlcVars.TimeSet timeSetD1_17; public PlcVars.TimeSet timeSetP1_17;
        public PlcVars.WordForCheckBox Tor_EN_17; public PlcVars.TimeSet timeSetD2_17; public PlcVars.TimeSet timeSetP2_17;
        public PlcVars.WordForCheckBox Sre_EN_17; public PlcVars.TimeSet timeSetD3_17; public PlcVars.TimeSet timeSetP3_17;
        public PlcVars.WordForCheckBox Čet_EN_17; public PlcVars.TimeSet timeSetD4_17; public PlcVars.TimeSet timeSetP4_17;
        public PlcVars.WordForCheckBox Pet_EN_17; public PlcVars.TimeSet timeSetD5_17; public PlcVars.TimeSet timeSetP5_17;
        public PlcVars.WordForCheckBox Sob_EN_17; public PlcVars.TimeSet timeSetD6_17; public PlcVars.TimeSet timeSetP6_17;
        public PlcVars.WordForCheckBox Ned_EN_17; public PlcVars.TimeSet timeSetD7_17; public PlcVars.TimeSet timeSetP7_17;
        public PlcVars.Word DeltaOn1_17;
        public PlcVars.Bit Alarmzarazlikotemperature17;
        public PlcVars.Bit Urniki_CikelAktiven17;
        public PlcVars.Bit DelovanjeMesanja17;
        public PlcVars.Bit MUSS_Grelec17;
        public PlcVars.Bit PrisotnostSarze17;
        public PlcVars.Bit MUSS_FiltracijskaCrpalka17;
        public PlcVars.PowerShow MocGrelca17;
        public PlcVars.PhShow PhOverLimitForAlarm17;
        public PlcVars.PhShow PhUnderLimitForAlarm17;
        public PlcVars.Bit AlarmPh17;
        public PlcVars.Bit CanStartGrelec17;
        public PlcVars.Bit CanStartCrpalka17;
        public PlcVars.PowerShow MocFiltracijskeCrpalke17;
        public PlcVars.Word SkupnaPorabaKadi17;
        public PlcVars.Word DeltaOn2_17;
        public PlcVars.Bit Alarmzatemperaturo17;

        public PlcVars.Word WATCHDOG;


       

        // CHANGE TO HERE

        public Prop7(Sharp7.S7Client client)
        {
            Client = client;
            WATCHDOG = new PlcVars.Word(Client, "DW 262", "", "", false);

            // KAD 18
            PrisotnostSarze18 = new PlcVars.Bit(Client, "bit at 391.0", "Prisotna", "Ni Prisotna", false);

            // KAD 15
            Nivo15 = new PlcVars.Bit(Client, "bit at 10.0", Misc.Checkmark, Misc.Crossmark, false);
            DelovanjeGrelca15 = new PlcVars.Bit(Client, "bit at 11.0", Misc.Checkmark, Misc.Crossmark, false);
            Temperatura115 = new PlcVars.TemperatureShow(Client, "W 12", "", "°C", 0, 0.1F, false);
            Temperatura215 = new PlcVars.TemperatureShow(Client, "W 14", "", "°C", 0, 0.1F, false);
            Ph15 = new PlcVars.PhShow(Client, "W 16", "Ph = ", "", 0, 0.1F, false);
            Histereza1_15 = new PlcVars.Word(Client, "W 18", "", "°C", true);
            TemperaturaAktivnegaCikla15 = new PlcVars.TemperatureShow(Client, "W 22", "", "°C", 0, 0.1F, true);
            TemperaturaPasivnegaCikla15 = new PlcVars.TemperatureShow(Client, "W 24", "", "°C", 0, 0.1F, true);
            DeltaOn1_15 = new PlcVars.Word(Client, "W 70", "", "°C", true);
            Alarmzarazlikotemperature15 = new PlcVars.Bit(Client, "bit at 72.0", "ALARM", "OK", false);
            Urniki_CikelAktiven15 = new PlcVars.Bit(Client, "bit at 73.0", "Aktivno", "Ni aktivno", false);
            DelovanjeMesanja15 = new PlcVars.Bit(Client, "bit at 76.0", Misc.Checkmark, Misc.Crossmark, false);
            MUSS_FiltracijskaCrpalka15 = new PlcVars.Bit(Client, "bit at 82.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            MUSS_Grelec15 = new PlcVars.Bit(Client, "bit at 83.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            PrisotnostSarze15 = new PlcVars.Bit(Client, "bit at 90.0", "Prisotna", "Ni Prisotna", false);
            MocGrelca15 = new PlcVars.PowerShow(Client, "W 140", "", "W", 0, 1, true);
            MocFiltracijskeCrpalke15 = new PlcVars.PowerShow(Client, "W 144", "", "W", 0, 1, true);
            PhOverLimitForAlarm15 = new PlcVars.PhShow(Client, "W 146", "", "", 0, 0.1F, true);
            PhUnderLimitForAlarm15 = new PlcVars.PhShow(Client, "W 148", "", "", 0, 0.1F, true);
            AlarmPh15 = new PlcVars.Bit(Client, "bit at 150.0", "ALARM", "OK", false);
            CanStartGrelec15 = new PlcVars.Bit(Client, "bit at 158.0", "Pripravljen", "Čaka", false);
            CanStartCrpalka15 = new PlcVars.Bit(Client, "bit at 172.0", "Pripravljen", "Čaka", false);
            SkupnaPorabaKadi15 = new PlcVars.Word(Client, "W 180", "", "W", false);
            DeltaOn2_15 = new PlcVars.Word(Client, "W 184", "", "°C", true);
            Alarmzatemperaturo15 = new PlcVars.Bit(Client, "bit at 186.0", "ALARM", "OK", false);

            Pon_EN_15 = new PlcVars.WordForCheckBox(Client, "W 56", true); timeSetD1_15 = new PlcVars.TimeSet(Client, "W 28", true); timeSetP1_15 = new PlcVars.TimeSet(Client, "W 42", true);
            Tor_EN_15 = new PlcVars.WordForCheckBox(Client, "W 58", true); timeSetD2_15 = new PlcVars.TimeSet(Client, "W 30", true); timeSetP2_15 = new PlcVars.TimeSet(Client, "W 44", true);
            Sre_EN_15 = new PlcVars.WordForCheckBox(Client, "W 60", true); timeSetD3_15 = new PlcVars.TimeSet(Client, "W 32", true); timeSetP3_15 = new PlcVars.TimeSet(Client, "W 46", true);
            Čet_EN_15 = new PlcVars.WordForCheckBox(Client, "W 62", true); timeSetD4_15 = new PlcVars.TimeSet(Client, "W 34", true); timeSetP4_15 = new PlcVars.TimeSet(Client, "W 48", true);
            Pet_EN_15 = new PlcVars.WordForCheckBox(Client, "W 64", true); timeSetD5_15 = new PlcVars.TimeSet(Client, "W 36", true); timeSetP5_15 = new PlcVars.TimeSet(Client, "W 50", true);
            Sob_EN_15 = new PlcVars.WordForCheckBox(Client, "W 66", true); timeSetD6_15 = new PlcVars.TimeSet(Client, "W 38", true); timeSetP6_15 = new PlcVars.TimeSet(Client, "W 52", true);
            Ned_EN_15 = new PlcVars.WordForCheckBox(Client, "W 68", true); timeSetD7_15 = new PlcVars.TimeSet(Client, "W 40", true); timeSetP7_15 = new PlcVars.TimeSet(Client, "W 54", true);


            // KAD 16
            PrisotnostSarze16 = new PlcVars.Bit(Client, "bit at 91.0", "Prisotna", "Ni Prisotna", false);

            // KAD 17
            Nivo17 = new PlcVars.Bit(Client, "bit at 310.0", Misc.Checkmark, Misc.Crossmark, false);
            DelovanjeGrelca17 = new PlcVars.Bit(Client, "bit at 311.0", Misc.Checkmark, Misc.Crossmark, false);
            Temperatura117 = new PlcVars.TemperatureShow(Client, "W 312", "", "°C", 0, 0.1F, false);
            Temperatura217 = new PlcVars.TemperatureShow(Client, "W 314", "", "°C", 0, 0.1F, false);
            Ph17 = new PlcVars.PhShow(Client, "W 316", "Ph = ", "", 0, 0.1F, false);
            Histereza1_17 = new PlcVars.Word(Client, "W 318", "", "°C", true);
            TemperaturaAktivnegaCikla17 = new PlcVars.TemperatureShow(Client, "W 322", "", "°C", 0, 0.1F, true);
            TemperaturaPasivnegaCikla17 = new PlcVars.TemperatureShow(Client, "W 324", "", "°C", 0, 0.1F, true);
            DeltaOn1_17 = new PlcVars.Word(Client, "W 370", "", "°C", true);
            Alarmzarazlikotemperature17 = new PlcVars.Bit(Client, "bit at 372.0", "ALARM", "OK", false);
            Urniki_CikelAktiven17 = new PlcVars.Bit(Client, "bit at 373.0", "Aktivno", "Ni aktivno", false);
            DelovanjeMesanja17 = new PlcVars.Bit(Client, "bit at 376.0", Misc.Checkmark, Misc.Crossmark, false);
            MUSS_FiltracijskaCrpalka17 = new PlcVars.Bit(Client, "bit at 382.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            MUSS_Grelec17 = new PlcVars.Bit(Client, "bit at 383.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            PrisotnostSarze17 = new PlcVars.Bit(Client, "bit at 390.0", "Prisotna", "Ni Prisotna", false);
            MocGrelca17 = new PlcVars.PowerShow(Client, "W 440", "", "W", 0, 1, true);
            MocFiltracijskeCrpalke17 = new PlcVars.PowerShow(Client, "W 444", "", "W", 0, 1, true);
            PhOverLimitForAlarm17 = new PlcVars.PhShow(Client, "W 446", "", "", 0, 0.1F, true);
            PhUnderLimitForAlarm17 = new PlcVars.PhShow(Client, "W 448", "", "", 0, 0.1F, true);
            AlarmPh17 = new PlcVars.Bit(Client, "bit at 450.0", "ALARM", "OK", false);
            CanStartGrelec17 = new PlcVars.Bit(Client, "bit at 458.0", "Pripravljen", "Čaka", false);
            CanStartCrpalka17 = new PlcVars.Bit(Client, "bit at 472.0", "Pripravljen", "Čaka", false);
            SkupnaPorabaKadi17 = new PlcVars.Word(Client, "W 480", "", "W", false);
            DeltaOn2_17 = new PlcVars.Word(Client, "W 484", "", "°C", true);
            Alarmzatemperaturo17 = new PlcVars.Bit(Client, "bit at 486.0", "ALARM", "OK", false);

            Pon_EN_17 = new PlcVars.WordForCheckBox(Client, "W 356", true); timeSetD1_17 = new PlcVars.TimeSet(Client, "W 328", true); timeSetP1_17 = new PlcVars.TimeSet(Client, "W 342", true);
            Tor_EN_17 = new PlcVars.WordForCheckBox(Client, "W 358", true); timeSetD2_17 = new PlcVars.TimeSet(Client, "W 330", true); timeSetP2_17 = new PlcVars.TimeSet(Client, "W 344", true);
            Sre_EN_17 = new PlcVars.WordForCheckBox(Client, "W 360", true); timeSetD3_17 = new PlcVars.TimeSet(Client, "W 332", true); timeSetP3_17 = new PlcVars.TimeSet(Client, "W 346", true);
            Čet_EN_17 = new PlcVars.WordForCheckBox(Client, "W 362", true); timeSetD4_17 = new PlcVars.TimeSet(Client, "W 334", true); timeSetP4_17 = new PlcVars.TimeSet(Client, "W 348", true);
            Pet_EN_17 = new PlcVars.WordForCheckBox(Client, "W 364", true); timeSetD5_17 = new PlcVars.TimeSet(Client, "W 336", true); timeSetP5_17 = new PlcVars.TimeSet(Client, "W 350", true);
            Sob_EN_17 = new PlcVars.WordForCheckBox(Client, "W 366", true); timeSetD6_17 = new PlcVars.TimeSet(Client, "W 338", true); timeSetP6_17 = new PlcVars.TimeSet(Client, "W 352", true);
            Ned_EN_17 = new PlcVars.WordForCheckBox(Client, "W 368", true); timeSetD7_17 = new PlcVars.TimeSet(Client, "W 340", true); timeSetP7_17 = new PlcVars.TimeSet(Client, "W 354", true);


            

        }

        public void DatagridRowsInSubmenu_18(SmartDatagrid datagrid)
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
        public void DatagridRowsInSubmenu_15(SmartDatagrid datagrid)
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
                datagrid[1, r] = cb3_14;

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

       

        public void DatagridRowsInSubmenu_16(SmartDatagrid datagrid)
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
        public void DatagridRowsInSubmenu_17(SmartDatagrid datagrid)
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
                datagrid[1, r] = cb1_3;

                r = datagrid.Rows.Add("Delta T za Alarm razlike: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb2_3;

                r = datagrid.Rows.Add("Alarm razlike Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Delta T za Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb3_17;

                r = datagrid.Rows.Add("Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Vklop grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1_3;

                r = datagrid.Rows.Add("Vklop mešanja: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m3_3;

                r = datagrid.Rows.Add("Moč grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1_3;

                r = datagrid.Rows.Add("Moč fil.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p3_3;

                r = datagrid.Rows.Add("Ph: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Limit Ph zg.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs1_3;

                r = datagrid.Rows.Add("Limit Ph sp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = phs2_3;

                r = datagrid.Rows.Add("Alarm Ph.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                //comboboxes


                // CHANGE TO HERE

            }
        }

        

        

        public void AddRowsToScheduleDatagrid_18(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
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

        public void AddRowsToScheduleDatagrid_15(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
        {

            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Dan", "Dan"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 60;
                r = datagrid.Columns.Add("Vklop", "Vklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Izklop", "Izklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("EN", "EN"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 40;

                r = Statusdatagrid.Columns.Add("Status", "Status"); Statusdatagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; Statusdatagrid.Columns[r].Width = 140; Statusdatagrid.ColumnHeadersVisible = false;
                r = Statusdatagrid.Columns.Add("Status_", "Status_"); Statusdatagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; Statusdatagrid.Columns[r].Width = 340 - Statusdatagrid.Columns[r - 1].Width; Statusdatagrid.ColumnHeadersVisible = false;


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

        public void AddRowsToScheduleDatagrid_16(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
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

        public void AddRowsToScheduleDatagrid_17(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
        {

            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Dan", "Dan"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 60;
                r = datagrid.Columns.Add("Vklop", "Vklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Izklop", "Izklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("EN", "EN"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 40;

                r = Statusdatagrid.Columns.Add("Status", "Status"); Statusdatagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; Statusdatagrid.Columns[r].Width = 140; Statusdatagrid.ColumnHeadersVisible = false;
                r = Statusdatagrid.Columns.Add("Status_", "Status_"); Statusdatagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; Statusdatagrid.Columns[r].Width = 340 - Statusdatagrid.Columns[r - 1].Width; Statusdatagrid.ColumnHeadersVisible = false;


                // CHANGE FROM HERE (only show values)
                r = datagrid.Rows.Add("Pon: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td1_3; datagrid[2, r] = tp1_3;
                datagrid[3, r] = chk1_3;
                r = datagrid.Rows.Add("Tor: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td2_3; datagrid[2, r] = tp2_3;
                datagrid[3, r] = chk2_3;
                r = datagrid.Rows.Add("Sre: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td3_3; datagrid[2, r] = tp3_3;
                datagrid[3, r] = chk3_3;
                r = datagrid.Rows.Add("Čet: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td4_3; datagrid[2, r] = tp4_3;
                datagrid[3, r] = chk4_3;
                r = datagrid.Rows.Add("Pet: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td5_3; datagrid[2, r] = tp5_3;
                datagrid[3, r] = chk5_3;
                r = datagrid.Rows.Add("Sob: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td6_3; datagrid[2, r] = tp6_2;
                datagrid[3, r] = chk6_3;
                r = datagrid.Rows.Add("Ned: ", PropComm.NA, PropComm.NA, PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; datagrid[2, r].ReadOnly = false; datagrid[3, r].ReadOnly = false;
                datagrid[1, r] = td7_3; datagrid[2, r] = tp7_2;
                datagrid[3, r] = chk7_3;

                r = Statusdatagrid.Rows.Add("Status: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = true;

                r = Statusdatagrid.Rows.Add("Temp.Aktivnega cikla: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = false;
                Statusdatagrid[1, r] = ts1_3;

                r = Statusdatagrid.Rows.Add("Temp.Pasivnega cikla: ", PropComm.NA); Statusdatagrid[0, r].ReadOnly = true; Statusdatagrid[1, r].ReadOnly = false;
                Statusdatagrid[1, r] = ts2_3;

                // CHANGE TO HERE

            }
        }

        public void UpdateValues_18(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze18.SyncWithPC(Main_datagrid[1, 0]);


                        // END CHANGE

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                    }


                }
                WarningLevelAssesment_Kad18();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        public void UpdateValues_15(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC                     
                        Nivo15.SyncWithPC(Main_datagrid[1, 3]);
                        DelovanjeGrelca15.SyncWithPC(Main_datagrid[1, 4]);
                        Temperatura115.SyncWithPC(Main_datagrid[1, 1]);
                        Temperatura215.SyncWithPC(Main_datagrid[1, 2]);
                        Ph15.SyncWithPC(Main_datagrid[1, 16]);
                        Histereza1_15.SyncWithPC(Main_datagrid[1, 7]);

                        DeltaOn1_15.SyncWithPC(Main_datagrid[1, 8]);
                        Alarmzarazlikotemperature15.SyncWithPC(Main_datagrid[1, 9]);

                        DeltaOn2_15.SyncWithPC(Main_datagrid[1, 10]);
                        Alarmzatemperaturo15.SyncWithPC(Main_datagrid[1, 11]);

                        DelovanjeMesanja15.SyncWithPC(Main_datagrid[1, 5]);
                        MUSS_Grelec15.SyncWithPC(Main_datagrid[1, 12]);
                        PrisotnostSarze15.SyncWithPC(Main_datagrid[1, 0]);
                        MUSS_FiltracijskaCrpalka15.SyncWithPC(Main_datagrid[1, 13]);
                        MocGrelca15.SyncWithPC(Main_datagrid[1, 14]);
                        PhOverLimitForAlarm15.SyncWithPC(Main_datagrid[1, 17]);
                        PhUnderLimitForAlarm15.SyncWithPC(Main_datagrid[1, 18]);
                        AlarmPh15.SyncWithPC(Main_datagrid[1, 19]);
                        //CanStartGrelec14.SyncWithPC(Main_datagrid[1, ]);
                        //CanStartCrpalka14.SyncWithPC(Main_datagrid[1, ];                        
                        MocFiltracijskeCrpalke15.SyncWithPC(Main_datagrid[1, 15]);
                        SkupnaPorabaKadi15.SyncWithPC(Main_datagrid[1, 6]);

                        Urniki_CikelAktiven15.SyncWithPC(Statusdatagrid[1, 0]);
                        TemperaturaAktivnegaCikla15.SyncWithPC(Statusdatagrid[1, 1]);
                        TemperaturaPasivnegaCikla15.SyncWithPC(Statusdatagrid[1, 2]);
                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {
                        Pon_EN_15.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN_15.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN_15.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN_15.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN_15.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN_15.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN_15.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1_15.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2_15.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3_15.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4_15.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5_15.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6_15.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7_15.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1_15.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2_15.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3_15.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4_15.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5_15.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6_15.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7_15.SyncWithPC(Shedule_datagrid[2, 6], 1);

                        // END CHANGE
                    }
                }
                WarningLevelAssesment_Kad15();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        
        public void UpdateValues_16(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze16.SyncWithPC(Main_datagrid[1, 0]);


                        // END CHANGE

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                    }

                }
                WarningLevelAssesment_Kad16();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        public void UpdateValues_17(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC                     
                        Nivo17.SyncWithPC(Main_datagrid[1, 3]);
                        DelovanjeGrelca17.SyncWithPC(Main_datagrid[1, 4]);
                        Temperatura117.SyncWithPC(Main_datagrid[1, 1]);
                        Temperatura217.SyncWithPC(Main_datagrid[1, 2]);
                        Ph17.SyncWithPC(Main_datagrid[1, 16]);
                        Histereza1_17.SyncWithPC(Main_datagrid[1, 7]);

                        DeltaOn1_17.SyncWithPC(Main_datagrid[1, 8]);
                        Alarmzarazlikotemperature17.SyncWithPC(Main_datagrid[1, 9]);

                        DeltaOn2_17.SyncWithPC(Main_datagrid[1, 10]);
                        Alarmzatemperaturo17.SyncWithPC(Main_datagrid[1, 11]);

                        DelovanjeMesanja17.SyncWithPC(Main_datagrid[1, 5]);
                        MUSS_Grelec17.SyncWithPC(Main_datagrid[1, 12]);
                        PrisotnostSarze17.SyncWithPC(Main_datagrid[1, 0]);
                        MUSS_FiltracijskaCrpalka17.SyncWithPC(Main_datagrid[1, 13]);
                        MocGrelca17.SyncWithPC(Main_datagrid[1, 14]);
                        PhOverLimitForAlarm17.SyncWithPC(Main_datagrid[1, 17]);
                        PhUnderLimitForAlarm17.SyncWithPC(Main_datagrid[1, 18]);
                        AlarmPh17.SyncWithPC(Main_datagrid[1, 19]);
                        //CanStartGrelec16.SyncWithPC(Main_datagrid[1, ]);
                        //CanStartCrpalka16.SyncWithPC(Main_datagrid[1, ];                        
                        MocFiltracijskeCrpalke17.SyncWithPC(Main_datagrid[1, 15]);
                        SkupnaPorabaKadi17.SyncWithPC(Main_datagrid[1, 6]);

                        Urniki_CikelAktiven17.SyncWithPC(Statusdatagrid[1, 0]);
                        TemperaturaAktivnegaCikla17.SyncWithPC(Statusdatagrid[1, 1]);
                        TemperaturaPasivnegaCikla17.SyncWithPC(Statusdatagrid[1, 2]);
                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {
                        Pon_EN_17.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN_17.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN_17.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN_17.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN_17.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN_17.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN_17.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1_17.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2_17.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3_17.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4_17.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5_17.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6_17.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7_17.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1_17.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2_17.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3_17.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4_17.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5_17.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6_17.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7_17.SyncWithPC(Shedule_datagrid[2, 6], 1);

                        // END CHANGE
                    }


                }
                WarningLevelAssesment_Kad17();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        private void WarningLevelAssesment_Kad18()
        {
            ALARM_Any_18 = false;
            MUSS_Any_18 = false;
        }

        private void WarningLevelAssesment_Kad15()
        {
            if (AlarmPh15.Value || Alarmzarazlikotemperature15.Value || Alarmzatemperaturo15.Value || !Nivo15.Value)
            {
                ALARM_Any_15 = true;
            }
            else
            {
                ALARM_Any_15 = false;
            }

            if (MUSS_FiltracijskaCrpalka15.Value || MUSS_Grelec15.Value)
            {
                MUSS_Any_15 = true;
            }
            else
            {
                MUSS_Any_15 = false;
            }
        }

        
        private void WarningLevelAssesment_Kad16()
        {
            ALARM_Any_16 = false;
            MUSS_Any_16 = false;
        }

        private void WarningLevelAssesment_Kad17()
        {
            if (AlarmPh17.Value || Alarmzarazlikotemperature17.Value || Alarmzatemperaturo17.Value || !Nivo17.Value)
            {
                ALARM_Any_17 = true;
            }
            else
            {
                ALARM_Any_17 = false;
            }

            if (MUSS_FiltracijskaCrpalka17.Value || MUSS_Grelec17.Value)
            {
                MUSS_Any_17 = true;
            }
            else
            {
                MUSS_Any_17 = false;
            }
        }

       
    }
}
