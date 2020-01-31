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

public class DAProductCatBase : TDatabase
{
    public Int32 fID;
    public String fProductCat;
    public Int32 fParentID;
    public String fDescription;
    public String fIconLink;
    public Int32 fPos;
    public String fMetaTitle;
    public String fMetaDescription;
    public String fMetaKeywords;
    public String fTags;

    public DAProductCatBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "ProductCat";
        mKeyName = "ID";
    }
    public int USP_ProductCat_Insert()
    {
        mCmd.CommandText = "USP_ProductCat_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductCat", SqlDbType.NVarChar).Value = fProductCat;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@IconLink", SqlDbType.NVarChar).Value = fIconLink;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;

        return Execute();
    }
    public int USP_ProductCat_Insert(Int32 ID, String ProductCat, Int32 ParentID, String Description, String IconLink, Int32 Pos, String MetaTitle, String MetaDescription, String MetaKeywords, String Tags)
    {
        mCmd.CommandText = "USP_ProductCat_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProductCat", SqlDbType.NVarChar).Value = ProductCat;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@IconLink", SqlDbType.NVarChar).Value = IconLink;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = Tags;

        return Execute();
    }

    public int USP_ProductCat_Update()
    {
        mCmd.CommandText = "USP_ProductCat_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductCat", SqlDbType.NVarChar).Value = fProductCat;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@IconLink", SqlDbType.NVarChar).Value = fIconLink;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;

        return Execute();
    }
    public int USP_ProductCat_Update(Int32 ID, String ProductCat, Int32 ParentID, String Description, String IconLink, Int32 Pos, String MetaTitle, String MetaDescription, String MetaKeywords, String Tags)
    {
        mCmd.CommandText = "USP_ProductCat_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProductCat", SqlDbType.NVarChar).Value = ProductCat;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@IconLink", SqlDbType.NVarChar).Value = IconLink;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = Tags;

        return Execute();
    }

    public int USP_ProductCat_Delete(int ID)
    {
        mCmd.CommandText = "USP_ProductCat_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_ProductCat_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_ProductCat_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_ProductCat_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ProductCat_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ProductCat_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ProductCat_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_ProductCat_GetByID(int ID)
    {
        mCmd.CommandText = "USP_ProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_ProductCat_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_ProductCat_Fetch()
    {
        return 0;
    }
    public bool USP_ProductCat_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_ProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fProductCat = mDataReader["ProductCat"].ToString();
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fDescription = mDataReader["Description"].ToString();
            fIconLink = mDataReader["IconLink"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_ProductCat_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ProductCat_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_ProductCat_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_ProductCat_CheckDuplicate(string ProductCat)
    {
        mCmd.CommandText = "USP_ProductCat_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductCat", SqlDbType.VarChar).Value = ProductCat;
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
            fProductCat = mDataReader["ProductCat"].ToString();
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fDescription = mDataReader["Description"].ToString();
            fIconLink = mDataReader["IconLink"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();

            return true;
        }
        else
            if (bClose)
            {
                mDataReader.Close();
            }
        return false;
    }

    public List<DAProductCat> USP_ProductCat_GetList(int First, int Count)
    {
        SqlDataReader reader = USP_ProductCat_GetAll_Reader(First, Count);
        List<DAProductCat> productCats = new List<DAProductCat>();
        while (reader.Read())
        {
            productCats.Add(new DAProductCat()
            {
                fID = Convert.ToInt32(reader["ID"]),
                fProductCat = reader["ProductCat"].ToString(),
                fParentID = Convert.ToInt32(reader["ParentID"]),
                fDescription = reader["Description"].ToString(),
                fIconLink = reader["IconLink"].ToString(),
                fPos = Convert.ToInt32(reader["Pos"]),
                fMetaTitle = reader["MetaTitle"].ToString(),
                fMetaDescription = reader["MetaDescription"].ToString(),
                fMetaKeywords = reader["MetaKeywords"].ToString(),
                fTags = reader["Tags"].ToString()
            });
        }
        return productCats;
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
public partial class DAProductCat : DAProductCatBase
{
    public DataSet USP_ProductCat_GetBelongProductID(int ProductID)
    {
        mCmd.CommandText = "USP_ProductCat_GetBelongProductID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public DataSet USP_ProductCat_GetBelongDiscountID(int DiscountID)
    {
        mCmd.CommandText = "USP_ProductCat_GetBelongDiscountID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@DiscountID", SqlDbType.Int).Value = DiscountID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }
    public DataSet USP_ProductCat_GetForTree()
    {
        mCmd.CommandText = "USP_ProductCat_GetForTree";
        mCmd.Parameters.Clear();
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public int USP_ProductCat_UpdateSEO()
    {
        mCmd.CommandText = "USP_ProductCat_UpdateSEO";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;

        return Execute();
    }
}
