-- 100611 / �Թ���ͧ�����¡��
update Job_SrvSingle set GLAccountCodeSales='100611' where IsCredit=1 and isExpense=0  and GLAccountCodeSales='' 
-- 500913 / �Թ���ͧ�١������׹
update Job_SrvSingle set GLAccountCodeCost='500913' where IsCredit=1 and isExpense=0  and GLAccountCodeCost=''
-- 101001 / �Թ�Ѵ�ӷ�����¡�׹��
update Job_SrvSingle set GLAccountCodeSales='101001' where GLAccountCodeCost='101001'  and GLAccountCodeSales=''
-- 5001 / �鹷ع�ҹ��ԡ�÷��������Թ�Ѵ��
update Job_SrvSingle set GLAccountCodeCost='5001',GLAccountCodeSales='5001'  where isExpense=1 and GLAccountCodeCost<>'101001'
update Job_SrvSingle set GLAccountCodeCost='5001' where IsCredit=0 and IsExpense=0  and GLAccountCodeCost=''
-- 100613 / ��Һ�ԡ�������¡��
update Job_SrvSingle set GLAccountCodeSales='100613' where IsCredit=0 and IsExpense=0 and GLAccountCodeSales=''
--�١���絤�ҷ�����
select distinct GLAccountCodeCost,GLAccountCodeSales from Job_SrvSingle