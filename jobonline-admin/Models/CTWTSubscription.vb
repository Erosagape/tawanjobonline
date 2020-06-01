Imports System.Data.SqlClient
Public Class TWTSubscription
    Private m_ConnStr As String
    Public Property SubScriptionID As Integer
    Public Property SubscriptionName As String
    Public Property SubscriptionDesc As String
    Public Property AppID As String
    Public Property Edition As Integer
    Public Property BeginDate As Date
    Public Property ExpireDate As Date
    Public Property LoginCount As Integer
    Public Sub New()

    End Sub
    Public Sub New(pConn As String)
        m_ConnStr = pConn
    End Sub
    Public Sub SetConnect(pConn As String)
        m_ConnStr = pConn
    End Sub
    Public Function SaveData() As Boolean
        Try
            Using cn As SqlConnection = New SqlConnection(m_ConnStr)
                cn.Open()
                Using da As New SqlDataAdapter(String.Format("SELECT * FROM TWTSubscription WHERE SubScriptionID={0}", Me.SubScriptionID), cn)
                    Using cm As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)

                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then
                                dr = dt.Rows(0)
                            End If
                            If Me.SubScriptionID = 0 Then
                                Me.SubScriptionID = (From tb In New TWTSubscription(My.Settings.weblicenseConnection).GetData("")
                                                     Select tb.SubScriptionID).Max + 1
                            End If
                            dr("SubScriptionID") = Me.SubScriptionID
                            dr("SubscriptionName") = Me.SubscriptionName
                            dr("SubscriptionDesc") = Me.SubscriptionDesc
                            dr("AppID") = Me.AppID
                            dr("Edition") = Me.Edition
                            dr("BeginDate") = Main.GetDBDate(Me.BeginDate)
                            dr("ExpireDate") = Main.GetDBDate(Me.ExpireDate)
                            dr("LoginCount") = Me.LoginCount

                            If dr.RowState = DataRowState.Detached Then
                                dt.Rows.Add(dr)
                            End If
                            da.Update(dt)

                            Return True
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GetData(sqlWhere As String) As List(Of TWTSubscription)
        Dim lst As New List(Of TWTSubscription)
        Try
            Using cn As SqlConnection = New SqlConnection(m_ConnStr)
                cn.Open()
                Using rd As SqlDataReader = New SqlCommand("SELECT * FROM TWTSubscription " & sqlWhere, cn).ExecuteReader
                    While rd.Read
                        lst.Add(New TWTSubscription With {
                            .SubScriptionID = rd("SubScriptionID"),
                            .SubscriptionName = rd("SubscriptionName").ToString,
                            .SubscriptionDesc = rd("SubscriptionDesc").ToString,
                            .AppID = rd("AppID").ToString,
                            .Edition = rd("Edition"),
                            .BeginDate = rd("BeginDate"),
                            .ExpireDate = rd("ExpireDate"),
                            .LoginCount = rd("LoginCount")
                        })
                    End While
                    rd.Close()
                End Using
                cn.Close()
            End Using
        Catch ex As Exception

        End Try
        Return lst
    End Function
End Class
