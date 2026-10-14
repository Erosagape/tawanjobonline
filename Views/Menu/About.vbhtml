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
    <div class="row">
        <b>Contact Us</b>
        <br/>
        <a href="http://www.anydesk.com">1. AnyDesk</a>
        <br/>
        <a href="http://www.teamviewer.com">2. TeamViewer</a>
        <br/>
        <a href="https://www.supremocontrol.com">3. Supremo</a>
        <br/>
        <a href="https://www.ultraviewer.net/th/">4. Ultraviewer</a>
    </div>
    <div class="row">
        <b>Manual</b>
	<br/>
	1. All Manual /คู่มือการใช้โปรแกรมบริหารงานชิปปิ้ง / 所有手册-点击下载用户手册。<a href="http://103.225.168.137/Docs">PDF-คลิ๊ก !downloadคู่มือการใช้งาน</a>
        <br/>
        2. Setup First-time using <a href="http://103.225.168.137/docs/MAS2-SetupMaster_设置主数据.pdf">PDF</a>
        <br/>
<<<<<<< HEAD
        2. Full Manual ver 1.0 <a href="http://103.225.168.137/docs/manual.pdf">PDF</a>
	<br/>
	3. Manual Data For B/L,AWB <a href="http://103.225.168.137/docs/manualBLAWB.pdf">PDF</a>
=======
        3. Full Manual ver 1.0 <a href="http://103.225.168.137/docs//FULL-Manual_V0.1手册.pdf">PDF</a>
	<br/>
	4. Manual Data For B/L,AWB <a href="http://103.225.168.137/docs/CS01วิธีจัดทำใบBL%20,AWB,ManualBLAWB_海运空运提单手册.pdf">PDF</a>
        <br/>
	5. Manual VDO Youtube. <a href="http://tawantech.co.th/tawantech/pageHome/Manual.html">PDFคลิ๊ก !downloadคู่มือการใช้งาน</a>
        <br/>
	6.Tawan Job Workflow <a href="http://103.225.168.137/Docs/TawanJobWorkflow/">IMG</a>
        <br/>
	7.คู่มือโปรแกรมช่วยนำส่งข้อมูล SWC User Interface <a href="https://www.rd.go.th/fileadmin/user_upload/WHT/swc1.5.4/swc-ui_manual_1.5.4.pdf">PDF</a>
>>>>>>> 3x
    </div>
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
                               Facebook - Company:
                           </td>
                           <td>
                               <a href="http://facebook.com/tawantechnology">Tawan Technology Co.,Ltd. - ตะวันเทคโนโลยี</a>
                           </td>
                       </tr>
                       <tr>
                           <td>
                               Facebook - Job Online:
                           </td>
                           <td>
                               <a href="https://www.facebook.com/%E0%B9%82%E0%B8%9B%E0%B8%A3%E0%B9%81%E0%B8%81%E0%B8%A3%E0%B8%A1%E0%B8%9A%E0%B8%A3%E0%B8%B4%E0%B8%AB%E0%B8%B2%E0%B8%A3%E0%B8%87%E0%B8%B2%E0%B8%99%E0%B8%A3%E0%B8%B0%E0%B8%9A%E0%B8%9A%E0%B8%9A%E0%B8%B1%E0%B8%8D%E0%B8%8A%E0%B8%B5%E0%B8%8A%E0%B8%B4%E0%B8%9B%E0%B8%9B%E0%B8%B4%E0%B9%89%E0%B8%87-%E0%B9%82%E0%B8%9B%E0%B8%A3%E0%B9%81%E0%B8%81%E0%B8%A3%E0%B8%A1%E0%B9%83%E0%B8%9A%E0%B8%82%E0%B8%99%E0%B8%AA%E0%B8%B4%E0%B9%89%E0%B8%99%E0%B8%84%E0%B9%89%E0%B8%B2paperless-import-Export-115454756498290">Go To Page</a>
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
        if (r.length > 0) {
            let html = '';
            for (let o of r) {
                html += '<tr>';
                html += '<td>' + o.UserID + '</td>';
                html += '<td>' + ShowDate(o.LastLogin) +'</td>';
                html += '</tr>';
            }
            $('#tbUser').html(html);
        }
    });
</script>