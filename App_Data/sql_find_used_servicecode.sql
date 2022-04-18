use job_bft
go
select s.* from (
select distinct a.SICode,b.GroupCode,b.NameThai,b.NameEng FROM Job_QuotationItem a
inner join Job_SrvSingle b on a.SICode=b.SICode
union
select distinct a.SICode,b.GroupCode,b.NameThai,b.NameEng FROM Job_ClearExp a
inner join Job_SrvSingle b on a.SICode=b.SICode
union
select distinct a.SICode,b.GroupCode,b.NameThai,b.NameEng FROM Job_AdvDetail a
inner join Job_SrvSingle b on a.SICode=b.SICode
union
select distinct a.SICode,b.GroupCode,b.NameThai,b.NameEng FROM Job_ClearDetail a
inner join Job_SrvSingle b on a.SICode=b.SICode
union
select distinct a.SICode,b.GroupCode,b.NameThai,b.NameEng FROM Job_InvoiceDetail a
inner join Job_SrvSingle b on a.SICode=b.SICode
union
select distinct a.SICode,b.GroupCode,b.NameThai,b.NameEng FROM Job_ReceiptDetail a
inner join Job_SrvSingle b on a.SICode=b.SICode
union
select distinct a.SICode,b.GroupCode,b.NameThai,b.NameEng FROM Job_PaymentDetail a
inner join Job_SrvSingle b on a.SICode=b.SICode
) s
order by s.GroupCode,s.NameEng
