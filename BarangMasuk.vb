Public Class BarangMasuk
    Public mycommand As New System.Data.SqlClient.SqlCommand
    Public myadapter As New System.Data.SqlClient.SqlDataAdapter
    Public mydata As New DataTable

    Property Kode_pemasok As Object

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveBarangMasuk()
        GetData()

    End Sub
    Private Sub txtkodesupplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkodesupplier.KeyDown
        If (e.KeyCode = Keys.Enter And txtFaktur.Text <> "") Then
            oBmas.CaribarangMasuk(txtKodeSupplier.Text)
            txtPenerima.Text = penerima
            TampilData()
        Else
            MessageBox.Show("Data Tidak Di temukan")
        End If
    End Sub
    Private Sub ClearEntry()

        txtkodesupplier.Clear()
        txtFaktur.Clear()
        txtPenerima.Clear()
        txtkodesupplier.Focus()
    End Sub
    Private Sub TampilData()

        txtKodeSupplier.Text = kode_pemasok
        txtFaktur.Text = oBmas.nomor_faktur
        txtPenerima.Text = penerima()
    End Sub
    Private Sub SaveBarangMasuk()
        barangmasuk_baru = True
        oBmas.Simpan()

        txtKodeSupplier.Text = oBmas.kode_pemasok
        txtFaktur.Text = oBmas.nomor_faktur
        txtPenerima.Text = oBmas.penerima
    End Sub
    Private Sub GetData()
        oBmas.getAllData(DataGridView1)
    End Sub
    Private Sub getAllData(dataGridView As DataGridView)
        Throw New NotImplementedException
    End Sub

    Private Function Faktur() As String
        Throw New NotImplementedException
    End Function

    Private Function penerima() As String
        Throw New NotImplementedException
    End Function

   
    Private Sub btnRefresh_Click_1(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        GetData()
    End Sub
    Private Sub BarangMasuk_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub

    Private Sub btnClear_Click_1(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub
    Public Sub reload()
        GetData()

    End Sub
End Class