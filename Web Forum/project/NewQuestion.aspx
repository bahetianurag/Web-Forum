<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewQuestion.aspx.cs" Inherits="project.NewQuestion" %>

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
    
        <asp:Label ID="Label1" runat="server" Text="New Question"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="quesText" runat="server" Height="105px" Width="484px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Question" />
        <br />
        <br />
        <br />
    
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Go Back" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
