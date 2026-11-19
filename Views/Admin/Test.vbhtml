@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<input type="text" id="txtSQL" value="SELECT * FROM v_JOB_WHTAX" />
<input type="button" onclick="ReadData()" value="Get Data" />
<script type="text/javascript">
    let path = '@Url.Content("~")';
    function ReadData() {
        let obj = {
            IsError:false,
            Source:$('#txtSQL').val(),
            Param:"JOB",
            Result:"Y"
        };
        $.post(path+'Config/GetSQLResult?Database=1', obj).done(function (r) {
            alert(r.result.msg);
        });
    }
</script>
