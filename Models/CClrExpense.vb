'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CClearExp
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
    Private m_JNo As String
    Public Property JNo As String
        Get
            Return m_JNo
        End Get
        Set(value As String)
            m_JNo = value
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
    Private m_TRemark As String
    Public Property TRemark As String
        Get
            Return m_TRemark
        End Get
        Set(value As String)
            m_TRemark = value
        End Set
    End Property
    Private m_AmountCharge As Double
    Public Property AmountCharge As Double
        Get
            Return m_AmountCharge
        End Get
        Set(value As Double)
            m_AmountCharge = value
        End Set
    End Property
    Private m_Status As String
    Public Property Status As String
        Get
            Return m_Status
        End Get
        Set(value As String)
            m_Status = value
        End Set
    End Property
    Private m_CurrencyCode As String
    Public Property CurrencyCode As String
        Get
            Return m_CurrencyCode
        End Get
        Set(value As String)
            m_CurrencyCode = value
        End Set
    End Property
    Private m_ExchangeRate As Double
    Public Property ExchangeRate As Double
        Get
            Return m_ExchangeRate
        End Get
        Set(value As Double)
            m_ExchangeRate = value
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
    Private m_AmtVatRate As Double
    Public Property AmtVatRate As Double
        Get
            Return m_AmtVatRate
        End Get
        Set(value As Double)
            m_AmtVatRate = value
        End Set
    End Property
    Private m_AmtVat As Double
    Public Property AmtVat As Double
        Get
            Return m_AmtVat
        End Get
        Set(value As Double)
            m_AmtVat = value
        End Set
    End Property
    Private m_AmtWhtRate As Double
    Public Property AmtWhtRate As Double
        Get
            Return m_AmtWhtRate
        End Get
        Set(value As Double)
            m_AmtWhtRate = value
        End Set
    End Property
    Private m_AmtWht As Double
    Public Property AmtWht As Double
        Get
            Return m_AmtWht
        End Get
        Set(value As Double)
            m_AmtWht = value
        End Set
    End Property
    Private m_AmtTotal As Double
    Public Property AmtTotal As Double
        Get
            Return m_AmtTotal
        End Get
        Set(value As Double)
            m_AmtTotal = value
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
    Private m_QNo As String
    Public Property QNo As String
        Get
            Return m_QNo
        End Get
        Set(value As String)
            m_QNo = value
        End Set
    End Property
    Private m_QSeqNo As Integer
    Public Property QSeqNo As Integer
        Get
            Return m_QSeqNo
        End Get
        Set(value As Integer)
            m_QSeqNo = value
        End Set
    End Property
    Private m_QItemNo As Integer
    Public Property QItemNo As Integer
        Get
            Return m_QItemNo
        End Get
        Set(value As Integer)
            m_QItemNo = value
        End Set
    End Property
    Private m_ClrNo As String
    Public Property ClrNo As String
        Get
            Return m_ClrNo
        End Get
        Set(value As String)
            m_ClrNo = value
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
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_ClearExp" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("BranchCode") = Main.GetDBString(Me.BranchCode, dt.Columns("BranchCode"))
                            dr("JNo") = Main.GetDBString(Me.JNo, dt.Columns("JNo"))
                            dr("SICode") = Main.GetDBString(Me.SICode, dt.Columns("SICode"))
                            dr("ItemNo") = Me.ItemNo
                            dr("SDescription") = Main.GetDBString(Me.SDescription, dt.Columns("SDescription"))
                            dr("TRemark") = Main.GetDBString(Me.TRemark, dt.Columns("TRemark"))
                            dr("AmountCharge") = Me.AmountCharge
                            dr("Status") = Main.GetDBString(Me.Status, dt.Columns("Status"))
                            dr("CurrencyCode") = Main.GetDBString(Me.CurrencyCode, dt.Columns("CurrencyCode"))
                            dr("ExchangeRate") = Me.ExchangeRate
                            dr("Qty") = Me.Qty
                            dr("QtyUnit") = Main.GetDBString(Me.QtyUnit, dt.Columns("QtyUnit"))
                            dr("AmtVatRate") = Me.AmtVatRate
                            dr("AmtVat") = Me.AmtVat
                            dr("AmtWhtRate") = Me.AmtWhtRate
                            dr("AmtWht") = Me.AmtWht
                            dr("AmtTotal") = Me.AmtTotal
                            dr("QNo") = Me.QNo
                            dr("QItemNo") = Me.QItemNo
                            dr("QSeqNo") = Me.QSeqNo
                            dr("ClrNo") = Me.ClrNo
                            dr("ClrItemNo") = Me.ClrItemNo
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CClrExpense", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CClrExpense", "SaveData", ex.Message, True, ex.StackTrace, "")
                msg = "[ERROR]:" & ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()
        Dim retStr As String = Main.GetMaxByMask(m_ConnStr, String.Format("SELECT MAX(ItemNo) as t FROM Job_ClearExp WHERE BranchCode='{0}' And JNo ='{1}' And SICode='{2}' ", m_BranchCode, m_JNo, m_SICode), "____")
        m_ItemNo = Convert.ToInt32("0" & retStr)
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CClearExp)
        Dim lst As New List(Of CClearExp)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CClearExp
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_ClearExp" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CClearExp(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("JNo"))) = False Then
                        row.JNo = rd.GetValue(rd.GetOrdinal("JNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SICode"))) = False Then
                        row.SICode = rd.GetString(rd.GetOrdinal("SICode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SDescription"))) = False Then
                        row.SDescription = rd.GetString(rd.GetOrdinal("SDescription")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TRemark"))) = False Then
                        row.TRemark = rd.GetString(rd.GetOrdinal("TRemark")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AmountCharge"))) = False Then
                        row.AmountCharge = rd.GetDouble(rd.GetOrdinal("AmountCharge"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Status"))) = False Then
                        row.Status = rd.GetString(rd.GetOrdinal("Status")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CurrencyCode"))) = False Then
                        row.CurrencyCode = rd.GetString(rd.GetOrdinal("CurrencyCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ExchangeRate"))) = False Then
                        row.ExchangeRate = rd.GetDouble(rd.GetOrdinal("ExchangeRate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Qty"))) = False Then
                        row.Qty = rd.GetDouble(rd.GetOrdinal("Qty"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ItemNo"))) = False Then
                        row.ItemNo = rd.GetInt32(rd.GetOrdinal("ItemNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("QtyUnit"))) = False Then
                        row.QtyUnit = rd.GetString(rd.GetOrdinal("QtyUnit")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AmtVatRate"))) = False Then
                        row.AmtVatRate = rd.GetDouble(rd.GetOrdinal("AmtVatRate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AmtVat"))) = False Then
                        row.AmtVat = rd.GetDouble(rd.GetOrdinal("AmtVat"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AmtWhtRate"))) = False Then
                        row.AmtWhtRate = rd.GetDouble(rd.GetOrdinal("AmtWhtRate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AmtWht"))) = False Then
                        row.AmtWht = rd.GetDouble(rd.GetOrdinal("AmtWht"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AmtTotal"))) = False Then
                        row.AmtTotal = rd.GetDouble(rd.GetOrdinal("AmtTotal"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("QNo"))) = False Then
                        row.QNo = rd.GetString(rd.GetOrdinal("QNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("QItemNo"))) = False Then
                        row.QItemNo = rd.GetInt32(rd.GetOrdinal("QItemNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("QSeqNo"))) = False Then
                        row.QSeqNo = rd.GetInt32(rd.GetOrdinal("QSeqNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ClrNo"))) = False Then
                        row.ClrNo = rd.GetString(rd.GetOrdinal("ClrNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ClrItemNo"))) = False Then
                        row.ClrItemNo = rd.GetInt32(rd.GetOrdinal("ClrItemNo"))
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CClrExpense", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Job_ClearExp" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CClrExpense", "DeleteData", cm.CommandText, False)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CClrExpense", "DeleteData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class
