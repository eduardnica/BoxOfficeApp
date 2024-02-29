<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZedGraphPage.aspx.cs" Inherits="BoxOfficeApp.ZedGraphClass" %>

<%@ Register Assembly="ZedGraph.Web" Namespace="ZedGraph.Web" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        <cc1:ZedGraphWeb ID="ZedGraphWeb1" runat="server"></cc1:ZedGraphWeb> 
        </div>
    </form>
</body>
</html>
