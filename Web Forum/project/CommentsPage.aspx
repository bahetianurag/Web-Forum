<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentsPage.aspx.cs" Inherits="project.CommentsPage" %>

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
        <br />
    
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

        <br />

        <asp:PlaceHolder ID="CommentsPlaceHolder" runat="server"></asp:PlaceHolder> 

        <br />
        <br />
    
        <br />
        <asp:Button ID="Button1" runat="server" Text="ADD NEW ANSWER?" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <br />
    
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Go Back" />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
