<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cCart.ascx.cs" Inherits="controls_content_cCart" %>
<section id="cart-page">
    <div class="container">
        <!-- ========================================= CONTENT ========================================= -->
        <div class="col-xs-12 col-md-9 items-holder no-margin">
            <asp:Repeater ID="rptOrder" runat="server" onitemcommand="rptOrder_ItemCommand">
            <ItemTemplate>
                <div class="row no-margin cart-item">
                    <div class="col-xs-12 col-sm-2 no-margin">
                        <a href='<%# Eval("RewriteURL")%>' class="thumb-holder">
                            <img class="lazy" alt="" src='<%# Eval("ImgLink1")%>' style="width: 145px;" />
                        </a>
                    </div>

                    <div class="col-xs-12 col-sm-5 ">
                        <div class="title">
                            <a href='<%# Eval("RewriteURL")%>'><%# Eval("ProductName")%></a>
                        </div>
                        <div class="brand"><%# Eval("ProductCode")%></div>
                        <div class=""><%# Eval("ProducerName")%></div>
                    </div> 

                    <div class="col-xs-12 col-sm-3 no-margin">
                        <div class="quantity">
                            <div class="le-quantity">                                
                                <a class="minus" href="#reduce"></a>
                                <%--<input name="quantity" readonly="readonly" type="text" value="1" />--%>
                                <asp:TextBox ID="txtQuantity" runat="server" Text= '<%# Eval("Quantity")%>' ReadOnly="true"></asp:TextBox>
                                <a class="plus" href="#add"></a>                                
                            </div>
                        </div>
                    </div> 

                    <div class="col-xs-12 col-sm-2 no-margin">
                        <div class="price">
                            <%# Eval("Price")%> Vnd
                        </div>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>   
                        <asp:LinkButton ID="lkbDel" runat="server" CssClass="close-btn" CommandName ="Delete" ></asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
            </asp:Repeater>            
        </div>
        <!-- ========================================= CONTENT : END ========================================= -->

        <!-- ========================================= SIDEBAR ========================================= -->

        <div class="col-xs-12 col-md-3 no-margin sidebar ">
            <div class="widget cart-summary">
                <h1 class="border">Giỏ hàng</h1>
                <div class="body">
                    <ul class="tabled-data no-border inverse-bold">
                        <li>
                            <label>Số lượng</label>
                            <div class="value pull-right"><asp:Label ID="lblQuantity" runat="server" Text="0"></asp:Label></div>
                        </li>
                        <%--<li>
                            <label>Giao hàng</label>
                            <div class="value pull-right">Miễn phí nội thành</div>
                        </li>--%>
                    </ul>
                    <ul id="total-price" class="tabled-data inverse-bold no-border">
                        <li>
                            <%--<label>order total</label>
                            <div class="value pull-right">$8434.00</div>--%>
                        </li>
                    </ul>
                    <div class="buttons-holder">                        
                        <%--<a class="le-button big" href="?s=BUY" runat="server" id="btnBuy" visible="false"></a>--%>
                        <asp:LinkButton ID="lkbBuy" runat="server" CssClass="le-button big" 
                            Visible="false" onclick="lkbBuy_Click">Đặt hàng</asp:LinkButton>
                        <a class="simple-link block" href="~/san-pham/index.html" >Tiếp tục mua hàng</a>
                    </div>
                </div>
            </div><!-- /.widget -->
            
        </div><!-- /.sidebar -->

        <!-- ========================================= SIDEBAR : END ========================================= -->
    </div>
</section>
