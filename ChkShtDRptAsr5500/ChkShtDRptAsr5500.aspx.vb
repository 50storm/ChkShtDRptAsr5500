Imports System
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data.Linq
Imports System.Transactions



Public Class ChkShtDRptAsr5500
    Inherits System.Web.UI.Page
    Private strConn As String = ConfigurationManager.ConnectionStrings("ConnectionString").ToString()


    Private Function IsRegisterd(keyDate As String) As Boolean
        Dim Dc As New Asr5500ChkSheetDataContext(strConn)
        Dim Query = (From x In Dc.asr5500_chksheets
                     Where x.date = CDate(keyDate)
                     Order By x.id Descending).ToArray()

        If Query.Length = 0 Then

            Return False
        Else
            Return True
        End If


    End Function


    Private Sub DeleteData()
        Try

            Using ASR5500ChkSheet As New Asr5500ChkSheetDataContext(strConn)
                ASR5500ChkSheet.ExecuteCommand("DELETE FROM asr5500_chksheets WHERE date = {0}", Me.txtYear.Text.Replace("/", "-"))

            End Using
            Me.lblMsg.Text = "チェックシートを削除しました"

        Catch ex As Exception
            Me.lblMsg.Text = "例外発生"
        End Try


    End Sub


    Private Sub UndateData()

        Dim updSql As String = "UPDATE asr5500_chksheets SET  " &
                               "   no1 = @no1 ,  no2 = @no2 , no3 = @no3, no4 = @no4, no5 = @no5, no6 = @no6, no7 = @no7 " &
                               "  ,no1_dblchk = @no1_dblchk ,  no2_dblchk = @no2_dblchk , no3_dblchk = @no3_dblchk, no4_dblchk = @no4_dblchk, no5_dblchk = @no5_dblchk, no6_dblchk = @no6_dblchk, no7_dblchk = @no7_dblchk " &
                               "  ,name1 = @name1 , name2 = @name2" &
                               " WHERE date = @date"


        Using con As New SqlConnection(strConn)


            Dim trans As SqlTransaction
            con.Open()
            trans = con.BeginTransaction()

            Try


                Dim SqlCmd As New SqlCommand(updSql, con)

                '作成者
                SqlCmd.Parameters.Add("@no1", SqlDbType.Bit).Value = Me.ChkBoxMaker01.Checked
                SqlCmd.Parameters.Add("@no2", SqlDbType.Bit).Value = Me.ChkBoxMaker02.Checked
                SqlCmd.Parameters.Add("@no3", SqlDbType.Bit).Value = Me.ChkBoxMaker03.Checked
                SqlCmd.Parameters.Add("@no4", SqlDbType.Bit).Value = Me.ChkBoxMaker04.Checked
                SqlCmd.Parameters.Add("@no5", SqlDbType.Bit).Value = Me.ChkBoxMaker05.Checked
                SqlCmd.Parameters.Add("@no6", SqlDbType.Bit).Value = Me.ChkBoxMaker06.Checked
                SqlCmd.Parameters.Add("@no7", SqlDbType.Bit).Value = Me.ChkBoxMaker07.Checked
                SqlCmd.Parameters.Add("@no8", SqlDbType.Bit).Value = Me.ChkBoxMaker08.Checked
                '確認者
                SqlCmd.Parameters.Add("@no1_dblchk", SqlDbType.Bit).Value = Me.ChkBoxChecker01.Checked
                SqlCmd.Parameters.Add("@no2_dblchk", SqlDbType.Bit).Value = Me.ChkBoxChecker02.Checked
                SqlCmd.Parameters.Add("@no3_dblchk", SqlDbType.Bit).Value = Me.ChkBoxChecker03.Checked
                SqlCmd.Parameters.Add("@no4_dblchk", SqlDbType.Bit).Value = Me.ChkBoxChecker04.Checked
                SqlCmd.Parameters.Add("@no5_dblchk", SqlDbType.Bit).Value = Me.ChkBoxChecker05.Checked
                SqlCmd.Parameters.Add("@no6_dblchk", SqlDbType.Bit).Value = Me.ChkBoxChecker06.Checked
                SqlCmd.Parameters.Add("@no7_dblchk", SqlDbType.Bit).Value = Me.ChkBoxChecker07.Checked
                SqlCmd.Parameters.Add("@no8_dblchk", SqlDbType.Bit).Value = Me.ChkBoxChecker08.Checked

                SqlCmd.Parameters.Add("@name1", SqlDbType.VarChar).Value = Me.ddListPerson1.Text
                SqlCmd.Parameters.Add("@name2", SqlDbType.VarChar).Value = Me.ddListPerson2.Text

                SqlCmd.Parameters.Add("@date", SqlDbType.Date).Value = Me.txtYear.Text.Trim



                SqlCmd.Transaction = trans
                SqlCmd.ExecuteNonQuery()
                trans.Commit()

                Me.lblMsg.Text = "チェックシートを修正しました"

            Catch ex As Exception

                trans.Rollback()

                Me.lblMsg.Text = "例外が発生しました"

            End Try


        End Using



    End Sub





    Private Sub InsertData()


        Using con As New SqlConnection(strConn)

            Using ObjContext As New DataContext(con)
                Dim Asr5500ChkSheet = ObjContext.GetTable(Of asr5500_chksheets)()
                Dim EntityAsr5500 As New asr5500_chksheets


                Using Tran = New TransactionScope()

                    Try
                        EntityAsr5500.date = CDate(Me.txtYear.Text)




                        '作った人
                        If Me.ChkBoxMaker01.Checked Then
                            EntityAsr5500.no1 = True
                        Else
                            EntityAsr5500.no1 = False
                        End If

                        If Me.ChkBoxMaker02.Checked Then
                            EntityAsr5500.no2 = True
                        Else
                            EntityAsr5500.no2 = False
                        End If


                        If Me.ChkBoxMaker03.Checked Then
                            EntityAsr5500.no3 = True
                        Else
                            EntityAsr5500.no3 = False
                        End If

                        If Me.ChkBoxMaker04.Checked Then
                            EntityAsr5500.no4 = True
                        Else
                            EntityAsr5500.no4 = False
                        End If

                        If Me.ChkBoxMaker05.Checked Then
                            EntityAsr5500.no5 = True
                        Else
                            EntityAsr5500.no5 = False
                        End If

                        If Me.ChkBoxMaker06.Checked Then
                            EntityAsr5500.no6 = True
                        Else
                            EntityAsr5500.no6 = False
                        End If

                        If Me.ChkBoxMaker07.Checked Then
                            EntityAsr5500.no7 = True
                        Else
                            EntityAsr5500.no7 = False
                        End If

                        If Me.ChkBoxMaker08.Checked Then
                            EntityAsr5500.no8 = True
                        Else
                            EntityAsr5500.no8 = False
                        End If

                        If Me.ChkBoxChecker01.Checked Then
                            EntityAsr5500.no1_dblchk = True
                        Else
                            EntityAsr5500.no1_dblchk = False
                        End If

                        If Me.ChkBoxChecker02.Checked Then
                            EntityAsr5500.no2_dblchk = True
                        Else
                            EntityAsr5500.no2_dblchk = False
                        End If

                        'ダブルチェック
                        If Me.ChkBoxChecker03.Checked Then
                            EntityAsr5500.no3_dblchk = True
                        Else
                            EntityAsr5500.no3_dblchk = False
                        End If

                        If Me.ChkBoxChecker04.Checked Then
                            EntityAsr5500.no4_dblchk = True
                        Else
                            EntityAsr5500.no4_dblchk = False
                        End If

                        If Me.ChkBoxChecker05.Checked Then
                            EntityAsr5500.no5_dblchk = True
                        Else
                            EntityAsr5500.no5_dblchk = False
                        End If

                        If Me.ChkBoxChecker06.Checked Then
                            EntityAsr5500.no6_dblchk = True
                        Else
                            EntityAsr5500.no6_dblchk = False
                        End If

                        If Me.ChkBoxChecker07.Checked Then
                            EntityAsr5500.no7_dblchk = True
                        Else
                            EntityAsr5500.no7_dblchk = False
                        End If

                        If Me.ChkBoxChecker08.Checked Then
                            EntityAsr5500.no8_dblchk = True
                        Else
                            EntityAsr5500.no8_dblchk = False
                        End If

                        EntityAsr5500.name1 = Me.ddListPerson1.Text
                        EntityAsr5500.name2 = Me.ddListPerson2.Text


                        Asr5500ChkSheet.InsertOnSubmit(EntityAsr5500)
                        ObjContext.SubmitChanges()
                        Tran.Complete()



                    Catch ex As TransactionAbortedException
                        Me.lblMsg.Text = "トランザクション失敗[INSERT]：" & ex.Message
                        Throw

                    Catch ex As Exception
                        Me.lblMsg.Text = "例外発生：" & ex.Message
                        Throw


                    End Try
                End Using
            End Using
        End Using
    End Sub



    'Private Function GetData() As Object()

    '    Dim Dc As New Asr5500ChkSheetDataContext(strConn)
    '    Dim Query = (From x In Dc.asr5500_chksheets Order By x.id Descending).ToArray()


    '    Return Query

    'End Function






    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Page.IsPostBack Then

            Else

                If Me.Session("searchKey") Is Nothing Then

                    Dim Dc As New Asr5500ChkSheetDataContext(strConn)
                    'Dim Query = (From x In Dc.asr5500_chksheets Order By x.id Descending).ToArray()

                    Dim Query = (From x In Dc.asr5500_chksheets
                                 Where x.date = Now
                                 Order By x.id Descending).ToArray()



                    If Query.Length = 0 Then
                        '1件もテーブルにない場合
                        Me.txtYear.Text = Now.ToString("yyyy/MM/dd")
                        Me.lblMsg.Text = "まだチェックシートを作成していません。"
                        Me.RBtnInsert.Checked = True



                    Else

                        Me.lblMsg.Text = "まだチェックシートを作成済です。"
                        Me.RBtnUpdate.Checked = True
                        Me.txtYear.Text = Query(0).date.ToString().Substring(0, 10)


                        If Query(0).no1 Is Nothing OrElse Query(0).no1 = False Then
                            Me.ChkBoxMaker01.Checked = False

                        Else
                            Me.ChkBoxMaker01.Checked = True

                        End If


                        If Query(0).no2.ToString() Is Nothing Then
                            Me.ChkBoxMaker02.Checked = False

                        Else
                            Me.ChkBoxMaker02.Checked = True

                        End If

                        If Query(0).no3.ToString() Is Nothing Then
                            Me.ChkBoxMaker03.Checked = False

                        Else
                            Me.ChkBoxMaker03.Checked = True

                        End If


                        If Query(0).no4.ToString() Is Nothing Then
                            Me.ChkBoxMaker04.Checked = False

                        Else
                            Me.ChkBoxMaker04.Checked = True

                        End If


                        If Query(0).no5.ToString() Is Nothing Then
                            Me.ChkBoxMaker05.Checked = False

                        Else
                            Me.ChkBoxMaker05.Checked = True

                        End If

                        If Query(0).no6.ToString() Is Nothing Then
                            Me.ChkBoxMaker06.Checked = False

                        Else
                            Me.ChkBoxMaker06.Checked = True

                        End If

                        If String.IsNullOrEmpty(Query(0).no7.ToString()) Then
                            Me.ChkBoxMaker07.Checked = False

                        Else
                            Me.ChkBoxMaker07.Checked = True

                        End If


                        If String.IsNullOrEmpty(Query(0).no8.ToString()) Then
                            Me.ChkBoxMaker08.Checked = False

                        Else
                            Me.ChkBoxMaker08.Checked = True

                        End If





                        If String.IsNullOrEmpty(Query(0).no1.ToString()) Then
                            Me.ChkBoxChecker01.Checked = False

                        Else
                            Me.ChkBoxChecker01.Checked = True

                        End If


                        If Query(0).no2.ToString() Is Nothing Then
                            Me.ChkBoxChecker02.Checked = False

                        Else
                            Me.ChkBoxChecker02.Checked = True

                        End If


                        If Query(0).no3.ToString() Is Nothing Then
                            Me.ChkBoxChecker03.Checked = False

                        Else
                            Me.ChkBoxChecker03.Checked = True

                        End If

                        If Query(0).no4.ToString() Is Nothing Then
                            Me.ChkBoxChecker04.Checked = False

                        Else
                            Me.ChkBoxChecker04.Checked = True

                        End If


                        If Query(0).no5.ToString() Is Nothing Then
                            Me.ChkBoxChecker05.Checked = False

                        Else
                            Me.ChkBoxChecker05.Checked = True

                        End If

                        If Query(0).no6.ToString() Is Nothing Then
                            Me.ChkBoxChecker06.Checked = False

                        Else
                            Me.ChkBoxChecker06.Checked = True

                        End If

                        If Query(0).no7.ToString() Is Nothing Then
                            Me.ChkBoxChecker07.Checked = False

                        Else
                            Me.ChkBoxChecker07.Checked = True

                        End If
                    End If



                Else

                    Dim Dc As New Asr5500ChkSheetDataContext(strConn)
                    Dim Query = (From x In Dc.asr5500_chksheets
                                 Where x.id = CInt(Session("searchKey"))
                                 Order By x.id Descending).ToArray()

                    Me.txtYear.Text = Query(0).date.ToString().Substring(0, 10)



                    If Query(0).no1.ToString() Is Nothing Then
                        Me.ChkBoxMaker01.Checked = False

                    Else
                        Me.ChkBoxMaker01.Checked = True

                    End If


                    If Query(0).no2.ToString() Is Nothing Then
                        Me.ChkBoxMaker02.Checked = False

                    Else
                        Me.ChkBoxMaker02.Checked = True

                    End If



                    If Query(0).no3.ToString() Is Nothing Then
                        Me.ChkBoxMaker03.Checked = False

                    Else
                        Me.ChkBoxMaker03.Checked = True

                    End If


                    If Query(0).no4.ToString() Is Nothing Then
                        Me.ChkBoxMaker04.Checked = False

                    Else
                        Me.ChkBoxMaker04.Checked = True

                    End If


                    If Query(0).no5.ToString() Is Nothing Then
                        Me.ChkBoxMaker05.Checked = False

                    Else
                        Me.ChkBoxMaker05.Checked = True

                    End If

                    If Query(0).no6.ToString() Is Nothing Then
                        Me.ChkBoxMaker06.Checked = False

                    Else
                        Me.ChkBoxMaker06.Checked = True

                    End If

                    If Query(0).no7.ToString() Is Nothing Then
                        Me.ChkBoxMaker07.Checked = False

                    Else
                        Me.ChkBoxMaker07.Checked = True

                    End If
                    If Query(0).no1.ToString() Is Nothing Then
                        Me.ChkBoxChecker01.Checked = False

                    Else
                        Me.ChkBoxChecker01.Checked = True

                    End If


                    If Query(0).no2.ToString() Is Nothing Then
                        Me.ChkBoxChecker02.Checked = False

                    Else
                        Me.ChkBoxChecker02.Checked = True

                    End If



                    If Query(0).no3.ToString() Is Nothing Then
                        Me.ChkBoxChecker03.Checked = False

                    Else
                        Me.ChkBoxChecker03.Checked = True

                    End If


                    If Query(0).no4.ToString() Is Nothing Then
                        Me.ChkBoxChecker04.Checked = False

                    Else
                        Me.ChkBoxChecker04.Checked = True

                    End If


                    If Query(0).no5.ToString() Is Nothing Then
                        Me.ChkBoxChecker05.Checked = False

                    Else
                        Me.ChkBoxChecker05.Checked = True

                    End If

                    If Query(0).no6.ToString() Is Nothing Then
                        Me.ChkBoxChecker06.Checked = False

                    Else
                        Me.ChkBoxChecker06.Checked = True

                    End If

                    If Query(0).no7.ToString() Is Nothing Then
                        Me.ChkBoxChecker07.Checked = False

                    Else
                        Me.ChkBoxChecker07.Checked = True

                    End If



                End If

            End If

        Catch ex As Exception
            Me.lblMsg.Text = ex.Message
            Exit Sub

        End Try

    End Sub

    Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            '入力値検証
            If Not Me.RBtnInsert.Checked AndAlso Not Me.RBtnUpdate.Checked And Not Me.RBtnDelete.Checked Then
                Me.lblMsg.Text = "モードが選択されていません。"
                Me.RBtnInsert.BackColor = System.Drawing.Color.Yellow
                Me.RBtnUpdate.BackColor = System.Drawing.Color.Yellow
                Me.RBtnDelete.BackColor = System.Drawing.Color.Yellow
                Me.RBtnInsert.Focus()

                Exit Sub
            Else
                Me.RBtnInsert.BackColor = System.Drawing.Color.White
                Me.RBtnUpdate.BackColor = System.Drawing.Color.White
                Me.RBtnDelete.BackColor = System.Drawing.Color.White

            End If


            '必須チェック
            If Me.txtYear.Text.Trim = "" Then
                Me.lblMsg.Text = "日付が入力されていません[必須入力]"
                Exit Sub
            End If

            '型チェック
            If Not Utility.IsDateFormat(Me.txtYear.Text) Then
                Me.lblMsg.Text = "日付は9999/99/99で入力してください。"
                Exit Sub

            End If


            '登録
            If Me.RBtnInsert.Checked Then
                If Me.IsRegisterd(Me.txtYear.Text.Trim) Then
                    Me.lblMsg.Text = "すでに作成されています。"
                    Exit Sub
                Else
                    Me.lblMsg.Text = ""
                End If

                Me.InsertData()
                Me.lblMsg.Text = "チェックシートを作成しました。"
                Exit Sub
            End If

            '修正
            If Me.RBtnUpdate.Checked Then
                UndateData()
                Exit Sub
            End If



            '削除
            If Me.RBtnDelete.Checked Then
                DeleteData()
                Exit Sub
            End If




        Catch ex As Exception
            Me.lblMsg.Text = ex.Message
            Exit Sub
        End Try
    End Sub


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Response.Redirect("~/Search.aspx")
        Catch ex As Exception
            Me.lblMsg.Text = ex.Message
            Exit Sub
        End Try

    End Sub

    Protected Sub btnMail_Click(sender As Object, e As EventArgs) Handles btnMail.Click
        Try
            Response.Redirect("~/MailForm.aspx")

        Catch ex As Exception
            Me.lblMsg.Text = ex.Message
            Exit Sub
        End Try

    End Sub
End Class