create table Job_ContainerMaintenance
(
CTN_NO varchar(50) NOT NULL, --เบอร์ตู้
SEQ int NOT NULL, --ลำดับ
CTN_PART varchar(20), --ส่วน ALL/INSIDE/OUTSIDE/TOP/LEFTSIDE/RIGHTSIDE/BOTTOM/AIR
SerialNo varchar(20), --เลขserial
EntryDate date, --วันที่คีย์ข้อมูล
EntryBy varchar(20), --ผู้บันทึก
MaintenanceReason nvarchar(MAX), --คำอธิบาย
MaintenanceType varchar(10), --ประเภท ADD/REPAIR/CLEAN/REMOVE
PicturePath varchar(50), --รูปประกอบ
VenderCode varchar(10), --ผู้ให้บริการ
DepotCode varchar(10), --ลานตู้
CountryCode varchar(10), --ประเทศ
BeginDate date, --วันเริ่ม
EndDate date, --วันเสร็จ
ApproveBy varchar(20), --ผู้อนุมัติ
ApproveDate date, --วันที่อนุมัติ
CancelBy varchar(20), --ผู้ยกเลิก
CancelDate date, --วันที่ยกเลิก
BudgetAmount float, ---ยอดเงิน 
CurrencyCode varchar(10),--สกุลเงิน
PaymentNo varchar(20), --ใบเปย์
constraint PK_JobContainerMaintenance PRIMARY KEY (CTN_NO,Seq) 
)
GO
