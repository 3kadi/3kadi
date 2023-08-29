using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Sharp7;
using System.Windows.Forms;
using Linq = System.Xml.Linq;

namespace KontrolaKadi
{
    public partial class BackroundTasks
    {
        public void PROGRAM7(Prop7 prop)
        {
            // GET/SET with plc KAD14
            prop.Nivo15.SyncWithPLC();
            prop.DelovanjeGrelca15.SyncWithPLC();
            prop.Temperatura115.SyncWithPLC();
            prop.Temperatura215.SyncWithPLC();
            prop.Ph15.SyncWithPLC();
            prop.Histereza1_15.SyncWithPLC();
            prop.DeltaOn1_15.SyncWithPLC();
            prop.Alarmzarazlikotemperature15.SyncWithPLC();
            prop.DelovanjeMesanja15.SyncWithPLC();
            prop.MUSS_Grelec15.SyncWithPLC();
            prop.PrisotnostSarze15.SyncWithPLC();
            prop.MUSS_FiltracijskaCrpalka15.SyncWithPLC();
            prop.MocGrelca15.SyncWithPLC();
            prop.PhOverLimitForAlarm15.SyncWithPLC();
            prop.PhUnderLimitForAlarm15.SyncWithPLC();
            prop.AlarmPh15.SyncWithPLC();
            prop.MocFiltracijskeCrpalke15.SyncWithPLC();
            prop.SkupnaPorabaKadi15.SyncWithPLC();
            prop.DeltaOn2_15.SyncWithPLC();
            prop.Alarmzatemperaturo15.SyncWithPLC();

            prop.Urniki_CikelAktiven15.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla15.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla15.SyncWithPLC();

            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN_15.SyncWithPLC();  break;
                case 2: prop.Tor_EN_15.SyncWithPLC();  break;
                case 3: prop.Sre_EN_15.SyncWithPLC();  break;
                case 4: prop.Čet_EN_15.SyncWithPLC();  break;
                case 5: prop.Pet_EN_15.SyncWithPLC();  break;
                case 6: prop.Sob_EN_15.SyncWithPLC();  break;
                case 7: prop.Ned_EN_15.SyncWithPLC();  break;

                case 8: prop.timeSetD1_15.SyncWithPLC();  break;
                case 9: prop.timeSetD2_15.SyncWithPLC();  break;
                case 10: prop.timeSetD3_15.SyncWithPLC();  break;
                case 11: prop.timeSetD4_15.SyncWithPLC();  break;
                case 12: prop.timeSetD5_15.SyncWithPLC();  break;
                case 13: prop.timeSetD6_15.SyncWithPLC();  break;
                case 14: prop.timeSetD7_15.SyncWithPLC();  break;

                case 15: prop.timeSetP1_15.SyncWithPLC();  break;
                case 16: prop.timeSetP2_15.SyncWithPLC();  break;
                case 17: prop.timeSetP3_15.SyncWithPLC();  break;
                case 18: prop.timeSetP4_15.SyncWithPLC();  break;
                case 19: prop.timeSetP5_15.SyncWithPLC();  break;
                case 20: prop.timeSetP6_15.SyncWithPLC();  break;
                case 21: prop.timeSetP7_15.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }

            // GET/SET with plc KAD15
            prop.PrisotnostSarze18.SyncWithPLC();

            // GET/SET with plc KAD16
            prop.Nivo17.SyncWithPLC();
            prop.DelovanjeGrelca17.SyncWithPLC();
            prop.Temperatura117.SyncWithPLC();
            prop.Temperatura217.SyncWithPLC();
            prop.Ph17.SyncWithPLC();
            prop.Histereza1_17.SyncWithPLC();
            prop.DeltaOn1_17.SyncWithPLC();
            prop.Alarmzarazlikotemperature17.SyncWithPLC();
            prop.DelovanjeMesanja17.SyncWithPLC();
            prop.MUSS_Grelec17.SyncWithPLC();
            prop.PrisotnostSarze17.SyncWithPLC();
            prop.MUSS_FiltracijskaCrpalka17.SyncWithPLC();
            prop.MocGrelca17.SyncWithPLC();
            prop.PhOverLimitForAlarm17.SyncWithPLC();
            prop.PhUnderLimitForAlarm17.SyncWithPLC();
            prop.AlarmPh17.SyncWithPLC();
            prop.MocFiltracijskeCrpalke17.SyncWithPLC();
            prop.SkupnaPorabaKadi17.SyncWithPLC();
            prop.DeltaOn2_17.SyncWithPLC();
            prop.Alarmzatemperaturo17.SyncWithPLC();

            prop.Urniki_CikelAktiven17.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla17.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla17.SyncWithPLC();

            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN_17.SyncWithPLC();  break;
                case 2: prop.Tor_EN_17.SyncWithPLC();  break;
                case 3: prop.Sre_EN_17.SyncWithPLC();  break;
                case 4: prop.Čet_EN_17.SyncWithPLC();  break;
                case 5: prop.Pet_EN_17.SyncWithPLC();  break;
                case 6: prop.Sob_EN_17.SyncWithPLC();  break;
                case 7: prop.Ned_EN_17.SyncWithPLC();  break;

                case 8: prop.timeSetD1_17.SyncWithPLC();  break;
                case 9: prop.timeSetD2_17.SyncWithPLC();  break;
                case 10: prop.timeSetD3_17.SyncWithPLC();  break;
                case 11: prop.timeSetD4_17.SyncWithPLC();  break;
                case 12: prop.timeSetD5_17.SyncWithPLC();  break;
                case 13: prop.timeSetD6_17.SyncWithPLC();  break;
                case 14: prop.timeSetD7_17.SyncWithPLC();  break;

                case 15: prop.timeSetP1_17.SyncWithPLC();  break;
                case 16: prop.timeSetP2_17.SyncWithPLC();  break;
                case 17: prop.timeSetP3_17.SyncWithPLC();  break;
                case 18: prop.timeSetP4_17.SyncWithPLC();  break;
                case 19: prop.timeSetP5_17.SyncWithPLC();  break;
                case 20: prop.timeSetP6_17.SyncWithPLC();  break;
                case 21: prop.timeSetP7_17.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }

            prop.Cntr++;

            // GET/SET with plc KAD17
            prop.PrisotnostSarze16.SyncWithPLC();
        }
    }
}
