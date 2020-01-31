<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cWebFunction.ascx.cs" Inherits="Pages_Setting_cWebFunction" %>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Quản lý chức năng trang Admin
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
                     <telerik:RadTreeList ID="rtl" runat="server" AllowPaging="True" AllowSorting="false"
			                    AllowMultiRowSelection="true"  Skin="Metro" AutoGenerateColumns="false"
                            OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="rtl_NeedDataSource"  ParentDataKeyNames="ParentID" DataKeyNames="FuncID">
                                <Columns>
				                    <telerik:TreeListBoundColumn DataField="VNName" UniqueName="VNName" HeaderText="VNName" >
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
				                    <telerik:TreeListBoundColumn DataField="UControl" UniqueName="UControl" HeaderText="UControl" >
					                    <HeaderStyle Width="20%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="FuncID" UniqueName="FuncID" HeaderText="FuncID" >
					                    <HeaderStyle Width="10%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
				                    <telerik:TreeListBoundColumn DataField="UKey" UniqueName="UKey" HeaderText="Thông số phụ" >
					                    <HeaderStyle Width="10%" HorizontalAlign="Center" /> 
				                    </telerik:TreeListBoundColumn>
				                    <telerik:TreeListCheckBoxColumn DataField="Active" UniqueName="Active" HeaderText="Active"  ReadOnly="True">
					                    <HeaderStyle Width="10%" HorizontalAlign="Center" />
					                    <ItemStyle HorizontalAlign="Center" />
				                    </telerik:TreeListCheckBoxColumn>
				                    <telerik:TreeListBoundColumn DataField="DisplayOrder" UniqueName="DisplayOrder" HeaderText="DisplayOrder" >
					                    <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
				                    </telerik:TreeListBoundColumn>
				                    <telerik:TreeListCheckBoxColumn DataField="isShow" UniqueName="isShow" HeaderText="isShow"  ReadOnly="True">
					                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
					                    <ItemStyle HorizontalAlign="Center" />
				                    </telerik:TreeListCheckBoxColumn>
                                    <telerik:TreeListSelectColumn HeaderText="Chọn" UniqueName="ClientSelectColumn1" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </telerik:TreeListSelectColumn>
                                    <telerik:TreeListTemplateColumn>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" CommandName='<%# ActRow.Edit %>'
                                                CommandArgument='<%# Eval("FuncID") %>' runat="server" ImageUrl="~/images/edit.png" ToolTip="Chỉnh sửa" />
                                        </ItemTemplate>
					                    <ItemStyle HorizontalAlign="Center" />
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