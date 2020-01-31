<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cOrdersAlter.ascx.cs" Inherits="Pages_Order_cOrdersAlter" %>
 
<section class="content-header no-print">
    <h1>
        <i class="fa fa-edit"></i>
        Thông tin đơn hàng
    </h1>
    <ol class="toolbar">
        <!-- fa-mail-reply -->
        <li><button runat="server" id="Save" onserverclick="Save_Click" class="btn btn-info btn-sm">
            <i class="fa fa-save"></i>
            <span>Lưu</span>
        </button></li>
        <%--<li><button runat="server" id="SaveAndCreate" onserverclick="SaveAndCreate_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            <span>Lưu và tạo mới</span>
        </button></li>--%>
        <li><button runat="server" id="Back" onserverclick="Back_Click" class="btn btn-info btn-sm">
            <i class="fa fa-mail-reply"></i>
            <span>Quay lại</span>
        </button></li>
    </ol>
</section>

<div runat="server" id="message_box">    
</div>

<section class="content no-print">
    <%--<h6 class="page-header page-header-custom">
        Đơn hàng: <span runat="server" id="fID"></span> | <span runat="server" id="Span1"></span> | Trạng thái: <span runat="server" id="fOrderStatus"></span>
    </h6>--%>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <!-- Thông tin chung của đơn hàng -->
    <div class="row">
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Thông tin đơn hàng</h3>
                    <div class="box-tools pull-right">
                        <div runat="server" id="titleTotalPrice" class="label-custom"></div>
                    </div>
                </div>
                <div class="box-body">
                   
                    <div class="form-group">
					    <label>Khách hàng</label>
					    <%--<select runat="server" id="fCustomerID" datatextfield="CustomerName" datavaluefield="ID" class="form-control"> </select>--%>
				        <asp:DropDownList runat="server" ID="fCustomerID" DataTextField="CustomerName"
                            DataValueField="ID" CssClass="form-control" AutoPostBack="True" EnableViewState="true"
                            OnSelectedIndexChanged="fCustomerID_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <table class="table">
                        <tbody><tr>
                            <th style="width:50%">Họ tên khách hàng</th>
                            <td>
                                <input runat="server" id="fCustomer" class="form-control">
                            </td>
                        </tr>
                        <tr>
                            <th>Nhóm khách hàng</th>
                            <td>
                                <select runat="server" id="fCustomerGroupID" datatextfield="CustomerGroup" datavaluefield="ID" class="form-control">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <th>Email</th>
                            <td>
                                <input runat="server" id="fEmail" class="form-control">
                            </td>
                        </tr>
                        <tr>
                            <th>Tỉnh thành</th>
                            <td>
                                <select runat="server" id="fProvinceID" datatextfield="Province" datavaluefield="ID" class="form-control"></select>
                            </td>
                        </tr>
                        <tr>
                            <th>Số điện thoại</th>
                            <td>
                                <input runat="server" id="fPhone" class="form-control">
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <th>Địa chỉ IP đặt hàng</th>
                            <td runat="server" id="fIPAddress">LocalHost</td>
                        </tr>
                    </tbody></table>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="box box-solid">
                <div class="box-header">
                    <h3 class="box-title">Bảng thao tác</h3>
                </div>
                <div class="box-body">
                    <div class="form-group">
					    <label>Trạng thái đơn hàng</label>
					    <select runat="server" id="fOrderStatusID" datatextfield="OrderStatus" datavaluefield="ID" class="form-control" placeholder=""></select>
				    </div>
                    <a runat="server" id="btPrintBill" class="btn bg-olive margin" target="_blank" 
                        href="http://localhost/WebAdmin/Pages/Order/InvoiceTemplate/Bill.aspx">In hóa đơn</a>
                    <%--<button class="btn bg-olive margin">In hóa đơn + phiếu giao hàng</button>--%>
                    <%--<button class="btn bg-olive margin">In phiếu giao hàng</button>--%>
                    <a runat="server" id="btPrintPacking" class="btn bg-olive margin" target="_blank" href="http://localhost/WebAdmin/Pages/Order/InvoiceTemplate/Bill.aspx">In phiếu giao hàng</a>
                    <%--<button class="btn bg-olive margin">In báo giá</button>--%>
                    <%--<div class="form-group">
					    <label>Gởi Email: </label>
					    <select id="Select1" class="form-control" runat="server">
                            <option value="1">Thông tin đơn hàng</option>
                            <option value="2">Đang giao hàng</option>
                            <option value="3">Đơn hàng đã giao</option>
                            <option value="4">Hủy đơn hàng</option>
                        </select>
				    </div>--%>
                    <%--<div class="form-group">
	                    <div class="checkbox">
	                    <label>
		                    <input checked="checked" runat="server" id="fActive" type="checkbox" /> Gởi không cần xem trước.
	                    </label>
	                    </div>
                    </div>--%>
                    <div class="form-group">
                        <%--<button class="btn btn-primary btn-sm">Gởi Email</button>--%>
                        <%--<asp:Button ID="Button2" runat="server" Text="Gởi Email" CssClass="btn btn-primary btn-sm"/>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Phương thức thanh toán + Note -->
    <div class="row">
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-body">
                    <div class="form-group">
					    <label>Hình thức thanh toán</label>
					    <select runat="server" id="fPaymentID" datatextfield="Payment" datavaluefield="ID" class="form-control" ></select>
				    </div>
				    <div class="form-group">
					    <label>Hình thức giao hàng</label>
					    <select runat="server" id="fShippingID" datatextfield="Shipping" datavaluefield="ID" class="form-control" > </select>
				    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#customerNote" data-toggle="tab">Ghi chú của khách hàng</a></li>
                    <li><a href="#SalerNote" data-toggle="tab">Ghi chú đơn hàng</a></li>
                    <li><a href="#AddressNote" data-toggle="tab">Hướng dẫn đường đi</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="customerNote">
                        <textarea runat="server" id="fShipAddressNote" class="form-control" rows="3" placeholder=""></textarea>
                    </div>
                    <div class="tab-pane" id="SalerNote">
                        <textarea runat="server" id="fNoteSaler" class="form-control" rows="3" placeholder=""></textarea>
                    </div>
                    <div class="tab-pane" id="AddressNote">
                        <textarea runat="server" id="fNoteCustomer" class="form-control" rows="3" placeholder=""></textarea>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Địa chỉ thành toán + giao hàng -->
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Always">
    <ContentTemplate>
    <div class="row">
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Địa chỉ thanh toán</h3>
                </div>
                <div class="box-body">
                    <!-- Thông tin thanh toán cước -->
				        <div class="form-group">
					        <label>Khách hàng</label>
					        <input runat="server" id="fBillCustomer" class="form-control" ClientIDMode="Static">
				        </div>
				        <div class="form-group">
					        <label>Điện thoại</label>
					        <input runat="server" id="fBillPhone" class="form-control" ClientIDMode="Static">
				        </div>
				        <div class="form-group">
					        <label>Địa chỉ</label>
					        <input runat="server" id="fBillAddress" class="form-control" ClientIDMode="Static">
				        </div>
				        <div class="form-group">
					        <label>Tỉnh thành</label>
                            <asp:DropDownList runat="server" id="fBillProvinceID" datatextfield="Province" datavaluefield="ID" class="form-control" ClientIDMode="Static" OnSelectedIndexChanged="fBillProvinceID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
				        </div>
				        <div class="form-group">
					        <label>Quận/ Huyện</label>
					        <select runat="server" id="fBillDistrictID" datatextfield="District" datavaluefield="ID" class="form-control" ClientIDMode="Static"> </select>
				        </div>
                        <div class="form-group">
					        <div class="checkbox">
					        <label>
						        <input checked="checked" runat="server" id="cbSameAddr" type="checkbox" ClientIDMode="Static" /> Giao hàng và thanh toán cùng địa chỉ.
					        </label>
					        </div>
				        </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Địa chỉ giao hàng</h3>
                </div>
                <div class="box-body">
                    <!-- Địa chỉ giao hàng -->
				        <div class="form-group">
					        <label>Khách hàng</label>
					        <input runat="server" id="fShipCustomer" class="form-control" placeholder="" ClientIDMode="Static">
				        </div>
				        <div class="form-group">
					        <label>Điện thoại</label>
					        <input runat="server" id="fShipPhone" class="form-control" placeholder="" ClientIDMode="Static">
				        </div>
				        <div class="form-group">
					        <label>Địa chỉ</label>
					        <input runat="server" id="fShipAddress" class="form-control" placeholder="" ClientIDMode="Static">
				        </div>
                        
				        <div class="form-group">
					        <label>Tỉnh/ Thành Phố</label>
                            <asp:DropDownList runat="server" id="fShipProvinceID" datatextfield="Province" datavaluefield="ID" class="form-control" ClientIDMode="Static" OnSelectedIndexChanged="fShipProvinceID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
				        </div>
				        <div class="form-group">
					        <label>Quận/ Huyện</label>
					        <select runat="server" id="fShipDistrictID" datatextfield="District" datavaluefield="ID" class="form-control" ClientIDMode="Static"></select>
				        </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Thông tin chi tiết Đơn hàng -->
    </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="row">
        <!-- Chi tiết Đơn hàng -->
        <div class="col-md-12">
            <div class="box box-primary">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <div class="box-header">
                    <h3 class="box-title">Chi tiết đơn hàng <span runat="server" id="mesOrderDetail" style="color: Red"></span></h3>
                    <div class="box-tools pull-right">
                        <button runat="server" id="Button1" onserverclick="UpdateQuality_CLick" class="btn bg-olive margin">Cập nhật số lượng</button>
                    </div>
                </div><!-- /.box-header -->
                 <div class="box-body">
                    <div class="row">
                        <div class="col-md-12">
                            <!-- Lấy thông tin đơn hàng bỏ vào đây. -->
                            
                                <telerik:RadComboBox runat="server" ID="sProfuctSearch" CssClass="form-control"
                                    DataTextField="ProductName" DataValueField="ID"
                                    EnableLoadOnDemand="True" OnItemsRequested="RadComboBox2_ItemsRequested" 
                                    Height="200px" Width="100%" class="form-control"
                                    ShowMoreResultsBox="true" AutoPostBack="true"
                                    onselectedindexchanged="RadComboBox2_SelectedIndexChanged">
                                </telerik:RadComboBox>
				            
                            <telerik:RadGrid ID="RadGrid_OrderDetailt" runat="server" EnableEmbeddedSkins="false"
                                GridLines="None" PageSize="10" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
                                AllowMultiRowSelection="false" AllowFilteringByColumn="false" OnItemCommand="RadGrid_OrderDetailt_ItemCommand">
                                <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered">
                                   <Columns>
                                      <telerik:GridTemplateColumn UniqueName="RowNo" HeaderText="#">
                                         <ItemTemplate>
                                            <%# (Container.ItemIndex + (RadGrid_OrderDetailt.CurrentPageIndex * RadGrid_OrderDetailt.PageSize) + 1).ToString()%>
                                         </ItemTemplate>
                                         <ItemStyle Width="3%" HorizontalAlign="Center"/>
                                      </telerik:GridTemplateColumn>
                                      <telerik:GridBoundColumn DataField="ProductName"
                                         HeaderText="Tên sản phẩm" UniqueName="ProductName" HeaderStyle-HorizontalAlign="Center">
                                         <ItemStyle Width="45%" />
                                      </telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="ProductCode"
                                         HeaderText="Mã sản phẩm" UniqueName="ProductCode" HeaderStyle-HorizontalAlign="Center">
                                         <ItemStyle Width="10%" HorizontalAlign="Center" />
                                      </telerik:GridBoundColumn>
                                      <telerik:GridTemplateColumn UniqueName="Quatity" ShowFilterIcon="false" AllowFiltering="false" HeaderText="Số lượng" HeaderStyle-HorizontalAlign="Center">
                                         <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="fQuatity" runat="server" MaxLength="3" class="form-control" DBValue='<%# Eval("Quatity") %>' MinValue="0" 
                                               NumberFormat-DecimalDigits="0" Width="60px">
                                            </telerik:RadNumericTextBox>
                                         </ItemTemplate>
                                         <ItemStyle Width="10%" HorizontalAlign="Center"/>
                                      </telerik:GridTemplateColumn>
                                      <telerik:GridBoundColumn DataField="Price" HeaderStyle-Width="10%"  HeaderStyle-HorizontalAlign="Center"
                                         HeaderText="Đơn giá" DataFormatString="{0:###,###;#;0}" UniqueName="Price">
                                         <ItemStyle HorizontalAlign="Right" Width="10%" />
                                      </telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="VAT" HeaderStyle-Width="10%"  HeaderStyle-HorizontalAlign="Center"
                                         HeaderText="Thuế VAT" DataFormatString="{0:###,###;#;0}" UniqueName="VAT">
                                         <ItemStyle HorizontalAlign="Right" />
                                      </telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="TotalPrice" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                         HeaderText="Thành tiền" DataFormatString="{0:###,###;#;0}" UniqueName="TotalPrice">
                                         <ItemStyle HorizontalAlign="Right" />
                                      </telerik:GridBoundColumn>
                                      <telerik:GridTemplateColumn ShowFilterIcon="false" AllowFiltering="false"  HeaderStyle-HorizontalAlign="Center">
                                         <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" CommandName="delete" Height="15px" OnClientClick="javascript:return ConfirmDeleteCustom();"
                                               CommandArgument='<%# Eval("ID") %>' runat="server" ImageUrl="~/images/delete.png" />
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                                      </telerik:GridTemplateColumn>
                                   </Columns>
                                   <NoRecordsTemplate>
                                      <div>
                                         Chưa có sản phẩm nào trong giỏ hàng
                                      </div>
                                   </NoRecordsTemplate>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true">
                                   <Selecting AllowRowSelect="true"></Selecting>
                                </ClientSettings>
                             </telerik:RadGrid>
                        </div>   
                    </div>
                    <div class="row" style="height: 20px;"></div>
                    <div class="row">
                        <div class="col-md-6"></div>                                                        
                        <div class="col-md-6">
                            <div class="table-responsive order-overview">
                                <table class="table table-condensed">
                                    <tbody>
                                        <tr>
                                            <td>1.</td>
                                            <td>Tổng thành tiền</td>
                                            <td>
                                                <telerik:RadNumericTextBox Enabled="false" ID="fTotalPrice" runat="server" CssClass="form-control" MinValue="0" 
                                                    NumberFormat-DecimalDigits="0">
                                                </telerik:RadNumericTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2.</td>
                                            <td>Khuyến mãi - Giảm giá</td>
                                            <td>
                                                <telerik:RadNumericTextBox ID="fDiscount" runat="server" 
                                                    CssClass="form-control" MinValue="0" 
                                                    NumberFormat-DecimalDigits="0" ontextchanged="fDiscount_TextChanged" AutoPostBack="true">
                                                </telerik:RadNumericTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3.</td>
                                            <td>Phí vận chuyển</td>
                                            <td>
                                                <telerik:RadNumericTextBox ID="fShippingPrice" runat="server" 
                                                    CssClass="form-control" MinValue="0" 
                                                   NumberFormat-DecimalDigits="0" ontextchanged="fShippingPrice_TextChanged" AutoPostBack="true">
                                                </telerik:RadNumericTextBox>
                                            </td>
                                        </tr>
                                        <tr style="font-size: 23px;">
                                            <td>#</td>
                                            <td>TỔNG CỘNG</td>
                                            <td>
                                                <telerik:RadNumericTextBox ID="fTotalNeedPay" runat="server" CssClass="form-control" MinValue="0" 
                                                   NumberFormat-DecimalDigits="0" AutoPostBack="true">
                                                </telerik:RadNumericTextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                </ContentTemplate>
                    </asp:UpdatePanel>
            </div><!-- /.box -->
        </div>

    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</section><!-- /.content -->


