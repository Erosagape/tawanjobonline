@Code
    ViewData("Title") = "Login"
End Code
<style>
    .card-img-top {
        width: 100%;
        height: 15vw;
        object-fit: contain;
    }
</style>
<div class="row">
    <div class="col-sm-2">
        <span>User ID :</span>
    </div>
    <div class="col-sm-4">
        <input type="text" id="txtUserID" class="form-control" />
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <span>Password :</span>
    </div>
    <div class="col-sm-4">
        <input type="password" id="txtPassword" class="form-control" />
    </div>
</div>
<button id="btnLogin" class="btn btn-primary" onclick="CheckLogin()">Log in</button>
<div class="row" style="background-color:white;text-align:center;">
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a class="card-text" href="http://103.225.168.137/damon"><img src="~/Resources/logo-damon.jpg" class="card-img-top" />Damon Goods Services</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a class="card-text" href="http://103.225.168.137/kwan"><img src="~/Resources/kwanchai.png" class="card-img-top" />Kwanchai Technology</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a class="card-text" href="http://103.225.168.137/southeast"><img src="~/Resources/logo-south.png" class="card-img-top" />Southeast Logistics</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">

                <a href="http://203.151.56.105/ACE/" class="card-text">
                    <img src="~/Resources/logo-ace.png" class="card-img-top" />
                    ACE Shipping
                </a>
                <br />
                <a href="http://203.151.56.105/ACET/" class="card-text">ACE Transport</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.68/apll-bkk/" class="card-text"><img src="~/Resources/apl-logo.jpg" class="card-img-top" />APL Logistics</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.154.39.165/theso/" class="card-text"><img src="~/Resources/logo-theso.jpg" class="card-img-top" />The Solution Logistics</a>
            </div>
        </div>
    </div>
</div>
<div class="row" style="background-color:white;text-align:center;">
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://103.225.168.137/smart/" class="card-text"><img src="~/Resources/sss-logo.jpg" class="card-img-top" />Smart Shipping Solution</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://103.225.168.137/dpk/" class="card-text"><img src="~/Resources/logo-dpk.png" class="card-img-top" />Dan Pak Kad LTD.Part</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://103.225.168.137/ctt/" class="card-text"><img src="~/Resources/ctt-logo.jpg" class="card-img-top" />CTT Trans</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://103.225.168.137/bft/" class="card-text"><img src="~/Resources/logo_bft.png" class="card-img-top" />BETTER FREIGHT</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://103.225.168.137/uglobe/" class="card-text"><img src="~/Resources/logo_uglobe.jpg" class="card-img-top" />United Global Logistics</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.150.199.181/STM/" class="card-text"><img src="~/Resources/logo-stm.jpg" class="card-img-top" />SINOTHAI Logistics</a>
            </div>
        </div>
    </div>
</div>
<div class="row" style="background-color:white;text-align:center;">
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://103.225.168.137/ant/" class="card-text"><img src="~/Resources/ant-logo.png" class="card-img-top" />ANT GLOBAL</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.161/tgs/" class="card-text"><img src="~/Resources/logo_tgs.png" class="card-img-top" />TRIPLE GROWTH SUPPLY</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.161/teg/" class="card-text"><img src="~/Resources/logo_teg.jpg" class="card-img-top" />TEG Logistics</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.161/star/" class="card-text"><img src="~/Resources/logo-star.png" class="card-img-top" />Star Shipping Cargo Likes</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.161/sincere/" class="card-text"><img src="~/Resources/logo_sincere.png" class="card-img-top" />Sincerely Services</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.161/sil/" class="card-text"><img src="~/Resources/logo-sil.png" class="card-img-top" />Stallion International Logistics</a>
            </div>
        </div>
    </div>
</div>
<div class="row" style="background-color:white;text-align:center;">
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.161/mnl/" class="card-text"><img src="~/Resources/mnl-logo.png" class="card-img-top" />Mahanakorn Logistics</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.161/pcg/" class="card-text"><img src="~/Resources/logo_dyy_t.jpeg" class="card-img-top" />DYY Logistics</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.161/convey/" class="card-text"><img src="~/Resources/logo_convey.png" class="card-img-top" />Convey Logistics</a>
            </div>
        </div>
    </div>
    <div class="col-sm-2">
        <div class="card">            
            <div class="card-body">
                <a href="http://203.151.56.161/bkk/" class="card-text"><img src="~/Resources/logo_bangkok.jpeg" class="card-img-top" />BANGKOK TRANS AND TRADE</a>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    function CheckLogin() {
        getData(path+'home/checklogin?uid=' + $('#txtUserID').val() + '&upwd=' + $('#txtPassword').val(),function (res) {
            if (res == 'OK') {
                window.open(path + 'home/index');
            } else {
                alert(res);
            }
        });
    }
</script>

