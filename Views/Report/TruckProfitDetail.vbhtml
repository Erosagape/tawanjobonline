@Code
    Layout = "~/Views/Shared/_ReportNoHeadLandscape.vbhtml"
    ViewBag.FileName = "export" & DateTime.Now.ToString("yyyyMMddHHMMss") & ".csv"
    ViewData("Title") = "Profit & Costing By Truck"
End Code
<label id="lblTitle" ondblclick="ExportData()">@ViewBag.Title</label>
<div id="dvTable">
    <table id="tbResult" border="1" style="border-collapse:collapse;border-width:thin;white-space:nowrap;">
        <tr>
            <td>Customer</td>
            <td>Shipper</td>
            <td>Load Date</td>
            <td>Job No</td>
            <td>HAWB/BL</td>
            <td>Driver</td>
            <td>Truck</td>
            <td>Pickup</td>
            <td>Packing</td>
            <td>Return</td>
            <td>Container</td>
            <td>Booking</td>
            <td>Comm.Inv</td>
            <td>Fuel</td>
            <td>Costs</td>
            <td>Charges</td>
            <td>Advance</td>
            <td>Profit</td>
            <td>Trip</td>
            <td>Total Fuel</td>
            <td>Total Cost</td>
            <td>Total Charge</td>
        </tr>
        @For Each dr As System.Data.DataRow In ViewBag.DataTable.Rows
            @<tr>
                <td>@dr("CustomerName").ToString()</td>
                <td>@dr("ShipperName").ToString()</td>
                @If IsDate(dr("LoadDate")) Then
                    @<td>@String.Format(dr("LoadDate"), "dd/MM/yyyy")</td>
                Else
                    @<td></td>
                End If
                <td>@dr("JNo").ToString()</td>
                <td>@dr("HAWB").ToString()</td>
                <td>@dr("Driver").ToString()</td>
                <td>@dr("TruckNo").ToString()</td>
                <td> @dr("PickupPlace").ToString()</td>
                <td> @dr("PackingPlace").ToString()</td>
                <td> @dr("ReturnPlace").ToString()</td>
                <td> @dr("CTN_SIZE").ToString(), @dr("CTN_NO").ToString()</td>
                <td> @dr("BookingNo").ToString()</td>
                <td> @dr("InvNo").ToString()</td>
                <td> @dr("TotalFuelUsed").ToString()</td>
                <td> @dr("DetailCost").ToString()</td>
                <td> @dr("DetailCharge").ToString()</td>
                <td> @dr("DetailAdv").ToString()</td>
                <td Class="right">@Format(dr("Profit").ToString(), "Fixed")</td>
                <td Class="right">@Format(dr("SumTrip").ToString(), "Fixed")</td>
                <td Class="right">@Format(dr("TotalFuelAmount").ToString(), "Fixed")</td>
                <td Class="right">@Format(dr("SumCost").ToString(), "Fixed")</td>
                <td Class="right">@Format(dr("SumCharge").ToString(), "Fixed")</td>
            </tr>
        Next
    </table>
</div>
<script type="text/javascript">
    function ExportData() {
        var ans = confirm("Download This Data?");
        if (ans == true) {
            ExportTableToCSV('@ViewBag.FileName');
        }
    }
    function DownloadCSV(csv, filename) {
        var csvFile;
        var downloadLink;

        // CSV file
        csvFile = new Blob(["\ufeff" + csv], { type: "text/csv;charset=utf-8" });

        // Download link
        downloadLink = document.createElement("a");

        // File name
        downloadLink.download = filename;

        // Create a link to the file
        downloadLink.href =window.URL.createObjectURL(csvFile);

        // Hide download link
        downloadLink.style.display = "none";

        // Add the link to DOM
        document.body.appendChild(downloadLink);

        // Click download link
        downloadLink.click();
    }
    function ExportTableToCSV(filename) {
        var csv = [];
        var rows = document.querySelectorAll("#tbResult tr");
        csv.push($('#lblTitle').text());
        for (var i = 0; i < rows.length; i++) {
            var row = [], cols = rows[i].querySelectorAll("td, th");

            for (var j = 0; j < cols.length; j++)
                row.push(cols[j].innerText);

            csv.push(row.join("\t"));
        }
        // Download CSV file
        DownloadCSV(csv.join("\n"), filename);
    }
</script>