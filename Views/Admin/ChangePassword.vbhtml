@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewData("Title") = "ChangePassword"
End Code
<h2>Change Password</h2>
<form method="post" action="">
    <input type="hidden" id="txtDatabase" value="1" name="db" />
    <div class="panel-primary">
        <div class="panel-heading">
            Your User Name : <input type="text" class="form-control" id="txtUserID" name="userid" value="" />
        </div>
    </div>
    <div class="panel-danger">
        <div class="panel-heading">
            Old Password :            <input type="password" class="form-control" id="txtOldPassword" name="oldpass" value="" />
        </div>
    </div>
    <div class="panel-success">
        <div class="panel-heading">
            New Password :<input type="password" class="form-control" id="txtNewPassword" name="newpass" value="" />
        </div>
    </div>
    <button type="submit" class="btn btn-success">Change Password</button>
    @Html.Raw(ViewBag.Message)
</form>
<script type="text/javascript">
    var user = getQueryString("Code");
    var db = getQueryString("DB");
    if (user !== '') {
        $('#txtUserID').val(user);
    }
    if (db !== '') {
        $('#txtDatabase').val(db);
    }
</script>
