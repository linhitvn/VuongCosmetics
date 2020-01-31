<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cArticleAlter.ascx.cs" Inherits="Pages_Article_cArticleAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa bài viết
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
                <%--<div class="box-header">
                    <h3 class="box-title">Quick Example</h3>
                </div><!-- /.box-header -->--%>
                <!-- form start -->
                <div role="form" class="form">
                    <div class="box-body">
                        <div class="form-group">
					        <label>Tiêu đề</label>
					        <input runat="server" id="fTitle" class="form-control" placeholder="">
				        </div>
                        <div class="form-group">
					        <label>Thuộc danh mục</label>
					        <select runat="server" id="fCategoryID" datatextfield="Category" datavaluefield="ID" class="form-control" placeholder=""></select>
				        </div>
                        <div role="form" class="form">
                            <div class="form-group" id="uploadForm">
                                <label>Icon (Hình đại diện nếu cần)</label><br />
                                <input type="file" accept="image/*" id="inputFile" name="inputFile" runat="server" onchange="inputFileChange(this)">

                                <asp:Image ID="fImgLink" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
                                    onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />
                                <p class="help-block">Click vào hình để thay đổi</p>
                            </div>
                        </div>
				        <div class="form-group">
					        <label>Mô tả</label>
					        <textarea runat="server" id="fDescription" class="form-control" placeholder="" rows="7"></textarea>
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
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Cấu hình hiển thị</h3>
                </div>
                <div class="box-body">
                    <div class="form-group">
					    <label>Trạng thái</label>
					    <select runat="server" id="fRecordStatusID" datatextfield="RecordStatus" datavaluefield="ID" class="form-control" placeholder=""></select>
				    </div>
                    <div class="form-group">
					    <label>Ngày xuất bản</label>
					    <telerik:RadDatePicker ID="fPublishDate" runat="server" culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
					        <DatePopupButton ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" /> 					  
                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" /> 					
                        </telerik:RadDatePicker>
				    </div>
				    <div class="form-group">
					    <label>Bài viết mới</label>
					    <input runat="server" id="fNew" class="form-control input-number">
                        <p class="help-block">*** số thứ tự xuất hiện trong danh mục bài viết mới. Chọn 0 nếu không muốn hiễn thị</p>
				    </div>
				    <div class="form-group">
					    <label>Bài viết Hot</label>
					    <input runat="server" id="fHot" class="form-control input-number" placeholder="">
                        <p class="help-block">*** số thứ tự xuất hiện trong danh mục bài viết HOT. Chọn 0 nếu không muốn hiễn thị</p>
				    </div>
                    <div class="form-group">
					    <div class="checkbox">
					    <label>
						    <input runat="server" id="fIsComment" type="checkbox" /> Cho phép Comment
					    </label>
					    </div>
				    </div>
				    <div class="form-group">
					    <label>Số lượt xem</label>
					    <input runat="server" id="fViewNumber" class="form-control input-number" placeholder="">
				    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <%--<div class="box-header">
                    <h3 class="box-title">Quick Example</h3>
                </div><!-- /.box-header -->--%>
                <!-- form start -->
                <div role="form" class="form">
                    <div class="box-body">
                        <div class="form-group">
					        <label>Nội dung</label>
                            <telerik:RadEditor ID="fContent" runat="server" EditModes="All" 
                                Height="1000px" Width="100%" oninit="fContent_Init">
                                <Modules>
                                    <telerik:EditorModule Enabled="false" Name="RadEditorStatistics" />
                                </Modules>
                                <ImageManager MaxUploadFileSize="5242880" />
                            </telerik:RadEditor>
				        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="box box-primary collapsed-box">
            <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                <h3 class="box-title">Cấu hình SEO</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                    <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div role="form" class="form">
                        <div class="col-md-6">
                            <div class="form-group">
					            <label>Đường dẫn Rewrite</label>
					            <input runat="server" id="fUrlRewrite" class="form-control" placeholder="">
				            </div>
                            <div class="form-group">
					            <label>Tiêu đề</label>
					            <input runat="server" id="fMetaTitle" class="form-control" placeholder="">
				            </div>
                            <div class="form-group">
					            <label>Từ khóa</label>
					            <input runat="server" id="fMetaKeywords" class="form-control" placeholder="">
				            </div>
                        </div>
                    
                        <div class="col-md-6">
                            <div class="form-group">
					            <label>Mô tả</label>
					            <textarea runat="server" id="fMetaDescription" class="form-control" placeholder="" rows="4"></textarea>
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