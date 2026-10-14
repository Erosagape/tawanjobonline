<<<<<<< HEAD
﻿
@Code
    ViewBag.Title = "Search Container"
End Code
<style>

</style>

<div class="row">
             <div class="col-sm-6" style="display:flex">
            	<div style="width:30%">
               		<label style="display:block;width:100%;">From Date</label>
            	</div>
            	<div style="width:70%">
                	<input type="date" id="txtDateFrom" class="form-control" value="@(New Date(Today.Year, Today.Month, 1).ToString("yyyy-MM-dd"))" >
                </div>
 	     </div>
             <div class="col-sm-6" style="display:flex">
            	<div style="width:30%">
                    <label style="display:block;width:100%;">To Date</label>
                </div>
                <div style="width:70%">
                    <input type="date" id="txtDateTo" class="form-control" value="@(New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"))" >
                </div>
	   </div>
</div>
<div class="row">
	<div class="col-sm-6" style="display:flex">
            <div style="width:30%">
                <label  style="display:block;width:100%;">Job Type</label>
            </div>
            <div style="width:70%">
                <select id="cboJobType" class="form-control dropdown" onchange="CheckJobType()" style="width:100%" tabindex="0">
		</select>
            </div>
	 </div>
	<div class="col-sm-6" style="display:flex">
            <div style="width:30%">
                <label  style="display:block;width:100%;">Ship By</label>
            </div>
            <div style="width:70%">
                <select id="cboShipBy" class="form-control dropdown"  style="width:100%" tabindex="1">
		</select>
	    </div>

	</div>

 </div>
<div class="row">
<div class="col-sm-6" style="display:flex">
            <div style="width:30%">
                <a href="../Master/Customers"><label  style="display:block;width:100%;">IM_EX PORTER</label></a>
            </div>
            <div style="display:flex;width:70%">
                <input type="text" class="form-control" style="width:80px" id="txtCustCode" tabindex="4" readonly>
                <input type="text" class="form-control" style="width:40px;display:none" id="txtCustBranch" tabindex="5" >
                <input type="button" class="btn btn-default" id="btnBrowseCust" value="..." onclick="SearchData('customer')">
                <input type="text" class="form-control" style="width:100%" id="txtCustName" disabled="">
            </div>

</div>
 </div>

<br><button type="button" class="btn btn-warning" onclick="handleClick();">Search</button>
<div id="dvLOVs"></div>

<script type="text/javascript">
    var path = '@Url.Content("~")';
    let userGroup = '@ViewBag.UserGroup';
    let user = '@ViewBag.User';

    let jt = getQueryString('JType');
    let sb = getQueryString('SBy');

    SetLOVs();
    CheckParam();

function handleClick() {
            let queryParam = `&BeginDate=${document.getElementById("txtDateFrom").value}`;
            let queryParam1 = `&EndDate=${document.getElementById("txtDateTo").value}`;
            let queryParam2 = `&CustCode=${document.getElementById("txtCustCode").value}`;
            let queryParam3 = `&JobType=${document.getElementById("cboJobType").value}`;
            let queryParam4 = `&ShipBy=${document.getElementById("cboShipBy").value}`;
            let params = queryParam + queryParam1 + queryParam2 + queryParam3 + queryParam4
	   

	     if (!($("#txtDateFrom").val() && $("#txtDateTo").val())) {
                alert("Please input both date")
                name.focus();
                return false;
            }

		
            window.open(path +"Tracking/Dashboard?form=5_report" + params);
            
        }
  
    function SetLOVs() {
        let lists = 'JOB_STATUS=#cboStatus';
        loadCombos(path, lists);
        //$('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        //$('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
           
        });
    }
    function SearchData(type) {
        switch (type) {
           case 'customer':
                SetGridCompanyByGroup(path, '#tbCust','CUSTOMERS,INTERNAL,PERSON', '#frmSearchCust', ReadCustomer);
                break;

        }
    }
   
     function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
       
    }

     function CheckJobType() {
        if (jt !== $('#cboJobType').val()) {
            jt = $('#cboJobType').val();
            loadShipByByType(path, jt, '#cboShipBy');
            return;
        }
    }

    function CheckParam() {
        let lists = 'JOB_TYPE=#cboJobType|'+jt+',SHIP_BY=#cboShipBy|'+ sb;
        loadCombos(path, lists);

        $('#cboJobType').val(jt);
        $('#cboShipBy').val(sb);

    }

    
