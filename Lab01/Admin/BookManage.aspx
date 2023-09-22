<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookManage.aspx.cs" Inherits="Lab01.BookManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 40%;
        }
        .auto-style2 {
            text-align: center;
            font-size: large;
        }
        .auto-style3 {
            width: 189px;
        }
        .auto-style4 {
            font-size: xx-large;
        }
        .auto-style5 {
            font-size: medium;
        }
        .auto-style6 {
            text-align: center;
        }
        .auto-style7 {
            width: 275px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong><span class="auto-style4">Book Management</span></strong><br />
          
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2"><strong>Create new Book</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3"><strong>Title:</strong></td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" Width="275px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><strong>Author:</strong></td>
                    <td>
                        <asp:TextBox ID="txtAuthor" runat="server"  Width="275px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><strong>Edition:</strong></td>
                    <td>
                        <asp:TextBox ID="txtEdition" runat="server"  Width="275px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><strong>Price:</strong></td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server"  Width="275px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><strong>Images:</strong></td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" colspan="2">
                        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
                    </td>
                </tr>
            </table>
            <br class="auto-style5" />
            <span class="auto-style5"><strong>Book List</strong></span><asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="245px" Width="739px">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
          
        </div>
    </form>
</body>
</html>
