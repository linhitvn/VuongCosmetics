<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cmenu.ascx.cs" Inherits="controls_menu_cmenu" %>

<!-- Start Navigation -->
<nav class="navbar navbar-expand-lg navbar-light bg-light navbar-default bootsnav">
    <div class="container">
        <!-- Start Header Navigation -->
        <div class="navbar-header">
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar-menu" aria-controls="navbars-rs-food" aria-expanded="false" aria-label="Toggle navigation">
                <i class="fa fa-bars"></i>
            </button>
            <a class="navbar-brand" href="/">
                <img src="/assets/images/logo.png" class="logo" alt="The Vuong's Cosmetics"></a>
        </div>
        <!-- End Header Navigation -->

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="navbar-menu">
            <ul class="nav navbar-nav ml-auto" data-in="fadeInDown" data-out="fadeOutUp">
                <li class="nav-item" id="liHome" runat="server"><a class="nav-link" href="/">Trang chủ </a></li>
                <li class="nav-item" id="liProduct" runat="server"><a class="nav-link" href="/san-pham/index.html">Sản phẩm </a></li>
                <li class="nav-item" id="liAbout" runat="server"><a class="nav-link" href="/gioi-thieu/index.html">Giới thiệu </a></li>
                <li class="nav-item" id="liContact" runat="server"><a class="nav-link" href="/lien-he/index.html">Liên hệ </a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->

        <!-- Start Atribute Navigation -->
        <div class="attr-nav">
            <ul>
                <li class="search"><a href="#"><i class="fa fa-search-plus"></i></a></li>
                <li class="side-menu"><a href="#">
                    <i class="fa fa-shopping-cart"></i>
                    <span class="badge">
                        <asp:Label ID="lblQuantity" runat="server" Text="0"></asp:Label>
                    </span></a>
                </li>
            </ul>
        </div>
        <!-- End Atribute Navigation -->
    </div>

    <!-- Start Side Menu -->
    <div class="side">
        <a href="#" class="close-side"><i class="fa fa-times-circle"></i></a>
        <div class="cart-box">
            <ul class="cart-list">
                <asp:Repeater ID="rptCart" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href='<%# Eval("RewriteURL")%>' class="photo">
                                <img alt='<%# Eval("ProductName")%>' src='<%# Eval("ImgLink1")%>' class="cart-thumb" />
                            </a>
                            <h6><a href="#"><%# Eval("ProductName")%> </a></h6>
                            <p><%# Eval("Quantity")%>x - <span class="price"><%# Eval("Price","{0:#,##}")%> VNĐ</span></p>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <li class="total">
                    <a href="/gio-hang/index.html" class="btn btn-default hvr-hover btn-cart">Đặt Mua</a>
                    <span class="float-right"><strong>TC</strong>: <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label> VNĐ</span>
                </li>
            </ul>
        </div>
    </div>
    <!-- End Side Menu -->
</nav>
<!-- End Navigation -->

