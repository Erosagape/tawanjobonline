@Code
    Layout = "~/Views/Shared/_ReportLandscape.vbhtml"
    ViewBag.Title = "Invoice Slip"
    Dim branch = Request.QueryString("branch")
    Dim code = Request.QueryString("code")
    Dim sqlSource = "
from Job_ClearDetail cd
inner join Job_ClearHeader ch
on cd.ClrNo=ch.ClrNo and cd.BranchCode=ch.BranchCode
inner join Job_InvoiceDetail id 
on cd.LinkBillNo=id.DocNo and cd.LinkItem=id.ItemNo
and cd.BranchCode=id.BranchCode 
inner join Job_SrvSingle s on cd.SICode=s.SICode
inner join Job_InvoiceHeader ih
on cd.LinkBillNo=ih.DocNo and cd.BranchCode=ih.BranchCode
inner join Job_Order j on cd.JobNo=j.JNo and cd.BranchCode =j.BranchCode
inner join Job_LoadInfoDetail ld on
ch.CTN_NO=ld.CTN_NO and cd.JobNo=ld.JNo and cd.BranchCode=ld.BranchCode
inner join Mas_Company c on ih.BillToCustCode=c.CustCode and ih.BillToCustBranch=c.Branch
"
    Dim sql = "
select ih.DocNo,ih.DocDate,j.JNo,j.DutyDate,ld.PlaceName1 as PickupPlace,
ld.PlaceName2 as DeliveryPlace,ld.Placename3 as ReturnPlace,
ld.TruckType,1 as TripNo,
{2},
SUM(cd.UsedAmount+cd.ChargeVAT-cd.Tax50Tavi) as TotalNet,
j.BookingNo,ld.CTN_NO,ld.TruckNO,
c.NameThai as CustTName,CONCAT(c.TAddress1,' ',c.TAddress2) as CustTAddress
" & sqlSource & "
where ih.BranchCode='{0}' and ih.DocNo='{1}'
group by ih.DocNo,ih.DocDate,j.JNo,j.DutyDate,ld.PlaceName1,ld.PlaceName2,ld.PlaceName3,
ld.TruckType,j.BookingNo,ld.CTN_NO,ld.TruckNO,c.NameThai,c.TAddress1,c.TAddress2
"
    Dim startDetailField As Integer = 9
    Dim sqlHeader = "
select distinct s.SICode,s.NameThai as SDescription
" & sqlSource & "
where ih.BranchCode='{0}' and ih.DocNo='{1}'
"
    Dim dt As New Data.DataTable
    Dim dh As New Data.DataTable
    Dim ls As New List(Of Double)
    Dim bLogin = False
    If ViewBag.User <> "" Then
        bLogin = True
        dh = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sqlHeader, branch, code))
        Dim sqlDetail As String = ""
        If dh.Rows.Count > 0 Then
            For Each dr As Data.DataRow In dh.Rows
                If sqlDetail <> "" Then
                    sqlDetail &= ","
                End If
                sqlDetail &= String.Format("SUM(CASE WHEN cd.SICode='{0}' THEN cd.UsedAmount+cd.ChargeVAT-cd.Tax50Tavi else 0 end) as [{1}]", dr("SICode").ToString(), dr("SDescription").ToString())
            Next
        End If
        sql = String.Format(sql, branch, code, sqlDetail)
        dt = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sql)
    End If
End Code
@If bLogin Then
    If dt.Rows.Count > 0 Then
        Dim totalNet As Double = 0
        @<div style="width:98%;display:flex;flex-direction:row;">
            <div style="flex:3">
                <p>
                    เรื่อง ขอเบิกค่าขนส่ง<br />
                    เรียน @dt.Rows(0)("CustTName").ToString()
                    @dt.Rows(0)("CustTAddress").ToString()
                </p>
            </div>
            <div style="flex:1">
                <p>
                    เลขที่ @dt.Rows(0)("DocNo").ToString()<br />
                    วันที่ @Convert.ToDateTime(dt.Rows(0)("DocDate").ToString()).ToString("dd/MM/yyyy")
                </p>
            </div>
        </div>
        @<table border="1" style="border-width:thin;border-collapse:collapse;">
            <thead>
                <tr>
                    <th>วันที่</th>
                    <th>รับตู้</th>
                    <th>โหลดตู้</th>
                    <th>คืนตู้</th>
                    <th>ขนาดรถ</th>
                    <th>จำนวนเที่ยว</th>
                    @For each dr As Data.DataRow In dh.Rows
                        @<th>@dr("SDescription").ToString()</th>
                        ls.Add(0)
                    Next
                    <th>รวม</th>
                    <th>Booking</th>
                    <th>Container</th>
                    <th>ทะเบียนรถ</th>
                </tr>
            </thead>
    <tbody>
        @For Each dr As Data.DataRow In dt.Rows
            totalNet += Convert.ToDouble(dr("TotalNet"))
            @<tr>
    <td>@Convert.ToDateTime(dr("DutyDate").ToString()).ToString("dd/MM/yyyy")</td>
    <td>@dr("PickupPlace").ToString()</td>
    <td>@dr("DeliveryPlace").ToString()</td>
    <td>@dr("ReturnPlace").ToString()</td>
    <td>@dr("TruckType").ToString()</td>
    <td>@dr("TripNo").ToString()</td>
    @For i As Integer = 0 To dh.Rows.Count - 1
        @<td style="text-align:right;">@Convert.ToDouble(dr(startDetailField + i)).ToString("#,##0.00")</td>
        ls(i) += Convert.ToDouble(dr(startDetailField + i))
    Next
    <td style="text-align:right;">@Convert.ToDouble(dr("TotalNet")).ToString("#,##0.00")</td>
    <td>@dr("BookingNo").ToString()</td>
    <td>@dr("CTN_NO").ToString()</td>
    <td>@dr("TruckNO").ToString()</td>
</tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="6">
                TOTAL
            </td>
            @For Each a In ls
                        @<td style="text-align:right;">@a.ToString("#,##0.00")</td>
            Next
            <td style="text-align:right;">@totalNet.ToString("#,##0.00")</td>
            <td colspan="3"></td>
        </tr>
    </tfoot>
</table>
    End If
End If
<script type="text/javascript">
    const path = '@Url.Content("~")';
</script>
