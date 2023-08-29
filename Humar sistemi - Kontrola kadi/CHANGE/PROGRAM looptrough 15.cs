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
        public void PROGRAM15(Prop15 prop)
        {
            prop.Nivo14.SyncWithPLC();
            prop.DelovanjeGrelca14.SyncWithPLC();
            prop.Temperatura114.SyncWithPLC();
            prop.Temperatura214.SyncWithPLC();
            prop.Ph14.SyncWithPLC();
            prop.Histereza1_14.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla14.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla14.SyncWithPLC();
            prop.DeltaOn14.SyncWithPLC();
            prop.Alarmzarazlikotemperature14.SyncWithPLC();
            prop.Urniki_CikelAktiven14.SyncWithPLC();
            prop.DelovanjeFilterCrpalke14.SyncWithPLC();
            prop.MUSS_Grelec14.SyncWithPLC();
            prop.PrisotnostSarze14.SyncWithPLC();
            prop.MUSS_FiltracijskaCrpalka14.SyncWithPLC();
            prop.MocGrelca14.SyncWithPLC();
            prop.PhOverLimitForAlarm14.SyncWithPLC();
            prop.PhUnderLimitForAlarm14.SyncWithPLC();
            prop.AlarmPh14.SyncWithPLC();
            prop.CanStartGrelec14.SyncWithPLC();
            prop.CanStartCrpalka14.SyncWithPLC();
            prop.MocFiltracijskeCrpalke14.SyncWithPLC();
            prop.SkupnaPorabaKadi14.SyncWithPLC();


            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN.SyncWithPLC(); prop.Cntr++; break;
                case 2: prop.Tor_EN.SyncWithPLC(); prop.Cntr++; break;
                case 3: prop.Sre_EN.SyncWithPLC(); prop.Cntr++; break;
                case 4: prop.Čet_EN.SyncWithPLC(); prop.Cntr++; break;
                case 5: prop.Pet_EN.SyncWithPLC(); prop.Cntr++; break;
                case 6: prop.Sob_EN.SyncWithPLC(); prop.Cntr++; break;
                case 7: prop.Ned_EN.SyncWithPLC(); prop.Cntr++; break;

                case 8: prop.timeSetD1.SyncWithPLC(); prop.Cntr++; break;
                case 9: prop.timeSetD2.SyncWithPLC(); prop.Cntr++; break;
                case 10: prop.timeSetD3.SyncWithPLC(); prop.Cntr++; break;
                case 11: prop.timeSetD4.SyncWithPLC(); prop.Cntr++; break;
                case 12: prop.timeSetD5.SyncWithPLC(); prop.Cntr++; break;
                case 13: prop.timeSetD6.SyncWithPLC(); prop.Cntr++; break;
                case 14: prop.timeSetD7.SyncWithPLC(); prop.Cntr++; break;

                case 15: prop.timeSetP1.SyncWithPLC(); prop.Cntr++; break;
                case 16: prop.timeSetP2.SyncWithPLC(); prop.Cntr++; break;
                case 17: prop.timeSetP3.SyncWithPLC(); prop.Cntr++; break;
                case 18: prop.timeSetP4.SyncWithPLC(); prop.Cntr++; break;
                case 19: prop.timeSetP5.SyncWithPLC(); prop.Cntr++; break;
                case 20: prop.timeSetP6.SyncWithPLC(); prop.Cntr++; break;
                case 21: prop.timeSetP7.SyncWithPLC(); prop.Cntr++; break;
                default: prop.Cntr = 0; break;
            }
        }
    }
}
