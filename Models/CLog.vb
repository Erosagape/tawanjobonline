﻿'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CLog
    Private m_ConnStr As String
    Public Sub New()
        AddNew()
    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
        AddNew()
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_LogID As Long
    Public Property LogID As Long
        Get
            Return m_LogID
        End Get
        Set(value As Long)
            m_LogID = value
        End Set
    End Property
    Private m_CustID As String
    Public Property CustID As String
        Get
            Return m_CustID
        End Get
        Set(value As String)
            m_CustID = value
        End Set
    End Property
    Private m_AppID As String
    Public Property AppID As String
        Get
            Return m_AppID
        End Get
        Set(value As String)
            m_AppID = value
        End Set
    End Property
    Private m_ModuleName As String
    Public Property ModuleName As String
        Get
            Return m_ModuleName
        End Get
        Set(value As String)
            m_ModuleName = value
        End Set
    End Property
    Private m_LogAction As String
    Public Property LogAction As String
        Get
            Return m_LogAction
        End Get
        Set(value As String)
            m_LogAction = value
        End Set
    End Property
    Private m_Message As String
    Public Property Message As String
        Get
            Return m_Message
        End Get
        Set(value As String)
            m_Message = value
        End Set
    End Property
    Private m_LogDateTime As DateTime
    Public Property LogDateTime As DateTime
        Get
            Return m_LogDateTime
        End Get
        Set(value As DateTime)
            m_LogDateTime = value
        End Set
    End Property
    Private m_IsError As Boolean
    Public Property IsError As Boolean
        Get
            Return m_IsError
        End Get
        Set(value As Boolean)
            m_IsError = value
        End Set
    End Property
    Public Property FromIP As String
    Public Property StackTrace As String
    Public Property JsonData As String

    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM TWTLog " & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("CustID") = Main.GetDBString(Me.CustID, dt.Columns("CustID"))
                            dr("AppID") = Main.GetDBString(Me.AppID, dt.Columns("AppID"))
                            dr("ModuleName") = Main.GetDBString(Me.ModuleName, dt.Columns("ModuleName"))
                            dr("LogAction") = Main.GetDBString(Me.LogAction, dt.Columns("LogAction"))
                            dr("Message") = Main.GetDBString(Me.Message, dt.Columns("Message"))
                            dr("LogDateTime") = Me.LogDateTime
                            dr("IsError") = Me.IsError
                            dr("FromIP") = Me.FromIP
                            dr("StackTrace") = Me.StackTrace
                            dr("JsonData") = Me.JsonData
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                msg = "[ERROR] " & ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()
        m_CustID = ""
        m_AppID = ""
        m_ModuleName = ""
        m_LogAction = ""
        m_Message = ""
        m_LogDateTime = DateTime.Now
        m_IsError = False
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CLog)
        Dim lst As New List(Of CLog)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CLog
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM TWTLog" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CLog(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LogID"))) = False Then
                        row.LogID = rd.GetValue(rd.GetOrdinal("LogID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CustID"))) = False Then
                        row.CustID = rd.GetString(rd.GetOrdinal("CustID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AppID"))) = False Then
                        row.AppID = rd.GetString(rd.GetOrdinal("AppID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ModuleName"))) = False Then
                        row.ModuleName = rd.GetString(rd.GetOrdinal("ModuleName")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LogAction"))) = False Then
                        row.LogAction = rd.GetString(rd.GetOrdinal("LogAction")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Message"))) = False Then
                        row.Message = rd.GetString(rd.GetOrdinal("Message")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LogDateTime"))) = False Then
                        row.LogDateTime = rd.GetDateTime(rd.GetOrdinal("LogDateTime")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("IsError"))) = False Then
                        row.IsError = rd.GetBoolean(rd.GetOrdinal("IsError")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FromIP"))) = False Then
                        row.FromIP = rd.GetString(rd.GetOrdinal("FromIP")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("StackTrace"))) = False Then
                        row.StackTrace = rd.GetString(rd.GetOrdinal("StackTrace")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("JsonData"))) = False Then
                        row.JsonData = rd.GetString(rd.GetOrdinal("JsonData")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM TWTLog" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class
