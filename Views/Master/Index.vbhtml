@Code
    ViewBag.Title = "Home"
End Code
<div class="row">
    <div class="col-md-12 text-center" >
        <img src="~/Resource/jobtawan_bg.jpg" style="width:100%"/>
    </div>
</div>
<script type="text/javascript">
    let user='@ViewBag.User';
    if(user!==''){
        window.location.href = 'Menu/Index';
    }
</script>