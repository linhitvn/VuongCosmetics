using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Menu_cMenuItemAlter : TUserControlForAlter
{
    override protected Boolean SetServerControl()
    {
        try
        {
            // Set Message Value
            this.messBox = message_box;

            // Set button Controller
            this.BtSave1 = Save;
            this.BtSaveAndCreate1 = SaveAndCreate;
        }
        catch
        {
            ShowErrorMes("Lỗi hệ thống Control !");
            return false;
        }

        return true;
    }

    override protected Boolean GetDataComboBox()
    {
        try
        {
            DAMenu daMenu = new DAMenu();
            fMenuID.DataSource = daMenu.USP_Menu_GetDataForComboBox();
            fMenuID.DataBind();

            DAMenuItem daMenuItem = new DAMenuItem();
            fParentID.DataSource = daMenuItem.USP_MenuItem_GetDataForComboBox(this.KeyID);
            fParentID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAMenuItem CreateObjectFromPage()
    {
        // check 
        DAMenuItem daMenuItem = new DAMenuItem();
        //
        daMenuItem.fMenuItem = fMenuItem.Value.Trim();
        daMenuItem.fParentID = Convert.ToInt32(fParentID.Value.Trim());
        daMenuItem.fUrl = fUrl.Value.Trim();
        daMenuItem.fUrlRewrite = fUrlRewrite.Value.Trim();
        daMenuItem.fMenuID = Convert.ToInt32(fMenuID.Value.Trim());
        daMenuItem.fPos = Convert.ToInt32(fPos.Value.Trim());
        daMenuItem.fActive = fActive.Checked;

        HttpPostedFile file = inputFile.PostedFile;

        if (file != null && file.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImg.ImageUrl, Server);
            daMenuItem.fImg = Utils.UploadImage(file, Server, "~/Media/MenuItem");
        }
        else
        {
            daMenuItem.fImg = fImg.ImageUrl.Replace("~", "");
        }
        fImg.ImageUrl = "~" + daMenuItem.fImg;
        daMenuItem.fCss = fCss.Value.Trim();

        //

        return daMenuItem;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAMenuItem daMenuItem = new DAMenuItem();
            daMenuItem.USP_MenuItem_GetFullID(this.KeyID);
            //
            fMenuItem.Value = daMenuItem.fMenuItem.ToString();
            fParentID.Value = daMenuItem.fParentID.ToString();
            fUrl.Value = daMenuItem.fUrl.ToString();
            fUrlRewrite.Value = daMenuItem.fUrlRewrite.ToString();
            fMenuID.Value = daMenuItem.fMenuID.ToString();
            fPos.Value = daMenuItem.fPos.ToString();
            fActive.Checked = daMenuItem.fActive;
            fImg.ImageUrl = "~" + daMenuItem.fImg.ToString();
            fCss.Value = daMenuItem.fCss.ToString();

            //

            // Khi cần enabled cột nào
            //if (this.KeyID > 0)
            //{
            //    if (mode != Act.Clone)
            //        fUserName.Enabled = false;
            //    else
            //        fUserName.Text = "";
            //}
        }
        catch (Exception e)
        {
            ShowErrorMes("Lỗi hệ thống: " + e.ToString());
            return false;
        }

        return true;
    }

    override protected int ExecInsert()
    {
        try
        {
            DAMenuItem DAMenuItem = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAMenuItem.fID = DAMenuItem.USP_GetKey();
                this.KeyID = DAMenuItem.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAMenuItem.fID = 0; }

            DAMenuItem.USP_MenuItem_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAMenuItem DAMenuItem = CreateObjectFromPage();
            DAMenuItem.fID = this.KeyID;

            DAMenuItem.USP_MenuItem_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAMenuItem DAMenuItem = new DAMenuItem();
            DAMenuItem.USP_MenuItem_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        //if (fUserName.Value.Trim() == "")
        //{
        //    ShowErrorMes("Bạn chưa nhập tài khoản!");
        //    fUserName.Focus();
        //    return false;
        //}
        //if (fPassWord.Value.Trim() == "")
        //{
        //    ShowErrorMes("Bạn chưa nhập mật khẩu!");
        //    fPassWord.Focus();
        //    return false;
        //}
        return true;
    }

    override protected Boolean CheckDuplicate()
    {
        //if (this.KeyID == 0)
        //{
        //    DACategory DACategory = new DACategory();
        //    if (DACategory.USP_Category_CheckDuplicate(fUserName.Value.Trim()) == 1)
        //    {
        //        ShowErrorMes("Tài khoản này đã tồn tại. Bạn nhập lại!");
        //        fUserName.Focus();
        //        return false;
        //    }
        //}
        return true;
    }
}