<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="BoxOfficeApp.FirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Box Office App</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to Box Office App</h1>
            <div>
                <label for="dropDownMovies">Select Movie:</label>
                <asp:DropDownList ID="dropDownMovies" runat="server">
                </asp:DropDownList>
            </div>
            <div>
                <label for="txtDate">Select Date:</label>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div>
                <label for="txtQuantity">Quantity:</label>
                <asp:TextBox ID="txtQuantity" runat="server" Text="1"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnBuyTickets" runat="server" Text="Buy Tickets" OnClick="btnBuyTickets_Click" />
            </div>
        </div>
    </form>
</body>
</html>
