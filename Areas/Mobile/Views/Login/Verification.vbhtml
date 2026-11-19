@Code
    ViewData("Title") = "Verification"
End Code
<form action="" method="post" class="container">
    <div class="row">
        <div class="col-md-4">
            Please Input your Password : @ViewBag.User
        </div>
        <div class="col-md-6">
            <input type="password" class="form-control" name="txtUserPassword"  autofocus/>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <input type="submit" value="Proceed" class="btn btn-success" />
        </div>
    </div>    
    <input type="hidden" name="txtUserID" value="@ViewBag.User" />
    <input type="hidden" name="txtUserRole" value="@ViewBag.UserRole" />
    <input type="hidden" name="txtDatabaseID" value="@ViewBag.UserDB" />
    <input type="hidden" name="Redirect" value="@ViewBag.Redirect" />
</form>
@ViewBag.Message