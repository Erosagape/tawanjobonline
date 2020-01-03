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

                                Dim oFile As New CDocument(jobWebConn)
                                oFile.BranchCode = branch
                                oFile.JNo = job
                                oFile.ItemNo = 0
                                oFile.DocType = typ
                                oFile.FileType = System.IO.Path.GetExtension(filename).ToLower
                                oFile.FilePath = saveTo + "/" + job + "_" + typ
                                oFile.DocNo = filename
                                oFile.Description = saveFolder + "/" + filename
                                oFile.DocDate = DateTime.MinValue
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