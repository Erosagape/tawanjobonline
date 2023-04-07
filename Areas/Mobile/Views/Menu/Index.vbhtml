@Code
    ViewData("Title") = "Menu"
    Dim role = ViewBag.UserRole
End Code

<h2>Welcome @ViewBag.UserID</h2>
<a href="@Url.Action("Index", "Chart")">Status Chart</a>
@If role = "S" Then
    @<br>@<a href="">List Booking</a>
    @<br>@<a href="">Create Booking</a>
End If
@If role = "C" Then
    @<br>@<a href="">List Order</a>
    @<br>@<a href="">Create Order</a>
End If
@If role = "V" Then
    @<br>@<a href="">List Truck Order</a>
    @<br>@<a href="">Create Truck Order</a>
End If