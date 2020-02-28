using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

/// <summary>
/// Summary description for MyString
/// </summary>
public static class MyString
{
    public static string CurrencyFomat(int CurrencyValue)
    {
        return String.Format(CultureInfo.InvariantCulture,
                                 "{0:0,0}", CurrencyValue);
    }
}