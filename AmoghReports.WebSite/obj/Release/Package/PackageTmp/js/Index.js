$(document).ready(function () {
    $('#myTable tbody tr').click(function () {
        $(this).addClass('bg-success').siblings().removeClass('bg-success');
    });

    var getHighlightRow = function () {
        return $('table > tbody > tr.bg-success');
    }

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
                window.location = document.getElementById('hdnURL').value + "Home/Error"; //redirect to Error url
            }
        });
    });

    $("#myTable").on('click', function () {
        var projectName;
        var rows = getHighlightRow();
        projectName = rows[0].cells[0].innerText;
        if (projectName == undefined) { projectName = 1; }
        sessionStorage.setItem("reportID", projectName);
        window.location = document.getElementById('hdnURL').value + "Home/ReportsList?ProjId=" + projectName;
    });

    //$('#myReports tbody').on('click', 'tr', function () {
    //    var table = $('#myReports').DataTable();
    //    var data = table.row(this).data();
    //    window.open('../../Reports/WeldingSummaryReport.aspx', '_blank');
    //    //window.open("/Home/WeldingSummaryReport", 'WeldingReport', 'height=500,width=700');
    //});


});