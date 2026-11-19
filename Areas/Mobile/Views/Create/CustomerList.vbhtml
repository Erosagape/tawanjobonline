@Code
    Dim list = Model
End Code
<div class="modal fade" role="dialog" id="mdlCustomers">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <input type="button" data-dismiss="modal" class="btn btn-danger" value="X" /> 
                <b>Customers List</b>
            </div>
            <div class="modal-body">
                <div class="table-responsive">
                    <table class="table" id="tbCust">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Code</th>
                                <th>Name (TH)</th>
                                <th>Name (EN)</th>
                            </tr>
                        </thead>
                        <tbody>
                            @For Each r As System.Data.DataRow In list.Rows
                                @<tr>
    <td>
        <input type="button" data-dismiss="modal" onclick="SetValueCust('@r("CustCode")','@r("Branch")','@r("NameThai")','@r("NameEng")')" class="btn btn-success" value="Select" />
    </td>
    <td>@r("CustCode")</td>
    <td>@r("NameThai")</td>
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
    $('#tbCust').dataTable();
    function SetValueCust(code, br,tname,ename) {
        $('@ViewBag.CustCode').val(code + '|' + br);
        $('@ViewBag.CustTName').val(tname);
        $('@ViewBag.CustEName').val(ename);
    }
</script>