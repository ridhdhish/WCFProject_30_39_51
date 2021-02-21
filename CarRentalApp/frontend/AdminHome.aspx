<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="frontend.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="Id" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <p>
            &nbsp;</p>
        <p>
            Add new car here!!</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="232px"></asp:TextBox>
        </p>
        <p>
            <asp:Button BackColor="Green" ID="Button1" runat="server" Height="34px" OnClick="Button1_Click" Text="Add" Width="152px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button2" BackColor="Red" runat="server" Height="30px" Text="Logout" Width="87px" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>
