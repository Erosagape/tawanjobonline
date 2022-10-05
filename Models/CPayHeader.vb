Imports System.Data.SqlClient
Public Class CPayHeader
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
    Private m_DocDate As Date
    Public Property DocDate As Date
        Get
            Return m_DocDate
        End Get
        Set(value As Date)
            m_DocDate = value
        End Set
    End Property
    Private m_VenCode As String
    Public Property VenCode As String
        Get
            Return m_VenCode
        End Get
        Set(value As String)
            m_VenCode = value
        End Set
    End Property
    Private m_ContactName As String
    Public Property ContactName As String
        Get
            Return m_ContactName
        End Get
        Set(value As String)
            m_ContactName = value
        End Set
    End Property
    Private m_EmpCode As String
    Public Property EmpCode As String
        Get
            Return m_EmpCode
        End Get
        Set(value As String)
            m_EmpCode = value
        End Set
    End Property
    Private m_PoNo As String
    Public Property PoNo As String
        Get
            Return m_PoNo
        End Get
        Set(value As String)
            m_PoNo = value
        End Set
    End Property
    Private m_VATRate As Double
    Public Property VATRate As Double
        Get
            Return m_VATRate
        End Get
        Set(value As Double)
            m_VATRate = value
        End Set
    End Property
    Private m_TaxRate As Double
    Public Property TaxRate As Double
        Get
            Return m_TaxRate
        End Get
        Set(value As Double)
            m_TaxRate = value
        End Set
    End Property
    Private m_TotalExpense As Double
    Public Property TotalExpense As Double
        Get
            Return m_TotalExpense
        End Get
        Set(value As Double)
            m_TotalExpense = value
        End Set
    End Property
    Private m_TotalTax As Double
    Public Property TotalTax As Double
        Get
            Return m_TotalTax
        End Get
        Set(value As Double)
            m_TotalTax = value
        End Set
    End Property
    Private m_TotalVAT As Double
    Public Property TotalVAT As Double
        Get
            Return m_TotalVAT
        End Get
        Set(value As Double)
            m_TotalVAT = value
        End Set
    End Property
    Private m_TotalDiscount As Double
    Public Property TotalDiscount As Double
        Get
            Return m_TotalDiscount
        End Get
        Set(value As Double)
            m_TotalDiscount = value
        End Set
    End Property
    Private m_TotalNet As Double
    Public Property TotalNet As Double
        Get
            Return m_TotalNet
        End Get
        Set(value As Double)
            m_TotalNet = value
        End Set
    End Property
    Private m_Remark As String
    Public Property Remark As String
        Get
            Return m_Remark
        End Get
        Set(value As String)
            m_Remark = value
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
    Private m_ForeignAmt As Double
    Public Property ForeignAmt As Double
        Get
            Return m_ForeignAmt
        End Get
        Set(value As Double)
            m_ForeignAmt = value
        End Set
    End Property
    Private m_RefNo As String
    Public Property RefNo As String
        Get
            Return m_RefNo
        End Get
        Set(value As String)
            m_RefNo = value
        End Set
    End Property
    Private m_PayType As String
    Public Property PayType As String
        Get
            Return m_PayType
        End Get
        Set(value As String)
            m_PayType = value
        End Set
    End Property
    Private m_AdvRef As String
    Public Property AdvRef As String
        Get
            Return m_AdvRef
        End Get
        Set(value As String)
            m_AdvRef = value
        End Set
    End Property
    Private m_ApproveBy As String
    Public Property ApproveBy As String
        Get
            Return m_ApproveBy
        End Get
        Set(value As String)
            m_ApproveBy = value
        End Set
    End Property
    Private m_ApproveDate As Date
    Public Property ApproveDate As Date
        Get
            Return m_ApproveDate
        End Get
        Set(value As Date)
            m_ApproveDate = value
        End Set
    End Property
    Private m_ApproveTime As Date
    Public Property ApproveTime As Date
        Get
            Return m_ApproveTime
        End Get
        Set(value As Date)
            m_ApproveTime = value
        End Set
    End Property
    Private m_PaymentBy As String
    Public Property PaymentBy As String
        Get
            Return m_PaymentBy
        End Get
        Set(value As String)
            m_PaymentBy = value
        End Set
    End Property
    Private m_PaymentDate As Date
    Public Property PaymentDate As Date
        Get
            Return m_PaymentDate
        End Get
        Set(value As Date)
            m_PaymentDate = value
        End Set
    End Property
    Private m_PaymentTime As Date
    Public Property PaymentTime As Date
        Get
            Return m_PaymentTime
        End Get
        Set(value As Date)
            m_PaymentTime = value
        End Set
    End Property
    Private m_PaymentRef As String
    Public Property PaymentRef As String
        Get
            Return m_PaymentRef
        End Get
        Set(value As String)
            m_PaymentRef = value
        End Set
    End Property
    Private m_ApproveRef As String
    Public Property ApproveRef As String
        Get
            Return m_ApproveRef
        End Get
        Set(value As String)
            m_ApproveRef = value
        End Set
    End Property

    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_PaymentHeader" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("BranchCode") = Main.GetDBString(Me.BranchCode, dt.Columns("BranchCode"))
                            dr("DocNo") = Main.GetDBString(Me.DocNo, dt.Columns("DocNo"))
                            dr("DocDate") = Main.GetDBDate(Me.DocDate)
                            dr("VenCode") = Main.GetDBString(Me.VenCode, dt.Columns("VenCode"))
                            dr("ContactName") = Main.GetDBString(Me.ContactName, dt.Columns("ContactName"))
                            dr("EmpCode") = Main.GetDBString(Me.EmpCode, dt.Columns("EmpCode"))
                            dr("PoNo") = Main.GetDBString(Me.PoNo, dt.Columns("PoNo"))
                            dr("VATRate") = Me.VATRate
                            dr("TaxRate") = Me.TaxRate
                            dr("TotalExpense") = Me.TotalExpense
                            dr("TotalTax") = Me.TotalTax
                            dr("TotalVAT") = Me.TotalVAT
                            dr("TotalDiscount") = Me.TotalDiscount
                            dr("TotalNet") = Me.TotalNet
                            dr("Remark") = Main.GetDBString(Me.Remark, dt.Columns("Remark"))
                            dr("CancelReson") = Main.GetDBString(Me.CancelReson, dt.Columns("CancelReson"))
                            dr("CancelProve") = Main.GetDBString(Me.CancelProve, dt.Columns("CancelProve"))
                            dr("CancelDate") = Main.GetDBDate(Me.CancelDate)
                            dr("CancelTime") = Main.GetDBTime(Me.CancelTime)
                            dr("CurrencyCode") = Main.GetDBString(Me.CurrencyCode, dt.Columns("CurrencyCode"))
                            dr("ExchangeRate") = Me.ExchangeRate
                            dr("ForeignAmt") = Me.ForeignAmt
                            dr("RefNo") = Main.GetDBString(Me.RefNo, dt.Columns("RefNo"))
                            dr("PayType") = Main.GetDBString(Me.PayType, dt.Columns("PayType"))
                            dr("AdvRef") = Main.GetDBString(Me.AdvRef, dt.Columns("AdvRef"))
                            dr("ApproveBy") = Main.GetDBString(Me.ApproveBy, dt.Columns("ApproveBy"))
                            dr("ApproveDate") = Main.GetDBDate(Me.ApproveDate)
                            dr("ApproveTime") = Main.GetDBTime(Me.ApproveTime)
                            dr("PaymentBy") = Main.GetDBString(Me.PaymentBy, dt.Columns("PaymentBy"))
                            dr("PaymentDate") = Main.GetDBDate(Me.PaymentDate)
                            dr("PaymentTime") = Main.GetDBTime(Me.PaymentTime)
                            dr("PaymentRef") = Main.GetDBString(Me.PaymentRef, dt.Columns("PaymentRef"))
                            dr("ApproveRef") = Main.GetDBString(Me.ApproveRef, dt.Columns("ApproveRef"))
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CPayHeader", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CPayHeader", "SaveData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew(pFormatSQL As String)
        If pFormatSQL = "" Then
            m_DocNo = ""
        Else
            'Dim retStr As String = Main.GetMaxByMask(m_ConnStr, String.Format("SELECT MAX(DocNo) as t FROM Job_PaymentHeader WHERE BranchCode='{0}' And DocNo Like '{1}' ", m_BranchCode, pFormatSQL), pFormatSQL)
            Dim retStr As String = Main.GetMaxByMask(m_ConnStr, String.Format("SELECT MAX(DocNo) as t FROM Job_PaymentHeader WHERE DocNo Like '{0}' ", pFormatSQL), pFormatSQL)
            m_DocNo = retStr
        End If
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CPayHeader)
        Dim lst As New List(Of CPayHeader)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CPayHeader
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_PaymentHeader" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CPayHeader(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocNo"))) = False Then
                        row.DocNo = rd.GetString(rd.GetOrdinal("DocNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocDate"))) = False Then
                        row.DocDate = rd.GetValue(rd.GetOrdinal("DocDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("VenCode"))) = False Then
                        row.VenCode = rd.GetString(rd.GetOrdinal("VenCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ContactName"))) = False Then
                        row.ContactName = rd.GetString(rd.GetOrdinal("ContactName")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("EmpCode"))) = False Then
                        row.EmpCode = rd.GetString(rd.GetOrdinal("EmpCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PoNo"))) = False Then
                        row.PoNo = rd.GetString(rd.GetOrdinal("PoNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("VATRate"))) = False Then
                        row.VATRate = rd.GetDouble(rd.GetOrdinal("VATRate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TaxRate"))) = False Then
                        row.TaxRate = rd.GetDouble(rd.GetOrdinal("TaxRate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TotalExpense"))) = False Then
                        row.TotalExpense = rd.GetDouble(rd.GetOrdinal("TotalExpense"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TotalTax"))) = False Then
                        row.TotalTax = rd.GetDouble(rd.GetOrdinal("TotalTax"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TotalVAT"))) = False Then
                        row.TotalVAT = rd.GetDouble(rd.GetOrdinal("TotalVAT"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TotalDiscount"))) = False Then
                        row.TotalDiscount = rd.GetDouble(rd.GetOrdinal("TotalDiscount"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TotalNet"))) = False Then
                        row.TotalNet = rd.GetDouble(rd.GetOrdinal("TotalNet"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Remark"))) = False Then
                        row.Remark = rd.GetString(rd.GetOrdinal("Remark")).ToString()
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
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CurrencyCode"))) = False Then
                        row.CurrencyCode = rd.GetString(rd.GetOrdinal("CurrencyCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ExchangeRate"))) = False Then
                        row.ExchangeRate = rd.GetDouble(rd.GetOrdinal("ExchangeRate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ForeignAmt"))) = False Then
                        row.ForeignAmt = rd.GetDouble(rd.GetOrdinal("ForeignAmt"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("RefNo"))) = False Then
                        row.RefNo = rd.GetString(rd.GetOrdinal("RefNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PayType"))) = False Then
                        row.PayType = rd.GetString(rd.GetOrdinal("PayType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AdvRef"))) = False Then
                        row.AdvRef = rd.GetString(rd.GetOrdinal("AdvRef")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ApproveBy"))) = False Then
                        row.ApproveBy = rd.GetString(rd.GetOrdinal("ApproveBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ApproveDate"))) = False Then
                        row.ApproveDate = rd.GetValue(rd.GetOrdinal("ApproveDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ApproveTime"))) = False Then
                        row.ApproveTime = rd.GetValue(rd.GetOrdinal("ApproveTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PaymentBy"))) = False Then
                        row.PaymentBy = rd.GetString(rd.GetOrdinal("PaymentBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PaymentDate"))) = False Then
                        row.PaymentDate = rd.GetValue(rd.GetOrdinal("PaymentDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PaymentTime"))) = False Then
                        row.PaymentTime = rd.GetValue(rd.GetOrdinal("PaymentTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PaymentRef"))) = False Then
                        row.PaymentRef = rd.GetString(rd.GetOrdinal("PaymentRef")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ApproveRef"))) = False Then
                        row.ApproveRef = rd.GetString(rd.GetOrdinal("ApproveRef")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CPayHeader", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Job_PaymentHeader" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CPayHeader", "DeleteData", cm.CommandText, False)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CPayHeader", "DeleteData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class