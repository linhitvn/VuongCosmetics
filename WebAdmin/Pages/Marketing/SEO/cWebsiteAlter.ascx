<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cWebsiteAlter.ascx.cs" Inherits="Pages_Marketing_SEO_cWebsite" %>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Thiết lập SEO Cho Website
    </h1>
    <ol class="toolbar">
                <li><button runat="server" id="Save" onserverclick="Save_Click" class="btn btn-info btn-sm">
            <i class="fa fa-save"></i>
            <span>Lưu</span>
            </button>
       </li>
        <%--<li><button runat="server" id="btCreate" onserverclick="New_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            <span>Tạo mới</span>
            </button>
        </li>
        <li><button runat="server" id="btClone" onserverclick="Clone_Click" class="btn btn-info btn-sm">
            <i class="fa fa-copy"></i>
            <span>Sao chép</span>
            </button>
       </li>
        <li>
            <button runat="server" id="btDelete" onserverclick="Delete_Click" class="btn btn-info btn-sm">
                <i class="fa fa-trash-o"></i>
                <span>Xóa</span>
            </button>
        </li>--%>
    </ol>
</section>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
<ContentTemplate>
<div runat="server" id="message_box">    
</div>


<section class="content">
    <div class="row">
        <div class="col-xs-12">
            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="~&act=edit">Thiết lập SEO cho Website</a></li>
                    <li class=""><a id="A1" runat="server" href="~/?module=513">Thiết lập SEO Cho Trang</a></li>
                    <li class=""><a id="A2" runat="server" href="~/?module=523">Danh mục sản phẩm</a></li>
                    <li class=""><a id="A3" runat="server" href="~/?module=533">Danh mục tin tức</a></li>
                </ul>
            </div>
            <div class="tab-content">
                <div class="tab-pane active" id="fa-icons">
                    <div class="box">
                        <div class="box-body">
                            <div role="form" class="form-custom">
                                <div class="form-group" style="display: none;">
					                <label>Tên Website</label>
					                <input disabled="disabled" runat="server" id="fWebsiteName" class="form-control" placeholder="">
				                </div>
                                <div class="form-group">
					                <label>Tiêu đề Seo</label>
					                <input runat="server" id="fMetaTitle" class="form-control" placeholder="">
				                </div>
				                <div class="form-group">
					                <label>Mô tả Seo</label>
                                    <textarea runat="server" id="fMetaDescription" class="form-control" rows="3" placeholder=""></textarea>
				                </div>
				                <div class="form-group">
					                <label>Từ khóa Seo</label>
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
</ContentTemplate>
</asp:UpdatePanel>