<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <!-- Meta -->    
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
    <title>The Vuong's Cosmetics</title>
    
    <meta name="robots" content="index, follow" />
    <meta name="keywords" content="" />
	<meta name="description" content="" />
    <meta name="author" content="">
     <!-- Site Icons -->
    <link rel="shortcut icon" href="/assets/images/favicon.ico" type="image/x-icon">
    <link rel="apple-touch-icon" href="/assets/images/apple-touch-icon.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="/assets/css/bootstrap.min.css">
    <!-- Site CSS -->
    <link rel="stylesheet" href="/assets/css/style.css">
	
    <!-- Responsive CSS -->
    <link rel="stylesheet" href="/assets/css/responsive.css">
    <!-- Custom CSS -->
    <link rel="stylesheet" href="/assets/css/custom.css">

    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    
    <%--<script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
          m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-75267049-1', 'auto');
        ga('send', 'pageview');

    </script>--%>
</head>
<body>
    <form id="frmMain" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
     <script lang="JavaScript" type="text/javascript">
        function EndRequestHandler() {
            theForm.action = document.location.href; theForm._initialAction = theForm.action;
        } if (typeof (Sys) != "undefined") {
            EndRequestHandler(); Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
    </script>
        
    <!-- Start Main Top -->
    <div class="main-top" id="dvHeader" runat="server"></div>
    <!-- End Main Top -->
    <header class="main-header" id="dvmenu" runat="server"></header>
   
    <!-- Start Top Search -->
    <div class="top-search">
        <div class="container">
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-search"></i></span>
                <input type="text" class="form-control" placeholder="ex: Shine Spray...">
                <span class="input-group-addon close-search"><i class="fa fa-times"></i></span>
            </div>
        </div>
    </div>
    <!-- End Top Search -->

    <!-- Start Slider -->
    <div id="dvSlider" runat="server"></div>
    <!-- End Slider -->    

    <div id="dvContact" runat="server"></div>
    <div id="dvAbout" runat="server"></div>
        
    <div id="dvProduct" runat="server"></div>
    <div id="dvBestseller" runat="server"></div>

    <!-- Start Footer  -->
    <footer id="footer">
        <div id="dvFooter" runat="server"></div>
    </footer>
    <!-- End Footer  -->
    <!-- Start copyright  -->
    <div class="footer-copyright">
        <p class="footer-company">2019 &copy; Bản quyền thuộc về <a href="#">VIPHARMA CO., LTD.</a></p>
    </div>
    <!-- End copyright  -->
    <a href="#" id="back-to-top" title="Back to top" style="display: none;">&uarr;</a>
    <!-- JavaScripts placed at the end of the document so the pages load faster -->
    <!-- ALL JS FILES -->
    <script src="/assets/js/jquery-3.2.1.min.js"></script>
    <script src="/assets/js/popper.min.js"></script>
    <script src="/assets/js/bootstrap.min.js"></script>
    <!-- ALL PLUGINS -->
    <script src="/assets/js/jquery.superslides.min.js"></script>
    <%--<script src="/assets/js/bootstrap-select.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.13.12/js/bootstrap-select.js"></script>
    <script src="/assets/js/inewsticker.js"></script>
    <script src="/assets/js/bootsnav.js"></script>
    <script src="/assets/js/images-loded.min.js"></script>
    <script src="/assets/js/isotope.min.js"></script>
    <script src="/assets/js/owl.carousel.min.js"></script>
    <script src="/assets/js/baguetteBox.min.js"></script>
    <script src="/assets/js/form-validator.min.js"></script>
    <script src="/assets/js/contact-form-script.js"></script>
    <script src="/assets/js/custom.js"></script>

    <%--<script src="http://maps.google.com/maps/api/js?sensor=false&amp;language=en"></script>
    <script src="/assets/js/gmap3.min.js"></script>--%>
   
    </form>
</body>
</html>
