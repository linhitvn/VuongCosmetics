<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductOptionAlter.ascx.cs" Inherits="Pages_Product_cProductOptionAlter" %>
<link href="./css/colorpicker/evol.colorpicker.css" rel="stylesheet" />
<script src="./js/plugins/colorpicker/evol.colorpicker.min.js" type="text/javascript"></script>
<link id="jquiCSS" rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.1/themes/ui-lightness/jquery-ui.css" type="text/css" media="all">
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Chỉnh sửa thông tin tùy chọn sản phẩm
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
        <div class="col-md-12">
            <div class="box box-primary">
                <%--<div class="box-header">
                    <h3 class="box-title">Quick Example</h3>
                </div><!-- /.box-header -->--%>
                <!-- form start -->
                <div role="form" class="form-custom">
                    <div class="box-body">
                        <div class="form-group">
					        <label>Tên tùy chọn</label>
					        <input runat="server" id="fProductOption" class="form-control" placeholder="">
				        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="form-group" runat="server" id="div_Color">
					        <label>Màu sắc</label>
					       
                                <input runat="server" id="fValue"   clientidmode="Static">
                              
				        </div>
				        <div class="form-group">
					        <label>Nhóm tùy chọn</label>
                            <asp:DropDownList runat="server" id="fProductOptionGroupID" datatextfield="ProductOptionGroup" 
                                AutoPostBack="true" OnSelectedIndexChanged="ProductOptionGroup_Change" datavaluefield="ID" class="form-control" placeholder=""></asp:DropDownList>
				        </div>
                        
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        <%--<button id="Button1" runat="server" onserverclick="Save_Click" type="submit" class="btn btn-primary">Lưu</button>--%>
                    </div>
                </div>
            </div><!-- /.box -->
        </div>
    </div>
</section><!-- /.content -->


<!-- bootstrap color picker -->
<script>
    $(document).ready(function () {
        // No color indicator
        $('#fValue').colorpicker({
            displayIndicator: false
        });
    });
</script>
        <!-- Page script -->
        <script type="text/javascript">
            //$(function () {
               

            //    $('.my-colorpicker1').colorpicker().on('changeColor.colorpicker', function (event) {
            //        $('#fValue').css("background-color", event.color.toHex());
            //    });
            //});

            //function OnChangeClient_GroupOption() {
                
               
            //    //$('.my-colorpicker1').colorpicker().on('changeColor.colorpicker', function (event) {
            //    //    $('#fValue').css("background-color", event.color.toHex());
            //    //});

            //        // No color indicator
            //        $('#fValue').colorpicker({
            //            displayIndicator: false
            //        });
                
            //}

        </script>