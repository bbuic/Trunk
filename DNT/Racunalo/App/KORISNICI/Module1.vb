Module Module1

    'PROCEDURA ZA POSTAVLJANJE KURSORA NA PRAVU POZICIJU
    Public Sub Kursor_Pozicija(ByVal kojiStupac As Byte, ByVal KojiRed As Byte)
        Dim KURSOR_POZ As Byte() = {27, 108, kojiStupac, KojiRed}
        FRM_OGRANICENO.RS232_LCD.Write(KURSOR_POZ, 0, 4)
    End Sub

    'PROCEDURA 
    Public Sub brisi_lcd()
        Dim BRISI_LCD As Byte() = {12}
        FRM_OGRANICENO.RS232_LCD.Write(BRISI_LCD, 0, 1)
    End Sub

    'PROCEDURA (SLOVA SE ISPISUJU NA DONJOJ LINJI, KAD DOÐE DO KRAJA SADRŽAJ PREBACUJE NA GORNJU LINJU 
    ' I POÈINJE PISATI OD POÈETKA DONJE LINJE)
    Public Sub vertical_lcd()
        Dim VERTICAL As Byte() = {27, 18}
        FRM_OGRANICENO.RS232_LCD.Write(VERTICAL, 0, 2)
    End Sub

    'PROCEDURA
    Public SLOVO_UVODNE_PORUKE As Int16 = 1
    Public Sub uvodna_poruka()
        If My.Settings.KoristiLcd Then
            FRM_OGRANICENO.TIMER_SLOVA.Start()
            SLOVO_UVODNE_PORUKE = 1
            FRM_OGRANICENO.TIMER_SLOVA.Interval = 250
        End If
    End Sub

    Public Sub LCD_PORUKA(ByVal TEXT As String)
        If My.Settings.KoristiLcd Then
            FRM_OGRANICENO.TIMER_SLOVA.Stop()
            brisi_lcd()
            Kursor_Pozicija(1, 1)
            FRM_OGRANICENO.RS232_LCD.Write(TEXT)
        End If
    End Sub

    Public Sub UPDATE_NAREDBA(ByVal SQLCommand As System.Data.OleDb.OleDbCommand)

        FRM_OGRANICENO.KONEKCIJA.Open()
        SQLCommand.Connection = FRM_OGRANICENO.KONEKCIJA
        Dim UPDATE_NAR As Int32 = SQLCommand.ExecuteNonQuery()
        FRM_OGRANICENO.KONEKCIJA.Close()
        '
        '
        Call FRM_OGRANICENO.NAPUNI_TRANSAKCIJE()
    End Sub

End Module
