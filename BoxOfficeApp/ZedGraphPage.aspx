<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZedGraphPage.aspx.cs" Inherits="BoxOfficeApp.ZedGraphClass" %>

<%@ Register Assembly="ZedGraph.Web" Namespace="ZedGraph.Web" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ZedGraph Page</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        form {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .graph-container {
            margin-bottom: 20px;
        }

        .pie-chart-image {
            max-width: 100%;
            height: auto;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        <cc1:ZedGraphWeb ID="ZedGraphWeb1" runat="server"></cc1:ZedGraphWeb> 
        </div>
        <div>
            <asp:Image ID="imgPieChart" runat="server" />
        </div>
    </form>
</body>
</html>
