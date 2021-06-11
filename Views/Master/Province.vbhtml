@Code
    ViewBag.Title = "Province"
End Code
<div id="dvHeader" class="row">
    <div class="col-sm-2">
        <label id="lblProvinceCode">Province Code :</label>
        <br /><div style="display:flex"><input type="text" id="txtProvinceCode" class="form-control"></div>
    </div>
    <div class="col-sm-10">
        <label id="lblProvinceName">Province Name :</label>
        <br /><div style="display:flex"><input type="text" id="txtProvinceName" class="form-control"></div>
    </div>
</div>
<div id="dvCommand">
    <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">New</b>
    </a>
    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
    </a>
    <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteData()">
        <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
    </a>
    <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('code')">
        <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
    </a>
</div>
<table id="tbDetail" class="table table-responsive">
    <thead>
        <tr>
            <th>District</th>
            <th>SubProvince</th>
            <th>PostCode</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<div id="dvDetail" class="row">
    <div class="col-sm-1">
        <labei id="lblid">ID :</labei>
        <br /><div style="display:flex"><input type="text" id="txtid" class="form-control" disabled></div>
    </div>
    <div class="col-sm-4">
        <label id="lblDistrict">District :</label>
        <br /><div style="display:flex"><input type="text" id="txtDistrict" class="form-control"></div>
    </div>
    <div class="col-sm-4">
        <label id="lblSubProvince">Sub District :</label>
        <br /><div style="display:flex"><input type="text" id="txtSubProvince" class="form-control"></div>
    </div>
    <div class="col-sm-3">
        <label id="lblPostCode">Post Code :</label>
        <br /><div style="display:flex"><input type="text" id="txtPostCode" class="form-control"></div>
    </div>
</div>
<div id="dvCommand">
    <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="ClearDetail()">
        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAddD">New Detail</b>
    </a>
    <a href="#" class="btn btn-success" id="btnSaveDetail" onclick="SaveDetail()">
        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSaveD">Save Detail</b>
    </a>
    <a href="#" class="btn btn-danger" id="btnDeleteDetail" onclick="DeleteDetail()">
        <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDeleteD">Delete Detail</b>
    </a>
</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    SetEvents();
    function SetEvents(){
        $('#txtProvinceCode').keydown(function (event) {
            if (event.which == 13) {
                let code=$('#txtProvinceCode').val();
                ClearData();
                $('#txtProvinceCode').val(code);
                CallBackQueryProvince(path, code,ReadData);
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            var dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchProvince', '#tbProvince', 'Province', response, 2);
        });
    }
    function RefreshGrid() {
        $.get(path + 'Master/GetProvinceSub?Code=' + $('#txtProvinceCode').val(), function (r) {
            if (r.province.detail.length == 0) {
                $('#tbDetail').DataTable().clear().draw();
            }
            let tb=$('#tbDetail').dataTable({
                data: r.province.detail,
                columns: [
                    { data: "District", title: "District" },
                    { data: "SubProvince", title: "Sub District" },
                    { data: "PostCode", title: "ZIP Code" }
                ],
                destroy: true,
                responsive: true
                , pageLength: 100
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
            $('#tbDetail tbody').on('click', 'tr', function () {
                SetSelect('#tbDetail', this);
                row = $('#tbDetail').DataTable().row(this).data(); //read current row selected
                ClearDetail();
                ReadDetail(row);
            });
        });
    }
    //CRUD Functions used in HTML Java Scripts
    function DeleteData() {
        let code = $('#txtProvinceCode').val();
        let ask = confirm("Do you need to Delete " + code + "?");
        if (ask == false) return;
            $.get(path + 'master/delprovince?code=' + code, function (r) {
                ShowMessage(r.province.result);
                ClearData();
            });
    }

    function ReadData(dr) {
        $('#txtProvinceCode').val(dr.ProvinceCode);
        $('#txtProvinceName').val(dr.ProvinceName);
        RefreshGrid();
    }
    function SaveData() {
        let obj = {
            ProvinceCode:$('#txtProvinceCode').val(),
            ProvinceName:$('#txtProvinceName').val(),
	    };
        if (obj.ProvinceCode != "") {
            let ask = confirm("Do you need to Save " + obj.ProvinceCode + "?");
            if (ask == false) return;
            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetProvince", "Master")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != null) {
                        $('#txtProvinceCode').val(response.result.data);
                        $('#txtProvinceCode').focus();
                        RefreshGrid();
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }

    function ClearData() {
        $('#txtProvinceCode').val('');
        $('#txtProvinceName').val('');
    }
    function DeleteDetail() {
        let code = $('#txtid').val();
        let ask = confirm("Do you need to Delete " + code + "?");
        if (ask == false) return;
        $.get(path + 'master/delprovincesub?id=' + code, function (r) {
            ShowMessage(r.province.result);
            ClearDetail();
            RefreshGrid();
        });
    }
    function ReadDetail(dr) {		
        $('#txtSubProvince').val(dr.SubProvince);
        $('#txtDistrict').val(dr.District);
        $('#txtPostCode').val(dr.PostCode);
        $('#txtid').val(dr.id);
    }

    function SaveDetail() {
		let obj={			
            ProvinceCode: $('#txtProvinceCode').val(),
            SubProvince: $('#txtSubProvince').val(),
            District: $('#txtDistrict').val(),
            PostCode: $('#txtPostCode').val(),
            id: $('#txtid').val()
        };
        if (obj.SubProvince != "") {
            let ask = confirm("Do you need to Save " + obj.SubProvince + "?");
            if (ask == false) return;
            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetProvinceSub", "Master")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != null) {
                        $('#txtid').val(response.result.data);
                        $('#txtid').focus();
                        RefreshGrid();
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }

	function ClearDetail(){		        
        $('#txtSubProvince').val('');
        $('#txtDistrict').val('');
        $('#txtPostCode').val('');
        $('#txtid').val('0');
    }

    function SearchData(type) {
        switch (type) {
            case 'code':
                SetGridProvince(path, '#tbProvince', '#frmSearchProvince', ReadData);
                break;
        }
    }
</script>