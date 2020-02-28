<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cDistrictAlter.ascx.cs" Inherits="Pages_SysCategory_cDistrictAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa Quận/ Huyện
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
					    <label>Quận/ Huyện</label>
					    <input runat="server" id="fDistrict" class="form-control" placeholder="">
				    </div>
				    <div class="form-group">
					    <label>Tỉnh/ Thành phố</label>
                        <select runat="server" id="fProvinceID" datatextfield="Province" datavaluefield="ID" class="form-control"></select>
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