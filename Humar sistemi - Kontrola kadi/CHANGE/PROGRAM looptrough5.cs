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
        public void PROGRAM5(Prop5 prop)
        {

            // GET/SET with plc KAD6
            prop.Nivo9.SyncWithPLC();
            prop.DelovanjeHladilnegaSistema9.SyncWithPLC();
            prop.Temperatura19.SyncWithPLC();
            prop.Temperatura29.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla9.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla9.SyncWithPLC();
            prop.DeltaOnElektrolit9.SyncWithPLC();
            prop.AlarmzaT_Elektrolit9.SyncWithPLC();
            prop.Urniki_CikelAktiven9.SyncWithPLC();
            prop.DelovanjeCrpalkeZaCasDolivanje9.SyncWithPLC();
            prop.CrpalkaZaCasDolivanjeOnDelay9.SyncWithPLC();
            prop.CrpalkaZaCasDolivanjeOffDelay9.SyncWithPLC();
            prop.MUSS_MesalVentilMinus9.SyncWithPLC();
            prop.MUSS_MesalVentilPlus9.SyncWithPLC();
            prop.PrisotnostSarze9.SyncWithPLC();
            prop.EN_CasDolivanje9.SyncWithPLC();
            prop.MUSS_CrpalkaHladSist9.SyncWithPLC();
            prop.MUSS_CrpalkaZaCasDolivanje9.SyncWithPLC();
            prop.MixValveTimeBase9.SyncWithPLC();
            prop.RefTempHran9.SyncWithPLC();
            prop.DeltaOnHranilnik9.SyncWithPLC();
            prop.MocCrpalkHladSist9.SyncWithPLC();
            prop.MocCrpalkeZaCasDolivanje9.SyncWithPLC();
            prop.AlarmTemperatureHran9.SyncWithPLC();
            prop.CanStartCrpalkeZaCasDolivanje9.SyncWithPLC();
            prop.CanStartHladSist9.SyncWithPLC();
            prop.SkupnaPorabaKadi9.SyncWithPLC();


            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN.SyncWithPLC();  break;
                case 2: prop.Tor_EN.SyncWithPLC();  break;
                case 3: prop.Sre_EN.SyncWithPLC();  break;
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
