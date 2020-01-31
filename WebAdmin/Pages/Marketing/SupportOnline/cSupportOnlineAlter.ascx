<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cSupportOnlineAlter.ascx.cs" Inherits="Pages_Marketing_SupportOnline_cSupportOnlineAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa thông tin
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
            <div class="box box-danger">
                <%--<div class="box-header">
                    <h3 class="box-title">Quick Example</h3>
                </div><!-- /.box-header -->--%>
                <!-- form start -->
                <div role="form" class="form">
                    <div class="box-body">
                        <div class="form-group not-null">
					        <label>
                                <i class="fa fa-asterisk"></i>
                                Tên hiển thị
                            </label>
					        <input runat="server" id="fSupportName" class="form-control" placeholder="">
				        </div>
				        <div class="form-group">
					        <label>Skype</label>
					        <input runat="server" id="fSkype" class="form-control" placeholder="">
				        </div>
				        <div class="form-group">
					        <label>Yahoo!</label>
					        <input runat="server" id="fYahoo" class="form-control" placeholder="Ví dụ: ntanh">
				        </div>
                        <div class="form-group">
					        <label>Điện thoại</label>
					        <input runat="server" id="fPhone" class="form-control" placeholder="">
				        </div>
                        <div class="form-group">
					        <label>
                                E-mail
                            </label>
					        <input runat="server" id="fEmail" class="form-control" placeholder="">
				        </div>
				        <div class="form-group">
					        <label>Vị trí hiển thị</label>
					        <input runat="server" id="fPos" class="form-control input-number">
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
                    <h3 class="box-title">Hình đại diện</h3>
                    <%--<div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>--%>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div class="box-body">
                    <div class="form-group" id="uploadForm">
                        <label>Avata</label><br />
                        <input type="file" accept="image/*" id="inputFile" name="inputFile" runat="server" onchange="inputFileChange(this)">

                        <asp:Image ID="fImgLink" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
                            onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />
                        <p class="help-block">Click vào hình để thay đổi</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Thông tin khác</h3>
                   <%-- <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>--%>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div class="box-body">
                    <div class="form-group">
					    <label>Google+</label>
					    <input runat="server" id="fGooglePlus" class="form-control" placeholder="Trang mạng xã hội Google+">
				    </div>
				    <div class="form-group">
					    <label>FaceBook</label>
					    <input runat="server" id="fFaceBook" class="form-control" placeholder="Trang mạng xã hội Facebook">
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