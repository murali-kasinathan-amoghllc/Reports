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
        var inputParam = [];
        inputParam.push(data.reportParams);
       // var datas = JSON.stringify({ "reportName": rowData.reportTitle});
        ////, "reportParameters": inputParam
        //$.ajax({
        //    type: "POST",
        //    //url: '/Home/LogOut',
        //    url: document.getElementById('hdnURL').value + "Home/ReportTemplate",
        //    //data: { reportName: rowData.reportTitle, reportParameters: inputParam },
        //    data: datas,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "html",
        //    success: function (response) {
        //        //window.open(response, '_blank')
        //        var w = window.open('about:blank');
        //        w.document.open();
        //        w.document.write(response);
        //        w.document.close();
        //    },
        //    error: function (xhr, status, error) {
        //    }
        //}); 

        //if (rowData.reportTitle != null) {
        //    openWindow("Reports/SpoolAreaWiseReport.aspx?reportName=" + rowData.reportTitle + "&param=" + JSON.stringify(rowData.reportParams));
        //}
        
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
        if (data.reportTitle == "RT INSPECTION") {
            openWindow("Reports/Radiography_InspectionReport.aspx");
        }
        if (data.reportTitle == "LPT INSPECTION") {
            openWindow("Reports/Liquid_PenetrantTestingReport.aspx");
        }
        if (data.reportTitle == "INCH DIA SUMMARY CHART") {
            openWindow("Reports/SpoolId_PieChart.aspx");
        }
    });
});



