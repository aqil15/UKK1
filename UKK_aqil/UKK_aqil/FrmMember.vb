Imports System.Data.SqlClient
Public Class FrmMember
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand

    Sub tampildata()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_masyarakat"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rd)
        DataGridView1.DataSource = dt
        cn.Close()

        DataGridView1.Columns(0).HeaderText = "Id Member"
        DataGridView1.Columns(1).HeaderText = "Nama Member"
        DataGridView1.Columns(2).HeaderText = "Telp"
        DataGridView1.Columns(3).HeaderText = "Alamat"

        DataGridView1.Columns(0).Width = 275
        DataGridView1.Columns(1).Width = 275
        DataGridView1.Columns(2).Width = 275
        DataGridView1.Columns(3).Width = 277
    End Sub
    Private Sub FrmMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn.ConnectionString = "Data Source=DESKTOP-9SSHS8T\SQLEXPRESS;Initial Catalog=db_UKK_aqil;Integrated Security=True"
        tampildata()
        txtid.Enabled = False
    End Sub

    Sub bersih()
        txtid.Text = ""
        txtnama.Text = ""
        txttelp.Text = ""
        txtalamat.Text = ""
    End Sub

    Sub kodeotomatis()
        Dim kodeauto As Single
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT COUNT(*) AS id_user FROM tb_masyarakat"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        While rd.Read
            kodeauto = Val(rd.Item("id_user").ToString) + 1
        End While
        Select Case Len(Trim(kodeauto))
            Case 1 : txtid.Text = "U-00" + Trim(Str(kodeauto))
            Case 2 : txtid.Text = "U-0" + Trim(Str(kodeauto))
            Case 3 : txtid.Text = "U-" + Trim(Str(kodeauto))
        End Select
        rd.Close()
        cn.Close()
    End Sub


    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kodeotomatis()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID Member wajib diisi, tidak boleh dikosongkan")
        ElseIf txtnama.Text = "" Then
            MessageBox.Show("Nama Member wajib diisi, tidak boleh dikosongkan")
        ElseIf txttelp.Text = "" Then
            MessageBox.Show("Telp wajib diisi, tidak boleh dikosongkan")
        ElseIf txtalamat.Text = "" Then
            MessageBox.Show("Alamat wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtnama.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "INSERT INTO tb_masyarakat VALUES ('" & txtid.Text & "','" & txtnama.Text & "','" & txttelp.Text & "','" & txtalamat.Text & "') "
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data Member Berhasil Tersimpan", MsgBoxStyle.Information)
            tampildata()
            txtid.Enabled = False
        End If
    End Sub

    Private Sub btnubah_Click(sender As Object, e As EventArgs) Handles btnubah.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID Member wajib diisi, tidak boleh dikosongkan")
        ElseIf txtnama.Text = "" Then
            MessageBox.Show("Nama Member wajib diisi, tidak boleh dikosongkan")
        ElseIf txttelp.Text = "" Then
            MessageBox.Show("Telp wajib diisi, tidak boleh dikosongkan")
        ElseIf txtalamat.Text = "" Then
            MessageBox.Show("Alamat wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtnama.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "UPDATE tb_masyarakat SET nama_lengkap ='" & txtnama.Text & "', telp ='" & txttelp.Text & "' , alamat ='" & txtalamat.Text & "' WHERE id_user ='" & txtid.Text & "'"
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data Member Berhasil Di ubah", MsgBoxStyle.Information)
            tampildata()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        txtid.Text = DataGridView1.SelectedCells(0).Value
        txtnama.Text = DataGridView1.SelectedCells(1).Value
        txttelp.Text = DataGridView1.SelectedCells(2).Value
        txtalamat.Text = DataGridView1.SelectedCells(3).Value
    End Sub


    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim baris As Integer
        Dim id As String

        baris = DataGridView1.CurrentCell.RowIndex
        id = DataGridView1(0, baris).Value.ToString

        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "DELETE FROM tb_masyarakat WHERE id_user = '" + id + "'"
        cmd.ExecuteNonQuery()
        cn.Close()
        MsgBox("Data Member Berhasil Terhapus", MsgBoxStyle.Information)
        tampildata()
        bersih()

    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        bersih()

    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_masyarakat WHERE id_user LIKE '%" & txtcari.Text & "%' OR nama_lengkap LIKE '%" & txtcari.Text & "%' OR telp LIKE '%" & txtcari.Text & "%' OR alamat LIKE '%" & txtcari.Text & "%'"

        Dim rd As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rd)
        DataGridView1.DataSource = dt
        cn.Close()
    End Sub

  
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()

    End Sub

    Private Sub btnlap_Click(sender As Object, e As EventArgs) Handles btnlap.Click
        Dim lapmember As New FrmLapMember
        lapmember.TopLevel = False
        FrmMenu.panel_menu.Controls.Add(lapmember)
        lapmember.Show()
    End Sub
End Class