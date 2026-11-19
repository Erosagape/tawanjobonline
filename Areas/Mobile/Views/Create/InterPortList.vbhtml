@Code
    Dim list = Model
End Code
<div class="modal fade" role="dialog" id="mdlInterPort">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <input type="button" data-dismiss="modal" class="btn btn-danger" value="X" />
                <b>Port List</b>
            </div>
            <div class="modal-body">
                <div class="table-responsive">
                    <table class="table" id="tbInterPort">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Country</th>
                                <th>Port Code</th>
                                <th>Port Name</th>
                            </tr>
                        </thead>
                        <tbody>
                            @For Each r In list
                                @<tr>
    <td>
        <input type="button" data-dismiss="modal" onclick="SetValuePort('@r.CountryCode','@r.PortCode','@r.PortName')" class="btn btn-success" value="Select" />
    </td>
    <td>@r.CountryCode</td>
    <td>@r.PortCode</td>
    <td>@r.PortName</td>
</tr>
                            Next
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $('#tbInterPort').dataTable();
    function SetValuePort(ccode,pcode, pname) {
        $('@ViewBag.InterPortCountry').val(ccode);
        $('@ViewBag.InterPortCode').val(pcode);
        $('@ViewBag.InterPortName').val(pname);
    }
</script>