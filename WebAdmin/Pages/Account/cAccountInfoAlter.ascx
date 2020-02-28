<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cAccountInfoAlter.ascx.cs" Inherits="Pages_Account_cAccountInfo" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa thông tin tài khoản
    </h1>
    <ol class="toolbar">
        <!-- fa-mail-reply -->
        <li><button runat="server" id="Save1" onserverclick="Save_Click" class="btn btn-info btn-sm">
            <i class="fa fa-save"></i>
            <span>Lưu</span>
        </button></li>
        <%--<li><button runat="server" id="SaveAndCreate1" onserverclick="SaveAndCreate_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            <span>Lưu và tạo mới</span>
        </button></li>--%>
        <%--<li><button runat="server" id="Delete1" onserverclick="Delete_Click" class="btn btn-info btn-sm">
            <i class="fa fa-trash-o"></i>
            <span>Xóa</span>
        </button></li>--%>
        <%--<li><button runat="server" id="Back1" onserverclick="Back_Click" class="btn btn-info btn-sm">
            <i class="fa fa-mail-reply"></i>
            <span>Quay lại</span>
        </button></li>--%>
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
                            <label for="exampleInputEmail1">Tài khoản</label>
                            <input runat="server" id="fUserName" class="form-control" placeholder="Nhập tên danh mục tin tức">
                        </div>
                        <div class="form-group">
                            <label>Chọn quyền</label>
                            <select runat="server" id="ddlRGroup" class="form-control">
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Họ tên</label>
                            <input runat="server" id="fFullName" class="form-control" placeholder="Họ tên đầy đủ">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Địa chỉ</label>
                            <input runat="server" id="fAddress" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Điện thoại</label>
                            <input runat="server" id="fTel" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Email</label>
                            <input runat="server" id="fEmail" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Mạng xã hội</label>
                            <input runat="server" id="fSocial" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Ghi chú</label>
                            <textarea runat="server" id="fDescription" class="form-control" rows="3" placeholder="Nhập ghi chú về tài khoản (nếu cần)"></textarea>
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
                    <h3 class="box-title">Đổi mật khẩu</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div class="box-body">
                    <div role="form" class="form">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Mật khẩu cũ</label>
                            <input runat="server" id="fPassWord" type="password" class="form-control">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Mật khẩu mới</label>
                            <input runat="server" id="fPassWordNew" type="password" class="form-control">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Xác nhận mật khẩu mới</label>
                            <input runat="server" id="fPassWordNewConfirm" type="password" class="form-control">
                        </div>
                    </div><!-- /.box-body -->
                </div>
                <div class="box-footer">
                    <button id="Button1" runat="server" onserverclick="ChangePass_Click" type="submit" class="btn btn-primary">Đổi mật khẩu</button>
                </div>
            </div><!-- /.box -->
        </div>
    </div>
</section><!-- /.content -->