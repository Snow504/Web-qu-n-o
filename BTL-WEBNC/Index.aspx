<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BTL_WEBNC.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="list">
        <div class="containerlist">
            <h3 class="txtSPban">SẢN PHẨM BÁN</h3>
            <!-- Sản phẩm được đổ vào datalist-->
            <asp:DataList ID="databaseindex" CssClass="containerlist" runat="server" DataKeyField="iID" RepeatColumns="3">
                <ItemTemplate>
                    <table class="infordata">
                        <tr style="margin: 0 auto;">
                            <td>
                                <a href="Product-Infor.aspx?id=<%# Eval("iID") %>">
                                    <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl='<%# Eval("sImage") %>' Width="165px" />
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="txtten" runat="server" Text='<%# Eval("sName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="txtgia" runat="server" Text='<%# Eval("fPrice") %>'></asp:Label>
                            </td>
                        </tr>

                    </table>
                </ItemTemplate>
            </asp:DataList>
            <asp:Button ID="btnPre" runat="server" Text="Trước" OnClick="btnPre_Click" CssClass="smallbutton" />
            <asp:Button ID="btnNext" runat="server" Text="Sau" OnClick="btnNext_Click" CssClass="smallbutton" />
        </div>

    </div>
</asp:Content>
