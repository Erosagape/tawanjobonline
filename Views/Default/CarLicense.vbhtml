@Code
    ViewData("Title") = "Car License"
End Code

<div id="dvForm">
    <div class="row">
        <div class="col-sm-4">
            <label id="lblCarNo">Car Code</label>
            :
        </div>
        <div class="col-sm-8"><input type="text" id="txtCarNo" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblCarLicense">Car License</label>
            :
        </div>
        <div class="col-sm-8"><input type="text" id="txtCarLicense" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblEmpCode">Driver</label>
            :
        </div>
        <div class="col-sm-8"><input type="text" id="txtEmpCode" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblDateStart">Begin Date</label>
            :
        </div>
        <div class="col-sm-8"><input type="date" id="txtDateStart" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblCarBrand">Brand</label>
            :
        </div>
        <div class="col-sm-8"><input type="text" id="txtCarBrand" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblModelyear">Model Year</label>
            :
        </div>
        <div class="col-sm-8"><input type="text" id="txtModelYear" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblCarModel">Model</label>
            :
        </div>
        <div class="col-sm-8"><input type="text" id="txtCarModel" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblCarType">Car Type</label>
            :
        </div>
        <div class="col-sm-8" style="display:flex">
            <input type="text" id="txtCarType" class="form-control">
            <input type="button" class="btn btn-default" id="btnBrowseType" value="..." onclick="SearchData('type')" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblCarPic">Picture</label>
            :
        </div>
        <div class="col-sm-8"><input type="text" id="txtCarPic" class="form-control"></div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblStatus">Status</label>
            :
        </div>
        <div class="col-sm-8">
            <select id="txtStatus" class="form-control dropdown"></select>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblWeight">Car Weight</label>
            :
        </div>
        <div class="col-sm-8"><input type="number" id="txtWeight" class="form-control" value="0.00"></div>
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
    <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('car')">
        <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Search</b>
    </a>

</div>
<div id="dvLOVs"></div>


<script type="text/javascript">
    let path = '@Url.Content("~")';
    let user ='@ViewBag.User';
    let userRights = '@ViewBag.UserRights';
    let search = {carNos: null }
    SetEvents();
    function CallBackQueryarLicense(p, code, ev) {
        $.get(p + 'Default/getCarLicense?Code=' + code).done(function (r) {
            let dr = r.carlicense.data;
            if (dr.length > 0) {
                ev(dr[0]);
            }
        });
    }
    function SetEvents() {
        let lists = 'CAR_STATUS=#txtStatus';
        loadCombos(path, lists);
        $('#txtCarNo').keydown(function (event) {
            if (event.which == 13) {
                let code=$('#txtCarNo').val();
                ClearData();
                $('#txtCarNo').val(code);
                CallBackQueryarLicense(path, code,ReadData);
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            var dv = document.getElementById("dvLOVs");
            //popup step1
            CreateLOV(dv, '#frmSearchCar', '#tbCar', 'Car List', response, 2);
            CreateLOV(dv, '#frmSearchType', '#tbType', 'Car Type', response, 2);
        });
    }
    function DeleteData() {
        let code = $('#txtCarNo').val();
        ShowConfirm("Do you need to Delete " + code + "?",function(ask){
            if (ask == false) return;
            $.get(path + 'Home/delCarlicense?code=' + code, function (r) {
                ShowMessage(r.carlicense.result);
                ClearData();
            });
        });
    }
	function ReadData(dr){
        $('#txtCarNo').val(dr.CarNo);
        $('#txtCarLicense').val(dr.CarLicense);
        $('#txtEmpCode').val(dr.EmpCode);
        $('#txtDateStart').val(CDateEN(dr.DateStart));
        $('#txtCarBrand').val(dr.CarBrand);
        $('#txtModelYear').val(dr.ModelYear);
        $('#txtCarModel').val(dr.CarModel);
        $('#txtCarType').val(dr.CarType);
        $('#txtCarPic').val(dr.CarPic);
        $('#txtStatus').val(dr.Status);
        $('#txtWeight').val(dr.Weight);
    }

   function SaveData() {
        let obj = {
            CarNo: $('#txtCarNo').val(),
            CarLicense: $('#txtCarLicense').val(),
            EmpCode: $('#txtEmpCode').val(),
            DateStart: CDateTH($('#txtDateStart').val()),
            CarBrand: $('#txtCarBrand').val(),
            ModelYear: $('#txtModelYear').val(),
            CarModel: $('#txtCarModel').val(),
            CarType: $('#txtCarType').val(),
            CarPic: $('#txtCarPic').val(),
            Status: $('#txtStatus').val(),
            Weight: CNum($('#txtWeight').val()),
        };
        if (obj.CarNo != "") {
            let jsonText = JSON.stringify({ data: obj });
                $.ajax({
                    url: "@Url.Action("SetCarLicense", "Default")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtCarNo').val(response.result.data);
                            $('#txtCarNo').focus();
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e);
                    }
                });
        } else {
            alert('No data to save');
        }
	}
	function ClearData(){
        //$('#txtCLid').val('');
        $('#txtCarNo').val('');
        $('#txtCarLicense').val('');
        $('#txtEmpCode').val('');
        $('#txtDateStart').val('');
        $('#txtCarBrand').val('');
        $('#txtModelYear').val('');
        $('#txtCarModel').val('');
        $('#txtCarType').val('');
        $('#txtCarPic').val('');
        $('#txtStatus').val('');
        $('#txtWeight').val('0.00');
    }

    function SearchData(type) {
        //popup step2 --> popup.js
        switch (type) {
            case 'car':
                SetGridCar(path, '#tbCar', '#frmSearchCar', ReadData);
                break;
            case 'type':
                SetGridServUnitFilter(path, '#tbType', '?Type=2', '#frmSearchType', ReadType);
                break;
        }
    }

    function ReadType(dr) {
        //popup step3
        $('#txtCarType').val(dr.UName);
    }

</script>


