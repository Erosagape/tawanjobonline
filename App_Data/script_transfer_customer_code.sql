declare @custfrom varchar='ABC';
declare @custbranchfrom varchar='0000';
declare @custto varchar='DEF';
declare @custbranchto varchar='01';

update job_order set CustCode=@custto,CustBranch=@custbranchto where CustCode=@custfrom and CustBranch=@custbranchfrom
update job_order set consigneecode=@custto where consigneecode=@custfrom 
update job_advheader set CustCode=@custto,CustBranch=@custbranchto where CustCode=@custfrom and CustBranch=@custbranchfrom
update job_billacceptheader set CustCode=@custto,CustBranch=@custbranchto where CustCode=@custfrom and CustBranch=@custbranchfrom
update job_invoiceheader set CustCode=@custto,CustBranch=@custbranchto where CustCode=@custfrom and CustBranch=@custbranchfrom
update job_invoiceheader set BillToCustCode=@custto,BillToCustBranch=@custbranchto where BillToCustCode=@custfrom and BillToCustBranch=@custbranchfrom
update job_cashcontrol set CustCode=@custto,CustBranch=@custbranchto where CustCode=@custfrom and CustBranch=@custbranchfrom
update job_cashcontroldoc set CmpCode=@custto,CmpBranch=@custbranchto where CmpCode=@custfrom and CmpBranch=@custbranchfrom
update job_cndnheader set CustCode=@custto,CustBranch=@custbranchto where CustCode=@custfrom and CustBranch=@custbranchfrom
update job_quotationheader set CustCode=@custto,CustBranch=@custbranchto where CustCode=@custfrom and CustBranch=@custbranchfrom
update job_quotationheader set BillToCustCode=@custto,BillToCustBranch=@custbranchto where BillToCustCode=@custfrom and BillToCustBranch=@custbranchfrom
update job_receiptheader set CustCode=@custto,CustBranch=@custbranchto where CustCode=@custfrom and CustBranch=@custbranchfrom
update job_receiptheader set BillToCustCode=@custto,BillToCustBranch=@custbranchto where BillToCustCode=@custfrom and BillToCustBranch=@custbranchfrom
update job_transportprice set CustCode=@custto where CustCode=@custfrom 
update job_loadinfo set NotifyCode=@custto where NotifyCode=@custfrom 
update Mas_Company set BillToCustCode=@custto,BillToBranch=@custbranchto where BillToCustCode=@custfrom and BillToBranch=@custbranchfrom
update Mas_Company set CustCode=@custto,Branch=@custbranchto where CustCode=@custfrom and Branch=@custbranchfrom
