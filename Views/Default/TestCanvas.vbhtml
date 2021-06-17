@Code
    ViewData("Title") = "TestCanva"
    Layout = Nothing
End Code
@Scripts.Render("~/bundles/jquery")
<h2>Your Signature</h2> ID : <label id="lblSigID"></label>
<div>
    <canvas id="mycanvas" width="640" height="480" style="box-shadow: 0 0 6px 0 #999;"></canvas>
</div>
<div style="display:flex">
    <input id="save" class="btn btn-default" type="submit" value="Save" />
    <input id="download" class="btn btn-default" type="submit" value="Download" />
    <input id="clear" class="btn btn-default" type="button" value="Clear" />
    <img name="myimage" id="hdwrite-image" />
</div>
<a id="link"></a>
<script src="~/Scripts/Func/util.js"></script>
<script type="text/javascript">

    var path = '@Url.Action("PostCanvas", "Default")';
    var id = getQueryString("id");

    $('#lblSigID').text(id);
    // =============
    // == Globals ==
    // =============
    const canvas = document.getElementById('mycanvas');
    const canvasContext = canvas.getContext('2d');
    const saveButton = document.getElementById('save');
    const clearButton = document.getElementById('clear');
    const downloadButton = document.getElementById('download');
    const state = {
        mousedown: false
    };

    // ===================
    // == Configuration ==
    // ===================
    const lineWidth = 3;
    const halfLineWidth = lineWidth / 2;
    const fillStyle = '#333';
    const strokeStyle = '#333';
    const shadowColor = '#333';
    const shadowBlur = lineWidth / 4;

    // =====================
    // == Event Listeners ==
    // =====================
    canvas.addEventListener('mousedown', handleWritingStart);
    canvas.addEventListener('mousemove', handleWritingInProgress);
    canvas.addEventListener('mouseup', handleDrawingEnd);
    canvas.addEventListener('mouseout', handleDrawingEnd);

    canvas.addEventListener('touchstart', handleWritingStart);
    canvas.addEventListener('touchmove', handleWritingInProgress);
    canvas.addEventListener('touchend', handleDrawingEnd);

    clearButton.addEventListener('click', handleClearButtonClick);
    saveButton.addEventListener('click', handleSaveButtonClick);
    downloadButton.addEventListener('click', handleDownloadButtonClick);

    // ====================
    // == Event Handlers ==
    // ====================
    function handleWritingStart(event) {
        event.preventDefault();

        const mousePos = getMosuePositionOnCanvas(event);

        canvasContext.beginPath();

        canvasContext.moveTo(mousePos.x, mousePos.y);

        canvasContext.lineWidth = lineWidth;
        canvasContext.strokeStyle = strokeStyle;
        canvasContext.shadowColor = null;
        canvasContext.shadowBlur = null;

        canvasContext.fill();

        state.mousedown = true;
    }

    function handleWritingInProgress(event) {
        event.preventDefault();

        if (state.mousedown) {
            const mousePos = getMosuePositionOnCanvas(event);

            canvasContext.lineTo(mousePos.x, mousePos.y);
            canvasContext.stroke();
        }
    }

    function handleDrawingEnd(event) {
        event.preventDefault();

        if (state.mousedown) {
            canvasContext.shadowColor = shadowColor;
            canvasContext.shadowBlur = shadowBlur;

            canvasContext.stroke();
        }

        state.mousedown = false;
    }

    function handleClearButtonClick(event) {
        event.preventDefault();

        clearCanvas();
    }
    function handleSaveButtonClick(event) {
        if (id !== '') {
            var myImage = canvas.toDataURL("image/png");
            var result = $.ajax({
                url: path + '?ID=' + id,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({ dataImage: myImage })
            });
            result.done(function (response) {
                alert(response);
            });
            result.fail(function (err) {
                alert(err);
            });
        } else {
            alert('ID must be assigned');
        }
    }
    function handleDownloadButtonClick(event) {
        var myImage = canvas.toDataURL("image/png");
        var img = document.getElementById('hdwrite-image');
        img.src = myImage;
        var link = document.getElementById('link');
        link.setAttribute('download', 'your-signature.png');
        link.setAttribute('href', myImage.replace("image/png", "image/octet-stream"));
        link.click();
    }
    // ======================
    // == Helper Functions ==
    // ======================
    function getMosuePositionOnCanvas(event) {
        const clientX = event.clientX || event.touches[0].clientX;
        const clientY = event.clientY || event.touches[0].clientY;
        const { offsetLeft, offsetTop } = event.target;
        const canvasX = clientX - offsetLeft;
        const canvasY = clientY - offsetTop;

        return { x: canvasX, y: canvasY };
    }

    function clearCanvas() {
        canvasContext.clearRect(0, 0, canvas.width, canvas.height);
    }



</script>