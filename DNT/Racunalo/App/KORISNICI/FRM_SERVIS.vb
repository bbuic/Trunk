Public Class FRM_SERVIS

#Region "UÈITAVANJE FORME"
    Private Sub UCITAJ(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each COMString As String In My.Computer.Ports.SerialPortNames
            Me.CB_COM_LCD.Items.Add(COMString)
            Me.CB_COM_MIKRO.Items.Add(COMString)
        Next
        Me.CB_COM_LCD.Sorted = True
        Me.CB_COM_MIKRO.Sorted = True
    End Sub
#End Region

#Region "UNOS LOZINE SERVISA"

    Private Sub BTN_LOZINKA_SERVIS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LOZINKA_SERVIS.Click
        If TXT_LOZINKA_SERVIS.Text = "6cpjs5aa" Then
            GRB_ISPIS_BAZE_KARTICA.Visible = True
            TXT_LOZINKA_SERVIS.Text = ""
            Me.TXT_LOZINKA_SERVIS.Visible = False
            Me.BTN_LOZINKA_SERVIS.Visible = False

        End If
    End Sub

#End Region

#Region "ZAPAMTI COM"

    Private Sub BTN_ZAPAMTI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_ZAPAMTI.Click
        FRM_OGRANICENO.KONEKCIJA.Open()
        Dim NAREDBA3 As New System.Data.OleDb.OleDbCommand("UPDATE SISTEM Set COM_LCD = '" & Me.CB_COM_LCD.Text & "', COM_MIKRO = '" & Me.CB_COM_MIKRO.Text & "' WHERE ID = 1", FRM_OGRANICENO.KONEKCIJA)
        Dim VRATI_NATRAG1 As Int32 = NAREDBA3.ExecuteNonQuery()
        FRM_OGRANICENO.KONEKCIJA.Close()




        If (Me.CB_COM_LCD.Text <> Me.CB_COM_MIKRO.Text) And Me.CB_COM_LCD.Text <> "" Then
            FRM_OGRANICENO.RS232_MIKRO.Close()
            FRM_OGRANICENO.RS232_MIKRO.PortName = Me.CB_COM_MIKRO.Text
            FRM_OGRANICENO.RS232_MIKRO.Open()
            FRM_OGRANICENO.RS232_MIKRO.DiscardInBuffer()
        Else
            MsgBox("MIKRO=KRIVI COM PORT", MsgBoxStyle.Critical)
        End If

    End Sub
#End Region

End Class