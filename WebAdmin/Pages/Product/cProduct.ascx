<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProduct.ascx.cs" Inherits="Pages_Product_cProduct" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Quản lý sản phẩm
    </h1>
    <ol class="toolbar">
        <li><button runat="server" id="btCreate" onserverclick="New_Click" class="btn btn-info btn-sm">
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
                Danh mục sản phẩm
            </label>
            <label>
                <select runat="server" id="sProductCat" style="min-width: 150px;"
                    datatextfield="ProductCat" datavaluefield="ID" class="form-control input-sm"></select>
            </label>
            <label>
                <input runat="server" id="sProductCN" class="form-control" style="width: 300px;" placeholder="Nhập tên sản phẩm/ Mã sản phẩm">
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
                        <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"  
                                     GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
			                        AllowMultiRowSelection="true" AllowFilteringByColumn="false" 
                                OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="RadGrid1_NeedDataSource">
                                <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                                    <Columns>
										<telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        </telerik:GridClientSelectColumn>
                                        <telerik:GridTemplateColumn ShowFilterIcon="false" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("ImgLink1") %>' NavigateUrl='<%# Bind("ImgLink1", "~{0}") %>'
                                                    runat="server">
                                                    <asp:Image Width="25px" ID="Image1" ImageUrl='<%# Bind("ImgLink1", "~{0}") %>' runat="server" onerror="this.src='./images/Default/No_image_available.png';" />
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Width="47px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ProductName" UniqueName="ProductName" HeaderText="Tên" ShowFilterIcon="false">
					                        <HeaderStyle Width="35%" HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="ProductCode" UniqueName="ProductCode" HeaderText="Mã" ShowFilterIcon="false">
					                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>
                                        <%--<telerik:GridBoundColumn DataField="ProductCat" UniqueName="ProductCat" HeaderText="Danh mục" ShowFilterIcon="false">
					                        <HeaderStyle Width="17%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>--%>
				                        <telerik:GridBoundColumn DataField="Price" UniqueName="Price" DataFormatString="{0:###,###}" HeaderText="Giá Bán" ShowFilterIcon="false">
					                        <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="SalePrice" UniqueName="SalePrice" DataFormatString="{0:###,###}" HeaderText="Giá KM" ShowFilterIcon="false">
					                        <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
				                        </telerik:GridBoundColumn>
				                        <%--<telerik:GridBoundColumn DataField="Quantity" UniqueName="Quantity" DataFormatString="{0:###,###}" HeaderText="Số lượng" ShowFilterIcon="false">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="NumSaled" UniqueName="NumSaled" DataFormatString="{0:###,###}" HeaderText="Đã bán" ShowFilterIcon="false">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>--%>
                                        <telerik:GridCheckBoxColumn DataField="IsHiddenWhenOutoff" UniqueName="IsHiddenWhenOutoff" HeaderText="Hết hàng" ShowFilterIcon="false" ReadOnly="True">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
					                        <ItemStyle HorizontalAlign="Center" />
				                        </telerik:GridCheckBoxColumn>
				                        <telerik:GridCheckBoxColumn DataField="IsShow" UniqueName="IsShow" HeaderText="Hiễn thị" ShowFilterIcon="false" ReadOnly="True">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
					                        <ItemStyle HorizontalAlign="Center" />
				                        </telerik:GridCheckBoxColumn>
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
                </div><!-- /.box-body -->
            </div><!-- /.box -->
        </div>
    </div>
</section>
</ContentTemplate>
</asp:UpdatePanel>