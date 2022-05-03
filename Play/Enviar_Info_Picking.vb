Imports System.Data.SqlClient
Imports System.Threading

Public Class Enviar_Info_Picking
    Public trd1 As Thread
    Public Bod1, Bod2 As String

    Private Sub btn_ExpoInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ExpoInfo.Click
        Try
            Bod1 = TextB_Bod1.Text
            Bod2 = TextB_Bod1.Text
            'hilo de ejecucion constante
            trd1 = New Thread(AddressOf FuncionEn_BackGroud)
            trd1.IsBackground = Enabled
            'trd2.Priority = ThreadPriority.Highest
            CheckForIllegalCrossThreadCalls = False
            trd1.Start()

        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_ExpoInfo_Click [ " & ex.Message & " ]")
        End Try

    End Sub
    Public Function FuncionEn_BackGroud()
        If CBX_Param.Checked = True Then
            ExportaParametros(Class_VariablesGlobales.SQL_Comman1, TextB_Bod1.Text, TextB_Bod2.Text)
        End If
        MessageBox.Show("Carga del Bodeguero Completa " & TextB_CodBodeguero.Text, TextB_CodBodeguero.Text)
        TextB_CodBodeguero.Text = ""
        CBX_Param.Checked = False
    End Function



    Private Sub CBX_Param_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBX_Param.CheckedChanged
        If CBX_Param.Checked = True Then



            Dim result1 As DialogResult = MessageBox.Show("Esta por Cargar los parametros , si carga mal esta informacion puede perder pedidos\nEsta Seguro que desea Cargar los Parametros?", _
                "Important Question", _
                MessageBoxButtons.YesNo)

            If result1 = DialogResult.No Then
                CBX_Param.Checked = False

            End If
        End If
    End Sub


    Public Function ExportaParametros(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
        'OBTIENE LA INFORMACION DE CONFIGURACION

        Try
            My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & "Picking\" & Ruta & "\parametros.mbg")
        Catch ex As Exception

        End Try


        Dim TABLA As New DataTable
        Dim Lineas As String
        TABLA = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_InfoConfiguracionPicking(Class_VariablesGlobales.SQL_Comman2, Ruta)

        Dim CONT As Integer = 0
        For Each row As DataRow In TABLA.Rows
            Class_VariablesGlobales.Obj_Creaarchivo.Crear_ParamPicking(TABLA, Class_VariablesGlobales.XMLParamFTP_dirLocal & "Picking\" & Bod1 & "\parametros.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & "Picking\" & Bod1)
            CONT += 1
        Next
        'CARGA EN FTO Y ENVIA CORREO 
        If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & "Picking\" & Ruta & "\parametros.mbg") <> "0 Kb" Then
            'Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & "Picking\" & Ruta & "\parametros.mbg", "parametros.mbg", "Picking/" & Ruta2, "Completo", Servidor)
        End If

    End Function

    Private Sub btn_Cambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cambiar.Click
        Try

            Bod1 = TextB_Bod1.Text
            Bod2 = TextB_Bod2.Text
            'hilo de ejecucion constante
            trd1 = New Thread(AddressOf FuncionEn_BackGroud)
            trd1.IsBackground = Enabled
            'trd2.Priority = ThreadPriority.Highest
            CheckForIllegalCrossThreadCalls = False
            trd1.Start()

        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_ExpoInfo_Click [ " & ex.Message & " ]")
        End Try

    End Sub
End Class