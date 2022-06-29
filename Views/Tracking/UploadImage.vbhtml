@Code
    ViewData("Title") = "Update Status"
End Code
<div class="panel vertical-align-center center" style="padding:20px 20px 20px 20px">
    <div class="row">
        <div class="col-sm-6">
            <select id="txtDocType" class="form-control dropdown">
                <option value="STEP1">Prepare Documents</option>
                <option value="STEP2">Prepare Declaration</option>
                <option value="STEP3">Container Pick-up</option>
                <option value="STEP4">Loading at place</option>
                <option value="STEP5">Delivery at place</option>
                <option value="STEP6">Unpacking at place</option>
            </select>
            @Html.Raw(ViewBag.ImageShow)
        </div>
        <div class="col-sm-6">
            <label id="lblJobNo">Job Number </label>
            <input type="text" id="txtJNo" name="jobno" value="" />
            <input type="button" class="btn btn-primary" onclick="ShowImage()" value="Show" />
            <input id="objFile" type="file" accept="image/*" multiple />
            <input id="btnUpload" class="btn btn-success" type="button" value="Upload" onclick="UploadFile()" />

        </div>

    </div>

</div>

<script type="text/javascript">
    var path = '@Url.Content("~")';
    function ShowImage() {
        if ($('#txtJNo').val() !== '' && $('#txtDocType').val() !== '') {
            window.location.href = path + "Tracking/UploadImage?Path=" + $('#txtJNo').val() + "_" + $('#txtDocType').val();
        }
    }
    function UploadFile() {
        let count = $('#objFile')[0].files.length;
        if (count == 0) {
            ShowMessage('Data not found', true);
            return;
        }
        let saveTo = 'Resource/Import';
        for (let file of $('#objFile')[0].files) {
            let data = new FormData();
            data.append(file.name, file);
            var xhr = new XMLHttpRequest();
            xhr.open('POST', path + 'Tracking/UploadDocument?Branch=@ViewBag.PROFILE_DEFAULT_BRANCH&Code=' + $('#txtJNo').val() + '&Type=' + $('#txtDocType').val() + '&Path=' + saveTo);
            xhr.send(data);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    if (xhr.responseText.substr(0, 1) !== "[") {
                        let fname = xhr.responseText.split(' ')[1];
                        if (fname !== '') {
                            $('#objFile').val('');
                        }
                        ShowMessage(fname);
                        return;
                    }
                    ShowMessage(xhr.responseText, true);
                }
            }
        }
    }
</script>