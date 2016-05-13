Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data.Linq
Imports System.Transactions

Public Class Search
    Inherits System.Web.UI.Page

    Private strConn As String = ConfigurationManager.ConnectionStrings("ConnectionString").ToString()



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '初期表示

            Me.txtDateFrom.Text = Now.ToString("yyyy/MM/dd")
            Me.txtDateTo.Text = Now.ToString("yyyy/MM/dd")


            Using Dc As New Asr5500ChkSheetDataContext(strConn)


                Dim Query = From x In Dc.asr5500_chksheets Order By x.id
                Me.GridView1.DataSource = Query
                Me.GridView1.DataBind()
                If (Me.GridView1.Rows.Count = 0) Then
                    '検索ゼロ件の時のコード
                    Me.GridView1.Visible = False
                    Me.lblMsg.Text = "登録件数は0件です。"
                Else
                    Me.GridView1.Visible = True
                    Me.lblMsg.Text = "データ一覧を初期表示してます"
                End If
            End Using
        Else

            'Me.ViewState.Add("txtDateFrom", Me.txtDateFrom.Text)
            'Me.ViewState.Add("txtDateTo", Me.txtDateTo.Text)
        End If

        'If Not Me.ViewState.Item("txtDateFrom") Is Nothing Then
        '    Me.txtDateFrom.Text = Me.ViewState.Item("txtDateFrom").ToString()

        'End If
        'If Not Me.ViewState.Item("txtDateTo") Is Nothing Then
        '    Me.txtDateTo.Text = Me.ViewState.Item("txtDateTo").ToString()
        'End If



    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Me.txtDateFrom.Text.Trim() = String.Empty And Me.txtDateTo.Text.Trim() = String.Empty Then
            Me.lblMsg.Text = "日付のFromとToが入力されていません。"

        End If

        If Me.txtDateFrom.Text.Trim() <> String.Empty And Me.txtDateTo.Text.Trim() = String.Empty Then
            Me.lblMsg.Text = "日付のToが入力されていません。"

        End If


        If Me.txtDateFrom.Text.Trim() = String.Empty And Me.txtDateTo.Text.Trim() <> String.Empty Then
            Me.lblMsg.Text = "日付のFromが入力されていません。"

        End If


        Using Dc As New Asr5500ChkSheetDataContext(strConn)
            Dim Query = From x In Dc.asr5500_chksheets
                        Where x.date >= CDate(Me.txtDateFrom.Text) And x.date <= CDate(Me.txtDateTo.Text)
                        Order By x.id


            Me.GridView1.DataSource = Query
            Me.GridView1.DataBind()
            If (Me.GridView1.Rows.Count = 0) Then
                '検索ゼロ件の時のコード
                Me.GridView1.Visible = False
                Me.lblMsg.Text = "検索結果0件です。"
            Else
                Me.GridView1.Visible = True
                Me.lblMsg.Text = "検索結果を表示してます"
            End If
        End Using

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub


    '1行が作成されたら、発生するイベント
    Private Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowCreated
        'Me.GridView1.Rows(0).Visible = False

        'https://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=JA-JP&k=k(System.Web.UI.WebControls.DataControlRowType);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5.2);k(DevLang-VB)&rd=true

        If e.Row.RowType = DataControlRowType.DataRow OrElse e.Row.RowType = DataControlRowType.Header Then
            'e.Row.Cells(0).Visible = False


        End If

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If GridView1.SelectedRow Is Nothing Then

        Else
            Select Case e.CommandName.ToString()
                Case "Select"

                    Dim dr As GridViewRow = GridView1.SelectedRow
                    'デバック
                    'For i As Integer = 0 To dr.Cells.Count - 1
                    '    Console.WriteLine(dr.Cells(i).Text)

                    'Next

                    Dim key As String = dr.Cells(1).Text


                    Dim Dc As New Asr5500ChkSheetDataContext(strConn)
                    Dim Query = (From x In Dc.asr5500_chksheets Where x.id = CInt(key) Select x).ToArray()

                    Me.Session("searchKey") = Query(0).id.ToString()
                    'Me.Session("name1") = Query(0).name1
                    'Me.Session("name2") = Query(0).name2


                    'Dim aaa As Object = Me.Session("Query")(0)("name1")


                    Me.Response.Redirect("~/ChkShtDRptAsr5500.aspx")

            End Select

        End If

    End Sub

    Protected Sub GridView1_DataBinding(sender As Object, e As EventArgs) Handles GridView1.DataBinding

    End Sub
End Class