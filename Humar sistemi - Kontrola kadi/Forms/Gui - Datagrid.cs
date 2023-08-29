using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace KontrolaKadi
{

    public partial class Gui
    {      

        Font bold = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold);
        
        private void InitializeDatagrid(Kad kad)
        {           
            kad.Out_datagrid = new Datagrid();
            AddColumnToDatagrid(kad.Out_datagrid, "Vrednost", "Vrednost", false);
                        
            kad.Out_datagrid.AllowUserToAddRows = false;
            kad.Out_datagrid.AllowUserToDeleteRows = false;
            kad.Out_datagrid.AllowUserToOrderColumns = false;
            kad.Out_datagrid.AllowUserToResizeColumns = false;
            kad.Out_datagrid.AllowUserToResizeRows = false;
            kad.Out_datagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            kad.Out_datagrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            kad.Out_datagrid.RowHeadersVisible = false;
            kad.Out_datagrid.ColumnHeadersVisible = false;
            kad.Out_datagrid.RowTemplate.DividerHeight = 0;
            kad.Out_datagrid.ScrollBars = ScrollBars.None;
            kad.Out_datagrid.BackgroundColor = controlsColor;
            kad.Out_datagrid.ReadOnly = true;
            kad.Out_datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           
            kad.Out_datagrid.RowTemplate.Height = varsSizePX; // row height
            kad.Out_datagrid.DefaultCellStyle.Font = varsFont;
            kad.Out_datagrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
            try
            {                
                kad.Out_datagrid.BackgroundColor = Color.FromArgb(int.Parse(XML_handler.settingsXML.Element("root").Element("GUI" + GuiID).Element("GuiControlsColor").Value));
            }
            catch
            {
                kad.Out_datagrid.BackgroundColor = Color.Gray;
            }

            try
            {
                // CHANGE
                if (kad.Out_datagrid != null)
                {
                    kad.Out_datagrid.Rows.Add(); kad.Out_datagrid[0, 0].Value = XML_handler.settingsXML.Element("root").Element("GUI" + GuiID).Element("Kad" + kad.ID).Element("Processname").Value;
                    kad.Out_datagrid[0, 0].Style.ForeColor = Color.FromArgb(-16695460);
                    kad.Out_datagrid.Rows.Add(); kad.Out_datagrid[0, 1].Value = "";
                    kad.Out_datagrid.Rows.Add(); kad.Out_datagrid[0, 2].Value = "";
                    kad.Out_datagrid.Rows.Add(); kad.Out_datagrid[0, 3].Value = "";
                    kad.Out_datagrid.Rows.Add(); kad.Out_datagrid[0, 4].Value = "";
                    //kad.Out_datagrid.Rows.Add(); kad.Out_datagrid[0, 5].Value = "";
                    //kad.Out_datagrid.Rows.Add(); kad.Out_datagrid[0, 6].Value = "";
                    kad.Out_datagrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving data from XML file. Error while retrieving names of processes for datagrids: " + ex.Message);
            }


            try
            {                

                if (Convert.ToBoolean(XML_handler.settingsXML.Element("root").Element("GUI" + GuiID).Element("Kad" + kad.ID).Element("HasOutDatagrid").Value) == true)
                {
                    kad.Out_datagrid.ShowOnGUI = true;
                    if (kad.TypeOfKad != 0)
                    {
                        panel.Controls.Add(kad.Out_datagrid);
                    }
                }
                else
                {
                    kad.Out_datagrid.ShowOnGUI = false;
                }
                
            }
            catch 
            {
                if (kad.TypeOfKad != 0)
                {
                    panel.Controls.Add(kad.Out_datagrid);
                }
            }
            

            kad.Out_datagrid.Rows[0].Cells[0].Style.Font = bold;

            try
            {
                kad.valuesforOutDatagrid.Datagrid = kad.Main_datagrid;
            }
            catch { }
            
                        
        }
                
        private void PopulateDatagrid()
        {
            if (FormControl.bt1.InitialisationComplete)
            {
                // refreshes data in submenus
                foreach (var kad in kadi)
                {
                    if (kad != null)
                    {
                        kad.Out_datagrid[0, 1].Value = kad.valuesforOutDatagrid.postResult[1];
                        kad.Out_datagrid[0, 2].Value = kad.valuesforOutDatagrid.postResult[2];
                        kad.Out_datagrid[0, 3].Value = kad.valuesforOutDatagrid.postResult[3];
                        kad.Out_datagrid[0, 4].Value = kad.valuesforOutDatagrid.postResult[4];
                        //kad.Out_datagrid[0, 5].Value = kad.valuesforOutDatagrid.postResult[5];
                        //kad.Out_datagrid[0, 6].Value = kad.valuesforOutDatagrid.postResult[6];
                    }
                }                
            }           
        }
                

        private void NestDatagrids()
        {
            int state = 0;
            // datagrids height            
            for (int i = 1; i < StKadi + 1; i++)
            {
                if (!kadi[i].GetThisEnabled())
                {
                    kadi[i].Out_datagrid.Hide();
                }
                else
                {
                    kadi[i].Out_datagrid.Show();
                }

                if (kadi[i].TypeOfKad == 0 )
                {
                    // not shown
                }
                else if (kadi[i].TypeOfKad == 1 || kadi[i].TypeOfKad == 2 || kadi[i].TypeOfKad == 3)
                {
                    if (kadi[i].Out_datagrid != null)
                    {
                        kadi[i].Out_datagrid.Top = Misc.ToInt(_UnderTitleRect_Y + _UnderTitleRect_H + 20);
                        kadi[i].Out_datagrid.Height = 
                            (kadi[i].Out_datagrid.Rows.GetRowCount(DataGridViewElementStates.None)) * kadi[i].Out_datagrid.RowTemplate.Height + 
                            kadi[i].Out_datagrid.Rows.GetRowCount(DataGridViewElementStates.None) * kadi[i].Out_datagrid.RowTemplate.DividerHeight + 3;

                        if (kadi[i].TypeOfKad == 3 || state != 0)
                        {
                            if (state == 0) // 1st part of double drawing
                            {
                                kadi[i].Out_datagrid.Left = Misc.ToInt(_Containers[i].Left - _ContainerPause / 2.5F) - 1;
                                kadi[i].Out_datagrid.Width = Misc.ToInt(_Containers[i].Right + 0) - (kadi[i].Out_datagrid.Left)+1;
                                kadi[i].Out_datagrid.Columns[0].Width = kadi[i].Out_datagrid.Width;
                                state = 1;
                            }
                            else // 2nd part of double drawing
                            {
                                kadi[i].Out_datagrid.Left = Misc.ToInt(_Containers[i].Left - 0 + 1);
                                kadi[i].Out_datagrid.Width = Misc.ToInt(_Containers[i].Right + _ContainerPause / 2.5F) - (kadi[i].Out_datagrid.Left)+1;
                                kadi[i].Out_datagrid.Columns[0].Width = kadi[i].Out_datagrid.Width;
                                state = 0;
                            }
                        }                        
                        else
                        {
                            kadi[i].Out_datagrid.Left = Misc.ToInt(_Containers[i].Left - _ContainerPause / 2.5F);
                            kadi[i].Out_datagrid.Width = Misc.ToInt(_Containers[i].Right + _ContainerPause / 2.5F) - (kadi[i].Out_datagrid.Left)+1;
                            kadi[i].Out_datagrid.Columns[0].Width = kadi[i].Out_datagrid.Width;                            
                        }

                        kadi[i].Out_datagrid.Rows[0].Cells[0].Style.BackColor = Color.FromArgb(-3613441); // first line color change 

                    }
                }
                else
                {
                    throw new Exception("\"Type of kad\" entry is not supported. Type provided is: " + kadi[i].TypeOfKad);
                }                
            }
                        
        }

        private void Populate()
        {

            DateTime time1;
            DateTime time2;
            double refreshOriginalVal = 500;
            double refreshCalculated = 500;

            MethodInvoker mi = new MethodInvoker(delegate
            {
                PopulateDatagrid();                
            });

            try
            {
                refreshOriginalVal = int.Parse(settingsXML.Element("root").Element("GENERAL").Element("GUIrefreshrate").Value);
                if (refreshOriginalVal > 3000 || refreshOriginalVal < 100)
                {
                    refreshOriginalVal = 500;
                    FormControl.bt1.WL("GUI Refresh rate is not a suitable value (must not be >3000 or 100ms). Default value of 500ms is set.(message source: Form Settings)", -1);
                }
            }
            catch (Exception)
            {
                FormControl.bt1.WL("GUI Refresh rate entry can not be found in XML file provided. Default value of 500ms is set.(message source: Form Settings)", -1);
            }

           
            while (true)
            {
                try
                {
                    time1 = DateTime.Now;

                    if (btnStarted.StartedStatus == (int)StartedButton.StatedStatus.Started)
                    {
                        Invoke(mi);
                                                
                        for (int i = 1; i < kadi.Length; i++)
                        {
                            if (kadi[i] != null)
                            {
                                kadi[i].RefreshValuesInDatagrid();
                            }                           
                        }
                    }                    
                    
                    time2 = DateTime.Now;
                    refreshCalculated = refreshOriginalVal - (time2 - time1).TotalMilliseconds;
                    if (refreshCalculated < 10)
                    { refreshCalculated = 10; }
                    if (refreshCalculated > 3000)
                    { refreshCalculated = 3000; }
                    Thread.Sleep((int)refreshCalculated);

                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(ex.Message);
                }
                
            }

        }

        public static void AddColumnToDatagrid(DataGridView datagrid, string columnName, string columnHeaderText, bool isEditable)
        {

            int a = datagrid.Columns.Add(columnName, columnHeaderText);
            datagrid.Columns[a].ReadOnly = !isEditable;
            datagrid.Columns[a].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

    }
}
