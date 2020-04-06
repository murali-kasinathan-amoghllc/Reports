namespace AmoghReports.Library
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for IsometricSummaryMatWiselReport.
    /// </summary>
    public partial class DailyWelding_Joint_Field_Report : Telerik.Reporting.Report
    {
        public DailyWelding_Joint_Field_Report()
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
            if (imageLocation == "1")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\App_LOGO1.png";
            else
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\Duqm_Logo.png";

            return Image.FromFile(absoluteLocation);
        }

        public static Image LoadImage1(string imageLocation)
        {
            string absoluteLocation = string.Empty;
            if (imageLocation == "1")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\APP_LOGO2.png";
            else
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\APP-LOGO4.png";

            return Image.FromFile(absoluteLocation);
        }

        public static string LoadProjectTitle(string projId)
        {
            string title = string.Empty;
            if (projId == "1")
                title = "GC 32 IN SOUTH EAST KUWAIT (SEK)";
            else
                title = "DUQM PROJECT";
            return title;
        }
    }
}