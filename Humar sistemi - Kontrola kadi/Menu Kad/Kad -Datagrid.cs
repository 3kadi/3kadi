using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace KontrolaKadi
{
    public partial class Kad : Panel
    {
        
        public void RefreshValuesInDatagrid()
        {
            // CHANGE

            switch (ID)
            {
                case 1: FormControl.bt1.Prop2.UpdateValues_1(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 2: FormControl.bt1.Prop2.UpdateValues_2(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;                
                case 3: FormControl.bt1.Prop2.UpdateValues_3(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 4: FormControl.bt1.Prop2.UpdateValues_4(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 5: FormControl.bt1.Prop2.UpdateValues_5(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 6: FormControl.bt1.Prop3.UpdateValues_6(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 7: FormControl.bt1.Prop4.UpdateValues_7(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 8: FormControl.bt1.Prop4.UpdateValues_8(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 9: FormControl.bt1.Prop5.UpdateValues_9(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 10: FormControl.bt1.Prop6.UpdateValues_10(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 11: FormControl.bt1.Prop8.UpdateValues_11(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 12: FormControl.bt1.Prop6.UpdateValues_12(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break; 
                case 13: FormControl.bt1.Prop6.UpdateValues_13(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 14: FormControl.bt1.Prop6.UpdateValues_14(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 15: FormControl.bt1.Prop7.UpdateValues_15(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 16: FormControl.bt1.Prop7.UpdateValues_16(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 17: FormControl.bt1.Prop7.UpdateValues_17(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 18: FormControl.bt1.Prop7.UpdateValues_18(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break;
                case 19: FormControl.bt1.Prop8.UpdateValues_19(Main_datagrid, Schedule_datagrid, Schedule_datagrid_Status); break; 
                default:
                    break;
            }



        }

        
        private void PaintDatagrids(PaintEventArgs e, float X, float Y, int border)
        {
            float buff;
            float Void;
            Main_datagrid.Left = (int)X;
            Main_datagrid.Top = (int)Y;
            Main_datagrid.Width = Main_datagrid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + Main_datagrid.RowTemplate.DividerHeight * (Main_datagrid.ColumnCount +1) + 4;
            Main_datagrid.Height = (Main_datagrid.Rows.GetRowCount(DataGridViewElementStates.None)) * Main_datagrid.RowTemplate.Height + Main_datagrid.Rows.GetRowCount(DataGridViewElementStates.None) * Main_datagrid.RowTemplate.DividerHeight + 2 + Main_datagrid.ColumnHeadersHeight;
            Main_datagrid_rect.X = Main_datagrid.Location.X - border;
            Main_datagrid_rect.Width = Main_datagrid.Width + 2* border;
            Main_datagrid_rect.Y = Main_datagrid.Location.Y -2* border;
            Main_datagrid_rect.Height = Main_datagrid.Height + 3 * border;
            e.Graphics.FillRectangle(DatagridBorderBrush, Main_datagrid_rect);            
            Misc.CalculateCenter(Main_datagrid_rect.X, Main_datagrid_rect.Width, Main_datagrid_rect.Y, Main_datagrid_rect.Height, Main_datagrid_Label.Width, Main_datagrid_Label.Height, out buff, out Void);
            Main_datagrid_Label.Left = (int)buff;
            Main_datagrid_Label.Top = Main_datagrid_rect.Top + 4;

            if (this.hasSchedule)
            {
                Schedule_datagrid.Left = (int)X + Main_datagrid.Width + 50;
                Schedule_datagrid.Top = (int)Y;
                Schedule_datagrid.Width = Schedule_datagrid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + Schedule_datagrid.RowTemplate.DividerHeight * (Schedule_datagrid.ColumnCount + 1) + 4;
                Schedule_datagrid.Height = (Schedule_datagrid.Rows.GetRowCount(DataGridViewElementStates.None)) * Schedule_datagrid.RowTemplate.Height + Schedule_datagrid.Rows.GetRowCount(DataGridViewElementStates.None) * Schedule_datagrid.RowTemplate.DividerHeight + 2 + Schedule_datagrid.ColumnHeadersHeight;
                                
                Schedule_datagrid_Status.Left = Schedule_datagrid.Left;
                Schedule_datagrid_Status.Top = Schedule_datagrid.Top + Schedule_datagrid.Height + 20;
                Schedule_datagrid_Status.Width = Schedule_datagrid.Width;
                Schedule_datagrid_Status.Height = (Schedule_datagrid_Status.Rows.GetRowCount(DataGridViewElementStates.None)) * Schedule_datagrid_Status.RowTemplate.Height + Schedule_datagrid_Status.Rows.GetRowCount(DataGridViewElementStates.None) * Schedule_datagrid_Status.RowTemplate.DividerHeight + 2;

                Schedule_datagrid_rect.X = Schedule_datagrid.Location.X - border;
                Schedule_datagrid_rect.Width = Schedule_datagrid.Width + 2 * border;
                Schedule_datagrid_rect.Y = Schedule_datagrid.Location.Y - 2 * border;
                Schedule_datagrid_rect.Height = (Schedule_datagrid.Height + Schedule_datagrid_Status.Height + 3 * border) +20;

                e.Graphics.FillRectangle(DatagridBorderBrush, Schedule_datagrid_rect);
                Misc.CalculateCenter(Schedule_datagrid_rect.X, Schedule_datagrid_rect.Width, Schedule_datagrid_rect.Y, Schedule_datagrid_rect.Height, Schedule_datagrid_Label.Width, Schedule_datagrid_Label.Height, out buff, out Void);
                Schedule_datagrid_Label.Left = (int)buff;
                Schedule_datagrid_Label.Top = Schedule_datagrid_rect.Top + 4;

            }           
            
        }

        
        private static void AddRowsToMainDatagrid(SmartDatagrid datagrid, int ID)
        {
            // CHANGE
            switch (ID) 
            {                
                case 1: FormControl.bt1.Prop2.DatagridRowsInSubmenu_1(datagrid); break;
                case 2: FormControl.bt1.Prop2.DatagridRowsInSubmenu_2(datagrid); break;
                case 3: FormControl.bt1.Prop2.DatagridRowsInSubmenu_3(datagrid); break;
                case 4: FormControl.bt1.Prop2.DatagridRowsInSubmenu_4(datagrid); break;
                case 5: FormControl.bt1.Prop2.DatagridRowsInSubmenu_5(datagrid); break;
                case 6: FormControl.bt1.Prop3.DatagridRowsInSubmenu_6(datagrid); break;
                case 7: FormControl.bt1.Prop4.DatagridRowsInSubmenu_7(datagrid); break;
                case 8: FormControl.bt1.Prop4.DatagridRowsInSubmenu_8(datagrid); break;
                case 9: FormControl.bt1.Prop5.DatagridRowsInSubmenu_9(datagrid); break;
                case 10: FormControl.bt1.Prop6.DatagridRowsInSubmenu_10(datagrid); break; 
                case 11: FormControl.bt1.Prop8.DatagridRowsInSubmenu_11(datagrid); break; 
                case 12: FormControl.bt1.Prop6.DatagridRowsInSubmenu_12(datagrid); break; 
                case 13: FormControl.bt1.Prop6.DatagridRowsInSubmenu_13(datagrid); break;
                case 14: FormControl.bt1.Prop6.DatagridRowsInSubmenu_14(datagrid); break;
                case 15: FormControl.bt1.Prop7.DatagridRowsInSubmenu_15(datagrid); break;
                case 16: FormControl.bt1.Prop7.DatagridRowsInSubmenu_16(datagrid); break;
                case 17: FormControl.bt1.Prop7.DatagridRowsInSubmenu_17(datagrid); break;
                case 18: FormControl.bt1.Prop7.DatagridRowsInSubmenu_18(datagrid); break;
                case 19: FormControl.bt1.Prop8.DatagridRowsInSubmenu_19(datagrid); break; 
                default: FormControl.bt1.WL("Error adding row to datagrid in submenu (" + ID + ").", -1); break;

            }

        }

        private static void AddRowsToScheduleDatagrid(SmartDatagrid datagrid, SmartDatagrid Statusdatagrid, int ID)
        {
            // CHANGE
            switch (ID)
            {
                case 1: FormControl.bt1.Prop2.AddRowsToScheduleDatagrid_1(datagrid, Statusdatagrid); break;
                case 2: FormControl.bt1.Prop2.AddRowsToScheduleDatagrid_2(datagrid, Statusdatagrid); break;
                case 3: FormControl.bt1.Prop2.AddRowsToScheduleDatagrid_3(datagrid, Statusdatagrid); break;
                case 4: FormControl.bt1.Prop2.AddRowsToScheduleDatagrid_4(datagrid, Statusdatagrid); break;
                case 5: FormControl.bt1.Prop2.AddRowsToScheduleDatagrid_5(datagrid, Statusdatagrid); break;
                case 6: FormControl.bt1.Prop3.AddRowsToScheduleDatagrid_6(datagrid, Statusdatagrid); break;
                case 7: FormControl.bt1.Prop4.AddRowsToScheduleDatagrid_7(datagrid, Statusdatagrid); break;
                case 8: FormControl.bt1.Prop4.AddRowsToScheduleDatagrid_8(datagrid, Statusdatagrid); break;
                case 9: FormControl.bt1.Prop5.AddRowsToScheduleDatagrid_9(datagrid, Statusdatagrid); break;
                case 10: FormControl.bt1.Prop6.AddRowsToScheduleDatagrid_10(datagrid, Statusdatagrid); break; 
                case 11: FormControl.bt1.Prop8.AddRowsToScheduleDatagrid_11(datagrid, Statusdatagrid); break;
                case 12: FormControl.bt1.Prop6.AddRowsToScheduleDatagrid_12(datagrid, Statusdatagrid); break; 
                case 13: FormControl.bt1.Prop6.AddRowsToScheduleDatagrid_13(datagrid, Statusdatagrid); break;
                case 14: FormControl.bt1.Prop6.AddRowsToScheduleDatagrid_14(datagrid, Statusdatagrid); break;
                case 15: FormControl.bt1.Prop7.AddRowsToScheduleDatagrid_15(datagrid, Statusdatagrid); break;
                case 16: FormControl.bt1.Prop7.AddRowsToScheduleDatagrid_16(datagrid, Statusdatagrid); break;
                case 17: FormControl.bt1.Prop7.AddRowsToScheduleDatagrid_17(datagrid, Statusdatagrid); break;
                case 18: FormControl.bt1.Prop7.AddRowsToScheduleDatagrid_18(datagrid, Statusdatagrid); break;
                case 19: FormControl.bt1.Prop8.AddRowsToScheduleDatagrid_19(datagrid, Statusdatagrid); break; 
                default: FormControl.bt1.WL("Error adding row to datagrid in submenu (" + ID + ").", -1); break;

            }
        }
    }
}
