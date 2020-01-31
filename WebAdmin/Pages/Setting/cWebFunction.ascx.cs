using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_Setting_cWebFunction : TUserControlForList_TreeList
{

    override protected Boolean SetServerControl()
    {
        try
        {
            this.Grid = rtl;
            this.messBox = message_box;

            this.BtCreate = btCreate;
            this.BtClone = btClone;
            this.BtDelete = btDelete;

            rtl.PageSize = Convert.ToInt32(MyConfig.GetValueByKey("PageSize"));
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
            DAWebFunction tData = new DAWebFunction();
            rtl.DataSource = tData.USP_WebFunction_GetAll(0, 0);
            rtl.DataBind();

            rtl.ExpandAllItems();

            return true;
        }
        catch (Exception e) {
            ShowErrorMes("Lổi hệ thống: " + e.ToString());
            return false;
        };

    }

    override protected int DeleteByID(int pID)
    {
        DAWebFunction tData = new DAWebFunction();
        try
        {
            return tData.USP_WebFunction_Delete(pID);
        }
        catch { return -1; }
    }


    protected void rtl_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
    {
        DAWebFunction tData = new DAWebFunction();
        rtl.DataSource = tData.USP_WebFunction_GetAll(0, 0);
    }

}