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

public class DAWebUserBase : TDatabase
{

    public int fUserID;
    public string fUserName;
    public string fFullName;
    public string fPassWord;
    public string fEmail;
    public string fAddress;
    public string fTel;
    public int fRole;
    public string fDescription;
    public string fSocial;
    public bool fActive;
    public DateTime fCreateDate;
    public DateTime fLastLogin;
    public string fServerMsg;
    public DAWebUserBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "WebUser";
    }
    public int USP_WebUser_Insert()
    {
        mCmd.CommandText = "USP_WebUser_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.SmallInt).Value = fUserID;
        mCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = fUserName;
        mCmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = fFullName;
        mCmd.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = fPassWord;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = fAddress;
        mCmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = fTel;
        mCmd.Parameters.Add("@Role", SqlDbType.Int).Value = fRole;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Social", SqlDbType.VarChar).Value = fSocial;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        return Execute();
    }
    public int USP_WebUser_Insert(int UserID, string UserName, string FullName, string PassWord, string Email, string Address, string Tel, int Role, string Description, string Social, bool Active, DateTime CreateDate, DateTime LastLogin)
    {
        mCmd.CommandText = "USP_WebUser_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.SmallInt).Value = UserID;
        mCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
        mCmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = FullName;
        mCmd.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = PassWord;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
        mCmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = Tel;
        mCmd.Parameters.Add("@Role", SqlDbType.Int).Value = Role;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Social", SqlDbType.VarChar).Value = Social;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        return Execute();
    }

    public int USP_WebUser_Update()
    {
        mCmd.CommandText = "USP_WebUser_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.SmallInt).Value = fUserID;
        mCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = fUserName;
        mCmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = fFullName;
        mCmd.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = fPassWord;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = fAddress;
        mCmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = fTel;
        mCmd.Parameters.Add("@Role", SqlDbType.Int).Value = fRole;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Social", SqlDbType.VarChar).Value = fSocial;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        return Execute();
    }
    public int USP_WebUser_Update(int UserID, string UserName, string FullName, string PassWord, string Email, string Address, string Tel, int Role, string Description, string Social, bool Active, DateTime CreateDate, DateTime LastLogin)
    {
        mCmd.CommandText = "USP_WebUser_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.SmallInt).Value = UserID;
        mCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
        mCmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = FullName;
        mCmd.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = PassWord;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
        mCmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = Tel;
        mCmd.Parameters.Add("@Role", SqlDbType.Int).Value = Role;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Social", SqlDbType.VarChar).Value = Social;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        return Execute();
    }

    public int USP_WebUser_Delete(int UserID)
    {
        mCmd.CommandText = "USP_WebUser_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        return Execute();
    }

    public int USP_WebUser_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fUserID;
        return Execute();
    }

    public DataSet USP_WebUser_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_WebUser_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebUser_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_WebUser_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebUser_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_WebUser_GetByID(int UserID)
    {
        mCmd.CommandText = "USP_WebUser_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_WebUser_GetByID_Reader(int UserID)
    {
        mCmd.CommandText = "USP_WebUser_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_WebUser_Fetch()
    {
        return 0;
    }
    public bool USP_WebUser_GetFullID(int UserID)
    {
        mCmd.CommandText = "USP_WebUser_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fUserID = Convert.ToInt32(mDataReader["UserID"]);
            fUserName = mDataReader["UserName"].ToString();
            fFullName = mDataReader["FullName"].ToString();
            fPassWord = mDataReader["PassWord"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fAddress = mDataReader["Address"].ToString();
            fTel = mDataReader["Tel"].ToString();
            fRole = Convert.ToInt32(mDataReader["Role"]);
            fDescription = mDataReader["Description"].ToString();
            fSocial = mDataReader["Social"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fCreateDate = Convert.ToDateTime(mDataReader["CreateDate"]);
            fLastLogin = Convert.ToDateTime(mDataReader["LastLogin"]);
            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_WebUser_GetFullID_Reader(int UserID)
    {
        mCmd.CommandText = "USP_WebUser_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        ExecuteReader();
        return mDataReader;
    }

    public int USP_NewKey()
    {
        fUserID = USP_GetKey();
        return fUserID;
    }

    public bool Fetch_Reader(bool bClose)
    {
        if (mDataReader.IsClosed)
            return false;
        if (mDataReader.Read())
        {
            fUserID = Convert.ToInt32(mDataReader["UserID"]);
            fUserName = Convert.ToString(mDataReader["UserName"]);
            fFullName = Convert.ToString(mDataReader["FullName"]);
            fPassWord = Convert.ToString(mDataReader["PassWord"]);
            fEmail = Convert.ToString(mDataReader["Email"]);
            fAddress = Convert.ToString(mDataReader["Address"]);
            fTel = Convert.ToString(mDataReader["Tel"]);
            fRole = Convert.ToInt32(mDataReader["Role"]);
            fDescription = Convert.ToString(mDataReader["Description"]);
            fSocial = Convert.ToString(mDataReader["Social"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fCreateDate = Convert.ToDateTime(mDataReader["CreateDate"]);
            fLastLogin = Convert.ToDateTime(mDataReader["LastLogin"]);
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
public partial class DAWebUser : DAWebUserBase
{
    public DataSet USP_WebUser_GetAllUser()
    {
        mCmd.CommandText = "USP_WebUser_GetAllUser";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        //ExecuteReader();
        return ExecuteDataSet();
    }

    public DataSet USP_WebUser_GetAllUserByUserID(int UserID)
    {
        mCmd.CommandText = "USP_WebUser_GetAllUserByUserID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        //ExecuteReader();
        return ExecuteDataSet();
    }

    public SqlDataReader USP_WebUser_Login(string UserName, string Pass)
    {
        mCmd.CommandText = "USP_WebUser_Login";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = UserName;
        mCmd.Parameters.Add("@PassWord", SqlDbType.VarChar, 100).Value = Pass;
        return ExecuteReader();
    }

    public int USP_WebUser_CheckDuplicate(string UserName)
    {
        mCmd.CommandText = "USP_WebUser_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
        //ExecuteReader();
        return Execute();
    }

    public int USP_WebUser_UpdateInfo()
    {
        mCmd.CommandText = "USP_WebUser_UpdateInfo";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.SmallInt).Value = fUserID;
        mCmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = fFullName;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = fAddress;
        mCmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = fTel;
        mCmd.Parameters.Add("@Social", SqlDbType.VarChar).Value = fSocial;
        return Execute();
    }

    public int USP_WebUser_ChangePass(int UserID, string Password)
    {
        mCmd.CommandText = "USP_WebUser_ChangePass";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@WebUserID", SqlDbType.SmallInt).Value = UserID;
        mCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
        return Execute();
    }
    
}
