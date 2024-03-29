﻿'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CTransportDetail
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
    Private m_CTN_NO As String
    Public Property CTN_NO As String
        Get
            Return m_CTN_NO
        End Get
        Set(value As String)
            m_CTN_NO = value
        End Set
    End Property
    Private m_SealNumber As String
    Public Property SealNumber As String
        Get
            Return m_SealNumber
        End Get
        Set(value As String)
            m_SealNumber = value
        End Set
    End Property
    Private m_TruckNO As String
    Public Property TruckNO As String
        Get
            Return m_TruckNO
        End Get
        Set(value As String)
            m_TruckNO = value
        End Set
    End Property
    Private m_TruckIN As Date
    Public Property TruckIN As Date
        Get
            Return m_TruckIN
        End Get
        Set(value As Date)
            m_TruckIN = value
        End Set
    End Property
    Private m_Start As Date
    Public Property Start As Date
        Get
            Return m_Start
        End Get
        Set(value As Date)
            m_Start = value
        End Set
    End Property
    Private m_Finish As Date
    Public Property Finish As Date
        Get
            Return m_Finish
        End Get
        Set(value As Date)
            m_Finish = value
        End Set
    End Property
    Private m_TimeUsed As Double
    Public Property TimeUsed As Double
        Get
            Return m_TimeUsed
        End Get
        Set(value As Double)
            m_TimeUsed = value
        End Set
    End Property
    Private m_CauseCode As String
    Public Property CauseCode As String
        Get
            Return m_CauseCode
        End Get
        Set(value As String)
            m_CauseCode = value
        End Set
    End Property
    Private m_Comment As String
    Public Property Comment As String
        Get
            Return m_Comment
        End Get
        Set(value As String)
            m_Comment = value
        End Set
    End Property
    Private m_TruckType As String
    Public Property TruckType As String
        Get
            Return m_TruckType
        End Get
        Set(value As String)
            m_TruckType = value
        End Set
    End Property
    Private m_Driver As String
    Public Property Driver As String
        Get
            Return m_Driver
        End Get
        Set(value As String)
            m_Driver = value
        End Set
    End Property
    Private m_TargetYardDate As Date
    Public Property TargetYardDate As Date
        Get
            Return m_TargetYardDate
        End Get
        Set(value As Date)
            m_TargetYardDate = value
        End Set
    End Property
    Private m_TargetYardTime As Date
    Public Property TargetYardTime As Date
        Get
            Return m_TargetYardTime
        End Get
        Set(value As Date)
            m_TargetYardTime = value
        End Set
    End Property
    Private m_ActualYardDate As Date
    Public Property ActualYardDate As Date
        Get
            Return m_ActualYardDate
        End Get
        Set(value As Date)
            m_ActualYardDate = value
        End Set
    End Property
    Private m_ActualYardTime As Date
    Public Property ActualYardTime As Date
        Get
            Return m_ActualYardTime
        End Get
        Set(value As Date)
            m_ActualYardTime = value
        End Set
    End Property
    Private m_UnloadFinishDate As Date
    Public Property UnloadFinishDate As Date
        Get
            Return m_UnloadFinishDate
        End Get
        Set(value As Date)
            m_UnloadFinishDate = value
        End Set
    End Property
    Private m_UnloadFinishTime As Date
    Public Property UnloadFinishTime As Date
        Get
            Return m_UnloadFinishTime
        End Get
        Set(value As Date)
            m_UnloadFinishTime = value
        End Set
    End Property
    Private m_UnloadDate As Date
    Public Property UnloadDate As Date
        Get
            Return m_UnloadDate
        End Get
        Set(value As Date)
            m_UnloadDate = value
        End Set
    End Property
    Private m_UnloadTime As Date
    Public Property UnloadTime As Date
        Get
            Return m_UnloadTime
        End Get
        Set(value As Date)
            m_UnloadTime = value
        End Set
    End Property
    Private m_Location As String
    Public Property Location As String
        Get
            Return m_Location
        End Get
        Set(value As String)
            m_Location = value
        End Set
    End Property
    Private m_ReturnDate As Date
    Public Property ReturnDate As Date
        Get
            Return m_ReturnDate
        End Get
        Set(value As Date)
            m_ReturnDate = value
        End Set
    End Property
    Private m_ShippingMark As String
    Public Property ShippingMark As String
        Get
            Return m_ShippingMark
        End Get
        Set(value As String)
            m_ShippingMark = value
        End Set
    End Property
    Private m_ProductDesc As String
    Public Property ProductDesc As String
        Get
            Return m_ProductDesc
        End Get
        Set(value As String)
            m_ProductDesc = value
        End Set
    End Property
    Private m_CTN_SIZE As String
    Public Property CTN_SIZE As String
        Get
            Return m_CTN_SIZE
        End Get
        Set(value As String)
            m_CTN_SIZE = value
        End Set
    End Property
    Private m_ProductQty As Double
    Public Property ProductQty As Double
        Get
            Return m_ProductQty
        End Get
        Set(value As Double)
            m_ProductQty = value
        End Set
    End Property
    Private m_ProductUnit As String
    Public Property ProductUnit As String
        Get
            Return m_ProductUnit
        End Get
        Set(value As String)
            m_ProductUnit = value
        End Set
    End Property
    Private m_GrossWeight As Double
    Public Property GrossWeight As Double
        Get
            Return m_GrossWeight
        End Get
        Set(value As Double)
            m_GrossWeight = value
        End Set
    End Property
    Private m_Measurement As Double
    Public Property Measurement As Double
        Get
            Return m_Measurement
        End Get
        Set(value As Double)
            m_Measurement = value
        End Set
    End Property
    Private m_BookingNo As String
    Public Property BookingNo As String
        Get
            Return m_BookingNo
        End Get
        Set(value As String)
            m_BookingNo = value
        End Set
    End Property
    Private m_DeliveryNo As String
    Public Property DeliveryNo As String
        Get
            Return m_DeliveryNo
        End Get
        Set(value As String)
            m_DeliveryNo = value
        End Set
    End Property
    Private m_LocationID As Integer
    Public Property LocationID As Integer
        Get
            Return m_LocationID
        End Get
        Set(value As Integer)
            m_LocationID = value
        End Set
    End Property
    Private m_NetWeight As Double
    Public Property NetWeight As Double
        Get
            Return m_NetWeight
        End Get
        Set(value As Double)
            m_NetWeight = value
        End Set
    End Property
    Private m_ProductPrice As Double
    Public Property ProductPrice As Double
        Get
            Return m_ProductPrice
        End Get
        Set(value As Double)
            m_ProductPrice = value
        End Set
    End Property
    Private m_PlaceName1 As String
    Public Property PlaceName1 As String
        Get
            Return m_PlaceName1
        End Get
        Set(value As String)
            m_PlaceName1 = value
        End Set
    End Property
    Private m_PlaceAddress1 As String
    Public Property PlaceAddress1 As String
        Get
            Return m_PlaceAddress1
        End Get
        Set(value As String)
            m_PlaceAddress1 = value
        End Set
    End Property
    Private m_PlaceContact1 As String
    Public Property PlaceContact1 As String
        Get
            Return m_PlaceContact1
        End Get
        Set(value As String)
            m_PlaceContact1 = value
        End Set
    End Property
    Private m_PlaceName2 As String
    Public Property PlaceName2 As String
        Get
            Return m_PlaceName2
        End Get
        Set(value As String)
            m_PlaceName2 = value
        End Set
    End Property
    Private m_PlaceAddress2 As String
    Public Property PlaceAddress2 As String
        Get
            Return m_PlaceAddress2
        End Get
        Set(value As String)
            m_PlaceAddress2 = value
        End Set
    End Property
    Private m_PlaceContact2 As String
    Public Property PlaceContact2 As String
        Get
            Return m_PlaceContact2
        End Get
        Set(value As String)
            m_PlaceContact2 = value
        End Set
    End Property
    Private m_PlaceName3 As String
    Public Property PlaceName3 As String
        Get
            Return m_PlaceName3
        End Get
        Set(value As String)
            m_PlaceName3 = value
        End Set
    End Property
    Private m_PlaceAddress3 As String
    Public Property PlaceAddress3 As String
        Get
            Return m_PlaceAddress3
        End Get
        Set(value As String)
            m_PlaceAddress3 = value
        End Set
    End Property
    Private m_PlaceContact3 As String
    Public Property PlaceContact3 As String
        Get
            Return m_PlaceContact3
        End Get
        Set(value As String)
            m_PlaceContact3 = value
        End Set
    End Property
    Private m_PlaceName4 As String
    Public Property PlaceName4 As String
        Get
            Return m_PlaceName4
        End Get
        Set(value As String)
            m_PlaceName4 = value
        End Set
    End Property
    Private m_PlaceAddress4 As String
    Public Property PlaceAddress4 As String
        Get
            Return m_PlaceAddress4
        End Get
        Set(value As String)
            m_PlaceAddress4 = value
        End Set
    End Property
    Private m_PlaceContact4 As String
    Public Property PlaceContact4 As String
        Get
            Return m_PlaceContact4
        End Get
        Set(value As String)
            m_PlaceContact4 = value
        End Set
    End Property
    Private m_MileBegin As Double
    Public Property MileBegin As Double
        Get
            Return m_MileBegin
        End Get
        Set(value As Double)
            m_MileBegin = value
        End Set
    End Property
    Private m_MileEnd As Double
    Public Property MileEnd As Double
        Get
            Return m_MileEnd
        End Get
        Set(value As Double)
            m_MileEnd = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Job_LoadInfoDetail" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("BranchCode") = Main.GetDBString(Me.BranchCode, dt.Columns("BranchCode"))
                            dr("JNo") = Main.GetDBString(Me.JNo, dt.Columns("JNo"))
                            dr("BookingNo") = Main.GetDBString(Me.BookingNo, dt.Columns("BookingNo"))
                            If Me.ItemNo = 0 Then Me.AddNew()
                            dr("ItemNo") = Me.ItemNo
                            dr("CTN_NO") = Main.GetDBString(Me.CTN_NO, dt.Columns("CTN_NO"))
                            dr("SealNumber") = Main.GetDBString(Me.SealNumber, dt.Columns("SealNumber"))
                            dr("TruckNO") = Main.GetDBString(Me.TruckNO, dt.Columns("TruckNO"))
                            dr("TruckIN") = Main.GetDBDate(Me.TruckIN)
                            dr("Start") = Main.GetDBTime(Me.Start)
                            dr("Finish") = Main.GetDBTime(Me.Finish)
                            dr("CauseCode") = Main.GetDBString(Me.CauseCode, dt.Columns("CauseCode"))
                            dr("Comment") = Main.GetDBString(Me.Comment, dt.Columns("Comment"))
                            dr("TruckType") = Main.GetDBString(Me.TruckType, dt.Columns("TruckType"))
                            dr("Driver") = Main.GetDBString(Me.Driver, dt.Columns("Driver"))
                            dr("TargetYardDate") = Main.GetDBDate(Me.TargetYardDate)
                            dr("TargetYardTime") = Main.GetDBTime(Me.TargetYardTime)
                            dr("ActualYardDate") = Main.GetDBDate(Me.ActualYardDate)
                            dr("ActualYardTime") = Main.GetDBTime(Me.ActualYardTime)
                            dr("UnloadFinishDate") = Main.GetDBDate(Me.UnloadFinishDate)
                            dr("UnloadFinishTime") = Main.GetDBTime(Me.UnloadFinishTime)
                            dr("UnloadDate") = Main.GetDBDate(Me.UnloadDate)
                            dr("UnloadTime") = Main.GetDBTime(Me.UnloadTime)
                            dr("Location") = Main.GetDBString(Me.Location, dt.Columns("Location"))
                            dr("ReturnDate") = Main.GetDBDate(Me.ReturnDate)
                            dr("ShippingMark") = Main.GetDBString(Me.ShippingMark, dt.Columns("ShippingMark"))
                            dr("ProductDesc") = Main.GetDBString(Me.ProductDesc, dt.Columns("ProductDesc"))
                            dr("CTN_SIZE") = Main.GetDBString(Me.CTN_SIZE, dt.Columns("CTN_SIZE"))
                            dr("ProductQty") = Me.ProductQty
                            dr("ProductUnit") = Main.GetDBString(Me.ProductUnit, dt.Columns("ProductUnit"))
                            dr("GrossWeight") = Me.GrossWeight
                            dr("Measurement") = Me.Measurement
                            dr("TimeUsed") = Me.TimeUsed
                            dr("DeliveryNo") = Main.GetDBString(Me.DeliveryNo, dt.Columns("DeliveryNo"))
                            dr("LocationID") = Main.GetDBString(Me.LocationID, dt.Columns("LocationID"))
                            dr("NetWeight") = Me.NetWeight
                            dr("ProductPrice") = Me.ProductPrice
                            dr("PlaceName1") = Me.m_PlaceName1
                            dr("PlaceName2") = Me.m_PlaceName2
                            dr("PlaceName3") = Me.m_PlaceName3
                            dr("PlaceName4") = Me.m_PlaceName4
                            dr("PlaceAddress1") = Me.m_PlaceAddress1
                            dr("PlaceAddress2") = Me.m_PlaceAddress2
                            dr("PlaceAddress3") = Me.m_PlaceAddress3
                            dr("PlaceAddress4") = Me.m_PlaceAddress4
                            dr("PlaceContact1") = Me.m_PlaceContact1
                            dr("PlaceContact2") = Me.m_PlaceContact2
                            dr("PlaceContact3") = Me.m_PlaceContact3
                            dr("PlaceContact4") = Me.m_PlaceContact4
                            dr("MileBegin") = Me.MileBegin
                            dr("MileEnd") = Me.MileEnd
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            Main.SaveLogFromObject(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportDetail", "SaveData", Me, False)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportDetail", "SaveData", ex.Message, True, ex.StackTrace, "")
                msg = "[ERROR]:" & ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()
        Dim retStr As String = Main.GetMaxByMask(m_ConnStr, String.Format("SELECT MAX(ItemNo) as t FROM Job_LoadInfoDetail WHERE BranchCode='{0}' And BookingNo ='{1}' ", m_BranchCode, m_BookingNo), "____")
        m_ItemNo = Convert.ToInt32("0" & retStr)
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of CTransportDetail)
        Dim lst As New List(Of CTransportDetail)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CTransportDetail
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Job_LoadInfoDetail" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CTransportDetail(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("JNo"))) = False Then
                        row.JNo = rd.GetString(rd.GetOrdinal("JNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BookingNo"))) = False Then
                        row.BookingNo = rd.GetString(rd.GetOrdinal("BookingNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ItemNo"))) = False Then
                        row.ItemNo = rd.GetInt16(rd.GetOrdinal("ItemNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CTN_NO"))) = False Then
                        row.CTN_NO = rd.GetString(rd.GetOrdinal("CTN_NO")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SealNumber"))) = False Then
                        row.SealNumber = rd.GetString(rd.GetOrdinal("SealNumber")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TruckNO"))) = False Then
                        row.TruckNO = rd.GetString(rd.GetOrdinal("TruckNO")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TruckIN"))) = False Then
                        row.TruckIN = rd.GetValue(rd.GetOrdinal("TruckIN"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Start"))) = False Then
                        row.Start = rd.GetValue(rd.GetOrdinal("Start"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Finish"))) = False Then
                        row.Finish = rd.GetValue(rd.GetOrdinal("Finish"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TimeUsed"))) = False Then
                        row.TimeUsed = rd.GetValue(rd.GetOrdinal("TimeUsed"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CauseCode"))) = False Then
                        row.CauseCode = rd.GetString(rd.GetOrdinal("CauseCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Comment"))) = False Then
                        row.Comment = rd.GetString(rd.GetOrdinal("Comment")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TruckType"))) = False Then
                        row.TruckType = rd.GetString(rd.GetOrdinal("TruckType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Driver"))) = False Then
                        row.Driver = rd.GetString(rd.GetOrdinal("Driver")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TargetYardDate"))) = False Then
                        row.TargetYardDate = rd.GetValue(rd.GetOrdinal("TargetYardDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TargetYardTime"))) = False Then
                        row.TargetYardTime = rd.GetValue(rd.GetOrdinal("TargetYardTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ActualYardDate"))) = False Then
                        row.ActualYardDate = rd.GetValue(rd.GetOrdinal("ActualYardDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ActualYardTime"))) = False Then
                        row.ActualYardTime = rd.GetValue(rd.GetOrdinal("ActualYardTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UnloadFinishDate"))) = False Then
                        row.UnloadFinishDate = rd.GetValue(rd.GetOrdinal("UnloadFinishDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UnloadFinishTime"))) = False Then
                        row.UnloadFinishTime = rd.GetValue(rd.GetOrdinal("UnloadFinishTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UnloadDate"))) = False Then
                        row.UnloadDate = rd.GetValue(rd.GetOrdinal("UnloadDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UnloadTime"))) = False Then
                        row.UnloadTime = rd.GetValue(rd.GetOrdinal("UnloadTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Location"))) = False Then
                        row.Location = rd.GetString(rd.GetOrdinal("Location")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ReturnDate"))) = False Then
                        row.ReturnDate = rd.GetValue(rd.GetOrdinal("ReturnDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ShippingMark"))) = False Then
                        row.ShippingMark = rd.GetString(rd.GetOrdinal("ShippingMark")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProductDesc"))) = False Then
                        row.ProductDesc = rd.GetString(rd.GetOrdinal("ProductDesc")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CTN_SIZE"))) = False Then
                        row.CTN_SIZE = rd.GetString(rd.GetOrdinal("CTN_SIZE")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProductQty"))) = False Then
                        row.ProductQty = rd.GetDouble(rd.GetOrdinal("ProductQty"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProductUnit"))) = False Then
                        row.ProductUnit = rd.GetString(rd.GetOrdinal("ProductUnit")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("GrossWeight"))) = False Then
                        row.GrossWeight = rd.GetDouble(rd.GetOrdinal("GrossWeight"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Measurement"))) = False Then
                        row.Measurement = rd.GetDouble(rd.GetOrdinal("Measurement"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DeliveryNo"))) = False Then
                        row.DeliveryNo = rd.GetString(rd.GetOrdinal("DeliveryNo"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LocationID"))) = False Then
                        row.LocationID = rd.GetInt32(rd.GetOrdinal("LocationID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("NetWeight"))) = False Then
                        row.NetWeight = rd.GetDouble(rd.GetOrdinal("NetWeight"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProductPrice"))) = False Then
                        row.ProductPrice = rd.GetDouble(rd.GetOrdinal("ProductPrice"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceName1"))) = False Then
                        row.PlaceName1 = rd.GetString(rd.GetOrdinal("PlaceName1"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceAddress1"))) = False Then
                        row.PlaceAddress1 = rd.GetString(rd.GetOrdinal("PlaceAddress1"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceContact1"))) = False Then
                        row.PlaceContact1 = rd.GetString(rd.GetOrdinal("PlaceContact1"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceName2"))) = False Then
                        row.PlaceName2 = rd.GetString(rd.GetOrdinal("PlaceName2"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceAddress2"))) = False Then
                        row.PlaceAddress2 = rd.GetString(rd.GetOrdinal("PlaceAddress2"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceContact2"))) = False Then
                        row.PlaceContact2 = rd.GetString(rd.GetOrdinal("PlaceContact2"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceName3"))) = False Then
                        row.PlaceName3 = rd.GetString(rd.GetOrdinal("PlaceName3"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceAddress3"))) = False Then
                        row.PlaceAddress3 = rd.GetString(rd.GetOrdinal("PlaceAddress3"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceContact3"))) = False Then
                        row.PlaceContact3 = rd.GetString(rd.GetOrdinal("PlaceContact3"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceName4"))) = False Then
                        row.PlaceName4 = rd.GetString(rd.GetOrdinal("PlaceName4"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceAddress4"))) = False Then
                        row.PlaceAddress4 = rd.GetString(rd.GetOrdinal("PlaceAddress4"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PlaceContact4"))) = False Then
                        row.PlaceContact4 = rd.GetString(rd.GetOrdinal("PlaceContact4"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("MileBegin"))) = False Then
                        row.MileBegin = rd.GetValue(rd.GetOrdinal("MileBegin"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("MileEnd"))) = False Then
                        row.MileEnd = rd.GetValue(rd.GetOrdinal("MileEnd"))
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportDetail", "GetData", ex.Message, True, ex.StackTrace, "")
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM Job_LoadInfoDetail" + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportDetail", "DeleteData", cm.CommandText, False)
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CTransportDetail", "DeleteData", ex.Message, True, ex.StackTrace, "")
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class
