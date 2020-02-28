<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cHeader.ascx.cs" Inherits="Controls_Header_cHeader" %>


<a runat="server" href="~/" class="logo">
    <!-- Add the class icon to your logo image or logo icon to add the margining -->
    The Vuong's Cosmetics
</a>
<!-- Header Navbar: style can be found in header.less -->
<nav class="navbar navbar-static-top" role="navigation">
    <!-- Sidebar toggle button-->
    <a href="#" class="navbar-btn sidebar-toggle" data-toggle="offcanvas" role="button">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
    </a>
    <div class="navbar-right">
        <ul class="nav navbar-nav">
            <li class="dropdown messages-menu" title="Chức năng khóa màn hình !">
                <a onclick="AddLockScreen()">
                    <i class="fa fa-lock" aria-hidden="true"></i>
                </a>
            </li>
            <!-- Liên hệ từ khách hàng -->
            <li class="dropdown messages-menu" title="Danh sách phản hồi từ khách hàng !">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                    <i class="fa fa-bell-o" aria-hidden="true"></i>
                    <span runat="server" id="fFeedBackNumber" class="label label-success"></span>
                </a>
                <ul class="dropdown-menu">
                    <li class="header">Thông tin liên hệ từ khách hàng</li>
                    <li>
                        <!-- inner menu: contains the actual data -->
                        <ul class="menu">
                            <asp:Repeater runat="server" ID="rptFeedBack">
                                <ItemTemplate>
                                    <li>
                                        <!-- start message -->
                                        <a href="#">
                                            <%--<div class="pull-left">
                                                <img src="./img/avatar3.png" class="img-circle" alt="User Image"/>
                                            </div>--%>
                                            <h4>
                                                <%# Eval("FeedBack")%>
                                                <small><i class="fa fa-clock-o"></i>5 mins</small>
                                            </h4>
                                            <%--<p><%# Eval("Content")%></p>--%>
                                        </a>
                                    </li>
                                    <!-- end message -->
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </li>
                    <li class="footer"><a runat="server" href="~/?module=404">Xem tất cả</a></li>
                </ul>
            </li>
            <!-- User Account: style can be found in dropdown.less -->
            <li runat="server" id="cUserAccount" class="dropdown user user-menu"></li>
        </ul>
    </div>
</nav>
