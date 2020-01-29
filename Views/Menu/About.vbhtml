@Code
    ViewBag.Title = "About Us"
End Code
<style>
    body, html {
  height: 100%;
  margin: 0;
  font-family: Arial;
}

/* Style tab links */
.tablink {
  background-color: #c1b0b0;
  color: black;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  padding: 14px 16px;
  font-size: 17px;
  width: 25%;
}

.tablink:hover {
  background-color: white;
}

/* Style the tab content (and add height:100% for full page content) */
.tabcontent {
  color: black;
  display: none;
  padding: 100px 20px;
  height: 100%;
}

#Home {background-color: wheat;}
#News {background-color: wheat;}
#Contact {background-color: wheat;}
#About {background-color: wheat;}
</style>
<button class="tablink" onclick="openPage('Home', this, 'wheat')" id="defaultOpen">Login</button>
<button class="tablink" onclick="openPage('News', this, 'wheat')">Variables</button>
<button class="tablink" onclick="openPage('Contact', this, 'wheat')">Contact</button>
<button class="tablink" onclick="openPage('About', this, 'wheat')">About</button>

<div id="Home" class="tabcontent">
    <h3>User Login</h3>
    <table class="table table-responsive">
        <thead>
            <tr>
                <th>User ID</th>
                <th>Log in Date</th>
            </tr>
        </thead>
        <tbody id="tbUser">
        </tbody>
    </table>
</div>

<div id="News" class="tabcontent">
    <h3>System Variables</h3>
    <table class="table table-responsive">
        <thead>
            <tr>
                <th>Variable Name</th>
                <th>Variable Values</th>
            </tr>
        </thead>
        <tbody>
            @Code
                For Each vwData In ViewData
                    @<tr>
                        <td>@vwData.Key</td>
                        <td>@vwData.Value</td>
                    </tr>
                Next
            End Code
        </tbody>
    </table>
</div>

<div id="Contact" class="tabcontent">
    <b>Contact Us</b>
    <a href="http://www.anydesk.com">1. AnyDesk</a>
    <a href="http://www.teamviewer.com">2. TeamViewer</a>
</div>

<div id="About" class="tabcontent">
    <b>About Us</b><br />
    <table class="table table-bordered">
        <tr>
            <td width="20%">
                Web site :
            </td>
            <td width="80%">
                <a href="http://www.tawantech.co.th">www.tawantech.co.th</a>
            </td>
        </tr>
        <tr>
            <td>
                Address :
            </td>
            <td>
                89 ซอยศรีประเวศ (ลาดกระบัง 1ก/3) ถนน ลาดกระบัง แขวง ลาดกระบัง เขต ลาดกระบัง กรุงเทพฯ 10520
                Tel :02-0586209, 02-0583509
            </td>
        </tr>
        <tr>
            <td>
                Facebook :
            </td>
            <td>
                <a href="http://facebook.com/tawantechnology">Tawan Technology Co.,Ltd. - ตะวันเทคโนโลยี</a>
            </td>
        </tr>
        <tr>
            <td>
                Line :
            </td>
            <td>
                @@tawantech
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    function openPage(pageName, elmnt, color) {
        // Hide all elements with class="tabcontent" by default */
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
        }

        // Remove the background color of all tablinks/buttons
        tablinks = document.getElementsByClassName("tablink");
        for (i = 0; i < tablinks.length; i++) {
        tablinks[i].style.backgroundColor = "";
        }

        // Show the specific tab content
        document.getElementById(pageName).style.display = "block";

        // Add the specific color to the button used to open the tab content
        elmnt.style.backgroundColor = color;
    }

// Get the element with id="defaultOpen" and click on it
    document.getElementById("defaultOpen").click();

    $.get(path + 'Config/GetLoginHistory').done(function(r) {
        if(r.data !== null){
            let html = '';
            for (let o of r.data) {
                html += '<tr>';
                html += '<td>' + o.UserID + '</td>';
                html += '<td>' + ShowDate(o.LastLogin) +'</td>';
                html += '</tr>';
            }
            $('#tbUser').html(html);
        }
    });
</script>