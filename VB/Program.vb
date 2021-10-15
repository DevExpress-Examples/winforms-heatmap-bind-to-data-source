Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace BindHeatmapToDataSource

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            WindowsFormsSettings.SetDPIAware()
            WindowsFormsSettings.AllowDpiScale = True
            WindowsFormsSettings.AllowAutoScale = DevExpress.Utils.DefaultBoolean.[True]
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call Application.Run(New Form1())
        End Sub
    End Module
End Namespace
