@Code
    Dim bookCode = Model("BookCode")
    Dim acGroup = Model("acGroup")
    Dim beginDate = ViewBag.BeginDate
    Dim endDate = ViewBag.EndDate
    Dim qryCash = ViewBag.QueryCash
    Dim sql = "
SELECT * FROM (
    " & qryCash & "
) t
WHERE VoucherDate>='{0}' AND VoucherDate <='{1}' AND BookCode='{2}' AND acGroup='{3}'
"
    Dim tb = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sql, beginDate, endDate, bookCode, acGroup))
    Dim divName = TempData("id")
End Code
<div class="modal fade" role="dialog" id="@divName">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-header">
                <input type="button" data-dismiss="modal" class="btn btn-danger" value="Close" />
                Detail of : @bookCode
            </div>
            <div class="modal-body">
                @If tb.Rows.Count > 0 Then
                    @<div class="table-responsive">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>
                                ControlNo
                            </th>
                            <th>
                                VoucherDate
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
                                    <a href="@Url.Action("Voucher", "Acc")?Branch=@ViewBag.PROFILE_DEFAULT_BRANCH&Code=@dr("ControlNo")">@dr("ControlNo")</a>          
                                </td>
                                <td>@dr("VoucherDate")</td>
                                <td>@dr("TRemark")</td>
                                <td>@dr("Debit")</td>
                                <td>@dr("Credit")</td>
                            </tr>
                        Next
                    </tbody>
                </table>                        
                        
                </div>

                End If
            </div>
        </div>
    </div>
</div>
