<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cRewardAlter.ascx.cs" Inherits="Pages_Marketing_Reward_RewardAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Cấu hình điểm thưởng
    </h1>
    <ol class="toolbar">
        <!-- fa-mail-reply -->
        <li>
            <button runat="server" id="Save" onserverclick="Save_Click" class="btn btn-info btn-sm">
                <i class="fa fa-save"></i>
                <span>Lưu</span>
            </button>
        </li>
        <%--        <li><button runat="server" id="SaveAndCreate" onserverclick="SaveAndCreate_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            <span>Lưu và tạo mới</span>
        </button></li>--%>
        <%--        <li><button runat="server" id="Back" onserverclick="Back_Click" class="btn btn-info btn-sm">
            <i class="fa fa-mail-reply"></i>
            <span>Quay lại</span>
        </button></li>--%>
    </ol>
</section>

<div runat="server" id="message_box">
</div>

<!-- Main content -->
<section class="content">
    <div class="row">
        <div class="col-md-6">
            <div class="box box-danger">
                <%--<div class="box-header">
                    <h3 class="box-title">Quick Example</h3>
                </div><!-- /.box-header -->--%>
                <!-- form start -->
                <div role="form" class="form">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Loại điểm thưởng</label>
                            <select runat="server" id="fRewardTypeID" datatextfield="RecordType" datavaluefield="ID" class="form-control"></select>
                        </div>
                        <div class="form-group">
                            <label>Số điểm đổi ngược lại 1 đv tiền</label>
                            <input runat="server" id="fPointToMoney" class="form-control input-number" placeholder="">
                        </div>
                        <div class="form-group">
                            <label>Số điểm tối thiểu để đổi</label>
                            <input runat="server" id="fMinForChange" class="form-control input-number" placeholder="">
                        </div>
                        <div class="form-group">
                            <label>Thời gian điểm bắt đầu có thể đổi</label>
                            <input runat="server" id="fAfterDayForChange" class="form-control input-number" placeholder="">
                        </div>
                        <div class="form-group">
                            <label>Thời gian điểm trở về 0 (Điểm trước đó không còn hiệu lực)</label>
                            <input runat="server" id="fDayForResetAll" class="form-control input-number" placeholder="">
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input runat="server" id="fActive" type="checkbox" />
                                    Kích hoạt
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Ghi chú</label>
                            <textarea runat="server" id="fNote" class="form-control" placeholder="" rows="3"></textarea>
                        </div>
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer">
                        <%--<button id="Button1" runat="server" onserverclick="Save_Click" type="submit" class="btn btn-primary">Lưu</button>--%>
                    </div>
                </div>
            </div>
            <!-- /.box -->
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-header">
                            <h3 class="box-title">Cấu hình Điểm thưởng theo giá trị đơn hàng</h3>
                            <div class="box-tools pull-right">
                                <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"
                                GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
                                AllowMultiRowSelection="true" AllowFilteringByColumn="false" OnItemCommand="RadGrid1_ItemCommand">
                                <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="MinPrice" UniqueName="MinPrice" DataFormatString="{0:###,###}" HeaderText="Giá trị đơn hàng tối thiểu" ShowFilterIcon="false">
                                            <HeaderStyle Width="50%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Point" UniqueName="Point" DataFormatString="{0:###,###}" HeaderText="Điểm thưởng" ShowFilterIcon="false">
                                            <HeaderStyle Width="33%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn ShowFilterIcon="false" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton3" CommandName='<%# ActRow.Delete %>'
                                                    CommandArgument='<%# Eval("ID") %>' runat="server"
                                                    ImageUrl="~/images/delete.png" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings>
                                    <Selecting AllowRowSelect="true"></Selecting>
                                </ClientSettings>
                            </telerik:RadGrid>
                            
                            <input runat="server" id="aValue" placeholder="Giá trị đơn hàng tối thiểu" class="col-xs-6" style="text-align:center">
                            
                            <input runat="server" id="aPoint" placeholder="Điểm thưởng"  class="col-xs-4" style="text-align:center">
                            
                            <button runat="server" id="Button1" onserverclick="Add_Click" class="btn btn-info btn-sm" style="margin-left:16px; margin-top:-2px;">
                                <i class="fa fa-search"></i>
                                <span>Thêm</span>
                            </button>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</section>
<!-- /.content -->
