Public Class Barangkeluar
    Public mycommand As New System.Data.SqlClient.SqlCommand
    Public myadapter As New System.Data.SqlClient.SqlDataAdapter
    Public mydata As New DataTable
    Private Sub txtNoBukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoBukti.KeyDown
        If (e.KeyCode = Keys.Enter And txtNoBukti.Text <> "") Then
            oBkel.Caribarangkeluar(txtNoBukti.Text)
            txtSatffToko.Text = oBkel.staff_toko
            txtStaffGudang.Text = oBkel.staff_gudang
        End If
    End Sub
    Private Sub ClearEntry()

        txtSatffToko.Clear()
        txtNoBukti.Clear()
        txtStaffGudang.Clear()
        txtSatffToko.Focus()
    End Sub
    Private Sub TampilData()

        txtSatffToko.Text = oBkel.nomor_bukti
        txtNoBukti.Text = oBkel.staff_toko
        txtStaffGudang.Text = oBkel.staff_gudang
    End Sub
    Private Sub SaveBarangKeluar()
        barangkeluar_baru = True
        oBkel.nomor_bukti = txtNoBukti.Text
        oBkel.staff_toko = txtSatffToko.Text
        oBkel.staff_gudang = txtStaffGudang.Text
    End Sub
    Private Sub GetData()
        oBkel.getAllData(DataGridView1)
    End Sub


    Private Sub txtnomorbukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoBukti.KeyDown
        If (e.KeyCode = Keys.Enter And txtNoBukti.Text <> "") Then
            oBkel.CaribarangKeluar(txtNoBukti.Text)
            txtSatffToko.Text = oBkel.staff_toko
            txtStaffGudang.Text = oBkel.staff_gudang
        Else
            MessageBox.Show("Data Tidak Di temukan")
        End If
    End Sub

    Private Sub frmBarangkeluar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnRefresh_Click_1(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        GetData()
    End Sub

    Private Sub btnClear_Click_1(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        SaveBarangKeluar()
        GetData()

    End Sub
End Class