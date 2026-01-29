@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewData("Title") = "Total Containers"
    Dim beginDate = New Date(Today.Year, Today.Month, 1).ToString("yyyy-MM-dd")
    If Request.QueryString("BeginDate") IsNot Nothing Then
        beginDate = Request.QueryString("BeginDate")
    End If
    Dim endDate = New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
    If Request.QueryString("EndDate") IsNot Nothing Then
        endDate = Request.QueryString("EndDate")
    End If
    Dim custCode = ""
    If Request.QueryString("CustCode") IsNot Nothing Then
        custCode = Request.QueryString("CustCode")
    End If
    Dim jobType = ""
    If Request.QueryString("JobType") IsNot Nothing Then
        jobType = Request.QueryString("JobType")
    End If
    Dim shipBy = ""
    If Request.QueryString("ShipBy") IsNot Nothing Then
        shipBy = Request.QueryString("ShipBy")
    End If
    Dim jsonData = ""
    Dim jsonDataD = ""
    Dim sqlSource = ""

    If ViewBag.User <> "" Then
        Dim conn = ViewBag.CONNECTION_JOB

        sqlSource = "select
CONCAT(replace(j.TotalContainer,' ',''),',') as TotalContainer
,count(*) as CountJob
,jt.JobTypeName
,j.CustCode
,c.NameThai as CustName
,LoginName
From job_order j
inner join Mas_Company c on j.CustCode=c.CustCode and j.CustBranch=c.Branch
inner join
(
select convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName
from Mas_Config where ConfigCode='JOB_TYPE'
) jt on j.JobType=jt.JobType
where j.JobStatus<>99
{0}

Group by CONCAT(replace(j.TotalContainer,' ',''),','),jt.JobTypeName,j.CustCode,c.NameThai,LoginName
order by c.NameThai
"
        Dim sqlSourceByJob = "
select j.JNo,CONCAT(replace(j.TotalContainer,' ',''),',') as TotalContainer,count(*) as CountJob,jt.JobTypeName,c.NameThai as CustName ,c.TaxNumber ,c.EAddress1,c.TAddress1,c.Branch
From job_order j inner join Mas_Company c on j.CustCode=c.CustCode and j.CustBranch=c.Branch
inner join
(
select convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName
from Mas_Config where ConfigCode='JOB_TYPE'
) jt on j.JobType=jt.JobType
where j.JobStatus<>99 AND j.TotalContainer <> ' '
{0}
Group by j.JNo,CONCAT(replace(j.TotalContainer,' ',''),','),jt.JobTypeName,c.NameThai,c.TaxNumber,c.EAddress1,c.TAddress1,c.Branch
order by c.NameThai
"

        Dim sqlWhere = ""
        sqlWhere &= String.Format(" AND j.DocDate>='{0}' and j.DocDate<='{1}'", beginDate, endDate)
        If custCode <> "" Then
            sqlWhere &= String.Format(" AND j.CustCode='{0}'", custCode)
        End If
        If jobType <> "" Then
            sqlWhere &= String.Format(" AND j.JobType={0}", jobType)
        End If
        If shipBy <> "" Then
            sqlWhere &= String.Format(" AND j.ShipBy={0}", shipBy)
        End If

        If ViewBag.UserGroup = "C" Then
            'sqlWhere &= "And J.loginname = '" & ViewBag.Use & "'"
            sqlWhere &= String.Format(" And loginname = '{0}'", ViewBag.User)


        End If
        Dim sqlTemp = String.Format(sqlSource, sqlWhere)
        Using rs = New CUtil(conn).GetTableFromSQL(sqlTemp)
            jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(rs)
        End Using

        Dim sqlTemp2 = String.Format(sqlSourceByJob, sqlWhere)
        Using rs2 = New CUtil(conn).GetTableFromSQL(sqlTemp2)
            jsonDataD = Newtonsoft.Json.JsonConvert.SerializeObject(rs2)
        End Using
    End If
End Code

<style>
    th {
        text-align: center
    }
</style>

<div id="customerInfo" style="
    margin-top: 10px;
    margin-bottom: 10px;
    line-height: 1.4;
    border: 1px solid black;
    border-radius: 8px;
    padding: 10px;
    width: fit-content;
    min-width: 500px;
    font-family: Arial, sans-serif;
    font-size: 14px;">
    <div>NAME : <span id="lblCustName"></span></div>
    <div>ADDRESS : <span id="lblAddress"></span></div>
    <div>TAX-ID : <span id="lblTaxNumber"></span> BRANCH : <span id="lblBranch"></span></div>
   
</div>

<script type="text/javascript">
    var path = '@Url.Content("~")';
    var jsonData = @Html.Raw(jsonData);
    var jsonDataD = @Html.Raw(jsonDataD);

   if (jsonDataD.length > 0) {
        let firstRow = jsonDataD[0];
        console.log('jsonDataD:',firstRow)
        let displayAddr = (firstRow.EAddress1 && firstRow.EAddress1.trim() !== '') 
                          ? firstRow.EAddress1 
                          : (firstRow.TAddress1 || '-');

        document.getElementById('lblCustName').innerText = (firstRow.CustName || '').toUpperCase();
        document.getElementById('lblAddress').innerText = (displayAddr || '').toUpperCase();
        document.getElementById('lblTaxNumber').innerText = firstRow.TaxNumber || '-';
        
       let branchRaw = firstRow.Branch ? firstRow.Branch.toString().trim() : '';
       let branchText = '';
	if (/^0+$/.test(branchRaw)) { 
    	branchText = 'HEAD OFFICE';
	} else {
   	 branchText = branchRaw || '-';
	}
     document.getElementById('lblBranch').innerText = branchText;
     }
    var html = '';

    var lastCust = '';


    function renderTable2() {
        let rowCount = 0;
        let strHtml = "";
        let lastCustomer = "";
        let ttcontainer = 0;
        for (let o of jsonDataD) {
            let ctn = o.TotalContainer || '';
            let amctn = 0;
            let sptctn = ctn.split(',');
            let afterX = '';
            let beforeX = '';

    		// แยกด้วย comma แล้ววนลูปแต่ละค่า
    	    let parts = ctn.split(',').map(p => p.trim()).filter(p => p);

    		for (let part of parts) {
        		const match = part.match(/^(\d+)[xX]/);
        		if (match) {
            			amctn += parseInt(match[1]);
        		}
    		}

            ttcontainer += amctn;
            rowCount++;

            //display details
            strHtml += '<tr>';
            strHtml += '<td style="text-align:center">' + rowCount + '</td>';
            strHtml += '<td>' + o.CustName + '</td>';
            strHtml += '<td>' + o.JNo + '</td>';
            strHtml += '<td>' + o.JobTypeName + '</td>';
            strHtml += '<td>' + o.TotalContainer.trimEnd(',') + '</td>';

            //strHtml += '<td>' + o.CountJob + '</td>';

            strHtml += '</tr>';

        }
        strHtml += '<tr>';
        strHtml += '<th style="text-align:center" colspan="5">TOTAL Container:' + ttcontainer + '</td>';

        strHtml += '</tr>';


        $('#tbResult tbody').html(strHtml);
        return strHtml;
    }

    renderTable2();
</script>
