<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cWebFunctionAlter.ascx.cs" Inherits="Pages_Setting_cWebFunctionAlter" %>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa nhóm quyền
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
        <div class="col-md-12">
            <div class="box box-primary">
                <!-- form start -->
                <div role="form" class="form-custom">
                    <div class="box-body">
                        <div class="form-group">
					        <label>ID</label>
					        <input runat="server" id="fFuncID" class="form-control">
				        </div>
                        <div class="form-group">
					        <label>Tên chức năng (Tiếng Việt)</label>
					        <input runat="server" id="fVNName" class="form-control">
				        </div>
                        <div class="form-group" style="display: none">
					        <label>Tên chức năng (Tiếng Anh)</label>
					        <input runat="server" id="fENName" class="form-control">
				        </div>
                        <div class="form-group">
					        <label>Chức năng cha</label>
					        <select runat="server" id="fParentID" datatextfield="VNName" datavaluefield="FuncID" class="form-control"></select>
				        </div>
                        <div class="form-group">
					        <label>Đường cẩn Module</label>
					        <input runat="server" id="fUControl" class="form-control">
				        </div>
                        <div class="form-group">
					        <label>Thông số phụ</label>
					        <input runat="server" id="fUKey" class="form-control">
				        </div>
                        <div class="form-group" style="display: none">
					        <label>URLLink</label style="display: none">
					        <input runat="server" id="fURLLink" class="form-control">
				        </div>
                        <div class="form-group" style="display: none">
					        <label>Role</label>
					        <input runat="server" id="fRole" class="form-control">
				        </div>
                        <div class="form-group">
					        <label>CssClass</label>
					        <input runat="server" id="fCssClass" class="form-control">
				        </div>
                        <div class="form-group" style="display: none">
					        <label>Icon</label>
					        <input runat="server" id="fIcon" class="form-control">
				        </div>
                        <div class="form-group" style="display: none">
					        <label>IconHover</label>
					        <input runat="server" id="fIconHover" class="form-control">
				        </div>
                        <div class="form-group">
					        <label>DisplayOrder</label>
					        <input runat="server" id="fDisplayOrder" class="form-control">
				        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input runat="server" id="fisShow" type="checkbox" /> Hiển thị
                                </label>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <input runat="server" id="fActive" type="checkbox" /> Kích hoạt
                                </label>
                            </div>
                        </div>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                    </div>
                </div>
            </div><!-- /.box -->
        </div>
    </div>
</section><!-- /.content -->