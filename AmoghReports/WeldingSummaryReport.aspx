<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeldingSummaryReport.aspx.cs" Inherits="AmoghReports.Website.WeldingSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type=<"text/javascript">
        this.print({ bUI: true, bSilent: false, bShrinkToFit: true });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        Project ID:
        <asp:TextBox ID="txtProjectId" runat="server"></asp:TextBox>
        Weld Report No: <asp:TextBox ID="txtWeldNumber" runat="server"></asp:TextBox>
        <asp:Button ID="btnReport" runat="server" Text="Report" OnClick="btnReport_Click" />
        <br />
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <div>
            <br />
            <reportViewer:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="900"></reportViewer:ReportViewer>
        </div>
    </form>
</body>
</html>
