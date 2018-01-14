<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forum.aspx.cs" Inherits="project.forum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    
        <asp:BulletedList ID="BulletedList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="username" BulletStyle="Disc" DataValueField="username">
        </asp:BulletedList>


    
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    

    
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
        </asp:GridView>
        <br />

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbconnect1 %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
    

    
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbconnect1 %>" SelectCommand="SELECT * FROM [questions]"></asp:SqlDataSource>
        <br />

        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dbconnect1 %>" SelectCommand="SELECT * FROM [comments]"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="quesId" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="quesId" HeaderText="quesId" ReadOnly="True" SortExpression="quesId" />
                <asp:BoundField DataField="question" HeaderText="question" SortExpression="question" />
                <asp:BoundField DataField="commentId" HeaderText="commentId" SortExpression="commentId" />
                <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="commentId" DataSourceID="SqlDataSource3">
            <Columns>
                <asp:BoundField DataField="commentId" HeaderText="commentId" ReadOnly="True" SortExpression="commentId" />
                <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
                <asp:BoundField DataField="text" HeaderText="text" SortExpression="text" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
<br />
<u>Selected Row Values: </u>
    <br />
<br />
<asp:Label ID="lblValues" runat="server" Text=""></asp:Label>

    
    </div>
    </form>
</body>
</html>
