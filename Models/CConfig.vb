﻿Imports System.Data.SqlClient

Public Class CConfig
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(Optional pConnStr As String = "")
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Property ConfigCode As String
    Public Property ConfigKey As String
    Public Property ConfigValue As String
    Public Function SaveData() As Boolean
        Dim bComplete As Boolean = False
        Try
            Using cn As New SqlConnection(m_ConnStr)
                cn.Open()
                Using da As New SqlDataAdapter(String.Format("SELECT * FROM Mas_Config WHERE ConfigCode='{0}' AND ConfigKey='{1}'", Me.ConfigCode, Me.ConfigKey), cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count <> 0 Then
                                dr = dt.Rows(0)
                            End If
                            dr(0) = Main.GetDBString(Me.ConfigCode, dt.Columns(0))
                            dr(1) = Main.GetDBString(Me.ConfigKey, dt.Columns(1))
                            dr(2) = Main.GetDBString(Me.ConfigValue, dt.Columns(2))
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            If da.Update(dt) > 0 Then
                                Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CConfig", "SaveData", Me, False)
                                bComplete = True
                            End If
                        End Using
                    End Using
                End Using

            End Using
        Catch ex As Exception
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CConfig", "SaveData", ex.Message, True, ex.StackTrace, "")
        End Try
        Return bComplete
    End Function
    Public Function DeleteData(Optional pSqlWhere As String = "") As String
        Try
            Using cn As New SqlConnection(m_ConnStr)
                cn.Open()

                Using cm = New SqlCommand("DELETE FROM Mas_Config " & pSqlWhere, cn)
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CConfig", "DeleteData", cm.CommandText, False)
                End Using

            End Using
            Return "Delete Complete"
        Catch ex As Exception
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CConfig", "DeleteData", ex.Message, True, ex.StackTrace, "")
            Return String.Format("[exception] {0}", ex.Message, True, ex.StackTrace, "")
        End Try
    End Function
    Public Function GetData(Optional pSqlWhere As String = "") As List(Of CConfig)
        Dim lst As New List(Of CConfig)
        Try
            Using cn As New SqlConnection(m_ConnStr)
                cn.Open()

                Using rd As SqlDataReader = New SqlCommand("SELECT * FROM Mas_Config " & pSqlWhere, cn).ExecuteReader
                    While rd.Read
                        Dim data As New CConfig(m_ConnStr) With {
                            .ConfigCode = rd.GetString(0),
                            .ConfigKey = rd.GetString(1),
                            .ConfigValue = rd.GetString(2)
                        }
                        lst.Add(data)
                    End While
                End Using

            End Using
        Catch ex As Exception
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CConfig", "GetData", ex.Message, True, ex.StackTrace, "")
        End Try
        Return lst
    End Function
End Class
