Imports System.IO

Public Class PlanillaBL
    Public Function ValidaExistenciaDePlanillaEnCreacion()
        Try


            Dim TblInfoPlanilla As New DataTable
            Dim id_Planilla As Integer = 0
            TblInfoPlanilla = Class_VariablesGlobales.Obj_Funciones_SQL.ValidaExistePlanillaEnProceso(Class_VariablesGlobales.SQL_Comman2)
            ' Recorremos los registros obtenidos
            For Each row As DataRow In TblInfoPlanilla.Rows

                id_Planilla = row("Consecutivo").ToString.Trim()
                Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text = row("Consecutivo").ToString.Trim()
                Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text = row("Cedula_Empresa").ToString.Trim()
                Class_VariablesGlobales.frmPlanilla.Txt_NombreEmpresa.Text = row("Nombre_Empresa").ToString()
                Class_VariablesGlobales.frmPlanilla.DTP_FechaPlanillaDesde.Value = Convert.ToDateTime(row("FechaINI"))
                Class_VariablesGlobales.frmPlanilla.DTP_FechaPlanillaHasta.Value = Convert.ToDateTime(row("FechaFIN"))
                Class_VariablesGlobales.frmPlanilla.TxtBox_DescripcionPlanilla.Text = row("Comentario").ToString()
                Class_VariablesGlobales.frmPlanilla.DTP_FechaCrea.Value = Convert.ToDateTime(row("FechaCrea"))
                Class_VariablesGlobales.frmPlanilla.Txt_UsuarioCrea.Text = row("UsuarioCrea").ToString()
                Class_VariablesGlobales.frmPlanilla.TxtBox_CuentaDeducirPlanilla.Text = row("CuentaDeducirPlanilla").ToString()
            Next

            Return id_Planilla

        Catch ex As Exception
            MessageBox.Show("Error PlanillaBL ValidaExistenciaDePlanillaEnCreacion :" & ex.Message)

            Return 0
        End Try
    End Function


    Public Function PlanillaExistente(IdPlanilla As Integer)
        Try
            Dim TblPlanillaExistente As New DataTable
            TblPlanillaExistente = Class_VariablesGlobales.Obj_Funciones_SQL.CargaPlanillaExistente(IdPlanilla, Class_VariablesGlobales.SQL_Comman2)
            Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.DataSource = TblPlanillaExistente

        Catch ex As Exception
            MessageBox.Show("Error PlanillaBL PlanillaExistente :" & ex.Message)
        End Try
    End Function


    Public Function ObtieneInformacionEmpresa()
        Try
            Dim tabla As DataTable

            Dim contardor As Integer = 0
            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Empresa(Class_VariablesGlobales.SQL_Comman2)

            While contardor < tabla.Rows.Count
                Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text = tabla.Rows(contardor).Item("Cedula").ToString()
                Class_VariablesGlobales.frmPlanilla.Txt_NombreEmpresa.Text = tabla.Rows(contardor).Item("Nombre").ToString()
                contardor += 1
            End While
        Catch ex As Exception
            MessageBox.Show("Error PlanillaBL ObtieneInformacionEmpresa :" & ex.Message)
        End Try
    End Function


    Public Function CargaDesgloseCCSS()
        Try

            Dim tablaDesgloseCCSS As DataTable
            tablaDesgloseCCSS = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDesgloseCCSS(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.SQL_Comman2)
            Class_VariablesGlobales.frmPlanilla.DGV_DesgloseCCSS.DataSource = tablaDesgloseCCSS
        Catch ex As Exception
            MessageBox.Show("Error PlanillaBL CargaDesgloseCCSS :" & ex.Message)
        End Try
    End Function


    Public Function CargaDesgloseRenta()
        Try
            Dim tablaDesgloseRenta As DataTable
            tablaDesgloseRenta = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDesgloseRenta(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.SQL_Comman2)
            Class_VariablesGlobales.frmPlanilla.DGV_DesgloseRenta.DataSource = tablaDesgloseRenta
            ObtieneTotalRenta(tablaDesgloseRenta)
        Catch ex As Exception
            MessageBox.Show("Error PlanillaBL CargaDesgloseRenta :" & ex.Message)
        End Try
    End Function

    Public Function ObtieneTotalRenta(DesgloseRenta As DataTable)
        Try

            Dim Contador As Integer = 0
            Dim TotalRenta As Double = 0

            While Contador < DesgloseRenta.Rows.Count
                If DesgloseRenta.Rows(Contador).Item("Monto").ToString() <> "" Then
                    TotalRenta = TotalRenta + CDbl(DesgloseRenta.Rows(Contador).Item("Monto").ToString())
                End If
                Contador += 1
            End While

            Class_VariablesGlobales.frmPlanilla.txtb_TotalRentaPlanilla.Text = CStr(FormatCurrency(TotalRenta, 2))

        Catch ex As Exception
            MsgBox("Error en ObtieneTotalRenta " & ex.Message)
        End Try
    End Function



    Public Function ObtieneInfoPlanilla(IdPlanilla As Integer)
        Try
            Dim Estado As String
            Dim TblPlanilla As Object
            TblPlanilla = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInfoPlanillaXId(IdPlanilla, Class_VariablesGlobales.SQL_Comman2)

            If Not TblPlanilla Is Nothing And TblPlanilla.Rows.Count > 0 Then
                Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text = IdPlanilla
                Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text = TblPlanilla.Rows(0).Item("Cedula_Empresa")
                Class_VariablesGlobales.frmPlanilla.Txt_NombreEmpresa.Text = TblPlanilla.Rows(0).Item("Nombre_Empresa")
                Class_VariablesGlobales.frmPlanilla.DTP_FechaPlanillaDesde.Value = TblPlanilla.Rows(0).Item("FechaINI")
                Class_VariablesGlobales.frmPlanilla.DTP_FechaPlanillaHasta.Value = TblPlanilla.Rows(0).Item("FechaFIN")
                Class_VariablesGlobales.frmPlanilla.TxtBox_DescripcionPlanilla.Text = TblPlanilla.Rows(0).Item("Comentario")
                Estado = TblPlanilla.Rows(0).Item("Estado")

                If Estado.Equals("0") Then

                    Class_VariablesGlobales.frmPlanilla.CambiaEstadoBotones(True)
                    Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.Visible = False
                    Class_VariablesGlobales.frmPlanilla.btn_ImprimeRepEmpleado.Visible = False

                ElseIf Estado.Equals("1") Then

                    Class_VariablesGlobales.frmPlanilla.CambiaEstadoBotones(False)
                    Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.ForeColor = Color.Red
                    Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.Text = "ANULADA"
                    Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.Visible = True
                    Class_VariablesGlobales.frmPlanilla.btn_ImprimeRepEmpleado.Visible = False

                ElseIf Estado.Equals("2") Then
                    Class_VariablesGlobales.frmPlanilla.CambiaEstadoBotones(False)
                    Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.ForeColor = Color.Green
                    Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.Text = "FINALIZADA"
                    Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.Visible = True
                    Class_VariablesGlobales.frmPlanilla.btn_ImprimeRepEmpleado.Visible = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Function


    Public Function CreaPlanillaNueva(TipoPlanilla As Integer, FechaIni As String, FechaFin As String, Comentario As String, UsuarioCrea As String)
        Try
            Dim TblPlanilla As DataTable
            TblPlanilla = Class_VariablesGlobales.Obj_Funciones_SQL.CreaPlanillaNueva(TipoPlanilla, FechaIni, FechaFin, Comentario, UsuarioCrea, Class_VariablesGlobales.SQL_Comman2)
            Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.DataSource = TblPlanilla
        Catch ex As Exception

        End Try
    End Function
    Public Function CargarAdjunto(imageData As Byte(), Txtbox As TextBox, PBox_Adjunto As PictureBox)

        Try
            ' Si los datos de la imagen son válidos
            If imageData IsNot Nothing AndAlso imageData.Length > 0 Then
                ' Crea un flujo de memoria para almacenar los datos de la imagen
                Using stream As New MemoryStream(imageData)
                    ' Carga la imagen desde el flujo de memoria
                    Dim image As Image = Image.FromStream(stream)

                    ' Asigna la imagen al control PictureBox
                    PBox_Adjunto.Image = image

                    'Carga la imagen en espacio temporal
                    Dim tempPath As String = Path.GetTempFileName()
                    File.WriteAllBytes(tempPath, imageData)
                    Txtbox.Text = tempPath

                End Using
            Else

            End If

        Catch ex As Exception
            MessageBox.Show("Error al recuperar la imagen [ " & ex.Message & " ]")
        End Try

    End Function

End Class
