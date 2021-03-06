Imports System.Drawing.Imaging

Public Class FRM_OGRANICENO

#Region "KONEKCIJA, DATASET, ADAPTERI, NAPUNI TRANSAKCIJE"


    Public KONEKCIJA As New OleDb.OleDbConnection(My.Settings.DNTbazaConnectionString)

    Public DATASET As New DataSet()
    Dim TRANSAKCIJE As DataTable = New DataTable("TRANSAKCIJE")
    Dim KORISNICI As DataTable = DATASET.Tables.Add("KORISNICI")
    Dim KARTICE As DataTable = DATASET.Tables.Add("KARTICE")

    Dim ADAPTER_KORISNICI As New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM DNTKorisnici ORDER BY ime, prezime", KONEKCIJA)

    Dim ADAPTER_TRANSAKCIJE As New System.Data.OleDb.OleDbDataAdapter("SELECT DNTTransakcije.kartica, DNTKorisnici.ime, DNTKorisnici.prezime, DNTTransakcije.dolazak, DNTTransakcije.vrecica, DNTTransakcije.odlazak, DNTTransakcije.trezor " & _
    " FROM (Kartice INNER JOIN DNTKorisnici ON Kartice.VlasnikID = DNTKorisnici.ID) INNER JOIN DNTTransakcije ON Kartice.Broj = DNTTransakcije.kartica " & _
    " WHERE (((DNTTransakcije.trezor)=True)) ORDER BY DNTTransakcije.dolazak DESC ", KONEKCIJA)

    Dim VRECICE_U_TREZORU As New System.Data.OleDb.OleDbCommand("SELECT Sum(DNTTransakcije.vrecica) AS SumOfvrecica, DNTTransakcije.trezor " & _
    " FROM(DNTTransakcije) GROUP BY DNTTransakcije.trezor HAVING (((DNTTransakcije.trezor)=True))", KONEKCIJA)


    Sub NAPUNI_TRANSAKCIJE()
        Me.DATASET.Tables("TRANSAKCIJE").Clear()
        ADAPTER_TRANSAKCIJE.Fill(Me.DATASET.Tables("TRANSAKCIJE"))
    End Sub

    Sub NAPUNI_KORISNIK()
        DATASET.Tables("KORISNICI").Clear() 'PONISTI PRIJE UPISANO
        ADAPTER_KORISNICI.Fill(DATASET.Tables("KORISNICI"))
        If DGV_KORISNICI.Rows.Count > 0 Then
            Me.DGV_KORISNICI.Columns(0).Visible = False
            Me.DGV_KORISNICI.Columns(1).HeaderText = "Ime (Naziv1)"
            Me.DGV_KORISNICI.Columns(1).Width = 250
            Me.DGV_KORISNICI.Columns(2).HeaderText = "Prezime (Naziv2)"
            Me.DGV_KORISNICI.Columns(2).Width = 250
            Me.DGV_KORISNICI.Columns(3).HeaderText = "Ulica"
            Me.DGV_KORISNICI.Columns(3).Width = 200
            Me.DGV_KORISNICI.Columns(4).HeaderText = "Kućni broj"
            Me.DGV_KORISNICI.Columns(5).HeaderText = "Grad"
            Me.DGV_KORISNICI.Columns(6).HeaderText = "Telefon"
            Me.DGV_KORISNICI.Rows(0).Selected = True
            NAPUNI_KARTICE()
        End If
    End Sub

    Sub NAPUNI_KARTICE()
        Me.KARTICE.Clear()
        Dim ADAPTER_KARTICE As New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM Kartice WHERE VlasnikID = " & Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells(0).Value.ToString & "", KONEKCIJA)
        ADAPTER_KARTICE.Fill(Me.KARTICE)
        If DGV_KARTICE.Rows.Count > 0 Then
            Me.DGV_KARTICE.Rows(0).Selected = True
        End If
    End Sub

    Sub LABELA_VRECICE_TREZOR()
        Me.KONEKCIJA.Open()
        Dim VRECICE As Int16 = Me.VRECICE_U_TREZORU.ExecuteScalar
        Me.KONEKCIJA.Close()
        If VRECICE > 0 Then
            LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA.Text = VRECICE
        Else
            LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA.Text = 0
        End If
    End Sub

#End Region

