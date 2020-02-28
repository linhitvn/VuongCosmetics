<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cWebsite.ascx.cs" Inherits="Pages_Marketing_SEO_cWebsite" %>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Thiết lập SEO Cho Website
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
                    <li class="active"><a>Thiết lập SEO cho Website</a></li>
                    <li class=""><a id="A1" runat="server" href="~/?module=513">Thiết lập SEO Cho Trang</a></li>
                    <li class=""><a id="A2" runat="server" href="~/?module=523">Danh mục sản phẩm</a></li>
                    <li class=""><a id="A3" runat="server" href="~/?module=533">Danh mục tin tức</a></li>
                </ul>
            </div>
            <div class="tab-content">
                <div class="tab-pane active" id="fa-icons">
                    <div class="box">
                        <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"  
                                    GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
			                    AllowMultiRowSelection="true" AllowFilteringByColumn="false" 
                            OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="RadGrid1_NeedDataSource">
                            <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                                <Columns>
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
                    </div><!-- /.box -->
                </div>
                <div class="tab-pane" id="glyphicons"></div>
            </div>
        </div>
    </div>
</section>
</ContentTemplate>
</asp:UpdatePanel>