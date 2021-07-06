'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CarLicense
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_CLid As String
    Public Property CLid As String
        Get
            Return m_CLid
        End Get
        Set(value As String)
            m_CLid = value
        End Set
    End Property
    Private m_CarNo As String
    Public Property CarNo As String
        Get
            Return m_CarNo
        End Get
        Set(value As String)
            m_CarNo = value
        End Set
    End Property
    Private m_CarLicense As String
    Public Property CarLicense As String
        Get
            Return m_CarLicense
        End Get
        Set(value As String)
            m_CarLicense = value
        End Set
    End Property
    Private m_EmpCode As String
    Public Property EmpCode As String
        Get
            Return m_EmpCode
        End Get
        Set(value As String)
            m_EmpCode = value
        End Set
    End Property
    Private m_DateStart As Date
    Public Property DateStart As Date
        Get
            Return m_DateStart
        End Get
        Set(value As Date)
            m_DateStart = value
        End Set
    End Property
    Private m_CarBrand As String
    Public Property CarBrand As String
        Get
            Return m_CarBrand
        End Get
        Set(value As String)
            m_CarBrand = value
        End Set
    End Property
    Private m_ModelYear As String
    Public Property ModelYear As String
        Get
            Return m_ModelYear
        End Get
        Set(value As String)
            m_ModelYear = value
        End Set
    End Property
    Private m_CarModel As String
    Public Property CarModel As String
        Get
            Return m_CarModel
        End Get
        Set(value As String)
            m_CarModel = value
        End Set
    End Property
    Private m_CarType As String
    Public Property CarType As String
        Get
            Return m_CarType
        End Get
        Set(value As String)
            m_CarType = value
        End Set
    End Property
    Private m_CarPic As String
    Public Property CarPic As String
        Get
            Return m_CarPic
        End Get
        Set(value As String)
            m_CarPic = value
        End Set
    End Property
    Private m_Status As String
    Public Property Status As String
        Get
            Return m_Status
        End Get
        Set(value As String)
            m_Status = value
        End Set
    End Property
    Private m_Weight As Double
    Public Property Weight As Double
        Get
            Return m_Weight
        End Get
        Set(value As Double)
            m_Weight = value
        End Set
    End Property

    Friend Function GetDBDate(pDate As Date, Optional pTodayAsDefault As Boolean = False) As Object
        If pDate.Year > 2000 Then
            If pDate.Year > 2500 Then
                Return pDate.AddYears(-543)
            Else
                If pDate.Year > 2200 Then
                    Return Date.MinValue
                End If
            End If
            Return pDate
        Else
            If pTodayAsDefault Then
                Return DateTime.Today
            Else
                If pDate.Year > 2500 Then
                    Return pDate.AddYears(-543)
                Else
                    Return System.DBNull.Value
                End If
            End If
        End If
    End Function

    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()
                Using da As New SqlDataAdapter("SELECT * FROM Mas_CarLicense" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            'dr("CLid") = Me.CLid
                            dr("CarNo") = Me.CarNo
                            dr("CarLicense") = Me.CarLicense
                            dr("EmpCode") = Me.EmpCode
                            dr("DateStart") = GetDBDate(Me.DateStart)
                            dr("CarBrand") = Me.CarBrand
                            dr("ModelYear") = Me.ModelYear
                            dr("CarModel") = Me.CarModel
                            dr("CarType") = Me.CarType
                            dr("CarPic") = Me.CarPic
                            dr("Status") = Me.Status
                            dr("Weight") = Me.Weight
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

        m_CLid = ""
        m_CarNo = ""
        m_CarLicense = ""
        m_EmpCode = ""
        m_DateStart = DateTime.MinValue
        m_CarBrand = ""
        m_ModelYear = ""
        m_CarModel = ""
        m_CarType = ""
        m_CarPic = ""
        m_Status = ""
        m_Weight = 0
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CarLicense)
        Dim lst As New List(Of CarLicense)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CarLicense
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Mas_CarLicense" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CarLicense(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CLid"))) = False Then
                        row.CLid = rd.GetInt32(rd.GetOrdinal("CLid")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CarNo"))) = False Then
                        row.CarNo = rd.GetString(rd.GetOrdinal("CarNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CarLicense"))) = False Then
                        row.CarLicense = rd.GetString(rd.GetOrdinal("CarLicense")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("EmpCode"))) = False Then
                        row.EmpCode = rd.GetString(rd.GetOrdinal("EmpCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DateStart"))) = False Then
                        row.DateStart = rd.GetDateTime(rd.GetOrdinal("DateStart"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CarBrand"))) = False Then
                        row.CarBrand = rd.GetString(rd.GetOrdinal("CarBrand")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ModelYear"))) = False Then
                        row.ModelYear = rd.GetString(rd.GetOrdinal("ModelYear")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CarModel"))) = False Then
                        row.CarModel = rd.GetString(rd.GetOrdinal("CarModel")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CarType"))) = False Then
                        row.CarType = rd.GetString(rd.GetOrdinal("CarType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CarPic"))) = False Then
                        row.CarPic = rd.GetString(rd.GetOrdinal("CarPic")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Status"))) = False Then
                        row.Status = rd.GetString(rd.GetOrdinal("Status")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Weight"))) = False Then
                        row.Weight = rd.GetDouble(rd.GetOrdinal("Weight"))
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
                Using cm As New SqlCommand("DELETE FROM Mas_CarLicense" + pSQLWhere, cn)
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

    Public Function GetLicenseList() As List(Of String)
        Dim lst As New List(Of String)
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT [CarNo] FROM Mas_CarLicense", cn).ExecuteReader()
                While rd.Read()
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CarNo"))) = False Then
                        lst.Add(rd.GetString(rd.GetOrdinal("CarNo")).ToString())
                    End If
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class