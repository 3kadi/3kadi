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
        public void PROGRAM4(Prop4 prop)
        {
            // GET/SET with plc KAD7
            prop.Nivo7.SyncWithPLC();
            prop.DelovanjeGrelca7.SyncWithPLC();
            prop.Temperatura17.SyncWithPLC();
            prop.Temperatura27.SyncWithPLC();
            prop.Ph7.SyncWithPLC();
            prop.Histereza1_7.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla7.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla7.SyncWithPLC();
            prop.DeltaOn1_7.SyncWithPLC();
            prop.Alarmzarazlikotemperature7.SyncWithPLC();
            prop.Urniki_CikelAktiven7.SyncWithPLC();
            prop.DelovanjeCrpalkeZaCasDolivanje7.SyncWithPLC();
            prop.DelovanjeFilterCrpalke7.SyncWithPLC();
            prop.MUSS_Grelec7.SyncWithPLC();
            prop.PrisotnostSarze7.SyncWithPLC();
            prop.EN_CasDolivanje7.SyncWithPLC();
            prop.MUSS_CrpalkaZaCasDolivanje7.SyncWithPLC();
            prop.MUSS_FiltracijskaCrpalka7.SyncWithPLC();
            prop.MocGrelca7.SyncWithPLC();
            prop.PhOverLimitForAlarm7.SyncWithPLC();
            prop.PhUnderLimitForAlarm7.SyncWithPLC();
            prop.AlarmPh7.SyncWithPLC();
            prop.CanStartGrelec7.SyncWithPLC();
            prop.MocCrpalkeZaCasDolivanje7.SyncWithPLC();
            prop.MocFiltracijskeCrpalke7.SyncWithPLC();
            prop.SkupnaPorabaKadi7.SyncWithPLC();
            prop.CrpalkaZaCasDolivanjeOnDelay7.SyncWithPLC();
            prop.CrpalkaZaCasDolivanjeOffDelay7.SyncWithPLC();
            prop.DeltaOn2_7.SyncWithPLC();
            prop.Alarmzatemperaturo7.SyncWithPLC();

            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN_7.SyncWithPLC();  break;
                case 2: prop.Tor_EN_7.SyncWithPLC();  break;
                case 3: prop.Sre_EN_7.SyncWithPLC();  break;
                case 4: prop.Čet_EN_7.SyncWithPLC();  break;
                case 5: prop.Pet_EN_7.SyncWithPLC();  break;
                case 6: prop.Sob_EN_7.SyncWithPLC();  break;
                case 7: prop.Ned_EN_7.SyncWithPLC();  break;

                case 8: prop.timeSetD1_7.SyncWithPLC();  break;
                case 9: prop.timeSetD2_7.SyncWithPLC();  break;
                case 10: prop.timeSetD3_7.SyncWithPLC();  break;
                case 11: prop.timeSetD4_7.SyncWithPLC();  break;
                case 12: prop.timeSetD5_7.SyncWithPLC();  break;
                case 13: prop.timeSetD6_7.SyncWithPLC();  break;
                case 14: prop.timeSetD7_7.SyncWithPLC();  break;

                case 15: prop.timeSetP1_7.SyncWithPLC();  break;
                case 16: prop.timeSetP2_7.SyncWithPLC();  break;
                case 17: prop.timeSetP3_7.SyncWithPLC();  break;
                case 18: prop.timeSetP4_7.SyncWithPLC();  break;
                case 19: prop.timeSetP5_7.SyncWithPLC();  break;
                case 20: prop.timeSetP6_7.SyncWithPLC();  break;
                case 21: prop.timeSetP7_7.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }
            prop.Cntr++;

            // GET/SET with plc KAD8
            prop.PrisotnostSarze8.SyncWithPLC();

        }
    }
}
