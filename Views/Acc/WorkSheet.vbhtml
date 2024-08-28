@Code
    ViewData("Title") = "WorkSheet"
    Dim branch = Request.Form("branch")
    Dim jobtype = Request.Form("jobtype")
    Dim shipby = Request.Form("shipby")
    Dim yy = Request.Form("fiscalyear")
    Dim mm = Request.Form("fiscalmonth")
    If Request.QueryString("JobType") IsNot Nothing Then
        jobtype = Request.QueryString("JobType").ToString()
    End If
    If Request.QueryString("ShipBy") IsNot Nothing Then
        shipby = Request.QueryString("ShipBy").ToString()
    End If
    Dim cliteria = "Year=" & yy & ",Month=" & mm & ",Job Type=" & jobtype & ",Ship By=" & shipby & ",Branch=" & branch
    Dim bLogin = False
    If ViewBag.User <> "" Then
        bLogin = True
    End If
End Code
<div class="container">
    <form method="post" action="">
        <div class="row">
            <div class="col-sm-2">
                <label for="cboBranch" id="lblBranch">Branch</label>
                <select id="cboBranch" name="branch" class="form-control dropdown"></select>
            </div>
            <div class="col-sm-2">
                <label for="cboJobType" id="lblJobType">Job Type</label>
                <select id="cboJobType" name="jobtype" class="form-control dropdown" onchange="CheckJobType()"></select>
            </div>
            <div class="col-sm-2">
                <label for="cboShipBy" id="lblShipBy">Ship By</label>
                <select id="cboShipBy" name="shipby" class="form-control dropdown"></select>
            </div>
            <div class="col-sm-2">
                <label for="cboYear" id="lblYear">Year</label>
                <select id="cboYear" name="fiscalyear" class="form-control dropdown"></select>
            </div>
            <div class="col-sm-1">
                <label for="cboMonth" id="lblMonth">Month</label>
                <select id="cboMonth" name="fiscalmonth" class="form-control dropdown"></select>
            </div>
        </div>
        <input type="submit" value="Refresh" class="btn btn-success" />
        <label id="lblCliteria">@cliteria</label>
    </form>
    <div class="panel">
        @If bLogin Then
            @<b>Summary Advance Payment</b>
            Dim sqlAdv = "
