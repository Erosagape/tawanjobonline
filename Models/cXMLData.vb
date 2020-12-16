Imports System.Xml
Public Class CXMLData
    Private ReadOnly dataPath As String
    Private msgError As String
    Private oXML As XmlDocument
    Public ReadOnly Property IsError As String
        Get
            Return msgError
        End Get
    End Property
    Public Sub New(ptPath As String)
        dataPath = ptPath
        msgError = ""
    End Sub
#Disable Warning IDE1006 ' Naming Styles
    Public Function getData(nodeName As String) As XmlNodeList
#Enable Warning IDE1006 ' Naming Styles
        Return oXML.SelectNodes(nodeName)
    End Function
#Disable Warning IDE1006 ' Naming Styles
    Public Function getXML() As XmlDocument
#Enable Warning IDE1006 ' Naming Styles
        msgError = ""
        Try
            oXML = New XmlDocument
            oXML.Load(dataPath)
        Catch ex As Exception
            msgError = ex.Message
        End Try
        Return oXML
    End Function
End Class
Public Class CJsonData
#Disable Warning IDE1006 ' Naming Styles
    Public Property source As String
#Enable Warning IDE1006 ' Naming Styles
#Disable Warning IDE1006 ' Naming Styles
    Public Property data As Object
#Enable Warning IDE1006 ' Naming Styles
End Class
Public Class CTestDate
    Private m_DocDate As Date
    Public Property DocDate As Date
        Get
            Return m_DocDate
        End Get
        Set(value As Date)
            m_DocDate = value
        End Set
    End Property
End Class