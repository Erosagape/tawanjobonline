@Code
    ViewData("Title") = "Billing"
End Code
<style>
    ul, #myUL {
        list-style-type: none;
    }

    #myUL {
        margin: 0;
        padding: 0;
    }

    .box {
        cursor: pointer;
        -webkit-user-select: none; /* Safari 3.1+ */
        -moz-user-select: none; /* Firefox 2+ */
        -ms-user-select: none; /* IE 10+ */
        user-select: none;
    }

        .box::before {
            content: "+";
            color: black;
            display: inline-block;
            margin-right: 6px;
        }

    .check-box::before {
        content: "-";
    }

    .nested {
        display: none;
    }

    .active {
        display: block;
    }
</style>
<h2>Billing</h2>
<div class="container">
    @Html.Raw(ViewBag.TableHTML)
</div>


<script type="text/javascript">
    var toggler = document.getElementsByClassName("box");
    for (var i = 0; i < toggler.length; i++) {
        toggler[i].addEventListener("click", function () {
            if (this.parentElement.querySelector(".nested") != null) {
                this.parentElement.querySelector(".nested").classList.toggle("active");
                this.classList.toggle("check-box");
            }
        });
    }
</script>