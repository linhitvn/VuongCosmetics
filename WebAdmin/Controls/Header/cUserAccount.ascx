<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cUserAccount.ascx.cs" Inherits="Controls_Header_cUserAccount" %>

<a href="#" class="dropdown-toggle" data-toggle="dropdown">
    <i class="glyphicon glyphicon-user"></i>
    <span runat="server" id="fUsername">Jane Doe <i class="caret"></i></span>
</a>
<ul class="dropdown-menu">
    <!-- User image -->
    <li class="user-header bg-light-blue">
        <img src="./img/avatar3.png" class="img-circle" alt="User Image" />
        <p runat="server" id="fUserInfo">
        </p>
    </li>
    <!-- Menu Body -->
   <%-- <li class="user-body">
        <div class="col-xs-4 text-center">
            <a href="#">Followers</a>
        </div>
        <div class="col-xs-4 text-center">
            <a href="#">Sales</a>
        </div>
        <div class="col-xs-4 text-center">
            <a href="#">Friends</a>
        </div>
    </li>--%>
    <!-- Menu Footer-->
    <li class="user-footer">
        <div class="pull-left">
            <a href="?module=1101&act=edit" class="btn btn-default btn-flat">Tài khoản</a>
        </div>
        <div class="pull-right">
            <a runat="server" onserverclick="btLogout_Click" href="#" class="btn btn-default btn-flat">Thoát</a>
        </div>
    </li>
</ul>