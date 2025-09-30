@Code
    ViewBag.Title = "Clearing Information"
    Dim mobileMode As String = ""
    If Not Request.QueryString("Mode") Is Nothing Then
        mobileMode = Request.QueryString("Mode").ToUpper()
    End If
End Code
@If mobileMode = "MOBILE" Then
    @Html.Partial("ClrMobile")
Else
    @Html.Partial("ClrDesktop")
End If

