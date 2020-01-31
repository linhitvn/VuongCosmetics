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

public class DARewardBase : TDatabase
{
    public Int32 fID;
    public Int32 fRewardTypeID;
    public Int32 fPointToMoney;
    public Int32 fMinForChange;
    public Int32 fAfterDayForChange;
    public Int32 fDayForResetAll;
    public Boolean fActive;
    public String fNote;
    public String fOperator;

    public DARewardBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Reward";
        mKeyName = "ID";
    }
    public int USP_Reward_Insert()
    {
        mCmd.CommandText = "USP_Reward_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@RewardTypeID", SqlDbType.Int).Value = fRewardTypeID;
        mCmd.Parameters.Add("@PointToMoney", SqlDbType.Int).Value = fPointToMoney;
        mCmd.Parameters.Add("@MinForChange", SqlDbType.Int).Value = fMinForChange;
        mCmd.Parameters.Add("@AfterDayForChange", SqlDbType.Int).Value = fAfterDayForChange;
        mCmd.Parameters.Add("@DayForResetAll", SqlDbType.Int).Value = fDayForResetAll;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = fNote;
        mCmd.Parameters.Add("@Operator", SqlDbType.NChar).Value = fOperator;

        return Execute();
    }
    public int USP_Reward_Insert(Int32 ID, Int32 RewardTypeID, Int32 PointToMoney, Int32 MinForChange, Int32 AfterDayForChange, Int32 DayForResetAll, Boolean Active, String Note, String Operator)
    {
        mCmd.CommandText = "USP_Reward_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@RewardTypeID", SqlDbType.Int).Value = RewardTypeID;
        mCmd.Parameters.Add("@PointToMoney", SqlDbType.Int).Value = PointToMoney;
        mCmd.Parameters.Add("@MinForChange", SqlDbType.Int).Value = MinForChange;
        mCmd.Parameters.Add("@AfterDayForChange", SqlDbType.Int).Value = AfterDayForChange;
        mCmd.Parameters.Add("@DayForResetAll", SqlDbType.Int).Value = DayForResetAll;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = Note;
        mCmd.Parameters.Add("@Operator", SqlDbType.NChar).Value = Operator;

        return Execute();
    }

    public int USP_Reward_Update()
    {
        mCmd.CommandText = "USP_Reward_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@RewardTypeID", SqlDbType.Int).Value = fRewardTypeID;
        mCmd.Parameters.Add("@PointToMoney", SqlDbType.Int).Value = fPointToMoney;
        mCmd.Parameters.Add("@MinForChange", SqlDbType.Int).Value = fMinForChange;
        mCmd.Parameters.Add("@AfterDayForChange", SqlDbType.Int).Value = fAfterDayForChange;
        mCmd.Parameters.Add("@DayForResetAll", SqlDbType.Int).Value = fDayForResetAll;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = fNote;
        mCmd.Parameters.Add("@Operator", SqlDbType.NChar).Value = fOperator;

        return Execute();
    }
    public int USP_Reward_Update(Int32 ID, Int32 RewardTypeID, Int32 PointToMoney, Int32 MinForChange, Int32 AfterDayForChange, Int32 DayForResetAll, Boolean Active, String Note, String Operator)
    {
        mCmd.CommandText = "USP_Reward_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@RewardTypeID", SqlDbType.Int).Value = RewardTypeID;
        mCmd.Parameters.Add("@PointToMoney", SqlDbType.Int).Value = PointToMoney;
        mCmd.Parameters.Add("@MinForChange", SqlDbType.Int).Value = MinForChange;
        mCmd.Parameters.Add("@AfterDayForChange", SqlDbType.Int).Value = AfterDayForChange;
        mCmd.Parameters.Add("@DayForResetAll", SqlDbType.Int).Value = DayForResetAll;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = Note;
        mCmd.Parameters.Add("@Operator", SqlDbType.NChar).Value = Operator;

        return Execute();
    }

    public int USP_Reward_Delete(int ID)
    {
        mCmd.CommandText = "USP_Reward_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Reward_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Reward_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Reward_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Reward_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Reward_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Reward_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Reward_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Reward_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Reward_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Reward_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Reward_Fetch()
    {
        return 0;
    }
    public bool USP_Reward_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Reward_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fRewardTypeID = Convert.ToInt32(mDataReader["RewardTypeID"]);
            fPointToMoney = Convert.ToInt32(mDataReader["PointToMoney"]);
            fMinForChange = Convert.ToInt32(mDataReader["MinForChange"]);
            fAfterDayForChange = Convert.ToInt32(mDataReader["AfterDayForChange"]);
            fDayForResetAll = Convert.ToInt32(mDataReader["DayForResetAll"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fNote = mDataReader["Note"].ToString();
            fOperator = mDataReader["Operator"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Reward_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Reward_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Reward_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Reward_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Reward_CheckDuplicate(string RewardTypeID)
    {
        mCmd.CommandText = "USP_Reward_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@RewardTypeID", SqlDbType.VarChar).Value = RewardTypeID;
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
            fRewardTypeID = Convert.ToInt32(mDataReader["RewardTypeID"]);
            fPointToMoney = Convert.ToInt32(mDataReader["PointToMoney"]);
            fMinForChange = Convert.ToInt32(mDataReader["MinForChange"]);
            fAfterDayForChange = Convert.ToInt32(mDataReader["AfterDayForChange"]);
            fDayForResetAll = Convert.ToInt32(mDataReader["DayForResetAll"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fNote = mDataReader["Note"].ToString();
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
public partial class DAReward : DARewardBase
{
}
