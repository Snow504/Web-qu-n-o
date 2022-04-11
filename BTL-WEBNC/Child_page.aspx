<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Child_page.aspx.cs" Inherits="BTL_WEBNC.Child_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="list">
        <div class="containerlist">
            <h3 class="txtSPban">SẢN PHẨM BÁN</h3>
            <!-- Sản phẩm được đổ vào datalist-->
            <asp:datalist id="databaseindex" cssclass="containerlist" runat="server" datakeyfield="iID" repeatcolumns="3">
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
            </asp:datalist>
            <asp:button id="btnPre" runat="server" text="Trước" onclick="btnPre_Click" cssclass="smallbutton" />
            <asp:button id="btnNext" runat="server" text="Sau" onclick="btnNext_Click" cssclass="smallbutton" />
        </div>

    </div>
</asp:Content>
