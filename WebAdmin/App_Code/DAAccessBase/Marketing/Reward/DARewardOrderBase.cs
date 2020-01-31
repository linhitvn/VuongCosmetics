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

public class DARewardOrderBase : TDatabase
{
    public Int32 fID;
    public Int32 fRewardID;
    public Int32 fMinPrice;
    public Int32 fPoint;

    public DARewardOrderBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "RewardOrder";
        mKeyName = "ID";
    }
    public int USP_RewardOrder_Insert()
    {
        mCmd.CommandText = "USP_RewardOrder_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@RewardID", SqlDbType.Int).Value = fRewardID;
        mCmd.Parameters.Add("@MinPrice", SqlDbType.Int).Value = fMinPrice;
        mCmd.Parameters.Add("@Point", SqlDbType.Int).Value = fPoint;

        return Execute();
    }
    public int USP_RewardOrder_Insert(Int32 ID, Int32 RewardID, Int32 MinPrice, Int32 Point)
    {
        mCmd.CommandText = "USP_RewardOrder_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@RewardID", SqlDbType.Int).Value = RewardID;
        mCmd.Parameters.Add("@MinPrice", SqlDbType.Int).Value = MinPrice;
        mCmd.Parameters.Add("@Point", SqlDbType.Int).Value = Point;

        return Execute();
    }

    public int USP_RewardOrder_Update()
    {
        mCmd.CommandText = "USP_RewardOrder_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@RewardID", SqlDbType.Int).Value = fRewardID;
        mCmd.Parameters.Add("@MinPrice", SqlDbType.Int).Value = fMinPrice;
        mCmd.Parameters.Add("@Point", SqlDbType.Int).Value = fPoint;

        return Execute();
    }
    public int USP_RewardOrder_Update(Int32 ID, Int32 RewardID, Int32 MinPrice, Int32 Point)
    {
        mCmd.CommandText = "USP_RewardOrder_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@RewardID", SqlDbType.Int).Value = RewardID;
        mCmd.Parameters.Add("@MinPrice", SqlDbType.Int).Value = MinPrice;
        mCmd.Parameters.Add("@Point", SqlDbType.Int).Value = Point;

        return Execute();
    }

    public int USP_RewardOrder_Delete(int ID)
    {
        mCmd.CommandText = "USP_RewardOrder_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_RewardOrder_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_RewardOrder_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_RewardOrder_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_RewardOrder_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_RewardOrder_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_RewardOrder_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_RewardOrder_GetByID(int ID)
    {
        mCmd.CommandText = "USP_RewardOrder_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_RewardOrder_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_RewardOrder_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_RewardOrder_Fetch()
    {
        return 0;
    }
    public bool USP_RewardOrder_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_RewardOrder_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fRewardID = Convert.ToInt32(mDataReader["RewardID"]);
            fMinPrice = Convert.ToInt32(mDataReader["MinPrice"]);
            fPoint = Convert.ToInt32(mDataReader["Point"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_RewardOrder_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_RewardOrder_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_RewardOrder_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_RewardOrder_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_RewardOrder_CheckDuplicate(string RewardID)
    {
        mCmd.CommandText = "USP_RewardOrder_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@RewardID", SqlDbType.VarChar).Value = RewardID;
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
            fRewardID = Convert.ToInt32(mDataReader["RewardID"]);
            fMinPrice = Convert.ToInt32(mDataReader["MinPrice"]);
            fPoint = Convert.ToInt32(mDataReader["Point"]);

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
public partial class DARewardOrder : DARewardOrderBase
{
}
