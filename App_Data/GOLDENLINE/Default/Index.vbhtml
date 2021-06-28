@Code
    ViewData("Title") = "Index"
End Code
<input type="date" id="date1" />
<input type="button" value="Test" onclick="TestDate('#date1')" />
<input type="text" id="date2" />
<input type="button" value="Test" onclick="TestDate('#date2')" />
<input type="datetime-local" id="date3" />
<input type="button" value="Test" onclick="TestDate('#date3')" />
Return Data :
<input type="text" id="dateret"/>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    function TestDate(e) {
        let obj = {
            DocDate:CDateEN($(e).val())
        };        
        $.ajax({
                url: path +"Default/TestDate",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({ data: obj }),
                success: function (response) {
                    alert(response.DocDate);
                    $('#dateret').val(ShowDate(response.DocDate));
                }
            });
    }    
</script>