'-----Class Definition-----
Imports System.Data.SqlClient
Public Class CJobOrderN
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_Factory As String
    Public Property Factory As String
        Get
            Return m_Factory
        End Get
        Set(value As String)
            m_Factory = value
        End Set
    End Property
    Private m_Product As String
    Public Property Product As String
        Get
            Return m_Product
        End Get
        Set(value As String)
            m_Product = value
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
    Private m_BranchCode As String
    Public Property BranchCode As String
        Get
            Return m_BranchCode
        End Get
        Set(value As String)
            m_BranchCode = value
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
    Private m_DocDate As Date
    Public Property DocDate As Date
        Get
            Return m_DocDate
        End Get
        Set(value As Date)
            m_DocDate = value
        End Set
    End Property
    Private m_CustRefNO As String
    Public Property CustRefNO As String
        Get
            Return m_CustRefNO
        End Get
        Set(value As String)
            m_CustRefNO = value
        End Set
    End Property
    Private m_AgentCode As String
    Public Property AgentCode As String
        Get
            Return m_AgentCode
        End Get
        Set(value As String)
            m_AgentCode = value
        End Set
    End Property
    Private m_VesselName As String
    Public Property VesselName As String
        Get
            Return m_VesselName
        End Get
        Set(value As String)
            m_VesselName = value
        End Set
    End Property
    Private m_ClearPort As String
    Public Property ClearPort As String
        Get
            Return m_ClearPort
        End Get
        Set(value As String)
            m_ClearPort = value
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
    Private m_CTN_NO As String
    Public Property CTN_NO As String
        Get
            Return m_CTN_NO
        End Get
        Set(value As String)
            m_CTN_NO = value
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
    Private m_SealNumber As String
    Public Property SealNumber As String
        Get
            Return m_SealNumber
        End Get
        Set(value As String)
            m_SealNumber = value
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
    Private m_FactoryAddress As String
    Public Property FactoryAddress As String
        Get
            Return m_FactoryAddress
        End Get
        Set(value As String)
            m_FactoryAddress = value
        End Set
    End Property
    Private m_FactoryTime As Date
    Public Property FactoryTime As Date
        Get
            Return m_FactoryTime
        End Get
        Set(value As Date)
            m_FactoryTime = value
        End Set
    End Property
    Private m_PackingAddress As String
    Public Property PackingAddress As String
        Get
            Return m_PackingAddress
        End Get
        Set(value As String)
            m_PackingAddress = value
        End Set
    End Property
    Private m_PackingTime As Date
    Public Property PackingTime As Date
        Get
            Return m_PackingTime
        End Get
        Set(value As Date)
            m_PackingTime = value
        End Set
    End Property
    Private m_ReturnAddress As String
    Public Property ReturnAddress As String
        Get
            Return m_ReturnAddress
        End Get
        Set(value As String)
            m_ReturnAddress = value
        End Set
    End Property
    Private m_ReturnTime As Date
    Public Property ReturnTime As Date
        Get
            Return m_ReturnTime
        End Get
        Set(value As Date)
            m_ReturnTime = value
        End Set
    End Property
    Private m_DeliveryAddr As String
    Public Property DeliveryAddr As String
        Get
            Return m_DeliveryAddr
        End Get
        Set(value As String)
            m_DeliveryAddr = value
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
    Private m_Driver As String
    Public Property Driver As String
        Get
            Return m_Driver
        End Get
        Set(value As String)
            m_Driver = value
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
    Private m_CarLicense As String
    Public Property CarLicense As String
        Get
            Return m_CarLicense
        End Get
        Set(value As String)
            m_CarLicense = value
        End Set
    End Property
    Private m_ItemNo As String
    Public Property ItemNo As String
        Get
            Return m_ItemNo
        End Get
        Set(value As String)
            m_ItemNo = value
        End Set
    End Property
    Private m_Destination As String
    Public Property Destination As String
        Get
            Return m_Destination
        End Get
        Set(value As String)
            m_Destination = value
        End Set
    End Property

    Public Function GetData(pSQLWhere As String) As List(Of CJobOrderN)
        Dim lst As New List(Of CJobOrderN)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CJobOrderN
            Dim sql = "select d.PlaceName1 as Factory,o.InvProduct as Product,f.JNo as JNo,f.BranchCode as BranchCode,f.DocNo as DocNo,f.DocDate as DocDate,o.CustRefNO as CustRefNO,o.AgentCode as AgentCode,o.VesselName as VesselName,o.ClearPort as ClearPort,d.Finish as Finish,d.CTN_NO as CTN_NO,d.CTN_SIZE as CTN_SIZE,d.SealNumber as SealNumber,d.BookingNo as BookingNo,
                        l.FactoryAddress as FactoryAddress,l.FactoryTime as FactoryTime,l.PackingAddress as PackingAddress,l.PackingTime as PackingTime,l.ReturnAddress as ReturnAddress,l.ReturnTime as ReturnTime,o.DeliveryAddr as DeliveryAddr,l.Remark as Remark,d.Driver as Driver,
                        d.TruckNO as TruckNO,t.CarLicense as CarLicense,d.ItemNo as ItemNo,d.PlaceName2 as Destination
