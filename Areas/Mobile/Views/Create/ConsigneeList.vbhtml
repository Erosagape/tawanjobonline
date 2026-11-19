@Code
    Dim list = Model
End Code
<div class="modal fade" role="dialog" id="mdlConsignees">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <input type="button" data-dismiss="modal" class="btn btn-danger" value="X" />
                <b>Consignee List</b>
            </div>
            <div class="modal-body">
                <div class="table-responsive">
                    <table class="table" id="tbCons">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Code</th>
                                <th>Name (EN)</th>
                            </tr>
                        </thead>
                        <tbody>
                            @For Each r As System.Data.DataRow In list.Rows
                                @<tr>
                                    <td>
                                        <input type="button" data-dismiss="modal" onclick="SetValueCons('@r("CustCode")','@r("Branch")','@r("NameThai")','@r("NameEng")')" class="btn btn-success" value="Select" />
                                    </td>
                                    <td>@r("CustCode")</td>
                                    <td>@r("NameEng")</td>
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
    $('#tbCons').dataTable();
    function SetValueCons(code, br,tname,ename) {
        $('@ViewBag.ConsignCode').val(code);
        $('@ViewBag.ConsignTName').val(tname);
        $('@ViewBag.ConsignEName').val(ename);
    }
</script>
