Imports System.Web.Mvc
Imports Newtonsoft.Json
Public Class CController
    Inherits Controller
    Friend Sub New()
        Current = New CSession()
    End Sub
    Friend Property Current As CSession
    Friend Property SessionData As String
    Friend Sub SaveSession()
        Current.CurrUser = GetSession("CurrUser")
        Current.UserGroup = GetSession("UserGroup")
        Current.UserProfiles = CType(Session("UserProfiles"), CUser)
        Current.CurrIP = Request.UserHostAddress
        Current.DatabaseID = GetSession("DatabaseID")
        Current.CurrLicense = GetSession("CurrLicense")
        Current.ConnJob = GetSession("ConnJob")
        Current.ConnMas = GetSession("ConnMas")
        Current.CurrForm = GetSession("CurrForm")
        Current.CurrRights = GetSession("CurrRights")
        Current.CurrBranch = GetSession("CurrBranch")
        Current.CurrBranchName = GetSession("CurrBranchName")
        Current.CompanyLogo = GetSession("CompanyLogo")
        Current.CompanyName = GetSession("CompanyName")
        Current.CompanyName_EN = GetSession("CompanyName_EN")
        Current.CompanyFax = GetSession("CompanyFax")
        Current.CompanyTel = GetSession("CompanyTel")
        Current.CompanyEMail = GetSession("CompanyEmail")
        Current.CompanyAddr1 = GetSession("CompanyAddr1")
        Current.CompanyAddr2 = GetSession("CompanyAddr2")
        Current.CompanyAddr1_EN = GetSession("CompanyAddr1_EN")
        Current.CompanyAddr2_EN = GetSession("CompanyAddr2_EN")
        Current.CurrentLang = GetSession("CurrentLang")
        Current.Currency = GetSession("Currency")
        Current.VatRate = GetSession("VatRate")
        Current.TaxRate_SRV = GetSession("TaxRate_SRV")
        Current.TaxRate_TRN = GetSession("TaxRate_TRN")
        Current.TaxNumber = GetSession("TaxNumber")
        Current.CreditDays = GetSession("CreditDays")
        Current.TaxBranch = GetSession("TaxBranch")
        Current.MenuType = GetSession("MenuType")
        SessionData = JsonConvert.SerializeObject(Current)
    End Sub
    Friend Sub LoadSession()
        Session("CurrUser") = Current.CurrUser
        Session("UserProfiles") = Current.UserProfiles
        Session("UserGroup") = Current.UserGroup
        Session("UserUpline") = Current.UserProfiles.UserUpline
        Session("DatabaseID") = Current.DatabaseID
        Session("CurrLicense") = Current.CurrLicense
        Session("ConnJob") = Current.ConnJob
        Session("ConnMas") = Current.ConnMas
        Session("CurrForm") = Current.CurrForm
        Session("CurrRights") = Current.CurrRights
        Session("CurrentLang") = Current.CurrentLang
        Session("CurrBranch") = Current.CurrBranch
        Session("CurrBranchName") = Current.CurrBranchName
        Session("CompanyLogo") = Current.CompanyLogo
        Session("CompanyName") = Current.CompanyName
        Session("CompanyName_EN") = Current.CompanyName_EN
        Session("CompanyFax") = Current.CompanyFax
        Session("CompanyTel") = Current.CompanyTel
        Session("CompanyEmail") = Current.CompanyEMail
        Session("CompanyAddr1") = Current.CompanyAddr1
        Session("CompanyAddr2") = Current.CompanyAddr2
        Session("CompanyAddr1_EN") = Current.CompanyAddr1_EN
        Session("CompanyAddr2_EN") = Current.CompanyAddr2_EN
        Session("Currency") = Current.Currency
        Session("VatRate") = Current.VatRate
        Session("TaxRate_TRN") = Current.TaxRate_TRN
        Session("TaxRate_SRV") = Current.TaxRate_SRV
        Session("CreditDays") = Current.CreditDays
        Session("TaxNumber") = Current.TaxNumber
        Session("TaxBranch") = Current.TaxBranch
        Session("MenuType") = Current.MenuType
    End Sub
    Friend Sub ClearSession()
        Session("CurrUser") = Nothing
        Session("UserProfiles") = Nothing
        Session("UserGroup") = Nothing
        Session("UserUpline") = Nothing
        Session("DatabaseID") = Nothing
        Session("CurrLicense") = Nothing
        Session("ConnJob") = Nothing
        Session("ConnMas") = Nothing
        Session("CurrForm") = Nothing
        Session("CurrRights") = Nothing
        Session("CurrentLang") = Nothing
        Session("CurrBranch") = Nothing
        Session("CurrBranchName") = Nothing
        Session("CompanyLogo") = Nothing
        Session("CompanyName") = Nothing
        Session("CompanyName_EN") = Nothing
        Session("CompanyFax") = Nothing
        Session("CompanyTel") = Nothing
        Session("CompanyEmail") = Nothing
        Session("CompanyAddr1") = Nothing
        Session("CompanyAddr2") = Nothing
        Session("CompanyAddr1_EN") = Nothing
        Session("CompanyAddr2_EN") = Nothing
        Session("Currency") = Nothing
        Session("VatRate") = Nothing
        Session("TaxRate_TRN") = Nothing
        Session("TaxRate_SRV") = Nothing
        Session("CreditDays") = Nothing
        Session("TaxNumber") = Nothing
        Session("TaxBranch") = Nothing
        Session("MenuType") = Nothing
        SessionData = ""
    End Sub
    Friend Function GetSession(sName As String) As String
        If IsNothing(Session(sName)) Then
            Select Case sName
                Case "CurrUser"
                    Session(sName) = ""
                Case "DatabaseID"
                    Session(sName) = "1"
                Case "CurrLicense"
                    Session(sName) = "Guest"
                Case "ConnJob"
                    Session(sName) = ""
                Case "ConnMas"
                    Session(sName) = ""
                Case "CurrRights"
                    Session(sName) = "*MIREDP"
                Case "CurrentLang"
                    Session(sName) = GetValueConfig("PROFILE", "DEFAULT_LANGUAGE")
                Case "CurrBranch"
                    Session(sName) = GetValueConfig("PROFILE", "DEFAULT_BRANCH")
                Case "CurrBranchName"
                    Session(sName) = Main.GetValueSQL(GetSession("ConnJob"), String.Format("SELECT BrName FROM Mas_Branch WHERE [Code]='{0}'", ViewBag.PROFILE_DEFAULT_BRANCH)).Result
                Case "CompanyLogo"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_LOGO", "logo-tawan.jpg")
                Case "CompanyName"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_NAME")
                Case "CompanyName_EN"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_NAME_EN")
                Case "CompanyFax"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_FAX")
                Case "CompanyTel"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_TEL")
                Case "CompanyEmail"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_EMAIL")
                Case "CompanyAddr1"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_ADDRESS1")
                Case "CompanyAddr2"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_ADDRESS2")
                Case "CompanyAddr1_EN"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_ADDRESS1_EN")
                Case "CompanyAddr2_EN"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_ADDRESS2_EN")
                Case "Currency"
                    Session(sName) = GetValueConfig("PROFILE", "CURRENCY")
                Case "CreditDays"
                    Session(sName) = GetValueConfig("PROFILE", "PAYMENT_CREDIT_DAYS")
                Case "TaxNumber"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_TAXNUMBER")
                Case "TaxBranch"
                    Session(sName) = GetValueConfig("PROFILE", "COMPANY_TAXBRANCH")
                Case "VatRate"
                    Session(sName) = GetValueConfig("PROFILE", "VATRATE")
                Case "TaxRate_TRN"
                    Session(sName) = GetValueConfig("PROFILE", "TAXRATE_TRN", "1")
                Case "TaxRate_SRV"
                    Session(sName) = GetValueConfig("PROFILE", "TAXRATE_SRV", "3")
                Case "UserGroup"
                    Session(sName) = "S"
                Case "UserUpline"
                    Session(sName) = ""
                Case "MenuType"
                    Session(sName) = GetValueConfig("PROFILE", "MENU_TYPE", "D")
                Case Else
                    Session(sName) = ""
            End Select
        End If
        Return Session(sName).ToString
    End Function
    Friend Function FindSessionFromDB(ip As String, userSession As String) As Boolean
        Dim oData = New CWebLogin(ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString)
        Dim oFind = oData.GetData(String.Format(" WHERE FromIP='{0}' AND SessionID='{1}' AND ExpireDateTime>GETDATE() AND CustID='{2}' ", ip, userSession, My.Settings.LicenseTo))
        If oFind.Count = 0 Then
            Return False
        Else
            Dim oJson = oFind(0).SessionData.ToString()
            If oJson <> "" Then
                Current = JsonConvert.DeserializeObject(Of CSession)(oJson)
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Friend Function CheckSession(sName As String) As Boolean
        If IsNothing(Session(sName)) Then
            Return True
        Else
            Return False
        End If
    End Function
    Friend Function LoadCompanyProfile() As Boolean
        Dim bExpired = False
        ViewBag.User = GetSession("CurrUser").ToString
        If ViewBag.User = "" Then
            bExpired = True
            ViewBag.UserName = "**TIME OUT**"
        End If
        If FindSessionFromDB(Request.UserHostAddress, Session.SessionID) = True Then
            LoadSession()
        End If
        If CheckSession("UserProfiles") = False Then
            ViewBag.UserName = DirectCast(Session("UserProfiles"), CUser).TName
            ViewBag.UserPosition = DirectCast(Session("UserProfiles"), CUser).UPosition
            ViewBag.UserUpline = DirectCast(Session("UserProfiles"), CUser).UserID
        Else
            ViewBag.UserUpline = GetSession("UserUpline").ToString
        End If
        ViewBag.UserGroup = GetSession("UserGroup").ToString
        ViewBag.CONNECTION_JOB = GetSession("ConnJob").ToString
        ViewBag.CONNECTION_MAS = GetSession("ConnMas").ToString
        ViewBag.DATABASE = GetSession("DatabaseID").ToString
        ViewBag.LICENSE_NAME = GetSession("CurrLicense").ToString
        If ViewBag.CONNECTION_JOB <> "" Then
            ViewBag.PROFILE_DEFAULT_LANG = GetSession("CurrentLang").ToString()
            ViewBag.PROFILE_DEFAULT_BRANCH = GetSession("CurrBranch").ToString
            ViewBag.PROFILE_DEFAULT_BRANCH_NAME = GetSession("CurrBranchName").ToString
            ViewBag.PROFILE_LOGO = GetSession("CompanyLogo").ToString
            ViewBag.PROFILE_COMPANY_NAME = GetSession("CompanyName").ToString
            ViewBag.PROFILE_COMPANY_NAME_EN = GetSession("CompanyName_EN").ToString
            ViewBag.PROFILE_COMPANY_FAX = GetSession("CompanyFax").ToString
            ViewBag.PROFILE_COMPANY_TEL = GetSession("CompanyTel").ToString
            ViewBag.PROFILE_COMPANY_EMAIL = GetSession("CompanyEmail").ToString
            ViewBag.PROFILE_COMPANY_ADDR1 = GetSession("CompanyAddr1").ToString
            ViewBag.PROFILE_COMPANY_ADDR2 = GetSession("CompanyAddr2").ToString
            ViewBag.PROFILE_COMPANY_ADDR1_EN = GetSession("CompanyAddr1_EN").ToString
            ViewBag.PROFILE_COMPANY_ADDR2_EN = GetSession("CompanyAddr2_EN").ToString
            ViewBag.PROFILE_CURRENCY = GetSession("Currency").ToString
            ViewBag.PROFILE_VATRATE = GetSession("VatRate").ToString
            ViewBag.PROFILE_WHTRATE_SRV = GetSession("TaxRate_SRV").ToString
            ViewBag.PROFILE_WHTRATE_TRN = GetSession("TaxRate_TRN").ToString
            ViewBag.PROFILE_PAYMENT_CREDIT_DAYS = GetSession("CreditDays").ToString
            ViewBag.PROFILE_TAXNUMBER = GetSession("TaxNumber").ToString
            ViewBag.PROFILE_TAXBRANCH = GetSession("TaxBranch").ToString
            ViewBag.PROFILE_MENU_TYPE = GetSession("MenuType").ToString
        Else
            ViewBag.PROFILE_DEFAULT_BRANCH = ""
            ViewBag.PROFILE_DEFAULT_BRANCH_NAME = ""
            ViewBag.PROFILE_LOGO = "tawan.jpg"
            ViewBag.PROFILE_COMPANY_NAME = ""
            ViewBag.PROFILE_COMPANY_NAME_EN = ""
            ViewBag.PROFILE_COMPANY_FAX = ""
            ViewBag.PROFILE_COMPANY_TEL = ""
            ViewBag.PROFILE_COMPANY_EMAIL = ""
            ViewBag.PROFILE_COMPANY_ADDR1 = ""
            ViewBag.PROFILE_COMPANY_ADDR2 = ""
            ViewBag.PROFILE_COMPANY_ADDR1_EN = ""
            ViewBag.PROFILE_COMPANY_ADDR2_EN = ""
            ViewBag.PROFILE_CURRENCY = ""
            ViewBag.PROFILE_VATRATE = "7"
            ViewBag.PROFILE_WHTRATE_SRV = "3"
            ViewBag.PROFILE_WHTRATE_TRN = "1"
            ViewBag.PROFILE_PAYMENT_CREDIT_DAYS = ""
            ViewBag.PROFILE_TAXNUMBER = ""
            ViewBag.PROFILE_TAXBRANCH = ""
            ViewBag.PROFILE_DEFAULT_LANG = "EN"
            ViewBag.PROFILE_MENU_TYPE = "D"
        End If
        ViewBag.SESSION_ID = Session.SessionID
        SaveSession()
        Return Not bExpired
    End Function
    Friend Sub UpdateSessionToDb()
        SaveSession()
        Dim oLogin = New CWebLogin(ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString).GetData(String.Format(" WHERE FromIP='{0}' AND SessionID='{1}' AND ExpireDateTime>GETDATE()", Request.UserHostAddress, Session.SessionID))
        If oLogin.Count > 0 Then
            oLogin(0).SessionData = Me.SessionData
            oLogin(0).SaveData(String.Format(" WHERE CustID='{0}' AND AppID='{1}' AND UserLogIN='{2}'", oLogin(0).CustID, oLogin(0).AppID, oLogin(0).UserLogIN))
        End If
    End Sub
    Friend Function GetView(vName As String, modName As String, funcName As String) As ActionResult
        Dim baseURL = Me.ControllerContext.RouteData.Values("Controller").ToString() & "\" & vName
        Try
            LoadCompanyProfile()
            If modName <> "" And ViewBag.User <> "" Then
                Session("CurrForm") = modName & "/" & vName
                ViewBag.Module = GetSession("CurrForm").ToString()
                Session("CurrRights") = Main.GetAuthorize(ViewBag.User, modName, funcName)
                If Session("CurrRights").ToString().IndexOf("M") < 0 Then
                    Return RedirectToAction("AuthError", "Menu")
                End If
            Else
                If Me.ControllerContext.RouteData.Values("Controller").ToString() & "/" & vName <> "Menu/AuthError" Then
                    Session("CurrForm") = Me.ControllerContext.RouteData.Values("Controller").ToString() & "/" & vName
                End If
                Session("CurrRights") = "*MIREDP"
                ViewBag.Module = GetSession("CurrForm").ToString()
            End If
            ViewBag.UserRights = GetSession("CurrRights").ToString()
            Return View(vName)
        Catch ex As Exception
            Return Redirect("~/index.html?message=" & ex.Message)
        End Try
    End Function
    Friend Function GetView(vName As String, Optional modName As String = "") As ActionResult
        Return GetView(vName, modName, vName)
    End Function
End Class
