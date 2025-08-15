use job_ace
go

declare @dateto date='2023-12-31';

/**job order**/
delete from Job_Order where DocDate<=@dateto;

/**advance by job**/
delete a 
from Job_AdvDetail a left join Job_Order b on 
a.BranchCode=b.BranchCode and a.ForJNo=b.JNo 
where b.JNo is null and a.ForJNo<>'';

delete a
from Job_AdvHeader a left join Job_AdvDetail b 
on a.BranchCode=b.BranchCode and a.AdvNo=b.AdvNo where b.AdvNo is null;

/**clearing by job**/
delete a 
from Job_ClearDetail a left join Job_Order b on 
a.BranchCode=b.BranchCode and a.JobNo=b.JNo 
where b.JNo is null and a.JobNo<>'';

delete a
from Job_ClearHeader a left join Job_ClearDetail b 
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo 
where b.ClrNo is null;

/**container by job**/
delete a
from Job_LoadInfoDetail a left join Job_Order b
on a.BranchCode=b.BranchCode 
and a.JNo=b.JNO 
where a.JNo<>'' and b.JNo is null;

delete a 
from Job_LoadInfo a left join Job_LoadInfoDetail b
on a.BranchCode=b.BranchCode 
and a.JNo=b.JNo
where b.JNo is null

/**estimate cost/pre-invoice by job**/
delete a
from Job_ClearExp a left join Job_Order b
on a.BranchCode=b.BranchCode 
and a.JNo=b.JNo 
where a.JNo<>'' and b.JNo is null;

/**expense bill by job**/
delete a
from Job_PaymentDetail a left join Job_Order b 
on a.Branchcode=b.BranchCode 
and a.ForJNo=b.JNO 
where b.JNo is null and a.ForJNo<>''

delete a
from Job_PaymentHeader a left join Job_PaymentDetail b
on a.Branchcode=b.BranchCode
and a.DocNo=b.DocNo 
where b.DocNo is null

/**invoice by job**/
delete a 
from Job_InvoiceHeader a left join Job_ClearDetail b 
on a.BranchCode =b.BranchCode 
and a.DocNo=b.LinkBillNo
where b.LinkBillNo is null

delete a
from Job_InvoiceDetail a left join Job_InvoiceHeader b
on a.BranchCode=b.BranchCode 
and a.DocNo=b.DocNo 
where b.DocNo is null

/**billing by job**/
delete a
from Job_BillAcceptDetail a left join Job_InvoiceHeader b
on a.BranchCode=b.BranchCode
and a.InvNo=b.DocNo 
where b.DocNo is null

delete a
from Job_BillAcceptHeader a left join Job_BillAcceptDetail b 
on a.BranchCode=b.BranchCode
and a.BillAcceptNo=b.BillAcceptNo
where b.BillAcceptNo is null

/**receipt by job**/
delete a
from Job_ReceiptDetail a left join Job_InvoiceDetail b
on a.BranchCode=b.BranchCode 
and a.InvoiceNo=b.DocNo 
where b.DocNo is null

delete a
from Job_ReceiptHeader a left join Job_ReceiptDetail b
on a.BranchCode=b.BranchCode 
and a.ReceiptNo=b.ReceiptNo
where b.ReceiptNo is null

/**cndn by job**/
delete a
from Job_CNDNDetail a left join Job_InvoiceHeader b
on a.BranchCode=b.BranchCode
and a.BillingNo=b.DocNo 
where b.DocNo is null

delete a
from Job_CNDNHeader a left join Job_CNDNDetail b
on a.Branchcode=b.BRanchCode 
and a.DocNo=b.DocNo 
where b.DocNo is null

/**job order log**/
delete a
from Job_OrderLog a left join Job_Order b
on a.BranchCode=b.BranchCode
and a.JNo=b.JNo 
where b.JNo is null

/**wh-tax**/
delete a 
from Job_WHTaxDetail a
left join Job_Order b on a.BranchCode=b.BranchCode 
and a.JNo=b.JNo 
where a.JNo<>'' and b.JNo is null

delete a
from Job_WHTax a left join Job_WHTaxDetail b
on a.BranchCode=b.BranchCode
and a.DocNo=b.DocNo 
where b.DocNo is null

/**cash control by date**/
delete from Job_CashControl where VoucherDate<=@dateto;

delete a 
from Job_CashControlSub a 
left join Job_CashControl b
on a.BranchCode=b.BranchCode
and a.ControlNo=b.ControlNo 
where b.ControlNo is null

delete a 
from Job_CashControlDoc a 
left join Job_CashControl b
on a.BranchCode=b.BranchCode
and a.ControlNo=b.ControlNo 
where b.ControlNo is null

/*
select distinct Year(b.DocDate) 
from Job_AdvDetail a inner join Job_Order b 
on a.Branchcode=b.BranchCode and a.ForJNo=b.JNo 

select distinct Year(b.DocDate) 
from Job_ClearDetail a inner join Job_Order b 
on a.Branchcode=b.BranchCode and a.JobNo=b.JNo 

*/
