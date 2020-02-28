using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class Pages_SysCategory_cRecordStatus : TUserControlForList
{
    DARecordStatus tData = new DARecordStatus();
    override protected Boolean SetServerControl()
    {
        try
        {
            this.Grid = RadGrid1;
            this.messBox = message_box;

            this.BtCreate = btCreate;
            this.BtClone = btClone;
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
            RadGrid1.DataSource = tData.USP_RecordStatus_GetAll(0, 0);
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
            return tData.USP_RecordStatus_Delete(pID);
        }
        catch { return 0; }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = tData.USP_RecordStatus_GetAll(0, 0);
    }
}