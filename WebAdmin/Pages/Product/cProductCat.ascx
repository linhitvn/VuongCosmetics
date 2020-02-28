<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductCat.ascx.cs" Inherits="Pages_Product_cProductCat" %>

<style type="text/css">
    .fixwidth{min-width:480px;}
</style>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Danh mục sản phẩm
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
                        <telerik:RadTreeList ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="false"
			                    AllowMultiRowSelection="true"  Skin="Metro" AutoGenerateColumns="false"
                            OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="RadGrid1_NeedDataSource"  
                                ParentDataKeyNames="ParentIDCustom" DataKeyNames="ID" CssClass="fixwidth MyTreeList">
                                <Columns>
                                        <telerik:TreeListTemplateColumn>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("IconLink") %>' NavigateUrl='<%# Bind("IconLink", "~{0}") %>'
                                                    runat="server">
                                                    <asp:Image Width="22px" ID="Image1" ImageUrl='<%# Bind("IconLink", "~{0}") %>' runat="server" onerror="this.src='./images/Default/No_image_available.png';" />
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Width="47px" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:TreeListTemplateColumn>
                                        <telerik:TreeListBoundColumn DataField="ProductCat" UniqueName="ProductCat" HeaderText="Tên danh mục">
					                        <HeaderStyle Width="65%" HorizontalAlign="Center" /> 
				                        </telerik:TreeListBoundColumn>
				                        <telerik:TreeListBoundColumn DataField="Pos" UniqueName="Pos" HeaderText="Vị trí">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
				                        </telerik:TreeListBoundColumn>
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
</ContentTemplate>
</asp:UpdatePanel>