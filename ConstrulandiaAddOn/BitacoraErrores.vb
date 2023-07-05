Imports System.IO

Public Class BitacoraErrores

    Public Sub CrearBitacora(cadena As String)
        Dim fecha As String = DateTime.Now.ToString()
        'Dim path As String = "C:\Users\Descon5\Desktop\KevinG\Proyectos Descon 2020\CONSTRULANDIA\Bitacora\" & "bitacora_Construlandia1.txt"
        Dim path As String = My.Settings.LogErrores & "Log-Errores_AddOn.txt"
        If Not File.Exists(path) Then
            ' Create a file to write to.
            Using sw As StreamWriter = File.CreateText(path)
                sw.WriteLine("**** BITÁCORA DE ERRORES Y EXCEPCIONES  ****")
                sw.WriteLine(fecha & ": " & cadena)
            End Using
        Else
            Using sw As StreamWriter = File.AppendText(path)
                sw.WriteLine(fecha & ": " & cadena)
            End Using
        End If
    End Sub

End Class
