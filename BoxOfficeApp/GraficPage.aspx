<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GraficPage.aspx.cs" Inherits="BoxOfficeApp.GraficPage" %>

<%@ Register assembly="ZedGraph.Web" namespace="ZedGraph.Web" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 456px">
    <form id="form1" runat="server">
        <div>
            <cc1:ZedGraphWeb ID="ZedGraphWeb1" runat="server" Height="400" Width="800">
            </cc1:ZedGraphWeb>
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Inapoi" />
            <br />
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/data/data.xml"></asp:XmlDataSource>
            <asp:TextBox ID="TextBox2" runat="server" BorderStyle="None" ReadOnly="True">Integrarea datelor cu XML</asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" ReadOnly="True">Tabel Categorii</asp:TextBox>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource1">
                <Columns>
                    <asp:BoundField DataField="CategorieId" HeaderText="CategorieId" SortExpression="CategorieId" />
                    <asp:BoundField DataField="Denumire" HeaderText="Denumire" SortExpression="Denumire" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
