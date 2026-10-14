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
    Dim sqlWhere = ""
    If ViewBag.User <> "" Then
        Dim conn = ViewBag.CONNECTION_JOB
        '        Dim sqlSource = "
        'select
        'CONCAT(replace(j.TotalContainer,' ',''),',') as TotalContainer
        ',count(*) as CountJob
        ',jt.JobTypeName
        ',j.CustCode
        ',j.CustBranch
        ',c.NameThai as CustName
        'From job_order j
        'inner join Mas_Company c on j.CustCode=c.CustCode and j.CustBranch=c.Branch
        'inner join
        '(
        'select convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName
        'from Mas_Config where ConfigCode='JOB_TYPE'
        ') jt on j.JobType=jt.JobType
        'where j.JobStatus<>99
        '{0}
        'Group by CONCAT(replace(j.TotalContainer,' ',''),','),jt.JobTypeName,j.CustCode,c.NameThai
        'order by c.NameThai
        '"
        sqlSource = "select
CONCAT(replace(j.TotalContainer,' ',''),',') as TotalContainer
,count(*) as CountJob
,jt.JobTypeName
,j.CustCode
,j.CustBranch
,c.NameThai as CustName
,c.TaxNumber
,c.EAddress1
,c.TAddress1
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
Group by CONCAT(replace(j.TotalContainer,' ',''),','),jt.JobTypeName,j.CustCode,j.CustBranch,c.NameThai,LoginName,c.TaxNumber,c.EAddress1,c.TAddress1
order by c.NameThai
"

        Dim sqlSourceByJob = "
select j.JNo,CONCAT(replace(j.TotalContainer,' ',''),',') as TotalContainer,count(*) as CountJob,jt.JobTypeName,j.CustBranch,c.NameThai as CustName,c.TaxNumber ,c.EAddress1
From job_order j inner join Mas_Company c on j.CustCode=c.CustCode and j.CustBranch=c.Branch
inner join
(
select convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName
from Mas_Config where ConfigCode='JOB_TYPE'
) jt on j.JobType=jt.JobType
where j.JobStatus<>99   AND j.TotalContainer <> ','
{0}
Group by j.JNo,CONCAT(replace(j.TotalContainer,' ',''),','),jt.JobTypeName,c.NameThai,c.TaxNumber ,c.EAddress1
order by c.NameThai
"


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

<div style="margin:0; padding:0;">
    <strong>SUMMARY: From Date [@beginDate] - To Date  [@endDate]</strong>
    <br />
    <table id="tbSummary" style="border-collapse:collapse;width:100%" border="1">
        <thead>
            <tr>

                <th rowspan="2">Customer</th>
                <th rowspan="2">CusCode / Branch</th>
                <th rowspan="2">Jobs</th>
                <th colspan="3">IMPORT</th>
                <th colspan="3">EXPORT</th>
                <th colspan="3">OTHER</th>
            </tr>
            <tr>
                <th>20</th>
                <th>40</th>
                <th>Others</th>
                <th>20</th>
                <th>40</th>
                <th>Others</th>
                <th>20</th>
                <th>40</th>
                <th>Others</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
</div>
<!--DETAILS:-->
<br />
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var jsonData = @Html.Raw(jsonData);
    var jsonDataD = @Html.Raw(jsonDataD);
    var html = '';
    var lst = [];
    var lastCust = '';
    var obj = {
        CustCode: '',
        CustName: '',
	CustBranch: '',
        TaxNumber: '',
        CountJob: 0,
        SUMIM20: 0,
        SUMIM40: 0,
        SUMIMOTH: 0,
        SUMEX20: 0,
        SUMEX40: 0,
        SUMEXOTH: 0,
        SUMOT20: 0,
        SUMOT40: 0,
        SUMOTOTH: 0
    };

    function renderTable2(custName) {
        let rowCount = 0;
        let strHtml = "";
        for (let o of jsonDataD.filter(r => r.CustName == custName )) {
            rowCount++;
            strHtml += '<tr>';
            strHtml += '<td style="text-align:center">' + rowCount + '</td>';
            strHtml += '<td>' + o.JobTypeName + '</td>';
            strHtml += '<td>' + o.TotalContainer + '</td>';
            strHtml += '<td>' + o.JNo + '</td>';
            strHtml += '</tr>';
        }
        strHtml += '<tr>';
        strHtml += '<th style="text-align:center" colspan="4">รวมทั้งหมด ' + rowCount + '</td>';
        strHtml += '</tr>';
        return strHtml;
    }

