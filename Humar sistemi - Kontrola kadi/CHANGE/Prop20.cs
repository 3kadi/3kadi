using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace KontrolaKadi
{
    public class Prop20
    {

        public Sharp7.S7Client Client { get; set; }
        public bool firsTimeSync = true;

        public bool canWriteToPLC = false;
        public bool canReadFromPLC = true;

        public int Cntr { get; set; }



        // Public properties - AutoRetrieveable / Writable

        // CHANGE FROM HERE






        // CHANGE TO HERE

        public Prop20(Sharp7.S7Client client)
        {
            Client = client;
                        
                  

        }


        // add datagrid elements for submenu
        public void DatagridRowsInSubmenu(SmartDatagrid datagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Parameter", "Parameter"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Vrednost", "Vrednost"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable;

                // CHANGE FROM HERE (only show values)
                r = datagrid.Rows.Add("Sarža: ", PropComm.NA); datagrid[0, r].ReadOnly = true; datagrid[1, r].ReadOnly = true;



                //comboboxes



                // CHANGE TO HERE
            }
        }

        public void AddRowsToScheduleDatagrid(SmartDatagrid datagrid)
        {
            if (datagrid != null)
            {
                int r;

                r = datagrid.Columns.Add("Dan", "Dan"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 60;
                r = datagrid.Columns.Add("Vklop", "Vklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("Izklop", "Izklop"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 120;
                r = datagrid.Columns.Add("EN", "EN"); datagrid.Columns[r].SortMode = DataGridViewColumnSortMode.NotSortable; datagrid.Columns[r].Width = 40;


                // CHANGE FROM HERE (only show values)
                
                //comboboxes


                // CHANGE TO HERE
            }

        }


        public void UpdateValues(SmartDatagrid Main_datagrid, SmartDatagrid Shedule_datagrid)
        {
            try
            {
                if (Main_datagrid != null)
                {
                    if (Main_datagrid.Rows.Count > 0)
                    {

                        // CHANGE                   

                        // GET/SET With PC 



                        // END CHANGE

                    }
                }

                if (Shedule_datagrid != null)
                {
                    if (Shedule_datagrid.Rows.Count > 0)
                    {

                    }


                }
            }

            catch (Exception ex)
            {
                FormControl.bt1.WL("Adding values to datagrid is incomplete: device ID=" + Client.deviceID + ". Details: " + ex.Message, -1);
            }

        }

    }
}
