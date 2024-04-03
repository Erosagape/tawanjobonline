@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.ReportName = "BILL OF LADING"
    ViewBag.Title = "BILL OF LADING"
End Code
<style>
    body {
        font-size: 9px;
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

    .top {
        border-collapse: collapse;
        border-top: solid;
        border-width: thin;
    }

    #dvFooter, #pFooter {
        display: none;
    }

    #page2 pre{
        flex: 1;
        white-space: pre-wrap;
        font-stretch: ultra-condensed;
        letter-spacing: 0px;
        font-family: Arial Narrow;
        font-size: 7px;
    }
</style>
<p>
    <table style="width:100%">
        <tr>
            <td class="top" style="height:100px;width:50%;" colspan="2">
                <b>Shipper</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblShipperName"></label>
                    <br />
                    <label id="lblShipperAddress1"></label>
                    <br />
                    <div id="lblShipperAddress2"></div>
                </div>
            </td>
            <td class="top" style="width:50%;" rowspan="3" colspan="2">
                <div style="display:flex">
                    <div style="flex:1;text-align:center;">
                        <h1>BILL OF LADING</h1>
                    </div>
                    <div style="flex:1;text-align:left;" class="top-left bottom-right">
                        B/L No.
                        <br/>
                        <div style="text-align:center;width:100%">
                            <label id="lblHAWB" style="color:red;font-size:14px;"></label>
                        </div>
                    </div>
                </div>
                <div style="display:flex">
                    <div style="flex:1;">
                        <input type="text" style="text-align: center;border-style:none; width: 100%;" value="ORIGINAL" />
                    </div>
                    <div style="flex:1;text-align:center">
                        ORIGINAL BILL REQUIRED AT DESTINATION
                    </div>
                </div>
                <img src="~/Resource/logo_uglobe.jpg" style="width:100%" />
                <div style="text-align:right">  AS THE CARRIER <br /> OCEAN BILL OF LADING</div>
              
                <div>
                    RECEIVED by the Carrier the Goods as specified below in apparent good order and condition unless otherwise stated, to be transported to such place as agreed, authorized or permitted herein and subject to all the terms and conditions appearing on the front and reverse of this Bill of Lading to which the Merchant agrees by accepting this Bill of Lading, any local privileges and customs notwithstanding.
                    The particulars given below as stated by the shipper and the weight, measure, quantity, condition,
                    contents and value of the Goods are unknown to the Carrier. In WTINESS whereof one (1)
                    original Bill of Lading has been signed if not otherwise stated below, the same being accomplished
                    the other(s), if any to be void. If required by the Carrier one (1) original Bill of Lading must be
                    surrendered duly endored in exchange for the Goods or delivery order.
                </div>

            </td>

        </tr>
        <tr>
            <td class="top" style="width:50%;height:100px;" colspan="2">
                <b>Consignee</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblConsigneeName"></label>
                    <br />
                    <label id="lblConsignAddress1"></label>
                    <br />
                    <div id="lblConsignAddress2"></div>
                </div>
            </td>
        </tr>
        <tr>
            <td class="top" style="width:50%;height:100px;" colspan="2">
                <b>Notify Party</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblNotifyName"></label>
                    <br />
                    <label id="lblNotifyAddress1"></label>
                    <br />
                    <label id="lblNotifyAddress2"></label>
                </div>
            </td>
        </tr>
        <tr style="height:30px;">
            <td class="top" style="width:25%;">
                <b>Pre-Carriage By</b>
                <div>
                    <label id="lblMVesselName"></label>
                </div>
            </td>
            <td class="top" style="width:25%;">
                <b>Place of Receipt</b>
                <div>
                    <label id="lblPackingPlace"></label>
                </div>
            </td>
            <td class="top" style="width:50%;" rowspan="2" colspan="2">
                <b>For delivery of Goods please apply to:</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblDeliveryTo"></label><br />
                    <div id="lblDeliveryAddr"></div>
                </div>
            </td>
        </tr>
        <tr style="height:30px;">
            <td class="top" style="width:25%;">
                <b>Vessel / Voy.No.</b>
                <div>
                    <label id="lblVesselName"></label>
                </div>
            </td>
            <td class="top" style="width:25%;">
                <b>Port of Loading</b>
                <div>
                    <label id="lblFactoryPlace"></label>
                </div>
            </td>
        </tr>
        <tr style="height:30px;">
            <td class="top" style="width:25%;">
                <b>Port of Discharge</b>
                <div>
                    <label id="lblDischargePlace"></label>
                </div>
            </td>
            <td class="top" style="width:25%;">
                <b>Place of Delivery</b>
                <div>
                    <label id="lblInterPortName"></label>,<label id="lblCountryName"></label>
                </div>
            </td>
            <td class="top" style="width:50%;">
                <b>Excess Limit Declaration as per Clause 16</b>
            </td>
        </tr>
    </table>
    <table style="width:100%">
        <tr>
            <td class="bottom top" colspan="7" style="width:100%;text-align: center;">
                <b>The below particulars of the goods are according to the declaration of the shipper,and are unknown to the Carrier</b>
            </td>
        </tr>
        <tr>
            <td class="bottom top" style="width:10%;">
                <b>Container No.</b>
            </td>
            <td class="bottom top" style="width:15%;">
                <b>Seal No.<br />Marks and Numbers</b>
            </td>
            <td class="bottom top" style="width:10%;">
                <b>No.Of Containers<br />Of Pkgs</b>
            </td>
          
            <td class="bottom top" colspan="2" style="width:35%;">
                <b>Description Of Goods</b>
            </td>
            <td class="bottom top" style="width:15%;">
                <b>Gross Weight</b>
            </td>
            <td class="bottom top" style="width:15%;">
                <b>Measurement</b>
            </td>
        </tr>
        <tr style="height:330px;">
            <td colspan="7" id="dvDetail" class="bottom">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                TOTAL No.Of Containers or Packages<br/> (In Words)
            </td>
            <td colspan="5">
                <label id="lblSumQty"></label>
                <label id="lblProductUnit" style="display:none;"></label>
            </td>
        </tr>
    </table>
    <table style="width:100%">
        <tr class="top">
            <td colspan="2">
                Freight And Charges
                <div>
                    <label id="lblPaymentCondition"></label>
                </div>
            </td>
            <td>
                Revenue Tons
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td>
                Rate
            </td>
            <td>
                Per
            </td>
            <td style="width:10%">
                Prepaid
            </td>
            <td style="width:10%" class="left">
                Collect
            </td>
        </tr>
        <tr>
            <td class="top-right">
                Ex.Rate
            </td>
            <td colspan="2" class="top-right">
                Prepaid At
            </td>
            <td colspan="2" class="top-right">
                Payable At
                <br />
                <label id="lblPaymentBy"></label>
            </td>
            <td colspan="2" class="top-left">
                Place and Date of issue
                <br/>
                <label id="lblBookingDate"></label>
            </td>
        </tr>
        <tr>
            <td class="top-right">
                <label id="lblExchangeRate"></label>
            </td>
            <td colspan="2" class="top-right">
                Total Prepaid in local Currencys
            </td>
            <td colspan="2" class="top-right">
                No. of Original B/L(s)
                <div>
                    <label id="lblBLNo"></label>
                </div>
            </td>
            <td colspan="2" rowspan="2" class="top-left">
                Stamp / Signature of the Carrier or its agent
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td  class="top-right" style="width:20%">
                <div>Shipped on board </div>
            </td>
            <td colspan="2" class="top-right" style="width:20%">
                <label id="lblLoadDate"></label><br />
                <label id="lblLoadPort2"></label><br />
                <label id="lblPreCarriage"></label>
            </td>
            <td colspan="2" class="top-left" >
                The contract evidenced by this Bill of Lading is governed by the laws of the Hong Kong Special Administrative Region. Any proceedings against the carrier must be brought in the courts of the
                Hong Kong Special Administrative Region and on other court.
                <br />
                <div style="padding-left:50%">Excess Value Declaration Refer to Clause 11.4 on reverse side</div>
            </td>
        </tr>
    </table>
