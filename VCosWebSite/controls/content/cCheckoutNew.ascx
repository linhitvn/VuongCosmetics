<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cCheckoutNew.ascx.cs" Inherits="controls_content_cCheckoutNew" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!-- Start All Title Box -->
<div class="all-title-box">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="title-all text-center">
                    <h1>Thủ tục thanh toán đơn hàng </h1>
                    <p>
                        <%-- Chúc mừng bạn đã đặt hàng thành công!
                        <br>--%>
                        Vui lòng nhập đầy đủ thông tin cần thiết bên dưới để hoàn tất đơn hàng.
                        <br>
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- End All Title Box -->
<!-- Start Cart  -->
<div class="cart-box-main">
    <div class="container">
        <div class="row new-account-login">
            <div class="col-sm-6 col-lg-6 mb-3">
                <h3>
                    <asp:Label ID="lblMessege" runat="server" Text="" Style="color: red;"></asp:Label></h3>
            </div>
        </div>
        <!-- Shipping Info -->
        <div class="row">
            <div class="col-sm-6 col-lg-6 mb-3">
                <div class="checkout-address">
                    <div class="title-left">
                        <h3>Thông tin nhận hàng</h3>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="firstName">Tên *</label>
                            <input type="text" runat="server" id="txtFirstName" class="form-control" name="name" placeholder="Ex: Quỳnh Hoa ..." required data-error="Vui lòng nhập Tên của bạn">
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="lastName">Họ *</label>
                            <input type="text" runat="server" id="txtLastName" class="form-control" name="name" placeholder="Ex: Lê ..." required data-error="Vui lòng nhập Họ của bạn">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="email">Địa chỉ Email *</label>
                            <input type="text" runat="server" id="txtEmail" class="form-control" name="name" placeholder="Ex: hoa.abc@gmail.com" required data-error="Vui lòng nhập Địa chỉ Email.">
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="address">Điện thoại *</label>
                            <input type="text" runat="server" id="txtTel" class="form-control" name="name" placeholder="09xx.xxx" required data-error="Vui lòng nhập Số điện thoại.">
                        </div>
                    </div>
                    <div class="mb-3">
                        <label for="address">Địa chỉ nhận hàng *</label>
                        <input type="text" runat="server" id="txtAddress" class="form-control" name="name" placeholder="Ex: 123 đường abc, phường xx" required data-error="Vui lòng nhập Địa chỉ nhận hàng.">
                    </div>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                        <div class="row">

                            <div class="col-md-3 mb-3">
                                <label for="country">Quốc gia *</label>
                                <select class="wide w-100" id="country">
                                    <option data-display="Select">Việt Nam</option>
                                </select>
                            </div>
                            <div class="col-md-4 mb-3">
                                <label for="city">Thành phố *</label>
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="wide w-100" DataTextField="Province" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-5 mb-3">
                                <label for="city">Quận/Huyện *</label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="wide w-100" DataTextField="District" DataValueField="ID"></asp:DropDownList>
                            </div>

                        </div>
                    </telerik:RadAjaxPanel>
                    <div class="title"><span>Phương thức thanh toán </span></div>
                    <hr class="mb-4">
                    <div class="d-block my-3">
                        <%--<div class="custom-control custom-radio">
                            <input id="credit" name="paymentMethod" type="radio" class="custom-control-input" checked required>
                            <label class="custom-control-label" for="credit">Thanh toán tiền mặt khi nhận hàng</label>
                        </div>
                        <div class="custom-control custom-radio">
                            <input id="debit" name="paymentMethod" type="radio" class="custom-control-input" required>
                            <label class="custom-control-label" for="debit">Chuyển khoản</label>
                        </div>--%>
                        <div class="custom-control" style="padding-left:0px !important;">
                        <asp:RadioButtonList id="rblPayment" runat="server">
                            <asp:ListItem Selected="True" Text=" &nbsp; &nbsp;Thanh toán tiền mặt khi nhận hàng" Value="1"></asp:ListItem>
                            <asp:ListItem Text=" &nbsp; &nbsp;Chuyển khoản" Value="3"></asp:ListItem>
                         </asp:RadioButtonList>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-sm-6 col-lg-6 mb-3">
                <div class="odr-box">
                    <div class="title-left">
                        <h3>Chi tiết giỏ hàng </h3>
                    </div>
                    <div class="p-2 bg-light">
                        <asp:Repeater ID="rptOrder" runat="server">
                            <ItemTemplate>
                                <div class="media mb-2 border-bottom">
                                    <div class="media-body">
                                        <a href="#"><%# Eval("ProductName")%> </a>
                                        <div class="small text-muted">Giá tiền: <%# Eval("Price","{0:#,##}")%> VNĐ <span class="mx-2">|</span> SL: <%# Eval("Quantity") %> <span class="mx-2">|</span> Subtotal: <%# Eval("TotalPrice","{0:#,##}")%> VNĐ</div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="odr-box">
                    <div class="title-left">
                        <h3>Chi tiết đơn hàng </h3>
                    </div>

                    <div class="d-flex">
                        <div class="font-weight-bold">Mặt hàng </div>
                        <div class="ml-auto font-weight-bold">Thành tiền </div>
                    </div>
                    <hr>
                    <div class="d-flex">
                        <span>Giá tiền sản phẩm</span>
                        <div class="ml-auto font-weight-bold">
                            <asp:Label ID="lblSumOrder" runat="server" Text="0"></asp:Label>
                            VNĐ</div>
                    </div>
                    <div class="d-flex">
                        <span>Thuế VAT</span>
                        <div class="ml-auto font-weight-bold">
                            <asp:Label ID="lblTax" runat="server" Text="0"></asp:Label>
                            VNĐ</div>
                    </div>
                    <div class="d-flex">
                        <span>Phí vận chuyển</span>
                        <div class="ml-auto font-weight-bold">Miễn phí </div>
                    </div>
                    <hr>
                    <div class="d-flex gr-total">
                        <h7>Tổng cộng:</h7>
                        <div class="ml-auto h5">
                            <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                            VNĐ </div>
                    </div>
                </div>

                <div class="odr-box">
                    <div class="small text-muted">Nhấn nút <strong>"Hoàn tất mua hàng" </strong>bên dưới. Chúng tôi sẽ gửi email và liện hệ xác nhận với bạn trong thời gian sớm nhất. Cảm ơn bạn! </div>
                </div>

                <div class="col-12 d-flex">
                    <asp:Button ID="btnBuy" runat="server" Text="Hoàn tất mua hàng" CssClass="ml-auto btn hvr-hover" Visible="false" OnClick="btnBuy_Click"></asp:Button>
                </div>
            </div>
        </div>

    </div>
</div>
<!-- End Cart -->
