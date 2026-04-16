use job_tbil
go
--เอาเลขจ๊อบต่อท้ายเพื่อทำให้ unique
update j
set j.BookingNo=Concat(j.BookingNo,'-',j.JNo)
from Job_LoadInfo j
where exists(
	select count(*),BookingNo,len(BookinGNo) from Job_Order where JobStatus<>99 
	and BookingNo<>''
	and BookingNo=j.BookingNo
	group by BookingNo
	having count(*)>1
)
--เอาเลขจ๊อบต่อท้ายเพื่อทำให้ unique
update j
set j.BookingNo=Concat(j.BookingNo,'-',j.JNo)
from Job_LoadInfoDetail j
where exists(
	select count(*),BookingNo,len(BookinGNo) from Job_Order where JobStatus<>99 
	and BookingNo<>''
	and BookingNo=j.BookingNo
	group by BookingNo
	having count(*)>1
)
--เอาเลขจ๊อบต่อท้ายเพื่อทำให้ unique

update j 
set j.BookingNo=Concat(j.BookingNo,'-',j.JNo)
from Job_Order j
where exists(
select count(*),BookingNo,len(BookinGNo) from Job_Order where JobStatus<>99 
and BookingNo<>''
and BookingNo=j.BookingNo
group by BookingNo
having count(*)>1
)

---check duplicate booking
select count(*),BookingNo,len(BookinGNo) from Job_Order where JobStatus<>99 
and BookingNo<>''
group by BookingNo
having count(*)>1
