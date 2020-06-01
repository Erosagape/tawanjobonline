Imports System.Web.Mvc

Public Class CController
    Inherits Controller
    Friend Sub ClearSession()
        Session("CurrUser") = Nothing
        Session("UserName") = Nothing
        Session("CurrRights") = Nothing
        Session("CurrForm") = Nothing
    End Sub
    Friend Function GetSession(sName As String) As String
        If IsNothing(Session(sName)) Then
            Select Case sName
                Case "CurrRights"
                    Session(sName) = "*MIREDP"
                Case Else
                    Session(sName) = ""
            End Select
        End If
        Return Session(sName).ToString
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
        ViewBag.UserName = GetSession("UserName").ToString
        ViewBag.Module = GetSession("CurrForm").ToString
        ViewBag.SessionID = Session.SessionID
        ViewBag.UserRights = GetSession("CurrRights").ToString()
        ViewBag.Error = ""
        Return Not bExpired
    End Function
    Friend Function GetView(vName As String, Optional modName As String = "") As ActionResult
        Dim baseURL = Me.ControllerContext.RouteData.Values("Controller").ToString() & "\" & vName
        Try
            If GetSession("CurrUser") = "" Then
                Return RedirectToAction("Login", "Home")
            End If
            LoadCompanyProfile()
            If modName <> "" And ViewBag.User <> "" Then
                Session("CurrForm") = modName & "/" & vName
            Else
                Session("CurrForm") = Me.ControllerContext.RouteData.Values("Controller").ToString() & "/" & vName
            End If
            ViewBag.Module = GetSession("CurrForm").ToString()
            ViewBag.UserRights = GetSession("CurrRights").ToString()
            Return View(vName)
        Catch ex As Exception
            ViewBag.Error = ex.Message
            Return RedirectToAction("Login", "Home")
        End Try
    End Function
End Class
