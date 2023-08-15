@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.ReportName = "BILL OF LADING"
    ViewBag.Title = "BILL OF LADING"
End Code
<style>
    #dvFooter, #pFooter {
        display: none;
    }
</style>
<div style="display:flex">
    <div style="flex-direction:row;width:40%;font-size:10px;">
        <div style="display:flex;flex-direction:column;">
            <div style="height:100px;border-bottom:solid;border-top:solid;border-left:solid;border-width:thin;">
                <b>Shipper</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblShipperName"></label>
                    <br />
                    <label id="lblShipperAddress1"></label>
                    <br />
                    <div id="lblShipperAddress2"></div>
                </div>
            </div>
            <div style="height:100px;border-bottom:solid;border-left:solid;border-width:thin;">
                <b>Consignee or order</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblConsigneeName"></label>
                    <br />
                    <label id="lblConsignAddress1"></label>
                    <br />
                    <div id="lblConsignAddress2"></div>
                </div>
            </div>
            <div style="height:100px;border-bottom:solid;border-left:solid;border-width:thin;">
                <b>Notify address</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblNotifyName"></label>
                    <br />
                    <label id="lblNotifyAddress1"></label>
                    <br />
                    <label id="lblNotifyAddress2"></label>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    @*@<b>Port of Loading</b>
                <div>
                    <label id="lblInterPortName"></label>
                </div>
                    *@
                </div>
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Place of Receipt</b>
                    <div>
                        <label id="lblCYPlace"></label>
                    </div>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Ocean Vessel/Voyage No</b>
                    <div>
                        <label id="lblVesselName"></label>
                    </div>
                </div>
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Port of Loading</b>
                    <div>
                        <label id="lblInterPortName"></label>
                    </div>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex: 1; border-left: solid; border-bottom: solid; border-width: thin;">
                    <b>Port of Discharge</b>
                    <div>
                        <label id="lblFactoryPlace"></label>,<label id="lblCountryName"></label>
                    </div>
                </div>

                <div style="flex: 1; border-left: solid; border-bottom: solid; border-width: thin;">
                    <b>Port of Delivery</b>
                    <div>
                        <label id="lblPackingPlace"></label>
                    </div>
                </div>
            </div>
        </div>        
    </div>
    <div style="flex-direction:row;width:60%;font-size:12px;border-top:solid;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
        <div style="display:flex;flex-direction:column;">
            <div style="display:flex;flex-direction:column;padding:5px 5px 5px 5px;width:50%;align-self:center">
                <div style="flex:1;text-align:center;align-items:center;border:thin;border-width:thin;border-style:solid;">
                    B/L NO:<label id="lblHAWB" style="color:red"></label>
                </div>
            </div>
            <div style="text-align:center">
                <br />
                <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:50%" />
                <br /><br />
                <div id="divCompany" style="text-align:center;color:darkblue;font-size:12px">
                    <div style="font-weight:bold;font-size:12px">
                        <b>BILL OF LADING</b><br />
                    </div>
                    <p style="font-size:10px;text-align:left">
                        RECEIVED by the Carrier that the Goods as specified above in apparent good order and condition
                        unless otherwise stated,to be transported to such place as agreed authorized or permited herein
                        and subject to all the terms and conditions appearing on the front and reverse of this bill of lading
                        that the Merchant agree by accepting this bill of lading any local privileges and customs not withstanding.
                        <br />
                        The particulars given below as stated by shipper and weight measure,quantity,condition contents and value of the goods
                        are unknown to the Carrier in WITNESS where of one (1) original bill of lading has been signed if not otherwise stated below
                        the same being accomplished the other(s),if any to be void,if required by the Carrier one (1) original bill of lading
                        must be surrendered duty endorsed in exchange for the Goods or delivery order.

                    </p>
                </div>

            </div>
        </div>
    </div>
</div>
@*
<div style="width:100%;display:flex;flex-direction:row;font-size:10px;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
    <div style="flex:1;">
        <b>Ocean Vessel/Voyage No</b>
        <div>
            <label id="lblVesselName"></label>
        </div>
    </div>
    <div style="flex:1;border-left:solid;border-width:thin;">
        <b>Port of Discharge</b>
        <div>
            <label id="lblFactoryPlace"></label>,<label id="lblCountryName"></label>
        </div>
    </div>

    <div style="flex:1;border-left:solid;border-width:thin;">
        <b>Port of Delivery</b>
        <div>
            <label id="lblPackingPlace"></label>
        </div>
    </div>
    <div style="flex:1;border-left:solid;border-width:thin;">
        <b>Freight Payable At:</b><br />
        <label id="lblPaymentBy"></label>
    </div>
    <div style="flex:1;border-left:solid;border-width:thin;">
        <b>Number or original BLs :</b><br /><label id="lblBLNo"></label>
    </div>
</div>
*@
<div style="width:100%;display:flex;flex-direction:row;font-size:10px;text-align:center;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
    <div style="width:20%;"><b>Marks & Numbers</b></div>
    <div style="width:15%;"><b>No. of Pkgs or Units</b></div>
    <div style="width:35%;"><b>Kind of Pkgs or Description of Goods (said to contain)</b></div>
    <div style="width:15%;"><b>Gross Weight</b></div>
    <div style="width:15%;"><b>Measurements</b></div>
</div>
<div id="dvDetail" style="height:300px;vertical-align:top;display:flex;flex-direction:column;font-size:10px;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
</div>
<div style="width:100%;display:flex;flex-direction:row;font-size:10px;text-align:center;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
    <div style="width:20%;"><b>Total number of Packages or units (in words)</b></div>
    <div style="width:80%;">
        <label id="lblTotalPackage"></label><label id="lblProductUnit"></label> ONLY
    </div>
