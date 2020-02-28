using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using NDL.Framework.MSSQL;

public class DAProductBase : TDatabase
{
    public Int32 fID;
    public String fProductName;
    public String fDescription;
    public String fProductCode;
    public String fUnitName;
    public Int32 fProducerID;
    public Int32 fPrice;
    public Int32 fSalePrice;
    public Int32 fSchSalePrice;
    public DateTime fScheSaleFrom;
    public DateTime fScheSaleTo;
    public Int32 fVATID;
    public String fThumbLink;
    public String fImgLink1;
    public String fImgLink2;
    public String fImgLink3;
    public String fImgLink4;
    public String fImgLink5;
    public Boolean fIsManagerQuantity;
    public Int32 fQuantity;
    public Int32 fNumSaled;
    public String fRewriteURL;
    public String fPageTitle;
    public String fMetaTitle;
    public String fMetaDescription;
    public String fMetaKeywords;
    public String fTags;
    public String fDesShort;
    public String fDesBeforPrice;
    public String fDesAfterPrice;
    public Boolean fIsNewProduct;
    public Boolean fIsHot;
    public Boolean fIsShow;
    public Boolean fIsHiddenWhenOutoff;
    public Boolean fIsShowYouSaving;
    public String fBuyButtonText;
    public Int32 fShowInProductTyleID;
    public Int32 fMinOrder;
    public Int32 fMaxForWarrning;
    public Int32 fBonusPoint;
    public Boolean fIsAllowComment;
    public Int32 fPos;
    public DateTime fSysDate;
    public String fOperator;
    public String fProductCats;
    public String fProductNosign;

