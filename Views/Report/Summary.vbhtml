@Code
    ViewData("Title") = "Summary"
End Code
<style>
    tbody > tr {
        display: none;
    }
    tbody > tr.header {
        display: table-row;
        font-weight:bold;
        text-decoration:underline;
    }
    tbody > tr.hide {
        display: none;
    }
    tbody > tr.detail {
        background-color:lightyellow;
    }
    .status0 {
        background-color: lightgray;
        color: black;
    }
    .status1 {
        background-color:khaki;
        color:black;
    }
    .status2 {
        background-color:lightcoral;
        color:yellow;
    }
    .status3 {
        background-color:yellow;
        color: red;
    }
    .status4 {
        background-color:aqua;
        color:blue;
    }
    .status5 {
        background-color:blue;
        color:white;
    }
    .status6 {
        background-color:lightgreen;
        color:green;
    }
    .status7 {
        background-color:green;
        color:white;
    }
    .status98 {
        background-color:brown;
        color:white;
    }
    .status99 {
        background-color:red;
        color:white;
    }
</style>
<div class="row" id="dvBackground">
    <div class="col-md-12 text-center">
        <br />
        <img src="~/Resource/jobtawan_bg.jpg" style="width:100%" />
    </div>
</div>
<div id="dvSummary" style="display:none;">
    @Code
        If ViewBag.User <> "" Then
            @Html.Raw(ViewBag.DataHTML)
        End If
    End Code
</div>
<script type = "text/javascript" >
    let path = '@Url.Content("~")';
    let user = '@ViewBag.User';
    if (user != '') {
        $('#dvBackground').hide();
        $('#dvSummary').show();
    }
    $('tr.header').click(function () {
        $(this).nextUntil('tr.header').css('display', function (i, v) {
            return this.style.display === 'table-row' ? 'none' : 'table-row';
        });
    });
</script>