select adv.AccCode,adv.AdvDesc as AdvDescription
,sum(case when adv.IsCreditAdv=1 then adv.PaymentAmt else 0 end) as CustomerAdv
,sum(case when adv.IsCreditAdv=1 then adv.WhtAmt else 0 end) as CustomerWht
,sum(case when adv.IsCreditAdv=0 then adv.PaymentAmt else 0 end) as CompanyAdv
,sum(case when adv.IsCreditAdv=0 then adv.WhtAmt else 0 end) as CompanyWht
,sum(adv.PaymentAmt-adv.WhtAmt) as PaymentNet
from
(
select isnull(s.GLAccountCodeCost,'') as AccCode,concat(isnull(s.SICode,'N'),'/',ISNULL(Trim(s.NameThai),'A')) as AdvDesc,ad.ForJNo,ah.EmpCode,ah.PaymentDate,
ad.AdvNet+ad.Charge50Tavi as PaymentAmt
,ad.Charge50Tavi as WhtAmt,isnull(s.IsCredit,0) as IsCreditAdv
from Job_AdvDetail ad inner join Job_AdvHeader ah
on ad.AdvNo=ah.AdvNo and ad.BranchCode=ah.BranchCode
left join Mas_User u on ah.EmpCode=u.UserID
left join Job_SrvSingle s on ad.SICode=s.SICode
left join Job_Order j on ad.ForJNo=j.JNo and ad.BranchCode=j.BranchCode
where ah.PaymentRef<>'' and not ah.PaymentNo<>'' {0}
) adv
group by adv.AccCode,adv.AdvDesc
order by adv.AccCode,adv.AdvDesc
"
            Dim sqlWhere = String.Format(" AND ah.BranchCode='{0}'", branch)
            If jobtype <> "" Then
                sqlWhere &= String.Format(" AND ah.JobType='{0}'", jobtype)
            End If
            If shipby <> "" Then
                sqlWhere &= String.Format(" AND j.ShipBy='{0}'", shipby)
            End If
            If yy <> "" Then
                sqlWhere &= String.Format(" AND YEAR(ah.PaymentDate)='{0}'", yy)
            End If
            If mm <> "" Then
                sqlWhere &= String.Format(" AND MONTH(ah.PaymentDate)='{0}'", mm)
            End If
            sqlAdv = String.Format(sqlAdv, sqlWhere)
            Dim dt = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlAdv)
            Dim sumAdvPayment As Double = 0
            Dim sumCompAdvPayment As Double = 0
            Dim sumCustAdvPayment As Double = 0
            Dim sumCompAdvWht As Double = 0
            Dim sumCustAdvWht As Double = 0
            If dt.Rows.Count > 0 Then
                @<table border="1" class="table table-bordered">
                    <thead>
                        <tr>
                            @For Each dc As System.Data.DataColumn In dt.Columns
                                @<th>@dc.ColumnName</th>
                            Next
                        </tr>
                    </thead>
                    <tbody>
                        @For Each dr As System.Data.DataRow In dt.Rows
                            sumAdvPayment += Convert.ToDouble(dr("PaymentNet"))
                            sumCompAdvPayment += Convert.ToDouble(dr("CompanyAdv"))
                            sumCompAdvWht += Convert.ToDouble(dr("CompanyWht"))
                            sumCustAdvPayment += Convert.ToDouble(dr("CustomerAdv"))
                            sumCustAdvWht += Convert.ToDouble(dr("CustomerWht"))
                            @<tr>
                                @For each dc As System.Data.DataColumn In dt.Columns
                                    Select Case dc.ColumnName
                                        Case "PaymentNet", "CustomerAdv", "CompanyAdv", "CompanyWht", "CustomerWht"
                                            @<td style="text-align:right">@Convert.ToDouble(dr(dc.ColumnName)).ToString("#,##0.0000")</td>
                                        Case Else
                                            @<td>@dr(dc.ColumnName)</td>
                                    End Select
                                Next
                            </tr>
                        Next
                    </tbody>
                    <tfoot>
                        <tr style="background-color:yellow;font-weight:bold;">
                            <td colspan="2"><b>Total</b></td>
                            <td style="text-align:right">@sumCustAdvPayment.ToString("#,##0.0000")</td>
                            <td style="text-align:right">
                                @sumCustAdvWht.ToString("#,##0.0000")
                            </td>
                            <td style="text-align:right">
                                @sumCompAdvPayment.ToString("#,##0.0000")
                        </td>
                        <td style="text-align:right">@sumCompAdvWht.ToString("#,##0.0000")</td>
                        <td style="text-align:right">@sumAdvPayment.ToString("#,##0.0000")</td>
                    </tr>
                </tfoot>
            </table>
            End If
        @<b>Summary Account Payables</b>
            Dim sqlAP = "
