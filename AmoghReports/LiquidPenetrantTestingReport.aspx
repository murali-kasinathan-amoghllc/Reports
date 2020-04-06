<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiquidPenetrantTestingReport.aspx.cs" Inherits="AmoghReports.Website.LiquidPenetrantTestingReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="liquidPenetrantTestingForm" runat="server">
        Project ID
        <asp:TextBox ID="txtProjectID" runat="server"></asp:TextBox>
        <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreview_Click" />
        <telerik:RadScriptManager ID="liquidPenetrantTestingRptRadScriptManager" runat="server"></telerik:RadScriptManager>
        <div>
            <reportViewer:ReportViewer ID="liquidPenetrantTestingReportViewer" runat="server" Width="100%" Height="900"></reportViewer:ReportViewer>
        </div>
    </form>
</body>
</html>
