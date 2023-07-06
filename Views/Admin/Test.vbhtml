@Code
    ViewData("Title") = "Test"
    Layout = "~/Views/Shared/_Layout.vbhtml"
    Dim param1 = "Param1"
    If Request.QueryString("Param1") IsNot Nothing Then
        param1 = Request.QueryString("Param1")
    End If
    Dim param2 = "Param2"
    If Request.QueryString("Param2") IsNot Nothing Then
        param2 = Request.QueryString("Param2")
    End If
    ViewBag.Param1 = param1
    ViewBag.Param2 = param2
End Code
<h2>Test</h2>
<label id="lblTest">
    This is the Test
</label>
<p>
    Param1 : @ViewBag.Param1
    <br />
    Param2 : @ViewBag.Param2
</p>
<p>
    @Html.Partial("Partial1")
</p>

<script>
</script>
