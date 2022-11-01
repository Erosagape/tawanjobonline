Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class CResult
    Public Sub New()

    End Sub
    Public Property IsError As Boolean
    Public Property Source As String
    Public Property Param As String
    Public Property Result As String
End Class
Public Class CUtil
    Private m_ConnStr As String
    Public Property Message As String
    Public Sub New()
        Message = ""
    End Sub
    Public Sub New(Optional pConnStr As String = "")
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Function ExecuteSQL(pSQL As String, Optional bLog As Boolean = True) As String
        Message = "OK"
        Dim dt As New DataTable
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()
                Using cm As New SqlCommand
                    cm.Connection = cn
                    cm.CommandTimeout = Convert.ToInt32(GetValueConfig("PROFILE", "TIMEOUT", 600))
                    cm.CommandText = pSQL
                    cm.CommandType = CommandType.Text
                    Message &= " Row(s)=" & cm.ExecuteNonQuery()
                    If bLog Then Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "ExecuteSQL", Message, pSQL, False)
                End Using

            Catch ex As Exception
                Message = "[ERROR]" & ex.Message
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "ExecuteSQL", Message, pSQL, True)
            End Try
        End Using
        Return Message
    End Function
    Public Function GetTableFromSQL(pSQL As String, Optional saveLog As Boolean = False) As DataTable
        Message = "OK"
        Dim dt As New DataTable
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()
                Using da As New SqlDataAdapter(pSQL, cn)
                    da.SelectCommand.CommandTimeout = Convert.ToInt32(GetValueConfig("PROFILE", "TIMEOUT", 600))
                    da.Fill(dt)
                End Using
                If dt.Rows.Count = 0 Then dt.Rows.Add(dt.NewRow)
            Catch ex As Exception
                Message = "[ERROR]" & ex.Message
            End Try
        End Using
        If saveLog Then
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, "JOBSHIPING", "GetTableFromSQL", Message, pSQL, False)
        End If
        Return dt
    End Function
    Public Function ReadExcelFromFile(fname As String, Optional tbName As String = "") As DataTable
        Message = "OK"
        Dim dt As New DataTable
        Try
            Dim connXLS As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"
            Using cnExcel = New OleDbConnection(String.Format(connXLS, fname, "YES"))
                cnExcel.Open()
                Dim cnSchemaTable = cnExcel.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
                If cnSchemaTable.Rows.Count > 0 Then
                    If tbName = "" Then
                        tbName = cnSchemaTable.Rows(0)("TABLE_NAME").ToString()
                    End If
                    Using da = New OleDb.OleDbDataAdapter("SELECT * FROM [" & tbName & "]", cnExcel)
                        da.Fill(dt)
                    End Using
                End If
            End Using
        Catch ex As Exception
            Message = "[ERROR] " & ex.Message
        End Try
        Return dt
    End Function
End Class
