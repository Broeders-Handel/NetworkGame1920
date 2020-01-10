<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Client
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.SendButton = New System.Windows.Forms.Button()
        Me.MessageTextBox = New System.Windows.Forms.TextBox()
        Me.DisconnectButton = New System.Windows.Forms.Button()
        Me.ChatRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.IPAdressTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.ChatRichTextBox.ReadOnly = True
        Me.ChatRichTextBox.Size = New System.Drawing.Size(305, 253)
        Me.ChatRichTextBox.TabIndex = 4
        Me.ChatRichTextBox.Text = ""
        '
        'IPAdressTextBox
        '
        Me.IPAdressTextBox.Location = New System.Drawing.Point(12, 331)
        Me.IPAdressTextBox.Name = "IPAdressTextBox"
        Me.IPAdressTextBox.Size = New System.Drawing.Size(316, 20)
        Me.IPAdressTextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(345, 334)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "IP Adress"
        '
        'Client
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 372)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.IPAdressTextBox)
        Me.Controls.Add(Me.ChatRichTextBox)
        Me.Controls.Add(Me.DisconnectButton)
        Me.Controls.Add(Me.MessageTextBox)
        Me.Controls.Add(Me.SendButton)
        Me.Controls.Add(Me.ConnectButton)
        Me.Name = "Client"
        Me.Text = "Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ConnectButton As Button
    Friend WithEvents SendButton As Button
    Friend WithEvents MessageTextBox As TextBox
    Friend WithEvents DisconnectButton As Button
    Friend WithEvents ChatRichTextBox As RichTextBox
    Friend WithEvents IPAdressTextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
