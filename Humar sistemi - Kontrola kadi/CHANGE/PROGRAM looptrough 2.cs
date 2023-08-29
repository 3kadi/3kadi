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
        

        public void PROGRAM2(Prop2 prop)
        {
           
            // GET/SET with plc KAD1
            prop.PrisotnostSarze1.SyncWithPLC();
            prop.Temperatura11.SyncWithPLC();
            prop.Temperatura21.SyncWithPLC();
            prop.Nivo1.SyncWithPLC();
            prop.DelovanjeGrelca1.SyncWithPLC();            
            prop.Urniki_CikelAktiven1.SyncWithPLC();
            prop.SkupnaPorabaKadi1.SyncWithPLC();
            prop.Histereza1_1.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla1.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla1.SyncWithPLC();
            prop.DeltaOn1_1.SyncWithPLC();
            prop.Alarmzarazlikotemperature1.SyncWithPLC();
            prop.MUSS_Grelec1.SyncWithPLC();
            prop.MocGrelca1.SyncWithPLC();
            prop.DeltaOn2_1.SyncWithPLC();
            prop.Alarmzatemperaturo1.SyncWithPLC();

            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN_1.SyncWithPLC();  break;
                case 2: prop.Tor_EN_1.SyncWithPLC();  break;
                case 3: prop.Sre_EN_1.SyncWithPLC();  break;
                case 4: prop.Čet_EN_1.SyncWithPLC();  break;
                case 5: prop.Pet_EN_1.SyncWithPLC();  break;
                case 6: prop.Sob_EN_1.SyncWithPLC();  break;
                case 7: prop.Ned_EN_1.SyncWithPLC();  break;

                case 8: prop.timeSetD1_1.SyncWithPLC();  break;
                case 9: prop.timeSetD2_1.SyncWithPLC();  break;
                case 10: prop.timeSetD3_1.SyncWithPLC();  break;
                case 11: prop.timeSetD4_1.SyncWithPLC();  break;
                case 12: prop.timeSetD5_1.SyncWithPLC();  break;
                case 13: prop.timeSetD6_1.SyncWithPLC();  break;
                case 14: prop.timeSetD7_1.SyncWithPLC();  break;

                case 15: prop.timeSetP1_1.SyncWithPLC();  break;
                case 16: prop.timeSetP2_1.SyncWithPLC();  break;
                case 17: prop.timeSetP3_1.SyncWithPLC();  break;
                case 18: prop.timeSetP4_1.SyncWithPLC();  break;
                case 19: prop.timeSetP5_1.SyncWithPLC();  break;
                case 20: prop.timeSetP6_1.SyncWithPLC();  break;
                case 21: prop.timeSetP7_1.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }


            // GET/SET with plc KAD2
            prop.PrisotnostSarze2.SyncWithPLC();
            prop.Temperatura12.SyncWithPLC();
            prop.Temperatura22.SyncWithPLC();
            prop.Nivo2.SyncWithPLC();
            prop.DelovanjeGrelca2.SyncWithPLC();
            prop.Urniki_CikelAktiven2.SyncWithPLC();
            prop.SkupnaPorabaKadi2.SyncWithPLC();
            prop.Histereza1_2.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla2.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla2.SyncWithPLC();
            prop.DeltaOn1_2.SyncWithPLC();
            prop.Alarmzarazlikotemperature2.SyncWithPLC();
            prop.MUSS_Grelec2.SyncWithPLC();
            prop.MUSS_NivojskaCrpalka2.SyncWithPLC();
            prop.MocGrelca2.SyncWithPLC();
            prop.MocNivojskeCrpalke2.SyncWithPLC();
            prop.NivoVisok2.SyncWithPLC();
            prop.NivojskaCrpalkaOffDelay.SyncWithPLC();
            prop.DelovanjeNivojskeCrpalke2.SyncWithPLC();
            prop.DeltaOn2_2.SyncWithPLC();
            prop.Alarmzatemperaturo2.SyncWithPLC();

            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN_2.SyncWithPLC();  break;
                case 2: prop.Tor_EN_2.SyncWithPLC();  break;
                case 3: prop.Sre_EN_2.SyncWithPLC();  break;
                case 4: prop.Čet_EN_2.SyncWithPLC();  break;
                case 5: prop.Pet_EN_2.SyncWithPLC();  break;
                case 6: prop.Sob_EN_2.SyncWithPLC();  break;
                case 7: prop.Ned_EN_2.SyncWithPLC();  break;

                case 8: prop.timeSetD1_2.SyncWithPLC();  break;
                case 9: prop.timeSetD2_2.SyncWithPLC();  break;
                case 10: prop.timeSetD3_2.SyncWithPLC();  break;
                case 11: prop.timeSetD4_2.SyncWithPLC();  break;
                case 12: prop.timeSetD5_2.SyncWithPLC();  break;
                case 13: prop.timeSetD6_2.SyncWithPLC();  break;
                case 14: prop.timeSetD7_2.SyncWithPLC();  break;

                case 15: prop.timeSetP1_2.SyncWithPLC();  break;
                case 16: prop.timeSetP2_2.SyncWithPLC();  break;
                case 17: prop.timeSetP3_2.SyncWithPLC();  break;
                case 18: prop.timeSetP4_2.SyncWithPLC();  break;
                case 19: prop.timeSetP5_2.SyncWithPLC();  break;
                case 20: prop.timeSetP6_2.SyncWithPLC();  break;
                case 21: prop.timeSetP7_2.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }

            prop.Cntr++;

            // GET/SET with plc KAD3
            prop.PrisotnostSarze3.SyncWithPLC();

            // GET/SET with plc KAD4
            prop.PrisotnostSarze4.SyncWithPLC();


            // GET/SET with plc KAD5
            prop.PrisotnostSarze5.SyncWithPLC();

        }
    }
}
