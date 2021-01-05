<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class custombsod_w8w10
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(custombsod_w8w10))
        Me.lblMain = New System.Windows.Forms.Label()
        Me.lblSmile = New System.Windows.Forms.Label()
        Me.lblSubMain = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblMain
        '
        Me.lblMain.AutoSize = True
        Me.lblMain.Font = New System.Drawing.Font("Segoe UI Semilight", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMain.ForeColor = System.Drawing.Color.White
        Me.lblMain.Location = New System.Drawing.Point(12, 31)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(612, 13)
        Me.lblMain.TabIndex = 0
        Me.lblMain.Text = "Your PC ran into a problem and needs to restart. We're just collecting some error" & _
    " info, and then we'll restart for you. (0% complete)"
        '
        'lblSmile
        '
        Me.lblSmile.AutoSize = True
        Me.lblSmile.ForeColor = System.Drawing.Color.White
        Me.lblSmile.Location = New System.Drawing.Point(12, 9)
        Me.lblSmile.Name = "lblSmile"
        Me.lblSmile.Size = New System.Drawing.Size(13, 13)
        Me.lblSmile.TabIndex = 1
        Me.lblSmile.Text = ":("
        '
        'lblSubMain
        '
        Me.lblSubMain.AutoSize = True
        Me.lblSubMain.Font = New System.Drawing.Font("Segoe UI Semilight", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubMain.ForeColor = System.Drawing.Color.White
        Me.lblSubMain.Location = New System.Drawing.Point(12, 64)
        Me.lblSubMain.Name = "lblSubMain"
        Me.lblSubMain.Size = New System.Drawing.Size(553, 13)
        Me.lblSubMain.TabIndex = 2
        Me.lblSubMain.Text = "If you'd like to know more, you can search online later for this error: BSODMKR_R" & _
    "UN_STATUS_FAILED (bsodmkr2.exe)"
        '
        'custombsod_w8w10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(300, 300)
        Me.Controls.Add(Me.lblSubMain)
        Me.Controls.Add(Me.lblSmile)
        Me.Controls.Add(Me.lblMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "custombsod_w8w10"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "BSOD Mkr 2.0 - Custom BSOD"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMain As System.Windows.Forms.Label
    Friend WithEvents lblSmile As System.Windows.Forms.Label
    Friend WithEvents lblSubMain As System.Windows.Forms.Label
End Class
