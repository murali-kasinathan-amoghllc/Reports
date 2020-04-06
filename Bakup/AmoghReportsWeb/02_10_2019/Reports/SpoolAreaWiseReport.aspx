<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpoolAreaWiseReport.aspx.cs" Inherits="AmoghHome.Web.Views.Home.SpoolAreaWiseReport" %>

<%--<%@ Register Assembly="Telerik.ReportViewer.Html5.WebForms, Version=13.1.19.618, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.Html5.WebForms" TagPrefix="telerik" %>--%>

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
/** {
  box-sizing: border-box;
}

.textVal{
  width: 100%;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 4px;
  resize: vertical;
}

label {
  padding: 12px 12px 12px 0;
  display: inline-block;
}

input[type=submit] {
  background-color: #4CAF50;
  color: white;
  padding: 12px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

input[type=submit]:hover {
  background-color: #45a049;
}

.container {
  border-radius: 5px;
  background-color: #f2f2f2;
  padding: 20px;
}

.col-25 {
  float: left;
  width: 15%;
  margin-top: 6px;
}

.col-75 {
  float: left;
  width: 20%;
  margin-top: 6px;
}

/* Clear floats after the columns */
/*.row:after {
  content: "";
  display: table;
  clear: both;
}*/

/* Responsive layout - when the screen is less than 600px wide, make the two columns stack on top of each other instead of next to each other */
/*@media screen and (max-width: 600px) {
  .col-25, .col-75, input[type=submit] {
    width: 100%;
    margin-top: 0;
  }
}*/
</style>
    <title></title>
</head>
    
<body>
     <div class="">
            <div class="">
                <div class="headerInfo">
                    AREA WISE SPOOL INCH DIA REPORT
                </div><br />
                    <form runat="server" id="form">
                        <div class="form-row align-items-center">
                          <div class="row">
                                    <reportViewer:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="900"></reportViewer:ReportViewer>
                          </div>
                        </div>
                    </form>
                </div>
         </div>
</body>
</html>
