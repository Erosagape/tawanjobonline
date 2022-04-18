@Code
    ViewData("Title") = "PostForm"
End Code

<h2>PostForm</h2>
<form id="myform" method="post" action="/Test/PostForm">
    <input type="text" name="text1" id="txt1" required/>
    <br/>
    <input type="text" name="text2" id="txt2" required />
    <br/>
    <input type="button" value="Submit" onclick="DoPost()" />
    @ViewBag.Result
</form>
<script type="text/javascript">
    function DoPost() {
        if ($('#txt1').val() == '') {
            alert('data not complete');
            $('#txt1').focus();
            return;
        }
        if ($('#txt2').val() == '') {
            alert('data not complete');
            $('#txt2').focus();
            return;
        }

        $('#myform').submit();
    }
</script>

