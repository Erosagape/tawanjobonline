Imports System.Data.SqlClient
Imports Newtonsoft.Json
Module Main
    Friend Const jsonContent As String = "application/json;charset=UTF-8"
    Friend Const xmlContent As String = "application/xml;charset=UTF-8"
    Friend Const textContent As String = "text/html"
    Friend Const jobPrefix As String = "[J][S]"
    Friend Const quoPrefix As String = "Q-"
    Friend Const advPrefix As String = "ADV-"
    Friend Const clrPrefix As String = "CLR-"
    Friend Const invPrefix As String = "INV-"
    Friend Const billPrefix As String = "BL-"
    Friend Const payPrefix As String = "PAY-"
    Friend Const whtPrefix As String = "WT-"
    Friend Const costPrefix As String = "CST-"
    Friend Const expPrefix As String = "ACC-"
    Friend Const servPrefix As String = "SRV-"
    Friend Const appName As String = "JOBSHIPPING"
    Friend jobmaster As String = "jobmaster"
    Friend Function GetDBString(pValue As String, dc As DataColumn)
        If pValue Is Nothing Then
            Return ""
        End If
        If dc.MaxLength >= pValue.Length Or dc.MaxLength < 0 Then
            Return pValue
        Else
            Return pValue.Substring(0, dc.MaxLength)
        End If
    End Function
    Friend Function GetDBDate(pDate As Date, Optional pTodayAsDefault As Boolean = False) As Object
        If pDate.Year > 2000 Then
            If pDate.Year > 2500 Then
                Return pDate.AddYears(-543)
            Else
                If pDate.Year > 2200 Then
                    Return Date.MinValue
                End If
            End If
            Return pDate
        Else
            If pTodayAsDefault Then
                Return DateTime.Today
            Else
                If pDate.Year > 2500 Then
                    Return pDate.AddYears(-543)
                Else
                    Return System.DBNull.Value
                End If
            End If
        End If
    End Function
    Friend Function GetDBTime(pDate As Date) As Object
        If Not (pDate.Minute = 0 And pDate.Second = 0 And pDate.Hour = 0) Then
            Return pDate
        Else
            Return DateTime.Today.Date
        End If
    End Function
    Friend Function GetValueSQL(conn As String, sql As String) As CResult
        Dim ret As New CResult With {
    .Source = sql,
    .Param = conn,
    .Result = ""
}
        Try
            Using cn As New SqlConnection(conn)
                cn.Open()
                Using rd As SqlDataReader = New SqlCommand(sql, cn).ExecuteReader
                    If rd.Read Then
                        If rd.HasRows Then
                            Dim val As String = rd.GetValue(0).ToString()
                            ret.Result = val
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetValueSQL", ex.Message, ex.StackTrace & "=>" & sql & " (" & conn & ")", True)
            ret.IsError = True
            ret.Result = ex.Message
        End Try
        Return ret
    End Function
    Friend Function GetValueConfig(sCode As String, sKey As String, Optional sDef As String = "") As String
        Try
            Dim tSqlw As String = " WHERE ConfigCode<>'' "
            If sCode <> "" Then tSqlw &= String.Format("AND ConfigCode='{0}'", sCode)
            tSqlw &= String.Format("AND ISNULL(ConfigKey,'')='{0}'", sKey)
            Dim oData = New CConfig(GetSession("ConnJob")).GetData(tSqlw)
            If oData.Count > 0 Then
                Return oData(0).ConfigValue
            Else
                Return sDef
            End If
        Catch ex As Exception
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetValueConfig", ex.Message, ex.StackTrace, True)
            Return sDef
        End Try
    End Function
    Friend Function GetDataConfig(sCode As String) As List(Of CConfig)
        Dim tSqlw As String = " WHERE ConfigCode<>'' "
        If sCode <> "" Then tSqlw &= String.Format("AND ConfigCode='{0}'", sCode)
        Dim oData = New CConfig(GetSession("ConnJob")).GetData(tSqlw)
        Return oData
    End Function
    Friend Function GetMaxByMask(sConn As String, sSQL As String, sFormat As String) As String
        Dim retStr As String = ""
        Try
            Using cn As New SqlConnection(sConn)
                cn.Open()
                Using rd As SqlDataReader = New SqlCommand(sSQL, cn).ExecuteReader
                    If rd.Read Then
                        If rd.HasRows Then
                            Dim numStr As String = ""
                            Dim formatStr As String = ""
                            Dim val As String = rd.GetValue(0).ToString()
                            Dim i As Integer = 0
                            For i = 1 To val.Length
                                If IsNumeric(val.Substring(val.Length - i, 1)) Then
                                    numStr = val.Substring(val.Length - i, 1) & numStr
                                    formatStr &= "0"
                                Else
                                    Exit For
                                End If
                            Next
                            If numStr <> "" Then
                                retStr = val.Substring(0, val.Length - i + 1) & Format(CLng(numStr) + 1, formatStr)
                            End If
                        End If
                    End If
                    rd.Close()
                End Using

            End Using
        Catch ex As Exception
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetMaxByMask", ex.Message, ex.StackTrace, True)
        End Try
        If retStr = "" Then
            Dim j As Integer = sFormat.Count(Function(c As Char) c = "_")
            retStr = Replace(sFormat, Strings.StrDup(j, "_"), Format(1, Strings.StrDup(j, "0")))
        End If
        Return retStr
    End Function
    Friend Function GetAuthorize(uname As String, app As String, mnu As String) As String
        'M=Can Manage
        'I=Can Insert Data
        'R=Can Query Data
        'E=Can Edit Data
        'D=Can Delete Data
        'P=Can Print Data
        Dim data = ""
        If uname <> "" Then
            Dim auth = New CUserAuth(GetSession("ConnJob")).GetData(" WHERE UserID='" & uname & "' AND AppID='" & app & "' AND MenuID='" & mnu & "'")
            data = If(auth.Count > 0, "" & auth(0).Author, "")
        End If
        Return data
    End Function
    Friend Function SetAuthorizeFromRole(uname As String) As String
        Dim msg As String = ""
        Try
            Dim SQL As String = SQLSelectRoleAll()
            If uname <> "" Then
                SQL = String.Format(SQL, " AND a.UserID='" & uname & "'")
            Else
                SQL = String.Format(SQL, "")
            End If
            Dim dt As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQL)
            Dim iRow As Integer = 0
            For Each dr As DataRow In dt.Rows

                Dim oAuth = New CUserAuth(GetSession("ConnJob")) With {
    .UserID = If(uname <> "", uname, dr("UserID").ToString()),
    .AppID = dr("ModuleCode").ToString(),
    .MenuID = dr("ModuleFunc").ToString(),
    .Author = dr("Authorize").ToString()
}
                msg += oAuth.SaveData(String.Format(" WHERE UserID='{0}' AND AppID='{1}' AND MenuID='{2}'", oAuth.UserID, oAuth.AppID, oAuth.MenuID)) & "\n"
                iRow += 1
            Next
            Return msg & iRow & " Processed"
        Catch ex As Exception
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetAuthorizeFromRole", ex.Message, ex.StackTrace, True)
            Return "[ERROR] SetAuthorizeByRole:" + ex.Message
        End Try
    End Function

    Friend Function SetAuthorizeFromPolicy(roleid As String) As String
        Dim msg As String = ""
        Try
            Dim SQL As String = SQLSelectRoleAll()

            If roleid <> "" Then
                SQL = String.Format(SQL, " AND b.RoleID='" & roleid & "'")
            Else
                SQL = String.Format(SQL, "")
            End If
            Dim dt As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQL)
            Dim iRow As Integer = 0
            For Each dr As DataRow In dt.Rows

                Dim oAuth = New CUserAuth(GetSession("ConnJob")) With {
    .UserID = dr("UserID").ToString(),
    .AppID = dr("ModuleCode").ToString(),
    .MenuID = dr("ModuleFunc").ToString(),
    .Author = dr("Authorize").ToString()
}
                msg += oAuth.SaveData(String.Format(" WHERE UserID='{0}' AND AppID='{1}' AND MenuID='{2}'", oAuth.UserID, oAuth.AppID, oAuth.MenuID)) & "\n"
                iRow += 1
            Next
            Return msg & iRow & " Processed"
        Catch ex As Exception
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetAuthorizeByRole", ex.Message, ex.StackTrace, True)
            Return "[ERROR] SetAuthorizeByRole:" + ex.Message
        End Try
    End Function
    Friend Function DBExecute(conn As String, SQL As String) As String
        Try
            Using cn As New SqlConnection(conn)
                cn.Open()
                Using cm As New SqlCommand()
                    cm.Connection = cn
                    cm.CommandType = CommandType.Text
                    cm.CommandText = SQL
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DBExecute", conn, SQL, False)
                End Using
            End Using
            Return "OK"
        Catch ex As Exception
            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DBExecute", ex.Message, ex.StackTrace, True)
            Return "[ERROR]" & ex.Message
        End Try
    End Function
    Public Function SQLUpdateClearHeader() As String
        Return "
UPDATE a
SET a.AdvTotal=ISNULL(b.AdvTotal,0)
,a.TotalExpense=ISNULL(b.TotalNET,0)
,a.ClearTotal=ISNULL(b.AdvTotal-b.TotalNET,0)
,a.ClearVat=ISNULL(b.TotalVAT,0)
,a.ClearWht=ISNULL(b.TotalWHT,0)
,a.ClearNet=ISNULL(b.TotalNET,0)
,a.ClearBill=ISNULL(b.TotalBill,0)
,a.ClearCost=ISNULL(b.TotalCost,0)
FROM Job_ClearHeader a LEFT JOIN (
  SELECT BranchCode,ClrNo,Sum(AdvAmount) as AdvTotal,
  Sum(ChargeVAT) as TotalVAT,Sum(Tax50Tavi) as TotalWHT,Sum(BNet) as TotalNET,
  Sum(CASE WHEN BPrice >0 THEN BPrice ELSE 0 END) as TotalBill,
  Sum(CASE WHEN BPrice =0 THEN BCost ELSE 0 END) as TotalCost
  FROM Job_ClearDetail
  GROUP BY BranchCode,ClrNo
) b
ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
"
    End Function
    Public Function SQLUpdateAdvStatus() As String
        Return "
update adv
set adv.DocStatus=src.ClrStatus
from Job_AdvHeader adv inner join
(
    select BranchCode,AdvNo,sum(ClrCount) as ClrCount,
    (CASE WHEN sum(CASE WHEN IsDuplicate=0 THEN ClrCount ELSE 0 END)=Count(*) THEN 5 ELSE 
 (CASE WHEN Sum(ClrCount) > 0 THEN 4 ELSE Max(AdvStatus) END) 
     END) as ClrStatus 
    ,sum(ClrNet) as ClrNet,Sum(AdvNet) as AdvNet
    from
    (
        select h.BranchCode,d.AdvNo,d.ItemNo,d.IsDuplicate,d.AdvAmount as AdvNet,
        (CASE WHEN d.IsDuplicate=1 THEN ISNULL(c.ClrNet,0) ELSE ISNULL(c.AdvNet,0) END) as ClrNet,
        (CASE WHEN ISNULL(h.PaymentRef,'')<>'' THEN 3 ELSE (CASE WHEN ISNULL(h.ApproveBy,'')<>'' THEN 2 ELSE 1 END) END) as AdvStatus,
        (CASE WHEN c.ClrNo IS NULL THEN 0 ELSE 1 END) as ClrCount
        from Job_AdvHeader h inner join Job_AdvDetail d
        on h.BranchCode=d.BranchCode
        and h.AdvNo=d.AdvNo 
        left join
        (
            select a.BranchCode,a.AdvNO,a.AdvItemNo
            ,Max(a.ClrNo) as ClrNo
            ,Sum(a.BNet) as ClrNet,Sum(a.AdvAmount) as AdvNet 
            FROM Job_ClearDetail a inner join Job_ClearHeader b
            on a.BranchCode=b.BranchCode
            and a.ClrNo=b.ClrNo
            where b.DocStatus<>99
            group by a.BranchCode,a.AdvNO,a.AdvItemNo
        ) c
        on h.BranchCode=c.BranchCode
        and h.AdvNo=c.AdvNO
        and d.ItemNo=c.AdvItemNo
        where h.DocStatus<>99
    ) clr
    group by BranchCode,AdvNo
) src
on adv.BranchCode=src.BranchCode
and adv.AdvNo=src.AdvNo
"
    End Function
    Public Function SQLUpdateAdvHeader() As String
        Return "
update b 
set b.TotalAdvance =ISNULL(a.SumAdvance,0)
,b.TotalVAT=ISNULL(a.SumVAT,0)
,b.Total50Tavi=ISNULL(a.Sum50Tavi,0)
from Job_AdvHeader b left join 
(
	select BranchCode,AdvNo,Sum(AdvNet) as SumAdvance,
	sum(ChargeVAT) as SumVAT,
	sum(Charge50Tavi) as Sum50Tavi
	from Job_AdvDetail 
	group by BranchCode,AdvNo
) a     
on b.BranchCode =a.BranchCode
and b.AdvNo=a.AdvNo
"
    End Function
    Public Function SQLUpdatePayHeader() As String
        Return "
update b 
set b.TotalExpense =ISNULL(a.SumNet,0)
,b.TotalVAT=ISNULL(a.SumAmtVAT,0)
,b.TotalTax=ISNULL(a.SumAmtWHT,0)
,b.TotalDiscount=ISNULL(a.SumAmtDisc,0)
,b.TotalNet=ISNULL(a.SumTotal,0)
,b.ForeignAmt=ISNULL(a.SumFTotal,0)
from Job_PaymentHeader b left join 
(
	select BranchCode,DocNo,Sum(Amt-AmtDisc) as SumNet,
	sum(AmtVAT) as SumAmtVAT,
	sum(AmtWHT) as SumAmtWHT,
    sum(AmtDisc) as SumAmtDisc,
    sum(Total) as SumTotal,
    sum(FTotal) as SumFTotal
	from Job_PaymentDetail 
	group by BranchCode,DocNo
) a     
on b.BranchCode =a.BranchCode
and b.DocNo=a.DocNo
"
    End Function
    Function SQLUpdateWHTaxHeader() As String
        Return "
UPDATE h
SET h.TotalPayAmount=d.TotalAmt,
h.TotalPayTax=d.TotalTax
FROM Job_WHTax h INNER JOIN (
    SELECT BranchCode,DocNo,Sum(PayAmount) as TotalAmt,Sum(PayTax) as TotalTax
    FROM Job_WHTaxDetail 
    GROUP BY BranchCode,DocNo
) d
ON h.BranchCode=d.BranchCode
AND h.DocNo=d.DocNo 
"
    End Function
    Function SQLSelectCNDNByInvoice() As String
        Return "
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo
"
    End Function

    Function SQLSelectCNDNSummary() As String
        Return "
SELECT a.*,b.InvoiceNo,
b.TotalAmt,b.TotalVAT,b.TotalWHT,b.TotalNet,b.FTotalNet
FROM Job_CNDNHeader a LEFT JOIN
(
    SELECT BranchCode,DocNo,
    (SELECT STUFF((
SELECT DISTINCT ',' + BillingNo
FROM Job_CNDNDetail WHERE BranchCode=d.BranchCode
AND DocNo=d.DocNo  
    FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
    )) as InvoiceNo,
    Sum(DiffAmt) as TotalAmt,
    Sum(VATAmt) as TotalVAT,
    Sum(WHTAmt) as TotalWHT,
    Sum(TotalNet) as TotalNet,
    Sum(ForeignNet) as FTotalNet
    FROM Job_CNDNDetail d
    GROUP BY BranchCode,DocNo
) b
ON a.BranchCode=b.BranchCode
AND a.DocNo=b.DocNo
"
    End Function

    Function SQLSelectVoucher() As String
        Dim sql As String = "
SELECT h.BranchCode,h.ControlNo,h.VoucherDate,h.TRemark,h.CustCode,h.CustBranch,h.RecUser,h.RecDate,h.RecTime,
h.PostedBy,h.PostedDate,h.PostedTime,h.CancelReson,h.CancelProve,h.CancelDate,h.CancelTime,h.PostRefNo,
d.ItemNo,d.PRVoucher,d.PRType,d.ChqNo,d.BookCode,d.BankCode,d.BankBranch,d.ChqDate,d.CashAmount,d.ChqAmount,d.CreditAmount,
d.SumAmount,d.CurrencyCode,d.ExchangeRate,d.VatInc+d.VatExc as VatAmount,d.WhtInc+d.WhtExc as WhtAmount,d.TotalAmount,
d.TotalNet,d.IsLocal,d.ChqStatus,d.TRemark as DRemark,d.PayChqTo,d.DocNo as DRefNo,d.SICode,d.RecvBank,d.RecvBranch,
d.acType,d.ForJNo,r.ItemNo as DocItemNo,r.DocType,r.DocNo,r.DocDate,r.CmpType,r.CmpCode,r.CmpBranch,r.PaidAmount as PaidTotal,r.TotalAmount as DocTotal
FROM Job_CashControl h inner join Job_CashControlSub d
on h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
left join Job_CashControlDoc r
on d.BranchCode=r.BranchCode AND d.ControlNo=r.ControlNo
AND d.acType=r.acType 
"
        Return sql
    End Function
    Function SQLSelectWHTax() As String
        Return "
SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
(CASE WHEN h.FormType=1 THEN 'ภงด1ก' ELSE (CASE WHEN h.FormType=2 THEN 'ภงด1ก(พิเศษ)' ELSE (CASE WHEN h.FormType=3 THEN 'ภงด2' ELSE (CASE WHEN h.FormType=4 THEN 'ภงด3' ELSE (CASE WHEN h.FormType=5 THEN 'ภงด2ก' ELSE (CASE WHEN h.FormType=6 THEN 'ภงด3ก' ELSE (CASE WHEN h.FormType=7 THEN 'ภงด53' ELSE 'ไม่ระบุ' END) END) END) END) END) END) END) as FormTypeName,
(CASE WHEN h.TaxLawNo=1 THEN '3เตรส' ELSE (CASE WHEN h.TaxLawNo=2 THEN '65จัตวา' ELSE (CASE WHEN h.TaxLawNo=3 THEN '69ทวิ' ELSE (CASE WHEN h.TaxLawNo=4 THEN '48ทวิ' ELSE (CASE WHEN h.TaxLawNo=5 THEN '50ทวิ' ELSE 'ไม่ระบุ' END) END) END) END) END) as TaxLawName
FROM dbo.Job_WHTax h LEFT JOIN dbo.Job_WHTaxDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
AND d.JNo=j.JNo 
LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID
"
    End Function
    Function SQLSelectWHTaxSummary() As String
        Return "
SELECT FormTypeName,TaxLawName,TaxNumber1 as TaxNumber,Branch1 as Branch,NameThai as TaxBy,
Year(a.PayDate) as TaxYear,Month(a.PayDate)  as TaxMonth,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayAmount END) as ServiceAmount,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayTax END) as TaxService, 
SUM(CASE WHEN a.PayRate<>1 THEN 0 ELSE a.PayAmount END) as TranAmount,
SUM(CASE WHEN a.PayRate<>1 THEN 0 ELSE a.PayTax END) as TaxTransport
FROM
(
    SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
    d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
    j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
    (CASE WHEN h.FormType=1 THEN 'ภงด1ก' ELSE (CASE WHEN h.FormType=2 THEN 'ภงด1ก(พิเศษ)' ELSE (CASE WHEN h.FormType=3 THEN 'ภงด2' ELSE (CASE WHEN h.FormType=4 THEN 'ภงด3' ELSE (CASE WHEN h.FormType=5 THEN 'ภงด2ก' ELSE (CASE WHEN h.FormType=6 THEN 'ภงด3ก' ELSE (CASE WHEN h.FormType=7 THEN 'ภงด53' ELSE 'ไม่ระบุ' END) END) END) END) END) END) END) as FormTypeName,
    (CASE WHEN h.TaxLawNo=1 THEN '3เตรส' ELSE (CASE WHEN h.TaxLawNo=2 THEN '65จัตวา' ELSE (CASE WHEN h.TaxLawNo=3 THEN '69ทวิ' ELSE (CASE WHEN h.TaxLawNo=4 THEN '48ทวิ' ELSE (CASE WHEN h.TaxLawNo=5 THEN '50ทวิ' ELSE 'ไม่ระบุ' END) END) END) END) END) as TaxLawName
    FROM dbo.Job_WHTax h INNER JOIN dbo.Job_WHTaxDetail d
    ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
    LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
    AND d.JNo=j.JNo 
    LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID
) a LEFT JOIN dbo.Mas_Company c ON a.TaxNumber1=c.TaxNumber 
{0}
GROUP BY FormTypeName,TaxLawName,TaxNumber1,Branch1,Year(a.PayDate),Month(a.PayDate),NameThai
ORDER BY FormTypeName,NameThai,Year(a.PayDate),Month(a.PayDate)
"
    End Function
    Function SQLSelectAdvHeader() As String
        Return "