from Job_AddFuel as f
inner join Job_LoadInfo as l on f.JNo=l.JNo and f.BranchCode=l.BranchCode 
inner join Job_Order as o on o.JNo = l.JNo and o.BranchCode=l.BranchCode
inner join Job_LoadInfoDetail as d  on o.JNo = d.JNo and o.BranchCode=d.BranchCode
left join Mas_CarLicense as t on t.CarNo=d.TruckNO "
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand(sql & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CJobOrderN(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Factory"))) = False Then
                        row.Factory = rd.GetString(rd.GetOrdinal("Factory")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Product"))) = False Then
                        row.Product = rd.GetString(rd.GetOrdinal("Product")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("JNo"))) = False Then
                        row.JNo = rd.GetString(rd.GetOrdinal("JNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BranchCode"))) = False Then
                        row.BranchCode = rd.GetString(rd.GetOrdinal("BranchCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocNo"))) = False Then
                        row.DocNo = rd.GetString(rd.GetOrdinal("DocNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DocDate"))) = False Then
                        row.DocDate = rd.GetValue(rd.GetOrdinal("DocDate"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CustRefNO"))) = False Then
                        row.CustRefNO = rd.GetString(rd.GetOrdinal("CustRefNO")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AgentCode"))) = False Then
                        row.AgentCode = rd.GetString(rd.GetOrdinal("AgentCode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("VesselName"))) = False Then
                        row.VesselName = rd.GetString(rd.GetOrdinal("VesselName")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ClearPort"))) = False Then
                        row.ClearPort = rd.GetString(rd.GetOrdinal("ClearPort")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Finish"))) = False Then
                        row.Finish = rd.GetValue(rd.GetOrdinal("Finish"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CTN_NO"))) = False Then
                        row.CTN_NO = rd.GetString(rd.GetOrdinal("CTN_NO")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CTN_SIZE"))) = False Then
                        row.CTN_SIZE = rd.GetString(rd.GetOrdinal("CTN_SIZE")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SealNumber"))) = False Then
                        row.SealNumber = rd.GetString(rd.GetOrdinal("SealNumber")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("BookingNo"))) = False Then
                        row.BookingNo = rd.GetString(rd.GetOrdinal("BookingNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FactoryAddress"))) = False Then
                        row.FactoryAddress = rd.GetString(rd.GetOrdinal("FactoryAddress")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FactoryTime"))) = False Then
                        row.FactoryTime = rd.GetValue(rd.GetOrdinal("FactoryTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PackingAddress"))) = False Then
                        row.PackingAddress = rd.GetString(rd.GetOrdinal("PackingAddress")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PackingTime"))) = False Then
                        row.PackingTime = rd.GetValue(rd.GetOrdinal("PackingTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ReturnAddress"))) = False Then
                        row.ReturnAddress = rd.GetString(rd.GetOrdinal("ReturnAddress")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ReturnTime"))) = False Then
                        row.ReturnTime = rd.GetValue(rd.GetOrdinal("ReturnTime"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DeliveryAddr"))) = False Then
                        row.DeliveryAddr = rd.GetString(rd.GetOrdinal("DeliveryAddr")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Remark"))) = False Then
                        row.Remark = rd.GetString(rd.GetOrdinal("Remark")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Driver"))) = False Then
                        row.Driver = rd.GetString(rd.GetOrdinal("Driver")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("TruckNO"))) = False Then
                        row.TruckNO = rd.GetString(rd.GetOrdinal("TruckNO")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("CarLicense"))) = False Then
                        row.CarLicense = rd.GetString(rd.GetOrdinal("CarLicense")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ItemNo"))) = False Then
                        row.ItemNo = rd.GetValue(rd.GetOrdinal("ItemNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Destination"))) = False Then
                        row.Destination = rd.GetString(rd.GetOrdinal("Destination")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return lst
    End Function

End Class