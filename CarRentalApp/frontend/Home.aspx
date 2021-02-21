<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="frontend.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <label>Welcome back</label>
        
        <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="name" runat="server" Height="175px" Width="383px">
            <Columns>
                <asp:CommandField DeleteText="Return car" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <p>
            <asp:Label ID="Label1" runat="server" Text="No Cars are rented by you!!"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Available cars for rent!</p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="152px" Width="191px">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" BackColor="green" Height="31px" OnClick="Button1_Click" Text="Rent this car" Width="140px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button2" BackColor="Red" runat="server" Height="35px" Text="Logout" Width="111px" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>
