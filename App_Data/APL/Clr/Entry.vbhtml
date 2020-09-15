
@Code
    ViewBag.Title = "Clearing Advance"
End Code
<div class="panel-body">
    <div id="dvHeader" class="container">
        <div class="row">
            <div class="col-sm-5">
                *<label id="lblBranch">Branch:</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                    <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
                </div>
                <div id="dvJob"></div>
            </div>
            <div class="col-sm-4" style="text-align:left">
                <label id="lblAdvNo">Advance No:</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtAdvNo" style="font-weight:bold;font-size:20px;text-align:center;background-color:navajowhite;color:brown" tabindex="1" />
                </div>
            </div>
            <div class="col-sm-3">
                <br />
                <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                    <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Document</b>
                </a>
            </div>
        </div>
    </div>
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userRights = '@ViewBag.UserRights';
    const branch = getQueryString("Branch");
    const code = getQueryString("Code");

    $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
        let dv = document.getElementById("dvLOVs");
        //Branch
        CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,2);
    });

    $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
    $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
    if (branch !== '' && code !== '') {
        $('#txtAdvNo').val(code);
    }

    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
        }
    }
    function PrintData() {
        window.open(path + 'Adv/FormClrAdv?branch=' + $('#txtBranchCode').val() + '&advno=' + $('#txtAdvNo').val());
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
</script>