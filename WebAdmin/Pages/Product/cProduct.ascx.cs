using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class Pages_Product_cProduct : TUserControlForList
{
    DAProduct tData = new DAProduct();
    override protected Boolean SetServerControl()
    {
        try
        {
            this.Grid = RadGrid1;
            this.messBox = message_box;

            this.BtCreate = btCreate;
            //this.BtClone = btClone;
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
        DAProductCat daProductCat = new DAProductCat();
        sProductCat.DataSource = daProductCat.USP_ProductCat_GetDataForComboBox();
        sProductCat.DataBind();

        return true;
    }

    override protected Boolean LoadData()
    {
        try
        {
            string productNC = Utils.convertToUnSign2(sProductCN.Value);
            int ProductCatID = int.Parse(sProductCat.Value);

            RadGrid1.DataSource = tData.USP_Product_Search(productNC, ProductCatID);
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
            return tData.USP_Product_Delete(pID);
        }
        catch { return 0; }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        string productNC = Utils.convertToUnSign2(sProductCN.Value);
        int ProductCatID = int.Parse(sProductCat.Value);

        RadGrid1.DataSource = tData.USP_Product_Search(productNC, ProductCatID);
    }
}