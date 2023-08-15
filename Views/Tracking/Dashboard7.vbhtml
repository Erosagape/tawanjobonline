@Code
    Dim bLogin = False
    If ViewBag.User <> "" Then
        bLogin = True
    End If
End Code
<div class="container">
    @If bLogin Then
        Dim oJobType = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL("SELECT * FROM Mas_Config WHERE ConfigCode='JOB_TYPE'")
        Dim oShipBy = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL("SELECT * FROM Mas_Config WHERE ConfigCode='SHIP_BY'")
        @<b>Job Create Date</b>
    @<div class="panel">
         <div class="row">
             <div class="col-sm-2">
                 From :
             </div>
             <div class="col-sm-4">
                <input type="date" class="form-control" id="txtDateFrom" name="dateFrom" />
             </div>
             <div class="col-sm-2">
                 To :
             </div>
             <div class="col-sm-4">
                 <input type="date" class="form-control" id="txtDateTo" name="dateTo" />
             </div>
         </div>
         <div class="row">
             <div class="col-sm-2">
                 Job Type :
             </div>
             <div class="col-sm-4">
                 <select class="form-control dropdown" id="cboJobType" name="jobtype">

                 </select>
             </div>
             <div class="col-sm-2">
                 Ship By :
             </div>
             <div class="col-sm-4">
                 <select class="form-control dropdown" id="cboShipBy" name="shipby">

                 </select>
             </div>
         </div>
    </div>
    Else
        @Html.Label("Please Login First")
    End If
</div>
<script type = "text/javascript" >
    var path = '@Url.Content("~")';
</script>
