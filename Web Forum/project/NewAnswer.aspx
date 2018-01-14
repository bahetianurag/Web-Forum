<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAnswer.aspx.cs" Inherits="project.NewAnswer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        WEB FORUM<br />
        <br />
        <br />
    <asp:Label ID="Label1" runat="server" Text="Write New Answer"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="ansText" runat="server" Height="105px" Width="484px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Answer" />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Go Back" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
