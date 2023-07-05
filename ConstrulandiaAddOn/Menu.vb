Imports SAPbouiCOM.Framework
Imports Google.Apis.Auth
Imports Google.Apis.Download
Imports Google.Apis.Drive.v2
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports System.Threading
Imports Google.Apis.Drive.v2.Data
Imports System.Data.SqlClient
Imports SAPbobsCOM
Imports System.Threading.Tasks
Imports System.Xml
Imports System.Text
Imports System.Net.Http
Imports iTextSharp.text.pdf
Imports System.Windows.Forms



Namespace ConstrulandiaAddOn
    Public Class Menu

        Private WithEvents SBO_Application As SAPbouiCOM.Application
        Private Service As DriveService = New DriveService
        'Dim oRecordset As SAPbobsCOM.Recordset
        Dim documento As SAPbobsCOM.Documents
        Dim proceso As String
        Dim arr(3) As String
        Dim rutas As String
        Dim cont_Entrar As Integer = 0
        Dim Credito As String
        Dim AnticipoSN As String
        ''Crear el Objeto SN (BP)
        Dim UF As SAPbobsCOM.UserFieldsMD
        Dim CardCode As String 'SAPbobsCOM.BusinessPartners
        Public con As String
        Dim CardCodeSN, DocNum, DocDate As String
        Public MiConexion As New SqlConnection
        Public Base As String
        Public BitError1 = New BitacoraErrores()
        Public Carpeta As String
        Dim validar As Boolean = False
        Dim condb As String
        '--Para la parte de Pediddos
        Dim validaPedido As String
        Dim NPedidoBD As String
        Dim rutaArchivoPedidoBD As String
        Dim rutaArchivoPedido As String
        Dim arr_combustible As New List(Of String)
        Dim carpetaFinal As String
        Dim NewDirectory = Nothing
        Dim rutaValia As String
        Dim URLBusqueda As String
        Public Sub CreateService()
            Dim ClientId = My.Settings.IdCliente '"1033848810809-fhot6cc5lptoag0poj394chd5rjahhag.apps.googleusercontent.com" 'CONSTRULANDIA 341251384514-khurlp5833i941b7402c2qq99nku1rk8.apps.googleusercontent.com
            Dim ClientSecret = My.Settings.IdSecret '"ll6xZwD43sGl9FlJXXNKnxD1"   'CONSTRULANDIA Yi1NtIKq9tx6qlVKWOeiRfG4
            Dim MyUserCredential As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With {.ClientId = ClientId, .ClientSecret = ClientSecret}, {DriveService.Scope.Drive}, "user", CancellationToken.None).Result
            Service = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = MyUserCredential, .ApplicationName = "Google Drive VB Dot Net"})
        End Sub

        Sub New()
            SBO_Application = SAPbouiCOM.Framework.Application.SBO_Application

        End Sub
        Public Sub conexion(ByVal nombre, ByVal usuario)
            Base = nombre
            Carpeta = usuario
            condb = "data source=" & My.Settings.ServidorSQL & ";initial catalog='" & Base & "'; User Id=" & My.Settings.UsuarioSQL & ";password=" & My.Settings.PassSQL & "" '"Data Source=DESKTOP-2INU24R\DESCONTESTER;Initial Catalog=SBODemoMX;Persist Security Info=True;User ID=sa;Password=Admin123"
        End Sub
        Sub setFilters()
            Dim lofilter As SAPbouiCOM.EventFilter
            Dim lofilters As SAPbouiCOM.EventFilters
            Dim lofilter2 As SAPbouiCOM.EventFilter
            Dim lofilters2 As SAPbouiCOM.EventFilters
            Try
                lofilters = New SAPbouiCOM.EventFilters
                lofilter = lofilter.Add(SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED)
                lofilter = lofilter.Add(SAPbouiCOM.BoEventTypes.et_ALL_EVENTS)

                lofilter.AddEx(143)
                lofilters2 = New SAPbouiCOM.EventFilters
                lofilter2 = lofilter.Add(SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED)
                lofilter2 = lofilter.Add(SAPbouiCOM.BoEventTypes.et_ALL_EVENTS)
                lofilter2.AddEx(133)
            Catch ex As Exception
                BitError1.CrearBitacora(ex.Message)
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox(ex.ToString(), 1, "Error Filtros", "", "")
            End Try
        End Sub


        Private Sub SBO_Application_RightClickEvent(ByRef eventInfo As SAPbouiCOM.ContextMenuInfo, ByRef BubbleEvent As Boolean) Handles SBO_Application.RightClickEvent

            Try
                SBO_Application.Menus.RemoveEx("AbrirBT")

            Catch ex As Exception
                '' MessageBox.Show(ex.Message)
            End Try
            Dim oForm As SAPbouiCOM.Form
            Dim enlace1 As SAPbouiCOM.EditText
            Dim enlace2 As SAPbouiCOM.EditText
            Dim enlace3 As SAPbouiCOM.EditText
            Dim enlace4 As SAPbouiCOM.EditText
            Try
                'PEDIDO
                oForm = SBO_Application.Forms.GetFormByTypeAndCount(-142, 1)
                enlace1 = oForm.Items.Item("U_Enlace").Specific
                enlace2 = oForm.Items.Item("U_Enlace2").Specific
                enlace3 = oForm.Items.Item("U_Enlace3").Specific
                enlace3 = oForm.Items.Item("U_Enlace4").Specific
            Catch ex As Exception

            End Try
            Try
                'ENTRADA DE MERCANCIA
                oForm = SBO_Application.Forms.GetFormByTypeAndCount(-143, 1)
                enlace1 = oForm.Items.Item("U_Enlace").Specific
                enlace2 = oForm.Items.Item("U_Enlace2").Specific
                enlace3 = oForm.Items.Item("U_Enlace3").Specific
                enlace3 = oForm.Items.Item("U_Enlace4").Specific
            Catch ex As Exception

            End Try
            Try
                'FACTURA DE PROVEEDORES
                oForm = SBO_Application.Forms.GetFormByTypeAndCount(-141, 1)
                enlace1 = oForm.Items.Item("U_Enlace").Specific
                enlace2 = oForm.Items.Item("U_Enlace2").Specific
                enlace3 = oForm.Items.Item("U_Enlace3").Specific
                enlace3 = oForm.Items.Item("U_Enlace4").Specific
            Catch ex As Exception

            End Try
            Try
                'ENTREGA
                oForm = SBO_Application.Forms.GetFormByTypeAndCount(-140, 1)
                enlace1 = oForm.Items.Item("U_Enlace").Specific
                enlace2 = oForm.Items.Item("U_Enlace2").Specific
                enlace3 = oForm.Items.Item("U_Enlace3").Specific
                enlace3 = oForm.Items.Item("U_Enlace4").Specific
            Catch ex As Exception

            End Try
            If eventInfo.ItemUID = "U_Enlace" Or eventInfo.ItemUID = "U_Enlace2" Or eventInfo.ItemUID = "U_Enlace3" Or eventInfo.ItemUID = "U_Enlace4" Then
                If (eventInfo.BeforeAction = True) Then
                    Dim oMenuItem As SAPbouiCOM.MenuItem
                    Dim oMenus As SAPbouiCOM.Menus
                    If (eventInfo.ItemUID = "U_Enlace") Then
                        URLBusqueda = enlace1.Value
                    End If
                    If (eventInfo.ItemUID = "U_Enlace2") Then
                        URLBusqueda = enlace2.Value
                    End If
                    If (eventInfo.ItemUID = "U_Enlace3") Then
                        URLBusqueda = enlace2.Value
                    End If
                    If (eventInfo.ItemUID = "U_Enlace4") Then
                        URLBusqueda = enlace2.Value
                    End If
                    Try
                        Dim oCreationPackage As SAPbouiCOM.MenuCreationParams
                        oCreationPackage = SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)

                        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING
                        oCreationPackage.UniqueID = "AbrirBT"
                        oCreationPackage.String = "Abrir en el Navegador"

                        oCreationPackage.Enabled = True

                        oMenuItem = SBO_Application.Menus.Item("1280") 'Data'
                        oMenus = oMenuItem.SubMenus
                        oMenus.AddEx(oCreationPackage)

                    Catch ex As Exception
                        ' MessageBox.Show(ex.Message)
                    End Try
                Else
                    Dim oMenuItem As SAPbouiCOM.MenuItem
                    Dim oMenus As SAPbouiCOM.Menus


                    Try
                        SBO_Application.Menus.RemoveEx("AbrirBT")

                    Catch ex As Exception
                        '' MessageBox.Show(ex.Message)
                    End Try

                End If
            End If
        End Sub
        Private Sub SBO_Application_ItemEvent(ByVal FormUID As String, ByRef pVal As SAPbouiCOM.ItemEvent, ByRef BubbleEvent As Boolean) Handles SBO_Application.ItemEvent

            Dim oButton As SAPbouiCOM.Button
            Dim oForm As SAPbouiCOM.Form
            Dim oMatrix As SAPbouiCOM.Matrix
            Dim oCardCode As SAPbouiCOM.EditText
            Dim oDocNum As SAPbouiCOM.EditText
            Dim oDocDate As SAPbouiCOM.EditText
            Dim validarRuta As Boolean = False

            Try

                '---VALIDACION DE COMBUSTIBLE
                If pVal.FormType = 142 And pVal.Before_Action = True And pVal.EventType = SAPbouiCOM.BoEventTypes.et_COMBO_SELECT And pVal.ItemUID = "10000329" Then
                    Try
                        oForm = SBO_Application.Forms.GetFormByTypeAndCount(142, 1)
                        oDocNum = oForm.Items.Item("8").Specific
                        Select Case pVal.PopUpIndicator
                            Case 0
                                ' SBO_Application.MessageBox("select 0")
                                'Return

                            Case 1
                                If Base = "SBO_CONSTRULANDIA" Then
                                    NPedidoBD = "SELECT COUNT(*)[CONT] FROM OPOR T0 WITH (NOLOCK) INNER JOIN POR1 T1 WITH (NOLOCK) ON  T0.DocEntry =T1.DocEntry WHERE T0.DocNum ='" & oDocNum.Value & "' AND T1.ItemCode='SE003'"
                                    Dim dbConnC As New SqlConnection(condb)
                                    Dim Consulta As New SqlConnection
                                    Consulta.ConnectionString = condb
                                    Dim dbCommand2 As New SqlCommand(NPedidoBD, dbConnC)
                                    dbConnC.Open()
                                    validaPedido = Convert.ToString(dbCommand2.ExecuteScalar)
                                    dbConnC.Close()
                                    '--VALIDA RUTA DEL ARCHIVO
                                    rutaArchivoPedidoBD = "SELECT (CASE WHEN U_Enlace IS NULL THEN 0 ELSE 1 END) AS PartNumber FROM OPOR T0  WITH (NOLOCK) WHERE T0.DocNum ='" & oDocNum.Value & "'"
                                    Dim dbConn As New SqlConnection(condb)
                                    Dim Consulta2 As New SqlConnection
                                    Consulta2.ConnectionString = condb
                                    Dim dbCommand3 As New SqlCommand(rutaArchivoPedidoBD, dbConn)
                                    dbConn.Open()
                                    rutaArchivoPedido = Convert.ToString(dbCommand3.ExecuteScalar)
                                    dbConn.Close()
                                End If
                                If Base = "SBODemoMX" Then
                                    NPedidoBD = "SELECT COUNT(*)[CONT] FROM OPOR T0 WITH (NOLOCK) INNER JOIN POR1 T1 WITH (NOLOCK) ON  T0.DocEntry =T1.DocEntry WHERE T0.DocNum ='" & oDocNum.Value & "' AND T1.ItemCode='A00004'"
                                    Dim dbConnC As New SqlConnection(condb)
                                    Dim Consulta As New SqlConnection
                                    Consulta.ConnectionString = condb
                                    Dim dbCommand2 As New SqlCommand(NPedidoBD, dbConnC)
                                    dbConnC.Open()
                                    validaPedido = Convert.ToString(dbCommand2.ExecuteScalar)
                                    dbConnC.Close()
                                    '--VALIDA RUTA DEL ARCHIVO
                                    rutaArchivoPedidoBD = "SELECT (CASE WHEN U_Enlace IS NULL THEN 0 ELSE 1 END) AS PartNumber FROM OPOR T0  WITH (NOLOCK) WHERE T0.DocNum ='" & oDocNum.Value & "'"
                                    Dim dbConn As New SqlConnection(condb)
                                    Dim Consulta2 As New SqlConnection
                                    Consulta2.ConnectionString = condb
                                    Dim dbCommand3 As New SqlCommand(rutaArchivoPedidoBD, dbConn)
                                    dbConn.Open()
                                    rutaArchivoPedido = Convert.ToString(dbCommand3.ExecuteScalar)
                                    dbConn.Close()
                                End If




                                If Base = "ILM" Then
                                    NPedidoBD = "SELECT COUNT(*)[CONT] FROM OPOR T0 WITH (NOLOCK) INNER JOIN POR1 T1 WITH (NOLOCK) ON  T0.DocEntry =T1.DocEntry WHERE T0.DocNum='" & oDocNum.Value & "' AND T1.ItemCode='DI0001'"
                                    Dim dbConnC As New SqlConnection(condb)
                                    Dim Consulta As New SqlConnection
                                    Consulta.ConnectionString = condb
                                    Dim dbCommand2 As New SqlCommand(NPedidoBD, dbConnC)
                                    dbConnC.Open()
                                    validaPedido = Convert.ToString(dbCommand2.ExecuteScalar)
                                    dbConnC.Close()
                                    '--VALIDA RUTA DEL ARCHIVO
                                    rutaArchivoPedidoBD = "SELECT (CASE WHEN U_Enlace IS NULL THEN 0 ELSE 1 END) AS PartNumber FROM OPOR T0  WITH (NOLOCK) WHERE T0.DocNum ='" & oDocNum.Value & "'"
                                    Dim dbConn As New SqlConnection(condb)
                                    Dim Consulta2 As New SqlConnection
                                    Consulta2.ConnectionString = condb
                                    Dim dbCommand3 As New SqlCommand(rutaArchivoPedidoBD, dbConn)
                                    dbConn.Open()
                                    rutaArchivoPedido = Convert.ToString(dbCommand3.ExecuteScalar)
                                    dbConn.Close()
                                End If
                                If validaPedido <> "0" And rutaArchivoPedido = "0" Then
                                    SBO_Application.StatusBar.SetText("El Pedido debera contener al menos un archivo PDF", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    BubbleEvent = False
                                End If
                            Case 2

                        End Select
                    Catch ex As Exception

                        BitError1.CrearBitacora(ex.Message)
                    End Try
                End If
                ''--VALIDACION DE COMBUSTIBLE
                'If pVal.MenuUID = "772" Then
                '    '  oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)
                '    Dim oMenuItem As SAPbouiCOM.MenuItem
                '    Dim oMenus As SAPbouiCOM.Menus
                '    MsgBox(pVal.EventType.ToString())
                '    ' Create menu popup MyUserMenu and add it to Tools menu
                '    'Dim oCreationPackage As SAPbouiCOM.MenuCreationParams
                '    'oCreationPackage = SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)
                '    'oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP
                '    'oCreationPackage.UniqueID = "AlwaysAppear"
                '    'oCreationPackage.String = "Always Appear"
                '    'oCreationPackage.Enabled = True
                '    'oMenuItem = SBO_Application.Menus.Item("1280")
                '    'oMenus = oMenuItem.SubMenus
                '    'oMenus.AddEx(oCreationPackage)
                '    ' Process.Start("http://www.google.com/")
                'End If

                'PEDIDO PARA ACTUALIZAR VALIDACIONES
                If pVal.FormType = 142 And pVal.Before_Action = True And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)
                    oMatrix = oForm.Items.Item("1320002138").Specific
                    oCardCode = oForm.Items.Item("4").Specific
                    oDocNum = oForm.Items.Item("8").Specific
                    oDocDate = oForm.Items.Item("10").Specific
                    oButton = oForm.Items.Item("1").Specific
                    CardCodeSN = oCardCode.String
                    DocNum = oDocNum.Value.ToString()
                    DocDate = oDocDate.Value.ToString()
                    proceso = oButton.Caption
                    arr_combustible = New List(Of String)
                    If proceso = "Actualizar" And oForm.Title.ToLower.Contains("pedido") Then
                        'VERIFICACION DE LA API DE DRIVE
                        For j As Integer = 1 To oMatrix.VisualRowCount


                            rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                            Dim i As Integer
                            i = j - 1
                            arr_combustible.Add(rutas)
                            Try
                                Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(rutas)

                            Catch ex As Exception
                                validarRuta = True
                                BitError1.CrearBitacora(ex.Message)
                            End Try
                            If oMatrix.RowCount = 1 Then
                                rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                                Dim ext As String
                                ext = oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value
                                If (ext.ToLower <> "pdf") Then
                                    SBO_Application.StatusBar.SetText("El Archivo debe ser PDF", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    oMatrix.DeleteRow(oMatrix.VisualRowCount)
                                    BubbleEvent = False
                                    Return
                                End If
                            End If
                            Do While oMatrix.RowCount = 1
                                oMatrix.DeleteRow(oMatrix.VisualRowCount)
                            Loop
                        Next


                        If (validarRuta <> False) Then
                            SBO_Application.StatusBar.SetText("El archivo se debera tomar de una ruta valida", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                    End If
                End If


                'ENTRADA DE MERCANCIAS CREAR VALIDACIONES
                If pVal.FormType = 143 And pVal.Before_Action = True And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)
                    oMatrix = oForm.Items.Item("1320002138").Specific
                    oCardCode = oForm.Items.Item("4").Specific
                    oDocNum = oForm.Items.Item("8").Specific
                    oDocDate = oForm.Items.Item("10").Specific
                    oButton = oForm.Items.Item("1").Specific
                    CardCodeSN = oCardCode.String
                    DocNum = oDocNum.Value.ToString()
                    DocDate = oDocDate.Value.ToString()
                    proceso = oButton.Caption

                    If proceso = "Crear" Then
                        'VERIFICACION DE LA API DE DRIVE



                        'PARA CARGAR ARCHIVOS

                        If (oMatrix.VisualRowCount > 1) Then
                            SBO_Application.StatusBar.SetText("Número de archivos permitido, excedido. Eliminar archibos sobrantes", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                        If oMatrix.VisualRowCount = 0 And proceso = "Crear" And oForm.Title = "Entrada de mercancías" And Not oForm.Title.Contains("Cancel") Then
                            SBO_Application.StatusBar.SetText("Falta Archivo de aprobación de entrega", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                        For j As Integer = 1 To oMatrix.VisualRowCount


                            rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                            Dim i As Integer
                            i = j - 1
                            arr(i) = rutas
                            Try
                                Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(rutas)
                            Catch ex As Exception
                                validarRuta = True
                            End Try
                            If oMatrix.RowCount = 1 Then
                                rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                                Dim ext As String
                                ext = oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value
                                If (ext.ToLower <> "pdf") Then
                                    SBO_Application.StatusBar.SetText("El Archivo debe ser PDF", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    oMatrix.DeleteRow(oMatrix.VisualRowCount)
                                    BubbleEvent = False
                                    Return
                                End If
                            End If
                            Do While oMatrix.RowCount = 1
                                oMatrix.DeleteRow(oMatrix.VisualRowCount)
                            Loop
                        Next


                        If (validarRuta <> False And Not oForm.Title.Contains("Cancel")) Then
                            SBO_Application.StatusBar.SetText("El archivo se debera tomar de una ruta valida", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                    End If
                End If

                'ENTRADA DE MERCANCIAS PARA  ACTUALIZAR VALIDACIONES
                If pVal.FormType = 143 And pVal.Before_Action = True And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)
                    oMatrix = oForm.Items.Item("1320002138").Specific
                    oCardCode = oForm.Items.Item("4").Specific
                    oDocNum = oForm.Items.Item("8").Specific
                    oDocDate = oForm.Items.Item("10").Specific
                    oButton = oForm.Items.Item("1").Specific
                    CardCodeSN = oCardCode.String
                    DocNum = oDocNum.Value.ToString()
                    DocDate = oDocDate.Value.ToString()
                    proceso = oButton.Caption

                    If proceso = "Actualizar" Then
                        'VERIFICACION DE LA API DE DRIVE
                        'PARA CARGAR ARCHIVOS

                        If (oMatrix.VisualRowCount > 1) Then
                            SBO_Application.StatusBar.SetText("Número de archivos permitido, excedido. Eliminar archivos sobrantes", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                        If oMatrix.VisualRowCount = 0 And proceso = "Actualizar" And oForm.Title = "Entrada de mercancías" Then
                            SBO_Application.StatusBar.SetText("Falta Archivo de aprobación de entrega", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                        For j As Integer = 1 To oMatrix.VisualRowCount
                            rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                            Dim i As Integer
                            i = j - 1
                            arr(i) = rutas
                            Try
                                Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(rutas)
                            Catch ex As Exception
                                validarRuta = True
                            End Try
                            If oMatrix.RowCount = 1 Then
                                rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                                Dim ext As String
                                ext = oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value
                                If (ext.ToLower <> "pdf") Then
                                    SBO_Application.StatusBar.SetText("El Archivo debe ser PDF", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    oMatrix.DeleteRow(oMatrix.VisualRowCount)
                                    BubbleEvent = False
                                    Return
                                End If
                            End If
                            Do While oMatrix.RowCount = 1
                                oMatrix.DeleteRow(oMatrix.VisualRowCount)
                            Loop
                        Next


                        If (validarRuta <> False) Then
                            SBO_Application.StatusBar.SetText("El archivo se debera tomar de una ruta valida", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                    End If
                End If


                '---FACTURA DE PROVEEDORES CREAR VALIDACIONES
                If pVal.FormType = 141 And pVal.Before_Action = True And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)
                    oMatrix = oForm.Items.Item("1320002138").Specific
                    oCardCode = oForm.Items.Item("4").Specific
                    oDocNum = oForm.Items.Item("8").Specific
                    oDocDate = oForm.Items.Item("10").Specific
                    oButton = oForm.Items.Item("1").Specific

                    CardCodeSN = oCardCode.String
                    DocNum = oDocNum.Value.ToString()
                    DocDate = oDocDate.Value.ToString()
                    proceso = oButton.Caption
                    If proceso = "Crear" Then



                        If (oMatrix.VisualRowCount >= 3) Then
                            SBO_Application.StatusBar.SetText("Número de archivos permitido, excedido. Eliminar archivos de sobra", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                        If oMatrix.VisualRowCount = 0 And proceso = "Crear" And oForm.Title = "Factura de proveedores" Then
                            SBO_Application.StatusBar.SetText("FALTA ANEXAR LOS ARCHIVOS CORRESPONDIENTES 0", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                        'If oMatrix.VisualRowCount > 2 And oForm.Title = "Factura de proveedores" Then
                        '    SBO_Application.StatusBar.SetText("FALTA ANEXAR  ARCHIVOS CORRESPONDIENTES", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                        '    'SBO_Application.MessageBox("FALTA ANEXAR LOS ARCHIVOS CORRESPONDIENTES")
                        '    BubbleEvent = False
                        '    Return
                        'End If
                        For j As Integer = 1 To oMatrix.VisualRowCount
                            rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                            Dim i As Integer
                            i = j - 1
                            arr(i) = rutas
                            validarRuta = False

                            Try
                                Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(rutas)
                            Catch ex As Exception
                                validarRuta = True
                            End Try
                            'no suba mas de 3 archivo entrada mercancia/factura 3 o 4 check
                            If oMatrix.RowCount = 2 Or oMatrix.RowCount = 3 Then
                                rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                                Dim ext As String
                                ext = oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value
                                'If Not arr(i).Contains("xml") Or Not arr(i).Contains("pdf") Then
                                '    BubbleEvent = False
                                '    SBO_Application.StatusBar.SetText("Se debe incluir por lo menos un archivo PDF y 1 archivo XML", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                'End If
                                Dim validar1 As Integer = 0
                                Dim validar2 As Integer = 0

                                For k As Integer = 1 To oMatrix.RowCount
                                    Dim verificaxmlpdf As String
                                    verificaxmlpdf = oMatrix.Columns.Item("1320000005").Cells.Item(k).Specific.Value
                                    If Not verificaxmlpdf.ToLower.Contains("pdf") Then
                                        validar1 = validar1 + 1
                                    End If
                                    If Not verificaxmlpdf.ToLower.Contains("xml") Then
                                        validar2 = validar2 + 1
                                    End If
                                    'If k = 1 Then
                                    '    If Not verificaxmlpdf.ToLower.Contains("pdf") Then
                                    '        If Not verificaxmlpdf.ToLower.Contains("xml") Then
                                    '            validar = True

                                    '        End If
                                    '    End If
                                    'End If
                                    'If k = 2 Then
                                    '    If Not verificaxmlpdf.ToLower.Contains("xml") Then
                                    '        If verificaxmlpdf.ToLower.Contains("pdf") Then
                                    '            validar = True

                                    '        End If
                                    '    End If
                                    'End If
                                Next
                                If (validar1 >= 2 Or validar2 >= 2) Then
                                    SBO_Application.StatusBar.SetText("Se debe incluir por lo menos un archivo PDF y 1 archivo XML", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    BubbleEvent = False
                                    Return
                                End If
                                If (validarRuta <> False) Then
                                    SBO_Application.StatusBar.SetText("El archivo se debera tomar de una ruta valida", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    BubbleEvent = False
                                    Return
                                End If
                                If (ext.ToLower = "pdf") Then
                                    BubbleEvent = True
                                ElseIf (ext.ToLower = "xml") Then
                                    BubbleEvent = True
                                    Dim readComp = New ReadComprobantevb()
                                    'readComp.Metodo(rutas)
                                    Dim oComprobante As Comprobante
                                    oComprobante = readComp.Metodo(rutas)
                                    If oComprobante Is Nothing Then
                                        SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                        BubbleEvent = False
                                        Return
                                    Else
                                        Dim SATSAP = New SAT()
                                        Dim results As Task(Of String) = New SAT().Soap(readComp.oComprobante.Emisor.Rfc.ToString(), readComp.oComprobante.Receptor.Rfc.ToString(), readComp.oComprobante.TimbreFiscalDigital.UUID.ToString(), readComp.oComprobante.Total.ToString())
                                        Dim xDoc As New XmlDocument()
                                        xDoc.LoadXml(results.Result)
                                        Dim XMLstatus As XmlNodeList = xDoc.GetElementsByTagName("a:CodigoEstatus")
                                        Dim XMLcancelable As XmlNodeList = xDoc.GetElementsByTagName("a:EsCancelable")
                                        Dim XMLestado As XmlNodeList = xDoc.GetElementsByTagName("a:Estado")
                                        Dim XMLstatusCancelacion As XmlNodeList = xDoc.GetElementsByTagName("a:EstatusCancelacion")
                                        Dim codigo As String = XMLstatus.Cast(Of XmlNode)().LastOrDefault().InnerText
                                        Dim cancelacion As String = XMLcancelable.Cast(Of XmlNode)().LastOrDefault().InnerText
                                        Dim estado As String = XMLestado.Cast(Of XmlNode)().LastOrDefault().InnerText
                                        Dim estatus As String = XMLstatusCancelacion.Cast(Of XmlNode)().LastOrDefault().InnerText

                                        Try
                                            If (codigo <> "S - Comprobante obtenido satisfactoriamente." And estado <> "Vigente") Then
                                                SBO_Application.StatusBar.SetText("El archivo XML de la factura es Apocrifo o la factura no es vigente", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            Else
                                                SBO_Application.StatusBar.SetText("XML VIGENTE", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success)
                                                BubbleEvent = True
                                            End If
                                            If readComp.oComprobante.Emisor.Rfc.ToString() = "" Then
                                                SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            End If
                                            If readComp.oComprobante.Receptor.Rfc.ToString() = "" Then
                                                SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            End If
                                            If readComp.oComprobante.TimbreFiscalDigital.UUID.ToString() = "" Then
                                                SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            End If
                                            If readComp.oComprobante.Total.ToString() = "" Then
                                                SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            End If
                                        Catch ex As Exception
                                            'SBO_Application.MessageBox(ex.Message)
                                            BubbleEvent = False
                                            Return
                                        End Try
                                    End If
                                Else
                                    SBO_Application.StatusBar.SetText("Error en la exxtensión de los archivos. Revisar apartado de anexos", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    'SBO_Application.MessageBox("Debe haber 2 archivos pdf y 1 xml")
                                    oMatrix.DeleteRow(ext.ToLower <> "pdf")
                                    BubbleEvent = False
                                    Return
                                End If
                            End If
                        Next
                        If oMatrix.RowCount >= 2 Then
                            Do While oMatrix.RowCount > 0
                                oMatrix.DeleteRow(oMatrix.VisualRowCount)
                            Loop
                        End If
                    End If

                End If


                '---FACTURA DE PROVEEDORES ACTUALIZAR VALIDACIONES 
                If pVal.FormType = 141 And pVal.Before_Action = True And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)
                    oMatrix = oForm.Items.Item("1320002138").Specific
                    oCardCode = oForm.Items.Item("4").Specific
                    oDocNum = oForm.Items.Item("8").Specific
                    oDocDate = oForm.Items.Item("10").Specific
                    oButton = oForm.Items.Item("1").Specific

                    CardCodeSN = oCardCode.String
                    DocNum = oDocNum.Value.ToString()
                    DocDate = oDocDate.Value.ToString()
                    proceso = oButton.Caption

                    If proceso = "Actualizar" Then



                        If (oMatrix.VisualRowCount >= 3) Then
                            SBO_Application.StatusBar.SetText("Número de archivos permitido, excedido. Eliminar archivos de sobra", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                        If oMatrix.VisualRowCount = 0 And proceso = "Actualizar" And oForm.Title = "Factura de proveedores" Then
                            SBO_Application.StatusBar.SetText("FALTA ANEXAR LOS ARCHIVOS CORRESPONDIENTES 0", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                            BubbleEvent = False
                            Return
                        End If
                        'If oMatrix.VisualRowCount > 2 And oForm.Title = "Factura de proveedores" Then
                        '    SBO_Application.StatusBar.SetText("FALTA ANEXAR  ARCHIVOS CORRESPONDIENTES", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                        '    'SBO_Application.MessageBox("FALTA ANEXAR LOS ARCHIVOS CORRESPONDIENTES")
                        '    BubbleEvent = False
                        '    Return
                        'End If
                        For j As Integer = 1 To oMatrix.VisualRowCount
                            rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                            Dim i As Integer
                            i = j - 1
                            arr(i) = rutas
                            validarRuta = False

                            Try
                                Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(rutas)
                            Catch ex As Exception
                                validarRuta = True
                            End Try
                            'no suba mas de 3 archivo entrada mercancia/factura 3 o 4 check
                            If oMatrix.RowCount = 2 Or oMatrix.RowCount = 3 Then
                                rutas = My.Settings.CarpetaDrive.ToString() & Carpeta & "\" & oMatrix.Columns.Item("1320000004").Cells.Item(j).Specific.Value & "." & oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value.ToString()
                                Dim ext As String
                                ext = oMatrix.Columns.Item("1320000005").Cells.Item(j).Specific.Value
                                'If Not arr(i).Contains("xml") Or Not arr(i).Contains("pdf") Then
                                '    BubbleEvent = False
                                '    SBO_Application.StatusBar.SetText("Se debe incluir por lo menos un archivo PDF y 1 archivo XML", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                'End If
                                Dim validar1 As Integer = 0
                                Dim validar2 As Integer = 0

                                For k As Integer = 1 To oMatrix.RowCount
                                    Dim verificaxmlpdf As String
                                    verificaxmlpdf = oMatrix.Columns.Item("1320000005").Cells.Item(k).Specific.Value
                                    If Not verificaxmlpdf.ToLower.Contains("pdf") Then
                                        validar1 = validar1 + 1
                                    End If
                                    If Not verificaxmlpdf.ToLower.Contains("xml") Then
                                        validar2 = validar2 + 1
                                    End If
                                Next
                                If (validar1 >= 2 Or validar2 >= 2) Then
                                    SBO_Application.StatusBar.SetText("Se debe incluir por lo menos un archivo PDF y 1 archivo XML", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    BubbleEvent = False
                                    Return
                                End If
                                If (validarRuta <> False) Then
                                    SBO_Application.StatusBar.SetText("El archivo se debera tomar de una ruta valida", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    BubbleEvent = False
                                    Return
                                End If
                                If (ext.ToLower = "pdf") Then
                                    BubbleEvent = True
                                ElseIf (ext.ToLower = "xml") Then
                                    BubbleEvent = True
                                    Dim readComp = New ReadComprobantevb()
                                    'readComp.Metodo(rutas)
                                    Dim oComprobante As Comprobante
                                    oComprobante = readComp.Metodo(rutas)
                                    If oComprobante Is Nothing Then
                                        SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                        BubbleEvent = False
                                        Return
                                    Else
                                        Dim SATSAP = New SAT()
                                        Dim results As Task(Of String) = New SAT().Soap(readComp.oComprobante.Emisor.Rfc.ToString(), readComp.oComprobante.Receptor.Rfc.ToString(), readComp.oComprobante.TimbreFiscalDigital.UUID.ToString(), readComp.oComprobante.Total.ToString())
                                        Dim xDoc As New XmlDocument()
                                        xDoc.LoadXml(results.Result)
                                        Dim XMLstatus As XmlNodeList = xDoc.GetElementsByTagName("a:CodigoEstatus")
                                        Dim XMLcancelable As XmlNodeList = xDoc.GetElementsByTagName("a:EsCancelable")
                                        Dim XMLestado As XmlNodeList = xDoc.GetElementsByTagName("a:Estado")
                                        Dim XMLstatusCancelacion As XmlNodeList = xDoc.GetElementsByTagName("a:EstatusCancelacion")
                                        Dim codigo As String = XMLstatus.Cast(Of XmlNode)().LastOrDefault().InnerText
                                        Dim cancelacion As String = XMLcancelable.Cast(Of XmlNode)().LastOrDefault().InnerText
                                        Dim estado As String = XMLestado.Cast(Of XmlNode)().LastOrDefault().InnerText
                                        Dim estatus As String = XMLstatusCancelacion.Cast(Of XmlNode)().LastOrDefault().InnerText

                                        Try
                                            If (codigo <> "S - Comprobante obtenido satisfactoriamente." And estado <> "Vigente") Then
                                                SBO_Application.StatusBar.SetText("El archivo XML de la factura es Apocrifo o la factura no es vigente", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            Else
                                                SBO_Application.StatusBar.SetText("XML VIGENTE", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success)
                                                BubbleEvent = True
                                            End If
                                            If readComp.oComprobante.Emisor.Rfc.ToString() = "" Then
                                                SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            End If
                                            If readComp.oComprobante.Receptor.Rfc.ToString() = "" Then
                                                SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            End If
                                            If readComp.oComprobante.TimbreFiscalDigital.UUID.ToString() = "" Then
                                                SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            End If
                                            If readComp.oComprobante.Total.ToString() = "" Then
                                                SBO_Application.StatusBar.SetText("El archivo XML no contiene el formato de una factura", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                                BubbleEvent = False
                                                Return
                                            End If
                                        Catch ex As Exception
                                            BitError1.CrearBitacora(ex.Message)
                                            'SBO_Application.MessageBox(ex.Message)
                                            BubbleEvent = False
                                            Return
                                        End Try
                                    End If
                                Else
                                    SBO_Application.StatusBar.SetText("Error en la exxtensión de los archivos. Revisar apartado de anexos", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
                                    'SBO_Application.MessageBox("Debe haber 2 archivos pdf y 1 xml")
                                    oMatrix.DeleteRow(ext.ToLower <> "pdf")
                                    BubbleEvent = False
                                    Return
                                End If
                            End If
                        Next
                    End If
                    If oMatrix.RowCount >= 2 Then
                        Do While oMatrix.RowCount > 0
                            oMatrix.DeleteRow(oMatrix.VisualRowCount)
                        Loop
                    End If
                End If
                '----
                'ENTRADA DE MERCANCIAS  CREAR Y SUBIR ARCHIVO

                '----
                If pVal.FormType = 143 And pVal.Before_Action = False And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)

                    If proceso = "Crear" And pVal.ActionSuccess = True And oForm.Title = "Entrada de mercancías" Then
                        ' Dim oMatrix As SAPbouiCOM.Matrix
                        oMatrix = oForm.Items.Item("1320002138").Specific
                        Try
                            If arr.Count > 0 Then
                                For j As Integer = 0 To arr.Count
                                    Dim campourl As String
                                    campourl = "Select U_Enlace From OPDN WITH (NOLOCK) WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                    Dim dbConnC As New SqlConnection(condb)
                                    Dim Consulta As New SqlConnection
                                    Consulta.ConnectionString = condb
                                    Dim dbCommand2 As New SqlCommand(campourl, dbConnC)
                                    dbConnC.Open()
                                    Dim urllleno As String
                                    urllleno = Convert.ToString(dbCommand2.ExecuteScalar)
                                    If urllleno = "" Then
                                        'sujeto a cedito
                                        Dim drive = New Drive()
                                        If Service.ApplicationName <> "Google Drive VB Dot Net" Then CreateService()
                                        Dim TheFile As New File()
                                        Dim nombre_ArchivoDrive As String
                                        If arr(0).ToLower.Contains(".pdf") Then
                                            nombre_ArchivoDrive = "ENTRADA_" + DocNum + "_" + DocDate + ".pdf"
                                            TheFile.Title = "" & nombre_ArchivoDrive & ""
                                        End If
                                        'TheFile.Title = "" & nombre_ArchivoDrive & ""
                                        TheFile.Description = "Documento basado en la  Entrada de Mercancias " & " " & DocNum & " Con el socio de Negocios " & CardCodeSN
                                        TheFile.MimeType = ""
                                        'Dim Sociedad As String
                                        'Dim Carpeta As String
                                        'Carpeta = "Select U_RutaCarpetaDrive from OPDN where DocNum='" & DocNum & "'"
                                        'MiConexion.ConnectionString = condb
                                        'Dim dbConn As New SqlConnection(condb)
                                        'Dim dbCommand As New SqlCommand(Carpeta, dbConn)
                                        'dbConn.Open()
                                        'Dim rutaCarpeta As String
                                        'rutaCarpeta = dbCommand.ExecuteScalar
                                        '---CAMBIAR CARPETA
                                        Dim query As String
                                        query = "SELECT T0.U_RutaDrive[Carpeta] FROM OCRD T0  WITH (NOLOCK) WHERE T0.CardCode='" & CardCodeSN & "'"
                                        Dim dbConnC2 As New SqlConnection(condb)
                                        Dim Consulta2 As New SqlConnection
                                        Consulta2.ConnectionString = condb
                                        Dim dbCommand3 As New SqlCommand(query, dbConnC2)
                                        dbConnC2.Open()
                                        Dim carpetaF As String
                                        carpetaF = Convert.ToString(dbCommand3.ExecuteScalar)
                                        dbConnC2.Close()
                                        Dim parent = New ParentReference()
                                        parent.Id = carpetaF
                                        Dim aList As New List(Of ParentReference)
                                        aList.Add(parent)
                                        TheFile.Parents = aList

                                        '---CAMBIAR CARPETA

                                        ' TheFile.Parents = New List(Of ParentReference) From {New ParentReference With {.Id = My.Settings.CarpetaDrive.ToString()}}
                                        Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(arr(j))
                                        Dim Stream As New System.IO.MemoryStream(ByteArray)
                                        Dim UploadRequest As FilesResource.InsertMediaUpload = Service.Files.Insert(TheFile, Stream, TheFile.MimeType)
                                        UploadRequest.Upload()
                                        Dim file As File = UploadRequest.ResponseBody
                                        SBO_Application.StatusBar.SetText("El archivo " & TheFile.Title & " se ha subido correctamente ", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success)
                                        Dim gdrive_ruta As String
                                        gdrive_ruta = file.EmbedLink
                                        Dim U_Enlace As String
                                        U_Enlace = gdrive_ruta.ToString() ' documento.UserFields.Fields.Item("U_Enlace").Value
                                        '-----
                                        Dim UpdateURL As String
                                        UpdateURL = "UPDATE OPDN Set U_Enlace='" & U_Enlace & "' WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        Dim dbConn1 As New SqlConnection(condb)
                                        MiConexion.ConnectionString = condb
                                        Dim dbCommand1 As New SqlCommand(UpdateURL, dbConn1)
                                        dbConn1.Open()
                                        Dim EM As String
                                        EM = dbCommand1.ExecuteScalar
                                        If System.IO.File.Exists(arr(j)) Then
                                            Try
                                                System.IO.File.Delete(arr(j))

                                            Catch ex As System.IO.IOException
                                                BitError1.CrearBitacora(ex.Message)
                                                Return
                                            End Try
                                        End If
                                    End If
                                Next

                            End If
                        Catch ex As Exception
                            BitError1.CrearBitacora(ex.Message)
                            'SBO_Application.MessageBox(ex.Message)
                            BubbleEvent = False
                        End Try
                    End If
                End If

                '----
                'ENTRADA DE MERCANCIAS SUBIR ACTUALIZAR Y SUBIR ARCHIVO

                '----
                If pVal.FormType = 143 And pVal.Before_Action = False And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)

                    If proceso = "Actualizar" And pVal.ActionSuccess = True And oForm.Title = "Entrada de mercancías" Then
                        ' Dim oMatrix As SAPbouiCOM.Matrix
                        oMatrix = oForm.Items.Item("1320002138").Specific
                        Try
                            If arr.Count > 0 Then
                                For j As Integer = 0 To arr.Count
                                    Dim campourl As String
                                    campourl = "Select U_Enlace From OPDN WITH (NOLOCK) WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                    Dim dbConnC As New SqlConnection(condb)
                                    Dim Consulta As New SqlConnection
                                    Consulta.ConnectionString = condb
                                    Dim dbCommand2 As New SqlCommand(campourl, dbConnC)
                                    dbConnC.Open()
                                    Dim urllleno As String
                                    urllleno = Convert.ToString(dbCommand2.ExecuteScalar)

                                    'sujeto a cedito
                                    Dim drive = New Drive()
                                    If Service.ApplicationName <> "Google Drive VB Dot Net" Then CreateService()
                                    Dim TheFile As New File()
                                    Dim nombre_ArchivoDrive As String
                                    If arr(0).ToLower.Contains(".pdf") Then
                                        nombre_ArchivoDrive = "ENTRADA_" + DocNum + "_" + DocDate + ".pdf"
                                        TheFile.Title = "" & nombre_ArchivoDrive & ""
                                    End If
                                    'TheFile.Title = "" & nombre_ArchivoDrive & ""
                                    TheFile.Description = "Documento basado en la Entrada de Mercancias " & " " & DocNum & " Con el socio de Negocios " & CardCodeSN
                                    TheFile.MimeType = ""
                                    'Dim Sociedad As String
                                    'Dim Carpeta As String
                                    'Carpeta = "Select U_RutaCarpetaDrive from OPDN where DocNum='" & DocNum & "'"
                                    'MiConexion.ConnectionString = condb
                                    'Dim dbConn As New SqlConnection(condb)
                                    'Dim dbCommand As New SqlCommand(Carpeta, dbConn)
                                    'dbConn.Open()
                                    'Dim rutaCarpeta As String
                                    'rutaCarpeta = dbCommand.ExecuteScalar
                                    '---CAMBIAR CARPETA
                                    Dim query As String
                                    query = "SELECT T0.U_RutaDrive[Carpeta] FROM OCRD T0  WITH (NOLOCK) WHERE T0.CardCode='" & CardCodeSN & "'"
                                    Dim dbConnC2 As New SqlConnection(condb)
                                    Dim Consulta2 As New SqlConnection
                                    Consulta2.ConnectionString = condb
                                    Dim dbCommand3 As New SqlCommand(query, dbConnC2)
                                    dbConnC2.Open()
                                    Dim carpetaF As String
                                    carpetaF = Convert.ToString(dbCommand3.ExecuteScalar)
                                    dbConnC2.Close()
                                    Dim parent = New ParentReference()
                                    parent.Id = carpetaF
                                    Dim aList As New List(Of ParentReference)
                                    aList.Add(parent)
                                    TheFile.Parents = aList

                                    '---CAMBIAR CARPETA

                                    TheFile.Parents = New List(Of ParentReference) From {New ParentReference With {.Id = "1pbHG6IFf4umdnGjhl3V44s0KhDtaeCZI"}}
                                    Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(arr(j))
                                    Dim Stream As New System.IO.MemoryStream(ByteArray)
                                    Dim UploadRequest As FilesResource.InsertMediaUpload = Service.Files.Insert(TheFile, Stream, TheFile.MimeType)
                                    UploadRequest.Upload()
                                    Dim file As File = UploadRequest.ResponseBody

                                    Dim gdrive_ruta As String
                                    gdrive_ruta = file.EmbedLink
                                    Dim U_Enlace As String
                                    U_Enlace = gdrive_ruta.ToString() ' documento.UserFields.Fields.Item("U_Enlace").Value
                                    '-----
                                    Dim UpdateURL As String
                                    UpdateURL = "UPDATE OPDN Set U_Enlace='" & U_Enlace & "' WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                    Dim dbConn1 As New SqlConnection(condb)
                                    MiConexion.ConnectionString = condb
                                    Dim dbCommand1 As New SqlCommand(UpdateURL, dbConn1)
                                    dbConn1.Open()
                                    Dim EM As String
                                    EM = dbCommand1.ExecuteScalar
                                    If System.IO.File.Exists(arr(j)) Then
                                        Try
                                            System.IO.File.Delete(arr(j))

                                        Catch ex As System.IO.IOException
                                            BitError1.CrearBitacora(ex.Message)
                                            Return
                                        End Try
                                    End If
                                    SBO_Application.StatusBar.SetText("El archivo " & TheFile.Title & " se ha subido correctamente ", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success)
                                Next

                            End If
                        Catch ex As Exception
                            BitError1.CrearBitacora(ex.Message)
                            'SBO_Application.MessageBox(ex.Message)
                            BubbleEvent = False
                            Return
                        End Try
                    End If
                End If
                '----
                'FACTURA CREAR Y SUBIR ARCHIVO

                '----
                If pVal.FormType = 141 And pVal.Before_Action = False And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)

                    If proceso = "Crear" And pVal.ActionSuccess = True And oForm.Title.ToLower.Contains("factura") Then 'pVal.ActionSuccess = True And
                        Try
                            If arr.Count > 0 Then
                                For j As Integer = 0 To arr.Count
                                    'sujeto a cedito


                                    Dim drive = New Drive()
                                    If Service.ApplicationName <> "Google Drive VB Dot Net" Then CreateService()
                                    Dim TheFile As New File()
                                    Dim nombre_ArchivoDrive As String
                                    If arr(j).ToLower.Contains(".pdf") Then
                                        nombre_ArchivoDrive = "FACTURA_" + DocNum + "_" + DocDate + ".pdf"
                                        TheFile.Title = "" & nombre_ArchivoDrive & ""
                                    End If
                                    If arr(j).ToLower.Contains(".xml") Then
                                        nombre_ArchivoDrive = "FACTURA_" + DocNum + "_" + DocDate + ".xml"
                                        TheFile.Title = "" & nombre_ArchivoDrive & ""
                                    End If
                                    'nombre = "FACTURA_" + DocNum + "_" + DocDate + ".pd"
                                    TheFile.Description = "Documento basado en la Factura de Proveedores " & DocNum & "Con el socio de Negocios " & CardCodeSN
                                    TheFile.MimeType = ""
                                    ' Dim Sociedad As String
                                    'Dim Carpeta As String
                                    'Carpeta = "Select U_RutaCarpetaDrive from OPCH where DocNum='" & DocNum & "'"
                                    'MiConexion.ConnectionString = condb
                                    'Dim dbConn As New SqlConnection(condb)
                                    'Dim dbCommand As New SqlCommand(Carpeta, dbConn)
                                    'dbConn.Open()
                                    'Dim rutaCarpeta As String
                                    'rutaCarpeta = dbCommand.ExecuteScalar
                                    'TheFile.Parents = New List(Of ParentReference) From {New ParentReference With {.Id = rutaCarpeta}}

                                    'TheFile.Parents = New List(Of ParentReference) From {New ParentReference With {.Id = My.Settings.CarpetaDrive.ToString()}}
                                    '---CAMBIAR CARPETA
                                    Dim query As String
                                    query = "SELECT T0.U_RutaDrive[Carpeta] FROM OCRD T0  WITH (NOLOCK) WHERE T0.CardCode='" & CardCodeSN & "'"
                                    Dim dbConnC2 As New SqlConnection(condb)
                                    Dim Consulta2 As New SqlConnection
                                    Consulta2.ConnectionString = condb
                                    Dim dbCommand3 As New SqlCommand(query, dbConnC2)
                                    dbConnC2.Open()
                                    Dim carpetaF As String
                                    carpetaF = Convert.ToString(dbCommand3.ExecuteScalar)
                                    dbConnC2.Close()
                                    Dim parent = New ParentReference()
                                    parent.Id = carpetaF
                                    Dim aList As New List(Of ParentReference)
                                    aList.Add(parent)
                                    TheFile.Parents = aList

                                    '---CAMBIAR CARPETA
                                    '--CONTRASEÑA DE PDF
                                    '--Contraseña PDF
                                    Dim path As String
                                    path = arr(j)
                                    Dim PdfPass As String
                                    PdfPass = arr(j).Replace(".pdf", "2.pdf")
                                    If path.ToLower.Contains(".pdf") Then
                                        Using input = New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                                            Using outputpdf = New IO.FileStream(PdfPass, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
                                                If path.Contains(".pdf") Then
                                                    Dim readerpdf = New PdfReader(input)
                                                    PdfEncryptor.Encrypt(readerpdf, outputpdf, True, My.Settings.Contrasena.ToString(), My.Settings.Contrasena.ToString(), PdfWriter.ALLOW_PRINTING)
                                                    If System.IO.File.Exists(arr(j)) Then
                                                        Try
                                                            System.IO.File.Delete(arr(j))

                                                        Catch ex As System.IO.IOException
                                                            BitError1.CrearBitacora(ex.Message)
                                                            ''BitError1.CrearBitacora(e.Message)
                                                            Return
                                                        End Try
                                                    End If
                                                    arr(j) = PdfPass
                                                End If
                                            End Using
                                        End Using
                                        'arr(j) = PdfPass
                                    End If
                                    '--
                                    '--CONTRASEÑA DE PDF

                                    Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(arr(j))
                                    Dim Stream As New System.IO.MemoryStream(ByteArray)


                                    Dim gdrive_ruta As String

                                    Dim UploadRequest As FilesResource.InsertMediaUpload = Service.Files.Insert(TheFile, Stream, TheFile.MimeType)

                                    UploadRequest.Upload()
                                    Dim file_carga As File = UploadRequest.ResponseBody


                                    gdrive_ruta = file_carga.EmbedLink

                                    Dim FD As String

                                    Dim U_Enlace2, U_Enlace3, U_Enlace4 As String
                                    U_Enlace2 = gdrive_ruta.ToString() ' documento.UserFields.Fields.Item("U_Enlace2").Value
                                    U_Enlace3 = gdrive_ruta.ToString() 'documento.UserFields.Fields.Item("U_Enlace3").Value
                                    U_Enlace4 = gdrive_ruta.ToString() ' documento.UserFields.Fields.Item("U_Enlace4").Value
                                    '-----
                                    Dim Update As String
                                    Dim dbConn1 As New SqlConnection(condb)
                                    If j = 0 Then
                                        Dim campourl As String
                                        campourl = "Select U_Enlace2 From OPCH WITH (NOLOCK) WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        Dim dbConnC As New SqlConnection(condb)
                                        Dim Consulta As New SqlConnection
                                        Consulta.ConnectionString = condb
                                        Dim dbCommand2 As New SqlCommand(campourl, dbConnC)
                                        dbConnC.Open()
                                        Dim urllleno As String
                                        urllleno = Convert.ToString(dbCommand2.ExecuteScalar)
                                        If urllleno = "" Then
                                            Update = "UPDATE OPCH Set U_Enlace2='" & U_Enlace2 & "' WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                            MiConexion.ConnectionString = condb
                                            Dim dbCommand1 As New SqlCommand(Update, dbConn1)
                                            dbConn1.Open()
                                            FD = dbCommand1.ExecuteScalar
                                            dbConn1.Close()
                                        End If
                                    End If
                                    If j = 1 Then
                                        Dim campourl As String
                                        campourl = "Select U_Enlace3 From OPCH WITH (NOLOCK) WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        Dim dbConnC As New SqlConnection(condb)
                                        Dim Consulta As New SqlConnection
                                        Consulta.ConnectionString = condb
                                        Dim dbCommand2 As New SqlCommand(campourl, dbConnC)
                                        dbConnC.Open()
                                        Dim urllleno As String
                                        urllleno = Convert.ToString(dbCommand2.ExecuteScalar)
                                        If urllleno = "" Then
                                            Update = "UPDATE OPCH Set U_Enlace3='" & U_Enlace3 & "' WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                            MiConexion.ConnectionString = condb
                                            Dim dbCommand1 As New SqlCommand(Update, dbConn1)
                                            dbConn1.Open()
                                            FD = dbCommand1.ExecuteScalar
                                            dbConn1.Close()
                                        End If
                                    End If
                                    If j = 2 Then
                                        Dim campourl As String
                                        campourl = "Select U_Enlace4 From OPCH WITH (NOLOCK) WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        Dim dbConnC As New SqlConnection(condb)
                                        Dim Consulta As New SqlConnection
                                        Consulta.ConnectionString = condb
                                        Dim dbCommand2 As New SqlCommand(campourl, dbConnC)
                                        dbConnC.Open()
                                        Dim urllleno As String
                                        urllleno = Convert.ToString(dbCommand2.ExecuteScalar)
                                        If urllleno = "" Then
                                            Update = "UPDATE OPCH Set U_Enlace4='" & U_Enlace4 & "' WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                            MiConexion.ConnectionString = condb
                                            Dim dbCommand1 As New SqlCommand(Update, dbConn1)
                                            dbConn1.Open()
                                            FD = dbCommand1.ExecuteScalar
                                            dbConn1.Close()
                                        End If
                                    End If
                                    'dbConn.Close()
                                    If System.IO.File.Exists(arr(j)) Then
                                        Try
                                            System.IO.File.Delete(arr(j))
                                        Catch ex As System.IO.IOException
                                            BitError1.CrearBitacora(ex.Message)
                                            Return
                                        End Try
                                    End If
                                Next
                                'MsgBox("Archivo(s) subidos correctamente a " + "https://drive.google.com/drive/my-drive")
                                'Process.Start("https://drive.google.com/drive/my-drive")
                            End If
                        Catch ex As Exception
                            BitError1.CrearBitacora(ex.Message)
                            'SBO_Application.MessageBox(ex.Message)
                            BubbleEvent = False
                            Return
                        End Try
                    End If
                End If

                '----
                '----
                'FACTURA ACTUALIZAR Y SUBIR ARCHIVO

                '----
                If pVal.FormType = 141 And pVal.Before_Action = False And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)

                    If proceso = "Actualizar" And pVal.ActionSuccess = True And oForm.Title.ToLower.Contains("factura") Then 'pVal.ActionSuccess = True And
                        Try
                            If arr.Count > 0 Then
                                For j As Integer = 0 To arr.Count
                                    'sujeto a cedito


                                    Dim drive = New Drive()
                                    If Service.ApplicationName <> "Google Drive VB Dot Net" Then CreateService()
                                    Dim TheFile As New File()
                                    Dim nombre_ArchivoDrive As String
                                    If arr(j).ToLower.Contains(".pdf") Then
                                        nombre_ArchivoDrive = "FACTURA_" + DocNum + "_" + DocDate + ".pdf"
                                        TheFile.Title = "" & nombre_ArchivoDrive & ""
                                    End If
                                    If arr(j).ToLower.Contains(".xml") Then
                                        nombre_ArchivoDrive = "FACTURA_" + DocNum + "_" + DocDate + ".xml"
                                        TheFile.Title = "" & nombre_ArchivoDrive & ""
                                    End If
                                    'nombre = "FACTURA_" + DocNum + "_" + DocDate + ".pd"
                                    TheFile.Description = "Documento basado en la  Factura de Proveedores " & DocNum & "Con el socio de Negocios " & CardCodeSN
                                    TheFile.MimeType = ""
                                    ' Dim Sociedad As String
                                    'Dim Carpeta As String
                                    'Carpeta = "Select U_RutaCarpetaDrive from OPCH where DocNum='" & DocNum & "'"
                                    'MiConexion.ConnectionString = condb
                                    'Dim dbConn As New SqlConnection(condb)
                                    'Dim dbCommand As New SqlCommand(Carpeta, dbConn)
                                    'dbConn.Open()
                                    'Dim rutaCarpeta As String
                                    'rutaCarpeta = dbCommand.ExecuteScalar
                                    'TheFile.Parents = New List(Of ParentReference) From {New ParentReference With {.Id = rutaCarpeta}}

                                    'TheFile.Parents = New List(Of ParentReference) From {New ParentReference With {.Id = My.Settings.CarpetaDrive.ToString()}}
                                    '---CAMBIAR CARPETA
                                    Dim query As String
                                    query = "SELECT T0.U_RutaDrive[Carpeta] FROM OCRD T0  WITH (NOLOCK) WHERE T0.CardCode='" & CardCodeSN & "'"
                                    Dim dbConnC2 As New SqlConnection(condb)
                                    Dim Consulta2 As New SqlConnection
                                    Consulta2.ConnectionString = condb
                                    Dim dbCommand3 As New SqlCommand(query, dbConnC2)
                                    dbConnC2.Open()
                                    Dim carpetaF As String
                                    carpetaF = Convert.ToString(dbCommand3.ExecuteScalar)
                                    dbConnC2.Close()
                                    Dim parent = New ParentReference()
                                    parent.Id = carpetaF
                                    Dim aList As New List(Of ParentReference)
                                    aList.Add(parent)
                                    TheFile.Parents = aList

                                    '---CAMBIAR CARPETA

                                    '--CONTRASEÑA DE PDF
                                    '--Contraseña PDF
                                    Dim path As String
                                    path = arr(j)
                                    Dim PdfPass As String
                                    PdfPass = arr(j).Replace(".pdf", "2.pdf")
                                    If path.ToLower.Contains(".pdf") Then
                                        Using input = New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                                            Using outputpdf = New IO.FileStream(PdfPass, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
                                                If path.Contains(".pdf") Then
                                                    Dim readerpdf = New PdfReader(input)
                                                    PdfEncryptor.Encrypt(readerpdf, outputpdf, True, My.Settings.Contrasena.ToString(), My.Settings.Contrasena.ToString(), PdfWriter.ALLOW_PRINTING)
                                                    If System.IO.File.Exists(arr(j)) Then
                                                        Try
                                                            System.IO.File.Delete(arr(j))

                                                        Catch ex As System.IO.IOException
                                                            BitError1.CrearBitacora(ex.Message)
                                                            ''BitError1.CrearBitacora(e.Message)
                                                            Return
                                                        End Try
                                                    End If
                                                    arr(j) = PdfPass
                                                End If
                                            End Using
                                        End Using
                                        'arr(j) = PdfPass
                                    End If
                                    '--
                                    '--CONTRASEÑA DE PDF

                                    Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(arr(j))
                                    Dim Stream As New System.IO.MemoryStream(ByteArray)

                                    Dim UploadRequest As FilesResource.InsertMediaUpload = Service.Files.Insert(TheFile, Stream, TheFile.MimeType)

                                    UploadRequest.Upload()
                                    Dim file As File = UploadRequest.ResponseBody
                                    '
                                    Dim gdrive_ruta As String
                                    gdrive_ruta = file.EmbedLink
                                    'arr(j) = gdrive_ruta
                                    Dim FD As String

                                    Dim U_Enlace2, U_Enlace3, U_Enlace4 As String
                                    U_Enlace2 = gdrive_ruta.ToString() ' documento.UserFields.Fields.Item("U_Enlace2").Value
                                    U_Enlace3 = gdrive_ruta.ToString() 'documento.UserFields.Fields.Item("U_Enlace3").Value
                                    U_Enlace4 = gdrive_ruta.ToString() ' documento.UserFields.Fields.Item("U_Enlace4").Value
                                    '-----
                                    Dim Update As String
                                    Dim dbConn1 As New SqlConnection(condb)
                                    If j = 0 Then
                                        Dim campourl As String
                                        campourl = "Select U_Enlace2 From OPCH WITH (NOLOCK) WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        Dim dbConnC As New SqlConnection(condb)
                                        Dim Consulta As New SqlConnection
                                        Consulta.ConnectionString = condb
                                        Dim dbCommand2 As New SqlCommand(campourl, dbConnC)
                                        dbConnC.Open()
                                        Dim urllleno As String
                                        urllleno = Convert.ToString(dbCommand2.ExecuteScalar)

                                        Update = "UPDATE OPCH Set U_Enlace2='" & U_Enlace2 & "' WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        MiConexion.ConnectionString = condb
                                        Dim dbCommand1 As New SqlCommand(Update, dbConn1)
                                        dbConn1.Open()
                                        FD = dbCommand1.ExecuteScalar
                                        dbConn1.Close()

                                    End If
                                    If j = 1 Then
                                        Dim campourl As String
                                        campourl = "Select U_Enlace3 From OPCH WITH (NOLOCK) WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        Dim dbConnC As New SqlConnection(condb)
                                        Dim Consulta As New SqlConnection
                                        Consulta.ConnectionString = condb
                                        Dim dbCommand2 As New SqlCommand(campourl, dbConnC)
                                        dbConnC.Open()
                                        Dim urllleno As String
                                        urllleno = Convert.ToString(dbCommand2.ExecuteScalar)

                                        Update = "UPDATE OPCH Set U_Enlace3='" & U_Enlace3 & "' WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        MiConexion.ConnectionString = condb
                                        Dim dbCommand1 As New SqlCommand(Update, dbConn1)
                                        dbConn1.Open()
                                        FD = dbCommand1.ExecuteScalar
                                        dbConn1.Close()

                                    End If
                                    If j = 2 Then
                                        Dim campourl As String
                                        campourl = "Select U_Enlace4 From OPCH WITH (NOLOCK) WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        Dim dbConnC As New SqlConnection(condb)
                                        Dim Consulta As New SqlConnection
                                        Consulta.ConnectionString = condb
                                        Dim dbCommand2 As New SqlCommand(campourl, dbConnC)
                                        dbConnC.Open()
                                        Dim urllleno As String
                                        urllleno = Convert.ToString(dbCommand2.ExecuteScalar)

                                        Update = "UPDATE OPCH Set U_Enlace4='" & U_Enlace4 & "' WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                        MiConexion.ConnectionString = condb
                                        Dim dbCommand1 As New SqlCommand(Update, dbConn1)
                                        dbConn1.Open()
                                        FD = dbCommand1.ExecuteScalar
                                        dbConn1.Close()

                                    End If
                                    'dbConn.Close()
                                    If System.IO.File.Exists(arr(j)) Then
                                        Try
                                            System.IO.File.Delete(arr(j))
                                        Catch ex As System.IO.IOException
                                            BitError1.CrearBitacora(ex.Message)
                                            Return
                                        End Try
                                    End If
                                Next
                                'MsgBox("Archivo(s) subidos correctamente a " + "https://drive.google.com/drive/my-drive")
                                'Process.Start("https://drive.google.com/drive/my-drive")
                                SBO_Application.StatusBar.SetText("Los archivo se han subido correctamente ", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success)
                            End If

                        Catch ex As Exception
                            BitError1.CrearBitacora(ex.Message)
                            'SBO_Application.MessageBox(ex.Message)
                            BubbleEvent = False
                            Return
                        End Try
                    End If
                End If



                '----
                'PEDIDO SUBIR ACTUALIZAR Y SUBIR ARCHIVO

                '----
                If pVal.FormType = 142 And pVal.Before_Action = False And pVal.ItemUID = "1" And pVal.EventType = SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED Then
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)
                    Dim body As New File()
                    oForm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount)
                    oCardCode = oForm.Items.Item("4").Specific
                    oDocNum = oForm.Items.Item("8").Specific
                    CardCodeSN = oCardCode.Value.ToString()
                    DocNum = oDocNum.Value.ToString()
                    Dim carpetaF As String
                    If proceso = "Actualizar" And pVal.ActionSuccess = True And oForm.Title.ToLower.Contains("pedido") Then
                        Try
                            If arr_combustible.Count > 0 Then
                                Dim query As String
                                query = "SELECT T0.U_RutaDrive[Carpeta] FROM OCRD T0  WITH (NOLOCK) WHERE T0.CardCode='" & CardCodeSN & "'"
                                Dim dbConnC2 As New SqlConnection(condb)
                                Dim Consulta2 As New SqlConnection
                                Consulta2.ConnectionString = condb
                                Dim dbCommand3 As New SqlCommand(query, dbConnC2)
                                dbConnC2.Open()

                                carpetaF = Convert.ToString(dbCommand3.ExecuteScalar)
                                dbConnC2.Close()
                                'AGREGADO


                                For j As Integer = 0 To arr_combustible.Count
                                    Dim campourl As String
                                    campourl = "Select U_Enlace From OPOR WITH (NOLOCK) WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                    Dim dbConnC As New SqlConnection(condb)
                                    Dim Consulta As New SqlConnection
                                    Consulta.ConnectionString = condb
                                    Dim dbCommand2 As New SqlCommand(campourl, dbConnC)
                                    dbConnC.Open()
                                    Dim urllleno As String
                                    urllleno = Convert.ToString(dbCommand2.ExecuteScalar)
                                    dbConnC.Close()






                                    Dim drive = New Drive()
                                    If Service.ApplicationName <> "Google Drive VB Dot Net" Then CreateService()
                                    Dim TheFile As New File()
                                    Dim nombre_ArchivoDrive As String
                                    If arr_combustible(0).ToLower.Contains(".pdf") Then
                                        nombre_ArchivoDrive = "ACUSE DE PEDIDO" & DocNum & " " & DateTime.Now.ToShortDateString()
                                        TheFile.Title = "" & nombre_ArchivoDrive & ""
                                        TheFile.Description = "Documento basado en el Pedido " & " " & DocNum & " Con el socio de Negocios " & CardCodeSN
                                        TheFile.MimeType = ""
                                        TheFile.Parents = New List(Of ParentReference) From {New ParentReference With {.Id = carpetaF}}
                                    End If

                                    Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(arr_combustible(j))
                                    Dim Stream As New System.IO.MemoryStream(ByteArray)
                                    Dim UploadRequest As FilesResource.InsertMediaUpload = Service.Files.Insert(TheFile, Stream, TheFile.MimeType)
                                    UploadRequest.Upload()
                                    Dim file As File = UploadRequest.ResponseBody
                                    SBO_Application.StatusBar.SetText("El archivo " & TheFile.Title & " se ha subido correctamente ", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success)
                                    Dim gdrive_ruta As String
                                    gdrive_ruta = file.EmbedLink
                                    Dim U_Enlace As String
                                    U_Enlace = gdrive_ruta.ToString() ' documento.UserFields.Fields.Item("U_Enlace").Value
                                    '-----
                                    Dim UpdateURL As String
                                    UpdateURL = "UPDATE OPOR Set U_Enlace='" & U_Enlace & "' WHERE CARDCODE='" & CardCodeSN & "' AND DocNum='" & DocNum & "'"
                                    Dim dbConn1 As New SqlConnection(condb)
                                    MiConexion.ConnectionString = condb
                                    Dim dbCommand1 As New SqlCommand(UpdateURL, dbConn1)
                                    dbConn1.Open()
                                    Dim EM As String
                                    EM = dbCommand1.ExecuteScalar
                                    If System.IO.File.Exists(arr_combustible(j)) Then
                                        Try
                                            System.IO.File.Delete(arr_combustible(j))

                                        Catch ex As System.IO.IOException
                                            BitError1.CrearBitacora(ex.Message)
                                            Return
                                        End Try
                                    End If

                                Next
                                arr_combustible = New List(Of String)
                            End If
                        Catch ex As Exception
                            BitError1.CrearBitacora(ex.Message)
                            'SBO_Application.MessageBox(ex.Message)
                            BubbleEvent = False
                        End Try


                    End If
                End If

            Catch ex As Exception
                BitError1.CrearBitacora(ex.Message)
                ' SBO_Application.MessageBox(ex.Message)
                BubbleEvent = False
                Return
            End Try
        End Sub
        Sub SBO_Application_MenuEvent(ByRef pVal As SAPbouiCOM.MenuEvent, ByRef BubbleEvent As Boolean) Handles SBO_Application.MenuEvent
            BubbleEvent = True
            Try
                Select Case pVal.MenuUID
                    Case "AbrirBT"
                        Try
                            If (URLBusqueda <> "") Then
                                System.Diagnostics.Process.Start(URLBusqueda)
                                URLBusqueda = String.Empty
                            End If

                        Catch ex As Exception

                        End Try


                End Select
                If (pVal.BeforeAction And pVal.MenuUID = "ConstrulandiaAddOn.Form1") Then
                    Dim activeForm As Form1
                    activeForm = New Form1
                    activeForm.Show()
                End If
            Catch ex As System.Exception
                BitError1.CrearBitacora(ex.Message)
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "")
                BubbleEvent = False
            End Try
        End Sub
    End Class
End Namespace