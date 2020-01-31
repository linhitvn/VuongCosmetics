<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cAbout.ascx.cs" Inherits="controls_content_cAbout" %>
<!-- Start All Title Box -->
    <div class="all-title-box">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="title-all text-center">
                        <h1>VIPHARMA CGMP-ASEAN </h1>
                        <p>Dòng Mỹ phẩm Thương hiệu Độc quyền của VIPHARMA CO., LTD. </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End All Title Box -->
<!-- Start AboutUs Box  -->
<div class="aboutus-box-main">
    <div class="container">
        <asp:Repeater ID="rptAbout" runat="server">
            <ItemTemplate>
                <div class="row">
                           <%# Eval("Content")%>
                     
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>

    </div>
</div>
<!-- End AboutUs Box -->
