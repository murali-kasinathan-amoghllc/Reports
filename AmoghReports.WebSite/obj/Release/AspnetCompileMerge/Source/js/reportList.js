$(document).ready(function () {


    $("#selRptCat").change(function () {
        var catId = this.value;

        $.ajax({
            url: document.getElementById('hdnURL').value + "Home/GetReportsList",
            dataType: "json",
            type: "POST",
            cache: false,
            data: { catId: catId },
            success: function (data) {
                if (data != null) {
                    populateDataTable(data);
                }
            },
            error: function (xhr) {
                //alert(xhr.responseText);
            }
        });
       
    });

    function populateDataTable(data) {
        // clear the table before populating it with more data
        $("#myReports").DataTable().clear();
        var length = Object.keys(data.data).length;
        for (var i = 0; i < length + 1; i++) {
            var results = data.data[i];
            $('#myReports').dataTable().fnAddData(results);
        }
    }

    //$("#btnLogOut").bind("click", function () {
    //    $.ajax({
    //        type: "POST",
    //        //url: '/Home/LogOut',
    //        url: document.getElementById('hdnURL').value + "Home/LogOut",
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "html",
    //        success: function (response) {

    //        },
    //        error: function (xhr, status, error) {
    //        }
    //    });
    //});
    //var selectedMenu;

    //$("#accordionSidebar li a").click(function (e) {
    //    e.preventDefault();
    //    selectedMenu = $(this).find('span').html();
    //});

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
            { "data": "reportId", "autoWidth": true, "className": "rowsName",},
            { "data": "reportTitle", "autoWidth": true, "className": "rowsName" }
            //{ "data": "ServiceUrl", "autoWidth": true,  }
        ]
    });

    $("#btnBack").on("click", function (e) {
        e.preventDefault();
        window.history.back();
    });

    function openWindow(url) {
        window.open(document.getElementById('hdnURL').value + url, '_blank');
    }

    $('#myReports tbody').on('click', 'tr', function () {
        var table = $('#myReports').DataTable();
        var data = table.row(this).data();
        //var reportItemModel = new Object();
        //var reportItemParam = [];
        //for (var key in datas.reportParams) {
        //    reportItemParam.push({
        //        "reportId": datas.reportParams[key].reportId,
        //        "paramName": datas.reportParams[key].paramName,
        //        "paramText": datas.reportParams[key].paramText,
        //        "paramTypeId": datas.reportParams[key].paramTypeId,
        //        "paramTypeName": datas.reportParams[key].paramTypeName
        //    });
        //}
        //reportItemModel.reportParams = reportItemParam;
        //reportItemModel.reportTitle = datas.reportTitle;
        //reportItemModel.reportId = datas.reportId;
        //reportItemModel.isChart = datas.isChart;
        //reportItemModel.categoryID = datas.categoryID;
        //reportItemModel.forProjId = datas.forProjId;
        //reportItemModel.ServiceUrl = datas.ServiceUrl;
        //var data = JSON.stringify({ "reportItemModel": reportItemModel});
        //$.ajax({
        //    type: "POST",
        //    url: document.getElementById('hdnURL').value + "Home/ReportTemplates",
        //    data: data,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "html",
        //    success: function (response) {
        //        window.location = document.getElementById('hdnURL').value + "Home/ReportTemplate"; 
        //        //window.open(response, '_blank')
        //        //var w = window.open('about:blank');
        //        //w.document.open();
        //        //w.document.write(response);
        //        //w.document.close();
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
        if (data.reportTitle == "WELDING SUMMARY") {
            openWindow("Reports/WeldingSummaryReport.aspx");
        }
        if (data.reportTitle == "RT SUMMARY - MATERIAL WISE") {
            openWindow("Reports/RT_SummaryMaterialWiseReport.aspx");
        }
        if (data.reportTitle == "SPOOL CLEARANCE SHEET") {
            openWindow("Reports/SpoolClearanceAndReleaseReport.aspx");
        }
        if (data.reportTitle == "RT INSPECTION") {
            openWindow("Reports/Radiography_InspectionReport.aspx");
        }
        if (data.reportTitle == "LPT INSPECTION") {
            openWindow("Reports/Liquid_PenetrantTestingReport.aspx");
        }
        if (data.reportTitle == "PT INSPECTION") {
            openWindow("Reports/Magnetic_ParticleTestingReport.aspx");
        }
        if (data.reportTitle == "PWHT INSPECTION") {
            openWindow("Reports/Post_WeldHeatTreatmentReport.aspx");
        }
        if (data.reportTitle == "RT STATUS - CLASS WISE") {
            openWindow("Reports/NDE_StatusReport.aspx");
        }
        if (data.reportTitle == "PWHT STATUS - CLASS WISE") {
            openWindow("Reports/NDE_StatusReport.aspx");
        }
        if (data.reportTitle == "PMI STATUS - CLASS WISE") {
            openWindow("Reports/NDE_StatusReport.aspx");
        }
        if (data.reportTitle == "UT STATUS - CLASS WISE") {
            openWindow("Reports/NDE_StatusReport.aspx");
        }
        if (data.reportTitle == "HT STATUS - CLASS WISE") {
            openWindow("Reports/NDE_StatusReport.aspx");
        }
        if (data.reportTitle == "FT STATUS - CLASS WISE") {
            openWindow("Reports/NDE_StatusReport.aspx");
        }
        if (data.reportTitle == "SPOOLGEN PROGRESS - LOT WISE") {
            openWindow("Reports/SpoolGenProgressLotWiseReport.aspx");
        }
        if (data.reportTitle == "SPOOLGEN PROGRESS - EXCLUDE 3 REV") {
            openWindow("Reports/SpoolGenProgressExclude3RevLotWiseReport.aspx");
        }
        if (data.reportTitle == "INCH DIA SUMMARY CHART") {
            openWindow("Reports/SpoolId_PieChart.aspx");
            //openWindow("Reports/NDE_StatusReport.aspx");
        }
        if (data.reportTitle == "WELDER PERFORMANCE") {
            openWindow("Reports/WelderPerformanceReport.aspx");
        }
        if (data.reportTitle == "WELDER PERFORMANCE LENGTH WISE") {
            openWindow("Reports/WelderPerformanceReport.aspx");
        }
        if (data.reportTitle == "WELDER PERFORMANCE MAT WISE") {
            openWindow("Reports/WelderPerformanceReport.aspx");
        }
        if (data.reportTitle == "WELDER PERFORMANCE RT PERCENT") {
            openWindow("Reports/WelderPerformanceReport.aspx");
        }
        if (data.reportTitle == "WELDER PERFORMANCE SIZE") {
            openWindow("Reports/WelderPerformanceReport.aspx");
        }
        if (data.reportTitle == "WELDER PERFORMANCE MONTHLY") {
            openWindow("Reports/WelderPerformanceReport.aspx");
        }
        if (data.reportTitle == "WELDER PERFORMANCE CLASS WISE") {
            openWindow("Reports/WelderPerformanceReport.aspx");
        }
        if (data.reportTitle == "WELDER PERFORMANCE CLASS/LENGHT WISE") {
            openWindow("Reports/WelderPerformanceReport.aspx");
        }
        if (data.reportTitle == "RFI INSPECTION") {
            openWindow("Reports/RFITransmittalForm.aspx");
        }
    });
});



