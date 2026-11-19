@Code
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
    If ViewBag.User <> "" Then
        Dim conn = ViewBag.CONNECTION_JOB
        Dim sqlSource = "
select CONCAT(replace(j.TotalContainer,' ',''),',') as TotalContainer,count(*) as CountJob,jt.JobTypeName,c.NameThai as CustName
From job_order j inner join Mas_Company c on j.CustCode=c.CustCode and j.CustBranch=c.Branch
inner join
(
select convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName
from Mas_Config where ConfigCode='JOB_TYPE'
) jt on j.JobType=jt.JobType
where j.JobStatus<>99
{0}
Group by CONCAT(replace(j.TotalContainer,' ',''),','),jt.JobTypeName,c.NameThai
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
        Dim sqlTemp = String.Format(sqlSource, sqlWhere)
        Using rs = New CUtil(conn).GetTableFromSQL(sqlTemp)
            jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(rs)
        End Using
    End If
End Code
SUMMARY:
<br />
<table id="tbSummary" style="border-collapse:collapse;" border="1">
    <thead>
        <tr>
            <th rowspan="2">Customer</th>
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
@*
    DETAILS:
    <br />
    <table id="tbResult" style="border-collapse:collapse;" border="1">
        <thead>
            <tr>
                <th>
                    Customer
                </th>
                <th>
                    Job Type
                </th>
                <th>
                    Volume
                </th>
                <th>
                    Count
                </th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