select a.*,
(SELECT STUFF((
    SELECT DISTINCT ',' + ForJNo
    FROM Job_AdvDetail WHERE BranchCode=a.BranchCode
    AND AdvNo=a.AdvNo AND ForJNo<>'' 
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as JobNo
,
(SELECT STUFF((
    SELECT DISTINCT ',' + InvNo
    FROM Job_Order WHERE BranchCode=a.BranchCode AND JNo in(SELECT ForJNo FROM Job_AdvDetail WHERE BranchCode=a.BranchCode
    AND AdvNo=a.AdvNo AND ForJNo<>'')
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as CustInvNo
,b.TaxNumber,b.NameThai,b.NameEng
,c.BaseAmount,c.RateVAT,c.Rate50Tavi,c.BaseVATInc,c.Base50TaviInc,c.BaseVATExc,c.Base50TaviExc
,c.BaseVATInc+c.BaseVATExc as BaseVAT,c.Base50TaviExc+c.Base50TaviInc as Base50Tavi
,c.VATInc,c.VATExc,c.WHTInc,c.WHTExc,c.TotalNet
,a.AdvCash*a.ExchangeRate as AdvCashCal
,a.AdvChq*a.ExchangeRate as AdvChqCal
,a.AdvChqCash*a.ExchangeRate as AdvChqCashCal
,a.AdvCred*a.ExchangeRate as AdvCredCal
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT BranchCode,AdvNo,MAX(VATRate) as RateVAT,MAX(Rate50Tavi) as Rate50Tavi,
    SUM(CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    SUM(CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    SUM(CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    SUM(CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    SUM(CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    SUM(CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    SUM(CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    SUM(CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc,
    SUM(AdvAmount) as BaseAmount,SUM(AdvNet) as TotalNet  
    FROM Job_AdvDetail 
    GROUP BY BranchCode,AdvNo
) c
ON a.BranchCode=c.BranchCode AND a.AdvNo=c.AdvNo
"
    End Function
    Function SQLSelectAdvDetail() As String
        Return "
select a.*,d.ForJNo,d.ItemNo,d.SICode,d.SDescription,
d.IsDuplicate,d.IsChargeVAT,d.Is50Tavi,d.CurrencyCode,d.ExchangeRate as DExchangeRate,
b.TaxNumber,b.NameThai,b.NameEng,d.VenCode,d.TRemark as DRemark,
d.BaseAmount,d.RateVAT,d.ChargeVAT,d.Rate50Tavi,d.Charge50Tavi,
d.AdvQty,d.UnitPrice,d.AdvNet,d.AdvPayAmount,
d.BaseVATExc,d.VATExc,d.BaseVATInc,d.VATInc,
d.Base50TaviInc,d.WHTExc,d.Base50TaviExc,d.WHTInc,
d.BaseVATInc+d.BaseVATExc as BaseVAT,d.Base50TaviExc+d.Base50TaviInc as Base50Tavi,j.*
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT *,
    VATRate as RateVAT,AdvAmount+ChargeVAT as AdvPayAmount,
    AdvAmount as BaseAmount,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    (CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    (CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    (CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    (CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc
    FROM Job_AdvDetail 
) d
ON a.BranchCode=d.BranchCode AND a.AdvNo=d.AdvNo
LEFT JOIN (
SELECT BranchCode as JobBranch,JNo as JobNo,JRevise, ConfirmDate, CPolicyCode, DocDate, CustContactName, QNo, Revise, ManagerCode, CSCode, JobStatus, 
                         InvNo as CustInvNo, InvTotal, InvProduct, InvCountry, InvFCountry, InvInterPort, InvProductQty, InvProductUnit, InvCurUnit, InvCurRate, ImExDate, BLNo, 
                         BookingNo, ClearPort, ClearPortNo, ClearDate, LoadDate, ForwarderCode, AgentCode, VesselName, ETDDate, ETADate, ETTime, FNetPrice, BNetPrice, 
                          CancelProveTime, CloseJobDate, CloseJobTime, CloseJobBy, DeclareType, DeclareNumber, 
                         DeclareStatus, TyAuthorSp, Ty19BIS, TyClearTax, TyClearTaxReson, EstDeliverDate, EstDeliverTime, TotalContainer, DutyDate, DutyAmount, DutyCustPayOther, 
                         DutyCustPayChqAmt, DutyCustPayBankAmt, DutyCustPayEPAYAmt, DutyCustPayCardAmt, DutyCustPayCashAmt, DutyCustPayOtherAmt, DutyLtdPayOther, 
                         DutyLtdPayChqAmt, DutyLtdPayEPAYAmt, DutyLtdPayCashAmt, DutyLtdPayOtherAmt, ConfirmChqDate, ShippingEmp, ShippingCmd, TotalGW, GWUnit, TSRequest, 
                         ShipmentType, ReadyToClearDate, Commission, CommPayTo, ProjectName, MVesselName, TotalNW, Measurement, CustRefNO, TotalQty, HAWB, MAWB, 
                         consigneecode, privilegests, DeliveryNo, DeliveryTo, DeliveryAddr, CreateDate
FROM dbo.Job_Order
) j on d.BranchCode=j.JobBranch AND d.ForJNo=j.JobNo
"
    End Function
    Function SQLSelectPayForCharge() As String
        Return "
 SELECT d.BranchCode, '' AS ClrNo, 0 AS ItemNo, 0 AS LinkItem, 'SRV' AS STCode, p.ChargeCode AS SICode, 
 s.NameThai + ' (' + p.Location + ')' as SDescription, h.VenCode AS VenderCode, d.Qty, d.QtyUnit AS UnitCode, 
 h.CurrencyCode, h.ExchangeRate AS CurRate, p.ChargeAmount as UnitPrice, 
 d.Qty * p.ChargeAmount AS FPrice, 
 (d.Qty * p.ChargeAmount / h.ExchangeRate) AS BPrice, (d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.VATRate*0.01)*s.IsTaxCharge AS ChargeVAT, 
 (d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.TaxRate*0.01)*s.Is50Tavi AS Tax50Tavi,'' AS AdvNO, 0 AS AdvAmount, (d.Qty * p.ChargeAmount / h.ExchangeRate) AS UsedAmount, 0 AS IsQuoItem, '' AS SlipNO, 
 '' AS Remark, 0 AS IsDuplicate, 0 AS IsLtdAdv50Tavi, '' AS Pay50TaviTo, '' AS NO50Tavi, NULL AS Date50Tavi,
 d.DocNo + '#0' AS VenderBillingNo,'' AS AirQtyStep, '' AS StepSub, d.ForJNo AS JobNo, 0 AS AdvItemNo, '' AS LinkBillNo, 0 AS VATType, h.VATRate, 
 h.TaxRate AS Tax50TaviRate,'' AS QNo, (d.Qty * p.ChargeAmount / h.ExchangeRate)+((d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.VATRate*0.01)*s.IsTaxCharge)-((d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.TaxRate*0.01)*s.Is50Tavi) AS BNet, 
 ((d.Qty * p.ChargeAmount / h.ExchangeRate)+((d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.VATRate*0.01)*d.IsTaxCharge)-((d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.TaxRate*0.01)*d.Is50Tavi)) * h.ExchangeRate AS FNet ,h.DocDate as VenderBillDate,
h.RefNo,h.PoNo
  FROM dbo.Job_PaymentDetail d INNER JOIN
 dbo.Job_PaymentHeader h ON d.BranchCode = h.BranchCode AND 
 d.DocNo = h.DocNo
 INNER JOIN (SELECT x.*,y.VenderCode,y.NotifyCode FROM dbo.Job_LoadInfoDetail x INNER JOIN dbo.Job_LoadInfo y ON x.BranchCode=y.BranchCode AND x.BookingNo=y.BookingNo ) b
 ON d.BranchCode=b.BranchCode
 AND d.BookingRefNo=b.BookingNo
 AND d.BookingItemNo=b.ItemNo
   INNER JOIN dbo.Job_TransportPrice p
 ON b.BranchCode=p.BranchCode
 AND b.LocationID=p.LocationID
 AND b.VenderCode=p.VenderCode
 AND b.NotifyCode=p.CustCode
 AND d.SICode=p.SICode
 LEFT JOIN dbo.Job_SrvSingle s ON p.ChargeCode=s.SICode
 WHERE ISNULL(h.ApproveBy,'')<>'' AND s.IsCredit=0 AND s.IsExpense=0
"
    End Function
    Function SQLSelectPayForClear() As String
        Return "
  SELECT d.BranchCode, '' AS ClrNo, 0 AS ItemNo, 0 AS LinkItem, 'EXP' AS STCode, d.SICode, 
  d.SDescription, h.VenCode AS VenderCode, d.Qty, d.QtyUnit AS UnitCode, 
  h.CurrencyCode, h.ExchangeRate AS CurRate, d.UnitPrice, 
  d.Qty * d.UnitPrice AS FPrice, 
  d.Qty * d.UnitPrice / h.ExchangeRate AS BPrice, d.AmtVAT AS ChargeVAT, 
  d.AmtWHT AS Tax50Tavi,'' AS AdvNO, 0 AS AdvAmount, d.Amt AS UsedAmount, 0 AS IsQuoItem, '' AS SlipNO, 
  '' AS Remark, 0 AS IsDuplicate, 0 AS IsLtdAdv50Tavi, '' AS Pay50TaviTo, '' AS NO50Tavi, NULL AS Date50Tavi,
 d.DocNo + '#' + Convert(varchar,d.ItemNo) AS VenderBillingNo,'' AS AirQtyStep, '' AS StepSub, d.ForJNo AS JobNo, 0 AS AdvItemNo, '' AS LinkBillNo, 0 AS VATType, h.VATRate, 
 h.TaxRate AS Tax50TaviRate,'' AS QNo, d.Total AS FNet, 
 d.Total / h.ExchangeRate AS BNet ,h.DocDate as VenderBillDate,h.RefNo,h.PoNo
 FROM dbo.Job_PaymentDetail d INNER JOIN
 dbo.Job_PaymentHeader h ON d.BranchCode = h.BranchCode AND 
 d.DocNo = h.DocNo
 WHERE d.AdvItemNo=0 AND ISNULL(h.ApproveBy,'')<>'' 
"
    End Function
    Function SQLSelectAdvForClear() As String
        Return "
Select a.BranchCode,'' as ClrNo,0 as ItemNo,0 as LinkItem,
a.STCode,a.SICode,a.SDescription,a.VenCode as VenderCode,
a.AdvQty as Qty,b.UnitCharge as UnitCode,a.CurrencyCode,a.ExchangeRate as CurRate,
(CASE WHEN b.IsExpense=0 THEN a.UnitPrice ELSE 0 END) as UnitPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice ELSE 0 END) as FPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice*a.ExchangeRate ELSE 0 END) as BPrice,
q.TotalCharge as QUnitPrice,a.AdvQty*q.ChargeAmt as QFPrice,a.AdvQty*q.ChargeAmt*q.CurrencyRate as QBPrice,
a.UnitPrice as UnitCost,a.AdvQty*a.UnitPrice as FCost,a.AdvQty*a.UnitPrice*a.ExchangeRate as BCost,
a.ChargeVAT,a.Charge50Tavi as Tax50Tavi,a.AdvNo as AdvNO,d.AdvDate,a.ItemNo as AdvItemNo,a.AdvAmount,a.AdvNet,
a.AdvNet-ISNULL(d.TotalCleared,0) as AdvBalance,ISNULL(d.TotalCleared,0) as UsedAmount,
(CASE WHEN ISNULL(q.QNo,'')='' THEN 0 ELSE 1 END) as IsQuoItem,
a.IsDuplicate,b.IsExpense,
b.IsLtdAdv50Tavi,(CASE WHEN CHARINDEX('#',a.PayChqTo,0)>0 THEN '' ELSE a.PayChqTo END) as Pay50TaviTo,a.Doc50Tavi as NO50Tavi,NULL as Date50Tavi,
(CASE WHEN CHARINDEX('#',a.PayChqTo,0)>0 THEN a.PayChqTo ELSE '' END) as VenderBillingNo,'' as SlipNO,'' as Remark,
(SELECT STUFF((
	SELECT DISTINCT ',' + Convert(varchar,QtyBegin) + '-'+convert(varchar,QtyEnd)+'='+convert(varchar,ChargeAmt)
	FROM Job_QuotationItem WHERE BranchCode=q.BranchCode
	AND QNo=q.QNo AND SICode=q.SICode AND VenderCode =q.VenderCode
	AND UnitCheck=q.UnitCheck AND CalculateType=1
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as AirQtyStep,q.CalculateType as StepSub,
a.ForJNo as JobNo,a.IsChargeVAT as VATType,a.VATRate,a.Rate50Tavi as Tax50TaviRate,q.QNo,
c.DocStatus,c.AdvBy,c.EmpCode as ReqBy,c.PaymentDate,c.CustCode,c.PaymentRef
FROM Job_AdvDetail a LEFT JOIN Job_SrvSingle b on a.SICode=b.SICode
INNER JOIN Job_AdvHeader c on a.BranchCode=c.BranchCode and a.AdvNo=c.AdvNo 
left join Job_Order j on a.BranchCode=j.BranchCode and a.ForJNo=j.JNo
left join 
(
	select qh.BranchCode,qh.QNo,
	qd.JobType,qd.ShipBy,qd.SeqNo,
	qi.ItemNo,qi.SICode,qi.CalculateType,
	qi.QtyBegin,qi.QtyEnd,qi.UnitCheck,qi.CurrencyCode,
	qi.CurrencyRate,qi.ChargeAmt,qi.Isvat,qi.VatRate,
	qi.VatAmt,qi.IsTax,qi.TaxRate,qi.TaxAmt,
	qi.TotalAmt,qi.TotalCharge,qi.UnitDiscntPerc,qi.UnitDiscntAmt,
	qi.VenderCode,qi.VenderCost,qi.BaseProfit,qi.CommissionPerc,qi.CommissionAmt,
	qi.NetProfit,qi.IsRequired
	from Job_QuotationHeader qh	inner join Job_QuotationDetail qd ON qh.BranchCode=qd.BranchCode and qh.QNo=qd.QNo
	inner join Job_QuotationItem qi	on qd.BranchCode=qi.BranchCode and qd.QNo=qi.QNo and qd.SeqNo=qi.SeqNo 
    where qh.DocStatus=3 
) q
on a.BranchCode=q.BranchCode and b.SICode=q.SICode and ISNULL(a.VenCode,b.DefaultVender)=q.VenderCode 
and b.UnitCharge=q.UnitCheck and a.AdvQty <=q.QtyEnd and a.AdvQty>=q.QtyBegin and q.QNo=j.QNo
left join 
(
	SELECT ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,
    SUM(ISNULL(cd.BNet,0)) as TotalCleared    
	FROM Job_ClearDetail cd INNER JOIN Job_ClearHeader ch
	on cd.BranchCode=ch.BranchCode	and cd.ClrNo =ch.ClrNo 	and ch.DocStatus<>99
    INNER JOIN Job_AdvDetail ad on cd.BranchCode=ad.BranchCode and cd.AdvNO=ad.AdvNo and cd.AdvItemNo=ad.ItemNo
    INNER JOIN Job_AdvHeader ah on ad.BranchCode=ah.BranchCode and ad.AdvNo=ah.AdvNo
    WHERE ah.DocStatus<>99 AND ch.DocStatus<>99 
	GROUP BY ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,ad.IsDuplicate,ad.AdvNet
) d
ON a.BranchCode=d.BranchCode and a.AdvNo=d.AdvNo and a.ItemNo=d.ItemNo "
    End Function
    Function SQLSelectClrHeader() As String
        Return "
select a.*,
b.CustCode,b.CustBranch,b.JobNo,b.InvNo as CustInvNo,b.CurrencyCode,b.AdvNO,b.AdvNet,
b.ClrAmt,b.BaseVat,b.RateVAT,b.ClrVat,b.Base50Tavi,b.Rate50Tavi,b.Clr50Tavi,b.ClrNet
FROM Job_ClearHeader as a 
left join 
(
    SELECT d.BranchCode,d.ClrNo,d.JobNo,j.InvNo,j.CustCode,j.CustBranch,
    d.AdvNO,d.CurrencyCode,
    SUM(d.UsedAmount) as ClrAmt,sum(d.AdvAmount) as AdvNet,
    SUM(CASE WHEN d.ChargeVAT>0 THEN d.UsedAmount ELSE 0 END) as BaseVat,
    SUM(CASE WHEN d.Tax50Tavi>0 THEN d.UsedAmount ELSE 0 END) as Base50Tavi,
    SUM(d.ChargeVAT) as ClrVat,SUM(d.Tax50Tavi) as Clr50Tavi,
    MAX(VATRate) as RateVAT,MAX(Tax50TaviRate) as Rate50Tavi,
    SUM(d.BNet) as ClrNet
    FROM Job_ClearDetail d
    inner join Job_Order j on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
    GROUP BY d.BranchCode,d.ClrNo,d.JobNo,j.InvNo,j.CustCode,j.CustBranch,
    d.AdvNO,d.CurrencyCode
) b
on b.BranchCode=a.BranchCode
and b.ClrNo=a.ClrNo"
    End Function
    Function SQLSelectClrDetail() As String
        Return "select 
h.BranchCode,h.ClrNo,h.ClrDate,h.DocStatus,c1.ClrStatusName,
h.ClearanceDate,h.JobType,c4.JobTypeName,j.ShipBy,c6.ShipByName,
b.BrName as BranchName,h.CTN_NO,h.CoPersonCode,h.TRemark,h.ClearType,c2.ClrTypeName,h.ClearFrom,c3.ClrFromName,
h.EmpCode,u1.TName as ClrByName,h.ApproveBy,u2.TName as ApproveByName,
h.ApproveDate,h.ReceiveBy,u3.TName as ReceiveByName, h.ReceiveDate,h.ReceiveRef,
h.AdvTotal,h.ClearTotal,h.TotalExpense,h.ClearVat,h.ClearWht,h.ClearNet,h.ClearBill,h.ClearCost,
d.ItemNo,d.AdvNO,d.AdvItemNo,a.IsDuplicate,d.AdvAmount,
a.AdvNet,a.PaymentDate,a.AdvDate,a.DocStatus as AdvStatus,
d.SICode,d.SDescription,d.SlipNO,d.JobNo,d.VenderCode,v.TName as VenderName,
d.UsedAmount,d.Tax50Tavi,d.ChargeVAT,d.BNet as ClrNet,
d.FPrice,d.BPrice,d.FCost,d.BCost,
d.UnitPrice,d.Qty,d.CurrencyCode,d.CurRate,d.UnitCost,d.FNet,d.BNet,d.Tax50TaviRate,d.VATRate,
d.LinkItem,d.LinkBillNo,s.IsExpense,s.IsCredit,s.IsTaxCharge,s.Is50Tavi,s.IsHaveSlip,s.IsLtdAdv50Tavi,
d.Remark,j.CustCode,j.CustBranch,j.InvNo,j.NameEng,j.NameThai,j.TotalContainer,j.VesselName,j.Commission,j.consigneecode,j.DeliveryTo,
j.JobDate,j.JobStatus,c5.JobStatusName,j.CloseJobDate,j.CloseJobBy,j.DeclareNumber,j.InvProduct,j.TotalGW,j.InvProductQty,
h.CancelProve,h.CancelReson,h.CancelDate,r.LastReceipt,r.ReceiveNet 
from Job_ClearHeader h inner join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join Mas_Branch b on h.BranchCode=b.Code 
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.EmpCode,ad.AdvAmount,ad.ChargeVAT,
  ad.IsDuplicate,ad.AdvNet,ah.AdvDate,ah.DocStatus
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.*,j.DocDate as JobDate,c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
left join 
(SELECT ConfigKey as ClrStatusKey,ConfigValue as ClrStatusName FROM Mas_Config WHERE ConfigCode='CLR_STATUS') c1
on h.DocStatus=c1.ClrStatusKey
left join 
(SELECT ConfigKey as ClrTypeKey,ConfigValue as ClrTypeName FROM Mas_Config WHERE ConfigCode='CLR_TYPE') c2
on h.ClearType=c2.ClrTypeKey
left join 
(SELECT ConfigKey as ClrFromKey,ConfigValue as ClrFromName FROM Mas_Config WHERE ConfigCode='CLR_FROM') c3
on h.ClearFrom=c3.ClrFromKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode='JOB_TYPE') c4
on h.JobType=c4.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode='JOB_STATUS') c5
on j.JobStatus=c5.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode='SHIP_BY') c6
on j.ShipBy=c6.JobTypeKey
left join Mas_User u1 on h.EmpCode=u1.UserID
left join Mas_User u2 on h.ApproveBy=u2.UserID
left join Mas_User u3 on h.ReceiveBy=u3.UserID 
left join Job_SrvSingle s on d.SICode=s.SICode
left join Mas_Vender v on d.VenderCode=v.VenCode
left join (
    SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,MAX(d.ReceiptNo) as LastReceipt,
    SUM(d.Net) as ReceiveNet
    FROM Job_ReceiptHeader h INNER JOIN Job_ReceiptDetail d
    ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
    WHERE NOT ISNULL(h.CancelProve,'')<>''
    GROUP BY d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
) r on d.BranchCode=r.BranchCode and d.LinkBillNo=r.InvoiceNo and d.LinkItem=r.InvoiceItemNo
"
    End Function
    Function SQLSelectClrNoAdvance() As String
        Return "
select h.ClrDate,h.ReceiveRef,h.ClrNo,d.ItemNo,a.AdvAmount,a.ChargeVAT,a.Charge50Tavi,a.AdvNet,
d.SICode,d.SDescription,j.CustCode,j.CustBranch,sum(d.UsedAmount+d.ChargeVAT) as ClrTotal,
ISNULL(a.AdvNet,0)-sum(d.BNet) as ClrBal,
sum(d.UsedAmount) as ClrAmount,
SUM(d.Tax50Tavi) as Clr50Tavi,SUM(d.ChargeVAT) as ClrVat,
SUM(d.BNet) as ClrNet,d.JobNo as ForJNo
from Job_ClearHeader h
left join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.PaymentRef,ah.JobType,
  ah.EmpCode,ah.AdvDate,ad.SICode,ad.SDescription,ad.AdvAmount,ad.ChargeVAT,ad.Charge50Tavi,ad.AdvNet,
  ah.CustCode,ah.CustBranch
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
  where ah.DocStatus <>99
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.BranchCode,j.JNo,j.CustCode,j.CustBranch,j.InvNo,j.JobStatus,j.CloseJobDate,
  c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
{0} 
group by h.ClrDate,h.ReceiveRef,h.ClrNo,d.ItemNo,a.AdvAmount,a.ChargeVAT,a.Charge50Tavi,a.AdvNet,
d.SICode,d.SDescription,j.CustCode,j.CustBranch,d.JobNo
"
    End Function
    Function SQLSelectClrFromAdvance() As String
        Return "
select a.PaymentDate,a.PaymentRef,a.AdvNo,a.ItemNo,a.AdvAmount,a.ChargeVAT,a.Charge50Tavi,a.AdvNet,
a.SICode,a.SDescription,a.CustCode,a.CustBranch,
sum(d.UsedAmount+d.ChargeVAT) as ClrTotal,
ISNULL(a.AdvNet,0)-sum(d.BNet) as ClrBal,
sum(d.UsedAmount) as ClrAmount,
SUM(d.Tax50Tavi) as Clr50Tavi,SUM(d.ChargeVAT) as ClrVat,
SUM(d.BNet) as ClrNet,a.ForJNo
from Job_ClearHeader h
left join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.PaymentRef,ah.JobType,
  ah.EmpCode,ah.AdvDate,ad.SICode,ad.SDescription,ad.AdvAmount,ad.ChargeVAT,ad.Charge50Tavi,ad.AdvNet,
  ah.CustCode,ah.CustBranch,ah.DocStatus,ad.ForJNo
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
  where ah.DocStatus<>99 
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.BranchCode,j.JNo,j.CustCode,j.CustBranch,j.InvNo,j.JobStatus,j.CloseJobDate,
  c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
{0} 
group by a.PaymentDate,a.PaymentRef,a.AdvNo,a.ItemNo,a.AdvAmount,a.ChargeVAT,a.Charge50Tavi,a.AdvNet,
a.SICode,a.SDescription,a.CustCode,a.CustBranch,a.ForJNo
"
    End Function
    Function SQLSelectBookAccBalance() As String
        Return "
SELECT q.*,q.SumCashOnhand+q.SumChqClear as SumCash,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand-q.LimitBalance as SumCashInBank,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand+q.SumCredit as SumBal,
q.SumCredit+q.SumChqReturn as SumCreditable
FROM (
select c.BookCode,c.LimitBalance,c.ControlBalance,
Sum(Case when a.PRType='P' then -1*(a.CashAmount) else a.CashAmount end) as SumCashOnhand,
Sum(Case when a.ChqStatus='P' then (CASE WHEN a.PRType='P' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqClear,
Sum(Case when a.ChqStatus='R' then (CASE WHEN a.PRType='P' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqReturn,
Sum(Case when a.ChqStatus NOT IN('P','R') then (CASE WHEN a.PRType='P' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqOnhand,
Sum(Case when a.PRType='P' then -1*a.CreditAmount else a.CreditAmount end) as SumCredit,
Sum(Case when a.PRType='P' then -1*(a.CreditAmount) else 0 end) as SumAP,
Sum(Case when a.PRType='R' then (a.CreditAmount) else 0 end) as SumAR,
Sum(Case when a.PRType='P' then -1*(a.CashAmount+a.ChqAmount) else 0 end) as SumPV,
Sum(Case when a.PRType='R' then (a.CashAmount+a.ChqAmount) else 0 end) as SumRV
from Job_CashControlSub a inner join Job_CashControl b
on a.BranchCode=b.BranchCode and a.ControlNo=b.ControlNo
left join Mas_BookAccount c 
on a.BookCode=c.BookCode
WHERE ISNULL(b.CancelProve,'')='' {0}
group by c.BookCode,c.LimitBalance,c.ControlBalance) q
"
    End Function
    Function SQLSelectChequeBalance(pType As String, chqType As String) As String
        Return "
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo," & If(pType = "CU", "RecvBank,RecvBranch", "BankCode,BankBranch") & ",acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo," & If(pType = "CU", "RecvBank,RecvBranch", "BankCode,BankBranch") & ",acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    " & If(pType = "CU", "h.RecvBank,h.RecvBranch", "h.BankCode,h.BankBranch") & "
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType='" & If(chqType = "P", "R", "P") & "' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'')<>''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    " & If(pType = "CU", ",h.RecvBank,h.RecvBranch", ",h.BankCode,h.BankBranch") & "
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo " & If(pType = "CU", "AND a.RecvBank=c.RecvBank AND a.RecvBranch=c.RecvBranch ", "AND a.BankCode=c.BankCode AND a.BankBranch=c.BankBranch ") & "
left join (
	SELECT h.BranchCode,h.ChqNo
" & If(pType = "CU", ",h.RecvBank,h.RecvBranch", ",h.BankCode,h.BankBranch") & "
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'')<>''
    )
	GROUP BY h.BranchCode,h.ChqNo" & If(pType = "CU", ",h.RecvBank,h.RecvBranch", ",h.BankCode,h.BankBranch") & "
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo " & If(pType = "CU", "AND a.RecvBank=d.RecvBank AND a.RecvBranch=d.RecvBranch ", "AND a.BankCode=d.BankCode AND a.BankBranch=d.BankBranch ") & "
WHERE a.acType='" & pType & "'
AND a.PRType='" & chqType & "' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'')<>'' 
"
    End Function
    Function SQLSelectDocumentBalance(pType As String, docType As String) As String
        If docType = "Credit" Then
            Return "
SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,a.CreditAmount-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX('#',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType='" & If(pType = "R", "P", "R") & "' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'')<>''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX('#',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE a.PRType='" & pType & "' AND a.CreditAmount>0 
"
        Else
            Return "
SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,(a.CashAmount+a.ChqAmount)-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX('#',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType='" & If(pType = "R", "P", "R") & "' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'')<>''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX('#',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE a.PRType='" & pType & "' AND (a.CashAmount+a.ChqAmount)>0 
"
        End If
    End Function
    Function SQLSelectJobReport() As String
        Return "
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode='JOB_TYPE') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode='JOB_STATUS') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode='SHIP_BY') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from " & jobmaster & ".dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
"
    End Function
    Function SQLUpdateInvoiceHeader() As String
        Return "
update h
set h.TotalAdvance=ROUND(d.TotalAdvance,2),
h.TotalCharge=ROUND(d.TotalCharge,2),
h.TotalIsTaxCharge=ROUND(d.TotalIsTaxCharge,2),
h.TotalIs50Tavi=ROUND(d.TotalIs50Tavi,2),
h.TotalVAT=ROUND(d.TotalVAT,2),
h.Total50Tavi=ROUND(d.Total50Tavi,2),
h.SumDiscount=ROUND(d.SumDiscount,2),
h.DiscountCal=ROUND(d.TotalNet*(h.DiscountRate*0.01),2),
h.TotalNet=ROUND(d.TotalNet-(d.TotalNet*(h.DiscountRate*0.01)),2),
h.ForeignNet=ROUND((d.TotalNet-(d.TotalNet*(h.DiscountRate*0.01)))/h.ExchangeRate,2)
from Job_InvoiceHeader h
inner join (
	select BranchCode,DocNo,
	sum((CASE WHEN AmtCharge>0 THEN Amt-AmtDiscount ELSE 0 END)) as TotalCharge,
	sum((CASE WHEN AmtAdvance>0 THEN TotalAmt ELSE 0 END)) as TotalAdvance,
	sum(case when AmtVat>0 And AmtCharge>0 then Amt-AmtDiscount else 0 end) as TotalIsTaxCharge, 
	sum(case when Amt50Tavi>0 And AmtCharge>0 then Amt-AmtDiscount else 0 end) as TotalIs50Tavi,
	sum(case when AmtCharge>0 then AmtVat else 0 end) as TotalVAT,
	sum(case when AmtCharge>0 then Amt50Tavi else 0 end) as Total50Tavi,
    sum(AmtDiscount) as SumDiscount,
	sum(TotalAmt-AmtCredit) as TotalNet
	from Job_InvoiceDetail
	group by BranchCode,DocNo
) d
on h.BranchCode=d.BranchCode
and h.DocNo=d.DocNo 
"
    End Function
    Function SQLSelectClrForInvoice() As String
        Return "
select b.BranchCode,b.LinkBillNo as DocNo,b.LinkItem as ItemNo,b.SICode,b.SDescription,
b.SlipNO as ExpSlipNO,b.Remark as SRemark,b.CurrencyCode,
b.CurRate as ExchangeRate,b.Qty,b.UnitCode as QtyUnit,
b.UsedAmount/b.Qty as UnitPrice,(b.UsedAmount/b.Qty)*b.CurRate as FUnitPrice,
b.UsedAmount as Amt,
b.UsedAmount/b.CurRate as FAmt,
0 as DiscountType,0 as DiscountPerc,0 as AmtDiscount,0 as FAmtDiscount,
CASE WHEN b.Tax50TaviRate>0 THEN 1 ELSE 0 END as Is50Tavi,
b.Tax50TaviRate as Rate50Tavi,
b.Tax50Tavi as Amt50Tavi,
b.VATType as IsTaxCharge,s.IsCredit,s.IsExpense,
b.ChargeVAT as AmtVat,
(CASE WHEN s.IsCredit=1 THEN b.UsedAmount+b.ChargeVAT ELSE b.BNet END) as TotalAmt,
(CASE WHEN s.IsCredit=1 THEN b.UsedAmount+b.ChargeVAT ELSE b.BNet END)/b.CurRate as FTotalAmt,
CASE WHEN s.IsCredit=1 AND s.IsExpense=0  THEN b.UsedAmount+b.ChargeVAT ELSE 0 END as AmtAdvance,
CASE WHEN s.IsCredit=0 AND s.IsExpense=0  THEN b.UsedAmount ELSE 0 END as AmtCharge,
b.CurrencyCode as CurrencyCodeCredit,b.CurRate as ExchangeRateCredit,0 as AmtCredit,0 as FAmtCredit,b.VATRate,
a.CTN_NO,c.CustCode,c.CustBranch,
b.JobNo,b.ClrNo,b.ItemNo as ClrItemNo,b.ClrNo+'/'+Convert(varchar,b.ItemNo) as ClrNoList,
(CASE WHEN s.IsExpense=1 THEN b.UsedAmount ELSE 0 END) as AmtCost,
(CASE WHEN s.IsCredit=1 THEN b.UsedAmount+b.ChargeVAT ELSE b.BNet END) as AmtNet
from Job_ClearHeader a INNER JOIN Job_ClearDetail b
ON a.BranchCode=b.BranchCode
AND a.ClrNo=b.ClrNo
INNER JOIN Job_SrvSingle s
ON b.SICode=s.SICode
INNER JOIN Job_Order c
ON b.BranchCode=c.BranchCode
and b.JobNo=c.JNo
"
    End Function
    Function SQLSelectInvForBilling() As String
        Return "
SELECT a.*,
(CASE WHEN a.TotalIsTaxCharge>0 AND a.TotalCharge>a.TotalIsTaxCharge THEN a.TotalCharge-a.TotalIsTaxCharge ELSE (CASE WHEN a.TotalIsTaxCharge=0 THEN TotalCharge ELSE 0 END) END) as TotalNonVat
,b.NameThai,b.NameEng 
FROM Job_InvoiceHeader a
LEFT JOIN Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch 
"
    End Function
    Function SQLUpdateBillHeader(branch As String, billno As String) As String
        Dim sql As String = "
UPDATE a
SET a.TotalCustAdv=ISNULL(b.SumCustAdvance,0),
a.TotalAdvance=ISNULL(b.SumAdvance,0),
a.TotalChargeVAT=ISNULL(b.SumChargeVAT,0),
a.TotalChargeNonVAT=ISNULL(b.SumChargeNonVAT,0),
a.TotalVAT=ISNULL(b.SumVAT,0),
a.TotalWH=ISNULL(b.SumWH,0),
a.TotalDiscount=ISNULL(b.SumDiscount,0),
a.TotalNet=ISNULL(b.SumNet,0)
FROM Job_BillAcceptHeader a 
LEFT JOIN (
    SELECT BranchCode,BillAcceptNo,
    SUM(AmtCustAdvance) as SumCustAdvance,
    SUM(AmtAdvance) as SumAdvance,
    SUM(AmtChargeVAT) as SumChargeVAT,
    SUM(AmtChargeNonVAT) as SumChargeNonVAT,
    SUM(AmtVAT) as SumVAT,
    SUM(AmtWH) as SumWH,
    SUM(AmtDiscount) as SumDiscount,
    SUM(AmtTotal) as SumNet
    FROM Job_BillAcceptDetail
    GROUP BY BranchCode,BillAcceptNo
) b
ON a.BranchCode=b.BranchCode
AND a.BillAcceptNo=b.BillAcceptNo
"
        Return sql & If(billno <> "" And branch <> "", String.Format(" WHERE a.BranchCode='{0}' AND a.BillAcceptNo='{1}' ", branch, billno), "")
    End Function
    Function SQLUpdateBillToInv(branch As String, billno As String, Optional iscancel As Boolean = False) As String
        Dim sql As String = "UPDATE a"
        If iscancel Then
            sql &= " SET a.BillAcceptNo=null,a.BillIssueDate=null,a.BillAcceptDate=null,"
            sql &= " a.BillToCustCode=null,a.BillToCustBranch=null"
            sql &= " FROM Job_InvoiceHeader a "
            sql &= " WHERE a.BranchCode='{0}' AND a.BillAcceptNo='{1}' "
        Else
            sql &= " SET a.BillAcceptNo=b.BillAcceptNo,a.BillIssueDate=b.BillDate,a.BillAcceptDate=b.BillRecvDate,"
            sql &= " a.BillToCustCode=b.CustCode,a.BillToCustBranch=b.CustBranch,a.DueDate=b.DuePaymentDate "
            sql &= " FROM Job_InvoiceHeader a INNER JOIN (SELECT h.*,d.InvNo FROM Job_BillAcceptHeader h INNER JOIN Job_BillAcceptDetail d ON h.BranchCode=d.BranchCode AND h.BillAcceptNo=d.BillAcceptNo WHERE NOT ISNULL(h.CancelProve,'')<>'') b "
            sql &= " ON a.BranchCode=b.BranchCode AND a.DocNo=b.InvNo WHERE a.BranchCode='{0}' AND b.BillAcceptNo='{1}' "
        End If
        Return String.Format(sql, branch, billno)
    End Function
    Function SQLUpdateJobStatus(sqlwhere As String) As String
        Dim today = DateTime.Today.ToString("yyyy-MM-dd")
        Dim sql As String = "
UPDATE j
SET j.JobStatus=c.JobStatus
FROM Job_Order j INNER JOIN (
    SELECT s.BranchCode,s.JNo,MAX(s.JobStatus) as JobStatus
    FROM (
SELECT BranchCode,JNo,0 as JobStatus FROM Job_Order 
WHERE ConfirmDate IS NULL 
AND JobStatus<>99 AND NOT ISNULL(CancelReson,'')<>''
UNION
SELECT BranchCode,JNo,1 FROM Job_Order 
WHERE ConfirmDate IS NOT NULL AND CloseJobDate IS NULL AND DutyDate IS NULL
AND JobStatus<>1 AND NOT ISNULL(CancelReson,'')<>''
UNION
SELECT BranchCode,JNo,1 FROM Job_Order 
WHERE ConfirmDate IS NOT NULL AND CloseJobDate IS NULL AND NOT DutyDate<=Convert(datetime,'" & today & "',102)
AND JobStatus<>1 AND NOT ISNULL(CancelReson,'')<>''
UNION
SELECT BranchCode,JNo,2 FROM Job_Order 
WHERE ConfirmDate IS NOT NULL AND CloseJobDate IS NULL AND DutyDate<=Convert(datetime,'" & today & "',102)
AND JobStatus<>2 AND NOT ISNULL(CancelReson,'')<>'' 
UNION
SELECT BranchCode,JNo,2 FROM Job_Order 
WHERE EXISTS(SELECT DISTINCT b.ForJNo FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b ON a.BranchCode=b.BranchCode AND a.AdvNo=b.AdvNo WHERE b.ForJNo=Job_Order.JNo AND a.DocStatus<>99)
AND JobStatus<2 AND NOT ISNULL(CancelReson,'')<>'' 
UNION
SELECT BranchCode,JNo,3 FROM Job_Order 
WHERE ConfirmDate IS NOT NULL AND CloseJobDate IS NOT NULL
AND JobStatus<>3 AND NOT ISNULL(CancelReson,'')<>''
UNION
SELECT a.BranchCode,a.JNo,4 FROM Job_Order a 
WHERE EXISTS(
      SELECT b.BranchCode,b.JobNo as JNo,
      SUM(CASE WHEN ISNULL(b.LinkBillNo,'')<>'' THEN 1 ELSE 0 END) as TotalBill
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      WHERE b.BranchCode=a.BranchCode AND b.JobNo=a.JNo
      AND h.DocStatus<>99 AND b.BNet>0
      GROUP BY b.BranchCode,b.JobNo
      HAVING SUM(CASE WHEN ISNULL(b.LinkBillNo,'')<>'' THEN 1 ELSE 0 END)=0
)
AND a.JobStatus<>99 AND NOT ISNULL(a.CancelReson,'')<>''
UNION 
SELECT a.BranchCode,a.JNo,5 FROM Job_Order a 
WHERE EXISTS(
      SELECT b.BranchCode,b.JobNo as JNo,
      SUM(CASE WHEN ISNULL(b.LinkBillNo,'')<>'' THEN 1 ELSE 0 END) as TotalBill,
      COUNT(*) as TotalDoc
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      WHERE b.BranchCode=a.BranchCode AND b.JobNo=a.JNo
      AND h.DocStatus<>99  AND b.BNet>0 
      GROUP BY b.BranchCode,b.JobNo
      HAVING COUNT(*)>SUM(CASE WHEN ISNULL(b.LinkBillNo,'')<>'' THEN 1 ELSE 0 END)
      AND SUM(CASE WHEN ISNULL(b.LinkBillNo,'')<>'' THEN 1 ELSE 0 END)>0
)
AND a.JobStatus<>99 AND NOT ISNULL(a.CancelReson,'')<>''
UNION 
SELECT a.BranchCode,a.JNo,6 FROM Job_Order a 
WHERE EXISTS (
      SELECT b.BranchCode,b.JobNo as JNo,
      SUM(CASE WHEN ISNULL(b.LinkBillNo,'')<>'' THEN 1 ELSE 0 END) as TotalBill,
      COUNT(*) as TotalDoc
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      WHERE b.BranchCode=a.BranchCode AND b.JobNo=a.JNo
      AND h.DocStatus<>99  AND b.BNet>0 
      GROUP BY b.BranchCode,b.JobNo
      HAVING COUNT(*)=SUM(CASE WHEN ISNULL(b.LinkBillNo,'')<>'' THEN 1 ELSE 0 END)
)
AND a.JobStatus<>99 AND NOT ISNULL(a.CancelReson,'')<>''
UNION
SELECT a.BranchCode,a.JNo,7 FROM Job_Order a 
WHERE EXISTS
(
      SELECT b.BranchCode,b.JobNo as JNo,SUM(b.BNet-(CASE WHEN s.IsExpense=1 AND ISNULL(b.LinkBillNo,'')<>'' THEN b.BNet ELSE 0 END)-ISNULL(r.TotalRcv,0)-ISNULL(c.CreditNet,0)-ISNULL(r.AmtCredit,0)-ISNULL(r.AmtDiscount,0)) as Balance
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      INNER JOIN Job_SrvSingle s ON b.SICode=s.SICode
      LEFT JOIN (
            SELECT rh.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,Sum(rd.Net) as TotalRcv,id.AmtCredit,id.AmtDiscount
            FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd
            ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
            INNER JOIN Job_InvoiceHeader ih
            ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo
            INNER JOIN Job_InvoiceDetail id
            ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
            WHERE ISNULL(rh.CancelProve,'')='' AND ISNULL(ih.CancelProve,'')='' 
            GROUP BY rh.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,id.AmtCredit,id.AmtDiscount
      ) r
      ON b.BranchCode=r.BranchCode AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
      LEFT JOIN (
" & SQLSelectCNDNByInvoice() & "
      ) c
      ON b.BranchCode=c.BranchCode AND b.LinkBillNo=c.BillingNo AND b.LinkItem=c.BillItemNo
      WHERE h.DocStatus<>99 AND b.BranchCode=a.BranchCode AND b.JobNo=a.JNo       
      GROUP BY b.BranchCode,b.JobNo
      HAVING SUM(b.BNet-(CASE WHEN s.IsExpense=1 AND ISNULL(b.LinkBillNo,'')<>'' THEN b.BNet ELSE 0 END)-ISNULL(r.TotalRcv,0)-ISNULL(c.CreditNet,0)-ISNULL(r.AmtCredit,0)-ISNULL(r.AmtDiscount,0))<=0
) AND a.ConfirmDate IS NOT NULL AND a.CloseJobDate IS NOT NULL  
AND a.JobStatus<>99 AND NOT ISNULL(a.CancelReson,'')<>''
UNION
SELECT BranchCode,JNo,98 as JobStatus FROM Job_Order 
WHERE ISNULL(CancelReson,'')<>'' AND JobStatus<>99 AND ISNULL(CancelProve,'')=''
UNION
SELECT BranchCode,JNo,99 as JobStatus FROM Job_Order 
WHERE ISNULL(CancelReson,'')<>'' AND ISNULL(CancelProve,'')<>''
UNION
SELECT a.BranchCode,a.JNo,7 FROM Job_Order a 
WHERE NOT EXISTS
(
      SELECT b.BranchCode,b.JobNo as JNo,SUM(b.BNet-(CASE WHEN s.IsExpense=1 AND ISNULL(b.LinkBillNo,'')<>'' THEN b.BNet ELSE 0 END)-ISNULL(r.TotalRcv,0)-ISNULL(c.CreditNet,0)-ISNULL(r.AmtCredit,0)-ISNULL(r.AmtDiscount,0)) as Balance
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      INNER JOIN Job_SrvSingle s ON b.SICode=s.SICode
      LEFT JOIN (
            SELECT rh.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,Sum(rd.Net) as TotalRcv,id.AmtCredit,id.AmtDiscount
            FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd
            ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
            INNER JOIN Job_InvoiceHeader ih
            ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo
            INNER JOIN Job_InvoiceDetail id
            ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
            WHERE ISNULL(rh.CancelProve,'')='' AND ISNULL(ih.CancelProve,'')='' 
            GROUP BY rh.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,id.AmtCredit,id.AmtDiscount
      ) r
      ON b.BranchCode=r.BranchCode AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
      LEFT JOIN (
" & SQLSelectCNDNByInvoice() & "
      ) c
      ON b.BranchCode=c.BranchCode AND b.LinkBillNo=c.BillingNo AND b.LinkItem=c.BillItemNo
      WHERE h.DocStatus<>99 AND b.BranchCode=a.BranchCode AND b.JobNo=a.JNo       
      GROUP BY b.BranchCode,b.JobNo
      HAVING SUM(b.BNet-(CASE WHEN s.IsExpense=1 AND ISNULL(b.LinkBillNo,'')<>'' THEN b.BNet ELSE 0 END)-ISNULL(r.TotalRcv,0)-ISNULL(c.CreditNet,0)-ISNULL(r.AmtCredit,0)-ISNULL(r.AmtDiscount,0))<=0
) AND a.ConfirmDate IS NOT NULL AND a.CloseJobDate IS NOT NULL 
AND a.JobStatus=7 AND NOT ISNULL(a.CancelReson,'')<>''
UNION
SELECT a.BranchCode,a.JNo,6 FROM Job_Order a 
WHERE NOT EXISTS (
      SELECT b.BranchCode,b.JobNo as JNo,
      SUM(CASE WHEN ISNULL(b.LinkBillNo,'')<>'' THEN 1 ELSE 0 END) as TotalBill,
      COUNT(*) as TotalDoc
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      WHERE b.BranchCode=a.BranchCode AND b.JobNo=a.JNo
      AND h.DocStatus<>99  AND b.BNet>0 
      GROUP BY b.BranchCode,b.JobNo
      HAVING COUNT(*)=SUM(CASE WHEN ISNULL(b.LinkBillNo,'')<>'' THEN 1 ELSE 0 END)
)
AND a.JobStatus=6 AND NOT ISNULL(a.CancelReson,'')<>''
    ) s
    GROUP BY s.BranchCode,s.JNo
) c
ON j.BranchCode=c.BranchCode
AND j.JNo=c.JNo 
WHERE j.JobStatus<> c.JobStatus
{0}
"
        Return String.Format(sql, sqlwhere)
    End Function

    Function SQLSelectInvSummary(pSqlw As String) As String
        Dim sqlGroup As String = "
h.BranchCode,h.DocNo,h.Docdate,h.CustCode,h.CustBranch,h.CustTName,h.CustEName,
h.BillToCustCode,h.BillToCustBranch,h.BillTName,h.BillEName,h.ContactName,h.EmpCode,
h.RefNo,h.VATRate,h.TotalAdvance,h.TotalCharge,h.TotalIsTaxCharge,h.TotalIs50Tavi,
h.TotalVAT,h.Total50Tavi,h.TotalCustAdv,h.TotalNet,h.CurrencyCode,h.ExchangeRate,
h.ForeignNet,h.BillAcceptDate,h.BillIssueDate,h.BillAcceptNo,
h.Remark1,h.Remark2,h.Remark3,h.Remark4,h.Remark5,h.Remark6,h.Remark7,h.Remark8,h.Remark9,h.Remark10,
h.CancelReson,h.CancelProve,h.CancelDate,h.CancelTime,h.ShippingRemark,h.SumDiscount,
h.DiscountRate,h.DiscountCal,h.TotalDiscount
"

        Dim sql As String = SQLSelectInvReport(pSqlw)
        sql = "
SELECT " & sqlGroup & "
,sum(h.TotalNet) as TotalInv,sum(ISNULL(h.ReceivedNet,0)) as TotalReceive
,sum(ISNULL(h.CreditNet,0)) as TotalCredit
,sum(h.TotalNet-ISNULL(h.ReceivedNet,0)-ISNULL(h.CreditNet,0)) as TotalBalance
,max(h.ControlLink) as ControlLink
FROM (
" & sql & "
) as h
GROUP BY " & sqlGroup
        Return sql
    End Function
    Function SQLSelectInvReport(Optional psqlW As String = "") As String
        Dim sql As String = "
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + '-' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(CASE WHEN rd.ControlNo<>'' THEN rd.Amt ELSE 0 END) as ReceivedAmt,
	sum(CASE WHEN rd.ControlNo<>'' THEN rd.AmtVAT ELSE 0 END) as ReceivedVat,
	sum(CASE WHEN rd.ControlNo<>'' THEN rd.Amt50Tavi ELSE 0 END) as ReceivedWht,
	sum(CASE WHEN rd.ControlNo<>'' THEN rd.Net ELSE 0 END) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'')=''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	" & SQLSelectCNDNByInvoice() & "
) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+'-'+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
where ISNULL(ih.CancelProve,'')='' {0}
"
        Return String.Format(sql, psqlW)
    End Function
    Function SQLSelectInvForReceive(bHasVoucher As Boolean) As String
        Dim amtSQL As String = "(id.Amt-ISNULL(id.AmtDiscount,0)-ISNULL(r.ReceivedAmt,0)-ISNULL(c.CreditAmt,0))"
        Dim vatSQL As String = "(id.AmtVat-ISNULL(r.ReceivedVat,0)-ISNULL(c.CreditVat,0))"
        Dim whtSQL As String = "(id.Amt50Tavi-ISNULL(r.ReceivedWht,0)-ISNULL(c.CreditWht,0))"
        Dim netSQL As String = "(id.TotalAmt-ISNULL(c.CreditNet,0)-ISNULL(r.ReceivedNet,0))"
        Return "
select id.BranchCode,'' as ReceiptNo,
0 as ItemNo,0 as CreditAmount,
" & netSQL & " as TransferAmount,
0 as CashAmount,0 as ChequeAmount,'' as ControlNo,'' as VoucherNo,0 as ControlItemNo,
ih.DocNo as InvoiceNo,ih.DocDate as InvoiceDate,id.ItemNo as InvoiceItemNo,
id.SICode,id.SDescription,id.VATRate,id.Rate50Tavi,
" & amtSQL & " as Amt,
" & vatSQL & " as AmtVAT,
" & whtSQL & " as Amt50Tavi,
" & netSQL & " as Net,
id.CurrencyCode as DCurrencyCode,id.ExchangeRate as DExchangeRate,
" & amtSQL & "/id.ExchangeRate as FAmt,
" & vatSQL & "/id.ExchangeRate as FAmtVAT,
" & whtSQL & "/id.ExchangeRate as FAmt50Tavi,
" & netSQL & "/id.ExchangeRate as FNet,
ih.CustCode,ih.CustBranch,ih.BillToCustCode,ih.BillToCustBranch,ih.RefNo,
id.Amt As InvAmt,id.AmtVat as InvVat,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
id.AmtAdvance,id.AmtCharge,id.AmtDiscount,id.AmtCredit,
c.CreditNo,c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,
r.LastReceiptNo,r.LastControlNo,r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
	sum(rd.Amt) as ReceivedAmt,
	sum(rd.AmtVAT) as ReceivedVat,
	sum(rd.Amt50Tavi) as ReceivedWht,
	sum(rd.Net) as ReceivedNet,
    max(rh.ReceiptNo) as LastReceiptNo,
    max(rd.ControlNo) as LastControlNo,
    max(rh.ReceiptDate) as ReceiptDate
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	WHERE ISNULL(rh.CancelProve,'')='' 
    " & If(bHasVoucher, " AND ISNULL(rd.ControlNo,'')<>'' ", "") & "
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
    " & SQLSelectCNDNByInvoice() & "
) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
"

    End Function
    Function SQLSelectInvByReceive(pRcpNo As String, pNoVoucher As Boolean) As String
        Return "
select id.BranchCode,r.ReceiptNo,
r.ReceiptItemNo as ItemNo,r.CreditAmount,
r.TransferAmount,
r.CashAmount,r.ChequeAmount,r.ControlNo,r.VoucherNo,r.ControlItemNo,
ih.DocNo as InvoiceNo,ih.DocDate as InvoiceDate,id.ItemNo as InvoiceItemNo,
id.SICode,id.SDescription,id.VATRate,id.Rate50Tavi,
ISNULL(r.ReceivedAmt,0)-ISNULL(id.AmtCredit,0) as Amt,
ISNULL(r.ReceivedVat,0) as AmtVAT,
ISNULL(r.ReceivedWht,0) as Amt50Tavi,
ISNULL(r.ReceivedNet,0)-ISNULL(id.AmtCredit,0) as Net,
id.CurrencyCode as DCurrencyCode,id.ExchangeRate as DExchangeRate,
(ISNULL(r.ReceivedAmt,0)-ISNULL(id.AmtCredit,0))/id.ExchangeRate as FAmt,
ISNULL(r.ReceivedVat,0)/id.ExchangeRate as FAmtVAT,
ISNULL(r.ReceivedWht,0)/id.ExchangeRate as FAmt50Tavi,
(ISNULL(r.ReceivedNet,0)-ISNULL(id.AmtCredit,0))/id.ExchangeRate as FNet,
ih.CustCode,ih.CustBranch,ih.BillToCustCode,ih.BillToCustBranch,ih.RefNo,
id.Amt-id.AmtCredit As InvAmt,id.AmtVat as InvVat,id.Amt50Tavi as Inv50Tavi,id.TotalAmt-id.AmtCredit as InvTotal,
id.AmtAdvance,id.AmtCharge,id.AmtDiscount,id.AmtCredit,
ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,r.ReceiptDate,bh.DuePaymentDate
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join Job_BillAcceptHeader bh ON ih.BranchCode=bh.BranchCode AND ih.BillAcceptNo=bh.BillAcceptNo
inner join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
	rd.Amt as ReceivedAmt,
	rd.AmtVAT as ReceivedVat,
	rd.Amt50Tavi as ReceivedWht,
	rd.Net as ReceivedNet,
    rd.CreditAmount,rd.CashAmount,rd.ChequeAmount,rd.TransferAmount,
    rd.ReceiptNo,rh.ReceiptDate,
    rd.ItemNo as ReceiptItemNo,rd.ControlNo,rd.ControlItemNo,rd.VoucherNo
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	WHERE ISNULL(rh.CancelProve,'')='' 
    " & If(pRcpNo <> "", " AND rh.ReceiptNo='" & pRcpNo & "' ", "") & "
    " & If(pNoVoucher, " AND ISNULL(rd.ControlNo,'')=''", "") & "
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
"
    End Function
    Function SQLSelectDocumentByJob(branch As String, job As String) As String
        Dim sql As String = "
SELECT ISNULL(ah.PaymentDate,ah.AdvDate) as DocDate,ah.AdvNo as DocNo,'ADV' as DocType,ad.SDescription as Expense,ad.AdvNet as Amount,cf.ConfigValue as DocStatus,ad.ItemNo
,(CASE WHEN ah.DocStatus=99 THEN 1 ELSE 0 END) as IsCancel
FROM Job_AdvHeader ah INNER JOIN Job_AdvDetail ad ON ah.BranchCode=ad.BranchCode AND ah.AdvNo=ad.AdvNo 
INNER JOIN (SELECT * FROM Mas_Config WHERE ConfigCode='ADV_STATUS') cf ON ah.DocStatus=Convert(int,cf.ConfigKey)
WHERE ad.BranchCode='{0}' AND ad.ForJNo='{1}' 
UNION 
SELECT ISNULL(ch.ApproveDate,ch.ClrDate) as DocDate,ch.ClrNo as DocNo,'CLR' as DocType,cd.SDescription+ (CASE WHEN cd.SlipNO<>'' THEN ' #'+cd.SlipNo ELSE '' END) as Expense,
cd.BNet as Amount,cf.ConfigValue as DocStatus,cd.ItemNo
,(CASE WHEN ch.DocStatus=99 THEN 1 ELSE 0 END) as IsCancel
FROM Job_ClearHeader ch INNER JOIN Job_ClearDetail cd ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
INNER JOIN (SELECT * FROM Mas_Config WHERE ConfigCode='CLR_STATUS') cf ON ch.DocStatus=Convert(int,cf.ConfigKey)
WHERE cd.BranchCode='{0}' AND cd.JobNo='{1}' 
UNION
SELECT ih.DocDate,ih.DocNo,'INV' as DocType,id.SDescription,cd.BNet as Amount,(CASE WHEN ISNULL(ih.BillAcceptNo,'')='' THEN 'UNBILL' ELSE 'BILLED' END) as DocStatus,id.ItemNo
,(CASE WHEN ISNULL(ih.CancelProve,'')<>'' THEN 1 ELSE 0 END) as IsCancel
FROM Job_InvoiceHeader ih INNER JOIN Job_InvoiceDetail id ON ih.BranchCode=id.BranchCode AND ih.DocNo=id.DocNo
INNER JOIN Job_ClearDetail cd ON id.BranchCode=cd.BranchCode AND id.DocNo=cd.LinkBillNo AND id.ItemNo=cd.LinkItem
WHERE cd.BranchCode='{0}' AND cd.JobNo='{1}' 
UNION
select ch.ChqDate,ch.ChqNo,'CHQ' as DocType,Convert(varchar,ch.ChqAmount) +' '+ ch.CurrencyCode +' REF# '+ch.PRVoucher+' ('+vc.ControlNo+')' as Descr,ch.ChqAmount-SUM(ISNULL(cd.PaidAmount,0)) as Amount,
(CASE WHEN ISNULL(vc.PostedBy,'')<>'' THEN 'POSTED' ELSE (CASE WHEN vc.CancelProve<>'' THEN 'CANCEL' ELSE 'ACTIVE' END) END) as DocStatus,ch.ItemNo
,(CASE WHEN ISNULL(vc.CancelProve,'')<>'' THEN 1 ELSE 0 END) as IsCancel
FROM Job_CashControlSub ch INNER JOIN Job_CashControl vc ON ch.BranchCode=vc.BranchCode AND ch.ControlNo=vc.ControlNo
LEFT JOIN Job_CashControlDoc cd ON ch.BranchCode=cd.BranchCode AND ch.ControlNo=cd.ControlNo AND ch.acType=cd.acType
WHERE ch.BranchCode='{0}' AND ch.ForJNo='{1}'
GROUP BY ch.ChqDate,ch.ChqNo,ch.ChqAmount,ch.PRVoucher,vc.ControlNo,vc.PostedBy,vc.CancelProve,ch.CurrencyCode,ch.ItemNo
UNION
select rh.ReceiptDate,rh.ReceiptNo,'RCV' as DocType,rd.SDescription +' INV#' + rd.InvoiceNo as Descr,cd.BNet as Amount,
(CASE WHEN rh.CancelProve<>'' THEN 'CANCEL' ELSE (CASE WHEN ISNULL(rd.ControlNo,'')<>'' THEN 'RECEIVED' ELSE 'ACTIVE' END) END) as DocStatus,rd.ItemNo
,(CASE WHEN ISNULL(rh.CancelProve,'')<>'' THEN 1 ELSE 0 END) as IsCancel
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
INNER JOIN Job_ClearDetail cd ON rd.InvoiceNo=cd.LinkBillNo AND rd.InvoiceItemNo=cd.LinkItem
WHERE cd.BranchCode='{0}' AND cd.JobNo='{1}'
"
        Return String.Format(sql, branch, job)
    End Function
    Function SQLSelectSumReceipt(sqlw As String) As String
        Dim sql As String = "
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.InvNo, dbo.Job_Order.CustCode, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, SUM(dbo.Job_ReceiptDetail.Net) AS SumReceipt,
dbo.Job_Order.Commission, dbo.Job_ReceiptDetail.InvoiceNo, dbo.Job_ReceiptDetail.ReceiptNo, SUM(dbo.Job_ReceiptDetail.Net) * (dbo.Job_Order.Commission * 0.01) AS TotalComm
FROM dbo.Job_ClearDetail INNER JOIN
 dbo.Job_ClearHeader ON dbo.Job_ClearDetail.BranchCode = dbo.Job_ClearHeader.BranchCode INNER JOIN
 dbo.Job_ReceiptDetail ON dbo.Job_ClearDetail.BranchCode = dbo.Job_ReceiptDetail.BranchCode AND 
 dbo.Job_ClearDetail.LinkItem = dbo.Job_ReceiptDetail.InvoiceItemNo AND dbo.Job_ClearDetail.LinkBillNo = dbo.Job_ReceiptDetail.InvoiceNo INNER JOIN
 dbo.Job_ReceiptHeader ON dbo.Job_ReceiptDetail.BranchCode = dbo.Job_ReceiptHeader.BranchCode AND 
 dbo.Job_ReceiptDetail.ReceiptNo = dbo.Job_ReceiptHeader.ReceiptNo INNER JOIN
 dbo.Job_Order ON dbo.Job_ClearDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_ClearDetail.JobNo = dbo.Job_Order.JNo INNER JOIN
 dbo.Job_InvoiceHeader ON dbo.Job_ReceiptDetail.BranchCode = dbo.Job_InvoiceHeader.BranchCode AND 
 dbo.Job_ReceiptDetail.InvoiceNo = dbo.Job_InvoiceHeader.DocNo
WHERE (ISNULL(dbo.Job_InvoiceHeader.CancelProve, '') = '') AND (ISNULL(dbo.Job_ReceiptHeader.ReceiveRef, '') <> '') AND (dbo.Job_ClearHeader.DocStatus <> 99)  {0}
GROUP BY dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.InvNo, dbo.Job_Order.CustCode, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Commission, 
 dbo.Job_ReceiptDetail.InvoiceNo, dbo.Job_ReceiptDetail.ReceiptNo
"
        Return String.Format(sql, sqlw)
    End Function
    Function SQLSelectReceiptSummaryByInv(sqlW As String) As String
        Dim sql As String = "
SELECT ih.BranchCode,ih.DocNo,rh.ReceiptNo,rh.ReceiptDate as ReceiveDate,rh.ReceiptType,c1.UsedLanguage,ih.CurrencyCode,ih.ExchangeRate,
rh.CustCode,rh.CustBranch,rh.BillToCustCode,rh.BillToCustBranch,
c1.Title + ' '+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+' '+c1.TAddress2 as CustTAddr,c1.EAddress1+' '+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + ' '+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+' '+c2.TAddress2 as BillTAddr,c2.EAddress1+' '+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.InvoiceNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
Sum(id.AmtCharge) as AmtCharge,Sum(id.AmtAdvance) as AmtAdvance,Sum(id.Amt-id.AmtDiscount) as InvAmt,
Sum(CASE WHEN id.AmtCharge >0 THEN id.AmtVat ELSE 0 END) as InvVAT,
Sum(CASE WHEN id.AmtCharge >0 THEN id.Amt50Tavi ELSE 0 END) as Inv50Tavi,
Sum(id.TotalAmt) as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT ',' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=ih.BranchCode
    AND LinkBillNo=ih.DocNo 
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT ',' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=ih.BranchCode
    AND LinkBillNo=ih.DocNo 
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT ',' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=ih.BranchCode
    AND LinkBillNo=ih.DocNo 
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as AdvNo,
Sum(rd.Amt) as Amt,Sum(rd.FAmt) as FAmt,Sum(CASE WHEN id.AmtCharge >0 THEN rd.AmtVAT ELSE 0 END) as AmtVAT,
Sum(CASE WHEN id.AmtCharge>0 THEN rd.FAmtVAT ELSE 0 END) as FAmtVAT,
Sum(CASE WHEN id.AmtCharge>0 THEN rd.Amt50Tavi ELSE 0 END) as Amt50Tavi,
Sum(CASE WHEN id.AmtCharge>0 THEN rd.FAmt50Tavi ELSE 0 END) as FAmt50Tavi,
Sum(rd.Net) as Net,Sum(rd.FNet) as FNet,
Max(rd.ControlNo) as ControlNo,Max(vd.ChqNo) as ChqNo,Max(vd.ChqDate) as ChqDate,Max(vd.PRVoucher) as PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
LEFT JOIN Job_CashControlSub vd ON rd.BranchCode=vd.BranchCode AND rd.ControlNo=vd.ControlNo AND rd.ControlItemNo=vd.ItemNo
{0}
GROUP BY ih.BranchCode,ih.DocNo,rh.ReceiptNo,rh.ReceiptDate,rh.ReceiptType,c1.UsedLanguage,ih.CurrencyCode,ih.ExchangeRate,
c1.Title , c1.NameThai,c1.NameEng,c1.TAddress1,c1.TAddress2,c1.EAddress1,c1.EAddress2,c1.Phone,c1.TaxNumber,
c2.Title , c2.NameThai,c2.NameEng,c2.TAddress1,c2.TAddress2,c2.EAddress1,c2.EAddress2,c2.Phone,c2.TaxNumber,
rd.InvoiceNo,ih.DocDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,rh.CustCode,rh.CustBranch,rh.BillToCustCode,rh.BillToCustBranch,ih.RefNo
"
        Return String.Format(sql, sqlW)
    End Function
    Function SQLSelectReceiptReport() As String
        Dim sql As String = "
SELECT rh.*,c1.UsedLanguage,
c1.Title + ' '+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+' '+c1.TAddress2 as CustTAddr,c1.EAddress1+' '+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + ' '+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+' '+c2.TAddress2 as BillTAddr,c2.EAddress1+' '+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
c1.TProvince as CustProvince,c2.TProvince as BillProvince,c1.TPostCode as CustPostCode,c2.TPostCode as BillPostCode,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT ',' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT ',' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT ',' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'')<>''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'')<>''
LEFT JOIN (
select a.BranchCode,SUBSTRING(a.DocNo,0,CHARINDEX('#',a.DocNo)) as InvoiceNo,
SUBSTRING(a.DocNo,CHARINDEX('#',a.DocNo)+1,4) as InvoiceItem,
MAX(b.ChqNo) as ChqNo,MAX(b.ChqDate) as ChqDate,MAX(b.PRVoucher) as PRVoucher
from Job_CashControlDoc a inner join Job_CashControlSub b
on a.BranchCode=b.BranchCode and a.ControlNo=b.ControlNo and a.acType=b.acType 
WHERE a.DocType='INV'
GROUP BY a.BranchCode,SUBSTRING(a.DocNo,0,CHARINDEX('#',a.DocNo)),
SUBSTRING(a.DocNo,CHARINDEX('#',a.DocNo)+1,4)
) vd ON id.BranchCode=vd.BranchCode AND id.DocNo=vd.InvoiceNo AND id.ItemNo=vd.InvoiceItem
"
        Return sql
    End Function
    Function SQLSelectServiceBudget() As String
        Return "
SELECT a.*,b.ID,b.TRemark,b.MaxAdvance,b.MaxCost,b.MinCharge,b.MinProfit,b.Active,b.LastUpdate,b.UpdateBy
FROM Job_SrvSingle a LEFT JOIN Job_BudgetPolicy b
ON a.SICode=b.SICode 
"
    End Function
    Function SQLSelectQuotation() As String
        Return "
SELECT dbo.Job_QuotationHeader.BranchCode, dbo.Job_QuotationHeader.QNo, dbo.Job_QuotationHeader.ReferQNo, dbo.Job_QuotationHeader.CustCode, 
    dbo.Job_QuotationHeader.CustBranch, dbo.Job_QuotationHeader.BillToCustCode, dbo.Job_QuotationHeader.BillToCustBranch, 
    dbo.Job_QuotationHeader.ContactName, dbo.Job_QuotationHeader.DocDate, dbo.Job_QuotationHeader.ManagerCode, dbo.Job_QuotationHeader.DescriptionH, 
    dbo.Job_QuotationHeader.DescriptionF, dbo.Job_QuotationHeader.TRemark, dbo.Job_QuotationHeader.DocStatus, dbo.Job_QuotationHeader.ApproveBy, 
    dbo.Job_QuotationHeader.ApproveDate, dbo.Job_QuotationHeader.ApproveTime, dbo.Job_QuotationHeader.CancelBy, dbo.Job_QuotationHeader.CancelDate, 
    dbo.Job_QuotationHeader.CancelReason, dbo.Job_QuotationDetail.JobType, dbo.Job_QuotationDetail.ShipBy, dbo.Job_QuotationDetail.Description, 
    dbo.Job_QuotationDetail.SeqNo, dbo.Job_QuotationItem.ItemNo, dbo.Job_QuotationItem.IsRequired, dbo.Job_QuotationItem.NetProfit, dbo.Job_QuotationItem.CommissionAmt, 
    dbo.Job_QuotationItem.CommissionPerc, dbo.Job_QuotationItem.BaseProfit, dbo.Job_QuotationItem.VenderCost, dbo.Job_QuotationItem.VenderCode, 
    dbo.Job_QuotationItem.UnitDiscntAmt, dbo.Job_QuotationItem.UnitDiscntPerc, dbo.Job_QuotationItem.TotalCharge, dbo.Job_QuotationItem.TotalAmt, 
    dbo.Job_QuotationItem.TaxAmt, dbo.Job_QuotationItem.TaxRate, dbo.Job_QuotationItem.IsTax, dbo.Job_QuotationItem.VatAmt, dbo.Job_QuotationItem.VatRate, 
    dbo.Job_QuotationItem.Isvat, dbo.Job_QuotationItem.ChargeAmt, dbo.Job_QuotationItem.CurrencyRate, dbo.Job_QuotationItem.CurrencyCode, 
    dbo.Job_QuotationItem.UnitCheck, dbo.Job_QuotationItem.QtyEnd, dbo.Job_QuotationItem.QtyBegin, dbo.Job_QuotationItem.CalculateType, 
    dbo.Job_QuotationItem.DescriptionThai, dbo.Job_QuotationItem.SICode
FROM dbo.Job_QuotationHeader INNER JOIN
    dbo.Job_QuotationDetail ON dbo.Job_QuotationHeader.BranchCode = dbo.Job_QuotationDetail.BranchCode AND 
    dbo.Job_QuotationHeader.QNo = dbo.Job_QuotationDetail.QNo INNER JOIN
    dbo.Job_QuotationItem ON dbo.Job_QuotationDetail.BranchCode = dbo.Job_QuotationItem.BranchCode AND 
    dbo.Job_QuotationDetail.QNo = dbo.Job_QuotationItem.QNo AND dbo.Job_QuotationDetail.SeqNo = dbo.Job_QuotationItem.SeqNo
"
    End Function
    Function SQLSelectPaymentSummary() As String
        Return "
SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.ApproveBy ,h.ApproveDate,
h.ApproveTime, h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, h.ApproveRef,h.PaymentRef,
d.ForJNo as JobNo, d.BookingRefNo, d.BookingItemNo , h.AdvRef , j.CustCode,j.CustBranch,
SUM(d.Amt- d.AmtDisc) as Amt,SUM(d.AmtVAT) as AmtVat,SUM(d.AmtWHT) as AmtTax50Tavi,SUM(d.Total) as Total,
SUM(d.FTotal) as FTotal
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
{0}
GROUP BY h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.ApproveBy ,h.ApproveDate,
h.ApproveTime, h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, h.ApproveRef,h.PaymentRef,
d.ForJNo, d.BookingRefNo, d.BookingItemNo , h.AdvRef , j.CustCode,j.CustBranch
"
    End Function
    Function SQLSelectPaymentReport() As String
        Return "
SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.ApproveBy ,h.ApproveDate,
h.ApproveTime, h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, h.ApproveRef,h.PaymentRef, d.ItemNo, d.SICode, d.SDescription, d.SRemark, d.Qty, d.QtyUnit, d.UnitPrice, d.IsTaxCharge, 
d.Is50Tavi, d.DiscountPerc, d.Amt, d.AmtDisc, d.AmtVAT, d.AmtWHT, d.Total, d.FTotal, d.ForJNo, d.BookingRefNo, d.BookingItemNo , h.AdvRef , j.CustCode,j.CustBranch,d.ClrRefNo,d.ClrItemNo 
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
"
    End Function
    Function GetJobPrefix(data As CJobOrder) As String
        Dim formatStr As String = GetValueConfig("RUNNING_FORMAT", "JOBNO", jobPrefix)
        Dim jobType As String = GetValueConfig("JOB_TYPE", data.JobType.ToString("00"))
        Dim shipBy As String = GetValueConfig("SHIP_BY", data.ShipBy.ToString("00"))
        Dim Customer As String = data.CustCode
        If jobType <> "" Then formatStr = formatStr.Replace("[J]", jobType.Substring(0, 1))
        If shipBy <> "" Then formatStr = formatStr.Replace("[S]", shipBy.Substring(0, 1))
        If Customer <> "" Then formatStr = formatStr.Replace("[C]", Customer.Substring(0, 3))
        Return formatStr
    End Function
    Function SaveLog(cust As String, app As String, modl As String, action As String, msg As String, isError As Boolean, Optional StackTrace As String = "", Optional JsonData As String = "") As String
        Try
            Dim isSaveLog = "Y"
            If GetSession("ConnJob") <> "" Then
                isSaveLog = Main.GetValueConfig("PROFILE", "SAVE_LOG", "Y")
            End If
            If isSaveLog = "N" Then
                Return "Save Log Is not activated"
            Else
                Dim clientIP = HttpContext.Current.Request.UserHostAddress
                Dim userLogin = GetSession("CurrUser").ToString()
                If userLogin <> "" Then
                    Dim sessionID = HttpContext.Current.Session.SessionID
                    Dim cnMas = ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString
                    Dim oLog As New CLog(cnMas) With {
                    .AppID = app & "(" & sessionID & ")",
                    .CustID = cust & "/" & userLogin,
                    .FromIP = clientIP,
                    .ModuleName = modl,
                    .LogAction = action,
                    .Message = msg,
                    .StackTrace = StackTrace,
                    .JsonData = JsonData,
                    .IsError = isError
                }
                    Return oLog.SaveData(" WHERE LogID=0 ")
                Else
                    Return "Save Log Session Expire"
                End If
            End If
        Catch ex As Exception
            Dim str = "[ERROR] : " & ex.Message
            Return str
        End Try
    End Function
    Function SaveLogFromObject(cust As String, app As String, modl As String, action As String, obj As Object, IsError As Boolean, Optional StackTrace As String = "") As String
        Dim isSaveLog = "Y"
        If GetSession("ConnJob") <> "" Then
            isSaveLog = Main.GetValueConfig("PROFILE", "SAVE_LOG", "Y")
        End If
        If isSaveLog = "N" Then
            Return "Save log is Not activated"
        Else
            Try
                Dim clientIP = HttpContext.Current.Request.UserHostAddress
                Dim userLogin = GetSession("CurrUser").ToString()
                Dim sessionID = HttpContext.Current.Session.SessionID
                Dim cnMas = ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString
                Dim oLog As New CLog(cnMas) With {
                    .AppID = app & "(" & SessionId & ")",
                    .CustID = cust & "/" & userLogin,
                    .FromIP = clientIP,
                    .ModuleName = modl,
                    .LogAction = action,
                    .Message = If(IsError = True, "ERROR", "SUCCESS"),
                    .JsonData = JsonConvert.SerializeObject(obj),
                    .StackTrace = StackTrace,
                    .IsError = IsError
                }
                Return oLog.SaveData(" WHERE LogID=0 ")
            Catch ex As Exception
                Main.SaveLog(cust, app, modl, "SaveLogFromObject", ex.Message, True, ex.StackTrace, "")
                Dim str = "[ERROR] : " & ex.Message
                Return str
            End Try
        End If
    End Function
    Function GetDatabaseList(pCustomer As String, pApp As String) As List(Of String)
        Dim db = New List(Of String)
        Dim cnMas = ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString
        Try
            Dim tb = New CUtil(cnMas).GetTableFromSQL(String.Format("SELECT * FROM TWTCustomerApp WHERE CustID='{0}' AND AppID='{1}' ", pCustomer, pApp))
            If tb.Rows.Count > 0 Then
                For Each dr As DataRow In tb.Rows
                    'db.Add(dr("WebTranDB").ToString()) 'Change 2021/01/04 by Phuthipong
                    db.Add(dr("Comment").ToString())
                Next
            End If
        Catch ex As Exception

        End Try
        Return db
    End Function
    Function GetDatabaseProfile(pCustomer As String, dbID As String) As DataTable
        Dim cnMas = ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString
        If dbID = "" Then
            Dim tb = New CUtil(cnMas).GetTableFromSQL(String.Format("SELECT a.*,b.Comment FROM TWTCustomer a INNER JOIN TWTCustomerApp b ON a.CustID=b.CustID WHERE a.CustID='{0}' ", pCustomer))
            Return tb
        Else
            Dim tb = New CUtil(cnMas).GetTableFromSQL(String.Format("SELECT a.*,b.Comment FROM TWTCustomer a INNER JOIN TWTCustomerApp b ON a.CustID=b.CustID WHERE a.CustID='{0}' AND b.Seq={1} ", pCustomer, dbID))
            Return tb
        End If
    End Function
    Function GetApplicationProfile(pCustomer As String) As DataTable
        Dim cnMas = ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString
        Dim tb = New CUtil(cnMas).GetTableFromSQL(String.Format("SELECT a.*,b.SubscriptionName,b.Edition,b.BeginDate,b.ExpireDate,b.LoginCount FROM TWTCustomerApp a INNER JOIN TWTSubscription b ON a.SubscriptionID=b.SubScriptionID WHERE a.CustID='{0}' AND a.AppID='JOBSHIPPING' ", pCustomer))
        Return tb
    End Function
    Function GetDatabaseConnection(pCustomer As String, pApp As String, pSeq As String) As String()
        Dim db = New String() {"", ""}
        Try
            Dim cnMas = ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString
            Using tb As DataTable = New CUtil(cnMas).GetTableFromSQL(String.Format("SELECT * FROM TWTCustomerApp WHERE CustID='{0}' AND AppID='{1}' AND Seq='{2}'", pCustomer, pApp, pSeq))
                If tb.Rows.Count > 0 Then
                    db = New String() {tb.Rows(0)("WebTranConnect").ToString, tb.Rows(0)("WebMasConnect").ToString}
                    jobmaster = tb.Rows(0)("WebMasDB").ToString()
                End If
            End Using
        Catch ex As Exception

        End Try
        Return db
    End Function
    Function SetDatabaseMaster(pDBName As String) As Boolean
        Try
            Dim bChk As Boolean = False
            Using cn As New SqlConnection(pDBName)
                cn.Open()
                bChk = (cn.State = ConnectionState.Open)
                Return bChk
            End Using
            Return True
        Catch ex As Exception
            Main.SaveLog(My.Settings.LicenseTo, "JOBSHIPPING", "SetDataBaseMaster", "OpenConnection", ex.Message, True, ex.StackTrace, pDBName)
            Return False
        End Try
    End Function
    Function SetDatabaseJob(pDBName As String) As Boolean
        Try
            Dim bChk As Boolean = False
            Using cn As New SqlConnection(pDBName)
                cn.Open()
                bChk = (cn.State = ConnectionState.Open)
                Return bChk
            End Using
            Return True
        Catch ex As Exception
            Main.SaveLog(My.Settings.LicenseTo, "JOBSHIPPING", "SetDataBaseJob", "OpenConnection", ex.Message, True, ex.StackTrace, pDBName)
            Return False
        End Try
    End Function
    Public Function SQLSelectJobCount(tsqlW As String, tGroup As String) As String
        Dim oCfg = Main.GetDataConfig("JOB_STATUS")
        Dim sqlCheckStatus As String = ""
        For Each cfg In oCfg
            sqlCheckStatus &= ",SUM("
            sqlCheckStatus &= "CASE WHEN j.JobStatus=" & Convert.ToInt16(cfg.ConfigKey) & " THEN 1 ELSE 0 END"
            sqlCheckStatus &= ") as '" & cfg.ConfigValue & "'"
        Next
        'If sqlCheckStatus = "" Then
        sqlCheckStatus &= ",COUNT(*) as TotalJob"
        'End If
        Dim sql = "
SELECT " & tGroup & "
" & sqlCheckStatus & "
FROM Job_Order j {0}
GROUP BY " & tGroup
        sql = String.Format(sql, tsqlW)
        Return sql

    End Function
    Public Function SQLDashboard3(tSqlW As String) As String
        Dim oCfg = Main.GetDataConfig("JOB_STATUS")
        Dim sqlCheckStatus As String = ""
        For Each cfg In oCfg
            sqlCheckStatus &= ",SUM("
            sqlCheckStatus &= "CASE WHEN j.JobStatus=" & Convert.ToInt16(cfg.ConfigKey) & " THEN 1 ELSE 0 END"
            sqlCheckStatus &= ") as '" & cfg.ConfigValue & "'"
        Next
        If sqlCheckStatus = "" Then
            sqlCheckStatus = ",COUNT(*) as TotalJob"
        End If
        Dim sql = "
SELECT j.CustCode
" & sqlCheckStatus & "
FROM Job_Order j {0}
GROUP BY j.CustCode
"
        sql = String.Format(sql, tSqlW)
        Return sql
    End Function
    Public Function SQLDashboard5(tSqlW As String) As String
        Dim oCfg = Main.GetDataConfig("JOB_STATUS")
        Dim sqlCheckStatus As String = ""
        For Each cfg In oCfg
            sqlCheckStatus &= ",SUM("
            sqlCheckStatus &= "CASE WHEN j.JobStatus=" & Convert.ToInt16(cfg.ConfigKey) & " THEN 1 ELSE 0 END"
            sqlCheckStatus &= ") as '" & cfg.ConfigValue & "'"
        Next
        If sqlCheckStatus = "" Then
            sqlCheckStatus = ",COUNT(*) as TotalJob"
        End If
        Dim sql = "
SELECT j.CSCode
" & sqlCheckStatus & "
FROM Job_Order j {0}
GROUP BY j.CSCode
ORDER BY j.CSCode
"
        sql = String.Format(sql, tSqlW)
        Return sql
    End Function
    Public Function SQLDashboard2(tSqlW As String) As String
        Dim oCfg = Main.GetDataConfig("JOB_STATUS")
        Dim sqlCheckStatus As String = ""
        For Each cfg In oCfg
            sqlCheckStatus &= ",SUM("
            sqlCheckStatus &= "CASE WHEN j.JobStatus=" & Convert.ToInt16(cfg.ConfigKey) & " THEN 1 ELSE 0 END"
            sqlCheckStatus &= ") as '" & cfg.ConfigValue & "'"
        Next
        If sqlCheckStatus = "" Then
            sqlCheckStatus = ",COUNT(*) as TotalJob"
        End If
        Dim sql = "
SELECT j.ShipBy
" & sqlCheckStatus & "
FROM Job_Order j {0}
GROUP BY j.ShipBy
"
        sql = String.Format(sql, tSqlW)
        Return sql
    End Function
    Public Function SQLDashboard4(tSqlW As String) As String
        Dim oCfg = Main.GetDataConfig("JOB_STATUS")
        Dim sqlCheckStatus As String = ""
        For Each cfg In oCfg
            sqlCheckStatus &= ",SUM("
            sqlCheckStatus &= "CASE WHEN j.JobStatus=" & Convert.ToInt16(cfg.ConfigKey) & " THEN 1 ELSE 0 END"
            sqlCheckStatus &= ") as '" & cfg.ConfigValue & "'"
        Next
        If sqlCheckStatus = "" Then
            sqlCheckStatus = ",COUNT(*) as TotalJob"
        End If
        Dim sql = "
SELECT j.JobType
" & sqlCheckStatus & "
FROM Job_Order j {0}
GROUP BY j.JobType
"
        sql = String.Format(sql, tSqlW)
        Return sql
    End Function
    Public Function SQLDashboard1(tSqlW As String) As String
        Dim sql = "
SELECT j.JobStatus,
COUNT(*) as TotalJob
FROM Job_Order j {0}
GROUP BY j.JobStatus
"
        sql = String.Format(sql, tSqlW)
        Return sql
    End Function
    Public Function SQLSelectClearExp() As String
        Dim sql = "
SELECT a.BranchCode,a.JNo,a.SICode,a.SDescription,a.TRemark,a.AmountCharge,a.Status,
a.CurrencyCode,a.ExchangeRate,a.Qty,a.QtyUnit,a.AmtVatRate,a.AmtVat,a.AmtWhtRate,a.AmtWht,
a.AmtTotal,b.ClrNo,b.CostAmount,b.ChargeAmount
FROM dbo.Job_ClearExp a
LEFT JOIN (
SELECT BranchCode,JobNo,SICode,SUM(BCost) as CostAmount,SUM(BPrice) as ChargeAmount,Max(ClrNo) as ClrNo
FROM dbo.Job_ClearDetail WHERE ClrNo NOT IN (SELECT ClrNo FROM Job_ClearHeader WHERE DocStatus=99)
GROUP BY BranchCode,JobNo,SICode
) b
ON a.BranchCode=b.BranchCode AND a.JNo=b.JobNo AND a.SICode=b.SICode
"
        Return sql
    End Function
    Public Function SQLSelectTrackingCount(tSqlW As String) As String
        Dim sql As String = "
SELECT t.JobStatus,COUNT(DISTINCT t.JNo) AS TotalJob FROM (" & SQLSelectTracking(tSqlW) & ") as t GROUP BY t.JobStatus 
"
        Return sql
    End Function
    Public Function SQLSelectTrackingDay(useDay As String, onDate As Date, cutoffDay As Integer, tSQLW As String) As String
        Dim oCfg = Main.GetDataConfig("JOB_TYPE")
        Dim sqlCheckStatus As String = ""
        For Each cfg In oCfg
            sqlCheckStatus &= ",SUM(CASE WHEN JobType=" & CInt(cfg.ConfigKey) & " THEN 1 ELSE 0 END)"
            sqlCheckStatus &= " as '" & cfg.ConfigValue & "'"
        Next
        Dim sqlGroup As String = "
(CASE WHEN Day(" & useDay & ") <=Day(DATEADD(d,-" & cutoffDay & ",'" & onDate.ToString("yyyy-MM-dd") & "')) THEN '00' ELSE 
(CASE WHEN Day(" & useDay & ") >=Day(DATEADD(d," & cutoffDay & ",'" & onDate.ToString("yyyy-MM-dd") & "')) THEN '99' ELSE FORMAT(" & useDay & ",'dd/MM/yy') END)
END)
"
        Dim sql As String = "
SELECT 
" & sqlGroup & " as JobDay
" & sqlCheckStatus & "
FROM Job_Order WHERE JobStatus<90 AND " & useDay & " IS NOT NULL
" & tSQLW & "
GROUP BY " & sqlGroup & "
ORDER BY 1
"
        Return sql
    End Function
    Public Function SQLSelectTracking(tsqlW As String) As String
        Dim sql = "
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, dbo.Job_LoadInfo.BookingNo, 
dbo.Job_LoadInfo.LoadDate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, 
dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, 
dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, 
dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.CauseCode, 
dbo.Job_LoadInfoDetail.Comment, dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, 
dbo.Job_LoadInfoDetail.TargetYardTime, dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, 
dbo.Job_LoadInfoDetail.UnloadFinishDate, dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, 
dbo.Job_LoadInfoDetail.Location, dbo.Job_LoadInfoDetail.ReturnDate AS TruckReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, 
dbo.Job_LoadInfoDetail.ProductDesc, dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, 
dbo.Job_LoadInfoDetail.GrossWeight, dbo.Job_LoadInfoDetail.Measurement, dbo.Job_Order.DocDate, dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, 
dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, 
dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.ClearPort, 
dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, 
dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, 
dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.EstDeliverDate, 
dbo.Job_Order.EstDeliverTime, dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, 
dbo.Job_Order.TotalGW, dbo.Job_Order.GWUnit, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, dbo.Job_Order.CommPayTo, 
dbo.Job_Order.MVesselName, dbo.Job_Order.ProjectName, dbo.Job_Order.TotalNW, dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, 
dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, dbo.Job_LoadInfoDetail.DeliveryNo, dbo.Job_Order.DeliveryTo, 
dbo.Job_Order.DeliveryAddr, dbo.Job_Order.ShippingCmd, dbo.Mas_Company.NameThai, dbo.Mas_Company.NameEng, dbo.Mas_Company.TAddress1, 
dbo.Mas_Company.TAddress2, dbo.Mas_Company.EAddress1, dbo.Mas_Company.EAddress2, dbo.Mas_Company.Phone, dbo.Mas_Company.FaxNumber, 
dbo.Mas_Company.GLAccountCode, dbo.Mas_Company.BillToCustCode, dbo.Mas_Company.BillToBranch, dbo.Mas_Company.TaxNumber
FROM  dbo.Mas_Company RIGHT OUTER JOIN
dbo.Job_Order LEFT OUTER JOIN
dbo.Mas_Vender RIGHT OUTER JOIN
dbo.Job_LoadInfo RIGHT OUTER JOIN
dbo.Job_LoadInfoDetail ON dbo.Job_LoadInfo.BranchCode = dbo.Job_LoadInfoDetail.BranchCode AND 
dbo.Job_LoadInfo.BookingNo = dbo.Job_LoadInfoDetail.BookingNo
ON dbo.Mas_Vender.BranchCode = dbo.Job_LoadInfo.BranchCode ON 
dbo.Job_Order.JNo = dbo.Job_LoadInfoDetail.JNo AND dbo.Job_Order.BranchCode = dbo.Job_LoadInfoDetail.BranchCode ON 
dbo.Mas_Company.Branch = dbo.Job_Order.CustBranch AND dbo.Mas_Company.CustCode = dbo.Job_Order.CustCode
WHERE (dbo.Job_Order.JobStatus < '90') {0}
"
        Return String.Format(sql, tsqlW)
    End Function
    Public Function SQLSelectTransport(tsqlW As String) As String
        Dim sql = "
SELECT dbo.Job_LoadInfo.BranchCode, dbo.Job_LoadInfo.JNo, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, dbo.Job_LoadInfo.BookingNo, 
dbo.Job_LoadInfo.LoadDate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, 
dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, 
dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, 
dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.CYContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, 
dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.CauseCode, 
dbo.Job_LoadInfoDetail.Comment, dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, 
dbo.Job_LoadInfoDetail.TargetYardTime, dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, 
dbo.Job_LoadInfoDetail.UnloadFinishDate, dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.Location, dbo.Job_LoadInfoDetail.ReturnDate AS TruckReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, 
dbo.Job_LoadInfoDetail.ProductDesc, dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit,dbo.Job_LoadInfoDetail.NetWeight,dbo.Job_LoadInfoDetail.ProductPrice, 
dbo.Job_LoadInfoDetail.GrossWeight, dbo.Job_LoadInfoDetail.Measurement,
dbo.Job_LoadInfoDetail.PlaceName1,dbo.Job_LoadInfoDetail.PlaceAddress1,dbo.Job_LoadInfoDetail.PlaceContact1, 
dbo.Job_LoadInfoDetail.PlaceName2,dbo.Job_LoadInfoDetail.PlaceAddress2,dbo.Job_LoadInfoDetail.PlaceContact2,
dbo.Job_LoadInfoDetail.PlaceName3,dbo.Job_LoadInfoDetail.PlaceAddress3,dbo.Job_LoadInfoDetail.PlaceContact3,
dbo.Job_LoadInfoDetail.PlaceName4,dbo.Job_LoadInfoDetail.PlaceAddress4,dbo.Job_LoadInfoDetail.PlaceContact4,
dbo.Job_Order.DocDate, dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, 
dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, 
dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.ClearPort, 
dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, 
dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, 
dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.EstDeliverDate, 
dbo.Job_Order.EstDeliverTime, dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.ConfirmDate, dbo.Job_Order.ShippingEmp, 
dbo.Job_Order.TotalGW, dbo.Job_Order.GWUnit, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, dbo.Job_Order.CommPayTo,
dbo.Job_Order.MVesselName, dbo.Job_Order.ProjectName, dbo.Job_Order.TotalNW, dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, 
dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, dbo.Job_LoadInfoDetail.DeliveryNo, dbo.Job_Order.DeliveryTo, 
dbo.Job_Order.DeliveryAddr,dbo.Job_Order.ShippingCmd, dbo.Mas_Company.NameThai, dbo.Mas_Company.NameEng, dbo.Mas_Company.TAddress1, dbo.Mas_Company.TAddress2, 
dbo.Mas_Company.EAddress1, dbo.Mas_Company.EAddress2, dbo.Mas_Company.Phone, dbo.Mas_Company.FaxNumber, dbo.Mas_Company.GLAccountCode, 
dbo.Mas_Company.BillToCustCode, dbo.Mas_Company.BillToBranch,dbo.Mas_Company.TaxNumber,
(CASE WHEN ISNULL(dbo.Job_LoadInfoDetail.CauseCode,'')<>'' THEN (case when dbo.Job_LoadInfoDetail.CauseCode='99' THEN 'Cancel' ELSE (CASE WHEN dbo.Job_LoadInfoDetail.CauseCode='3' THEN 'Finish' ELSE (CASE WHEN dbo.Job_LoadInfoDetail.CauseCode='2' THEN 'Reject' ELSE 'Working' END) END) END) ELSE 'Checking' END) as TruckStatus
FROM dbo.Mas_Company RIGHT OUTER JOIN
dbo.Job_Order RIGHT OUTER JOIN
dbo.Job_LoadInfoDetail ON dbo.Job_Order.JNo = dbo.Job_LoadInfoDetail.JNo AND 
dbo.Job_Order.BranchCode = dbo.Job_LoadInfoDetail.BranchCode RIGHT OUTER JOIN
dbo.Mas_Vender RIGHT OUTER JOIN
dbo.Job_LoadInfo ON dbo.Mas_Vender.BranchCode = dbo.Job_LoadInfo.BranchCode ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo 
ON dbo.Mas_Company.Branch = dbo.Job_Order.CustBranch AND 
dbo.Mas_Company.CustCode = dbo.Job_Order.CustCode
WHERE (dbo.Job_LoadInfo.BookingNo <> '') {0}
"
        Return String.Format(sql, tsqlW)
    End Function
    Function SQLUpdateGLHeader() As String
        Dim sql As String = "
UPDATE a
SET a.TotalDebit=ISNULL(b.SumDebit,0),
a.TotalCredit=ISNULL(b.SumCredit,0)
FROM Job_GLHeader a LEFT JOIN (
    SELECT BranchCode,GLRefNo,SUM(DebitAmt) as SumDebit,SUM(CreditAmt) as SumCredit
    FROM Job_GLDetail GROUP BY BranchCode,GLRefNo
) b
ON a.BranchCode=b.BranchCode AND a.GLRefNo=b.GLRefNo
"
        Return sql
    End Function
    Function SQLSelectRoleAll() As String
        Return "
SELECT a.UserID,SUBSTRING(b.ModuleID,1,CHARINDEX('/',b.ModuleID)-1) as ModuleCode,
SUBSTRING(b.ModuleID,CHARINDEX('/',b.ModuleID)+1,50) as ModuleFunc,
(CASE WHEN MAX(CASE WHEN CHARINDEX('M',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN 'M' ELSE '' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX('E',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN 'E' ELSE '' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX('I',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN 'I' ELSE '' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX('R',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN 'R' ELSE '' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX('D',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN 'D' ELSE '' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX('P',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN 'P' ELSE '' END) 
 as Authorize
FROM Mas_UserRolePolicy b,Mas_UserRoleDetail a
WHERE a.RoleID=b.RoleID {0}
GROUP BY a.UserID,b.ModuleID
"
    End Function
    Function SQLSelectBillDetail() As String
        Return "
SELECT a.BranchCode, a.BillAcceptNo, a.ItemNo, a.InvNo, a.AmtAdvance, a.AmtChargeNonVAT, a.AmtChargeVAT, a.AmtWH, a.AmtVAT, a.AmtTotal, a.CurrencyCode, 
a.ExchangeRate, a.AmtCustAdvance, a.AmtForeign, a.InvDate, a.RefNo, a.AmtVATRate, a.AmtWHRate, a.AmtDiscount, a.AmtDiscRate, b.DocDate, b.CustCode, 
b.CustBranch, b.BillToCustCode, b.BillToCustBranch, b.ContactName, b.EmpCode, b.PrintedBy, b.PrintedDate, b.PrintedTime, b.VATRate, b.TotalAdvance, 
b.TotalCharge, b.TotalIsTaxCharge, b.TotalIs50Tavi, b.TotalVAT, b.Total50Tavi, b.TotalCustAdv, b.TotalNet, b.ForeignNet, b.BillAcceptDate, b.BillIssueDate, 
b.Remark1, b.Remark2, b.Remark3, b.Remark4, b.Remark5, b.Remark6, b.Remark7, b.Remark8, b.Remark9, b.Remark10, b.CancelReson, b.CancelProve, 
b.CancelDate, b.CancelTime, b.ShippingRemark, b.SumDiscount, b.DiscountRate, b.DiscountCal, b.TotalDiscount, b.DueDate, b.CreateDate, c.TaxNumber, 
c.Title + '' + c.NameThai AS CustTName, c.NameEng AS CustEName,d.Total50Tavi1 as AmtWH1,d.Total50Tavi3 as AmtWH3
FROM dbo.Job_BillAcceptDetail AS a INNER JOIN
dbo.Job_InvoiceHeader AS b ON a.BranchCode = b.BranchCode AND a.InvNo = b.DocNo 
INNER JOIN (SELECT BranchCode,DocNo,
SUM(CASE WHEN Rate50Tavi=1 THEN Amt50Tavi ELSE 0 END) as Total50Tavi1,
SUM(CASE WHEN Rate50Tavi=1 THEN 0 ELSE Amt50Tavi END) as Total50Tavi3
FROM Job_InvoiceDetail GROUP BY BranchCode,DocNo) d
ON b.BranchCode=d.BranchCode AND b.DocNo=d.DocNo
INNER JOIN
dbo.Mas_Company AS c ON b.CustCode = c.CustCode AND b.CustBranch = c.Branch
"
    End Function
    Function SQLSelectBillReport() As String
        Dim sql = "
SELECT h.BranchCode, h.BillAcceptNo, h.BillDate, h.CustCode, h.CustBranch, h.BillRecvBy, h.BillRecvDate, h.DuePaymentDate, h.BillRemark, h.CancelReson, 
h.CancelProve, h.CancelDate, h.CancelTime, h.EmpCode, h.RecDateTime, h.TotalCustAdv, h.TotalAdvance, h.TotalChargeVAT, h.TotalChargeNonVAT, h.TotalVAT, 
h.TotalWH, h.TotalDiscount, h.TotalNet, d.ItemNo, d.InvNo, d.AmtAdvance, d.AmtChargeNonVAT, d.AmtChargeVAT, d.AmtWH, d.AmtVAT, d.AmtTotal, d.CurrencyCode, 
d.ExchangeRate, d.AmtCustAdvance, d.AmtForeign, d.InvDate, d.RefNo, d.AmtVATRate, d.AmtWHRate, d.AmtDiscount, d.AmtDiscRate
FROM dbo.Job_BillAcceptHeader AS h INNER JOIN
dbo.Job_BillAcceptDetail AS d ON h.BranchCode = d.BranchCode AND h.BillAcceptNo=d.BillAcceptNo AND ISNULL(h.CancelProve,'')=''
"
        Return sql
    End Function
    Function SQLUpdateServiceCode() As String
        Return "
UPDATE d
SET d.IsTaxCharge=h.IsTaxCharge,
d.Is50Tavi=h.Is50Tavi,
d.IsHaveSlip=h.IsHaveSlip,
d.IsCredit=h.IsCredit,
d.IsExpense=h.IsExpense,
d.IsLtdAdv50Tavi=h.IsLtdAdv50Tavi
FROM Job_SrvGroup h INNER JOIN Job_SrvSingle d
ON h.GroupCode=d.GroupCode
"
    End Function
    Function SQLSelectInvDetail() As String
        Return "
SELECT d.ItemNo, d.SICode, d.SDescription, d.ExpSlipNO, d.SRemark, d.CurrencyCode, d.ExchangeRate, d.Qty, d.QtyUnit, d.UnitPrice, d.FUnitPrice, d.Amt, d.FAmt, 
    d.DiscountType, d.DiscountPerc, d.AmtDiscount, d.FAmtDiscount, d.Is50Tavi, d.Rate50Tavi, d.Amt50Tavi, d.IsTaxCharge, d.AmtVat, d.TotalAmt, d.FTotalAmt, 
    d.AmtAdvance, d.AmtCharge, d.CurrencyCodeCredit AS DCurrencyCode, d.ExchangeRateCredit AS DExchangeRate, d.AmtCredit, d.FAmtCredit, d.VATRate, 
    h.BranchCode, h.DocNo, h.DocDate, h.CustCode, h.CustBranch, h.BillToCustCode, h.BillToCustBranch, h.ContactName, h.EmpCode, h.PrintedBy, h.PrintedDate, 
    h.PrintedTime, h.RefNo, h.TotalAdvance, h.TotalCharge, h.TotalIsTaxCharge, h.TotalIs50Tavi, h.TotalVAT, h.Total50Tavi, h.TotalCustAdv, h.TotalNet, h.ForeignNet, 
    h.BillAcceptDate, h.BillIssueDate, h.BillAcceptNo, h.Remark1, h.Remark2, h.Remark3, h.Remark4, h.Remark5, h.Remark6, h.Remark7, h.Remark8, h.Remark9, 
    h.Remark10, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.ShippingRemark, h.SumDiscount, h.DiscountRate, h.DiscountCal, h.TotalDiscount, 
    h.CurrencyCode AS HCurrencyCode, h.ExchangeRate AS HExchangeRate, c1.TaxNumber AS CustTaxNumber, c1.NameThai AS CustNameThai, 
    c1.NameEng AS CustNameEng, c1.TAddress1 AS CustTAddress1, c1.TAddress2 AS CustTAddress2, c1.EAddress1 AS CustEAddress1, 
    c1.EAddress2 AS CustEAddress2, c2.TaxNumber AS BillTaxNumber, c2.NameThai AS BillNameThai, c2.NameEng AS BillNameEng, c2.TAddress1 AS BillTAddress1, 
    c2.TAddress2 AS BillTAddress2, c2.EAddress1 AS BillEAddress1, c2.EAddress2 AS BillEAddress2, u.TName AS IssueNameThai, u.EName AS IssueNameEng,
(SELECT STUFF((
SELECT DISTINCT ',' + JobNo
FROM Job_ClearDetail WHERE BranchCode=d.BranchCode
AND LinkBillNo=d.DocNo  AND LinkItem=d.ItemNo
    FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
    )) as FromJobNo,
(SELECT STUFF((
SELECT DISTINCT ',' + ClrNo + '#' + Convert(varchar,ItemNo)
FROM Job_ClearDetail WHERE BranchCode=d.BranchCode
AND LinkBillNo=d.DocNo  AND LinkItem=d.ItemNo
    FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
    )) as FromClrNo
FROM     dbo.Job_InvoiceDetail AS d INNER JOIN
    dbo.Job_InvoiceHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Company AS c1 ON h.CustCode = c1.CustCode AND h.CustBranch = c1.Branch INNER JOIN
    dbo.Mas_Company AS c2 ON h.BillToCustCode = c2.CustCode AND h.BillToCustBranch = c2.Branch INNER JOIN
    dbo.Mas_User AS u ON h.EmpCode = u.UserID
"
    End Function
    Function SQLSelectVATSales() As String
        Return "
SELECT ReceiptDate,ReceiptNo,ServiceType,TaxNumber,Branch,TotalChargeVAT,TotalVAT,TotalChargeNonVAT,CancelReson FROM (
SELECT h.ReceiptDate,h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN h.TotalVAT>0 THEN 'ค่าบริการของบริษัท' ELSE 'ค่าขนส่งของบริษัท' END) + c.NameThai as ServiceType,
CASE WHEN h.TotalVAT>0 THEN d.TotalVATCharge ELSE 0 END as TotalChargeVAT,
h.TotalVAT,
CASE WHEN h.TotalVAT=0 THEN d.TotalNonVAT ELSE 0 END as TotalChargeNonVAT,
h.TotalCharge+h.TotalVAT as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h inner join (
	SELECT BranchCode,ReceiptNo,
	SUM(CASE WHEN VATRate>0 THEN Amt ELSE 0 END) as TotalVATCharge,
	SUM(CASE WHEN VATRate=0 THEN Amt ELSE 0 END) as TotalNonVAT
	FROM Job_ReceiptDetail 
	GROUP BY BranchCode,ReceiptNo
) d ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.ReceiptType<>'ADV' AND NOT ISNULL(h.CancelProve,'')<>''
UNION
SELECT h.DocDate,h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN d.DiffAmt>0 THEN 'เพิ่มหนี้' ELSE 'ลดหนี้' END)+(CASE WHEN d.VATAmt <>0 THEN 'ค่าบริการของบริษัท' ELSE 'ค่าขนส่งของบริษัท' END)+c.NameThai as ServiceType,
CASE WHEN d.VATAmt <>0 THEN d.DiffAmt ELSE 0 END as TotalChargeVAT,
d.VATAmt,
CASE WHEN d.VATAmt =0 THEN d.DiffAmt ELSE 0 END as TotalChargeNonVAT,
d.DiffAmt+d.VATAmt as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE NOT h.DocStatus<>99
UNION
SELECT h.CancelDate,'*'+h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
'**ยกเลิก**'+ (CASE WHEN h.TotalVAT>0 THEN 'ค่าบริการของบริษัท' ELSE 'ค่าขนส่งของบริษัท' END) + c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVat,
0 as TotalChargeNonVAT,
0 as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.ReceiptType<>'ADV' AND ISNULL(h.CancelProve,'')<>''
UNION
SELECT h.CancelDate,'*'+h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
'**ยกเลิก**'+ (CASE WHEN d.DiffAmt>0 THEN 'เพิ่มหนี้' ELSE 'ลดหนี้' END)+(CASE WHEN d.VATAmt <>0 THEN 'ค่าบริการของบริษัท' ELSE 'ค่าขนส่งของบริษัท' END)+c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVAT,
0 as TotalNonVAT,
0 as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.DocStatus<>99
) AS t {0} ORDER BY ReceiptDate,ReceiptNo
"
    End Function
    Function SQLSelectVATBuy() As String
        Return "SELECT ExpenseDate,SlipNo,VenderName,TaxNumber,Branch,ExpenseAmt,ExpenseVAT,CancelReson FROM (
SELECT cd.Date50Tavi as ExpenseDate, cd.SlipNO as SlipNo, v.TName as VenderName, v.TaxNumber, v.BranchCode as Branch, v.VenCode, cd.UsedAmount as ExpenseAmt, cd.ChargeVAT as ExpenseVAT, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.PaymentDate IS NOT NULL) AND (cd.SlipNO <> '')
UNION
SELECT h.CancelDate, '*'+cd.SlipNO, v.TName + '**ยกเลิก**', v.TaxNumber, v.BranchCode, v.VenCode, 0, 0, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.CancelDate IS NOT NULL) AND (cd.SlipNO <> '')
) AS t {0} ORDER BY ExpenseDate,SlipNo"
    End Function
    Function SQLSelectTax50TaviReport() As String
        Return "
SELECT cd.Date50Tavi, cd.NO50Tavi, v.VenCode, v.TaxNumber AS VenTaxNumber, v.BranchCode AS VenTaxBranch, v.TName AS VenderName, c.CustCode, 
    c.TaxNumber AS CustTaxNumber, c.Branch AS CustTaxBranch, c.NameThai AS CustName, cd.SICode, cd.SDescription, cd.UsedAmount, cd.Tax50TaviRate, 
    cd.Tax50Tavi, cd.IsLtdAdv50Tavi, cd.SlipNO
FROM     dbo.Job_ClearDetail AS cd INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch INNER JOIN
    dbo.Mas_Vender AS v ON cd.VenderCode = v.VenCode
WHERE (cd.Tax50Tavi > 0) AND ch.DocStatus<>99 {0}
"
    End Function
    Function SQLSelectCashFlow() As String
        Return "
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '') <> '')) {0}
"
    End Function
    Function SQLSelectBooking() As String
        Return "
SELECT h.BranchCode, h.JNo, h.BookingNo, h.LoadDate AS BookingDate, h.NotifyCode, h.VenderCode AS ForwarderCode, h.ContactName AS ShipperContact, 
u.TName AS CSName, u.MobilePhone AS CSTel, u.EMail AS CSEMail, j.InvNo, j.InvProduct, j.InvProductQty, j.InvProductUnit,j.InvCurUnit,j.InvCurRate, j.TotalContainer, j.ShippingCmd,
a.English AS ForwarderName, a.EAddress1 AS ForwarderAddress1, a.EAddress2 AS ForwarderAddress2, a.ContactSale AS ForwarderContact, a.TaxNumber as ForwarderTaxID,
a.Phone AS ForwarderPhone, c.NameEng AS ConsigneeName, c.EAddress1 AS ConsignAddress1, c.EAddress2 AS ConsignAddress2, c.Phone AS ConsignPhone, c.FaxNumber as ConsignFax,c.DMailAddress as ConsignEmail,c.TaxNumber as ConsignTaxID,c.Branch as ConsignTaxBranch,
n.NameEng AS NotifyName, n.EAddress1 AS NotifyAddress1, n.EAddress2 AS NotifyAddress2, n.Phone AS NotifyPhone, n.FaxNumber as NotifyFax,n.DMailAddress as NotifyEmail, n.TaxNumber as NotifyTaxID,n.Branch as NotifyTaxBranch,
j.VesselName, j.MVesselName, j.ProjectName, j.TotalGW, j.TotalNW , j.GWUnit, j.InvInterPort, j.InvFCountry, j.InvCountry, j.ETDDate, j.ETADate, j.ClearPortNo, j.ClearPort, j.DeliveryTo, j.DeliveryAddr, 
j.ShippingEmp,e.TName as ShippingName, e.MobilePhone as ShippingTel,j.TRemark, j.EstDeliverDate, h.Remark, h.PackingAddress, h.CYAddress, h.FactoryAddress, h.ReturnAddress, h.PackingContact, h.CYContact, h.FactoryContact, h.ReturnContact, 
h.PackingPlace, h.CYPlace, h.FactoryPlace, h.ReturnPlace, h.PackingDate, h.CYDate, h.FactoryDate, h.ReturnDate, h.PackingTime, h.CYTime, h.FactoryTime, 
h.ReturnTime, h.TransMode, h.PaymentCondition, h.PaymentBy, d.CTN_NO, d.SealNumber, d.TruckNO, d.Comment, d.TruckType, d.Driver, d.Location, d.DeliveryNo,
d.ShippingMark, d.CTN_SIZE, d.ProductDesc, d.ProductQty, d.ProductUnit, d.GrossWeight, d.Measurement, d.TargetYardDate, d.TargetYardTime, d.ActualYardDate, d.ActualYardTime, 
d.UnloadDate AS TargetDeliveryDate, d.UnloadTime as TargetDeliveryTime, d.UnloadFinishDate AS ActualDeliveryDate, d.UnloadFinishTime as ActualDeliveryTime,
d.TruckIN AS TargetReturnDate, d.Start as TargetReturnTime, d.ReturnDate AS ActualReturnDate, d.Finish as ActualReturnTime, j.BLNo, j.JobType, 
j.ShipBy, j.AgentCode, s.NameEng AS ShipperName, s.EAddress1 AS ShipperAddress1, s.EAddress2 AS ShipperAddress2, s.Phone AS ShipperPhone, s.FaxNumber as ShipperFax, s.DMailAddress as ShipperEMail,
s.TaxNumber as ShipperTaxID,s.Branch as ShipperTaxBranch,j.AgentCode AS TransportCode, j.ForwarderCode AS CarrierCode, v.English AS CarrierName, v.EAddress1 AS CarrierAddress1, v.EAddress2 AS CarrierAddress2, 
v.ContactSale AS CarrierContact, v.Phone AS CarrierPhone,v.TaxNumber as CarrierTaxID, t.English AS TransportName, t.EAddress1 AS TransportAddress1, t.EAddress2 AS TransportAddress2, 
t.ContactSale AS TransportContact, t.Phone AS TransportPhone,t.TaxNumber as TransportTaxID, j.CustContactName, j.Measurement AS TotalM3, j.HAWB, j.MAWB, j.Description, j.CustRefNO,j.ConfirmDate,
r.LocationRoute,d.PlaceName1,d.PlaceAddress1,PlaceContact1,d.PlaceName2,d.PlaceAddress2,PlaceContact2,d.PlaceName3,d.PlaceAddress3,PlaceContact3,d.PlaceName4,d.PlaceAddress4,PlaceContact4
FROM dbo.Mas_Company AS n INNER JOIN
dbo.Mas_Vender AS a INNER JOIN
dbo.Job_LoadInfo AS h LEFT OUTER JOIN
dbo.Job_LoadInfoDetail AS d ON h.BranchCode = d.BranchCode AND h.BookingNo = d.BookingNo ON a.VenCode = h.VenderCode ON 
n.CustCode = h.NotifyCode LEFT OUTER JOIN
dbo.Job_TransportRoute AS r ON d.LocationID = r.LocationID INNER JOIN
dbo.Job_Order AS j ON h.BranchCode = j.BranchCode AND h.JNo = j.JNo INNER JOIN
dbo.Mas_User AS u ON j.CSCode = u.UserID LEFT OUTER JOIN
dbo.Mas_User AS e ON j.ShippingEmp = e.UserID LEFT OUTER JOIN
dbo.Mas_Vender AS v ON j.ForwarderCode = v.VenCode LEFT OUTER JOIN
dbo.Mas_Vender AS t ON j.AgentCode = t.VenCode LEFT OUTER JOIN
dbo.Mas_Company AS c ON j.consigneecode = c.CustCode LEFT OUTER JOIN
dbo.Mas_Company AS s ON j.CustCode = s.CustCode AND j.CustBranch = s.Branch
WHERE (j.JobStatus < 90) 
"
    End Function
    Function SQLSelectJobSummary(sqlw As String, bCancel As Boolean) As String
        Dim sql = "SELECT * FROM 
(SELECT jt.ConfigKey AS JobTypeCode, jt.ConfigValue AS JobTypeName, sb.ConfigKey AS ShipByCode, sb.ConfigValue AS ShipByName, COUNT(j.JNo) AS TotalJob, 
                         Convert(varchar,Year(j.CreateDate)) + '/' + RIGHT('0'+Convert(varchar,Month(j.CreateDate)),2) AS Period,Year(j.CreateDate) as FiscalYear,Month(j.CreateDate) as JobMonth
FROM dbo.Mas_Config AS jt INNER JOIN
                         dbo.Job_Order AS j ON CONVERT(int, jt.ConfigKey) = j.JobType INNER JOIN
                         dbo.Mas_Config AS sb ON CONVERT(int, sb.ConfigKey) = j.ShipBy
WHERE (jt.ConfigCode = N'JOB_TYPE') AND (sb.ConfigCode = N'SHIP_BY') AND (j.JobStatus " & If(bCancel, "=", "<>") & " 99) {0}
GROUP BY jt.ConfigKey, jt.ConfigValue, sb.ConfigKey, sb.ConfigValue, Year(j.CreateDate),
Month(j.CreateDate)
UNION
SELECT 'ALL','**ALL TYPE**','ALL','**ALL TYPE**',COUNT(*),Convert(varchar,Year(j.CreateDate)) +'/ALL',Year(j.CreateDate) as FiscalYear,0 as JobMonth
FROM dbo.Job_Order j WHERE j.JobStatus" & If(bCancel, "=", "<>") & "99 {0}
GROUP BY Year(j.CreateDate)
UNION
SELECT 'ALL','**ALL TYPE**','ALL','**ALL TYPE**',COUNT(*),Convert(varchar,Year(j.CreateDate)) +'/' + RIGHT('0'+Convert(varchar,Month(j.CreateDate)),2),Year(j.CreateDate) as FiscalYear,Month(j.CreateDate) as JobMonth
FROM dbo.Job_Order j WHERE j.JobStatus" & If(bCancel, "=", "<>") & "99 {0}
GROUP BY Year(j.CreateDate),Month(j.CreateDate)
) t
"
        Return String.Format(sql, sqlw)
    End Function
    Function SQLSelectJobList(sqlw As String, bCancel As Boolean) As String
        Dim sql = "SELECT * FROM 
(SELECT jt.ConfigKey AS JobTypeCode, jt.ConfigValue AS JobTypeName, sb.ConfigKey AS ShipByCode, sb.ConfigValue AS ShipByName, JNo AS JobNo, 
                         Convert(varchar,Year(j.CreateDate)) + '/' + RIGHT('0'+Convert(varchar,Month(j.CreateDate)),2) AS Period,Year(j.CreateDate) as FiscalYear,Month(j.CreateDate) as JobMonth
FROM dbo.Mas_Config AS jt INNER JOIN
                         dbo.Job_Order AS j ON CONVERT(int, jt.ConfigKey) = j.JobType INNER JOIN
                         dbo.Mas_Config AS sb ON CONVERT(int, sb.ConfigKey) = j.ShipBy
WHERE (jt.ConfigCode = N'JOB_TYPE') AND (sb.ConfigCode = N'SHIP_BY') AND (j.JobStatus " & If(bCancel = True, "=", "<>") & " 99) {0}
) t
"
        Return String.Format(sql, sqlw)
    End Function
    Function SQLSelectExpenseFromClr() As String
        Return "
SELECT j.BranchCode, j.JNo, d.ClrNo, i.SICode, i.SDescription as TRemark, i.Qty as QtyBegin,  i.UnitCode as UnitCheck
, i.CurrencyCode, i.CurRate as CurrencyRate, i.UsedAmount as ChargeAmt, i.VATRate as VatRate, i.ChargeVAT as VatAmt, 
i.Tax50TaviRate as TaxRate, i.Tax50Tavi as TaxAmt, i.BNet as TotalAmt, i.FNet as TotalAmtF,1 as IsRequired,
s.NameThai, s.NameEng
FROM dbo.Job_ClearHeader AS d INNER JOIN
dbo.Job_ClearDetail AS i ON d.BranchCode = i.BranchCode AND d.ClrNo = i.ClrNo INNER JOIN
dbo.Job_Order AS j ON i.BranchCode = j.BranchCode AND i.JobNo = j.JNo INNER JOIN
dbo.Job_SrvSingle AS s ON i.SICode = s.SICode
"
    End Function
    Function SQLSelectExpenseFromQuo() As String
        Return "
SELECT j.BranchCode, j.JNo, j.QNo, i.SICode, i.DescriptionThai as TRemark, i.QtyBegin, i.QtyEnd, i.CalculateType, i.UnitCheck, i.CurrencyCode, i.CurrencyRate, i.ChargeAmt, i.Isvat, i.VatRate, i.VatAmt, i.IsTax, 
i.TaxRate, i.TaxAmt, i.TotalAmt, i.TotalCharge, i.UnitDiscntPerc, i.UnitDiscntAmt, i.VenderCode, i.VenderCost, i.BaseProfit, i.CommissionPerc, i.CommissionAmt, 
i.NetProfit, i.IsRequired,s.NameThai, s.NameEng
FROM dbo.Job_QuotationDetail AS d INNER JOIN
dbo.Job_Order AS j ON d.BranchCode = j.BranchCode AND d.QNo = j.QNo AND d.SeqNo = j.Revise AND d.JobType = j.JobType AND d.ShipBy = j.ShipBy INNER JOIN
dbo.Job_QuotationItem AS i ON d.BranchCode = i.BranchCode AND d.QNo = i.QNo AND d.SeqNo = i.SeqNo INNER JOIN
dbo.Job_SrvSingle AS s ON i.SICode = s.SICode
"
    End Function
    Function SQLSelectDocList(bCancel As Boolean) As String
        Return "
SELECT * FROM (
select Convert(varchar,Year(AdvDate))+'/'+RIGHT('0'+Convert(varchar,Month(AdvDate)),2) as Period,'ADV' as DocType,AdvNo as DocNo,AdvDate as DocDate 
from Job_AdvHeader where DocStatus" & If(bCancel = True, "=", "<>") & "99 
union
select Convert(varchar,Year(ClrDate))+'/'+RIGHT('0'+Convert(varchar,Month(ClrDate)),2) as Period,'CLR' as DocType,ClrNo as DocNo,ClrDate as DocDate 
from Job_ClearHeader where DocStatus" & If(bCancel = True, "=", "<>") & "99 
UNION
select Convert(varchar,Year(CreateDate))+'/'+RIGHT('0'+Convert(varchar,Month(CreateDate)),2) as Period,'INV' as DocType,DocNo,CreateDate as DocDate 
from Job_InvoiceHeader where " & If(bCancel = True, "", "NOT") & " ISNULL(CancelProve,'')<>''
) t {0} ORDER BY t.DocType,t.Period,t.DocNo
"
    End Function
    Function SQLSelectDocSummary(bCancel As Boolean) As String
        Return "
SELECT * FROM (
select Convert(varchar,Year(AdvDate))+'/'+RIGHT('0'+Convert(varchar,Month(AdvDate)),2) as Period,'ADV' as DocType,Count(*) as CountDoc 
from Job_AdvHeader where DocStatus" & If(bCancel, "=", "<>") & "99 
group by Convert(varchar,Year(AdvDate))+'/'+RIGHT('0'+Convert(varchar,Month(AdvDate)),2)
union
SELECT Convert(varchar,Year(AdvDate))+'/ALL' as Period,'ADV' as DocType,Count(*) as CountDoc 
from Job_AdvHeader where DocStatus" & If(bCancel, "=", "<>") & "99 
group by Convert(varchar,Year(AdvDate))
UNION
select Convert(varchar,Year(ClrDate))+'/'+RIGHT('0'+Convert(varchar,Month(ClrDate)),2) as Period,'CLR' as DocType,Count(*) as CountDoc 
from Job_ClearHeader where DocStatus" & If(bCancel, "=", "<>") & "99 
group by Convert(varchar,Year(ClrDate))+'/'+RIGHT('0'+Convert(varchar,Month(ClrDate)),2)
union
SELECT Convert(varchar,Year(ClrDate))+'/ALL' as Period,'CLR' as DocType,Count(*) as CountDoc 
from Job_ClearHeader where DocStatus" & If(bCancel, "=", "<>") & "99 
group by Convert(varchar,Year(ClrDate))
UNION
select Convert(varchar,Year(CreateDate))+'/'+RIGHT('0'+Convert(varchar,Month(CreateDate)),2) as Period,'INV' as DocType,Count(*) as CountDoc 
from Job_InvoiceHeader where " & If(bCancel, "", "NOT") & " ISNULL(CancelProve,'')<>''
group by Convert(varchar,Year(CreateDate))+'/'+RIGHT('0'+Convert(varchar,Month(CreateDate)),2)
union
SELECT Convert(varchar,Year(CreateDate))+'/ALL' as Period,'INV' as DocType,Count(*) as CountDoc 
from Job_InvoiceHeader where " & If(bCancel, "", "NOT") & " ISNULL(CancelProve,'')<>''
group by Convert(varchar,Year(CreateDate))
) t {0} ORDER BY t.DocType,t.Period
"
    End Function
    Function SQLSelectLoginHistory() As String
        Return "
select b.CustID,b.CustName,a.LogAction as UserID,Max(a.LogDateTime) as LastLogin
from TWTLog a 
INNER JOIN TWTCustomer b
ON a.CustID=b.CustID+'/'
where a.ModuleName='LOGIN_SHIPPING' and b.CustID='" & My.MySettings.Default.LicenseTo.ToString & "'
and a.LogAction Not in('ADMIN','CS','BOAT','pasit','test')
group by b.CustID,b.CustName,a.LogAction 
"
    End Function
    Function SQLSelectLoginSummary() As String
        Return "SELECT tb.* FROM (
select b.CustID,b.CustName,Convert(varchar,Year(a.LogDateTime))+'/'+RIGHT('0'+Convert(varchar,Month(a.LogDateTime)),2) as Period,a.LogAction as UserID,Convert(varchar,Max(a.LogDateTime),103) as LastLogin
from TWTLog a 
INNER JOIN TWTCustomer b
ON a.CustID=b.CustID+'/'
where a.ModuleName='LOGIN_SHIPPING' and b.CustID='" & My.MySettings.Default.LicenseTo.ToString & "'
and a.LogAction Not in('ADMIN','CS','BOAT','pasit','test')
group by b.CustID,b.CustName,a.LogAction ,Convert(varchar,Year(a.LogDateTime))+'/'+RIGHT('0'+Convert(varchar,Month(a.LogDateTime)),2)
UNION
select b.CustID,b.CustName,Convert(varchar,Year(a.LogDateTime))+'/'+RIGHT('0'+Convert(varchar,Month(a.LogDateTime)),2) as Period,Cast(Count(DISTINCT a.LogAction) as varchar)+' Users' as CountUser,'ALL' as LastLogin
from TWTLog a 
INNER JOIN TWTCustomer b
ON a.CustID=b.CustID+'/'
where a.ModuleName='LOGIN_SHIPPING' and b.CustID='" & My.MySettings.Default.LicenseTo.ToString & "'
and a.LogAction Not in('ADMIN','CS','BOAT','pasit','test')
group by b.CustID,b.CustName,Convert(varchar,Year(a.LogDateTime))+'/'+RIGHT('0'+Convert(varchar,Month(a.LogDateTime)),2)
) tb"
    End Function
    Function SQLUpdateClrStatusToClear() As String
        'ใบปิดที่มีใบแจ้งหนี้แต่ยังไม่ครบ
        Return "
UPDATE d SET d.DocStatus=3
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,
    SUM(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 1 ELSE 0 END) as SumBill,
    COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99 
    GROUP BY a.BranchCode,a.ClrNo
    HAVING COUNT(*)>SUM(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 1 ELSE 0 END)
    AND SUM(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 1 ELSE 0 END)>0
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>3 AND d.DocStatus<>99
"
    End Function
    Function SQLUpdateClrStatusFromAdvance() As String
        'ใบปิดที่มีใบเบิกที่มีการรับเคลียร์เงินครบแล้ว
        Return "
UPDATE d SET d.DocStatus=3
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,b.DocStatus,SUM(CASE WHEN ISNULL(c.DocStatus,0)=6 THEN 1 ELSE 0 END) as SumBill
    ,COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99 AND a.AdvAmount>0
	LEFT JOIN Job_AdvHeader c ON a.BranchCode=c.BranchCode
	AND a.AdvNO=c.AdVNo 
    WHERE ISNULL(c.DocStatus,0)<>99
    GROUP BY a.BranchCode,a.ClrNo,b.DocStatus
    HAVING COUNT(*)=SUM(CASE WHEN ISNULL(c.DocStatus,0)=6 THEN 1 ELSE 0 END)
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>3 AND d.DocStatus<>99
"
    End Function
    Function SQLUpdateClrReceiveFromAdvance(user As String, docno As String) As String
        Return "
UPDATE d SET d.DocStatus=3,d.ReceiveBy='" & user & "',d.ReceiveRef='" & docno & "',d.ReceiveDate=GetDate(),d.ReceiveTime=Convert(varchar(10),GetDate(),108)
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,b.DocStatus,SUM(CASE WHEN ISNULL(c.DocStatus,0)=6 THEN 1 ELSE 0 END) as SumBill
    ,COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99 AND a.AdvAmount>0
	LEFT JOIN Job_AdvHeader c ON a.BranchCode=c.BranchCode
	AND a.AdvNO=c.AdVNo
    WHERE ISNULL(c.DocStatus,0)<>99
    GROUP BY a.BranchCode,a.ClrNo,b.DocStatus
    HAVING COUNT(*)=SUM(CASE WHEN ISNULL(c.DocStatus,0)=6 THEN 1 ELSE 0 END)
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>3 AND d.DocStatus<>99
"
    End Function

    Function SQLUpdateClrStatusToComplete() As String
        'ใบปิดที่มีการทำใบแจ้งหนี้ครบแล้ว
        Return "
UPDATE d SET d.DocStatus=4
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,b.DocStatus,SUM(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 1 ELSE 0 END) as SumBill
    ,COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99 AND a.BNet>0
    GROUP BY a.BranchCode,a.ClrNo,b.DocStatus
    HAVING COUNT(*)=SUM(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 1 ELSE 0 END)
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>4 AND d.DocStatus<>99 
"
    End Function
    Function SQLUpdateClrStatusToInComplete() As String
        Dim caseStatus = "(CASE WHEN ISNULL(d.ReceiveRef,'')<>'' THEN 3 ELSE (CASE WHEN ISNULL(d.ApproveBy,'')<>'' THEN 2 ELSE 1 END) END)"
        Return "
UPDATE d SET d.DocStatus=" & caseStatus & "
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,b.DocStatus
    ,SUM(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 1 ELSE 0 END) as SumBill
    ,COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99
    GROUP BY a.BranchCode,a.ClrNo,b.DocStatus
    HAVING SUM(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 1 ELSE 0 END)=0
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>99 
"
    End Function
    Function SQLSelectTransportDetail() As String
        Return "
SELECT a.*,ISNULL(b.CountBill,0) as CountBill,ISNULL(b.CountClear,0) as CountClear, 
ISNULL(b.CountBill,0)-ISNULL(b.CountClear,0) as CountBalance,c.VenderCode,c.NotifyCode,c.JNo
FROM Job_LoadInfoDetail a LEFT JOIN(
    SELECT h.BranchCode,d.BookingRefNo,d.BookingItemNo,COUNT(*) as CountBill,
    SUM(CASE WHEN ISNULL(d.ClrReFNo,'')<>'' THEN 1 ELSE 0 END) as CountClear
    FROM Job_PaymentDetail d INNER JOIN Job_PaymentHeader h 
    ON d.BranchCode=h.BranchCode AND d.DocNo=h.DocNo
    WHERE ISNULL(h.CancelProve,'')='' GROUP BY h.BranchCode,d.BookingRefNo,d.BookingItemNo
) b ON a.BranchCode=b.BranchCode AND a.BookingNo=b.BookingRefNo AND a.ItemNo=b.BookingItemNo
INNER JOIN Job_LoadInfo c ON a.BranchCode=c.BranchCode AND a.BookingNo=c.BookingNo
"
    End Function
    Function SQLUpdateContainer() As String
        Return "
update h
SET h.TotalContainer=d.SumContainer
FROM (
	SELECT a.BranchCode,a.JNo,
	(SELECT STUFF((
	SELECT ',' + Convert(varchar,Count(*)) + 'x' + CTN_SIZE
	FROM Job_LoadInfoDetail WHERE BranchCode=a.BranchCode
	AND BookingNo=a.BookingNo AND ISNULL(CTN_SIZE,'')<>''
	AND ISNULL(CauseCode,'')<>'99'
	GROUP BY CTN_SIZE
	FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
	)) as SumContainer
	from job_loadinfo a
) d INNER JOIN job_order h
ON d.BranchCode=h.BranchCode
AND d.JNo=h.JNo
WHERE ISNULL(d.SumContainer,'')<>''
AND ISNULL(d.SumContainer,'')<>h.TotalContainer
"
    End Function
    Public Function SQLSelectVoucherDetail(tSqlw As String) As String
        Dim sql = "
SELECT * FROM (
    select d.*,h.VoucherDate,ah.CustCode as CmpCode,ah.CustBranch as CmpBranch,ad.PayChqTo as VenderName,ad.TRemark as Remark, 
    ad.ForJNo as JobNo,ah.EmpCode, ah.AdvNo as DocRefNo,ah.AdvDate as DocDate,ad.SDescription,ad.AdvAmount as Amount,ad.ChargeVAT as VAT,ad.Charge50Tavi as WHT,ad.AdvNet as PaidAmount
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_AdvHeader ah ON h.BranchCode=ah.BranchCode
    AND h.ControlNo=ah.PaymentRef
    inner join Job_AdvDetail ad ON ah.BranchCode=ad.BranchCode
    AND ah.AdvNo=ad.AdvNo
    union
    select d.*,h.VoucherDate,j.CustCode,j.CustBranch,ad.Pay50TaviTo as VenderName,ad.Remark,
    ad.JobNo,ah.EmpCode,ah.ClrNo,ah.ClrDate,ad.SDescription,ad.UsedAmount,ad.ChargeVAT,ad.Tax50Tavi,ad.BNet
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_ClearHeader ah ON h.BranchCode=ah.BranchCode
    AND h.ControlNo=ah.ReceiveRef
    inner join Job_ClearDetail ad ON ah.BranchCode=ad.BranchCode
    AND ah.ClrNo=ad.ClrNo
    left join Job_Order j ON ad.BranchCode=j.BranchCode AND ad.JobNo=j.JNo
    where ISNULL(ad.AdvNo,'')=''
    union
    select d.*,h.VoucherDate,j.CustCode,j.CustBranch,ad.Pay50TaviTo as VenderName,ad.Remark,
    ad.JobNo,ah.EmpCode,ah.ClrNo,ah.ClrDate,ad.SDescription,ad.UsedAmount,ad.ChargeVAT,ad.Tax50Tavi,ad.BNet
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_CashControlDoc dc ON d.BranchCode=dc.BranchCode AND d.Controlno=dc.ControlNo
    AND d.acType=dc.acType
    inner join Job_ClearHeader ah ON h.BranchCode=ah.BranchCode
    AND h.ControlNo=ah.ReceiveRef
    inner join Job_ClearDetail ad ON ah.BranchCode=ad.BranchCode
    AND ah.ClrNo=ad.ClrNo
    left join Job_Order j ON ad.BranchCode=j.BranchCode AND ad.JobNo=j.JNo
    inner join Job_AdvDetail av on dc.BranchCode=av.BranchCode AND
    dc.DocNo =av.AdvNo+'#'+cast(av.ItemNo as varchar) AND 
	ad.BranchCode=av.BranchCode AND
	ad.AdvNo+'#'+cast(ad.AdvItemNo as varchar)=av.AdvNo+'#'+cast(av.ItemNo as varchar)
    where ISNULL(ad.AdvNo,'')<>''
    union
    select d.*,h.VoucherDate,j.CustCode,j.CustBranch,'',ah.TRemark,
    c.JobNo ,ah.EmpCode, ad.InvoiceNo,ah.ReceiptDate,ad.SDescription,ad.Amt,ad.AmtVAT,ad.Amt50Tavi,ad.Net
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_ReceiptDetail ad ON h.BranchCode=ad.BranchCode
    AND h.ControlNo=ad.ControlNo
    inner join Job_ReceiptHeader ah ON ad.BranchCode=ah.BranchCode
    AND ad.ReceiptNo=ah.ReceiptNo
    left join Job_ClearDetail c ON ad.BranchCode=c.BranchCode 
    AND ad.InvoiceNo=c.LinkBillNo AND ad.InvoiceItemNo=c.LinkItem
    left join Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo
    union
    select d.*,h.VoucherDate,h.CustCode,h.CustBranch,v.TName,ad.SRemark,
    ad.ForJNo,ah.EmpCode,ad.DocNo,ah.PaymentDate,ad.SDescription,ad.Amt,ad.AmtVAT,ad.AmtWHT,ad.Total
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_PaymentHeader ah ON h.BranchCode=ah.BranchCode
    AND h.ControlNo=ah.PaymentRef
    inner join Job_PaymentDetail ad ON ad.BranchCode=ah.BranchCode
    AND ad.DocNo=ah.DocNo
    left join Job_Order j ON ad.BranchCode=j.BranchCode AND ad.ForJNo=j.JNo
    left join Mas_Vender v ON ah.VenCode=v.VenCode
) pr {0}
"
        Return String.Format(sql, tSqlw)
    End Function
    Public Function SQLSelectVoucherDoc(tSqlw As String) As String
        Return "
SELECT src.*,doc.JobNo,doc.EmpCode,doc.TRemark
FROM
(select *,
(CASE WHEN CHARINDEX('#',DocNo)>0 THEN SUBSTRING(DocNo,1,CHARINDEX('#',DocNo)-1) ELSE DocNo END) as LinkNo from Job_CashControlDoc
" & tSqlw & "
) src
left join
(
SELECT h.BranchCode,h.AdvNo as DocNo,h.AdvDate as DocDate,
(SELECT STUFF((
SELECT DISTINCT ',' + ForJNo
FROM Job_AdvDetail WHERE BranchCode=h.BranchCode
AND AdvNo=h.AdvNo
  FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
  )) as JobNo,h.EmpCode,h.TRemark
	FROM Job_AdvHeader h 
	UNION
	SELECT h.BranchCode,h.ClrNo,h.ClrDate,
(SELECT STUFF((
SELECT DISTINCT ',' + JobNo
FROM Job_ClearDetail WHERE BranchCode=h.BranchCode
AND ClrNo=h.ClrNo
  FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
  )) as JobNo,h.EmpCode,h.TRemark
	FROM Job_ClearHeader h
	UNION
	SELECT h.BranchCode,h.DocNo,h.DocDate,
(SELECT STUFF((
SELECT DISTINCT ',' + ForJNo
FROM Job_PaymentDetail WHERE BranchCode=h.BranchCode
AND DocNo=h.DocNo
  FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
  )) as JobNo,h.EmpCode,h.Remark
	FROM Job_PaymentHeader h
	UNION
	SELECT h.BranchCode,h.DocNo,h.DocDate,h.RefNo,h.EmpCode,h.ShippingRemark
	FROM Job_InvoiceHeader h
) doc on src.BranchCode=doc.BranchCode AND src.LinkNo=doc.DocNo
"
    End Function
    Public Function SQLSelectClearingTotal(sqlW As String) As String
        Dim hSql As String = "
select DISTINCT b.SICode,s.IsExpense,s.IsCredit,
ISNULL(s.NameThai,'(N/A)') as Description 
from Job_ClearDetail b 
inner join Job_ClearHeader a ON b.BranchCode=a.BranchCode 
and b.ClrNo=a.ClrNo and b.BNet>0 
inner join Job_SrvSingle s
ON b.SICode=s.SICode
inner join Job_Order j
ON b.BranchCode=j.BranchCode AND b.JobNo=j.JNo
inner join Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
WHERE a.DocStatus<>99 and s.IsCredit=0 {0}
ORDER BY s.IsExpense
"
        Dim tSql As String = ""
        Dim tb = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(hSql, sqlW))
        For Each dr As DataRow In tb.Rows
            If tSql <> "" Then
                tSql &= ","
            End If
            If dr("IsExpense").ToString = "1" Then
                tSql &= String.Format("SUM(CASE WHEN b.SICode='{0}' THEN b.UsedAmount ELSE 0 END) as 'COST-{1}'", dr("SICode").ToString(), dr("Description").ToString())
            Else
                tSql &= String.Format("SUM(CASE WHEN b.SICode='{0}' THEN b.UsedAmount ELSE 0 END) as 'SVC-{1}'", dr("SICode").ToString(), dr("Description").ToString())
            End If
        Next
        tSql = "
SELECT j.DocDate,j.DutyDate,b.JobNo as 'Job Number',jt.JobTypeName as JobType,sb.ShipByName as ShipBy,
e.NameEng as 'Customer',i.NameEng as 'Consignee',j.DeliveryTo as Shipper,t.TName as Agent,j.InvProduct,
j.InvNo,j.HAWB,j.DeclareNumber,j.ETDDate,j.ETADate,j.LoadDate,j.EstDeliverDate as UnloadDate,j.TotalContainer,
SUM(CASE WHEN s.IsCredit=1 AND s.IsExpense=0 THEN b.UsedAmount ELSE 0 END) as SumAdvance,
SUM(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN b.UsedAmount ELSE 0 END) as SumCharge,
SUM(CASE WHEN s.IsExpense=1 THEN b.UsedAmount ELSE 0 END) as SumCost,
" & tSql & "
FROM Job_ClearDetail b
INNER JOIN Job_ClearHeader a ON b.BranchCode=a.BranchCode 
AND b.ClrNo= a.ClrNo
INNER JOIN Job_SrvSingle s ON b.SICode=s.SICode
INNER JOIN Job_Order j ON b.BranchCode=j.BranchCode AND b.JobNo=j.JNo
LEFT JOIN (SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM MAs_Config WHERE ConfigCode='JOB_TYPE') jt ON j.ShipBy=jt.JobType
LEFT JOIN (SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM MAs_Config WHERE ConfigCode='SHIP_BY') sb ON j.ShipBy=sb.ShipBy
LEFT JOIN Mas_Company e ON e.CustCode=j.CustCode AND e.Branch=j.CustBranch
LEFT JOIN (SELECT CustCode,MAX(Branch) as Branch,MAX(NameEng) as NameEng FROM  Mas_Company GROUP BY CustCode) i ON i.CustCode=j.consigneecode
LEFT JOIN Mas_Vender t ON j.ForwarderCode=t.VenCode
WHERE a.DocStatus<>99 AND b.BNet>0 AND j.JobStatus<>99 {0}
GROUP BY j.DocDate,j.DutyDate,b.JobNo,jt.JobTypeName,sb.ShipByName,e.NameEng,i.NameEng,j.DeliveryTo,j.InvProduct,t.TName,j.InvNo,j.HAWB,
j.InvNo,j.HAWB,j.DeclareNumber,j.ETDDate,j.ETADate,j.LoadDate,j.EstDeliverDate,j.TotalContainer 
ORDER BY j.DocDate,b.JobNo
"
        Return String.Format(tSql, sqlW)
    End Function
    Public Function SQLSelectAdvanceTotalJob(sqlW As String) As String
        Dim tSql As String = ""
        Dim hSql As String = "
select DISTINCT b.SICode,ISNULL(s.NameThai,'(N/A)') as Description 
from Job_AdvDetail b 
inner join Job_AdvHeader a ON b.BranchCode=a.BranchCode 
and b.AdVNo=a.AdvNo and b.AdvNet>0 
left join Job_SrvSingle s
ON b.SICode=s.SICode
WHERE a.DocStatus<>99 {0}
        "
        Dim tb = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(hSql, sqlW))
        For Each dr As DataRow In tb.Rows
            If tSql <> "" Then
                tSql &= ","
            End If
            tSql &= String.Format("SUM(CASE WHEN b.SICode='{0}' THEN b.AdvNet ELSE 0 END) as '{1}'", dr("SICode").ToString(), dr("Description").ToString())
        Next
        tSql = "
SELECT e.NameEng as 'Customer',i.NameEng as 'Consignee',
c.InvProduct as 'Products',c.TotalContainer as 'Containers',
c.BookingNo as 'Booking',
c.HAWB as 'BL/AWB',c.CSCode as 'CS',v.TName as 'Agent',
b.ForJNo as 'Job Number',c.DeclareNumber as 'Customs Declare',
c.DocDate as 'Job Date',
" & tSql & ",
SUM(b.AdvNet) as 'Advance Paid',a.EmpCode as 'Request By',
SUM(d.ClrNet) as TotalExpClear,c.CloseJobDate as 'Close Job Date'
FROM Job_AdvDetail b
INNER JOIN Job_AdvHeader a ON b.BranchCode=a.BranchCode 
AND b.AdvNo= a.AdvNo
INNER JOIN Job_Order c ON b.BranchCode=c.BranchCode
AND b.ForJNo=c.JNo
INNER JOIN Mas_Company e ON e.CustCode=c.CustCode AND e.Branch=c.CustBranch
LEFT JOIN (Select CustCode,MAX(Branch) as Branch,MAX(NameEng) as NameEng from Mas_Company Group by CustCode) i ON i.CustCode=c.CustCode 
LEFT JOIN (
    SELECT ch.BranchCode,cd.AdvNo,cd.AdvItemNo,SUM(cd.BNet) as ClrNet
    FROM Job_ClearHeader ch INNER JOIN Job_ClearDetail cd
    ON ch.BranchCode=cd.BranchCode AND 
    ch.ClrNo=cd.ClrNo
    WHERE ch.DocStatus<>99
    GROUP BY ch.BranchCode,cd.AdvNo,cd.AdvItemNo
) d
ON b.BranchCode=d.BranchCode
AND b.AdvNo=d.AdvNo
AND b.ItemNo=d.AdvItemNo
LEFT JOIN Mas_Vender v ON c.ForwarderCode=v.VenCode
WHERE a.DocStatus<>99 AND b.AdvNet>0 {0}
GROUP BY e.NameEng,i.NameEng,c.InvProduct,c.TotalContainer,c.BookingNo,c.HAWB,
c.CSCode,v.TName,b.ForJNo,c.DeclareNumber,c.DocDate,a.EmpCode,c.CloseJobDate
ORDER BY e.NameEng,b.ForJNo"
        Return String.Format(tSql, sqlW)
    End Function
    Public Function SQLSelectAdvanceTotal(sqlW As String) As String
        Dim tSql As String = ""
        Dim hSql As String = "
select DISTINCT b.SICode,ISNULL(s.NameThai,'(N/A)') as Description 
from Job_AdvDetail b 
inner join Job_AdvHeader a ON b.BranchCode=a.BranchCode 
and b.AdVNo=a.AdvNo and b.AdvNet>0 
left join Job_SrvSingle s
ON b.SICode=s.SICode
WHERE a.DocStatus<>99 {0}
        "
        Dim tb = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(hSql, sqlW))
        For Each dr As DataRow In tb.Rows
            If tSql <> "" Then
                tSql &= ","
            End If
            tSql &= String.Format("SUM(CASE WHEN b.SICode='{0}' THEN b.AdvNet ELSE 0 END) as '{1}'", dr("SICode").ToString(), dr("Description").ToString())
        Next
        tSql = "
SELECT a.CustCode,b.ForJNo as 'Job Number'," & tSql & ",
SUM(b.AdvNet) as 'Advance Paid'
FROM Job_AdvDetail b
INNER JOIN Job_AdvHeader a ON b.BranchCode=a.BranchCode 
AND b.AdvNo= a.AdvNo
LEFT JOIN Mas_Company c ON a.CustCode=c.CustCode AND a.CustBranch=c.Branch
WHERE a.DocStatus<>99 AND b.AdvNet>0 {0}
GROUP BY a.CustCode,b.ForJNo
ORDER BY a.CustCode,b.ForJNo
"
        Return String.Format(tSql, sqlW)
    End Function
    Function SQLSelectAdvReport() As String
        Dim tSql = "
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode='JOB_TYPE') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode='SHIP_BY') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
"
        Return tSql
    End Function
    Function SQLSelectContainerReport() As String
        Dim tSql = "
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
"
        Return tSql
    End Function
    Function SQLSelectReceiptSummary(sqlW As String) As String
        Dim tSql = "
select r.*,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+':' + r.PaidAmount+':',''),1,CHARINDEX(':',REPLACE(r.PaidDetail,r.PaidType+':' + r.PaidAmount+':',''))),':','') as PaidBank,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+':' + r.PaidAmount+':',''),CHARINDEX(':',REPLACE(r.PaidDetail,r.PaidType+':' + r.PaidAmount+':','')),100),':','') as PaidRef
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng as CustEName,
rh.TRemark as PaidDetail,
REPLACE(SUBSTRING(rh.TRemark,1,CHARINDEX(':',rh.TRemark)),':','')  as PaidType,
REPLACE(SUBSTRING(REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX(':',rh.TRemark)),''),1,CHARINDEX(':',REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX(':',rh.TRemark)),''))),':','')  as PaidAmount,
Sum(CASE WHEN id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(rd.AmtVat) as TotalVat,
Sum(rd.Amt50Tavi) as TotalWhtax,
Sum(rd.Net+rd.Amt50Tavi) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'')<>'' THEN 'N' ELSE 'Y' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT ','+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as InvNo
from Job_ReceiptHeader rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'')='' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.TRemark,rh.CancelProve
) r
"
        Return String.Format(tSql, sqlW)
    End Function
    Function SQLSelectVenderReport(sqlW As String, sqlAdd As String) As String
        Dim tSql As String = "
