<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cProductDetail.ascx.cs" Inherits="controls_content_cProductDetail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div id="single-product">
    <div class="container">
        <div class="no-margin col-xs-12 col-sm-6 col-md-5 gallery-holder">
            <div class="product-item-holder size-big single-product-gallery small-gallery">
                <div id="owl-single-product">
                    <asp:Repeater ID="rptImgShow" runat="server">
                    <ItemTemplate>
                        <div class="single-product-gallery-item" id='slide<%# Eval("id")%>'>
                            <img class="img-responsive" alt="" src="~/assets/images/blank.gif" data-echo='<%# Eval("Img")%>' />                            
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>                
                </div>
                <!-- /.single-product-slider -->
                <div class="single-product-gallery-thumbs gallery-thumbs">
                    <div id="owl-single-product-thumbnails">
                        <asp:Repeater ID="rptImgThumb" runat="server">
                        <ItemTemplate>                            
                            <a class='horizontal-thumb <%#Eval("id").ToString() == "1" ? "active" : "" %>' data-target="#owl-single-product" data-slide='<%#Convert.ToInt32(Eval("id"))-1%>' href='slide<%# Eval("id")%>'>
                                <img width="67" alt="" src="~/assets/images/blank.gif" data-echo='<%# Eval("Img")%>' />
                            </a>
                        </ItemTemplate>
                        </asp:Repeater>                  
                    </div>
                    <!-- /#owl-single-product-thumbnails -->
                    <div class="nav-holder left hidden-xs">
                        <a class="prev-btn slider-prev" data-target="#owl-single-product-thumbnails" href="#prev">
                        </a>
                    </div>
                    <!-- /.nav-holder -->
                    <div class="nav-holder right hidden-xs">
                        <a class="next-btn slider-next" data-target="#owl-single-product-thumbnails" href="#next">
                        </a>
                    </div>
                    <!-- /.nav-holder -->
                </div>
                <!-- /.gallery-thumbs -->
            </div>
            <!-- /.single-product-gallery -->
        </div>
        <!-- /.gallery-holder -->
        <div class="no-margin col-xs-12 col-sm-7 body-holder">
            <div class="body">
                                 
                <div class="title"><a href="#"> 
                    <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></a></div>
                <div class="brand">
                    <a href="#"> <asp:Label ID="lblBrand" runat="server" Text=""></asp:Label></a>
                </div>
                
                <div class="social-row">
                    <!-- Go to www.addthis.com/dashboard to customize your tools -->
                    Sharing<div class="addthis_sharing_toolbox"></div>
                </div>                            
                <div class="excerpt">
                    <div class="meta-row">
                        <div class="inline">
                            <label>Mã sản phẩm:</label>&nbsp;&nbsp;
                            <asp:Label ID="lblSKU" runat="server" Text=""></asp:Label>
                        </div><!-- /.inline -->
                    </div>                  
                    <div class="meta-row">
                        <div class="inline">
                            <label>Giá:</label>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="~/lien-he/index.html"><asp:Label ID="lblPrice" runat="server" Text="Chúng tôi sẽ gọi điện báo giá tốt nhất cho quý khách sau khi nhận được đơn hàng" style ="color: #59b210;"></asp:Label></a>
                        </div><!-- /.inline -->
                    </div>  
                </div>
                <div class="star-holder inline"><div class="star" data-score="4"></div></div>
                <div class="meta-row"><label>Tình trạng:</label>&nbsp;&nbsp;&nbsp;<span style ="color: #59b210;">  còn hàng</span></div>
                <%--<div class="prices">
                    <div class="price-current">
                        Giá</div>
                    <div class="price-prev">
                        Liên hệ</div>
                </div>--%>
                <div class="qnt-holder">
                    <div class="le-quantity">                        
                        <a class="minus" href="#reduce"></a>                        
                        <asp:TextBox ID="txtQuantity" runat="server" Text="1" MaxLength="2"></asp:TextBox>                        
                        <a class="plus" href="#add"></a>                        
                    </div>
                    <asp:TextBox ID="txtProductID" runat="server" Visible="false"></asp:TextBox>
                    <asp:LinkButton ID="lkbOrder" runat="server" CssClass="le-button huge" 
                        onclick="lkbOrder_Click">Đặt hàng</asp:LinkButton>
                    <%--<a id="addto-cart" href="#" class="le-button huge">Đặt hàng</a>--%>
                </div>
                <!-- /.qnt-holder -->
            </div>
            <!-- /.body -->
        </div>
        <!-- /.body-holder -->
    </div>
    <!-- /.container -->
