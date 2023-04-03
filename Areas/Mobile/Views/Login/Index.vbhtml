
@Code    
    ViewData("Title") = "Index"
End Code
<h2>Who are you?</h2>
<form action="" method="post">
    <div class="row">
        <div class="col-md-6">
            Log-in as:
        </div>
        <div class="col-md-6">
            <select class="form-control dropdown" name="cboRole">
                <option value="S">Staff</option>
                <option value="C">Shipper/Consignee</option>
                <option value="V">Agent/Vender</option>
            </select>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            Your ID:
        </div>
        <div class="col-md-6">
            <input type="text" class="form-control" name="txtUserID" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            Log-in to:
        </div>
        <div class="col-md-6">
            <select class="form-control dropdown" name="cboDatabase">
@For Each dr As System.Data.DataRow In ViewBag.DatabaseList.Rows
    @<option value="@dr("Seq")">@dr("Comment").ToString</option>
Next
            </select>
        </div>
    </div>
    <input type = "submit" Class="btn btn-success fa fa-unlock" value="Log-in" />
</form>
@ViewBag.Message
