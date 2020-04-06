<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Isometric_SummaryMatWiseReport.aspx.cs" Inherits="AmoghReports.WebSite.Reports.Isometric_SummaryMatWiseReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/main.css" rel="stylesheet">
</head>
<body>
     <div class="">
                <span class="">
                    <img src="Images/master-header.png" alt="Image" style="height: 70px" />
                            <span class="lo-image">
                                MATERIAL WISE ISOMETRIC SUMMARY
                            </span>
                </span>
                <hr />
         <div class="form-style-2">
                    <form runat="server" id="form" method="post">
                          <div class="row">
                                    <reportViewer:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="900"></reportViewer:ReportViewer>
                          </div>
                        </form>
                        </div>
         </div>
</body>
</html>