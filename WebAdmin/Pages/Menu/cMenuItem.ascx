<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cMenuItem.ascx.cs" Inherits="Pages_Menu_cMenuItem" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Quản lý Menu
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
                        <telerik:RadTreeList ID="RadTreeList1" runat="server" AllowPaging="True" AllowSorting="false"
			                    AllowMultiRowSelection="true"  Skin="Metro" AutoGenerateColumns="false"
                            OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="RadGrid1_NeedDataSource" CssClass="MyTreeList"
                                ParentDataKeyNames="ParentIDCustom" DataKeyNames="ID">
                                <Columns>
                                    <%--<telerik:TreeListTemplateColumn>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("ImgLink") %>' NavigateUrl='<%# Bind("ImgLink", "~{0}") %>'
                                                runat="server">
                                                <asp:Image Width="22px" ID="Image1" ImageUrl='<%# Bind("ImgLink", "~{0}") %>' runat="server" />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                        <HeaderStyle Width="47px" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:TreeListTemplateColumn>--%>
                                    <telerik:TreeListBoundColumn DataField="MenuItem" UniqueName="MenuItem" HeaderText="Tên hiễn thị">
					                    <HeaderStyle Width="35%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="Url" UniqueName="Url" HeaderText="Đường dẫn (Link)">
					                    <HeaderStyle Width="30%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
				                    <telerik:TreeListBoundColumn DataField="Pos" UniqueName="Pos" HeaderText="Thứ tự">
					                    <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListCheckBoxColumn DataField="Active" UniqueName="Active" HeaderText="Kích hoạt">
					                    <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
				                    </telerik:TreeListCheckBoxColumn>
                                    <telerik:TreeListSelectColumn UniqueName="ClientSelectColumn1" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </telerik:TreeListSelectColumn>
                                    <telerik:TreeListTemplateColumn>
                                            <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" CommandName='<%# ActRow.Edit %>'
                                                CommandArgument='<%# Eval("ID") %>' runat="server" ImageUrl="~/images/edit.png" ToolTip="Chỉnh sửa" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </telerik:TreeListTemplateColumn>
                                </Columns>
                                <ClientSettings>
                                    <Selecting AllowItemSelection="true" />
                                </ClientSettings>
                        </telerik:RadTreeList>
                    </div>
                </div><!-- /.box-body -->
            </div><!-- /.box -->
        </div>
    </div>
</section>
</ContentTemplate>
</asp:UpdatePanel>