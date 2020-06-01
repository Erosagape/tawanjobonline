Imports System.Data.SqlClient
Public Class TWTUser
    Private m_ConnStr As String
    Public Property TWTUserID As String
    Public Property TWTUserPassword As String
    Public Property TWTUserName As String
    Public Sub New()

    End Sub
    Public Sub New(pConn As String)
        m_ConnStr = pConn
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Function SaveData() As Boolean
        If "" & Me.TWTUserID = "" Then
            Return False
        Else
            Try
                Using cn As SqlConnection = New SqlConnection(m_ConnStr)
                    cn.Open()
                    Using da As New SqlDataAdapter(String.Format("SELECT * FROM TWTUser WHERE TWTUserID='{0}'", Me.TWTUserID), cn)
                        Using cm As New SqlCommandBuilder(da)
                            Using dt As New DataTable
                                da.Fill(dt)

                                Dim dr As DataRow = dt.NewRow
                                If dt.Rows.Count > 0 Then
                                    dr = dt.Rows(0)
                                End If

                                dr("TWTUserID") = Me.TWTUserID
                                dr("TWTUserName") = Me.TWTUserName
                                dr("TWTUserPassword") = Me.TWTUserPassword

                                If dr.RowState = DataRowState.Detached Then
                                    dt.Rows.Add(dr)
                                End If
                                da.Update(dt)

                                Return True
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return False
            End Try
        End If
    End Function

    Public Function GetData(sqlWhere As String) As List(Of TWTUser)
        Dim lst As New List(Of TWTUser)
        Try
            Using cn As SqlConnection = New SqlConnection(m_ConnStr)
                cn.Open()
                Using rd As SqlDataReader = New SqlCommand("SELECT * FROM TWTUser " & sqlWhere, cn).ExecuteReader
                    While rd.Read
                        lst.Add(New TWTUser With {
                            .TWTUserID = rd("TWTUserID").ToString,
                            .TWTUserName = rd("TWTUserName").ToString,
                            .TWTUserPassword = rd("TWTUserPassword").ToString
                        })
                    End While
                    rd.Close()
                End Using
                cn.Close()
            End Using
        Catch ex As Exception

        End Try
        Return lst
    End Function
End Class
