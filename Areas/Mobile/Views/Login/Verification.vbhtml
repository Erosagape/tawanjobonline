@Code
    ViewData("Title") = "Verification"
End Code

<h2>Verification</h2>
<form action="" method="post">
    <div class="row">
        <div class="col-md-4">
            Please Input your Password : @ViewBag.User
        </div>
        <div class="col-md-6">
            <input type="password" class="form-control" name="txtUserPassword" />
        </div>
    </div>
    <input type="submit" value="Proceed" class="btn btn-success" />
    <input type="hidden" name="txtUserID" value="@ViewBag.User" />
    <input type="hidden" name="txtUserRole" value="@ViewBag.UserRole" />
    <input type="hidden" name="txtDatabaseID" value="@ViewBag.UserDB" />
</form>
@ViewBag.Message