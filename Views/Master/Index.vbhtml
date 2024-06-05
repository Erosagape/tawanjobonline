@Code
    ViewBag.Title = "Home"
End Code
<div class="row">
    <div class="col-md-12 text-center">
        <img src="~/Resource/jobtawan_bg.jpg" style="width:100%" />
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
    let userGroup = '@ViewBag.UserGroup';
    let userPosition ='@ViewBag.UserPosition';
    if (user !== '') {
        switch (userGroup) {
            case 'S':
                let csCheck = '3,4,5';
                switch (userPosition) {
                    case '3':
                    case '4':
                        window.location.href = path + 'Tracking/Timeline';
                        break;
                    case '5':
                        window.location.href = path + 'Tracking/Index';
                        break;
                    default:
                        window.location.href = path + 'Menu/Index';
                        break;
                }
                break;
            case 'V':
                window.location.href = path + 'Tracking/Index';
                break;
            case 'C':
                //window.location.href = path + 'Tracking/Timeline';
		window.location.href = path + 'Tracking/Dashboard?Type=v2';
                break;
        }
    }
</script>