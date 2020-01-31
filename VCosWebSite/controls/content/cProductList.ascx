<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductList.ascx.cs" Inherits="controls_content_cProductList" %>

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

<!-- Start latest Products  -->
<div class="products-box">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="title-all">
                    <h2>Danh mục sản phẩm </h2>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="special-menu">
                    <div class="button-group filter-button-group">
                        <label class="active" data-filter="*">Tất cả </label>
                        <asp:Repeater ID="rptProductCate" runat="server">
                            <ItemTemplate>
                                <label data-filter=".<%# Eval("ID")%>"> <%# Eval("ProductCat")%></label>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>

        <div class="row special-list">
            <asp:Repeater ID="rptProList" runat="server" OnItemCommand="rptProList_ItemCommand">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-6 special-grid <%# Eval("ProductCatID")%>">
                        <div class="products-single fix">
                            <div class="box-img-hover">
                                <img alt='<%# Eval("ProductName")%>' src='<%# Eval("ImgLink1")%>' data-echo="/assets/images/products/pro_M_001.png" class="img-fluid" />
                                <div class="mask-icon">
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lkbOrder" runat="server" CssClass="cart" CommandName ="AddCart">Thêm Vào Giỏ Hàng</asp:LinkButton>
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
<!-- End latest Products  -->
