Imports System.Data.SqlClient
Imports Newtonsoft.Json
Module Main
    Friend Const jsonContent As String = "application/json;charset=UTF-8"
    Friend Const xmlContent As String = "application/xml;charset=UTF-8"
    Friend Const textContent As String = "text/html"
    Friend Const appName As String = "JOBADMIN"
    Friend Function GetDBString(pValue As String, dc As DataColumn)
        If pValue Is Nothing Then
            Return ""
        End If
        If dc.MaxLength >= pValue.Length Or dc.MaxLength < 0 Then
            Return pValue
        Else
            Return pValue.Substring(0, dc.MaxLength)
        End If
    End Function
    Friend Function GetDBDate(pDate As Date, Optional pTodayAsDefault As Boolean = False) As Object
        If pDate.Year > 2000 Then
            If pDate.Year > 2500 Then
                Return pDate.AddYears(-543)
            Else
                If pDate.Year > 2200 Then
                    Return Date.MinValue
                End If
            End If
            Return pDate
        Else
            If pTodayAsDefault Then
                Return DateTime.Today
            Else
                If pDate.Year > 2500 Then
                    Return pDate.AddYears(-543)
                Else
                    Return System.DBNull.Value
                End If
            End If
        End If
    End Function
    Friend Function GetDBTime(pDate As Date) As Object
        If pDate.Hour > 0 Then
            Return pDate
        Else
            Return System.DBNull.Value
        End If
    End Function
    Friend Function GetValueSQL(conn As String, sql As String) As CResult
        Dim ret As New CResult With {
    .Source = sql,
    .Param = conn,
    .Result = "",
    .IsError = False
}
        Try
            Using cn As New SqlConnection(conn)
                cn.Open()
                Using rd As SqlDataReader = New SqlCommand(sql, cn).ExecuteReader
                    If rd.Read Then
                        If rd.HasRows Then
                            Dim val As String = rd.GetValue(0).ToString()
                            ret.Result = val
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            Main.SaveLog(GetSession("CurrLicense"), appName, "GetValueSQL", ex.Message, ex.StackTrace & "=>" & sql & " (" & conn & ")", True)
            ret.IsError = True
            ret.Result = ex.Message
        End Try
        Return ret
    End Function

    Friend Function GetMaxByMask(sConn As String, sSQL As String, sFormat As String) As String
        Dim retStr As String = ""
        Try
            Using cn As New SqlConnection(sConn)
                cn.Open()
                Using rd As SqlDataReader = New SqlCommand(sSQL, cn).ExecuteReader
                    If rd.Read Then
                        If rd.HasRows Then
                            Dim numStr As String = ""
                            Dim formatStr As String = ""
                            Dim val As String = rd.GetValue(0).ToString()
                            Dim i As Integer = 0
                            For i = 1 To val.Length
                                If IsNumeric(val.Substring(val.Length - i, 1)) Then
                                    numStr = val.Substring(val.Length - i, 1) & numStr
                                    formatStr &= "0"
                                Else
                                    Exit For
                                End If
                            Next
                            If numStr <> "" Then
                                retStr = val.Substring(0, val.Length - i + 1) & Format(CLng(numStr) + 1, formatStr)
                            End If
                        End If
                    End If
                    rd.Close()
                End Using

            End Using
        Catch ex As Exception
            Main.SaveLog(GetSession("CurrLicense"), appName, "GetMaxByMask", ex.Message, ex.StackTrace, True)
        End Try
        If retStr = "" Then
            Dim j As Integer = sFormat.Count(Function(c As Char) c = "_")
            retStr = Replace(sFormat, Strings.StrDup(j, "_"), Format(1, Strings.StrDup(j, "0")))
        End If
        Return retStr
    End Function
    Friend Function DBExecute(conn As String, SQL As String) As String
        Try
            Using cn As New SqlConnection(conn)
                cn.Open()
                Using cm As New SqlCommand()
                    cm.Connection = cn
                    cm.CommandType = CommandType.Text
                    cm.CommandText = SQL
                    cm.ExecuteNonQuery()
                    Main.SaveLog(GetSession("CurrLicense"), appName, "DBExecute", conn, SQL, False)
                End Using
            End Using
            Return "OK"
        Catch ex As Exception
            Main.SaveLog(GetSession("CurrLicense"), appName, "DBExecute", ex.Message, ex.StackTrace, True)
            Return "[ERROR]" & ex.Message
        End Try
    End Function
    Function SaveLog(cust As String, app As String, modl As String, action As String, msg As String, isError As Boolean, Optional StackTrace As String = "", Optional JsonData As String = "") As String
        Try
            Dim clientIP = HttpContext.Current.Request.UserHostAddress
            Dim userLogin = HttpContext.Current.Session("CurrUser").ToString()
            Dim sessionID = HttpContext.Current.Session.SessionID
            Dim cnMas = My.Settings.weblicenseConnection
            Dim oLog As New CLog(cnMas)
            oLog.AppID = app & "(" & sessionID & ")"
            oLog.CustID = cust & "/" & userLogin
            oLog.FromIP = clientIP
            oLog.ModuleName = modl
            oLog.LogAction = action
            oLog.Message = msg
            oLog.StackTrace = StackTrace
            oLog.JsonData = JsonData
            oLog.IsError = isError
            Return oLog.SaveData(" WHERE LogID=0 ")
        Catch ex As Exception
            Dim str = "[ERROR] : " & ex.Message
            Return str
        End Try
    End Function
    Function SaveLogFromObject(cust As String, app As String, modl As String, action As String, obj As Object, IsError As Boolean, Optional StackTrace As String = "") As String
        Dim clientIP = HttpContext.Current.Request.UserHostAddress
        Dim userLogin = HttpContext.Current.Session("CurrUser").ToString()
        Dim sessionID = HttpContext.Current.Session.SessionID
        Try
            Dim cnMas = My.Settings.weblicenseConnection
            Dim oLog As New CLog(cnMas)
            oLog.AppID = app & "(" & sessionID & ")"
            oLog.CustID = cust & "/" & userLogin
            oLog.FromIP = clientIP
            oLog.ModuleName = modl
            oLog.LogAction = action
            oLog.Message = If(IsError = True, "ERROR", "SUCCESS")
            oLog.JsonData = JsonConvert.SerializeObject(obj)
            oLog.StackTrace = StackTrace
            oLog.IsError = IsError
            Return oLog.SaveData(" WHERE LogID=0 ")
        Catch ex As Exception
            Main.SaveLog(cust, app, modl, "SaveLogFromObject", ex.Message, True, ex.StackTrace, "")
            Dim str = "[ERROR] : " & ex.Message
            Return str
        End Try
    End Function
    Function GetDatabaseList(pCustomer As String, pApp As String) As List(Of String)
        Dim db = New List(Of String)
        Dim cnMas = My.Settings.weblicenseConnection
        Try
            Dim tb = New CUtil(cnMas).GetTableFromSQL(String.Format("SELECT * FROM TWTCustomerApp WHERE CustID='{0}' AND AppID='{1}' ", pCustomer, pApp))
            If tb.Rows.Count > 0 Then
                For Each dr As DataRow In tb.Rows
                    db.Add(dr("WebTranDB").ToString())
                Next
            End If
        Catch ex As Exception

        End Try
        Return db
    End Function
    Function GetDatabaseProfile(pCustomer As String) As DataTable
        Dim cnMas = My.Settings.weblicenseConnection
        Dim tb = New CUtil(cnMas).GetTableFromSQL(String.Format("SELECT * FROM TWTCustomer WHERE CustID='{0}' ", pCustomer))
        Return tb
    End Function
    Function GetUserProfile(pCustomer As String) As DataTable
        Dim cnMas = My.Settings.weblicenseConnection
        Dim tb = New CUtil(cnMas).GetTableFromSQL(String.Format("SELECT a.*,b.SubscriptionName,b.Edition,b.BeginDate,b.ExpireDate,b.LoginCount FROM TWTCustomerApp a INNER JOIN TWTSubscription b ON a.SubscriptionID=b.SubScriptionID WHERE a.CustID='{0}' AND a.AppID='JOBSHIPPING' ", pCustomer))
        Return tb
    End Function
    Function GetUserConnection(pCustomer As String, pApp As String, pSeq As String) As String()
        Dim db = New String() {"", ""}
        Try
            Dim cnMas = My.Settings.weblicenseConnection
            Using tb As DataTable = New CUtil(cnMas).GetTableFromSQL(String.Format("SELECT * FROM TWTCustomerApp WHERE CustID='{0}' AND AppID='{1}' AND Seq='{2}'", pCustomer, pApp, pSeq))
                If tb.Rows.Count > 0 Then
                    db = New String() {tb.Rows(0)("WebTranConnect").ToString, tb.Rows(0)("WebMasConnect").ToString}
                End If
            End Using
        Catch ex As Exception

        End Try
        Return db
    End Function
    Function GetSession(sName As String) As String
        Return HttpContext.Current.Session(sName).ToString
    End Function
End Module
