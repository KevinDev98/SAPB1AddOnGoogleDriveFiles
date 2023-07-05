Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Http
Imports System.Text
Imports System.Net.Http.Headers
Imports System.Threading.Tasks

Public Class SAT
    Public Async Function Soap(RFC_EMISOR As String, RFC_RECEPTOR As String, UUID As String, TOTAL As String) As Task(Of String)

        Dim soapString As String = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">" & vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & "<soapenv:Header/>" & vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "<soapenv:Body>" & vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "<tem:Consulta>" & vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "<tem:expresionImpresa>" & vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & " <![CDATA[?re=" & RFC_EMISOR.TrimStart().TrimEnd() & "&rr=" + RFC_RECEPTOR.TrimStart().TrimEnd() & "&tt=" + TOTAL.TrimStart().TrimEnd() & "&id=" + UUID.TrimStart().TrimEnd() & "]]></tem:expresionImpresa></tem:Consulta></soapenv:Body></soapenv:Envelope>"
        Dim response As HttpResponseMessage = Await PostXmlRequest("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc", soapString)
        Return Await response.Content.ReadAsStringAsync()
    End Function

    Public Async Function PostXmlRequest(baseUrl As String, xmlString As String) As Task(Of HttpResponseMessage)

        Dim client As HttpClient = New HttpClient()
        Dim url As String = baseUrl

        Dim content As HttpContent = New StringContent(xmlString)
        content.Headers.ContentType = New MediaTypeWithQualityHeaderValue("text/xml")
        content.Headers.Add("SOAPAction", "http://tempuri.org/IConsultaCFDIService/Consulta")

        Dim resp As HttpResponseMessage
        resp = Await client.PostAsync(baseUrl, content)
        Return resp

    End Function
End Class
