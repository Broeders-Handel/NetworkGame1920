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
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.SendButton = New System.Windows.Forms.Button()
        Me.MessageTextBox = New System.Windows.Forms.TextBox()
        Me.DisconnectButton = New System.Windows.Forms.Button()
        Me.ChatRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'ConnectButton
        '
        Me.ConnectButton.Location = New System.Drawing.Point(12, 12)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(112, 28)
        Me.ConnectButton.TabIndex = 0
        Me.ConnectButton.Text = "Connect"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'SendButton
        '
        Me.SendButton.Location = New System.Drawing.Point(334, 305)
        Me.SendButton.Name = "SendButton"
        Me.SendButton.Size = New System.Drawing.Size(75, 20)
        Me.SendButton.TabIndex = 1
        Me.SendButton.Text = "Send"
        Me.SendButton.UseVisualStyleBackColor = True
        '
        'MessageTextBox
        '
        Me.MessageTextBox.Location = New System.Drawing.Point(12, 305)
        Me.MessageTextBox.Name = "MessageTextBox"
        Me.MessageTextBox.Size = New System.Drawing.Size(316, 20)
        Me.MessageTextBox.TabIndex = 2
        '
        'DisconnectButton
        '
        Me.DisconnectButton.Location = New System.Drawing.Point(130, 12)
        Me.DisconnectButton.Name = "DisconnectButton"
        Me.DisconnectButton.Size = New System.Drawing.Size(112, 28)
        Me.DisconnectButton.TabIndex = 3
        Me.DisconnectButton.Text = "Disconnect"
        Me.DisconnectButton.UseVisualStyleBackColor = True
        '
        'ChatRichTextBox
        '
        Me.ChatRichTextBox.Location = New System.Drawing.Point(12, 46)
        Me.ChatRichTextBox.Name = "ChatRichTextBox"
        Me.ChatRichTextBox.Size = New System.Drawing.Size(305, 237)
        Me.ChatRichTextBox.TabIndex = 4
        Me.ChatRichTextBox.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 372)
        Me.Controls.Add(Me.ChatRichTextBox)
        Me.Controls.Add(Me.DisconnectButton)
        Me.Controls.Add(Me.MessageTextBox)
        Me.Controls.Add(Me.SendButton)
        Me.Controls.Add(Me.ConnectButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ConnectButton As Button
    Friend WithEvents SendButton As Button
    Friend WithEvents MessageTextBox As TextBox
    Friend WithEvents DisconnectButton As Button
    Friend WithEvents ChatRichTextBox As RichTextBox
End Class
