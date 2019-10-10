<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="kicks.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
            height: 23px;
        }
        .auto-style3 {
            text-align: center;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Shop Now!<br />
            <br />
            <asp:DataList ID="DataList1" runat="server" DataKeyField="PId" DataSourceID="Shoes" Width="236px" GridLines="Both" RepeatColumns="4" RepeatDirection="Horizontal" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" OnItemCommand="DataList1_ItemCommand">
                <ItemTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">Product ID:
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("PId") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Name:<asp:Label ID="Label2" runat="server" Text='<%# Eval("pName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("pImage") %>' width ="200px" Height ="200px"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Price:<asp:Label ID="Label3" runat="server" Text='<%# Eval("pPrice") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:ImageButton ID="addtocart" runat="server" CommandName ="addtocart"  Height ="80px" ImageUrl="~/Images/addToCart.png" Width="185px" CommandArgument ='<%# Eval("PId")%>' />
                                &nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource ID="Shoes" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [warehouse]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
