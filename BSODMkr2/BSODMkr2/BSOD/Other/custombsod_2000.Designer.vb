<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class custombsod_2000
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(custombsod_2000))
        Me.custombsodtext = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'custombsodtext
        '
        Me.custombsodtext.AutoSize = True
        Me.custombsodtext.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.custombsodtext.ForeColor = System.Drawing.Color.White
        Me.custombsodtext.Location = New System.Drawing.Point(0, 9)
        Me.custombsodtext.Name = "custombsodtext"
        Me.custombsodtext.Size = New System.Drawing.Size(162, 16)
        Me.custombsodtext.TabIndex = 0
        Me.custombsodtext.Text = "THIS IS A CUSTOM BSOD!"
        '
        'custombsod_2000
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(300, 300)
        Me.Controls.Add(Me.custombsodtext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "custombsod_2000"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "BSOD Mkr 2.0 - Custom BSOD"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents custombsodtext As System.Windows.Forms.Label
End Class
