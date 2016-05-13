Imports System.Net
Imports System.Net.Mail
Imports System.Data.Linq


Public Class MailForm
    Inherits System.Web.UI.Page

    Private MsgTitle As New ArrayList

    Private MsgBods As New ArrayList


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim MailSettings As XElement = XElement.Load(My.Settings("MailSettings").ToString().Trim())


        'XMLをLinQにセット。
        Dim q = (From x In MailSettings.<ASR5500>).ToArray()
        For Each table As String In q
            '共通でないテーブル名をセット・
            MsgTitle.Add(table)
        Next




        If Page.IsPostBack Then

        Else

        End If

    End Sub

    Private Sub btnSubmitMail_Click(sender As Object, e As EventArgs) Handles btnSubmitMail.Click
        Dim Title As String = ""
        Dim Body As String = ""
        Dim AddFrom As String = ""
        Dim AddTo As String = ""

        If Not MenuRequest.Checked AndAlso Not MenuPass.Checked AndAlso Not MenuNotPass.Checked Then
            Me.lblMsg.Text = "メニューが選択されていません。"
            Exit Sub

        End If

        Try

            Dim msg As New MailMessage("igarashi@hnps.co.jp", "igarashi@hnps.co.jp", Title, Body)
            Dim SmtpClientObj As New SmtpClient()
            SmtpClientObj.Host = "smtp.hnps.co.jp"
            SmtpClientObj.Port = 587
            SmtpClientObj.DeliveryMethod = SmtpDeliveryMethod.Network

            Dim NTC As New System.Net.NetworkCredential()
            'SMTP AUTHで使うアドレスとパスワード
            SmtpClientObj.Credentials = New NetworkCredential("igarashi@hnps.co.jp", "hiGara123")



            'メッセージを送信する
            SmtpClientObj.Send(msg)
            msg.Dispose()
            SmtpClientObj.Dispose()
            Me.lblMsg.Text = "メールを送信しました。"
        Catch ex As Exception
            Me.lblMsg.Text = "メールを送信できませんでした。"



        End Try

    End Sub

    Protected Sub MenuRequest_CheckedChanged(sender As Object, e As EventArgs) Handles MenuRequest.CheckedChanged
        Me.txtTitle.Text = MsgTitle.Item(0).ToString()
    End Sub

    Protected Sub MenuPass_CheckedChanged(sender As Object, e As EventArgs) Handles MenuPass.CheckedChanged
        Me.txtTitle.Text = MsgTitle.Item(1).ToString()
    End Sub

    Protected Sub MenuNotPass_CheckedChanged(sender As Object, e As EventArgs) Handles MenuNotPass.CheckedChanged
        Me.txtTitle.Text = MsgTitle.Item(2).ToString()
    End Sub

End Class