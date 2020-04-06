<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liquid_PenetrantTestingReport.aspx.cs" Inherits="AmoghHome.Web.Reports.Liquid_PenetrantTestingReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
     <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="~/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/perfect-scrollbar/perfect-scrollbar.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/css/util.css">
    <link rel="stylesheet" type="text/css" href="~/css/main.css">
    <!--===============================================================================================-->
    <!--===============================================================================================-->
    <script src="~/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/vendor/bootstrap/js/popper.js"></script>
    <script src="~/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <style>

</style>
    <title></title>
</head>
    
<body>
     <div class="">
            <div class="">
                <div class="headerInfo">
                    LIQUID PENETRANT TESTING REPORT 
                </div><br />
                    <form runat="server" id="form">
                        <div class="form-row align-items-center">
                            <div class="col-auto">
                                <input type="text" id="rt_NDE_ReportNo" runat="server" class="form-control mb-2" placeholder="NDE Report No">
                            </div>
                            <div class="col-auto">
                                <button type="submit" id="btnReport" runat="server" onserverclick="btnReport_Click" class="btn btn-primary mb-2">Preview</button>
                            </div><br />
                            <hr />
                          <div class="row">
                                    <reportViewer:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="900"></reportViewer:ReportViewer>
                          </div>
                        </div>
                    </form>
                </div>
         </div>
</body>
</html>
