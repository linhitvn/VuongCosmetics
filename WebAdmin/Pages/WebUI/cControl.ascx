<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cControl.ascx.cs" Inherits="Pages_WebUI_cControl" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Quản lý Control
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
                <select runat="server" id="sPageID" datatextfield="Page" class="form-control" datavaluefield="ID" style="width: 200px;">
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
                        <telerik:RadTreeList ID="RadTreeList1" runat="server" AllowPaging="True" AllowSorting="false"
			                    AllowMultiRowSelection="true"  Skin="Metro" AutoGenerateColumns="false"
                            OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="RadGrid1_NeedDataSource"  
                                ParentDataKeyNames="ParentIDCustom" DataKeyNames="ID">
                                <Columns>
                                     <telerik:TreeListTemplateColumn HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("ImgLink") %>' NavigateUrl='<%# Bind("ImgLink", "~{0}") %>'
                                                runat="server">
                                                <asp:Image Width="100%" ID="Image1" ImageUrl='<%# Bind("ImgLink", "~{0}") %>' runat="server" />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </telerik:TreeListTemplateColumn>
                                    <telerik:TreeListBoundColumn DataField="ControlName" UniqueName="ControlName" HeaderText="Tên Control">
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="UControl" UniqueName="UControl" HeaderText="Đường dẫn Control">
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="param" UniqueName="param" HeaderText="Thông số Control">
					                    <HeaderStyle Width="15%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
				                    <telerik:TreeListBoundColumn DataField="Pos" UniqueName="Pos" HeaderText="Thứ tự hiển thị">
					                    <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListCheckBoxColumn UniqueName="Active" DataField="Active" HeaderStyle-HorizontalAlign="Center" HeaderText="Kích hoạt">
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </telerik:TreeListCheckBoxColumn>
                                     <telerik:TreeListSelectColumn UniqueName="ClientSelectColumn1" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
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