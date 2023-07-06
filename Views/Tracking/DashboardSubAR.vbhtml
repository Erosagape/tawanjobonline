@Code
    Dim custCode = Model("BillToCustCode")
    Dim docGroup = Model("DocGroup")
    Dim beginDate = ViewBag.BeginDate
    Dim endDate = ViewBag.EndDate
    Dim qry = ViewBag.QueryAR
    Dim sql = "
SELECT * FROM (
" & qry & "
) t
WHERE DocDate>='{0}' AND DocDate <='{1}' AND BillToCustCode='{2}' AND DocGroup='{3}'
"
    Dim tb = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sql, beginDate, endDate, custCode, docGroup))
    Dim divName = TempData("id")
End Code
<div class="modal fade" role="dialog" id="@divName">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-header">
                Detail of : @custCode
            </div>
            <div class="modal-body">
                @If tb.Rows.Count > 0 Then
                    @<div class="table-responsive">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th>
                                        DocNo
                                    </th>
                                    <th>
                                        DocDate
                                    </th>
                                    <th>
                                        RefNo
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
                                             @If dr("Debit") > 0 Then
                                                 @<a href="@Url.Action("FormInv", "Acc")?Branch=@ViewBag.PROFILE_DEFAULT_BRANCH&InvNo=@dr("DocNo")">@dr("DocNo")</a>

                                             Else
                                                 @<a href="@Url.Action("FormTaxInv", "Acc")?Branch=@ViewBag.PROFILE_DEFAULT_BRANCH&ReceiptNo=@dr("DocNo")">@dr("DocNo")</a>
                                             End If
                                         </td>
                                        <td>@dr("DocDate")</td>
                                        <td>@dr("Remark")</td>
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
