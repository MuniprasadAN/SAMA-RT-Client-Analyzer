Imports System.Text.RegularExpressions

Public Class AddOPC
    Public btnclose As Boolean
    Public btnupdate As Boolean
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try

            If NeedUserInput() Then

            Else
                If btnadd.Text = "Update" Then
                    btnupdate = True
                End If

                btnclose = True
                Me.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Function NeedUserInput() As Boolean
        Try

            If txtbxconfigname.Text = "" Then
                MsgBox("Please Enter the Config Name")
                Return True
            End If


            If TxtbxHostname.Text = "" Then
                MsgBox("Please Enter IPAddress")
                Return True
            End If

            If Not IsIpValid(TxtbxHostname.Text) Then
                MsgBox("Please Enter Valid IPAddress")
                Return True
            End If

            If TxtbxPortnumber.Text = "" Then
                MsgBox("Please Enter PortNumber")
                Return True
            End If

            If CBxredundancy.Checked Then
                If txtbxredundantipaddr.Text = "" Then
                    MsgBox("Please Enter Valid IPAddress for Redundancy")
                    Return True
                End If

                If Not IsIpValid(txtbxredundantipaddr.Text) Then
                    MsgBox("Please Enter Valid Redundant IPAddress")
                    Return True
                End If

                If txtbxredundantportno.Text = "" Then
                    MsgBox("Please Enter Valid Portnumber for Redundancy")
                    Return True
                End If
            End If


        Catch ex As Exception

        End Try
    End Function
    Public Function IsIpValid(ByVal ipAddress As String)

        Dim expr As String = "^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"

        Dim reg As Regex = New Regex(expr)
        If (reg.IsMatch(ipAddress)) Then
            Dim parts() As String = ipAddress.Split(".")
            If Convert.ToInt32(parts(0)) = 0 Then
                Return False
            ElseIf Convert.ToInt32(parts(3)) = 0 Then
                Return False
            End If
            For i As Integer = 0 To 3
                If parts(i) > 255 Then
                    Return False
                End If
            Next
            Return True
        Else
            Return False
        End If

    End Function
    Private Sub CBxredundancy_CheckedChanged(sender As Object, e As EventArgs) Handles CBxredundancy.CheckedChanged
        If CBxredundancy.Checked Then
            GroupBox1.Visible = True
        Else
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub AddOPC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnupdate = False
        GroupBox1.Visible = False
        If CBxredundancy.Checked Then
            GroupBox1.Visible = True
        Else
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

End Class