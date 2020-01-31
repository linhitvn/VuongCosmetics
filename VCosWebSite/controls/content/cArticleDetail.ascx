<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cArticleDetail.ascx.cs" Inherits="controls_content_cArticleDetail" %>
<section id="blog-single">
	 <div class="container">
	 	<!-- ========================================= CONTENT ========================================= -->
	 	<div class="posts col-md-9">
	 		<div class="post-entry">	 			 			
	            
	            <div class="post-content">
					<h2 class="post-title"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h2>
					<ul class="meta">
						<li>Posted By : <asp:Label ID="lblOperator" runat="server" Text=""></asp:Label></li>
						<li><asp:Label ID="lblDate" runat="server" Text=""></asp:Label></li>						
						<li><asp:Label ID="lblView" runat="server" Text=""></asp:Label> Views</li>
					</ul><!-- /.meta -->
					<asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
				</div><!-- /.post-content -->
	 		</div><!-- /.post-entry -->

			<section id="comments" class="inner-bottom-xs" style="padding-top: 40px;">
                <h3 style="color: #59b210;font-weight:bold;">Tin khác</h3>

                <div class="comment-item">
                    <div class="row no-margin">
                        <asp:Repeater ID="rptOther" runat="server">
                        <ItemTemplate>
                            <div class="media">
					            <a href='<%# Eval("UrlRewrite")%>' class="pull-left"><img src='<%# Eval("ImgLink")%>' alt="" style="width: 170px; height: 150px;"></a>
					            <div class="media-body">
						            <h4 class="media-heading"><a href='<%# Eval("UrlRewrite")%>'><%# Eval("Title")%> </a></h4>
                                    <ul class="meta">
						                <li>Posted By : <%# Eval("Operator")%> </li>
						                <li><%# Convert.ToDateTime(Eval("PublishDate")).ToString("MMMM dd, yyyy")%></li>						
						                <li><%# Eval("ViewNumber")%> Views</li>
					                </ul>
						            <p><%# Eval("Description")%></p>
					            </div>
				            </div>
                        </ItemTemplate>
                        </asp:Repeater>                    
                    </div>
                </div>
            </section>
			
		</div><!-- /.posts -->

		<!-- ========================================= CONTENT :END ========================================= -->
			
        <!-- ========================================= SIDEBAR ========================================= -->
        <div class="col-md-3">
			<aside class="sidebar blog-sidebar">	
	            <div class="widget">
	                <div class="simple-banner">
		                <a href="#"><img alt="" class="img-responsive" src="~/assets/images/blank.gif" data-echo="~/assets/images/banners/banner-simple.jpg" /></a>
	                </div>
                </div>
	<!-- ========================================= RECENT POST ========================================= -->
                <div class="widget">
                    <h4>Tin nổi bật</h4>
                    <div class="body">
                        <ul class="recent-post-list">
                            <asp:Repeater ID="rptHotNews" runat="server">
                            <ItemTemplate>
                                <li class="sidebar-recent-post-item">
                                    <div class="media">
                                        <a href='<%# Eval("UrlRewrite")%>' class="thumb-holder pull-left">
                                            <img alt="" src="~/assets/images/blank.gif" data-echo='<%# Eval("ImgLink")%>' />
                                        </a>
                                        <div class="media-body">
                                            <h5><a href='<%# Eval("UrlRewrite")%>'><%# Eval("Title")%> </a></h5>
                                            <div class="posted-date"><%# Convert.ToDateTime(Eval("PublishDate")).ToString("MMMM dd, yyyy")%></div>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                            </asp:Repeater>
                        </ul><!-- /.recent-post-list -->
                    </div><!-- /.body -->
                </div><!-- /.widget -->
                <!-- ========================================= RECENT POST : END ========================================= -->
	
            </aside><!-- /.sidebar .blog-sidebar -->       
        </div>
        <!-- /.col -->
        <!-- ========================================= SIDEBAR : END ========================================= -->

        <!-- ========================================= CONTENT ========================================= -->
    </div>
</section>
