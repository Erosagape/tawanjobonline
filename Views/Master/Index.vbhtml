@Code
    ViewBag.Title = "Home"
End Code
<div class="row">
    <div class="col-md-12 text-center" >
        <img src="~/Resource/jobtawan_bg.jpg" style="width:100%"/>
    </div>
</div>
<div id="dvSyncing" class="modal" role="dialog">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-body">
                Syncing Data...
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    let user = '@ViewBag.User';
    if (user !== '') {
        window.location.href = path+ 'Menu/Index';
    }    
</script>