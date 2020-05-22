@Code
    ViewBag.Title = "Vessel/Vehicles"
End Code
<div class="panel-body">
    <div class="container">
        <div id="dvForm">
            <label id="lblRegsNumber">Register Code:</label>
            <br />
            <input type="text" id="txtRegsNumber" class="form-control" tabIndex="1">
            <label id="lblTName">Name:</label>
            <br />
            <input type="text" id="txtTName" class="form-control" tabIndex="2">
            <label id="lblVesselType">Type:</label>
            <br />
            <input type="text" id="txtVesselType" class="form-control" tabIndex="3">
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
            <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('vessel')">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
            </a>
        </div>
    </div>
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    //$(document).ready(function () {
        SetEvents();
        SetEnterToTab();
        ClearData();
    //});
    function SetEvents() {
        $('#txtRegsNumber').keydown(function (event) {
            if (event.which == 13) {
                var code = $('#txtRegsNumber').val();
                ClearData();
                $('#txtRegsNumber').val(code);
                CallBackQueryVessel(path, code, ReadData);
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            var dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchCode', '#tbCode', 'Vessel', response, 2);
        });
    }
    function SetEnterToTab() {
        //Set enter to tab
        $("input[tabindex], select[tabindex], textarea[tabindex]").each(function () {
            $(this).on("keypress", function (e) {
                if (e.keyCode === 13) {
                    var idx = (this.tabIndex + 1);
                    var nextElement = $('[tabindex="' + idx + '"]');
                    while (nextElement.length) {
                        if (nextElement.prop('disabled') == false) {
                            $('[tabindex="' + idx + '"]').focus();
                            e.preventDefault();
                            return;
                        } else {
                            idx = idx + 1;
                            nextElement = $('[tabindex="' + idx + '"]');
                        }
                    }
                    $('[tabindex="1"]').focus();
                }
            });
        });
    }
    function ReadData(dr) {
        $('#txtRegsNumber').val(dr.RegsNumber);
        $('#txtTName').val(dr.TName);
        $('#txtVesselType').val(dr.VesselType);
    }
    function DeleteData() {
        var code = $('#txtTName').val();
        ShowConfirm('Do you need to delete this data?', function (ask) {
            if (ask == false) return;
            $.get(path + 'master/delvessel?code=' + code, function (r) {
                ShowMessage(r.vessel.result);
                ClearData();
            });
        });
    }
    function SaveData() {
        var obj = {
            RegsNumber: $('#txtRegsNumber').val(),
            TName: $('#txtTName').val(),
            VesselType: $('#txtVesselType').val()
        };
        if (obj.RegsNumber != "") {
            if (obj.TName == '') {
                ShowMessage('Please input name',true);
                $('#txtTName').focus();
                return;
            }
            ShowConfirm('Do you need to save this data?', function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetVessel", "Master")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtRegsNumber').val(response.result.data);
                            $('#txtRegsNumber').focus();
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e,true);
                    }
                });
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }
    function ClearData() {
        $('#txtRegsNumber').val('');
        $('#txtTName').val('');
        $('#txtVesselType').val('0');

        $('#txtRegsNumber').focus();
    }
    function SearchData(type) {
        switch (type) {
            case 'vessel':
                SetGridVessel(path, '#tbCode', '#frmSearchCode', '', ReadData);
                break;
        }
    }
</script>