</div>
<div style="display:flex;">
    <div style="font-size: 10px;width: 40%; border-left: solid; border-bottom: solid; border-width: thin;">
        <div>
            <b>Freight Details,Charges etc.</b>
            <br /><label id="lblPaymentCondition"></label>
        </div>
        <div>
            <b>F/Agent Name to delivery</b><br />
            <label id="lblDeliveryTo"></label><br />
            <div id="lblDeliveryAddr"></div>
        </div>
    </div>
    <div style="width:60%;font-size:10px;border-left:solid;border-right:solid;border-bottom:solid;border-width:thin;">
        <div>
            <b>Type of Service</b>
            <label id="lblServiceMode"></label>
        </div>
        <div>
            <b>Ex.Rate</b>
            <label id="lblInvCurRate"></label>
        </div>
        <div>
            <b>Place and date of issue :</b>
            <label id="lblBookingDate"></label>
        </div>
        <div>
            <b>Signed on behalf of the carrier:</b>
            <br />
            <br />
            AS AGENT FOR THE CARRIER: <label id="lblForwarderName"></label>
        </div>
    </div>
</div>
<p>
    <div style="width:100%;font-size:14px;">
        <b>Terms and Conditions</b>
    </div>
    <div style="display:flex;font-size:5px;flex-direction:row;">
        <div class="right" style="flex:1;padding:5px 5px 5px 5px;">
            1.(a) Except as otherwise provided herein this Bill of Lading shall have effect subject to the provisions of the Carriage of Goods by Sea Act of the United States of America, approved April 16, 1936, which shall be deemed to be incorporated herein, and nothing herein contained shall be deemed a surrender by the Carrier of any of its rights or immunities or an increase of any of its responsibilities or liabilities under said Act. The provisions stated in said Act (except as otherwise specifically provided herein) shall govern before loading on and after discharge from the vessel and throughout the entire time the Goods are in the custody of the Carrier if this Bill of Lading is issued or delivered in a locality where there is in force a compulsorily applicable Carriage of Goods by Sea Act, ordinance or statute of a nature similar to the International Convention for the Unification of Certain Rules Relating to Bills of Lading dated at Brussels, August 25, 1924. It shall be subject to the provisions of said Act, ordinance or statue and rules thereto annexed.
            (b) The Carrier shall be entitled to full benefit of, and right to, all limitations of, or exceptions from, liability authorized by any provisions of Section 4281 to 4288, inclusive, of the Revised Statutes of the United States and amendments thereto and of any other provisions of the laws of the United States or of any other country whose laws shall apply.
            <br /><br />
            2. In this Bill of Lading
            <br />
            (a) "Carrier" means the Carrier named on the face side hereof, the vessel, her owner, Master, operator, demise charterer, and if bound hereby, the time charterer, and any substitute Carrier whether the owner, operator, charterer or Master shall be acting as carrier or bailee;
            <br />
            (b) "Vessel" means and includes the ocean vessel on which the Goods are shipped, named on the face hereof, or any substitute vessel, also any leadership, ferry, barge, lighter or any other watercraft used by the Carrier in the performance of this contract.
            <br />
            (c) "Merchant" means and includes the shipper, the consignee, the receiver, the holder of this bill of lading, the owner of the Goods or person entitled to the possession of the Goods and the servants or agents of any of these.
            <br />
            (d) "Charges" means and includes freight and all expenses and money obligations incurred and payable by the Merchant.
            <br />
            (e) "Goods" means and includes the cargo received from the shipper and described on the lace side hereof and any Container not supplied by or on behalf of the Carrier.
            <br />
            (f) "Container" means and includes any container, van, trailer, transportable tank, flat, pallet or any similar article of transport.
            <br />
            (g) "Person" means and includes any individual, corporation, partnership or other entity as the case may be.
            <br />
            (h) "Participating Carrier" means and shall include any other water, land or air carrier performing any stage of the Combined Transport.
            <br /><br />
            3. It is understood and agreed that other than the said Carrier no person whatsoever (including the Master, officers and crew of the vessel, all servants, agents, employees, representatives, and all stevedores, terminal operators, crane operators, watchmen, carpenters, ship cleaners, surveyors and other independent contractors whatsoever) is or shall be deemed to be liable with respect to the goods as carrier, bailee or otherwise howsoever, in contract or in tort. If, however, it should be adjudged that any other than  said  carrier  is  under  any responsibility with respect to the Goods, all limitations of the exonerations from liability provided by law or by the terms hereof shall be available to such other persons as herein described in contracting for the foregoing exemptions limitations and exonerations from liability, the Carrier is acting as agent and trustee for and on behalf of all persons described above, all of whom shall to this extent be deemed to be a party to this contract evidenced by this Bill of Lading, it being always understood that said beneficiaries are not entitled to any greater or further exemptions, limitations or exonerations from liability than those that the Carrier has under this Bill of Lading in any given situation.
            <br /><br />
            4. Subject to all rights, privileges and limitations of and exonerations from liability granted to the ocean carrier under this Bill of Lading or by law, any liability by the respective participating carriers for loss or damage to the Goods or packages carried hereunder shall be governed by the following:
            <br /><br />
            (a) If loss or damage occurs while the goods or packages are in the custody of the ocean carrier, only the ocean carrier shall be responsible therefor and any liability of the ocean carrier shall be determined by the terms and conditions of this Bill of Lading and any law compulsorily applicable.
            <br />
            (b) If loss or damage occurs while the Goods or packages are in the custody of a participating domestic or foreign carrier, only the participating domestic or foreign Carrier(s) shall be responsible therefor, and any liability of such participating domestic or foreign Carrier(s) shall be determined, in respective order, by the terms, conditions and provisions of the applicable participating domestic or foreign Carrier's Bill(s) of Lading, whether issued or not, tariff(s) and law compulsorily applicable in the circumstances.
            <br />
            (c) Notwithstanding subdivision (a) and (b) hereof, it is contemplated that the Goods or packages will from time to time be carried in through transportation that will include inland transportation within the United States by railroad and sea carriage by one or more of the other Carrier above defined. (when used in or endorsed on this Bill of Lading the words "on board" shall mean and include on board the original carrying vessel when the Goods or packages are being transported from a foreign port or place to the continental United States, but when the Goods or packages are being transported form the continental United States to a foreign port or place "on board" shall mean and include on board a rail car operated by the originating carrier and en route by rail to the port of loading from loading on board the Carrier's or participating Carrier's vessel.)
            <br />
            (d) If loss or damage occurs after receipt of the Goods or packages hereunder, and it cannot be determined from the records of the ocean Carrier or participating domestic or foreign Carrier(s) whether such damage or loss occurred during ocean, domestic or foreign carriage, it shall be conclusively presumed that the loss or damage occurred on board the vessel and while the Goods or packages were in the custody of the ocean Carrier.
            <br />
            (e) At all times when the Goods or packages are in the custody of the above mentioned participating domestic or foreign Carriers, such Carrier shall be entitled to all rights, defenses, exceptions from or limitations of liability and immunities of whatsoever nature referred to or incorporated herein applicable or granted to the Carrier as herein defined, to the full extent permitted to such domestic and foreign Carriers under this Bill(s) of Lading, tariffs and any other laws applicable or relating thereto, provided however, that nothing contained in this Bill of Lading shall be deemed a surrender by these domestic or foreign Carriers of any of their rights and immunities or an increase of any of their limitations of and exonerations from liability under their said Bill(s) of Lading, tariffs or laws applicable or relating to said carriage.
            <br />
            (f) In making any arrangements for transportation by participating domestic or foreign Carriers of the Goods or packages carried hereunder, either before or after ocean carriage, it is understood and agreed that the ocean Carrier acts solely as agent of the Merchant, without any other responsibility whatsoever, and it assumes no responsibility as Carrier for such domestic or foreign transportation.
            <br />
            (g) Notice of loss or damage and claim against the ocean Carrier, where applicable, shall be given to the ocean Carrier, and suit commenced as provided for in Clauses 30 and 31 hereof. Notice of loss or damage against the participating domestic or foreign Carrier(s), where applicable, shall be filed with the participating domestic or foreign Carrier(s) and suit commenced as provided for the terms conditions and provisions of said Carrier(s) Bill(s) of lading or by law applicable thereto. It is understood by the Merchant that such terms, conditions and provisions, as they pertain to the notice of, and claim for, loss or damage and commencement of suit, contain different requirements than those requirements pertaining to ocean Carriage as contained in Clauses 30 and 31 hereof.
            <br />
            5. The goods carried hereunder are subject to all terms and provisions of the Carrier's applicable Tariff or Tariffs on file with the Federal Maritime Commission, Interstate Commerce Commission or any other regulatory body which governs a particular portion of this carriage, and the terms and provisions of the sail Tariff or Tariffs are hereby incorporated herein as part of the Terms and Conditions of this Bill of Lading. Copies of the relevant provisions of the applicable Tariffs or Tariffs are obtainable from the Carrier, Federal Maritime Commission, Interstate Commerce Commission or other regulatory body upon request.  In the event of any conflict between the terms and provisions of such Tariff or Tariffs and the Terms and Conditions of this Bill of Lading, this Bill of lading shall prevail.
            <br /><br />
            6. The Merchant warrants that in agreeing to the Terms and Conditions hereof, he is, or has the authority of the person owning or entitled to the possession of the Good and this Bill of Lading.
            <br /><br />
            7.(a) The Carrier shall be entitled to sub-contract on any terms the whole or any part of the Carriage, loading, unloading, storing, warehouse, handling, and any and all duties whatsoever undertaken by the Carrier in relation to the Goods.
            <br />
            (b) As to through transportation, the carrier undertakes to procure such services as necessary and shall have the right at its sole discretion to contract any mode of land, sea or air transportation and to arrange participating by other Carriers to accomplish the combined transport from place of receipt to place of delivery. Whenever any stage of the combined transport is accomplished by any land or air Carrier or any other water Carrier, each such stage shall be controlled according to any law compulsorily applicable to such stage and according to the contracts, rules and tariffs of each participating Carrier, the same as if such contracts, rules and tariffs were fully set forth herein.
            <br /><br />
            8. The Carrier shall be entitled but under no obligation to open any Container at any time and to inspect the contents unless applicable law prohibits same. If it thereupon appears that the contents or any part thereof cannot safely or properly be carried further, either at all or without incurring any additional expense or taking any measures in relation to the Container or its contents or any part thereof, the Carrier may abandon the transportation thereof and/or take any measures and/or incur any reasonable additional expense to carry or to continue the Carriage or to store the same ashore or afloat under cover or in the open, at any place, which storage shall be deemed to constitute due delivery under this Bill of Lading. The Merchant shall indemnify the Carrier against any reasonable additional expense so incurred.
            <br /><br />
            9. Carrier may containerize any Goods or packages.  Containers may be stowed on deck or under deck and when so stowed shall be deemed for all purposes to be stowed under deck. Including for General Average and U.S. Carriage of Goods by Sea Act, 1936 and similar legislation.
            <br /><br />
            10. Deck cargo (except goods carried in container on deck) and live animals and received and carried solely at Merchant's risk (including accident or mortality of animals) and the Carrier shall not in any event be liable for any loss or damage thereto arising or resulting from any matters mentioned in Section 4, Sub Section 2 (a) to (p), inclusive, of the United States. Carriage of Goods by Sea Act or from any other cause whatsoever not due to the fault of the Carrier, any warranty of seaworthiness in the premises being hereby waived, and the burden of proving liability being in all respects upon the Merchant. Except as provided above, such shipments shall be deemed Goods and shall be subject to all terms and provisions of this Bill of Lading relating to Goods.
            <br /><br />
            11. Special containers with heating or refrigeration units will not be furnished unless contracted for expressly in writing at time of booking and, when furnished, may entail an increased freight rate or charge. Shipper shall advise Carrier of desired temperature range when delivering Goods to Carrier, and Carrier shall exercise due diligence to maintain the temperature within a reasonable range while the containers are in its custody or control. The Carrier does not, however, accept any reasponsibility for the functioning of heated or refrigerated container not owned or leased by Carrier.
            <br />
            12. The scope of the voyage herein contracted for shall include usual or customary or advertised ports of call whether named in this contract or not, also ports in or out of the advertised, geographical or usual route or order, even though in proceeding thereto the vessel may sail beyond the port of discharge named herein or in a direction contrary thereto or return to the original port, or depart from the direct or customary route and includes all canals, straits and other waters. The vessel may call at any port for the purpose of the current, prior or subsequent voyages. The vessel may omit calling at any port whether scheduled or not, and may call at the same port more than once, may discharge the goods during the first or subsequent call at the port of discharge, may for matters occurring before or after loading, and either with or without the goods on board, and before or after proceeding towards the port of discharge adjust compasses, drydock with or without cargo on board, stop for repairs, shift berths, make trail trips or tests, takes fuel or stores, remain in port, be on bottom, aground or at anchor, sail with or without pilots, tow and be towed, and save or attempt to save life or property, and all of the foregoing are included in the contract voyage. The vessel may carry contraband, explosives, munitions, warlike stores, hazardous cargo, and sail armed or unarmed, and with or without convoy.
            The Carrier’s sailing schedules are subject to change without notice both as to the sailing date and the date of arrival. If this is a Through Bill of Lading, no Carrier is bound to transport the shipment by any particular train, truck, aircraft, vessel or other means of conveyance, or in time for any particular market or otherwise. No Carrier shall be liable for delay and any Carrier shall have the right to forward the goods by substitute Carrier.
        </div>
        <div class="right" style="flex:1;padding:5px 5px 5px 5px;">
            13. If at any time the performance of the contract evidenced by this Bill of Lading is or is likely to be affected by any hindrance, risk, delay difficulty, or disadvantage of whatsoever kind which cannot be avoided by the exercise of reasonable endeavors, the Carrier (whether or not the transport is commenced) may without notice to the Merchant treat the performance of this contract as terminated and place the Good or any part of them at the Merchant’s disposal at any place or port which the Carrier may deem safe and convenient, whereupon the responsibility of the Carrier in respect of such Goods shall cease. The Carrier shall nevertheless be entitled to full freight and charges on Goods received for transportation and the Merchant shall pay any additional costs of carriage to and delivery and storage at such place or port.
            <br /><br />
            14. If the Carrier makes a special agreement, whether by stamp hereon or otherwise, to deliver the Good at a specified dock or place, it is mutually agreed that such agreement shall be construed to mean that the carrier is to make such delivery only if, in the sole judgement of the Carrier, the vessel can get to, be at, and leave said dock or place, always safely afloat, and only if such dock or place is available for immediate receipt of the Goods and that otherwise the Goods shall be discharge as otherwise provided in this Bill of lading, whereupon all responsibility of Carrier shall cease.
            <br /><br />
            15. The port authorities are hereby authorized to grant a general order for discharging immediately upon arrival of the vessel and the Carrier, without giving notice either of arrival or discharge, may, immediately upon arrival of the vessel at the designated destination, discharge the4 goods continuously, Sundays and holidays included, at all such hours by day or by night as the Carrier may determine no matter what the state of the weather or custom of the port may be.
            <br /><br />
            The Carrier shall not be liable in any respect whatsoever if heat or refrigeration or special cooling facilities shall not be furnished during loading or discharge or any part of the time that the Goods are upon the wharf, craft or other loading or discharging place.
            <br /><br />
            Landing and delivery charges and pier dues shall be at the expense of the Goods unless included in the freight herein provided for, if the Goods are not taken away by the consignee by the expiration of the next working day after the Goods are at his disposable, the Goods may, at Carrier’s option and subject to Carrier’s lien, be sent to store or warehouse or be permitted to lie where landed, but always at the expense and risk of the Goods. The responsibilities of the Carrier in any capacity shall altogether cease and the Goods shall be considered to be delivered and at their own risk and expense in every respect when taken into the custody of Customs or other Authorities, or into that of any municipal or government concessionaire or depository. The Carrier shall not be required to give any notification of disposition of the Goods, except as may be otherwise provided in this Bill of Lading.
            <br /><br />
            16. At ports or places where by local law, authorities, or custom, the Carrier is required to discharge cargo to lighters or other craft, or where is has been so agreed, or where wharves are not available which the ship can get to, lie at, or leave, always safely afloat, or where conditions prevailing at the time render discharge at a wharf dangerous, imprudent, or likely to delay the vessel, the Merchant shall promptly furnish lighters or other craft to take delivery alongside the ship, at the risk and expense of the Goods. If the Merchant fails to provide such lighters or other craft, Carrier, acting solely as agent for the Merchant, may engage such lighters or other craft at the risk and expense of the Goods. Discharge of the Goods into such lighters or other craft shall constitute proper delivery, and any further responsibility of Carrier with respect to the goods shall thereupon terminate.
            <br /><br />
            17. The Carrier shall have liberty to comply with any order or directions or recommendations in connection with the transport under this contract of carriage given by any Government or Authority or  anyone  acting  or purporting to act on behalf of such Government or Authority, or having, under the terms of the mortgage or insurance on the vessel or other transport, the right to give such  orders,  directions  or  recommendations. Discharge or delivery of the Goods in accordance with the said order or directions or recommendations shall be deemed a fulfillment of the contract. Any extra expense incurred in connection with the exercise of the Carrier’s liberty under this clause shall be paid by the Merchant in addition to freight and charges.
            <br /><br />
            18. Whenever the Carrier or Master may deem it advisable, or in any case where goods are destined for port(s) or places(s) at which the vessel or participating carrier swill not call, the Carrier may, without notice, forward the whole or any part of the shipment, before or after loading at the original port of shipment, or any other place or places even though outside the scope of the voyage or the route to or beyond the port of discharge or destination of the Goods by water, by land or by air or by any combination thereof, whether operated by the Carrier or others and whether departing or arriving or scheduled to depart or arrive before or after the ship expected to be used for the transportation of the shipment. The Carrier may delay forwarding awaiting a vessel or conveyance in its own service or with which it has established connections in all cases where the shipment is delivered to another Carrier or to a lighter. Port authority, warehouseman or other bailee for transshipment, the liability of this Carrier shall absolutely cease when the Goods are out of its exclusive possession and shall not resume until the Goods again come into its exclusive possession, and the responsibility of this Carrier during any such period shall be that of an agent of the Merchant, and this Carrier shall be without any other responsibility whatsoever. The carriage by any transshipping or on-Carrier and all transshipment or forwarding shall be subject tot all the terms whatsoever in the regular form of bill of lading, consignment note, contract or other shipping document used at the time by the Carrier performing such transshipment or forwarding.
            <br />
            19. In any situation whatsoever and wheresoever occurring and whether existing or anticipated before commencement of or during the combined transport, which in the judgment of the Carrier or the Master is likely to give rise to risk of capture, seizure, detention, damage, delay or disadvantage of loss to the Carrier of any part of the Goods to make it unsafe, imprudent or unlawful for any reason to receive, keep, load, or carry the goods, or commerce or proceed on or continue the transport or to enter or discharge the goods or disembark passengers at the port of discharge, or the usual or agreed or intended place of discharge or delivery, or to give rise to delay, or difficulty in proceeding by the usual or intended route, the Carrier or the Master may decline to receive, keep load or carry the Goods or may devan container(s) contents or any part thereof and may require the Merchant to take delivery of the Goods at the place of receipt or any other point in the combined transport and upon failure to do so, may warehouse the Goods at the risk and expense of the Goods, or the vessel, whether or not proceeding toward or entering or attempting to enter a port of discharge, or reaching or attempting to reach a usual place of discharge therein or attempting to discharge the shipment may discharge the Goods and/or devan the contents of any container(s) at another port depot, lighter craft or other place or may forward or transship them as provided in this Bill of Lading, or the Carrier or the Master may retain the Goods vanned or unvanned, on board until the return of the vessel to the port of loading or to the port of discharge or until such time as the Carrier or the Master thinks advisable and discharge the Goods at any place whatsoever as herein provided.  The Carrier or the Master is not required to give notice of such devanning or of discharge of the Goods or of the forwarding thereof as herein provided. When the Goods are discharged from the ship as herein provided, such shall be at the risk and expense of the Goods.  Such discharge shall constitute complete delivery and performance under this contract and the Carrier shall be free from any further responsibility, unless it be shown that any loss or damage to the Goods arose from Carrier’s negligence in the discharge and delivery as herein provided, the burden of establishing such negligence being on the Merchant. For any service rendered to the Goods as hereinabove provided or for any delay or expense to the vessel caused as a result thereof, the Carrier shall be entitled to a reasonable extra compensation, and shall have a lien on the goods for such carriage. Notice of disposition of Goods shall be mailed to shipper or consignee named in this Bill of Lading.  Goods shut out from the vessel named herein for any cause may be forwarded on a subsequent vessel of this type or at Carrier's’ option, on a vessel of another type or by other mode of transportation.
            <br /><br />
            20. Notwithstanding the foregoing, the Carrier shall neither be liable therefor, nor concluded as to the correctness of any such marks, descriptions or representations.
            <br /><br />
            When any cargo unit owned or leased by Carrier is packed or loaded by shipper or its agent, or discharged by consignee or its agent, shipper, consignee, receiver, holder of this Bill of Lading, owners of the Goods and person entitled to the possession of the Goods shall be and remain liable, jointly and severally, for any loss or damage to the cargo until during such loading or discharge, howsoever occurring until the cargo unit is returned to Carrier’s custody and, at tariff rates, for any delay beyond the time allowed for such loading or discharge and for any loss, damage or expense incurred by Carrier as a result of the failure to return the cargo unit to the Carrier in the same, sound condition and state of cleanliness as when received by shipper. Such loss, damage, expense or delay shall constitute a lien on the Goods.
            <br /><br />
            Where a cargo unit is to be unpacked or unloaded by consignee or its agent, consignee or its agent shall promptly unpack or unload such cargo unit and take delivery of its contents, irrespective of whether the Goods are damaged or not.  Carrier shall not be liable for loss or damage caused to the Goods by or during such unpacking or unloading.
            <br /><br />
            21. When containers, vans, trailer, transportable tanks, flats, palletized units, and all other  packages  (all hereinafter referred to generically as "“cargo units”) are not packed or loaded by Carrier, such cargo units shall be deemed shipped as Shipper’s weight, load and count. “Carrier has no reasonable means of checking the quantity, weight, condition or existence of the contents thereof, does not represent the quantity, weight and condition or existence of such contents, as furnished by the shipper and inserted in this Bill of Lading, to be accurate and shall not be liable for nonreceipt or misdescription of such contents. Carrier shall have no securing and/or stowage of contents of such cargo units, or for loss or damage caused thereby or resulting therefrom, or for the physical suitability or structural adequacy of such cargo units properly to contain their contents.
            <br /><br />
            The Merchant whether principal or agent, by packing or loading the cargo unit and/or allowing the cargo unit to be so packed or loaded, represents, guarantees and warrants (a) that the Goods are properly described, marked and safely packed in their respective cargo units, that such cargo units are physically suitable, sound and structurally adequate properly to contain and support the Goods during handling and on the transport and that the cargo units may be handled in the ordinary course without damage to themselves or to their contents, or to the vessel or conveyance or to their cargo, or properly, or persons, (b) that all particulars with regard to the cargo units and their contents and the weight of each said cargo unit, are in all respects correct, and (c) that they have ascertained and fully disclosed in writing tot he Carrier and all participating Carrier on or prior to shipment, any condition, ingredient or characteristic of the Goods which might indicate that they are inflammable, explosive, corrosive, radioactive, noxious, hazardous or dangerous in nature or which might cause damage, injury or detriment to the Goods, or to the vessel, conveyance or other cargo or to properly or persons and that they have complied fully with all statues ordinances and regulations of the Department of Transportation of the United States of America and all other regulatory bodies with respect to labeling, packing and preparation of shipment of all such Goods.
            <br /><br />
            The shipper, consignee receiver, holder of this Bill of Lading, owner of the Goods and person entitled to the possession of the Goods jointly and severally agree fully to protect and indemnify Carrier and to hold it harmless in respect to any injury or death of a person, or loss or damage to cargo or cargo unit of any other property or to the vessel or conveyance or expense or line arising out of damage to cargo or cargo unit or any other property, or to the vessel or conveyance or expense or fine arising out of or in any way connected with breach of any of the foregoing representations or warranties, howsoever occurring, even without fault of shipper, consignee and/or owner of the Goods, and even though such injury, death, loss or damage is caused in whole or in part by fault of the Carrier or unseaworthiness.
            <br /><br />
            22. The Merchant and the Goods themselves shall be liable for and shall indemnify the Carrier, and the Carrier shall have a lien on the Goods for all expenses of mending, repairing, fumigating, repacking, coopering, baling, reconditioning of the Goods are gathering of loose contents of packages,  also  for  expenses  for  repairing containers damaged while in the possession of the Merchant for demurrage on containers and any payment, expense, fine, dues, duty, tax, impost, loss, damage or detention sustained or incurred by or levied upon the Carrier, vessel or conveyance in connection with the Goods, howsoever caused, including any action or requirement of any government or governmental authority or person purporting to act under the authority thereof,seizure under legal process or attempted seizure, incorrect or insufficient marking, numbering, or addressing of containers, packages or description of the contents, failure of the Merchant to procure consular, Board of Health or other certificates to accompany the Goods or to comply with the laws or regulations of any kind imposed with respect to the Goods by the authorities at any port or place or any act or omission of the Merchant.  The Carrier’s lien shall survive delivery and may be enforced by private or public sale and without notice.
        </div>
        <div class="right" style="flex:1;padding:5px 5px 5px 5px;">
            23. Freight shall be payable, at Carrier’s option, on actual gross intake weight or measurement or on actual gross discharge weight or measurement or on a value or other basis. Freight may be calculated on the basis of the particulars of the Goods furnished by the shipper herein, but the Carrier may, as previously stated herein, at any time open the packages or containers and examine, weigh, measure and value the Goods (unless applicable law prohibits same). In case shipper’s particulars are found to be erroneous and additional freight payable, the Merchant and the Goods shall be liable for any expense incurred for examining, weighing, measuring and valuing the Goods. Full freight shall be paid on damaged or unsound goods. Full freight hereunder to place of delivery named herein and advance charges (including on-Carrier’s) shall be considered completely earned on receipt of the Goods by the Carrier, whether the freight be stated or intended to be prepaid or to be collected at destination, and the Carrier shall be entitled to all freight and charges, extra compensation, demurrage, detention, General Average, claims and any other payments made and liability incurred with respect to the Goods, whether actually paid or not, and to receive and retain them irrevocably under all circumstances whatsoever, vessel, conveyance and/or cargo lost, damaged or otherwise, or the combined transport changed, frustrated or abandoned. In case of forced abandonment or interruption of the combined transport for any cause, any forwarding of the goods or any part thereof shall be at the risk and expense of the Goods. All unpaid charges shall be paid in full, without any offset, counterclaim or deduction in the currency of the place of receipt, or, at Carrier’s option, in the currency of the place of delivery at the demand rate of New York exchange as quoted on day of arrival of the Goods at the place of delivery.
            <br /><br />
            The Merchant shall be jointly and severally liable to the Carrier for the payment of all freight charges and the amount due to the Carrier, and for any failure of either or both to perform his or their obligations under the provisions of this Bill of Lading, and they shall indemnity the Carrier against, and hold it harmless from all liability, loss, damage and expense which the Carrier may sustain or incur arising or resulting from any such failure of performance by the Merchant. Any person, firm or corporation engaged by any party to perform forwarding services with respect to the cargo shall be considered the exclusive agent of the Merchant for all purposes and any payment of freight to such person, firm or corporation shall not be considered payment to the Carrier in any event.  Failure of such person, firm or corporation to pay any part of the freight to the Carrier shall be considered a default by the Merchant in the payment of the freight.
            <br /><br />
            The Carrier shall have a lien on the Goods and any documents relating thereto, which shall survive delivery, for all freight charges and damages of any kind whatsoever, and for the costs of recovering same, including expenses incurred in preserving this lien, and may enforce this lien by publish or private sale and without notice. The shipper, consignee, receiver, holder of this Bill of Lading, owner of the Goods and person entitled to the possession of the Goods shall be jointly and severally liable to the Carrier for the payment of all freight charges and damages as aforesaid and for the performance of the obligations of each of them hereunder.
            <br /><br />
            24. Carrier shall not be liable for any consequential or special damages and shall have the option of replacing lost Goods or repairing damaged Goods.
            <br /><br />
            25. The weight or quantity of any bulk cargo inserted in this Bill of Lading is the weight or quantity as ascertained by a third party other than the Carrier and Carrier makes no representation with regard to the accuracy thereof. This Bill of Lading shall not be deemed evidence against the Carrier of receipt of goods of the weight or quantity so inserted in the Bill of Lading.
            <br /><br />
            26. Neither the Carrier nor any corporation owned by, subsidiary to or associated or affiliated with the Carrier shall be liable to answer for or make good any loss or damage to the goods occurring at any time and even though before loading on or after discharge from the ship, by reason or by means of any fire whatsoever, unless such fire shall be caused by its design or neglect, or by its actual fault or privily. In any case where this exemption is not permitted by law. Carrier shall not be liable for loss or damage by fire unless shown to have been caused by Carrier’s negligence.
            <br /><br />
            27. If the vessel comes into collision with another vessel as a result of the fault or negligence of the other vessel and any act, neglect or default of the Carrier, Master, mariner, pilot or the servants of the Carrier in the navigation or in the management of the vessel, the Merchant will indemnity the Carrier against all loss or liability to the other or non-carrying vessel or her owners insofar as such loss or liability represents loss of, or damage to, or any claim whatsoever of the Merchant, paid or payable by the other or non-carrying vessel or her owners to the Merchant and set-off, recouped or recovered by the other or non-carrying vessel or her owners as part of their claim against the carrying vessel or Carrier.
            <br /><br />
            The foregoing provisions shall also apply where the owners, operators or those in charge of any vessel or vessels or objects other than, or in addition to the colliding vessels or objects are at fault in respect of a collision, contact, stranding or other accident.
            <br /><br />
            This provision is to remain in effect in other jurisdictions even if unenforceable in the Courts of the United States of America.
            <br /><br />
            28. General Average shall be adjusted, stated and settled according to York Antwerp Rules 1974, except Rule XII thereof, at such port or place as may be selected by the Carrier and as to matters not provided for by these Rules, according to the laws and usage’s of New York.
            <br /><br />
            In such adjustment, disbursements in foreign currencies shall be exchanged into United States money at the rate prevailing on the dates made and allowances for damage to cargo claimed in foreign currency shall be converted at the rate prevailing on the last day of discharge at the port or place of final discharge of such damaged cargo from the ship.  Average agreement or bond and such additional security as may be required by the Carrier must be furnished before delivery of the goods. Such cash deposit as the Carrier or his agents may deem sufficient as additional security for the contribution of the goods and for any salvage and special charges thereon shall, if required, by  made by the Goods, shippers, consignees or owners of the goods to the Carrier before delivery of the Goods. Notwithstanding anything here in before contained, such deposit shall at the option of the Carrier be payable in United States currency, and be remitted to the adjust pending settlement of the General Average and refunds of credit balances, if any, shall be paid in United States currency. In addition to the circumstances dealt with the 1974 York Antwerp Rules. It is agreed that if the Carrier has used due diligence in the stowage of cargo and if the safe prosecution of the voyage is thereafter imperiled in consequence of the disturbance of stowage, the costs of handling, discharge, reloading and restowing cargo shall be allowed in General Average, even though the handling of cargo is not necessary for the purpose of effecting repairs to the vessel.
            <br /><br />
            In the event of accident, danger or disaster, before or after commencement of the voyage resulting from any cause, whatsoever whether due to negligence or not for which or for the consequence of which, the Carrier is not responsible by statue, contract or otherwise, the Goods, the shipper, consignee, receiver holder of this Bill of Lading, owner of the Goods and person entitled to the possession of the Goods, jointly and severally, shall contribute with the Carrier in General Average to the payment of any sacrifices, losses or expenses of a General Average nature that may be made or incurred and shall pay salvage and special charges incurred in respect of the Goods. If a salving ship is owned or operated by the Carrier, salvage shall be paid for as fully and in the same manner as if such salving ship or ships were owned or operated by strangers. Cargo’s contribution in General Average shall be paid to the shipowner even when such average is the result of fault, neglect or error of the Master, pilot officers or crew. The Merchant expressly renounces any and all codes, statutes, laws or regulations which might otherwise apply.
            <br /><br />
            29. In case of any loss or damage to or in connection with Goods exceeding in actual value the equivalent of $500 lawful money of the United States per package, or in case of Goods not shipped in packages, per shipping unit, the value of the Goods shall be deemed to be $500 per package or per shipping unit. The Carrier’s liability, if any, shall be determined on the basis of a value of $500 per package or per shipping unit or pro rata in case of partial loss or damage unless the nature of the Goods and a valuation higher than $500 per package or per shipping unit shall have been declared by the shipper before shipment and inserted in this Bill of Lading, and extra freight paid if required. In such case, if the actual value of the Goods per package or per shipping unit shall exceed such declared value, the value shall nevertheless be deemed to be declared value and the Carrier’s liability.  If any, shall not exceed the declared value and any partial loss or damage shall be adjusted pro rata on the basis of such declared value. The words “shipping unit” shall mean each physical unit or piece of cargo not shipped in a package, including articles or things of any description whatsoever, except goods shipped in bulk, and irrespective of the weight or measurement unit employed in calculating freight charges.
            <br /><br />
            Where containers, vans, trailers, transportable tanks, flats, palletized units and other such packages are not packed by the Carrier, each individual such container, van, trailer, transportable tank, palletized unit and other such package including in each instance its contents, shall be deemed a single package and Carrier’s liability, limited to $500 with respect to each such package.
            <br /><br />
            30. As to loss or damage to the Goods or packages occurring or presumed to have occurred during ocean voyage, unless notice of loss of or damage and the general nature of it be given in writing to the Carrier or its agent at the port of delivery before or at the time of the removal of the Good or packages into the custody of the persons entitled to delivery thereof under this Bill of Lading or, if the loss or damage be not apparent, within three consecutive days after delivery at the port of discharge, such removal shall be prima facie evidence of the delivery by the Carrier of the goods or packages as described in this Bill of Lading.
            <br /><br />
            31. As to loss or damage to the Goods or package occurring or presumed to have occurred during ocean carriage, the Carrier and the vessel shall be discharged from all liability in respect of loss, damage, misdelivery, delay or in respect of any other breach of this contract and any claim whatsoever with respect to the Goods or packages, unless suit is brought within one year after delivery of the Goods or package or the date when the Goods or package should have been delivered. Suit shall not be deemed brought unless jurisdiction shall have been obtained over the Carrier and/or the vessel by service of process or by an agreement to appear.
            <br /><br />
            32. Gold, silver, specie, bullion or other valuables, including those named or described in Sec. 4281 of the Revised Statutes of the United States, will not be received by the Carrier unless their true character and value are disclosed to the Carrier and a special written agreement therefor has been made in advance, and will not, in any case, be loaded or landed by the Carrier. No such valuables shall be considered received by or delivered to the Carrier until brought aboard the ship by the shipper and put in the actual possession of and a written receipt therefor is given by the Master or other officer in charge. Such valuables will only be delivered by the Carrier aboard the ship on presentation of bills of lading properly endorsed and upon such delivery on board the Carrier’s responsibility shall cease. If delivery is not so taken promptly after the ship’s arrival at the port of discharge, the goods may be retained aboard or landed or carried on, solely at the risk and expense of the goods.
            <br /><br />
            33. It is agreed that superficial rust, oxidation or any like condition due to moisture, is not a condition of damage but is inherent to the nature of the cargo, and acknowledgement of receipt of the Goods in apparent good order and condition is not representation that such conditions of rust, oxidation and the like did not exist on receipt.
            <br /><br />
            34. Nothing in this Bill of Lading shall operate to deprive the Carrier of any statutory protection or exemption from, or limitation of, liability, contained in the laws of the United Sates, or in the laws of any other country which may be applicable.  This Bill of Lading shall be construed according to the laws of the United States and the merchant agrees that any suits against the Carrier shall be brought in the Federal Courts of the United States. The terms of this Bill of Lading shall be separable, and if any part or term hereof shall be held invalid, such holding shall not affect the validity or enforceability of any other part or term hereof.   +++
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
            //$('#lblMAWB').text(h.MAWB);
            $('#lblHAWB').text(h.BookingNo);
            $('#lblBLNo').text(h.BLNo);
            $('#lblDeliveryTo').text(h.DeliveryTo);
            $('#lblDeliveryAddr').html(CStr(h.DeliveryAddr));
            $('#lblTransMode').text(h.TransMode);
            $('#lblPaymentBy').text(h.PaymentBy);
            $('#lblPaymentCondition').text(h.PaymentCondition);
            $('#lblBookingDate').text('BANGKOK ' + ShowDate(h.BookingDate));
            $('#lblForwarderName').text(h.ForwarderName);
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperAddress1').text(h.ShipperAddress1);
            $('#lblShipperAddress2').html(CStr(h.ShipperAddress2));
            $('#lblConsigneeName').text(h.ConsigneeName);
            $('#lblConsignAddress1').text(h.ConsignAddress1);
            $('#lblConsignAddress2').html(CStr(h.ConsignAddress2));
            $('#lblNotifyName').text(h.NotifyName);
            $('#lblNotifyAddress1').text(h.NotifyAddress1);
            $('#lblNotifyAddress2').text(h.NotifyAddress2);
            $('#lblVesselName').text(h.VesselName);
            //$('#lblMVesselName').text(h.MVesselName);
            $('#lblPackingPlace').text(h.PackingPlace);
            $('#lblCYPlace').text(h.CYPlace);
            $('#lblClearPortName').text(h.ClearPortNo);
            //ShowReleasePort(path, h.ClearPort, '#lblClearPortName');
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
                ShowCountry(path, h.InvFCountry, '#lblCountryName');
            } else {
                ShowCountry(path, h.InvCountry, '#lblCountryName');
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName');
            }
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblTotalPackage').text(CNumEng(h.InvProductQty).replace('ONLY', ''));
            $('#lblServiceMode').text(h.TRemark);
            $('#lblInvCurRate').text(h.InvCurRate);

            let html = '';
            //html += '<div style="width:100%;text-align:center;font-size:10px">"SHIPPER LOAD & COUNT & SEAL"</div>';
            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
            html += '<div style="width:20%;">'+ CStr(h.Remark) +'</div>';
            html += '<div style="width:15%;">' + h.InvProductQty + '<br/>' + $('#lblProductUnit').text() + '</div>';
            html += '<div style="width:35%;">' + h.InvProduct + '<br/>' + CStr(h.ProjectName);
            html += '<br/>SAY ' + h.TotalContainer + ' CONTAINER(s) ONLY';
            html += '</div>';
            html += '<div style="width:15%;">G.W ' + ShowNumber(h.TotalGW,3) + ' ' + h.GWUnit + '';
            if(h.TotalNW>0)  {
                html += '<br/>N.W ' + ShowNumber(h.TotalNW, 3) + ' ' + h.GWUnit;
            }
            html +='</div>';
            html += '<div style="width:15%;text-align:center">'+ h.TotalM3 +' M3</div>';
            html += '</div>';

            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
            html += '<div style="width:45%;"><u>CONTAINER & SEAL</u></div>';
            html += '</div>';
            let i = 0;
            for (i = 0; i < r.booking.data.length; i++){
                if (r.booking.data[i].CTN_NO != null) {
                    let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:10px">';
                    htmlTemplate += r.booking.data[i].CTN_NO + '/' + r.booking.data[i].CTN_SIZE + ' #' + r.booking.data[i].SealNumber + ' ' + r.booking.data[i].Measurement + ' M3 ' + r.booking.data[i].ProductQty + ' ' + r.booking.data[i].ProductUnit + ' ' + h.TransMode;
                    htmlTemplate += '</div>';

                    html += htmlTemplate;
                }
            }
            //html += '<div style="font-size:9px;">SAY ' + h.TotalContainer + ' CONTAINER(s) ONLY';
            //html += '<br/> TOTAL ' + CNumEng(h.InvProductQty).replace('ONLY','') + ' ' + $('#lblProductUnit').text() + ' ONLY';
            html += '</div>';
            $('#dvDetail').html(html);
        }
    });
    }
</script>
