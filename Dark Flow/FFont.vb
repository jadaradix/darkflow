Imports System.IO
Imports System
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Drawing

Public Class FFont

    Public User As Form

    Private Sub FFont_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Icon = My.Resources.Icon
        BackColor = NiceBG

        Dim InstalledFonts As New InstalledFontCollection
        Dim MyFonts() As FontFamily = InstalledFonts.Families()

        FontDropper.BackCombo.Items.Clear()
        For Each MyFont In MyFonts
            FontDropper.BackCombo.Items.Add(MyFont.Name)
        Next MyFont

        FontDropper.Text = "Arial"
        SexUpToolStrip(MainToolStrip, False, False)

        UpdateFont()

    End Sub

    Private Sub DCancelButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCancelButton.Click
        Me.Close()
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        Dim TI As Image = PreviewHolder.BackgroundImage
        DirectCast(User, FImage).UpdateImage(TI)
        Me.Close()
    End Sub

    Sub UpdateFont()
        Dim FinalBack As New Bitmap(TileWidth.Value * 16, TileHeight.Value * 16)
        PreviewHolder.Size = FinalBack.Size
        Dim BackGFX As Graphics = Graphics.FromImage(FinalBack)
        For i As Integer = 0 To 255
            Dim charbmp As New Bitmap(TileWidth.Value, TileHeight.Value)
            Dim gfx As Graphics = Graphics.FromImage(charbmp)
            Dim fnt As New Font("Arial", FontSize.Value)
            Try
                fnt = New Font(FontDropper.Text, FontSize.Value)
                If BoldCheck.Checked And ItalicCheck.Checked Then
                    fnt = New Font(FontDropper.Text, FontSize.Value, FontStyle.Bold Or FontStyle.Italic)
                End If
                If BoldCheck.Checked And Not ItalicCheck.Checked Then
                    fnt = New Font(FontDropper.Text, FontSize.Value, FontStyle.Bold)
                End If
                If Not BoldCheck.Checked And ItalicCheck.Checked Then
                    fnt = New Font(FontDropper.Text, FontSize.Value, FontStyle.Italic)
                End If
            Catch

            End Try
            Dim CharWidth = gfx.MeasureString(Chr(i), fnt).Width
            Dim CharHeight = gfx.MeasureString(Chr(i), fnt).Height
            If AntialiasCheck.Checked Then gfx.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias Else gfx.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
            gfx.DrawString(Chr(i), fnt, Brushes.Black, New Point(Math.Floor((TileWidth.Value / 2) - (CharWidth / 2)), Math.Floor((TileHeight.Value / 2) - (CharHeight / 2))))
            BackGFX.DrawImage(charbmp, New Point((i Mod 16) * TileWidth.Value, Math.Floor(i / 16) * TileHeight.Value))
        Next
        PreviewHolder.BackgroundImage = FinalBack
    End Sub

    Private Sub Checkers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItalicCheck.CheckedChanged, BoldCheck.CheckedChanged, AntialiasCheck.CheckedChanged
        UpdateFont()
    End Sub

    Private Sub FontDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontDropper.SelectedIndexChanged
        UpdateFont()
    End Sub

    Private Sub FontSize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontSize.ValueChanged, TileWidth.ValueChanged, TileHeight.ValueChanged
        UpdateFont()
    End Sub

End Class