function renderTable() {

    // ===== 1) GROUP DATA BY CustCode =====
    let map = {};

    for (let o of jsonData) {

        let key = `${o.CustCode.trim().toUpperCase()}|${o.CustBranch}`;

        if (!map[key]) {
            let displayAddress = (o.EAddress1 && o.EAddress1.trim() !== '')
                                 ? o.EAddress1
                                 : (o.TAddress1 || '');
            map[key] = {
                CustCode: o.CustCode,
		CustBranch: o.CustBranch,
                CustName: o.CustName.trim(),
                TaxNumber: o.TaxNumber || '',
                Address: displayAddress,
                CountJob: 0,
                SUMIM20: 0, SUMIM40: 0, SUMIMOTH: 0,
                SUMEX20: 0, SUMEX40: 0, SUMEXOTH: 0,
                SUMOT20: 0, SUMOT40: 0, SUMOTOTH: 0
            };
        }

        let obj = map[key];

        if (o.TotalContainer !== ',') {
            obj.CountJob += o.CountJob;
        }

        ProcessContainer(o.TotalContainer.toUpperCase(), obj, o);
    }

    let lst = Object.values(map);

    // ===== 2) GRAND TOTAL =====
    let grandTotal = {
        Jobs: 0,
        IM20: 0, IM40: 0, IMOth: 0,
        EX20: 0, EX40: 0, EXOth: 0,
        OT20: 0, OT40: 0, OTOth: 0
    };

    // ===== 3) BUILD TABLE =====
    let html = '';

    for (let o of lst) {

        if (o.CountJob > 0) {

            // ---- accumulate grand total ----
            grandTotal.Jobs += o.CountJob;
            grandTotal.IM20 += o.SUMIM20;
            grandTotal.IM40 += o.SUMIM40;
            grandTotal.IMOth += o.SUMIMOTH;
            grandTotal.EX20 += o.SUMEX20;
            grandTotal.EX40 += o.SUMEX40;
            grandTotal.EXOth += o.SUMEXOTH;
            grandTotal.OT20 += o.SUMOT20;
            grandTotal.OT40 += o.SUMOT40;
            grandTotal.OTOth += o.SUMOTOTH;

            // ---- table row (รูปแบบเดิม) ----
            html += '<tr>';
            html += `
                <td>
                   <a href="javascript:void(0)"
                    onclick="handleClickCust('${o.CustCode}')" 
                        style="text-decoration:none; color:#062547; font-weight:bold; cursor:pointer;">
                        ${o.CustName}
                         </a>
                    <button style="float:right" onclick="handleClick('${o.CustCode}','${o.CustBranch}')">v</button>
                </td>`;
            html += `<td style="text-align:right">${o.CustCode} - ${o.CustBranch}</td>`;
            html += `<td style="text-align:right">${o.CountJob}</td>`;
            html += `<td style="text-align:right">${ShowNumber(o.SUMIM20 || '', 2)}</td>`;
            html += `<td style="text-align:right">${ShowNumber(o.SUMIM40 || '', 2)}</td>`;
            html += `<td style="text-align:right">${ShowNumber(o.SUMIMOTH || '', 2)}</td>`;
            html += `<td style="text-align:right">${ShowNumber(o.SUMEX20 || '', 2)}</td>`;
            html += `<td style="text-align:right">${ShowNumber(o.SUMEX40 || '', 2)}</td>`;
            html += `<td style="text-align:right">${ShowNumber(o.SUMEXOTH || '', 2)}</td>`;
            html += `<td style="text-align:right">${ShowNumber(o.SUMOT20 || '', 2)}</td>`;
            html += `<td style="text-align:right">${ShowNumber(o.SUMOT40 || '', 2)}</td>`;
            html += `<td style="text-align:right">${ShowNumber(o.SUMOTOTH || '', 2)}</td>`;
            html += '</tr>';
        }
    }

    // ===== 4) GRAND TOTAL ROW =====
    html += `
        <tr style="background-color:#c3c7d5; font-weight:bold; border-top:2px solid #555;">
            <td colspan="2" style="text-align:center">GRAND TOTAL</td>
            <td style="text-align:right">${grandTotal.Jobs}</td>
            <td style="text-align:right">${ShowNumber(grandTotal.IM20,2)}</td>
            <td style="text-align:right">${ShowNumber(grandTotal.IM40,2)}</td>
            <td style="text-align:right">${ShowNumber(grandTotal.IMOth,2)}</td>
            <td style="text-align:right">${ShowNumber(grandTotal.EX20,2)}</td>
            <td style="text-align:right">${ShowNumber(grandTotal.EX40,2)}</td>
            <td style="text-align:right">${ShowNumber(grandTotal.EXOth,2)}</td>
            <td style="text-align:right">${ShowNumber(grandTotal.OT20,2)}</td>
            <td style="text-align:right">${ShowNumber(grandTotal.OT40,2)}</td>
            <td style="text-align:right">${ShowNumber(grandTotal.OTOth,2)}</td>
        </tr>`;

    $('#tbSummary tbody').html(html);
}




    function ProcessContainer(a, b, c) {
        if (a == ',') return;
        let s = a.split(',');
        for (let i = 0; i < s.length; i++) {
            let item = s[i].trim();
            if (item !== '') {
                let match20 = item.match(/^(\d+)[xX].*20/);
                let match40 = item.match(/^(\d+)[xX].*40/);

                if (match20) {
                    let count = parseInt(match20[1]);
                    switch (c.JobTypeName) {
                        case 'IMPORT': b.SUMIM20 += (count * c.CountJob); break;
                        case 'EXPORT': b.SUMEX20 += (count * c.CountJob); break;
                        default: b.SUMOT20 += (count * c.CountJob); break;
                    }
                } else if (match40) {
                    let count = parseInt(match40[1]);
                    switch (c.JobTypeName) {
                        case 'IMPORT': b.SUMIM40 += (count * c.CountJob); break;
                        case 'EXPORT': b.SUMEX40 += (count * c.CountJob); break;
                        default: b.SUMOT40 += (count * c.CountJob); break;
                    }
                } else {
                    let count = parseInt(item.split(/[xX]/)[0]) || 1;
                    switch (c.JobTypeName) {
                        case 'IMPORT': b.SUMIMOTH += (count * c.CountJob); break;
                        case 'EXPORT': b.SUMEXOTH += (count * c.CountJob); break;
                        default: b.SUMOTOTH += (count * c.CountJob); break;
                    }
                }
            }
        }
    }

    function handleClick(custcode,custbranch) {
        let bd = getQueryString('BeginDate');
        let ed = getQueryString('EndDate');
        let jt = getQueryString('JobType');
        let sb = getQueryString('ShipBy');
        window.open(path + `Tracking/Dashboard?form=8_reportByjob&BeginDate=${bd}&EndDate=${ed}&CustCode=${custcode}&CustBranch=${custbranch}&JobType=${jt}&ShipBy=${sb}`);
    }
    function handleClickCust(custcode) {
        let bd = getQueryString('BeginDate');
        let ed = getQueryString('EndDate');
        let jt = getQueryString('JobType');
        let sb = getQueryString('ShipBy');
        window.open(path + `Tracking/Dashboard?form=8_customer&BeginDate=${bd}&EndDate=${ed}&CustCode=${custcode}&JobType=${jt}&ShipBy=${sb}`);
    }
    function closeDiaLog() { $('#popup').html(""); }

    function openDailog(custName) {
        $('#popup').html(`<dialog open style="width:50vw;max-height: 50vh; overflow: scroll;">
            <div><button style="float:right" onclick="closeDiaLog();">X</button></div>
            <table style="border-collapse:collapse;width:100%" border="1">
                <thead>
                    <tr>
                        <th>No.</th>
                        <th>Job Type</th>
                        <th>Volume</th>
                        <th>JNo</th>
                    </tr>
                </thead>
                <tbody>
                    ${renderTable2(custName)}
                </tbody>
            </table>
        </dialog>`);
    }

    renderTable();
</script>