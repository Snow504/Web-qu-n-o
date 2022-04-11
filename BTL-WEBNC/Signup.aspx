<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="BTL_WEBNC.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>login</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="Login.css" />
    <script>

        function Redirect() {
            window.location = "Login.aspx";
        }
        function Accept() {
            var user = document.getElementById("txtUsername").value;
            var pass = document.getElementById("txtPassword").value;
            var repass = document.getElementById("txtrePassword").value;
            if (user != "" && pass != "" && repass != "") {
                if (user.toString().length < 5 && pass.toString().length < 5 && user.toString().length > 30 && pass.toString().length>30) {
                    alert("Tài khoản và mật khẩu từ 5 ký tự trở lên và dưới 30 ký tự");

                } else {
                    if (pass === repass) {
                        var modal = document.getElementById("boxAlert");
                        modal.style.display = "block";
                    } else {
                        alert("Mật khẩu không khớp");
                    }
                }
            } else {
                alert("Chưa đủ thông tin");
            }

        }
        function Cannel() {
            var modal = document.getElementById("boxAlert");
            modal.style.display = "none";
        }
        function SendData() {
            var modal = document.getElementById("boxAlert");
            modal.style.display = "none";
            return true;
        }
    </script>
</head>
<body>
    <div class="container">
        <div class="header">
            <h1>SIGN UP</h1>
        </div>
        <div class="main">
            <form action="Signup.aspx" method="post" runat="server" onsubmit="return SendData();">
                <!-- Nhập dữ liệu-->
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
                <span>
                    <i class="fa fa-lock"></i>
                    <input id="txtrePassword" type="password" placeholder="repassword" name="repass" />
                </span>
                <br />
                <input class="smallbutton" type="button" value="SIGN UP" onclick="Accept();" />
                <input class="smallbutton" type="button" value="CANNEL" onclick="Redirect();" />
                <!-- The Box thong báo -->
                <div id="boxAlert" class="modal">
                    <!-- Nội dung thông báo -->
                    <div class="modal-content">
                        <h2>Bạn có chắc tạo tài khoản mới?</h2>
                        <input class="tinybutton" type="submit" value="Accept" />
                        <input class="tinybutton" type="button" value="Cannel" onclick="Cannel();" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
