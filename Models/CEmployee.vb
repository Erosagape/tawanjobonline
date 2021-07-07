
Imports System.Data.SqlClient
Public Class Employee
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_Eid As String
    Public Property Eid As String
        Get
            Return m_Eid
        End Get
        Set(value As String)
            m_Eid = value
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
    Private m_PreName As String
    Public Property PreName As String
        Get
            Return m_PreName
        End Get
        Set(value As String)
            m_PreName = value
        End Set
    End Property
    Private m_Name As String
    Public Property Name As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_NickName As String
    Public Property NickName As String
        Get
            Return m_NickName
        End Get
        Set(value As String)
            m_NickName = value
        End Set
    End Property
    Private m_AccountNumber As String
    Public Property AccountNumber As String
        Get
            Return m_AccountNumber
        End Get
        Set(value As String)
            m_AccountNumber = value
        End Set
    End Property
    Private m_Branch As String
    Public Property Branch As String
        Get
            Return m_Branch
        End Get
        Set(value As String)
            m_Branch = value
        End Set
    End Property
    Private m_Address As String
    Public Property Address As String
        Get
            Return m_Address
        End Get
        Set(value As String)
            m_Address = value
        End Set
    End Property
    Private m_Tel As String
    Public Property Tel As String
        Get
            Return m_Tel
        End Get
        Set(value As String)
            m_Tel = value
        End Set
    End Property
    Private m_Remark As String
    Public Property Remark As String
        Get
            Return m_Remark
        End Get
        Set(value As String)
            m_Remark = value
        End Set
    End Property
    Private m_Email As String
    Public Property Email As String
        Get
            Return m_Email
        End Get
        Set(value As String)
            m_Email = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Mas_Employee" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("EmpCode") = Me.EmpCode
                            dr("PreName") = Me.PreName
                            dr("Name") = Me.Name
                            dr("NickName") = Me.NickName
                            dr("AccountNumber") = Me.AccountNumber
                            dr("Branch") = Me.Branch
                            dr("Address") = Me.Address
                            dr("Tel") = Me.Tel
                            dr("Remark") = Me.Remark
                            dr("Email") = Me.Email
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

        m_Eid = ""
        m_EmpCode = ""
        m_PreName = ""
        m_Name = ""
        m_NickName = ""
        m_AccountNumber = ""
        m_Branch = ""
        m_Address = ""
        m_Tel = ""
        m_Remark = ""
        m_Email = ""
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of Employee)
        Dim lst As New List(Of Employee)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As Employee
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Mas_Employee" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New Employee(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Eid"))) = False Then
                        row.Eid = rd.GetValue(rd.GetOrdinal("Eid")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("EmpCode"))) = False Then
                        row.EmpCode = rd.GetString(rd.GetOrdinal("EmpCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PreName"))) = False Then
                        row.PreName = rd.GetString(rd.GetOrdinal("PreName")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Name"))) = False Then
                        row.Name = rd.GetString(rd.GetOrdinal("Name")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("NickName"))) = False Then
                        row.NickName = rd.GetString(rd.GetOrdinal("NickName")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AccountNumber"))) = False Then
                        row.AccountNumber = rd.GetString(rd.GetOrdinal("AccountNumber")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Branch"))) = False Then
                        row.Branch = rd.GetString(rd.GetOrdinal("Branch")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address"))) = False Then
                        row.Address = rd.GetString(rd.GetOrdinal("Address")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Tel"))) = False Then
                        row.Tel = rd.GetString(rd.GetOrdinal("Tel")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Remark"))) = False Then
                        row.Remark = rd.GetString(rd.GetOrdinal("Remark")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Email"))) = False Then
                        row.Email = rd.GetString(rd.GetOrdinal("Email")).ToString()
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

                Using cm As New SqlCommand("DELETE FROM Mas_Employee" + pSQLWhere, cn)
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