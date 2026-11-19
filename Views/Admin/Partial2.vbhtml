@Code
    Dim param1 = ViewData("Param1")
    Dim param2 = ViewData("Param2")
End Code
<div class="row">
    <div class="col-sm-6">
        Hi,I'm Partial #2
    </div>
    <div class="col-sm-6">
        Param1 : @param1<br />
        Param2 : @param2
    </div>
</div>
