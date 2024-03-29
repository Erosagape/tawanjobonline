﻿'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CProvince
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_ProvinceCode As String
    Public Property ProvinceCode As String
        Get
            Return m_ProvinceCode
        End Get
        Set(value As String)
            m_ProvinceCode = value
        End Set
    End Property
    Private m_ProvinceName As String
    Public Property ProvinceName As String
        Get
            Return m_ProvinceName
        End Get
        Set(value As String)
            m_ProvinceName = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Mas_Province" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("ProvinceCode") = Main.GetDBString(Me.ProvinceCode, dt.Columns(0))
                            dr("ProvinceName") = Main.GetDBString(Me.ProvinceName, dt.Columns(1))
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CProvince", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CProvince", "SaveData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()
        m_ProvinceCode = ""
        m_ProvinceName = ""
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CProvince)
        Dim lst As New List(Of CProvince)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CProvince
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Mas_Province" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CProvince(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProvinceCode"))) = False Then
                        row.ProvinceCode = rd.GetString(rd.GetOrdinal("ProvinceCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProvinceName"))) = False Then
                        row.ProvinceName = rd.GetString(rd.GetOrdinal("ProvinceName")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CProvince", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Mas_Province" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CProvince", "DeleteData", cm.CommandText, False)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CProvince", "DeleteData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class
Public Class CProvinceSub
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_ProvinceCode As String
    Public Property ProvinceCode As String
        Get
            Return m_ProvinceCode
        End Get
        Set(value As String)
            m_ProvinceCode = value
        End Set
    End Property
    Private m_SubProvince As String
    Public Property SubProvince As String
        Get
            Return m_SubProvince
        End Get
        Set(value As String)
            m_SubProvince = value
        End Set
    End Property
    Private m_District As String
    Public Property District As String
        Get
            Return m_District
        End Get
        Set(value As String)
            m_District = value
        End Set
    End Property
    Private m_PostCode As String
    Public Property PostCode As String
        Get
            Return m_PostCode
        End Get
        Set(value As String)
            m_PostCode = value
        End Set
    End Property
    Private m_id As Integer
    Public Property id As Integer
        Get
            Return m_id
        End Get
        Set(value As Integer)
            m_id = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Mas_ProvinceSub" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("ProvinceCode") = Main.GetDBString(Me.ProvinceCode, dt.Columns("ProvinceCode"))
                            dr("SubProvince") = Main.GetDBString(Me.SubProvince, dt.Columns("SubProvince"))
                            dr("District") = Main.GetDBString(Me.District, dt.Columns("District"))
                            dr("PostCode") = Main.GetDBString(Me.PostCode, dt.Columns("PostCode"))

                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CProvinceSub", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CProvinceSub", "SaveData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()
        m_id = 0
        m_ProvinceCode = ""
        m_SubProvince = ""
        m_District = ""
        m_PostCode = ""
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CProvinceSub)
        Dim lst As New List(Of CProvinceSub)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CProvinceSub
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Mas_ProvinceSub" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CProvinceSub(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProvinceCode"))) = False Then
                        row.ProvinceCode = rd.GetString(rd.GetOrdinal("ProvinceCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SubProvince"))) = False Then
                        row.SubProvince = rd.GetString(rd.GetOrdinal("SubProvince")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("District"))) = False Then
                        row.District = rd.GetString(rd.GetOrdinal("District")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PostCode"))) = False Then
                        row.PostCode = rd.GetString(rd.GetOrdinal("PostCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("id"))) = False Then
                        row.id = rd.GetValue(rd.GetOrdinal("id")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CProvinceSub", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Mas_ProvinceSub" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CProvinceSub", "DeleteData", cm.CommandText, False)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CProvinceSub", "DeleteData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class