</p>
<div id="page2" style="width:100%;display:flex;flex-direction:row;">
    <pre >
1. DEFINITIONS
        “Carrier” means the Company state on the front of this Bill of Lading as being the Carrier and on whose behalf this Bill of Lading has been signed.
        “Merchant” includes the shipper, the consignee the receiver of the Goods, the holder of this Bill of Lading, any person owning or entitled to the possession of the Goods or this Bill of Lading, any person having a present or future interest in the Goods or any person acting on behalf of any of the above mentioned persons.
        “Goods” includes the cargo supplied by the Merchant and includes any Container not supplied by or on behalf of the Carrier.
        “Container” includes any container, trailer, transportable tank, lift van, flat, pallet or any similar article of transport used to consolidate goods.
        “Carriage” means the whole of the operations and services undertaken or performed by or on behalf of the Carrier in respect of the Goods.
        “Combined Transport” arises where the Carriage called for by the Bill of Lading is not a Port to Port Shipment.
        “Port to Port Shipment” arises where the Place of Receipt and the Place of Delivery are not indicated on the front of this
        Bill of Lading or if both the Place of Receipt and the Place of Delivery indicate are ports and the Bill of Lading does not in the nomination of the Place of Receipt or the Place of Delivery on the front hereof specify any place or spot within the area of the port so nominated.
        “Hague Rules” means the provisions of the International Convention for Unification of certain Rules relating to Bill of Lading signed at Brussels on 25th August 1924.
        “Hague-Visby Rules” means the Hague Rules as amended by the Protocal signed at Brussels on 23rd February 1968.
        “COGSA” means the Carriage of Goods by Sea Act of the United State Of America approved on 16th April 1936.
        “COGWA” means the Carriage of Goods by Water Act 1936 of Canada.
        “Charges” includes freight and all expenses and money obligations incurred and payable by the Merchant.
        “Shipping unit” includes freight unit and the term “unit” as used in the Hague Rules and Hague-Visby Rules
        “Person” includes and individual a partnership, a body corporate or other entity.
        “Stuffed” includes filled, consolidated, packed, loaded or secured.
