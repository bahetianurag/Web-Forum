<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForum.aspx.cs" Inherits="project.Test" %>

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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="question" HeaderText="question" SortExpression="question" />
                <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
                <asp:TemplateField><ItemTemplate>
                <asp:LinkButton id="linkbutton" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" CommandName="Select" runat ="server" Text="View" />
                    </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="ADD NEW QUESTION?" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbconnect1 %>" SelectCommand="SELECT [question], [author] FROM [questions]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
    </div>
       
    </form>
</body>
</html>
