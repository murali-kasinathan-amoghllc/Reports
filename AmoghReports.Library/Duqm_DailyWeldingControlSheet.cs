namespace AmoghReports.Library
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for SpoolIdAreaWise.
    /// </summary>
    public partial class Duqm_DailyWeldingControlSheet : Telerik.Reporting.Report
    {
        public Duqm_DailyWeldingControlSheet()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static Image LoadImage(string imageLocation)
        {
            string absoluteLocation = string.Empty;
            if (imageLocation == "4")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\adnoc_logo.png";
            if (imageLocation == "2")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\Duqm_Logo.png";
            if (imageLocation == "1")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\App_LOGO1.png";

            return Image.FromFile(absoluteLocation);
        }

        public static Image LoadImage1(string imageLocation)
        {
            string absoluteLocation = string.Empty;
            if (imageLocation == "4")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\cpecclogo.png";
            if (imageLocation == "2")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\APP-LOGO4.png";
            if (imageLocation == "1")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\APP_LOGO2.png";

            return Image.FromFile(absoluteLocation);
        }

        public static string LoadProjectTitle(string projId)
        {
            string title = string.Empty;
            if (projId == "2")
                title = "INSPECTION & TEST RECORD - WELDING \n ITR No: W-0103X \n DAILY WELDING CONTROL SHEET (SHOP/FIELD) \n SO0267-CV0R-QCR-038-Rev-01 \n W-0103X";
            if (projId == "4")
                title = "BAB INTEGRATED FACILITIES PROJECT \n Job No. P11570 \n INSPECTION & TEST RECORD - WELDING \n DAILY WELDING CONTROL SHEET(SHOP/ FIELD)";
            return title;
        }

        public static string LoadProjectCode(string projId)
        {
            string code = string.Empty;
            if (projId == "1")
                code = "PROJECT NO.: JI-2035";
            if (projId == "2")
                code = "PROJECT NO.: JI-2037";
            if (projId == "4")
                code = "PROJECT NO.: P11570";
            return code;
        }
    }
}