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
        public void PROGRAM13(Prop13 prop)
        {
            prop.Nivo12.SyncWithPLC();
            prop.DelovanjeGrelca12.SyncWithPLC();
            prop.Temperatura112.SyncWithPLC();
            prop.Temperatura212.SyncWithPLC();
            prop.Ph12.SyncWithPLC();
            prop.Histereza1_12.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla12.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla12.SyncWithPLC();
            prop.DeltaOn12.SyncWithPLC();
            prop.Alarmzarazlikotemperature12.SyncWithPLC();
            prop.Urniki_CikelAktiven12.SyncWithPLC();
            prop.DelovanjeFilterCrpalke12.SyncWithPLC();
            prop.MUSS_Grelec12.SyncWithPLC();
            prop.PrisotnostSarze12.SyncWithPLC();
            prop.MUSS_FiltracijskaCrpalka12.SyncWithPLC();
            prop.MocGrelca12.SyncWithPLC();
            prop.PhOverLimitForAlarm12.SyncWithPLC();
            prop.PhUnderLimitForAlarm12.SyncWithPLC();
            prop.AlarmPh12.SyncWithPLC();
            prop.CanStartGrelec12.SyncWithPLC();
            prop.CanStartCrpalka12.SyncWithPLC();
            prop.MocFiltracijskeCrpalke12.SyncWithPLC();
            prop.SkupnaPorabaKadi12.SyncWithPLC();

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
