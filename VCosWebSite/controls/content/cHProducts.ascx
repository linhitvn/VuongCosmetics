<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cHProducts.ascx.cs" Inherits="controls_content_cHProducts" %>

<div class="products-box">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="title-all text-center">
                    <%--<h1>Sản Phẩm Nổi Bật </h1>--%>
                    <div class="container middle-col-hot">				
					    <img src="/assets/images/vipharma-graphic_04.png" alt="" />					
                    </div>
                    <%--<p>Tất cả sản phẩm tại The Vuong's Cosmetics mang thương hiệu VIPHARMA CGMP-ASEAN đều được Bộ Y Tế công nhận được sản xuất tại nhà máy đạt tiêu chuẩn CGMP.... </p>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="special-menu">
                    <div class="button-group filter-button-group">
                        <label class="active" data-filter="*">Tất cả </label>
                        <label data-filter=".latest">Mới Nhất </label>
                        <label data-filter=".best-seller">Best-seller </label>
                    </div>
                </div>
            </div>
        </div>

        <div class="row special-list">
            <asp:Repeater ID="rptHot" runat="server" onitemcommand="rptHot_ItemCommand">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-6 special-grid <%#Eval("Filter")%>">
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                        <div class="products-single fix">
                            <div class="box-img-hover">
                                <div class="type-lb">
                                    <%--<p class="sale">Mua nhiều </p>--%>
                                </div>
                                <img alt='<%# Eval("ProductName")%>' src='<%# Eval("ImgLink1")%>' data-echo="/assets/images/products/pro_M_001.png" class="img-fluid" />
                                <div class="mask-icon">
                                    <asp:LinkButton ID="lkbOrder" runat="server" CssClass="cart" CommandName ="AddCart">Thêm Vào Giỏ Hàng</asp:LinkButton>
                                </div>
                            </div>
                            <div class="why-text">
                                <h4>
                                    <a href='<%#Eval("RewriteURL")%>'><%# Eval("ProductName")%></a>
                                </h4>
                                <h5><%#  Eval("Price", "{0:#,##}") %> VNĐ</h5>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
        </div>

        <!-- VIEW MORE -->
        <div class="container middle-col">
            <div class="price-box-bar">
                <div class="cart-and-bay-btn">
                    <a class="btn hvr-hover" data-fancybox-close="" href="/san-pham/index.html">Xem Thêm </a>
                </div>
            </div>
        </div>

    </div>
</div>


<%--
<div id="products-tab" class="wow fadeInUp">
    <div class="container">
        <div class="tab-holder">
            <!-- Nav tabs -->
            <ul class="nav nav-tabs">
                <li class="active"><a href="#featured" data-toggle="tab">Sản phẩm nổi bật</a></li>
                <li><a href="#new-arrivals" data-toggle="tab">Sản phẩm mới</a></li>                
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
                <div class="tab-pane active" id="featured">
                    <div class="product-grid-holder">
                        <asp:Repeater ID="rptHot" runat="server" onitemcommand="rptHot_ItemCommand">
                        <ItemTemplate>
                            <div class="col-sm-4 col-md-3  no-margin product-item-holder hover">
                                <div class="product-item">                                    
                                    <div class="image">
                                        <a href='<%#Eval("RewriteURL")%>'><img alt="" src="~/assets/images/blank.gif" data-echo='<%# Eval("ImgLink1")%>' /></a>
                                    </div>
                                    <div class="body">                                        
                                        <div class="title">
                                            <a href='<%#Eval("RewriteURL")%>'><%# Eval("ProductName")%></a>
                                        </div>
                                        <div class="brand">
                                            <%# Eval("ProducerName")%></div>
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                                    </div>
                                    <div class="prices">
                                        <div class="price-prev">Giá</div>
                                        <div class="price-current pull-right"><a href="~/lien-he/index.html">Liên hệ</a></div>
                                    </div>
                                    <div class="hover-area">
                                        <div class="add-cart-button">                                            
                                            <asp:LinkButton ID="lkbOrder" runat="server" CssClass="le-button" CommandName ="AddCart">Đặt hàng</asp:LinkButton>
                                        </div>                                        
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <div class="loadmore-holder text-center">
                        <a class="btn-loadmore" href="~/san-pham/index.html"><i class="fa fa-plus"></i> Xem thêm sản phẩm</a>
                    </div>
                </div>
                <div class="tab-pane" id="new-arrivals">
                    <div class="product-grid-holder">
                        <asp:Repeater ID="rptNew" runat="server" onitemcommand="rptNew_ItemCommand">
                        <ItemTemplate>
                            <div class="col-sm-4 col-md-3  no-margin product-item-holder hover">
                                <div class="product-item">     
                                    <div class="ribbon blue">
                                    <span>Mới!</span></div>                               
                                    <div class="image">
                                        <a href='<%#Eval("RewriteURL")%>'><img alt="" src="~/assets/images/blank.gif" data-echo='<%# Eval("ImgLink1")%>' /></a>
                                    </div>
                                    <div class="body">                                        
                                        <div class="title">
                                            <a href='<%#Eval("RewriteURL")%>'><%# Eval("ProductName")%></a>
                                        </div>
                                        <div class="brand">
                                            <%# Eval("ProducerName")%></div>
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                                    </div>                                    
                                    <div class="prices">
                                        <div class="price-prev">Giá</div>
                                        <div class="price-current pull-right"><a href="~/lien-he/index.html">Liên hệ</a></div>
                                    </div>
                                    <div class="hover-area">
                                        <div class="add-cart-button">                                            
                                            <asp:LinkButton ID="lkbOrder" runat="server" CssClass="le-button" CommandName ="AddCart">Đặt hàng</asp:LinkButton>
                                        </div>                                        
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        </asp:Repeater>                        
                    </div>
                    <div class="loadmore-holder text-center">
                        <a class="btn-loadmore" href="~/san-pham/index.html"><i class="fa fa-plus"></i> Xem thêm sản phẩm</a>
                    </div>
                </div>  
            </div>
        </div>
    </div>
</div>--%>
