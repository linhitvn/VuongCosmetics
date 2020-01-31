using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using System.Web.Configuration;
using System.IO;

public partial class Pages_Article_cArticleAlter : TUserControlForAlter
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

    protected void fContent_Init(object sender, EventArgs e)
    {
        string uploadFolder = "~/Media/RadMedia";
        string uploadFolderMap = Server.MapPath(uploadFolder);
        DirectoryInfo ObjSearchDir = new DirectoryInfo(uploadFolderMap);

        if (!ObjSearchDir.Exists)
        {
            ObjSearchDir.Create();
        }

        // Image
        fContent.ImageManager.ViewPaths = new String[] { uploadFolder + "/Image" };
        fContent.ImageManager.DeletePaths = new String[] { uploadFolder + "/Image" };
        fContent.ImageManager.UploadPaths = new String[] { uploadFolder + "/Image" };

        // Media
        fContent.MediaManager.ViewPaths = new String[] { uploadFolder + "/Media" };
        fContent.MediaManager.DeletePaths = new String[] { uploadFolder + "/Media" };
        fContent.MediaManager.UploadPaths = new String[] { uploadFolder + "/Media" };

        // Flash
        fContent.FlashManager.ViewPaths = new String[] { uploadFolder + "/Flash" };
        fContent.FlashManager.DeletePaths = new String[] { uploadFolder + "/Flash" };
        fContent.FlashManager.UploadPaths = new String[] { uploadFolder + "/Flash" };

        // Document
        fContent.DocumentManager.ViewPaths = new String[] { uploadFolder + "/Document" };
        fContent.DocumentManager.DeletePaths = new String[] { uploadFolder + "/Document" };
        fContent.DocumentManager.UploadPaths = new String[] { uploadFolder + "/Document" };

        // Silverlight
        fContent.SilverlightManager.ViewPaths = new String[] { uploadFolder + "/Silverlight" };
        fContent.SilverlightManager.DeletePaths = new String[] { uploadFolder + "/Silverlight" };
        fContent.SilverlightManager.UploadPaths = new String[] { uploadFolder + "/Silverlight" };

        // Template
        fContent.TemplateManager.ViewPaths = new String[] { uploadFolder + "/Template" };
        fContent.TemplateManager.DeletePaths = new String[] { uploadFolder + "/Template" };
        fContent.TemplateManager.UploadPaths = new String[] { uploadFolder + "/Template" };
    }

    override protected Boolean GetDataComboBox()
    {
        try
        {
            DACategory daCategory = new DACategory();
            fCategoryID.DataSource = daCategory.USP_Category_GetDataForComboBox();
            fCategoryID.DataBind();

            DARecordStatus daRecordStatus = new DARecordStatus();
            fRecordStatusID.DataSource = daRecordStatus.USP_RecordStatus_GetComboBox_ByTableName("Article");
            fRecordStatusID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAArticle CreateObjectFromPage()
    {
        // check 
        DAArticle daArticle = new DAArticle();
        //
        daArticle.fCategoryID = Convert.ToInt32(fCategoryID.Value.Trim());
        daArticle.fTitle = fTitle.Value.Trim();
        daArticle.fTitleNosign = Utils.convertToUnSign2(fTitle.Value);
        daArticle.fDescription = fDescription.Value.Trim();
        daArticle.fContent = fContent.Content;
        daArticle.fUrlRewrite = fUrlRewrite.Value.Trim();
 
        HttpPostedFile file = inputFile.PostedFile;

        if (file != null && file.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink.ImageUrl, Server);
            daArticle.fImgLink = Utils.UploadImage(file, Server, "~/Media/Article");
        }
        else
        {
            daArticle.fImgLink = fImgLink.ImageUrl.Replace("~", "");
        }
        fImgLink.ImageUrl = "~" + daArticle.fImgLink;

        daArticle.fIsComment = fIsComment.Checked;
        daArticle.fNew = Convert.ToByte(fNew.Value.Trim());
        daArticle.fHot = Convert.ToByte(fHot.Value.Trim());
        daArticle.fViewNumber = Convert.ToInt32(fViewNumber.Value.Trim());
        daArticle.fRecordStatusID = Convert.ToInt32(fRecordStatusID.Value.Trim());
        daArticle.fPublishDate = Convert.ToDateTime(fPublishDate.SelectedDate);
        daArticle.fMetaTitle = fMetaTitle.Value.Trim();
        daArticle.fMetaDescription = fMetaDescription.Value.Trim();
        daArticle.fMetaKeywords = fMetaKeywords.Value.Trim();
        daArticle.fTags = fTags.Value.Trim();
        daArticle.fOperator = MySession.UserName;

        //

        return daArticle;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAArticle daArticle = new DAArticle();
            daArticle.USP_Article_GetFullID(this.KeyID);
            //
            fCategoryID.Value = daArticle.fCategoryID.ToString();
            fTitle.Value = daArticle.fTitle.ToString();
            fDescription.Value = daArticle.fDescription.ToString();
            fContent.Content = daArticle.fContent.ToString();
            fUrlRewrite.Value = daArticle.fUrlRewrite.ToString();
            fImgLink.ImageUrl = "~" + daArticle.fImgLink.ToString();
            fIsComment.Checked = daArticle.fIsComment;
            fNew.Value = daArticle.fNew.ToString();
            fHot.Value = daArticle.fHot.ToString();
            fViewNumber.Value = daArticle.fViewNumber.ToString();
            fRecordStatusID.Value = daArticle.fRecordStatusID.ToString();
            fPublishDate.SelectedDate = daArticle.fPublishDate;
            fMetaTitle.Value = daArticle.fMetaTitle.ToString();
            fMetaDescription.Value = daArticle.fMetaDescription.ToString();
            fMetaKeywords.Value = daArticle.fMetaKeywords.ToString();
            fTags.Value = daArticle.fTags.ToString();

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
            DAArticle DAArticle = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAArticle.fID = DAArticle.USP_GetKey();
                this.KeyID = DAArticle.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAArticle.fID = 0; }

            DAArticle.USP_Article_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAArticle DAArticle = CreateObjectFromPage();
            DAArticle.fID = this.KeyID;

            DAArticle.USP_Article_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAArticle DAArticle = new DAArticle();
            DAArticle.USP_Article_Delete(pID);
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