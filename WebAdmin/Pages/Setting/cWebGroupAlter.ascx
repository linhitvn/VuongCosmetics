<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cWebGroupAlter.ascx.cs" Inherits="Pages_Setting_cWebGroupAlter" %>

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
        <div class="col-md-6">
            <div class="box box-primary">
                <!-- form start -->
                <div role="form" class="form">
                    <div class="box-body">
                        <div class="form-group">
					        <label>Tên nhóm quyền</label>
					        <input runat="server" id="fGroupName" class="form-control">
				        </div>
                        <div class="form-group">
					        <label>Cấp độ nhóm quyền</label>
                            <select runat="server" id="fLevel" datatextfield="LevelName" datavaluefield="LevelID" class="form-control">
                            </select>
                            <p class="help-block">Thành viên Cấp n. Chỉ có thể tạo và quản lý những thành viên có Cấp < n.</p>
				        </div>
                        <div class="form-group">
					        <label>Mô tả</label>
                            <textarea runat="server" id="fDescription" class="form-control" rows="3"></textarea>
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
                        
                    </div>
                </div>
            </div><!-- /.box -->
        </div>
    </div>
</section><!-- /.content -->