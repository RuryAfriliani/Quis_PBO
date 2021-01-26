Public Class RibbonGudang

    Private Property menu_barang As Boolean

    Private Sub btnBarangMasuk_Click(sender As System.Object, e As System.EventArgs) Handles btnBarangMasuk.Click
        If (barangmasuk_baru = False) Then
            bikinMenu(cldBM, TabControl1, "Barang Masuk")
            barangmasuk_baru = True
        Else
            x = getTabIndex(TabControl1, "Barang Masuk")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnBarangKeluar_Click(sender As System.Object, e As System.EventArgs) Handles btnBarangKeluar.Click
        If (barangKeluar_baru = False) Then
            bikinMenu(cldBK, TabControl1, "Barang Keluar")
            barangKeluar_baru = True
        Else
            x = getTabIndex(TabControl1, "Barang Keluar")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub
    Private Sub TabControl1_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TabControl1.ControlAdded
        TabControl1.SelectedTabIndex = TotalTab - 1
    End Sub

    Private Sub TabControl1_TabItemClose(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles TabControl1.TabItemClose
        Dim itemToRemove As DevComponents.DotNetBar.TabItem = TabControl1.SelectedTab
        If (TotalTab > 3) Then
            TotalTab = TotalTab - 1
        Else
            TotalTab = 0
        End If
        TabControl1.Tabs.Remove(itemToRemove)
        TabControl1.Controls.Remove(itemToRemove.AttachedControl)
        TabControl1.RecalcLayout()


        If (itemToRemove.ToString = "Barang") Then
            menu_barang = False
        ElseIf (itemToRemove.ToString = "Barang Keluar") Then
            barangkeluar_baru = False
        ElseIf (itemToRemove.ToString = "Barang Masuk") Then
            barangmasuk_baru = False
        Else

        End If
    End Sub

    Private Sub TabControl1_TabItemOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabItemOpen
        If (TotalTab = 0) Then
            TotalTab = TotalTab + 5
        Else
            TotalTab = TotalTab + 1
        End If
    End Sub
    
End Class