@Code
    ViewData("Title") = "Test"
End Code

<h2>Test</h2>
<input type="text" id="txtField1" />
<input type="text" id="txtField2" />
<input type="button" onclick="PostData()" value="Post" />
<script type="text/javascript">
    function PostData(){
        var obj = {
            Field1: $('#txtField1').val(),
            Field2: $('#txtField2').val()
        };
        var json = JSON.stringify({ data: obj });
        $.ajax({
            url: '/Home/TestPost',
            type: "POST",
            contentType: "application/json",
            data: json,
            success: function (r) {
                alert(r);
            }
        });
    }
</script>
