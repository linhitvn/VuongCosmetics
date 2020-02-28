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

public class DAProvinceBase : TDatabase
{
    public Int32 fID;
    public String fProvince;
    public Boolean fIsAllowShipping;
    public Boolean fIsAllowBilling;

    public DAProvinceBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Province";
        mKeyName = "ID";
    }
    public int USP_Province_Insert()
    {
        mCmd.CommandText = "USP_Province_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = fProvince;
        mCmd.Parameters.Add("@IsAllowShipping", SqlDbType.Bit).Value = fIsAllowShipping;
        mCmd.Parameters.Add("@IsAllowBilling", SqlDbType.Bit).Value = fIsAllowBilling;

        return Execute();
    }
    public int USP_Province_Insert(Int32 ID, String Province, Boolean IsAllowShipping, Boolean IsAllowBilling)
    {
        mCmd.CommandText = "USP_Province_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = Province;
        mCmd.Parameters.Add("@IsAllowShipping", SqlDbType.Bit).Value = IsAllowShipping;
        mCmd.Parameters.Add("@IsAllowBilling", SqlDbType.Bit).Value = IsAllowBilling;

        return Execute();
    }

    public int USP_Province_Update()
    {
        mCmd.CommandText = "USP_Province_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = fProvince;
        mCmd.Parameters.Add("@IsAllowShipping", SqlDbType.Bit).Value = fIsAllowShipping;
        mCmd.Parameters.Add("@IsAllowBilling", SqlDbType.Bit).Value = fIsAllowBilling;

        return Execute();
    }
    public int USP_Province_Update(Int32 ID, String Province, Boolean IsAllowShipping, Boolean IsAllowBilling)
    {
        mCmd.CommandText = "USP_Province_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = Province;
        mCmd.Parameters.Add("@IsAllowShipping", SqlDbType.Bit).Value = IsAllowShipping;
        mCmd.Parameters.Add("@IsAllowBilling", SqlDbType.Bit).Value = IsAllowBilling;

        return Execute();
    }

    public int USP_Province_Delete(int ID)
    {
        mCmd.CommandText = "USP_Province_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Province_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Province_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Province_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Province_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Province_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Province_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Province_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Province_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Province_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Province_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Province_Fetch()
    {
        return 0;
    }
    public bool USP_Province_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Province_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fProvince = mDataReader["Province"].ToString();
            fIsAllowShipping = Convert.ToBoolean(mDataReader["IsAllowShipping"]);
            fIsAllowBilling = Convert.ToBoolean(mDataReader["IsAllowBilling"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Province_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Province_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Province_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Province_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Province_CheckDuplicate(string Province)
    {
        mCmd.CommandText = "USP_Province_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@Province", SqlDbType.VarChar).Value = Province;
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
            fProvince = mDataReader["Province"].ToString();
            fIsAllowShipping = Convert.ToBoolean(mDataReader["IsAllowShipping"]);
            fIsAllowBilling = Convert.ToBoolean(mDataReader["IsAllowBilling"]);

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
public partial class DAProvince : DAProvinceBase
{
}