<script type="text/javascript">
    $('#fBillCustomer').change(function () {
        if ($('#cbSameAddr').prop('checked'))
            $('#fShipCustomer').val($('#fBillCustomer').val())
    });
    $('#fBillPhone').change(function () {
        if ($('#cbSameAddr').prop('checked'))
            $('#fShipPhone').val($('#fBillPhone').val())
    });
    $('#fBillAddress').change(function () {
        if ($('#cbSameAddr').prop('checked'))
            $('#fShipAddress').val($('#fBillAddress').val())
    });
    $('#fBillProvinceID').change(function () {
        if ($('#cbSameAddr').prop('checked'))
            $('#fShipProvinceID').val($('#fBillProvinceID').val())
    });
    $('#fBillDistrictID').change(function () {
        if ($('#cbSameAddr').prop('checked'))
            $('#fShipDistrictID').val($('#fBillDistrictID').val())
    });
    $('#cbSameAddr').click(function () {
        if ($('#cbSameAddr').prop('checked')) {
            $('#fShipCustomer').val($('#fBillCustomer').val());
            $('#fShipPhone').val($('#fBillPhone').val())
            $('#fShipAddress').val($('#fBillAddress').val())
            $('#fShipProvinceID').val($('#fBillProvinceID').val())
            $('#fShipDistrictID').val($('#fBillDistrictID').val());
        }
    });
</script>