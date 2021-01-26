Public Class Login

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        login_valid = ouser.Login(txtUsername.Text, txtPassword.Text)
        If (login_valid = True) Then
            MessageBox.Show("Welcome")
            RibbonGudang.Show()
            Me.Hide()
        Else
            MessageBox.Show("Login Not Valid")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub


End Class
