<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductOptionGroup.ascx.cs" Inherits="Pages_Product_cProductOptionGroup" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Nhóm tùy chọn sản phẩm
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
            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class=""><a runat="server" href="~/?module=303">Tùy chọn sản phẩm</a></li>
                    <li class="active"><a>Nhóm Tùy Chọn sản phẩm</a></li>
                </ul>
            </div>
            <div class="tab-content">
                <div class="tab-pane active" id="fa-icons">
                    <div class="box">
                        <div class="box-body table-responsive">
                            <div id="Div1" class="dataTables_wrapper form-inline" role="grid">
                                <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"  
                                     GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
			                        AllowMultiRowSelection="true" AllowFilteringByColumn="false" 
                                OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="RadGrid1_NeedDataSource">
                                <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                                    <Columns>
										<telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        </telerik:GridClientSelectColumn>
                                        <telerik:GridBoundColumn DataField="ProductOptionGroup" UniqueName="ProductOptionGroup" HeaderText="Nhóm tùy chọn sản phẩm" ShowFilterIcon="false">
					                        <HeaderStyle Width="40%" HorizontalAlign="Center" /> 
				                        </telerik:GridBoundColumn>
				                        <telerik:GridBoundColumn DataField="Description" UniqueName="Description" HeaderText="Mô tả" ShowFilterIcon="false">
					                        <HeaderStyle Width="50%" HorizontalAlign="Center" /> 
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
                        </div><!-- /.box-body -->
                    </div><!-- /.box -->
                </div>
            </div>

            
        </div>
    </div>
</section>
</ContentTemplate>
</asp:UpdatePanel>
