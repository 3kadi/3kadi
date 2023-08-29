using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace KontrolaKadi
{
    public class SmartDatagrid : DataGridView
    {
        public Gui _MotherForm;
        public int?  RowsHeight { get; set; }
        public int ID { get; set; }
       
        public SmartDatagrid(Gui MotherForm, int _ID)
        {
            
            AutoGenerateColumns = true;            
            RowHeadersWidth = RowHeadersWidth;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            AllowUserToOrderColumns = false;
            ReadOnly = false;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            RowHeadersVisible = false;            
            RowTemplate.DividerHeight = 0;
            DefaultCellStyle.SelectionBackColor = DefaultCellStyle.BackColor;
            DefaultCellStyle.SelectionForeColor = DefaultCellStyle.ForeColor;
            ScrollBars = ScrollBars.None;
            SelectionMode = DataGridViewSelectionMode.CellSelect;
            EditMode = DataGridViewEditMode.EditOnEnter;
            _MotherForm = MotherForm;
            ID = _ID;

            try
            {
                BackgroundColor = Color.FromArgb(int.Parse(XML_handler.settingsXML.Element("root").Element("GUI" + _MotherForm.GuiID).Element("GuiControlsColor").Value));
            }
            catch
            {
                BackgroundColor = Color.Gray;
            }

            if (RowsHeight != null)
            {
                RowTemplate.Height = (int)RowsHeight;
            }
            else
            {
                RowTemplate.Height = 20;
            }
                        
            this.ColumnHeadersHeight = 40;
            this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(this.DefaultCellStyle.Font.FontFamily, 10, System.Drawing.FontStyle.Bold); ;

            this.CellBeginEdit += SmartDatagrid_CellBeginEdit;
            CellContentClick += In_datagrid_CellContentClick;
            DataError += In_datagrid_DataError;
            CurrentCellDirtyStateChanged += In_datagrid_CurrentCellDirtyStateChanged;            
            RowsAdded += SmartDatagrid_RowsAdded;
        }

        private void SmartDatagrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SmartDatagrid grd;
            grd = (SmartDatagrid)sender;
            if (grd[e.ColumnIndex, e.RowIndex].GetType() == typeof(DatagridTypes.MussLauf))
            {
                if (!FormControl.identify.GetPermision(7))
                {
                    FormControl.identify.ShowPermissionError();
                    e.Cancel = true;
                }
            }
        }

        private void SmartDatagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //format
            var fb = new Font(this.DefaultCellStyle.Font, FontStyle.Bold);
            this[0, e.RowIndex].Style.Font = fb;
        }

        

        private void In_datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {                         
            if (sender.GetType() == typeof(SmartDatagrid))
            {
                SmartDatagrid grd;
                grd = (SmartDatagrid)sender;                
                if (grd[e.ColumnIndex, e.RowIndex].GetType() == typeof(DatagridTypes.TempSet))
                {
                    var c = (DatagridTypes.TempSet)grd[e.ColumnIndex, e.RowIndex];                    
                    c.ShowForm();
                }
                if (grd[e.ColumnIndex, e.RowIndex].GetType() == typeof(DatagridTypes.PwrSet))
                {
                    var c = (DatagridTypes.PwrSet)grd[e.ColumnIndex, e.RowIndex];
                    c.ShowForm();
                }
                if (grd[e.ColumnIndex, e.RowIndex].GetType() == typeof(DatagridTypes.TimeDurationSec))
                {
                    var c = (DatagridTypes.TimeDurationSec)grd[e.ColumnIndex, e.RowIndex];
                    c.ShowForm();
                }
                if (grd[e.ColumnIndex, e.RowIndex].GetType() == typeof(DatagridTypes.PhSet))
                {
                    var c = (DatagridTypes.PhSet)grd[e.ColumnIndex, e.RowIndex];
                    c.ShowForm();
                }
                
            }
        }
        
        private void In_datagrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
            //RefreshEdit();
            //CommitEdit(new DataGridViewDataErrorContexts());
            EndEdit();

        }

        private void In_datagrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (this[e.ColumnIndex, e.RowIndex].Value.ToString() != PropComm.NA)
            {
                Console.WriteLine("Cant set value in datagrid properly." + "Datagrid ID (inside Menu): " + ID + ". Row is: " + e.RowIndex + ". Column is: " + e.ColumnIndex + ". Value is: " + this[e.ColumnIndex, e.RowIndex].Value.ToString());
                System.Threading.Thread.Sleep(100);
            }
        }
    }

    
}
