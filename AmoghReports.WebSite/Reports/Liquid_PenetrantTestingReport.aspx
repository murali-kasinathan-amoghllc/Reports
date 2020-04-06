<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liquid_PenetrantTestingReport.aspx.cs" Inherits="AmoghReports.WebSite.Reports.Liquid_PenetrantTestingReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/main.css" rel="stylesheet">
     <script type="text/javascript" src="JS/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnReports").click(function () {
                $('#reqMsg').css('display', 'none');
                var ndeNo = $("#rt_NDE_ReportNo").val();

                if (ndeNo == "") {
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
                                LIQUID PENETRANT TESTING REPORT 
                            </span>
                </span>
                <hr />
         <div class="form-style-2">
                    <form runat="server" id="form" method="post">
                        <div id="reqMsg" style="display:none; color:red">Please Enter the value!</div>
                        <div class="form-row align-items-center">
                            <label for="field1"><span>NDE ReportNo <span class="required">*</span></span><input type="text" id="rt_NDE_ReportNo" runat="server" class="input-field" name="field1" value="" /></label>
                            <label><span> </span><input type="submit" value="Preview" id="btnReports" runat="server" onserverclick="btnReport_Click"  /></label>
                            <%--<input type="submit" value="Register" id="Submit1" runat="server" onserverclick="btnReport1_Click"  />--%>
                         
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
