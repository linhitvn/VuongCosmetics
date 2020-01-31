<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cFeedBackAlter.ascx.cs"
    Inherits="Pages_Customer_cFeedBackAlter" %>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Phản hồi từ người dùng
    </h1>
    <ol class="toolbar">
        <!-- fa-mail-reply -->
        <!-- compose message btn -->
                            
                            <!-- Navigation - folders-->
        <li runat="server" id="div_btReply">
            <a class="btn btn-info btn-sm" id="composeEmail" data-toggle="modal" data-target="#compose-modal">
                <i class="fa fa-pencil"></i> 
                Trả lời 
            </a>
        </li>
        <li><button runat="server" id="Save" onserverclick="Save_Click" class="btn btn-info btn-sm">
            <i class="fa fa-save"></i>
            <span>Lưu</span>
        </button></li>
        <li><button runat="server" id="SaveAndCreate" onserverclick="SaveAndCreate_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            <span>Lưu và tạo mới</span>
        </button></li>
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
        <div class="col-md-6">
            <div class="box box-primary">
                <div role="form" class="form">
                    <div class="box-body">
                        <div class="form-group not-null">
					        <label>
                                <i class="fa fa-asterisk"></i>
                                Tiêu đề
                            </label>
					        <input runat="server" id="fFeedBack" clientidmode="Static" class="form-control" placeholder="">
				        </div>
				        <div class="form-group">
					        <label>Tên khách hàng</label>
					        <input runat="server" id="fName" class="form-control" placeholder="">
				        </div>
				        <div class="form-group">
					        <label>Địa chỉ</label>
					        <input runat="server" id="fAddress" class="form-control" placeholder="">
				        </div>
				        <div class="form-group">
					        <label>E-mail</label>
					        <input runat="server" clientidmode="Static" id="fEmail" class="form-control" placeholder="">
				        </div>
				        <div class="form-group">
					        <label>Điện thoại</label>
					        <input runat="server" id="fPhone" class="form-control" placeholder="">
				        </div>
                        <div class="form-group not-null">
					        <label>
                                <i class="fa fa-asterisk"></i>
                                Nội dung
                            </label>
                            <textarea runat="server" id="fContent" class="form-control" rows="7"></textarea>
				        </div>
                        <div class="form-group not-null">
					        <label>
                                Thời gian : 
                            </label>
                            <label runat="server" id="fSysDate">
                            </label>
				        </div>
				        <%--<div class="form-group">
					        <div class="checkbox">
					        <label>
						        <input runat="server" id="fisRead" type="checkbox" /> Đã đọc
					        </label>
					        </div>
				        </div>--%>
                        <%--<div class="form-group">
					        <label>Ngày liên hệ</label>
					        <telerik:RadDatePicker ID="fSysDate" runat="server" culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
					          <DatePopupButton ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" /> 					  
                              <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" /> 					
                            </telerik:RadDatePicker>
				        </div>--%>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                            
                    </div>
                </div>
            </div><!-- /.box -->
        </div>
          <div runat="server" id="div_box_reply" class="col-md-6">
            <div class="box box-primary">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Nội dung đã gởi lại</h3>
                    <%--<div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>--%>
                </div>
                <div class="box-body">
                    <telerik:RadGrid ID="RadGrid1" ClientInstanceName="RadGrid1" runat="server" EnableEmbeddedSkins="false"  
                                GridLines="None" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False"
			                AllowMultiRowSelection="false" AllowFilteringByColumn="false">
                        <MasterTableView DataKeyNames="ID" ShowHeadersWhenNoRecords="true" CssClass="table table-bordered table-striped dataTable">
                            <Columns>
                                <telerik:GridBoundColumn DataField="Content" UniqueName="Content" HeaderText="Nội dung" ShowFilterIcon="false">
					                <HeaderStyle Width="60%" HorizontalAlign="Center" /> 
				                </telerik:GridBoundColumn>
				                <telerik:GridBoundColumn DataField="SysDate" UniqueName="SysDate" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" HeaderText="Ngày gởi" ShowFilterIcon="false"> 
					                <HeaderStyle Width="20%" HorizontalAlign="Center" />
				                </telerik:GridBoundColumn>
				                <telerik:GridBoundColumn DataField="Operator" UniqueName="Operator" HeaderText="Người gởi" ShowFilterIcon="false">
					                <HeaderStyle Width="20%" HorizontalAlign="Center" /> 
				                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings>
                            <Selecting AllowRowSelect="true"></Selecting>
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- /.content -->
<!-- COMPOSE MESSAGE MODAL -->
<div class="modal fade" id="compose-modal" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h4 class="modal-title">
                    <i class="fa fa-envelope-o"></i>Soạn thư</h4>
            </div>
            <div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">TO:</span>
                            <input runat="server" id="fEmailTo" clientidmode="Static" name="email_to" class="form-control" placeholder="Email TO">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">Tiêu đề</span>
                            <input runat="server" id="fEmailTitle" clientidmode="Static" class="form-control">
                        </div>
                    </div>
                    <div class="form-group">
                        <textarea runat="server" clientidmode="Static" name="message" id="fEmailContent" class="form-control" placeholder="Message" rows="9"></textarea>
                    </div>
                    <%--<div class="form-group">
                        <div class="btn btn-success btn-file">
                            <i class="fa fa-paperclip"></i>Attachment
                            <input type="file" name="attachment" />
                        </div>
                        <p class="help-block">
                            Max. 32MB</p>
                    </div>--%>
                </div>
                <div class="modal-footer clearfix">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <i class="fa fa-times"></i>Hủy bỏ</button>
                    <button runat="server" id="btSendEmail" onserverclick="btSendEmail_Click" class="btn btn-primary pull-left">
                        <i class="fa fa-envelope"></i>Gởi trả lời</button>
                </div>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->
<!-- Page script -->
<script type="text/javascript">

    $('#composeEmail').click(function () {
        $('#fEmailTo').val($('#fEmail').val());
        $('#fEmailTitle').val('RE: ' + $('#fFeedBack').val());
        
    });

    $(function () {

        "use strict";

        //Initialize WYSIHTML5 - text editor
        $("#fEmailContent").wysihtml5();
    });
        </script>