#Region "LOAD FORME"
    'VARIJABLA KOJOM OBILJEŽAVAM DA PRVI PUT PITAM ZA PRISUTNOST UPRAVLJAČKE KUTIJE
    Public PRVI_PUT As Boolean = False
    Private Sub UCITAVANJE_ORANICENO(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TRANSAKCIJE.Columns.Add("kartica", Type.GetType("System.String"))
        TRANSAKCIJE.Columns.Add("ime", Type.GetType("System.String"))
        TRANSAKCIJE.Columns.Add("prezime", Type.GetType("System.String"))
        TRANSAKCIJE.Columns.Add("dolazak", Type.GetType("System.String"))
        TRANSAKCIJE.Columns.Add("vrecica", Type.GetType("System.Int16"))
        TRANSAKCIJE.Columns.Add("odlazak", Type.GetType("System.String"))
        Me.DATASET.Tables.Add(Me.TRANSAKCIJE)


        Me.DGV_KARTICE.AutoGenerateColumns = False
        Me.DGV_KARTICE.DataSource = Me.KARTICE
        '
        'POVEZIVANJE DTA-GRID VIEW SA ODREĐENIM SOURCE !!!!
        Me.DGV_KORISNICI.AutoGenerateColumns = True
        Me.DGV_KORISNICI.DataSource = DATASET.Tables("KORISNICI")
        '

        'POVEZIVANJE DTA-GRID VIEW SA ODREĐENIM SOURCE !!!!

        Me.DGV_TRANSAKCIJE.AutoGenerateColumns = False
        Me.DGV_TRANSAKCIJE.DataSource = DATASET.Tables("TRANSAKCIJE")

        ''

        ''-----------------------------------------------------------------------------------------
        ''-------POSTAVLJANJE VRIJEDNOST UBACENIH VREČICA NAKON PRAŽNJENJA TREZORA-----------------
        ''-----------------------------------------------------------------------------------------

        Me.LABELA_VRECICE_TREZOR()

        KONEKCIJA.Open()
        Dim NAREDBA2 As New System.Data.OleDb.OleDbCommand("SELECT TREZOR_PRAZAN_VRIJEME FROM SISTEM WHERE ID = 1", KONEKCIJA)
        Dim VRIJEME_PAZNJENJA As DateTime = NAREDBA2.ExecuteScalar
        KONEKCIJA.Close()

        Try
            Me.LBL_PRAZNJENJE_TREZORA.Text = VRIJEME_PAZNJENJA.ToString("dd.MM.yyyy HH:ss")
        Catch ex As Exception
            VRIJEME_PAZNJENJA = "Datum pražnjenja"
        End Try

        Call NAPUNI_TRANSAKCIJE()

        Try
            Me.RS232_MIKRO.Open()
            Me.RS232_MIKRO.DiscardInBuffer()
        Catch ex As Exception
            MessageBox.Show("Greška kod spajanja na elektroniku DNTa: " & ex.Message, Me.Text)
        End Try

        If My.Settings.KoristiLcd Then
            Try
                Me.RS232_LCD.Open()
                uvodna_poruka()
            Catch ex As Exception
                MessageBox.Show("Greška kod spajanja na LCD DNTa: " & ex.Message, Me.Text)
            End Try
        End If





    End Sub
#End Region

#Region "SERIJSKI PORT"
    Dim I As Integer
    Dim _vrijemeDolaska As DateTime
    Dim _brojVrecica As Integer

    Dim _unutraVrataOtvorena As Boolean = False 'OVIME OBILJEŽAVAM DA UNUTRAŠNJA VRATA NISU OTVORENA
    Dim _fotocelijaBlokirana As Boolean = False 'OVIME OBILJEŽAVAM DA JE FOTOČELIJA BLOKIRANA (ZAPUNJEN KANAL)

    Private Sub OBRADI(ByVal sender As System.Object, ByVal e As System.EventArgs)

        RemoveHandler RS232_MIKRO.DataReceived, AddressOf BROJ

        Select Case Hex(Me.RS232_MIKRO.ReadByte())

            Case 20

                Dim kartica As String
                Dim buffer(2) As Byte
                buffer(1) = RS232_MIKRO.ReadByte()
                buffer(0) = RS232_MIKRO.ReadByte()
                kartica = ((BitConverter.ToInt16(buffer, 0)).ToString).PadLeft(5, "0")

                KONEKCIJA.Open()
                Dim nar2 As New OleDb.OleDbCommand("SELECT Count(*) FROM Kartice WHERE Broj = '" & kartica & "' ", KONEKCIJA)
                Dim brojKorisnika As Int16 = nar2.ExecuteScalar()
                KONEKCIJA.Close()

                If brojKorisnika >= 1 And Me._unutraVrataOtvorena = False And Me._fotocelijaBlokirana = False _
                And Me.Enabled = True Then  'AKO DOĐE OVDJE KORISNIK POSTOJI U BAZI

                    Me.Enabled = False

                    RS232_MIKRO.Write(Chr(16)) 'OTVORI VRATA
                    _brojVrecica = 0 'KAD DOÐE KORISNIK BROJ VREÈICA SE POSTAVLJA U NULU

                    _vrijemeDolaska = Now

                    KONEKCIJA.Open()
                    Dim naredba As New OleDb.OleDbCommand("INSERT INTO DNTTransakcije (kartica ,dolazak,trezor) Values (?,?,true)", KONEKCIJA)
                    naredba.Parameters.Add("@Kartica", OleDb.OleDbType.VarChar).Value = kartica
                    naredba.Parameters.Add("@VrijemeDolaska", OleDb.OleDbType.Date).Value = _vrijemeDolaska
                    naredba.ExecuteNonQuery()
                    KONEKCIJA.Close()
                    '
                    Call Me.NAPUNI_TRANSAKCIJE()

                    LCD_PORUKA("   OTORITE VRATA      Ubacujte vrecice")
                    Me.TIMER_ZASUN_UVUCEN.Start() ' timer koji ako se vrata ne otvore u roku tri sekunde zatvori zasun

                End If


                Exit Select


                '
                '--------------------------------------------------------------------------------------------------------------------------------
                '--------MIKROKONTROLER MI JAVLJA DA SU VANJSKA VRATA OTVORENA-----------
                '
            Case 21
                Me.TIMER_ZASUN_UVUCEN.Stop()
                Me.TIME_VRATA_OTVORENA.Start()
                LCD_PORUKA("Dozvoljeno ubacivatiUbaceno vrecica = 0")

                Exit Select


                '
                '--------------------------------------------------------------------------------------------------------------------------------
                '--------MIKROKONTROLER obavještava da su VANJSKA vrata zatvorena-----------
                '
                '
            Case 22

                Me.TIME_VRATA_OTVORENA.Stop()

                Dim komanda As New OleDb.OleDbCommand("UPDATE DNTTransakcije Set odlazak = ? WHERE dolazak = ?")
                komanda.Parameters.Add("@Odlazak", OleDb.OleDbType.Date).Value = Now
                komanda.Parameters.Add("@Dolazak", OleDb.OleDbType.Date).Value = _vrijemeDolaska
                UPDATE_NAREDBA(komanda)

                PORUKA("HVALA NA POVJERENJU!")
                Me.Enabled = True

                FRM_PORUKA_VRATA1.Close() 'OVDJE ZATVARAM PORUKU AKO JE OTVORENA
                Exit Select







                '*********************************************************************************************************************************
                'SLANJE KOLIKO JE VREĆICA UBAČENO
                '***********************************************
                '
            Case 23

                _brojVrecica += 1

                Me.TIME_VRATA_OTVORENA.Stop()
                Me.TIME_VRATA_OTVORENA.Start()

                LCD_PORUKA("Dozvoljeno ubacivatiUbaceno vrecica = " & _brojVrecica & "")

                Dim komanda As New OleDb.OleDbCommand("UPDATE DNTTransakcije Set vrecica = ? WHERE dolazak = ?")
                komanda.Parameters.Add("@Vrecice", OleDb.OleDbType.Integer).Value = _brojVrecica
                komanda.Parameters.Add("@Dolazak", OleDb.OleDbType.Date).Value = _vrijemeDolaska
                UPDATE_NAREDBA(komanda)

                'POKAŽI U LABELI BROJ VREČICA
                Me.LABELA_VRECICE_TREZOR()

                Exit Select



                '*********************************************************************************************************************************
                'UNUTRAŠNJA VRATA OTVORENA
                '***********************************************
                '
            Case 26
                Me._unutraVrataOtvorena = True
                FRM_PORUKA1.Show()
                FRM_PORUKA1.Label1.Text = "PRAŽNJENJE TREZORA"
                LCD_PORUKA("PRAZNJENJE TREZORA  Pricekajte trenutak")
                Exit Select

                '*********************************************************************************************************************************
                'UNUTRAŠNJA VRATA ZATVORENA
                '***********************************************
                '
            Case 25
                Me._unutraVrataOtvorena = False
                FRM_PORUKA1.Close()
                Module1.uvodna_poruka()
                Exit Select



                '*********************************************************************************************************************************
                'ZAPUNJEN KANAL
                '***********************************************
                '
            Case 24

                Me._fotocelijaBlokirana = True

                FRM_PORUKA_FOTO1.Show()
                LCD_PORUKA("TREZOR NE RADI      Dodite kasnije")

                'KONEKCIJA.Open()
                'Dim NAREDBA As New System.Data.OleDb.OleDbCommand("INSERT INTO ALARM" & _
                '"(dolazak_ZA,zapunjeno) Values ('" & VRIJEME_DOLASKA & "','" & Now & "')", KONEKCIJA)
                'Dim recordsAffected As Int32 = NAREDBA.ExecuteNonQuery()
                'KONEKCIJA.Close()
                Exit Select




                '*********************************************************************************************************************************
                'OTVOREN KANAL (NAKON ALARMA ZAPUNJEN KANAL)
                '***********************************************
                '
            Case 27
                Me._fotocelijaBlokirana = False
                FRM_PORUKA_FOTO1.Close()

        End Select


        AddHandler RS232_MIKRO.DataReceived, AddressOf BROJ
    End Sub


    Private Sub BROJ(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles RS232_MIKRO.DataReceived
        Me.Invoke(New EventHandler(AddressOf OBRADI))
    End Sub
#End Region


#Region "KORISNICI DNT-A = ZAPAMTI"

    Private Sub BTN_UNOS_KARTICE_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_UNOS_KARTICE.Click

        If Me.TabControl1.SelectedIndex = 0 Then
            If Me.Provjera_unosa_naziva1 = True Then

                'PROVJERAVAM DALI KARTICA VEČ POSTOJI U BAZI PODATAKA
                KONEKCIJA.Open()
                Dim NAREDBA1 As New System.Data.OleDb.OleDbCommand("SELECT Count(*) FROM DNTKorisnici WHERE ime = '" & Me.TXT_IME.Text & "'", KONEKCIJA)
                Dim BROJ_NAZIV1 As Int16 = NAREDBA1.ExecuteScalar()
                KONEKCIJA.Close()
                '
                If BROJ_NAZIV1 = 0 Then

                    '
                    KONEKCIJA.Open()
                    Dim ImePrezime As String = TXT_IME.Text.Trim()
                    Dim NAREDBA As New System.Data.OleDb.OleDbCommand("INSERT INTO DNTKorisnici " & _
                    " (ime, prezime, ulica, kucni, mjesto, telefon)" & _
                    " Values ('" & ImePrezime & "', '" & TXT_PREZIME.Text & "', '" & TXT_ULICA.Text & "', '" & TXT_KUCNI_BROJ.Text & "', " & " '" & TXT_GRAD_MJESTO.Text & "', '" & TXT_TELEFON.Text & "')", KONEKCIJA)
                    Dim ZAPAMTI_KORISNIKA As Int32 = NAREDBA.ExecuteNonQuery()
                    KONEKCIJA.Close()


                    'RESETIRANJE FORME JER IZA OVOGA SE VIŠE NE UUNOSE KORISNICI                    
                    Me.NAPUNI_KORISNIK()
                    If Me.DGV_KORISNICI.Rows.Count > 0 Then
                        For j As Integer = 0 To Me.DGV_KORISNICI.Rows.Count
                            If Me.DGV_KORISNICI.Rows(j).Cells(1).Value.ToString = ImePrezime Then
                                Me.DGV_KORISNICI.FirstDisplayedScrollingRowIndex = Me.DGV_KORISNICI.Rows(j).Index
                                Me.DGV_KORISNICI.Rows(j).Selected = True
                                Exit For
                            End If
                        Next
                    End If

                    '-------------------------------------------------------
                    'PRIKAZIVANJE PORUKE USPIJEŠNOSTI UPISIVANJA KORISNIKA U BAZU KORISNIKA
                    '
                    MsgBox("Uspješno ste unijeli korisnika  bazu korisnika" & vbCrLf & _
                                                        "DNEVNO-NOĆNOG TREZORA !", MsgBoxStyle.Information, "INFORMACIJA")

                Else
                    MsgBox("Ime(Naziv 1) koji želite unijeti već postoji u bazi! Morate ga promjeniti.", MsgBoxStyle.Exclamation, "OPREZ!")
                End If

            End If
        End If




        If Me.TabControl1.SelectedIndex = 1 Then

            If Me.Provjera_unosa_kartice = True Then  'IDEM PROVJERITI DALI SU SVI POTREBITI PODACI UNEŠENI

                'PROVJERAVAM DALI KARTICA VEČ POSTOJI U BAZI PODATAKA
                KONEKCIJA.Open()
                Dim NAREDBA1 As New System.Data.OleDb.OleDbCommand("SELECT Count(*) FROM Kartice WHERE Broj = '" & TXT_BROJ_KARTICE.Text & "'", KONEKCIJA)
                Dim BROJ_KARTICA_BAZA As Int16 = NAREDBA1.ExecuteScalar()
                KONEKCIJA.Close()
                '
                If BROJ_KARTICA_BAZA = 0 Then
                    '

                    KONEKCIJA.Open()
                    Dim NAREDBA As New System.Data.OleDb.OleDbCommand("INSERT INTO Kartice " & _
                    " (Broj, VlasnikID, Ugovor, Datum)" & _
                    " Values ('" & TXT_BROJ_KARTICE.Text & "', '" & Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells("ID").Value & "' ,'" & TXT_BROJ_UGOVORA.Text & "', '" & DATUM1.Text & "')", KONEKCIJA)
                    Dim recordsAffected As Int32 = NAREDBA.ExecuteNonQuery()
                    KONEKCIJA.Close()
                    Me.NAPUNI_KARTICE()



                Else

                    MsgBox("Kartica koju želite unijeti već postoji u bazi! Morate promjeniti karticu.", MsgBoxStyle.Exclamation, "OPREZ!")

                End If



            End If
        End If


    End Sub
#End Region

#Region "KORISNICI DNT-A = PROMJENI"

    Private Sub BTN_PROMJENI_KORISNIKA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_PROMJENI_KORISNIKA.Click

        If Me.TabControl1.SelectedIndex = 0 Then

            If Me.Provjera_unosa_naziva1 = True Then  'IDEM PROVJERITI DALI SU SVI POTREBITI PODACI UNEŠENI

                KONEKCIJA.Open()
                Dim NAREDBA As New System.Data.OleDb.OleDbCommand("UPDATE DNTKorisnici Set " & _
                " ime = '" & TXT_IME.Text & "', prezime = '" & Me.TXT_PREZIME.Text & "', ulica = '" & Me.TXT_ULICA.Text & "', " & _
                " kucni = '" & Me.TXT_KUCNI_BROJ.Text & "', mjesto = '" & Me.TXT_GRAD_MJESTO.Text & "', " & _
                " telefon = '" & Me.TXT_TELEFON.Text & "' " & _
                " WHERE  ID = " & Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells("ID").Value & " ", KONEKCIJA)
                Dim recordsAffected As Int32 = NAREDBA.ExecuteNonQuery()
                KONEKCIJA.Close()


                Me.NAPUNI_KORISNIK()
                Me.SELEKTIRANJE_KORISNIKA()
            End If


        ElseIf Me.TabControl1.SelectedIndex = 1 Then

        End If
    End Sub
#End Region

#Region "KORISNICI DNT-A = BRISI"
    '
    '-----------------------------------------------------------
    '-------------------BRISANJE KARTICE-------------------------
    '-----------------------------------------------------------
    '
    Private Sub BTN_BRISANJE_KARTICE_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_BRISANJE_KARTICE.Click




        If Me.TabControl1.SelectedIndex = 0 Then

            If Me.Provjera_unosa_naziva1 = True Then  'IDEM PROVJERITI DALI SU SVI POTREBITI PODACI UNEŠENI

                KONEKCIJA.Open()
                Dim NAREDBA1 As New System.Data.OleDb.OleDbCommand("SELECT Count(*) FROM Kartice WHERE VlasnikID = " & Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells("ID").Value.ToString & "", KONEKCIJA)
                Dim BROJ_KARTICA_BAZA As Int16 = NAREDBA1.ExecuteScalar()
                KONEKCIJA.Close()
                If BROJ_KARTICA_BAZA > 0 Then
                    MsgBox("Prije nego izbrišete korisnika iz baze morate obrisati njegove kartice!", MsgBoxStyle.Information, "INFORMACIJA")
                    Exit Sub
                End If

                Dim INT As Integer
                INT = MsgBox("Jeste sigurni da želite korisnika izbrisati iz baze ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "OPREZ !")

                If INT = MsgBoxResult.Yes Then
                    KONEKCIJA.Open()
                    Dim NAREDBA As New System.Data.OleDb.OleDbCommand("DELETE FROM DNTKorisnici WHERE ime = ('" & Me.TXT_IME.Text & "')", KONEKCIJA)
                    Dim recordsAffected As Int32 = NAREDBA.ExecuteNonQuery()
                    KONEKCIJA.Close()

                    Me.NAPUNI_KORISNIK()

                    MsgBox("Uspješno ste izbrisali korisnika iz baze korisnika" & vbCrLf & _
                                                        "DNEVNO-NOĆNOG TREZORA !", MsgBoxStyle.Information, "INFORMACIJA")



                End If
            End If


        ElseIf Me.TabControl1.SelectedIndex = 1 Then

            If Me.Provjera_unosa_kartice = True Then  'IDEM PROVJERITI DALI SU SVI POTREBITI PODACI UNEŠENI

                Dim INT As Integer
                INT = MsgBox("Jeste sigurni da želite karticu izbrisati iz baze podataka? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "OPREZ !")

                If INT = MsgBoxResult.Yes Then
                    KONEKCIJA.Open()
                    Dim NAREDBA As New System.Data.OleDb.OleDbCommand("DELETE FROM Kartice WHERE Broj = ('" & Me.TXT_BROJ_KARTICE.Text & "')", KONEKCIJA)
                    Dim recordsAffected As Int32 = NAREDBA.ExecuteNonQuery()
                    KONEKCIJA.Close()


                    Me.NAPUNI_KARTICE()
                    Call Me.SELEKTIRANJE_KARTICE()

                    MsgBox("Uspješno ste izbrisali karticu iz baze podataka" & vbCrLf & _
                                                        "DNEVNO-NOĆNOG TREZORA !", MsgBoxStyle.Information, "INFORMACIJA")



                End If

            End If
        End If


    End Sub

#End Region

#Region "KORISNICI DNT-A = RESET"
    '
    '-----------------------------------------------------------
    '-------------------PRIPREMA ZA DODAVANJE NOVOG KORISNIKA-----------------------
    '-----------------------------------------------------------
    '
    Private Sub BTN_RESET_KORISNIK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_RESET_KORISNIK.Click

        If Me.TabControl1.SelectedIndex = 0 Then
            Me.DGV_KORISNICI.ClearSelection()
        ElseIf Me.TabControl1.SelectedIndex = 1 Then
            For Each c As Control In Me.TabPage2.Controls
                If TypeOf c Is System.Windows.Forms.TextBox Then
                    c.Text = String.Empty
                End If
            Next
            Me.DGV_KARTICE.CurrentRow.Selected = False
        End If

    End Sub
#End Region



#Region "FORMA UNOSA NOVOG KORISNIKA = RESETIRANJE, SELEKTIRANJE"
    Sub RESET_TXT()
        For Each c As Control In Me.TabPage1.Controls
            If TypeOf c Is System.Windows.Forms.TextBox Then
                c.Text = String.Empty
            End If
        Next

    End Sub

    'Private Sub ODABIR_KARTICE(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_KARTICE.MouseClick
    'End Sub

    Private Sub KorisniciKarticaPromjenaSelekta(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_KARTICE.SelectionChanged
        Call SELEKTIRANJE_KARTICE()
    End Sub

    Sub SELEKTIRANJE_KARTICE()
        If Me.KARTICE.Rows.Count > 0 And DGV_KARTICE.SelectedRows.Count > 0 Then
            Me.TXT_BROJ_KARTICE.Text = Me.DGV_KARTICE.Rows(Me.DGV_KARTICE.SelectedRows(0).Index).Cells(0).Value.ToString
            Me.TXT_BROJ_UGOVORA.Text = Me.DGV_KARTICE.Rows(Me.DGV_KARTICE.SelectedRows(0).Index).Cells(1).Value.ToString
            Me.DATUM1.Text = Me.DGV_KARTICE.Rows(Me.DGV_KARTICE.SelectedRows(0).Index).Cells(2).Value.ToString
        Else
            Me.TXT_BROJ_KARTICE.Text = ""
            Me.TXT_BROJ_UGOVORA.Text = ""
            Me.DATUM1.Value = Now
        End If
    End Sub


    'ODABIR KORISNIKA ZA BRISANJE MIŠEM U DATAGRIDVIEW-U...

    'Private Sub ODABIR_KORISNIKA_ZA_BRISANJE(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_KORISNICI.MouseClick
    'End Sub

    Sub SELEKTIRANJE_KORISNIKA()

        If Me.DGV_KORISNICI.Rows.Count > 0 And Me.DGV_KORISNICI.SelectedRows.Count > 0 Then
            'SELEKTIRANJE KORISNIKA
            Me.TXT_IME.Text = Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells(1).Value.ToString()
            Me.TXT_PREZIME.Text = Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells(2).Value.ToString()
            Me.TXT_ULICA.Text = Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells(3).Value.ToString()
            Me.TXT_KUCNI_BROJ.Text = Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells(4).Value.ToString()
            Me.TXT_GRAD_MJESTO.Text = Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells(5).Value.ToString()
            Me.TXT_TELEFON.Text = Me.DGV_KORISNICI.Rows(Me.DGV_KORISNICI.SelectedRows(0).Index).Cells(6).Value.ToString()

            Me.NAPUNI_KARTICE()
        Else
            For Each c As Control In Me.TabPage1.Controls
                If TypeOf c Is System.Windows.Forms.TextBox Then
                    c.Text = String.Empty
                End If
            Next
        End If
    End Sub




#End Region

#Region "PREGLEDAVANJE UPISA PODATAKA U FORMU UNOSA KORISNKA"
    '
    '-----------------OVO SE DESI KAD KONTRLA IZGUBI FOKUS , ONDA SE PROVJERI SADRŽAJ 
    '-----------------TEXTBOX KONTROLE,AKO SU VELIKA SLOVA ONDA IH PRETVORI U MALA--------
    '
    Dim INT As Integer
    Private Sub LOST_FOCUS(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_IME.LostFocus, TXT_PREZIME.LostFocus, TXT_GRAD_MJESTO.LostFocus, TXT_ULICA.LostFocus
        TXT_IME.Text = (StrConv(TXT_IME.Text, VbStrConv.ProperCase))
        TXT_PREZIME.Text = (StrConv(TXT_PREZIME.Text, VbStrConv.ProperCase))
        TXT_ULICA.Text = (StrConv(TXT_ULICA.Text, VbStrConv.ProperCase))
        TXT_GRAD_MJESTO.Text = (StrConv(TXT_GRAD_MJESTO.Text, VbStrConv.ProperCase))
    End Sub


    '
    Private Sub PROVJERA_UNOSA_KARTICE(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_BROJ_KARTICE.KeyPress
        'Na keyPres vidi dali korisnik unosi brojeve
        'ako su karakteri manji od 48 a veci od 57 tada nisu brojevi
        If e.KeyChar < Microsoft.VisualBasic.ChrW(48) OrElse e.KeyChar > Microsoft.VisualBasic.ChrW(57) Then
            'uz brojeve dozvoli unos Backspace tipke (brisanje)
            If e.KeyChar <> Microsoft.VisualBasic.ChrW(8) And e.KeyChar <> Microsoft.VisualBasic.ChrW(9) Then
                'ako karakteri nisu brojevi i backspace
                'zaustavi daljni usnos
                e.Handled = True

                TXT_BROJ_KARTICE.BackColor = Color.Red

                INT = MsgBox("Za BROJ KARTICE dozvoljeno je unosti samo brojeve ( 0 - 9 )" & vbCr & _
                                    "Za broj kartice potrebno je unijeti peteroznamenkasti broj sa kartice", MsgBoxStyle.Information, "INFORMACIJA !")

                If INT = MsgBoxResult.Ok Then
                    TXT_BROJ_KARTICE.BackColor = Color.White
                    TXT_BROJ_KARTICE.Focus()
                End If
            End If
        End If
    End Sub

    Private Function Provjera_unosa_naziva1() As Boolean
        If TXT_IME.Text = "" Then
            TXT_IME.BackColor = Color.Red
            I = MsgBox("Niste unijeli IME korisnika DNEVNO-NOĆNOG TREZORA", MsgBoxStyle.Critical, "GREŠKA !")

            If I = MsgBoxResult.Ok Then
                TXT_IME.BackColor = Color.White
                TXT_IME.Focus()
            End If
            Return False
        Else
            Return True
        End If
    End Function
    Private Function Provjera_unosa_kartice() As Boolean
        '
        If TXT_BROJ_KARTICE.Text = "" Then
            TXT_BROJ_KARTICE.BackColor = Color.Red
            I = MsgBox("Niste unijeli BROJ KARTICE korisnika DNEVNO-NOĆNOG TREZORA", MsgBoxStyle.Critical, "GREŠKA !")
            If I = MsgBoxResult.Ok Then
                TXT_BROJ_KARTICE.BackColor = Color.White
                TXT_BROJ_KARTICE.Focus()
            End If
            Return False
            '
        ElseIf TXT_BROJ_KARTICE.TextLength < 5 Then
            '
            'TREBA UNIJETTI PETEROZNAMENKASTI BROJ SA KARTICE
            TXT_BROJ_KARTICE.BackColor = Color.Red
            I = MsgBox("NEISPRAVAN UNOS BROJA KARTICE! Za BROJ KARTICE treba unijeti peteroznamenkasi broj sa kartice", MsgBoxStyle.Critical, "GREŠKA !")
            If I = MsgBoxResult.Ok Then
                TXT_BROJ_KARTICE.BackColor = Color.White
                TXT_BROJ_KARTICE.Focus()
            End If
            Return False
        Else
            Return True
        End If
    End Function
#End Region



#Region "ULAZ U FORMU UNOSA NOVOG KORISNIKA, IZLAZ IZ FORME UNOSA"


    '-----------------------------------------------------------------
    ' BIRANJE ADMINITRATORA DA BAŠ ŽELI RAITI SA KORISNICIMA DNT-A
    '--------------------------------------------------------------
    '
    Private Sub LIBL_KORISNICI_DNT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LIBL_KORISNICI_DNT.LinkClicked
        Try
            Me.DATASET.Clear()
            'TABELA KOJA PRIKAZUJE TRANSAKCIJE SE VIŠE NE VIDI
            DGV_TRANSAKCIJE.Visible = False
            'POKAŽI TABELU U KOJOJ SU SVI KORISNICI DNT-A
            DGV_KORISNICI.Visible = True

            'FORMA ZA UNOS KORISNIKA
            GRB_KORISNICI_DNT.Visible = True


            'DISABLE LINKA KOJI VODI NA KORISNIKE DNT-A!!!
            LIBL_KORISNICI_DNT.Enabled = False
            'GRUPBOX U KOJEM SE BIRAJU TRANSAKCIJE POKAZUJEM
            GRB_TRANSAKCIJE.Enabled = False
            Me.ControlBox = False
            '
            'U STARTU JE OTVOREN PRVI TAB
            Me.TabControl1.SelectedTab = Me.TabPage1

            NAPUNI_KORISNIK()
            SELEKTIRANJE_KARTICE()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text)
        End Try
    End Sub
    '
    '-----------------------------------------------------------------
    ' IZLAZ IZ FORME UNOSA, BRISANJE I MODIFICIRANJA KORISNIKA
    '--------------------------------------------------------------
    '
    Private Sub BTN_IZLAZ_KORISNICI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_IZLAZ_KORISNICI.Click

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        '
        '*********KAD IZLAZIM IZ FORME RESETIRAM JE**********
        '****************************************************
        'Call BTN_RESET_CLICK(sender, e)



        '
        'IZBRIŠI TABELU KOJA PRIKAZUJE KORISNIKE DNT-A
        DGV_KORISNICI.Visible = False
        'GROUP-BOX ZA UNOS, MODIFIKACIJU, BRISANJE KORISNIKA SE VIŠE NE VIDI
        GRB_KORISNICI_DNT.Visible = False
        '
        '!!!!PUNI DATASET TRANSAKCIJE SA PODACIMA!!!
        Me.DATASET.Clear()
        DGV_TRANSAKCIJE.Visible = True
        'DEFULT (NAPUNI TABLICU SA NOVIM PODACIMA)
        Call NAPUNI_TRANSAKCIJE()
        '
        '-------------------------------
        'POSTAVLJANJE DA JE GROUP BOX ADMINISTRACIJA , DA SE NE VIDI LINK ODABIRA 
        GRB_ADMINISTRACIJA.Height = 85
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'TU JOŠ IDE RESET MASKED TEXT BOX-A
        '
        'GRUPBOX U KOJEM SE BIRAJU TRANSAKCIJE POKAZUJEM
        GRB_TRANSAKCIJE.Enabled = True
        '
        Me.ControlBox = True
        'ENABLE LINKA KOJI VODI NA KORISNIKE PROGRAMA!!!
        LIBL_KORISNICI_DNT.Enabled = True

        txtPrezimeFilter.Text = String.Empty
        txtImeFilter.Text = String.Empty

    End Sub
#End Region

#Region "TIMER ,  STATISTIKA, ODABIR PRETRAŽIVANJA, PRINTANJE TRANSAKCIJA"

    Private Sub BTN_PRINTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_PRINTER.Click
        Try
            ' Create a new instance of Margins with one inch margins.
            Dim margins As New Margins(50, 50, 100, 200)
            PrintDocument1.DefaultPageSettings.Margins = margins

            'POKAŽI DIALOG DA KORISNIK MOŽE ODABRATI PRINTER I BROJ KOPIJA
            PrintDialog1.Document = PrintDocument1
            If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

            ' Print the document.
            PrintDocument1.Print()

            'Dim ppvw As PrintPreviewDialog
            'ppvw = New PrintPreviewDialog
            'ppvw.WindowState = FormWindowState.Normal
            'ppvw.StartPosition = FormStartPosition.CenterScreen
            'ppvw.Height = 720
            'ppvw.Width = 800
            'ppvw.Text = "Pregled ispisa"
            'ppvw.Document = PrintDocument1
            'ppvw.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text)
        End Try

    End Sub



    '
    '
    '!!!!!!!!!!!!!!!!!!!!!!!IZLAZ IZ FORME STATISTIKE!!!!!!!!!!!!!!!!
    '
    '

    Private Sub BTN_IZLAZ_STATISTIKA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_IZLAZ_STATISTIKA.Click

        Call NAPUNI_TRANSAKCIJE()

        GRB_ODABIR_UZ_UVIJET.Visible = False
        DGV_TRANSAKCIJE.Height = Me.DGV_TRANSAKCIJE.Height + 155


        GRB_POCETNO_VRIJEME.Visible = True
        GRB_ZAVRSNO_VRIJEME.Visible = True
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'JER KAD RADI SA KORISNICIMA NIJE POTREBNO DA RADI SA TANSAKCIJAMA
        GRB_TRANSAKCIJE.Enabled = True


        Me.ControlBox = True

        GRB_ODABIR_UZ_UVIJET.Text = "Pretraživanje uz uvijet"
        '
        Me.GRB_TRANSAKCIJE.Enabled = True
        Me.GRB_ADMINISTRACIJA.Enabled = True
    End Sub












    '***********************************************************************************************************
    'OVO SE DESI KAD KORISNIK STISNE DUGME PRETRAŽI
    '***********************************************************************************************************


    Private Sub BTN_PRETRAZI_UZ_UVIJET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_PRETRAZI_UZ_UVIJET.Click
        Try
            Me.TRANSAKCIJE.Clear()

            KONEKCIJA.Open()

            Dim cmd As New StringBuilder()
            cmd.Append("SELECT dntt.kartica, dntk.ime, dntk.prezime, dntt.dolazak, dntt.vrecica, dntt.odlazak, dntt.trezor ")
            cmd.Append("FROM (Kartice k ")
            cmd.Append("INNER JOIN DNTKorisnici dntk ON k.VlasnikID = dntk.ID) ")
            cmd.Append("INNER JOIN DNTTransakcije dntt ON k.Broj = dntt.kartica  ")
            cmd.Append("WHERE dntt.dolazak BETWEEN ? AND ? ")
            cmd.Append("ORDER BY dntt.dolazak DESC ")

            Dim komanda As New OleDb.OleDbCommand(cmd.ToString(), KONEKCIJA)
            komanda.Parameters.Add("@DatumOd", OleDb.OleDbType.Date).Value = DTP_POCETNI_DATUM.Value()
            komanda.Parameters.Add("@DatumDo", OleDb.OleDbType.Date).Value = DTP_ZAVRSNI_DATUM.Value()

            Dim ADAPTER As New System.Data.OleDb.OleDbDataAdapter(komanda)
            ADAPTER.Fill(Me.TRANSAKCIJE)
            KONEKCIJA.Close()

            If Me.TRANSAKCIJE.Rows.Count = 0 Then
                '-------------------------------------------------------
                'PORUKA O GRESCI UVIJET NIJE DAO REZULTATE
                '
                MsgBox("Uz vaš uvijet nije pronađena niti jedna transakcija, pokušajte ponovno! ", MsgBoxStyle.Exclamation, "OPREZ !")
                BTN_PRINTER.Visible = False
            Else
                BTN_PRINTER.Visible = True
                MsgBox("Završeno pretraživanje! ", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text)
        End Try
    End Sub

#End Region

#Region "ISPIS PORUKA"


    Private Sub ISPISUJ_SLOVA_LCD(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMER_SLOVA.Tick
        If My.Settings.KoristiLcd Then
            Try

                If SLOVO_UVODNE_PORUKE = 1 Then
                    brisi_lcd()
                    vertical_lcd()
                    Kursor_Pozicija(1, 2)
                End If


                Dim KURSOR_POZ_CHAR As Char() = {GetChar(My.Settings.UvodnaPoruka, SLOVO_UVODNE_PORUKE)}
                RS232_LCD.Write(KURSOR_POZ_CHAR, 0, 1)
                SLOVO_UVODNE_PORUKE += 1

                If (SLOVO_UVODNE_PORUKE = My.Settings.UvodnaPoruka.Length + 1) Then SLOVO_UVODNE_PORUKE = 1


            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text)
            End Try
        End If
    End Sub

    Sub PORUKA(ByVal TEXT As String)
        If My.Settings.KoristiLcd Then
            TIMER_SLOVA.Stop()
            SLOVO_UVODNE_PORUKE = 1
            brisi_lcd()
            Kursor_Pozicija(1, 1)
            RS232_LCD.Write(TEXT)
            Me.TIMER_PORUKA.Start()
        End If
    End Sub
    Private Sub ZATVORI_PORUKU_(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMER_PORUKA.Tick
        Me.TIMER_PORUKA.Stop()
        Module1.uvodna_poruka()
    End Sub
#End Region

#Region "PRINTANJE TREZORSKE KNJIGE"

    Private Sub LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE.LinkClicked
        Try

            Me.DATASET.Tables("TRANSAKCIJE").Clear()
            'POKAŽI GROUP BOX NA KOJEM SE ZADAJE UVIJET ZA PRETRAGU TRANSAKCIJA
            GRB_ODABIR_UZ_UVIJET.Visible = True
            DGV_TRANSAKCIJE.Height = Me.DGV_TRANSAKCIJE.Height - 155
            '
            'OVO JE DISABLE SVEGA DOK RADIM NEŠTO DRUGO
            '
            Me.GRB_TRANSAKCIJE.Enabled = False
            Me.GRB_ADMINISTRACIJA.Enabled = False
            Me.ControlBox = False

            DTP_ZAVRSNI_DATUM.Value = Now
            DTP_POCETNI_DATUM.Value = Now


            DTP_POCETNI_DATUM.MaxDate = DTP_ZAVRSNI_DATUM.Value
            DTP_ZAVRSNI_DATUM.MinDate = DTP_POCETNI_DATUM.Value

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub LIBL_PRINT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LIBL_PRINT.LinkClicked
        Try
            ' Create a new instance of Margins with one inch margins.
            PrintDocument1.DefaultPageSettings.Margins = New Margins(50, 50, 100, 200)

            'POKAŽI DIALOG DA KORISNIK MOŽE ODABRATI PRINTER I BROJ KOPIJA
            PrintDialog1.Document = PrintDocument1
            If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ' Print the document.
                PrintDocument1.Print()
            End If


            Dim INT As Integer
            INT = MsgBox("Želite izvaditi sigurnosne vrečice iz trezora ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "OPREZ !")

            If INT = MsgBoxResult.Yes Then

                KONEKCIJA.Open()

                'U BAZI OKREČEM BITOVE KOJI OBILJEŽAVAJU DA SU VREČICE U TREZORU
                Dim NAREDBA_1 As New System.Data.OleDb.OleDbCommand("UPDATE DNTTransakcije Set Trezor = false", KONEKCIJA)
                Dim recordsAffected_1 As Int32 = NAREDBA_1.ExecuteNonQuery()

                Dim NAREDBA3 As New System.Data.OleDb.OleDbCommand("UPDATE SISTEM Set TREZOR_PRAZAN_VRIJEME = '" & Now & "' WHERE ID = 1", KONEKCIJA)
                Dim VRATI_NATRAG1 As Int32 = NAREDBA3.ExecuteNonQuery()
                '
                KONEKCIJA.Close()

                NAPUNI_TRANSAKCIJE()

                'PRIKAZIVANJE KOLIKO JE VREČICA UBAČENO NAKON PRAŽNJENJA TREZORA
                Me.LABELA_VRECICE_TREZOR()

                '
                'POSTAVLJANJE INFORMACIJE KAD JE ZANJI PUT PRAŽNJEN TREZOR
                'U OBLIKU PAMČENJA ZADNJE "id-A"
                LBL_PRAZNJENJE_TREZORA.Text = Now

                MsgBox("Uspješno ste ispraznuli trezor", MsgBoxStyle.Information, "INFORMACIJA")
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text)
        End Try

    End Sub




    Private Shared NewPage As Boolean            ' Indicates if a new page reached 
    Private Shared PageNo As Int16 = 1              ' Number of pages to print
    Private Shared RowPos As Int16               ' Position of currently printing row 
    Private Shared RowPos1 As Int16



    Private Sub STRANICA_ZA_PRINTANJE(ByVal sender As System.Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim yPos As Integer
        Dim BROJAC As Integer = 0

        'FORMATIRANJE STRINGA
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.LineAlignment = StringAlignment.Center
        format1.Alignment = StringAlignment.Center

        'PRINTANJE NASLOVA
        ev.Graphics.DrawString("Trezorska knjiga", New Font("Arial", 16), New SolidBrush(Color.Black), New PointF(ev.MarginBounds.Left, 30))

        'PRINTANJE VREMENA IZDAVANJA TREZORSE KNJIGE
        ev.Graphics.DrawString("Vrijeme izdavanja trezorske knjige:" & " " & Now, New Font("Arial", 10), New SolidBrush(Color.Black), New PointF(400, 30))


        'PRINTANJE BROJA UBAČENIH VREČICA
        Dim BROJ_VREC As Int16 = 0
        For BROJAC = 0 To Me.DATASET.Tables("TRANSAKCIJE").Rows.Count - 1
            If Me.DATASET.Tables("TRANSAKCIJE").Rows(BROJAC).Item("vrecica").ToString <> "" Then BROJ_VREC += Convert.ToInt16(Me.DATASET.Tables("TRANSAKCIJE").Rows(BROJAC).Item("vrecica"))
        Next
        ev.Graphics.DrawString("Ukupan broj ubačenih vrećica:" & " " & BROJ_VREC, New Font("Arial", 10), New SolidBrush(Color.Black), New PointF(400, 60))


        'PRINTANJE KOMISIJE ZA PREUZIMANJE 
        ev.Graphics.DrawString("Komisija koja je preuzela trezorske vrećice:", New Font("Arial", 10), New SolidBrush(Color.Black), _
        New PointF(ev.MarginBounds.Left + ev.MarginBounds.Width / 2 + 20, ev.MarginBounds.Top + ev.MarginBounds.Height + 30))

        'PRINTANJE KOMISIJE ZA IZDAVAVANJE
        ev.Graphics.DrawString("Komisija koja je izdala trezorske vrećice:", New Font("Arial", 10), New SolidBrush(Color.Black), _
        New PointF(ev.MarginBounds.Left + 20, ev.MarginBounds.Top + ev.MarginBounds.Height + 30))


        yPos = 25
        BROJAC = 0
        While BROJAC <= 3

            'PRINTANJE KOMISIJE ZA IZDAVAVANJE
            ev.Graphics.DrawString(BROJAC & ".", New Font("Arial", 10), New SolidBrush(Color.Black), _
            New PointF(ev.MarginBounds.Left + 25, ev.MarginBounds.Top + ev.MarginBounds.Height + 30 + yPos))

            'PRINTANJE KOMISIJE ZA PREUZIMANJE 
            ev.Graphics.DrawString(BROJAC & ".", New Font("Arial", 10), New SolidBrush(Color.Black), _
            New PointF(ev.MarginBounds.Left + ev.MarginBounds.Width / 2 + 25, ev.MarginBounds.Top + ev.MarginBounds.Height + 30 + yPos))
            yPos += 20
            BROJAC += 1
        End While

        ' nacrtaj glavni okvir
        'ev.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(ev.MarginBounds.Left, ev.MarginBounds.Top, ev.MarginBounds.Width, ev.MarginBounds.Height))


        'nacrtaj pravokutnik u kojem su nazivi kolona BROJ KARTICE
        ev.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(ev.MarginBounds.Left, ev.MarginBounds.Top, 100, 25))
        ev.Graphics.DrawString("Broj kartice", New Font("Arial", 11), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left, ev.MarginBounds.Top, 100, 25))

        'nacrtaj pravokutnik u kojem su nazivi kolona IME
        ev.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(ev.MarginBounds.Left + 100, ev.MarginBounds.Top, 150, 25))
        ev.Graphics.DrawString("Ime", New Font("Arial", 11), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 100, ev.MarginBounds.Top, 100, 25))

        'nacrtaj pravokutnik u kojem su nazivi kolona PREZIME
        ev.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(ev.MarginBounds.Left + 250, ev.MarginBounds.Top, 150, 25))
        ev.Graphics.DrawString("Prezime", New Font("Arial", 11), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 250, ev.MarginBounds.Top, 150, 25))

        'nacrtaj pravokutnik u kojem su nazivi kolona VRIJEME DOLASKA
        ev.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(ev.MarginBounds.Left + 400, ev.MarginBounds.Top, 130, 25))
        ev.Graphics.DrawString("Vrijeme dolaska", New Font("Arial", 11), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 400, ev.MarginBounds.Top, 130, 25))

        'nacrtaj pravokutnik u kojem su nazivi kolona BROJ VRECICA
        ev.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(ev.MarginBounds.Left + 530, ev.MarginBounds.Top, 60, 25))
        ev.Graphics.DrawString("Broj vr.", New Font("Arial", 11), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 530, ev.MarginBounds.Top, 60, 25))

        'nacrtaj pravokutnik u kojem su nazivi kolona VRIJEME ODLASKA
        ev.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(ev.MarginBounds.Left + 590, ev.MarginBounds.Top, ev.MarginBounds.Width - 605, 25))
        ev.Graphics.DrawString("Vrijeme odlaska", New Font("Arial", 11), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 590, ev.MarginBounds.Top, ev.MarginBounds.Width - 605, 25))

        ev.HasMorePages = False
        yPos = 25
        If PageNo = 1 Then
            RowPos1 = 0
        End If
        RowPos = 0
        For BROJAC = RowPos1 To Me.DATASET.Tables("TRANSAKCIJE").Rows.Count - 1
            'nacrtaj pravokutnik u kojem su nazivi kolona BROJ KARTICE
            ev.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(ev.MarginBounds.Left, ev.MarginBounds.Top + yPos, 100, 25))
            ev.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(ev.MarginBounds.Left + 100, ev.MarginBounds.Top + yPos, 150, 25))
            ev.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(ev.MarginBounds.Left + 250, ev.MarginBounds.Top + yPos, 150, 25))
            ev.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(ev.MarginBounds.Left + 400, ev.MarginBounds.Top + yPos, 130, 25))
            ev.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(ev.MarginBounds.Left + 530, ev.MarginBounds.Top + yPos, 60, 25))
            ev.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(ev.MarginBounds.Left + 590, ev.MarginBounds.Top + yPos, ev.MarginBounds.Width - 605, 25))



            ev.Graphics.DrawString(Me.DATASET.Tables("TRANSAKCIJE").Rows(BROJAC).Item(0).ToString, New Font("Arial", 7.5), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left, ev.MarginBounds.Top + yPos, 100, 25), format1)
            ev.Graphics.DrawString(Me.DATASET.Tables("TRANSAKCIJE").Rows(BROJAC).Item(1).ToString, New Font("Arial", 7.5), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 100, ev.MarginBounds.Top + yPos, 150, 25), format1)
            ev.Graphics.DrawString(Me.DATASET.Tables("TRANSAKCIJE").Rows(BROJAC).Item(2).ToString, New Font("Arial", 7.5), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 250, ev.MarginBounds.Top + yPos, 150, 25), format1)
            ev.Graphics.DrawString(Me.DATASET.Tables("TRANSAKCIJE").Rows(BROJAC).Item(3).ToString, New Font("Arial", 7.5), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 400, ev.MarginBounds.Top + yPos, 130, 25), format1)
            ev.Graphics.DrawString(Me.DATASET.Tables("TRANSAKCIJE").Rows(BROJAC).Item(4).ToString, New Font("Arial", 7.5), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 530, ev.MarginBounds.Top + yPos, 60, 25), format1)
            ev.Graphics.DrawString(Me.DATASET.Tables("TRANSAKCIJE").Rows(BROJAC).Item(5).ToString, New Font("Arial", 7.5), New SolidBrush(Color.Black), New RectangleF(ev.MarginBounds.Left + 590, ev.MarginBounds.Top + yPos, ev.MarginBounds.Width - 605, 25), format1)

            RowPos = RowPos + 1
            yPos = yPos + 25

            If RowPos * 25 >= ev.MarginBounds.Height - 50 Then
                RowPos1 = BROJAC
                PageNo = PageNo + 1
                ev.HasMorePages = True
                Exit Sub
            End If
        Next

        'VRACAM NA POCETAK
        PageNo = 1

    End Sub



