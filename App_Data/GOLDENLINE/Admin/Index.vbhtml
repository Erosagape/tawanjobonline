@Code
    ViewBag.Title = "Index"
End Code
Period : <input type="text" id="txtPeriod" value="@DateTime.Now.ToString("yyyy/MM")" />
<input type="checkbox" id="chkCancel" /> Show Cancel
<input type="button" id="btnShow" class="btn btn-success" value="Show Summary" onclick="ShowData(true)" />
<input type="button" id="btnShow" class="btn btn-warning" value="Show Detail" onclick="ShowData(false)" />
<h3>User Login</h3>
<div id="dvLoginCount">
    <table id="tbUser" class="table table-responsive" style="border:thin;width:100%">
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
<h3>Job Usages</h3>
<div id="dvJobCount">
    <table id="tbJobCount" class="table table-responsive" style="border:thin;width:100%">
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
<h3>Document Created</h3>
<div id="dvDocCount">
    <table id="tbDocCount" class="table table-responsive" style="border:thin;width:100%">
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
    var isSummary = true;
    ShowData(true);
    function ShowData(summary) {
        IsSummary = summary;
        let period = '?summary=' + (IsSummary == true ? 'Y' : 'N');
        if($('#txtPeriod').val() !== '') {
            period += '&period=' + $('#txtPeriod').val();
        }       
        if ($('#chkCancel').prop('checked') == true) {
            period += '&cancel=Y';
        }
        $('#tbJobCount tbody').html('');
        $.get(path + 'JobOrder/GetJobSummary' + period)
        .done((r) => {
            if (r.length > 0) {
                let html = '';
                if (r[0].JobMonth !== null) {
                    let countJob = 0;
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
                        if (IsSummary == true) {
                            html += '<td>' + d.TotalJob + '</td>';
                        } else {
                            html += '<td>' + d.JobNo + '</td>';
                            countJob += 1;
                        }
                        html += '</tr>';
                    }                
                    if (IsSummary == false) {
                        html += '<tr style="background-color:lightgreen;font-weight:bold">';
                        html += '<td>Total</td>';
                        html += '<td>JOB</td>';
                        html += '<td></td>';
                        html += '<td>' + countJob + '</td>';
                        html += '</tr>';
                    }
                }
                $('#tbJobCount tbody').html(html);
            }
        });
        $('#tbDocCount tbody').html('');
        $.get(path + 'JobOrder/GetDocSummary' + period)
        .done((r) => {
            if (r.length > 0) {
                let html = '';
                if (r[0].DocType !== null) {
                    let lastType = '';
                    let docCount = 0;
                    for (let d of r) {
                        if (lastType == '') lastType = d.DocType;
                        if (IsSummary) {
                            if (d.Period.indexOf('ALL') > 0) {
                                html += '<tr style="background-color:lightgreen;font-weight:bold">';
                            } else {
                                html += '<tr>';
                            }
                        } else {
                            if (lastType !== d.DocType) {
                                html += '<tr style="background-color:lightgreen;font-weight:bold">';
                                html += '<td>Total</td>';
                                html += '<td>' + lastType + '</td>';
                                html += '<td>' + docCount + '</td>';
                                html += '</tr>';
                                lastType = d.DocType;
                                docCount = 0;
                            }
                            html += '<tr>';
                        }
                        
                        if (IsSummary == true) {
                            html += '<td>' + d.Period + '</td>';                        
                            html += '<td>' + d.DocType + '</td>';
                            html += '<td>' + d.CountDoc + '</td>';
                        } else {
                            html += '<td>' + ShowDate(d.DocDate) + '</td>';                        
                            html += '<td>' + d.DocType + '</td>';
                            html += '<td>' + d.DocNo + '</td>';
                        }
                        html += '</tr>';
                        docCount += 1;
                    }        
                    if (IsSummary == false) {
                        html += '<tr style="background-color:lightgreen;font-weight:bold">';
                        html += '<td>Total</td>';
                        html += '<td>' + lastType + '</td>';
                        html += '<td>' + docCount + '</td>';
                        html += '</tr>';                
                    }                            
                }
                $('#tbDocCount tbody').html(html);
            }
        });
        $('#tbUser tbody').html('');
        $.get(path + 'Config/GetLoginSummary' + period)
        .done((r) => {
            if (r.length > 0) {
                let html = '';
                for (let d of r) {
                    if (d.LastLogin.indexOf('ALL')>=0) {
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
    }

</script>