<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NDE_StatusReport.aspx.cs" Inherits="AmoghReports.WebSite.Reports.NDE_StatusReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/main.css" rel="stylesheet">
     <script type="text/javascript" src="JS/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var projectId = $('#projId').val();
            var urlShop = "https://amoghapps.com/AmoghReportsService/GetReportXShop.asmx/GetReportXShopDetails?ProjId="+projectId;
            var urlField = "https://amoghapps.com/AmoghReportsService/GetReportXField.asmx/GetReportXFieldDetails?ProjId=" + projectId;
            var ndeType = "https://amoghapps.com/AmoghMobileService/NdtServices.asmx/GetNdtTypes?ProjId=" + projectId;
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

            let ndeDropdown = $('#ndeType');
               ndeDropdown.empty();
               ndeDropdown.append('<option value="99" selected="true">--Select--</option>');
               ndeDropdown.prop('selectedIndex', 99);

               $.getJSON(ndeType, function (data) {
                   $.each(data, function (key, entry) {
                       if (entry.ndtId != "2" && entry.ndtId != "13" && entry.ndtId != "11" && entry.ndtId != "5") {
                           ndeDropdown.append($('<option></option>').attr('value', entry.ndtId).text(entry.ndtType));
                           }
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

            $("#btnReports").click(function () {
                $('#reqMsg').css('display', 'none');
                var subCon = $("#selSubCon").val();
                var ndeType = $("#ndeType").val();

                if ((subCon == "99") || (ndeType == "99")){
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
                                NDE STATUS  
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
                                <td style="width:8%;background-color: Gainsboro;"><span>Report Type</span></td>
                                <td style="width:23%">
                                    <%-- <label for="field1">--%>
                                        <%--<input type="text" id="mt_NDE_ReportNo" runat="server" class="input-field" name="field1" value="" />--%>
                                         <input type="radio" checked="true" runat="server" name="reportType" id="rdo_reportType_include"  value="1"> Including Production & Penalty Joints <br />
                                         <input type="radio" runat="server" name="reportType" id="rdo_reportType_exclude" value="2"> Excluding Production & Penalty Joints
                                   <%--  </label>--%>
                                </td>
                                <td style="width:7%;background-color: Gainsboro;">
                                    <span>Category </span>
                                </td>
                                <td style="width:8%">
                                   <%-- <label for="field1">--%>
                                        <input type="radio" checked="true" runat="server" name="category" id="rdo_Category_shop" class="input-field"  value="1"> Shop <br />
                                         <input type="radio" runat="server" name="category" id="rdo_Category_field" class="input-field" value="2"> Field
                                    <%-- </label>--%>
                                </td>
                                <td style="width:7%;background-color: Gainsboro;">
                                    <span>Subcon<span class="required">*</span> </span>
                                </td>
                                 <td style="width:12%">
                                    <%-- <label for="field1">--%>
                                        <select id="selSubCon" runat="server" style="width:145px;height:40px">
                                           <%-- <option value="99">--Select--</option>
                                            <option value="1">ARABIAN-1</option>
                                          <option value="14">ALTURKI</option>
                                          <option value="2">STS</option>
                                          <option value="mercedes">Mercedes</option>
                                          <option value="audi">Audi</option>--%>
                                        </select>
                                    <%-- </label>--%>
                                </td>
                                <td style="width:10%;background-color: Gainsboro;">
                                    <span>NDE Type<span class="required">*</span> </span>
                                </td>
                                <td style="width:7%">
                                   <%-- <label for="field1">--%>
                                         <select id="ndeType" runat="server" style="width:145px; height:40px">
                                          <%--<option value="99">--Select--</option>--%>
                                        <%--  <option value="1">RT</option>
                                          <option value="saab">Saab</option>
                                          <option value="mercedes">Mercedes</option>
                                          <option value="audi">Audi</option>--%>
                                        </select>
                                    <%-- </label>--%>
                                </td>
                            </tr>
                            </table>
                        <label><span> </span><input type="submit" value="Preview" id="btnReports" runat="server" onserverclick="btnReport_Click"  /></label>
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
