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
        Function TestDate(<FromBody()> ByVal data As CTestDate) As ActionResult
            data.DocDate = Main.GetDBDate(data.DocDate)
            Dim json = JsonConvert.SerializeObject(data)
            Return Content(json, jsonContent)
        End Function
    End Class
End Namespace