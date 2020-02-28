<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cLeftMenu.ascx.cs" Inherits="Controls_Menu_cLeftMenu" %>
<!-- sidebar: style can be found in sidebar.less -->
<section class="sidebar">
    <!-- Sidebar user panel -->
    <%--<div class="user-panel">
            <div class="pull-left image">
                <img src="./img/avatar3.png" class="img-circle" alt="User Image" />
            </div>
            <div class="pull-left info">
                <p runat="server" id="fUsername"></p>
                <a href="#"><i class="fa fa-circle text-success"></i> Online</a>
            </div>
        </div>--%>
    <!-- search form -->
    <%--<div class="sidebar-form">
            <div class="input-group">
                <input type="text" name="q" class="form-control" placeholder="Search..."/>
                <span class="input-group-btn">
                    <button type='submit' name='seach' id='search-btn' class="btn btn-flat"><i class="fa fa-search"></i></button>
                </span>
            </div>
        </div>--%>
    <!-- /.search form -->
    <!-- sidebar menu: : style can be found in sidebar.less -->
    <ul class="sidebar-menu">
        <li>
            <a href="?module=100">
                <i class="fa fa-dashboard"></i><span>Dashboard</span>
            </a>
        </li>
        <asp:Repeater ID="rptParent" runat="server" OnItemDataBound="rptParent_ItemDataBound">
            <ItemTemplate>
                <li class="treeview <%# GetActiveClass(Eval("FuncID").ToString()) %>">
                    <a href='?module=<%# Eval("FuncID") %>'>
                        <i class="<%#Eval("CssClass") %>"></i>
                        <span><%# Eval("VNName")%></span>
                        <i class="fa fa-angle-left pull-right"></i>
                        <asp:HiddenField ID="hdnParentID" runat="server" Value='<%# Eval("FuncID") %>' />
                    </a>
                    <ul class="treeview-menu">
                        <asp:Repeater ID="rptChild" runat="server">
                            <ItemTemplate>
                                <li><a href='?module=<%# Eval("FuncID") %><%# Eval("UKey") %>'><i class="fa fa-angle-double-right"></i><%# Eval("VNName")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</section>
<!-- /.sidebar -->
