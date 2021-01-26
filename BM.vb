Public Class BM
    Dim strsql As String
    Dim info As String
    Private _idbarangmasuk As System.Int32
    Private _nomor_faktur As System.String
    Private _kode_pemasok As System.String
    Private _tanggal As System.DateTime
    Private _penerima As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property nomor_faktur()
        Get
            Return _nomor_faktur
        End Get
        Set(ByVal value)
            _nomor_faktur = value
        End Set
    End Property
    Public Property kode_pemasok()
        Get
            Return _kode_pemasok
        End Get
        Set(ByVal value)
            _kode_pemasok = value
        End Set
    End Property
    Public Property tanggal()
        Get
            Return _tanggal
        End Get
        Set(ByVal value)
            _tanggal = value
        End Set
    End Property
    Public Property penerima()
        Get
            Return _penerima
        End Get
        Set(ByVal value)
            _penerima = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (barangmasuk_baru = True) Then
            strsql = "Insert into barangMasuk(nomor_faktur,kode_pemasok,tanggal,penerima) values ('" & _nomor_faktur & "','" & _kode_pemasok & "','" & _tanggal & "','" & _penerima & "')"
            info = "INSERT"
        Else
            strsql = "update barangMasuk set nomor_faktur='" & _nomor_faktur & "', kode_pemasok='" & _kode_pemasok & "', tanggal='" & _tanggal & "', penerima='" & _penerima & "' where nomor_faktur='" & _nomor_faktur & "'"
            info = "UPDATE"
        End If
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        Try
            mycommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub CaribarangMasuk(ByVal snomor_faktur As String)
        DBConnect()
        strsql = "SELECT * FROM barangMasuk WHERE nomor_faktur='" & snomor_faktur & "'"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        DR = mycommand.ExecuteReader
        If (DR.HasRows = True) Then
            barangmasuk_baru = False
            DR.Read()
            nomor_faktur = Convert.ToString((DR("nomor_faktur")))
            kode_pemasok = Convert.ToString((DR("kode_pemasok")))
            tanggal = Convert.ToString((DR("tanggal")))
            penerima = Convert.ToString((DR("penerima")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            barangmasuk_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal snomor_faktur As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM barangMasuk WHERE nomor_faktur='" & snomor_faktur & "'"
        info = "DELETE"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        Try
            mycommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM barangMasuk"
            mycommand.Connection = conn
            mycommand.CommandText = strsql
            mydata.Clear()
            myadapter.SelectCommand = mycommand
            myadapter.Fill(mydata)
            With dg
                .DataSource = mydata
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class

