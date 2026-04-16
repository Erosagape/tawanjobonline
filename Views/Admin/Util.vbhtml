@Imports Newtonsoft.Json
@Code
    ViewData("Title") = "Util"
    Dim dt As New Data.DataTable
    Dim id As Integer = 0
    Dim moduleName As String = ""
    Dim dateFrom As String = "2026-03-30"
    Dim dateTo As String = "2026-03-31"
    Dim msg As String = ""
    Dim docNo As String = ""
    If ViewBag.User <> "" Then
        If Not Request.Form("submit") Is Nothing Then
            dateFrom = Request.Form("dateFrom")
            dateTo = Request.Form("dateTo")
            moduleName = Request.Form("moduleName")
            docNo = Request.Form("docNo")
        End If

        If Not Request.QueryString("ModuleName") Is Nothing Then
            moduleName = Request.QueryString("ModuleName")
        End If

        If Not Request.QueryString("ID") Is Nothing Then
            id = Convert.ToInt32(Request.QueryString("ID"))
        End If

        Dim obj = New CUtil(ViewBag.CONNECTION_JOB)
        obj.ExecuteSQL("UPDATE Mas_Config SET ConfigValue='N' WHERE ConfigKey='SAVE_LOG'")
        'Dim sql As String = String.Format("SELECT * from weblicense.dbo.TWTLog where ModuleName='{0}' AND LogDateTime>='2026-03-27' AND LogDateTime<='2026-03-31' AND JsonData<>'' ", moduleName) & IIf(id > 0, " AND LogID=" & id, "") & " ORDER BY ModuleName,LogDateTime,LogID"
        Dim sql As String = "SELECT * from weblicense.dbo.TWTLog " & IIf(id > 0, " WHERE LogID=" & id, String.Format("where LogDateTime>='" & dateFrom & "' AND LogDateTime<='" & dateTo & "' AND JsonData<>'' AND ModuleName='{0}'", moduleName) & IIf(docNo <> "", String.Format(" AND JsonData like '%{0}%'", docNo), "")) & " ORDER BY ModuleName,LogDateTime,LogID"
        dt = obj.GetTableFromSQL(sql)
        msg = sql
        If dt.Rows.Count > 0 Then
            msg = ""
            Dim i As Integer = 0
            For Each r As Data.DataRow In dt.Rows
                Dim jsonData = r("JsonData").ToString()
                Select Case r("ModuleName").ToString()
                    Case "CWHTaxHeader"
                        Dim oData = JsonConvert.DeserializeObject(Of CWHTaxHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE DocNo='{0}'", oData.DocNo))
                    Case "CWHTaxDetail"
                        Dim oData = JsonConvert.DeserializeObject(Of CWHTaxDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE DocNo='{0}' AND ItemNo={1}", oData.DocNo, oData.ItemNo))
                    Case "CVoucherSub"
                        Dim oData = JsonConvert.DeserializeObject(Of CVoucherSub)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE ControlNo='{0}' And ItemNo={1}", oData.ControlNo, oData.ItemNo))
                    Case "CVoucherDoc"
                        Dim oData = JsonConvert.DeserializeObject(Of CVoucherDoc)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE ControlNo='{0}' And ItemNo={1}", oData.ControlNo, oData.ItemNo))
                    Case "CVoucher"
                        Dim oData As CVoucher = JsonConvert.DeserializeObject(Of CVoucher)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE ControlNo='{0}'", oData.ControlNo))
                    Case "CVender"
                        Dim oData As CVender = JsonConvert.DeserializeObject(Of CVender)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE VenCode='{0}'", oData.VenCode))
                    Case "CTransportHeader"
                        Dim oData As CTransportHeader = JsonConvert.DeserializeObject(Of CTransportHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE BookingNo='{0}'", oData.BookingNo))
                    Case "CTransportDetail"
                        Dim oData As CTransportDetail = JsonConvert.DeserializeObject(Of CTransportDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE BookingNo='{0}' AND ItemNo={1}", oData.BookingNo, oData.ItemNo))
                    Case "CPayHeader"
                        Dim oData As CPayHeader = JsonConvert.DeserializeObject(Of CPayHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE DocNo='{0}'", oData.DocNo))
                    Case "CPayDetail"
                        Dim oData As CPayDetail = JsonConvert.DeserializeObject(Of CPayDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE DocNo='{0}' AND ItemNo={1}", oData.DocNo, oData.ItemNo))
                    Case "CJobOrder"
                        Dim oData As CJobOrder = JsonConvert.DeserializeObject(Of CJobOrder)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE JNo='{0}'", oData.JNo))
                    Case "CJobOrderLog"
                        Dim oData As CJobOrderLog = JsonConvert.DeserializeObject(Of CJobOrderLog)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE JNo='{0}' AND ItemNo={1}", oData.JNo, oData.ItemNo))
                    Case "CInvHeader"
                        Dim oData As CInvHeader = JsonConvert.DeserializeObject(Of CInvHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE DocNo='{0}'", oData.DocNo))
                    Case "CInvDetail"
                        Dim oData As CInvDetail = JsonConvert.DeserializeObject(Of CInvDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE DocNo='{0}' AND ItemNo={1}", oData.DocNo, oData.ItemNo))
                    Case "CCompany"
                        Dim oData As CCompany = JsonConvert.DeserializeObject(Of CCompany)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE CustCode='{0}' AND Branch='{1}'", oData.CustCode, oData.Branch))
                    Case "CCNDNHeader"
                        Dim oData As CCNDNHeader = JsonConvert.DeserializeObject(Of CCNDNHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE DocNo='{0}'", oData.DocNo))

                    Case "CCNDNDetail"
                        Dim oData As CCNDNDetail = JsonConvert.DeserializeObject(Of CCNDNDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE DocNo='{0}' AND ItemNo={1}", oData.DocNo, oData.ItemNo))
                    Case "CClrHeader"
                        Dim oData As CClrHeader = JsonConvert.DeserializeObject(Of CClrHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE ClrNo='{0}' ", oData.ClrNo))
                    Case "CClrDetail"
                        Dim oData As CClrDetail = JsonConvert.DeserializeObject(Of CClrDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE ClrNo='{0}' AND ItemNo={1}", oData.ClrNo, oData.ItemNo))
                    Case "CBillHeader"
                        Dim oData As CBillHeader = JsonConvert.DeserializeObject(Of CBillHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE BillAcceptNo='{0}'", oData.BillAcceptNo))
                    Case "CBillDetail"
                        Dim oData As CBillDetail = JsonConvert.DeserializeObject(Of CBillDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE BillAcceptNo='{0}' AND ItemNo={1}", oData.BillAcceptNo, oData.ItemNo))
                    Case "CAdvHeader"
                        Dim oData As CAdvHeader = JsonConvert.DeserializeObject(Of CAdvHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE AdvNo='{0}'", oData.AdvNo))
                    Case "CAdvDetail"
                        Dim oData As CAdvDetail = JsonConvert.DeserializeObject(Of CAdvDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE AdvNo='{0}' AND ItemNo={1}", oData.AdvNo, oData.ItemNo))
                    Case "CRcpHeader"
                        Dim oData As CRcpHeader = JsonConvert.DeserializeObject(Of CRcpHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE ReceiptNo='{0}'", oData.ReceiptNo))
                    Case "CRcpDetail"
                        Dim oData As CRcpDetail = JsonConvert.DeserializeObject(Of CRcpDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE ReceiptNo='{0}' AND ItemNo={1}", oData.ReceiptNo, oData.ItemNo))
                    Case "CQuoHeader"
                        Dim oData As CQuoHeader = JsonConvert.DeserializeObject(Of CQuoHeader)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE QNo='{0}' ", oData.QNo))
                    Case "CQuoDetail"
                        Dim oData As CQuoDetail = JsonConvert.DeserializeObject(Of CQuoDetail)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE QNo='{0}' AND SeqNo={1}", oData.QNo, oData.SeqNo))
                    Case "CQuoItem"
                        Dim oData As CQuoItem = JsonConvert.DeserializeObject(Of CQuoItem)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE QNo='{0}' AND ItemNo={1} AND SeqNo={2}", oData.QNo, oData.ItemNo, oData.SeqNo))
                    Case "CUser"
                        Dim oData As CUser = JsonConvert.DeserializeObject(Of CUser)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE UserID='{0}'", oData.UserID))
                    Case "CUserAuth"
                        Dim oData As CUserAuth = JsonConvert.DeserializeObject(Of CUserAuth)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & oData.SaveData(String.Format(" WHERE UserID='{0}' AND MenuID='{1}' AND AppID='{2}'", oData.UserID, oData.MenuID, oData.AppID))
                    Case "CConfig"
                        Dim oData As CConfig = JsonConvert.DeserializeObject(Of CConfig)(jsonData)
                        oData.SetConnect(ViewBag.CONNECTION_JOB)
                        msg &= "<br>" & IIf(oData.SaveData() = True, "Save Complete", "Save Failed")
                End Select
                msg &= " LogID=" & r("LogID")
                i = i + 1
            Next
            Dim j As Integer = 0
            If docNo <> "" Then
                dt = obj.GetTableFromSQL(String.Format("SELECT * FROM weblicense.dbo.TWTLog WHERE [Message] Like '%{0}%'", docNo) & " AND LogDateTime>='" & dateFrom & "' AND LogDateTime<='" & dateTo & "' ")
                If dt.Rows.Count > 0 Then
                    For Each dr As Data.DataRow In dt.Rows
                        Dim sqlcmd As String = dr("Message").ToString()
                        obj.ExecuteSQL(sqlcmd)
                        j += 1
                    Next
                End If
            End If
            @<p>
                @i rows Process (@j sql executed)
            </p>

        Else
            @<p>
                Data Not Found
            </p>
        End If
        obj.ExecuteSQL("UPDATE Mas_Config SET ConfigValue='Y' WHERE ConfigKey='SAVE_LOG'")
    End If
End Code
<form action="" method="post">
    Date from <input type="text" name="dateFrom" value="@dateFrom" />
    <br>
    Date from <input type="text" name="dateTo" value="@dateTo" />
    <br />
    Module Name <input type="text" name="moduleName" value="@moduleName" />
    <br />
    DocNo <input type="text" name="docNo" value="" />
    <br />
    <input type="submit" name="submit" value="Submit" />
</form>
@If dt.Rows.Count > 0 And id > 0 Then
    @<p>
        @Html.Raw(msg)
    </p>
End If
<script type = "text/javascript" >
    var path = '@Url.Content("~")';
</script>