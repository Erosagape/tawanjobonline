@Code
    ViewBag.Title = "Index"
End Code
<h3>Summary User Login</h3>
<div id="dvLoginCount">
    <table id="tbUser" class="table table-bordered" style="border:thin;width:100%">
        <thead>
            <tr>
                <th>Period</th>
                <th>User ID</th>
                <th>Log-in Date</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<h3>Summary Job Usages</h3>
<div id="dvJobCount">
    <table id="tbJobCount" class="table table-bordered" style="border:thin;width:100%">
        <thead>
            <tr>
                <th>Period</th>
                <th>Job Type</th>
                <th>Ship By</th>
                <th>Total</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
</div>
<h3>Summary Document Created</h3>
<div id="dvDocCount">
    <table id="tbDocCount" class="table table-bordered" style="border:thin;width:100%">
        <thead>
            <tr>
                <th>Period</th>
                <th>Doc Type</th>
                <th>Total</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetJobSummary')
        .done((r) => {
            if (r.length > 0) {
                let html = '';
                for (let d of r) {
                    if (d.JobTypeCode == 'ALL') {
                        if (d.JobMonth == 0) {
                            html += '<tr style="background-color:lightgreen;font-weight:bold">';
                        } else {
                            html += '<tr style="background-color:yellow;font-weight:bold">';
                        }
                    } else {
                        html += '<tr>';
                    }
                    html += '<td>' + d.Period + '</td>';
                    html += '<td>' + d.JobTypeName + '</td>';
                    html += '<td>' + d.ShipByName + '</td>';
                    html += '<td>' + d.TotalJob + '</td>';
                    html += '</tr>';
                }                
                $('#tbJobCount tbody').html(html);
            }
        });
    $.get(path + 'JobOrder/GetDocSummary')
        .done((r) => {
            if (r.length > 0) {
                let html = '';
                for (let d of r) {
                    if (d.Period.indexOf('ALL')>0) {
                        html += '<tr style="background-color:lightgreen;font-weight:bold">';
                    } else {
                        html += '<tr>';
                    }
                    html += '<td>' + d.Period + '</td>';
                    html += '<td>' + d.DocType + '</td>';
                    html += '<td>' + d.CountDoc + '</td>';
                    html += '</tr>';
                }                
                $('#tbDocCount tbody').html(html);
            }
        });
    $.get(path + 'Config/GetLoginSummary')
        .done((r) => {
            if (r.length > 0) {
                let html = '';
                for (let d of r) {
                    if (d.LastLogin.indexOf('ALL')>0) {
                        html += '<tr style="background-color:lightgreen;font-weight:bold">';
                    } else {
                        html += '<tr>';
                    }
                    html += '<td>' + d.Period + '</td>';
                    html += '<td>' + d.UserID + '</td>';
                    html += '<td>' + d.LastLogin + '</td>';
                    html += '</tr>';
                }                
                $('#tbUser tbody').html(html);
            }
        });
</script>