@Code
    Layout = "~/Views/Shared/_ReportLandScape.vbhtml"
    ViewBag.Title = "Invoice Slip"
    Dim Branch = Request.QueryString("Branch")
    Dim Code = Request.QueryString("Code")
    Dim sql = "
select ih.BranchCode,ih.DocNo,ih.DocDate,b.NameEng as BillToName,concat(b.EAddress1,'<br>',b.EAddress2) as BillToAddress,
j.JNo,j.HAWB,c.NameEng as ShipperName,c.CustCode as ShipperCode,
j.InvProduct,ch.CTN_NO,ld.GrossWeight,
sum(CASE WHEN cd.SICode='ERN-002' THEN cd.UsedAmount ELSE 0 END) as 'DEPOSIT',
j.TotalContainer,
sum(CASE WHEN cd.SICode not in('SRV-093','SRV-092') AND id.AmtCharge>0 then cd.UsedAmount ELSE 0 END) as 'SERVICE VAT',
sum(case when cd.SICode='SRV-093' then cd.UsedAmount ELSE 0 END) as 'BRIDGE',
sum(case when cd.SICode='SRV-092' then cd.UsedAmount ELSE 0 END) as 'DEPOSIT CHG',
sum(case when id.AmtCharge>0 then cd.UsedAmount ELSE 0 END) as 'SERVICE FEE',
sum(case when id.AmtAdvance>0 AND cd.SICode not in('ADV-029','ADV-010','ADV-011','ADV-105',
'ADV-018','ADV-102','ADV-103','ADV-107') then cd.BNet ELSE 0 END) as 'INSPECTION FEE',
sum(case when id.AmtAdvance>0 and cd.SICode='ADV-029' then cd.Bnet else 0 end) as 'RENT',
sum(case when id.AmtAdvance>0 and cd.SICode='ADV-010' then cd.Bnet else 0 end) as 'DEM',
sum(case when id.AmtAdvance>0 and cd.SICode='ADV-011' then cd.Bnet else 0 end) as 'DET',
sum(case when id.AmtAdvance>0 and cd.SICode='ADV-105' then cd.Bnet else 0 end) as 'LSS',
sum(case when id.AmtAdvance>0 and cd.SICode IN('ADV-018','ADV-102','ADV-103') then cd.Bnet else 0 end) as 'REPAIR',
sum(case when id.AmtAdvance>0 and cd.SICode='ADV-107' then cd.Bnet else 0 end) as 'OTHER',
sum(case when id.AmtAdvance>0 then cd.Bnet else 0 end) as 'TOTAL'
from Job_ClearDetail cd
inner join Job_ClearHeader ch
on concat(cd.BranchCode,cd.ClrNo)=concat(ch.BranchCode,ch.ClrNo)
inner join Job_InvoiceDetail id
on concat(cd.BranchCode,cd.LinkBillNo,cd.LinkItem)=concat(id.BranchCode,id.DocNo,id.ItemNo)
inner join Job_InvoiceHeader ih
on concat(cd.BranchCode,cd.LinkBillNo)=concat(ih.BranchCode,ih.DocNo)
inner join Job_Order j on
concat(cd.BranchCode,cd.JobNo)=concat(j.BranchCode,j.JNo)
inner join Mas_Company c on concat(j.CustCode,j.CustBranch)=concat(c.CustCode,c.Branch)
inner join Mas_Company b on concat(ih.BillToCustCode,ih.BillToCustBranch)=concat(b.CustCode,b.Branch)
left join Job_LoadInfoDetail ld on j.BranchCode=ld.BranchCode
and j.JNo=ld.JNo and ch.CTN_NO=ld.CTN_NO
and j.BookingNo=ld.BookingNo
and ch.CTN_NO<>''
{0}
group by ih.BranchCode,ih.DocNo,ih.DocDate,b.NameEng,b.EAddress1,b.EAddress2,j.JNo,j.HAWB,c.NameEng,c.CustCode,
j.InvProduct,ch.CTN_NO,ld.GrossWeight,j.TotalContainer
"
    Dim sqlW = String.Format(" WHERE cd.BranchCode='{0}' and cd.LinkBillNo='{1}'", Branch, Code)
    sql = String.Format(sql, sqlW)
    Dim tb = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sql)
End Code
<style>
    table {
        font-size: 7px;
    }
</style>
<div style="display:flex;flex-direction:column;">
    <div style="width:100%;text-align:center">
        <b style="font-size:12px;">INVOICE</b>
    </div>
    @If tb.Rows.Count > 0 Then
        @
