<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadiographyInspectionReport.aspx.cs" Inherits="AmoghReports.Website.RadiographyInspectionReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="radiographyInsForm" runat="server">
        Project ID
        <asp:TextBox ID="txtProjectID" runat="server"></asp:TextBox>
        <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreview_Click" />
        <telerik:RadScriptManager ID="radiographyInsRptRadScriptManager" runat="server"></telerik:RadScriptManager>
        <div>
            <reportViewer:ReportViewer ID="radiographyInsReportViewer" runat="server" Width="100%" Height="900"></reportViewer:ReportViewer>
        </div>
    </form>
</body>
</html>
