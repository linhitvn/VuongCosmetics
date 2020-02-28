<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProducerAlter.ascx.cs" Inherits="Pages_Product_cProducerAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Thông tin nhà sản xuất
    </h1>
    <ol class="toolbar">
        <!-- fa-mail-reply -->
        <li>
            <button runat="server" id="Save" onserverclick="Save_Click" class="btn btn-info btn-sm">
                <i class="fa fa-save"></i>
                <span>Lưu</span>
            </button>
        </li>
        <li>
            <button runat="server" id="SaveAndCreate" onserverclick="SaveAndCreate_Click" class="btn btn-info btn-sm">
                <i class="fa fa-plus-square"></i>
                <span>Lưu và tạo mới</span>
            </button>
        </li>
        <li>
            <button runat="server" id="Back" onserverclick="Back_Click" class="btn btn-info btn-sm">
                <i class="fa fa-mail-reply"></i>
                <span>Quay lại</span>
            </button>
        </li>
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
                        <div class="form-group not-null">
                            <label>
                                <i class="fa fa-asterisk"></i>
                                Tên nhà sản xuất
                            </label>
                            <input runat="server" id="fProducerName" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label>Mô tả</label>
                            <textarea runat="server" id="fDescription" class="form-control" rows="3"></textarea>
                        </div>
                        <div class="form-group">
                            <label>Địa chỉ Website</label>
                            <input runat="server" id="fWebsite" class="form-control" placeholder="">
                        </div>
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer">
                        <%--<button id="Button1" runat="server" onserverclick="Save_Click" type="submit" class="btn btn-primary">Lưu</button>--%>
                    </div>
                </div>
            </div>
            <!-- /.box -->
        </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <%--<div class="box-header">
                    <h3 class="box-title">Quick Example</h3>
                </div><!-- /.box-header -->--%>
                <!-- form start -->
                <div role="form" class="form-custom">
                    <div class="box-body">
                        <div class="form-group" id="uploadForm">
                            <label>Logo nhà sản xuất</label><br />

                            <input type="file" accept="image/*"  id="inputFile" name="inputFile" runat="server" onchange="inputFileChange(this)">
                            <asp:Image ID="fLogoLink" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
                                onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />

                            <p class="help-block">Click vào hình để thay đổi.</p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.box -->
        </div>
    </div>
</section>
<!-- /.content -->
<script type="text/javascript">
    function inputFileChange(input) {
        for (var i = 0; i < input.files.length; i++) {
            var file = input.files[i];
            var reader = new FileReader();

            reader.onloadend = function () {
                fLogoLink.src = reader.result;
            }
            reader.readAsDataURL(file);
        }
    }
    $('#uploadForm input').hide();
    $("#fLogoLink").click(function () {
        $('#uploadForm input').click().hide();

    });
</script>
