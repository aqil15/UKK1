Imports System.Data.SqlClient
Public Class FrmLelang
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand

    Sub tampildata()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_lelang"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rd)
        DataGridView1.DataSource = dt
        cn.Close()

        DataGridView1.Columns(0).HeaderText = "ID Lelang"
        DataGridView1.Columns(1).HeaderText = "ID Barang"
        DataGridView1.Columns(2).HeaderText = "Tanggal Lelang"
        DataGridView1.Columns(3).HeaderText = "Harga Akhir"
        DataGridView1.Columns(4).HeaderText = "Id User"
        DataGridView1.Columns(5).HeaderText = "Id Petugas"
        DataGridView1.Columns(6).HeaderText = "Status"

        DataGridView1.Columns(0).Width = 200
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 280
        DataGridView1.Columns(3).Width = 200
        DataGridView1.Columns(4).Width = 200
        DataGridView1.Columns(5).Width = 200
        DataGridView1.Columns(6).Width = 200
    End Sub

    Private Sub FrmLelang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn.ConnectionString = "Data Source=DESKTOP-9SSHS8T\SQLEXPRESS;Initial Catalog=db_UKK_aqil;Integrated Security=True"
        tampildata()
        auto_barang()
        auto_user()
        auto_petugas()
        txtid.Enabled = False
        txtnampil.Enabled = False
    End Sub
    Sub bersih()
        txtid.Text = ""
        txtbarang.Text = ""
        txttgl.Text = ""
        txtharga.Text = ""
        txtuser.Text = ""
        txtpetugas.Text = ""
        txtstatus.Text = ""
        txtnampil.Text = ""
    End Sub

    Sub kodeotomatis()
        Dim kodeauto As Single
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT COUNT(*) AS id_lelang FROM tb_lelang"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        While rd.Read
            kodeauto = Val(rd.Item("id_lelang").ToString) + 1
        End While
        Select Case Len(Trim(kodeauto))
            Case 1 : txtid.Text = "L-0" + Trim(Str(kodeauto))
            Case 2 : txtid.Text = "L-" + Trim(Str(kodeauto))
        End Select
        rd.Close()
        cn.Close()
    End Sub

    Sub auto_barang()
        Try
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter("SELECT * FROM tb_barang", cn)
            da.Fill(dt)
            Dim r As DataRow
            txtbarang.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                txtbarang.AutoCompleteCustomSource.Add(r.Item(0).ToString)
            Next
        Catch ex As Exception
            cn.Close()
        End Try
    End Sub

    Private Sub txtbarang_TextChanged(sender As Object, e As EventArgs) Handles txtbarang.TextChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_barang WHERE id_barang ='" & txtbarang.Text & "'"
        cmd.ExecuteNonQuery()
        Dim rd As SqlDataReader = cmd.ExecuteReader
        rd.Read()
        rd.Close()
        cn.Close()
    End Sub

    Sub auto_user()
        Try
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter("SELECT * FROM tb_masyarakat", cn)
            da.Fill(dt)
            Dim r As DataRow
            txtuser.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                txtuser.AutoCompleteCustomSource.Add(r.Item(0).ToString)
            Next
        Catch ex As Exception
            cn.Close()
        End Try
    End Sub

    Private Sub txtuser_TextChanged(sender As Object, e As EventArgs) Handles txtuser.TextChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_masyarakat WHERE id_user ='" & txtuser.Text & "'"
        cmd.ExecuteNonQuery()
        Dim rd As SqlDataReader = cmd.ExecuteReader
        rd.Read()
        rd.Close()
        cn.Close()
    End Sub

    Sub auto_petugas()
        Try
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter("SELECT * FROM tb_petugas", cn)
            da.Fill(dt)
            Dim r As DataRow
            txtpetugas.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                txtpetugas.AutoCompleteCustomSource.Add(r.Item(0).ToString)
            Next
        Catch ex As Exception
            cn.Close()
        End Try
    End Sub

    Private Sub txtpetugas_TextChanged(sender As Object, e As EventArgs) Handles txtpetugas.TextChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_petugas WHERE id_petugas ='" & txtpetugas.Text & "'"
        cmd.ExecuteNonQuery()
        Dim rd As SqlDataReader = cmd.ExecuteReader
        rd.Read()
        rd.Close()
        cn.Close()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txtbarang.Text = "" Then
            MessageBox.Show("Id Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txttgl.Text = "" Then
            MessageBox.Show("Tanggal wajib diisi, tidak boleh dikosongkan")
        ElseIf txtharga.Text = "" Then
            MessageBox.Show("Harga Akhir wajib diisi, tidak boleh dikosongkan")
        ElseIf txtuser.Text = "" Then
            MessageBox.Show("Id User wajib diisi, tidak boleh dikosongkan")
        ElseIf txtpetugas.Text = "" Then
            MessageBox.Show("Id Petugas wajib diisi, tidak boleh dikosongkan")
        ElseIf txtstatus.Text = "" Then
            MessageBox.Show("Status wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtbarang.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "INSERT INTO tb_lelang VALUES ('" & txtid.Text & "','" & txtbarang.Text & "','" & txttgl.Text & "','" & txtharga.Text & "','" & txtuser.Text & "','" & txtpetugas.Text & "','" & txtstatus.Text & "') "
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data Lelang Berhasil Tersimpan", MsgBoxStyle.Information)
            tampildata()
            txtid.Enabled = False
        End If
    End Sub

    Private Sub btnubah_Click(sender As Object, e As EventArgs) Handles btnubah.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txtbarang.Text = "" Then
            MessageBox.Show("Id Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txttgl.Text = "" Then
            MessageBox.Show("Tanggal wajib diisi, tidak boleh dikosongkan")
        ElseIf txtharga.Text = "" Then
            MessageBox.Show("Harga Akhir wajib diisi, tidak boleh dikosongkan")
        ElseIf txtuser.Text = "" Then
            MessageBox.Show("Id User wajib diisi, tidak boleh dikosongkan")
        ElseIf txtpetugas.Text = "" Then
            MessageBox.Show("Id Petugas wajib diisi, tidak boleh dikosongkan")
        ElseIf txtstatus.Text = "" Then
            MessageBox.Show("Status wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtbarang.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "UPDATE tb_lelang SET id_barang ='" & txtbarang.Text & "', tgl_lelang ='" & txttgl.Text & "' , harga_akhir ='" & txtharga.Text & "', id_user ='" & txtuser.Text & "', id_petugas ='" & txtpetugas.Text & "', status ='" & txtstatus.Text & "' WHERE id_lelang ='" & txtid.Text & "'"
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data Lelang Berhasil Di ubah", MsgBoxStyle.Information)
            tampildata()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        txtid.Text = DataGridView1.SelectedCells(0).Value
        txtbarang.Text = DataGridView1.SelectedCells(1).Value
        txttgl.Text = DataGridView1.SelectedCells(2).Value
        txtharga.Text = DataGridView1.SelectedCells(3).Value
        txtuser.Text = DataGridView1.SelectedCells(4).Value
        txtpetugas.Text = DataGridView1.SelectedCells(5).Value
        txtstatus.Text = DataGridView1.SelectedCells(6).Value
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim baris As Integer
        Dim id As String

        baris = DataGridView1.CurrentCell.RowIndex
        id = DataGridView1(0, baris).Value.ToString

        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "DELETE FROM tb_lelang WHERE id_lelang = '" + id + "'"
        cmd.ExecuteNonQuery()
        cn.Close()
        MsgBox("Data Lelang Berhasil Terhapus", MsgBoxStyle.Information)
        tampildata()
    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_lelang WHERE id_lelang LIKE '%" & txtcari.Text & "%' OR id_barang LIKE '%" & txtcari.Text & "%' OR tgl_lelang LIKE '%" & txtcari.Text & "%' OR harga_akhir LIKE '%" & txtcari.Text & "%'OR id_user LIKE '%" & txtcari.Text & "%'OR id_petugas LIKE '%" & txtcari.Text & "%'OR status LIKE '%" & txtcari.Text & "%'  "

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

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kodeotomatis()
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        bersih()

    End Sub

    Private Sub btnlap_Click(sender As Object, e As EventArgs) Handles btnlap.Click
        Dim laplaporan As New FrmLapLelang
        laplaporan.TopLevel = False
        FrmMenu.panel_menu.Controls.Add(laplaporan)
        laplaporan.Show()
    End Sub
End Class