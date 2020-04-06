<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeldingSummaryReport.aspx.cs" Inherits="AmoghReports.WebSite.Reports.WeldingSummaryReport" %>

<%--<%@ Register Assembly="Telerik.ReportViewer.Html5.WebForms, Version=13.1.19.618, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.Html5.WebForms" TagPrefix="telerik" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/main.css" rel="stylesheet">
     <script type="text/javascript" src="JS/jquery-3.3.1.min.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        
        $(document).ready(function () {
            var projectId = $('#projId').val();

             $("#weldNumber").autocomplete({
                    source: function (request, response) {
                        $.getJSON("https://amoghapps.com/AmoghReportsService/GetReportParameters.asmx/GetWeldReportNo?ProjId="+ projectId +"&weldReportNo=" + request.term, function (data) {
                            response($.map(data, function (value, key) {
                                return {
                                    label: value.weld_rep_no,
                                    value: value.weld_rep_no
                                };
                            }));
                        });
                    },
                    autoFocus: true
                });

            $("#btnReports").click(function () {
                $('#reqMsg').css('display', 'none');
                var weldNo = $("#weldNumber").val();

                if (weldNo == "") {
                    $('#reqMsg').css('display', 'block');
                    return false;
                  }
            });
        });
    </script>
</head>
<body>
     <div class="">
                <span class="">
                    <img src="Images/master-header.png" alt="Image" style="height: 70px" />
                            <span class="lo-image">
                                DAILY WELDING CONTROL SHEET 
                            </span>
                </span>
                <hr />
         <div class="form-style-2">
                    <form runat="server" id="form" method="post">
                        <div id="reqMsg" style="display:none; color:red">Please Enter the value!</div>
                        <input type="hidden" id="projId" runat="server" value="" />
                        <div class="form-row align-items-center">
                            <label for="field1"><span>Weld ReportNo <span class="required">*</span></span><input type="text" id="weldNumber" runat="server" class="input-field" style="height:30px" name="field1" value="" /></label>
                            <label><span> </span><input type="submit" value="Preview" id="btnReports" runat="server" onserverclick="BtnReports_Click"  /></label>
                         
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
