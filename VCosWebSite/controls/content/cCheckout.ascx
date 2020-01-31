<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cCheckout.ascx.cs" Inherits="controls_content_cCheckout" %>
<!-- ========================================= CONTENT ========================================= -->
<section id="checkout-page">
    <div class="container">
        <div class="col-xs-12 no-margin">
            
            <div class="billing-address">
                <h2 class="border h1">Địa chỉ đơn hàng</h2>  
                <p><asp:Label ID="lblMessege" runat="server" Text="" style="color: red;"></asp:Label></p>
                    <div class="row field-row">
                        <div class="col-xs-12">
                            <label>Họ tên*</label>                            
                            <asp:TextBox ID="txtFullName" runat="server" CssClass="le-input"></asp:TextBox>                            
                        </div>                        
                    </div><!-- /.field-row -->

                    <div class="row field-row">
                        <div class="col-xs-12">
                            <label>Địa chỉ*</label>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="le-input"></asp:TextBox>
                        </div>
                    </div><!-- /.field-row -->

                    <div class="row field-row">
                        <div class="col-xs-12 col-sm-6">
                            <label>Địa chỉ Email*</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="le-input"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label>Số điện thoại*</label>
                            <asp:TextBox ID="txtTel" runat="server" CssClass="le-input"></asp:TextBox>
                        </div>
                    </div>

            </div><!-- /.billing-address -->
            
            <section id="your-order">
                <h2 class="border h1">Chi tiết đơn hàng</h2>
                <asp:Repeater ID="rptOrder" runat="server">
                <ItemTemplate>
                    <div class="row no-margin order-item">
                        <div class="col-xs-12 col-sm-1 no-margin">
                            <a href="#" class="qty"><%# Eval("Quantity")%></a>
                        </div>
                        <div class="col-xs-12 col-sm-9 ">
                            <div class="title"><a href='<%# Eval("RewriteURL")%>'><%# Eval("ProductName")%></a></div>
                            <div class="brand"><%# Eval("ProducerName")%></div>
                            <%--<div class=""><%# Eval("ProductCode")%></div>--%>
                        </div>

                        <div class="col-xs-12 col-sm-2 no-margin">
                            <div class="price"><%# Eval("Price", "{0:#,##}")%> Vnd</div>
                        </div>
                    </div>
                </ItemTemplate>
                </asp:Repeater> 
            </section><!-- /#your-order -->

            <div id="total-area" class="row no-margin">
                <div class="col-xs-12 col-lg-4 col-lg-offset-8 no-margin-right">
                    <div id="subtotal-holder">
                        <ul class="tabled-data inverse-bold no-border">
                            <li>
                                <label>Số lượng</label>
                                <div class="value "><asp:Label ID="lblQuantity" runat="server" Text="0"></asp:Label></div>
                            </li>
                           <%-- <li>
                                <label>Giao Hàng</label>
                                <div class="value pull-right">Miễn phí nội thành</div>
                            </li>--%>
                        </ul><!-- /.tabled-data -->

                        <!--<ul id="total-field" class="tabled-data inverse-bold ">
                            <li>
                                <label>order total</label>
                                <div class="value">$8434.00</div>
                            </li>
                        </ul> -->

                    </div><!-- /#subtotal-holder -->
                </div><!-- /.col -->
            </div><!-- /#total-area -->
                       
            <div class="place-order-button">                
                <asp:Button ID="btnBuy" runat="server" CssClass="le-button big" Text="Mua hàng" 
                    onclick="btnBuy_Click"></asp:Button>
            </div><!-- /.place-order-button -->

        </div><!-- /.col -->
    </div><!-- /.container -->    
</section>
<!-- /#checkout-page -->
<!-- ========================================= CONTENT : END ========================================= -->
