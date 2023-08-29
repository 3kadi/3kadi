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
        public void PROGRAM11(Prop11 prop)
        {
            prop.Nivo10.SyncWithPLC();
            prop.DelovanjeGrelca10.SyncWithPLC();
            prop.Temperatura110.SyncWithPLC();
            prop.Temperatura210.SyncWithPLC();
            prop.Ph10.SyncWithPLC();
            prop.Histereza1_10.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla10.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla10.SyncWithPLC();
            prop.DeltaOn10.SyncWithPLC();
            prop.Alarmzarazlikotemperature10.SyncWithPLC();
            prop.Urniki_CikelAktiven10.SyncWithPLC();
            prop.DelovanjeFilterCrpalke10.SyncWithPLC();
            prop.MUSS_Grelec10.SyncWithPLC();
            prop.PrisotnostSarze10.SyncWithPLC();
            prop.MUSS_FiltracijskaCrpalka10.SyncWithPLC();
            prop.MocGrelca10.SyncWithPLC();
            prop.PhOverLimitForAlarm10.SyncWithPLC();
            prop.PhUnderLimitForAlarm10.SyncWithPLC();
            prop.AlarmPh10.SyncWithPLC();
            prop.CanStartGrelec10.SyncWithPLC();
            prop.CanStartCrpalka10.SyncWithPLC();
            prop.MocFiltracijskeCrpalke10.SyncWithPLC();
            prop.SkupnaPorabaKadi10.SyncWithPLC();

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
