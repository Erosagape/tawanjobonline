@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.ReportName = "BILL OF LADING"
    ViewBag.Title = "BILL OF LADING"
End Code
<style>
    body {
        font-size: 8px;
    }

    table {
        border-collapse: collapse;
    }

    td {
        vertical-align: top;
    }

    .left {
        border-collapse: collapse;
        border-left: solid;
        border-width: thin;
    }

    .right {
        border-collapse: collapse;
        border-right: solid;
        border-width: thin;
    }

    .top-right {
        border-collapse: collapse;
        border-top: solid;
        border-right: solid;
        border-width: thin;
    }

    .top-left {
        border-collapse: collapse;
        border-top: solid;
        border-left: solid;
        border-width: thin;
    }

    .bottom-right {
        border-collapse: collapse;
        border-bottom: solid;
        border-right: solid;
        border-width: thin;
    }

    .bottom-left {
        border-collapse: collapse;
        border-bottom: solid;
        border-left: solid;
        border-width: thin;
    }

    .bottom {
        border-collapse: collapse;
        border-bottom: solid;
        border-width: thin;
    }

    #dvFooter, #pFooter {
        display: none;
    }
</style>
<table style="width:100%">
    <tr>
        <td style="display:flex">
            <img src="~/Resource/logo-east.jpg" style="width:150px;">
            <div>
                <b style="font-size:18px">EASTRONG INTERNATIONAL LOGISTICS CO.,LTD</b>
            </div>

        </td>
        <td>
            <br />
            <span style="float:right;font-size:20px;font-weight:bold;">BILL OF LADING</span>
        </td>
    </tr>
