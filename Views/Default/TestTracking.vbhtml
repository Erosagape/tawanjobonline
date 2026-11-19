@Code
    ViewData("Title") = "Test"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Test</h2>
BEFORE:
<br />
<table id="tbBefore" class="table">
    <thead>
        <tr>
            <th>CurrencyCode</th>
            <th>AmtCharge</th>
            <th>AmtAdvance</th>
            <th>AmtVat</th>
            <th>AmtWht</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
AFTER:
<br />
<table id="tbAfter" class="table">
    <thead>
        <tr>
            <th>CurrencyCode</th>
            <th>AmtCharge</th>
            <th>AmtAdvance</th>
            <th>AmtVat</th>
            <th>AmtWht</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<script type="text/javascript">
    var cols = [];
    var arr = [
        { CurrencyCode: "USD", AmtCharge: 100, AmtAdvance: 0, AmtVat: 0, AmtWht: 0 },
        { CurrencyCode: "THB", AmtCharge: 1000, AmtAdvance: 0, AmtVat: 0, AmtWht: 10 },
        { CurrencyCode: "THB", AmtCharge: 4000, AmtAdvance: 0, AmtVat: 28, AmtWht: 12 },
        { CurrencyCode: "THB", AmtCharge: 0, AmtAdvance: 300, AmtVat: 21, AmtWht: 9 },
        { CurrencyCode: "THB", AmtCharge: 0, AmtAdvance: 2000, AmtVat: 0, AmtWht: 20 },
        { CurrencyCode: "USD", AmtCharge: 50, AmtAdvance: 0, AmtVat: 0, AmtWht: 0 },
        { CurrencyCode: "THB", AmtCharge: 10000, AmtAdvance: 0, AmtVat: 100, AmtWht: 0 }
    ];
    for (let o of arr) {
        let html = '<tr>';
        html += '<td>' + o.CurrencyCode + '</td>';
        html += '<td>' + o.AmtCharge + '</td>';
        html += '<td>' + o.AmtAdvance + '</td>';
        html += '<td>' + o.AmtVat + '</td>';
        html += '<td>' + o.AmtWht + '</td>';
        html += '</tr>';
        $('#tbBefore tbody').append(html);
    }

    arr.sort((a, b) => (
        a.CurrencyCode.localeCompare(b.CurrencyCode) ||
        (b.AmtCharge - a.AmtCharge && b.AmtVat - a.AmtVat) ||
        b.AmtAdvance - a.AmtAdvance
    ));

    for (let o of arr) {
        let html = '<tr>';
        html += '<td>' + o.CurrencyCode + '</td>';
        html += '<td>' + o.AmtCharge + '</td>';
        html += '<td>' + o.AmtAdvance + '</td>';
        html += '<td>' + o.AmtVat + '</td>';
        html += '<td>' + o.AmtWht + '</td>';
        html += '</tr>';
        $('#tbAfter tbody').append(html);
    }
</script>
