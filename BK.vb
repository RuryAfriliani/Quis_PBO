Public Class Bk
    Dim strsql As String
    Dim info As String

    Private _nomor_bukti As System.String
    Private _tanggal As System.DateTime
    Private _staff_gudang As System.String
    Private _staff_toko As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property nomor_bukti()
        Get
            Return _nomor_bukti
        End Get
        Set(ByVal value)
            _nomor_bukti = value
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
    Public Property staff_gudang()
        Get
            Return _staff_gudang
        End Get
        Set(ByVal value)
            _staff_gudang = value
        End Set
    End Property
    Public Property staff_toko()
        Get
            Return _staff_toko
        End Get
        Set(ByVal value)
            _staff_toko = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (barangKeluar_baru = True) Then
            strsql = "Insert into barangKeluar(nomor_bukti,tanggal,staff_gudang,staff_toko) values ('" & _nomor_bukti & "','" & _tanggal & "','" & _staff_gudang & "','" & _staff_toko & "')"
            info = "INSERT"
        Else
            strsql = "update barangKeluar set nomor_bukti='" & _nomor_bukti & "', tanggal='" & _tanggal & "', staff_gudang='" & _staff_gudang & "', staff_toko='" & _staff_toko & "' where nomor_bukti='" & _nomor_bukti & "'"
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
    Public Sub CaribarangKeluar(ByVal snomor_bukti As String)
        DBConnect()
        strsql = "SELECT * FROM barangKeluar WHERE nomor_bukti='" & snomor_bukti & "'"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        DR = mycommand.ExecuteReader
        If (DR.HasRows = True) Then
            barangKeluar_baru = False
            DR.Read()
            nomor_bukti = Convert.ToString((DR("nomor_bukti")))
            tanggal = Convert.ToString((DR("tanggal")))
            staff_gudang = Convert.ToString((DR("staff_gudang")))
            staff_toko = Convert.ToString((DR("staff_toko")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            barangKeluar_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal snomor_bukti As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM barangKeluar WHERE nomor_bukti='" & snomor_bukti & "'"
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
            strsql = "SELECT * FROM barangKeluar"
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

