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

public class DAShortCutTypeBase : TDatabase
{
    public Int32 fID;
    public String fShortCutType;
    public String fDescription;
    public String fHTMLDefault;
    public Boolean fActive;

    public DAShortCutTypeBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "ShortCutType";
        mKeyName = "ID";
    }
    public int USP_ShortCutType_Insert()
    {
        mCmd.CommandText = "USP_ShortCutType_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ShortCutType", SqlDbType.NVarChar).Value = fShortCutType;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@HTMLDefault", SqlDbType.NVarChar).Value = fHTMLDefault;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;

        return Execute();
    }
    public int USP_ShortCutType_Insert(Int32 ID, String ShortCutType, String Description, String HTMLDefault, Boolean Active)
    {
        mCmd.CommandText = "USP_ShortCutType_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ShortCutType", SqlDbType.NVarChar).Value = ShortCutType;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@HTMLDefault", SqlDbType.NVarChar).Value = HTMLDefault;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;

        return Execute();
    }

    public int USP_ShortCutType_Update()
    {
        mCmd.CommandText = "USP_ShortCutType_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ShortCutType", SqlDbType.NVarChar).Value = fShortCutType;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@HTMLDefault", SqlDbType.NVarChar).Value = fHTMLDefault;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;

        return Execute();
    }
    public int USP_ShortCutType_Update(Int32 ID, String ShortCutType, String Description, String HTMLDefault, Boolean Active)
    {
        mCmd.CommandText = "USP_ShortCutType_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ShortCutType", SqlDbType.NVarChar).Value = ShortCutType;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@HTMLDefault", SqlDbType.NVarChar).Value = HTMLDefault;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;

        return Execute();
    }

    public int USP_ShortCutType_Delete(int ID)
    {
        mCmd.CommandText = "USP_ShortCutType_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_ShortCutType_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_ShortCutType_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_ShortCutType_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ShortCutType_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ShortCutType_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ShortCutType_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_ShortCutType_GetByID(int ID)
    {
        mCmd.CommandText = "USP_ShortCutType_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_ShortCutType_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ShortCutType_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_ShortCutType_Fetch()
    {
        return 0;
    }
    public bool USP_ShortCutType_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_ShortCutType_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fShortCutType = mDataReader["ShortCutType"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fHTMLDefault = mDataReader["HTMLDefault"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_ShortCutType_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ShortCutType_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ShortCutType_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_ShortCutType_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_ShortCutType_CheckDuplicate(string ShortCutType)
    {
        mCmd.CommandText = "USP_ShortCutType_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ShortCutType", SqlDbType.VarChar).Value = ShortCutType;
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
            fShortCutType = mDataReader["ShortCutType"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fHTMLDefault = mDataReader["HTMLDefault"].ToString();
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
public partial class DAShortCutType : DAShortCutTypeBase
{
}
