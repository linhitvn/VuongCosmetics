<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head id="Head1" runat="server">
    <title>Telerik ASP.NET Example</title>
</head>
 
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" />
 
    <div class="demo-container size-thin">
        <telerik:RadComboBox runat="server" ID="RadComboBox2" 
            DataTextField="ProductName" DataValueField="ID"
            EnableLoadOnDemand="True" OnItemsRequested="RadComboBox2_ItemsRequested" 
            Height="200px" Width="250px"
            ShowMoreResultsBox="true" AutoPostBack="true"
            onselectedindexchanged="RadComboBox2_SelectedIndexChanged">
        </telerik:RadComboBox>
        <label runat="server" id="div_check">Not Checked</label>
    </div>
 
    </form>
</body>
</html>