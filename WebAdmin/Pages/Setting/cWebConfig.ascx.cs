using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Telerik.Web.UI;

public partial class Pages_Setting_cWebConfig : TUserControlForList
{
    DAWebConfig tData = new DAWebConfig();
    override protected Boolean SetServerControl()
    {
        try
        {
            this.Grid = RadGrid1;
            this.messBox = message_box;

            if (MyConfig.DevMode)
            {
                //this.BtCreate = btCreate;
                //this.BtClone = btClone;
                //this.BtDelete = btDelete;
            }

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
            RadGrid1.DataSource = tData.USP_WebConfig_GetAll(0, 0);
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
            return tData.USP_WebConfig_Delete(pID);
        }
        catch { return 0; }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = tData.USP_WebConfig_GetAll(0, 0);
    }
    /// <summary>
    /// Update 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void UpdateListConfigValue_CLick(object sender, EventArgs e)
    {
        //check valid input
        bool dataIsValid = true;
        //bool isIntValue;
        //foreach (GridDataItem item in RadGrid1.Items)
        //{
        //    isIntValue = bool.Parse(item["IsIntValue"].Text);
        //    //if it's integer value then checking
        //    if (isIntValue)
        //    {
        //        RadTextBox fConfigValue = (RadTextBox)item.FindControl("fConfigValue");
        //        int number;
        //        // check true or fasle integer value
        //        dataIsValid = int.TryParse(fConfigValue.Text, out number);
        //        if (!dataIsValid)
        //        {
        //            ShowErrorMes("Dữ liệu nhập vào không đúng format. Vui lòng nhập số.");
        //            break;
        //        }
        //    }
        //    //try
        //    //{
        //    //    isIntValue = bool.Parse(item["IsIntValue"].Text);
        //    //    //if it's integer value then checking
        //    //    if (isIntValue)
        //    //    {
        //    //        RadTextBox fConfigValue = (RadTextBox)item.FindControl("fConfigValue");
        //    //        int number;
        //    //        // check true or fasle integer value
        //    //        dataIsValid = int.TryParse(fConfigValue.Text, out number);
        //    //        if (!dataIsValid)
        //    //        {
        //    //            ShowErrorMes("Dữ liệu nhập vào không đúng format. Vui lòng nhập số.");
        //    //            break;
        //    //        }
        //    //    }

        //    //}
        //    //catch
        //    //{
        //    //    ShowErrorMes("Có lỗi xảy ra, vui lòng liên hệ Quản trị.");
        //    //    dataIsValid = false;
        //    //    break;
        //    //}
        //}
        //--------------------------------------------------------------------------------//
        if (dataIsValid)
        {
            int configID = 0;
            //Uupdate database
            foreach (GridDataItem item in RadGrid1.Items)
            {
                try
                {
                    // get data update
                    configID = int.Parse(item.GetDataKeyValue("ConfigID").ToString());
                    RadTextBox fConfigValue = (RadTextBox)item.FindControl("fConfigValue");

                    // update to database
                    DAWebConfig daWebConfig = new DAWebConfig();
                    daWebConfig.USP_WebConfig_UpdateListConfigValue(configID, fConfigValue.Text);

                }
                catch 
                {
                    ShowErrorMes("Có lỗi! Cập nhật dữ liệu không thành công.");
                    dataIsValid = false;
                    break;
                }
            }
        }
        // check successful update
        if (dataIsValid)
        {
            ShowSuccessMes("Dữ liệu đã được cập nhật thành công. Vui lòng login lại.");
            LoadData();
        }
    }

}