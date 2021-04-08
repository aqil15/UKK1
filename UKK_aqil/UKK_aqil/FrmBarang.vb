Imports System.Data.SqlClient
Public Class FrmBarang

    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand

    Sub tampildata()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_barang"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rd)
        DataGridView1.DataSource = dt
        cn.Close()

        DataGridView1.Columns(0).HeaderText = "Id Barang"
        DataGridView1.Columns(1).HeaderText = "Nama Barang"
        DataGridView1.Columns(2).HeaderText = "Tanggal"
        DataGridView1.Columns(3).HeaderText = "Harga Awal"
        DataGridView1.Columns(4).HeaderText = "Deskripsi Barang"

        DataGridView1.Columns(0).Width = 210
        DataGridView1.Columns(1).Width = 210
        DataGridView1.Columns(2).Width = 210
        DataGridView1.Columns(3).Width = 210
        DataGridView1.Columns(4).Width = 500
    End Sub

    Private Sub FrmBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn.ConnectionString = "Data Source=DESKTOP-9SSHS8T\SQLEXPRESS;Initial Catalog=db_UKK_aqil;Integrated Security=True"
        tampildata()
        txtid.Enabled = False
        txttampil.Enabled = False
    End Sub

    Sub bersih()
        txtid.Text = ""
        txtnama.Text = ""
        txttgl.Text = ""
        txtharga.Text = ""
        txtdes.Text = ""
        txttampil.Text = ""
    End Sub

    Sub kodeotomatis()
        Dim kodeauto As Single
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT COUNT(*) AS id_barang FROM tb_barang"
        Dim rd As SqlDataReader = cmd.ExecuteReader
        While rd.Read
            kodeauto = Val(rd.Item("id_barang").ToString) + 1
        End While
        Select Case Len(Trim(kodeauto))
            Case 1 : txtid.Text = "BR-0" + Trim(Str(kodeauto))
            Case 2 : txtid.Text = "BR-" + Trim(Str(kodeauto))
        End Select
        rd.Close()
        cn.Close()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kodeotomatis()
    End Sub


    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        bersih()

    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txtnama.Text = "" Then
            MessageBox.Show("Nama Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txttgl.Text = "" Then
            MessageBox.Show("Tanggal wajib diisi, tidak boleh dikosongkan")
        ElseIf txtharga.Text = "" Then
            MessageBox.Show("Harga Awal wajib diisi, tidak boleh dikosongkan")
        ElseIf txtdes.Text = "" Then
            MessageBox.Show("Deskripsi wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtnama.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "INSERT INTO tb_barang VALUES ('" & txtid.Text & "','" & txtnama.Text & "','" & txttgl.Text & "','" & txtharga.Text & "','" & txtdes.Text & "') "
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data Barang Berhasil Tersimpan", MsgBoxStyle.Information)
            tampildata()
            txtid.Enabled = False
        End If
    End Sub

    Private Sub txtharga_TextChanged(sender As Object, e As EventArgs) Handles txtharga.TextChanged
        Try
            Dim a As Integer
            a = txtharga.Text
            txttampil.Text = "Rp " + FormatNumber(a, 2, , , TriState.True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnubah_Click(sender As Object, e As EventArgs) Handles btnubah.Click
        If txtid.Text = "" Then
            MessageBox.Show("ID Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txtnama.Text = "" Then
            MessageBox.Show("Nama Barang wajib diisi, tidak boleh dikosongkan")
        ElseIf txttgl.Text = "" Then
            MessageBox.Show("Tanggal wajib diisi, tidak boleh dikosongkan")
        ElseIf txtharga.Text = "" Then
            MessageBox.Show("Harga Awal wajib diisi, tidak boleh dikosongkan")
        ElseIf txtdes.Text = "" Then
            MessageBox.Show("Deskripsi wajib diisi, tidak boleh dikosongkan")
        ElseIf txtid.Text <> "" And txtnama.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "UPDATE tb_barang SET nama_barang ='" & txtnama.Text & "', tgl ='" & txttgl.Text & "' , harga_awal ='" & txtharga.Text & "', deskripsi='" & txtdes.Text & "' WHERE id_barang ='" & txtid.Text & "'"
            cmd.ExecuteNonQuery()
            cn.Close()
            bersih()
            MsgBox("Data Barang Berhasil Di ubah", MsgBoxStyle.Information)
            tampildata()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        txtid.Text = DataGridView1.SelectedCells(0).Value
        txtnama.Text = DataGridView1.SelectedCells(1).Value
        txttgl.Text = DataGridView1.SelectedCells(2).Value
        txtharga.Text = DataGridView1.SelectedCells(3).Value
        txtdes.Text = DataGridView1.SelectedCells(4).Value
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim baris As Integer
        Dim id As String

        baris = DataGridView1.CurrentCell.RowIndex
        id = DataGridView1(0, baris).Value.ToString

        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "DELETE FROM tb_barang WHERE id_barang = '" + id + "'"
        cmd.ExecuteNonQuery()
        cn.Close()
        MsgBox("Data barang Berhasil Terhapus", MsgBoxStyle.Information)
        tampildata()
        bersih()

    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM tb_barang WHERE id_barang LIKE '%" & txtcari.Text & "%' OR nama_barang LIKE '%" & txtcari.Text & "%' OR tgl LIKE '%" & txtcari.Text & "%' OR harga_awal LIKE '%" & txtcari.Text & "%'OR deskripsi LIKE '%" & txtcari.Text & "%'  "

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
        Dim lapbarang As New FrmLapBarang
        lapbarang.TopLevel = False
        FrmMenu.panel_menu.Controls.Add(lapbarang)
        lapbarang.Show()
    End Sub
End Class