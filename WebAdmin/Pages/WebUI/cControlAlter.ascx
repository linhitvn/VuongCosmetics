<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cControlAlter.ascx.cs" Inherits="Pages_WebUI_cControlAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa Control
    </h1>
    <ol class="toolbar">
        <!-- fa-mail-reply -->
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
                <%--<div class="box-header">
                    <h3 class="box-title">Quick Example</h3>
                </div><!-- /.box-header -->--%>
                <!-- form start -->
                <div role="form" class="form">
                    <div class="box-body">
                        <div class="form-group">
					        <label>Tên control</label>
					        <input runat="server" id="fControlName" class="form-control" placeholder="">
                            <p class="help-block">Sẻ hiển thị tại tiêu đề của Control nếu có trong thiết kế HTML</p>
				        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-group">
					                <label>Thuộc Trang</label>
                                    <asp:DropDownList runat="server" id="fPageID" 
                                        AutoPostBack="true"
                                        datatextfield="Page" datavaluefield="ID" class="form-control" 
                                        onselectedindexchanged="fPageID_SelectedIndexChanged"></asp:DropDownList>
				                </div>
                                <div class="form-group">
					                <label>Thuộc Control</label>
					                <select runat="server" id="fParentID" datatextfield="ControlName" datavaluefield="ID" class="form-control"></select>
				                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
				        <div class="form-group">
					        <label>Thứ tự hiển thị</label>
					        <input runat="server" id="fPos" class="form-control input-number" placeholder="">
				        </div>
				        <div class="form-group">
					        <div class="checkbox">
					        <label>
						        <input runat="server" id="fActive" type="checkbox" /> Kích hoạt
					        </label>
					        </div>
				        </div>

                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        <%--<button id="Button1" runat="server" onserverclick="Save_Click" type="submit" class="btn btn-primary">Lưu</button>--%>
                    </div>
                </div>
            </div><!-- /.box -->
        </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Thiết kế Control</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div role="form" class="form">
                    <div class="box-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                 <div class="form-group">
					                    <label>Control Template</label>
                                        <asp:DropDownList runat="server" id="fUControl" 
                                            datatextfield="ControlListName" datavaluefield="ControlPath"
                                            AutoPostBack="true"
                                            class="form-control" 
                                            onselectedindexchanged="fUControl_SelectedIndexChanged"></asp:DropDownList>
				                    </div>
				                    <div class="form-group">
					                    <label>Thông số Control</label>
					                    <input runat="server" id="fparam" class="form-control">
                                        <p runat="server" id="fParamHelp" class="help"></p>
				                    </div>
                                    <div class="form-group">
					                    <label></label>
                                        <asp:Image id="fImgLink" runat="server" Height="200px"
                                            onerror="this.src='./images/Default/No_image_available.png';"/>
				                    </div>
                                    <div class="form-group" style="display: none;">
					                    <div class="checkbox">
					                    <label>
						                    <input runat="server" id="fIsAdsControl" type="checkbox" /> Là Control Quảng Cáo
					                    </label>
					                    </div>
				                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div><!-- /.box -->
        </div>
    </div>
</section><!-- /.content -->