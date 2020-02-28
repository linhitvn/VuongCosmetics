using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class Pages_Setting_cLogTable : TUserControlForList
{
    DALogTable tData = new DALogTable();
    override protected Boolean SetServerControl()
    {
        try
        {
            this.Grid = RadGrid1;
            this.messBox = message_box;

            this.BtCreate = btCreate;
            //this.BtClone = btClone;

            if (MyConfig.IsRoleSa) // If Role Sa --> Show button Delete
                this.BtDelete = btDelete;

            RadGrid1.PageSize = Convert.ToInt32(MyConfig.GetValueByKey("PageSize"));
        }
        catch
        {
            return false;
        }

        return true;
    }
    override protected Boolean LoadData()
    {
        try
        {
            RadGrid1.DataSource = tData.FUNC_GET_STATUS_TABLE_TRIGGER_ALL();
            RadGrid1.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            // DELETE TRIGGER
            tData.USP_LogTable_GetFullID(pID);
            tData.FUNC_DELETE_LOG_FOR_TABLE(tData.fTableName);

            return tData.USP_LogTable_Delete(pID);
        }
        catch { return 0; }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = tData.USP_LogTable_GetAll(0, 0);
    }
}