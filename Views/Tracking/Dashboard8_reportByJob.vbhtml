@Code
    Layout = "~/Views/Shared/_ReportLandscape_Dashboard8.vbhtml"
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
    Dim custBranch = ""
    If Request.QueryString("CustBranch") IsNot Nothing Then
        custBranch = Request.QueryString("CustBranch")
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
,c.CustCode
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

Group by CONCAT(replace(j.TotalContainer,' ',''),','),jt.JobTypeName,j.CustCode,c.NameThai,LoginName,c.CustCode
order by c.NameThai
"
        '        Dim sqlSource = "
        'select CONCAT(replace(j.TotalContainer,' ',''),',') as TotalContainer,count(*) as CountJob,jt.JobTypeName,c.NameThai as CustName
        'From job_order j inner join Mas_Company c on j.CustCode=c.CustCode and j.CustBranch=c.Branch
        'inner join
        '(
        'select convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName
        'from Mas_Config where ConfigCode='JOB_TYPE'
        ') jt on j.JobType=jt.JobType
        'where j.JobStatus<>99
        '{0}
        'Group by CONCAT(replace(j.TotalContainer,' ',''),','),jt.JobTypeName,c.NameThai
        'order by c.NameThai
        '"

        Dim sqlSourceByJob = "
select j.JNo,CONCAT(replace(j.TotalContainer,' ',''),',') as TotalContainer,count(*) as CountJob,jt.JobTypeName,c.NameThai as CustName,c.Branch,c.CustCode
From job_order j inner join Mas_Company c on j.CustCode=c.CustCode and j.CustBranch=c.Branch
inner join
(
select convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName
from Mas_Config where ConfigCode='JOB_TYPE'
) jt on j.JobType=jt.JobType
where j.JobStatus<>99 AND j.TotalContainer <> ' '
{0}
Group by j.JNo,CONCAT(replace(j.TotalContainer,' ',''),','),jt.JobTypeName,c.NameThai,c.Branch,c.CustCode
order by c.NameThai
"

        Dim sqlWhere = ""
        sqlWhere &= String.Format(" AND j.DocDate>='{0}' and j.DocDate<='{1}'", beginDate, endDate)
        If custCode <> "" Then
            sqlWhere &= String.Format(" AND j.CustCode='{0}'", custCode)
        End If
        If custBranch <> "" Then
            sqlWhere &= String.Format(" AND j.CustBranch={0}", custBranch)
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

@*<div id="popup" style=" position: -webkit-sticky; position: sticky; top: 0;">
    </div>*@

<strong>DETAILS: From Date [@beginDate] To Date  [@endDate] | CustCode [@custCode] - Branch [@custBranch]</strong>


<table id="tbResult" style="border-collapse:collapse; width:100%" border="1">
        <thead>
            <tr>
                <th>
                    No.
                </th>
                <th>
                    Customer
                </th>
                <th>
                    Job No
                </th>
                <th>
                    Job Type
                </th>
                <th>
                    Containers
                </th>

            </tr>
        </thead>
        <tbody></tbody>
    </table>

<script type="text/javascript">
    var path = '@Url.Content("~")';
    var jsonData = @Html.Raw(jsonData);
    var jsonDataD = @Html.Raw(jsonDataD);
    var html = '';
  
    var lastCust = '';
   

    function renderTable2() {
        let rowCount = 0;
        let strHtml = "";
        let lastCustomer = "";
        let ttcontainer = 0;
            console.log('jsonDataD:',jsonDataD)
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
            //strHtml += '<td>' + o.CustName + '</td>';
        strHtml += '<td>';
        strHtml += '  <a href="javascript:void(0)" ';
        strHtml += '     onclick="handleClickCust(\'' + o.CustCode + '\')" '; 
        strHtml += '     style="text-decoration:none; color:#062547; font-weight:bold; cursor:pointer;">';
        strHtml +=       o.CustName;
        strHtml += '  </a>';
        strHtml += '</td>';

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
    function handleClickCust(custcode) {
        let bd = getQueryString('BeginDate');
        let ed = getQueryString('EndDate');
        let jt = getQueryString('JobType');
        let sb = getQueryString('ShipBy');
        window.open(path + `Tracking/Dashboard?form=8_customer&BeginDate=${bd}&EndDate=${ed}&CustCode=${custcode}&JobType=${jt}&ShipBy=${sb}`);
    }

    renderTable2();
</script>
