<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductAlter.ascx.cs" Inherits="Pages_Product_cProductAlter" %>

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Thông tin sản phẩm
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
        <!-- Thông tin cơ bản -->
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Thông tin cơ bản</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <div role="form" class="form">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Tên sản phẩm</label>
                            <input runat="server" id="fProductName" class="form-control" placeholder="">
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                 <div class="form-group">
                                    <label>Mã Sản phẩm (SKU)</label>
                                    <input runat="server" id="fProductCode" class="form-control" placeholder="Dùng để quản lý và tìm kiếm sản phẩm. Ví dụ: #00001">
                                </div>
                            </div>
                            <div class="col-lg-6">
                                 <div class="form-group">
                                    <label>Đơn vị tính</label>
                                    <input runat="server" id="fUnitName" class="form-control" placeholder="">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Nhà sản xuất</label>
                            <select runat="server" id="fProducerID" datatextfield="ProducerName" datavaluefield="ID" class="form-control"></select>
                        </div>
                        <div class="form-group">
                                <label>Ngày tạo</label>
                                <telerik:RadDatePicker ID="fSysDate" runat="server" Culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
                                    <DatePopupButton Enabled="false" ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" />
                                    <DateInput runat="server" Enabled="false" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" />
                                </telerik:RadDatePicker>
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

        <!-- Hiển thị sản phẩm -->
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Hiển thị sản phẩm</h3>
                    <%--<div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>--%>
                </div>
                <div class="box-body">
                    <div class="row">
                        
                        <div class="col-md-6">
                            <div role="form" class="form">
                                <label>Hình đại diện sản phẩm</label>
	                            <div class="form-group" id="uploadFormImg1">
		                            <input type="file" accept="image/*"  id="inputFileImg1" name="inputFileImg1" runat="server" onchange="inputFileImg1Change(this)" >
		                            <asp:Image ID="fImgLink1" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
			                            onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />
		                            <p class="help-block">Click vào hình để thay đổi</p>
	                            </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Vị trí hiễn thị</label>
                                <input runat="server" id="fPos" class="form-control input-number" placeholder="">
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <label>
                                        <input runat="server" id="fIsNewProduct" type="checkbox" />
                                        Sản phẩm mới
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <label>
                                        <input runat="server" id="fIsHot" type="checkbox" />
                                        Sản phẩm HOT
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <label>
                                        <input runat="server" id="fIsShow" type="checkbox" />
                                        <b>Hiện/ Ẩn sản phẩm</b>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <label>
                                        <input runat="server" id="fIsHiddenWhenOutoff" type="checkbox" />
                                        Hết hàng (&#10004; khi hết hàng)
                                    </label>
                                </div>
                            </div>
                            <div class="form-group" style="display: none;">
                                <div class="checkbox">
                                    <label>
                                        <input runat="server" id="fIsShowYouSaving" type="checkbox" />
                                        Hiển thị "Bạn tiết kiệm"
                                    </label>
                                </div>
                            </div>
                            <div class="form-group" style="display: none;">
                                <label>Đổi chữ nút "Mua hàng"</label>
                                <input runat="server" id="fBuyButtonText" class="form-control" placeholder="">
                            </div>
                            <div class="form-group" style="display: none;">
                                <label>Mục hiễn thị tại trang chủ</label>
                                <input runat="server" id="fShowInProductTyleID" class="form-control" placeholder="">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Giá sản phẩm -->
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Giá sản phẩm</h3>
                    <%--<div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>--%>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Thuế</label>
                                <select runat="server" id="fVATID" datatextfield="VATName" datavaluefield="ID" class="form-control"></select>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Giá bán</label>
                                <input runat="server" id="fPrice" class="form-control" placeholder="">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Giá khuyến mãi</label>
                                <input runat="server" id="fSalePrice" class="form-control" placeholder="">
                            </div>
                        </div>
                    </div>
                    <div class="form-group" style="display: none;">
                        <label>Giá đã giảm (Chạy Schedule)</label>
                        <input runat="server" id="fSchSalePrice" class="form-control input-number" text="123" value="123123" placeholder="">
                    </div>
                    <div class="form-group" style="display: none;">
                        <label>Giảm từ ngày</label>
                        <telerik:RadDatePicker ID="fScheSaleFrom" runat="server" Culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
                            <DatePopupButton ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" />
                            <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" />
                        </telerik:RadDatePicker>
                    </div>
                    <div class="form-group" style="display: none;">
                        <label>Giảm đến ngày</label>
                        <telerik:RadDatePicker ID="fScheSaleTo" runat="server" Culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
                            <DatePopupButton ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" />
                            <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" />
                        </telerik:RadDatePicker>
                    </div>
                </div>
            </div>
        </div>


    </div>
    <div class="row">
        <!-- Danh mục sản phẩm -->
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Danh mục sản phẩm</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <telerik:RadTreeView runat="server" ID="RadTreeView1" DataFieldID="ID" DataFieldParentID="ParentIDCustom"
                        TriStateCheckBoxes="true" CheckBoxes="true" CheckChildNodes="true" Skin="Metro">
                        <DataBindings>
                            <telerik:RadTreeNodeBinding TextField="ProductCat" ValueField="ID" Expanded="true" CheckedField="Active"></telerik:RadTreeNodeBinding>
                        </DataBindings>
                    </telerik:RadTreeView>
                </div>
            </div>
        </div>

        <!-- Quản lý tồn kho -->
        <div class="col-md-6" style="display: none;">
            <div class="box box-primary collapsed-box">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Quản lý tồn kho</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body" style="display: none;">
                    <div class="form-group">
                        <div class="checkbox">
                            <label>
                                <input runat="server" id="fIsManagerQuantity" type="checkbox" />
                                Quản lý tồn kho
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Số lượng hàng</label>
                        <input runat="server" id="fQuantity" class="form-control input-number" placeholder="">
                    </div>
                    <div class="form-group">
                        <label>Số lượng đã bán</label>
                        <input runat="server" id="fNumSaled" class="form-control input-number" placeholder="">
                    </div>
                </div>
            </div>
        </div>
        <!-- Mô tả sản phẩm -->
        <div class="col-md-6" style="display: none;">
            <div class="box box-primary collapsed-box">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">mô tả sản phẩm</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body" style="display: none;">
                    <div class="form-group">
                        <label>Mô tả ngắn(hiển thị phí dưới sản phẩm)</label>
                        <input runat="server" id="fDesShort" class="form-control" placeholder="">
                    </div>
                    <div class="form-group">
                        <label>Mô tả hiển thị phía trên giá</label>
                        <input runat="server" id="fDesBeforPrice" class="form-control" placeholder="">
                    </div>
                    <div class="form-group">
                        <label>Mô tả hiển thị phía dưới giá</label>
                        <input runat="server" id="fDesAfterPrice" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
        </div>
        
        <!-- khác -->
        <div class="col-md-6" style="display: none;">
            <div class="box box-primary collapsed-box">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Khác</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body" style="display: none;">
                    <div class="form-group">
                        <label>Số lượng đặt hàng ít nhất</label>
                        <input runat="server" id="fMinOrder" class="form-control" placeholder="">
                    </div>
                    <div class="form-group">
                        <label>Số lượng cảnh báo sắp hết hàng</label>
                        <input runat="server" id="fMaxForWarrning" class="form-control" placeholder="">
                    </div>
                    <div class="form-group">
                        <label>Điểm thưởng</label>
                        <input runat="server" id="fBonusPoint" class="form-control" placeholder="">
                    </div>
                    <div class="form-group">
                        <div class="checkbox">
                            <label>
                                <input runat="server" id="fIsAllowComment" type="checkbox" />
                                Cho phép bình luận
                            </label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Liên kết sản phẩm -->
        <div class="col-md-6" style="display: none;">
            <div class="box box-primary collapsed-box">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Liên kết sản phẩm</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body" style="display: none;">
                </div>
            </div>
        </div>
        <!-- Quản lý tồn kho -->
        <div class="col-md-6" style="display: none;">
            <div class="box box-primary collapsed-box">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Quản lý tồn kho</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body" style="display: none;">
                </div>
            </div>
        </div>
        <!-- Hình theo tùy chọn -->
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Thư viện ảnh (Không bắt buộc)</h3>
                </div>
                <div class="box-body"">
                    <%--<div id="uploadForm" class="form-group">
                        <div class="image-div">
                            <div class="img-container">
    	                        <div class="img-upload">
                                    <input type="text" runat="server" id="hidenInput1" style="display:none">
    		                        <img class="img-thumbnail" src="~" id="fImage1" runat="server"/>
                                    <input type="file" accept="image/*" runat="server" onchange="fileInputChange(this)" style="display:none">
    		                        <div class="del-button">
    			                        <button class="fa fa-times btn-default" onclick="delFunc(this)"></button>
    		                        </div>
    	                        </div>
                            </div>
                        </div>
                        <div class="image-div">
                            <div class="img-container">
    	                        <div class="img-upload">
                                    <input type="text" runat="server" id="hidenInput2" style="display:none">
    		                        <img class="img-thumbnail" src="~" id="fImage2" runat="server"/>
                                    <input type="file" accept="image/*" runat="server" onchange="fileInputChange(this)" style="display:none">
    		                        <div class="del-button">
    			                        <button class="fa fa-times btn-default" onclick="delFunc(this)"></button>
    		                        </div>
    	                        </div>
                            </div>
                        </div>
                        <div class="image-div">
                            <div class="img-container">
    	                        <div class="img-upload">
                                    <input type="text" runat="server" id="hidenInput3" style="display:none">
    		                        <img class="img-thumbnail" src="~" id="fImage3" runat="server"/>
                                    <input type="file" accept="image/*" runat="server" onchange="fileInputChange(this)" style="display:none">
    		                        <div class="del-button" >
    			                        <button class="fa fa-times btn-default" onclick="delFunc(this)"></button>
    		                        </div>
    	                        </div>
                            </div>
                        </div>
                        <div class="image-div">
                            <div class="img-container">
    	                        <div class="img-upload">
                                    <input type="text" runat="server" id="hidenInput4" style="display:none">
    		                        <img class="img-thumbnail" src="~" id="fImage4" runat="server"/>
                                    <input type="file" accept="image/*" runat="server" onchange="fileInputChange(this)" style="display:none">
    		                        <div class="del-button">
    			                        <button class="fa fa-times btn-default" onclick="delFunc(this)"></button>
    		                        </div>
    	                        </div>
                            </div>
                        </div>
                        <div class="image-div">
                            <div class="img-container">
    	                        <div class="img-upload">
                                    <input type="text" runat="server" id="hidenInput5" style="display:none">
    		                        <img class="img-thumbnail" src="~" id="fImage5" runat="server"/>
                                    <input type="file" accept="image/*" runat="server" onchange="fileInputChange(this)" style="display:none">
    		                        <div class="del-button">
    			                        <button class="fa fa-times btn-default" onclick="delFunc(this)"></button>
    		                        </div>
    	                        </div>
                            </div>
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-md-6">
                            <div role="form" class="form">
	                            <div class="form-group" id="uploadFormImg2" style="text-align: center;">
		                            <input type="file" accept="image/*"  id="inputFileImg2" name="inputFileImg2" runat="server" onchange="inputFileImg2Change(this)" >
		                            <asp:Image ID="fImgLink2" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
			                            onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />
		                            <p class="help-block">Click vào hình để thay đổi</p>
	                            </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div role="form" class="form">
	                            <div class="form-group" id="uploadFormImg3" style="text-align: center;">
		                            <input type="file" accept="image/*"  id="inputFileImg3" name="inputFileImg3" runat="server" onchange="inputFileImg3Change(this)" >
		                            <asp:Image ID="fImgLink3" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
			                            onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />
		                            <p class="help-block">Click vào hình để thay đổi</p>
	                            </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div role="form" class="form">
	                            <div class="form-group" id="uploadFormImg4" style="text-align: center;">
		                            <input type="file" accept="image/*"  id="inputFileImg4" name="inputFileImg4" runat="server" onchange="inputFileImg4Change(this)" >
		                            <asp:Image ID="fImgLink4" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
			                            onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />
		                            <p class="help-block">Click vào hình để thay đổi</p>
	                            </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div role="form" class="form">
	                            <div class="form-group" id="uploadFormImg5" style="text-align: center;">
		                            <input type="file" accept="image/*"  id="inputFileImg5" name="inputFileImg5" runat="server" onchange="inputFileImg5Change(this)" >
		                            <asp:Image ID="fImgLink5" runat="server" Width="100px" Height="100px" ClientIDMode="Static"
			                            onerror="this.src='./images/Default/No_image_available.png';" class="img-thumbnail" />
		                            <p class="help-block">Click vào hình để thay đổi</p>
	                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
                            <telerik:RadEditor ID="fDescription" runat="server" EditModes="All" 
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
    <!-- Cấu Hình SEO -->
    <div class="col-md-12">
        <div class="box box-primary">
            <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                <h3 class="box-title">Cấu hình SEO</h3>
            </div>
            <div class="box-body">
                <div class="row">
                    <div role="form" class="form">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>URL Sản phẩm</label>
                                <input runat="server" id="fRewriteURL" class="form-control" placeholder="">
                            </div>
                            <div class="form-group">
                                <label>Tiêu đề trang</label>
                                <input runat="server" id="fPageTitle" class="form-control" placeholder="">
                            </div>
                            <div class="form-group">
                                <label>Meta Title</label>
                                <input runat="server" id="fMetaTitle" class="form-control" placeholder="">
                            </div>
                        </div>
                    
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Meta Description</label>
                                <textarea runat="server" id="fMetaDescription" class="form-control" placeholder="" rows="2"></textarea>
                            </div>
                            <div class="form-group">
                                <label>Meta Keywords</label>
                                <input runat="server" id="fMetaKeywords" class="form-control" placeholder="">
                            </div>
                            <div class="form-group">
                                <label>Từ khóa</label>
                                <input runat="server" id="fTags" class="form-control" placeholder="">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- /.content -->


<script type="text/javascript">
    //function delFunc(btnDel) {
    //    var input = $(btnDel).parent().prev();
    //    var image = $(input).prev();
    //    $(input).replaceWith($(input).clone(true));
    //    $(image).attr("src", "~");
    //    $(image).prev().removeAttr("value");
    
    //}

    //function fileInputChange(input) {
    //    $.each(input.files, function (index, value) {
    //        var reader = new FileReader();
    //        reader.onload = function (e) {
    //            var image = $(input).prev();
    //            $(image).attr("src", e.target.result);
    //            $(image).prev().attr("value", "image changed");

    //        }
    //        reader.readAsDataURL(input.files[index]);
    //    });
    //}


  
    //$("#uploadForm img").click(function () {
    //    $(this).next().click();
    //});

    //$.each($("#uploadForm img"), function (index, value) {
    //    if (typeof $(value).attr("src") !== undefined) {
    //        $(value).prev().attr("value", $(value).attr("src"));
    //    }
    //});

    // Image 1
    function inputFileImg1Change(input) {
        for (var i = 0; i < input.files.length; i++) {
            var file = input.files[i];
            var reader = new FileReader();

            reader.onloadend = function () {
                fImgLink1.src = reader.result;
            }
            reader.readAsDataURL(file);
        }
    }
    $('#uploadFormImg1 input').hide();
    $("#fImgLink1").click(function () {
        $('#uploadFormImg1 input').click().hide();

    });

    // Image 2
    function inputFileImg2Change(input) {
        for (var i = 0; i < input.files.length; i++) {
            var file = input.files[i];
            var reader = new FileReader();

            reader.onloadend = function () {
                fImgLink2.src = reader.result;
            }
            reader.readAsDataURL(file);
        }
    }
    $('#uploadFormImg2 input').hide();
    $("#fImgLink2").click(function () {
        $('#uploadFormImg2 input').click().hide();

    });

    // Image 3
    function inputFileImg3Change(input) {
        for (var i = 0; i < input.files.length; i++) {
            var file = input.files[i];
            var reader = new FileReader();

            reader.onloadend = function () {
                fImgLink3.src = reader.result;
            }
            reader.readAsDataURL(file);
        }
    }
    $('#uploadFormImg3 input').hide();
    $("#fImgLink3").click(function () {
        $('#uploadFormImg3 input').click().hide();

    });
    // Imaeg 4
    function inputFileImg4Change(input) {
        for (var i = 0; i < input.files.length; i++) {
            var file = input.files[i];
            var reader = new FileReader();

            reader.onloadend = function () {
                fImgLink4.src = reader.result;
            }
            reader.readAsDataURL(file);
        }
    }
    $('#uploadFormImg4 input').hide();
    $("#fImgLink4").click(function () {
        $('#uploadFormImg4 input').click().hide();

    });
    // Image 5
    function inputFileImg5Change(input) {
        for (var i = 0; i < input.files.length; i++) {
            var file = input.files[i];
            var reader = new FileReader();

            reader.onloadend = function () {
                fImgLink5.src = reader.result;
            }
            reader.readAsDataURL(file);
        }
    }
    $('#uploadFormImg5 input').hide();
    $("#fImgLink5").click(function () {
        $('#uploadFormImg5 input').click().hide();

    });

</script>
