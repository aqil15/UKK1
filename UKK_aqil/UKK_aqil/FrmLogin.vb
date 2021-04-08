Imports System.Data.SqlClient
Public Class FrmLogin

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    'ini sekrip bersih
    Sub bersih()
        txtuser.Text = ""
        txtpass.Text = ""
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim rd As SqlDataReader

            cn.ConnectionString = "Data Source=DESKTOP-9SSHS8T\SQLEXPRESS;Initial Catalog=db_UKK_aqil;Integrated Security=True"
            cmd.Connection = cn
            cn.Open()
            cmd.CommandText = "SELECT * FROM tb_petugas WHERE username ='" & txtuser.Text & "'AND password ='" & txtpass.Text & "' "
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                FrmMenu.lbadmin.Text = (rd("nama_petugas"))
            End If
            If rd("id_level") = "1" Then
                FrmMenu.Show()
            ElseIf rd("id_level") = "2" Then
                FrmMenu.Label5.Enabled = False
                FrmMenu.Label9.Enabled = False
                FrmMenu.Label11.Enabled = False
                FrmMenu.Label12.Enabled = False
                FrmMenu.Show()
            Else
                MsgBox("Nama Petugas Atau kata sandi tidak tersedia", MsgBoxStyle.Information)
                txtuser.Text = ""
                txtpass.Text = ""
            End If
            Me.Hide()

            rd.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan")
        End Try

        bersih()
    End Sub
End Class