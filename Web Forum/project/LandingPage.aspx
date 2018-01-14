<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="project.LandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        SIGN UP PAGE - WEB FORUM<br />
        <br />
        <br />
    
        <asp:TextBox ID="TextBox1" runat="server" Placeholder="Name" ></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Placeholder="Username"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="button1" runat="server" Text="SIGN UP" OnClick="Button1_Click" style="height: 29px" />
        <br />
        <br />
        Or<br />
        <br />
        If already a user<br />
        <br />
        <asp:Button ID="button2" runat="server" Text="LOGIN" OnClick="Button2_Click" />
    
    </div>
    </form>
</body>
</html>
