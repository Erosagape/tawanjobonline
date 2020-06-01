'-----Class Definition-----
Imports System.Data.SqlClient
Public Class TWTCustomerApp
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_AppID As String
    Public Property AppID As String
        Get
            Return m_AppID
        End Get
        Set(value As String)
            m_AppID = value
        End Set
    End Property
    Private m_CustID As String
    Public Property CustID As String
        Get
            Return m_CustID
        End Get
        Set(value As String)
            m_CustID = value
        End Set
    End Property
    Private m_WebURL As String
    Public Property WebURL As String
        Get
            Return m_WebURL
        End Get
        Set(value As String)
            m_WebURL = value
        End Set
    End Property
    Private m_WebDBType As Integer
    Public Property WebDBType As Integer
        Get
            Return m_WebDBType
        End Get
        Set(value As Integer)
            m_WebDBType = value
        End Set
    End Property
    Private m_WebTranDB As String
    Public Property WebTranDB As String
        Get
            Return m_WebTranDB
        End Get
        Set(value As String)
            m_WebTranDB = value
        End Set
    End Property
    Private m_WebMasDB As String
    Public Property WebMasDB As String
        Get
            Return m_WebMasDB
        End Get
        Set(value As String)
            m_WebMasDB = value
        End Set
    End Property
    Private m_WebTranConnect As String
    Public Property WebTranConnect As String
        Get
            Return m_WebTranConnect
        End Get
        Set(value As String)
            m_WebTranConnect = value
        End Set
    End Property
    Private m_WebMasConnect As String
    Public Property WebMasConnect As String
        Get
            Return m_WebMasConnect
        End Get
        Set(value As String)
            m_WebMasConnect = value
        End Set
    End Property
    Private m_Active As Boolean
    Public Property Active As Boolean
        Get
            Return m_Active
        End Get
        Set(value As Boolean)
            m_Active = value
        End Set
    End Property
    Private m_SubscriptionID As Integer
    Public Property SubscriptionID As Integer
        Get
            Return m_SubscriptionID
        End Get
        Set(value As Integer)
            m_SubscriptionID = value
        End Set
    End Property
    Private m_Seq As Integer
    Public Property Seq As Integer
        Get
            Return m_Seq
        End Get
        Set(value As Integer)
            m_Seq = value
        End Set
    End Property
    Private m_DefaultLang As String
    Public Property DefaultLang As String
        Get
            Return m_DefaultLang
        End Get
        Set(value As String)
            m_DefaultLang = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM TWTCustomerApp" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("AppID") = Me.AppID
                            dr("CustID") = Me.CustID
                            dr("WebURL") = Me.WebURL
                            dr("WebDBType") = Me.WebDBType
                            dr("WebTranDB") = Me.WebTranDB
                            dr("WebMasDB") = Me.WebMasDB
                            dr("WebTranConnect") = Me.WebTranConnect
                            dr("WebMasConnect") = Me.WebMasConnect
                            dr("Active") = Me.Active
                            dr("SubscriptionID") = Me.SubscriptionID
                            dr("Seq") = Me.Seq
                            dr("DefaultLang") = Me.DefaultLang
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()

        m_AppID = ""
        m_CustID = ""
        m_WebURL = ""
        m_WebDBType = ""
        m_WebTranDB = ""
        m_WebMasDB = ""
        m_WebTranConnect = ""
        m_WebMasConnect = ""
        m_Active = ""
        m_SubscriptionID = ""
        m_Seq = ""
        m_DefaultLang = ""
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of TWTCustomerApp)
        Dim lst As New List(Of TWTCustomerApp)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As TWTCustomerApp
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM TWTCustomerApp" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New TWTCustomerApp(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AppID"))) = False Then
                        row.AppID = rd.GetString(rd.GetOrdinal("AppID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CustID"))) = False Then
                        row.CustID = rd.GetString(rd.GetOrdinal("CustID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("WebURL"))) = False Then
                        row.WebURL = rd.GetString(rd.GetOrdinal("WebURL")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("WebDBType"))) = False Then
                        row.WebDBType = rd.GetInt32(rd.GetOrdinal("WebDBType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("WebTranDB"))) = False Then
                        row.WebTranDB = rd.GetString(rd.GetOrdinal("WebTranDB")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("WebMasDB"))) = False Then
                        row.WebMasDB = rd.GetString(rd.GetOrdinal("WebMasDB")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("WebTranConnect"))) = False Then
                        row.WebTranConnect = rd.GetString(rd.GetOrdinal("WebTranConnect")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("WebMasConnect"))) = False Then
                        row.WebMasConnect = rd.GetString(rd.GetOrdinal("WebMasConnect")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Active"))) = False Then
                        row.Active = rd.GetValue(rd.GetOrdinal("Active")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SubscriptionID"))) = False Then
                        row.SubscriptionID = rd.GetInt32(rd.GetOrdinal("SubscriptionID")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Seq"))) = False Then
                        row.Seq = rd.GetInt32(rd.GetOrdinal("Seq")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DefaultLang"))) = False Then
                        row.DefaultLang = rd.GetString(rd.GetOrdinal("DefaultLang")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM TWTCustomerApp" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class