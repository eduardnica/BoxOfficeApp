<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="BoxOfficeApp.GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"

OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IdMovie") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Title" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_Title" runat="server" Text='<%#Eval("Title") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReleaseDate">
                    <ItemTemplate>
                        <asp:Label ID="lbl_releaseDate" runat="server" Text='<%#Eval("releaseDate") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_releaseDate" runat="server" Text='<%#Eval("releaseDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                       <asp:TemplateField HeaderText="URL">
                    <ItemTemplate>
                        <asp:Label ID="lbl_url" runat="server" Text='<%#Eval("url") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_url" runat="server" Text='<%#Eval("url") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                      <asp:TemplateField HeaderText="ImageURL">
                    <ItemTemplate>
                        <asp:Label ID="lbl_imageURL" runat="server" Text='<%#Eval("imageURL") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_imageURL" runat="server" Text='<%#Eval("imageURL") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

            </Columns>
            <HeaderStyle BackColor="#175676" ForeColor="#ffffff"/>
            <RowStyle BackColor="#abd4f8"/>
        </asp:GridView>
    </div>
</form>
</body>
</html>
