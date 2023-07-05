Imports System.Data.SqlClient
Public Class ConBD
    'CONEXIÓN   
    Public con As String
    Public MiConexion As New SqlConnection
    Public Sub Conexion()
        Dim ServidorSQL As String
        ServidorSQL = "DESKTOP-2INU24R\DESCONTESTER"
        Dim BD As String
        BD = "SBODemoMX"
        Dim UsuarioSQL As String
        UsuarioSQL = "sa"
        Dim PassSQL As String
        PassSQL = "Admin123"

        'con = "data source=" & ServidorSQL & ";initial catalog='" & BD & "'; User Id=" & UsuarioSQL & ";password=" & PassSQL & ""
        con = "data source=" & My.Settings.ServidorSQL & ";initial catalog='" & My.Settings.Empresa & "'; User Id=" & My.Settings.UsuarioSQL & ";password=" & My.Settings.PassSQL & ""

    End Sub

    
End Class
