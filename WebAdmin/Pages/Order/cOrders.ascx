<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cOrders.ascx.cs" Inherits="Pages_Order_cOrders" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Danh sách đơn hàng
    </h1>
    <ol class="toolbar">
        <li>
            <button runat="server" id="btCreate" onserverclick="New_Click" class="btn btn-info btn-sm">
                <i class="fa fa-plus-square"></i>
                <span>Tạo mới</span>
            </button>
        </li>
        <%--<li><button runat="server" id="btClone" onserverclick="Clone_Click" class="btn btn-info btn-sm">
            <i class="fa fa-copy"></i>
            <span>Sao chép</span>
            </button>
       </li>--%>
        <li>
            <button runat="server" id="btDelete" onserverclick="Delete_Click" class="btn btn-info btn-sm">
                <i class="fa fa-trash-o"></i>
                <span>Xóa</span>
            </button>
        </li>
    </ol>
</section>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <div runat="server" id="message_box">
        </div>
        <section class="content">
            <div class="row pad">
                <div class="col-md-12" style="text-align: right; float: right;">
                    <label>
                        Khách hàng
                    </label>
                    <label>
                        <select runat="server" id="sCustomerID"
                            datatextfield="CustomerName" datavaluefield="ID" class="form-control input-sm">
                        </select>
                    </label>
                    <label>
                        Trạng thái
                    </label>
                    <label>
                        <select runat="server" id="sOrderStatus"
                            datatextfield="OrderStatus" datavaluefield="ID" class="form-control input-sm">
                        </select>
                    </label>
                    <label>
                        Từ ngày
                    </label>
                    <label>
                        <telerik:RadDatePicker ID="sFromDate" runat="server" Culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
                            <DatePopupButton ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" />
                            <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" />
                        </telerik:RadDatePicker>
                    </label>
                    <label>
                        Đến ngày
                    </label>
                    <label>
                        <telerik:RadDatePicker ID="sToDate" runat="server" Culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
                            <DatePopupButton ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" />
                            <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" />
                        </telerik:RadDatePicker>
                    </label>
                    <label>
                        <button runat="server" id="Button1" onserverclick="Search_Click" class="btn btn-info btn-sm">
                            <i class="fa fa-search"></i>
                            <span>Search</span>
                        </button>
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-body table-responsive">
                            <div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <%--<div class="row">
                            <div class="col-xs-6">
                                <div id="example1_length" class="dataTables_length">
                                    <label>
                                        <select size="1" name="example1_length" aria-controls="example1"></select> records per page
                                    </label>
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <div class="dataTables_filter" id="example1_filter">
                                    <label>Search: <input type="text" aria-controls="example1"></label>
                                </div>
                            </div>
                        </div>--%>
                                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                    <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"
                                        GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
                                        AllowMultiRowSelection="true" AllowFilteringByColumn="true"
                                        OnItemCommand="RadGrid1_ItemCommand" OnNeedDataSource="RadGrid1_NeedDataSource">
                                        <MasterTableView DataKeyNames="ID" AllowFilteringByColumn="False" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                                            <Columns>
                                                <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                </telerik:GridClientSelectColumn>
                                                <telerik:GridBoundColumn
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                    DataField="CustomerName" UniqueName="CustomerName"
                                                    HeaderText="Tên khách hàng" ShowFilterIcon="true">
                                                    <HeaderStyle Width="35%" HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="OrderStatus" UniqueName="OrderStatus" HeaderText="trạng thái" ShowFilterIcon="false">
                                                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TotalNeedPay" UniqueName="TotalNeedPay" DataFormatString="{0:###,###}" HeaderText="Giá trị" ShowFilterIcon="false">
                                                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SysDate" UniqueName="SysDate" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" HeaderText="Thời gian" ShowFilterIcon="false">
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
                                </telerik:RadAjaxPanel>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
            </div>
        </section>
    </ContentTemplate>
</asp:UpdatePanel>