</div>
<!-- /.single-product -->
<!-- ========================================= SINGLE PRODUCT TAB ========================================= -->
<section id="single-product-tab">
    <div class="container">
        <div class="tab-holder">
            
            <ul class="nav nav-tabs simple" >
                <li class="active"><a href="#description" data-toggle="tab">Mô tả sản phẩm</a></li>
                <%--<li><a href="#additional-info" data-toggle="tab">Additional Information</a></li>
                <li><a href="#reviews" data-toggle="tab">Reviews (3)</a></li>--%>
            </ul><!-- /.nav-tabs -->

            <div class="tab-content">
                <div class="tab-pane active" id="description">
                    <p>
                        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                    </p>
                </div><!-- /.tab-pane #description -->
            </div><!-- /.tab-content -->

        </div><!-- /.tab-holder -->
    </div><!-- /.container -->
</section>
<!-- /#single-product-tab -->
<!-- ========================================= SINGLE PRODUCT TAB : END ========================================= -->
<!-- ========================================= RECENTLY VIEWED ========================================= -->
<section id="recently-reviewd" class="wow fadeInUp">
	<div class="container">
		<div class="carousel-holder hover">
			
			<div class="title-nav">
				<h2 class="h1">Sản phẩm liên quan</h2>
				<div class="nav-holder">
					<a href="#prev" data-target="#owl-recently-viewed" class="slider-prev btn-prev fa fa-angle-left"></a>
					<a href="#next" data-target="#owl-recently-viewed" class="slider-next btn-next fa fa-angle-right"></a>
				</div>
			</div><!-- /.title-nav -->

			<div id="owl-recently-viewed" class="owl-carousel product-grid-holder">
                <asp:Repeater ID="rptRelateProduct" runat="server">
                <ItemTemplate>
                    <div class="no-margin carousel-item product-item-holder size-small hover">
					    <div class="product-item">
						    <%--<div class="ribbon red"><span>sale</span></div>
                            <div class="ribbon blue"><span>new!</span></div>--%> 
						    <div class="image">
							    <a href='<%# Eval("RewriteURL")%>'><img alt="" src="~/assets/images/blank.gif" data-echo="<%# Eval("ImgLink1")%>" /></a>
						    </div>
						    <div class="body">
							    <div class="title">
								    <a href='<%#Eval("RewriteURL")%>'><%# Eval("ProductName")%></a>
							    </div>
							    <div class="brand"><%# Eval("ProducerName")%></div>
						    </div>
						    <div class="prices">
                                <div class="price-prev">Giá: </div>
							    <div class="price-current pull-right"><a href="~/lien-he/index.html">Liên hệ</a></div>
						    </div>                            
						    <div class="hover-area">
							    <div class="add-cart-button">
								    <a href="single-product.html" class="le-button">Đặt hàng</a>
							    </div>
							    <%--<div class="wish-compare">
								    <a class="btn-add-to-wishlist" href="#">Add to Wishlist</a>
								    <a class="btn-add-to-compare" href="#">Compare</a>
							    </div>--%>
						    </div>
					    </div><!-- /.product-item -->
				    </div><!-- /.product-item-holder -->
                </ItemTemplate>
                </asp:Repeater>
				
			</div><!-- /#recently-carousel -->

		</div><!-- /.carousel-holder -->
	</div><!-- /.container -->
</section>
<!-- /#recently-reviewd -->
<!-- ========================================= RECENTLY VIEWED : END ========================================= -->
