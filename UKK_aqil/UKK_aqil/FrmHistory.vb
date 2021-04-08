Imports System.Data.SqlClient
Public Class FrmHistory
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand

    'script tampil data
    Sub tampildata()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM history_lelang"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rd)
        DataGridView1.DataSource = dt
        cn.Close()

        DataGridView1.Columns(0).HeaderText = "Id History"
        DataGridView1.Columns(1).HeaderText = "ID Lelang"
        DataGridView1.Columns(2).HeaderText = "ID Barang"
        DataGridView1.Columns(3).HeaderText = "ID User"
        DataGridView1.Columns(4).HeaderText = "Penawaran Harga"

        DataGridView1.Columns(0).Width = 200
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 280
        DataGridView1.Columns(3).Width = 200
        DataGridView1.Columns(4).Width = 200
    End Sub

    Private Sub FrmHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn.ConnectionString = "Data Source=DESKTOP-9SSHS8T\SQLEXPRESS;Initial Catalog=db_UKK_aqil;Integrated Security=True"
        tampildata()
        auto_lelang()
        txtid.Enabled = False
        txtbarang.Enabled = False
        txtuser.Enabled = False
        txtnampil.Enabled = False
        txtharga.Enabled = False
    End Sub

    'script hapus data
    Sub bersih()
        txtid.Text = ""
        txtlelang.Text = ""
        txtbarang.Text = ""
        txtuser.Text = ""
        txtharga.Text = ""
        txtnampil.Text = ""
    End Sub

    'script kode otomotis
    Sub kodeotomatis()
        Dim kodeauto As Single
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT COUNT(*) AS id_history FROM history_lelang"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        While rd.Read
            kodeauto = Val(rd.Item("id_history").ToString) + 1
        End While
        Select Case Len(Trim(kodeauto))
            Case 1 : txtid.Text = "H-0" + Trim(Str(kodeauto))
            Case 2 : txtid.Text = "H-" + Trim(Str(kodeauto))
        End Select
        rd.Close()
        cn.Close()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kodeotomatis()
    End Sub

    'script relasi
    Sub auto_lelang()
        Try
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter("SELECT * FROM tb_lelang", cn)
            da.Fill(dt)
            Dim r As DataRow
            txtlelang.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                txtlelang.AutoCompleteCustomSource.Add(r.Item(0).ToString)
            Next
        Catch ex As Exception
            cn.Close()
        End Try
    End Sub

    'script relasi
    Private Sub txtlelang_TextChanged(sender As Object, e As EventArgs) Handles txtlelang.TextChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_lelang WHERE id_lelang ='" & txtlelang.Text & "'"
        cmd.ExecuteNonQuery()
        Dim rd As SqlDataReader = cmd.ExecuteReader
        If rd.Read() Then
            txtbarang.Text = rd("id_barang")
            txtuser.Text = rd("id_user")
            txtharga.Text = rd("harga_akhir")
        End If
        rd.Read()
        rd.Close()
        cn.Close()
    End Sub


    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID History wajib diisi, tidak boleh dikosongkan")
        ElseIf txtlelang.Text = "" Then
            MessageBox.Show("ID Lelang wajib diisi, tidak boleh dikosongkan")
        ElseIf txtbarang.Text = "" Then
            MessageBox.Show("ID Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txtuser.Text = "" Then
            MessageBox.Show("ID User wajib diisi, tidak boleh dikosongkan")
        ElseIf txtharga.Text = "" Then
            MessageBox.Show("Penawaran Harga wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtlelang.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "INSERT INTO history_lelang VALUES ('" & txtid.Text & "','" & txtlelang.Text & "','" & txtbarang.Text & "','" & txtuser.Text & "','" & txtharga.Text & "') "
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data History Lelang Berhasil Tersimpan", MsgBoxStyle.Information)
            tampildata()
            txtid.Enabled = False
        End If
    End Sub

    Private Sub btnubah_Click(sender As Object, e As EventArgs) Handles btnubah.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID History wajib diisi, tidak boleh dikosongkan")
        ElseIf txtlelang.Text = "" Then
            MessageBox.Show("ID Lelang wajib diisi, tidak boleh dikosongkan")
        ElseIf txtbarang.Text = "" Then
            MessageBox.Show("ID Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txtuser.Text = "" Then
            MessageBox.Show("ID User wajib diisi, tidak boleh dikosongkan")
        ElseIf txtharga.Text = "" Then
            MessageBox.Show("Penawaran Harga wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtlelang.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "UPDATE history_lelang SET id_lelang ='" & txtlelang.Text & "', id_barang ='" & txtbarang.Text & "' , id_user ='" & txtuser.Text & "', penawaran_harga ='" & txtharga.Text & "' WHERE id_history ='" & txtid.Text & "'"
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data History Lelang Berhasil Di ubah", MsgBoxStyle.Information)
            tampildata()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        txtid.Text = DataGridView1.SelectedCells(0).Value
        txtlelang.Text = DataGridView1.SelectedCells(1).Value
        txtbarang.Text = DataGridView1.SelectedCells(2).Value
        txtuser.Text = DataGridView1.SelectedCells(3).Value
        txtharga.Text = DataGridView1.SelectedCells(4).Value
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
        cmd.CommandText = "DELETE FROM history_lelang WHERE id_history = '" + id + "'"
        cmd.ExecuteNonQuery()
        cn.Close()
        MsgBox("Data barang Berhasil Terhapus", MsgBoxStyle.Information)
        tampildata()
    End Sub


    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM history_lelang WHERE id_history LIKE '%" & txtcari.Text & "%' OR id_lelang LIKE '%" & txtcari.Text & "%' OR id_barang LIKE '%" & txtcari.Text & "%' OR id_user LIKE '%" & txtcari.Text & "%'OR penawaran_harga LIKE '%" & txtcari.Text & "%'  "

        Dim rd As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rd)
        DataGridView1.DataSource = dt
        cn.Close()
    End Sub

    Private Sub txtharga_TextChanged(sender As Object, e As EventArgs) Handles txtharga.TextChanged
        Try
            Dim a As Integer
            a = txtharga.Text
            txtnampil.Text = "Rp " + FormatNumber(a, 2, , , TriState.True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnlap_Click(sender As Object, e As EventArgs) Handles btnlap.Click
        Dim lapHistory As New FrmLapHistory
        lapHistory.TopLevel = False
        FrmMenu.panel_menu.Controls.Add(lapHistory)
        lapHistory.Show()
    End Sub
End Class