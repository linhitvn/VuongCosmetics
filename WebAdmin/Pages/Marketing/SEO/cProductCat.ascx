<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductCat.ascx.cs" Inherits="Pages_Marketing_SEO_cProductCat" %>
<style type="text/css">
    .fixwidth{min-width:480px;}
</style>
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Thiết lập SEO Cho Danh mục sản phẩm
    </h1>
    <ol class="toolbar">
        <%--<li><button runat="server" id="btCreate" onserverclick="New_Click" class="btn btn-info btn-sm">
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
        </li>--%>
    </ol>
</section>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
<ContentTemplate>
<div runat="server" id="message_box">    
</div>


<section class="content">
    <div class="row">
        <div class="col-xs-12">
            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class=""><a id="A2" runat="server" href="~/?module=503&act=edit&KeyID=1">Thiết lập SEO cho Website</a></li>
                    <li class=""><a id="A1" runat="server" href="~/?module=513">Thiết lập SEO Cho Trang</a></li>
                    <li class="active"><a>Danh mục sản phẩm</a></li>
                    <li class=""><a id="A3" runat="server" href="~/?module=533">Danh mục tin tức</a></li>
                </ul>
            </div>
            <div class="tab-content">
                <div class="tab-pane active" id="fa-icons">
                    <div class="box">
                        <div class="box-body table-responsive">
                        <telerik:RadTreeList ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="false"
			                    AllowMultiRowSelection="true"  Skin="Metro" AutoGenerateColumns="false"
                            OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="RadGrid1_NeedDataSource"  
                                ParentDataKeyNames="ParentIDCustom" DataKeyNames="ID"  CssClass="fixwidth">
                                <Columns>
                                    <telerik:TreeListBoundColumn DataField="ProductCat" UniqueName="ProductCat" HeaderText="Tên danh mục">
					                    <HeaderStyle Width="30%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
				                    <telerik:TreeListBoundColumn DataField="MetaTitle" UniqueName="MetaTitle" HeaderText="Tiêu đề">
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="MetaDescription" UniqueName="MetaDescription" HeaderText="Mô tả">
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="MetaKeywords" UniqueName="MetaKeywords" HeaderText="Từ khóa">
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListTemplateColumn>
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" CommandName='<%# ActRow.Edit %>'
                                                CommandArgument='<%# Eval("ID") %>' runat="server" ImageUrl="~/images/edit.png" ToolTip="Chỉnh sửa" />
                                            </ItemTemplate>
                                            <ItemStyle  HorizontalAlign="Center" />
                                    </telerik:TreeListTemplateColumn>
                                </Columns>
                                <ClientSettings>
                                    <Selecting AllowItemSelection="true" />
                                </ClientSettings>
                        </telerik:RadTreeList>
                        </div>
                    </div><!-- /.box -->
                </div>
                <div class="tab-pane" id="glyphicons"></div>
            </div>
        </div>
    </div>
</section>
</ContentTemplate>
</asp:UpdatePanel>