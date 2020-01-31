<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cImportExport.ascx.cs" Inherits="Pages_Product_cImportExport" %>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Danh sách nhà sản xuất
    </h1>
    <ol class="toolbar">
    </ol>
</section>

<div runat="server" id="message_box">
</div>


<!-- Main content -->
<section class="content">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div role="form" class="form-custom">
                    <div class="box-body">
                        <div class="form-group">
                            <label>
                                File Excel mẫu
                            </label>
                            <br />
                            <asp:Button runat="server" CssClass="btn btn-info btn-lg" Text="Tải Mẫu" OnClick="DownloadTemplate" Width="30%" /><br />
                        </div>
                        <div class="form-group" id="uploadForm">
                            <label>
                                Chọn file danh sách sản phẩm
                            </label>
                            <br />
                            <button class="btn btn-info btn-lg" id="importButton" style="width: 30%">
                                <i class="fa fa-plus-square"></i>
                                <span>Import Sản phẩm</span>
                            </button>
                            <input runat="server" type="file" id="fileUpload" style="display: none" />
                        </div>
                        <div class="form-group">
                            <label>
                                Tên file :
                            </label>
                            <label id="fileName">
                            </label>
                            <br />
                        </div>
                        <div class="form-group">
                            <label>
                                Upload file Excel
                            </label>
                            <br />
                            <asp:Button runat="server" CssClass="btn btn-info btn-lg" Text="Lưu" OnClick="onUploadExcelFile" Width="30%" /><br />
                        </div>
                    </div>
                </div>
                <!-- /.box -->
            </div>
        </div>
</section>

<script>
    $(document).ready(function () {
        $("#importButton").click(function () {
            //$("#fileUpload").trigger("click");
            $("#uploadForm input").trigger("click");
        });

        $("#uploadForm input").change(function () {
            $("#fileName").text($('input[type=file]').val().replace(/C:\\fakepath\\/i, ''));
        });
    });


</script>
