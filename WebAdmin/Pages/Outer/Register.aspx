﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Outer_Register" %>

<!DOCTYPE html>
<html class="bg-black">
    <head>
        <meta charset="UTF-8">
        <title>AdminLTE | Log in</title>
        <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
        <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="//cdnjs.cloudflare.com/ajax/libs/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <!-- Theme style -->
        <link href="../../css/AdminLTE.css" rel="stylesheet" type="text/css" />

        <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
        <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js" type="text/javascript"></script>

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
          <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
    </head>
    <body>
        <form id="form" runat="server" class="bg-black">
            <div class="form-box" id="login-box">
                <div class="header">Register New Membership</div>
                <form action="../../index.html" method="post">
                    <div class="body bg-gray">
                        <div class="form-group">
                            <input type="text" name="name" class="form-control" placeholder="Full name"/>
                        </div>
                        <div class="form-group">
                            <input type="text" name="userid" class="form-control" placeholder="User ID"/>
                        </div>
                        <div class="form-group">
                            <input type="password" name="password" class="form-control" placeholder="Password"/>
                        </div>
                        <div class="form-group">
                            <input type="password" name="password2" class="form-control" placeholder="Retype password"/>
                        </div>
                    </div>
                    <div class="footer">                    

                        <button type="submit" class="btn bg-olive btn-block">Sign me up</button>

                        <a href="./login.aspx" class="text-center">I already have a membership</a>
                    </div>
                </form>

                <div class="margin text-center">
                    <span>Register using social networks</span>
                    <br/>
                    <button class="btn bg-light-blue btn-circle"><i class="fa fa-facebook"></i></button>
                    <button class="btn bg-aqua btn-circle"><i class="fa fa-twitter"></i></button>
                    <button class="btn bg-red btn-circle"><i class="fa fa-google-plus"></i></button>

                </div>
            </div>
        </form>
    </body>
</html>