<table style = "width:100%;" >
                    <tr>
                        <td style="width:80%">
                            Bill To : @tb.Rows(0)("BillToName").ToString()
                                            </td>
                                            <td style="width:20%">
                                                Invoice No :@tb.Rows(0)("DocNo").ToString()
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style = "width:80%" >
                                                                    Address : @Html.Raw(tb.Rows(0)("BillToAddress").ToString())
                                                                                    </td>
                                                                                    <td style = "width:20%" >
                                                                                        Invoice Date :@Convert.ToDateTime(tb.Rows(0)("DocDate")).ToString("dd/MM/yyyy")
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                        @
<table style = "width: 100%; border-width: thin; border-collapse: collapse;" border="1">
                                                                                                    <thead>
                                                                                                        <tr>
                                                                                                            <th>#</th>
                                                                                                            <th>JOB NO</th>
                                                                                                            <th>B/L</th>
                                                                                                            <th>SHIPPER</th>
                                                                                                            <th>SHIPPING</th>
                                                                                                            <th>COMMODITY</th>
                                                                                                            <th>CON.NO</th>
                                                                                                            <th>G.W</th>
                                                                                                            <th>DEPOSIT</th>
                                                                                                            <th>VOL</th>
                                                                                                            <th>SERVICE</th>
                                                                                                            <th>BRIDGE</th>
                                                                                                            <th>DEPOSIT CHG</th>
                                                                                                            <th>SERVICE FEE</th>
                                                                                                            <th>INSPECTION FEE</th>
                                                                                                            <th>RENT</th>
                                                                                                            <th>DEM</th>
                                                                                                            <th>DET</th>
                                                                                                            <th>LSS</th>
                                                                                                            <th>REPAIR</th>
                                                                                                            <th>OTHER</th>
                                                                                                            <th>TOTAL</th>
                                                                                                        </tr>
                                                                                                    </thead>
                                                                                                    <tbody>
                                                                                        @For i As Integer = 1 To tb.Rows.Count
                                                                                            @
<tr>
                                                                                                                    <td>@i</td>
                                                                                                                                            <td>@tb.Rows(i - 1)("JNo").ToString()</td>
                                                                                                                                                                    <td>@tb.Rows(i - 1)("HAWB").ToString()</td>
                                                                                                                                                                                            <td>@tb.Rows(i - 1)("ShipperName").ToString()</td>
                                                                                                                                                                                                                    <td>@tb.Rows(i - 1)("ShipperCode").ToString()</td>
                                                                                                                                                                                                                                            <td>@tb.Rows(i - 1)("InvProduct").ToString()</td>
                                                                                                                                                                                                                                                                    <td>@tb.Rows(i - 1)("CTN_NO").ToString()</td>
                                                                                                                                                                                                                                                                                            <td>@tb.Rows(i - 1)("GrossWeight").ToString()</td>
                                                                                                                                                                                                                                                                                                                    <td>@Convert.ToDouble(tb.Rows(i - 1)("DEPOSIT")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                            <td>@tb.Rows(i - 1)("TotalContainer").ToString()</td>
                                                                                                                                                                                                                                                                                                                                                                    <td>@Convert.ToDouble(tb.Rows(i - 1)("SERVICE VAT")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                            <td>@Convert.ToDouble(tb.Rows(i - 1)("BRIDGE")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                    <td>@Convert.ToDouble(tb.Rows(i - 1)("DEPOSIT CHG")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                            <td>@Convert.ToDouble(tb.Rows(i - 1)("SERVICE FEE")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                    <td>@Convert.ToDouble(tb.Rows(i - 1)("INSPECTION FEE")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            <td>@Convert.ToDouble(tb.Rows(i - 1)("RENT")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    <td>@Convert.ToDouble(tb.Rows(i - 1)("DEM")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            <td>@Convert.ToDouble(tb.Rows(i - 1)("DET")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    <td>@Convert.ToDouble(tb.Rows(i - 1)("LSS")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            <td>@Convert.ToDouble(tb.Rows(i - 1)("REPAIR")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    <td>@Convert.ToDouble(tb.Rows(i - 1)("OTHER")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            <td>@Convert.ToDouble(tb.Rows(i - 1)("TOTAL")).ToString("#,###0.00")</td>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                </tr>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            Next
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            End If
</div>
<div style="display:flex;flex-direction:row;">
    <div style="flex:30%;">
        REMARK:
        <br>
        <br>
        <br>
        <br>
        ____________________________
        <br>
        AUTHORIZE SIGNATURE
        <br>
        <br>
        Transfer expense to Account name : JADESADA RATTANACHUTJEN" Reduce KBANK
        <br>
        BANGKOK BNAK Account No. 619-7-07542-4 Reduce KBANK
        <br>
        KASIKORN BANK Account NO. 354-2-44295-5
        <br>
    </div>
    <div style="flex:70%;">
    </div>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';

</script>
