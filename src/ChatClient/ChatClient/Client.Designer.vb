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
        Me.DisconnectButton = New System.Windows.Forms.Button()
        Me.IpAdressTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsersListBox = New System.Windows.Forms.ListBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.PublicTabPage = New System.Windows.Forms.TabPage()
        Me.PublicChatTextBox = New System.Windows.Forms.TextBox()
        Me.PublicTextBox = New System.Windows.Forms.TextBox()
        Me.PublicSendButton = New System.Windows.Forms.Button()
        Me.PrivateTabPage = New System.Windows.Forms.TabPage()
        Me.PrivateChatTextBox = New System.Windows.Forms.TextBox()
        Me.PrivateSendButton = New System.Windows.Forms.Button()
        Me.PrivateTextBox = New System.Windows.Forms.TextBox()
        Me.ChallengeButton = New System.Windows.Forms.Button()
        Me.LeaveButton = New System.Windows.Forms.Button()
        Me.GewonnenLabel = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.PublicTabPage.SuspendLayout()
        Me.PrivateTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConnectButton
        '
        Me.ConnectButton.Location = New System.Drawing.Point(444, 12)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(112, 28)
        Me.ConnectButton.TabIndex = 0
        Me.ConnectButton.Text = "Connect"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'DisconnectButton
        '
        Me.DisconnectButton.Location = New System.Drawing.Point(562, 12)
        Me.DisconnectButton.Name = "DisconnectButton"
        Me.DisconnectButton.Size = New System.Drawing.Size(112, 28)
        Me.DisconnectButton.TabIndex = 3
        Me.DisconnectButton.Text = "Disconnect"
        Me.DisconnectButton.UseVisualStyleBackColor = True
        '
        'IpAdressTextBox
        '
        Me.IpAdressTextBox.Location = New System.Drawing.Point(445, 342)
        Me.IpAdressTextBox.Name = "IpAdressTextBox"
        Me.IpAdressTextBox.Size = New System.Drawing.Size(316, 20)
        Me.IpAdressTextBox.TabIndex = 5
        Me.IpAdressTextBox.Text = "127.0.0.1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(763, 343)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ": IP"
        '
        'UsersListBox
        '
        Me.UsersListBox.FormattingEnabled = True
        Me.UsersListBox.Location = New System.Drawing.Point(801, 13)
        Me.UsersListBox.Name = "UsersListBox"
        Me.UsersListBox.Size = New System.Drawing.Size(139, 290)
        Me.UsersListBox.TabIndex = 8
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.PublicTabPage)
        Me.TabControl1.Controls.Add(Me.PrivateTabPage)
        Me.TabControl1.Location = New System.Drawing.Point(444, 50)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(351, 253)
        Me.TabControl1.TabIndex = 9
        '
        'PublicTabPage
        '
        Me.PublicTabPage.Controls.Add(Me.PublicChatTextBox)
        Me.PublicTabPage.Controls.Add(Me.PublicTextBox)
        Me.PublicTabPage.Controls.Add(Me.PublicSendButton)
        Me.PublicTabPage.Location = New System.Drawing.Point(4, 22)
        Me.PublicTabPage.Name = "PublicTabPage"
        Me.PublicTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.PublicTabPage.Size = New System.Drawing.Size(343, 227)
        Me.PublicTabPage.TabIndex = 0
        Me.PublicTabPage.Text = "Public Chatroom"
        Me.PublicTabPage.UseVisualStyleBackColor = True
        '
        'PublicChatTextBox
        '
        Me.PublicChatTextBox.Location = New System.Drawing.Point(6, 6)
        Me.PublicChatTextBox.Multiline = True
        Me.PublicChatTextBox.Name = "PublicChatTextBox"
        Me.PublicChatTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.PublicChatTextBox.Size = New System.Drawing.Size(331, 186)
        Me.PublicChatTextBox.TabIndex = 3
        '
        'PublicTextBox
        '
        Me.PublicTextBox.Location = New System.Drawing.Point(7, 198)
        Me.PublicTextBox.Name = "PublicTextBox"
        Me.PublicTextBox.Size = New System.Drawing.Size(249, 20)
        Me.PublicTextBox.TabIndex = 2
        '
        'PublicSendButton
        '
        Me.PublicSendButton.Location = New System.Drawing.Point(262, 196)
        Me.PublicSendButton.Name = "PublicSendButton"
        Me.PublicSendButton.Size = New System.Drawing.Size(75, 23)
        Me.PublicSendButton.TabIndex = 1
        Me.PublicSendButton.Text = "Send"
        Me.PublicSendButton.UseVisualStyleBackColor = True
        '
        'PrivateTabPage
        '
        Me.PrivateTabPage.Controls.Add(Me.PrivateChatTextBox)
        Me.PrivateTabPage.Controls.Add(Me.PrivateSendButton)
        Me.PrivateTabPage.Controls.Add(Me.PrivateTextBox)
        Me.PrivateTabPage.Location = New System.Drawing.Point(4, 22)
        Me.PrivateTabPage.Name = "PrivateTabPage"
        Me.PrivateTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.PrivateTabPage.Size = New System.Drawing.Size(343, 227)
        Me.PrivateTabPage.TabIndex = 1
        Me.PrivateTabPage.Text = "Private Chatroom"
        Me.PrivateTabPage.UseVisualStyleBackColor = True
        '
        'PrivateChatTextBox
        '
        Me.PrivateChatTextBox.Location = New System.Drawing.Point(6, 6)
        Me.PrivateChatTextBox.Multiline = True
        Me.PrivateChatTextBox.Name = "PrivateChatTextBox"
        Me.PrivateChatTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.PrivateChatTextBox.Size = New System.Drawing.Size(330, 183)
        Me.PrivateChatTextBox.TabIndex = 5
        '
        'PrivateSendButton
        '
        Me.PrivateSendButton.Location = New System.Drawing.Point(261, 195)
        Me.PrivateSendButton.Name = "PrivateSendButton"
        Me.PrivateSendButton.Size = New System.Drawing.Size(75, 23)
        Me.PrivateSendButton.TabIndex = 4
        Me.PrivateSendButton.Text = "Send"
        Me.PrivateSendButton.UseVisualStyleBackColor = True
        '
        'PrivateTextBox
        '
        Me.PrivateTextBox.Location = New System.Drawing.Point(6, 197)
        Me.PrivateTextBox.Name = "PrivateTextBox"
        Me.PrivateTextBox.Size = New System.Drawing.Size(249, 20)
        Me.PrivateTextBox.TabIndex = 3
        '
        'ChallengeButton
        '
        Me.ChallengeButton.Enabled = False
        Me.ChallengeButton.Location = New System.Drawing.Point(445, 310)
        Me.ChallengeButton.Name = "ChallengeButton"
        Me.ChallengeButton.Size = New System.Drawing.Size(91, 23)
        Me.ChallengeButton.TabIndex = 0
        Me.ChallengeButton.Text = "Challenge"
        Me.ChallengeButton.UseVisualStyleBackColor = True
        '
        'LeaveButton
        '
        Me.LeaveButton.Location = New System.Drawing.Point(542, 310)
        Me.LeaveButton.Name = "LeaveButton"
        Me.LeaveButton.Size = New System.Drawing.Size(91, 23)
        Me.LeaveButton.TabIndex = 10
        Me.LeaveButton.Text = "Leave"
        Me.LeaveButton.UseVisualStyleBackColor = True
        '
        'GewonnenLabel
        '
        Me.GewonnenLabel.AutoSize = True
        Me.GewonnenLabel.Location = New System.Drawing.Point(801, 310)
        Me.GewonnenLabel.Name = "GewonnenLabel"
        Me.GewonnenLabel.Size = New System.Drawing.Size(0, 13)
        Me.GewonnenLabel.TabIndex = 11
        '
        'Client
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 375)
        Me.Controls.Add(Me.GewonnenLabel)
        Me.Controls.Add(Me.LeaveButton)
        Me.Controls.Add(Me.ChallengeButton)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.UsersListBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.IpAdressTextBox)
        Me.Controls.Add(Me.DisconnectButton)
        Me.Controls.Add(Me.ConnectButton)
        Me.Name = "Client"
        Me.Text = "Client"
        Me.TabControl1.ResumeLayout(False)
        Me.PublicTabPage.ResumeLayout(False)
        Me.PublicTabPage.PerformLayout()
        Me.PrivateTabPage.ResumeLayout(False)
        Me.PrivateTabPage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ConnectButton As Button
    Friend WithEvents DisconnectButton As Button
    Friend WithEvents IpAdressTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents UsersListBox As ListBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents PublicTabPage As TabPage
    Friend WithEvents ChallengeButton As Button
    Friend WithEvents PublicTextBox As TextBox
    Friend WithEvents PublicSendButton As Button
    Friend WithEvents PrivateTabPage As TabPage
    Friend WithEvents PrivateSendButton As Button
    Friend WithEvents PrivateTextBox As TextBox
    Friend WithEvents PublicChatTextBox As TextBox
    Friend WithEvents PrivateChatTextBox As TextBox
    Friend WithEvents LeaveButton As Button
    Friend WithEvents GewonnenLabel As Label
End Class
