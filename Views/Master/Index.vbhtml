@Code
    ViewBag.Title = "Home"
End Code
<div class="row">
    <div class="col-md-12 text-center" >
        @ViewBag.Result
        <br/>
        <img src="~/Resource/jobtawan_bg.jpg" style="width:100%"/>
    </div>
</div>
<div id="dvSyncing" class="modal" role="dialog">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-body">
                Please wait...
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    let user = '@ViewBag.User';
    let userGroup = '@ViewBag.UserGroup';
    let userPosition = '@ViewBag.UserPosition';
    let menuStart = '@ViewBag.PROFILE_MENU_TYPE';
    if (user !== '') {
        switch (userGroup) {
            case 'S':
                let csCheck = '3,4,5';
                switch (userPosition) {
                    case '1': //MD
                    case '2': //Manager
                        window.location.href = path + 'JobOrder/Summary';
                        break;
                    case '3': //cs
                    case '4': //sales
                        window.location.href = path + 'Tracking/Timeline';
                        break;
                    case '5': //Shipping
                        window.location.href = path + 'Tracking/Index';
                        break;
                    case '6': //accounts
                        window.location.href = path + 'JobOrder/Summary';
                        break;
                    default:
                        if (IsMobile()||menuStart=='W') {
                            window.location.href = path + 'Menu/Index';
                        } else {
                            window.location.href = path + 'Tracking/Dashboard';
                        }
                        break;
                }
                break;
            case 'V':
                window.location.href = path + 'Tracking/Index';
                break;
            case 'C':
                window.location.href = path + 'Tracking/Timeline';
                break;
        }
    }    
    function IsMobile() {
        return ((window.innerWidth <= 800) && (window.innerHeight <= 600));
    }
</script>