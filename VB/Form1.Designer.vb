Namespace BindHeatmapToDataSource

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.heatmap = New DevExpress.XtraCharts.Heatmap.HeatmapControl()
            Me.SuspendLayout()
            ' 
            ' heatmap
            ' 
            Me.heatmap.Dock = System.Windows.Forms.DockStyle.Fill
            Me.heatmap.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
            Me.heatmap.Location = New System.Drawing.Point(0, 0)
            Me.heatmap.Name = "heatmap"
            Me.heatmap.Size = New System.Drawing.Size(1561, 966)
            Me.heatmap.TabIndex = 0
            Me.heatmap.Text = "heatmapControl1"
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(12F, 25F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1561, 966)
            Me.Controls.Add(Me.heatmap)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private heatmap As DevExpress.XtraCharts.Heatmap.HeatmapControl
    End Class
End Namespace
