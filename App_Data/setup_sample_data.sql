-- 100611 / เงินทดรองรอเรียกเก็บ
update Job_SrvSingle set GLAccountCodeSales='100611' where IsCredit=1 and isExpense=0  and GLAccountCodeSales='' 
-- 500913 / เงินทดรองลูกค้าไม่คืน
update Job_SrvSingle set GLAccountCodeCost='500913' where IsCredit=1 and isExpense=0  and GLAccountCodeCost=''
-- 101001 / เงินมัดจำที่เรียกคืนได้
update Job_SrvSingle set GLAccountCodeSales='101001' where GLAccountCodeCost='101001'  and GLAccountCodeSales=''
-- 5001 / ต้นทุนงานบริการที่ไม่ใช่เงินมัดจำ
update Job_SrvSingle set GLAccountCodeCost='5001',GLAccountCodeSales='5001'  where isExpense=1 and GLAccountCodeCost<>'101001'
update Job_SrvSingle set GLAccountCodeCost='5001' where IsCredit=0 and IsExpense=0  and GLAccountCodeCost=''
-- 100613 / ค่าบริการรอเรียกเก็บ
update Job_SrvSingle set GLAccountCodeSales='100613' where IsCredit=0 and IsExpense=0 and GLAccountCodeSales=''
--ดูการเซ็ตค่าทั้งหมด
select distinct GLAccountCodeCost,GLAccountCodeSales from Job_SrvSingle