@Code
    ViewData("Title") = "Login"
End Code
<table>
    <tr>
        <td>User ID :</td>
        <td><input type="text" id="txtUserID" /></td>
    </tr>
    <tr>
        <td>Password :</td>
        <td><input type="password" id="txtPassword" /></td>
    </tr>
</table>
<button id="btnLogin" class="btn btn-primary" onclick="CheckLogin()">Log in</button>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    function CheckLogin() {
        getData(path+'home/checklogin?uid=' + $('#txtUserID').val() + '&upwd=' + $('#txtPassword').val(),function (res) {
            if (res == 'OK') {
                window.open(path + 'home/index');
            } else {
                alert(res);
            }
        });
    }
</script>

