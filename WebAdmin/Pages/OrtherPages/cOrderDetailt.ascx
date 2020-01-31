<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cOrderDetailt.ascx.cs" Inherits="Pages_Backup_cOrderDetailt" %>
<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-edit"></i>
        Thông tin đơn hàng
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
    <h6 class="page-header page-header-custom">
        Đơn hàng: <span runat="server" id="fID"></span> | <span runat="server" id="fSysDate"></span> | Trạng thái: <span runat="server" id="fOrderStatus"></span>
    </h6>
    <!-- Thông tin chung của đơn hàng -->
    <div class="row">
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Thông tin đơn hàng</h3>
                    <div class="box-tools pull-right">
                        <div runat="server" id="titleTotalPrice" class="label-custom">250.000 đ</div>
                    </div>
                </div>
                <div class="box-body">
                    <div class="table-responsive">
                        <table class="table">
                            <tbody><tr>
                                <th style="width:50%">Họ tên khách hàng</th>
                                <td runat="server" id="fCustomer"></td>
                            </tr>
                            <tr>
                                <th>Email</th>
                                <td runat="server" id="fEmail"></td>
                            </tr>
                            <tr>
                                <th>Nhóm khách hàng</th>
                                <td runat="server" id="fCustomerGroup"></td>
                            </tr>
                            <tr>
                                <th>Địa chị IP đặt hàng</th>
                                <td runat="server" id="fIPAddress"></td>
                            </tr>
                        </tbody></table>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="box box-solid">
                <div class="box-header">
                    <h3 class="box-title">In</h3>
                </div>
                <div class="box-body">
                    <div id="Div1" runat="server" class="label-custom">Hóa đơn</div>
                    <div id="Div2" runat="server" class="label-custom">Hóa đơn + Phiếu giao hàng</div>
                    <div id="Div3" runat="server" class="label-custom">Phiếu giao hàng</div>
                    <div id="Div4" runat="server" class="label-custom">
                        Email: 
                        <select id="Select1" class="form-control" runat="server">
                            <option>Value</option>
                            <option>Value</option>
                            <option>Value</option>
                        </select>
                        <button type="submit" class="btn btn-primary btn-sm">Gởi lại Email</button>   
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Phương thức thanh toán + Note -->
    <div class="row">
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-body">
                    <div runat="server" id="Div5">Phương thức thanh toán</div>
                    <div runat="server" id="fPayment" class="label-custom">Thanh toán khi giao hàng</div>
                    <div runat="server" id="Div6">Phương thức giao hàng</div>
                    <div runat="server" id="fShipping" class="label-custom">Giao hàng trực tiếp</div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#customerNote" data-toggle="tab">Ghi chú của khách hàng</a></li>
                    <li><a href="#SalerNote" data-toggle="tab">Ghi chú đơn hàng</a></li>
                    <li><a href="#AddressNote" data-toggle="tab">Hướng dẫn đường đi</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="customerNote">
                        <p runat="server" id="fNoteCustomer"></p>
                    </div>
                    <div class="tab-pane" id="SalerNote">
                        <p runat="server" id="fNoteSaler"></p>
                    </div>
                    <div class="tab-pane" id="AddressNote">
                        <p runat="server" id="fShipAddressNote"></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Địa chỉ thành toán + giao hàng -->
    <div class="row">
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Địa chỉ thanh toán</h3>
                </div>
                <div class="box-body">
                    <div runat="server" id="fBillCustomer"></div>
                    <div runat="server" id="fBillPhone" class="label-custom"></div>
                    <div runat="server" id="fBillAddress" class="label-custom"></div>
                    <div runat="server" id="fBillProvince" class="label-custom"></div>
                    <div runat="server" id="fBillDistrict" class="label-custom"></div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Địa chỉ giao hàng</h3>
                </div>
                <div class="box-body">
                    <div runat="server" id="fShipCustomer"></div>
                    <div runat="server" id="fShipPhone" class="label-custom"></div>
                    <div runat="server" id="fShipAddress" class="label-custom"></div>
                    <div runat="server" id="fShipProvince" class="label-custom"></div>
                    <div runat="server" id="fShipDistrict" class="label-custom"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Thông tin chi tiết Đơn hàng -->
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Chi tiết đơn hàng</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                    
                </div><!-- /.box-body -->
            </div><!-- /.box -->
        </div>
    </div>
</section><!-- /.content -->