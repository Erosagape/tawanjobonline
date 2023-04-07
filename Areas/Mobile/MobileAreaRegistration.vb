Imports System.Web.Mvc
Namespace Areas.Mobile
    Public Class MobileAreaRegistration
        Inherits AreaRegistration

        Public Overrides ReadOnly Property AreaName() As String
            Get
                Return "Mobile"
            End Get
        End Property

        Public Overrides Sub RegisterArea(ByVal context As AreaRegistrationContext)
            context.MapRoute(
                "Mobile_default",
                "Mobile/{controller}/{action}/{id}",
                New With {.action = "Index", .id = UrlParameter.Optional}
            )
        End Sub
    End Class
End Namespace