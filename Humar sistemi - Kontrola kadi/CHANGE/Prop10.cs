﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace KontrolaKadi
{
    public class Prop10
    {

        public Sharp7.S7Client Client { get; set; }
        public bool firsTimeSync = true;

        public bool canWriteToPLC = false;
        public bool canReadFromPLC = true;

        public int Cntr { get; set; }

        public DatagridTypes.CheckBox chk1 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk2 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk3 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk4 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk5 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk6 = new DatagridTypes.CheckBox();
        public DatagridTypes.CheckBox chk7 = new DatagridTypes.CheckBox();

        public DatagridTypes.TempSet ts1 = new DatagridTypes.TempSet(-5, 30, 2);
        public DatagridTypes.TempSet ts2 = new DatagridTypes.TempSet(-5, 30, 2);

        public DatagridTypes.Delta cb1 = new DatagridTypes.Delta();
        public DatagridTypes.Delta cb2 = new DatagridTypes.Delta();

        public DatagridTypes.TempSet cb3 = new DatagridTypes.TempSet(-5,30,1);

        public DatagridTypes.PwrSet p1 = new DatagridTypes.PwrSet(100, 1500, 100);
        public DatagridTypes.PwrSet p2 = new DatagridTypes.PwrSet(100, 1500, 100);

        public DatagridTypes.CheckBox en1 = new DatagridTypes.CheckBox();

        public DatagridTypes.MussLauf m1 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m2 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m3 = new DatagridTypes.MussLauf();
        public DatagridTypes.MussLauf m4 = new DatagridTypes.MussLauf();

        public DatagridTypes.TimeDurationSec pl1 = new DatagridTypes.TimeDurationSec("00:01","59:59");
        public DatagridTypes.TimeDurationSec pl2 = new DatagridTypes.TimeDurationSec("00:01", "59:59");

        public DatagridTypes.Timeset tms1 = new DatagridTypes.Timeset();

        public DatagridTypes.TimeSelector td1 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp1 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td2 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp2 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td3 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp3 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td4 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp4 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td5 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp5 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td6 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp6 = new DatagridTypes.TimeSelector();
        public DatagridTypes.TimeSelector td7 = new DatagridTypes.TimeSelector(); public DatagridTypes.TimeSelector tp7 = new DatagridTypes.TimeSelector();


        // Public properties - AutoRetrieveable / Writable

        // CHANGE FROM HERE

        public PlcVars.Bit Nivo9;
        public PlcVars.Bit DelovanjeHladilnegaSistema9;
        public PlcVars.TemperatureShow Temperatura19;
        public PlcVars.TemperatureShow Temperatura29;
        public PlcVars.TemperatureShow TemperaturaAktivnegaCikla9;
        public PlcVars.TemperatureShow TemperaturaPasivnegaCikla9;
        public PlcVars.Word DeltaOnElektrolit9;
        public PlcVars.Bit AlarmzaT_Elektrolit9;
        public PlcVars.Bit Urniki_CikelAktiven9;
        public PlcVars.Bit DelovanjeCrpalkeZaCasDolivanje9;
        public PlcVars.TimeSet CrpalkaZaCasDolivanjeOnDelay9;
        public PlcVars.TimeSet CrpalkaZaCasDolivanjeOffDelay9;
        public PlcVars.Bit MUSS_MesalVentilMinus9;
        public PlcVars.Bit MUSS_MesalVentilPlus9;
        public PlcVars.Bit PrisotnostSarze9;
        public PlcVars.Bit EN_CasDolivanje9;
        public PlcVars.Bit MUSS_CrpalkaHladSist9;
        public PlcVars.Bit MUSS_CrpalkaZaCasDolivanje9;
        public PlcVars.Word MixValveTimeBase9;
        public PlcVars.TemperatureShow RefTempHran9;
        public PlcVars.TemperatureShow DeltaOnHranilnik9;
        public PlcVars.PowerShow MocCrpalkHladSist9;
        public PlcVars.PowerShow MocCrpalkeZaCasDolivanje9;
        public PlcVars.Bit AlarmTemperatureHran9;
        public PlcVars.Bit CanStartCrpalkeZaCasDolivanje9;
        public PlcVars.Bit CanStartHladSist9;
        public PlcVars.Word SkupnaPorabaKadi9;
        public PlcVars.Word WATCHDOG;        

        public PlcVars.WordForCheckBox Pon_EN; public PlcVars.TimeSet timeSetD1; public PlcVars.TimeSet timeSetP1;
        public PlcVars.WordForCheckBox Tor_EN; public PlcVars.TimeSet timeSetD2; public PlcVars.TimeSet timeSetP2;
        public PlcVars.WordForCheckBox Sre_EN; public PlcVars.TimeSet timeSetD3; public PlcVars.TimeSet timeSetP3;
        public PlcVars.WordForCheckBox Čet_EN; public PlcVars.TimeSet timeSetD4; public PlcVars.TimeSet timeSetP4;
        public PlcVars.WordForCheckBox Pet_EN; public PlcVars.TimeSet timeSetD5; public PlcVars.TimeSet timeSetP5;
        public PlcVars.WordForCheckBox Sob_EN; public PlcVars.TimeSet timeSetD6; public PlcVars.TimeSet timeSetP6;
        public PlcVars.WordForCheckBox Ned_EN; public PlcVars.TimeSet timeSetD7; public PlcVars.TimeSet timeSetP7;
       


        // CHANGE TO HERE

        public Prop10(Sharp7.S7Client client)
        {
            Client = client;
             Nivo9 = new PlcVars.Bit(Client, "bit at 10.0", "OK", "NAPAKA", false);
             DelovanjeHladilnegaSistema9 = new PlcVars.Bit(Client, "bit at 11.0", "Aktivno", "Ni aktivno", false);
             Temperatura19 = new PlcVars.TemperatureShow(Client, "W 12", "", "°C", 0, 0.1F, false);
             Temperatura29 = new PlcVars.TemperatureShow(Client, "W 14", "", "°C", 0, 0.1F, false); 
             TemperaturaAktivnegaCikla9 = new PlcVars.TemperatureShow(Client, "W 22", "", "°C", 0, 0.1F, true); 
             TemperaturaPasivnegaCikla9 = new PlcVars.TemperatureShow(Client, "W 24", "", "°C", 0, 0.1F, true); 
             DeltaOnElektrolit9 = new PlcVars.Word(Client, "W 70", "", "°C", true);
             AlarmzaT_Elektrolit9 = new PlcVars.Bit(Client, "bit at 72.0", "ALARM", "OK", false);
             Urniki_CikelAktiven9 = new PlcVars.Bit(Client, "bit at 73.0", "Aktivno", "Ni aktivno", false);
             DelovanjeCrpalkeZaCasDolivanje9 = new PlcVars.Bit(Client, "bit at 74.0", "Aktivno", "Ni aktivno", false);
             CrpalkaZaCasDolivanjeOnDelay9 = new PlcVars.TimeSet(Client, "W 76", true);
             CrpalkaZaCasDolivanjeOffDelay9 = new PlcVars.TimeSet(Client, "W 78", true);
             MUSS_MesalVentilMinus9 = new PlcVars.Bit(Client, "bit at 80.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
             MUSS_MesalVentilPlus9 = new PlcVars.Bit(Client, "bit at 82.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
             PrisotnostSarze9 = new PlcVars.Bit(Client, "bit at 90.0", "Prisotna", "Ni Prisotna", false);
             EN_CasDolivanje9 = new PlcVars.Bit(Client, "bit at 92.0", "Omogočeno", "Onemogočeno", false);
             MUSS_CrpalkaHladSist9 = new PlcVars.Bit(Client, "bit at 93.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
             MUSS_CrpalkaZaCasDolivanje9 = new PlcVars.Bit(Client, "bit at 94.0", DatagridTypes.MussLauf.ValueIfTrue, DatagridTypes.MussLauf.ValueIfFalse, true);
             MixValveTimeBase9 = new PlcVars.Word(Client, "W 96", "", "s", false); 
             RefTempHran9 = new PlcVars.TemperatureShow(Client, "W 98", "", "°C", 0, 0.1F, true);
             DeltaOnHranilnik9 = new PlcVars.TemperatureShow(Client, "W 100", "", "°C", 0, 0.1F, true);
             MocCrpalkHladSist9 = new PlcVars.PowerShow(Client, "W 140", "", "W", 0, 1, true); 
             MocCrpalkeZaCasDolivanje9 = new PlcVars.PowerShow(Client, "W 142", "", "W", 0, 1, true); 
             AlarmTemperatureHran9 = new PlcVars.Bit(Client, "bit at 144.0", "ALARM", "OK", false);
            CanStartCrpalkeZaCasDolivanje9 = new PlcVars.Bit(Client, "bit at 146.0", "Pripravljen", "Čaka", false);
            CanStartHladSist9 = new PlcVars.Bit(Client, "bit at 148.0", "Pripravljen", "Čaka", false);
             SkupnaPorabaKadi9 = new PlcVars.Word(Client, "W 170", "", "", false); 
            WATCHDOG = new PlcVars.Word(Client, "DW 250", "", "", false);             

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

                r = datagrid.Rows.Add("Delovanje Hl.sistema: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Delovanje čas. črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Omogoči čas. črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = en1;

                r = datagrid.Rows.Add("Pulz čas. črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = pl1;

                r = datagrid.Rows.Add("Pavza čas. črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = pl2;

                r = datagrid.Rows.Add("Status: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Poraba Kadi: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Temp.Aktivnega cikla: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = ts1;

                r = datagrid.Rows.Add("Temp.Pasivnega cikla: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = ts2;

                r = datagrid.Rows.Add("Delta T Alarm Elektrolita: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb1;

                r = datagrid.Rows.Add("Delta T Alarm Hran.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb2;

                r = datagrid.Rows.Add("Ref.temp.hran.hl.vode: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = cb3;

                r = datagrid.Rows.Add("Alarm Temp. Elektrolit: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Alarm Temp. Hran.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;

                r = datagrid.Rows.Add("Vklop čas.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m1;

                r = datagrid.Rows.Add("Vklop črpalk hl. sist.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m2;

                r = datagrid.Rows.Add("Čas.baza mešal. vent.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = tms1;

                r = datagrid.Rows.Add("Mesalni ventil (+): ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m3;

                r = datagrid.Rows.Add("Mesalni ventil (-): ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = m4;

                r = datagrid.Rows.Add("Moč čas.črpalke: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p1;

                r = datagrid.Rows.Add("Moč črpalk hl. sist.: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = false;
                datagrid[1, r] = p2;




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

                        Nivo9.SyncWithPC(Main_datagrid[1, 0]);
                        DelovanjeHladilnegaSistema9.SyncWithPC(Main_datagrid[1, 1]);
                        Temperatura19.SyncWithPC(Main_datagrid[1, 2]);
                        Temperatura29.SyncWithPC(Main_datagrid[1, 3]);
                        TemperaturaAktivnegaCikla9.SyncWithPC(Main_datagrid[1, 4]);
                        TemperaturaPasivnegaCikla9.SyncWithPC(Main_datagrid[1, 5]);
                        DeltaOnElektrolit9.SyncWithPC(Main_datagrid[1, 6]);
                        AlarmzaT_Elektrolit9.SyncWithPC(Main_datagrid[1, 7]);
                        Urniki_CikelAktiven9.SyncWithPC(Main_datagrid[1, 8]);
                        DelovanjeCrpalkeZaCasDolivanje9.SyncWithPC(Main_datagrid[1, 9]);
                        CrpalkaZaCasDolivanjeOnDelay9.SyncWithPC(Main_datagrid[1, 10], 1);
                        CrpalkaZaCasDolivanjeOffDelay9.SyncWithPC(Main_datagrid[1, 11], 1);
                        MUSS_MesalVentilMinus9.SyncWithPC(Main_datagrid[1, 12]);
                        MUSS_MesalVentilPlus9.SyncWithPC(Main_datagrid[1, 13]);
                        PrisotnostSarze9.SyncWithPC(Main_datagrid[1, 14]);
                        EN_CasDolivanje9.SyncWithPC(Main_datagrid[1, 15]);
                        MUSS_CrpalkaHladSist9.SyncWithPC(Main_datagrid[1, 16]);
                        MUSS_CrpalkaZaCasDolivanje9.SyncWithPC(Main_datagrid[1, 17]);
                        MixValveTimeBase9.SyncWithPC(Main_datagrid[1, 18]);
                        RefTempHran9.SyncWithPC(Main_datagrid[1, 19]);
                        DeltaOnHranilnik9.SyncWithPC(Main_datagrid[1, 20]);
                        MocCrpalkHladSist9.SyncWithPC(Main_datagrid[1, 21]);
                        MocCrpalkeZaCasDolivanje9.SyncWithPC(Main_datagrid[1, 22]);
                        AlarmTemperatureHran9.SyncWithPC(Main_datagrid[1, 23]);
                        CanStartCrpalkeZaCasDolivanje9.SyncWithPC(Main_datagrid[1, 24]);
                        CanStartHladSist9.SyncWithPC(Main_datagrid[1, 25]);
                        SkupnaPorabaKadi9.SyncWithPC(Main_datagrid[1, 26]);

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
