@Code
    Dim venCode = Model("VenCode")
    Dim docGroup = Model("DocGroup")
    Dim beginDate = ViewBag.BeginDate
    Dim endDate = ViewBag.EndDate
    Dim qry = ViewBag.QueryAP
    Dim sql = "
SELECT * FROM (
" & qry & "
) t
WHERE DocDate>='{0}' AND DocDate <='{1}' AND VenCode='{2}' AND DocGroup='{3}'
"
    Dim tb = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sql, beginDate, endDate, venCode, docGroup))
    Dim divName = TempData("id")
End Code
<div class="modal fade" role="dialog" id="@divName">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-header">
                Detail of : @venCode
            </div>
            <div class="modal-body">
                @If tb.Rows.Count > 0 Then
                    @<div class="table-responsive">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th>
                                        RefNo
                                    </th>
                                    <th>
                                        DocDate
                                    </th>
                                    <th>
                                        Description
                                    </th>
                                    <th>
                                        Debit
                                    </th>
                                    <th>
                                        Credit
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                @For each dr In tb.Rows
                                    @<tr>
                                        <td>
                                            @dr("RefNo")
                                        </td>
                                        <td>@dr("DocDate")</td>
                                        <td>@dr("SDescription")</td>
                                        <td>@dr("Debit")</td>
                                        <td>@dr("Credit")</td>
                                    </tr>
                                Next
                            </tbody>
                        </table>

                    </div>

                End If
            </div>
            <div class="modal-footer">
                <input type="button" data-dismiss="modal" class="btn btn-danger" value="Close" />
            </div>
        </div>
    </div>
</div>

