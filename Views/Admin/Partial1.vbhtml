@Code
    Dim param1 = ViewBag.Param1
    Dim param2 = ViewBag.Param2
End Code
<div class="row">
    <div class="col-sm-6">
        Hi,I'm Partial #1
    </div>
    <div class="col-sm-6">
        Param1 : @param1<br />
        Param2 : @param2
    </div>
</div>
<p>
    This is derived<br />
    @Html.Partial("Partial2")
</p>

