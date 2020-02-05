<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cOrder.ascx.cs" Inherits="controls_content_cOrder" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!-- Start All Title Box -->
<div class="all-title-box">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="title-all text-center">
                    <h1>Giỏ hàng của bạn </h1>
                    <p>Chúc mừng bạn...</p>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- End All Title Box -->

<!-- Start Cart  -->
<div class="cart-box-main">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="table-main table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Hình ảnh</th>
                                <th>Tên sản phẩm</th>
                                <th>Giá tiền</th>
                                <th>Số lượng</th>
                                <th>Thành tiền</th>
                                <th>Hủy mua</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptOrder" runat="server" onitemcommand="rptOrder_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td class="thumbnail-img">
                                        <a href='<%# Eval("RewriteURL")%>' class="photo">
                                            <img alt='<%# Eval("ProductName")%>' src='<%# Eval("ImgLink1")%>' class="img-fluid" />
                                        </a>
                                    </td>
                                    <td class="name-pr">
                                        <a href='<%# Eval("RewriteURL")%>'>
                                            <%# Eval("ProductName")%>
                                        </a>
                                    </td>
                                    <td class="price-pr">
                                        <p><%# Eval("Price","{0:#,##}")%> VNĐ</p>
                                    </td>
                                    <td class="quantity-box">
                                        <telerik:RadNumericTextBox RenderMode="Lightweight" ID="txtQuantity" runat="server" Value='<%# Convert.ToInt32(Eval("Quantity")) %>' MinValue="1" MaxLength="2" MaxValue="50" Type="Number" EnableEmbeddedSkins="false" ShowSpinButtons="true" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                                    </td>
                                    <td class="total-pr">
                                        <p><%# Eval("TotalPrice","{0:#,##}")%> VNĐ</p>
                                    </td>
                                    <td class="remove-pr">
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>  
                                        <asp:LinkButton ID="lkbRemoveCart" runat="server" CssClass="cart" CommandName ="RemoveCart"><i class="fas fa-times"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <%--<div class="row my-5">
            <div class="col-lg-6 col-sm-6">
                <div class="coupon-box">
                        <div class="input-group input-group-sm">
                            <input class="form-control" placeholder="Nhập mã giảm giá (nếu có)" aria-label="Coupon code" type="text">
                            <div class="input-group-append">
                                <button class="btn btn-theme" type="button">Apply Coupon</button>
                            </div>
                        </div>
                    </div>
            </div>
            <div class="col-lg-6 col-sm-6">
                <div class="update-box">
                    <input value="Cập nhật đơn hàng" type="submit">
                </div>
            </div>
        </div>--%>

        <div class="row my-5">
            <div class="col-lg-8 col-sm-12"></div>
            <div class="col-lg-4 col-sm-12">
                <div class="order-box">
                    <h3>Chi tiết đơn hàng</h3>
                    <div class="d-flex">
                        <span>Giá tiền sản phẩm</span>
                        <div class="ml-auto font-weight-bold"><asp:Label ID="lblSumOrder" runat="server" Text="0"></asp:Label> </div>
                    </div>
                    <div class="d-flex">
                        <span>Thuế</span>
                        <div class="ml-auto font-weight-bold"><asp:Label ID="lblTax" runat="server" Text="0"></asp:Label> </div>
                    </div>
                    <div class="d-flex">
                        <span>Phí vận chuyển</span>
                        <div class="ml-auto font-weight-bold">Miễn phí </div>
                    </div>
                    <hr>
                    <div class="d-flex gr-total">
                        <h7>Tổng cộng</h7>
                        <div class="ml-auto h5"><asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label> VNĐ </div>
                    </div>

                    <div class="small text-muted">Bấm nút <strong>"Thanh toán đơn hàng" </strong>bên dưới để chọn phương thức giao hàng - thanh toán....</div>

                </div>
            </div>
            <!-- CHECK-OUT Button -->
            <div class="col-12 d-flex my-5">
                <a class="ml-auto btn hvr-hover" href="/san-pham/index.html" >Tiếp tục mua hàng</a>&nbsp; &nbsp;
                <asp:LinkButton ID="lkbBuy" runat="server" CssClass="btn hvr-hover" 
                            Visible="false" onclick="lkbBuy_Click">Thanh toán đơn hàng</asp:LinkButton>
                
            </div>
            <!-- CHECK-OUT Button -->
        </div>
    </div>
</div>
<!-- End Cart -->
<!-- Start Similar Products  -->
<div class="shop-detail-box-main">
    <div class="container">
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
                                        <img alt='<%# Eval("ProductName")%>' src='<%# Eval("ImgLink1")%>' class="img-fluid" />
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
<!-- End -->
