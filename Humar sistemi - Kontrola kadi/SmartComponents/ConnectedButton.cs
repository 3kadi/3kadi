using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Threading;

namespace KontrolaKadi
{
    public class ConnectedButton : Button
    {
        
        public int ID { get;}
        public string Showname { get; set; }
        public int ConnectionStatus { get; set; }        
        private Bitmap disconnectedIcon;
        private Bitmap connectedIcon;
        private Bitmap connectedWarningIcon;
        private Bitmap connectingIcon;
        private int connstatcnt = 0;

        
        public int RefreshOriginalVal { get; set; }

        public ConnectedButton(int ID, int Height, int Width, int Top)
        {            
            this.ID = ID;
            this.Height = Height;
            this.Width = Width;
            this.Top = Top;
            RefreshOriginalVal = 500;

            ConnectionStatus = (int)Connection.Status.NotInitialised;

            try
            {
                Showname = Convert.ToString(XML_handler.settingsXML.Element("root").Element("LOGO" + ID).Element("showname").Value);
            }
            catch 
            {
                Showname = "";
            }
                      
            disconnectedIcon = Properties.Resources.disconnected;
            connectedIcon = Properties.Resources.connected;
            connectedWarningIcon = Properties.Resources.connect_warning;
            connectingIcon = Properties.Resources.connecing;                        
            BackgroundImage = disconnectedIcon;
            BackColor = DefaultBackColor;
            
            disconnectedIcon = Misc.Scale(disconnectedIcon, this.Height*0.75F);
            connectedIcon = Misc.Scale(connectedIcon, this.Height * 0.75F);
            connectedWarningIcon = Misc.Scale(connectedWarningIcon, this.Height * 0.75F);
            connectingIcon = Misc.Scale(connectingIcon, this.Height * 0.75F);
            this.BackgroundImageLayout = ImageLayout.Center;
            BackColor = Color.Transparent;

            // object own status retriever
            Thread updater = new Thread(new ThreadStart(Updater))
            {
                IsBackground = true,
                Name = "Updater Thread"
            };
            
            updater.Start();

            // on click
            this.Click += Clicked;
                        
        }
        

        private void Clicked(object sender, EventArgs e)
        {
            
            if (ConnectionStatus == (int)Connection.Status.Error)
            {
                Connect();
            }
            else if (ConnectionStatus == (int)Connection.Status.Connecting)
            {
                Disconnect();
            }
            else if (ConnectionStatus == (int)Connection.Status.Connected)
            {
                Disconnect();
            }
            else if (ConnectionStatus == (int)Connection.Status.Warning)
            {
                Disconnect();                
            }
            else
            {                
                Connect();
            }


        }

        public void Connect()
        {   
            if (FormControl.identify.GetPermision(4))
            {
                BackgroundImage = connectingIcon;
                FormControl.Form_settings.ConnectAsync(this.ID);
            }
            else
            {
                FormControl.identify.ShowPermissionError();
            }
        }

        public void Disconnect()
        {
            if (FormControl.identify.GetPermision(4))
            {
                BackgroundImage = connectingIcon;
                FormControl.Form_settings.DisconnectAsync(this.ID);
            }
            else
            {
                FormControl.identify.ShowPermissionError();
            }
        }

        public void UpdateConnectionStatus()
        {
            if (ConnectionStatus == (int)Connection.Status.NotInitialised){
                BackgroundImage = disconnectedIcon;
                connstatcnt = 0;
                return;}

            if (ConnectionStatus == (int)Connection.Status.Error){
                BackgroundImage = disconnectedIcon;
                connstatcnt = 0;
                return;}

            if (ConnectionStatus == (int)Connection.Status.Warning){
                BackgroundImage = connectedWarningIcon;
                connstatcnt = 0;
                return;}

            if (ConnectionStatus == (int)Connection.Status.Connecting){
                BackgroundImage = connectingIcon;
                connstatcnt = 0;
                return;}

            if (ConnectionStatus == (int)Connection.Status.Connected){       
                if (connstatcnt >= 2){
                    BackgroundImage = connectedIcon;}
                connstatcnt++;
                return;}            
        }
                

        public void RetrieveConnectionStatus()
        {
            try
            {
                ConnectionStatus = FormControl.bt1.LOGOConnection[ID].connectionStatusLOGO;

            }
            catch (Exception e)
            {
                ConnectionStatus = (int)Connection.Status.Error;
                var a = e.Message;
            }

        }

        public void Updater()
        {        
            while (true)
            {
                try
                {
                                       
                    RetrieveConnectionStatus();
                    UpdateConnectionStatus();
                    
                        System.Threading.Thread.Sleep(RefreshOriginalVal);                    
                    
                }
                catch 
                {
                    
                }                
            }
            
        }
        
    }
}
