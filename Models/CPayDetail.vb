﻿Imports System.Data.SqlClient
Public Class CPayDetail
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
    Private m_DocNo As String
    Public Property DocNo As String
        Get
            Return m_DocNo
        End Get
        Set(value As String)
            m_DocNo = value
        End Set
    End Property
    Private m_ItemNo As Integer
    Public Property ItemNo As Integer
        Get
            Return m_ItemNo
        End Get
        Set(value As Integer)
            m_ItemNo = value
        End Set
    End Property
    Private m_SICode As String
    Public Property SICode As String
        Get
            Return m_SICode
        End Get
        Set(value As String)
            m_SICode = value
        End Set
    End Property
    Private m_SDescription As String
    Public Property SDescription As String
        Get
            Return m_SDescription
        End Get
        Set(value As String)
            m_SDescription = value
        End Set
    End Property
    Private m_SRemark As String
    Public Property SRemark As String
        Get
            Return m_SRemark
        End Get
        Set(value As String)
            m_SRemark = value
        End Set
    End Property
    Private m_Qty As Double
    Public Property Qty As Double
        Get
            Return m_Qty
        End Get
        Set(value As Double)
            m_Qty = value
        End Set
    End Property
    Private m_QtyUnit As String
    Public Property QtyUnit As String
        Get
            Return m_QtyUnit
        End Get
        Set(value As String)
            m_QtyUnit = value
        End Set
    End Property
    Private m_UnitPrice As Double
    Public Property UnitPrice As Double
        Get
            Return m_UnitPrice
        End Get
        Set(value As Double)
            m_UnitPrice = value
        End Set
    End Property
    Private m_IsTaxCharge As Integer
    Public Property IsTaxCharge As Integer
        Get
            Return m_IsTaxCharge
        End Get
        Set(value As Integer)
            m_IsTaxCharge = value
        End Set
    End Property
    Private m_Is50Tavi As Integer
    Public Property Is50Tavi As Integer
        Get
            Return m_Is50Tavi
        End Get
        Set(value As Integer)
            m_Is50Tavi = value
        End Set
    End Property
    Private m_DiscountPerc As Double
    Public Property DiscountPerc As Double
        Get
            Return m_DiscountPerc
        End Get
        Set(value As Double)
            m_DiscountPerc = value
        End Set
    End Property
    Private m_Amt As Double
    Public Property Amt As Double
        Get
            Return m_Amt
        End Get
        Set(value As Double)
            m_Amt = value
        End Set
    End Property
    Private m_AmtDisc As Double
    Public Property AmtDisc As Double
        Get
            Return m_AmtDisc
        End Get
        Set(value As Double)
            m_AmtDisc = value
        End Set
    End Property
    Private m_AmtVAT As Double
    Public Property AmtVAT As Double
        Get
            Return m_AmtVAT
        End Get
        Set(value As Double)
            m_AmtVAT = value
        End Set
    End Property
    Private m_AmtWHT As Double
    Public Property AmtWHT As Double
        Get
            Return m_AmtWHT
        End Get
        Set(value As Double)
            m_AmtWHT = value
        End Set
    End Property
    Private m_Total As Double
    Public Property Total As Double
        Get
            Return m_Total
        End Get
        Set(value As Double)
            m_Total = value
        End Set
    End Property
    Private m_FTotal As Double
    Public Property FTotal As Double
        Get
            Return m_FTotal
        End Get
        Set(value As Double)
            m_FTotal = value
        End Set
    End Property
    Private m_ForJNo As String
    Public Property ForJNo As String
        Get
            Return m_ForJNo
        End Get
        Set(value As String)
            m_ForJNo = value
        End Set
    End Property

    Private m_ClrRefNo As String
    Public Property ClrRefNo As String
        Get
            Return m_ClrRefNo
        End Get
        Set(value As String)
            m_ClrRefNo = value
        End Set
    End Property
    Private m_BookingRefNo As String
    Public Property BookingRefNo As String
        Get
            Return m_BookingRefNo
        End Get
        Set(value As String)
            m_BookingRefNo = value
        End Set
    End Property
    Private m_AdvItemNo As Integer
    Public Property AdvItemNo As Integer
        Get
            Return m_AdvItemNo
        End Get
        Set(value As Integer)
            m_AdvItemNo = value
        End Set
    End Property
    Private m_ClrItemNo As Integer
    Public Property ClrItemNo As Integer
        Get
            Return m_ClrItemNo
        End Get
        Set(value As Integer)
            m_ClrItemNo = value
        End Set
    End Property
    Private m_BookingItemNo As Integer
    Public Property BookingItemNo As Integer
        Get
            Return m_BookingItemNo
        End Get
        Set(value As Integer)
            m_BookingItemNo = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_PaymentDetail" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("BranchCode") = Main.GetDBString(Me.BranchCode, dt.Columns("BranchCode"))
                            dr("DocNo") = Main.GetDBString(Me.DocNo, dt.Columns("DocNo"))
                            If Me.ItemNo = 0 Then Me.AddNew()
                            dr("ItemNo") = Main.GetDBString(Me.ItemNo, dt.Columns("ItemNo"))
                            dr("SICode") = Main.GetDBString(Me.SICode, dt.Columns("SICode"))
                            dr("SDescription") = Main.GetDBString(Me.SDescription, dt.Columns("SDescription"))
                            dr("SRemark") = Main.GetDBString(Me.SRemark, dt.Columns("SRemark"))
                            dr("Qty") = Me.Qty
                            dr("QtyUnit") = Main.GetDBString(Me.QtyUnit, dt.Columns("QtyUnit"))
                            dr("UnitPrice") = Me.UnitPrice
                            dr("IsTaxCharge") = Main.GetDBString(Me.IsTaxCharge, dt.Columns("IsTaxCharge"))
                            dr("Is50Tavi") = Main.GetDBString(Me.Is50Tavi, dt.Columns("Is50Tavi"))
                            dr("DiscountPerc") = Me.DiscountPerc
                            dr("Amt") = Me.Amt
                            dr("AmtDisc") = Me.AmtDisc
                            dr("AmtVAT") = Me.AmtVAT
                            dr("AmtWHT") = Me.AmtWHT
                            dr("Total") = Me.Total
                            dr("FTotal") = Me.FTotal
                            dr("ForJNo") = Main.GetDBString(Me.ForJNo, dt.Columns("ForJNo"))
                            dr("ClrRefNo") = Main.GetDBString(Me.ClrRefNo, dt.Columns("ClrRefNo"))
                            dr("BookingRefNo") = Main.GetDBString(Me.BookingRefNo, dt.Columns("BookingRefNo"))
                            dr("AdvItemNo") = Me.AdvItemNo
                            dr("ClrItemNo") = Me.ClrItemNo
                            dr("BookingItemNo") = Me.BookingItemNo
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            UpdateTotal(cn)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CPayDetail", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CPayDetail", "SaveData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()
        Dim retStr As String = Main.GetMaxByMask(m_ConnStr, String.Format("SELECT MAX(ItemNo) as t FROM Job_PaymentDetail WHERE BranchCode='{0}' And DocNo ='{1}' ", m_BranchCode, m_DocNo), "____")
        m_ItemNo = Convert.ToInt32("0" & retStr)
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CPayDetail)
        Dim lst As New List(Of CPayDetail)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CPayDetail
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_PaymentDetail" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CPayDetail(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocNo"))) = False Then
                        row.DocNo = rd.GetString(rd.GetOrdinal("DocNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ItemNo"))) = False Then
                        row.ItemNo = rd.GetInt16(rd.GetOrdinal("ItemNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SICode"))) = False Then
                        row.SICode = rd.GetString(rd.GetOrdinal("SICode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SDescription"))) = False Then
                        row.SDescription = rd.GetString(rd.GetOrdinal("SDescription")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SRemark"))) = False Then
                        row.SRemark = rd.GetString(rd.GetOrdinal("SRemark")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Qty"))) = False Then
                        row.Qty = rd.GetValue(rd.GetOrdinal("Qty"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("QtyUnit"))) = False Then
                        row.QtyUnit = rd.GetString(rd.GetOrdinal("QtyUnit")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UnitPrice"))) = False Then
                        row.UnitPrice = rd.GetDouble(rd.GetOrdinal("UnitPrice")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("IsTaxCharge"))) = False Then
                        row.IsTaxCharge = rd.GetByte(rd.GetOrdinal("IsTaxCharge"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Is50Tavi"))) = False Then
                        row.Is50Tavi = rd.GetByte(rd.GetOrdinal("Is50Tavi"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DiscountPerc"))) = False Then
                        row.DiscountPerc = rd.GetDouble(rd.GetOrdinal("DiscountPerc"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Amt"))) = False Then
                        row.Amt = rd.GetDouble(rd.GetOrdinal("Amt"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AmtDisc"))) = False Then
                        row.AmtDisc = rd.GetDouble(rd.GetOrdinal("AmtDisc"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AmtVAT"))) = False Then
                        row.AmtVAT = rd.GetDouble(rd.GetOrdinal("AmtVAT"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AmtWHT"))) = False Then
                        row.AmtWHT = rd.GetDouble(rd.GetOrdinal("AmtWHT"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Total"))) = False Then
                        row.Total = rd.GetDouble(rd.GetOrdinal("Total"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FTotal"))) = False Then
                        row.FTotal = rd.GetDouble(rd.GetOrdinal("FTotal"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ForJNo"))) = False Then
                        row.ForJNo = rd.GetString(rd.GetOrdinal("ForJNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AdvItemNo"))) = False Then
                        row.AdvItemNo = rd.GetValue(rd.GetOrdinal("AdvItemNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ClrRefNo"))) = False Then
                        row.ClrRefNo = rd.GetString(rd.GetOrdinal("ClrRefNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ClrItemNo"))) = False Then
                        row.ClrItemNo = rd.GetValue(rd.GetOrdinal("ClrItemNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BookingRefNo"))) = False Then
                        row.BookingRefNo = rd.GetString(rd.GetOrdinal("BookingRefNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BookingItemNo"))) = False Then
                        row.BookingItemNo = rd.GetValue(rd.GetOrdinal("BookingItemNo"))
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CPayDetail", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Job_PaymentDetail" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()

                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CPayDetail", "DeleteData", cm.CommandText, False)
                    UpdateTotal(cn, True)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CPayDetail", "DeleteData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub UpdateTotal(cn As SqlConnection, Optional IsDelete As Boolean = False)
        Dim sql As String = SQLUpdatePayHeader()

        Using cm As New SqlCommand(sql, cn)
            cm.CommandText = sql & " WHERE b.BranchCode='" + Me.BranchCode + "' and b.DocNo='" + Me.DocNo + "'"
            cm.CommandType = CommandType.Text
            cm.ExecuteNonQuery()
            If Me.ClrRefNo <> "" Then
                If IsDelete = True Then
                    cm.CommandText = "UPDATE Job_ClearDetail SET VenderBillingNo='' WHERE ClrNo='" & Me.ClrRefNo & "' AND ItemNo=" & Me.ClrItemNo & ""
                Else
                    cm.CommandText = "UPDATE Job_ClearDetail SET VenderBillingNo='" & Me.DocNo & "#" & Me.ItemNo & "' WHERE ClrNo='" & Me.ClrRefNo & "' AND ItemNo=" & Me.ClrItemNo & ""
                End If
                cm.ExecuteNonQuery()
            End If
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CPayDetail", "UpdatePayHeader", cm.CommandText, False)
        End Using
    End Sub
End Class
