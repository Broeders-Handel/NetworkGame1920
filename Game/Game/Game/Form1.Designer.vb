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
        Me.ButtonPanelBox = New Game.PanelBox()
        Me.SuspendLayout()
        '
        'ButtonPanelBox
        '
        Me.ButtonPanelBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ButtonPanelBox.Location = New System.Drawing.Point(13, 13)
        Me.ButtonPanelBox.Name = "ButtonPanelBox"
        Me.ButtonPanelBox.Size = New System.Drawing.Size(399, 47)
        Me.ButtonPanelBox.TabIndex = 1
        Me.ButtonPanelBox.Used = False
        '
        'SpeelGird1
        '
        Me.SpeelGird1.Location = New System.Drawing.Point(13, 67)
        Me.SpeelGird1.Name = "SpeelGird1"
        Me.SpeelGird1.Size = New System.Drawing.Size(400, 400)
        Me.SpeelGird1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 479)
        Me.Controls.Add(Me.SpeelGird1)
        Me.Controls.Add(Me.ButtonPanelBox)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Speelgrid As SpeelGird
    Friend WithEvents ButtonPanelBox As PanelBox
    Friend WithEvents UserControl1 As SpeelGird
    Friend WithEvents UserControl11 As SpeelGird
    Friend WithEvents SpeelGird1 As SpeelGird
End Class
