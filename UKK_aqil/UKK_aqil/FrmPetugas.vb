Imports System.Data.SqlClient
Public Class FrmPetugas
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand

    Sub tampildata()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_petugas"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rd)
        DataGridView1.DataSource = dt
        cn.Close()

        DataGridView1.Columns(0).HeaderText = "Id Petugas"
        DataGridView1.Columns(1).HeaderText = "Nama Petugas"
        DataGridView1.Columns(2).HeaderText = "Username"
        DataGridView1.Columns(3).HeaderText = "Password"
        DataGridView1.Columns(4).HeaderText = "ID Hak"

        DataGridView1.Columns(0).Width = 230
        DataGridView1.Columns(1).Width = 230
        DataGridView1.Columns(2).Width = 230
        DataGridView1.Columns(3).Width = 230
        DataGridView1.Columns(4).Width = 230
    End Sub

    Private Sub FrmPetugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn.ConnectionString = "Data Source=DESKTOP-9SSHS8T\SQLEXPRESS;Initial Catalog=db_UKK_aqil;Integrated Security=True"
        tampildata()
        txtid.Enabled = False
        TextBox1.Enabled = False
        auto_hak()
    End Sub

    Sub bersih()
        txtid.Text = ""
        txtnama.Text = ""
        txtuser.Text = ""
        txtpass.Text = ""
        txthak.Text = ""
        TextBox1.Text = ""
    End Sub

    Sub kodeotomatis()
        Dim kodeauto As Single
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT COUNT(*) AS id_petugas FROM tb_petugas"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        While rd.Read
            kodeauto = Val(rd.Item("id_petugas").ToString) + 1
        End While
        Select Case Len(Trim(kodeauto))
            Case 1 : txtid.Text = "P-0" + Trim(Str(kodeauto))
            Case 2 : txtid.Text = "P-" + Trim(Str(kodeauto))
        End Select
        rd.Close()
        cn.Close()
    End Sub

    Sub auto_hak()
        Try
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter("SELECT * FROM tb_hak", cn)
            da.Fill(dt)
            Dim r As DataRow
            txthak.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                txthak.AutoCompleteCustomSource.Add(r.Item(0).ToString)
            Next
        Catch ex As Exception
            cn.Close()
        End Try
    End Sub



    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kodeotomatis()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID Petugas wajib diisi, tidak boleh dikosongkan")
        ElseIf txtnama.Text = "" Then
            MessageBox.Show("Nama Petugas wajib diisi, tidak boleh dikosongkan")
        ElseIf txtuser.Text = "" Then
            MessageBox.Show("Username wajib diisi, tidak boleh dikosongkan")
        ElseIf txtpass.Text = "" Then
            MessageBox.Show("Password wajib diisi, tidak boleh dikosongkan")
        ElseIf txthak.Text = "" Then
            MessageBox.Show("Hak wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtnama.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "INSERT INTO tb_petugas VALUES ('" & txtid.Text & "','" & txtnama.Text & "','" & txtuser.Text & "','" & txtpass.Text & "','" & txthak.Text & "') "
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data Petugas Berhasil Tersimpan", MsgBoxStyle.Information)
            tampildata()
            txtid.Enabled = False
        End If
    End Sub

    Private Sub btnubah_Click(sender As Object, e As EventArgs) Handles btnubah.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID Petugas wajib diisi, tidak boleh dikosongkan")
        ElseIf txtnama.Text = "" Then
            MessageBox.Show("Nama Petugas wajib diisi, tidak boleh dikosongkan")
        ElseIf txtuser.Text = "" Then
            MessageBox.Show("Username wajib diisi, tidak boleh dikosongkan")
        ElseIf txtpass.Text = "" Then
            MessageBox.Show("Password wajib diisi, tidak boleh dikosongkan")
        ElseIf txthak.Text = "" Then
            MessageBox.Show("Hak wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtnama.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "UPDATE tb_petugas SET nama_petugas ='" & txtnama.Text & "', username ='" & txtuser.Text & "' , password ='" & txtpass.Text & "', id_level ='" & txthak.Text & "' WHERE id_petugas ='" & txtid.Text & "'"
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data Petugas Berhasil Di ubah", MsgBoxStyle.Information)
            tampildata()
        End If
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        bersih()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim baris As Integer
        Dim id As String

        baris = DataGridView1.CurrentCell.RowIndex
        id = DataGridView1(0, baris).Value.ToString

        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "DELETE FROM tb_petugas WHERE id_petugas = '" + id + "'"
        cmd.ExecuteNonQuery()
        cn.Close()
        MsgBox("Data Petugas Berhasil Terhapus", MsgBoxStyle.Information)
        tampildata()
    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_petugas WHERE id_petugas LIKE '%" & txtcari.Text & "%' OR nama_petugas LIKE '%" & txtcari.Text & "%' OR username LIKE '%" & txtcari.Text & "%' OR password LIKE '%" & txtcari.Text & "%'OR id_level LIKE '%" & txtcari.Text & "%'"

        Dim rd As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rd)
        DataGridView1.DataSource = dt
        cn.Close()
    End Sub


    Private Sub txthak_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txthak.SelectedIndexChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_level WHERE id_level ='" & txthak.Text & "'"
        cmd.ExecuteNonQuery()
        Dim rd As SqlDataReader = cmd.ExecuteReader
        If rd.Read() Then
            TextBox1.Text = rd("hak")
        End If
        rd.Read()
        rd.Close()
        cn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_DoubleClick1(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        txtid.Text = DataGridView1.SelectedCells(0).Value
        txtnama.Text = DataGridView1.SelectedCells(1).Value
        txtuser.Text = DataGridView1.SelectedCells(2).Value
        txtpass.Text = DataGridView1.SelectedCells(3).Value
        txthak.Text = DataGridView1.SelectedCells(4).Value
    End Sub
End Class