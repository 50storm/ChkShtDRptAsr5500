Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions

Public Class Utility

    Public Shared Function IsDateFormat(txt As String) As Boolean


        If (Regex.IsMatch(txt, "^[0-9]{4}\/[0-9]{2}\/[0-9]{2}$")) = False Then
            Return False
        Else
            Dim strDate() As String = txt.Split("/"c)
            If (1 <= CInt(strDate(1)) And CInt(strDate(1)) <= 12) Then
                If (1 <= CInt(strDate(2)) And CInt(strDate(2)) <= 31) Then

                    Return True

                End If
            End If
            Return False
        End If

    End Function




End Class
