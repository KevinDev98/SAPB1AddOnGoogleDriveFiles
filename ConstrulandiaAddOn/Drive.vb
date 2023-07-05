Imports Google.Apis.Auth
Imports Google.Apis.Download

' Your original code was missing the following "Imports":
Imports Google.Apis.Drive.v2
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports System.Threading
Imports Google.Apis.Drive.v2.Data
Public Class Drive
    Private Service As DriveService = New DriveService
    Public Sub CreateService()
        Dim ClientId = "1033848810809-fhot6cc5lptoag0poj394chd5rjahhag.apps.googleusercontent.com"
        Dim ClientSecret = "ll6xZwD43sGl9FlJXXNKnxD1"
        Dim MyUserCredential As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With {.ClientId = ClientId, .ClientSecret = ClientSecret}, {DriveService.Scope.Drive}, "user", CancellationToken.None).Result
        Service = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = MyUserCredential, .ApplicationName = "Google Drive VB Dot Net"})
    End Sub

    Public Sub UploadFile(FilePath As String)
        'Not needed from a Console app:
        'Me.Cursor = Cursors.WaitCursor

        If Service.ApplicationName <> "Google Drive VB Dot Net" Then CreateService()

        Dim TheFile As New File()
        TheFile.Title = "My document.pdf"
        TheFile.Description = "A test document"
        TheFile.MimeType = ""

        Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(FilePath)
        Dim Stream As New System.IO.MemoryStream(ByteArray)

        Dim UploadRequest As FilesResource.InsertMediaUpload = Service.Files.Insert(TheFile, Stream, TheFile.MimeType)

        '' You were mmissing the Upload part!
        UploadRequest.Upload()
        Dim file As File = UploadRequest.ResponseBody

        ' Not needed from a Console app:
        'Me.Cursor = Cursors.Default

        MsgBox("Upload Finished")
        Process.Start("https://drive.google.com/drive/my-drive")
    End Sub
End Class
