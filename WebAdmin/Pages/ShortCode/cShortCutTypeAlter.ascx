<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cShortCutTypeAlter.ascx.cs" Inherits="Pages_Setting_cShortCutAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa Loại ShortCut
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
                <%--<div class="box-header">
                    <h3 class="box-title">Quick Example</h3>
                </div><!-- /.box-header -->--%>
                <!-- form start -->
                <div role="form" class="form-custom">
                    <div class="box-body">
                        <div class="form-group">
					        <label>Loại ShortCut</label>
					        <input runat="server" id="fShortCutType" class="form-control">
				        </div>
				        <div class="form-group">
					        <label>Mô tả</label>
					        <textarea runat="server" id="fDescription" class="form-control" rows="3"> </textarea>
				        </div>
				        <div class="form-group">
					        <label>HTML mặc định</label>
					        <textarea runat="server" id="fHTMLDefault" class="form-control" rows="5" 
                                placeholder="Dùng để khôi phục định dạng Item chuẩn trong Shortcut"></textarea>
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
    </div>
</section><!-- /.content -->