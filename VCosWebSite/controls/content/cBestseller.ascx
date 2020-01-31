<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cBestseller.ascx.cs" Inherits="controls_content_cBestseller" %>
<!-- Start Featured Products  -->
<div class="shop-detail-box-main">
    <div class="container">
        <!-- YOU MAY ALSO LIKE -->
        <div class="row my-5">
            <div class="col-lg-12">
                <div class="title-all">
                    <h2>Sản phẩm nổi bật </h2>
                    <p>Tất cả sản phẩm tại The Vuong's Cosmetics mang thương hiệu VIPHARMA CGMP-ASEAN đều được sản xuất tại nhà máy đạt chuẩn CGMP.... </p>
                </div>
                <div class="featured-products-box owl-carousel owl-theme">
                    <asp:Repeater ID="rptHotProduct" runat="server" OnItemCommand="rptHotProduct_ItemCommand">
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
                                        <h5><%# Eval("Price", "{0:#,##}")%> VNĐ</h5>
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
<!-- End -->
