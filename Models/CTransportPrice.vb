'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CTransportPrice
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
    Private m_LocationID As Integer
    Public Property LocationID As Integer
        Get
            Return m_LocationID
        End Get
        Set(value As Integer)
            m_LocationID = value
        End Set
    End Property
    Private m_VenderCode As String
    Public Property VenderCode As String
        Get
            Return m_VenderCode
        End Get
        Set(value As String)
            m_VenderCode = value
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
    Private m_SICode As String
    Public Property SICode As String
        Get
            Return m_SICode
        End Get
        Set(value As String)
            m_SICode = value
        End Set
    End Property
    Private m_CostAmount As Double
    Public Property CostAmount As Double
        Get
            Return m_CostAmount
        End Get
        Set(value As Double)
            m_CostAmount = value
        End Set
    End Property
    Private m_ChargeAmount As Double
    Public Property ChargeAmount As Double
        Get
            Return m_ChargeAmount
        End Get
        Set(value As Double)
            m_ChargeAmount = value
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
    Private m_Location As String
    Public Property Location As String
        Get
            Return m_Location
        End Get
        Set(value As String)
            m_Location = value
        End Set
    End Property
    Private m_ChargeCode As String
    Public Property ChargeCode As String
        Get
            Return m_ChargeCode
        End Get
        Set(value As String)
            m_ChargeCode = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_TransportPrice" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("BranchCode") = Me.BranchCode
                            dr("LocationID") = Me.LocationID
                            dr("Location") = Me.Location
                            dr("VenderCode") = Me.VenderCode
                            dr("CustCode") = Me.CustCode
                            dr("SICode") = Me.SICode
                            dr("SDescription") = Me.SDescription
                            dr("CostAmount") = Me.CostAmount
                            dr("ChargeAmount") = Me.ChargeAmount
                            dr("ChargeCode") = Me.ChargeCode
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, "JOBSHIPPING", "CTransportPrice", "SaveData", Me)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                msg = ex.Message
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, "JOBSHIPPING", "CTransportPrice", "SaveData", ex.Message, True)
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()

        m_BranchCode = ""
        m_LocationID = 0
        m_VenderCode = ""
        m_CustCode = ""
        m_SICode = ""
        m_SDescription = ""
        m_Location = ""
        m_CostAmount = 0
        m_ChargeAmount = 0
        m_ChargeCode = ""
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CTransportPrice)
        Dim lst As New List(Of CTransportPrice)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CTransportPrice
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_TransportPrice" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CTransportPrice(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LocationID"))) = False Then
                        row.LocationID = rd.GetValue(rd.GetOrdinal("LocationID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("VenderCode"))) = False Then
                        row.VenderCode = rd.GetString(rd.GetOrdinal("VenderCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CustCode"))) = False Then
                        row.CustCode = rd.GetString(rd.GetOrdinal("CustCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SICode"))) = False Then
                        row.SICode = rd.GetString(rd.GetOrdinal("SICode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SDescription"))) = False Then
                        row.SDescription = rd.GetString(rd.GetOrdinal("SDescription")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Location"))) = False Then
                        row.Location = rd.GetString(rd.GetOrdinal("Location")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CostAmount"))) = False Then
                        row.CostAmount = rd.GetDouble(rd.GetOrdinal("CostAmount"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ChargeAmount"))) = False Then
                        row.ChargeAmount = rd.GetDouble(rd.GetOrdinal("ChargeAmount"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ChargeCode"))) = False Then
                        row.ChargeCode = rd.GetString(rd.GetOrdinal("ChargeCode")).ToString()
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

                Using cm As New SqlCommand("DELETE FROM Job_TransportPrice" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, "JOBSHIPPING", "CTransportPrice", "DeleteData", cm.CommandText)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                msg = ex.Message
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, "JOBSHIPPING", "CTransportPrice", "DeleteData", ex.Message, True)
            End Try
        End Using
        Return msg
    End Function
End Class