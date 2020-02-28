using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class Pages_Widgets_ShortCut : TUserControlForList
{
    DAShortCut tData = new DAShortCut();
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

    override protected Boolean GetDataComboBox()
    {

        DAShortCutType daShortCutType = new DAShortCutType();
        sShortCutTypeID.DataSource = daShortCutType.USP_ShortCutType_GetDataForComboBox();
        sShortCutTypeID.DataBind();
        return true;
    }

    override protected Boolean LoadData()
    {
        try
        {
            RadGrid1.DataSource = tData.USP_ShortCut_GetByShortTypeID(int.Parse(sShortCutTypeID.Value));
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
            return tData.USP_ShortCut_Delete(pID);
        }
        catch { return 0; }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = tData.USP_ShortCut_GetByShortTypeID(int.Parse(sShortCutTypeID.Value));
    }

    protected void Search_Click(object sender, EventArgs e)
    {       
        LoadData();
    }
}