</table>
<p>
    <table style="width:100%">
        <tr>
            <td class="top-right" style="height:100px;width:50%;" rowspan="2" colspan="2">
                <b>SHIPPER/EXPORTER</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblShipperName"></label>
                    <br />
                    <label id="lblShipperAddress1"></label>
                    <br />
                    <div id="lblShipperAddress2"></div>
                </div>
            </td>
            <td class="top-left" style="width:50%;" colspan="2">
                <b>BILL OF LADING NO.</b>
                <br />
                <label id="lblHAWB" style="color:red;"></label>
            </td>
        </tr>
        <tr>
            <td class="top-left" style="width:50%;" colspan="2">
                <b>EXPORT REFERENCES</b>
                <div>
                    <label id="lblPaymentCondition"></label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="top-right" style="width:50%;height:100px;" rowspan="2" colspan="2">
                <b>CONSIGNEE</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblConsigneeName"></label>
                    <br />
                    <label id="lblConsignAddress1"></label>
                    <br />
                    <div id="lblConsignAddress2"></div>
                </div>
            </td>
            <td class="top-left" style="width:50%;" colspan="2">
                <b>FORWARDING AGENT</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblDeliveryTo"></label><br />
                    <div id="lblDeliveryAddr"></div>
                </div>
            </td>
        </tr>
        <tr>
            <td class="top-left" style="width:50%;" colspan="2">
                <b>POINT AND COUNTRY OF ORIGIN</b>
                <div>
                    <label id="lblPickupPlace"></label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="top-right" style="width:50%;height:100px;" colspan="2">
                <b>NOTIFY PARTY</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblNotifyName"></label>
                    <br />
                    <label id="lblNotifyAddress1"></label>
                    <br />
                    <label id="lblNotifyAddress2"></label>
                </div>
            </td>
            <td class="top-left" style="width:50%;" colspan="2" rowspan="2">
                <b>TO OBTAIN DELIVERY CONTACT:</b>
                <div>
                    <label id="lblReturnAddress"></label>
                </div>
            </td>
        </tr>
        <tr style="height:30px;">
            <td class="top-right" style="width:25%;">
                <b>PRE CARRIAGE BY</b>
                <div>
                    <label id="lblMVesselName"></label>
                </div>
            </td>
            <td class="top-right" style="width:25%;">
                <b>PLACE OF RECEIPT</b>
                <div>
                    <label id="lblPackingPlace"></label>
                </div>
            </td>
        </tr>
        <tr style="height:30px;">
            <td class="top-right" style="width:25%;">
                <b>EXPORTING CARRIER</b>
                <div>
                    <label id="lblVesselName"></label>
                </div>
            </td>
            <td class="top-left" style="width:25%;">
                <b>PORT OF LOADING</b>
                <div>
                    <label id="lblFactoryPlace"></label>
                </div>
            </td>
            <td class="top-left" style="width:50%;" colspan="2">
                <b>ONWARD INLAND ROUTING</b>
                <div>
                    <label id="lblRouting"></label>
                </div>
            </td>
        </tr>
        <tr style="height:30px;">
            <td class="top-right bottom-right" style="width:25%;">
                <b>PORT OF DISCHARGE</b>
                <div>
                    <label id="lblDischargePlace"></label>
                </div>
            </td>
            <td class="top-right bottom-right" style="width:25%;">
                <b>PLACE OF DELIVERY</b>
                <div>
                    <label id="lblInterPortName"></label>,<label id="lblCountryName"></label>
                </div>
            </td>
            <td class="top-left bottom-left" style="width:20%;">
                <b>FOR TRANSHIPMENT TO</b>
                <div>
                    <label id="lblPaymentBy"></label>
                </div>

            </td>
            <td class="top-left bottom-left" style="width:30%;">
                <b>FINAL DESTINATION (FOR THE MERCHANT'S REF)</b>
                <div>
                    <label id="lblReturnPlace"></label>
                </div>

            </td>
        </tr>
    </table>
    <table style="width:100%">
        <tr>
            <td class="bottom" colspan="5" style="width:100%;text-align: center;">
                <b>PARTICULARS FURNISHED BY SHIPPER</b>
            </td>
        </tr>
        <tr>
            <td class="bottom-right" style="width:20%;text-align:center;">
                <b>MARKS AND NUMBERS</b>
            </td>
            <td class="bottom-right" style="width:15%;text-align:center;">
                <b>NO.OF CONT<br />OR OTHERS PKGS</b>
            </td>
            <td class="bottom-right" style="width:35%;text-align:center;">
                <b>DESCRIPTION OF PACKAGES AND GOODS</b>
            </td>
            <td class="bottom-right" style="width:15%;text-align:center;">
                <b>GROSS WEIGHT</b>
            </td>
            <td class="bottom-left" style="width:15%;text-align:center;">
                <b>MEASUREMENT</b>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <div id="dvDetail" style="position:absolute;width:740px;"></div>
            </td>
        </tr>
        <tr style="height:360px;">
            <td class="bottom-right"></td>
            <td class="bottom-right"></td>
            <td class="bottom-right"></td>
            <td class="bottom-right"></td>
            <td class="bottom-left"></td>
        </tr>
    </table>
    <table style="width:100%">
        <tr>
            <td class="bottom-right" style="width:20%;text-align:center;">
                <b>FREIGHT AND CHARGES<br />REVENUE TONS RATE PER</b>
            </td>
            <td class="bottom-right" style="width:13%;text-align:center;">
                <b>PREPAID</b>
            </td>
            <td class="bottom-right" style="width:12%;text-align:center;">
                <b>COLLECT</b>
            </td>
            <td class="bottom-left" colspan="2" rowspan="2" style="width:55%">
                The surrender of the original order bill of lading properly endorsed shall be required before the delivery of the property,Inspection of property covered by this bill of lading will not be permitted unless provided by law or unless permission is endorsed
                on this bill of lading or given in writing by the shipper.
            </td>
        </tr>
        <tr>
            <td class="bottom-right" rowspan="4">
            </td>
            <td class="bottom-right" rowspan="4">
            </td>
            <td class="bottom-right" rowspan="4">
            </td>
        </tr>
        <tr>
            <td class="bottom-left" colspan="2">
                IN WITNESS WHEREOF THE UNDERSIGNED,SIGNING ON BEHALF OF THIS CARRIER OR AGENT,HAS SIGNED THREE(3) BILLS OF LADING,ALL OF THE SAME TENOR AND DATE, ONE OF WHICH BEING ACCOMPLISHED THE OTHERS TO STAND VOID.
                <br />
                <br />
                <br />
                <br />
                <div style="display:flex;">
                    <div style="flex:1">
                        BY
                    </div>
                    <div style="flex:1;text-align:center">
                        DATE
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td class="bottom-left" style="text-align:center;">
                <span style="font-size: 11px; font-weight: bold;">
                    AS AGENT FOR THE CARRIER,
                </span>
                <br />
                <label id="lblForwarderName"></label>
                <label id="lblProductUnit" style="display:none;"></label>
            </td>
            <td class="bottom" style="text-align:right;">
                For The Company
            </td>
        </tr>
        <tr>
            <td class="bottom-right" rowspan="2">
                <b>ATTENTION OF SHIPPER</b> : The term and conditions of the order bill of lading under which this shipment is accepted are printed on the back hereof. Note unless otherwise specified the charges listed above do not include customs duties,taxes customs clearance
                charges and similar non transportation charges which are for the account of the cargo.
            </td>
            <td class="bottom-left" rowspan="2" style="width:15%">
                B/L NO.
                <br />
                <span style="text-align:center">
                    <label id="lblMAWB"></label>
                </span>
            </td>
        </tr>
        <tr style="height:30px;">
            <td class="bottom-right" style="font-size:12px;text-align:center;">
                <b>TOTAL</b>
            </td>
            <td class="bottom-right">
            </td>
            <td class="bottom-left">
            </td>
        </tr>
    </table>
</p>
<p>
    <div style="width:100%;font-size:14px;">
        <b>APISASI HOLDING CO.,LTD</b>
        <br />
        Definitions 'Merchant' means and includes the Shipper, the Consignor, the Consignee the Holder of tis Bill of Lading, the Receiver and the Owner of the Goods "The Freight forwarder" means the issuer of this bill of Lading as named on the face of it.
        The headings set forth below are for easy reference only
    </div>
    <div style="display:flex;font-size:5px;flex-direction:row;">
        <div class="right" style="flex:1;padding:5px 5px 5px 5px;">
            <div style="width:100%;text-align:center">
                <b>CONDITIONS</b>
                <br />
                <br/>1.  Applicability
                Not withstanding the heading "Combined Transport Bill of Lading" the Provisions set out and refereed to in this document shall also apply if the transport as described on the face of the bill of Lading is performed by one mode of transport only.
                <br />2.	Issuance of the "Combined Transport Bill of Lading"
                <br />2.1	By the issuance of this "Combined Transport Bill of Lading", the Freight Forwarder:
                <br />a)	undertakes to perform and/of in his own name to procure the performance of the entire transport, from the place at which the goods are taken in charge to the place designated for delivery in this Bill of Lading
                <br />b)	assumes liability as set out in these Conditions.
                <br />2.2	For the purposes and subject to the provisions of this Bill of Lading, the Freight Forwarder shall be responsible for the acts and omissions of any person of whose service he makes use for the performance of the contract evidenced by this Bill of Lading.
                <br />3.	Negotiability and title to the goods
                <br />3.1	By accepting this bill of Lading the Merchant and his transferees agree with the Freight Forwarder that. unless It is marked, "non negotiable" it shall constitute to the goods and the holder by endorsement of
                this Bill of Lading shall be entitled to receive or to transfer the Goods herein mentioned.
                <br />3.2	This Bill of Lading shall be prima fact evidence of the taking charge by the Freight Forwarder of the goods as herein described.  However, proof to the contrary shall not be admissible when this Bill of Lading has been negotiated or transferred for valuable consideration to a third party acting in good faith.
                <br />4.	Dangerous Goods and Indemnity
                <br />4.1	The Merchant shall comply with release which are mandatory according to the national law or by reason of international Convention, relating to the carriage of goods of a dangerous nature, and shall in any case inform the Freight Forwarder in writing of the exact nature of the danger before goods of a dangerous nature are taken in charge by the Freight Forwarder and indicate to him, if need be, the precautions to be taken.
                <br />4.2	lf the Merchant fails to provide such information and the Freight Forwarder is unaware of the dangerous
                nature of the goods and the necessary precautions to be taken and if, at any time they are deemed go be hazard to life or property, they may at any place be unloaded, destroyed rendered harmless, as circumstances may require, without compensation, and the Merchant shall be liable for all loss. damage, delay or expenses arising out of their being taken in charge, or their carriage, or of any service incidental thereto. The burden of proving the Freight Forwarder knew the exact nature of the danger constituted by the carriage of the said goods shall rest upon the parson entitles to the goods
                <br />4.3	If any goods shipped with knowledge of the Freight Forwarder as their dangerous nature shall become a danger to the vehicle or cargo, they may in like manner be unloaded or landed at any place or destroyed or rendered innocuous by the Freight Forwarder without liability on the part of the Freight Forwarder, except to General Average, if any
                <br />5.	Description of goods and Merchant's Packing
                <br />5.1	The Consignor shall be deemed to have guaranteed to the Freight Forwarded the accuracy at the time that goods were in charge by the Freight Forwarded of the description of the goods, marks, number. quantity, weight and/of volume as furnished by him, and the Consignor shall indemnity the Freight
                Forwarder against all loss, damage and expenses arising or resulting from inaccuracies in or in adequacy of such particulars, The right of the Freight Forwarder to such indemnity shall in no way
                Limit this responsibility and liability  under  this  Bill  of  Lading  to  any  person  other  than  the  Consignor.
                <br />5.2	Without prejudice to clause 6 (A) (2) (c), the Merchant shall be liable for any loss, damage or injury caused by faulty or insufficient packing of goods or by faulty loading or packing within containers and trailers and on flats when such loading or packing has been performed by the Merchant or on behalf of the Merchant by a person other than the Freight Forwarder or by the defect or unsuitability of the containers, trailers of flats. When supplied by the Merchant, and shall indemnify the Freight Forwarder against any additional expenses so caused.
                <br />6.	Extend of Liability
                <br />A.	1 ) The Freight Forwarder shall be liable for loss of or damage to the goods occurring between the time when he takes the goods into his charge and the time of delivery
                <br />2)	The Freight Forwarder shall, however, be relieved of liability for any loss or damage if such loss or damage was caused by
                <br />a)	an act or omission of the Merchant or from whom the Freight Forwarder took the goods in
                charge.
                <br />b)	insufficiency or defective condition of the packaging or marks and/or numbers.
                <br />c)	handling, loading, stowage or unloading of the goods by the Merchant or any person acting on behalf of the Merchant
                <br />d)	inherent vice of the goods.
                <br />e)	strike, lockout, stoppage or restraint of labour, the consequences of which the Freight Forwarder could not avoid by the exercise of reasonable diligence.
                <br />f)	any cause or event which the Freight Forwarder could not avoid and the consequences
                whereof he could not prevent by the exercise of reasonable diligence.
                <br />g)	a nuclar incident lf the operator of a nuclear installation or a person acting for him or liable for this damage under an applicable international Convention of national law governing liability in respect of nuclear energy.
                <br />3)	The burden of proving that loss or damage was due to one or more of the about causes or events shall rest upon the Freight Forwarder.
                When the Freight Forwarder, establishes that, in the circumstances of the case, the loss or
                damage could be attributed to one or more of the causes or events specified In b) to d) about, it shall be presumed that iit was so caused. The claimant shall, however be entitled to prove that the loss or damage was not, on fact, caused wholly or partly by one or more of these causes or events.
                <br />B.	When in accordance with clause 6, A  1 the Freight Forwarder is liable to pay compensation in
                respect of loss or damage to the goods and the stage of transport where the loss or damage occurred is known, the liability of the Freight Forwarder in respect of such loss or damage shall be determined by the provisions contained in any international Convention or national law, which provisions,
                <br />(i)	cannot be departed from by private contract to the detract, of the claimant, and
                <br />(ii) would have applied of the Claimant had made a separate and direct contract with the Freight Forwarder in respect of the particulate stage of transport where the loss or damage occurred and received as evidence thereof any particulate document which must be issued in order to make such international convention or national law applicable.
                <br />7.	Paramount Clause
                The Hague Rules contained in the International Convention for the unification of certain rules relate to Bill of Lading, dated Brussels 25th August 1924, or I those countries where they are already in force Hague Visby Rule contained in the Protocol of Brussels, dated February 23rd 1968, as enacted in the Country of Shipment, shalt apply to all carriage of goods by sea and, where no mandatory international or national law applies to the carriage of foods by inland waterways also, and such provisions shall apply to all goods whether carried on deck or under deck
            </div>
        </div>
        <div class="right" style="flex:1;padding:5px 5px 5px 5px;">
            <br/>8. Limitation Amount
            <br />8.1 When the Freight forwarder is liable for compensation in respect of loss or damage to the goods, such compensation shall be calculated by reference to the values of such goods at the place time they are delivered to the consignee in accordance with the contract or should have been so delivered.
            <br />8.2	The value of the goods shall be fixed according to the current commodity exchange price or there be no such price, according to the current market price, or, if there be no commodity, exchange price or current market price, by reference to the normal value of goods of the same kind and quality
            <br />8.3	Compensation shall not, however, exceed 500 SDR (Special Drawing Rights) per package of the goods lost or damage, unless, with the consent of the Freight Forwarder, the Merchant has declared a higher value for the goods and such higher value has been stated in the CT Bill of Lading. in which case such higher value shall be the limit. However, the Freight Forwarder shall not, in any case, be liable for an amount greater than the actual loss    to the person entitled to make claim.
            <br />9.	Delay Consequential Loss, atc
            <br />Arrival times are not guaranteed by the Freight Forwarder, if the Freight Forwarder is held liable in respect of delay, consequential loss or damage other than limited to double the. freight for the goods, the liability of the Freight Forwarder shall be limited to double the freight for the transport covered by this Bill of   Lading, or the value of the goods as determined in Clause 8, whichever is the less.
            <br />10.	Defenses
            <br />10.1	The defences and limited of liability provided for in these Conditions shall apply in any action against the Freight Forwarder for loss or damage to the goods whether the action be founded in contract or in tort.
            <br />10.2	The Freight Forwarder shall not be entitled to the benefit of the limitation of liabilIy provided for in paragraph 3 of Clause 8 of it is proved that the loss or damage resulted from an act or omission of the Freight Forwarder done with intent to cause damage or recklessly and with knowledge and Sub contractors
            <br />11.	Liability of Servants and Sub-contractors
            <br />11.1	if an action for loss of or damage to the _goods is brought against a person referred to in paragraph 2 of Clause 2, such person shall be entitled to avail himself of the defences and limits of liability which the Freight Forwarder is entitled to invoke under these Conditions
            <br />11.2	However if it is proved that the loss or damage resulted from an cat or omission of this person, done
            with intent cause damage or recklessly and with knowledge that damage or recklessly and with knowledge that damage would probably result, such person shall not be entitled to benefit of limitation or liability provided for in paragraph 3 of Clause 8.
            <br />11.3	Subject to the provisions of paragraph of Clause 10 and paragraph 2 of this Clause, the aggregate of the amount recoverable from the Freight Forwarder and the persons referred to in paragraph 2 of Clause 2 shall in no case exceed the limited provided for in these Conditions.
            <br />12.	Method and Route of Transportation
            The Freight Forwarder reserves to himself a reasonable liberty as to the means route and procedure to be followed in the handling, storage and transportation of goods.
            <br />13.  Delivery
            <br />If delivery of the goods or any part there of is not taken by the Merchant at the time and place when and where the Freight Forwarder is entitled to call upon the Merchant to the delivery thereof the Freight Forwarder shall be entitled to store the goods or the part thereof al the sole risk of the Merchant, where upon the liability of the Freight Forwarder in respect of the goods or that thereof stored as aforesaid (as the case may be) shall wholly cease and the cost of such storage (if paid by or payable by the Freight Forwarder or any agent or subcontractor  of the Freight Forwarder) shall forthwith upon demand be paid by the Merchant to the Freight Forwarder.
            <br />14.	Freight and Charges
            <br />14.1	Freight shall be paid in cash without discount and whether prepayable or payable at destination, shall be considered as earned on receipt of the goods and not to be returned of relinquished in any event
            <br />14.2	Freight and all other amounts mentioned in this Bill of Lading are to be paid in the currency named in the Bill of lading or at the Freight Forwarder's option in the currency of the county of dispatch or destination at the highest rate of exchange for bankers sight bills county for prepayable freight on the day of dispatch and for freight payable at destination on the day when the Merchant is notified of arrival of the goods there or on the Freight Forwarder on ;the date of the Bill of Lading.
            <br />14.3	paid dues, taxes and charges or other expenses in connection with the goods shall be paid by the Merchant.
            <br />14.4	The Merchant shall reimburse the Freight Forwarder in proportion to the amount of freight for any costs for deviation or delay or any other increase of costs of whatever nature caused by war warlike operations, epidemics, strikes, government directions or force majeure.
            <br />14.5	The Merchant warrants the correctness of the declaration of contents, Insurance, weight, measurements or value of the goods but the Freight Forwarder receives the right to have the contents inspected and the weight, measurements or value verified. If on such inspection it is found the declaration is not correct   it is agreed that a sum equal either live times the difference between the correct figure and the freight charged, or to double the correct freight less the freight charged, whichever sum is the smaller. shall be payable as liquidated damage to the Freight Forwarder for his inspection costs and losses of freight on other goods notwithstanding any other sum having been stated on the Bill of Lading as freight payable.
            <br />15.	Lien
            <br />The Freight Forwarder shall have a lien on the goods for any amount due under this Bill of Lading including storage fees and for the cost of recovering same, and may enforce such lien in any reasonable manner which he may think fit.
            <br />16.	General Average
            <br />The merchant shall indemnify Freight Forwarder in respect of any claims of a General Average nature which may be made on him and shall provide such security as may be req required by the Freight Forwarder in this connection.
            <br />17.	Notice
            <br />Unless notice of loss of or damage to the goods and the general nature of it be given in writing to the Freight Forwarder or the persons referred to in paragraph 2 of Clause 2, at the place of delivery before or at the time or the removal of the goods into the custody of the person entitled to delivery hereof under this Bill of Lading, or if the loss or damage be no apparent, within seven consecutive days thereafter, such removal shall be prima fact evidence of the delivery by the Freight Forwarder of the goods as described in this Bill oi Lading.
            <br />18.	Non delivery
            <br />Failure to effect delivery 90 days after the expiry of time a limit agreed and expressed in a CT Bill Lading
            or, where no time limites is agreed and so expressed, failure to effect delivery within 90 days after the time it
            would be reasonable to allow for diligent compensation of the combined transport operation shall, in the absence of evidence to the contra')', give to the party entitled to delivery, the right to treat the goods as lost
            <br />19.	Time Bar
            <br />The Freight Forwarder shall be discharged of all liability under the rules of these Conditions, unless suit is
            Brought within nine months after
            <br />(i)  the delivery of  the goods. or
            <br />(ii)	 the date when the goods should have been delivered, or
            <br />(iii) the date when in accordance with Clause 18. failure to deliver the goods would, in the absence of evidence to the contrary, give to the party entitled to receive delivery, the right to treat the goods as lost
            <br />20. Jurisdiction
            <br />Actions against the Freight Forwarder may only be instituted in the country where the Freight Forwarder has principal place of business
        </div>
    </div>
