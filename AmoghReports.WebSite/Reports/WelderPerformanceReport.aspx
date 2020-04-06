<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelderPerformanceReport.aspx.cs" Inherits="AmoghReports.WebSite.Reports.WelderPerformanceReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/main.css" rel="stylesheet">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <%--<script type="text/javascript" src="JS/jquery-3.3.1.min.js"></script>--%>
    <script type="text/javascript">
         $( function() {
             $("#txtDateFrom,#txtDateTo").datepicker({dateFormat: 'dd-MM-yy'});
        });

        $(document).ready(function () {
            var projectId = $('#projId').val();
            //$("#txtDateFrom").datepicker();

            var urlSubCon = "https://amoghapps.com/AmoghReportsService/GetReportParameters.asmx/GetAllSubContractorDetails?ProjId=" + projectId;
            var url = urlSubCon;
            let dropdown = $('#selSubCon');
            dropdown.empty();
            dropdown.append('<option value="99" selected="true">--(Select Subcon)--</option>');
            dropdown.prop('selectedIndex', 99);

            $.getJSON(url, function (data) {
                $.each(data, function (key, entry) {
                    dropdown.append($('<option></option>').attr('value', entry.SUB_CON_ID).text(entry.SUB_CON_NAME));
                })
            });

            $(".btnPreviewCls").click(function () {
                $('#reqMsg').css('display', 'none');
                var subCon = $("#selSubCon").val();
                var dateFrom = $("#txtDateFrom").val();
                var dateTo = $("#txtDateTo").val();

                if ((subCon == "99") || (dateFrom == "") || (dateTo == "")) {
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
            <span class="lo-image">Welder Performance
            </span>
        </span>
        <hr />
        <div class="form-style-2">
            <form runat="server" id="form" method="post">
                <input type="hidden" id="projId" runat="server" value="" />
                <div id="reqMsg" style="display: none; color: red">Please Select the mandatory value!</div>
                <div class="form-row align-items-center">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 5%; background-color: Gainsboro;">
                                <span>Date From<span class="required">*</span> </span>
                            </td>
                            <td style="width: 4%">
                                <input type="text" autocomplete="off" runat="server" name="dateFrom" id="txtDateFrom" class="input-field" style="width: 145px; height: 40px">
                            </td>
                            <td style="width: 5%; background-color: Gainsboro;">
                                <span>Date To<span class="required">*</span> </span>
                            </td>
                            <td style="width: 4%">
                                <input type="text" autocomplete="off" runat="server" name="dateTo" id="txtDateTo" class="input-field" style="width: 145px; height: 40px">
                            </td>
                            <td style="width: 6%; background-color: Gainsboro;">
                                <span>Subcon<span class="required">*</span> </span>
                            </td>
                            <td style="width: 15%">
                                <select id="selSubCon" runat="server" style="width: 155px; height: 40px">
                                </select>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td><label><input type="submit" value="Welder Wise" id="btnReports" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" /></label></td>
                            <td><label><input type="submit" value="Length Wise" id="Submit1" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" /></label></td>
                            <td><label><input type="submit" value="Material Wise" id="Submit2" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" /></label></td>
                            <td><label><input type="submit" value="RT Percent" id="Submit3" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" /></label></td>
                            <td><label><input type="submit" value="Weld Size" id="Submit4" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" /></label></td>
                            <td><label><input type="submit" value="Monthly" id="Submit5" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" /></label></td>
                            <td><label><input type="submit" value="Welder/Lineclass Wise" class="btnPreviewCls" id="Submit6" runat="server" onserverclick="btnReport_Click" /></label></td>
                            <td><label><input type="submit" value="Length/Lineclass Wise" class="btnPreviewCls" id="Submit7" runat="server" onserverclick="btnReport_Click" /></label></td>
                        </tr>
                    </table>
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

