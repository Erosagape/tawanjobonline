@Code
    ViewData("Title") = "TransferData"
End Code
<h2>Transfer Data</h2>
<div class="container">
    <div class="row">
        <div class="col-sm-6">
            Date From:
            <br />
        </div>
        <div class="col-sm-6">
            Date To:
            <br />

        </div>
    </div>
</div>
<form action="" method="post">
    <input type="hidden" name="database" value="job_evb" />
    <input type="hidden" name="jsondata1" value="" />
    <input type="hidden" name="jsondata2" value="" />
    <input type="hidden" name="jsondata3" value="" />
    <input type="hidden" name="tabledata1" value="Mas_Branch" />
    <input type="hidden" name="tabledata2" value="Job_WHTax" />
    <input type="hidden" name="tabledata3" value="Job_WHTaxDetail" />
    <input type="submit" value="Submit" class="btn btn-success" />
</form>
