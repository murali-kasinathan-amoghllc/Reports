<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpoolClearanceAndReleaseReport.aspx.cs" Inherits="AmoghReports.Website.SpoolClearanceAndReleaseReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type=<"text/javascript">
        this.print({ bUI: true, bSilent: false, bShrinkToFit: true });
    </script>
</head>
<body>
    <form id="SpoolClearanceAndReleaseReportForm" runat="server">
        Project ID:
        <asp:TextBox ID="txtProjectId" runat="server"></asp:TextBox>
        <asp:Button ID="btnReport" runat="server" Text="Report" OnClick="btnReport_Click" />
        <telerik:RadScriptManager ID="SpoolClearanceAndReleaseReportScriptManager" runat="server"></telerik:RadScriptManager>
        <div>
            <reportViewer:ReportViewer ID="SpoolClearanceAndReleaseReportViewer" runat="server" Width="100%" Height="900"></reportViewer:ReportViewer>
        </div>
    </form>
</body>
</html>
