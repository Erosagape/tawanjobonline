@Code
    ViewData("Title") = "FormSalesContract"
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
End Code
<style>
    #dvFooter, #pFooter {
        display: none;
    }
    #tbHeader {                
        border-collapse: collapse;
    }
    #tbDetail td,#tbHeader th {
        border-style:solid;
        border-width: thin;
    }
</style>
<div style="width:100%;text-align:center">
    <h2 id="lblCustName"></h2>
    <label id="lblEAddress1"></label>
    <br /><label id="lblEAddress2"></label>
    <h3>SALES CONTRACT</h3>
</div>
<table style="width:100%;">
    <tr>
        <td><b>CONTRACT NO:</b></td>
        <td><label id="lblQNo"></label></td>
        <td><b>DATE:</b></td>
        <td><label id="lblConfirmDate"></label></td>
    </tr>
    <tr>
        <td valign="top"><b>THE SELLER</b></td>
        <td colspan="3">
            <label id="lblSellerName"></label><br />
            <label id="lblSellerAddr1"></label><br />
            <label id="lblSellerAddr2"></label>
        </td>
    </tr>
    <tr>
        <td valign="top"><b>THE BUYER</b></td>
        <td colspan="3">
            <label id="lblBuyerName"></label><br />
            <label id="lblBuyerAddr1"></label><br />
            <label id="lblBuyerAddr2"></label>
        </td>
    </tr>
</table>
<p>
    The Seller agree to sell and The Buyer agree to buy the under mentioned goods with the Terms and Conditions state below:
</p>
<table id="tbHeader" border="1" style="width:100%">
    <thead>
        <tr>
            <th>DESCRIPTION</th>
            <th>
                QUANTITY<br />
                <label id="lblInvProductUnit"></label>
            </th>
            <th>
                QUANTITY<br />
                N.W (<label id="lblWeightUnit"></label>)
            </th>
            <th>
                UNIT PRICE<br />
                (<label id="lblCurrencyCode"></label>)
            </th>
            <th>
                AMOUNT<br />
                (<label id="lblCurrencyCode2"></label>)
            </th>
        </tr>
    </thead>
    <tbody id="tbDetail" style="text-align:center"></tbody>
    <tfoot>
        <tr>
            <td colspan="5">
                REMARKS:<br/>
                <div id="dvRemark">
                </div>
            </td>
        </tr>
    </tfoot>
</table>
<br/>
<table>
    <tr>
        <td valign="top">COMMODITY:</td>
        <td>
            <div id="dvDesc">
            </div>
        </td>
    </tr>
</table>
<br />
<table>
    <tr>
        <td>PACKING:</td>
        <td>
            <label id="lblTotalQty"></label>
        </td>
        <td>
            <div id="dvProd"></div>
        </td>
    </tr>
    <tr>
        <td>DELIVERY:</td>
        <td colspan="2">
            <label id="lblTransMode"></label>
        </td>
    </tr>
    <tr>
        <td>PAYMENT TERMS:</td>
        <td colspan="2">
            <label id="lblPaymentCondition"></label>
        </td>
    </tr>
</table>
<br/>
<p>
    TERMS &Aacute; CONDITIONS :
    <span>
The buyer agrees to accept the goods if the decayed/rotten rate in 5% of the goods total value,shall not claim from the seller.
    </span>
</p>
<br/>
<div style="display:flex;width:100%">
    <div style="flex:1;text-align:center;">
        ACCEPTED BY THE BUYER:
        <br />
        <br />
        <br />
        <br />
        <label id="lblBuyer"></label>
    </div>
    <div style="flex:1;text-align:center;">
        CONFIRMED BY THE SUPPLIER:
        <br />
        <br />
        <br />
        <br />
        <label id="lblSeller"></label>
    </div>
</div>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';

    $.get(path + 'JobOrder/GetTransportReport?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.transport.data !== null) {
            //alert(r.transport.data.length);
            let h = r.transport.data[0];
            $('#lblCustName').html(h.NameEng);
            $('#lblEAddress1').text(h.EAddress1);
            $('#lblEAddress2').text(h.EAddress2);
            $('#lblQNo').text(h.QNo);
            $('#lblConfirmDate').text(ShowDate(CDateEN(h.ConfirmDate)));
            $('#lblInvProductUnit').text(h.InvProductUnit);
            $('#lblWeightUnit').text(h.GWUnit);
            $('#lblCurrencyCode').text(h.InvCurUnit + '/' + h.GWUnit);
            $('#lblCurrencyCode2').text(h.InvCurUnit);
            $('#dvRemark').html(CStr(h.Remark));
            $('#dvDesc').html(CStr(h.Description));
            $('#dvProd').html(CStr(h.ProjectName));
            $('#lblTotalQty').text(ShowNumber(h.TotalQty,2));
            $('#lblTransMode').text(h.TransMode);
            $('#lblPaymentCondition').text(h.PaymentCondition);

            if (Number(h.JobType) == 1) {
                $('#lblBuyerName').text(h.NameEng);
                $('#lblBuyer').text(h.NameEng);
                $('#lblBuyerAddr1').text(h.EAddress1);
                $('#lblBuyerAddr2').text(h.EAddress2);
                $.get(path + 'Master/GetCompany?Code=' + h.NotifyCode).done(function (dc) {
                    if (dc.company.data.length > 0) {
                        let c = dc.company.data[0];
                        $('#lblSeller').text(h.NameEng);
                        $('#lblSellerName').text(c.NameEng);
                        $('#lblSellerAddr1').text(c.EAddress1);
                        $('#lblSellerAddr2').text(c.EAddress2);
                    }
                });
            } else {
                $('#lblSellerName').text(h.NameEng);
                $('#lblSeller').text(h.NameEng);
                $('#lblSellerAddr1').text(h.EAddress1);
                $('#lblSellerAddr2').text(h.EAddress2);
                $.get(path + 'Master/GetCompany?Code=' + h.NotifyCode).done(function (dc) {
                    if (dc.company.data.length > 0) {
                        let c = dc.company.data[0];
                        $('#lblBuyer').text(h.NameEng);
                        $('#lblBuyerName').text(c.NameEng);
                        $('#lblBuyerAddr1').text(c.EAddress1);
                        $('#lblBuyerAddr2').text(c.EAddress2);
                    }
                });
            }
            let d = r.transport.data;
            let tot = 0;
            let html = '';
            html += '<tr>';
            html += '<td></td>';
            html += '<td></td>';
            html += '<td></td>';
            html += '<td><u>' + h.TRemark + '</u></td>';
            html += '<td></td>';
            html += '</tr>';
            for (let dr of d) {
                html += '<tr>';
                html += '<td>'+ dr.ProductDesc +'</td>';
                html += '<td>'+ ShowNumber(dr.ProductQty,2) +'</td>';
                html += '<td>'+ ShowNumber(dr.NetWeight,2) +'</td>';
                html += '<td>' + ShowNumber(dr.ProductPrice,2) + '</td>';
                html += '<td>' + ShowNumber(Number(dr.ProductPrice)*Number(dr.ProductQty),2) +'</td>';
                html += '</tr>';
                tot += Number(dr.ProductPrice) * Number(dr.ProductQty);
            }
            html += '<tr>';
            html += '<td colspan="3"></td>'
            html += '<td>TOTAL</td>'
            html += '<td>' + ShowNumber(tot,2) +'</td>';
            html += '</tr>';
            $('#tbDetail').html(html);
        }
    });
</script>
