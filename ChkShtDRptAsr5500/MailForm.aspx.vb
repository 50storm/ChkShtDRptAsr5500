Imports System.Net
Imports System.Net.Mail
Imports System.Data.Linq


Public Class MailForm
    Inherits System.Web.UI.Page



    Private MailTitleList As New ArrayList



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim MailSettings As XElement = XElement.Load(My.Settings("MailSettings").ToString().Trim())

        Dim qAsr550Req = (From x In MailSettings.<ASR5500>.<Title>
                          Select x.<Req>.Value, x.<Pass>.Value, x.<NotPass>.Value).ToArray()

        MailTitleList.Add(qAsr550Req(0).Req.Trim())
        MailTitleList.Add(qAsr550Req(1).Pass.Trim())
        MailTitleList.Add(qAsr550Req(2).NotPass.Trim())


    End Sub

    Private Sub btnSubmitMail_Click(sender As Object, e As EventArgs) Handles btnSubmitMail.Click
        Dim Title As String = ""
        Dim Body As String = ddListPersonFrom.SelectedItem.Text & "さん" & ControlChars.NewLine _
            & "お疲れ様です。" & ControlChars.NewLine


        If Not MenuRequest.Checked AndAlso Not MenuPass.Checked AndAlso Not MenuNotPass.Checked Then
            Me.lblMsg.Text = "メニューが選択されていません。"
            Exit Sub

        End If


        If MenuRequest.Checked Then
            Title = MailTitleList.Item(0)
            Body = "ダブルチェックをお願いします。" & ControlChars.NewLine

        End If

        If MenuPass.Checked Then
            Title = MailTitleList.Item(1)
            Body = "ダブルチェックパスしました。" & ControlChars.NewLine

        End If
        If MenuNotPass.Checked Then
            Title = MailTitleList.Item(2)
            Body = "ダブルチェックパスできませんでした。" & ControlChars.NewLine

        End If

        If txtMailBody.Text.Trim() <> "" Then
            Body &= ControlChars.NewLine & txtMailBody.Text

        End If



        Try

            Dim msg As New MailMessage(ddListPersonFrom.SelectedValue.Trim(), ddListPersonTo.SelectedValue.Trim(), Title.Trim(), Body)
            Dim SmtpClientObj As New SmtpClient()
            SmtpClientObj.Host = "smtp.hnps.co.jp"
            SmtpClientObj.Port = 587
            SmtpClientObj.DeliveryMethod = SmtpDeliveryMethod.Network

            Dim NTC As New System.Net.NetworkCredential()
            'SMTP AUTHで使うアドレスとパスワード


            'SmtpClientObj.Credentials = New NetworkCredential("igarashi@hnps.co.jp", "hiGara123")


            Dim MailSettings As XElement = XElement.Load(My.Settings("MailSettings").ToString().Trim())

            Dim qAsr550Req = (From x In MailSettings.<Auth>
                              Select x.<Email>.Value, x.<Pass>.Value).ToArray()

            SmtpClientObj.Credentials = New NetworkCredential(qAsr550Req(0).Email.Trim(), qAsr550Req(0).Pass.Trim())





            'メッセージを送信する
            SmtpClientObj.Send(msg)
            msg.Dispose()
            SmtpClientObj.Dispose()
            Me.lblMsg.Text = "メールを送信しました。"
        Catch ex As Exception
            Me.lblMsg.Text = "メールを送信できませんでした。"



        End Try

    End Sub

    Protected Sub btnToMainSys_Click(sender As Object, e As EventArgs) Handles btnToMainSys.Click
        Me.Response.Redirect("~/ChkShtDRptAsr5500.aspx")
    End Sub
End Class