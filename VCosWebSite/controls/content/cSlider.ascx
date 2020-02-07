<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cSlider.ascx.cs" Inherits="controls_content_cSlider" %>
<div id="slides-shop" class="cover-slides">
    <ul class="slides-container">
        <asp:Repeater ID="rptSlider" runat="server">
            <ItemTemplate>
                <li class='<%# (Container.ItemIndex + 1) % 3 == 1 ? "text-center" : (Container.ItemIndex + 1) % 3 == 2 ? "text-center" : "text-center" %>'>
                    <img alt="" src='<%# Eval("ImgLink")%>' />
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <h1 class="m-b-20"><strong><%# Eval("Content1")%></strong></h1>
                                <p class="m-b-40"><%# Eval("Content2")%></p>
                                <p><a class="btn hvr-hover" href='<%# Eval("UrlLink")%>'>Khám phá </a></p>
                            </div>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="slides-navigation">
        <a href="#" class="next"><i class="fa fa-angle-right" aria-hidden="true"></i></a>
        <a href="#" class="prev"><i class="fa fa-angle-left" aria-hidden="true"></i></a>
    </div>
</div>
