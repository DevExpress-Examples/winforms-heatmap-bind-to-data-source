Imports System.Data
Imports DevExpress.Drawing
Imports DevExpress.XtraCharts
Imports DevExpress.XtraCharts.Heatmap

Namespace BindHeatmapToDataSource

    Public Partial Class Form1
        Inherits System.Windows.Forms.Form

        Public Sub New()
            Me.InitializeComponent()
            Dim data As System.Data.DataTable = BindHeatmapToDataSource.Form1.CreateDataSet("BalanceOfTrade.xml")
            Me.heatmap.DataAdapter = New HeatmapDataSourceAdapter() With {.XArgumentDataMember = "Country", .YArgumentDataMember = "Product", .ColorDataMember = "Value", .DataSource = data}
            Dim palette As Palette = New Palette("Custom") From {System.Drawing.Color.Red, System.Drawing.Color.White, System.Drawing.Color.Green}
            Dim colorProvider As HeatmapRangeColorProvider = New HeatmapRangeColorProvider() With {.Palette = palette, .ApproximateColors = True, .LegendItemPattern = "{V1} .. {V2}"}
            Me.heatmap.ColorProvider = colorProvider
            colorProvider.RangeStops.Add(New HeatmapRangeStop(0, HeatmapRangeStopType.Percentage))
            colorProvider.RangeStops.Add(New HeatmapRangeStop(-10))
            colorProvider.RangeStops.Add(New HeatmapRangeStop(-2.5))
            colorProvider.RangeStops.Add(New HeatmapRangeStop(0))
            colorProvider.RangeStops.Add(New HeatmapRangeStop(2.5))
            colorProvider.RangeStops.Add(New HeatmapRangeStop(10))
            colorProvider.RangeStops.Add(New HeatmapRangeStop(1, HeatmapRangeStopType.Percentage))
            Me.heatmap.Titles.Add(New HeatmapTitle With {.Text = "Balance of Trade"})
            Me.heatmap.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
            Me.heatmap.Label.Visible = True
            Me.heatmap.Label.DXFont = New DXFont("SegoeUI", 6)
            Me.heatmap.Label.Pattern = "{V}"
            Me.heatmap.Label.Color = System.Drawing.Color.Black
            Me.heatmap.ToolTipEnabled = True
            Me.heatmap.ToolTipController = New DevExpress.Utils.ToolTipController With {.AllowHtmlText = True, .ToolTipLocation = DevExpress.Utils.ToolTipLocation.RightTop, .ShowBeak = True}
            Me.heatmap.ToolTipTextPattern = "X: <b>{X}</b>" & Global.Microsoft.VisualBasic.Constants.vbLf & "Y: <b>{Y}</b>"
            Me.heatmap.EnableAxisXScrolling = True
            Me.heatmap.EnableAxisYScrolling = True
            Me.heatmap.EnableAxisXZooming = True
            Me.heatmap.EnableAxisYZooming = True
            Me.heatmap.AxisX.Title.Text = "Region"
            Me.heatmap.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.[True]
            Me.heatmap.AxisX.Label.Staggered = False
            Me.heatmap.AxisX.Label.ResolveOverlappingOptions.AllowStagger = False
            Me.heatmap.AxisX.Label.ResolveOverlappingOptions.AllowRotate = False
            Me.heatmap.AxisX.Label.ResolveOverlappingOptions.AllowHide = False
            Me.heatmap.AxisY.Title.Text = "Product Category"
            Me.heatmap.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        End Sub

        Public Shared Function CreateDataSet(ByVal xmlFileName As String) As DataTable
            Dim filePath As String = BindHeatmapToDataSource.Form1.GetRelativePath(xmlFileName)
            If Not String.IsNullOrWhiteSpace(filePath) Then
                Dim dataSet As System.Data.DataSet = New System.Data.DataSet()
                dataSet.ReadXml(filePath)
                If dataSet.Tables.Count > 0 Then Return dataSet.Tables(0)
            End If

            Return Nothing
        End Function

        Public Shared Function GetRelativePath(ByVal name As String) As String
            name = "Data\" & name
            Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(System.Windows.Forms.Application.StartupPath)
            For i As Integer = 0 To 10
                Dim filePath As String = System.IO.Path.Combine(dir.FullName, name)
                If System.IO.File.Exists(filePath) Then Return filePath
                dir = System.IO.Directory.GetParent(dir.FullName)
            Next

            Return String.Empty
        End Function
    End Class
End Namespace
