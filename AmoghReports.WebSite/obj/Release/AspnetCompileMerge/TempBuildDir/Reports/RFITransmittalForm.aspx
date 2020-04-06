<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RFITransmittalForm.aspx.cs" Inherits="AmoghReports.WebSite.Reports.RFITransmittalForm" %>

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
             $("#txtDateFrom,#txtInspDate").datepicker({dateFormat: 'dd-MM-yy'});
        });
        $(document).ready(function () {
            //$('#RFIInput').hide();
            var projectId = $('#projId').val();
            var url = "https://amoghapps.com/AmoghReportsService/GetReportParameters.asmx/GetAllSubContractorDetails?ProjId=" + projectId;
            let dropdown = $('#selSubCon');
            dropdown.empty();
            dropdown.append('<option value="99" selected="true">--Select--</option>');
            dropdown.prop('selectedIndex', 99);

            $.getJSON(url, function (data) {
                $.each(data, function (key, entry) {
                    dropdown.append($('<option></option>').attr('value', entry.SUB_CON_ID).text(entry.SUB_CON_NAME));
                })
            });

            //$("#btnRegister").click(function () {
            //    $('#RFIInput').show();
            //});
          

            $(".btnPreviewCls").click(function () {
                $('#reqMsg').css('display', 'none');
                var rfiNumber = $("#txtRptRFINumber").val();

                if (rfiNumber == "") {
                    $('#reqMsg').css('display', 'block');
                    return false;
                    }
                }
            );

             $("#btnSubmit").click(function () {
                $('#reqMsg').css('display', 'none');
                var rfiNumber = $("#txtRFINumber").val();
                var subCon = $("#selSubCon").val();
                var inspName = $("#txtInspectorName").val();
                var inspDate = $("#txtInspDate").val();
                var itemDesc = $("#txtItemDescription").val();
                var insResult = $("#selInsResult").val();

                if ((rfiNumber == "99") || (subCon == "99") || (inspName == "") || (inspDate == "") || (itemDesc == "") ||(insResult == "99")) {
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
            <span class="lo-image">RFI Transmittal
            </span>
        </span>
        <hr />
        <div class="form-style-2">
            <form runat="server" id="form" method="post">
                <input type="hidden" id="projId" runat="server" value="" />
                <div id="reqMsg" style="display: none; color: red">Please Enter the mandatory value!</div>
                <div class="form-row align-items-center">
                    <input type="submit" value="Register" id="btnRegister" class=""  runat="server" onserverclick="btnRegister_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="submit" value="Preview" id="btnReports1" class="btnPreviewCls" runat="server" onserverclick="btnReport_Click" />
                    <br />
                    <table id="RFIInput" runat="server" style="width: 100%">
                        <tr>
                            <td style="">
                                <br /><span>RFI Number<span class="required">*</span> </span>
                            </td>
                            <td style="">
                                <br /><input type="text" runat="server" name="RFINumber" style="width: 165px; height: 28px" id="txtRFINumber" class="input-field" value="">
                            </td>
                            <td style="">
                               <br /> <span>Sub Contractor<span class="required">*</span> </span>
                            </td>
                            <td style="">
                                <br /><select id="selSubCon" runat="server" style="width: 165px; height: 28px">
                                </select>
                            </td>
                            <td style="">
                                <br /><span>Inspector Name <span class="required">*</span> </span>
                            </td>
                            <td style="">
                                <br /><input type="text" runat="server" name="InspectorName" id="txtInspectorName" class="input-field" style="width: 165px; height: 28px" value="">
                            </td>
                            <td style="">
                                <br /><span>Inspection Date<span class="required">*</span> </span>
                            </td>
                            <td style="">
                                <br /><input type="text" autocomplete="off" runat="server" name="dateTo" id="txtInspDate" class="input-field" style="width: 165px; height: 28px">
                            </td>
                            </tr>
                        <tr>
                            <td style="">
                                <span>Item Description<span class="required">*</span> </span>
                            </td>
                            <td colspan="3" style="">
                                <input type="text" runat="server" name="ItemDescription" id="txtItemDescription" class="input-field" style="width: 505px; height: 28px" value="">
                            </td>
                            <td style="">
                                <span>Inspection Result<span class="required">*</span> </span>
                            </td>
                            <td style="">
                                <select id="selInsResult" runat="server" style="width: 165px; height: 28px">
                                    <option value="99">(--Select--)</option>
                                    <option value="A">Acceptable</option>
                                    <option value="PA">Partially Acceptable</option>
                                    <option value="H">RFI on Hold</option>
                                    <option value="C">Cancelled</option>
                                    <option value="R">Not Ready for Inspection</option>
                                    <option value="NR">Rejected</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="right">
                                <input type="submit" value="Submit" id="btnSubmit" class="" runat="server" onserverclick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <input type="submit" value="Cancel" id="Submit1" class="" runat="server" onserverclick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                    <table id="RFIReport" runat="server" style="width:30%">
                        <tr>
                            <td style="">
                               <br /> <span>RFI Number<span class="required">*</span> </span>
                            </td>
                            <td style="">
                               <br /> <input type="text" runat="server" name="RFINumber" style="width: 165px; height: 28px" id="txtRptRFINumber" class="input-field" value="">
                            </td>
                        </tr>
                    </table>
                    <br />
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

