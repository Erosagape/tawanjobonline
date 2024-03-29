﻿'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CUserAuth
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_UserID As String
    Public Property UserID As String
        Get
            Return m_UserID
        End Get
        Set(value As String)
            m_UserID = value
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
    Private m_MenuID As String
    Public Property MenuID As String
        Get
            Return m_MenuID
        End Get
        Set(value As String)
            m_MenuID = value
        End Set
    End Property
    Private m_Author As String
    Public Property Author As String
        Get
            Return m_Author
        End Get
        Set(value As String)
            m_Author = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Mas_UserAuth" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("UserID") = Main.GetDBString(Me.UserID, dt.Columns("UserID"))
                            dr("AppID") = Main.GetDBString(Me.AppID, dt.Columns("AppID"))
                            dr("MenuID") = Main.GetDBString(Me.MenuID, dt.Columns("MenuID"))
                            dr("Author") = Main.GetDBString(Me.Author, dt.Columns("Author"))
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CUserAuth", "SaveData", Me, False)
                            If GetSession("CurrentLang") = "TH" Then
                                msg = "บันทึกสิทธิ์ใน " & Me.MenuID & " ให้กับ " & Me.UserID & " เรียบร้อย"
                            Else
                                msg = "Save Authorize of " & Me.MenuID & " For " & Me.UserID & " Complete"
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CUserAuth", "SaveData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()

        m_UserID = ""
        m_AppID = ""
        m_MenuID = ""
        m_Author = ""
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CUserAuth)
        Dim lst As New List(Of CUserAuth)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CUserAuth
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Mas_UserAuth" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CUserAuth(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UserID"))) = False Then
                        row.UserID = rd.GetString(rd.GetOrdinal("UserID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AppID"))) = False Then
                        row.AppID = rd.GetString(rd.GetOrdinal("AppID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("MenuID"))) = False Then
                        row.MenuID = rd.GetString(rd.GetOrdinal("MenuID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Author"))) = False Then
                        row.Author = rd.GetString(rd.GetOrdinal("Author")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CUserAuth", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Mas_UserAuth" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CUserAuth", "DeleteData", cm.CommandText, False)
                End Using
                msg = "Delete Complete"
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CUserAuth", "DeleteData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class