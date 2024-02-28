<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="BoxOfficeApp.GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewMovies" runat="server" AutoGenerateColumns="False" DataKeyNames="IdMovie">
                <Columns>
                    <asp:BoundField DataField="IdMovie" HeaderText="Movie ID" SortExpression="IdMovie" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="ReleaseDate" HeaderText="Release Date" SortExpression="ReleaseDate" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:HyperLinkField DataNavigateUrlFields="URL" DataTextField="URL" HeaderText="IMDb URL" Text="IMDb" Target="_blank" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