</script>
=======
﻿@Code
    ViewData("Title") = "Total Containers"
    Dim beginDate = New Date(Today.Year, Today.Month, 1).ToString("yyyy-MM-dd")
    If Request.QueryString("BeginDate") IsNot Nothing Then
        beginDate = Request.QueryString("BeginDate")
    End If
    Dim endDate = New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
    If Request.QueryString("EndDate") IsNot Nothing Then
        endDate = Request.QueryString("EndDate")
    End If

    Dim oSummary = New Dictionary(Of String, Int32)
    If ViewBag.User <> "" Then
        Dim conn = ViewBag.CONNECTION_JOB
        Dim sqlConMultiple = "
select replace(TotalContainer,' ','') as TotalContainer,count(*) as c From job_order
where CHARINDEX(',',TotalContainer,0)>0 
and DocDate>='{0}' and DocDate<='{1}'
group by replace(TotalContainer,' ','')
"
        Dim sqlConSingle = "
select replace(TotalContainer,' ','') as TotalContainer,count(*) as c From job_order
where CHARINDEX(',',TotalContainer,0)=0
and DocDate>='{0}' and DocDate<='{1}'
group by replace(TotalContainer,' ','')
"
        Using rs = New CUtil(conn).GetTableFromSQL(String.Format(sqlConSingle, beginDate, endDate))
            If rs.Rows.Count > 0 Then
                For Each row In rs.Rows
                    Dim strCon = row("TotalContainer").ToString().ToUpper()
                    Dim xPos = strCon.IndexOf("X")
                    Dim jobQty = Convert.ToInt32(row("c"))
                    If xPos > 0 Then
                        Dim arrCon = strCon.Split("X")
                        Try
                            Dim conQty = Convert.ToInt32(arrCon(0)) * jobQty
                            Dim conUnit = arrCon(1)
                            If oSummary.ContainsKey(conUnit) Then
                                Dim oOldVal = oSummary(conUnit)
                                conQty = conQty + oOldVal
                                oSummary.Remove(conUnit)
                            End If
                            oSummary.Add(conUnit, conQty)
                        Catch ex As Exception
                            oSummary.Add(strCon, jobQty)
                        End Try
                    Else
                        Dim strUnit = ""
                        Dim qtyIndex = 0
                        For i As Integer = 0 To strCon.Length - 1
                            If "0123456789".IndexOf(strCon.Substring(i, 1)) < 0 Then
                                strUnit &= strCon.Substring(i, 1)
                                If qtyIndex > 0 Then
                                    Exit For
                                End If
                            Else
                                qtyIndex += 1
                            End If
                        Next
                        If qtyIndex > 0 Then
                            Try
                                jobQty = jobQty * Convert.ToInt32(strCon.Substring(0, qtyIndex))
                            Catch ex As Exception
                                jobQty = 1
                            End Try

                        End If
                        If oSummary.ContainsKey(strUnit) Then
                            Dim oOldVal = oSummary(strUnit)
                            jobQty = jobQty + oOldVal
                            oSummary.Remove(strUnit)
                        End If
                        oSummary.Add(strUnit, jobQty)
                    End If
                Next
            End If
        End Using
        Using rs = New CUtil(conn).GetTableFromSQL(String.Format(sqlConMultiple, beginDate, endDate))
            If rs.Rows.Count > 0 Then
                For Each row In rs.Rows
                    Dim strVal = row("TotalContainer").ToString().ToUpper()
                    For Each strCon In strVal.Split(",")
                        Dim xPos = strCon.IndexOf("X")
                        Dim jobQty As Int32 = 0
                        If Int32.TryParse(row("c").ToString(), jobQty) = False Then
                            Continue For
                        Else
                            jobQty = Convert.ToInt32(row("c"))
                        End If
                        If xPos > 0 Then
                            Dim arrCon = strCon.Split("X")
                            Try
                                Dim conQty = Convert.ToInt32(arrCon(0)) * jobQty
                                Dim conUnit = arrCon(1)
                                If oSummary.ContainsKey(conUnit) Then
                                    Dim oOldVal = oSummary(conUnit)
                                    conQty = conQty + oOldVal
                                    oSummary.Remove(conUnit)
                                End If
                                oSummary.Add(conUnit, conQty)
                            Catch ex As Exception
                                oSummary.Add(strCon, jobQty)
                            End Try
                        Else
                            Dim strUnit = ""
                            Dim qtyIndex = 0
                            For i As Integer = 0 To strCon.Length - 1
                                If "0123456789".IndexOf(strCon.Substring(i, 1)) < 0 Then
                                    strUnit &= strCon.Substring(i, 1)
                                    If qtyIndex > 0 Then
                                        Exit For
                                    End If
                                Else
                                    qtyIndex += 1
                                End If
                            Next
                            If qtyIndex > 0 Then
                                Try
                                    jobQty = jobQty * Convert.ToInt32(strCon.Substring(0, qtyIndex))
                                Catch ex As Exception
                                    jobQty = 1
                                End Try

                            End If
                            If oSummary.ContainsKey(strUnit) Then
                                Dim oOldVal = oSummary(strUnit)
                                jobQty = jobQty + oOldVal
                                oSummary.Remove(strUnit)
                            End If
                            oSummary.Add(strUnit, jobQty)
                        End If
                    Next
                Next
            End If
        End Using
    End If
    Dim arrSummary = ""