</p>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    var units=[];
    $.get(path + 'Master/GetCustomsUnit').done(function(m) {
	units=m.customsunit.data;
	LoadData();
    });
    function LoadData() {
$.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $('#lblMAWB').text(h.MAWB);
            $('#lblHAWB').text(h.HAWB);
            $('#lblBLNo').text(h.BLNo);
            $('#lblDeliveryTo').text(h.DeliveryTo);
            $('#lblDeliveryAddr').html(CStr(h.DeliveryAddr));
            $('#lblTransMode').text(h.TransMode);
            $('#lblPaymentBy').text(h.PaymentBy);
            $('#lblPaymentCondition').text(h.PaymentCondition);
            $('#lblBookingDate').text('BANGKOK ' + ShowDate(h.BookingDate));
            $('#lblForwarderName').text(h.ForwarderName);
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperAddress1').text(CStr(h.ShipperAddress1));
            $('#lblShipperAddress2').html(CStr(h.ShipperAddress2));
            $('#lblConsigneeName').text(h.ConsigneeName);
            $('#lblConsignAddress1').text(CStr(h.ConsignAddress1));
            $('#lblConsignAddress2').html(CStr(h.ConsignAddress2));
            $('#lblNotifyName').text(h.NotifyName);
            $('#lblNotifyAddress1').text(h.NotifyAddress1);
            $('#lblNotifyAddress2').text(h.NotifyAddress2);
            $('#lblVesselName').text(h.VesselName);
            $('#lblMVesselName').text(h.MVesselName);
            $('#lblPackingPlace').text(h.CYPlace);

            let unit=units.filter(function(data){
               return data.Code==h.InvProductUnit;
             });
            if(unit.length>0) {
               $('#lblProductUnit').text(unit[0].TName);
            } else {
               $('#lblProductUnit').text(h.InvProductUnit);
            }
            $('#lblInterPortName').text(h.PackingPlace)
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblRouting').text(h.FactoryAddress);
            $('#lblReturnPlace').text(h.ReturnPlace);
            $('#lblReturnAddress').text(h.ReturnAddress);
            $('#lblPickupPlace').text(h.CYAddress);
            $('#lblDischargePlace').text(h.ClearPortNo);
            $('#lblTotalPackage').text(CNumEng(h.InvProductQty).replace('ONLY', ''));
            $('#lblServiceMode').text(h.TRemark);
            $('#lblInvCurRate').text(h.InvCurRate);

            let html = '';
            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
            html += '<div style="width:20%;padding:5px 5px 5px 5px;">'+ CStr(h.Remark) +'</div>';
            html += '<div style="width:15%;padding:5px 5px 5px 5px;">' + h.InvProductQty + '<br/>' + $('#lblProductUnit').text() + '</div>';
            html += '<div style="width:35%;padding:5px 5px 5px 5px;">' + h.InvProduct + '<br/>' + CStr(h.ProjectName);
            html += '</div>';
            html += '<div style="width:15%;padding:5px 5px 5px 5px;">' + ShowNumber(h.TotalGW,3) + ' ' + h.GWUnit + '';
            html +='</div>';
            html += '<div style="width:15%;text-align:center;padding:5px 5px 5px 5px;">'+ h.TotalM3 +' M3</div>';
            html += '</div>';

            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px;padding:5px 5px 5px 5px;">';
            html += '<div style="width:45%;"><u>CONTAINER & SEAL</u></div>';
            html += '</div>';
            let i = 0;
            for (i = 0; i < r.booking.data.length; i++){
                let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:10px">';
                htmlTemplate += r.booking.data[i].CTN_NO + ' / ' + r.booking.data[i].SealNumber + ' / ' + r.booking.data[i].ProductQty + ' ' + $('#lblProductUnit').text() + ' / ' + r.booking.data[i].GrossWeight + ' '+ h.GWUnit + ' / ' + r.booking.data[i].Measurement + ' CBM / ' +h.TransMode;
                htmlTemplate += '</div>';

                html += htmlTemplate;
            }
            html += '</div>';
            $('#dvDetail').html(html);

        }
    });
    }
</script>