<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cCategoryAlter.ascx.cs" Inherits="Pages_Article_cCategoryAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa danh mục tin tức
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
            <div class="col-md-12">
                <div class="box box-primary">
                    <%--<div class="box-header">
                        <h3 class="box-title">Quick Example</h3>
                    </div><!-- /.box-header -->--%>
                    <!-- form start -->
                    <div role="form" class="form">
                        <div class="box-body">
                            <div class="form-group">
					            <label>Tên danh mục tin tức</label>
					            <input runat="server" id="fCategory" class="form-control" placeholder="">
				            </div>
				            <div class="form-group">
					            <label>Cấp cha</label>
					            <select runat="server" id="fParentID" datatextfield="Category" datavaluefield="ID" class="form-control" placeholder=""></select>
				            </div>
				            <div class="form-group">
					            <div class="checkbox">
					            <label>
						            <input runat="server" id="fActive" type="checkbox" /> Kích hoạt
					            </label>
					            </div>
				            </div>
				            <div class="form-group">
					            <label>Vị trí</label>
					            <input runat="server" id="fPos" class="form-control input-number" placeholder="">
				            </div>				        
                        </div><!-- /.box-body -->
                        <div class="box-footer">
                            <%--<button id="Button1" runat="server" onserverclick="Save_Click" type="submit" class="btn btn-primary">Lưu</button>--%>
                        </div>
                    </div>
                </div><!-- /.box -->
            </div>
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                        <h3 class="box-title">Hình đại diện</h3>
                    </div>
                    <div class="box-body">
                        <div role="form" class="form">
                            <div class="form-group" id="uploadForm">
                            
                                <input type="file" accept="image/*" id="inputFile" name="inputFile" runat="server" onchange="inputFileChange(this)">
                                <asp:Image ID="fImgLink" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
                                    onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />
                                <br />
                                <p class="help-block">Click vào hình để thay đổi</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Cấu hình SEO</h3>
                </div>
                <div class="box-body">
                    <div role="form" class="form">
                        <div class="form-group">
					        <label>Đường dẫn Rewrite</label>
					        <input runat="server" id="fUrlRewrite" class="form-control" placeholder="">
				        </div>
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
					        <label>Tags</label>
					        <input runat="server" id="fTags" class="form-control" placeholder="">
				        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section><!-- /.content -->
<script type="text/javascript">
    function inputFileChange(input) {
        for (var i = 0; i < input.files.length; i++) {
            var file = input.files[i];
            var reader = new FileReader();

            reader.onloadend = function () {
                fImgLink.src = reader.result;
            }
            reader.readAsDataURL(file);
        }
    }
    $('#uploadForm input').hide();
    $("#fImgLink").click(function () {
        $('#uploadForm input').click().hide();

    });
</script>