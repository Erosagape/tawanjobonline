@Code
    ViewBag.Title = "Clearing Information"
    Dim mobileMode As Boolean = False
    If Not Request.QueryString("Mode") Is Nothing Then
        mobileMode = IIf(Request.QueryString("Mode").ToString().ToUpper().Equals("MOBILE"), True, False)
    End If
End Code

@If mobileMode Then
    @Html.Partial("ClrMobile")
Else
    @Html.Partial("ClrDesktop")
End If
