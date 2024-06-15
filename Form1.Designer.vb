<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TextAnnotation1 As DevExpress.XtraCharts.TextAnnotation = New DevExpress.XtraCharts.TextAnnotation()
        Dim ChartAnchorPoint1 As DevExpress.XtraCharts.ChartAnchorPoint = New DevExpress.XtraCharts.ChartAnchorPoint()
        Dim FreePosition1 As DevExpress.XtraCharts.FreePosition = New DevExpress.XtraCharts.FreePosition()
        Dim TextAnnotation2 As DevExpress.XtraCharts.TextAnnotation = New DevExpress.XtraCharts.TextAnnotation()
        Dim SeriesPointAnchorPoint1 As DevExpress.XtraCharts.SeriesPointAnchorPoint = New DevExpress.XtraCharts.SeriesPointAnchorPoint()
        Dim RelativePosition1 As DevExpress.XtraCharts.RelativePosition = New DevExpress.XtraCharts.RelativePosition()
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SeriesPoint1 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(1.0R, New Object() {CType(10.0R, Object)})
        Dim SeriesPoint2 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(2.0R, New Object() {CType(20.0R, Object)})
        Dim SeriesPoint3 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(3.0R, New Object() {CType(30.0R, Object)})
        Dim SeriesPoint4 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(4.0R, New Object() {CType(40.0R, Object)})
        Dim SplineSeriesView1 As DevExpress.XtraCharts.SplineSeriesView = New DevExpress.XtraCharts.SplineSeriesView()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SeriesPoint5 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(1.0R, New Object() {CType(15.0R, Object)})
        Dim SeriesPoint6 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(2.0R, New Object() {CType(25.0R, Object)})
        Dim SeriesPoint7 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(3.0R, New Object() {CType(35.0R, Object)})
        Dim SeriesPoint8 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(4.0R, New Object() {CType(45.0R, Object)})
        Dim SplineSeriesView2 As DevExpress.XtraCharts.SplineSeriesView = New DevExpress.XtraCharts.SplineSeriesView()
        Dim Series3 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SeriesPoint9 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(0R, New Object() {CType(22.0R, Object)})
        Dim SeriesPoint10 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(5.0R, New Object() {CType(22.0R, Object)})
        Dim SplineSeriesView3 As DevExpress.XtraCharts.SplineSeriesView = New DevExpress.XtraCharts.SplineSeriesView()
        Dim Series4 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SeriesPoint11 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(2.2R, New Object() {CType(0R, Object)})
        Dim SeriesPoint12 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(2.2R, New Object() {CType(21.0R, Object)}, 1)
        Dim SplineSeriesView4 As DevExpress.XtraCharts.SplineSeriesView = New DevExpress.XtraCharts.SplineSeriesView()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(TextAnnotation1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(TextAnnotation2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SeriesPointAnchorPoint1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SplineSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SplineSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SplineSeriesView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SplineSeriesView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChartControl1
        '
        ChartAnchorPoint1.Y = 43
        TextAnnotation1.AnchorPoint = ChartAnchorPoint1
        TextAnnotation1.AutoHeight = True
        TextAnnotation1.AutoWidth = True
        TextAnnotation1.Name = "Text Annotation 1"
        FreePosition1.InnerIndents.Left = 115
        FreePosition1.InnerIndents.Top = 25
        TextAnnotation1.ShapePosition = FreePosition1
        SeriesPointAnchorPoint1.SeriesID = 3
        SeriesPointAnchorPoint1.SeriesPointID = 1
        TextAnnotation2.AnchorPoint = SeriesPointAnchorPoint1
        TextAnnotation2.AutoHeight = True
        TextAnnotation2.AutoWidth = True
        TextAnnotation2.Name = "Text Annotation 2"
        TextAnnotation2.RuntimeAnchoring = True
        TextAnnotation2.RuntimeEditing = True
        TextAnnotation2.RuntimeMoving = True
        TextAnnotation2.RuntimeResizing = True
        TextAnnotation2.RuntimeRotation = True
        RelativePosition1.Angle = -7.0041228698105629R
        RelativePosition1.ConnectorLength = 269.25641724498365R
        TextAnnotation2.ShapePosition = RelativePosition1
        TextAnnotation2.Text = "Hi22"
        Me.ChartControl1.AnnotationRepository.AddRange(New DevExpress.XtraCharts.Annotation() {TextAnnotation1, TextAnnotation2})
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControl1.Diagram = XyDiagram1
        Me.ChartControl1.Location = New System.Drawing.Point(36, 89)
        Me.ChartControl1.Name = "ChartControl1"
        Series1.Name = "Series 1"
        Series1.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint1, SeriesPoint2, SeriesPoint3, SeriesPoint4})
        Series1.View = SplineSeriesView1
        Series2.Name = "Series 2"
        Series2.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint5, SeriesPoint6, SeriesPoint7, SeriesPoint8})
        Series2.View = SplineSeriesView2
        Series3.Name = "Series 3"
        Series3.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint9, SeriesPoint10})
        Series3.View = SplineSeriesView3
        Series4.Name = "Series 4"
        Series4.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint11, SeriesPoint12})
        Series4.SeriesID = 3
        Series4.View = SplineSeriesView4
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1, Series2, Series3, Series4}
        Me.ChartControl1.Size = New System.Drawing.Size(668, 294)
        Me.ChartControl1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ChartControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(TextAnnotation1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SeriesPointAnchorPoint1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(TextAnnotation2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SplineSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SplineSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SplineSeriesView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SplineSeriesView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
End Class
