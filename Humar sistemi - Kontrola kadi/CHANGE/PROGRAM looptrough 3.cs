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
        public void PROGRAM3(Prop3 prop)
        {

            // GET/SET with plc KAD6
            prop.Nivo6.SyncWithPLC();
            prop.DelovanjeHladilnegaSistema6.SyncWithPLC();
            prop.Temperatura16.SyncWithPLC();
            prop.Temperatura26.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla6.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla6.SyncWithPLC();
            prop.DeltaOnElektrolit6.SyncWithPLC();
            prop.AlarmzaT_Elektrolit6.SyncWithPLC();
            prop.Urniki_CikelAktiven6.SyncWithPLC();
            prop.DelovanjeCrpalkeZaCasDolivanje6.SyncWithPLC();
            prop.CrpalkaZaCasDolivanjeOnDelay6.SyncWithPLC();
            prop.CrpalkaZaCasDolivanjeOffDelay6.SyncWithPLC();
            prop.MUSS_MesalVentilMinus6.SyncWithPLC();
            prop.MUSS_MesalVentilPlus6.SyncWithPLC();
            prop.PrisotnostSarze6.SyncWithPLC();
            prop.EN_CasDolivanje6.SyncWithPLC();
            prop.MUSS_CrpalkaHladSist6.SyncWithPLC();
            prop.MUSS_CrpalkaZaCasDolivanje6.SyncWithPLC();
            prop.MixValveTimeBase6.SyncWithPLC();
            prop.RefTempHran6.SyncWithPLC();
            prop.DeltaOnHranilnik6.SyncWithPLC();
            prop.MocCrpalkHladSist6.SyncWithPLC();
            prop.MocCrpalkeZaCasDolivanje6.SyncWithPLC();
            prop.AlarmTemperatureHran6.SyncWithPLC();
            prop.CanStartCrpalkeZaCasDolivanje6.SyncWithPLC();
            prop.CanStartHladSist6.SyncWithPLC();
            prop.SkupnaPorabaKadi6.SyncWithPLC();
            
            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN.SyncWithPLC();   break;
                case 2: prop.Tor_EN.SyncWithPLC();  break;
                case 3: prop.Sre_EN.SyncWithPLC();   break;
                case 4: prop.Čet_EN.SyncWithPLC();  break;
                case 5: prop.Pet_EN.SyncWithPLC();  break;
                case 6: prop.Sob_EN.SyncWithPLC();  break;
                case 7: prop.Ned_EN.SyncWithPLC();  break;

                case 8: prop.timeSetD1.SyncWithPLC();  break;
                case 9: prop.timeSetD2.SyncWithPLC();  break;
                case 10: prop.timeSetD3.SyncWithPLC();  break;
                case 11: prop.timeSetD4.SyncWithPLC();  break;
                case 12: prop.timeSetD5.SyncWithPLC();  break;
                case 13: prop.timeSetD6.SyncWithPLC();  break;
                case 14: prop.timeSetD7.SyncWithPLC();  break;

                case 15: prop.timeSetP1.SyncWithPLC();  break;
                case 16: prop.timeSetP2.SyncWithPLC();  break;
                case 17: prop.timeSetP3.SyncWithPLC();  break;
                case 18: prop.timeSetP4.SyncWithPLC();  break;
                case 19: prop.timeSetP5.SyncWithPLC();  break;
                case 20: prop.timeSetP6.SyncWithPLC();  break;
                case 21: prop.timeSetP7.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }
            prop.Cntr++;

        }
    }
}
