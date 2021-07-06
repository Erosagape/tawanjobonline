Imports System.Web.Mvc
Imports System.Web.Http
Imports Newtonsoft.Json
Namespace Controllers
    Public Class DefaultController
        Inherits CController

        ' GET: Default
        Function Index() As ActionResult
            Return View()
        End Function
        Function TestTracking() As ActionResult
            Return View()
        End Function
        Function CarLicense() As ActionResult
            Return GetView("CarLicense")
        End Function
        Function TestDate(<FromBody()> ByVal data As CTestDate) As ActionResult
            data.DocDate = Main.GetDBDate(data.DocDate)
            Dim json = JsonConvert.SerializeObject(data)
            Return Content(json, jsonContent)
        End Function
        Function TestQR() As ActionResult
            Return GetView("TestQR")
        End Function
        Function TestCanvas() As ActionResult
            Return GetView("TestCanvas")
        End Function
        Function PostCanvas(<FromBody()> dataImage As String) As ActionResult
            Dim str = dataImage.Split(";")
            Dim fileName = ""
            If Request.QueryString("ID") IsNot Nothing Then
                fileName = Request.QueryString("ID").ToString()
            End If
            Dim msg = "Cannot Process Data"
            If str.Length = 2 And fileName <> "" Then
                If str(1).IndexOf(",") > 0 Then
                    Dim imgArr = str(1).Split(",")
                    Try
                        System.IO.File.WriteAllBytes(Server.MapPath("~/Resource/Import") + "/" & fileName & ".png", Convert.FromBase64String(imgArr(1)))
                        msg = "Save Completed!"
                    Catch ex As Exception
                        msg = ex.Message
                    End Try
                End If
            End If
            Return Content(msg, "text/html")
        End Function
        Function GetCarLicense() As ActionResult
            Try
                Dim tSqlw As String = " WHERE CarNo<>'' "
                If Not IsNothing(Request.QueryString("code")) Then
                    tSqlw &= String.Format("AND CarNo ='{0}'", Request.QueryString("code").ToString)
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

        '-----Controller-----
        Function Employee() As ActionResult
            Return GetView("Employee")
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
    End Class
End Namespace