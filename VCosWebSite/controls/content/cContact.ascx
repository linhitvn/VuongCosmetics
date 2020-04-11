<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cContact.ascx.cs" Inherits="controls_content_cContact" %>

<div class="contact-box-main">
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-sm-12">
                <div class="contact-info-left" runat="server" id="divContactUs">                    
                </div>
            </div>
            <div class="col-lg-8 col-sm-12">
                <div class="contact-form-right">
                    <h2>Thông tin của bạn </h2>
                    <p>Vui lòng cung cấp đầy đủ thông tin theo mẫu bên dưới:</p>

                    <asp:Label ID="lblMessege" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <input type="text" runat="server" id="txtFullName" class="form-control" name="name" placeholder="Họ tên *" required data-error="Vui lòng nhập họ tên của bạn">
                                <div class="help-block with-errors"></div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <input type="text" runat="server" placeholder="Địa chỉ Email *" id="txtEmail" class="form-control" name="name" required data-error="Vui lòng nhập địa chỉ email của bạn">
                                <div class="help-block with-errors"></div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <input type="text" runat="server" placeholder="Số điện thoại" id="txtPhone" class="form-control" name="name" required data-error="Vui lòng nhập số điện thoại của bạn">
                                <div class="help-block with-errors"></div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <input type="text" runat="server" class="form-control" id="txtTitle" name="name" placeholder="Chủ đề" required data-error="Vui lòng chọn chủ đề">
                                <div class="help-block with-errors"></div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <textarea class="form-control" runat="server" id="txtContent" placeholder="Nội dung *" rows="4" data-error="Vui lòng nhập nội dung bạn quan tâm" required></textarea>
                                <div class="help-block with-errors"></div>
                            </div>
                            <div class="submit-button text-center">
                                <asp:Button ID="btnSend" runat="server" Text="Gửi yêu cầu" CssClass="btn hvr-hover" OnClick="btnSend_Click"></asp:Button>
                                <div id="msgSubmit" class="h3 text-center hidden"></div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>
