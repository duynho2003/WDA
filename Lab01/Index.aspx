<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Lab01.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 83%;
        }
        .auto-style2 {
            height: 28px;
            font-size: medium;
        }
        .auto-style3 {
            font-weight: bold;
            color: #0066CC;
        }
        .auto-style4 {
            text-align: center;
            height: 40px;
        }
        .auto-style5 {
            height: 35px;
            width: 150px;
        }
        .auto-style6 {
            height: 35px;
            width: 351px;
        }
        .auto-style7 {
            height: 71px;
            width: 150px;
        }
        .auto-style8 {
            height: 71px;
            width: 351px;
        }
        .auto-style9 {
            margin-right: 0px;
        }
    </style>
</head>
<body style="height: 123px; width: 418px">
    <form id="form1" runat="server">
        <div class="auto-style9">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2" style="text-align: center"><strong>Login page</strong></td>
                </tr>
                <tr>
                    <td class="auto-style7">User name:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="236px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="IblUsername" runat="server" ControlToValidate="TextBox1" ErrorMessage="User name is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">Password:</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox1_TextChanged" Width="236px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2"><strong>
                        <asp:Button ID="Button1" runat="server" CssClass="auto-style3" OnClick="Button1_Click" Text="Sign in" />
                        </strong></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
