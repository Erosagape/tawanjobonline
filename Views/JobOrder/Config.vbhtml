@Code
    ViewData("Title") = "Config Job Type"
End Code
<div class="row">
    <div class="col-sm-12">
        Job Type : <br /><select id="cboJobType" class="form-control dropdown"></select>
    </div>
</div>
<div style="display:flex">
    <textarea id="txtShipBy" class="form-control" disabled></textarea>
</div>
<div id="dvShipBy">

</div>
<input type="button" class="btn btn-success" value="Save Config" id="btnSave" />
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var isload = false;
    loadConfig('#cboJobType', 'JOB_TYPE', path, '');
    $.get(path + 'Config/GetConfig?Code=SHIP_BY')
        .done(function (r) {
            if (r.config.data !== undefined) {
                for (let d of r.config.data) {
                    let html = '<label id="lblShipBy'+ d.ConfigKey +'" class="checkbox-inline"><input type="checkbox" name="optShipBy" value="' + d.ConfigKey + '">'+ d.ConfigValue +'</label>';
                    $('#dvShipBy').append(html);
                    isload = true;
                }
            }
        });
    $('#cboJobType').on('change', function () {
        let val = $(this).val();

        $('input[name=optShipBy]').each(function () {
            $(this).prop('checked',false);
        });
        $('#txtShipBy').val('');

        if (val !== '' && isload == true) {
            $.get(path + 'Config/GetConfig?Code=SHIP_BY_FILTER&Key=' + val)
                .done(function (r) {
                    if (r.config.data.length>0) {
                        let chk = r.config.data[0].ConfigValue;
                        let str = '';
                        $('input[name=optShipBy]').each(function () {
                            let data = $(this).val();
                            if (chk.indexOf(data) >= 0) {
                                str += (str !== '' ? ',' : '') + $('#lblShipBy' + data).text();
                                $(this).prop('checked',true);
                            }
                        });
                        $('#txtShipBy').val(str);
                    }
                });
        }
    });
    $('#btnSave').on('click', function () {
        if ($('#cboJobType').val() !== '' && isload == true) {
            let val = '';
            $('input[name=optShipBy]:checked').each(function () {
                val += (val == '' ? '' : ',') + $(this).val();
            });
            var obj = {
                ConfigCode: 'SHIP_BY_FILTER',
                ConfigKey: $('#cboJobType').val().trim(),
                ConfigValue: val
            };
            ShowConfirm('Do you need to save this data?', function (ask) {
                if (ask == false) return;
                $.ajax({
                    url: "@Url.Action("SetConfig", "Config")",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify({ data: obj }),
                    success: function (response) {
                        response ? ShowMessage("Save Completed") : ShowMessage("No data to Save",true);
                    }
                });
            });
        } else {
            ShowMessage('Please select job type',true);
        }
    });
</script>