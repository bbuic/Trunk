<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_SERVIS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_SERVIS))
        Me.BTN_LOZINKA_SERVIS = New System.Windows.Forms.Button
        Me.GRB_ISPIS_BAZE_KARTICA = New System.Windows.Forms.GroupBox
        Me.BTN_ZAPAMTI = New System.Windows.Forms.Button
        Me.CB_COM_MIKRO = New System.Windows.Forms.ComboBox
        Me.CB_COM_LCD = New System.Windows.Forms.ComboBox
        Me.TXT_LOZINKA_SERVIS = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GRB_ISPIS_BAZE_KARTICA.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_LOZINKA_SERVIS
        '
        Me.BTN_LOZINKA_SERVIS.Location = New System.Drawing.Point(201, 49)
        Me.BTN_LOZINKA_SERVIS.Name = "BTN_LOZINKA_SERVIS"
        Me.BTN_LOZINKA_SERVIS.Size = New System.Drawing.Size(63, 23)
        Me.BTN_LOZINKA_SERVIS.TabIndex = 28
        Me.BTN_LOZINKA_SERVIS.Text = "Lozinka"
        Me.BTN_LOZINKA_SERVIS.UseVisualStyleBackColor = True
        '
        'GRB_ISPIS_BAZE_KARTICA
        '
        Me.GRB_ISPIS_BAZE_KARTICA.BackColor = System.Drawing.Color.Transparent
        Me.GRB_ISPIS_BAZE_KARTICA.Controls.Add(Me.Label2)
        Me.GRB_ISPIS_BAZE_KARTICA.Controls.Add(Me.Label1)
        Me.GRB_ISPIS_BAZE_KARTICA.Controls.Add(Me.BTN_ZAPAMTI)
        Me.GRB_ISPIS_BAZE_KARTICA.Controls.Add(Me.CB_COM_MIKRO)
        Me.GRB_ISPIS_BAZE_KARTICA.Controls.Add(Me.CB_COM_LCD)
        Me.GRB_ISPIS_BAZE_KARTICA.Location = New System.Drawing.Point(12, 12)
        Me.GRB_ISPIS_BAZE_KARTICA.Name = "GRB_ISPIS_BAZE_KARTICA"
        Me.GRB_ISPIS_BAZE_KARTICA.Size = New System.Drawing.Size(183, 96)
        Me.GRB_ISPIS_BAZE_KARTICA.TabIndex = 22
        Me.GRB_ISPIS_BAZE_KARTICA.TabStop = False
        Me.GRB_ISPIS_BAZE_KARTICA.Text = "COM port"
        Me.GRB_ISPIS_BAZE_KARTICA.Visible = False
        '
        'BTN_ZAPAMTI
        '
        Me.BTN_ZAPAMTI.Location = New System.Drawing.Point(19, 67)
        Me.BTN_ZAPAMTI.Name = "BTN_ZAPAMTI"
        Me.BTN_ZAPAMTI.Size = New System.Drawing.Size(145, 23)
        Me.BTN_ZAPAMTI.TabIndex = 29
        Me.BTN_ZAPAMTI.Text = "ZAPAMTI"
        Me.BTN_ZAPAMTI.UseVisualStyleBackColor = True
        '
        'CB_COM_MIKRO
        '
        Me.CB_COM_MIKRO.FormattingEnabled = True
        Me.CB_COM_MIKRO.Location = New System.Drawing.Point(99, 39)
        Me.CB_COM_MIKRO.Name = "CB_COM_MIKRO"
        Me.CB_COM_MIKRO.Size = New System.Drawing.Size(65, 21)
        Me.CB_COM_MIKRO.TabIndex = 1
        '
        'CB_COM_LCD
        '
        Me.CB_COM_LCD.FormattingEnabled = True
        Me.CB_COM_LCD.Location = New System.Drawing.Point(19, 39)
        Me.CB_COM_LCD.Name = "CB_COM_LCD"
        Me.CB_COM_LCD.Size = New System.Drawing.Size(66, 21)
        Me.CB_COM_LCD.TabIndex = 0
        '
        'TXT_LOZINKA_SERVIS
        '
        Me.TXT_LOZINKA_SERVIS.Location = New System.Drawing.Point(201, 23)
        Me.TXT_LOZINKA_SERVIS.Name = "TXT_LOZINKA_SERVIS"
        Me.TXT_LOZINKA_SERVIS.Size = New System.Drawing.Size(63, 20)
        Me.TXT_LOZINKA_SERVIS.TabIndex = 29
        Me.TXT_LOZINKA_SERVIS.UseSystemPasswordChar = True
        Me.TXT_LOZINKA_SERVIS.ValidatingType = GetType(Integer)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "LCD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "MIKRO"
        '
        'FRM_SERVIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(274, 120)
        Me.Controls.Add(Me.TXT_LOZINKA_SERVIS)
        Me.Controls.Add(Me.BTN_LOZINKA_SERVIS)
        Me.Controls.Add(Me.GRB_ISPIS_BAZE_KARTICA)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_SERVIS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Postavke"
        Me.GRB_ISPIS_BAZE_KARTICA.ResumeLayout(False)
        Me.GRB_ISPIS_BAZE_KARTICA.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_LOZINKA_SERVIS As System.Windows.Forms.Button
    Friend WithEvents GRB_ISPIS_BAZE_KARTICA As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_LOZINKA_SERVIS As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BTN_ZAPAMTI As System.Windows.Forms.Button
    Friend WithEvents CB_COM_MIKRO As System.Windows.Forms.ComboBox
    Friend WithEvents CB_COM_LCD As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