End Code
<div class="row">
    <div class="col-sm-3">
        From Date <br />
        <input type="date" id="txtDateFrom" class="form-control" value="@beginDate" />
    </div>
    <div class="col-sm-3">
        To Date <br />
        <input type="date" id="txtDateTo" class="form-control" value="@endDate" />
    </div>
    <div class="col-sm-3">
        <br />
        <input type="button" class="btn btn-primary" value="Search" onclick="RefreshData()" />
        <input type="button" class="btn btn-warning" value="Container Detail" onclick="SearchContainer()" />
    </div>
</div>
<div id="dvChart"></div>
<div class="table-responsive">
    <table class="table table-bordered">
        <thead>
            <tr>
                <th>Size</th>
                <th>Qty</th>
            </tr>
        </thead>
        <tbody>
            @If oSummary.Count > 0 Then
                Dim oSorted = From item In oSummary
                              Order By item.Key Ascending
                              Select item

                arrSummary = "[""Unit"",""Qty""]"
                For Each con In oSorted
                    arrSummary &= ",[""" & con.Key & """," & con.Value & "]"
                    @<tr>
                        <td>@con.Key</td>
                        <td>@con.Value</td>
                    </tr>
                Next
            Else
                arrSummary = "[""Unit"",""Qty""],[""N/A"",0]"
            End If
        </tbody>
    </table>
</div>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var arrSummary = [@Html.Raw(arrSummary)];
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);
    function drawChart() {
        var data1 = google.visualization.arrayToDataTable(arrSummary);

        var options1 = {
            width: 600,
            height: 400,
            legend: { position: 'top', maxLines: 3 },
            bar: { groupWidth: '75%' },
            isStacked: true
        };

        var chart1 = new google.visualization.BarChart(document.getElementById('dvChart'));
        chart1.draw(data1, options1);
    }

    function RefreshData() {
        window.location.href = path + 'Tracking/Dashboard?Form=5&BeginDate=' + $('#txtDateFrom').val() + '&EndDate=' + $('#txtDateTo').val();
    }
    function SearchContainer() {
        window.location.href = path + 'Tracking/Dashboard?Form=8';
    }
</script>
>>>>>>> 3x
