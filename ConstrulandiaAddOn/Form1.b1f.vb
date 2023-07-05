Option Strict Off
Option Explicit On

Imports SAPbouiCOM.Framework

Namespace ConstrulandiaAddOn
    <FormAttribute("ConstrulandiaAddOn.Form1", "Form1.b1f")>
    Friend Class Form1
        Inherits UserFormBase

        Public Sub New()
        End Sub

        Public Overrides Sub OnInitializeComponent()
            Me.OnCustomInitialize()

        End Sub

        Public Overrides Sub OnInitializeFormEvents()
            AddHandler LoadAfter, AddressOf Me.Form_LoadAfter

        End Sub

        Private Sub OnCustomInitialize()

        End Sub
        Private Sub Form_LoadAfter(pVal As SAPbouiCOM.SBOItemEventArg)
            

        End Sub
    End Class
End Namespace
