<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cheader.ascx.cs" Inherits="controls_header_cheader" %>
<div class="container-fluid">
    <div class="row">
        <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">
            <div class="text-slid-box">
                <div id="offer-box" class="carouselTicker">
                    <ul class="offer-box">
                        <asp:Repeater ID="rptNotification" runat="server">
                            <ItemTemplate>
                                <li>
                                    <i class="fab fa-opencart" aria-hidden="true"></i><%# Eval("Description")%>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>

        <!-- KHÓA CHỨC NĂNG NÀY --
        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">					
			<div class="our-link language-box">
                <ul>
                    <li><a href="_index.html" alt="English language">ENG </a></li>
					<li><a href="_index_VIE.html" alt="Vietnamese language">VIE </a></li>
                </ul>
            </div>					
        </div>
		-- KHÓA CHỨC NĂNG NÀY -->
    </div>
</div>
