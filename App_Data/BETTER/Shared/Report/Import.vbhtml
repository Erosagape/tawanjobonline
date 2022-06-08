@Code
    ViewData("Title") = "Import"
End Code
<script type="text/javascript">
    var path = '@Url.Content("~")';
</script>
<h2>Import Job Order From Excel</h2>
@Using Html.BeginForm("Import", "Report", FormMethod.Post, New With {.enctype = "multipart/form-data"})
    @<label id="lblMessage">@ViewBag.Message</label>
    @<input type="file" name="fileUpload" />
    @<input type="submit" value="Upload" />
    If Not ViewBag.Data Is Nothing Then
        @<table>
            <tr>
                @For Each col In ViewBag.Data.Columns
                    @<td>@col.ColumnName</td>
                Next
            </tr>
            @For Each row In ViewBag.Data.Rows
                @<tr>
                    @For Each col In ViewBag.Data.Columns
                        @<td>@row(col.ColumnName).ToString</td>
                    Next
                </tr>
            Next
        </table>
    End If
End Using

