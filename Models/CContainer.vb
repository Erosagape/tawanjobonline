﻿Imports System.Data.SqlClient
Public Class CContainer
    Private mCTN_NO As String
    Private mVenderCode As String
    Private mCTN_SIZE As String
    Private mAcquisitionDate As DateTime
    Private mEndDate As DateTime
    Private mCountryCode As String
    Private mRemark As String
    Private mPurpose As String
    Private mCoolerBrand As String
    Private mCoolerInstallDate As DateTime
    Private mCoolerRefillDate As DateTime
    Private mCTN_STATUS As String
    Private conn As String
    Public Property CTN_NO As String
        Get
            Return mCTN_NO
        End Get
        Set(value As String)
            mCTN_NO = value
        End Set
    End Property
    Public Property CTN_SIZE As String
        Get
            Return mCTN_SIZE
        End Get
        Set(value As String)
            mCTN_SIZE = value
        End Set
    End Property
    Public Property VenderCode As String
        Get
            Return mVenderCode
        End Get
        Set(value As String)
            mVenderCode = value
        End Set
    End Property
    Public Property CountryCode As String
        Get
            Return mCountryCode
        End Get
        Set(value As String)
            mCountryCode = value
        End Set
    End Property
    Public Property Remark As String
        Get
            Return mRemark
        End Get
        Set(value As String)
            mRemark = value
        End Set
    End Property
    Public Property AcquisitionDate As DateTime
        Get
            Return mAcquisitionDate
        End Get
        Set(value As DateTime)
            mAcquisitionDate = value
        End Set
    End Property
    Public Property EndDate As DateTime
        Get
            Return mEndDate
        End Get
        Set(value As DateTime)
            mEndDate = value
        End Set
    End Property
    Public Property Purpose As String
        Get
            Return mPurpose
        End Get
        Set(value As String)
            mPurpose = value
        End Set
    End Property
    Public Property CoolerBrand As String
        Get
            Return mCoolerBrand
        End Get
        Set(value As String)
            mCoolerBrand = value
        End Set
    End Property
    Public Property CoolerInstallDate As DateTime
        Get
            Return mCoolerInstallDate
        End Get
        Set(value As DateTime)
            mCoolerInstallDate = value
        End Set
    End Property
    Public Property CoolerRefillDate As DateTime
        Get
            Return mCoolerRefillDate
        End Get
        Set(value As DateTime)
            mCoolerRefillDate = value
        End Set
    End Property
    Public Property CTN_STATUS As String
        Get
            Return mCTN_STATUS
        End Get
        Set(value As String)
            mCTN_STATUS = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(connstr As String)
        conn = connstr
    End Sub
    Public Sub SetConnect(connstr As String)
        conn = connstr
    End Sub
    Public Function GetData(sqlw As String) As List(Of CContainer)
        Dim lst As New List(Of CContainer)
        Using cn As New SqlConnection(conn)
            cn.Open()
            Using rd As SqlDataReader = New SqlCommand("SELECT * FROM Mas_Container " & sqlw, cn).ExecuteReader
                While rd.Read
                    Dim row = New CContainer(conn)
                    row.CTN_NO = rd.GetString(rd.GetOrdinal("CTN_NO")).ToString()
                    row.VenderCode = rd.GetString(rd.GetOrdinal("VenderCode")).ToString()
                    row.CTN_SIZE = rd.GetString(rd.GetOrdinal("CTN_SIZE")).ToString()
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AcquisitionDate"))) = False Then
                        row.AcquisitionDate = rd.GetValue(rd.GetOrdinal("AcquisitionDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("EndDate"))) = False Then
                        row.EndDate = rd.GetValue(rd.GetOrdinal("EndDate"))
                    End If
                    row.CountryCode = rd.GetString(rd.GetOrdinal("CountryCode"))
                    row.Remark = rd.GetString(rd.GetOrdinal("Remark"))
                    row.CTN_STATUS = rd.GetString(rd.GetOrdinal("CTN_STATUS")).ToString()
                    row.CoolerBrand = rd.GetString(rd.GetOrdinal("CoolerBrand")).ToString()
                    row.Purpose = rd.GetString(rd.GetOrdinal("Purpose")).ToString()
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CoolerInstallDate"))) = False Then
                        row.CoolerInstallDate = rd.GetValue(rd.GetOrdinal("CoolerInstallDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CoolerRefillDate"))) = False Then
                        row.CoolerRefillDate = rd.GetValue(rd.GetOrdinal("CoolerRefillDate"))
                    End If
                    lst.Add(row)
                End While
                rd.Close()
            End Using
            cn.Close()
        End Using
        Return lst
    End Function
    Public Function SaveData(sqlw As String) As String
        Dim msg = "Save Complete"
        Using cn As New SqlConnection(conn)
            cn.Open()
            Using da As New SqlDataAdapter("SELECT * FROM Mas_Container " & sqlw, cn)
                Using cb As New SqlCommandBuilder(da)
                    Using dt As New DataTable
                        da.Fill(dt)
                        Dim dr As DataRow = dt.NewRow
                        If dt.Rows.Count > 0 Then
                            dr = dt.Rows(0)
                        End If
                        dr("CTN_NO") = Me.CTN_NO
                        dr("VenderCode") = Me.VenderCode
                        dr("CTN_SIZE") = Me.CTN_SIZE
                        dr("AcquisitionDate") = Main.GetDBDate(Me.AcquisitionDate)
                        dr("EndDate") = Main.GetDBDate(Me.EndDate)
                        dr("CountryCode") = Me.CountryCode
                        dr("Remark") = Me.Remark
                        dr("Purpose") = Me.Purpose
                        dr("CoolerBrand") = Me.CoolerBrand
                        dr("CTN_STATUS") = Me.CTN_STATUS
                        dr("CoolerRefillDate") = Main.GetDBDate(Me.CoolerRefillDate)
                        dr("CoolerInstallDate") = Main.GetDBDate(Me.CoolerInstallDate)
                        If dt.Rows.Count = 0 Then
                            dt.Rows.Add(dr)
                        End If
                        If da.Update(dt) > 0 Then
                            msg = "Save Complete"
                        Else
                            msg = "Save Failed"
                        End If
                    End Using
                End Using
            End Using
            cn.Close()
        End Using
        Return msg
    End Function
End Class