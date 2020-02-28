<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cWebConfig.ascx.cs" Inherits="Pages_Setting_cWebConfig" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-android"></i>
        Cấu hình thông số hệ thống
    </h1>
    <ol class="toolbar">
        <li><%--<button visible="false" runat="server" id="btCreate" onserverclick="New_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            </button>--%>
            <button runat="server" id="Button1" onserverclick="UpdateListConfigValue_CLick" class="btn btn-info btn-sm"><span>Cập nhật cấu hình</span></button>
        </li>
       <%-- <li><button visible="false" runat="server" id="btClone" onserverclick="Clone_Click" class="btn btn-info btn-sm">
            <i class="fa fa-copy"></i>
            <span>Sao chép</span>
            </button>
       </li>

        <li>
            <button visible="false" runat="server" id="btDelete" onclick="javascript:ConfirmDeleteCustom();" onserverclick="Delete_Click" class="btn btn-info btn-sm">
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
            <div class="box">
                    
                <div class="box-body table-responsive">
                    <div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"  
                                 GridLines="None" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
			                    AllowMultiRowSelection="true" AllowFilteringByColumn="false" 
                            OnItemCommand="RadGrid1_ItemCommand" onneeddatasource="RadGrid1_NeedDataSource">
                            <MasterTableView DataKeyNames="ConfigID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-hover dataTable">
                                <Columns>
							        <%--<telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="5%" HorizontalAlign="Center"/>
                                    </telerik:GridClientSelectColumn>--%>
							       <%-- <telerik:GridBoundColumn DataField="ConfigKey" UniqueName="ConfigKey" HeaderText="Từ khóa" ShowFilterIcon="false">
					                    <HeaderStyle Width="30%" HorizontalAlign="Center" /> 
				                    </telerik:GridBoundColumn>--%>
				                    <%--<telerik:GridBoundColumn DataField="ConfigValue" UniqueName="ConfigValue" DataFormatString="{0:###,###;#;0}" HeaderText="Giá trị" ShowFilterIcon="false">
					                <HeaderStyle Width="30%" HorizontalAlign="Center" /> 
				                    </telerik:GridBoundColumn>--%>

				                    <telerik:GridBoundColumn DataField="Description" UniqueName="Description" HeaderText="Mô tả" ShowFilterIcon="false">
					                    <HeaderStyle Width="30%" HorizontalAlign="Center" /> 
				                    </telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn UniqueName="ConfigValue" ShowFilterIcon="false" AllowFiltering="false" HeaderText="Giá trị" HeaderStyle-HorizontalAlign="Center">
                                         <ItemTemplate>
                                            <telerik:RadTextBox ID="fConfigValue" runat="server"  class="form-control" Text='<%# Eval("ConfigValue") %>'  Value='<%# Eval("ConfigValue") %>'>
                                            </telerik:RadTextBox>
                                         </ItemTemplate>
                                         <ItemStyle Width="10%" HorizontalAlign="Center"/>
                                      </telerik:GridTemplateColumn>

                                     <telerik:GridBoundColumn DataField="IsIntValue" UniqueName="IsIntValue" Display="false" />
							        <%--<telerik:GridTemplateColumn ShowFilterIcon="false" AllowFiltering="false">
								        <ItemTemplate>
									        <asp:ImageButton ID="ImageButton2" CommandName='<%# ActRow.Edit %>'
										        CommandArgument='<%# Eval("ConfigID") %>' runat="server" ImageUrl="~/images/edit.png" ToolTip="Chỉnh sửa" />
								        </ItemTemplate>
								        <ItemStyle HorizontalAlign="Center" Width="5%" />
							        </telerik:GridTemplateColumn>--%>
						        </Columns>
                            </MasterTableView>
                            <ClientSettings>            
                                <Selecting AllowRowSelect="true" UseClientSelectColumnOnly="true" />
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