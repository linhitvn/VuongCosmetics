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

public class DAContactInfoBase : TDatabase
{
    public Int32 fContactInfoID;
    public String fContactInfo;
    public String fSlogan;
    public String fAddress;
    public String fPhone;
    public String fFax;
    public String fEmail;
    public String fWebsite;
    public String fTaxCode;
    public String fBankName;
    public String fBankAccount;

    public DAContactInfoBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "ContactInfo";
        mKeyName = "ContactInfoID";
    }
    public int USP_ContactInfo_Insert()
    {
        mCmd.CommandText = "USP_ContactInfo_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = fContactInfoID;
        mCmd.Parameters.Add("@ContactInfo", SqlDbType.NVarChar).Value = fContactInfo;
        mCmd.Parameters.Add("@Slogan", SqlDbType.NVarChar).Value = fSlogan;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = fAddress;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = fPhone;
        mCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fFax;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = fWebsite;
        mCmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = fTaxCode;
        mCmd.Parameters.Add("@BankName", SqlDbType.NVarChar).Value = fBankName;
        mCmd.Parameters.Add("@BankAccount", SqlDbType.NVarChar).Value = fBankAccount;

        return Execute();
    }
    public int USP_ContactInfo_Insert(Int32 ContactInfoID, String ContactInfo, String Slogan, String Address, String Phone, String Fax, String Email, String Website, String TaxCode, String BankName, String BankAccount)
    {
        mCmd.CommandText = "USP_ContactInfo_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = ContactInfoID;
        mCmd.Parameters.Add("@ContactInfo", SqlDbType.NVarChar).Value = ContactInfo;
        mCmd.Parameters.Add("@Slogan", SqlDbType.NVarChar).Value = Slogan;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
        mCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Fax;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = Website;
        mCmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = TaxCode;
        mCmd.Parameters.Add("@BankName", SqlDbType.NVarChar).Value = BankName;
        mCmd.Parameters.Add("@BankAccount", SqlDbType.NVarChar).Value = BankAccount;

        return Execute();
    }

    public int USP_ContactInfo_Update()
    {
        mCmd.CommandText = "USP_ContactInfo_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = fContactInfoID;
        mCmd.Parameters.Add("@ContactInfo", SqlDbType.NVarChar).Value = fContactInfo;
        mCmd.Parameters.Add("@Slogan", SqlDbType.NVarChar).Value = fSlogan;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = fAddress;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = fPhone;
        mCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fFax;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = fWebsite;
        mCmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = fTaxCode;
        mCmd.Parameters.Add("@BankName", SqlDbType.NVarChar).Value = fBankName;
        mCmd.Parameters.Add("@BankAccount", SqlDbType.NVarChar).Value = fBankAccount;

        return Execute();
    }
    public int USP_ContactInfo_Update(Int32 ContactInfoID, String ContactInfo, String Slogan, String Address, String Phone, String Fax, String Email, String Website, String TaxCode, String BankName, String BankAccount)
    {
        mCmd.CommandText = "USP_ContactInfo_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = ContactInfoID;
        mCmd.Parameters.Add("@ContactInfo", SqlDbType.NVarChar).Value = ContactInfo;
        mCmd.Parameters.Add("@Slogan", SqlDbType.NVarChar).Value = Slogan;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
        mCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Fax;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = Website;
        mCmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = TaxCode;
        mCmd.Parameters.Add("@BankName", SqlDbType.NVarChar).Value = BankName;
        mCmd.Parameters.Add("@BankAccount", SqlDbType.NVarChar).Value = BankAccount;

        return Execute();
    }

    public int USP_ContactInfo_Delete(int ContactInfoID)
    {
        mCmd.CommandText = "USP_ContactInfo_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = ContactInfoID;
        return Execute();
    }

    public int USP_ContactInfo_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = fContactInfoID;
        return Execute();
    }

    public DataSet USP_ContactInfo_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_ContactInfo_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ContactInfo_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ContactInfo_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ContactInfo_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_ContactInfo_GetByID(int ContactInfoID)
    {
        mCmd.CommandText = "USP_ContactInfo_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = ContactInfoID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_ContactInfo_GetByID_Reader(int ContactInfoID)
    {
        mCmd.CommandText = "USP_ContactInfo_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = ContactInfoID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ContactInfo_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_ContactInfo_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_ContactInfo_Fetch()
    {
        return 0;
    }
    public bool USP_ContactInfo_GetFullID(int ContactInfoID)
    {
        mCmd.CommandText = "USP_ContactInfo_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = ContactInfoID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fContactInfoID = Convert.ToInt32(mDataReader["ContactInfoID"]);
            fContactInfo = mDataReader["ContactInfo"].ToString();
            fSlogan = mDataReader["Slogan"].ToString();
            fAddress = mDataReader["Address"].ToString();
            fPhone = mDataReader["Phone"].ToString();
            fFax = mDataReader["Fax"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fWebsite = mDataReader["Website"].ToString();
            fTaxCode = mDataReader["TaxCode"].ToString();
            fBankName = mDataReader["BankName"].ToString();
            fBankAccount = mDataReader["BankAccount"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_ContactInfo_GetFullID_Reader(int ContactInfoID)
    {
        mCmd.CommandText = "USP_ContactInfo_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ContactInfoID", SqlDbType.Int).Value = ContactInfoID;
        ExecuteReader();
        return mDataReader;
    }

    public int USP_NewKey()
    {
        fContactInfoID = USP_GetKey();
        return fContactInfoID;
    }

    public bool Fetch_Reader(bool bClose)
    {
        if (mDataReader.IsClosed)
            return false;
        if (mDataReader.Read())
        {
            fContactInfoID = Convert.ToInt32(mDataReader["ContactInfoID"]);
            fContactInfo = mDataReader["ContactInfo"].ToString();
            fSlogan = mDataReader["Slogan"].ToString();
            fAddress = mDataReader["Address"].ToString();
            fPhone = mDataReader["Phone"].ToString();
            fFax = mDataReader["Fax"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fWebsite = mDataReader["Website"].ToString();
            fTaxCode = mDataReader["TaxCode"].ToString();
            fBankName = mDataReader["BankName"].ToString();
            fBankAccount = mDataReader["BankAccount"].ToString();

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
public partial class DAContactInfo : DAContactInfoBase
{
}
