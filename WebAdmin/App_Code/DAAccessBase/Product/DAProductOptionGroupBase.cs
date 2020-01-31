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

public class DAProductOptionGroupBase : TDatabase
{
    public Int32 fID;
    public String fProductOptionGroup;
    public String fDescription;
    public Int32 fRecordTypeID;

    public DAProductOptionGroupBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "ProductOptionGroup";
        mKeyName = "ID";
    }
    public int USP_ProductOptionGroup_Insert()
    {
        mCmd.CommandText = "USP_ProductOptionGroup_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductOptionGroup", SqlDbType.NVarChar).Value = fProductOptionGroup;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@RecordTypeID", SqlDbType.Int).Value = fRecordTypeID;

        return Execute();
    }
    public int USP_ProductOptionGroup_Insert(Int32 ID, String ProductOptionGroup, String Description, Int32 RecordTypeID)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProductOptionGroup", SqlDbType.NVarChar).Value = ProductOptionGroup;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@RecordTypeID", SqlDbType.Int).Value = RecordTypeID;

        return Execute();
    }

    public int USP_ProductOptionGroup_Update()
    {
        mCmd.CommandText = "USP_ProductOptionGroup_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductOptionGroup", SqlDbType.NVarChar).Value = fProductOptionGroup;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@RecordTypeID", SqlDbType.Int).Value = fRecordTypeID;

        return Execute();
    }
    public int USP_ProductOptionGroup_Update(Int32 ID, String ProductOptionGroup, String Description, Int32 RecordTypeID)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProductOptionGroup", SqlDbType.NVarChar).Value = ProductOptionGroup;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@RecordTypeID", SqlDbType.Int).Value = RecordTypeID;

        return Execute();
    }

    public int USP_ProductOptionGroup_Delete(int ID)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_ProductOptionGroup_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_ProductOptionGroup_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_ProductOptionGroup_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ProductOptionGroup_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_ProductOptionGroup_GetByID(int ID)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_ProductOptionGroup_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_ProductOptionGroup_Fetch()
    {
        return 0;
    }
    public bool USP_ProductOptionGroup_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fProductOptionGroup = mDataReader["ProductOptionGroup"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fRecordTypeID = Convert.ToInt32(mDataReader["RecordTypeID"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_ProductOptionGroup_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ProductOptionGroup_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_ProductOptionGroup_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_ProductOptionGroup_CheckDuplicate(string ProductOptionGroup)
    {
        mCmd.CommandText = "USP_ProductOptionGroup_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductOptionGroup", SqlDbType.VarChar).Value = ProductOptionGroup;
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
            fProductOptionGroup = mDataReader["ProductOptionGroup"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fRecordTypeID = Convert.ToInt32(mDataReader["RecordTypeID"]);

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
public partial class DAProductOptionGroup : DAProductOptionGroupBase
{
}