    public DAProductBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Product";
        mKeyName = "ID";
    }
    public int USP_Product_Insert()
    {
        mCmd.CommandText = "USP_Product_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = fProductName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@ProductCode", SqlDbType.VarChar).Value = fProductCode;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = fUnitName;
        mCmd.Parameters.Add("@ProducerID", SqlDbType.Int).Value = fProducerID;
        mCmd.Parameters.Add("@Price", SqlDbType.Int).Value = fPrice;
        mCmd.Parameters.Add("@SalePrice", SqlDbType.Int).Value = fSalePrice;
        mCmd.Parameters.Add("@SchSalePrice", SqlDbType.Int).Value = fSchSalePrice;
        mCmd.Parameters.Add("@ScheSaleFrom", SqlDbType.DateTime).Value = fScheSaleFrom;
        mCmd.Parameters.Add("@ScheSaleTo", SqlDbType.DateTime).Value = fScheSaleTo;
        mCmd.Parameters.Add("@VATID", SqlDbType.Int).Value = fVATID;
        mCmd.Parameters.Add("@ThumbLink", SqlDbType.NVarChar).Value = "";
        mCmd.Parameters.Add("@ImgLink1", SqlDbType.NVarChar).Value = fImgLink1;
        mCmd.Parameters.Add("@ImgLink2", SqlDbType.NVarChar).Value = fImgLink2;
        mCmd.Parameters.Add("@ImgLink3", SqlDbType.NVarChar).Value = fImgLink3;
        mCmd.Parameters.Add("@ImgLink4", SqlDbType.NVarChar).Value = fImgLink4;
        mCmd.Parameters.Add("@ImgLink5", SqlDbType.NVarChar).Value = fImgLink5;
        mCmd.Parameters.Add("@IsManagerQuantity", SqlDbType.Bit).Value = fIsManagerQuantity;
        mCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = fQuantity;
        mCmd.Parameters.Add("@NumSaled", SqlDbType.Int).Value = fNumSaled;
        mCmd.Parameters.Add("@RewriteURL", SqlDbType.NVarChar).Value = fRewriteURL;
        mCmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar).Value = fPageTitle;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;
        mCmd.Parameters.Add("@DesShort", SqlDbType.NVarChar).Value = fDesShort;
        mCmd.Parameters.Add("@DesBeforPrice", SqlDbType.NVarChar).Value = fDesBeforPrice;
        mCmd.Parameters.Add("@DesAfterPrice", SqlDbType.NVarChar).Value = fDesAfterPrice;
        mCmd.Parameters.Add("@IsNewProduct", SqlDbType.Bit).Value = fIsNewProduct;
        mCmd.Parameters.Add("@IsHot", SqlDbType.Bit).Value = fIsHot;
        mCmd.Parameters.Add("@IsShow", SqlDbType.Bit).Value = fIsShow;
        mCmd.Parameters.Add("@IsHiddenWhenOutoff", SqlDbType.Bit).Value = fIsHiddenWhenOutoff;
        mCmd.Parameters.Add("@IsShowYouSaving", SqlDbType.Bit).Value = fIsShowYouSaving;
        mCmd.Parameters.Add("@BuyButtonText", SqlDbType.NVarChar).Value = fBuyButtonText;
        mCmd.Parameters.Add("@ShowInProductTyleID", SqlDbType.Int).Value = fShowInProductTyleID;
        mCmd.Parameters.Add("@MinOrder", SqlDbType.Int).Value = fMinOrder;
        mCmd.Parameters.Add("@MaxForWarrning", SqlDbType.Int).Value = fMaxForWarrning;
        mCmd.Parameters.Add("@BonusPoint", SqlDbType.Int).Value = fBonusPoint;
        mCmd.Parameters.Add("@IsAllowComment", SqlDbType.Bit).Value = fIsAllowComment;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;
        mCmd.Parameters.Add("@ProductNosign", SqlDbType.VarChar).Value = fProductNosign;

        return Execute();
    }
    public int USP_Product_Update()
    {
        mCmd.CommandText = "USP_Product_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = fProductName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@ProductCode", SqlDbType.VarChar).Value = fProductCode;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = fUnitName;
        mCmd.Parameters.Add("@ProducerID", SqlDbType.Int).Value = fProducerID;
        mCmd.Parameters.Add("@Price", SqlDbType.Int).Value = fPrice;
        mCmd.Parameters.Add("@SalePrice", SqlDbType.Int).Value = fSalePrice;
        mCmd.Parameters.Add("@SchSalePrice", SqlDbType.Int).Value = fSchSalePrice;
        mCmd.Parameters.Add("@ScheSaleFrom", SqlDbType.DateTime).Value = fScheSaleFrom;
        mCmd.Parameters.Add("@ScheSaleTo", SqlDbType.DateTime).Value = fScheSaleTo;
        mCmd.Parameters.Add("@VATID", SqlDbType.Int).Value = fVATID;
        mCmd.Parameters.Add("@ThumbLink", SqlDbType.NVarChar).Value = "";
        mCmd.Parameters.Add("@ImgLink1", SqlDbType.NVarChar).Value = fImgLink1;
        mCmd.Parameters.Add("@ImgLink2", SqlDbType.NVarChar).Value = fImgLink2;
        mCmd.Parameters.Add("@ImgLink3", SqlDbType.NVarChar).Value = fImgLink3;
        mCmd.Parameters.Add("@ImgLink4", SqlDbType.NVarChar).Value = fImgLink4;
        mCmd.Parameters.Add("@ImgLink5", SqlDbType.NVarChar).Value = fImgLink5;
        mCmd.Parameters.Add("@IsManagerQuantity", SqlDbType.Bit).Value = fIsManagerQuantity;
        mCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = fQuantity;
        mCmd.Parameters.Add("@NumSaled", SqlDbType.Int).Value = fNumSaled;
        mCmd.Parameters.Add("@RewriteURL", SqlDbType.NVarChar).Value = fRewriteURL;
        mCmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar).Value = fPageTitle;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;
        mCmd.Parameters.Add("@DesShort", SqlDbType.NVarChar).Value = fDesShort;
        mCmd.Parameters.Add("@DesBeforPrice", SqlDbType.NVarChar).Value = fDesBeforPrice;
        mCmd.Parameters.Add("@DesAfterPrice", SqlDbType.NVarChar).Value = fDesAfterPrice;
        mCmd.Parameters.Add("@IsNewProduct", SqlDbType.Bit).Value = fIsNewProduct;
        mCmd.Parameters.Add("@IsHot", SqlDbType.Bit).Value = fIsHot;
        mCmd.Parameters.Add("@IsShow", SqlDbType.Bit).Value = fIsShow;
        mCmd.Parameters.Add("@IsHiddenWhenOutoff", SqlDbType.Bit).Value = fIsHiddenWhenOutoff;
        mCmd.Parameters.Add("@IsShowYouSaving", SqlDbType.Bit).Value = fIsShowYouSaving;
        mCmd.Parameters.Add("@BuyButtonText", SqlDbType.NVarChar).Value = fBuyButtonText;
        mCmd.Parameters.Add("@ShowInProductTyleID", SqlDbType.Int).Value = fShowInProductTyleID;
        mCmd.Parameters.Add("@MinOrder", SqlDbType.Int).Value = fMinOrder;
        mCmd.Parameters.Add("@MaxForWarrning", SqlDbType.Int).Value = fMaxForWarrning;
        mCmd.Parameters.Add("@BonusPoint", SqlDbType.Int).Value = fBonusPoint;
        mCmd.Parameters.Add("@IsAllowComment", SqlDbType.Bit).Value = fIsAllowComment;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;
        mCmd.Parameters.Add("@ProductNosign", SqlDbType.VarChar).Value = fProductNosign;

        return Execute();
    }

    public int USP_Product_Delete(int ID)
    {
        mCmd.CommandText = "USP_Product_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Product_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Product_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Product_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Product_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Product_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Product_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Product_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Product_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Product_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Product_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Product_Fetch()
    {
        return 0;
    }
    public bool USP_Product_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Product_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fProductName = mDataReader["ProductName"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fProductCode = mDataReader["ProductCode"].ToString();
            fUnitName = mDataReader["UnitName"].ToString();
            fProducerID = Convert.ToInt32(mDataReader["ProducerID"]);
            fPrice = Convert.ToInt32(mDataReader["Price"]);
            fSalePrice = Convert.ToInt32(mDataReader["SalePrice"]);
            fSchSalePrice = Convert.ToInt32(mDataReader["SchSalePrice"]);
            fScheSaleFrom = Convert.ToDateTime(mDataReader["ScheSaleFrom"]);
            fScheSaleTo = Convert.ToDateTime(mDataReader["ScheSaleTo"]);
            fVATID = Convert.ToInt32(mDataReader["VATID"]);
            fThumbLink = mDataReader["ThumbLink"].ToString();
            fImgLink1 = mDataReader["ImgLink1"].ToString();
            fImgLink2 = mDataReader["ImgLink2"].ToString();
            fImgLink3 = mDataReader["ImgLink3"].ToString();
            fImgLink4 = mDataReader["ImgLink4"].ToString();
            fImgLink5 = mDataReader["ImgLink5"].ToString();
            fIsManagerQuantity = Convert.ToBoolean(mDataReader["IsManagerQuantity"]);
            fQuantity = Convert.ToInt32(mDataReader["Quantity"]);
            fNumSaled = Convert.ToInt32(mDataReader["NumSaled"]);
            fRewriteURL = mDataReader["RewriteURL"].ToString();
            fPageTitle = mDataReader["PageTitle"].ToString();
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();
            fDesShort = mDataReader["DesShort"].ToString();
            fDesBeforPrice = mDataReader["DesBeforPrice"].ToString();
            fDesAfterPrice = mDataReader["DesAfterPrice"].ToString();
            fIsNewProduct = Convert.ToBoolean(mDataReader["IsNewProduct"]);
            fIsHot = Convert.ToBoolean(mDataReader["IsHot"]);
            fIsShow = Convert.ToBoolean(mDataReader["IsShow"]);
            fIsHiddenWhenOutoff = Convert.ToBoolean(mDataReader["IsHiddenWhenOutoff"]);
            fIsShowYouSaving = Convert.ToBoolean(mDataReader["IsShowYouSaving"]);
            fBuyButtonText = mDataReader["BuyButtonText"].ToString();
            fShowInProductTyleID = Convert.ToInt32(mDataReader["ShowInProductTyleID"]);
            fMinOrder = Convert.ToInt32(mDataReader["MinOrder"]);
            fMaxForWarrning = Convert.ToInt32(mDataReader["MaxForWarrning"]);
            fBonusPoint = Convert.ToInt32(mDataReader["BonusPoint"]);
            fIsAllowComment = Convert.ToBoolean(mDataReader["IsAllowComment"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);
            fOperator = mDataReader["Operator"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Product_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Product_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Product_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Product_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Product_CheckDuplicate(string ProductName)
    {
        mCmd.CommandText = "USP_Product_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = ProductName;
        //ExecuteReader();
        return Execute();
    }

    public int USP_NewKey()
    {
        fID = USP_GetKey();
        return fID;
    }

    public bool Fetch_Reader(bool bClose)
    {
        if (mDataReader.IsClosed)
            return false;
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fProductName = mDataReader["ProductName"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fProductCode = mDataReader["ProductCode"].ToString();
            fUnitName = mDataReader["UnitName"].ToString();
            fProducerID = Convert.ToInt32(mDataReader["ProducerID"]);
            fPrice = Convert.ToInt32(mDataReader["Price"]);
            fSalePrice = Convert.ToInt32(mDataReader["SalePrice"]);
            fSchSalePrice = Convert.ToInt32(mDataReader["SchSalePrice"]);
            fScheSaleFrom = Convert.ToDateTime(mDataReader["ScheSaleFrom"]);
            fScheSaleTo = Convert.ToDateTime(mDataReader["ScheSaleTo"]);
            fVATID = Convert.ToInt32(mDataReader["VATID"]);
            fThumbLink = mDataReader["ThumbLink"].ToString();
            fImgLink1 = mDataReader["ImgLink1"].ToString();
            fIsManagerQuantity = Convert.ToBoolean(mDataReader["IsManagerQuantity"]);
            fQuantity = Convert.ToInt32(mDataReader["Quantity"]);
            fNumSaled = Convert.ToInt32(mDataReader["NumSaled"]);
            fRewriteURL = mDataReader["RewriteURL"].ToString();
            fPageTitle = mDataReader["PageTitle"].ToString();
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();
            fDesShort = mDataReader["DesShort"].ToString();
            fDesBeforPrice = mDataReader["DesBeforPrice"].ToString();
            fDesAfterPrice = mDataReader["DesAfterPrice"].ToString();
            fIsNewProduct = Convert.ToBoolean(mDataReader["IsNewProduct"]);
            fIsHot = Convert.ToBoolean(mDataReader["IsHot"]);
            fIsShow = Convert.ToBoolean(mDataReader["IsShow"]);
            fIsHiddenWhenOutoff = Convert.ToBoolean(mDataReader["IsHiddenWhenOutoff"]);
            fIsShowYouSaving = Convert.ToBoolean(mDataReader["IsShowYouSaving"]);
            fBuyButtonText = mDataReader["BuyButtonText"].ToString();
            fShowInProductTyleID = Convert.ToInt32(mDataReader["ShowInProductTyleID"]);
            fMinOrder = Convert.ToInt32(mDataReader["MinOrder"]);
            fMaxForWarrning = Convert.ToInt32(mDataReader["MaxForWarrning"]);
            fBonusPoint = Convert.ToInt32(mDataReader["BonusPoint"]);
            fIsAllowComment = Convert.ToBoolean(mDataReader["IsAllowComment"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);
            fOperator = mDataReader["Operator"].ToString();

            return true;
        }
        else
            if (bClose)
            {
                mDataReader.Close();
            }
        return false;
    }

    public bool U_Fetch_Reader(bool bClose)
    {
        return Fetch_Reader(bClose);
    }

    public bool U_Fetch_Reader()
    {
        return Fetch_Reader(true);
    }

}
public partial class DAProduct : DAProductBase
{
    public SqlDataReader USP_Product_SearchByName(string ProductName = "")
    {
        mCmd.CommandText = "USP_Product_SearchByName";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = ProductName;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Product_Search(string productCN, int productCatID)
    {
        mCmd.CommandText = "USP_Product_Search";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductCN", SqlDbType.NVarChar).Value = productCN;
        mCmd.Parameters.Add("@ProductCatID", SqlDbType.Int).Value = productCatID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }
}
