'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CJobOrderLog
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
    Private m_ItemNo As Integer
    Public Property ItemNo As Integer
        Get
            Return m_ItemNo
        End Get
        Set(value As Integer)
            m_ItemNo = value
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
    Private m_LogDate As Date
    Public Property LogDate As Date
        Get
            Return m_LogDate
        End Get
        Set(value As Date)
            m_LogDate = value
        End Set
    End Property
    Private m_LogTime As Date
    Public Property LogTime As Date
        Get
            Return m_LogTime
        End Get
        Set(value As Date)
            m_LogTime = value
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
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_OrderLog" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("BranchCode") = Main.GetDBString(Me.BranchCode, dt.Columns("BranchCode"))
                            dr("JNo") = Main.GetDBString(Me.JNo, dt.Columns("JNo"))
                            dr("ItemNo") = Main.GetDBString(Me.ItemNo, dt.Columns("ItemNo"))
                            dr("EmpCode") = Main.GetDBString(Me.EmpCode, dt.Columns("EmpCode"))
                            dr("LogDate") = Main.GetDBDate(Me.LogDate)
                            dr("LogTime") = Main.GetDBTime(Me.LogTime)
                            dr("TRemark") = Main.GetDBString(Me.TRemark, dt.Columns("TRemark"))
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CJobOrderLog", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CJobOrderLog", "SaveData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()
        Dim retStr As String = Main.GetMaxByMask(m_ConnStr, String.Format("SELECT MAX(ItemNo) as t FROM Job_OrderLog WHERE BranchCode='{0}' And JNo ='{1}' ", m_BranchCode, m_JNo), "____")
        m_ItemNo = Convert.ToInt32("0" & retStr)
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CJobOrderLog)
        Dim lst As New List(Of CJobOrderLog)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CJobOrderLog
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_OrderLog" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CJobOrderLog(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("JNo"))) = False Then
                        row.JNo = rd.GetString(rd.GetOrdinal("JNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ItemNo"))) = False Then
                        row.ItemNo = rd.GetInt32(rd.GetOrdinal("ItemNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("EmpCode"))) = False Then
                        row.EmpCode = rd.GetString(rd.GetOrdinal("EmpCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LogDate"))) = False Then
                        row.LogDate = rd.GetValue(rd.GetOrdinal("LogDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LogTime"))) = False Then
                        row.LogTime = rd.GetValue(rd.GetOrdinal("LogTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TRemark"))) = False Then
                        row.TRemark = rd.GetString(rd.GetOrdinal("TRemark")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CJobOrderLog", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Job_OrderLog" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CJobOrderLog", "DeleteData", cm.CommandText, False)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                msg = ex.Message
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CJobOrderLog", "DeleteData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return msg
    End Function
End Class