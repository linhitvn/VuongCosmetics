<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cDiscountAlter.ascx.cs" Inherits="Pages_Marketing_Discount_cDiscountAlter" %>
<script src="../../../js/plugins/dropzone/dropzone.js"></script>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Tạo chương trình khuyến mãi
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
                        <div class="form-group">
					        <label>Tên chương trình khuyến mãi</label>
					        <input runat="server" id="fDiscountName" class="form-control" placeholder="">
				        </div>
				        <div class="form-group">
					        <label>Loại khuyến mãi</label>
					        <select runat="server" id="fDiscountTypeID" datatextfield="RecordType" datavaluefield="ID" class="form-control" placeholder=""></select>
				        </div>
				        <div class="form-group">
					        <label>Giá trị giảm</label>
					        <input runat="server" id="fValue" class="form-control input-number" placeholder="">
				        </div>
                        <div class="form-group">
					        <label>Áp dụng từ ngày</label><br />
					        <telerik:RadDatePicker ID="fFromDate" runat="server" culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
					          <DatePopupButton ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" /> 					  
                              <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" /> 					
                            </telerik:RadDatePicker>
				        </div>
				        <div class="form-group">
					        <label>Áp dụng đến ngày</label><br />
					        <telerik:RadDatePicker ID="fToDate" runat="server" culture="Vietnamese (Vietnam)" MinDate="1900-01-01">
					          <DatePopupButton ToolTip="Chọn ngày" ImageUrl="" HoverImageUrl="" /> 					  
                              <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" /> 					
                            </telerik:RadDatePicker>
				        </div>
				        <div class="form-group">
					        <label>Số lượng sản phẩm tối thiểu</label>
					        <input runat="server" id="fMinProductNumber" class="form-control input-number" placeholder="">
				        </div>
				        <div class="form-group">
					        <label>Giá trị hóa đơn tối thiểu</label>
					        <input runat="server" id="fMinOrderPrice" class="form-control input-number" placeholder="">
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
                    <h3 class="box-title">Sử dụng Coupon</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-primary btn-xs" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-primary btn-xs" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div class="box-body">
                    <div class="form-group">
					    <label>Mã Coupon</label>
					    <input runat="server" id="fCoupon" class="form-control" placeholder="Ví dụ: 747372884">
				    </div>
				    <div class="form-group">
					    <label>Loại Coupon</label><br />
                        <form >
                            <input type="radio" name="reason" value="" class="radio-coupon" runat="server" id="unLimitedCoupon" >  Không giới hạn.<br>
                            <input type="radio" name="reason" value="" class="radio-coupon" runat="server" id="limitedPerUser">  <input type="text" style="width:30px"  runat="server" id="limitedPerUserValue"/> lần/khách hàng.<br>
                            <input type="radio" name="reason" value="" class="radio-coupon" runat="server" id="limitedPerUsed">  Sử dụng cho <input type="text"  style="width:30px"  runat="server" id="limitedPerUsedValue"/> lần.<br>
                        </form>
					    <%--<select runat="server" id="fCouponTypeID" datatextfield="RecordType" datavaluefield="ID" class="form-control" placeholder=""></select>--%>
				    </div>
				    <div class="form-group">
					    <div class="checkbox">
					    <label>
						    <input runat="server" id="fIsNotAllowWithOther" type="checkbox" /> Không được phép dùng với Coupon khác
					    </label>
					    </div>
				    </div>
                    
                    
                </div>
            </div>
        </div>
        <!-- Danh mục sản phẩm -->
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header" data-toggle="tooltip" title="Header tooltip">
                    <h3 class="box-title">Danh mục sản phẩm được áp dụng</h3>
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
    </div>
</section><!-- /.content -->

<script type="text/javascript">

    onChange(){

    };
</script>