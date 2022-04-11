<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Carts.aspx.cs" Inherits="BTL_WEBNC.Carts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <center>
        <div >
    <h2 style="margin-top:10px;">Giỏ hàng của bạn: <small class="pull-right"><asp:Label ID="TotalProduct" runat="server" Text="Label"></asp:Label> sản phẩm </small></h2>
        <hr>
    <table style="margin: 10px 0 150px 0; border:2px solid black;">
                    <thead>
                        <tr>
                            <th style="width:300px">Sản phẩm</th> <br />
                            <th style="width:300px">Tên sản phẩm</th>
                            <th style="width:150px">Giá</th>
                            <th style="width:150px">Số lượng</th>
                            <th style="width:150px">Thành tiền</th>
                        </tr>
                    </thead>
                            
                    <tbody>
                        <asp:ListView ID="DsGioHang" runat="server">
                            <LayoutTemplate>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>

                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><img width="200" src="<%# Eval("img") %>" alt=""></td>
                                    <td style="width:300px"><p ><%# Eval("name") %></p></td>
                                    <td style="width:100px"><%# Eval("price") %>đ</td>
                                    <td style="width:100px"><%# Eval("figure") %></td>
                                    <td style="width:100px">  <asp:Label ID="lblTT" runat="server" Text='<%# showTT(Eval("figure"), Eval("price")) %>'></asp:Label>đ</td>
                                    <td>
                                        <div >
                                            <asp:Button runat="server" CommandArgument='<%# Eval("id") %>' Text="X" OnCommand="Unnamed_Command"/>
                                        </div>
                                    </td>
                                   
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                        <tr>
                            <td colspan="4" class="alignR">Tổng tiền :	</td>
                            <td><asp:Label ID="TotalPriceProduct" runat="server" Text="Label"></asp:Label>đ</td>
                            <td>
                                <div >
                                <asp:Button runat="server"  CommandArgument='<%# Eval("id") %>' Text="Thanh toán" BackColor="#0066FF" />
                                </div>
                            </td>
                            <td></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </center>
</asp:Content>
