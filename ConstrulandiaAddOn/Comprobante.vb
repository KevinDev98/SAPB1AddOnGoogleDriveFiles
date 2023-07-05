
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Schema
Imports System.Xml.Serialization
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
<System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.sat.gob.mx/cfd/3", IsNullable:=False)>
Public Class Comprobante
    Private cfdiRelacionadosField As ComprobanteCfdiRelacionados
    Private emisorField As ComprobanteEmisor
    Private receptorField As ComprobanteReceptor
    Private conceptosField As ComprobanteConcepto()
    Private impuestosField As ComprobanteImpuestos
    Private complementoField As ComprobanteComplemento()
    Private addendaField As ComprobanteAddenda
    Private versionField As String
    Private serieField As String
    Private folioField As String
    Private fechaField As String
    Private selloField As String
    Private formaPagoField As String
    Private formaPagoFieldSpecified As Boolean
    Private noCertificadoField As String
    Private certificadoField As String
    Private condicionesDePagoField As String
    Private subTotalField As Decimal
    Private descuentoField As Decimal
    Private descuentoFieldSpecified As Boolean
    Private monedaField As String
    Private tipoCambioField As Decimal
    Private tipoCambioFieldSpecified As Boolean
    Private totalField As Decimal
    Private tipoDeComprobanteField As String
    Private metodoPagoField As String
    Private metodoPagoFieldSpecified As Boolean
    Private lugarExpedicionField As String
    Private confirmacionField As String

    <XmlAttribute("schemaLocation", [Namespace]:=XmlSchema.InstanceNamespace)>
    Public xsiSchemaLocation As String = "http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd"
    Public TimbreFiscalDigital As TimbreFiscalDigital

    Public Sub New()
        Me.versionField = "3.3"
    End Sub

    Public Property CfdiRelacionados As ComprobanteCfdiRelacionados
        Get
            Return Me.cfdiRelacionadosField
        End Get
        Set(ByVal value As ComprobanteCfdiRelacionados)
            Me.cfdiRelacionadosField = value
        End Set
    End Property

    Public Property Emisor As ComprobanteEmisor
        Get
            Return Me.emisorField
        End Get
        Set(ByVal value As ComprobanteEmisor)
            Me.emisorField = value
        End Set
    End Property

    Public Property Receptor As ComprobanteReceptor
        Get
            Return Me.receptorField
        End Get
        Set(ByVal value As ComprobanteReceptor)
            Me.receptorField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlArrayItemAttribute("Concepto", IsNullable:=False)>
    Public Property Conceptos As ComprobanteConcepto()
        Get
            Return Me.conceptosField
        End Get
        Set(ByVal value As ComprobanteConcepto())
            Me.conceptosField = value
        End Set
    End Property

    Public Property Impuestos As ComprobanteImpuestos
        Get
            Return Me.impuestosField
        End Get
        Set(ByVal value As ComprobanteImpuestos)
            Me.impuestosField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlElementAttribute("Complemento")>
    Public Property Complemento As ComprobanteComplemento()
        Get
            Return Me.complementoField
        End Get
        Set(ByVal value As ComprobanteComplemento())
            Me.complementoField = value
        End Set
    End Property

    Public Property Addenda As ComprobanteAddenda
        Get
            Return Me.addendaField
        End Get
        Set(ByVal value As ComprobanteAddenda)
            Me.addendaField = value
        End Set
    End Property

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
    Public Property Serie As String
        Get
            Return Me.serieField
        End Get
        Set(ByVal value As String)
            Me.serieField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Folio As String
        Get
            Return Me.folioField
        End Get
        Set(ByVal value As String)
            Me.folioField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Fecha As String
        Get
            Return Me.fechaField
        End Get
        Set(ByVal value As String)
            Me.fechaField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Sello As String
        Get
            Return Me.selloField
        End Get
        Set(ByVal value As String)
            Me.selloField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property FormaPago As String
        Get
            Return Me.formaPagoField
        End Get
        Set(ByVal value As String)
            formaPagoFieldSpecified = True
            Me.formaPagoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property FormaPagoSpecified As Boolean
        Get
            Return Me.formaPagoFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.formaPagoFieldSpecified = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NoCertificado As String
        Get
            Return Me.noCertificadoField
        End Get
        Set(ByVal value As String)
            Me.noCertificadoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Certificado As String
        Get
            Return Me.certificadoField
        End Get
        Set(ByVal value As String)
            Me.certificadoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property CondicionesDePago As String
        Get
            Return Me.condicionesDePagoField
        End Get
        Set(ByVal value As String)
            Me.condicionesDePagoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property SubTotal As Decimal
        Get
            Return Me.subTotalField
        End Get
        Set(ByVal value As Decimal)
            Me.subTotalField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Descuento As Decimal
        Get
            Return Me.descuentoField
        End Get
        Set(ByVal value As Decimal)
            descuentoFieldSpecified = True
            Me.descuentoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property DescuentoSpecified As Boolean
        Get
            Return Me.descuentoFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.descuentoFieldSpecified = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Moneda As String
        Get
            Return Me.monedaField
        End Get
        Set(ByVal value As String)
            Me.monedaField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TipoCambio As Decimal
        Get
            Return Me.tipoCambioField
        End Get
        Set(ByVal value As Decimal)
            Me.tipoCambioField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property TipoCambioSpecified As Boolean
        Get
            Return Me.tipoCambioFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.tipoCambioFieldSpecified = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total As Decimal
        Get
            Return Me.totalField
        End Get
        Set(ByVal value As Decimal)
            Me.totalField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TipoDeComprobante As String
        Get
            Return Me.tipoDeComprobanteField
        End Get
        Set(ByVal value As String)
            Me.tipoDeComprobanteField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property MetodoPago As String
        Get
            Return Me.metodoPagoField
        End Get
        Set(ByVal value As String)
            metodoPagoFieldSpecified = True
            Me.metodoPagoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property MetodoPagoSpecified As Boolean
        Get
            Return Me.metodoPagoFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.metodoPagoFieldSpecified = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property LugarExpedicion As String
        Get
            Return Me.lugarExpedicionField
        End Get
        Set(ByVal value As String)
            Me.lugarExpedicionField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Confirmacion As String
        Get
            Return Me.confirmacionField
        End Get
        Set(ByVal value As String)
            Me.confirmacionField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteCfdiRelacionados
    Private cfdiRelacionadoField As ComprobanteCfdiRelacionadosCfdiRelacionado()
    Private tipoRelacionField As String

    <System.Xml.Serialization.XmlElementAttribute("CfdiRelacionado")>
    Public Property CfdiRelacionado As ComprobanteCfdiRelacionadosCfdiRelacionado()
        Get
            Return Me.cfdiRelacionadoField
        End Get
        Set(ByVal value As ComprobanteCfdiRelacionadosCfdiRelacionado())
            Me.cfdiRelacionadoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TipoRelacion As String
        Get
            Return Me.tipoRelacionField
        End Get
        Set(ByVal value As String)
            Me.tipoRelacionField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteCfdiRelacionadosCfdiRelacionado
    Private uUIDField As String

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property UUID As String
        Get
            Return Me.uUIDField
        End Get
        Set(ByVal value As String)
            Me.uUIDField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteEmisor
    Private rfcField As String
    Private nombreField As String
    Private regimenFiscalField As String

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Rfc As String
        Get
            Return Me.rfcField
        End Get
        Set(ByVal value As String)
            Me.rfcField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Nombre As String
        Get
            Return Me.nombreField
        End Get
        Set(ByVal value As String)
            Me.nombreField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property RegimenFiscal As String
        Get
            Return Me.regimenFiscalField
        End Get
        Set(ByVal value As String)
            Me.regimenFiscalField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteReceptor
    Private rfcField As String
    Private nombreField As String
    Private residenciaFiscalField As String
    Private residenciaFiscalFieldSpecified As Boolean
    Private numRegIdTribField As String
    Private usoCFDIField As String

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Rfc As String
        Get
            Return Me.rfcField
        End Get
        Set(ByVal value As String)
            Me.rfcField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Nombre As String
        Get
            Return Me.nombreField
        End Get
        Set(ByVal value As String)
            Me.nombreField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ResidenciaFiscal As String
        Get
            Return Me.residenciaFiscalField
        End Get
        Set(ByVal value As String)
            Me.residenciaFiscalField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ResidenciaFiscalSpecified As Boolean
        Get
            Return Me.residenciaFiscalFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.residenciaFiscalFieldSpecified = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NumRegIdTrib As String
        Get
            Return Me.numRegIdTribField
        End Get
        Set(ByVal value As String)
            Me.numRegIdTribField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property UsoCFDI As String
        Get
            Return Me.usoCFDIField
        End Get
        Set(ByVal value As String)
            Me.usoCFDIField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteConcepto
    Private impuestosField As ComprobanteConceptoImpuestos
    Private informacionAduaneraField As ComprobanteConceptoInformacionAduanera()
    Private cuentaPredialField As ComprobanteConceptoCuentaPredial
    Private complementoConceptoField As ComprobanteConceptoComplementoConcepto
    Private parteField As ComprobanteConceptoParte()
    Private claveProdServField As String
    Private noIdentificacionField As String
    Private cantidadField As Decimal
    Private claveUnidadField As String
    Private unidadField As String
    Private descripcionField As String
    Private valorUnitarioField As Decimal
    Private importeField As Decimal
    Private descuentoField As Decimal
    Private descuentoFieldSpecified As Boolean

    Public Property Impuestos As ComprobanteConceptoImpuestos
        Get
            Return Me.impuestosField
        End Get
        Set(ByVal value As ComprobanteConceptoImpuestos)
            Me.impuestosField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlElementAttribute("InformacionAduanera")>
    Public Property InformacionAduanera As ComprobanteConceptoInformacionAduanera()
        Get
            Return Me.informacionAduaneraField
        End Get
        Set(ByVal value As ComprobanteConceptoInformacionAduanera())
            Me.informacionAduaneraField = value
        End Set
    End Property

    Public Property CuentaPredial As ComprobanteConceptoCuentaPredial
        Get
            Return Me.cuentaPredialField
        End Get
        Set(ByVal value As ComprobanteConceptoCuentaPredial)
            Me.cuentaPredialField = value
        End Set
    End Property

    Public Property ComplementoConcepto As ComprobanteConceptoComplementoConcepto
        Get
            Return Me.complementoConceptoField
        End Get
        Set(ByVal value As ComprobanteConceptoComplementoConcepto)
            Me.complementoConceptoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlElementAttribute("Parte")>
    Public Property Parte As ComprobanteConceptoParte()
        Get
            Return Me.parteField
        End Get
        Set(ByVal value As ComprobanteConceptoParte())
            Me.parteField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ClaveProdServ As String
        Get
            Return Me.claveProdServField
        End Get
        Set(ByVal value As String)
            Me.claveProdServField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NoIdentificacion As String
        Get
            Return Me.noIdentificacionField
        End Get
        Set(ByVal value As String)
            Me.noIdentificacionField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Cantidad As Decimal
        Get
            Return Me.cantidadField
        End Get
        Set(ByVal value As Decimal)
            Me.cantidadField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ClaveUnidad As String
        Get
            Return Me.claveUnidadField
        End Get
        Set(ByVal value As String)
            Me.claveUnidadField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Unidad As String
        Get
            Return Me.unidadField
        End Get
        Set(ByVal value As String)
            Me.unidadField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Descripcion As String
        Get
            Return Me.descripcionField
        End Get
        Set(ByVal value As String)
            Me.descripcionField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ValorUnitario As Decimal
        Get
            Return Me.valorUnitarioField
        End Get
        Set(ByVal value As Decimal)
            Me.valorUnitarioField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Importe As Decimal
        Get
            Return Me.importeField
        End Get
        Set(ByVal value As Decimal)
            Me.importeField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Descuento As Decimal
        Get
            Return Me.descuentoField
        End Get
        Set(ByVal value As Decimal)
            descuentoFieldSpecified = True
            Me.descuentoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property DescuentoSpecified As Boolean
        Get
            Return Me.descuentoFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.descuentoFieldSpecified = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteConceptoImpuestos
    Private trasladosField As ComprobanteConceptoImpuestosTraslado()
    Private retencionesField As ComprobanteConceptoImpuestosRetencion()

    <System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable:=False)>
    Public Property Traslados As ComprobanteConceptoImpuestosTraslado()
        Get
            Return Me.trasladosField
        End Get
        Set(ByVal value As ComprobanteConceptoImpuestosTraslado())
            Me.trasladosField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable:=False)>
    Public Property Retenciones As ComprobanteConceptoImpuestosRetencion()
        Get
            Return Me.retencionesField
        End Get
        Set(ByVal value As ComprobanteConceptoImpuestosRetencion())
            Me.retencionesField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteConceptoImpuestosTraslado
    Private baseField As Decimal
    Private impuestoField As String
    Private tipoFactorField As String
    Private tasaOCuotaField As Decimal
    Private tasaOCuotaFieldSpecified As Boolean
    Private importeField As Decimal
    Private importeFieldSpecified As Boolean

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Base As Decimal
        Get
            Return Me.baseField
        End Get
        Set(ByVal value As Decimal)
            Me.baseField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Impuesto As String
        Get
            Return Me.impuestoField
        End Get
        Set(ByVal value As String)
            Me.impuestoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TipoFactor As String
        Get
            Return Me.tipoFactorField
        End Get
        Set(ByVal value As String)
            Me.tipoFactorField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TasaOCuota As Decimal
        Get
            Return Me.tasaOCuotaField
        End Get
        Set(ByVal value As Decimal)
            Me.tasaOCuotaField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property TasaOCuotaSpecified As Boolean
        Get
            Return Me.tasaOCuotaFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.tasaOCuotaFieldSpecified = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Importe As Decimal
        Get
            Return Me.importeField
        End Get
        Set(ByVal value As Decimal)
            Me.importeField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ImporteSpecified As Boolean
        Get
            Return Me.importeFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.importeFieldSpecified = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteConceptoImpuestosRetencion
    Private baseField As Decimal
    Private impuestoField As String
    Private tipoFactorField As String
    Private tasaOCuotaField As Decimal
    Private importeField As Decimal

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Base As Decimal
        Get
            Return Me.baseField
        End Get
        Set(ByVal value As Decimal)
            Me.baseField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Impuesto As String
        Get
            Return Me.impuestoField
        End Get
        Set(ByVal value As String)
            Me.impuestoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TipoFactor As String
        Get
            Return Me.tipoFactorField
        End Get
        Set(ByVal value As String)
            Me.tipoFactorField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TasaOCuota As Decimal
        Get
            Return Me.tasaOCuotaField
        End Get
        Set(ByVal value As Decimal)
            Me.tasaOCuotaField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Importe As Decimal
        Get
            Return Me.importeField
        End Get
        Set(ByVal value As Decimal)
            Me.importeField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteConceptoInformacionAduanera
    Private numeroPedimentoField As String

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NumeroPedimento As String
        Get
            Return Me.numeroPedimentoField
        End Get
        Set(ByVal value As String)
            Me.numeroPedimentoField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteConceptoCuentaPredial
    Private numeroField As String

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Numero As String
        Get
            Return Me.numeroField
        End Get
        Set(ByVal value As String)
            Me.numeroField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteConceptoComplementoConcepto
    Private anyField As System.Xml.XmlElement()

    <System.Xml.Serialization.XmlAnyElementAttribute()>
    Public Property Any As System.Xml.XmlElement()
        Get
            Return Me.anyField
        End Get
        Set(ByVal value As System.Xml.XmlElement())
            Me.anyField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteConceptoParte
    Private informacionAduaneraField As ComprobanteConceptoParteInformacionAduanera()
    Private claveProdServField As String
    Private noIdentificacionField As String
    Private cantidadField As Decimal
    Private unidadField As String
    Private descripcionField As String
    Private valorUnitarioField As Decimal
    Private valorUnitarioFieldSpecified As Boolean
    Private importeField As Decimal
    Private importeFieldSpecified As Boolean

    <System.Xml.Serialization.XmlElementAttribute("InformacionAduanera")>
    Public Property InformacionAduanera As ComprobanteConceptoParteInformacionAduanera()
        Get
            Return Me.informacionAduaneraField
        End Get
        Set(ByVal value As ComprobanteConceptoParteInformacionAduanera())
            Me.informacionAduaneraField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ClaveProdServ As String
        Get
            Return Me.claveProdServField
        End Get
        Set(ByVal value As String)
            Me.claveProdServField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NoIdentificacion As String
        Get
            Return Me.noIdentificacionField
        End Get
        Set(ByVal value As String)
            Me.noIdentificacionField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Cantidad As Decimal
        Get
            Return Me.cantidadField
        End Get
        Set(ByVal value As Decimal)
            Me.cantidadField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Unidad As String
        Get
            Return Me.unidadField
        End Get
        Set(ByVal value As String)
            Me.unidadField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Descripcion As String
        Get
            Return Me.descripcionField
        End Get
        Set(ByVal value As String)
            Me.descripcionField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ValorUnitario As Decimal
        Get
            Return Me.valorUnitarioField
        End Get
        Set(ByVal value As Decimal)
            Me.valorUnitarioField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ValorUnitarioSpecified As Boolean
        Get
            Return Me.valorUnitarioFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.valorUnitarioFieldSpecified = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Importe As Decimal
        Get
            Return Me.importeField
        End Get
        Set(ByVal value As Decimal)
            Me.importeField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ImporteSpecified As Boolean
        Get
            Return Me.importeFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.importeFieldSpecified = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteConceptoParteInformacionAduanera
    Private numeroPedimentoField As String

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NumeroPedimento As String
        Get
            Return Me.numeroPedimentoField
        End Get
        Set(ByVal value As String)
            Me.numeroPedimentoField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteImpuestos
    Private retencionesField As ComprobanteImpuestosRetencion()
    Private trasladosField As ComprobanteImpuestosTraslado()
    Private totalImpuestosRetenidosField As Decimal
    Private totalImpuestosRetenidosFieldSpecified As Boolean
    Private totalImpuestosTrasladadosField As Decimal
    Private totalImpuestosTrasladadosFieldSpecified As Boolean

    <System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable:=False)>
    Public Property Retenciones As ComprobanteImpuestosRetencion()
        Get
            Return Me.retencionesField
        End Get
        Set(ByVal value As ComprobanteImpuestosRetencion())
            Me.retencionesField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable:=False)>
    Public Property Traslados As ComprobanteImpuestosTraslado()
        Get
            Return Me.trasladosField
        End Get
        Set(ByVal value As ComprobanteImpuestosTraslado())
            Me.trasladosField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalImpuestosRetenidos As Decimal
        Get
            Return Me.totalImpuestosRetenidosField
        End Get
        Set(ByVal value As Decimal)
            Me.totalImpuestosRetenidosField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property TotalImpuestosRetenidosSpecified As Boolean
        Get
            Return Me.totalImpuestosRetenidosFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.totalImpuestosRetenidosFieldSpecified = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalImpuestosTrasladados As Decimal
        Get
            Return Me.totalImpuestosTrasladadosField
        End Get
        Set(ByVal value As Decimal)
            Me.totalImpuestosTrasladadosField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property TotalImpuestosTrasladadosSpecified As Boolean
        Get
            Return Me.totalImpuestosTrasladadosFieldSpecified
        End Get
        Set(ByVal value As Boolean)
            Me.totalImpuestosTrasladadosFieldSpecified = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteImpuestosRetencion
    Private impuestoField As String
    Private importeField As Decimal

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Impuesto As String
        Get
            Return Me.impuestoField
        End Get
        Set(ByVal value As String)
            Me.impuestoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Importe As Decimal
        Get
            Return Me.importeField
        End Get
        Set(ByVal value As Decimal)
            Me.importeField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteImpuestosTraslado
    Private impuestoField As String
    Private tipoFactorField As String
    Private tasaOCuotaField As Decimal
    Private importeField As Decimal

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Impuesto As String
        Get
            Return Me.impuestoField
        End Get
        Set(ByVal value As String)
            Me.impuestoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TipoFactor As String
        Get
            Return Me.tipoFactorField
        End Get
        Set(ByVal value As String)
            Me.tipoFactorField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TasaOCuota As Decimal
        Get
            Return Me.tasaOCuotaField
        End Get
        Set(ByVal value As Decimal)
            Me.tasaOCuotaField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Importe As Decimal
        Get
            Return Me.importeField
        End Get
        Set(ByVal value As Decimal)
            Me.importeField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteComplemento
    Private anyField As System.Xml.XmlElement()

    <System.Xml.Serialization.XmlAnyElementAttribute()>
    Public Property Any As System.Xml.XmlElement()
        Get
            Return Me.anyField
        End Get
        Set(ByVal value As System.Xml.XmlElement())
            Me.anyField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")>
<System.SerializableAttribute()>
<System.Diagnostics.DebuggerStepThroughAttribute()>
<System.ComponentModel.DesignerCategoryAttribute("code")>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteAddenda
    Private anyField As System.Xml.XmlElement()

    <System.Xml.Serialization.XmlAnyElementAttribute()>
    Public Property Any As System.Xml.XmlElement()
        Get
            Return Me.anyField
        End Get
        Set(ByVal value As System.Xml.XmlElement())
            Me.anyField = value
        End Set
    End Property


End Class
