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
        Me.IpAdressTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsersListBox = New System.Windows.Forms.ListBox()
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
        Me.SendButton.Location = New System.Drawing.Point(334, 304)
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
        'IpAdressTextBox
        '
        Me.IpAdressTextBox.Location = New System.Drawing.Point(12, 331)
        Me.IpAdressTextBox.Name = "IpAdressTextBox"
        Me.IpAdressTextBox.Size = New System.Drawing.Size(316, 20)
        Me.IpAdressTextBox.TabIndex = 5
        Me.IpAdressTextBox.Text = "127.0.0.1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(331, 332)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ": IP"
        '
        'UsersListBox
        '
        Me.UsersListBox.FormattingEnabled = True
        Me.UsersListBox.Location = New System.Drawing.Point(324, 47)
        Me.UsersListBox.Name = "UsersListBox"
        Me.UsersListBox.Size = New System.Drawing.Size(139, 251)
        Me.UsersListBox.TabIndex = 8
        '
        'Client
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 372)
        Me.Controls.Add(Me.UsersListBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.IpAdressTextBox)
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
    Friend WithEvents IpAdressTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents UsersListBox As ListBox
End Class
