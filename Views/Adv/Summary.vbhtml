@Code
    ViewData("Title") = "Summary"
End Code
<style>
    thead > tr > th {
        background-color: lightblue;
        color: blue;
    }

    .number {
        text-align: right;
    }

    .groupfooter {
        background-color: lightyellow;
        color: red;
    }

    .groupheader {
        background-color: lightpink;
        color: blue;
        text-align: center;
    }

    .grouptotal {
        background-color: lightgreen;
        color: blue;
        text-align: right;
    }
</style>
<script type="text/javascript">
    var path = '@Url.Content("~")';
</script>
@Code
    If ViewBag.User <> "" Then
        @Html.Raw(ViewBag.DataGrid1)
    End If
End Code