#End Region

#Region "TIMERI OTVORENA VRATA, UVUČEN ZASUN"

    'OVAJ TIMER SAMO MJERI VRIJEME I JAVLJA MIKRAČU DA OTPUSTI ZASUN
    Private Sub ZASUN_OTPUSTI(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMER_ZASUN_UVUCEN.Tick
        Me.TIMER_ZASUN_UVUCEN.Stop()
        Me.Enabled = True
        RS232_MIKRO.Write(Chr(17)) 'zatvori vrata
        Module1.uvodna_poruka()
    End Sub

    Private Sub ALARM_VRATA_OTVORENA(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIME_VRATA_OTVORENA.Tick
        Me.TIME_VRATA_OTVORENA.Stop()

        FRM_PORUKA_VRATA1.Show()

        'KONEKCIJA.Open()
        'Dim NAREDBA As New System.Data.OleDb.OleDbCommand("INSERT INTO ALARM" & _
        '"(dolazak_OT, otvoreno) Values ('" & VRIJEME_DOLASKA & "','" & Now & "')", KONEKCIJA)
        'Dim recordsAffected As Int32 = NAREDBA.ExecuteNonQuery()
        'KONEKCIJA.Close()
        '
        RS232_MIKRO.Write(Chr(18)) 'zvučni signal koji obilježava da se zatvore varta
        LCD_PORUKA("Molimo da zatvorite vrata...")
    End Sub

#End Region

#Region "PRIKAZ SERVISA"
    Private Sub OBRADA_F1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = Keys.F1 Then
            FRM_SERVIS.Show()
        End If
    End Sub
#End Region

    Private Sub PromjenjenDatumOd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_POCETNI_DATUM.ValueChanged
        DTP_ZAVRSNI_DATUM.MinDate = DTP_POCETNI_DATUM.Value
    End Sub

    Private Sub PromjenjenDatumDo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_ZAVRSNI_DATUM.ValueChanged
        DTP_POCETNI_DATUM.MaxDate = DTP_ZAVRSNI_DATUM.Value
    End Sub

    Private Sub ImeFilter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrezimeFilter.TextChanged, txtImeFilter.TextChanged
        ADAPTER_KORISNICI.SelectCommand.CommandText = "SELECT * FROM DNTKorisnici WHERE Ime LIKE '%" & txtImeFilter.Text & "%' AND Prezime LIKE '%" & txtPrezimeFilter.Text & "%'  ORDER BY ime"
        NAPUNI_KORISNIK()
    End Sub

    Private Sub KorisniciPromjenaSelekta(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_KORISNICI.SelectionChanged
        Call SELEKTIRANJE_KORISNIKA()
    End Sub
End Class