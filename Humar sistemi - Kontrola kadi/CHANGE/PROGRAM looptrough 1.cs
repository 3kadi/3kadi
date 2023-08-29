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
        

        public void PROGRAM1(Prop1 prop)
        {
            // This program is for LOGO1 - Master

            // GET/SET with plc    
            prop.EloxConnected.SyncWithPLC();
            prop.BarveConnected.SyncWithPLC(); 
            prop.PC_Connected.SyncWithPLC();
            prop.WATCHDOG_Logo1.SyncWithPLC();
            prop.StartNetElox.SyncWithPLC();
            prop.StopNetElox.SyncWithPLC();
            prop.StartNetBarve.SyncWithPLC();
            prop.StopNetBarve.SyncWithPLC();

            prop.MaxPowerSet1.SyncWithPLC();
            prop.MaxPowerSet2.SyncWithPLC();

            prop.EN_Kad1.SyncWithPLC();
            prop.EN_Kad2.SyncWithPLC();
            prop.EN_Kad6.SyncWithPLC();
            prop.EN_Kad7.SyncWithPLC();
            prop.EN_Kad9.SyncWithPLC();
            prop.EN_Kad10.SyncWithPLC();
            prop.EN_Kad12.SyncWithPLC();
            prop.EN_Kad14.SyncWithPLC();
            prop.EN_Kad16.SyncWithPLC();
            prop.EN_Kad18.SyncWithPLC();
            prop.EN_Kad19.SyncWithPLC();

            prop.EN_Kad3.SyncWithPLC();
            prop.EN_Kad4.SyncWithPLC();
            prop.EN_Kad5.SyncWithPLC();
            prop.EN_Kad8.SyncWithPLC();
            prop.EN_Kad11.SyncWithPLC();
            prop.EN_Kad13.SyncWithPLC();
            prop.EN_Kad15.SyncWithPLC();
            prop.EN_Kad17.SyncWithPLC();

            prop.Watchdog_PC_value.SyncWithPLC();

            prop.BuzzFromPC_Normal.SyncWithPLC();
            prop.BuzzFromPC_Urgent.SyncWithPLC();
            prop.BuzzFromPC_Stop.SyncWithPLC();

            prop.LogoTimeShowOnly.SyncWithPLC();

            prop.EloxPoraba.SyncWithPLC();
            prop.BarvePoraba.SyncWithPLC();

        }
    }
}
