@Code
    ViewData("Title") = "General Ledger Process"
    Dim tb = CType(ViewBag.DataSource, System.Data.DataTable)
End Code
<script type="text/javascript">
    var path = '@Url.Content("~")';
</script>
<form action="" method="post">
    <div class="row">
        <div class="col-sm-4">
            <label id="lblBranch">Branch</label>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtBranchCode" name="Branch" value="@ViewBag.Branch" style="width:15%" readonly />
                <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                <input type="text" class="form-control" id="txtBranchName" value="@ViewBag.PROFILE_DEFAULT_BRANCH_NAME" style="width:65%" disabled />
            </div>
        </div>
        <div class="col-sm-2">
            <label id="lblDateFrom">Date From</label>
            <br />
            <input type="date" id="txtDateFrom" class="form-control" name="DateFrom" value="@ViewBag.DateFrom" />
        </div>
        <div class="col-sm-2">
            <label id="lblDateTo">Date To</label>
            <br />
            <input type="date" id="txtDateTo" class="form-control" name="DateTo" value="@ViewBag.DateTo" />
        </div>
        <div class="col-sm-2">
            <br />
            <input type="button" class="btn btn-success" id="btnShow" value="View" />
        </div>
    </div>
    <input type="submit" value="Process" class="btn btn-danger" />
    <a href="glnote" class="btn btn-warning">GL Details</a>
</form>
@Code
    @<table class="table table-responsive">
         <thead>
             <tr>
                 <th>Description</th>
                 <th>Debit</th>
                 <th>Credit</th>
             </tr>
         </thead>
        @If tb.Rows.Count > 0 And tb.Columns.Count > 1 Then
            @<tbody>
                @For Each dr As System.Data.DataRow In tb.Rows
                    If dr("GLDescription").ToString <> "" Then
                        @<tr>
                            <td>@dr("GLDescription")</td>
                            <td>@Convert.ToDouble(dr("Debit")).ToString("#,##0.00")</td>
                            <td>@Convert.ToDouble(dr("Credit")).ToString("#,##0.00")</td>
                        </tr>
                    End If
                Next
            </tbody>
        End If
    </table>
End Code
<div id="dvLOVs"></div>
<script type="text/javascript">
    $('#btnShow').bind('click', function () {
        window.location.href= path + 'acc/GLProcess?Branch=' +$('#txtBranchCode').val() + '&DateFrom=' + $('#txtDateFrom').val() + '&DateTo=' + $('#txtDateTo').val();
    });
    //3 Fields Show
    $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
        let dv = document.getElementById("dvLOVs");
        //Branch
        CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
    });
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
        }
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
</script>