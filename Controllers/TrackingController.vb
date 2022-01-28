Imports System.Web.Mvc

Namespace Controllers
    Public Class TrackingController
        Inherits CController

        ' GET: Tracking
        Function Index() As ActionResult
            Return GetView("Index")
        End Function
        Function Document() As ActionResult
            Return GetView("Document")
        End Function
        Function Timeline() As ActionResult
            Return GetView("Timeline")
        End Function
        Function Dashboard() As ActionResult
            Return GetView("Dashboard")
        End Function
        Function Planing() As ActionResult
            Return GetView("Planing")
        End Function
        Function Planload() As ActionResult
            Dim sql As String = GetValueConfig("SQL", "SelectPlanload")
            Dim sqlW As String = " WHERE j.JobStatus<>99 "
            If Not IsNothing(Request.QueryString("Show")) Then
                Select Case Request.QueryString("Show")
                    Case "Cancel"
                        sqlW = " WHERE j.JobStatus>90 "
                    Case "Unclear"
                        sqlW = " WHERE j.JobStatus<4 "
                    Case "Unbill"
                        sqlW = " WHERE j.JobStatus<6 AND j.JobStatus>3 "
                    Case "Billed"
                        sqlW = " WHERE j.JobStatus>5 AND j.JobStatus<90 "
                End Select
            End If
            If Not IsNothing(Request.QueryString("Branch")) Then
                sqlW &= String.Format(" AND j.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
            End If
            If Not IsNothing(Request.QueryString("HBL")) Then
                sqlW &= String.Format(" AND j.HAWB='{0}' ", Request.QueryString("HBL").ToString)
            End If
            If Not IsNothing(Request.QueryString("MBL")) Then
                sqlW &= String.Format(" AND j.MAWB='{0}' ", Request.QueryString("MBL").ToString)
            End If
            If Not IsNothing(Request.QueryString("JobType")) Then
                sqlW &= String.Format(" AND j.JobType={0} ", Request.QueryString("JobType").ToString)
            End If
            If Not IsNothing(Request.QueryString("ShipBy")) Then
                sqlW &= String.Format(" AND j.ShipBy={0} ", Request.QueryString("ShipBy").ToString)
            End If
            If Not IsNothing(Request.QueryString("Agent")) Then
                sqlW &= String.Format(" AND j.ForwarderCode='{0}' ", Request.QueryString("Agent").ToString)
            End If
            If Not IsNothing(Request.QueryString("Transport")) Then
                sqlW &= String.Format(" AND j.AgentCode='{0}' ", Request.QueryString("Transport").ToString)
            End If
            Dim dateBy As String = "a.DutyDate"
            If Not IsNothing(Request.QueryString("DateBy")) Then
                dateBy = Request.QueryString("DateBy")
            End If
            If Not IsNothing(Request.QueryString("DateFrom")) Then
                sqlW &= " AND " & dateBy & ">='" & Request.QueryString("DateFrom") & " 00:00:00'"
            End If
            If Not IsNothing(Request.QueryString("DateTo")) Then
                sqlW &= " AND " & dateBy & "<='" & Request.QueryString("DateTo") & " 23:59:00'"
            End If
            If Not IsNothing(Request.QueryString("Status")) Then
                sqlW &= String.Format(" AND j.JobStatus={0} ", Request.QueryString("Status").ToString)
            End If
            If Not IsNothing(Request.QueryString("Cust")) Then
                sqlW &= String.Format(" AND j.CustCode='{0}' ", Request.QueryString("Cust").ToString)
            End If
            If Not IsNothing(Request.QueryString("Cons")) Then
                sqlW &= String.Format(" AND j.consigneecode='{0}' ", Request.QueryString("Cons").ToString)
            End If
            If Not IsNothing(Request.QueryString("Shipping")) Then
                sqlW &= String.Format(" AND j.ShippingEmp='{0}' ", Request.QueryString("Shipping").ToString)
            End If
            If Not IsNothing(Request.QueryString("CS")) Then
                sqlW &= String.Format(" AND j.CSCode='{0}' ", Request.QueryString("CS").ToString)
            End If
            sql = sql.Replace("{0}", sqlW)
            Dim dt = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
            ViewBag.DataTable = dt
            Return GetView("Planload")
        End Function
        Function PublicIndex() As ActionResult
            Return View()
        End Function
        Function UploadDocument() As ActionResult
            Dim msg As String = ""
            Dim exts As String = "*.jpg,*.jpeg,*.pdf,*.png"

            Try
                Dim saveTo = ""
                Dim branch = Request.QueryString("Branch").ToString
                Dim job = Request.QueryString("Code").ToString
                Dim typ = Request.QueryString("Type").ToString
                If Not IsNothing(Request.QueryString("Path")) Then
                    saveTo = Request.QueryString("Path").ToString
                End If
                For Each fileIdx As String In Request.Files
                    Dim File As HttpPostedFileBase = Request.Files.Item(fileIdx)
                    Dim filename = System.IO.Path.GetFileName(File.FileName)
                    If File.ContentLength > 0 Then
                        If exts.IndexOf(System.IO.Path.GetExtension(filename).ToLower) >= 0 Then
                            Try
                                Dim saveFolder = Server.MapPath("~/" + saveTo + "/" + job + "_" + typ)
                                If System.IO.Directory.Exists(saveFolder) = False Then
                                    System.IO.Directory.CreateDirectory(saveFolder)
                                End If
                                Dim path = System.IO.Path.Combine(saveFolder, filename)
                                File.SaveAs(path)

                                Dim oFile As New CDocument(GetSession("ConnJob")) With {
                                    .BranchCode = branch,
                                    .JNo = job,
                                    .ItemNo = 0,
                                    .DocType = typ,
                                    .FileType = System.IO.Path.GetExtension(filename).ToLower,
                                    .FilePath = saveTo + "/" + job + "_" + typ + "/" + filename,
                                    .DocNo = filename,
                                    .Description = saveFolder + "/" + filename,
                                    .DocDate = DateTime.MinValue,
                                    .FileSize = File.ContentLength,
                                    .UploadBy = GetSession("CurrUser"),
                                    .UploadDate = DateTime.Now,
                                    .CheckedBy = "",
                                    .CheckedDate = DateTime.MinValue,
                                    .ApproveBy = ""
                                }
                                oFile.CheckedDate = DateTime.MinValue
                                oFile.CheckNote = ""
                                oFile.SaveData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}' AND ItemNo={2}", branch, job, oFile.ItemNo))
                                msg = msg + "Upload " + filename + " successfully" + vbCrLf
                            Catch ex As Exception
                                msg = msg + "[Error] " + filename + "=>" + ex.Message + vbCrLf
                            End Try
                        Else
                            msg = msg + "[Error] " + filename + " Is Not allowed To upload" + vbCrLf
                        End If
                    Else
                        msg = msg + "[Error] " + filename + " cannot upload" + vbCrLf
                    End If
                Next
            Catch e As Exception
                msg = "[Error]" + e.Message
            End Try
            If msg = "" Then msg = "[Error] No File To Upload"
            Return Content(msg, textContent)
        End Function
    End Class
End Namespace