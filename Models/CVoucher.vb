﻿'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CVoucher
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_BranchCode As String
    Public Property BranchCode As String
        Get
            Return m_BranchCode
        End Get
        Set(value As String)
            m_BranchCode = value
        End Set
    End Property
    Private m_ControlNo As String
    Public Property ControlNo As String
        Get
            Return m_ControlNo
        End Get
        Set(value As String)
            m_ControlNo = value
        End Set
    End Property
    Private m_VoucherDate As Date
    Public Property VoucherDate As Date
        Get
            Return m_VoucherDate
        End Get
        Set(value As Date)
            m_VoucherDate = value
        End Set
    End Property
    Private m_TRemark As String
    Public Property TRemark As String
        Get
            Return m_TRemark
        End Get
        Set(value As String)
            m_TRemark = value
        End Set
    End Property
    Private m_RecUser As String
    Public Property RecUser As String
        Get
            Return m_RecUser
        End Get
        Set(value As String)
            m_RecUser = value
        End Set
    End Property
    Private m_RecDate As Date
    Public Property RecDate As Date
        Get
            Return m_RecDate
        End Get
        Set(value As Date)
            m_RecDate = value
        End Set
    End Property
    Private m_RecTime As Date
    Public Property RecTime As Date
        Get
            Return m_RecTime
        End Get
        Set(value As Date)
            m_RecTime = value
        End Set
    End Property
    Private m_PostedBy As String
    Public Property PostedBy As String
        Get
            Return m_PostedBy
        End Get
        Set(value As String)
            m_PostedBy = value
        End Set
    End Property
    Private m_PostedDate As Date
    Public Property PostedDate As Date
        Get
            Return m_PostedDate
        End Get
        Set(value As Date)
            m_PostedDate = value
        End Set
    End Property
    Private m_PostedTime As Date
    Public Property PostedTime As Date
        Get
            Return m_PostedTime
        End Get
        Set(value As Date)
            m_PostedTime = value
        End Set
    End Property
    Private m_CancelReson As String
    Public Property CancelReson As String
        Get
            Return m_CancelReson
        End Get
        Set(value As String)
            m_CancelReson = value
        End Set
    End Property
    Private m_CancelProve As String
    Public Property CancelProve As String
        Get
            Return m_CancelProve
        End Get
        Set(value As String)
            m_CancelProve = value
        End Set
    End Property
    Private m_CancelDate As Date
    Public Property CancelDate As Date
        Get
            Return m_CancelDate
        End Get
        Set(value As Date)
            m_CancelDate = value
        End Set
    End Property
    Private m_CancelTime As Date
    Public Property CancelTime As Date
        Get
            Return m_CancelTime
        End Get
        Set(value As Date)
            m_CancelTime = value
        End Set
    End Property
    Private m_CustCode As String
    Public Property CustCode As String
        Get
            Return m_CustCode
        End Get
        Set(value As String)
            m_CustCode = value
        End Set
    End Property
    Private m_CustBranch As String
    Public Property CustBranch As String
        Get
            Return m_CustBranch
        End Get
        Set(value As String)
            m_CustBranch = value
        End Set
    End Property
    Private m_PostRefNo As String
    Public Property PostRefNo As String
        Get
            Return m_PostRefNo
        End Get
        Set(value As String)
            m_PostRefNo = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_CashControl" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("BranchCode") = Main.GetDBString(Me.BranchCode, dt.Columns("BranchCode"))
                            dr("ControlNo") = Main.GetDBString(Me.ControlNo, dt.Columns("ControlNo"))
                            dr("VoucherDate") = Main.GetDBDate(Me.VoucherDate)
                            dr("TRemark") = Main.GetDBString(Me.TRemark, dt.Columns("TRemark"))
                            dr("RecUser") = Main.GetDBString(Me.RecUser, dt.Columns("RecUser"))
                            dr("RecDate") = Main.GetDBDate(Me.RecDate)
                            dr("RecTime") = Main.GetDBTime(Me.RecTime)
                            dr("PostedBy") = Main.GetDBString(Me.PostedBy, dt.Columns("PostedBy"))
                            dr("PostedDate") = Main.GetDBDate(Me.PostedDate)
                            dr("PostedTime") = Main.GetDBTime(Me.PostedTime)
                            dr("CancelReson") = Main.GetDBString(Me.CancelReson, dt.Columns("CancelReson"))
                            dr("CancelProve") = Main.GetDBString(Me.CancelProve, dt.Columns("CancelProve"))
                            dr("CancelDate") = Main.GetDBDate(Me.CancelDate)
                            dr("CancelTime") = Main.GetDBTime(Me.CancelTime)
                            dr("CustCode") = Main.GetDBString(Me.CustCode, dt.Columns("CustCode"))
                            dr("CustBranch") = Main.GetDBString(Me.CustBranch, dt.Columns("CustBranch"))
                            dr("PostRefNo") = Main.GetDBString(Me.PostRefNo, dt.Columns("PostRefNo"))
                            If Me.CancelProve <> "" Then
                                Me.CancelData()
                            End If
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CVoucher", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CVoucher", "SaveData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub CancelData()
        Main.DBExecute(GetSession("ConnJob"), "UPDATE Job_AdvHeader SET PaymentRef='',PaymentDate=NULL,PaymentTime=NULL,PaymentBy='' WHERE PaymentRef='" & Me.ControlNo & "'")
        Main.DBExecute(GetSession("ConnJob"), "UPDATE Job_ClearHeader SET ReceiveRef='',ReceiveDate=NULL,ReceiveTime=NULL,ReceiveBy='' WHERE ReceiveRef='" & Me.ControlNo & "'")
        Main.DBExecute(GetSession("ConnJob"), "UPDATE Job_ClearDetail SET LinkBillNo='',LinkItem=0 WHERE LinkBillNo='" & Me.ControlNo & "'")
        Dim oSub = New CVoucherSub(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND ControlNo='{1}'", Me.BranchCode, Me.ControlNo))
        If oSub.Count > 0 Then
            For Each row In oSub
                row.CancelData()
            Next
        End If
        Dim oDtl As New CVoucherDoc(GetSession("ConnJob"))
        Dim oRows = oDtl.GetData(String.Format(" WHERE BranchCode='{0}' AND ControlNo='{1}' ", Me.BranchCode, Me.ControlNo))
        If oRows.Count > 0 Then
            For Each row In oRows
                row.DeleteData()
            Next
        End If
    End Sub
    Public Sub AddNew(pFormatSQL As String)
        If pFormatSQL = "" Then
            m_ControlNo = ""
        Else
            Dim tSql As String = String.Format("SELECT MAX(ControlNo) as t FROM Job_CashControl WHERE BranchCode='{0}' And ControlNo Like '%{1}' ", m_BranchCode, pFormatSQL)
            Dim retStr As String = Main.GetMaxByMask(m_ConnStr, tSql, pFormatSQL)
            m_ControlNo = retStr
        End If
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CVoucher)
        Dim lst As New List(Of CVoucher)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CVoucher
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_CashControl" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CVoucher(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ControlNo"))) = False Then
                        row.ControlNo = rd.GetString(rd.GetOrdinal("ControlNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("VoucherDate"))) = False Then
                        row.VoucherDate = rd.GetValue(rd.GetOrdinal("VoucherDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TRemark"))) = False Then
                        row.TRemark = rd.GetString(rd.GetOrdinal("TRemark")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("RecUser"))) = False Then
                        row.RecUser = rd.GetString(rd.GetOrdinal("RecUser")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("RecDate"))) = False Then
                        row.RecDate = rd.GetValue(rd.GetOrdinal("RecDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("RecTime"))) = False Then
                        row.RecTime = rd.GetValue(rd.GetOrdinal("RecTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PostedBy"))) = False Then
                        row.PostedBy = rd.GetString(rd.GetOrdinal("PostedBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PostedDate"))) = False Then
                        row.PostedDate = rd.GetValue(rd.GetOrdinal("PostedDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PostedTime"))) = False Then
                        row.PostedTime = rd.GetValue(rd.GetOrdinal("PostedTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CancelReson"))) = False Then
                        row.CancelReson = rd.GetString(rd.GetOrdinal("CancelReson")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CancelProve"))) = False Then
                        row.CancelProve = rd.GetString(rd.GetOrdinal("CancelProve")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CancelDate"))) = False Then
                        row.CancelDate = rd.GetValue(rd.GetOrdinal("CancelDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CancelTime"))) = False Then
                        row.CancelTime = rd.GetValue(rd.GetOrdinal("CancelTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CustCode"))) = False Then
                        row.CustCode = rd.GetString(rd.GetOrdinal("CustCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CustBranch"))) = False Then
                        row.CustBranch = rd.GetString(rd.GetOrdinal("CustBranch")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PostRefNo"))) = False Then
                        row.PostRefNo = rd.GetString(rd.GetOrdinal("PostRefNo")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CVoucher", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Job_CashControl" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CVoucher", "DeleteData", cm.CommandText, False)
                End Using
                Me.CancelData()
                msg = "Delete Complete"
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CVoucher", "DeleteData", ex.Message, True, ex.StackTrace, "")
                msg = "[ERROR]" & ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class