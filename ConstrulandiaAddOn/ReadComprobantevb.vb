Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml.Serialization
Imports SAPbouiCOM.Framework
Public Class ReadComprobantevb
    'crear un objeto el cual tendrá el resultado final, este objeto es el principal
    Public oComprobante As Comprobante

    Private WithEvents SBO_Application As SAPbouiCOM.Application
    Public Function Metodo(ByVal ruta As String)
        Try
            oComprobante = Nothing
            'pon la ruta donde tienes tu archivo XML Timbrado
            Dim path As String = ruta '"C:\Users\Descon5\Desktop\KevinG\BGP140314BQ5FB16197.xml"
            'creamos un objeto XMLSerializer para deserializar
            Dim oSerializer As New XmlSerializer(GetType(Comprobante))
            'creamos un flujo el cual recibe nuestro xml
            Using reader As New StreamReader(path)
                'aqui deserializamos
                oComprobante = CType(oSerializer.Deserialize(reader), Comprobante)
                'Deserializamos el complemento timbre fiscal
                For Each oComplemento In oComprobante.Complemento
                    For Each oComplementoInterior In oComplemento.Any
                        'si el complemento es TimbreFiscalDigital lo deserializamos
                        If oComplementoInterior.Name.Contains("TimbreFiscalDigital") Then

                            'Objeto para aplicar ahora la deserialización del complemento timbre
                            Dim oSerializerComplemento As New XmlSerializer(GetType(TimbreFiscalDigital))
                            'creamos otro flujo para el complemento
                            Using readerComplemento = New StringReader(oComplementoInterior.OuterXml)
                                'y por ultimo deserializamos el complemento
                                oComprobante.TimbreFiscalDigital = CType(oSerializerComplemento.Deserialize(readerComplemento), TimbreFiscalDigital)

                            End Using
                        End If
                    Next
                Next

            End Using
        Catch ex As Exception
            'SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
            'MsgBox("El archivo XML no contiene el formato de una factura")
            oComprobante = Nothing
        End Try
        Return oComprobante
    End Function

End Class
