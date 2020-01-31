<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cPartnerDetail.ascx.cs" Inherits="controls_content_cPartnerDetail" %>
<section id="category-grid">
    <div class="container">        
        <!-- ========================================= SIDEBAR ========================================= -->
        <div class="col-xs-12 col-sm-3 no-margin sidebar narrow">
            <div class="widget">
               <div class="sidemenu-holder" style="width:100%!important;"> 
			<!-- ================================== TOP NAVIGATION ================================== -->
                <div class="side-menu animate-dropdown">
                    <div class="head"><i class="fa fa-list"></i> Danh mục sản phẩm</div>        
                    <nav class="yamm megamenu-horizontal" role="navigation">
                        <ul class="nav">
                        <asp:Repeater ID="rptProCat" runat="server" onitemdatabound="rptProCat_ItemDataBound">
                        <ItemTemplate>
                             <li class="menu-item"><a href='<%# Eval("RewriteURL")%>' data-hover="dropdown">
                                <%#DataBinder.Eval(Container.DataItem, "ProductCat").ToString().ToUpper()%>
                                </a> 
                                <asp:Repeater ID="rptChild" runat="server">
                                <HeaderTemplate>
                                    <ul class="dropdown-menu mega-menu">
                                        <li class="yamm-content">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <ul class="list-unstyled">
                                </HeaderTemplate>
                                <ItemTemplate>                            
                                    <li><a href='<%# Eval("RewriteURL")%>'><%# Eval("ProductCat").ToString().ToUpper()%></a></li>
                                </ItemTemplate>
                                <FooterTemplate> 
                                                    </ul>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </FooterTemplate>
                                </asp:Repeater>
                            </li>                            
                        </ItemTemplate>
                        </asp:Repeater> 
                        </ul>                        
                    </nav><!-- /.megamenu-horizontal -->
                </div><!-- /.side-menu -->
               
                </div> 
           </div> 
            <%--<div class="widget">
	            <div class="simple-banner">
		            <a href="#"><img alt="" class="img-responsive" src="~/assets/images/blank.gif" data-echo="~/assets/images/banners/banner-01.jpg" /></a>                    
	            </div>
            </div>--%>
            <div class="widget">
	            <h1 class="border">Tin nổi bật</h1>
	            <ul class="product-list">
                    <asp:Repeater ID="rptHotNews" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="row">
                                <div class="col-xs-4 col-sm-4 no-margin">
                                    <a href='<%# Eval("UrlRewrite")%>' class="thumb-holder">
                                        <img alt="" src="~/assets/images/blank.gif" data-echo='<%# Eval("ImgLink")%>' style="width:75px;height:75px;" />
                                    </a>
                                </div>
                                <div class="col-xs-8 col-sm-8 no-margin">
                                    <a href='<%# Eval("UrlRewrite")%>'><%# Eval("Title")%> </a>
                                    <div class="price">
                                        <div style="color: #c6c6c6;font-size: 11px;"><%# Convert.ToDateTime(Eval("PublishDate")).ToString("MMMM dd, yyyy")%></div>                                        
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div><!-- /.widget -->            
        </div>
        <!-- ========================================= SIDEBAR : END =================================== -->
        <!-- ========================================= CONTENT ========================================= -->

        <div class="col-xs-12 col-sm-9 no-margin wide sidebar">
            <section id="gaming">
                <div class="grid-list-products">
                    <div class="title-nav">
                        <h1 style="color: #59b210;">Catalog</h1>
                    </div> 
                                                
                    <div class="tab-content">
                        <div id="grid-view" class="products-grid fade tab-pane in active">                          
                            <div class="partner-grid-holder">
                                <div class="row no-margin">
                                    <asp:Repeater ID="rptPartner" runat="server">
                                    <ItemTemplate>
                                        <div class="col-xs-12 col-sm-4 no-margin partner-item-holder hover">
                                            <div class="partner-item">                                                 
                                                <div class="image">
                                                    <a href='<%#DataBinder.Eval(Container.DataItem, "UrlLink")%>' target = "_blank">
                                                    <img alt="" src="~/assets/images/blank.gif" data-echo='<%#DataBinder.Eval(Container.DataItem, "ImgLink")%>' height = "160px" />
                                                    </a>
                                                </div>
                                                <%--<div class="body">                                                    
                                                    <div class="title">
                                                        <a href='<%#DataBinder.Eval(Container.DataItem, "UrlLink")%>'><%#DataBinder.Eval(Container.DataItem, "ShortCutName")%></a>
                                                    </div>
                                                </div>--%>
                                                <div class="prices">
                                                    <div class="price-prev"></div>
                                                    <div class="price-current pull-right"><a href='<%#DataBinder.Eval(Container.DataItem, "UrlLink")%>' target = "_blank"><%#DataBinder.Eval(Container.DataItem, "ShortCutName")%></a></div>
                                                </div>                                                
                                            </div><!-- /.product-item -->
                                        </div><!-- /.product-item-holder -->
                                    </ItemTemplate>
                                    </asp:Repeater>
                                </div><!-- /.row -->
                            </div><!-- /.product-grid-holder -->
                        </div>
                        <!-- /.products-grid #grid-view -->                       
                    </div><!-- /.tab-content -->
                </div><!-- /.grid-list-products -->

            </section><!-- /#gaming -->            
        </div><!-- /.col -->
        <!-- ========================================= CONTENT : END ================================== -->    
    </div><!-- /.container -->
</section>
<!-- /#category-grid -->