SELECT h.ApproveRef as 'Approve Ref#',h.PoNo as 'VenderInvNo',h.DocNo,d.ForJNo as JNo,c.NameEng as CustEName,b.Location as LocationRoute,
b.UnloadFinishDate as DeliveryDate,
b.BookingNo,b.CTN_NO,b.CTN_SIZE
" & sqlAdd & ",
SUM(d.Amt+d.AmtVAT) as TotalAmt,
SUM(CASE WHEN s.IsCredit=1 AND s.IsExpense=0 THEN d.Amt+d.AmtVAT ELSE 0 END) as TotalAdvance,
SUM(CASE WHEN s.IsCredit=0 AND s.IsExpense=1 THEN d.Amt+d.AmtVAT ELSE 0 END) as TotalCost,
SUM(CASE WHEN s.IsCredit=1 AND s.IsExpense=1 AND d.AmtVat>0 THEN d.Amt ELSE 0 END) as 'Claim Vat Amt',
SUM(CASE WHEN s.IsCredit=1 AND s.IsExpense=1 AND d.AmtVat>0 THEN d.AmtVat ELSE 0 END) as 'Claim Vat',
h.Remark,h.PaymentRef
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
LEFT OUTER JOIN dbo.Mas_Vender AS v ON h.VenCode = v.VenCode
LEFT OUTER JOIN Job_Order j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
LEFT OUTER JOIN Mas_Company c ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
LEFT OUTER JOIN Job_LoadInfoDetail b ON h.BranchCode=b.BranchCode 
AND h.RefNo=b.CTN_NO AND j.BranchCode=b.BranchCode AND j.JNo=b.JNo
LEFT OUTER JOIN Job_LoadInfo t ON b.BranchCode=t.BranchCode AND b.BookingNo=t.BookingNo
LEFT OUTER JOIN Job_SrvSingle  s ON d.SICode=s.SICode
LEFT OUTER JOIN Job_TransportPrice p ON h.BranchCode=p.BranchCode
AND b.LocationID=p.LocationID AND h.VenCode=p.VenderCode AND t.NotifyCode=p.CustCode
AND d.SICode=p.SICode
WHERE NOT ISNULL(h.CancelProve,'')<>'' {0}
GROUP BY h.ApproveRef,h.PoNo,h.DocNo,d.ForJNo,c.NameEng,j.VesselName,b.Location,
b.ActualYardDate,b.UnloadFinishDate,b.ReturnDate,
b.BookingNo,b.CTN_NO,b.CTN_SIZE,h.Remark,h.PaymentRef
ORDER BY h.PoNo,h.DocNo
"
        Return String.Format(tSql, sqlW)
    End Function
    Function SQLSelectAdvClear(sqlW As String) As String
        Dim tSql = "
