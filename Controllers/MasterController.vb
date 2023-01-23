Imports System.Web.Http
Imports System.Web.Mvc
Imports Newtonsoft.Json
Namespace Controllers
    Public Class MasterController
        Inherits CController
        ' GET: Customer
        Function Index() As ActionResult
            Dim isSync = Main.GetValueConfig("PROFILE", "SYNCMASTER")
            If isSync = "Y" Then
                ViewBag.Result = "Syncing..." & Main.DBExecute(GetSession("ConnJob"), "EXEC SyncMasterFile")
            Else
                ViewBag.Result = "Please wait..."
            End If
            Return GetView("Index")
        End Function
        Function Branch() As ActionResult
            Return GetView("Branch", "MODULE_MAS")
        End Function
        Function ServiceCode() As ActionResult
            Return GetView("ServiceCode", "MODULE_MAS")
        End Function
        Function ServiceGroup() As ActionResult
            Return GetView("ServiceGroup", "MODULE_MAS")
        End Function
        Function Customers() As ActionResult
            Return GetView("Customers", "MODULE_MAS")
        End Function
        Function Currency() As ActionResult
            Return GetView("Currency", "MODULE_MAS")
        End Function
        Function Users() As ActionResult
            Return GetView("Users", "MODULE_MAS")
        End Function
        Function Venders() As ActionResult
            Return GetView("Venders", "MODULE_MAS")
        End Function
        Function Country() As ActionResult
            Return GetView("Country", "MODULE_MAS")
        End Function
        Function ServUnit() As ActionResult
            Return GetView("ServUnit", "MODULE_MAS")
        End Function
        Function DeclareType() As ActionResult
            Return GetView("DeclareType", "MODULE_MAS")
        End Function
        Function CustomsPort() As ActionResult
            Return GetView("CustomsPort", "MODULE_MAS")
        End Function
        Function InterPort() As ActionResult
            Return GetView("InterPort", "MODULE_MAS")
        End Function
        Function BookAccount() As ActionResult
            Return GetView("BookAccount", "MODULE_MAS")
        End Function
        Function Bank() As ActionResult
            Return GetView("Bank", "MODULE_MAS")
        End Function
        Function BudgetPolicy() As ActionResult
            Return GetView("BudgetPolicy", "MODULE_MAS")
        End Function
        Function CustomsUnit() As ActionResult
            Return GetView("CustomsUnit", "MODULE_MAS")
        End Function
        Function CompanyContact() As ActionResult
            Return GetView("CompanyContact", "MODULE_MAS")
        End Function
        Function AccountCode() As ActionResult
            Return GetView("AccountCode", "MODULE_ACC")
        End Function
        Function TransportRoute() As ActionResult
            Return GetView("TransportRoute", "MODULE_MAS")
        End Function

        Function GetTransportPlace() As ActionResult
            Try
                Dim tSqlw As String = " WHERE PlaceName<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND PlaceName ='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    tSqlw &= String.Format(" AND PlaceType ={0}", Request.QueryString("Type").ToString)
                End If
                Dim oData = New CTransportPlace(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""transportplace"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetTransportPlace(<FromBody()> data As CTransportPlace) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.PlaceName = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE PlaceName='{0}' ", data.PlaceName))
                    Dim json = "{""result"":{""data"":""" & data.PlaceName & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelTransportPlace() As ActionResult
            Try
                Dim tSqlw As String = " WHERE PlaceName<>'' "
                If Not IsNothing(Request.QueryString("Type")) Then
                    tSqlw &= String.Format(" AND PlaceType ={0}", Request.QueryString("Type").ToString)
                Else
                    Return Content("{""transportplace"":{""result"":""Please enter type""}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND PlaceName ='{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""transportplace"":{""result"":""Please enter some data""}}", jsonContent)
                End If
                Dim oData As New CTransportPlace(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""transportplace"":{""result"":""" & msg & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetAccountCode() As ActionResult
            Try
                Dim tSqlw As String = " WHERE AccCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND AccCode Like '{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Group")) Then
                    tSqlw &= String.Format("AND AccMain ='{0}' ", Request.QueryString("Group").ToString)
                End If
                Dim oData = New CAccountCode(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""accountcode"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetAccountCode", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetAccountCode(<FromBody()> data As CAccountCode) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.AccCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE AccCode='{0}' ", data.AccCode))
                    Dim json = "{""result"":{""data"":""" & data.AccCode & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetAccountCode", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelAccountCode() As ActionResult
            Try
                Dim tSqlw As String = " WHERE AccCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND AccCode='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""accountcode"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CAccountCode(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""accountcode"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelAccountCode", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetCompanyContact() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ItemNo<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND CustCode='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND Branch='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0}", Request.QueryString("Item").ToString)
                End If
                Dim oData = New CCompanyContact(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""companycontact"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCompanyContact", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function Province() As ActionResult
            Return GetView("Province", "MODULE_MAS")
        End Function
        Function GetProvince() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ProvinceCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ProvinceCode ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CProvince(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""province"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetProvince", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetProvince(<FromBody()> data As CProvince) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.ProvinceCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE ProvinceCode='{0}' ", data.ProvinceCode))
                    Dim json = "{""result"":{""data"":""" & data.ProvinceCode & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetProvince", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelProvince() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ProvinceCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ProvinceCode='{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""province"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CProvince(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""province"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelProvince", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetProvinceSub() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ProvinceCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ProvinceCode='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CProvinceSub(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""province"":{""detail"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetProvinceSub", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetProvinceSub(<FromBody()> data As CProvinceSub) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.id = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE id='{0}' ", data.id))
                    Dim json = "{""result"":{""data"":""" & data.id & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetProvinceSub", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelProvinceSub() As ActionResult
            Try
                Dim tSqlw As String = " WHERE id<>'' "
                If Not IsNothing(Request.QueryString("ID")) Then
                    tSqlw &= String.Format("AND id Like '{0}'", Request.QueryString("ID").ToString)
                Else
                    Return Content("{""province"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CProvinceSub(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""province"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelProvinceSub", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetCompanyContact(<FromBody()> data As CCompanyContact) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.CustCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please choose customer first""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE CustCode='{0}' AND Branch='{1}' AND ItemNo='{2}' ", data.CustCode, data.Branch, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ItemNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetCompanyContact", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelCompanyContact() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ItemNo<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND CustCode='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND Branch='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0}", Request.QueryString("Item").ToString)
                Else
                    Return Content("{""companycontact"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CCompanyContact(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""companycontact"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelCompanyContact", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function

        Function Vessel() As ActionResult
            Return GetView("Vessel", "MODULE_MAS")
        End Function
        Function GetVessel() As ActionResult
            Try
                Dim tSqlw As String = " WHERE RegsNumber<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND RegsNumber ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CVessel(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""vessel"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetVessel", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetVessel(<FromBody()> data As CVessel) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.RegsNumber = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE RegsNumber='{0}' ", data.RegsNumber))
                    Dim json = "{""result"":{""data"":""" & data.RegsNumber & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetVessel", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelVessel() As ActionResult
            Try
                Dim tSqlw As String = " WHERE RegsNumber<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND RegsNumber Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""vessel"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CVessel(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""vessel"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelVessel", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function

        Function GetServiceGroup() As ActionResult
            Try
                Dim tSqlw As String = " WHERE GroupCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND GroupCode ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CServiceGroup(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""servicegroup"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetServiceGroup", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetServiceGroup(<FromBody()> data As CServiceGroup) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.GroupCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE GroupCode='{0}' ", data.GroupCode))
                    If data.IsApplyPolicy = 1 Then
                        Dim cmd As New CUtil(GetSession("ConnJob"))
                        Dim sql As String = "
UPDATE a
SET a.IsTaxCharge=b.IsTaxCharge,
a.Is50Tavi=b.Is50Tavi,
a.Rate50Tavi=b.Rate50Tavi,
a.IsCredit=b.IsCredit,
a.IsExpense=b.IsExpense,
a.IsHaveSlip=b.IsHaveSlip,
a.IsLtdAdv50Tavi=b.IsLtdAdv50Tavi
FROM Job_SrvSingle a
INNER JOIN Job_SrvGroup b
ON a.GroupCode=b.GroupCode
AND b.GroupCode='{0}'
AND b.IsApplyPolicy=1
"
                        cmd.ExecuteSQL(String.Format(sql, data.GroupCode))
                    End If
                    Dim json = "{""result"":{""data"":""" & data.GroupCode & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetServiceGroup", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelServiceGroup() As ActionResult
            Try
                Dim tSqlw As String = " WHERE GroupCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND GroupCode Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""servicegroup"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CServiceGroup(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""servicegroup"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelServiceGroup", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetBank() As ActionResult
            Try
                Dim tSqlw As String = " WHERE [Code]<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND [Code] ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CBank(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""bank"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetBank", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetBank(<FromBody()> data As CBank) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.Code = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE [Code]='{0}' ", data.Code))
                    Dim json = "{""result"":{""data"":""" & data.Code & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetBank", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelBank() As ActionResult
            Try
                Dim tSqlw As String = " WHERE [Code]<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND [Code] Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""bank"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CBank(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""bank"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelBank", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetBookAccount() As ActionResult
            Try
                Dim tSqlw As String = " WHERE BookCode<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BookCode ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CBookAccount(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""bookaccount"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetBookAccount", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetBookBalance() As ActionResult
            Try
                Dim tSqlw As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND a.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND c.BookCode ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(SQLSelectBookAccBalance(), tSqlw))
                Dim json As String = JsonConvert.SerializeObject(oData.Rows)
                json = "{""bookaccount"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetBookBalance", ex.Message, ex.StackTrace, True)
                Return Content("{""bookaccount"":{""data"":[],""msg"":" & ex.Message & "}}", jsonContent)
            End Try
        End Function
        Function SetBookAccount(<FromBody()> data As CBookAccount) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BookCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND BookCode='{1}' ", data.BranchCode, data.BookCode))
                    Dim json = "{""result"":{""data"":""" & data.BookCode & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetBookAccount", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelBookAccount() As ActionResult
            Try
                Dim tSqlw As String = " WHERE BookCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BookCode = '{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""bookaccount"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                Dim oData As New CBookAccount(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""bookaccount"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelBookAccount", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetInterPort() As ActionResult
            Try
                Dim tSqlw As String = " WHERE PortCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND PortCode ='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Key")) Then
                    tSqlw &= String.Format(" AND CountryCode ='{0}'", Request.QueryString("Key").ToString)
                End If
                Dim oData = New CInterPort(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""interport"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetInterPort", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetInterPort(<FromBody()> data As CInterPort) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.PortCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input code""}}", jsonContent)
                    End If
                    If "" & data.CountryCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input country code""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE PortCode='{0}' AND CountryCode='{1}' ", data.PortCode, data.CountryCode))
                    Dim json = "{""result"":{""data"":""" & data.PortCode & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetInterPort", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelInterPort() As ActionResult
            Try
                Dim tSqlw As String = " WHERE PortCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND PortCode Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""interport"":{""result"":""Please input code"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Key")) Then
                    tSqlw &= String.Format(" AND CountryCode Like '{0}'", Request.QueryString("Key").ToString)
                Else
                    Return Content("{""interport"":{""result"":""Please input country vode"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CInterPort(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""interport"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelInterPort", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function

        Function GetCustomsPort() As ActionResult
            Try

                Dim tSqlw As String = " WHERE AreaCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND AreaCode ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CCustomsPort(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""RFARS"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCustomsPort", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetCustomsPort(<FromBody()> data As CCustomsPort) As ActionResult

            Try
                If Not IsNothing(data) Then
                    If "" & data.AreaCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE AreaCode='{0}' ", data.AreaCode))
                    Dim json = "{""result"":{""data"":""" & data.AreaCode & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetCustomsPort", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try

        End Function
        Function DelCustomsPort() As ActionResult

            Try
                Dim tSqlw As String = " WHERE AreaCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND AreaCode Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""RFARS"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CCustomsPort(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""RFARS"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelCustomsPort", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try

        End Function
        Function SetDeclareType(<FromBody()> data As CDeclareType) As ActionResult

            Try
                If Not IsNothing(data) Then
                    If "" & data.Type = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE Type='{0}' ", data.Type))
                    Dim json = "{""result"":{""data"":""" & data.Type & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetDeclareType", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try

        End Function
        Function DelDeclareType() As ActionResult

            Try
                Dim tSqlw As String = " WHERE Type<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND Type Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""RFDCT"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CDeclareType(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""RFDCT"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelDeclareType", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try

        End Function
        Function GetServUnit() As ActionResult
            Try

                Dim tSqlw As String = " WHERE UnitType<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND UnitType ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    tSqlw &= String.Format("AND IsCTNUnit={0} ", Request.QueryString("Type").ToString)
                End If
                Dim oData = New CServUnit(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""servunit"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetServUnit", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetServUnit(<FromBody()> data As CServUnit) As ActionResult

            Try
                If Not IsNothing(data) Then
                    If "" & data.UnitType = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE UnitType='{0}' ", data.UnitType))
                    Dim json = "{""result"":{""data"":""" & data.UnitType & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetServUnit", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try

        End Function
        Function DelServUnit() As ActionResult

            Try
                Dim tSqlw As String = " WHERE UnitType<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND UnitType Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""servunit"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CServUnit(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""servunit"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelServUnit", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try

        End Function
        Function GetDeclareType() As ActionResult
            Try
                Dim tSqlw As String = " WHERE [Type]<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND [Type]='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CDeclareType(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""RFDCT"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetDeclareType", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try

        End Function

        Function GetCurrency() As ActionResult
            Try
                Dim tSqlw As String = " WHERE [Code]<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND [Code]='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CCurrency(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""currency"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCurrency", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try

        End Function
        Function SetCurrency(<FromBody()> data As CCurrency) As ActionResult

            Try
                If Not IsNothing(data) Then
                    If "" & data.Code = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE [Code]='{0}' ", data.Code))
                    Dim json = "{""result"":{""data"":""" & data.Code & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetCurrency", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try

        End Function
        Function DelCurrency() As ActionResult

            Try
                Dim tSqlw As String = " WHERE [Code]<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND [Code] ='{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""currency"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CCurrency(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""currency"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelCurrency", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try

        End Function
        Function GetUser() As ActionResult
            Try
                Dim tSqlw As String = " WHERE UserID<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND UserID='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Pass")) Then
                    tSqlw &= String.Format("AND UPassword='{0}'", Request.QueryString("Pass").ToString)
                End If
                Dim oData = New CUser(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""user"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetUser", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetNewCompany() As ActionResult
            Try
                Dim oData = New CCompany(GetSession("ConnJob"))
                oData.AddNew()
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""company"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetNewCompany", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetNewUser() As ActionResult
            Try
                Dim oData = New CUser(GetSession("ConnJob"))
                oData.AddNew()
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""user"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetNewUser", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetNewVender() As ActionResult
            Try
                Dim oData = New CVender(GetSession("ConnJob"))
                oData.AddNew()
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""vender"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetNewVender", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetCountry() As ActionResult
            Try
                Dim tSqlw As String = " WHERE CTYCODE<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND CTYCODE ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CCountry(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""country"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCountry", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetCountry(<FromBody()> data As CCountry) As ActionResult

            Try
                If Not IsNothing(data) Then
                    If "" & data.CTYCODE = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE CTYCODE='{0}' ", data.CTYCODE))
                    Dim json = "{""result"":{""data"":""" & data.CTYCODE & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetCountry", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try

        End Function
        Function DelCountry() As ActionResult

            Try
                Dim tSqlw As String = " WHERE CTYCODE<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND CTYCODE Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""country"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CCountry(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""country"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelCountry", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try

        End Function
        Function GetCompany() As ActionResult
            Try
                Dim tSqlw As String = " WHERE CustCode<>'' "
                Dim tSqlC As String = " WHERE CustCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND CustCode='{0}'", Request.QueryString("Code").ToString)
                    tSqlC &= String.Format(" AND CustCode='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND Branch='{0}'", Request.QueryString("Branch").ToString)
                    tSqlC &= String.Format(" AND Branch='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlw &= String.Format(" AND TaxNumber='{0}'", Request.QueryString("TaxNumber").ToString)
                End If
                If Not IsNothing(Request.QueryString("Group")) Then
                    tSqlw &= String.Format(" AND CustGroup IN('{0}')", Request.QueryString("Group").ToString.Replace(",", "','"))
                End If
                If Not IsNothing(Request.QueryString("ID")) Then
                    tSqlw &= String.Format(" AND LoginName='{0}'", Request.QueryString("ID").ToString)
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlw &= String.Format(" AND CustCode IN(SELECT DISTINCT CustCode FROM Job_Order WHERE AgentCode='{0}')", Request.QueryString("Vend").ToString)
                End If
                Dim oData = New CCompany(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                Dim oContact = New CCompanyContact(GetSession("ConnJob")).GetData(tSqlC)
                Dim jsonc As String = JsonConvert.SerializeObject(oContact)
                json = "{""company"":{""data"":" & json & ",""contact"":" & jsonc & "},""sql"":""" & tSqlw & """}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCompany", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetVender() As ActionResult
            Try
                Dim tSqlw As String = " WHERE VenCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND VenCode='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("ID")) Then
                    tSqlw &= String.Format(" AND LoginName='{0}'", Request.QueryString("ID").ToString)
                End If
                Dim oData = New CVender(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""vender"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetVender", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function DelServiceCode() As ActionResult
            Try
                Dim tSqlw As String = " WHERE SICode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND SICode Like '{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData As New CServiceCode(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""servicecode"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelServiceCode", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function DelVender() As ActionResult
            Try
                Dim tSqlw As String = " WHERE VenCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND VenCode Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""vender"":{""result"":""Please choose vender first"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CVender(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""vender"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelVender", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function DelCompany() As ActionResult
            Try
                Dim tSqlw As String = " WHERE CustCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND CustCode = '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""company"":{""result"":""Please choose customer first"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND Branch = '{0}'", Request.QueryString("Branch").ToString)
                End If
                Dim oData As New CCompany(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""company"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelCompany", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function

        Function DelUser() As ActionResult
            Try
                Dim tSqlw As String = " WHERE UserID<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND UserID Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""user"":{""result"":""Please select staff"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CUser(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""user"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelUser", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetServiceCode() As ActionResult
            Try
                Dim tSqlw As String = " WHERE SICode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND SICode Like '{0}%' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Group")) Then
                    tSqlw &= String.Format("AND GroupCode Like '{0}%' ", Request.QueryString("Group").ToString)
                Else
                    tSqlw &= "AND GroupCode<>'OLD' "
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    Dim type = Request.QueryString("Type").ToString
                    Select Case type
                        Case "A"
                            tSqlw &= "AND IsCredit=1 AND IsExpense=0 "
                        Case "C"
                            tSqlw &= "AND IsExpense=1 "
                        Case "S"
                            tSqlw &= "AND IsCredit=0 AND IsExpense=0 "
                        Case "E"
                            tSqlw &= "AND NOT (IsCredit=0 AND IsExpense=0) "
                    End Select
                End If
                Dim oData = New CServiceCode(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""servicecode"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetServiceCode", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetNewServiceCode() As ActionResult
            Try
                Dim oData = New CServiceCode(GetSession("ConnJob"))
                Dim msg As String = "OK"
                oData.AddNew("")
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""servicecode"":{""data"":[" & json & "],""result"":""" & msg & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetNewServiceCode", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetCompany(<FromBody()> data As CCompany) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If data.CustCode = "{AUTO}" Then
                        If GetValueConfig("RUNNING_BYMASK", "CUSTOMER") <> "" Then
                            Dim mask = GetValueConfig("RUNNING_BYMASK", "CUSTOMER")
                            data.CustCode = GetMaxByMask(GetSession("ConnJob"), String.Format("SELECT MAX(CustCode) as t FROM Mas_Company where CustCode like '{0}'", mask), mask)
                        Else
                            data.CustCode = ""
                        End If
                    End If

                    If "" & data.CustCode = "" Then
                        Dim sql = Main.GetValueConfig("SQL", "SelectGroupCustomerRunning")
                        If (sql = "") Then
                            Dim jsont = "{""result"":{""data"":null,""msg"":""Customer Code must be input""}}"
                            Return Content(jsont, jsonContent)
                        End If
                        Dim codeSearch = data.NameEng.Replace(" ", "").Replace(".", "").Substring(0, 5)
                        If (codeSearch = "") Then
                            Dim jsont = "{""result"":{""data"":null,""msg"":""Name English must be input""}}"
                            Return Content(jsont, jsonContent)
                        End If
                        sql = String.Format("select t.* from (" & sql & ") t where t.Code='{0}'", codeSearch)
                        Dim newCode = ""
                        Dim dt = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
                        If dt.Rows.Count > 0 Then
                            If dt.Rows(0)("Code").Equals(System.DBNull.Value) Then
                                newCode = codeSearch & "0001"
                            Else
                                newCode = dt.Rows(0)("Code").ToString() & (Convert.ToDouble(dt.Rows(0)("Counter")) + 1).ToString("0000")
                            End If
                        End If
                        If (newCode = "") Then
                            Dim jsont = "{""result"":{""data"":null,""msg"":""Customer Code must be input""}}"
                            Return Content(jsont, jsonContent)
                        End If
                        data.CustCode = newCode
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE CustCode='{0}' And Branch='{1}' ", data.CustCode, data.Branch))
                    Dim json = "{""result"":{""data"":""" & data.CustCode & """,""msg"":""" & msg & """}}"
                    'Dim msg = JsonConvert.SerializeObject(data)
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetCompany", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SetVender(<FromBody()> data As CVender) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If data.VenCode = "{AUTO}" Then
                        If GetValueConfig("RUNNING_BYMASK", "VENDER") <> "" Then
                            Dim mask = GetValueConfig("RUNNING_BYMASK", "VENDER")
                            data.VenCode = GetMaxByMask(GetSession("ConnJob"), String.Format("SELECT MAX(VenCode) as t FROM Mas_Vender where VenCode like '{0}'", mask), mask)
                        Else
                            data.VenCode = ""
                        End If
                    End If
                    If "" & data.VenCode = "" Then
                        Dim sql = Main.GetValueConfig("SQL", "SelectGroupVenderRunning")
                        If (sql = "") Then
                            Dim jsont = "{""result"":{""data"":null,""msg"":""Vender Code must be input""}}"
                            Return Content(jsont, jsonContent)
                        End If
                        Dim codeSearch = data.English.Replace("-", "").Replace("MR.", "").Replace(" ", "").Replace(".", "").Substring(0, 5)
                        If (codeSearch = "") Then
                            Dim jsont = "{""result"":{""data"":null,""msg"":""Name English must be input""}}"
                            Return Content(jsont, jsonContent)
                        End If
                        sql = String.Format("select t.* from (" & sql & ") t where t.Code='{0}'", codeSearch)
                        Dim newCode = ""
                        Dim dt = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
                        If dt.Rows.Count > 0 Then
                            If dt.Rows(0)("Code").Equals(System.DBNull.Value) Then
                                newCode = codeSearch & "0001"
                            Else
                                newCode = dt.Rows(0)("Code").ToString() & (Convert.ToDouble(dt.Rows(0)("Counter")) + 1).ToString("0000")
                            End If
                        End If
                        If (newCode = "") Then
                            Dim jsont = "{""result"":{""data"":null,""msg"":""Vender Code must be input""}}"
                            Return Content(jsont, jsonContent)
                        End If
                        data.VenCode = newCode
                    End If

                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE VenCode='{0}' ", data.VenCode))
                    Dim json = "{""result"":{""data"":""" & data.VenCode & """,""msg"":""" & msg & """}}"
                    'Dim msg = JsonConvert.SerializeObject(data)
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetVender", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SetUser(<FromBody()> data As CUser) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.UserID = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please select staff""}}", jsonContent)
                    End If

                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE UserID='{0}' ", data.UserID))
                    Dim json = "{""result"":{""data"":""" & data.UserID & """,""msg"":""" & msg & """}}"
                    'Dim msg = JsonConvert.SerializeObject(data)
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetUser", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SetServiceCode(<FromBody()> data As CServiceCode) As ActionResult
            Try
                If Not IsNothing(data) Then
                    data.SetConnect(GetSession("ConnJob"))
                    If data.SICode.ToString().Substring(data.SICode.ToString().Length - 1, 1) = "-" Then
                        data.AddNew(data.SICode + "___")
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE SICode='{0}' ", data.SICode))
                    Dim json = "{""result"":{""data"":""" & data.SICode & """,""msg"":""" & msg & """}}"
                    'Dim msg = JsonConvert.SerializeObject(data)
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetServicecode", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function GetBranch() As ActionResult
            Try
                Dim tSqlw As String = " WHERE [Code]<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND [Code]='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CBranch(GetSession("ConnJob")).GetData("SELECT * FROM Mas_Branch " & tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""branch"":{""data"":""" & json & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetBranch", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetBranch(<FromBody()> data As CBranch) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.Code = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE [Code]='{0}' ", data.Code))
                    Dim json = "{""result"":{""data"":""" & data.Code & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetBranch", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try

        End Function
        Function DelBranch() As ActionResult

            Try
                Dim tSqlw As String = " WHERE [Code]<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND [Code] Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""branch"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CBranch(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""branch"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelBranch", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetServiceBudget() As ActionResult
            Try
                Dim tSqlW As String = " AND b.Active=1 "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlW &= String.Format(" AND b.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= String.Format(" AND b.JobType={0} ", Request.QueryString("JType").ToString)
                End If
                If Not IsNothing(Request.QueryString("SBy")) Then
                    tSqlW &= String.Format(" AND b.ShipBy={0} ", Request.QueryString("SBy").ToString)
                End If

                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(Main.SQLSelectServiceBudget() & tSqlW)
                Dim json As String = JsonConvert.SerializeObject(oData.Rows)
                json = "{""budgetpolicy"":{""data"":" & json & ",""msg"":""OK""}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetServiceBudget", ex.Message, ex.StackTrace, True)
                Return Content("{""budgetpolicy"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetBudgetPolicy() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ID<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND ID={0}", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CBudgetPolicy(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""budgetpolicy"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetBudgetPolicy", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetBudgetPolicy(<FromBody()> data As CBudgetPolicy) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.ID = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE ID={0} ", data.ID))
                    Dim json = "{""result"":{""data"":""" & data.ID & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetBudgetPolicy", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelBudgetPolicy() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ID<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ID Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""budgetpolicy"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CBudgetPolicy(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""budgetpolicy"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelBudgetPolicy", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetCustomsUnit() As ActionResult
            Try
                Dim tSqlw As String = " WHERE [Code]<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND [Code] ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CCustomsUnit(GetSession("ConnMas")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""customsunit"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCustomsUnit", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetCustomsUnit(<FromBody()> data As CCustomsUnit) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.Code = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnMas"))
                    Dim msg = data.SaveData(String.Format(" WHERE [Code]='{0}' ", data.Code))
                    Dim json = "{""result"":{""data"":""" & data.Code & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetCustomsUnit", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelCustomsUnit() As ActionResult
            Try
                Dim tSqlw As String = " WHERE [Code]<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND [Code] Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""customsunit"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CCustomsUnit(GetSession("ConnMas"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""customsunit"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelCustomsUnit", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function CarLicense() As ActionResult
            Return GetView("CarLicense")
        End Function

        Function Employee() As ActionResult
            Return GetView("Employee")
        End Function
        Function GetCarLicense() As ActionResult
            Try
                Dim tSqlw As String = " WHERE CarNo<>'' "
                If Not IsNothing(Request.QueryString("code")) Then
                    tSqlw &= String.Format("AND CarNo ='{0}'", Request.QueryString("code").ToString)
                End If
                If Not IsNothing(Request.QueryString("type")) Then
                    tSqlw &= String.Format("AND CarType ='{0}'", Request.QueryString("type").ToString)
                End If
                'Return Content(tSqlw, jsonContent)
                Dim oData = New CarLicense(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""carlicense"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content(ex.StackTrace + ex.Message, jsonContent)
            End Try
        End Function

        Function GetCarNos() As ActionResult
            Try

                'Return Content(tSqlw, jsonContent)
                Dim oData = New CarLicense(GetSession("ConnJob")).GetLicenseList()
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""carNos"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content(ex.StackTrace + ex.Message, jsonContent)
            End Try
        End Function

        Function SetCarLicense(<FromBody()> data As CarLicense) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.CarNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE CarNo='{0}' ", data.CarNo))
                    Dim json = "{""result"":{""data"":""" & data.CarNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelCarLicense() As ActionResult
            Try
                Dim tSqlw As String = " WHERE CarNo<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND CarNo Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""carlicense"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CarLicense(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""carlicense"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]", jsonContent)
            End Try
        End Function

        Function GetEmployee() As ActionResult
            Try
                Dim tSqlw As String = " WHERE EmpCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND EmpCode ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New Employee(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""employee"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetEmployee(<FromBody()> data As Employee) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.EmpCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE EmpCode='{0}' ", data.EmpCode))
                    Dim json = "{""result"":{""data"":""" & data.EmpCode & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelEmployee() As ActionResult
            Try
                Dim tSqlw As String = " WHERE EmpCode<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND EmpCode Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""employee"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New Employee(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""employee"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function ChangeCustomer() As ActionResult
            Dim fromCode As String = Request.QueryString("FromCode")
            Dim fromBranch As String = Request.QueryString("FromBranch")
            Dim toCode As String = Request.QueryString("ToCode")
            Dim toBranch As String = Request.QueryString("ToBranch")
            Return Content(Main.DBExecute(GetSession("ConnJob"), String.Format("dbo.ChangeCustomer '{0}','{1}','{2}','{3}'", fromCode, fromBranch, toCode, toBranch)), textContent)
        End Function
        Function ChangeVender() As ActionResult
            Dim fromCode As String = Request.QueryString("FromCode")
            Dim toCode As String = Request.QueryString("ToCode")
            Return Content(Main.DBExecute(GetSession("ConnJob"), String.Format("dbo.ChangeVender '{0}','{1}'", fromCode, toCode)), textContent)
        End Function
    End Class
End Namespace