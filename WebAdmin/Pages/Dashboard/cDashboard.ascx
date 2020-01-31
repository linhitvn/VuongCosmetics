<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cDashboard.ascx.cs" Inherits="Pages_Dashboard_cDashboard" %>


<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-dashboard"></i>&nbsp;&nbsp;Dashboard
        <small>it all starts here</small>
    </h1>
</section>

<div runat="server" id="message_box">
</div>

<!-- Main content -->
<section class="content">
    <div class="row">
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-aqua">
                <div class="inner">
                    <h3 runat="server" id="fOrderNumber">
                    </h3>
                    <p>
                        Đơn hàng
                    </p>
                </div>
                <div class="icon">
                    <i class="ion ion-bag"></i>
                </div>
                <a runat="server" href="~/?module=201" class="small-box-footer">Quản lý đơn hàng <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-green">
                <div class="inner">
                    <h3 runat="server" id="fProductNumber">
                    </h3>
                    <p>
                        Sản phẩm
                    </p>
                </div>
                <div class="icon">
                    <i class="ion ion-stats-bars"></i>
                </div>
                <a runat="server" href="~/?module=302" class="small-box-footer">Quản lý sản phẩm <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-yellow">
                <div class="inner">
                    <h3 runat="server" id="fCustomerNumber"></h3>
                    <p>
                        Khách hàng
                    </p>
                </div>
                <div class="icon">
                    <i class="ion ion-person-add"></i>
                </div>
                <a runat="server" href="~/?module=401" class="small-box-footer">Quản lý khách hàng <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-red">
                <div class="inner">
                    <h3 runat="server" id="fNewsNumber"></h3>
                    <p>
                        Bài viết - tin tức
                    </p>
                </div>
                <div class="icon">
                    <i class="ion ion-pie-graph"></i>
                </div>
                <a href="/?module=702" class="small-box-footer">Quản lý bài viết <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <!-- ./col -->
    </div>
    <div class="row">
        <%--<div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-aqua">
                <div class="inner">
                    <h3>UhChat
                    </h3>
                    <p>&nbsp;</p>
                </div>
                <div class="icon">
                    <i class="ion ion-person-add"></i>
                </div>
                <a runat="server" href="http://uhchat.net/admin/" class="small-box-footer" target="_blank">Chat Online <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>--%>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-green">
                <div class="inner">
                    <h3>Google Analytics
                    </h3>
                    <p>
                        Thống kê theo dõi người dùng
                    </p>
                </div>
                <div class="icon">
                    <i class="ion ion-stats-bars"></i>
                </div>
                <a runat="server" href="https://analytics.google.com/analytics/web" class="small-box-footer" target="_blank">Xem chi tiết <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <!-- ./col -->
        <%--<div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-yellow">
                <div class="inner">
                    <h3>Google Adwords
                    </h3>
                    <p>
                        Quảng cáo Google
                    </p>
                </div>
                <div class="icon">
                    <i class="fa fa-calendar"></i>
                </div>
                <a runat="server" href="https://adwords.google.com.vn/" class="small-box-footer" target="_blank">Xem chi tiết <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>--%>
        <!-- ./col -->
    </div>
    <div class="row">
        <!-- Col Right -->
        <section class="col-lg-7 connectedSortable ui-sortable">
            <!-- Đơn hàng mới -->
            <div class="box box-primary" style="position: relative;">
                <div class="box-header ui-sortable-handle" style="cursor: move;">
                    <i class="fa fa-share"></i>
                    <h3 class="box-title"><a runat="server" href="~/?module=201" class="small-box-footer">Đơn hàng mới</a></h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <telerik:RadGrid ID="RadGrid_Orders" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"
                        GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False" PageSize="8"
                        AllowMultiRowSelection="true" AllowFilteringByColumn="false"
                        OnItemCommand="RadGrid_Orders_ItemCommand" OnNeedDataSource="RadGrid_Orders_NeedDataSource">
                        <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="RowNo" HeaderText="STT" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# (Container.ItemIndex + (RadGrid_Orders.CurrentPageIndex * RadGrid_Orders.PageSize) + 1).ToString()%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="CustomerName" UniqueName="CustomerName" HeaderText="Tên khách hàng" ShowFilterIcon="false">
                                    <HeaderStyle Width="35%" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OrderStatus" UniqueName="OrderStatus" HeaderText="trạng thái" ShowFilterIcon="false">
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TotalNeedPay" UniqueName="TotalNeedPay" DataFormatString="{0:###,###}" HeaderText="Giá trị" ShowFilterIcon="false">
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SysDate" UniqueName="SysDate" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" HeaderText="Ngày đặt" ShowFilterIcon="false">
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn ShowFilterIcon="false" AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" CommandName='<%# ActRow.Edit %>'
                                            CommandArgument='<%# Eval("ID") %>' runat="server"
                                            ImageUrl="~/images/edit.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings>
                            <Selecting AllowRowSelect="true"></Selecting>
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- Biểu đồ lượng đặt hàng -->
            <%--<div class="box box-primary">
                <div class="box-header">
                    <i class="fa fa-share"></i>
                    <h3 class="box-title">Biểu đồ lượng đặt hàng</h3>
                </div>
                <div class="box-body chart-responsive">
                    <div class="chart" id="graph-orders" style="height: 300px;"></div>
                </div><!-- /.box-body -->
            </div><!-- /.box -->--%>
            <!-- quick email widget -->
            <%--<div class="box box-info">
                <div class="box-header">
                    <i class="fa fa-envelope"></i>
                    <h3 class="box-title">Quick Email</h3>
                    <!-- tools box -->
                    <div class="pull-right box-tools">
                        <button class="btn btn-info btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div><!-- /. tools -->
                </div>
                <div class="box-body">
                    <form action="#" method="post">
                        <div class="form-group">
                            <input type="email" class="form-control" name="emailto" placeholder="Email to:"/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name="subject" placeholder="Subject"/>
                        </div>
                        <div>
                            <textarea class="textarea" placeholder="Message" style="width: 100%; height: 125px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></textarea>
                        </div>
                    </form>
                </div>
                <div class="box-footer clearfix">
                    <button class="pull-right btn btn-default" id="sendEmail">Send <i class="fa fa-arrow-circle-right"></i></button>
                </div>
            </div>--%>
        </section>
        <!-- Col Right -->
        <section class="col-lg-5 connectedSortable ui-sortable">
            <!-- Biểu đồ số lượng khách hàng vào Website -->
            <%--<div class="box box-primary">
                <div class="box-header">
                    <i class="fa fa-share"></i>
                    <h3 class="box-title">Khách hàng vào Website</h3>
                </div>
                <div class="box-body chart-responsive">
                    <div class="chart" id="customer-visited" style="height: 300px;"></div>
                </div><!-- /.box-body -->
            </div><!-- /.box -->--%>
            <!-- Calendar -->
            <div class="box box-solid bg-green-gradient">
                <div class="box-header">
                    <i class="fa fa-calendar"></i><h3 class="box-title">Calendar</h3>
                    <!-- tools box -->
                    <div class="pull-right box-tools">
                        <!-- button with a dropdown -->
                        <%--<div class="btn-group">
                          <button type="button" class="btn btn-success btn-sm dropdown-toggle" data-toggle="dropdown">
                            <i class="fa fa-bars"></i></button>
                          <ul class="dropdown-menu pull-right" role="menu">
                            <li><a href="#">Add new event</a></li>
                            <li><a href="#">Clear events</a></li>
                            <li class="divider"></li>
                            <li><a href="#">View calendar</a></li>
                          </ul>
                        </div>--%>
                        <button type="button" class="btn btn-success btn-sm" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                        <%--<button type="button" class="btn btn-success btn-sm" data-widget="remove"><i class="fa fa-times"></i>
                        </button>--%>
                    </div>
                    <!-- /. tools -->
                </div>
                <!-- /.box-header -->
                <div class="box-body no-padding">
                    <!--The calendar -->
                    <div id="calendar" style="width: 100%"></div>
                </div>
            </div>
        </section>
    </div>
</section>
<!-- /.content -->

<script type="text/javascript">

    $(function () {
        "use strict";

        //The Calender
        $("#calendar").datepicker();

        //SLIMSCROLL FOR CHAT WIDGET
        $('#chat-box').slimScroll({
            height: '250px'
        });



        /* Morris.js Charts */
        // customer-visited
        var area = new Morris.Area({
            element: 'customer-visited',
            resize: true,
            data: [
            { y: '2011 Q1', item1: 2666, item2: 2666 },
            { y: '2011 Q2', item1: 2778, item2: 2294 },
            { y: '2011 Q3', item1: 4912, item2: 1969 },
            { y: '2011 Q4', item1: 3767, item2: 3597 },
            { y: '2012 Q1', item1: 6810, item2: 1914 },
            { y: '2012 Q2', item1: 5670, item2: 4293 },
            { y: '2012 Q3', item1: 4820, item2: 3795 },
            { y: '2012 Q4', item1: 15073, item2: 5967 },
            { y: '2013 Q1', item1: 10687, item2: 4460 },
            { y: '2013 Q2', item1: 8432, item2: 5713 }
            ],
            xkey: 'y',
            ykeys: ['item1', 'item2'],
            labels: ['Item 1', 'Item 2'],
            lineColors: ['#a0d0e0', '#3c8dbc'],
            hideHover: 'auto'
        });


        // graph-orders
        var area_orders = new Morris.Area({
            element: 'graph-orders',
            resize: true,
            data: [
            { y: '2011 Q1', item1: 2666, item2: 2666 },
            { y: '2011 Q2', item1: 2778, item2: 2294 },
            { y: '2011 Q3', item1: 4912, item2: 1969 },
            { y: '2011 Q4', item1: 3767, item2: 3597 },
            { y: '2012 Q1', item1: 6810, item2: 1914 },
            { y: '2012 Q2', item1: 5670, item2: 4293 },
            { y: '2012 Q3', item1: 4820, item2: 3795 },
            { y: '2012 Q4', item1: 15073, item2: 5967 },
            { y: '2013 Q1', item1: 10687, item2: 4460 },
            { y: '2013 Q2', item1: 8432, item2: 5713 }
            ],
            xkey: 'y',
            ykeys: ['item1', 'item2'],
            labels: ['Item 1', 'Item 2'],
            lineColors: ['#a0d0e0', '#3c8dbc'],
            hideHover: 'auto'
        });

        //Make the dashboard widgets sortable Using jquery UI
        $(".connectedSortable").sortable({
            placeholder: "sort-highlight",
            connectWith: ".connectedSortable",
            handle: ".box-header, .nav-tabs",
            forcePlaceholderSize: true,
            zIndex: 999999
        }).disableSelection();
        $(".connectedSortable .box-header, .connectedSortable .nav-tabs-custom").css("cursor", "move");
        //jQuery UI sortable for the todo list
        $(".todo-list").sortable({
            placeholder: "sort-highlight",
            handle: ".handle",
            forcePlaceholderSize: true,
            zIndex: 999999
        }).disableSelection();
        ;
    });
</script>
