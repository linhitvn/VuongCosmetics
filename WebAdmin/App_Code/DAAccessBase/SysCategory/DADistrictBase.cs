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

public class DADistrictBase : TDatabase
{
    public Int32 fID;
    public String fDistrict;
    public Int32 fProvinceID;

    public DADistrictBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "District";
        mKeyName = "ID";
    }
    public int USP_District_Insert()
    {
        mCmd.CommandText = "USP_District_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@District", SqlDbType.NVarChar).Value = fDistrict;
        mCmd.Parameters.Add("@ProvinceID", SqlDbType.Int).Value = fProvinceID;

        return Execute();
    }
    public int USP_District_Insert(Int32 ID, String District, Int32 ProvinceID)
    {
        mCmd.CommandText = "USP_District_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@District", SqlDbType.NVarChar).Value = District;
        mCmd.Parameters.Add("@ProvinceID", SqlDbType.Int).Value = ProvinceID;

        return Execute();
    }

    public int USP_District_Update()
    {
        mCmd.CommandText = "USP_District_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@District", SqlDbType.NVarChar).Value = fDistrict;
        mCmd.Parameters.Add("@ProvinceID", SqlDbType.Int).Value = fProvinceID;

        return Execute();
    }
    public int USP_District_Update(Int32 ID, String District, Int32 ProvinceID)
    {
        mCmd.CommandText = "USP_District_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@District", SqlDbType.NVarChar).Value = District;
        mCmd.Parameters.Add("@ProvinceID", SqlDbType.Int).Value = ProvinceID;

        return Execute();
    }

    public int USP_District_Delete(int ID)
    {
        mCmd.CommandText = "USP_District_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_District_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_District_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_District_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_District_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_District_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_District_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_District_GetByID(int ID)
    {
        mCmd.CommandText = "USP_District_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_District_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_District_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_District_Fetch()
    {
        return 0;
    }
    public bool USP_District_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_District_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fDistrict = mDataReader["District"].ToString();
            fProvinceID = Convert.ToInt32(mDataReader["ProvinceID"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_District_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_District_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_District_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_District_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_District_CheckDuplicate(string District)
    {
        mCmd.CommandText = "USP_District_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@District", SqlDbType.VarChar).Value = District;
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
            fDistrict = mDataReader["District"].ToString();
            fProvinceID = Convert.ToInt32(mDataReader["ProvinceID"]);

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
public partial class DADistrict : DADistrictBase
{
    public SqlDataReader USP_District_GetDataForComboBox_ByProvinceID(int ProvinceID)
    {
        mCmd.CommandText = "USP_District_GetDataForComboBox_ByProvinceID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProvinceID", SqlDbType.Int).Value = ProvinceID;
        ExecuteReader();
        return mDataReader;
    }
}
