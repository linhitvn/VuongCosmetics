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

public class DACustomerBase : TDatabase
{
    public Int32 fID;
    public String fCustomerName;
    public Int32 fCustomerGroupID;
    public String fCompany;
    public String fEmail;
    public String fPhone;
    public String fAddress;
    public Int32 fProvinceID;
    public String fBirthday;
    public Byte fSex;
    public String fSocialNetwork;
    public String fUsername;
    public String fPassword;
    public String fNote;
    public String fOperator;
    public DateTime fSysDate;

    public DACustomerBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Customer";
        mKeyName = "ID";
    }
    public int USP_Customer_Insert()
    {
        mCmd.CommandText = "USP_Customer_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = fCustomerName;
        mCmd.Parameters.Add("@CustomerGroupID", SqlDbType.Int).Value = fCustomerGroupID;
        mCmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = fCompany;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = fPhone;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = fAddress;
        mCmd.Parameters.Add("@ProvinceID", SqlDbType.Int).Value = fProvinceID;
        mCmd.Parameters.Add("@Birthday", SqlDbType.NVarChar).Value = fBirthday;
        mCmd.Parameters.Add("@Sex", SqlDbType.TinyInt).Value = fSex;
        mCmd.Parameters.Add("@SocialNetwork", SqlDbType.NVarChar).Value = fSocialNetwork;
        mCmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = fUsername;
        mCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = fPassword;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = fNote;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;

        return Execute();
    }

    public int USP_Customer_Update()
    {
        mCmd.CommandText = "USP_Customer_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = fCustomerName;
        mCmd.Parameters.Add("@CustomerGroupID", SqlDbType.Int).Value = fCustomerGroupID;
        mCmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = fCompany;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = fPhone;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = fAddress;
        mCmd.Parameters.Add("@ProvinceID", SqlDbType.Int).Value = fProvinceID;
        mCmd.Parameters.Add("@Birthday", SqlDbType.NVarChar).Value = fBirthday;
        mCmd.Parameters.Add("@Sex", SqlDbType.TinyInt).Value = fSex;
        mCmd.Parameters.Add("@SocialNetwork", SqlDbType.NVarChar).Value = fSocialNetwork;
        mCmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = fUsername;
        mCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = fPassword;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = fNote;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;

        return Execute();
    }

    public int USP_Customer_Delete(int ID)
    {
        mCmd.CommandText = "USP_Customer_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Customer_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Customer_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Customer_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Customer_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Customer_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Customer_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Customer_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Customer_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Customer_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Customer_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Customer_Fetch()
    {
        return 0;
    }
    public bool USP_Customer_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Customer_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fCustomerName = mDataReader["CustomerName"].ToString();
            fCustomerGroupID = Convert.ToInt32(mDataReader["CustomerGroupID"]);
            fCompany = mDataReader["Company"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fPhone = mDataReader["Phone"].ToString();
            fAddress = mDataReader["Address"].ToString();
            fProvinceID = Convert.ToInt32(mDataReader["ProvinceID"]);
            fBirthday = mDataReader["Birthday"].ToString();
            fSex = Convert.ToByte(mDataReader["Sex"]);
            fSocialNetwork = mDataReader["SocialNetwork"].ToString();
            fUsername = mDataReader["Username"].ToString();
            fPassword = mDataReader["Password"].ToString();
            fNote = mDataReader["Note"].ToString();
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);
            fOperator = mDataReader["Operator"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Customer_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Customer_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Customer_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Customer_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Customer_CheckDuplicate(string CustomerName)
    {
        mCmd.CommandText = "USP_Customer_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = CustomerName;
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
            fCustomerName = mDataReader["CustomerName"].ToString();
            fCustomerGroupID = Convert.ToInt32(mDataReader["CustomerGroupID"]);
            fCompany = mDataReader["Company"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fPhone = mDataReader["Phone"].ToString();
            fAddress = mDataReader["Address"].ToString();
            fProvinceID = Convert.ToInt32(mDataReader["ProvinceID"]);
            fBirthday = mDataReader["Birthday"].ToString();
            fSex = Convert.ToByte(mDataReader["Sex"]);
            fSocialNetwork = mDataReader["SocialNetwork"].ToString();
            fUsername = mDataReader["Username"].ToString();
            fPassword = mDataReader["Password"].ToString();
            fNote = mDataReader["Note"].ToString();
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);
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
public partial class DACustomer : DACustomerBase
{

}
