<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cPartner.ascx.cs" Inherits="controls_content_cPartner" %>
<section id="top-brands" class="wow fadeInUp">
    <div class="container">
        <div class="carousel-holder" >
            
            <div class="title-nav">
                <h1>ĐỐI TÁC</h1>
                <div class="nav-holder">
                    <a href="#prev" data-target="#owl-brands" class="slider-prev btn-prev fa fa-angle-left"></a>
                    <a href="#next" data-target="#owl-brands" class="slider-next btn-next fa fa-angle-right"></a>
                </div>
            </div><!-- /.title-nav -->
            
            <div id="owl-brands" class="owl-carousel brands-carousel">
                <asp:Repeater ID="rptPartner" runat="server">
                <ItemTemplate>
                    <div class="carousel-item">
                        <a href="#">
                            <img alt="" src='<%#DataBinder.Eval(Container.DataItem, "ImgLink")%>' height="87px" />
                        </a>
                    </div>                     
                </ItemTemplate>
                </asp:Repeater>
            </div><!-- /.brands-caresoul -->

        </div><!-- /.carousel-holder -->
    </div><!-- /.container -->
</section>
<!-- /#top-brands -->
