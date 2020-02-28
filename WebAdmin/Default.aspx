<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Quản trị hệ thống - The Vuong's Cosmetics</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons -->
    <link href="//code.ionicframework.com/ionicons/1.5.2/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="./css/AdminLTE.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="./css/MyStyle.css" />
    <link rel="stylesheet" type="text/css" href="./css/datatables/dataTables.bootstrap.css" />

    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.1/jquery-ui.min.js" type="text/javascript"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- AdminLTE App -->
    <script src="./js/AdminLTE/app.js" type="text/javascript"></script>
    <!-- AdminLTE for demo purposes -->
    <%--<script src="./js/AdminLTE/demo.js" type="text/javascript"></script>--%>

    <!-- Color Picker -->
    <script src="./js/plugins/colorpicker/bootstrap-colorpicker.min.js" type="text/javascript"></script>
    <link href="./css/colorpicker/bootstrap-colorpicker.min.css" rel="stylesheet" />

    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <%--<script src="./js/AdminLTE/dashboard.js" type="text/javascript"></script>--%>

    <!-- Morris.js charts -->
    <script src="//cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="../../js/plugins/morris/morris.min.js" type="text/javascript"></script>


    <!-- DateGrahp -->
    <!-- Date Picker -->
    <link href="css/datepicker/datepicker3.css" rel="stylesheet" type="text/css" />


    <!-- Sparkline -->
    <script src="./js/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- jvectormap -->
    <script src="./js/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js" type="text/javascript"></script>
    <script src="./js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js" type="text/javascript"></script>


    <!-- jQuery Knob Chart -->
    <script src="./js/plugins/jqueryKnob/jquery.knob.js" type="text/javascript"></script>
    <!-- daterangepicker -->
    <script src="./js/plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <!-- datepicker -->
    <script src="./js/plugins/datepicker/bootstrap-datepicker.js" type="text/javascript"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="./js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js" type="text/javascript"></script>


    <!-- -->
    <script src="./js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js" type="text/javascript"></script>
    <!-- iCheck -->
    <script src="./js/plugins/iCheck/icheck.min.js" type="text/javascript"></script>
    <!-- bootstrap wysihtml5 - text editor -->
    <link href="./css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet" type="text/css" />


    <!-- Graph -->
    <!-- Morris.js charts -->
    <script src="//cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="./js/plugins/morris/morris.min.js" type="text/javascript"></script>


    <!-- POPUP -->
    <%--<script type="text/javascript" src="./js/jquery.colorbox.js"></script>
        <link type="text/css" rel="stylesheet" href="./css/colorbox.css" />--%>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
          <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
</head>
<body id="div_body" class="skin-blue">
    <form id="form" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function ConfirmDeleteCustom() {
                    confirm('Bạn có chắc chắn muốn xóa dữ liệu này không?');
                    //return confirm('Bạn có chắc chắn muốn xóa dữ liệu này không?');
                }
            </script>
        </telerik:RadCodeBlock>
        <!-- header logo: style can be found in header.less -->
        <header runat="server" id="cHeader" class="header"></header>

        <div class="wrapper row-offcanvas row-offcanvas-left">
            <!-- Left side column. contains the logo and sidebar -->
            <aside runat="server" id="cMenu" class="left-side sidebar-offcanvas"></aside>

            <!-- Right side column. Contains the navbar and content of the page -->
            <aside runat="server" id="cPage" class="right-side"></aside>
            <!-- /.right-side -->

        </div>
        <!-- ./wrapper -->

    </form>
</body>
</html>


<script type="text/javascript">

    $('button[type!=submit]').click(function () {
        // code to cancel changes
        return false;
    });
    function AddLockScreen() {

        $("#div_body").prepend("<iframe id=div_iframe></iframe>");
        $("#div_iframe").css("background-color", "Black");
        $("#div_iframe").css("z-index", "100000");
        $("#div_iframe").attr("src", "./Pages/Outer/lockscreen.aspx");
    }

    function RemoveClockScreen() {
        $("#div_iframe").css("background-color", "transparent");
        $("#div_iframe").css("z-index", "1");
        $("#div_iframe").remove();
    }

</script>

<%--<script language="javascript">
    $(document).ready(function () {
        $(".iframe").colorbox({ iframe: true, width: "90%", height: "80%" });
    });
    //Using with update panel
    function pageLoad(sender, args) {
        if (args.get_isPartialLoad()) {
            $(".iframe").colorbox({ iframe: true, width: "90%", height: "80%" });
        }
    }
</script>--%>