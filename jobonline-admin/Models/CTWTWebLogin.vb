Imports System.Data.SqlClient
Public Class TWTWebLogin
    Private m_Connstr As String
    Public Property CustID As String
    Public Property AppID As String
    Public Property UserLogIN As String
    Public Property FromIP As String
    Public Property SessionID As String
    Public Property LoginDateTime As Date
    Public Property ExpireDateTime As Date
    Public Sub New()

    End Sub
    Public Sub New(pConn As String)
        m_ConnStr = pConn
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of TWTWebLogin)
        Dim lst As New List(Of TWTWebLogin)
        Using cn As New SqlConnection(m_Connstr)
            Dim row As TWTWebLogin
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM TWTWebLogin" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New TWTWebLogin(m_Connstr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CustID"))) = False Then
                        row.CustID = rd.GetString(rd.GetOrdinal("CustID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AppID"))) = False Then
                        row.AppID = rd.GetString(rd.GetOrdinal("AppID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UserLogIN"))) = False Then
                        row.UserLogIN = rd.GetString(rd.GetOrdinal("UserLogIN")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FromIP"))) = False Then
                        row.FromIP = rd.GetString(rd.GetOrdinal("FromIP")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SessionID"))) = False Then
                        row.SessionID = rd.GetString(rd.GetOrdinal("SessionID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LoginDateTime"))) = False Then
                        row.LoginDateTime = rd.GetValue(rd.GetOrdinal("LoginDateTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ExpireDateTime"))) = False Then
                        row.ExpireDateTime = rd.GetValue(rd.GetOrdinal("ExpireDateTime"))
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class