select a.BranchCode,a.AdvNo,a.AdvBy,a.AdvDate,a.TotalAdvance,a.MainCurrency,c.ClrNo,b.ClrDate,
c.JobNo,j.DutyDate,j.CSCode,c.SDescription,d.GLAccountCode as CostCenter,
ISNULL(e.GLAccountCodeCost,e.GLAccountCodeSales) as AccountCode,c.Tax50TaviRate,c.VATRate,
c.UsedAmount,c.ChargeVAT,c.Tax50Tavi,c.BNet,b.DocStatus
from Job_AdvHeader a inner join Job_ClearDetail c
on a.BranchCode=c.BranchCode 
and a.AdvNo=c.AdvNO
inner join Job_ClearHeader b
on c.BranchCode=b.BranchCode 
and c.ClrNo=b.ClrNo
inner join Job_Order j
on c.BranchCode=j.BranchCode 
and c.JobNo=j.JNo
inner join Mas_Company d
on j.CustCode=d.CustCode AND j.CustBranch=d.Branch
inner join Job_SrvSingle e
on c.SICode=e.SICode
where b.DocStatus<>99 {0}
order by j.DutyDate,j.JNo
"
        Return String.Format(tSql, sqlW)
    End Function
    Function SQLSelectAdvSumClear(sqlW As String) As String
        Dim tSql = "
