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
        public void PROGRAM8(Prop8 prop)
        {
            // GET/SET with plc KAD18
            prop.PrisotnostSarze11.SyncWithPLC();
            prop.Temperatura111.SyncWithPLC();
            prop.Nivo11.SyncWithPLC();
            prop.DelovanjeGrelca11.SyncWithPLC();
            prop.SkupnaPorabaKadi11.SyncWithPLC();
            prop.Histereza1_11.SyncWithPLC();
            prop.MUSS_Grelec11.SyncWithPLC();
            prop.MocGrelca11.SyncWithPLC();
            prop.DeltaOn2_11.SyncWithPLC();
            prop.Alarmzatemperaturo11.SyncWithPLC();

            prop.Urniki_CikelAktiven11.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla11.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla11.SyncWithPLC();


            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN_11.SyncWithPLC();  break;
                case 2: prop.Tor_EN_11.SyncWithPLC();  break;
                case 3: prop.Sre_EN_11.SyncWithPLC();  break;
                case 4: prop.Čet_EN_11.SyncWithPLC();  break;
                case 5: prop.Pet_EN_11.SyncWithPLC();  break;
                case 6: prop.Sob_EN_11.SyncWithPLC();  break;
                case 7: prop.Ned_EN_11.SyncWithPLC();  break;

                case 8: prop.timeSetD1_11.SyncWithPLC();  break;
                case 9: prop.timeSetD2_11.SyncWithPLC();  break;
                case 10: prop.timeSetD3_11.SyncWithPLC();  break;
                case 11: prop.timeSetD4_11.SyncWithPLC();  break;
                case 12: prop.timeSetD5_11.SyncWithPLC();  break;
                case 13: prop.timeSetD6_11.SyncWithPLC();  break;
                case 14: prop.timeSetD7_11.SyncWithPLC();  break;

                case 15: prop.timeSetP1_11.SyncWithPLC();  break;
                case 16: prop.timeSetP2_11.SyncWithPLC();  break;
                case 17: prop.timeSetP3_11.SyncWithPLC();  break;
                case 18: prop.timeSetP4_11.SyncWithPLC();  break;
                case 19: prop.timeSetP5_11.SyncWithPLC();  break;
                case 20: prop.timeSetP6_11.SyncWithPLC();  break;
                case 21: prop.timeSetP7_11.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }


            // GET/SET with plc KAD19
            prop.PrisotnostSarze19.SyncWithPLC();
            prop.Temperatura119.SyncWithPLC();
            prop.Nivo19.SyncWithPLC();
            prop.DelovanjeGrelca19.SyncWithPLC();
            prop.SkupnaPorabaKadi19.SyncWithPLC();
            prop.Histereza1_19.SyncWithPLC();
            prop.MUSS_Grelec19.SyncWithPLC();
            prop.MocGrelca19.SyncWithPLC();
            prop.DeltaOn2_19.SyncWithPLC();
            prop.Alarmzatemperaturo19.SyncWithPLC();

            prop.Urniki_CikelAktiven19.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla19.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla19.SyncWithPLC();


             switch (prop.Cntr)
            {
                case 1: prop.Pon_EN_19.SyncWithPLC();  break;
                case 2: prop.Tor_EN_19.SyncWithPLC();  break;
                case 3: prop.Sre_EN_19.SyncWithPLC();  break;
                case 4: prop.Čet_EN_19.SyncWithPLC();  break;
                case 5: prop.Pet_EN_19.SyncWithPLC();  break;
                case 6: prop.Sob_EN_19.SyncWithPLC();  break;
                case 7: prop.Ned_EN_19.SyncWithPLC();  break;

                case 8: prop.timeSetD1_19.SyncWithPLC();  break;
                case 9: prop.timeSetD2_19.SyncWithPLC();  break;
                case 10: prop.timeSetD3_19.SyncWithPLC();  break;
                case 11: prop.timeSetD4_19.SyncWithPLC();  break;
                case 12: prop.timeSetD5_19.SyncWithPLC();  break;
                case 13: prop.timeSetD6_19.SyncWithPLC();  break;
                case 14: prop.timeSetD7_19.SyncWithPLC();  break;

                case 15: prop.timeSetP1_19.SyncWithPLC();  break;
                case 16: prop.timeSetP2_19.SyncWithPLC();  break;
                case 17: prop.timeSetP3_19.SyncWithPLC();  break;
                case 18: prop.timeSetP4_19.SyncWithPLC();  break;
                case 19: prop.timeSetP5_19.SyncWithPLC();  break;
                case 20: prop.timeSetP6_19.SyncWithPLC();  break;
                case 21: prop.timeSetP7_19.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }
            prop.Cntr++;

        }
    }
}
