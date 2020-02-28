<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Packing.aspx.cs" Inherits="Pages_Order_InvoiceTemplate_Packing" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <title>Đóa Đơn</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons -->
    <link href="//code.ionicframework.com/ionicons/1.5.2/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="../../../css/AdminLTE.css" rel="stylesheet" type="text/css" />
    <link id="Link1" runat="server" href="~/css/MyStyle.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <!-- header logo: style can be found in header.less -->
        <!-- Main content -->
                <section class="content invoice">
                    <!-- title row -->
                    <div class="row">
                        <div class="col-xs-12">
                            <h2 class="page-header">
                                <i class="fa fa-globe"></i> The Vuong's Cosmetics
                                <small class="pull-right">Ngày: <% =DateTime.Now.ToShortDateString() %></small>
                            </h2>
                        </div><!-- /.col -->
                    </div>
                    <!-- info row -->
                    <div class="row invoice-info">
                        <div class="col-sm-4 invoice-col">
                            Thông tin thanh toán
                            <address>
                                <strong runat="server" id="fBillCustomer"></strong><br />
                                <label runat="server" id="lblBillCity"></label><br />
                                <label runat="server" id="fBillAddress"></label><br />
                                <label>SĐT: </label> <label runat="server" id="fBillPhone"></label><br/>
                            </address>
                        </div><!-- /.col -->
                        <div class="col-sm-4 invoice-col">
                            Địa chỉ giao hàng
                            <address>
                                <strong runat="server" id="fShipCustomer"></strong><br />
                                <label runat="server" id="lblShipCity"></label><br />
                                <label runat="server" id="fShipAddress"></label><br />
                                <label>SĐT: </label> <label runat="server" id="fShipPhone"></label><br/>
                            </address>
                        </div><!-- /.col -->
                        <div class="col-sm-4 invoice-col">
                            <b>Người đăt hàng:</b> <b runat="server" id="fCustomer"></b><br />
                            <b>Mã đơn hàng: </b><b runat="server" id="fOrdersID"></b><br/>
                            <b>Ngày đặt hàng:</b> <b runat="server" id="fSysDate"></b><br/>
                        </div><!-- /.col -->
                    </div><!-- /.row -->

                    <!-- Table row -->
                    <div class="row">
                        <div class="col-xs-12 table-responsive">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>Sản phẩm</th>
                                        <th>Mã SP</th>
                                        <th>Số lượng</th>
                                        <th>Thành tiền</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <asp:Repeater runat="server" ID="rptOrderDetail">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("ProductName") %></td>
                                                <td><%# Eval("ProductCode") %></td>
                                                <td><%# Eval("Quatity") %></td>
                                                <td>N/A</td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div><!-- /.col -->
                    </div><!-- /.row -->

                    <div class="row">
                        <!-- accepted payments column -->
                        <div class="col-xs-6">
                            <b>Phương thức thanh toán:</b><br/>
                            <p runat="server" id="fPaymentName" class="lead"></p>
                            <b>Phương thức giao hàng:</b><br/>
                            <p runat="server" id="fShippingName" class="lead"></p>
                        </div><!-- /.col -->
                        <div class="col-xs-6">
                            <div class="table-responsive">
                                <table class="table priceTotal">
                                    <tr>
                                        <th style="width:50%">Tổng tiền hàng:</th>
                                        <td runat="server" id="fTotalPrice">N/A</td>
                                    </tr>
                                    <tr>
                                        <th>Khuyến mãi giảm giá</th>
                                        <td runat="server" id="fDiscount">N/A</td>
                                    </tr>
                                    <tr>
                                        <th>Phí vận chuyển</th>
                                        <td runat="server" id="fShippingPrice">N/A</td>
                                    </tr>
                                    <tr>
                                        <th>Tổng cộng:</th>
                                        <td runat="server" id="fTotalNeedPay">N/A</td>
                                    </tr>
                                </table>
                            </div>
                        </div><!-- /.col -->
                    </div><!-- /.row -->
                </section><!-- /.content -->

        <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
        <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js" type="text/javascript"></script>
        <!-- AdminLTE App -->
        <script src="../../../js/AdminLTE/app.js" type="text/javascript"></script>
        <!-- AdminLTE for demo purposes -->
        <script src="../../../js/AdminLTE/demo.js" type="text/javascript"></script>
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            window.onload = function () {
                window.print();
                setTimeout(function () { window.close(); }, 1);
            }
            //            window.print();
            //            window.onfocus = function () { window.close(); }
        });
    </script>
</body>
</html>
