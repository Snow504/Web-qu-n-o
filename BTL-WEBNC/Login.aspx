<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BTL_WEBNC.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>login</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="Login.css" />
    <script>
        function Check_input() {
            var username = document.getElementById("txtUsername").value;
            var password = document.getElementById("txtPassword").value;
            if (username.toString().length >= 5 && password.toString().length >= 5) {
                return true;
            } else {
                alert("Dữ liệu không phù hợp");
                return false;
            }

        }
    </script>
</head>
<body>
    <div class="container">
        <div class="header">
            <!-- Header-->
            <h1>LOGIN</h1>
        </div>
        <div class="main">
            <form action="Login.aspx" runat="server" onsubmit="return Check_input()" method="post">
                <!-- Nhập dữ liệu này-->
                <span>
                    <i class="fa fa-user"></i>
                    <input id="txtUsername" type="text" placeholder="Username" name="txtUsername" />
                </span>
                <br />
                <span>
                    <i class="fa fa-lock"></i>
                    <input id="txtPassword" type="password" placeholder="password" name="txtPassword" />
                </span>
                <br />
                <input class="button" type="submit" value="LOG IN" />
                <br />
                <span>
                    <a href="Signup.aspx">Not a member? <b>Sign up now</b></a>
                </span>
            </form>
        </div>
    </div>
</body>
</html>
