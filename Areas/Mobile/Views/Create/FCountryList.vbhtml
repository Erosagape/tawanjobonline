@Code
    Dim list = Model
End Code
<div class="modal fade" role="dialog" id="mdlFCountries">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <input type="button" data-dismiss="modal" class="btn btn-danger" value="X" />
                <b>Country List</b>
            </div>
            <div class="modal-body">
                <div class="table-responsive">
                    <table class="table" id="tbFCountries">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Code</th>
                                <th>Name</th>
                            </tr>
                        </thead>
                        <tbody>
                            @For Each r In list
                                @<tr>
                                    <td>
                                        <input type="button" data-dismiss="modal" onclick="SetValueF('@r.CTYCode','@r.CTYName')" class="btn btn-success" value="Select" />
                                    </td>
                                    <td>@r.CTYCode</td>
                                    <td>@r.CTYName</td>
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
    $('#tbFCountries').dataTable();
    function SetValueF(code,cname) {
        $('@ViewBag.FCountryCode').val(code);
        $('@ViewBag.FCountryName').val(cname);
    }
</script>