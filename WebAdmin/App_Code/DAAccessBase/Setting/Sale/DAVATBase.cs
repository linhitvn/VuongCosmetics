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

public class DAVATBase : TDatabase
{
    public Int32 fID;
    public String fVATName;
    public Int32 fValue;

    public DAVATBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "VAT";
        mKeyName = "ID";
    }
    public int USP_VAT_Insert()
    {
        mCmd.CommandText = "USP_VAT_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@VATName", SqlDbType.NVarChar).Value = fVATName;
        mCmd.Parameters.Add("@Value", SqlDbType.Int).Value = fValue;

        return Execute();
    }
    public int USP_VAT_Insert(Int32 ID, String VATName, Int32 Value)
    {
        mCmd.CommandText = "USP_VAT_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@VATName", SqlDbType.NVarChar).Value = VATName;
        mCmd.Parameters.Add("@Value", SqlDbType.Int).Value = Value;

        return Execute();
    }

    public int USP_VAT_Update()
    {
        mCmd.CommandText = "USP_VAT_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@VATName", SqlDbType.NVarChar).Value = fVATName;
        mCmd.Parameters.Add("@Value", SqlDbType.Int).Value = fValue;

        return Execute();
    }
    public int USP_VAT_Update(Int32 ID, String VATName, Int32 Value)
    {
        mCmd.CommandText = "USP_VAT_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@VATName", SqlDbType.NVarChar).Value = VATName;
        mCmd.Parameters.Add("@Value", SqlDbType.Int).Value = Value;

        return Execute();
    }

    public int USP_VAT_Delete(int ID)
    {
        mCmd.CommandText = "USP_VAT_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_VAT_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_VAT_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_VAT_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_VAT_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_VAT_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_VAT_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_VAT_GetByID(int ID)
    {
        mCmd.CommandText = "USP_VAT_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_VAT_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_VAT_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_VAT_Fetch()
    {
        return 0;
    }
    public bool USP_VAT_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_VAT_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fVATName = mDataReader["VATName"].ToString();
            fValue = Convert.ToInt32(mDataReader["Value"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_VAT_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_VAT_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_VAT_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_VAT_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_VAT_CheckDuplicate(string VATName)
    {
        mCmd.CommandText = "USP_VAT_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@VATName", SqlDbType.VarChar).Value = VATName;
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
            fVATName = mDataReader["VATName"].ToString();
            fValue = Convert.ToInt32(mDataReader["Value"]);

            return true;
        }
        else
            if (bClose)
            {
                mDataReader.Close();
            }
        return false;
    }

    public List<DAVAT> USP_VAT_GetList(int First, int Count)
    {
        SqlDataReader reader = USP_VAT_GetAll_Reader(First, Count);
        List<DAVAT> VATs = new List<DAVAT>();
        while (reader.Read())
        {
            VATs.Add(new DAVAT()
            {
                fID = Convert.ToInt32(mDataReader["ID"]),
                fVATName = mDataReader["VATName"].ToString(),
                fValue = Convert.ToInt32(mDataReader["Value"])
            });
        }
        return VATs;
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
public partial class DAVAT : DAVATBase
{
}
