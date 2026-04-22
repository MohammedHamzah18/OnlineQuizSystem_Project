<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="WebApplication62.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style.css" rel="stylesheet" />
    <title>Result - Online Quiz System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Score :"></asp:Label>
            <br />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" Height="260px" Width="654px">
        </asp:GridView>
    </form>
</body>
</html>
