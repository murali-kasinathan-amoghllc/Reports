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
    public partial class Duqm_SpoolClearanceAndReleaseReport : Telerik.Reporting.Report
    {
        public Duqm_SpoolClearanceAndReleaseReport()
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
            string absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\App_LOGO1.png";
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
            string absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\App_LOGO1.png";
            if (imageLocation == "4")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\cpecclogo.png";
            if (imageLocation == "2")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\APP-LOGO4.png";
            if (imageLocation == "1")
                absoluteLocation = @"C:\inetpub\wwwroot\AmoghGC32\Images\Company_Logo\APP_LOGO2.png";

            return Image.FromFile(absoluteLocation);
        }
    }
}