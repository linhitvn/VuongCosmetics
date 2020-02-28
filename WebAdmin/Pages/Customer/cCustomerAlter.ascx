<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cCustomerAlter.ascx.cs" Inherits="Pages_Customer_cCustomerAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Thông tin khách hàng
    </h1>
    <ol class="toolbar">
        <!-- fa-mail-reply -->
        <li><button runat="server" id="Save" onserverclick="Save_Click" class="btn btn-info btn-sm">
            <i class="fa fa-save"></i>
            <span>Lưu</span>
        </button></li>
        <li><button runat="server" id="SaveAndCreate" onserverclick="SaveAndCreate_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            <span>Lưu và tạo mới</span>
        </button></li>
        <li><button runat="server" id="Back" onserverclick="Back_Click" class="btn btn-info btn-sm">
            <i class="fa fa-mail-reply"></i>
            <span>Quay lại</span>
        </button></li>
    </ol>
</section>

<div runat="server" id="message_box">    
</div>

<!-- Main content -->
<section class="content">
    <div class="row">
        <div class="col-md-6">
            <div class="box box-danger">
                <div class="box-header">
                    <h3 class="box-title">Thông tin cơ bản</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div role="form">
                    <div class="box-body">
                    <div class="form-group not-null">
					    <label>
                            <i class="fa fa-asterisk"></i>
                            Tên khách hàng
                        </label>
					    <input runat="server" id="fCustomerName" class="form-control" placeholder="">
				    </div>
				    <div class="form-group not-null">
					    <label>
                            <i class="fa fa-asterisk"></i>
                            Nhóm khách hàng
                        </label>
                        <select runat="server" id="fCustomerGroupID" datatextfield="CustomerGroup" datavaluefield="ID" class="form-control">
                        </select>
				    </div>
                    <div class="form-group not-null">
					    <label>
                            <i class="fa fa-asterisk"></i>
                            Tỉnh/Thành Phố
                        </label>
                        <select runat="server" id="fProvinceID" datatextfield="Province" datavaluefield="ID" class="form-control">
                        </select>
				    </div>
				    <div class="form-group not-null">
					    <label>
                            <i class="fa fa-asterisk"></i>
                            E-mail
                        </label>
					    <input runat="server" id="fEmail" class="form-control" placeholder="">
				    </div>
				    <div class="form-group not-null">
					    <label>
                            <i class="fa fa-asterisk"></i>
                            Điện thoại
                        </label>
					    <input runat="server" id="fPhone" class="form-control" placeholder="">
				    </div>
				    <div class="form-group">
					    <label>Địa chỉ</label>
					    <input runat="server" id="fAddress" class="form-control" placeholder="">
				    </div>
                    <div class="form-group">
					    <label>Công ty</label>
					    <input runat="server" id="fCompany" class="form-control" placeholder="">
				    </div>
				    <div class="form-group">
					    <label>
                            Ngày sinh
                        </label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input runat="server" id="fBirthday" type="text" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="">
                        </div>
				    </div>
				    <div class="form-group">
					    <label>Giới tính</label>
                        <select runat="server" id="fSex" class="form-control">  
                            <option value="0" Text="Nam"></option>
                            <option value="1" Text="Nữ"></option>
                            <option value="2" Text="Khác"></option>
                        </select>
				    </div>
				    <div class="form-group">
					    <label>Địa chỉ: mạng xã hội</label>
					    <input runat="server" id="fSocialNetwork" class="form-control" placeholder="vd: https://www.facebook.com/tennguoidung">
				    </div>
				    <div class="form-group">
					    <label>Ghi chú</label>
                        <textarea runat="server" id="fNote" class="form-control" placeholder="Ghi chú về khách hàng (nếu cần)"></textarea>
				    </div>
                    <div class="form-group">
					    <label>Ngày tạo</label>
					    <telerik:RadDatePicker ID="fSysDate" runat="server" culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
					      <DatePopupButton ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" /> 					  
                          <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" /> 					
                        </telerik:RadDatePicker>
				    </div>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        <%--<button id="Button1" runat="server" onserverclick="Save_Click" type="submit" class="btn btn-primary">Lưu</button>--%>
                    </div>
                </div>
            </div><!-- /.box -->
        </div>
        <div class="col-md-6" style="display:none;">
            <div class="box box-primary collapsed-box">
                <div class="box-header">
                    <h3 class="box-title">Thông tin tài khoản</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div class="box-body" style="display: none;">
                    <div class="form-group not-null">
					    <label>
                            <i class="fa fa-asterisk"></i>
                            Tài khoản (Đăng nhập)
                        </label>
					    <input runat="server" id="fUsername" class="form-control" placeholder="">
				    </div>
				    <div class="form-group not-null">
					    <label>
                            <i class="fa fa-asterisk"></i>
                            Mật khẩu
                        </label>
					    <input runat="server" id="fPassword" type="password" class="form-control" placeholder="">
				    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Lịch sử mua hàng</h3>
                   <%-- <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>--%>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div class="box-body">
                    <telerik:RadGrid ID="RadGrid_Orders" runat="server" EnableEmbeddedSkins="false"  
                                    GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
			                    AllowMultiRowSelection="true" AllowFilteringByColumn="false" OnItemCommand="RadGrid_Orders_ItemCommand">
                            <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                                <Columns>
									<telerik:GridTemplateColumn UniqueName="RowNo" HeaderText="STT" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# (Container.ItemIndex + (RadGrid_Orders.CurrentPageIndex * RadGrid_Orders.PageSize) + 1).ToString()%>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center"/>
                                    </telerik:GridTemplateColumn>
				                    <telerik:GridBoundColumn DataField="TotalNeedPay" UniqueName="TotalNeedPay" DataFormatString="{0:###,###}" HeaderText="Giá trị" ShowFilterIcon="false">
					                    <HeaderStyle Width="30%" HorizontalAlign="Center" />
				                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OrderStatus" UniqueName="OrderStatus" HeaderText="trạng thái" ShowFilterIcon="false">
					                    <HeaderStyle Width="25%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
				                    </telerik:GridBoundColumn>
				                    <telerik:GridBoundColumn DataField="SysDate" UniqueName="SysDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Thời gian" ShowFilterIcon="false"> 
					                    <HeaderStyle Width="30%" HorizontalAlign="Center" />
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
            </div>
        </div>
        <div class="col-md-6" style="display:none;">
            <div class="box box-primary collapsed-box">
                <div class="box-header">
                    <h3 class="box-title">Điểm thưởng</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div class="box-body" style="display: none;">
                </div>
            </div>
        </div>
        <div class="col-md-6" style="display:none;">
            <div class="box box-primary collapsed-box">
                <div class="box-header">
                    <h3 class="box-title">Danh sách yêu thích</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div class="box-body" style="display: none;">
                    <telerik:RadGrid ID="RadGrid_WishList" runat="server" EnableEmbeddedSkins="false"  
                                GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
			                AllowMultiRowSelection="true" AllowFilteringByColumn="false">
                        <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="RowNo" HeaderText="STT" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# (Container.ItemIndex + (RadGrid_WishList.CurrentPageIndex * RadGrid_WishList.PageSize) + 1).ToString()%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center"/>
                                </telerik:GridTemplateColumn>
		                        <telerik:GridBoundColumn DataField="ProductName" UniqueName="ProductName" HeaderText="Sản phẩm" ShowFilterIcon="false">
			                        <HeaderStyle Width="50%" HorizontalAlign="Center" />
		                        </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ProductCode" UniqueName="ProductCode" HeaderText="Mã sản phẩm" ShowFilterIcon="false"> 
			                        <HeaderStyle Width="20%" HorizontalAlign="Center" />
		                        </telerik:GridBoundColumn>
		                        <telerik:GridBoundColumn DataField="SysDate" UniqueName="SysDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày" ShowFilterIcon="false"> 
			                        <HeaderStyle Width="20%" HorizontalAlign="Center" />
		                        </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
        </div>
    </div>
</section><!-- /.content -->