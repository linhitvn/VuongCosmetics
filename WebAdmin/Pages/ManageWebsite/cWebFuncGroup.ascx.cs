using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class Pages_ManageWebsite_cWebFuncGroup : TUserControlForList
{
    DAWebFuncGroup tData = new DAWebFuncGroup();

    override protected Boolean SetServerControl()
    {
        try
        {
            this.messBox = message_box;

            //this.BtCreate = btCreate;
            //this.BtClone = btClone;
            //this.BtDelete = btDelete;
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
            if (ddlRGroup.Items.Count > 0)
            {
                Int32 iRGroup;
                iRGroup = Convert.ToInt32(ddlRGroup.SelectedValue);

                int UserID = int.Parse(MyConfig.GetValueByKey("UserID"));

                DataSet ds = new DataSet();
                ds = tData.USP_WebFunction_GetListByGroupIDAndUserID(iRGroup, UserID);
                RadTreeView1.DataSource = ds;
                RadTreeView1.DataBind();


                //

            }
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
        }

        return true;
    }


    override protected int DeleteByID(int pID)
    {
        //DATestUser tData = new DATestUser();
        try
        {
            tData.USP_WebFuncGroup_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }


    override protected Boolean GetDataComboBox() 
    {
        try
        {
            DAWebGroup mWGroup = new DAWebGroup();

            ddlRGroup.DataSource = mWGroup.USP_WebGroup_GetAllByComboByUserID(int.Parse(MySession.UserID));
            ddlRGroup.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }

        
    }

    protected void ddlRGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }

    protected void cSave_Click(object sender, EventArgs e)
    {
        try
        {
            String IDList = ",";
            IList<RadTreeNode> nodeCollection = RadTreeView1.CheckedNodes;
            foreach (RadTreeNode node in nodeCollection)
            {
                IDList += node.Value + ",";
            }

            Int32 iRGroup;
            iRGroup = Convert.ToInt32(ddlRGroup.SelectedValue);

            // Lưu phân quyền
            tData.USP_WebFuncGroup_UpdateFunc(iRGroup, IDList);

            ShowSuccessMes("Phân quyền thành công.");
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
        }
    }

}