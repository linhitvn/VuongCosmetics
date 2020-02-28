using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using Telerik.Web.UI;
using System.IO;

public partial class Pages_Product_cProductAlter : TUserControlForAlter
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
            DAProducer daProducer = new DAProducer();
            fProducerID.DataSource = daProducer.USP_Producer_GetDataForComboBox();
            fProducerID.DataBind();

            DAVAT daVAT = new DAVAT();
            fVATID.DataSource = daVAT.USP_VAT_GetDataForComboBox();
            fVATID.DataBind();



            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAProduct CreateObjectFromPage()
    {
        // check 
        DAProduct daProduct = new DAProduct();
        daProduct.USP_Product_GetFullID(this.KeyID);
        //
        daProduct.fProductName = fProductName.Value.Trim();
        daProduct.fProductNosign = Utils.convertToUnSign2(fProductName.Value);
        daProduct.fDescription = fDescription.Content.Trim();
        daProduct.fProductCode = fProductCode.Value.Trim();
        daProduct.fUnitName = fUnitName.Value.Trim();
        daProduct.fProducerID = Convert.ToInt32(fProducerID.Value.Trim());
        daProduct.fPrice = Convert.ToInt32(fPrice.Value.Trim());
        daProduct.fSalePrice = Convert.ToInt32(fSalePrice.Value.Trim());
        daProduct.fSchSalePrice = Convert.ToInt32(fSchSalePrice.Value.Trim());
        daProduct.fScheSaleFrom = Convert.ToDateTime(fScheSaleFrom.SelectedDate);
        daProduct.fScheSaleTo = Convert.ToDateTime(fScheSaleTo.SelectedDate);
        daProduct.fVATID = Convert.ToInt32(fVATID.Value.Trim());
        //daProduct.fThumbLink = fThumbLink.ImageUrl;
        //daProduct.fImgLink1 = fImage1.;
        //daProduct.fImgLink2 = fImage2.ImageUrl;
        //daProduct.fImgLink3 = fImage3.ImageUrl;
        //daProduct.fImgLink4 = fImage4.ImageUrl;
        //daProduct.fImgLink5 = fImage5.ImageUrl;


        //uploadImages(ref daProduct);

        // Image 1
        HttpPostedFile fileImg1 = inputFileImg1.PostedFile;

        if (fileImg1 != null && fileImg1.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink1.ImageUrl, Server);
            daProduct.fImgLink1 = Utils.UploadImage(fileImg1, Server, "~/Media/Product");
        }
        else
        {
            daProduct.fImgLink1 = fImgLink1.ImageUrl.Replace("~", "");
        }
        fImgLink1.ImageUrl = "~" + daProduct.fImgLink1;

        // End
        

        // Image 2
        HttpPostedFile fileImg2 = inputFileImg2.PostedFile;

        if (fileImg2 != null && fileImg2.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink2.ImageUrl, Server);
            daProduct.fImgLink2 = Utils.UploadImage(fileImg2, Server, "~/Media/Product");
        }
        else
        {
            daProduct.fImgLink2 = fImgLink2.ImageUrl.Replace("~", "");
        }
        fImgLink2.ImageUrl = "~" + daProduct.fImgLink2;
        // End


        // Image 3
        HttpPostedFile fileImg3 = inputFileImg3.PostedFile;

        if (fileImg3 != null && fileImg3.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink3.ImageUrl, Server);
            daProduct.fImgLink3 = Utils.UploadImage(fileImg3, Server, "~/Media/Product");
        }
        else
        {
            daProduct.fImgLink3 = fImgLink3.ImageUrl.Replace("~", "");
        }
        fImgLink3.ImageUrl = "~" + daProduct.fImgLink3;
        // End

        //End

        // Image 4
        HttpPostedFile fileImg4 = inputFileImg4.PostedFile;

        if (fileImg4 != null && fileImg4.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink4.ImageUrl, Server);
            daProduct.fImgLink4 = Utils.UploadImage(fileImg4, Server,"~/Media/Product");
        }
        else
        {
            daProduct.fImgLink4 = fImgLink4.ImageUrl.Replace("~", "");
        }
        fImgLink4.ImageUrl = "~" + daProduct.fImgLink4;
        // End
        

        // Image 5
        // Image 3
        HttpPostedFile fileImg5 = inputFileImg5.PostedFile;

        if (fileImg5 != null && fileImg5.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink5.ImageUrl, Server);
            daProduct.fImgLink5 = Utils.UploadImage(fileImg5, Server, "~/Media/Product");
        }
        else
        {
            daProduct.fImgLink5 = fImgLink5.ImageUrl.Replace("~", "");
        }
        fImgLink5.ImageUrl = "~" + daProduct.fImgLink5;
        // End
        // End


        daProduct.fIsManagerQuantity = fIsManagerQuantity.Checked;
        daProduct.fQuantity = Convert.ToInt32(fQuantity.Value.Trim());
        daProduct.fNumSaled = Convert.ToInt32(fNumSaled.Value.Trim());
        daProduct.fRewriteURL = fRewriteURL.Value.Trim();
        daProduct.fPageTitle = fPageTitle.Value.Trim();
        daProduct.fMetaTitle = fMetaTitle.Value.Trim();
        daProduct.fMetaDescription = fMetaDescription.Value.Trim();
        daProduct.fMetaKeywords = fMetaKeywords.Value.Trim();
        daProduct.fTags = fTags.Value.Trim();
        daProduct.fDesShort = fDesShort.Value.Trim();
        daProduct.fDesBeforPrice = fDesBeforPrice.Value.Trim();
        daProduct.fDesAfterPrice = fDesAfterPrice.Value.Trim();
        daProduct.fIsNewProduct = fIsNewProduct.Checked;
        daProduct.fIsHot = fIsHot.Checked;
        daProduct.fIsShow = fIsShow.Checked;
        daProduct.fIsHiddenWhenOutoff = fIsHiddenWhenOutoff.Checked;
        daProduct.fIsShowYouSaving = fIsShowYouSaving.Checked;
        daProduct.fBuyButtonText = fBuyButtonText.Value.Trim();
        daProduct.fShowInProductTyleID = Convert.ToInt32(fShowInProductTyleID.Value.Trim());
        daProduct.fMinOrder = Convert.ToInt32(fMinOrder.Value.Trim());
        daProduct.fMaxForWarrning = Convert.ToInt32(fMaxForWarrning.Value.Trim());
        daProduct.fBonusPoint = Convert.ToInt32(fBonusPoint.Value.Trim());
        daProduct.fIsAllowComment = fIsAllowComment.Checked;
        daProduct.fPos = Convert.ToInt32(fPos.Value.Trim());
        daProduct.fOperator = MySession.UserName;

        //

        return daProduct;
    }

    private void LoadCategory()
    {
        DAProductCat daProductCat = new DAProductCat();
        RadTreeView1.DataSource = daProductCat.USP_ProductCat_GetBelongProductID(this.KeyID);
        RadTreeView1.DataBind();
    }

    override protected Boolean LoadData()
    {
        try
        {
            LoadCategory();

            // Load Data For Page.
            DAProduct daProduct = new DAProduct();
            daProduct.USP_Product_GetFullID(this.KeyID);
            //
            fProductName.Value = daProduct.fProductName.ToString();
            fDescription.Content = daProduct.fDescription.ToString();
            fProductCode.Value = daProduct.fProductCode.ToString();
            fUnitName.Value = daProduct.fUnitName.ToString();
            fProducerID.Value = daProduct.fProducerID.ToString();
            fPrice.Value = daProduct.fPrice.ToString();
            fSalePrice.Value = daProduct.fSalePrice.ToString();
            fSchSalePrice.Value = daProduct.fSchSalePrice.ToString();
            fScheSaleFrom.SelectedDate = daProduct.fScheSaleFrom;
            fScheSaleTo.SelectedDate = daProduct.fScheSaleTo;
            fVATID.Value = daProduct.fVATID.ToString();

            fImgLink1.ImageUrl = "~" + daProduct.fImgLink1;
            fImgLink2.ImageUrl = "~" + daProduct.fImgLink2;
            fImgLink3.ImageUrl = "~" + daProduct.fImgLink3;
            fImgLink4.ImageUrl = "~" + daProduct.fImgLink4;
            fImgLink5.ImageUrl = "~" + daProduct.fImgLink5;

            //fImage1.Src = daProduct.fImgLink1 == String.Empty ? String.Empty : "~" + daProduct.fImgLink1;
            //fImage2.Src = daProduct.fImgLink2 == String.Empty ? String.Empty : "~" + daProduct.fImgLink2;
            //fImage3.Src = daProduct.fImgLink3 == String.Empty ? String.Empty : "~" + daProduct.fImgLink3;
            //fImage4.Src = daProduct.fImgLink4 == String.Empty ? String.Empty : "~" + daProduct.fImgLink4;
            //fImage5.Src = daProduct.fImgLink5 == String.Empty ? String.Empty : "~" + daProduct.fImgLink5;
            
            fIsManagerQuantity.Checked = daProduct.fIsManagerQuantity;
            fQuantity.Value = daProduct.fQuantity.ToString();
            fNumSaled.Value = daProduct.fNumSaled.ToString();
            fRewriteURL.Value = daProduct.fRewriteURL.ToString();
            fPageTitle.Value = daProduct.fPageTitle.ToString();
            fMetaTitle.Value = daProduct.fMetaTitle.ToString();
            fMetaDescription.Value = daProduct.fMetaDescription.ToString();
            fMetaKeywords.Value = daProduct.fMetaKeywords.ToString();
            fTags.Value = daProduct.fTags.ToString();
            fDesShort.Value = daProduct.fDesShort.ToString();
            fDesBeforPrice.Value = daProduct.fDesBeforPrice.ToString();
            fDesAfterPrice.Value = daProduct.fDesAfterPrice.ToString();
            fIsNewProduct.Checked = daProduct.fIsNewProduct;
            fIsHot.Checked = daProduct.fIsHot;
            fIsShow.Checked = daProduct.fIsShow;
            fIsHiddenWhenOutoff.Checked = daProduct.fIsHiddenWhenOutoff;
            fIsShowYouSaving.Checked = daProduct.fIsShowYouSaving;
            fBuyButtonText.Value = daProduct.fBuyButtonText.ToString();
            fShowInProductTyleID.Value = daProduct.fShowInProductTyleID.ToString();
            fMinOrder.Value = daProduct.fMinOrder.ToString();
            fMaxForWarrning.Value = daProduct.fMaxForWarrning.ToString();
            fBonusPoint.Value = daProduct.fBonusPoint.ToString();
            fIsAllowComment.Checked = daProduct.fIsAllowComment;
            fPos.Value = daProduct.fPos.ToString();
            fSysDate.SelectedDate = daProduct.fSysDate;

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
            DAProduct DAProduct = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAProduct.fID = DAProduct.USP_GetKey();
                this.KeyID = DAProduct.fID; // --> Update new SessionID for continue edit.

            }
            else
            { DAProduct.fID = 0; }

            DAProduct.USP_Product_Insert();
            return UpdateCategory() == true ? 1 : -1;
        }
        catch(Exception ex) { return 0; }
    }

    override protected int ExecUpdate()
    {
        DAProduct DAProduct = CreateObjectFromPage();
        // Update with ID = this.ID       
        try
        {
            
            DAProduct.fID = this.KeyID;

            DAProduct.USP_Product_Update();
            return UpdateCategory() == true ? 1 : -1;

        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAProduct DAProduct = new DAProduct();
            DAProduct.USP_Product_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        
        if (fProductName.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập tên sản phẩm!");
            fProductName.Focus();
            return false;
        }
        if (fProductCode.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa mã sản phầm!");
            fProductCode.Focus();
            return false;
        }
        // category
        IList<RadTreeNode> nodeCollection = RadTreeView1.CheckedNodes;
        if(nodeCollection.Count ==0)
        {
            ShowErrorMes("Bạn chưa chọn danh mục sản phẩm!");
            return false;
        }
        // Vat
        if (fVATID.Value.Trim() == "0")
        {
            ShowErrorMes("Bạn chưa chọn thuế VAT!");
            return false;
        }
        // content
        if (fDescription.Content.Trim() == "")
        {
            ShowErrorMes("Bạn chưa chọn nhập nội dung!");
            return false;
        }
        //if (fImgLink1.ImageUrl.Trim() == String.Empty || fImgLink1.ImageUrl.Trim() == "~")
        //{
        //    ShowErrorMes("Bạn chưa chọn hình đại diện!");
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

    private Boolean UpdateCategory()
    {
        try
        {
            String IDListProductCatID = ",";
            DAProductProductCat daProductProductCat = new DAProductProductCat();
            IList<RadTreeNode> nodeCollection = RadTreeView1.CheckedNodes;
            foreach (RadTreeNode node in nodeCollection)
            {
                IDListProductCatID += node.Value + ",";
            }
            daProductProductCat.USP_ProductProductCat_UpdateCustom(this.KeyID, IDListProductCatID);
            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.ToString());
            return false;
        }
    }


    //private void uploadImages(ref DAProduct daProduct)
    //{
    //    HttpFileCollection uploadFilCol = Request.Files;
    //    int index = 0;
    //    for (int i = 0; i < 5; i++)
    //    {
    //        string fileName = String.Empty;
    //        while (index < uploadFilCol.Count)
    //        {
    //            HttpPostedFile file = uploadFilCol[index];
    //            fileName = Utils.UploadImage(file, Server);
    //            index++;
    //            if (fileName != String.Empty)
    //            {
    //                break;
    //            }

    //        }
    //        if (("/" + hidenInput1.Value) == daProduct.fImgLink1 && i == 0)
    //        {
    //            i++;
    //        }
    //        if (("/" + hidenInput2.Value) == daProduct.fImgLink2 && i == 1)
    //        {
    //            i++;
    //        }
    //        if (("/" + hidenInput3.Value) == daProduct.fImgLink3 && i == 2)
    //        {
    //            i++;
    //        }
    //        if (("/" + hidenInput4.Value) == daProduct.fImgLink4 && i == 3)
    //        {
    //            i++;
    //        }
    //        if (("/" + hidenInput5.Value) == daProduct.fImgLink5 && i == 4)
    //        {
    //            i++;
    //        }
    //        switch (i)
    //        {
    //            case 0:
    //                daProduct.fImgLink1 = fileName;
    //                //Delete old file
    //                //Utils.DeleteFile(fImage1.Src, Server);
    //                fImage1.Src = daProduct.fImgLink1 == String.Empty ? String.Empty : "~" + daProduct.fImgLink1;
    //                daProduct.fThumbLink = Utils.createThumbnail(fileName, Server);
    //                break;
    //            case 1:
    //                daProduct.fImgLink2 = fileName;
    //                //Delete old file
    //                //Utils.DeleteFile(fImage2.Src, Server);
    //                fImage2.Src = daProduct.fImgLink2 == String.Empty ? String.Empty : "~" + daProduct.fImgLink2;
    //                break;
    //            case 2:
    //                daProduct.fImgLink3 = fileName;
    //                //Delete old file
    //                //Utils.DeleteFile(fImage3.Src, Server);
    //                fImage3.Src = daProduct.fImgLink3 == String.Empty ? String.Empty : "~" + daProduct.fImgLink3;
    //                break;
    //            case 3:
    //                daProduct.fImgLink4 = fileName;
    //                //Delete old file
    //                //Utils.DeleteFile(fImage4.Src, Server);
    //                fImage4.Src = daProduct.fImgLink4 == String.Empty ? String.Empty : "~" + daProduct.fImgLink4;
    //                break;
    //            case 4:
    //                daProduct.fImgLink5 = fileName;
    //                //Delete old file
    //                //Utils.DeleteFile(fImage5.Src, Server);
    //                fImage5.Src = daProduct.fImgLink5 == String.Empty ? String.Empty : "~" + daProduct.fImgLink5;
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}
    ////27/01
    //protected void Button1_Click(object sender, System.EventArgs e)
    //{
    //    if (fImage1.ImageUrl == string.Empty)
    //    {
    //        Utils.UploadImage(fImage1, RadAsyncUpload1, Server, true);
    //        // save thumb link
    //        fThumbLink.ImageUrl = fImage1.ImageUrl.Replace("Images","Images/thumb"); 
    //    }
    //    else if (fImage2.ImageUrl == string.Empty)
    //    {
    //        Utils.UploadImage(fImage2, RadAsyncUpload1, Server);
    //    }
    //    else if (fImage3.ImageUrl == string.Empty)
    //    {
    //        Utils.UploadImage(fImage3, RadAsyncUpload1, Server);
    //    }
    //    else if (fImage4.ImageUrl == string.Empty)
    //    {
    //        Utils.UploadImage(fImage4, RadAsyncUpload1, Server);
    //    }
    //    else if (fImage5.ImageUrl == string.Empty)
    //    {
    //        Utils.UploadImage(fImage5, RadAsyncUpload1, Server);
    //    }


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
        fDescription.ImageManager.ViewPaths = new String[] { uploadFolder + "/Image" };
        fDescription.ImageManager.DeletePaths = new String[] { uploadFolder + "/Image" };
        fDescription.ImageManager.UploadPaths = new String[] { uploadFolder + "/Image" };

        // Media
        fDescription.MediaManager.ViewPaths = new String[] { uploadFolder + "/Media" };
        fDescription.MediaManager.DeletePaths = new String[] { uploadFolder + "/Media" };
        fDescription.MediaManager.UploadPaths = new String[] { uploadFolder + "/Media" };

        // Flash
        fDescription.FlashManager.ViewPaths = new String[] { uploadFolder + "/Flash" };
        fDescription.FlashManager.DeletePaths = new String[] { uploadFolder + "/Flash" };
        fDescription.FlashManager.UploadPaths = new String[] { uploadFolder + "/Flash" };

        // Document
        fDescription.DocumentManager.ViewPaths = new String[] { uploadFolder + "/Document" };
        fDescription.DocumentManager.DeletePaths = new String[] { uploadFolder + "/Document" };
        fDescription.DocumentManager.UploadPaths = new String[] { uploadFolder + "/Document" };

        // Silverlight
        fDescription.SilverlightManager.ViewPaths = new String[] { uploadFolder + "/Silverlight" };
        fDescription.SilverlightManager.DeletePaths = new String[] { uploadFolder + "/Silverlight" };
        fDescription.SilverlightManager.UploadPaths = new String[] { uploadFolder + "/Silverlight" };

        // Template
        fDescription.TemplateManager.ViewPaths = new String[] { uploadFolder + "/Template" };
        fDescription.TemplateManager.DeletePaths = new String[] { uploadFolder + "/Template" };
        fDescription.TemplateManager.UploadPaths = new String[] { uploadFolder + "/Template" };
    }



}