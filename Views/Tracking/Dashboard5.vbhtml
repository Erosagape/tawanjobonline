
@Code
    ViewBag.Title = "Search Container"
End Code
<style>

</style>

<div class="row">
             <div class="col-sm-6" style="display:flex">
            	<div style="width:30%">
               		<label style="display:block;width:100%;">From Date</label>
            	</div>
            	<div style="width:70%">
                	<input type="date" id="txtDateFrom" class="form-control" value="@(New Date(Today.Year, Today.Month, 1).ToString("yyyy-MM-dd"))" >
                </div>
 	     </div>
             <div class="col-sm-6" style="display:flex">
            	<div style="width:30%">
                    <label style="display:block;width:100%;">To Date</label>
                </div>
                <div style="width:70%">
                    <input type="date" id="txtDateTo" class="form-control" value="@(New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"))" >
                </div>
	   </div>
</div>
<div class="row">
	<div class="col-sm-6" style="display:flex">
            <div style="width:30%">
                <label  style="display:block;width:100%;">Job Type</label>
            </div>
            <div style="width:70%">
                <select id="cboJobType" class="form-control dropdown" onchange="CheckJobType()" style="width:100%" tabindex="0">
		</select>
            </div>
	 </div>
	<div class="col-sm-6" style="display:flex">
            <div style="width:30%">
                <label  style="display:block;width:100%;">Ship By</label>
            </div>
            <div style="width:70%">
                <select id="cboShipBy" class="form-control dropdown"  style="width:100%" tabindex="1">
		</select>
	    </div>

	</div>

 </div>
<div class="row">
<div class="col-sm-6" style="display:flex">
            <div style="width:30%">
                <a href="../Master/Customers"><label  style="display:block;width:100%;">IM_EX PORTER</label></a>
            </div>
            <div style="display:flex;width:70%">
                <input type="text" class="form-control" style="width:80px" id="txtCustCode" tabindex="4" readonly>
                <input type="text" class="form-control" style="width:40px;display:none" id="txtCustBranch" tabindex="5" >
                <input type="button" class="btn btn-default" id="btnBrowseCust" value="..." onclick="SearchData('customer')">
                <input type="text" class="form-control" style="width:100%" id="txtCustName" disabled="">
            </div>

</div>
 </div>

<br><button type="button" class="btn btn-warning" onclick="handleClick();">Search</button>
<div id="dvLOVs"></div>

<script type="text/javascript">
    var path = '@Url.Content("~")';
    let userGroup = '@ViewBag.UserGroup';
    let user = '@ViewBag.User';

    let jt = getQueryString('JType');
    let sb = getQueryString('SBy');

    SetLOVs();
    CheckParam();

function handleClick() {
            let queryParam = `&BeginDate=${document.getElementById("txtDateFrom").value}`;
            let queryParam1 = `&EndDate=${document.getElementById("txtDateTo").value}`;
            let queryParam2 = `&CustCode=${document.getElementById("txtCustCode").value}`;
            let queryParam3 = `&JobType=${document.getElementById("cboJobType").value}`;
            let queryParam4 = `&ShipBy=${document.getElementById("cboShipBy").value}`;
            let params = queryParam + queryParam1 + queryParam2 + queryParam3 + queryParam4
	   

	     if (!($("#txtDateFrom").val() && $("#txtDateTo").val())) {
                alert("Please input both date")
                name.focus();
                return false;
            }

		
            window.open(path +"Tracking/Dashboard?form=5_report" + params);
            
        }
  
    function SetLOVs() {
        let lists = 'JOB_STATUS=#cboStatus';
        loadCombos(path, lists);
        //$('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        //$('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
           
        });
    }
    function SearchData(type) {
        switch (type) {
           case 'customer':
                SetGridCompanyByGroup(path, '#tbCust','CUSTOMERS,INTERNAL,PERSON', '#frmSearchCust', ReadCustomer);
                break;

        }
    }
   
     function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
       
    }

     function CheckJobType() {
        if (jt !== $('#cboJobType').val()) {
            jt = $('#cboJobType').val();
            loadShipByByType(path, jt, '#cboShipBy');
            return;
        }
    }

    function CheckParam() {
        let lists = 'JOB_TYPE=#cboJobType|'+jt+',SHIP_BY=#cboShipBy|'+ sb;
        loadCombos(path, lists);

        $('#cboJobType').val(jt);
        $('#cboShipBy').val(sb);

    }

    
</script>
