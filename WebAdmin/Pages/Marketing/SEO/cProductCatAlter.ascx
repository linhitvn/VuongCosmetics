<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductCatAlter.ascx.cs" Inherits="Pages_Marketing_SEO_cProductCatAlter" %>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Thiết lập SEO Cho Danh mục sản phẩm
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

<section class="content">
    <div class="row">
        <div class="col-xs-12">
           <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class=""><a id="A2" runat="server" href="~/?module=503&act=edit&KeyID=1">Thiết lập SEO cho Website</a></li>
                    <li class=""><a id="A1" runat="server" href="~/?module=513">Thiết lập SEO Cho Trang</a></li>
                    <li class="active"><a>Danh mục sản phẩm</a></li>
                    <li class=""><a id="A3" runat="server" href="~/?module=533">Danh mục tin tức</a></li>
                </ul>
            </div>
            <div class="tab-content">
                <div class="tab-pane active" id="fa-icons">
                    <div class="box">
                        <div class="box-body">
                            <div role="form" class="form-custom">
                                <div class="form-group">
					                <label>Danh mục sản phẩm</label>
					                <input disabled="disabled" runat="server" id="fProductCat" class="form-control" placeholder="">
				                </div>
                                <div class="form-group">
					                <label>Tiêu đề</label>
					                <input runat="server" id="fMetaTitle" class="form-control" placeholder="">
				                </div>
				                <div class="form-group">
					                <label>Mô tả</label>
                                    <textarea runat="server" id="fMetaDescription" class="form-control" rows="3" placeholder=""></textarea>
				                </div>
				                <div class="form-group">
					                <label>Từ khóa</label>
                                    <textarea runat="server" id="fMetaKeywords" class="form-control" rows="2" placeholder=""></textarea>
				                </div>
                            </div>
                        </div>
                    </div><!-- /.box -->
                </div>
                <div class="tab-pane" id="glyphicons"></div>
            </div>
        </div>
    </div>
</section>
