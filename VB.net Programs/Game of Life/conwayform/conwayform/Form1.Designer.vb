<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CMDClear = New System.Windows.Forms.Button()
        Me.CMDNext = New System.Windows.Forms.Button()
        Me.CBXAuto = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Controls.Add(Me.CBXAuto)
        Me.Panel1.Controls.Add(Me.CMDClear)
        Me.Panel1.Controls.Add(Me.CMDNext)
        Me.Panel1.Location = New System.Drawing.Point(401, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(100, 401)
        Me.Panel1.TabIndex = 0
        '
        'CMDClear
        '
        Me.CMDClear.Location = New System.Drawing.Point(16, 41)
        Me.CMDClear.Name = "CMDClear"
        Me.CMDClear.Size = New System.Drawing.Size(75, 23)
        Me.CMDClear.TabIndex = 1
        Me.CMDClear.Text = "Clear"
        Me.CMDClear.UseVisualStyleBackColor = True
        '
        'CMDNext
        '
        Me.CMDNext.Location = New System.Drawing.Point(16, 12)
        Me.CMDNext.Name = "CMDNext"
        Me.CMDNext.Size = New System.Drawing.Size(75, 23)
        Me.CMDNext.TabIndex = 0
        Me.CMDNext.Text = "Next"
        Me.CMDNext.UseVisualStyleBackColor = True
        '
        'CBXAuto
        '
        Me.CBXAuto.AutoSize = True
        Me.CBXAuto.Location = New System.Drawing.Point(26, 70)
        Me.CBXAuto.Name = "CBXAuto"
        Me.CBXAuto.Size = New System.Drawing.Size(48, 17)
        Me.CBXAuto.TabIndex = 2
        Me.CBXAuto.Text = "Auto"
        Me.CBXAuto.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 401)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents CMDClear As Button
    Friend WithEvents CMDNext As Button
    Friend WithEvents CBXAuto As CheckBox
End Class