2. CARRIER’S TARIFF
        The provisions of the Carrier’s applicable Tariff, if any are incorporated herein. Copies of such provision are obtainable from the carrier or his agents upon request or, where applicable, from a government body with whom the Tariff has been filed. In the case of inconsistency between this Bill of lading and the applicable Tariff, This Bill of Lading shall prevail.
3. WARRANTY
        The Merchant warrants that in agreeing to the terms hereof he is or is the agent of and has the authority of the person owning or entitled to the possession of the Goods or any person who has a present or future interest in the Goods.
4. NEGOTIABILITY AND TITLE TO THE GOODS
        (1) This Bill of Lading shall be non-negotiable unless made out “to order” in which event it shall be negotiable and shall constitule title to the Goods and the holder shall be entitled to receive or to transfer the goods herein described.
        (2) This Bill of Lading shall be prima facie evidence of the taking in charge by the Carrier of the Goods as herein described. However, proof to the contrary shall not be admissible when this Bill of Lading has been negotiated or transferred for valuable consideration to a third party acting in goods failth.
        5.CERTAIN RIGHTS AND IMMUNITIES FOR THE CARRIER AND OTHER PERSONS
        (1) The Carrier shall be entitled to sub-contract on any terms the whole or any part of the Carriage.
        (2) The Merchant undertakes that no claim or allegation shall be made against any person or vessel whatsoever, other than the Carrier, including, but not limited to the Carrier’s servants or  agents. Any independent contractor and his servants or agents, and all others by whom the whole or any part of the Carriage, whether directly or indirectly, is procured, performed or undertake, which imposes or attempts to impose upon any such person or vessel any liability whatsoever in connection with the Goods or the Carriage; and if any claim or allegation should nevertheless be made to defend, indemnity and hold harmless the Carrier against all consequences thereof. Without prejudice to the foregoing every such person and vessel shall have the benefit of all provisions herein benefiting the Carrier as if such provisions were expressly for his benefit of all provisions herein benefiting the Carrier as if such provisions were expressly for his benefit and in entering into this contract the Carrier, to the extent of these provisions, does so not only on his own behalf but also as agent or trustee for such persons and vessels and such persons and vessels shall to this extent be or be deemed to be parties to this contract.
        (3) The Merchant shall defend, indemnify and hold harmless the Carrier against any claim or liability (and any expense arising thereform) arising from the Carrier of the Goods insofar as such claim or liability exceeds the Carrier’s liability under this Bill of Lading.
        (4) The defences and limits of liability provided for in this Bill of Lading shall apply in any action against the Carrier whether the action be found in contract or in Tort.
6. CARRRIER’S RESPONSIBILITY
    (1) CLAUSE PARAMOUNT
    (A) Subject to clause 13 below, this Bill of Lading insofar as it relates to sea carriage by any vessel whether named herein or not shall have effect subject to the Hague Rules of any legistation making such Rules or the Hague-Visby Rules compulsorily applicable (such as COGSA OR COGWA) to this Bill of Lading and the provisions of  the Hague Rules or applicable legistation shall be deemed incorporated herein. The Hague Rules (or COGSA OR COGWA if this Bill of Lading is subject of U.S or Canadian law respectively) shall apply to the carriage of Goods by inland waterways and reference to carriage by sea in such Rules or legistation shall be deemed to include reference to inland waterways. If and to the extent that the provisions of the Hater Act of the United States of America 1893 would otherwise be compulsorily applicable to regulate the Carrier’s responsibility for the Goods during any deriod prior to loading on or after discharge from the vessel the Carrier’s responsibility shall instead be determined by the provisions of 6(3) below, but if such provisions are found to be invalid such responsibility shall be subject to COGSA
            (B) The Carrier shall be entitled to (and nothing in this Bill of Lading shall operate to deprive or limit such entitlement) the full benefit of, and rights to all limitations of and exclusions from liability and all rights conferred or authorised by any applicable law, statute or regulation of any country (including, but not limited to, where applicable any provision or sections 4281 to 4287, inclusive, of the Revised Statutes of the united States of America and amendments thereto and where applicable any provisions of the laws of the United states of America) and without prejudice to the generality of the foregoing also any law, statute or regulation available to the Owner of the vessel(s) on which the Goods are carried
