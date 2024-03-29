﻿Imports System.Data.SqlClient
Public Class CDocument
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_BranchCode As String
    Public Property BranchCode As String
        Get
            Return m_BranchCode
        End Get
        Set(value As String)
            m_BranchCode = value
        End Set
    End Property
    Private m_JNo As String
    Public Property JNo As String
        Get
            Return m_JNo
        End Get
        Set(value As String)
            m_JNo = value
        End Set
    End Property
    Private m_ItemNo As Integer
    Public Property ItemNo As Integer
        Get
            Return m_ItemNo
        End Get
        Set(value As Integer)
            m_ItemNo = value
        End Set
    End Property
    Private m_DocType As String
    Public Property DocType As String
        Get
            Return m_DocType
        End Get
        Set(value As String)
            m_DocType = value
        End Set
    End Property
    Private m_DocDate As Date
    Public Property DocDate As Date
        Get
            Return m_DocDate
        End Get
        Set(value As Date)
            m_DocDate = value
        End Set
    End Property
    Private m_DocNo As String
    Public Property DocNo As String
        Get
            Return m_DocNo
        End Get
        Set(value As String)
            m_DocNo = value
        End Set
    End Property
    Private m_Description As String
    Public Property Description As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = value
        End Set
    End Property
    Private m_FileType As String
    Public Property FileType As String
        Get
            Return m_FileType
        End Get
        Set(value As String)
            m_FileType = value
        End Set
    End Property
    Private m_FilePath As String
    Public Property FilePath As String
        Get
            Return m_FilePath
        End Get
        Set(value As String)
            m_FilePath = value
        End Set
    End Property
    Private m_FileSize As Double
    Public Property FileSize As Double
        Get
            Return m_FileSize
        End Get
        Set(value As Double)
            m_FileSize = value
        End Set
    End Property
    Private m_UploadBy As String
    Public Property UploadBy As String
        Get
            Return m_UploadBy
        End Get
        Set(value As String)
            m_UploadBy = value
        End Set
    End Property
    Private m_UploadDate As DateTime
    Public Property UploadDate As DateTime
        Get
            Return m_UploadDate
        End Get
        Set(value As DateTime)
            m_UploadDate = value
        End Set
    End Property
    Private m_CheckedBy As String
    Public Property CheckedBy As String
        Get
            Return m_CheckedBy
        End Get
        Set(value As String)
            m_CheckedBy = value
        End Set
    End Property
    Private m_CheckedDate As DateTime
    Public Property CheckedDate As DateTime
        Get
            Return m_CheckedDate
        End Get
        Set(value As DateTime)
            m_CheckedDate = value
        End Set
    End Property
    Private m_CheckNote As String
    Public Property CheckNote As String
        Get
            Return m_CheckNote
        End Get
        Set(value As String)
            m_CheckNote = value
        End Set
    End Property
    Private m_ApproveBy As String
    Public Property ApproveBy As String
        Get
            Return m_ApproveBy
        End Get
        Set(value As String)
            m_ApproveBy = value
        End Set
    End Property
    Private m_ApproveDate As DateTime
    Public Property ApproveDate As DateTime
        Get
            Return m_ApproveDate
        End Get
        Set(value As DateTime)
            m_ApproveDate = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_Document" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("BranchCode") = Main.GetDBString(Me.BranchCode, dt.Columns("BranchCode"))
                            dr("JNo") = Main.GetDBString(Me.JNo, dt.Columns("JNo"))
                            If Me.ItemNo = 0 Then Me.AddNew()
                            dr("ItemNo") = Main.GetDBString(Me.ItemNo, dt.Columns("ItemNo"))
                            dr("DocType") = Main.GetDBString(Me.DocType, dt.Columns("DocType"))
                            dr("DocDate") = Main.GetDBDate(Me.DocDate)
                            dr("DocNo") = Main.GetDBString(Me.DocNo, dt.Columns("DocNo"))
                            dr("Description") = Main.GetDBString(Me.Description, dt.Columns("Description"))
                            dr("FileType") = Main.GetDBString(Me.FileType, dt.Columns("FileType"))
                            dr("FilePath") = Main.GetDBString(Me.FilePath, dt.Columns("FilePath"))
                            dr("FileSize") = Me.FileSize
                            dr("UploadBy") = Main.GetDBString(Me.UploadBy, dt.Columns("UploadBy"))
                            dr("UploadDate") = Main.GetDBDate(Me.UploadDate)
                            dr("CheckedBy") = Main.GetDBString(Me.CheckedBy, dt.Columns("CheckedBy"))
                            dr("CheckedDate") = Main.GetDBDate(Me.CheckedDate)
                            dr("CheckNote") = Main.GetDBString(Me.CheckNote, dt.Columns("CheckNote"))
                            dr("ApproveBy") = Main.GetDBString(Me.ApproveBy, dt.Columns("ApproveBy"))
                            dr("ApproveDate") = Main.GetDBDate(Me.ApproveDate)

                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CDocument", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                msg = ex.Message
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CDocument", "SaveData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()
        Dim retStr As String = Main.GetMaxByMask(m_ConnStr, String.Format("SELECT MAX(ItemNo) as t FROM Job_Document WHERE BranchCode='{0}' And JNo ='{1}' ", m_BranchCode, m_JNo), "____")
        m_ItemNo = Convert.ToInt32("0" & retStr)
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CDocument)
        Dim lst As New List(Of CDocument)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CDocument
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_Document" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CDocument(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("JNo"))) = False Then
                        row.JNo = rd.GetString(rd.GetOrdinal("JNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ItemNo"))) = False Then
                        row.ItemNo = rd.GetValue(rd.GetOrdinal("ItemNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocType"))) = False Then
                        row.DocType = rd.GetString(rd.GetOrdinal("DocType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocDate"))) = False Then
                        row.DocDate = rd.GetValue(rd.GetOrdinal("DocDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocNo"))) = False Then
                        row.DocNo = rd.GetString(rd.GetOrdinal("DocNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Description"))) = False Then
                        row.Description = rd.GetString(rd.GetOrdinal("Description")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FileType"))) = False Then
                        row.FileType = rd.GetString(rd.GetOrdinal("FileType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FilePath"))) = False Then
                        row.FilePath = rd.GetString(rd.GetOrdinal("FilePath")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FileSize"))) = False Then
                        row.FileSize = rd.GetDouble(rd.GetOrdinal("FileSize")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UploadBy"))) = False Then
                        row.UploadBy = rd.GetString(rd.GetOrdinal("UploadBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UploadDate"))) = False Then
                        row.UploadDate = rd.GetValue(rd.GetOrdinal("UploadDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CheckedBy"))) = False Then
                        row.CheckedBy = rd.GetString(rd.GetOrdinal("CheckedBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CheckedDate"))) = False Then
                        row.CheckedDate = rd.GetValue(rd.GetOrdinal("CheckedDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CheckNote"))) = False Then
                        row.CheckNote = rd.GetString(rd.GetOrdinal("CheckNote")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ApproveBy"))) = False Then
                        row.ApproveBy = rd.GetString(rd.GetOrdinal("ApproveBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ApproveDate"))) = False Then
                        row.ApproveDate = rd.GetValue(rd.GetOrdinal("ApproveDate"))
                    End If

                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CDocument", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Job_Document" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CDocument", "DeleteData", cm.CommandText, False)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                msg = ex.Message
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CDocument", "DeleteData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return msg
    End Function
End Class
