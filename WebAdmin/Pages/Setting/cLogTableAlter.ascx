<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cLogTableAlter.ascx.cs" Inherits="Pages_Setting_cLogTableAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Cấu hình ghi Log dữ liệu
    </h1>
    <ol class="toolbar">
        <!-- fa-mail-reply -->
        <li><button runat="server" id="btEnale" onserverclick="Enable_Click" class="btn btn-info btn-sm">
            <i class="fa fa-play"></i>
            <span>Kích hoạt ghi Log</span>
        </button></li>
        <li><button runat="server" id="btDisable" onserverclick="Disable_Click" class="btn btn-info btn-sm">
            <i class="fa fa-stop"></i>
            <span>Ngưng ghi Log</span>
        </button></li>
        <li><button runat="server" id="Save" onserverclick="Save_Click" class="btn btn-info btn-sm">
            <i class="fa fa-save"></i>
            <span>Lưu</span>
        </button></li>
        <%--<li><button runat="server" id="SaveAndCreate" onserverclick="SaveAndCreate_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            <span>Lưu và tạo mới</span>
        </button></li>--%>
        <li><button runat="server" id="Back" onserverclick="Back_Click" class="btn btn-info btn-sm">
            <i class="fa fa-mail-reply"></i>
            <span>Quay lại</span>
        </button></li>
    </ol>
</section>

<div runat="server" id="message_box">    
</div>

<!-- Main content -->
<section class="content">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <%--<div class="box-header">
                    <h3 class="box-title">Quick Example</h3>
                </div><!-- /.box-header -->--%>
                <!-- form start -->
                <div role="form" class="form-custom">
                    <div class="box-body">
                    <div class="form-group">
				        <label>Tên Table</label>
                        <select runat="server" id="fTableName" datatextfield="TableName" datavaluefield="TableName" class="form-control">
                        </select>
			        </div>
                    </div><!-- /.box-body -->
                </div>
            </div><!-- /.box -->
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" Skin="MyCustomSkin" EnableEmbeddedSkins="false"  
                         GridLines="None" PageSize="10" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
			            AllowMultiRowSelection="true" AllowFilteringByColumn="false">
                    <MasterTableView ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="RowNo" HeaderText="#" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# (Container.ItemIndex + (RadGrid1.CurrentPageIndex * RadGrid1.PageSize) + 1).ToString()%>
                                </ItemTemplate>
                                <ItemStyle Width="5%" HorizontalAlign="Center"/>
                            </telerik:GridTemplateColumn>
				            <telerik:GridBoundColumn DataField="name" UniqueName="name" HeaderText="Trigger" ShowFilterIcon="false">
					            <HeaderStyle Width="45%" HorizontalAlign="Center" />
				            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="is_visibled" UniqueName="is_visibled" HeaderText="Kích hoạt" ShowFilterIcon="false" ReadOnly="True">
					            <HeaderStyle Width="10%" HorizontalAlign="Center" />
					            <ItemStyle HorizontalAlign="Center" />
				            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="create_date" UniqueName="create_date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày tạo" ShowFilterIcon="false"> 
					            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
				            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="modify_date" UniqueName="modify_date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày chỉnh sửa" ShowFilterIcon="false"> 
					            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
				            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="true">            
                        <Selecting AllowRowSelect="true"></Selecting>
                    </ClientSettings>
                </telerik:RadGrid>    
            </div><!-- /.box -->
        </div>
    </div>
</section><!-- /.content -->