(2) PORT TO PORT SHIPMENT
        The responsibility of the Carrier is limited to that part of the carriage from and during loading onto the vessel up to and during discharge from the vessel and the Carrier shall not be liable for any loss or damage whatsoever in respect to the Goods or for any other matter arising during any other part of the Carriage even though Charges for the whole Carriage have been charged by the Carrier. The Merchant constitutes the Carrier as agent to enter into contracts on behalf of the Merchant with others for transport, storage, handing or any other service in respect of the Goods prior to loading and subsequent to discharge or the Goods from the vessel without responsibility for any act or omission whatsoever on the part of the Carrier or others and the Carrier may as such agent enter into contracts with others on any terms whatsoever including terms less favourable than the terms in this Bill of Lading.
(3) COMBINED TRANSPORT
        save as is otherwise provided in this Bill of lading, the Carrier shall liable for loss of or damage to the Goods occurring from the time that the Goods are taken into this charge until the time of delivery to the extent set out below:
        (A) Where the stage of Carriage where the loss or damage occurred cannot be proved:
        (i) The Carrier shall be entitled to rely upon all exclusions from liability under the Rules or legislation
        that would have been applied under 6(1) (A) above had the loss or damage occurred at sea or if there was no carriage by sea under the Hague Rules (or COGSA or COGWA if this Bill of Lading is subject to U.S or Canadian law respectively).
        (ii) Where under (i) above, the Carrier is not liable in respect of some of the factors causing the loss or damage he shall only be liable to the extent that those factors for which he is liable have contributed to the loss or damage.
        (iii) Subject to 6(4) (C) below, where the Hague Rules or any legistation apply such Rules or the Hague-Visby Rules (such as COGSA or COGWA) is not compulsorily applicable, the Carrier’s liability shall not exceed US $2.00 per kilo of the gross weight of the goods lost, damage or in respect of which the claim arises or the value of such Goods, whichever is the lesser.
        (iv) The value of the Goods shall be determined according to the commodity exchange price at the place and time of delivery to the Merchant or at the place and time when they should have been so delivered or if there is no such price according to the current market price by reference to the normal value of Goods of the same kind and quality, at such place and time.
     
    </pre>
    <pre>
       (B) where the stage of Carriage where the loss or damage occurred can be proved
            (i) the liability of the Carrier shall be determined by the provisions contained in any international convention or national law of the country which provisions
            (a) cannot be departed from by private contract to the detriment of the Merchant and
            (b) would have applied if the Merchant had made a separate and direct contract with the Carrier in respect of the particular stage of Carriage where the loss or damage occurred and had received as evidence thereof any particular document which must be issued in order to make such international convention or national law applicable
            (ii) with respect to the transportation in the United States of America or in Canada to the Port of Loading or from the Port of Discharge the responsibility of the Carrier shall be to procure transportation by carriers
            (one or more) and such transportation shall be subject to the inland carriers contracts of carriage and tariffs and any law compulsorily applicable. The Carrier guarantees the fulfillment of such inland carriers obligations under their contracts and tariffs.
        (iii) Where neither (i) or (ii) above apply, any liability of the Carrier shall be determined by 6(3) (A) above
        (4) GENERAL PROVISIONS
        (A) Delay, Consequential Loss
        save as otherwise provided herein, the Carrier shall in no circumstances be liable for direct, indirect, or consequential loss or damage caused by delay or any other cause whatsoever and howsoever caused. Without prejudice to the foregoing, if the Carrier is found liable for delay, liability shall be limited to the freight applicable to the relevant stage of the transport
        (B) Package or Shipping Unit Limitation
        Where the Hague Rules or any legistation making such Rules compulsority applicable (such as COGSA or COGWA) to this Bill of Lading apply, the Carrier shall not, unless a declared value has been note in accordance with (C) below be or become liable for any loss or damage to or in connection with the Goods in an amount per package or shipping unit in excess of the package or shipping unit limitation as laid down by such Rules or legistation, Such limitation amount according to COGSA is US $500 and according to COGWA is can $500 if no limitation amount is applicable under such Rules or legislation, the limitation shall be US $500.
        (C) Ad Valorem: Declared Value of Package or Shipping Unit
        The Carrier’s liability may be increased to a higher value by a declaration in writing of the value of the Goods by the shipper upon delivery to the Carrier of the Goods for shipment, such higher value being inserted on the front of this Bill of Lading in the space provided and, if required by the Carrier, extra freight paid in such case, if the actual value of the Goods shall exceed suchdeclared value, the value, the value shall nevertheless be deemed to be the declared value and the Carrier’s liability if any, shall not exceed the declared value and any partial loss or damage shall be adjusted prograta on the basis of such declared value.
        (D) Definition of Package or shipping Unit
        Where a Container is used to consolidate Goods and such Container is stuffed by the Carrier, the number of packages or shipping units stated on the face of this Bill of Lading in the box provided shall be deemed the number of packages or shipping units for the purpose of any limit of liability per package or shipping unit provide in any international convention or national law relating to the carriage or shipping unit.
        The words shipping unit’s shall mean each physical unit or piece of cargo not shipped in a package, including articles or things of any description whatsoever, except Goods shipped in bulk, and irrespective of the weight or measurement unit employed in calculating freight charge As to Goods shipped in bulk the limitation applicable thereto shall be the limitation provided in such convention or law which may be applicable and in no event shall anything herein be construed to be waiver of limitation as to Goods shipped in bulk.
        (E) Rust, etc.
        It is agreed that superficial rust, oxidation or any like condition due to moisture is not condition of damage but is inherent to the nature of the Goods and acknowledgement of receipt of the Goods in apparent good order and condition is not a representation that such conditions of rust oxidation or the like did not exist on receipt
        (F) Notice of Loss or Damage
        The Carrier shall be deemed prima facie to have delivered the Goods as described in this Bill of Lading unless or damage shall have been given in writing to the Carrier or to his representative at the place of delivery before or at the time of removal of the Goods into the custody of the person entitled to delivery thereof under this Bill of Lading or, if the loss or damage is not apparent within three consecutive days thereafter
        (G) Time-bar
        The Carrier shall be discharged of all liability unless suit is brought in the proper forum and written notice thereof received by the Carrier within nine months after delivery of the Goods or the date when the Goods should have been delivery in the event that such time period shall be found contrary to any convention or law compulsorily circumstance only.
        7. MERCHANT’S RESPONSIBILITY
        (1) The description and particulars of the Goods set out on the face hereof are furnished by the Merchant and the Merchant warrants to the Carrier that the description and particulars including, but not limited to, of weight, content, measure, quantity, quality, condition marks numbers and value are correct
        (2) The Merchant shall comply with all applicable laws, regulations and requirements of customs, port and other authorities and shall bear and pay all duties taxes fines imports expenses and losses incurred or suffered by reason thereof or by reason of any illegal incorrect or insufficient marking, numbering or addressing of the Goods
        (3) The Merchant undertakes that the Goods are package in a manner adequate to withstand the ordinary risks of carriage having regard to their nature and in compliance with all laws, regulations and requirements which may be applicable
        (4) No Goods which are or may become dangerous inflammable or damaging or which are or may become for Carriage for Carriage without the Carrier’s express consent in writing and without the Container or other covering in which the Goods are to be transported and the Goods being distinctly marked on the outside so as to indicate the nature and character of any such articles and so as to comply with applicable laws, regulations and requirement if any such articles are delivered to the Carrier without such written consent and marking or it in the opinion of the Carrier the articles are or are liable to become of a dangerous inflammable or damaging nature, the same may at any time be destroyed, disposed of abandoned or rendered harmless without compensation to the Merchant and without prejudice to the Carrier’s right to Charges
        (5) The Merchant shall be liable for the loss damage contamination soiling detention or demurrage before during and after the Carriage of property (including but not limited to Containers) of the Carrier or any person or vessel (other than the Merchant) referred to in 5(2) above caused by the Merchant or any person acting on his behalf or for which the Merchant or any person acting on his behalf or for which the Merchant is otherwise responsible
        (6) The Merchant shall defend, indemnify and hold harmless the Carrier against any loss, damage, claim, liability or expense whatsoever arising from any breach of the provisions of this clause 7 or from any cause in connection with the Goods for which the Carrier, is not responsible
        8. CONTAINERS
        (1) Goods may be stuffed by the Carrier in or on Containers and Goods may be stuffed with other Goods
        (2) The terms of this Bill of Lading shall govern the responsibility of the Carrier in Connection with or arising out of the supply of a Container to the Merchant whether supplied before or after the Goods are received by the Carrier or delivered to the Merchant
        (3) If a Container has been stuffed by or on behalf of the Merchant
        (A) The Carrier shall not be liable for loss of or damage to the Goods
        (i) caused by the manner in which the Container has been stuffed
        (ii) caused by the unsuitability of the Goods for carriage in Containers
        (iii) caused by the unsuitability or defective condition of the Container provided that where the Container has been supplied by or on behalf of the Carrier, this paragraph (iii) shall only apply if the unsuitability or defective condition arose (a) without any want of due diligence on the part of the Carrier or (b) would have been apparent upon reasonable inspection by the Merchant at or prior to the time when the Container was stuffed.
        (iv)  if the Container is not sealed at the commencement of the Carriage except where the Carrier has agreed to seal the Container
        (B) the Merchant shall defend indemnify and hold harmless the Carrier against any loss, damage, claim, liability or expense whatsoever arising from one or more of the matters covered by (A) above except for (A)(iii)(a) above
        (4) where the Carrier is instructed to provide a Container in the absence of a written request to the contrary, the Carrier is not under an obligation to provide a Container of any particular type or quality
    </pre>
    <pre>
        9. TEMPERATURE CONTROLLED CARGO
        (1) The Merchant undertakes not to tender for transportation any Goods which require temperature control without previously giving written notice (and filling in the box on the front of this Bill of Lading if this Bill of Lading if this Bill of Lading has been prepared by the Merchant or a person acting on his behalf) of their nature and particulars temperature range to be maintained and in the case of a temperature controlled Container stuffed by or on behalf of the Merchant further undertakes that the Container has been property pre-cooled that  the Goods have been property stuffed in the Container and that it’s themostatic controls have been property set by the Merchant before receipt of the Goods by the Carrier.
        If the above requirements are not complied with the Carrier shall not be liable for any loss of or damage to the Goods caused by such non-compliance.
        (2) The Carrier shall not be liable for any loss of or damage to the Goods arising from defects, derangement, breakdown, stoppage of the temperature controlling machinery, plant, insulation or any apparatus of the Container, provide that the Carrier shall before or at the beginning of the Carriage exercise due diligence to maintain the refrigerated Container in an efficient state
        10. INSPECTION OF GOODS
        The Carrier or any person authorized by the Carrier shall be entitled, but under no obligation, to open any Container or package at any time and to inspect the Goods.
        11. MATTERS AFFECTING PERFORMANCE
        (1) If at any time the Carriage is or is likely to be affected by any hindrance, risk, delay difficulty or disadvantage of any kind (including the condition of the Goods), whensoever  and howsoever arising (whether or not the Carriage has commenced) the Carrier may
        (A) without notice to the Merchant abandon the Carriage of the Goods and where reasonably possible place the Goods or any part of them at the Merchant’s disposal at any place which the Carrier may deem safe and convenient, whereupon the responsibility of the Carrier in respect of such Goods shall cause
        (B) without prejudice to the Carrier’s right subsequently to abandon the Carriage under
        (A) above, continue the Carriage
        In any event the Carrier shall be entitled to full Charges on Goods received for Carriage and the Merchant shall pay any additional costs resulting from the above mentioned circumstances
        (2) The liability of the Carrier in respect of the Goods shall cause on the delivery or other disposition of the Goods in accordance with the orders or recommendations given by any government or authority or any person acting or purporting to act as or on behalf of such government or authority
        12. METHODS AND ROUTE OF TRANSPORTATION
        (1) The carrier may at any time and without notice to the Merchant:
        use any means of transport or storage whatsoever; load or carry the Goods on any vessel whether named on the front hereof or by any other means of transport whatsoever, at any place unpack and remove Goods which Goods which have been stuffed in or on a Container and forward the same in any manner whatsoever proceed at any speed and by any route in his discretion (whether or not the nearest or most direct or customary or advertised routs) and proceed to or stay at any place whatsoever once or more often and in any order : load or unload the Goods from any conveyance at any place (whether or not the place is a port named on the front hereof as the intended Port of Loading or intended Port of Discharge), comply with any orders or recommendations given by any government or authority or having under the terms of the insurance in the conveyance employed by the Carrier the right to give orders of directions : permit the vessel to proceed with or without pilots, to tow or be towed or to be dry docked, permit vessel to carry livestock. Goods of all kinds, dangerous or otherwise, contraband, explosives, munitions or warlike stores and sail armed or unarmed
        (2) The liberties set out in (1) above may be invoked by the Carrier for any purposes whatsoever whether or not connected with the Carriage of the Goods. Anything done in accordance with (1) above or aby delay arising therefrom shall be deemed to be within the contractual Carriage and shall not be a deviation of whatsoever nature or degree.
        13. DECK CARGO (AND LIVESTOCK)
        (1) Goods of any description whether containerized or not may be stowed on or under deck without notice to the Merchant and such stowage shall not be a deviation of whatsoever nature or degree. Subject to (2) below, such Goods whether carried on deck or under deck shall participate in General Average and such Goods (other than livestock) shall be deemed to be within the definition of Goods for the purposes of the Hague Rules or any legislation marking such Rules or the Hague-Visby Rules compulsorily applicable (such as COGSA or COGWA) to this Bill of Lading.
        (2) Goods (not being Goods stuffed in or on Containers other than open flats or pallets) which are stated on the front of this Bill of Lading to be carried on deck and which are so carried (and livestock, whether or not carried on deck) are carried without responsibility on the part of the Carrier for loss or damage of whatsoever nature arising during carriage by sea or inland waterway waterway whether caused by unseaworthiness negligence or any other cause whatsoever. The Merchant shall defend indemnify and hold harmless the Carrier against all and any extra cost incurred for any reason whatsoever in connection with carriage of livestock.
        14. DELIVERY OF GOODS
        If delivery of the Goods or any part thereof is not taken by the Merchant at the time and place when and where to Carrier is entitled to call upon the Merchant to take delivery thereof, the Carrier shall be entitled without notice to remove from a Container the Goods or that part thereof if stuffed in or a Container and to store the Goods or that part thereof ashore, afloat, in the open or under cover at the sole risk and expense of the Merchant Such storage shall constitute due delivery hereunder, and thereupon the liability of the Carrier in respect of the Goods or that part thereof shall cease
        15.BOTH-TO-BLAME COLLISION
        If the vessel on which the Goods are carrier (the carrying vessel) comes into collision with any other vessel or object (the non-carrying vessel or object) as a result of the negligence of the non-carrying vessel or object, or the owner of, charterer of or person responsibility for the non-carrying vessel or object, the Merchant undertakes to defend, indemnify and hold harmless the Carrier against all claim by or liability to (and any expense arising therefrom) any vessel or person in respect of any loss of, or damage to, or any claim whatsoever of the Merchant paid or payable to the Merchant by the non-carrying vessel or object or the owner of, charterer of or person responsible for the non-carrying vessel or object and set- off recouped or recovered by such vessel, object or person(s) against the Carrier, the carrying vessel or her owners or charterers.
        16. GENERAL AVERAGE
        (1) The Carrier may declarer General Average which shall be adjustable according to the York/Antwerp Rules of 1974 at any place at the option of the Carrier and the Amended Jason Clause as approved by BIMCO is to be considered as incorporated herein and the Merchant shall provide such security as may be required by the Carrier in this connection
        (2) Notwithstanding (1) above, the Merchant shall defend, indemnify and hold harmless the Carrier in respect of any claim (and any expense arising therefrom) of a General Average nature which may go made on the Carrier and shall provide such security as may be required by the Carrier in this connection.
        (3) The Carrier shall be under no obligation to take any steps whatsoever to collect security for General Average contributions due to the Merchant.
        17. CHARGES
        (1) Charges shall be deemed fully earned on receipt of the Goods by the Carrier and shall be paid and
        non-refurnable in any event.
        (2) The Charges have been  calculated on  the basis of particulars furnished by or on behalf of the Merchant. The Carrier shall be entitled to production of the commercial invoice for the Goods or true copy thereof and to inspect, reweight, remeasure and revalue the Goods and if the particiars are found by the Carrier to be incorrect the Merchant shall pay the Carrier the correct Charges (credit being given for the charges charged) and the costs incurred by the Carrier in establishing the correct particulars.
        (3) All Charges shall be paid without any set-off, counter-claim, deduction or stay of execution.
        18. LINE
        The Carrier shall have a lien on Goods and any documents relating thereto for all sums whatsoever due at any time to the Carrier from the Merchant and for General Average contributions to whomsoever due and for the costs of recovering the same the Carrier shall have the right to sell the Goods and documents by public auction or private treaty, without notice to the Merchant and at the Merchant’s expense and without any liability towards the Merchant.
        19. VARIATION OF THE CONTACT
        No servant or agent of the Carrier shall have power to waive or vary any of the terms hereof unless such waiver or variation is in writing and is specifically authorised or ratitied in writing by a director or officer of the Carrier who has the actual authority of the Carrier so to waive or vary.
        20. PARTIAL INVIDITY|
        If any provision in this Bill of Lading is held to be invalid or unenforceable by any count or regulatory or self regulatory agency or body, such invalidity or unenforceability shall attach only to such provision. The validity of the remaining provisions shall not be affected thereby and this Bill of Lading contract shall be carried out as if such invalid or unenforceable provision were not contained herein.
    </pre>
