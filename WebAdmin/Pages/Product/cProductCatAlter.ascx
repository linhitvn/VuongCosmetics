<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductCatAlter.ascx.cs" Inherits="Pages_Product_cProductCatAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa danh mục sản phẩm
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
                    <div class="box-body">
                        <!-- form start -->
                        <div role="form" class="form">
                            <div role="form" class="form">
                                <div class="form-group" id="uploadForm">
                                    <label>Hình đại diện (Click vào hình để chọn)</label><br />
                                    <input type="file" accept="image/*"  id="inputFile" name="inputFile" runat="server" onchange="inputFileChange(this)" >
                                    <asp:Image ID="fIconLink" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
                                        onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />
                                    <p class="help-block">Click vào hình để thay đổi</p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>Tên danh mục</label>
                                <input runat="server" id="fProductCat" class="form-control" placeholder="">
                            </div>
                            <div class="form-group">
                                <label>Danh mục cha</label>
                                <select runat="server" id="fParentID" datatextfield="ProductCat" datavaluefield="ID" class="form-control" placeholder=""></select>
                            </div>
                            <div class="form-group">
                                <label>Mô tả</label>
                                <textarea runat="server" id="fDescription" class="form-control" rows="3"></textarea>
                            </div>
                            <div class="form-group">
                                <label>Vị trí</label>
                                <input runat="server" id="fPos" class="input-number form-control" placeholder="">
                            </div>
                        </div>
                        <!-- ./Box body -->
                    </div>
                </div>
                <!-- /.box -->
            </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Cấu hình SEO</h3>
                </div>
                <div class="box-body">
                    <div role="form" class="form">
                        <div class="form-group">
                            <label>Tiêu đề</label>
                            <input runat="server" id="fMetaTitle" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label>Mô tả</label>
                            <input runat="server" id="fMetaDescription" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label>Từ khóa</label>
                            <input runat="server" id="fMetaKeywords" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label>Thẻ (Tags)</label>
                            <input runat="server" id="fTags" class="form-control" placeholder="">
                        </div>
                    </div>
                </div>
            </div>
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
                fIconLink.src = reader.result;
            }
            reader.readAsDataURL(file);
        }
    }
    $('#uploadForm input').hide();
    $("#fIconLink").click(function () {
        $('#uploadForm input').click().hide();
        
    });
</script>
