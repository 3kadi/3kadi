using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace KontrolaKadi
{
    public class Prop2
    {

        public Sharp7.S7Client Client { get; set; }
        public bool firsTimeSync = true;

        public bool canWriteToPLC = false;
        public bool canReadFromPLC = true;

        public int Cntr { get; set; }


        // KAD 1
        public bool ALARM_Any_1 { get; private set; } = false;
        public bool MUSS_Any_1 { get; private set; } = false;

        public DatagridTypes.Histereza cb1_1 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb2_1 = new DatagridTypes.Delta();
        public DatagridTypes.Delta cb3_1 = new DatagridTypes.Delta();
        public DatagridTypes.TempSet ts1_1 = new DatagridTypes.TempSet(10, 60, 2); // 10 -60 / 2 TODO
        public DatagridTypes.TempSet ts2_1 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.MussLauf m1_1 = new DatagridTypes.MussLauf();
        public DatagridTypes.PwrSet p1_1 = new DatagridTypes.PwrSet(500, 3800, 100);

        public DatagridTypes.CheckBox chk1_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk2_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk3_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk4_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk5_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk6_1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk7_1 = new DatagridTypes.CheckBox();

        public DatagridTypes.TimeSelector td1_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp1_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td2_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp2_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td3_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp3_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td4_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp4_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td5_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp5_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td6_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp6_1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td7_1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp7_1 = new DatagridTypes.TimeSelector();

        // KAD 2
        public bool ALARM_Any_2 { get; private set; } = false;
        public bool MUSS_Any_2 { get; private set; } = false;
       // public ushort ALARM_Any_2 { get; private set; } = false;

        public DatagridTypes.Histereza cb1_2 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb2_2 = new DatagridTypes.Delta();
        public DatagridTypes.Delta cb3_2 = new DatagridTypes.Delta();
        public DatagridTypes.TempSet ts1_2 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.TempSet ts2_2 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.MussLauf m1_2 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m2_2 = new DatagridTypes.MussLauf();
        public DatagridTypes.PwrSet p1_2 = new DatagridTypes.PwrSet(500, 3800, 100);
        public DatagridTypes.PwrSet p2_2 = new DatagridTypes.PwrSet(100, 1500, 100);
        public DatagridTypes.TimeDurationSec pl1_2 = new DatagridTypes.TimeDurationSec("00:00", "59:59");

        public DatagridTypes.CheckBox chk1_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk2_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk3_2= new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk4_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk5_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk6_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk7_2 = new DatagridTypes.CheckBox();

        public DatagridTypes.TimeSelector td1_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp1_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td2_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp2_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td3_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp3_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td4_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp4_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td5_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp5_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td6_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp6_2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td7_2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp7_2 = new DatagridTypes.TimeSelector();

        // KAD 3
        public bool ALARM_Any_3 { get; private set; } = false;
        public bool MUSS_Any_3 { get; private set; } = false;

        // KAD 4
        public bool ALARM_Any_4 { get; private set; } = false;
        public bool MUSS_Any_4 { get; private set; } = false;

        // KAD 5
        public bool ALARM_Any_5 { get; private set; } = false;
        public bool MUSS_Any_5 { get; private set; } = false;


        // Public properties - AutoRetrieveable / Writable

        // CHANGE FROM HERE

        // KAD 1
        public PlcVars.Word WATCHDOG;
        public PlcVars.Bit Nivo1;
        public PlcVars.Bit DelovanjeGrelca1;
        public PlcVars.TemperatureShow Temperatura11;
        public PlcVars.TemperatureShow Temperatura21;
        public PlcVars.Word Histereza1_1;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla1;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla1;
        public PlcVars.WordForCheckBox Pon_EN_1; public PlcVars.TimeSet timeSetD1_1; public PlcVars.TimeSet timeSetP1_1;
        public PlcVars.WordForCheckBox Tor_EN_1; public PlcVars.TimeSet timeSetD2_1; public PlcVars.TimeSet timeSetP2_1;
        public PlcVars.WordForCheckBox Sre_EN_1; public PlcVars.TimeSet timeSetD3_1; public PlcVars.TimeSet timeSetP3_1;
        public PlcVars.WordForCheckBox Čet_EN_1; public PlcVars.TimeSet timeSetD4_1; public PlcVars.TimeSet timeSetP4_1;
        public PlcVars.WordForCheckBox Pet_EN_1; public PlcVars.TimeSet timeSetD5_1; public PlcVars.TimeSet timeSetP5_1;
        public PlcVars.WordForCheckBox Sob_EN_1; public PlcVars.TimeSet timeSetD6_1; public PlcVars.TimeSet timeSetP6_1;
        public PlcVars.WordForCheckBox Ned_EN_1; public PlcVars.TimeSet timeSetD7_1; public PlcVars.TimeSet timeSetP7_1;
        public PlcVars.Word DeltaOn1_1;
        public PlcVars.Bit Alarmzarazlikotemperature1;
        public PlcVars.Bit Urniki_CikelAktiven1;
        public PlcVars.Bit MUSS_Grelec1;
        public PlcVars.Bit PrisotnostSarze1;
        public PlcVars.PowerShow MocGrelca1;
        public PlcVars.Bit CanStartGrelec1;
        public PlcVars.Word SkupnaPorabaKadi1;
        public PlcVars.Word DeltaOn2_1;
        public PlcVars.Bit Alarmzatemperaturo1;

        // KAD 2
        public PlcVars.Bit CanStartNivojskaCrpalka2;
        public PlcVars.Bit CanStartGrelec2;
        public PlcVars.Bit Nivo2;
        public PlcVars.Bit DelovanjeGrelca2;
        public PlcVars.TemperatureShow Temperatura12;
        public PlcVars.TemperatureShow Temperatura22;
        public PlcVars.Word Histereza1_2;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla2;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla2;
        public PlcVars.WordForCheckBox Pon_EN_2; public PlcVars.TimeSet timeSetD1_2; public PlcVars.TimeSet timeSetP1_2;
        public PlcVars.WordForCheckBox Tor_EN_2; public PlcVars.TimeSet timeSetD2_2; public PlcVars.TimeSet timeSetP2_2;
        public PlcVars.WordForCheckBox Sre_EN_2; public PlcVars.TimeSet timeSetD3_2; public PlcVars.TimeSet timeSetP3_2;
        public PlcVars.WordForCheckBox Čet_EN_2; public PlcVars.TimeSet timeSetD4_2; public PlcVars.TimeSet timeSetP4_2;
        public PlcVars.WordForCheckBox Pet_EN_2; public PlcVars.TimeSet timeSetD5_2; public PlcVars.TimeSet timeSetP5_2;
        public PlcVars.WordForCheckBox Sob_EN_2; public PlcVars.TimeSet timeSetD6_2; public PlcVars.TimeSet timeSetP6_2;
        public PlcVars.WordForCheckBox Ned_EN_2; public PlcVars.TimeSet timeSetD7_2; public PlcVars.TimeSet timeSetP7_2;
        public PlcVars.Word DeltaOn1_2;
        public PlcVars.Bit Alarmzarazlikotemperature2;
        public PlcVars.Bit Urniki_CikelAktiven2;
        public PlcVars.Bit DelovanjeNivojskeCrpalke2;
        public PlcVars.TimeSet NivojskaCrpalkaOffDelay;
        public PlcVars.Bit MUSS_NivojskaCrpalka2;
        public PlcVars.Bit MUSS_Grelec2;
        public PlcVars.Bit PrisotnostSarze2;
        public PlcVars.Word SkupnaPorabaKadi2;
        public PlcVars.PowerShow MocGrelca2;
        public PlcVars.PowerShow MocNivojskeCrpalke2;
        public PlcVars.Bit NivoVisok2;
        public PlcVars.Word DeltaOn2_2;
        public PlcVars.Bit Alarmzatemperaturo2;
        
        // KAD 3
        public PlcVars.Bit PrisotnostSarze3;

        // KAD 4
        public PlcVars.Bit PrisotnostSarze4;

        // KAD 5
        public PlcVars.Bit PrisotnostSarze5;


        // CHANGE TO HERE

        public Prop2(Sharp7.S7Client client)
        {     
            
            Client = client;
            WATCHDOG = new PlcVars.Word(Client, "DW 246", "", "", false);

            // KAD 1
            Nivo1 = new PlcVars.Bit(Client, "bit at 10.0", Misc.Checkmark, Misc.Crossmark, false);
            DelovanjeGrelca1 = new PlcVars.Bit(Client, "bit at 11.0", Misc.Checkmark, Misc.Crossmark, false);
            Temperatura11 = new PlcVars.TemperatureShow(Client, "W 12", "", "°C", 0, 0.1F, false);
            Temperatura21 = new PlcVars.TemperatureShow(Client, "W 14", "", "°C", 0, 0.1F, false);
            Histereza1_1 = new PlcVars.Word(Client, "W 18", "", "°C", true);
            TemperaturaAktivnegaCikla1 = new PlcVars.TemperatureShow(Client, "W 22", "", "°C", 0, 0.1F, true);
            TemperaturaPasivnegaCikla1 = new PlcVars.TemperatureShow(Client, "W 24", "", "°C", 0, 0.1F, true);
            Pon_EN_1 = new PlcVars.WordForCheckBox(Client, "W 56", true); timeSetD1_1 = new PlcVars.TimeSet(Client, "W 28", true); timeSetP1_1 = new PlcVars.TimeSet(Client, "W 42", true);
            Tor_EN_1 = new PlcVars.WordForCheckBox(Client, "W 58", true); timeSetD2_1 = new PlcVars.TimeSet(Client, "W 30", true); timeSetP2_1 = new PlcVars.TimeSet(Client, "W 44", true);
            Sre_EN_1 = new PlcVars.WordForCheckBox(Client, "W 60", true); timeSetD3_1 = new PlcVars.TimeSet(Client, "W 32", true); timeSetP3_1 = new PlcVars.TimeSet(Client, "W 46", true);
            Čet_EN_1 = new PlcVars.WordForCheckBox(Client, "W 62", true); timeSetD4_1 = new PlcVars.TimeSet(Client, "W 34", true); timeSetP4_1 = new PlcVars.TimeSet(Client, "W 48", true);
            Pet_EN_1 = new PlcVars.WordForCheckBox(Client, "W 64", true); timeSetD5_1 = new PlcVars.TimeSet(Client, "W 36", true); timeSetP5_1 = new PlcVars.TimeSet(Client, "W 50", true);
            Sob_EN_1 = new PlcVars.WordForCheckBox(Client, "W 66", true); timeSetD6_1 = new PlcVars.TimeSet(Client, "W 38", true); timeSetP6_1 = new PlcVars.TimeSet(Client, "W 52", true);
            Ned_EN_1 = new PlcVars.WordForCheckBox(Client, "W 68", true); timeSetD7_1 = new PlcVars.TimeSet(Client, "W 40", true); timeSetP7_1 = new PlcVars.TimeSet(Client, "W 54", true);
            DeltaOn1_1 = new PlcVars.Word(Client, "W 70", "", "°C", true);
            Alarmzarazlikotemperature1 = new PlcVars.Bit(Client, "bit at 72.0", "ALARM", "OK", false);
            Urniki_CikelAktiven1 = new PlcVars.Bit(Client, "bit at 73.0", "Aktivno", "Ni aktivno", false);
            MUSS_Grelec1 = new PlcVars.Bit(Client, "bit at 83.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            PrisotnostSarze1 = new PlcVars.Bit(Client, "bit at 90.0", "Prisotna", "Ni Prisotna", false);
            MocGrelca1 = new PlcVars.PowerShow(Client, "W 140", "", "W", 0, 1, true);
            CanStartGrelec1 = new PlcVars.Bit(Client, "bit at 166.0", "Pripravljen", "Čaka", false);
            SkupnaPorabaKadi1 = new PlcVars.Word(Client, "W 170", "", "W", false);
            DeltaOn2_1 = new PlcVars.Word(Client, "W 174", "", "°C", true);
            Alarmzatemperaturo1 = new PlcVars.Bit(Client, "bit at 176.0", "ALARM", "OK", false);

        // KAD 2
        CanStartNivojskaCrpalka2 = new PlcVars.Bit(Client, "bit at 144.0", "Pripravljen", "Čaka", false);
            CanStartGrelec2 = new PlcVars.Bit(Client, "bit at 168.0", "Pripravljen", "Čaka", false);
            Nivo2 = new PlcVars.Bit(Client, "bit at 310.0", "OK", "NAPAKA", false);
            DelovanjeGrelca2 = new PlcVars.Bit(Client, "bit at 311.0", Misc.Checkmark, Misc.Crossmark, false);
            Temperatura12 = new PlcVars.TemperatureShow(Client, "W 312", "", "°C", 0, 0.1F, true);
            Temperatura22 = new PlcVars.TemperatureShow(Client, "W 314", "", "°C", 0, 0.1F, true);
            Histereza1_2 = new PlcVars.Word(Client, "W 318", "", "°C", true);
            TemperaturaAktivnegaCikla2 = new PlcVars.TemperatureShow(Client, "W 322", "", "°C", 0, 0.1F, true);
            TemperaturaPasivnegaCikla2 = new PlcVars.TemperatureShow(Client, "W 324", "", "°C", 0, 0.1F, true);
            Pon_EN_2 = new PlcVars.WordForCheckBox(Client, "W 356", true); timeSetD1_2 = new PlcVars.TimeSet(Client, "W 328", true); timeSetP1_2 = new PlcVars.TimeSet(Client, "W 342", true);
            Tor_EN_2 = new PlcVars.WordForCheckBox(Client, "W 358", true); timeSetD2_2 = new PlcVars.TimeSet(Client, "W 330", true); timeSetP2_2 = new PlcVars.TimeSet(Client, "W 344", true);
            Sre_EN_2 = new PlcVars.WordForCheckBox(Client, "W 360", true); timeSetD3_2 = new PlcVars.TimeSet(Client, "W 332", true); timeSetP3_2 = new PlcVars.TimeSet(Client, "W 346", true);
            Čet_EN_2 = new PlcVars.WordForCheckBox(Client, "W 362", true); timeSetD4_2 = new PlcVars.TimeSet(Client, "W 334", true); timeSetP4_2 = new PlcVars.TimeSet(Client, "W 348", true);
            Pet_EN_2 = new PlcVars.WordForCheckBox(Client, "W 364", true); timeSetD5_2 = new PlcVars.TimeSet(Client, "W 336", true); timeSetP5_2 = new PlcVars.TimeSet(Client, "W 350", true);
            Sob_EN_2 = new PlcVars.WordForCheckBox(Client, "W 366", true); timeSetD6_2 = new PlcVars.TimeSet(Client, "W 338", true); timeSetP6_2 = new PlcVars.TimeSet(Client, "W 352", true);
            Ned_EN_2 = new PlcVars.WordForCheckBox(Client, "W 368", true); timeSetD7_2 = new PlcVars.TimeSet(Client, "W 340", true); timeSetP7_2 = new PlcVars.TimeSet(Client, "W 354", true);
            DeltaOn1_2 = new PlcVars.Word(Client, "W 370", "", "°C", true);
            Alarmzarazlikotemperature2 = new PlcVars.Bit(Client, "bit at 372.0", "ALARM", "OK", false);
            Urniki_CikelAktiven2 = new PlcVars.Bit(Client, "bit at 373.0", "Aktivno", "Ni aktivno", false);
            DelovanjeNivojskeCrpalke2 = new PlcVars.Bit(Client, "bit at 376.0", "Aktivno", "Ni aktivno", false);
            NivojskaCrpalkaOffDelay = new PlcVars.TimeSet(Client, "W 378", false);
            MUSS_NivojskaCrpalka2 = new PlcVars.Bit(Client, "bit at 382.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            MUSS_Grelec2 = new PlcVars.Bit(Client, "bit at 383.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            PrisotnostSarze2 = new PlcVars.Bit(Client, "bit at 390.0", "Prisotna", "Ni Prisotna", false);
            SkupnaPorabaKadi2 = new PlcVars.Word(Client, "W 400", "", "W", false);
            MocGrelca2 = new PlcVars.PowerShow(Client, "W 440", "", "W", 0, 1, true);
            MocNivojskeCrpalke2 = new PlcVars.PowerShow(Client, "W 444", "", "W", 0, 1, true);
            NivoVisok2 = new PlcVars.Bit(Client, "bit at 396.0", "NAPAKA", "OK", false);
            DeltaOn2_2 = new PlcVars.Word(Client, "W 474", "", "°C", true);
            Alarmzatemperaturo2 = new PlcVars.Bit(Client, "bit at 476.0", "ALARM", "OK", false);

            // KAD 3
            PrisotnostSarze3 = new PlcVars.Bit(Client, "bit at 391.0", "Prisotna", "Ni Prisotna", false);

            // KAD 4
            PrisotnostSarze4 = new PlcVars.Bit(Client, "bit at 392.0", "Prisotna", "Ni Prisotna", false);

            // KAD 5
            PrisotnostSarze5 = new PlcVars.Bit(Client, "bit at 393.0", "Prisotna", "Ni Prisotna", false);
        }


        // add datagrid elements for submenu KAD1
        public void DatagridRowsInSubmenu_1(SmartDatagrid datagrid)
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

                r = datagrid.Rows.Add("Poraba Kadi: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Histereza: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb1_1;
                
                r = datagrid.Rows.Add("Delta T za Alarm razlike: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb2_1;

                r = datagrid.Rows.Add("Alarm razlike Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Delta T za Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb3_1;

                r = datagrid.Rows.Add("Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Vklop grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1_1;

                r = datagrid.Rows.Add("Moč grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1_1;

                
                // CHANGE TO HERE

            }
        }

        // add datagrid elements for submenu KAD2
        public void DatagridRowsInSubmenu_2(SmartDatagrid datagrid)
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

                r = datagrid.Rows.Add("Nivo Visok: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Ogrevanje: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Delovanje n.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;
                                
                r = datagrid.Rows.Add("Poraba Kadi: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Histereza: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb1_2;
                
                r = datagrid.Rows.Add("Delta T za Alarm razlike: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb2_2;

                r = datagrid.Rows.Add("Alarm razlike Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;                

                r = datagrid.Rows.Add("Delta T za Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false; //11
                datagrid[1, r] = cb3_2;

                r = datagrid.Rows.Add("Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;//12

                r = datagrid.Rows.Add("Vklop grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1_2;

                r = datagrid.Rows.Add("Vklop n.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m2_2;

                r = datagrid.Rows.Add("Moč grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1_2;

                r = datagrid.Rows.Add("Moč n.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p2_2;

                r = datagrid.Rows.Add("Pulz n.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = pl1_2;


                //comboboxes


                // CHANGE TO HERE

            }
        }

        // add datagrid elements for submenu KAD 3
        public void DatagridRowsInSubmenu_3(SmartDatagrid datagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 200;
                r = datagrid.Columns.Add("Vrednost", "Vrednost"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable;

                // CHANGE FROM HERE (only show values)
                r = datagrid.Rows.Add("Sarža: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;



                //comboboxes



                // CHANGE TO HERE
            }
        }

        // add datagrid elements for submenu KAD4
        public void DatagridRowsInSubmenu_4(SmartDatagrid datagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 200;
                r = datagrid.Columns.Add("Vrednost", "Vrednost"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable;

                // CHANGE FROM HERE (only show values)
                r = datagrid.Rows.Add("Sarža: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;



                //comboboxes



                // CHANGE TO HERE
            }
        }

        // add datagrid elements for submenu
        public void DatagridRowsInSubmenu_5(SmartDatagrid datagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 200;
                r = datagrid.Columns.Add("Vrednost", "Vrednost"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable;

                // CHANGE FROM HERE (only show values)
                r = datagrid.Rows.Add("Sarža: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;



                //Nima urnika



                // CHANGE TO HERE
            }
        }


        // KAD1
        public void AddRowsToScheduleDatagrid_1(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
        {
            if (datagrid != null)
            {

                int r;
                var fb = new System.Drawing.Font(datagrid.DefaultCellStyle.Font, System.Drawing.FontStyle.Bold);

                r = datagrid.Columns.Add("Dan", "Dan"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 60;
                r = datagrid.Columns.Add("Vklop", "Vklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Izklop", "Izklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("EN", "EN"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 40;

                r = Statusdatagrid.Columns.Add("Status", "Status"); Statusdatagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; Statusdatagrid.Columns[r].Width = 140; Statusdatagrid.ColumnHeadersVisible = false;
                r = Statusdatagrid.Columns.Add("Status_", "Status_"); Statusdatagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; Statusdatagrid.Columns[r].Width = 120 + 120 + 40 ; Statusdatagrid.ColumnHeadersVisible = false;


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

        // KAD2
        public void AddRowsToScheduleDatagrid_2(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
        {
            if (datagrid != null)
            {

                int r;
                var fb = new System.Drawing.Font(datagrid.DefaultCellStyle.Font, System.Drawing.FontStyle.Bold);

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

        //KAD3
        public void AddRowsToScheduleDatagrid_3(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Dan", "Dan"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 60;
                r = datagrid.Columns.Add("Vklop", "Vklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Izklop", "Izklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("EN", "EN"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 40;


                // CHANGE FROM HERE (only show values)

                


                // CHANGE TO HERE
            }

        }

        //KAD4
        public void AddRowsToScheduleDatagrid_4(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Dan", "Dan"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 60;
                r = datagrid.Columns.Add("Vklop", "Vklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Izklop", "Izklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("EN", "EN"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 40;


                // CHANGE FROM HERE (only show values)

                //Nima urnika


                // CHANGE TO HERE
            }

        }

        public void AddRowsToScheduleDatagrid_5(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
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


        //KAD1
        public void UpdateValues_1(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze1.SyncWithPC(Main_datagrid[1, 0]);
                        Temperatura11.SyncWithPC(Main_datagrid[1, 1]);
                        Temperatura21.SyncWithPC(Main_datagrid[1, 2]);
                        Nivo1.SyncWithPC(Main_datagrid[1, 3]);
                        DelovanjeGrelca1.SyncWithPC(Main_datagrid[1, 4]);                        
                        SkupnaPorabaKadi1.SyncWithPC(Main_datagrid[1, 5]);
                        Histereza1_1.SyncWithPC(Main_datagrid[1, 6]);
                        
                        DeltaOn1_1.SyncWithPC(Main_datagrid[1, 7]);
                        Alarmzarazlikotemperature1.SyncWithPC(Main_datagrid[1, 8]);

                        DeltaOn2_1.SyncWithPC(Main_datagrid[1, 9]);
                        Alarmzatemperaturo1.SyncWithPC(Main_datagrid[1, 10]);

                        MUSS_Grelec1.SyncWithPC(Main_datagrid[1, 11]);
                        MocGrelca1.SyncWithPC(Main_datagrid[1, 12]);

                        Urniki_CikelAktiven1.SyncWithPC(Statusdatagrid[1, 0]);
                        TemperaturaAktivnegaCikla1.SyncWithPC(Statusdatagrid[1, 1]);
                        TemperaturaPasivnegaCikla1.SyncWithPC(Statusdatagrid[1, 2]);

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {
                        
                        Pon_EN_1.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN_1.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN_1.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN_1.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN_1.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN_1.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN_1.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1_1.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2_1.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3_1.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4_1.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5_1.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6_1.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7_1.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1_1.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2_1.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3_1.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4_1.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5_1.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6_1.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7_1.SyncWithPC(Shedule_datagrid[2, 6], 1);


                        // END CHANGE                       
                    }

                }
                WarningLevelAssesment_Kad1();                
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        //KAD2
        public void UpdateValues_2(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze2.SyncWithPC(Main_datagrid[1, 0]);
                        Temperatura12.SyncWithPC(Main_datagrid[1, 1]);
                        Temperatura22.SyncWithPC(Main_datagrid[1, 2]);
                        Nivo2.SyncWithPC(Main_datagrid[1, 3]);
                        DelovanjeGrelca2.SyncWithPC(Main_datagrid[1, 5]);                        
                        SkupnaPorabaKadi2.SyncWithPC(Main_datagrid[1, 7]);
                        Histereza1_2.SyncWithPC(Main_datagrid[1, 8]); 
                        
                        DeltaOn1_2.SyncWithPC(Main_datagrid[1, 9]);
                        Alarmzarazlikotemperature2.SyncWithPC(Main_datagrid[1, 10]);

                        DeltaOn2_2.SyncWithPC(Main_datagrid[1, 11]);
                        Alarmzatemperaturo2.SyncWithPC(Main_datagrid[1, 12]);

                        MUSS_Grelec2.SyncWithPC(Main_datagrid[1, 13]);
                        MUSS_NivojskaCrpalka2.SyncWithPC(Main_datagrid[1, 14]);
                        MocGrelca2.SyncWithPC(Main_datagrid[1, 15]);
                        MocNivojskeCrpalke2.SyncWithPC(Main_datagrid[1, 16]);
                        NivoVisok2.SyncWithPC(Main_datagrid[1, 4]);
                        NivojskaCrpalkaOffDelay.SyncWithPC(Main_datagrid[1, 17], 1);
                        DelovanjeNivojskeCrpalke2.SyncWithPC(Main_datagrid[1, 6]);

                        Urniki_CikelAktiven2.SyncWithPC(Statusdatagrid[1, 0]);
                        TemperaturaAktivnegaCikla2.SyncWithPC(Statusdatagrid[1, 1]);
                        TemperaturaPasivnegaCikla2.SyncWithPC(Statusdatagrid[1, 2]);

                    }                  
                    
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {
                        Pon_EN_2.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN_2.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN_2.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN_2.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN_2.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN_2.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN_2.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1_2.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2_2.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3_2.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4_2.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5_2.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6_2.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7_2.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1_2.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2_2.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3_2.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4_2.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5_2.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6_2.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7_2.SyncWithPC(Shedule_datagrid[2, 6], 1);

                        // END CHANGE
                    }
                    
                }
                WarningLevelAssesment_Kad2();                
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        //KAD3
        public void UpdateValues_3(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze3.SyncWithPC(Main_datagrid[1, 0]);


                        // END CHANGE

                    }
                }


                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                    }
                }
                WarningLevelAssesment_Kad3();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        //KAD4
        public void UpdateValues_4(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze4.SyncWithPC(Main_datagrid[1, 0]);


                        // END CHANGE

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                    }


                }
                WarningLevelAssesment_Kad4();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }


        public void UpdateValues_5(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze5.SyncWithPC(Main_datagrid[1, 0]);


                        // END CHANGE

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                    }


                }
                WarningLevelAssesment_Kad5();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        private void WarningLevelAssesment_Kad1()
        {            
            if (Alarmzarazlikotemperature1.Value || Alarmzatemperaturo1.Value || !Nivo1.Value)
            {
                ALARM_Any_1 = true;                
            }
            else
            {
                ALARM_Any_1 = false;                
            }

            if (MUSS_Grelec1.Value)
            {
                MUSS_Any_1 = true;
            }
            else
            {
                MUSS_Any_1 = false;
            }

        }

        private void WarningLevelAssesment_Kad2()
        {
            if (Alarmzarazlikotemperature2.Value || Alarmzatemperaturo2.Value || !Nivo2.Value)
            {
                ALARM_Any_2 = true;               
            }
            else
            {
                ALARM_Any_2 = false;                
            }
            if (MUSS_Grelec2.Value || MUSS_NivojskaCrpalka2.Value)
            {
                MUSS_Any_2 = true;
            }
            else
            {
                MUSS_Any_2 = false;
            }
        }

        private void WarningLevelAssesment_Kad3()
        {
            ALARM_Any_3 = false;
            MUSS_Any_3 = false;
        }

        private void WarningLevelAssesment_Kad4()
        {
            ALARM_Any_4 = false;
            MUSS_Any_4 = false;
        }

        private void WarningLevelAssesment_Kad5()
        {
            ALARM_Any_5 = false;
            MUSS_Any_5 = false;
        }
    }
}
