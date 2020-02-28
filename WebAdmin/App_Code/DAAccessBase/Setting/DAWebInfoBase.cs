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

public class DAWebInfoBase : TDatabase
{
    public Int32 fID;
    public String fWebsiteName;
    public String fSeoDescription;
    public String fSeoTitle;
    public String fSeoKeyword;
    public String fEmail;
    public DateTime fCreateDate;
    public String fGoogleMap;
    public String fDescription;
    public String fLat;
    public String fLng;

    public DAWebInfoBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "WebInfo";
        mKeyName = "ID";
    }
    public int USP_WebInfo_Insert()
    {
        mCmd.CommandText = "USP_WebInfo_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@WebsiteName", SqlDbType.NVarChar).Value = fWebsiteName;
        mCmd.Parameters.Add("@SeoDescription", SqlDbType.NVarChar).Value = fSeoDescription;
        mCmd.Parameters.Add("@SeoTitle", SqlDbType.NVarChar).Value = fSeoTitle;
        mCmd.Parameters.Add("@SeoKeyword", SqlDbType.NVarChar).Value = fSeoKeyword;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fCreateDate;
        mCmd.Parameters.Add("@GoogleMap", SqlDbType.NText).Value = fGoogleMap;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Lat", SqlDbType.VarChar).Value = fLat;
        mCmd.Parameters.Add("@Lng", SqlDbType.VarChar).Value = fLng;

        return Execute();
    }
    public int USP_WebInfo_Insert(Int32 ID, String WebsiteName, String SeoDescription, String SeoTitle, String SeoKeyword, String Email, DateTime CreateDate, String GoogleMap, String Description, String Lat, String Lng)
    {
        mCmd.CommandText = "USP_WebInfo_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@WebsiteName", SqlDbType.NVarChar).Value = WebsiteName;
        mCmd.Parameters.Add("@SeoDescription", SqlDbType.NVarChar).Value = SeoDescription;
        mCmd.Parameters.Add("@SeoTitle", SqlDbType.NVarChar).Value = SeoTitle;
        mCmd.Parameters.Add("@SeoKeyword", SqlDbType.NVarChar).Value = SeoKeyword;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = CreateDate;
        mCmd.Parameters.Add("@GoogleMap", SqlDbType.NText).Value = GoogleMap;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Lat", SqlDbType.VarChar).Value = Lat;
        mCmd.Parameters.Add("@Lng", SqlDbType.VarChar).Value = Lng;

        return Execute();
    }



    
    public int USP_WebInfo_Update()
    {
        mCmd.CommandText = "USP_WebInfo_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@WebsiteName", SqlDbType.NVarChar).Value = fWebsiteName;
        mCmd.Parameters.Add("@SeoDescription", SqlDbType.NVarChar).Value = fSeoDescription;
        mCmd.Parameters.Add("@SeoTitle", SqlDbType.NVarChar).Value = fSeoTitle;
        mCmd.Parameters.Add("@SeoKeyword", SqlDbType.NVarChar).Value = fSeoKeyword;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fCreateDate;
        mCmd.Parameters.Add("@GoogleMap", SqlDbType.NText).Value = fGoogleMap;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        //mCmd.Parameters.Add("@Lat", SqlDbType.VarChar).Value = fLat;
        //mCmd.Parameters.Add("@Lng", SqlDbType.VarChar).Value = fLng;

        return Execute();
    }
    public int USP_WebInfo_Update(Int32 ID, String WebsiteName, String SeoDescription, String SeoTitle, String SeoKeyword, String Email, DateTime CreateDate, String GoogleMap, String Description, String Lat, String Lng)
    {
        mCmd.CommandText = "USP_WebInfo_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@WebsiteName", SqlDbType.NVarChar).Value = WebsiteName;
        mCmd.Parameters.Add("@SeoDescription", SqlDbType.NVarChar).Value = SeoDescription;
        mCmd.Parameters.Add("@SeoTitle", SqlDbType.NVarChar).Value = SeoTitle;
        mCmd.Parameters.Add("@SeoKeyword", SqlDbType.NVarChar).Value = SeoKeyword;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = CreateDate;
        mCmd.Parameters.Add("@GoogleMap", SqlDbType.NText).Value = GoogleMap;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        //mCmd.Parameters.Add("@Lat", SqlDbType.VarChar).Value = Lat;
        //mCmd.Parameters.Add("@Lng", SqlDbType.VarChar).Value = Lng;

        return Execute();
    }

    public int USP_WebInfo_Delete(int ID)
    {
        mCmd.CommandText = "USP_WebInfo_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_WebInfo_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_WebInfo_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_WebInfo_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebInfo_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_WebInfo_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebInfo_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_WebInfo_GetByID(int ID)
    {
        mCmd.CommandText = "USP_WebInfo_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_WebInfo_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_WebInfo_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_WebInfo_Fetch()
    {
        return 0;
    }
    public bool USP_WebInfo_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_WebInfo_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fWebsiteName = mDataReader["WebsiteName"] == null? string.Empty : mDataReader["WebsiteName"].ToString();
            fSeoDescription = mDataReader["MetaDescription"] == string.Empty ? "" : mDataReader["MetaDescription"].ToString();
            fSeoTitle = mDataReader["MetaTitle"] == null ? string.Empty : mDataReader["MetaTitle"].ToString();
            fSeoKeyword = mDataReader["MetaKeywords"] == null ? string.Empty : mDataReader["MetaKeywords"].ToString();
            fEmail = mDataReader["Email"] == null ? string.Empty : mDataReader["Email"].ToString();
            fCreateDate = Convert.ToDateTime(mDataReader["CreateDate"]);
            fGoogleMap = mDataReader["GoogleMap"] == null ? string.Empty : mDataReader["GoogleMap"].ToString();
            fDescription = mDataReader["Description"] == null ? string.Empty : mDataReader["Description"].ToString();
            fLat = mDataReader["Lat"] == null ? string.Empty : mDataReader["Lat"].ToString();
            fLng = mDataReader["Lng"] == null ? string.Empty : mDataReader["Lng"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_WebInfo_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_WebInfo_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
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
            fWebsiteName = mDataReader["WebsiteName"].ToString();
            fSeoDescription = mDataReader["SeoDescription"].ToString();
            fSeoTitle = mDataReader["SeoTitle"].ToString();
            fSeoKeyword = mDataReader["SeoKeyword"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fCreateDate = Convert.ToDateTime(mDataReader["CreateDate"]);
            fGoogleMap = mDataReader["GoogleMap"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fLat = mDataReader["Lat"].ToString();
            fLng = mDataReader["Lng"].ToString();

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
public partial class DAWebInfo : DAWebInfoBase
{
    public int USP_WebInfo_Update_KinhDo_ViDo()
    {
        mCmd.CommandText = "USP_WebInfo_Update_KinhDo_ViDo";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Lat", SqlDbType.VarChar).Value = fLat;
        mCmd.Parameters.Add("@Lng", SqlDbType.VarChar).Value = fLng;

        return Execute();
    }

    public int USP_WebInfo_UpdateSEO()
    {
        mCmd.CommandText = "USP_WebInfo_UpdateSEO";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fSeoTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fSeoDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fSeoKeyword;

        return Execute();
    }

    public bool USP_WebInfo_GetByID(int ID)
    {
        mCmd.CommandText = "USP_WebInfo_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fWebsiteName = mDataReader["WebsiteName"] == null ? string.Empty : mDataReader["WebsiteName"].ToString();
            fSeoDescription = mDataReader["MetaDescription"] == string.Empty ? "" : mDataReader["MetaDescription"].ToString();
            fSeoTitle = mDataReader["MetaTitle"] == null ? string.Empty : mDataReader["MetaTitle"].ToString();
            fSeoKeyword = mDataReader["MetaKeywords"] == null ? string.Empty : mDataReader["MetaKeywords"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }
}
