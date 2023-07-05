Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

<System.SerializableAttribute()>
    <System.Diagnostics.DebuggerStepThroughAttribute()>
    <System.ComponentModel.DesignerCategoryAttribute("code")>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/TimbreFiscalDigital")>
    <System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable:=False)>
Public Class TimbreFiscalDigital
    Private versionField As String
    Private uUIDField As String
    Private fechaTimbradoField As System.DateTime
    Private rfcProvCertifField As String
    Private leyendaField As String
    Private selloCFDField As String
    Private noCertificadoSATField As String
    Private selloSATField As String

    Public Sub New()
        Me.versionField = "1.1"
    End Sub

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Version As String
        Get
            Return Me.versionField
        End Get
        Set(ByVal value As String)
            Me.versionField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property UUID As String
        Get
            Return Me.uUIDField
        End Get
        Set(ByVal value As String)
            Me.uUIDField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property FechaTimbrado As System.DateTime
        Get
            Return Me.fechaTimbradoField
        End Get
        Set(ByVal value As System.DateTime)
            Me.fechaTimbradoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property RfcProvCertif As String
        Get
            Return Me.rfcProvCertifField
        End Get
        Set(ByVal value As String)
            Me.rfcProvCertifField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Leyenda As String
        Get
            Return Me.leyendaField
        End Get
        Set(ByVal value As String)
            Me.leyendaField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property SelloCFD As String
        Get
            Return Me.selloCFDField
        End Get
        Set(ByVal value As String)
            Me.selloCFDField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NoCertificadoSAT As String
        Get
            Return Me.noCertificadoSATField
        End Get
        Set(ByVal value As String)
            Me.noCertificadoSATField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property SelloSAT As String
        Get
            Return Me.selloSATField
        End Get
        Set(ByVal value As String)
            Me.selloSATField = value
        End Set
    End Property

End Class
