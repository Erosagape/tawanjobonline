Imports System.Web.Mvc

Namespace Controllers
    Public Class AdminController
        Inherits CController

        ' GET: Admin
        Function Index() As ActionResult
            Return View()
        End Function
        Function TestBilling() As ActionResult
            ViewBag.TableHTML = "
<ul id=""myUL"">
  <li><span class=""box"">Beverages</span>
    <ul class=""nested"">
      <li>Water</li>
      <li>Coffee</li>
      <li><span class=""box"">Tea</span>
        <ul class=""nested"">
          <li>Black Tea</li>
          <li>White Tea</li>
          <li><span class=""box"">Green Tea</span>
            <ul class=""nested"">
              <li>Sencha</li>
              <li>Gyokuro</li>
              <li>Matcha</li>
              <li>Pi Lo Chun</li>
            </ul>
          </li>
        </ul>
      </li>
    </ul>
  </li>
</ul>
"
            Return View()
        End Function
        Function Billing() As ActionResult
            Dim yyyy As String = ""
            If Not Request.QueryString("Year") Is Nothing Then
                yyyy = Request.QueryString("Year")
            Else
                yyyy = DateTime.Now.AddMonths(-1).Year.ToString()
            End If
            Dim mm As String = ""
            If Not Request.QueryString("Month") Is Nothing Then
                mm = Request.QueryString("Month")
            Else
                mm = DateTime.Now.AddMonths(-1).Month.ToString()
            End If
            Dim sqlC = ""
            If Not Request.QueryString("Cust") Is Nothing Then
                sqlC = String.Format(" WHERE CustID='{0}'", Request.QueryString("Cust"))
            End If

            Dim html = ""
            Try
                Dim oSource = New CUtil(My.Settings.weblicenseConnection).GetTableFromSQL("SELECT * FROM TWTCustomerApp " & sqlC)
                If oSource.Rows.Count > 0 Then
                    html &= "<ul id=""myUL"">"
                    For Each dr In oSource.Rows
                        html &= "<li><span class=""box"">" & dr("CustID").ToString() & "/" & dr("WebTranDB").ToString() & "</span>"
                        Dim oConnStr = dr("WebTranConnect").ToString()
                        Dim htmlJobList As String = ""
                        Try
                            Using oConn As New SqlClient.SqlConnection(oConnStr)
                                oConn.Open()
                                If oConn.State = ConnectionState.Open Then
                                    Dim lastPeriod = ""
                                    Dim tsqlW = ""
                                    If yyyy <> "" Then
                                        tsqlW = String.Format("Year(CreateDate)={0}", yyyy)
                                    End If
                                    If mm <> "" Then
                                        tsqlW &= IIf(tsqlW <> "", " AND ", "") & String.Format("Month(CreateDate)={0}", mm)
                                    End If
                                    If tsqlW <> "" Then
                                        tsqlW = "WHERE " & tsqlW
                                    End If
                                    Using oTbJob = New SqlClient.SqlCommand("SELECT * FROM Job_Order " & tsqlW & " ORDER BY CreateDate", oConn).ExecuteReader()
                                        While oTbJob.Read
                                            Dim period = (Convert.ToDateTime(oTbJob("CreateDate")).Year & "/" & Convert.ToDateTime(oTbJob("CreateDate")).Month.ToString("00"))
                                            If lastPeriod <> period Then
                                                If lastPeriod <> "" Then
                                                    htmlJobList &= "</ul></li></ul>"
                                                End If
                                                lastPeriod = period
                                                htmlJobList &= "<ul class=""nested"">"
                                                htmlJobList &= "<li><span class=""box"">" & period & "</span>"
                                                htmlJobList &= "<ul class=""nested"">"
                                            End If
                                            htmlJobList &= "<li>" & oTbJob("JNo").ToString() & "</li>"
                                        End While
                                        If lastPeriod <> "" Then
                                            htmlJobList &= "</ul></li></ul>"
                                        End If
                                    End Using
                                End If
                            End Using
                        Catch ex As Exception
                            htmlJobList &= "#Error : " & ex.Message
                        End Try
                        html &= htmlJobList & "</li>"
                    Next
                    html &= "</ul>"
                End If

            Catch ex As Exception
                html = ex.Message
            End Try
            ViewBag.TableHTML = html
            Return GetView("Billing")
        End Function
    End Class
End Namespace