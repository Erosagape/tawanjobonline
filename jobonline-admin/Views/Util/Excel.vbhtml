@Code
    ViewData("Title") = "Excel"
End Code
<h2>Excel Upload</h2>
@For Each fileName As String In ViewBag.FileList
    @<a href="~/Resources/Import/@fileName">@fileName</a>
Next
<form method = "post" action="" enctype="multipart/form-data">
    <input type = "file" name="xlsFiles"/>
    <input type="submit" value="Submit" />
</form>


