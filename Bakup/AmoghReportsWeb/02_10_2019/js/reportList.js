$(document).ready(function () {
  
    $("#btnLogOut").bind("click", function () {
        $.ajax({
            type: "POST",
            //url: '/Home/LogOut',
            url: document.getElementById('hdnURL').value + "Home/LogOut",
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (response) {
              
            },
            error: function (xhr, status, error) {
            }
        }); 
    });

    $('#myReports').DataTable({
        "filter": true,
        "ajax": {
            //"url": "/Home/GetReportsList",
            url: document.getElementById('hdnURL').value + "Home/GetReportsList",
            "type": "POST",
            "datatype": "json"
            //"data": '{"ProjId":"' + sessionStorage.getItem("reportID") + '","categoryID":"1"}',
        },
        "columns": [
            { "data": "reportId", "autoWidth": true },
            { "data": "reportTitle", "autoWidth": true }
            //{ "data": "ServiceUrl", "autoWidth": true,  }
        ]
    });

    function openWindow(url) {
        window.open(document.getElementById('hdnURL').value + url, '_blank');
    }

    $('#myReports tbody').on('click', 'tr', function () {
        var table = $('#myReports').DataTable();
        var data = table.row(this).data();
        if (data.reportTitle == "SPOOL INCH-DIA SUMMARY") {
            openWindow("Reports/SpoolAreaWiseReport.aspx");
        }
        if (data.reportTitle == "ISOMETRIC SUMMARY -AREA WISE") {
            openWindow("Reports/Isometric_SummaryAreaWiseReport.aspx");
        }
        if (data.reportTitle == "ISOMETRIC SUMMARY - MATERIAL WISE") {
            openWindow("Reports/Isometric_SummaryMatWiseReport.aspx");
        }
        if (data.reportTitle == "WELDING SUMMARY - DUQM") {
            openWindow("Reports/WeldingSummaryReport.aspx");
        }
        if (data.reportTitle == "RT SUMMARY - MATERIAL WISE") {
            openWindow("Reports/RT_SummaryMaterialWiseReport.aspx");
        }
        if (data.reportTitle == "SPOOL CLEARANCE SHEET - DUQM") {
            openWindow("Reports/SpoolClearanceAndReleaseReport.aspx");
        }
        if (data.reportTitle == "INCH DIA SUMMARY CHART") {
            openWindow("Charts/SpoolId_PieChart.aspx");
        }
    });
});



