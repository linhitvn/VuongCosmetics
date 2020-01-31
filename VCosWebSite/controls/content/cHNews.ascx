<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cHNews.ascx.cs" Inherits="controls_content_cHNews" %>
<div class="container" style="border-top: 1px solid #e0e0e0; padding-top: 25px;">
    <div class="row no-margin widgets-row">
        <div class="col-xs-12">
            <div class="widget">
                <h2>
                    <a href="~/tin-tuc/index.html">TIN TỨC</a></h2>
                <div class="col-xs-12 col-md-8 no-margin">
                    <div class="row">
                        <div class="col-xs-6 col-sm-6">
                            <div class="item-thumbnail">                                   
                                <asp:HyperLink ID="hplLink" runat="server">                                
                                    <asp:Image ID="imgLink" runat="server" AlternateText="" />
                                </asp:HyperLink>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6">
                            <div class="item-head row">
                                <div class="col-md-10 col-sm-10 col-xs-9">
                                    <h3>                                        
                                        <asp:HyperLink ID="hplTitle" runat="server" CssClass="maincolor2hover"></asp:HyperLink>
                                    </h3>
                                </div>
                                <div class="col-md-2 col-sm-2 col-xs-3">
                                    <div class="blog-date">
                                        <span><asp:Label ID="lblDate" runat="server" Text=""></asp:Label></span><br />
                                        <span>THÁNG <asp:Label ID="lblMonth" runat="server" Text=""></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                            <div class="blog-excerpt">
                                <p>
                                    <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                                </p>
                                <asp:HyperLink ID="hplDetail" runat="server" CssClass="readmore maincolor2 bordercolor2 bgcolor2hover bordercolor2hover">Đọc tiếp <i class="fa fa-angle-right"></i>
                                </asp:HyperLink>                                
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-4">
                    <ul>
                        <asp:Repeater ID="rptArticle" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="row">
                                    <div class="col-xs-12 col-sm-3 no-margin">
                                        <a href='<%# Eval("UrlRewrite")%>' class="thumb-holder">
                                            <img alt="" src="~/assets/images/blank.gif" data-echo='<%# Eval("ImgLink")%>' />                                          
                                        </a>
                                    </div>
                                    <div class="col-xs-12 col-sm-9">
                                        <a href='<%# Eval("UrlRewrite")%>'>
                                            <%#DataBinder.Eval(Container.DataItem, "Title")%>
                                        </a>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!-- /.widget -->
        </div>
        <!-- /.col -->
        <!-- ============================================================= ON SALE PRODUCTS : END ============================================================= -->
    </div>
    <!-- /.widgets-row-->
</div>
<!-- /.container -->