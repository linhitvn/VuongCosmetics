<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductDetailNew.ascx.cs" Inherits="controls_content_cProductDetailNew" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!-- Start All Title Box -->
<div class="all-title-box">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="title-all text-center">
                    <h1>VIPHARMA CGMP-ASEAN </h1>
                    <p>Dòng Mỹ phẩm Thương hiệu Độc quyền của VIPHARMA CO., LTD. </p>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- End All Title Box -->
<!-- Start Shop Detail  -->
<div class="shop-detail-box-main">
    <div class="container">

        <div class="row">
            <div class="col-xl-5 col-lg-5 col-md-6">
                <div class="large-image">
                    <asp:Image ID="imgLink" runat="server" CssClass="img-fluid" AlternateText="" />
                </div>
            </div>
            <div class="col-xl-7 col-lg-7 col-md-6">
                <div class="single-product-details">
                    <h1>
                        <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></h1>
                    <h5><del>
                        <asp:Label ID="lblSalePrice" runat="server" Text=""></asp:Label>
                    </del>
                        <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label>
                        VNĐ</h5>
                    <p class="available-stock">
                        <%--<span>Còn hàng </span>--%>
                        <asp:Label ID="lblOutofStock" runat="server" Text=""></asp:Label>
                    </p>
                    <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                    <asp:Panel ID="pnlOutofStock" runat="server">
                    <h4>Số lượng đặt mua:</h4>
                    <ul>
                        <li>
                            <div class="form-group quantity-box">
                                <telerik:RadNumericTextBox RenderMode="Lightweight" ID="txtQuantity" runat="server" Value="1" MinValue="1" MaxLength="2" MaxValue="50" Type="Number" EnableEmbeddedSkins="false" ShowSpinButtons="true" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                            </div>
                        </li>
                    </ul>

                    <div class="price-box-bar">
                        <div class="cart-and-bay-btn">
                            <asp:Label ID="lblPID" runat="server" Text="0" Visible="false"></asp:Label>
                            <asp:LinkButton ID="lkbAddCart" runat="server" CssClass="btn hvr-hover" OnClick="lkbAddCart_Click">Đặt Mua</asp:LinkButton>
                        </div>
                    </div>
                    </asp:Panel>
                </div>
            </div>
        </div>

        <!-- YOU MAY ALSO LIKE -->
        <div class="row my-5">
            <div class="col-lg-12">
                <div class="title-all">
                    <h2>Có thể bạn cũng thích </h2>
                    <p>Tất cả sản phẩm tại The Vuong's Cosmetics mang thương hiệu VIPHARMA CGMP-ASEAN đều được sản xuất tại nhà máy đạt chuẩn CGMP.... </p>
                </div>
                <div class="featured-products-box owl-carousel owl-theme">
                    <asp:Repeater ID="rptRelateProduct" runat="server" OnItemCommand="rptRelateProduct_ItemCommand">
                        <ItemTemplate>
                            <div class="item">
                                <div class="products-single fix">
                                    <div class="box-img-hover">
                                        <img alt='<%# Eval("ProductName")%>' src='<%# Eval("ImgLink1")%>' data-echo="/assets/images/products/pro_M_001.png" class="img-fluid" />
                                        <div class="mask-icon">
                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                                            <asp:LinkButton ID="lkbOrder" runat="server" CssClass="cart" CommandName="AddCart">Đặt Mua</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="why-text">
                                        <h4>
                                            <a href='<%# Eval("RewriteURL")%>'><%# Eval("ProductName")%></a>
                                        </h4>
                                        <h5><%# Eval("Price","{0:#,##}")%> VNĐ</h5>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <!-- YOU MAY ALSO LIKE -->

    </div>
</div>
<!-- End Cart -->
