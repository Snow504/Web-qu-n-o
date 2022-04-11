<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Product-Infor.aspx.cs" Inherits="BTL_WEBNC.Product_Infor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="product_detail_head">THÔNG TIN SẢN PHẨM</div>
    <!--Khung hiển thị-->
    <div class="product_detail_container">
        <div class="product_detail_left">
            <asp:Image ID="img" runat="server" CssClass="product_detail_img"/>
        </div>
        <div class="product_detail_right">
            <div class="product_detail_right_name">
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            </div>
            <div class="product_detail_right_feature">
                <asp:Label ID="lblFeature" runat="server" Text=""></asp:Label>
            </div>
            <div class="product_detail_right_price">
                <p>Giá: <asp:Label ID="lblPrice" runat="server" Text="" CssClass="lblprice"></asp:Label>₫</p>
            </div>
                <div class="product_detail_right_price">
                <p>Số lượng: <asp:Textbox ID="txtfigure" runat="server"></asp:Textbox></p>
            </div>
            <div class="product_detail_right_cart">
                <asp:Button ID="btnCart" runat="server" CommandArgument="" Text="MUA NGAY" CssClass="btnCart" OnClick="btnCart_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
