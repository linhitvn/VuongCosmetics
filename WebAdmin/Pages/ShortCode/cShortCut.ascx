<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cShortCut.ascx.cs" Inherits="Pages_Widgets_ShortCut" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Quản lý ShortCut
    </h1>
    <ol class="toolbar">
        <li><button runat="server" id="btCreate" onserverclick="New_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            <span>Tạo mới</span>
            </button>
        </li>
        <li><button runat="server" id="btClone" onserverclick="Clone_Click" class="btn btn-info btn-sm">
            <i class="fa fa-copy"></i>
            <span>Sao chép</span>
            </button>
       </li>
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
        <div class="col-sm-6" style="text-align: right; float: right;">
            <label>
                <select runat="server" id="sShortCutTypeID" datatextfield="ShortCutType" class="form-control" datavaluefield="ID" style="width: 200px;">
                </select>
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
                                        <telerik:GridTemplateColumn ShowFilterIcon="false" AllowFiltering="false" HeaderText="Ảnh">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("ImgLink") %>' NavigateUrl='<%# Bind("ImgLink", "~{0}") %>'
                                                    runat="server">
                                                    <asp:Image Width="47px" ID="Image1" ImageUrl='<%# Bind("ImgLink", "~{0}") %>' runat="server" />
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Width="47px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ShortCutName" UniqueName="ShortCutName" HeaderText="Tiêu đề" ShowFilterIcon="false">
					                        <HeaderStyle Width="30%" HorizontalAlign="Center" /> 
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="ShortCutType" UniqueName="ShortCutType" HeaderText="Loại" ShowFilterIcon="false">
					                        <HeaderStyle Width="20%" HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="UrlLink" UniqueName="UrlLink" HeaderText="Liên kết" ShowFilterIcon="false">
					                        <HeaderStyle Width="20%" HorizontalAlign="Center" /> 
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="Pos" UniqueName="Pos" HeaderText="Vị trí" ShowFilterIcon="false">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>
				                        <telerik:GridCheckBoxColumn DataField="Active" UniqueName="Active" HeaderText="Kích hoạt" ShowFilterIcon="false" ReadOnly="True">
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
</ContentTemplate>
</asp:UpdatePanel>