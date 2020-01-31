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

public class DAControlListBase : TDatabase
{
    public Int32 fID;
    public String fControlListName;
    public String fControlPath;
    public String fParamExample;
    public String fDescription;
    public String fImgLink;
    public Boolean fIsAdsControl;
    public Boolean fActive;

    public DAControlListBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "ControlList";
        mKeyName = "ID";
    }
    public int USP_ControlList_Insert()
    {
        mCmd.CommandText = "USP_ControlList_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ControlListName", SqlDbType.NVarChar).Value = fControlListName;
        mCmd.Parameters.Add("@ControlPath", SqlDbType.NVarChar).Value = fControlPath;
        mCmd.Parameters.Add("@ParamExample", SqlDbType.VarChar).Value = fParamExample;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@IsAdsControl", SqlDbType.Bit).Value = fIsAdsControl;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;

        return Execute();
    }
    public int USP_ControlList_Insert(Int32 ID, String ControlListName, String ControlPath, String ParamExample, String Description, String ImgLink, Boolean IsAdsControl, Boolean Active)
    {
        mCmd.CommandText = "USP_ControlList_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ControlListName", SqlDbType.NVarChar).Value = ControlListName;
        mCmd.Parameters.Add("@ControlPath", SqlDbType.NVarChar).Value = ControlPath;
        mCmd.Parameters.Add("@ParamExample", SqlDbType.VarChar).Value = ParamExample;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@IsAdsControl", SqlDbType.Bit).Value = IsAdsControl;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;

        return Execute();
    }

    public int USP_ControlList_Update()
    {
        mCmd.CommandText = "USP_ControlList_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ControlListName", SqlDbType.NVarChar).Value = fControlListName;
        mCmd.Parameters.Add("@ControlPath", SqlDbType.NVarChar).Value = fControlPath;
        mCmd.Parameters.Add("@ParamExample", SqlDbType.VarChar).Value = fParamExample;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@IsAdsControl", SqlDbType.Bit).Value = fIsAdsControl;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;

        return Execute();
    }
    public int USP_ControlList_Update(Int32 ID, String ControlListName, String ControlPath, String ParamExample, String Description, String ImgLink, Boolean IsAdsControl, Boolean Active)
    {
        mCmd.CommandText = "USP_ControlList_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ControlListName", SqlDbType.NVarChar).Value = ControlListName;
        mCmd.Parameters.Add("@ControlPath", SqlDbType.NVarChar).Value = ControlPath;
        mCmd.Parameters.Add("@ParamExample", SqlDbType.VarChar).Value = ParamExample;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@IsAdsControl", SqlDbType.Bit).Value = IsAdsControl;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;

        return Execute();
    }

    public int USP_ControlList_Delete(int ID)
    {
        mCmd.CommandText = "USP_ControlList_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_ControlList_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_ControlList_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_ControlList_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ControlList_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ControlList_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ControlList_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_ControlList_GetByID(int ID)
    {
        mCmd.CommandText = "USP_ControlList_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_ControlList_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ControlList_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_ControlList_Fetch()
    {
        return 0;
    }
    public bool USP_ControlList_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_ControlList_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fControlListName = mDataReader["ControlListName"].ToString();
            fControlPath = mDataReader["ControlPath"].ToString();
            fParamExample = mDataReader["ParamExample"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fIsAdsControl = Convert.ToBoolean(mDataReader["IsAdsControl"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_ControlList_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ControlList_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ControlList_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_ControlList_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_ControlList_CheckDuplicate(string ControlListName)
    {
        mCmd.CommandText = "USP_ControlList_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ControlListName", SqlDbType.VarChar).Value = ControlListName;
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
            fControlListName = mDataReader["ControlListName"].ToString();
            fControlPath = mDataReader["ControlPath"].ToString();
            fParamExample = mDataReader["ParamExample"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fIsAdsControl = Convert.ToBoolean(mDataReader["IsAdsControl"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);

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

public partial class DAControlList : DAControlListBase
{
    public SqlDataReader USP_ControlList_GetDataForComboBox_Custom()
    {
        mCmd.CommandText = "USP_ControlList_GetDataForComboBox_Custom";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }
    
    public int USP_ControlList_CheckDuplicateControlPath(string ControlPath)
    {
        mCmd.CommandText = "USP_ControlList_CheckDuplicateControlPath";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ControlPath", SqlDbType.VarChar).Value = ControlPath;
        //ExecuteReader();
        return Execute();
    }


    public bool USP_ControlList_GetByControlPath(string ControlPath)
    {
        mCmd.CommandText = "USP_ControlList_GetByControlPath";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ControlPath", SqlDbType.NVarChar).Value = ControlPath;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fControlListName = mDataReader["ControlListName"].ToString();
            fControlPath = mDataReader["ControlPath"].ToString();
            fParamExample = mDataReader["ParamExample"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fIsAdsControl = Convert.ToBoolean(mDataReader["IsAdsControl"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }
}
