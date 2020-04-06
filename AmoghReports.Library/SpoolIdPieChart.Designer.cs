namespace AmoghReports.Library
{
    partial class SpoolIdPieChart
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.GraphGroup graphGroup1 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.GraphTitle graphTitle1 = new Telerik.Reporting.GraphTitle();
            Telerik.Reporting.NumericalScale numericalScale1 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.CategoryScale categoryScale1 = new Telerik.Reporting.CategoryScale();
            Telerik.Reporting.GraphGroup graphGroup2 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.GraphGroup graphGroup3 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.GraphTitle graphTitle2 = new Telerik.Reporting.GraphTitle();
            Telerik.Reporting.NumericalScale numericalScale2 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.CategoryScale categoryScale2 = new Telerik.Reporting.CategoryScale();
            Telerik.Reporting.GraphGroup graphGroup4 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.GraphGroup graphGroup5 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.GraphTitle graphTitle3 = new Telerik.Reporting.GraphTitle();
            Telerik.Reporting.CategoryScale categoryScale3 = new Telerik.Reporting.CategoryScale();
            Telerik.Reporting.NumericalScale numericalScale3 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.GraphGroup graphGroup6 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.graph1 = new Telerik.Reporting.Graph();
            this.polarCoordinateSystem1 = new Telerik.Reporting.PolarCoordinateSystem();
            this.graphAxis1 = new Telerik.Reporting.GraphAxis();
            this.graphAxis2 = new Telerik.Reporting.GraphAxis();
            this.webServiceDataSource1 = new Telerik.Reporting.WebServiceDataSource();
            this.barSeries1 = new Telerik.Reporting.BarSeries();
            this.graph2 = new Telerik.Reporting.Graph();
            this.polarCoordinateSystem2 = new Telerik.Reporting.PolarCoordinateSystem();
            this.graphAxis3 = new Telerik.Reporting.GraphAxis();
            this.graphAxis4 = new Telerik.Reporting.GraphAxis();
            this.barSeries2 = new Telerik.Reporting.BarSeries();
            this.graph3 = new Telerik.Reporting.Graph();
            this.cartesianCoordinateSystem1 = new Telerik.Reporting.CartesianCoordinateSystem();
            this.graphAxis6 = new Telerik.Reporting.GraphAxis();
            this.graphAxis5 = new Telerik.Reporting.GraphAxis();
            this.barSeries3 = new Telerik.Reporting.BarSeries();
            this.barSeries4 = new Telerik.Reporting.BarSeries();
            this.barSeries5 = new Telerik.Reporting.BarSeries();
            this.barSeries6 = new Telerik.Reporting.BarSeries();
            this.barSeries7 = new Telerik.Reporting.BarSeries();
            this.barSeries9 = new Telerik.Reporting.BarSeries();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox2 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.5D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.3D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(26.1D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "INCHDIA SUMMARY CHART";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(16.2D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.graph1,
            this.graph2,
            this.graph3});
            this.detail.Name = "detail";
            // 
            // graph1
            // 
            graphGroup1.Name = "categoryGroup";
            this.graph1.CategoryGroups.Add(graphGroup1);
            this.graph1.CoordinateSystems.Add(this.polarCoordinateSystem1);
            this.graph1.DataSource = this.webServiceDataSource1;
            this.graph1.Filters.Add(new Telerik.Reporting.Filter("= Fields.sg_total", Telerik.Reporting.FilterOperator.GreaterThan, "0"));
            this.graph1.Legend.Style.LineColor = System.Drawing.Color.LightGray;
            this.graph1.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.graph1.Name = "graph1";
            this.graph1.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray;
            this.graph1.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph1.Series.Add(this.barSeries1);
            this.graph1.SeriesGroups.Add(graphGroup2);
            this.graph1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.9D), Telerik.Reporting.Drawing.Unit.Cm(7.4D));
            this.graph1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.graph1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.graph1.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.graph1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.graph1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.graph1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            graphTitle1.Position = Telerik.Reporting.GraphItemPosition.TopCenter;
            graphTitle1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            graphTitle1.Style.LineColor = System.Drawing.Color.LightGray;
            graphTitle1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            graphTitle1.Text = "Total Inch-dia";
            this.graph1.Titles.Add(graphTitle1);
            // 
            // polarCoordinateSystem1
            // 
            this.polarCoordinateSystem1.AngularAxis = this.graphAxis1;
            this.polarCoordinateSystem1.Name = "polarCoordinateSystem1";
            this.polarCoordinateSystem1.RadialAxis = this.graphAxis2;
            // 
            // graphAxis1
            // 
            this.graphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis1.MajorGridLineStyle.Visible = false;
            this.graphAxis1.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis1.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis1.MinorGridLineStyle.Visible = false;
            this.graphAxis1.Name = "graphAxis1";
            this.graphAxis1.Scale = numericalScale1;
            this.graphAxis1.Style.Visible = false;
            // 
            // graphAxis2
            // 
            this.graphAxis2.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MajorGridLineStyle.Visible = false;
            this.graphAxis2.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MinorGridLineStyle.Visible = false;
            this.graphAxis2.Name = "graphAxis2";
            categoryScale1.PositionMode = Telerik.Reporting.AxisPositionMode.OnTicks;
            categoryScale1.SpacingSlotCount = 0D;
            this.graphAxis2.Scale = categoryScale1;
            this.graphAxis2.Style.Visible = false;
            // 
            // webServiceDataSource1
            // 
            this.webServiceDataSource1.Name = "webServiceDataSource1";
            this.webServiceDataSource1.Parameters.AddRange(new Telerik.Reporting.WebServiceParameter[] {
            new Telerik.Reporting.WebServiceParameter("ProjId", Telerik.Reporting.WebServiceParameterType.Query, "= Parameters.ProjId.Value")});
            this.webServiceDataSource1.ServiceUrl = "https://amoghapps.com/AmoghReportsService/ReportSpoolIdService.asmx/GetMaterialWi" +
    "se";
            // 
            // barSeries1
            // 
            this.barSeries1.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Stacked100;
            this.barSeries1.CategoryGroup = graphGroup1;
            this.barSeries1.CoordinateSystem = this.polarCoordinateSystem1;
            this.barSeries1.DataPointLabel = "= Sum(Fields.sg_total)";
            this.barSeries1.DataPointLabelConnectorStyle.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.barSeries1.DataPointLabelConnectorStyle.Padding.Top = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.barSeries1.DataPointLabelConnectorStyle.Visible = false;
            this.barSeries1.DataPointLabelFormat = "{0:N0}";
            this.barSeries1.DataPointLabelOffset = Telerik.Reporting.Drawing.Unit.Mm(1D);
            this.barSeries1.DataPointLabelStyle.Visible = true;
            this.barSeries1.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.barSeries1.DataPointStyle.Visible = true;
            this.barSeries1.LegendItem.Value = "= Fields.mat_type";
            this.barSeries1.Name = "barSeries1";
            graphGroup2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.mat_type"));
            graphGroup2.Name = "mat_typeGroup";
            graphGroup2.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.mat_type", Telerik.Reporting.SortDirection.Asc));
            this.barSeries1.SeriesGroup = graphGroup2;
            this.barSeries1.ToolTip.Text = "= Format(\'{0:P}\', Sum(Fields.sg_shop) / CDbl(Exec(\'graph1\', Sum(Fields.sg_shop)))" +
    ")";
            this.barSeries1.ToolTip.Title = "= Fields.mat_type";
            this.barSeries1.X = "= Sum(Fields.sg_shop)";
            // 
            // graph2
            // 
            graphGroup3.Name = "categoryGroup1";
            this.graph2.CategoryGroups.Add(graphGroup3);
            this.graph2.CoordinateSystems.Add(this.polarCoordinateSystem2);
            this.graph2.DataSource = this.webServiceDataSource1;
            this.graph2.Filters.Add(new Telerik.Reporting.Filter("= Fields.mat_avl", Telerik.Reporting.FilterOperator.GreaterThan, "0"));
            this.graph2.Legend.Style.LineColor = System.Drawing.Color.LightGray;
            this.graph2.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.2D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.graph2.Name = "graph2";
            this.graph2.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray;
            this.graph2.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph2.Series.Add(this.barSeries2);
            this.graph2.SeriesGroups.Add(graphGroup4);
            this.graph2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.9D), Telerik.Reporting.Drawing.Unit.Cm(7.4D));
            this.graph2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.graph2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.graph2.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.graph2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.graph2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.graph2.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            graphTitle2.Position = Telerik.Reporting.GraphItemPosition.TopCenter;
            graphTitle2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            graphTitle2.Style.LineColor = System.Drawing.Color.LightGray;
            graphTitle2.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            graphTitle2.Text = "Material Available (Shop)";
            this.graph2.Titles.Add(graphTitle2);
            // 
            // polarCoordinateSystem2
            // 
            this.polarCoordinateSystem2.AngularAxis = this.graphAxis3;
            this.polarCoordinateSystem2.Name = "polarCoordinateSystem2";
            this.polarCoordinateSystem2.RadialAxis = this.graphAxis4;
            // 
            // graphAxis3
            // 
            this.graphAxis3.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis3.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MajorGridLineStyle.Visible = false;
            this.graphAxis3.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis3.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MinorGridLineStyle.Visible = false;
            this.graphAxis3.Name = "graphAxis3";
            this.graphAxis3.Scale = numericalScale2;
            this.graphAxis3.Style.Visible = false;
            // 
            // graphAxis4
            // 
            this.graphAxis4.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis4.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MajorGridLineStyle.Visible = false;
            this.graphAxis4.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis4.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MinorGridLineStyle.Visible = false;
            this.graphAxis4.Name = "graphAxis4";
            categoryScale2.PositionMode = Telerik.Reporting.AxisPositionMode.OnTicks;
            categoryScale2.SpacingSlotCount = 0D;
            this.graphAxis4.Scale = categoryScale2;
            this.graphAxis4.Style.Visible = false;
            // 
            // barSeries2
            // 
            this.barSeries2.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Stacked100;
            this.barSeries2.CategoryGroup = graphGroup3;
            this.barSeries2.CoordinateSystem = this.polarCoordinateSystem2;
            this.barSeries2.DataPointLabel = "= Sum(Fields.mat_avl)";
            this.barSeries2.DataPointLabelConnectorStyle.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.barSeries2.DataPointLabelConnectorStyle.Padding.Top = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.barSeries2.DataPointLabelConnectorStyle.Visible = false;
            this.barSeries2.DataPointLabelFormat = "{0:N0}";
            this.barSeries2.DataPointLabelOffset = Telerik.Reporting.Drawing.Unit.Mm(1D);
            this.barSeries2.DataPointLabelStyle.Visible = true;
            this.barSeries2.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.barSeries2.DataPointStyle.Visible = true;
            this.barSeries2.LegendItem.Value = "= Fields.mat_type";
            this.barSeries2.Name = "barSeries2";
            graphGroup4.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.mat_type"));
            graphGroup4.Name = "mat_typeGroup1";
            graphGroup4.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.mat_type", Telerik.Reporting.SortDirection.Asc));
            this.barSeries2.SeriesGroup = graphGroup4;
            this.barSeries2.ToolTip.Text = "= Format(\'{0:P}\', Sum(Fields.mat_avl) / CDbl(Exec(\'graph2\', Sum(Fields.mat_avl)))" +
    ")";
            this.barSeries2.ToolTip.Title = "= Fields.mat_type";
            this.barSeries2.X = "= Sum(Fields.mat_avl)";
            // 
            // graph3
            // 
            graphGroup5.Name = "categoryGroup2";
            this.graph3.CategoryGroups.Add(graphGroup5);
            this.graph3.CoordinateSystems.Add(this.cartesianCoordinateSystem1);
            this.graph3.DataSource = this.webServiceDataSource1;
            this.graph3.Legend.Style.LineColor = System.Drawing.Color.LightGray;
            this.graph3.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(7.7D));
            this.graph3.Name = "graph3";
            this.graph3.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray;
            this.graph3.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph3.Series.Add(this.barSeries3);
            this.graph3.Series.Add(this.barSeries4);
            this.graph3.Series.Add(this.barSeries5);
            this.graph3.Series.Add(this.barSeries6);
            this.graph3.Series.Add(this.barSeries7);
            this.graph3.Series.Add(this.barSeries9);
            this.graph3.SeriesGroups.Add(graphGroup6);
            this.graph3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(26.1D), Telerik.Reporting.Drawing.Unit.Cm(8.5D));
            this.graph3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.graph3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.graph3.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.graph3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.graph3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.graph3.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            graphTitle3.Position = Telerik.Reporting.GraphItemPosition.TopCenter;
            graphTitle3.Style.LineColor = System.Drawing.Color.LightGray;
            graphTitle3.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            graphTitle3.Style.Visible = false;
            graphTitle3.Text = "graph3";
            this.graph3.Titles.Add(graphTitle3);
            // 
            // cartesianCoordinateSystem1
            // 
            this.cartesianCoordinateSystem1.Name = "cartesianCoordinateSystem1";
            this.cartesianCoordinateSystem1.XAxis = this.graphAxis6;
            this.cartesianCoordinateSystem1.YAxis = this.graphAxis5;
            // 
            // graphAxis6
            // 
            this.graphAxis6.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis6.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis6.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis6.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis6.MinorGridLineStyle.Visible = false;
            this.graphAxis6.Name = "graphAxis6";
            this.graphAxis6.Scale = categoryScale3;
            this.graphAxis6.Style.Visible = false;
            // 
            // graphAxis5
            // 
            this.graphAxis5.LabelFormat = "{0:N0}";
            this.graphAxis5.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis5.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis5.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis5.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis5.MinorGridLineStyle.Visible = false;
            this.graphAxis5.Name = "graphAxis5";
            this.graphAxis5.Scale = numericalScale3;
            // 
            // barSeries3
            // 
            this.barSeries3.CategoryGroup = graphGroup5;
            this.barSeries3.CoordinateSystem = this.cartesianCoordinateSystem1;
            this.barSeries3.DataPointLabel = "= Sum(Fields.sg_shop)";
            this.barSeries3.DataPointLabelFormat = "{0:N0}";
            this.barSeries3.DataPointLabelStyle.Visible = true;
            this.barSeries3.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.barSeries3.DataPointStyle.Visible = true;
            this.barSeries3.LegendItem.Value = "Total Shop ID";
            this.barSeries3.Name = "barSeries3";
            graphGroup6.Name = "seriesGroup";
            this.barSeries3.SeriesGroup = graphGroup6;
            this.barSeries3.ToolTip.Text = "= Sum(Fields.sg_shop)";
            this.barSeries3.ToolTip.Title = "SG Shop";
            this.barSeries3.Y = "= Sum(Fields.sg_shop)";
            // 
            // barSeries4
            // 
            this.barSeries4.CategoryGroup = graphGroup5;
            this.barSeries4.CoordinateSystem = this.cartesianCoordinateSystem1;
            this.barSeries4.DataPointLabel = "= Sum(Fields.sg_field)";
            this.barSeries4.DataPointLabelFormat = "{0:N0}";
            this.barSeries4.DataPointLabelStyle.Visible = true;
            this.barSeries4.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.barSeries4.DataPointStyle.Visible = true;
            this.barSeries4.LegendItem.Value = "Total Field ID";
            this.barSeries4.Name = "barSeries4";
            this.barSeries4.SeriesGroup = graphGroup6;
            this.barSeries4.ToolTip.Text = "= Sum(Fields.sg_field)";
            this.barSeries4.ToolTip.Title = "\'Sum(sg_field)\'";
            this.barSeries4.Y = "= Sum(Fields.sg_field)";
            // 
            // barSeries5
            // 
            this.barSeries5.CategoryGroup = graphGroup5;
            this.barSeries5.CoordinateSystem = this.cartesianCoordinateSystem1;
            this.barSeries5.DataPointLabel = "=Sum(Fields.mat_avl)";
            this.barSeries5.DataPointLabelFormat = "{0:N0}";
            this.barSeries5.DataPointLabelStyle.Visible = true;
            this.barSeries5.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.barSeries5.DataPointStyle.Visible = true;
            this.barSeries5.LegendItem.Value = "Material Avl.";
            this.barSeries5.Name = "barSeries5";
            this.barSeries5.SeriesGroup = graphGroup6;
            this.barSeries5.ToolTip.Text = "= Sum(Fields.mat_avl)";
            this.barSeries5.ToolTip.Title = "\'Sum(mat_avl)\'";
            this.barSeries5.Y = "= Sum(Fields.mat_avl)";
            // 
            // barSeries6
            // 
            this.barSeries6.CategoryGroup = graphGroup5;
            this.barSeries6.CoordinateSystem = this.cartesianCoordinateSystem1;
            this.barSeries6.DataPointLabel = "= Sum(Fields.jc_issued)";
            this.barSeries6.DataPointLabelFormat = "{0:N0}";
            this.barSeries6.DataPointLabelStyle.Visible = true;
            this.barSeries6.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.barSeries6.DataPointStyle.Visible = true;
            this.barSeries6.LegendItem.Value = "Jobcard Issued";
            this.barSeries6.Name = "barSeries6";
            this.barSeries6.SeriesGroup = graphGroup6;
            this.barSeries6.ToolTip.Text = "= Sum(Fields.jc_issued)";
            this.barSeries6.ToolTip.Title = "\'Sum(jc_issued)\'";
            this.barSeries6.Y = "= Sum(Fields.jc_issued)";
            // 
            // barSeries7
            // 
            this.barSeries7.CategoryGroup = graphGroup5;
            this.barSeries7.CoordinateSystem = this.cartesianCoordinateSystem1;
            this.barSeries7.DataPointLabel = "= Sum(Fields.shop_welding)";
            this.barSeries7.DataPointLabelFormat = "{0:N0}";
            this.barSeries7.DataPointLabelStyle.Visible = true;
            this.barSeries7.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.barSeries7.DataPointStyle.Visible = true;
            this.barSeries7.LegendItem.Value = "Shop Welding";
            this.barSeries7.Name = "barSeries7";
            this.barSeries7.SeriesGroup = graphGroup6;
            this.barSeries7.ToolTip.Text = "= Sum(Fields.shop_welding)";
            this.barSeries7.ToolTip.Title = "\'Sum(shop_welding)\'";
            this.barSeries7.Y = "= Sum(Fields.shop_welding)";
            // 
            // barSeries9
            // 
            this.barSeries9.CategoryGroup = graphGroup5;
            this.barSeries9.CoordinateSystem = this.cartesianCoordinateSystem1;
            this.barSeries9.DataPointLabel = "= Sum(Fields.painted)";
            this.barSeries9.DataPointLabelFormat = "{0:N0}";
            this.barSeries9.DataPointLabelStyle.Visible = true;
            this.barSeries9.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.barSeries9.DataPointStyle.Visible = true;
            this.barSeries9.LegendItem.Value = "Painted";
            this.barSeries9.Name = "barSeries9";
            this.barSeries9.SeriesGroup = graphGroup6;
            this.barSeries9.ToolTip.Text = "= Sum(Fields.painted)";
            this.barSeries9.ToolTip.Title = "\'Sum(painted)\'";
            this.barSeries9.Y = "= Sum(Fields.painted)";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(22.5D), Telerik.Reporting.Drawing.Unit.Cm(0.2D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.6D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.Value = "Page: {PageNumber}";
            // 
            // SpoolIdPieChart
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "SpoolIdPieChart";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowBlank = false;
            reportParameter1.Name = "ProjId";
            reportParameter1.Text = "ProjId";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "1";
            this.ReportParameters.Add(reportParameter1);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(26.1D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.Graph graph1;
        private Telerik.Reporting.PolarCoordinateSystem polarCoordinateSystem1;
        private Telerik.Reporting.GraphAxis graphAxis1;
        private Telerik.Reporting.GraphAxis graphAxis2;
        private Telerik.Reporting.WebServiceDataSource webServiceDataSource1;
        private Telerik.Reporting.BarSeries barSeries1;
        private Telerik.Reporting.Graph graph2;
        private Telerik.Reporting.PolarCoordinateSystem polarCoordinateSystem2;
        private Telerik.Reporting.GraphAxis graphAxis3;
        private Telerik.Reporting.GraphAxis graphAxis4;
        private Telerik.Reporting.BarSeries barSeries2;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.Graph graph3;
        private Telerik.Reporting.CartesianCoordinateSystem cartesianCoordinateSystem1;
        private Telerik.Reporting.GraphAxis graphAxis6;
        private Telerik.Reporting.GraphAxis graphAxis5;
        private Telerik.Reporting.BarSeries barSeries3;
        private Telerik.Reporting.BarSeries barSeries4;
        private Telerik.Reporting.BarSeries barSeries5;
        private Telerik.Reporting.BarSeries barSeries6;
        private Telerik.Reporting.BarSeries barSeries7;
        private Telerik.Reporting.BarSeries barSeries9;
        private Telerik.Reporting.TextBox textBox2;
    }
}