*@
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var jsonData = @Html.Raw(jsonData);
    var html = '';
    var lst = [];
    var lastCust = '';
    var obj = {
        CustName: '',
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
    var sumIm20 = 0;
    var sumEx20 = 0;
    var sumOt20 = 0;
    var sumIm40 = 0;
    var sumEx40 = 0;
    var sumOt40 = 0;
    let sumImOt = 0;
    let sumExOt = 0;
    let sumOtOt = 0;
    let countJob = 0;
    function renderTable() {
        let rowCount = 0;
        for (let o of jsonData) {
            //if change row then add summary then move to new record
            if (lastCust !== o.CustName && lastCust !== '') {
                lst.push(obj);
                obj = {
                    CustName: '',
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
                lastCust = o.CustName;
            }
            obj.CustName = o.CustName;
            obj.CountJob += o.CountJob;
            //calculate text accumulated
            ProcessContainer(o.TotalContainer.toUpperCase(), obj, o);

            //add summary
            countJob += o.CountJob;
            sumIm20 += obj.SUMIM20;
            sumIm40 += obj.SUMIM40;
            sumImOt += obj.SUMIMOTH;
            sumEx20 += obj.SUMEX20;
            sumEx40 += obj.SUMEX40;
            sumExOt += obj.SUMEXOTH;
            sumOt20 += obj.SUMOT20;
            sumOt40 += obj.SUMOT20;
            sumOtOt += obj.SUMOTOTH;

            //if first row then set the default value
            if (lastCust == '') {
                lastCust = o.CustName;
            }

            rowCount++;
            //check if last row then add last row immediately
            if (rowCount == jsonData.length) {
                lst.push(obj);
            }
/*
            //display details
            html += '<tr>';
            html += '<td>' + o.CustName + '</td>';
            html += '<td>' + o.JobTypeName + '</td>';
            html += '<td>' + o.TotalContainer + '</td>';
            html += '<td>' + o.CountJob + '</td>';
            html += '</tr>';
*/
        }
/*        
        //display details
        html += '<tr>';
        html += '<td colspan="3"></td > ';
        html += '<td>' + countJob + '</td>';
        html += '</tr>';
        $('#tbResult tbody').html(html);
*/
        html = '';
        for (let o of lst) {
            html += '<tr>';
            html += '<td>' + o.CustName + '</td>';
            html += '<td>' + o.CountJob + '</td>';
            html += '<td>' + (o.SUMIM20==0? '' : o.SUMIM20) + '</td>';
            html += '<td>' + (o.SUMIM40 == 0 ? '' : o.SUMIM40) + '</td>';
            html += '<td>' + (o.SUMIMOTH == 0 ? '' : o.SUMIMOTH) + '</td>';
            html += '<td>' + (o.SUMEX20 == 0 ? '' : o.SUMEX20) + '</td>';
            html += '<td>' + (o.SUMEX40 == 0 ? '' : o.SUMEX40) + '</td>';
            html += '<td>' + (o.SUMEXOTH == 0 ? '' : o.SUMEXOTH) + '</td>';
            html += '<td>' + (o.SUMOT20 == 0 ? '' : o.SUMOT20) + '</td>';
            html += '<td>' + (o.SUMOT40 == 0 ? '' : o.SUMOT40) + '</td>';
            html += '<td>' + (o.SUMOTOTH == 0 ? '' : o.SUMOTOTH) + '</td>';
            html += '</tr>';
        }
        html += '<tr>';
        html += '<td>TOTAL</td>';
        html += '<td>'+ countJob+'</td>';
        html += '<td>' + (sumIm20 == 0 ? '' : sumIm20) + '</td>';
        html += '<td>' + (sumIm40 == 0 ? '' : sumIm40) + '</td>';
        html += '<td>' + (sumImOt == 0 ? '' : sumImOt) + '</td>';
        html += '<td>' + (sumEx20 == 0 ? '' : sumEx20) + '</td>';
        html += '<td>' + (sumEx40 == 0 ? '' : sumEx40) + '</td>';
        html += '<td>' + (sumExOt == 0 ? '' : sumExOt) + '</td>';
        html += '<td>' + (sumOt20 == 0 ? '' : sumOt20) + '</td>';
        html += '<td>' + (sumOt40 == 0 ? '' : sumOt40) + '</td>';
        html += '<td>' + (sumOtOt == 0 ? '' : sumOtOt) + '</td>';
        html += '</tr>';

        $('#tbSummary tbody').html(html);
    }
    function ProcessContainer(a, b, c) {
        if (a == ',') {
            switch (c.JobTypeName) {
                case 'IMPORT':
                    b.SUMIMOTH += c.CountJob;
                    break;
                case 'EXPORT':
                    b.SUMEXOTH += c.CountJob;
                    break;
                default:
                    b.SUMOTOTH += c.CountJob;
                    break;
            }
            return;
        }
        let s = a.split(',');
        for (let i = 0; i < s.length; i++) {
            if (s[i] !== '') {
                if (s[i].indexOf('X') >= 0) {
                    let v = s[i].split('X');
                    if (v[0] !== '') {
                        if (v[1].indexOf('20') >= 0) {
                            switch (c.JobTypeName) {
                                case 'IMPORT':
                                    b.SUMIM20 += (CNum(v[0]) * c.CountJob);
                                    break;
                                case 'EXPORT':
                                    b.SUMEX20 += (CNum(v[0]) * c.CountJob);
                                    break;
                                default:
                                    b.SUMOT20 += (CNum(v[0]) * c.CountJob);
                                    break;
                            }
                        } else {
                            if (v[1].indexOf('40') >= 0) {
                                switch (c.JobTypeName) {
                                    case 'IMPORT':
                                        b.SUMIM40 += (CNum(v[0]) * c.CountJob);
                                        break;
                                    case 'EXPORT':
                                        b.SUMEX40 += (CNum(v[0]) * c.CountJob);
                                        break;
                                    default:
                                        b.SUMOT40 += (CNum(v[0]) * c.CountJob);
                                        break;
                                }
                            } else {
                                switch (c.JobTypeName) {
                                    case 'IMPORT':
                                        b.SUMIMOTH += (CNum(v[0]) * c.CountJob);
                                        break;
                                    case 'EXPORT':
                                        b.SUMEXOTH += (CNum(v[0]) * c.CountJob);
                                        break;
                                    default:
                                        b.SUMOTOTH += (CNum(v[0]) * c.CountJob);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    renderTable();
</script>
