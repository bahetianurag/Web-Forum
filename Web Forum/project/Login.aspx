<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        LOG IN PAGE - WEB FORUM<br />
        <br />
        <br />
    
        <asp:TextBox ID="user" runat="server" Placeholder="Username"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="pass" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
    
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
