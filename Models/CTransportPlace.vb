'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CTransportPlace
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_PlaceType As Integer
    Public Property PlaceType As Integer
        Get
            Return m_PlaceType
        End Get
        Set(value As Integer)
            m_PlaceType = value
        End Set
    End Property
    Private m_PlaceName As String
    Public Property PlaceName As String
        Get
            Return m_PlaceName
        End Get
        Set(value As String)
            m_PlaceName = value
        End Set
    End Property
    Private m_PlaceAddress As String
    Public Property PlaceAddress As String
        Get
            Return m_PlaceAddress
        End Get
        Set(value As String)
            m_PlaceAddress = value
        End Set
    End Property
    Private m_PlaceContact As String
    Public Property PlaceContact As String
        Get
            Return m_PlaceContact
        End Get
        Set(value As String)
            m_PlaceContact = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_TransportPlace" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("PlaceType") = Me.PlaceType
                            dr("PlaceName") = Me.PlaceName
                            dr("PlaceAddress") = Me.PlaceAddress
                            dr("PlaceContact") = Me.PlaceContact
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

        m_PlaceType = 0
        m_PlaceName = ""
        m_PlaceAddress = ""
        m_PlaceContact = ""
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CTransportPlace)
        Dim lst As New List(Of CTransportPlace)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CTransportPlace
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_TransportPlace" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CTransportPlace(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceType"))) = False Then
                        row.PlaceType = rd.GetInt32(rd.GetOrdinal("PlaceType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceName"))) = False Then
                        row.PlaceName = rd.GetString(rd.GetOrdinal("PlaceName")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceAddress"))) = False Then
                        row.PlaceAddress = rd.GetString(rd.GetOrdinal("PlaceAddress")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceContact"))) = False Then
                        row.PlaceContact = rd.GetString(rd.GetOrdinal("PlaceContact")).ToString()
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

                Using cm As New SqlCommand("DELETE FROM Job_TransportPlace" + pSQLWhere, cn)
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