<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitupWeldingProgressReport.aspx.cs" Inherits="AmoghReports.WebSite.Reports.FitupWeldingProgressReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/main.css" rel="stylesheet">
       <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
          $( function() {
             $("#txtDateFrom,#txtDateTo").datepicker({dateFormat: 'dd-MM-yy'});
        });
        $(document).ready(function () {
            var projectId = $('#projId').val();
            var urlShop = "https://amoghapps.com/AmoghReportsService/GetReportXShop.asmx/GetReportXShopDetails?ProjId="+projectId;
            var urlField = "https://amoghapps.com/AmoghReportsService/GetReportXField.asmx/GetReportXFieldDetails?ProjId=" + projectId;
            var url = urlShop;
             let dropdown = $('#selSubCon');
               dropdown.empty();
               dropdown.append('<option value="99" selected="true">--Select--</option>');
               dropdown.prop('selectedIndex', 99);

               $.getJSON(url, function (data) {
                  $.each(data, function (key, entry) {
                    dropdown.append($('<option></option>').attr('value', entry.SUB_CON_ID).text(entry.SUB_CON_NAME));
                  })
            });

           

           $('input:radio[name=category]').change(function() {
                if (this.value == '1') {
                    url = urlShop;
                }
                else if (this.value == '2') {
                    url = urlField;
               }

               $.getJSON(url, function (data) {
                       dropdown.empty();
                   dropdown.append('<option value="99" selected="true">--Select--</option>');
                    dropdown.prop('selectedIndex', 99);
                  $.each(data, function (key, entry) {
                    dropdown.append($('<option></option>').attr('value', entry.SUB_CON_ID).text(entry.SUB_CON_NAME));
                  })
            });
              
            });

            $(".btnPreviewCls").click(function () {
                $('#reqMsg').css('display', 'none');
                var subCon = $("#selSubCon").val();
                var dateFrom = $("#txtDateFrom").val();
                var dateTo = $("#txtDateTo").val();

                if ((subCon == "99") || (dateFrom == "") || (dateTo == "")){
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
                                Fitup and Welding Progress Report
                            </span>
                </span>
                <hr />
         <div class="form-style-2">
                    <form runat="server" id="form" method="post">
                        <input type="hidden" id="projId" runat="server" value="" />
                        <div id="reqMsg" style="display:none; color:red">Please Select the mandatory value!</div>
                        <div class="form-row align-items-center">
                            <table style="width: 100%">
                            <tr>
                                <td style="width:5%;background-color: Gainsboro;">
                                    <span>Category </span>
                                </td>
                                <td style="width:5%">
                                        <input type="radio" checked="true" runat="server" name="category" id="rdo_Category_shop" class="input-field"  value="1"> Shop <br />
                                         <input type="radio" runat="server" name="category" id="rdo_Category_field" class="input-field" value="2"> Field
                                </td>
                                <td style="width:5%;background-color: Gainsboro;">
                                    <span>Subcon<span class="required">*</span> </span>
                                </td>
                                 <td style="width:8%">
                                        <select id="selSubCon" runat="server" style="width:145px;height:40px">
                                        </select>
                                </td>
                                <td style="width: 5%; background-color: Gainsboro;">
                                <span>Date From<span class="required">*</span> </span>
                            </td>
                            <td style="width: 5%">
                                <input type="text" autocomplete="off" runat="server" name="dateFrom" id="txtDateFrom" class="input-field" style="width: 145px; height: 40px">
                            </td>
                            <td style="width: 5%; background-color: Gainsboro;">
                                <span>Date To<span class="required">*</span> </span>
                            </td>
                            <td style="width: 5%">
                                <input type="text" autocomplete="off" runat="server" name="dateTo" id="txtDateTo" class="input-field" style="width: 145px; height: 40px">
                            </td>
                            </tr>
                            </table>
                          <table>
                             <tr>
                                <td><label><input type="submit" value="Area Wise" id="btnReports" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" /></label></td>
                                <td><label><input type="submit" value="Size Wise" id="btnReports1" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" /></label></td>
                                <td><label><input type="submit" value="Material Wise" id="btnReports2" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" /></label></td>
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
