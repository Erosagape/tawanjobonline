Imports System.Data.SqlClient
Public Class CAddFuel
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
    Private m_CarLicense As String
    Public Property CarLicense As String
        Get
            Return m_CarLicense
        End Get
        Set(value As String)
            m_CarLicense = value
        End Set
    End Property
    Private m_Driver As String
    Public Property Driver As String
        Get
            Return m_Driver
        End Get
        Set(value As String)
            m_Driver = value
        End Set
    End Property
    Private m_FuelType As String
    Public Property FuelType As String
        Get
            Return m_FuelType
        End Get
        Set(value As String)
            m_FuelType = value
        End Set
    End Property
    Private m_BudgetVolume As Double
    Public Property BudgetVolume As Double
        Get
            Return m_BudgetVolume
        End Get
        Set(value As Double)
            m_BudgetVolume = value
        End Set
    End Property
    Private m_BudgetValue As Double
    Public Property BudgetValue As Double
        Get
            Return m_BudgetValue
        End Get
        Set(value As Double)
            m_BudgetValue = value
        End Set
    End Property
    Private m_ActualVolume As Double
    Public Property ActualVolume As Double
        Get
            Return m_ActualVolume
        End Get
        Set(value As Double)
            m_ActualVolume = value
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
    Private m_TotalAmount As Double
    Public Property TotalAmount As Double
        Get
            Return m_TotalAmount
        End Get
        Set(value As Double)
            m_TotalAmount = value
        End Set
    End Property
    Private m_StationCode As String
    Public Property StationCode As String
        Get
            Return m_StationCode
        End Get
        Set(value As String)
            m_StationCode = value
        End Set
    End Property
    Private m_StationInvNo As String
    Public Property StationInvNo As String
        Get
            Return m_StationInvNo
        End Get
        Set(value As String)
            m_StationInvNo = value
        End Set
    End Property
    Private m_PaymentType As String
    Public Property PaymentType As String
        Get
            Return m_PaymentType
        End Get
        Set(value As String)
            m_PaymentType = value
        End Set
    End Property
    Private m_MileBegin As Double
    Public Property MileBegin As Double
        Get
            Return m_MileBegin
        End Get
        Set(value As Double)
            m_MileBegin = value
        End Set
    End Property
    Private m_MileEnd As Double
    Public Property MileEnd As Double
        Get
            Return m_MileEnd
        End Get
        Set(value As Double)
            m_MileEnd = value
        End Set
    End Property
    Private m_MileTotal As Double
    Public Property MileTotal As Double
        Get
            Return m_MileTotal
        End Get
        Set(value As Double)
            m_MileTotal = value
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
    Private m_TotalWeight As Double
    Public Property TotalWeight As Double
        Get
            Return m_TotalWeight
        End Get
        Set(value As Double)
            m_TotalWeight = value
        End Set
    End Property
    Private m_CreateBy As String
    Public Property CreateBy As String
        Get
            Return m_CreateBy
        End Get
        Set(value As String)
            m_CreateBy = value
        End Set
    End Property
    Private m_CreateDate As Date
    Public Property CreateDate As Date
        Get
            Return m_CreateDate
        End Get
        Set(value As Date)
            m_CreateDate = value
        End Set
    End Property
    Private m_UpdateBy As String
    Public Property UpdateBy As String
        Get
            Return m_UpdateBy
        End Get
        Set(value As String)
            m_UpdateBy = value
        End Set
    End Property
    Private m_LastUpdate As Date
    Public Property LastUpdate As Date
        Get
            Return m_LastUpdate
        End Get
        Set(value As Date)
            m_LastUpdate = value
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
    Private m_CancelBy As String
    Public Property CancelBy As String
        Get
            Return m_CancelBy
        End Get
        Set(value As String)
            m_CancelBy = value
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
    Private m_CancelReason As String
    Public Property CancelReason As String
        Get
            Return m_CancelReason
        End Get
        Set(value As String)
            m_CancelReason = value
        End Set
    End Property
    Private m_BookingNo As String
    Public Property BookingNo As String
        Get
            Return m_BookingNo
        End Get
        Set(value As String)
            m_BookingNo = value
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
    Private m_JNo As String
    Public Property JNo As String
        Get
            Return m_JNo
        End Get
        Set(value As String)
            m_JNo = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_AddFuel" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("BranchCode") = Me.BranchCode
                            dr("DocNo") = Me.DocNo
                            dr("DocDate") = Main.GetDBDate(Me.DocDate)
                            dr("CarLicense") = Me.CarLicense
                            dr("Driver") = Me.Driver
                            dr("FuelType") = Me.FuelType
                            dr("BudgetVolume") = Me.BudgetVolume
                            dr("BudgetValue") = Me.BudgetValue
                            dr("ActualVolume") = Me.ActualVolume
                            dr("UnitPrice") = Me.UnitPrice
                            dr("TotalAmount") = Me.TotalAmount
                            dr("StationCode") = Me.StationCode
                            dr("StationInvNo") = Me.StationInvNo
                            dr("PaymentType") = Me.PaymentType
                            dr("MileBegin") = Me.MileBegin
                            dr("MileEnd") = Me.MileEnd
                            dr("MileTotal") = Me.MileTotal
                            dr("Remark") = Me.Remark
                            dr("TotalWeight") = Me.TotalWeight
                            If dr.RowState = DataRowState.Detached Then
                                dr("CreateBy") = Me.CreateBy
                                dr("CreateDate") = Main.GetDBDate(Me.CreateDate)
                            End If
                            dr("UpdateBy") = Me.UpdateBy
                            dr("LastUpdate") = Main.GetDBDate(Me.LastUpdate)
                            dr("ApproveBy") = Me.ApproveBy
                            dr("ApproveDate") = Main.GetDBDate(Me.ApproveDate)
                            dr("CancelBy") = Me.CancelBy
                            dr("CancelDate") = Main.GetDBDate(Me.CancelDate)
                            dr("CancelReason") = Me.CancelReason
                            dr("BookingNo") = Me.BookingNo
                            dr("BookingItemNo") = Me.BookingItemNo
                            dr("JNo") = Me.JNo
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew(pFormatSQL As String)
        If pFormatSQL = "" Then
            m_DocNo = ""
        Else
            Dim retStr As String = Main.GetMaxByMask(m_ConnStr, String.Format("SELECT MAX(DocNo) as t FROM Job_AddFuel WHERE BranchCode='{0}' And DocNo Like '%{1}' ", m_BranchCode, pFormatSQL), pFormatSQL)
            m_DocNo = retStr
        End If
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CAddFuel)
        Dim lst As New List(Of CAddFuel)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CAddFuel
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_AddFuel" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CAddFuel(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocNo"))) = False Then
                        row.DocNo = rd.GetString(rd.GetOrdinal("DocNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocDate"))) = False Then
                        row.DocDate = rd.GetValue(rd.GetOrdinal("DocDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CarLicense"))) = False Then
                        row.CarLicense = rd.GetString(rd.GetOrdinal("CarLicense")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Driver"))) = False Then
                        row.Driver = rd.GetString(rd.GetOrdinal("Driver")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FuelType"))) = False Then
                        row.FuelType = rd.GetString(rd.GetOrdinal("FuelType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BudgetVolume"))) = False Then
                        row.BudgetVolume = rd.GetDouble(rd.GetOrdinal("BudgetVolume"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BudgetValue"))) = False Then
                        row.BudgetValue = rd.GetDouble(rd.GetOrdinal("BudgetValue"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ActualVolume"))) = False Then
                        row.ActualVolume = rd.GetDouble(rd.GetOrdinal("ActualVolume"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UnitPrice"))) = False Then
                        row.UnitPrice = rd.GetDouble(rd.GetOrdinal("UnitPrice"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TotalAmount"))) = False Then
                        row.TotalAmount = rd.GetDouble(rd.GetOrdinal("TotalAmount"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("StationCode"))) = False Then
                        row.StationCode = rd.GetString(rd.GetOrdinal("StationCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("StationInvNo"))) = False Then
                        row.StationInvNo = rd.GetString(rd.GetOrdinal("StationInvNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PaymentType"))) = False Then
                        row.PaymentType = rd.GetString(rd.GetOrdinal("PaymentType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("MileBegin"))) = False Then
                        row.MileBegin = rd.GetDouble(rd.GetOrdinal("MileBegin"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("MileEnd"))) = False Then
                        row.MileEnd = rd.GetDouble(rd.GetOrdinal("MileEnd"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("MileTotal"))) = False Then
                        row.MileTotal = rd.GetDouble(rd.GetOrdinal("MileTotal"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Remark"))) = False Then
                        row.Remark = rd.GetString(rd.GetOrdinal("Remark")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TotalWeight"))) = False Then
                        row.TotalWeight = rd.GetDouble(rd.GetOrdinal("TotalWeight"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CreateBy"))) = False Then
                        row.CreateBy = rd.GetString(rd.GetOrdinal("CreateBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CreateDate"))) = False Then
                        row.CreateDate = rd.GetValue(rd.GetOrdinal("CreateDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UpdateBy"))) = False Then
                        row.UpdateBy = rd.GetString(rd.GetOrdinal("UpdateBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LastUpdate"))) = False Then
                        row.LastUpdate = rd.GetValue(rd.GetOrdinal("LastUpdate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ApproveBy"))) = False Then
                        row.ApproveBy = rd.GetString(rd.GetOrdinal("ApproveBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ApproveDate"))) = False Then
                        row.ApproveDate = rd.GetValue(rd.GetOrdinal("ApproveDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CancelBy"))) = False Then
                        row.CancelBy = rd.GetString(rd.GetOrdinal("CancelBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CancelDate"))) = False Then
                        row.CancelDate = rd.GetValue(rd.GetOrdinal("CancelDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CancelReason"))) = False Then
                        row.CancelReason = rd.GetString(rd.GetOrdinal("CancelReason")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BookingNo"))) = False Then
                        row.BookingNo = rd.GetString(rd.GetOrdinal("BookingNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BookingItemNo"))) = False Then
                        row.BookingItemNo = rd.GetValue(rd.GetOrdinal("BookingItemNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("JNo"))) = False Then
                        row.JNo = rd.GetString(rd.GetOrdinal("JNo")).ToString()
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

                Using cm As New SqlCommand("DELETE FROM Job_AddFuel" + pSQLWhere, cn)
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