select a.BranchCode,a.AdvNo,ISNULL(f.AccTName,'') + ' / '+ ISNULL(g.AccTName,'') as GLDesc,
d.GLAccountCode as CostCenter,
ISNULL(e.GLAccountCodeCost,e.GLAccountCodeSales) as AccountCode,
SUM(c.UsedAmount) as Amt,SUM(c.ChargeVAT) as Vat,SUM(c.Tax50Tavi) as Wht,SUM(c.BNet) as Net
from Job_AdvHeader a inner join Job_ClearDetail c
on a.BranchCode=c.BranchCode 
and a.AdvNo=c.AdvNO
inner join Job_ClearHeader b
on c.BranchCode=b.BranchCode 
and c.ClrNo=b.ClrNo
inner join Job_Order j
on c.BranchCode=j.BranchCode 
and c.JobNo=j.JNo
inner join Mas_Company d
on j.CustCode=d.CustCode AND j.CustBranch=d.Branch
inner join Job_SrvSingle e
on c.SICode=e.SICode
left join Mas_Account f on f.AccCode=d.GLAccountCode
left join Mas_Account g on g.AccCode=ISNULL(e.GLAccountCodeCost,e.GLAccountCodeSales)
where b.DocStatus<>99 {0}
group by a.BranchCode,a.AdvNo,f.AccTName,g.AccTName,
d.GLAccountCode,ISNULL(e.GLAccountCodeCost,e.GLAccountCodeSales)
            "
        Return String.Format(tSql, sqlW)
    End Function
    Public Function SQLSelectAdvForWhTax(sqlW As String) As String
        Dim tSql = "
