Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports DevComponents.DotNetBar
Module MyModule
    Public mycommand As New System.Data.SqlClient.SqlCommand
    Public myadapter As New System.Data.SqlClient.SqlDataAdapter
    Public mydata As New DataTable
    Public DR As System.Data.SqlClient.SqlDataReader
    Public SQL As String
    Public conn As New SqlConnection
    Public cn As New Connection


    Public cldBM As New BarangMasuk
    Public cldBK As New BarangKeluar
    'Tabel barang masuk
    '-------------------------------
    Public barangmasuk_baru As Boolean
    Public oBmas As New BM
    '--------------------------------

    'Tabel barang keluar
    '-------------------------------
    Public barangkeluar_baru As Boolean
    Public oBkel As New Bk
    '--------------------------------

    'Tabel User
    '--------------------------------
    Public user_baru As Boolean
    Public ouser As New User
    '--------------------------------

    Public login_valid As Boolean
    Public R As Random = New Random
    Public TotalTab As Integer = 0
    Public x As Integer
    Public Sub bikinMenu(ByVal Child As Form, ByVal mytab As TabControl, ByVal sTitle As String)
        Dim newTab As DevComponents.DotNetBar.TabItem = mytab.CreateTab(sTitle)
        Dim panel As DevComponents.DotNetBar.TabControlPanel = DirectCast(newTab.AttachedControl, Panel)


        Child.TopLevel = False
        Child.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Child.Dock = DockStyle.Fill
        Child.Show()
        panel.Controls.Add(Child)

    End Sub
    Public Function getTabIndex(ByVal mytab As TabControl, ByVal sCari As String)
        Dim i As Integer
        For i = 0 To TotalTab - 1
            If (mytab.Tabs(i).Text = sCari) Then

                Exit For
            End If
        Next
        getTabIndex = i
    End Function


    Public Sub DBConnect()
        cn.DataSource = "LAPTOP-5IE33GJU\SQLEXPRESS"
        cn.DatabaseName = "Gudang"
        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function
End Module