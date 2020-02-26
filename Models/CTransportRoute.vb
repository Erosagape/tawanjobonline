'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CTransportRoute
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_LocationID As Integer
    Public Property LocationID As Integer
        Get
            Return m_LocationID
        End Get
        Set(value As Integer)
            m_LocationID = value
        End Set
    End Property
    Private m_Place1 As String
    Public Property Place1 As String
        Get
            Return m_Place1
        End Get
        Set(value As String)
            m_Place1 = value
        End Set
    End Property
    Private m_Place2 As String
    Public Property Place2 As String
        Get
            Return m_Place2
        End Get
        Set(value As String)
            m_Place2 = value
        End Set
    End Property
    Private m_Place3 As String
    Public Property Place3 As String
        Get
            Return m_Place3
        End Get
        Set(value As String)
            m_Place3 = value
        End Set
    End Property
    Private m_Place4 As String
    Public Property Place4 As String
        Get
            Return m_Place4
        End Get
        Set(value As String)
            m_Place4 = value
        End Set
    End Property
    Private m_Address1 As String
    Public Property Address1 As String
        Get
            Return m_Address1
        End Get
        Set(value As String)
            m_Address1 = value
        End Set
    End Property
    Private m_Address2 As String
    Public Property Address2 As String
        Get
            Return m_Address2
        End Get
        Set(value As String)
            m_Address2 = value
        End Set
    End Property
    Private m_Address3 As String
    Public Property Address3 As String
        Get
            Return m_Address3
        End Get
        Set(value As String)
            m_Address3 = value
        End Set
    End Property
    Private m_Address4 As String
    Public Property Address4 As String
        Get
            Return m_Address4
        End Get
        Set(value As String)
            m_Address4 = value
        End Set
    End Property
    Private m_Contact1 As String
    Public Property Contact1 As String
        Get
            Return m_Contact1
        End Get
        Set(value As String)
            m_Contact1 = value
        End Set
    End Property
    Private m_Contact2 As String
    Public Property Contact2 As String
        Get
            Return m_Contact2
        End Get
        Set(value As String)
            m_Contact2 = value
        End Set
    End Property
    Private m_Contact3 As String
    Public Property Contact3 As String
        Get
            Return m_Contact3
        End Get
        Set(value As String)
            m_Contact3 = value
        End Set
    End Property
    Private m_Contact4 As String
    Public Property Contact4 As String
        Get
            Return m_Contact4
        End Get
        Set(value As String)
            m_Contact4 = value
        End Set
    End Property
    Private m_LocationRoute As String
    Public Property LocationRoute As String
        Get
            Return m_LocationRoute
        End Get
        Set(value As String)
            m_LocationRoute = value
        End Set
    End Property
    Private m_RouteFormat As String
    Public Property RouteFormat As String
        Get
            Return m_RouteFormat
        End Get
        Set(value As String)
            m_RouteFormat = value
        End Set
    End Property
    Private m_IsActive As Boolean
    Public Property IsActive As Boolean
        Get
            Return m_IsActive
        End Get
        Set(value As Boolean)
            m_IsActive = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_TransportRoute" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            'dr("LocationID") = Me.LocationID
                            dr("Place1") = Main.GetDBString(Me.Place1, dt.Columns("Place1"))
                            dr("Place2") = Main.GetDBString(Me.Place2, dt.Columns("Place2"))
                            dr("Place3") = Main.GetDBString(Me.Place3, dt.Columns("Place3"))
                            dr("Place4") = Main.GetDBString(Me.Place4, dt.Columns("Place4"))
                            dr("LocationRoute") = Main.GetDBString(Me.LocationRoute, dt.Columns("LocationRoute"))
                            dr("IsActive") = Me.IsActive
                            dr("Address1") = Main.GetDBString(Me.Address1, dt.Columns("Address1"))
                            dr("Contact1") = Main.GetDBString(Me.Contact1, dt.Columns("Contact1"))
                            dr("Address2") = Main.GetDBString(Me.Address2, dt.Columns("Address2"))
                            dr("Contact2") = Main.GetDBString(Me.Contact2, dt.Columns("Contact2"))
                            dr("Address3") = Main.GetDBString(Me.Address3, dt.Columns("Address3"))
                            dr("Contact3") = Main.GetDBString(Me.Contact3, dt.Columns("Contact3"))
                            dr("Address4") = Main.GetDBString(Me.Address4, dt.Columns("Address4"))
                            dr("Contact4") = Main.GetDBString(Me.Contact4, dt.Columns("Contact4"))
                            dr("RouteFormat") = Main.GetDBString(Me.RouteFormat, dt.Columns("RouteFormat"))
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportRoute", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                msg = "[ERROR]" & ex.Message
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportRoute", "SaveData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()

        m_LocationID = 0
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CTransportRoute)
        Dim lst As New List(Of CTransportRoute)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CTransportRoute
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_TransportRoute" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CTransportRoute(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LocationID"))) = False Then
                        row.LocationID = rd.GetValue(rd.GetOrdinal("LocationID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Place1"))) = False Then
                        row.Place1 = rd.GetString(rd.GetOrdinal("Place1")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Place2"))) = False Then
                        row.Place2 = rd.GetString(rd.GetOrdinal("Place2")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Place3"))) = False Then
                        row.Place3 = rd.GetString(rd.GetOrdinal("Place3")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Place4"))) = False Then
                        row.Place4 = rd.GetString(rd.GetOrdinal("Place4")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address1"))) = False Then
                        row.Address1 = rd.GetString(rd.GetOrdinal("Address1")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address2"))) = False Then
                        row.Address2 = rd.GetString(rd.GetOrdinal("Address2")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address3"))) = False Then
                        row.Address3 = rd.GetString(rd.GetOrdinal("Address3")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address4"))) = False Then
                        row.Address4 = rd.GetString(rd.GetOrdinal("Address4")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Contact1"))) = False Then
                        row.Contact1 = rd.GetString(rd.GetOrdinal("Contact1")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Contact2"))) = False Then
                        row.Contact2 = rd.GetString(rd.GetOrdinal("Contact2")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Contact3"))) = False Then
                        row.Contact3 = rd.GetString(rd.GetOrdinal("Contact3")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Contact4"))) = False Then
                        row.Contact4 = rd.GetString(rd.GetOrdinal("Contact4")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LocationRoute"))) = False Then
                        row.LocationRoute = rd.GetString(rd.GetOrdinal("LocationRoute")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("RouteFormat"))) = False Then
                        row.RouteFormat = rd.GetString(rd.GetOrdinal("RouteFormat")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("IsActive"))) = False Then
                        row.IsActive = rd.GetBoolean(rd.GetOrdinal("IsActive")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportRoute", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("UPDATE Job_TransportRoute SET IsActive=0 " + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportRoute", "DeleteData", cm.CommandText, False)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                msg = ex.Message
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportRoute", "DeleteData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return msg
    End Function
End Class