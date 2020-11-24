@Code
    ViewBag.Title = "Import Excel"
End Code
<h2>Import Data From Excel</h2>
<input id="objFile" type="file" />
<input id="btnUpload" type="button" value="Upload" onclick="UploadFile()"/>
<select id="cboFileList">
    @For Each Str As String In ViewBag.FileList
        @<option value="@Str">@Str</option>
    Next
</select>
<input type="button" id="btnImport" value="Import" onclick="ImportData()" />
<script type="text/javascript">
    let path = '@Url.Content("~")';
    function ImportData() {
        if ($('#cboFileList').val() !== null) {
            $.get(path + 'Excel/ReadExcelFile?ID=' + $('#cboFileList').val()).done(function (msg) {
                ShowMessage(msg);
            });
        } else {
            ShowMessage("No File Selected");
        }
    }
    function UploadFile() {
        let count = $('#objFile')[0].files.length;
        if (count == 0) {
            ShowMessage('no file selected');
            return;
        }
        for (let file of $('#objFile')[0].files) {
            let data = new FormData();
            data.append(file.name, file);
            var xhr = new XMLHttpRequest();
            xhr.open('POST', path + 'Excel/UploadExcelFile');
            xhr.send(data);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    if (xhr.responseText.substr(0, 1) !== "[") {
                        let fname = xhr.responseText.split(' ')[1];
                        if (fname !== '') {
                            $('#objFile').val('');
                        }
                        ShowMessage(fname);
                        window.location.reload();
                    }
                    ShowMessage(xhr.responseText);
                }
            }
        }
    }
</script>

