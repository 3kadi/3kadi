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
        public void PROGRAM6(Prop6 prop)
        {
            
            var dt1 = DateTimeOffset.Now;
            var dt2 = dt1;

            // GET/SET with plc KAD10
            prop.Nivo12.SyncWithPLC();
            prop.DelovanjeGrelca12.SyncWithPLC();
            prop.Temperatura112.SyncWithPLC();
            prop.Temperatura212.SyncWithPLC();
            prop.Ph12.SyncWithPLC();
            prop.Histereza1_12.SyncWithPLC();
            prop.DeltaOn1_12.SyncWithPLC();
            prop.Alarmzarazlikotemperature12.SyncWithPLC();
            prop.DelovanjeMesanja12.SyncWithPLC();
            prop.MUSS_Grelec12.SyncWithPLC();
            prop.PrisotnostSarze12.SyncWithPLC();
            prop.MUSS_FiltracijskaCrpalka12.SyncWithPLC();
            prop.MocGrelca12.SyncWithPLC();
            prop.PhOverLimitForAlarm12.SyncWithPLC();
            prop.PhUnderLimitForAlarm12.SyncWithPLC();
            prop.AlarmPh12.SyncWithPLC();
            prop.MocFiltracijskeCrpalke12.SyncWithPLC();
            prop.SkupnaPorabaKadi12.SyncWithPLC();
            prop.DeltaOn2_12.SyncWithPLC();
            prop.Alarmzatemperaturo12.SyncWithPLC();

            prop.Urniki_CikelAktiven12.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla12.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla12.SyncWithPLC();

            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN_12.SyncWithPLC();  break;
                case 2: prop.Tor_EN_12.SyncWithPLC();  break;
                case 3: prop.Sre_EN_12.SyncWithPLC();  break;
                case 4: prop.Čet_EN_12.SyncWithPLC();  break;
                case 5: prop.Pet_EN_12.SyncWithPLC();  break;
                case 6: prop.Sob_EN_12.SyncWithPLC();  break;
                case 7: prop.Ned_EN_12.SyncWithPLC();  break;

                case 8: prop.timeSetD1_12.SyncWithPLC();  break;
                case 9: prop.timeSetD2_12.SyncWithPLC();  break;
                case 10: prop.timeSetD3_12.SyncWithPLC();  break;
                case 11: prop.timeSetD4_12.SyncWithPLC();  break;
                case 12: prop.timeSetD5_12.SyncWithPLC();  break;
                case 13: prop.timeSetD6_12.SyncWithPLC();  break;
                case 14: prop.timeSetD7_12.SyncWithPLC();  break;

                case 15: prop.timeSetP1_12.SyncWithPLC();  break;
                case 16: prop.timeSetP2_12.SyncWithPLC();  break;
                case 17: prop.timeSetP3_12.SyncWithPLC();  break;
                case 18: prop.timeSetP4_12.SyncWithPLC();  break;
                case 19: prop.timeSetP5_12.SyncWithPLC();  break;
                case 20: prop.timeSetP6_12.SyncWithPLC();  break;
                case 21: prop.timeSetP7_12.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }
           
            // GET/SET with plc KAD11
            prop.PrisotnostSarze10.SyncWithPLC();

            // GET/SET with plc KAD12
            prop.Nivo14.SyncWithPLC();
            prop.DelovanjeGrelca14.SyncWithPLC();
            prop.Temperatura114.SyncWithPLC();
            prop.Temperatura214.SyncWithPLC();
            prop.Ph14.SyncWithPLC();
            prop.Histereza1_14.SyncWithPLC();
            prop.DeltaOn1_14.SyncWithPLC();
            prop.Alarmzarazlikotemperature14.SyncWithPLC();
            prop.DelovanjeMesanja14.SyncWithPLC();
            prop.MUSS_Grelec14.SyncWithPLC();
            prop.PrisotnostSarze14.SyncWithPLC();
            prop.MUSS_FiltracijskaCrpalka14.SyncWithPLC();
            prop.MocGrelca14.SyncWithPLC();
            prop.PhOverLimitForAlarm14.SyncWithPLC();
            prop.PhUnderLimitForAlarm14.SyncWithPLC();
            prop.AlarmPh14.SyncWithPLC();
            prop.MocFiltracijskeCrpalke14.SyncWithPLC();
            prop.SkupnaPorabaKadi14.SyncWithPLC();
            prop.DeltaOn2_14.SyncWithPLC();
            prop.Alarmzatemperaturo14.SyncWithPLC();

            prop.Urniki_CikelAktiven14.SyncWithPLC();
            prop.TemperaturaAktivnegaCikla14.SyncWithPLC();
            prop.TemperaturaPasivnegaCikla14.SyncWithPLC();

            switch (prop.Cntr)
            {
                case 1: prop.Pon_EN_14.SyncWithPLC();  break;
                case 2: prop.Tor_EN_14.SyncWithPLC();  break;
                case 3: prop.Sre_EN_14.SyncWithPLC();  break;
                case 4: prop.Čet_EN_14.SyncWithPLC();  break;
                case 5: prop.Pet_EN_14.SyncWithPLC();  break;
                case 6: prop.Sob_EN_14.SyncWithPLC();  break;
                case 7: prop.Ned_EN_14.SyncWithPLC();  break;

                case 8: prop.timeSetD1_14.SyncWithPLC();  break;
                case 9: prop.timeSetD2_14.SyncWithPLC();  break;
                case 10: prop.timeSetD3_14.SyncWithPLC();  break;
                case 11: prop.timeSetD4_14.SyncWithPLC();  break;
                case 12: prop.timeSetD5_14.SyncWithPLC();  break;
                case 13: prop.timeSetD6_14.SyncWithPLC();  break;
                case 14: prop.timeSetD7_14.SyncWithPLC();  break;

                case 15: prop.timeSetP1_14.SyncWithPLC();  break;
                case 16: prop.timeSetP2_14.SyncWithPLC();  break;
                case 17: prop.timeSetP3_14.SyncWithPLC();  break;
                case 18: prop.timeSetP4_14.SyncWithPLC();  break;
                case 19: prop.timeSetP5_14.SyncWithPLC();  break;
                case 20: prop.timeSetP6_14.SyncWithPLC();  break;
                case 21: prop.timeSetP7_14.SyncWithPLC();  break;
                default: prop.Cntr = 0; break;
            }

            prop.Cntr++;

            // GET/SET with plc KAD13
            prop.PrisotnostSarze13.SyncWithPLC();
                        
        }
    }
}