select AccCode,VenderName,
sum(case when IsCreditAdv=1 then Total+AmtWHT else 0 end) as TotalCustAP,
sum(case when IsCreditAdv=1 then AmtWHT else 0 end) as TotalCustWHT,
sum(case when IsCreditAdv=0 then Total+AmtWHT else 0 end) as TotalCompAP,
sum(case when IsCreditAdv=0 then AmtWHT else 0 end) as TotalCompWHT,
sum(Total) as TotalPayment
from
(
select v.GLAccountCode as AccCode,v.Tname as VenderName,
s.NameThai as PayDescription,pd.ForJNo,ph.DocDate,ph.PaymentRef,ph.PaymentDate,
isnull(s.IsCredit,0) as IsCreditAdv,pd.Amt,pd.AmtVAT,pd.AmtWHT,pd.Total,ph.CurrencyCode,ph.ExchangeRate,pd.FTotal,
cd.BNet as ClrNet,cd.UsedAmount as ClrAmt,cd.ChargeVAT as ClrVAT,cd.Tax50Tavi as ClrWHT
from
job_paymentdetail pd inner join Job_paymentheader ph
on pd.DocNo=ph.DocNo and pd.BranchCode=ph.branchcode
inner join Mas_Vender v on ph.VenCode=v.VenCode
inner join Job_Order j on pd.ForJNo=j.JNo and pd.BranchCode=j.BranchCode
left join Job_SrvSingle s on pd.SIcode=s.SICode
left join Job_clearDetail cd on  pd.ClrRefNo=cd.ClrNo and pd.ClrItemNo=cd.ItemNo and pd.BranchCode=cd.BranchCode
where not ph.cancelprove<>'' and ph.AdvRef='' {0}
) as ap
group by AccCode,VenderName
"
            sqlWhere = String.Format(" AND ph.BranchCode='{0}'", branch)
            If jobtype <> "" Then
                sqlWhere &= String.Format(" AND j.JobType='{0}'", jobtype)
            End If
            If shipby <> "" Then
                sqlWhere &= String.Format(" AND j.ShipBy='{0}'", shipby)
            End If
            If yy <> "" Then
                sqlWhere &= String.Format(" AND YEAR(ph.DocDate)='{0}'", yy)
            End If
            If mm <> "" Then
                sqlWhere &= String.Format(" AND MONTH(ph.DocDate)='{0}'", mm)
            End If
            sqlAP = String.Format(sqlAP, sqlWhere)
            dt = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlAP)
            If dt.Rows.Count > 0 Then
                Dim totalAP As Double = 0
            @<table border="1" class="table table-bordered">
                <thead>
                    <tr>
                        @For Each dc As System.Data.DataColumn In dt.Columns
                            @<th>@dc.ColumnName</th>
                        Next
                    </tr>
                </thead>
                <tbody>
                    @For Each dr As System.Data.DataRow In dt.Rows
                        totalAP += Convert.ToDouble(dr("TotalPayment"))
                        @<tr>
                            @For each dc As System.Data.DataColumn In dt.Columns
                                Select Case dc.ColumnName
                                    Case "TotalCustAP", "TotalCustWHT", "TotalCompAP", "TotalCompWHT", "TotalPayment"
                                        @<td style="text-align:right">@Convert.ToDouble(dr(dc.ColumnName)).ToString("#,##0.0000")</td>
                                    Case Else
                                        @<td>@dr(dc.ColumnName)</td>
                                End Select
                            Next
                        </tr>
                    Next
                </tbody>                
        <tfoot>
            <tr style="background-color:yellow;font-weight:bold;">
                <td colspan="6">Total</td>
                <td style="text-align:right;">@totalAP.ToString("#,##0.0000")</td>
            </tr>
        </tfoot>
        </table>
            End If
        Else
    @<span>Please Login First</span>
End If
    </div>
    
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let user = '@ViewBag.User';
    let userGroup = '@ViewBag.UserGroup';
    let jt = '@jobtype';
    let sb = '@shipby';
    let custcode = getQueryString("custcode");

    loadCombo();

    function CheckJobType() {
        if (jt !== $('#cboJobType').val()) {
            jt = $('#cboJobType').val();
            loadShipByByType(path, jt, '#cboShipBy');
            return;
        }
        return;
    }

    function loadCombo() {
        let lists = 'JOB_TYPE=#cboJobType|' + jt;
        lists += ',SHIP_BY=#cboShipBy|' + sb;
        loadBranch(path);
        loadMonth('#cboMonth');
        loadYear(path);
        loadCombos(path, lists);
        setDefaultValue();
    }
    function setDefaultValue() {
        $('#cboBranch').val('@branch');
        $('#cboJobType').val('@jobtype');
        $('#cboShipBy').val('@shipby');
        $('#cboYear').val('@yy');
        $('#cboMonth').val(Number('@mm'));
    }
</script>