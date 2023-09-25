using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace KontrolaKadi
{
    public class Prop8
    {

        public Sharp7.S7Client Client { get; set; }
        public bool firsTimeSync = true;

        public bool canWriteToPLC = false;
        public bool canReadFromPLC = true;

        public int Cntr { get; set; }


        // KAD 11
        public bool ALARM_Any_11 { get; private set; } = false;
        public bool MUSS_Any_11 { get; private set; } = false;

        public DatagridTypes.Histereza cb1_1 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb3_18 = new DatagridTypes.Delta();
        public DatagridTypes.TempSet ts1_1 = new DatagridTypes.TempSet(10, 100, 2);
        public DatagridTypes.TempSet ts2_1 = new DatagridTypes.TempSet(10, 100, 2);
        public DatagridTypes.MussLauf m1_1 = new DatagridTypes.MussLauf();
        public DatagridTypes.PwrSet p1_1 = new DatagridTypes.PwrSet(1000, 10000, 100);

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

        // KAD 19
        public bool ALARM_Any_19 { get; private set; } = false;
        public bool MUSS_Any_19 { get; private set; } = false;

        public DatagridTypes.Histereza cb1_2 = new DatagridTypes.Histereza();
        public DatagridTypes.Delta cb3_19 = new DatagridTypes.Delta();
        public DatagridTypes.TempSet ts1_2 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.TempSet ts2_2 = new DatagridTypes.TempSet(10, 60, 2);
        public DatagridTypes.MussLauf m1_2 = new DatagridTypes.MussLauf();
        public DatagridTypes.PwrSet p1_2 = new DatagridTypes.PwrSet(1000, 10000, 100);

        public DatagridTypes.CheckBox chk1_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk2_2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk3_2 = new DatagridTypes.CheckBox();
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



        // Public properties - AutoRetrieveable / Writable

        // CHANGE FROM HERE

        // KAD 11
        public PlcVars.Word WATCHDOG;
        public PlcVars.Bit Nivo11;
        public PlcVars.Bit DelovanjeGrelca11;
        public PlcVars.TemperatureShow Temperatura111;
        public PlcVars.Word Histereza1_11;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla11;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla11;
        public PlcVars.WordForCheckBox Pon_EN_11; public PlcVars.TimeSet timeSetD1_11; public PlcVars.TimeSet timeSetP1_11;
        public PlcVars.WordForCheckBox Tor_EN_11; public PlcVars.TimeSet timeSetD2_11; public PlcVars.TimeSet timeSetP2_11;
        public PlcVars.WordForCheckBox Sre_EN_11; public PlcVars.TimeSet timeSetD3_11; public PlcVars.TimeSet timeSetP3_11;
        public PlcVars.WordForCheckBox Čet_EN_11; public PlcVars.TimeSet timeSetD4_11; public PlcVars.TimeSet timeSetP4_11;
        public PlcVars.WordForCheckBox Pet_EN_11; public PlcVars.TimeSet timeSetD5_11; public PlcVars.TimeSet timeSetP5_11;
        public PlcVars.WordForCheckBox Sob_EN_11; public PlcVars.TimeSet timeSetD6_11; public PlcVars.TimeSet timeSetP6_11;
        public PlcVars.WordForCheckBox Ned_EN_11; public PlcVars.TimeSet timeSetD7_11; public PlcVars.TimeSet timeSetP7_11;
        public PlcVars.Bit Urniki_CikelAktiven11;
        public PlcVars.Bit MUSS_Grelec11;
        public PlcVars.Bit PrisotnostSarze11;
        public PlcVars.PowerShow MocGrelca11;
        public PlcVars.Bit CanStartGrelec11;
        public PlcVars.Word SkupnaPorabaKadi11;
        public PlcVars.Word DeltaOn2_11;
        public PlcVars.Bit Alarmzatemperaturo11;

        // KAD 19        
        public PlcVars.Bit Nivo19;
        public PlcVars.Bit DelovanjeGrelca19;
        public PlcVars.TemperatureShow Temperatura119;
        public PlcVars.TemperatureShow Temperatura219;
        public PlcVars.Word Histereza1_19;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla19;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla19;
        public PlcVars.WordForCheckBox Pon_EN_19; public PlcVars.TimeSet timeSetD1_19; public PlcVars.TimeSet timeSetP1_19;
        public PlcVars.WordForCheckBox Tor_EN_19; public PlcVars.TimeSet timeSetD2_19; public PlcVars.TimeSet timeSetP2_19;
        public PlcVars.WordForCheckBox Sre_EN_19; public PlcVars.TimeSet timeSetD3_19; public PlcVars.TimeSet timeSetP3_19;
        public PlcVars.WordForCheckBox Čet_EN_19; public PlcVars.TimeSet timeSetD4_19; public PlcVars.TimeSet timeSetP4_19;
        public PlcVars.WordForCheckBox Pet_EN_19; public PlcVars.TimeSet timeSetD5_19; public PlcVars.TimeSet timeSetP5_19;
        public PlcVars.WordForCheckBox Sob_EN_19; public PlcVars.TimeSet timeSetD6_19; public PlcVars.TimeSet timeSetP6_19;
        public PlcVars.WordForCheckBox Ned_EN_19; public PlcVars.TimeSet timeSetD7_19; public PlcVars.TimeSet timeSetP7_19;
        public PlcVars.Bit Urniki_CikelAktiven19;
        public PlcVars.Bit MUSS_Grelec19;
        public PlcVars.Bit PrisotnostSarze19;
        public PlcVars.PowerShow MocGrelca19;
        public PlcVars.Bit CanStartGrelec19;
        public PlcVars.Word SkupnaPorabaKadi19;
        public PlcVars.Word DeltaOn2_19;
        public PlcVars.Bit Alarmzatemperaturo19;



        // CHANGE TO HERE

        public Prop8(Sharp7.S7Client client)
        {     
            
            Client = client;
            WATCHDOG = new PlcVars.Word(Client, "DW 246", "", "", false);

            // KAD 11
            Nivo11 = new PlcVars.Bit(Client, "bit at 10.0", Misc.Checkmark, Misc.Crossmark, false);
            DelovanjeGrelca11 = new PlcVars.Bit(Client, "bit at 11.0", Misc.Checkmark, Misc.Crossmark, false);
            Temperatura111 = new PlcVars.TemperatureShow(Client, "W 12", "", "°C", 0, 0.1F, false);            
            Histereza1_11 = new PlcVars.Word(Client, "W 18", "", "°C", true);
            TemperaturaAktivnegaCikla11 = new PlcVars.TemperatureShow(Client, "W 22", "", "°C", 0, 0.1F, true);
            TemperaturaPasivnegaCikla11 = new PlcVars.TemperatureShow(Client, "W 24", "", "°C", 0, 0.1F, true);
            Pon_EN_11 = new PlcVars.WordForCheckBox(Client, "W 56", true); timeSetD1_11 = new PlcVars.TimeSet(Client, "W 28", true); timeSetP1_11 = new PlcVars.TimeSet(Client, "W 42", true);
            Tor_EN_11 = new PlcVars.WordForCheckBox(Client, "W 58", true); timeSetD2_11 = new PlcVars.TimeSet(Client, "W 30", true); timeSetP2_11 = new PlcVars.TimeSet(Client, "W 44", true);
            Sre_EN_11 = new PlcVars.WordForCheckBox(Client, "W 60", true); timeSetD3_11 = new PlcVars.TimeSet(Client, "W 32", true); timeSetP3_11 = new PlcVars.TimeSet(Client, "W 46", true);
            Čet_EN_11 = new PlcVars.WordForCheckBox(Client, "W 62", true); timeSetD4_11 = new PlcVars.TimeSet(Client, "W 34", true); timeSetP4_11 = new PlcVars.TimeSet(Client, "W 48", true);
            Pet_EN_11 = new PlcVars.WordForCheckBox(Client, "W 64", true); timeSetD5_11 = new PlcVars.TimeSet(Client, "W 36", true); timeSetP5_11 = new PlcVars.TimeSet(Client, "W 50", true);
            Sob_EN_11 = new PlcVars.WordForCheckBox(Client, "W 66", true); timeSetD6_11 = new PlcVars.TimeSet(Client, "W 38", true); timeSetP6_11 = new PlcVars.TimeSet(Client, "W 52", true);
            Ned_EN_11 = new PlcVars.WordForCheckBox(Client, "W 68", true); timeSetD7_11 = new PlcVars.TimeSet(Client, "W 40", true); timeSetP7_11 = new PlcVars.TimeSet(Client, "W 54", true);                       
            Urniki_CikelAktiven11 = new PlcVars.Bit(Client, "bit at 73.0", "Aktivno", "Ni aktivno", false);
            MUSS_Grelec11 = new PlcVars.Bit(Client, "bit at 83.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            PrisotnostSarze11 = new PlcVars.Bit(Client, "bit at 90.0", "Prisotna", "Ni Prisotna", false);
            MocGrelca11 = new PlcVars.PowerShow(Client, "W 140", "", "W", 0, 1, true);
            CanStartGrelec11 = new PlcVars.Bit(Client, "bit at 176.0", "Pripravljen", "Čaka", false);
            SkupnaPorabaKadi11 = new PlcVars.Word(Client, "W 170", "", "W", false);
            DeltaOn2_11 = new PlcVars.Word(Client, "W 184", "", "°C", true);
            Alarmzatemperaturo11 = new PlcVars.Bit(Client, "bit at 186.0", "ALARM", "OK", false);

            // KAD 19
            Nivo19 = new PlcVars.Bit(Client, "bit at 310.0", Misc.Checkmark, Misc.Crossmark, false);
            DelovanjeGrelca19 = new PlcVars.Bit(Client, "bit at 311.0", Misc.Checkmark, Misc.Crossmark, false);
            Temperatura119 = new PlcVars.TemperatureShow(Client, "W 312", "", "°C", 0, 0.1F, false);
            Temperatura219 = new PlcVars.TemperatureShow(Client, "W 314", "", "°C", 0, 0.1F, false);
            Histereza1_19 = new PlcVars.Word(Client, "W 318", "", "°C", true);
            TemperaturaAktivnegaCikla19 = new PlcVars.TemperatureShow(Client, "W 322", "", "°C", 0, 0.1F, true);
            TemperaturaPasivnegaCikla19 = new PlcVars.TemperatureShow(Client, "W 324", "", "°C", 0, 0.1F, true);
            Pon_EN_19 = new PlcVars.WordForCheckBox(Client, "W 356", true); timeSetD1_19 = new PlcVars.TimeSet(Client, "W 328", true); timeSetP1_19 = new PlcVars.TimeSet(Client, "W 342", true);
            Tor_EN_19 = new PlcVars.WordForCheckBox(Client, "W 358", true); timeSetD2_19 = new PlcVars.TimeSet(Client, "W 330", true); timeSetP2_19 = new PlcVars.TimeSet(Client, "W 344", true);
            Sre_EN_19 = new PlcVars.WordForCheckBox(Client, "W 360", true); timeSetD3_19 = new PlcVars.TimeSet(Client, "W 332", true); timeSetP3_19 = new PlcVars.TimeSet(Client, "W 346", true);
            Čet_EN_19 = new PlcVars.WordForCheckBox(Client, "W 362", true); timeSetD4_19 = new PlcVars.TimeSet(Client, "W 334", true); timeSetP4_19 = new PlcVars.TimeSet(Client, "W 348", true);
            Pet_EN_19 = new PlcVars.WordForCheckBox(Client, "W 364", true); timeSetD5_19 = new PlcVars.TimeSet(Client, "W 336", true); timeSetP5_19 = new PlcVars.TimeSet(Client, "W 350", true);
            Sob_EN_19 = new PlcVars.WordForCheckBox(Client, "W 366", true); timeSetD6_19 = new PlcVars.TimeSet(Client, "W 338", true); timeSetP6_19 = new PlcVars.TimeSet(Client, "W 352", true);
            Ned_EN_19 = new PlcVars.WordForCheckBox(Client, "W 368", true); timeSetD7_19 = new PlcVars.TimeSet(Client, "W 340", true); timeSetP7_19 = new PlcVars.TimeSet(Client, "W 354", true);
            Urniki_CikelAktiven19 = new PlcVars.Bit(Client, "bit at 373.0", "Aktivno", "Ni aktivno", false);
            MUSS_Grelec19 = new PlcVars.Bit(Client, "bit at 383.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
            PrisotnostSarze19 = new PlcVars.Bit(Client, "bit at 390.0", "Prisotna", "Ni Prisotna", false);
            MocGrelca19 = new PlcVars.PowerShow(Client, "W 440", "", "W", 0, 1, true);
            CanStartGrelec19 = new PlcVars.Bit(Client, "bit at 478.0", "Pripravljen", "Čaka", false);
            SkupnaPorabaKadi19 = new PlcVars.Word(Client, "W 470", "", "W", false);
            DeltaOn2_19 = new PlcVars.Word(Client, "W 484", "", "°C", true);
            Alarmzatemperaturo19 = new PlcVars.Bit(Client, "bit at 486.0", "ALARM", "OK", false);
        }


        // add datagrid elements for submenu KAD11
        public void DatagridRowsInSubmenu_11(SmartDatagrid datagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 200;
                r = datagrid.Columns.Add("Vrednost", "Vrednost"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable;


                // CHANGE FROM HERE (only show values)

                r = datagrid.Rows.Add("Sarža: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Temp. 1: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;                

                r = datagrid.Rows.Add("Nivo: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Ogrevanje: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;                

                r = datagrid.Rows.Add("Poraba Kadi: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Histereza: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb1_1;

                r = datagrid.Rows.Add("Delta T za Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb3_18;

                r = datagrid.Rows.Add("Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Vklop grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1_1;

                r = datagrid.Rows.Add("Moč grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1_1;

                
                // CHANGE TO HERE

            }
        }

        // add datagrid elements for submenu KAD19
        public void DatagridRowsInSubmenu_19(SmartDatagrid datagrid)
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
                datagrid[1, r] = cb1_2;

                r = datagrid.Rows.Add("Delta T za Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb3_19;

                r = datagrid.Rows.Add("Alarm Temp.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Vklop grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1_2;

                r = datagrid.Rows.Add("Moč grelca: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1_2;


                // CHANGE TO HERE

            }
        }


        // KAD11
        public void AddRowsToScheduleDatagrid_11(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
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

        // KAD19
        public void AddRowsToScheduleDatagrid_19(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid)
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


        //KAD11
        public void UpdateValues_11(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze11.SyncWithPC(Main_datagrid[1, 0]);
                        Temperatura111.SyncWithPC(Main_datagrid[1, 1]);                        
                        Nivo11.SyncWithPC(Main_datagrid[1, 2]);
                        DelovanjeGrelca11.SyncWithPC(Main_datagrid[1, 3]);                        
                        SkupnaPorabaKadi11.SyncWithPC(Main_datagrid[1, 4]);
                        Histereza1_11.SyncWithPC(Main_datagrid[1, 5]);
                        DeltaOn2_11.SyncWithPC(Main_datagrid[1, 6]);
                        Alarmzatemperaturo11.SyncWithPC(Main_datagrid[1, 7]);
                        MUSS_Grelec11.SyncWithPC(Main_datagrid[1, 8]);
                        MocGrelca11.SyncWithPC(Main_datagrid[1, 9]);

                        Urniki_CikelAktiven11.SyncWithPC(Statusdatagrid[1, 0]);
                        TemperaturaAktivnegaCikla11.SyncWithPC(Statusdatagrid[1, 1]);
                        TemperaturaPasivnegaCikla11.SyncWithPC(Statusdatagrid[1, 2]);

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {
                        
                        Pon_EN_11.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN_11.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN_11.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN_11.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN_11.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN_11.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN_11.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1_11.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2_11.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3_11.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4_11.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5_11.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6_11.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7_11.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1_11.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2_11.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3_11.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4_11.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5_11.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6_11.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7_11.SyncWithPC(Shedule_datagrid[2, 6], 1);


                        // END CHANGE

                    }                    
                }
                WarningLevelAssesment_Kad11();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        //KAD19
        public void UpdateValues_19(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid, SmartDatagrid Statusdatagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 
                        PrisotnostSarze19.SyncWithPC(Main_datagrid[1, 0]);
                        Temperatura119.SyncWithPC(Main_datagrid[1, 1]);
                        Temperatura219.SyncWithPC(Main_datagrid[1, 2]);
                        Nivo19.SyncWithPC(Main_datagrid[1, 3]);
                        DelovanjeGrelca19.SyncWithPC(Main_datagrid[1, 4]);
                        SkupnaPorabaKadi19.SyncWithPC(Main_datagrid[1, 5]);
                        Histereza1_19.SyncWithPC(Main_datagrid[1, 6]);
                        DeltaOn2_19.SyncWithPC(Main_datagrid[1, 7]);
                        Alarmzatemperaturo19.SyncWithPC(Main_datagrid[1, 8]);
                        MUSS_Grelec19.SyncWithPC(Main_datagrid[1, 9]);
                        MocGrelca19.SyncWithPC(Main_datagrid[1, 10]);

                        Urniki_CikelAktiven19.SyncWithPC(Statusdatagrid[1, 0]);
                        TemperaturaAktivnegaCikla19.SyncWithPC(Statusdatagrid[1, 1]);
                        TemperaturaPasivnegaCikla19.SyncWithPC(Statusdatagrid[1, 2]);

                    }
                }
                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                        Pon_EN_19.SyncWithPC(Shedule_datagrid[3, 0]);
                        Tor_EN_19.SyncWithPC(Shedule_datagrid[3, 1]);
                        Sre_EN_19.SyncWithPC(Shedule_datagrid[3, 2]);
                        Čet_EN_19.SyncWithPC(Shedule_datagrid[3, 3]);
                        Pet_EN_19.SyncWithPC(Shedule_datagrid[3, 4]);
                        Sob_EN_19.SyncWithPC(Shedule_datagrid[3, 5]);
                        Ned_EN_19.SyncWithPC(Shedule_datagrid[3, 6]);

                        timeSetD1_19.SyncWithPC(Shedule_datagrid[1, 0], 1);
                        timeSetD2_19.SyncWithPC(Shedule_datagrid[1, 1], 1);
                        timeSetD3_19.SyncWithPC(Shedule_datagrid[1, 2], 1);
                        timeSetD4_19.SyncWithPC(Shedule_datagrid[1, 3], 1);
                        timeSetD5_19.SyncWithPC(Shedule_datagrid[1, 4], 1);
                        timeSetD6_19.SyncWithPC(Shedule_datagrid[1, 5], 1);
                        timeSetD7_19.SyncWithPC(Shedule_datagrid[1, 6], 1);

                        timeSetP1_19.SyncWithPC(Shedule_datagrid[2, 0], 1);
                        timeSetP2_19.SyncWithPC(Shedule_datagrid[2, 1], 1);
                        timeSetP3_19.SyncWithPC(Shedule_datagrid[2, 2], 1);
                        timeSetP4_19.SyncWithPC(Shedule_datagrid[2, 3], 1);
                        timeSetP5_19.SyncWithPC(Shedule_datagrid[2, 4], 1);
                        timeSetP6_19.SyncWithPC(Shedule_datagrid[2, 5], 1);
                        timeSetP7_19.SyncWithPC(Shedule_datagrid[2, 6], 1);

                        // END CHANGE

                    }

                }
                WarningLevelAssesment_Kad19();
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

        private void WarningLevelAssesment_Kad11()
        {
            if (Alarmzatemperaturo11.Value || !Nivo11.Value)
            {
                ALARM_Any_11 = true;
            }
            else
            {
                ALARM_Any_11 = false;
            }
            if (MUSS_Grelec11.Value)
            {
                MUSS_Any_11 = true;
            }
            else
            {
                MUSS_Any_11 = false;
            }
        }

        private void WarningLevelAssesment_Kad19()
        {
            if (Alarmzatemperaturo19.Value || !Nivo19.Value)
            {
                ALARM_Any_19 = true;
            }
            else
            {
                ALARM_Any_19 = false;
            }
            if (MUSS_Grelec19.Value)
            {
                MUSS_Any_19 = true;
            }
            else
            {
                MUSS_Any_19 = false;
            }
        }
    }
}
