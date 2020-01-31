<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cArticles.ascx.cs" Inherits="controls_content_cArticles" %>

<main id="blog" class="inner-bottom-xs">
	<div class="container">		
		<div class="row">
			<div class="col-md-12">				
				<div class="posts sidemeta">
                    <%--<asp:UpdatePanel ID="upData" runat="server">
                    <ContentTemplate>--%>                       
                        <asp:ListView ID="lvData" runat="server" GroupItemCount="1" GroupPlaceholderID="groupPlaceholder1"
                            ItemPlaceholderID="itemPlaceholder1" OnPreRender="lvData_PreRender">
                            <LayoutTemplate>                                
                                <div id="groupPlaceholder1" runat="server"></div>                        
                            </LayoutTemplate>
                            <GroupTemplate>
                                <div id="itemPlaceholder1" runat="server"></div>
                            </GroupTemplate>
                            <ItemTemplate>
                                <div class="post format-standard">
		                            <div class="date-wrapper">
			                            <div class="date">
				                            <span class="month"><%# Eval("Month")%></span>
				                            <span class="day"><%# Eval("Day")%></span>
			                            </div>
		                            </div>
		                             <div class="format-wrapper">
			                            <a href="#"><i class="fa fa-calendar"></i></a>
		                            </div> 
		                            <div class="post-content">
			                            <h2 class="post-title"><%# Eval("Title")%></h2>
			                            <ul class="meta">
				                            <li>Posted By : <%# Eval("Operator")%></li>
				                            <li>View : <%# Eval("ViewNumber")%></li>		
                                            <li>0 Comments</li>		                
			                            </ul>
                                        <div class="row">
                                            <div class="col-xs-3 col-sm-3 no-margin">
                                                <a href='<%# Eval("UrlRewrite")%>' class="thumb-holder-new">
                                                    <img alt="" src="~/assets/images/blank.gif" data-echo='<%# Eval("ImgLink")%>' />
                                                </a>
                                            </div>
                                            <div class="col-xs-9 col-sm-9 no-margin">
                                                <p><%# Eval("Description")%></p>
			                                    <a href='<%# Eval("UrlRewrite")%>' class="le-button huge">Chi tiết</a>
                                            </div>  
                                        </div>			                
		                            </div><!-- /.post-content -->
	                            </div><!-- /.post -->
                            </ItemTemplate>
                        </asp:ListView>
                        <hr/>
                        <!-- pagination -->  
                        <div id="dvPaging" class="nav_pages" runat="server">   
                            <asp:DataPager ID="dpData" runat="server" PagedControlID="lvData" PageSize="5">
                            <Fields>                        
                                <asp:TemplatePagerField>
                                    <PagerTemplate>
                                        <div class="pagination-holder">
                                        <div class="row">
                                            <div class="col-xs-12">
                                            <div class="pages">
                                    </PagerTemplate>                                
                                    </asp:TemplatePagerField> 
                                        <asp:NumericPagerField ButtonCount="3" CurrentPageLabelCssClass="current" />
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
                </div><!-- /.posts -->
                               
			</div><!-- /.col -->
		</div><!-- /.row -->
	</div><!-- /.container -->
</main>

