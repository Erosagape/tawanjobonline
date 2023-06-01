@Code
    ViewData("Title") = "Menu"
    Dim role = ViewBag.UserRole
End Code

<h2>Welcome @ViewBag.UserID</h2>
<a href="@Url.Action("Index", "Chart")">Total Job</a>
@If role = "S" Then
    @<br>@<a href="@Url.Action("Yearly", "Chart")">Year Summary</a>
    @<br>@<a href="@Url.Action("Finance", "Chart")">Cash Flow</a>
    @<br>@<a href="@Url.Action("Advance", "Chart")">Re-imbursement Followup</a>
    @<br>@<a href="@Url.Action("Loading", "Chart")">Loading Job</a>
    @<br>@<a href="@Url.Action("Container", "List")">List Transport</a>
    @<br>@<a href="@Url.Action("Container", "Create")">Create Transport</a>
End If
@If role = "C" Then
    @<br>@<a href="@Url.Action("Shipment", "List")">List Order</a>
    @<br>@<a href="@Url.Action("Shipment", "Create")">Create Order</a>
End If
@If role = "V" Then
    @<br>@<a href="@Url.Action("Booking", "List")">List B/L</a>
    @<br>@<a href="@Url.Action("Booking", "Create")">Create B/L</a>
End If
<p>
    Job Connection : @ViewBag.JobConn
    <br />
    Master Connection : @ViewBag.MasConn
</p>