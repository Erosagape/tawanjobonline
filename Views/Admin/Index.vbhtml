@Code
    ViewBag.Title = "Index"
End Code
<h2>Summary</h2>
<div id="dvJobCount">
    <table id="tbJobCount" style="border:thin;">
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
<script type="text/javascript">
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetJobSummary')
        .done((r) => {
            if (r.length > 0) {
                let html = '';
                for (let d of r) {
                    html += '<tr>';
                    html += '<td>' + d.Period + '</td>';
                    html += '<td>' + d.JobTypeName + '</td>';
                    html += '<td>' + d.ShipByName + '</td>';
                    html += '<td>' + d.TotalJob + '</td>';
                    html += '</tr>';
                }                
                $('#tbJobCount tbody').html(html);
            }
        });
</script>