</div>
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
            $('#lblLoadDate').text(ShowDate(h.BookingDate));
            $('#lblLoadDate').text(ShowDate(h.BookingDate));
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
            $('#lblPreCarriage').text(h.MVesselName);
            $('#lblPackingPlace').text(h.CYPlace);

            let unit=units.filter(function(data){
               return data.Code==h.InvProductUnit;
             });
            if(unit.length>0) {
               $('#lblProductUnit').text(unit[0].TName);
            } else {
               $('#lblProductUnit').text(h.InvProductUnit);
            }
            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblInterPortName');
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblLoadPort2');
                ShowCountry(path, h.InvFCountry, '#lblCountryName');
            } else {
                ShowCountry(path, h.InvCountry, '#lblCountryName');
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName');
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblLoadPort2');
            }
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblRouting').text(h.FactoryAddress);
            $('#lblReturnPlace').text(h.ReturnPlace);
            $('#lblReturnAddress').text(h.ReturnAddress);
            $('#lblPickupPlace').text(h.CYAddress);
            $('#lblDischargePlace').text(h.ClearPortNo);
            $('#lblTotalPackage').text(CNumEng(h.InvProductQty).replace('ONLY', ''));
            $('#lblServiceMode').text(h.TRemark);
            $('#lblInvCurRate').text(h.InvCurRate);
            $('#lblSumQty').text(CNumEng(h.InvProductQty).replace('ONLY', '') + ' ' + $('#lblProductUnit').text() + ' ONLY');

            let html = '';
            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
            html += '<div style="width:25%;padding:5px 5px 5px 5px;">'+ CStr(h.Remark) +'</div>';
            html += '<div style="width:10%;padding:5px 5px 5px 5px;">' + h.InvProductQty + '<br/>' + $('#lblProductUnit').text() + '</div>';
            html += '<div style="width:30%;padding:5px 5px 5px 5px;">' + h.InvProduct + '<br/>' + CStr(h.ProjectName);
            html += '</div>';
            html += '<div style="width:20%;padding:5px 5px 5px 5px;">G.W ' + ShowNumber(h.TotalGW,3) + ' ' + h.GWUnit + '';
            if(h.TotalNW>0)  {
                html += '<br/>N.W ' + ShowNumber(h.TotalNW, 3) + ' ' + h.GWUnit;
            }
            html +='</div>';
            html += '<div style="width:15%;text-align:center;padding:5px 5px 5px 5px;">'+ h.TotalM3 +' M3</div>';
            html += '</div>';

            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px;margin:5px 5px 5px 5px;">';
            html += '<div style="width:10%;">Container</div>';
            html += '<div style="width:15%;">Seal</div>';
            html += '<div style="width:5%;">Type</div>';
            html += '<div style="width:10%;">Weight</div>';
            html += '<div style="width:10%;">Volume</div>';
            html += '<div style="width:10%;">Package</div>';
            html += '<div style="width:10%;">Mode</div>';
            html += '</div>';
            let i = 0;
            for (i = 0; i < r.booking.data.length; i++){
                let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:10px">';
                htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].CTN_NO +'</div>';
                htmlTemplate += '<div style="width:15%;">' + r.booking.data[i].SealNumber +'</div>';
                htmlTemplate += '<div style="width:5%;">' + r.booking.data[i].CTN_SIZE +'</div>';
                htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].GrossWeight + ' ' + h.GWUnit +'</div>';
                htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].Measurement + ' M3</div>';
                htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].ProductQty + ' ' + $('#lblProductUnit').text() + '</div>';                
                htmlTemplate += '<div style="width:10%;">'+h.TransMode+'</div>';
                htmlTemplate += '</div>';

                html += htmlTemplate;
            }
            //html += '<br/> TOTAL No.Of Containers or Packages (In Words) : ' + CNumEng(h.InvProductQty).replace('ONLY','') + ' ' + $('#lblProductUnit').text() + ' ONLY';
            html += '</div>';
            $('#dvDetail').html(html);
        }
    });
    }
</script>