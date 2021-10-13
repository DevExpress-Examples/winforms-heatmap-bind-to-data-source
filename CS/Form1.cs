using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Heatmap;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BindHeatmapToDataSource {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            DataTable data = CreateDataSet("BalanceOfTrade.xml");

            heatmap.DataAdapter = new HeatmapDataSourceAdapter() {
                XArgumentDataMember = "Country",
                YArgumentDataMember = "Product",
                ColorDataMember = "Value",
                DataSource = data
            };

            Palette palette = new Palette("Custom") { Color.Red, Color.White, Color.Green };

            HeatmapRangeColorProvider colorProvider = new HeatmapRangeColorProvider() {
                Palette = palette,
                ApproximateColors = true,
                LegendItemPattern = "{V1} .. {V2}"
            };

            heatmap.ColorProvider = colorProvider;

            colorProvider.RangeStops.Add(new HeatmapRangeStop(0, HeatmapRangeStopType.Percentage));
            colorProvider.RangeStops.Add(new HeatmapRangeStop(-10));
            colorProvider.RangeStops.Add(new HeatmapRangeStop(-2.5));
            colorProvider.RangeStops.Add(new HeatmapRangeStop(0));
            colorProvider.RangeStops.Add(new HeatmapRangeStop(2.5));
            colorProvider.RangeStops.Add(new HeatmapRangeStop(10));
            colorProvider.RangeStops.Add(new HeatmapRangeStop(1, HeatmapRangeStopType.Percentage));


            heatmap.Titles.Add(new HeatmapTitle { Text = "Balance of Trade" });

            heatmap.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            heatmap.Label.Visible = true;
            heatmap.Label.Font = new Font("SegoeUI", 6);
            heatmap.Label.Pattern = "{V}";
            heatmap.Label.Color = Color.Black;

            heatmap.ToolTipEnabled = true;
            heatmap.ToolTipController = new DevExpress.Utils.ToolTipController {
                AllowHtmlText = true,
                ToolTipLocation = DevExpress.Utils.ToolTipLocation.RightTop,
                ShowBeak = true
            };
            heatmap.ToolTipTextPattern = "X: <b>{X}</b>\nY: <b>{Y}</b>";

            heatmap.EnableAxisXScrolling = true;
            heatmap.EnableAxisYScrolling = true;
            heatmap.EnableAxisXZooming = true;
            heatmap.EnableAxisYZooming = true;

            heatmap.AxisX.Title.Text = "Region";
            heatmap.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            heatmap.AxisX.Label.Staggered = false;
            heatmap.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            heatmap.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
            heatmap.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            heatmap.AxisY.Title.Text = "Product Category";
            heatmap.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
        }

        public static DataTable CreateDataSet(string xmlFileName) {
            string filePath = GetRelativePath(xmlFileName);
            if (!string.IsNullOrWhiteSpace(filePath)) {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(filePath);
                if (dataSet.Tables.Count > 0)
                    return dataSet.Tables[0];
            }
            return null;
        }
        public static string GetRelativePath(string name) {
            name = "Data\\" + name;
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            for (int i = 0; i <= 10; i++) {
                string filePath = Path.Combine(dir.FullName, name);
                if (File.Exists(filePath))
                    return filePath;
                dir = Directory.GetParent(dir.FullName);
            }
            return string.Empty;
        }
    }
}
