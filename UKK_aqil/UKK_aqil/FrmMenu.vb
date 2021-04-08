Public Class FrmMenu

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim Barang As New FrmBarang
        Barang.TopLevel = False
        panel_menu.Controls.Add(Barang)
        Barang.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Restart()

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Dim Petugas As New FrmPetugas
        Petugas.TopLevel = False
        panel_menu.Controls.Add(Petugas)
        Petugas.Show()
    End Sub

    Private Sub panel_menu_Paint(sender As Object, e As PaintEventArgs) Handles panel_menu.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbwaktu.Text = Format(Now, "HH:mm:ss")
        lbtanggal.Text = Format(Now, "yyyy-MM-dd")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim Member As New FrmMember
        Member.TopLevel = False
        panel_menu.Controls.Add(Member)
        Member.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim Lelang As New FrmLelang
        Lelang.TopLevel = False
        panel_menu.Controls.Add(Lelang)
        Lelang.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim History As New FrmHistory
        History.TopLevel = False
        panel_menu.Controls.Add(History)
        History.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Bantuan As New FrmBantuan
        Bantuan.TopLevel = False
        panel_menu.Controls.Add(Bantuan)
        Bantuan.Show()
    End Sub
End Class