select BranchCode,AdvNo,(CASE WHEN Rate50Tavi=1 THEN 'ค่าขนส่ง 1%' ELSE CONCAT('ค่าบริการ ',Rate50Tavi,'%') END) as SDescription,
SUM(AdvAmount) as AdvAmount,SUM(Charge50Tavi) as Charge50Tavi
,MAX(ForJNo) as ForJNo,Rate50Tavi 
from Job_AdvDetail where Rate50Tavi>0 {0}
group by BranchCode,AdvNo,Rate50Tavi
        "
        Return String.Format(tSql, sqlW)
    End Function

    Public Sub UpdateClearStatus()
        Main.DBExecute(GetSession("ConnJob"), SQLUpdateClrStatusToClear())
        Main.DBExecute(GetSession("ConnJob"), SQLUpdateClrStatusFromAdvance())
        Main.DBExecute(GetSession("ConnJob"), SQLUpdateClrStatusToComplete())
        Main.DBExecute(GetSession("ConnJob"), SQLUpdateClrStatusToInComplete())
    End Sub
    Function GetSQLCommand(cliteria As String, fldDate As String, fldCust As String, fldJob As String, fldEmp As String, fldVend As String, fldStatus As String, fldBranch As String, Optional fldSICode As String = "", Optional fldGroup As String = "") As String
        Dim sqlW As String = ""
        If cliteria Is Nothing Then
            Return ""
        End If

        For Each str As String In cliteria.Split(",")
            If str <> "" Then
                If sqlW <> "" Then
                    If str.Substring(0, 2) <> "Or" Then
                        sqlW &= " And ("
                    Else
                        sqlW = "(" & sqlW & ")"
                        str = str.Replace("Or", " Or ((")
                    End If
                Else
                    sqlW &= "("
                End If
                Dim bFound As Boolean = False
                If fldBranch <> "" And str.IndexOf("[BRANCH]") >= 0 Then
                    str = ProcessCliteria(str, "[BRANCH]", fldBranch)
                    bFound = True
                End If
                If fldDate <> "" And str.IndexOf("[DATE]") >= 0 Then
                    str = ProcessCliteria(str, "[DATE]", fldDate)
                    bFound = True
                End If
                If fldCust <> "" And str.IndexOf("[CUST]") >= 0 Then
                    str = ProcessCliteria(str, "[CUST]", fldCust)
                    bFound = True
                End If
                If fldJob <> "" And str.IndexOf("[JOB]") >= 0 Then
                    str = ProcessCliteria(str, "[JOB]", fldJob)
                    bFound = True
                End If
                If fldEmp <> "" And str.IndexOf("[EMP]") >= 0 Then
                    str = ProcessCliteria(str, "[EMP]", fldEmp)
                    bFound = True
                End If
                If fldStatus <> "" And str.IndexOf("[STATUS]") >= 0 Then
                    str = ProcessCliteria(str, "[STATUS]", fldStatus)
                    bFound = True
                End If
                If fldVend <> "" And str.IndexOf("[VEND]") >= 0 Then
                    str = ProcessCliteria(str, "[VEND]", fldVend)
                    bFound = True
                End If
                If fldSICode <> "" And str.IndexOf("[CODE]") >= 0 Then
                    str = ProcessCliteria(str, "[CODE]", fldSICode)
                    bFound = True
                End If
                If fldGroup <> "" And str.IndexOf("[GROUP]") >= 0 Then
                    str = ProcessCliteria(str, "[GROUP]", fldGroup)
                    bFound = True
                End If
                If bFound = True Then
                    sqlW &= str
                Else
                    sqlW &= "1=1"
                End If
                If sqlW <> "" Then
                    sqlW &= ")"
                End If
            End If
        Next
        If sqlW.Substring(0, 2) = "((" Then
            sqlW &= ")"
        End If
        Return sqlW
    End Function
    Function ProcessCliteria(str As String, key As String, val As String) As String
        If str.Contains(key) Then
            Dim fld As String = str.Replace(key, " " & val & " ")
            fld = FindFieldCliteria(fld) & FindValueCliteria(str)
            Return fld
        Else
            Return str
        End If
    End Function
    Function FindFieldCliteria(str As String) As String
        If str.IndexOf(">=") > 0 Then
            Return str.Split(">=")(0)
        End If
        If str.IndexOf("<=") > 0 Then
            Return str.Split("<=")(0)
        End If
        If str.IndexOf("<>") > 0 Then
            Return str.Split("<>")(0)
        End If
        If str.IndexOf("LIKE%") > 0 Then
            Return str.Split("LIKE%")(0)
        End If
        If str.IndexOf("=") > 0 Then
            Return str.Split("=")(0)
        End If
        Return ""
    End Function

    Function FindValueCliteria(str As String) As String
        If str.IndexOf(">=") > 0 Then
            Return ">='" & str.Split(">=")(1).Substring(1) & "'"
        End If
        If str.IndexOf("<=") > 0 Then
            Return "<='" & str.Split("<=")(1).Substring(1) & "'"
        End If
        If str.IndexOf("<>") > 0 Then
            Return "<>'" & str.Split("<>")(1).Substring(1) & "'"
        End If
        If str.IndexOf("LIKE%") > 0 Then
            Return "Like '" & str.Split("LIKE%")(1).Substring(3) & "%'"
        End If
        If str.IndexOf("=") > 0 Then
            Return "='" & str.Split("=")(1) & "'"
        End If
        Return "''"
    End Function
    Function GetSession(sName As String) As String
        Try
            Return HttpContext.Current.Session(sName).ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Function GetMonthThai(mn As Integer) As String
        Select Case mn
            Case 1
                Return "มกราคม"
            Case 2
                Return "กุมภาพันธ์"
            Case 3
                Return "มีนาคม"
            Case 4
                Return "เมษายน"
            Case 5
                Return "พฤษภาคม"
            Case 6
                Return "มิถุนายน"
            Case 7
                Return "กรกฏาคม"
            Case 8
                Return "สิงหาคม"
            Case 9
                Return "กันยายน"
            Case 10
                Return "ตุลาคม"
            Case 11
                Return "พฤศจิกายน"
            Case 12
                Return "ธันวาคม"
            Case Else
                Return ""
        End Select
    End Function
End Module
