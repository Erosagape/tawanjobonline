@Code
    ViewData("Title") = "Employee"
End Code
<div id="dvForm">
    <div class="row">
        <div class="col-sm-4">
            <label id="lblEmpCode">Code </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtEmpCode" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblPreName">Title </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtPreName" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblName">Name </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtName" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblNickName">NickName </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtNickName" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblAccountNumber">Bank Account </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtAccountNumber" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblBranch">Branch </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtBranch" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblAddress">Address </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtAddress" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblTel">Tel No. </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtTel" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblRemark">Remark </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtRemark" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblEmail">Email </label>:
        </div>
        <div class="col-sm-8"><input type="text" id="txtEmail" class="form-control"></div>
    </div>
</div>
<div id="dvCommand">

    <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b>New</b>
    </a>
    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
        <i class="fa fa-lg fa-save"></i>&nbsp;<b>Save</b>
    </a>
    <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteData()">
        <i class="fa fa-lg fa-trash"></i>&nbsp;<b>Delete</b>
    </a>
    <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('employee')">
        <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Search</b>
    </a>

</div>
<div id="dvLOVs"></div>

<script type="text/javascript">
    let path = '@Url.Content("~")';
    let user ='@ViewBag.User';
    let userRights ='@ViewBag.UserRights';
    SetEvents();
    function CallBackQuerymployee(p, code, ev) {
        $.get(p + 'Master/getemployee?Code=' + code).done(function (r) {
            let dr = r.employee.data;
            if (dr.length > 0) {
                ev(dr[0]);
            }
        });
    }
    function SetEvents(){
        $('#txtEmpCode').keydown(function (event) {
            if (event.which == 13) {
                let code=$('#txtEmpCode').val();
                ClearData();
                $('#txtEmpCode').val(code);
                CallBackQuerymployee(path, code,ReadData);
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            var dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchEmployee', '#tbEmployee', 'Employee', response, 2);
        });
    }

    function DeleteData() {
        let code = $('#txtEmpCode').val();
        ShowConfirm("Do you need to Delete " + code + "?",function(ask){
            if (ask == false) return;
            $.get(path + 'Master/delemployee?code=' + code, function (r) {
                ShowMessage(r.employee.result);
                ClearData();
            });
        });
    }
	function ReadData(dr){
        $('#txtEmpCode').val(dr.EmpCode);
        $('#txtPreName').val(dr.PreName);
        $('#txtName').val(dr.Name);
        $('#txtNickName').val(dr.NickName);
        $('#txtAccountNumber').val(dr.AccountNumber);
        $('#txtBranch').val(dr.Branch);
        $('#txtAddress').val(dr.Address);
        $('#txtTel').val(dr.Tel);
        $('#txtRemark').val(dr.Remark);
        $('#txtEmail').val(dr.Email);
	}
	function SaveData(){
		let obj={
            EmpCode:$('#txtEmpCode').val(),
            PreName:$('#txtPreName').val(),
            Name:$('#txtName').val(),
            NickName:$('#txtNickName').val(),
            AccountNumber:$('#txtAccountNumber').val(),
            Branch:$('#txtBranch').val(),
            Address:$('#txtAddress').val(),
            Tel:$('#txtTel').val(),
            Remark:$('#txtRemark').val(),
            Email:$('#txtEmail').val(),
	    };
        if (obj.EmpCode != "") {
            ShowConfirm("Do you need to Save " + obj.EmpCode + "?",function(ask){
                if (ask == false) return;
                let jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetEmployee", "Master")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtEmpCode').val(response.result.data);
                            $('#txtEmpCode').focus();
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e);
                    }
                });
            });
        } else {
            ShowMessage('No data to save');
        }
	}
    function ClearData(){
        $('#txtEid').val('');
        $('#txtEmpCode').val('');
        $('#txtPreName').val('');
        $('#txtName').val('');
        $('#txtNickName').val('');
        $('#txtAccountNumber').val('');
        $('#txtBranch').val('');
        $('#txtAddress').val('');
        $('#txtTel').val('');
        $('#txtRemark').val('');
        $('#txtEmail').val('');
	}
    function SearchData(type) {
        switch (type) {
            case 'employee':
                SetGridEmployee(path, '#tbEmployee', '#frmSearchEmployee', ReadData);
                break;
        }
    }
 
     
    //$('.col-sm-4').each(function (index, value) {
    //    console.log(value);
    //    console.log('<label id="lbl' + value.innerText.replace(" :", "") + '">' + value.innerText+'</label>');
    //});
    //$('label').each(function (index, value) {
    //    console.log(value);
    //});

</script>
