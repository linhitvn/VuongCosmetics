<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cSearch.ascx.cs" Inherits="controls_content_cSearch" %>
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
                        <h1 style="color: #59b210;">Kết quả tìm kiếm: <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label></h1>
                    </div> 
                                                
                    <div class="tab-content">
                        <div id="grid-view" class="products-grid fade tab-pane in active">                          
                        <%--<asp:UpdatePanel ID="upData" runat="server">
                        <ContentTemplate>--%>
                            <div class="product-grid-holder">
                            <div class="row no-margin">
                                <asp:ListView ID="lvData" runat="server" GroupItemCount="1" GroupPlaceholderID="groupPlaceholder1"
                                    ItemPlaceholderID="itemPlaceholder1" OnPreRender="lvData_PreRender" 
                                    onitemcommand="lvData_ItemCommand">
                                    <LayoutTemplate>                                
                                        <div id="groupPlaceholder1" runat="server"></div>                        
                                    </LayoutTemplate>
                                    <GroupTemplate>
                                        <div id="itemPlaceholder1" runat="server"></div>
                                    </GroupTemplate>
                                    <ItemTemplate>
                                        <div class="col-xs-12 col-sm-4 no-margin product-item-holder hover">
                                            <div class="product-item">
                                                <%--<div class="ribbon red"><span>sale</span></div>--%> 
                                                <div class="image">
                                                    <a href='<%# Eval("RewriteURL")%>'><img alt="" src="~/assets/images/blank.gif" data-echo='<%# Eval("ImgLink1")%>' /></a>
                                                </div>
                                                <div class="body">
                                                    <%--<div class="label-discount green">-50% sale</div>--%>
                                                    <div class="title">
                                                        <a href='<%# Eval("RewriteURL")%>'><%# Eval("ProductName")%></a>
                                                    </div>
                                                    <div class="brand"><%# Eval("ProducerName")%></div>
                                                </div>
                                                <div class="prices">
                                                    <div class="price-prev">Giá</div>
                                                    <div class="price-current pull-right"><a href="~/lien-he/index.html">Liên hệ</a></div>
                                                </div>
                                                <div class="hover-area">
                                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                                                    <div class="add-cart-button">
                                                        <asp:LinkButton ID="lkbOrder" runat="server" CssClass="le-button" CommandName ="AddCart">Đặt hàng</asp:LinkButton>
                                                    </div>                                                    
                                                </div>
                                            </div><!-- /.product-item -->
                                        </div><!-- /.product-item-holder -->
                                    </ItemTemplate>
                                </asp:ListView>
                            </div><!-- /.products-list -->
                            </div>
                            <!-- pagination -->  
                            <div id="dvPaging" class="nav_pages" runat="server">   
                                <asp:DataPager ID="dpData" runat="server" PagedControlID="lvData" PageSize="9">
                                <Fields>                        
                                    <asp:TemplatePagerField>
                                        <PagerTemplate>
                                            <div class="pagination-holder">
                                            <div class="row">
                                                <div class="col-xs-12">
                                                <div class="pages">
                                        </PagerTemplate>                                
                                        </asp:TemplatePagerField> 
                                            <asp:NumericPagerField ButtonCount="7" CurrentPageLabelCssClass="current" />
                                        <asp:TemplatePagerField>
                                        <PagerTemplate>
                                                </div>
                                                </div><!-- /.row -->
                                                </div>
                                            </div>
                                        </PagerTemplate>
                                    </asp:TemplatePagerField>        
                                </Fields>
                                </asp:DataPager>  
                            </div>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                        </div>
                        <!-- /.products-grid #grid-view -->
                        <!--
                        <div id="list-view" class="products-grid fade tab-pane ">
                        </div> products-grid #list-view -->

                    </div><!-- /.tab-content -->
                </div><!-- /.grid-list-products -->

            </section><!-- /#gaming -->            
        </div><!-- /.col -->
        <!-- ========================================= CONTENT : END ================================== -->    
    </div><!-- /.container -->
</section>
<!-- /#category-grid -->
