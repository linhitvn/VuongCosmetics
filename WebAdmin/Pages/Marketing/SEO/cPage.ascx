<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cPage.ascx.cs" Inherits="Pages_Marketing_SEO_cPage" %>
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Thiết lập SEO Cho Trang
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
                    <li class="active"><a>Thiết lập SEO Cho Trang</a></li>
                    <li class=""><a id="A1" runat="server" href="~/?module=523">Danh mục sản phẩm</a></li>
                    <li class=""><a id="A3" runat="server" href="~/?module=533">Danh mục tin tức</a></li>
                </ul>
            </div>
            <div class="tab-content">
                <div class="tab-pane active" id="fa-icons">
                    <div class="box">
                       <%-- <telerik:RadTreeList ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="false"
			                    AllowMultiRowSelection="true"  Skin="Metro" AutoGenerateColumns="false"
                            OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="RadGrid1_NeedDataSource"  
                                ParentDataKeyNames="ParentIDCustom" DataKeyNames="ID">
                                <Columns>
                                    <telerik:TreeListBoundColumn DataField="ProductCat" UniqueName="ProductCat" HeaderText="Tên danh mục">
					                    <HeaderStyle Width="30%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
				                    <telerik:TreeListBoundColumn DataField="MetaTitle" UniqueName="MetaTitle" HeaderText="Tiêu đề">
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="MetaDescription" UniqueName="MetaDescription" HeaderText="Mô tả">
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="MetaKeywords" UniqueName="MetaKeywords" HeaderText="Từ khóa">
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
				                    </telerik:TreeListBoundColumn>
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
                        </telerik:RadTreeList>--%>

                        <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"  
                                     GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
			                        AllowMultiRowSelection="true" AllowFilteringByColumn="false" 
                                OnItemCommand="RadGrid1_ItemCommand">
                                <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                                    <Columns>
										
                                        <telerik:GridBoundColumn DataField="Page" UniqueName="Page" HeaderText="Tên Trang" ShowFilterIcon="false">
					                        <HeaderStyle Width="30%" HorizontalAlign="Center" /> 
				                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MetaTitle" UniqueName="MetaTitle" HeaderText="Tiêu đề Seo" ShowFilterIcon="false">
					                        <HeaderStyle Width="20%" HorizontalAlign="Center" /> 
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="MetaDescription" UniqueName="MetaDescription" HeaderText="Mô Tả Seo" ShowFilterIcon="false">
					                        <HeaderStyle Width="20%" HorizontalAlign="Center" /> 
				                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MetaKeywords" UniqueName="MetaKeywords" HeaderText="Keyword Seo" ShowFilterIcon="false">
					                        <HeaderStyle Width="20%" HorizontalAlign="Center" /> 
				                        </telerik:GridBoundColumn>
                                        
				                        <%--<telerik:GridBoundColumn DataField="Price" UniqueName="Price" DataFormatString="{0:###,###}" HeaderText="Giá Bán" ShowFilterIcon="false">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="SalePrice" UniqueName="SalePrice" DataFormatString="{0:###,###}" HeaderText="Giá giảm" ShowFilterIcon="false">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="Quantity" UniqueName="Quantity" DataFormatString="{0:###,###}" HeaderText="Số lượng" ShowFilterIcon="false">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="NumSaled" UniqueName="NumSaled" DataFormatString="{0:###,###}" HeaderText="Đã bán" ShowFilterIcon="false">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
				                        </telerik:GridBoundColumn>
				                        <telerik:GridCheckBoxColumn DataField="IsShow" UniqueName="IsShow" HeaderText="Hiễn thị" ShowFilterIcon="false" ReadOnly="True">
					                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
					                        <ItemStyle HorizontalAlign="Center" />
				                        </telerik:GridCheckBoxColumn>--%>
                                        <telerik:GridTemplateColumn ShowFilterIcon="false" AllowFiltering="false">
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" /> 
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" CommandName='<%# ActRow.Edit %>'
                                                    CommandArgument='<%# Eval("ID") %>' runat="server"
                                                    ImageUrl="~/images/edit.png" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
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