<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cArticle.ascx.cs" Inherits="Pages_Article_cArticle" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Quản lý bài viết
    </h1>
    <ol class="toolbar">
        <li>
            <button runat="server" id="btCreate" onserverclick="New_Click" class="btn btn-info btn-sm">
                <i class="fa fa-plus-square"></i>
                <span>Tạo mới</span>
            </button>
        </li>
        <li>
            <button runat="server" id="btClone" onserverclick="Clone_Click" class="btn btn-info btn-sm">
                <i class="fa fa-copy"></i>
                <span>Sao chép</span>
            </button>
        </li>
        <li>
            <button runat="server" id="btDelete" onserverclick="Delete_Click" class="btn btn-info btn-sm" onclick="if(!confirm('Bạn có chắc chắn muốn xóa dữ liệu này không?')) return;">
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
                        Danh mục
                    </label>
                    <label>
                        <select runat="server" id="sCategory" style="min-width: 150px;"
                            datatextfield="Category" datavaluefield="ID" class="form-control input-sm">
                        </select>
                    </label>
                    <label>
                        <input runat="server" id="sArticle" class="form-control" style="width: 400px;" placeholder="Nhập tiêu đề bài viết">
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
                                
                                <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"
                                    GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
                                    AllowMultiRowSelection="true" AllowFilteringByColumn="false"
                                    OnItemCommand="RadGrid1_ItemCommand" OnNeedDataSource="RadGrid1_NeedDataSource">
                                    <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                                        <Columns>
                                            <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </telerik:GridClientSelectColumn>
                                            <telerik:GridTemplateColumn ShowFilterIcon="false" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("ImgLink") %>' NavigateUrl='<%# Bind("ImgLink", "~{0}") %>'
                                                        runat="server">
                                                        <asp:Image Width="25px" ID="Image1" ImageUrl='<%# Bind("ImgLink", "~{0}") %>' runat="server" onerror="this.src='./images/Default/No_image_available.png';" />
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle Width="47px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="Title" UniqueName="Title" HeaderText="Tiêu đề tin" ShowFilterIcon="false">
                                                <HeaderStyle Width="45%" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridCheckBoxColumn DataField="IsComment" UniqueName="IsComment" HeaderText="Cho phép Comment" ShowFilterIcon="false" ReadOnly="True">
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridCheckBoxColumn>--%>
                                            <telerik:GridBoundColumn DataField="Category" UniqueName="Category" HeaderText="Danh mục" ShowFilterIcon="false">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ViewNumber" UniqueName="ViewNumber" HeaderText="Số lượng xem" ShowFilterIcon="false">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn ShowFilterIcon="false" AllowFiltering="false" HeaderText="Trạng thái">
                                                <ItemTemplate>
                                                    <span class="<%# Eval("CssName") %>"><%# Eval("RecordStatus") %></span>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="PublishDate" UniqueName="PublishDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày xuất bản" ShowFilterIcon="false">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
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
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
            </div>
        </section>
    </ContentTemplate>
</asp:UpdatePanel>
