Imports System.Configuration
Imports System.IO
Imports System.Net.Mail
Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Office.Interop.Excel
Imports SincroCliente.DTO_Planilla

Public Class Planilla
    Public Obj_List_Empleados As New Planilla_List_Empleados
    Public Obj_Mformat As New MonedaFormat
    Dim Empleado As New PlanillaEmpleadoViewModel()

    Dim trd1 As Thread
    Public SalarioQuincenal, SalarioFinal As Double
    Dim ObjPlanillaBL As New PlanillaBL

    'TODO.

    'Revisar calculo de deducciones
    'Hacer pruebas general
    'Crear SP que permita la finalizacion de la planilla y todas las tablas relacionadas a la planillas, ademas de cambiarle el estado a los registros 
    'de las tablas relacionadas al empleado para que no sean tomados en cuenta en la proxima planilla

    'Hacer el proceso de recorrer cada empleado y crear un unico asiento contable
    'Para hacer pruebas cambiar la DB en los sp para que se use el nombre de la db de la conexion, basicamente eliminar el nombre de la db
    'Hacer el proceso de recorrer cada factura y crear un recibo de dinero en sap

    Private Sub Planilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Aumentar el tamaño de la fuente en el DataGridView


        DTGV_Planilla.RowTemplate.Height = 30 ' Establecer la altura de fila deseada (incluyendo el espacio adicional)

        If DTGV_Planilla.Columns.Contains("Listo") = False Then
            Dim col1 As New DataGridViewCheckBoxColumn
            col1.HeaderText = "Listo"
            col1.Name = "Listo"

            DTGV_Planilla.Columns.Add(col1)
        End If

        PictureBox_FotoEmpleado.Image = My.Resources.SinFoto

        Dim IdPlanillas As Integer = ValidaExistenciaDePlanillaEnCreacion()
        If IdPlanillas <> 0 Then
            MsgBox("Existe una planilla en proceso de creacion")
            PlanillaExistente(IdPlanillas)
            CambiaEstadoBotones(True)
        Else
            ConfiguracionPlanillaNueva(IdPlanillas)
        End If

        DTGV_Planilla.ClearSelection()
    End Sub



    ''' <summary>
    ''' Marca el check de las filas que tiene un estado en confirmado 
    ''' </summary>
    ''' <returns></returns>
    Public Function MarcaEstado()
        DTGV_Planilla.ClearSelection()
        For Each row As DataGridViewRow In DTGV_Planilla.Rows

            ' Obtén la celda de casilla de verificación específica
            Dim celda As DataGridViewCheckBoxCell = CType(row.Cells(0), DataGridViewCheckBoxCell)

            If row.Cells("Estado").Value = 2 Then
                ' Establecemos el valor de la casilla de verificación en True
                celda.Value = True
                row.DefaultCellStyle.BackColor = Color.Gray
                row.DefaultCellStyle.ForeColor = Color.White
            Else
                celda.Value = False
                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Black
            End If

        Next
    End Function



    Public Function ValidaExistenciaDePlanillaEnCreacion()

        Try


            Return ObjPlanillaBL.ValidaExistenciaDePlanillaEnCreacion()


        Catch ex As Exception
            MessageBox.Show("Error ValidaExistenciaDePlanillaEnCreacion :" & ex.Message)

            Return 0
        End Try
    End Function
    Public Function PlanillaExistente(IdPlanilla As Integer)
        ObjPlanillaBL.PlanillaExistente(IdPlanilla)

        ConfiguracionPlanillaNueva(IdPlanilla)
    End Function

    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DTGV_Planilla.CellBeginEdit
        ' Verificar si la celda es la columna donde se encuentra el CheckBox
        If e.ColumnIndex = 0 Then
            ' Cancelar la edición de la celda
            e.Cancel = True
        End If
    End Sub

    Private Sub DTGV_Planilla_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DTGV_Planilla.DataBindingComplete
        OrganizaColumnasPlanilla()



        ' Ejemplo: Ajustar el ancho de las columnas automáticamente para que se ajusten al contenido.
        DTGV_Planilla.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    Private Sub DGV_DesgloseCCSS_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGV_DesgloseCCSS.DataBindingComplete

        ' Ejemplo: Ajustar el ancho de las columnas automáticamente para que se ajusten al contenido.
        DGV_DesgloseCCSS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    Private Sub DGV_DesgloseRenta_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGV_DesgloseRenta.DataBindingComplete

        ' Ejemplo: Ajustar el ancho de las columnas automáticamente para que se ajusten al contenido.
        DGV_DesgloseRenta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    ''' <summary>
    ''' Permite cargar la configuracion inicial o la base de una planilla
    ''' </summary>
    ''' <returns></returns>
    Public Function ConfiguracionPlanillaNueva(IdPlanilla As Integer)
        Try
            ObtieneInfoPlanilla(IdPlanilla)
            If IdPlanilla = 0 Then
                ObtieneIdPlanillaNueva()
            End If

            ObtieneInformacionEmpresa()
            CargaDesgloseCCSS()
            CargaDesgloseRenta()
        Catch ex As Exception
            MsgBox("Error en CargaConfiguraciones")
        End Try
    End Function

    Public Function ObtieneIdPlanillaNueva()
        Txb_id_Planilla.Text = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_ID_Planilla(Class_VariablesGlobales.SQL_Comman2)
    End Function
    Public Function ObtieneInformacionEmpresa()
        ObjPlanillaBL.ObtieneInformacionEmpresa()
    End Function

    ''' <summary>
    ''' Carga los aportes tanto del patrono como del empleado segun la pagina del ccss https://www.ccss.sa.cr/calculadora
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaDesgloseCCSS()
        ObjPlanillaBL.CargaDesgloseCCSS()
    End Function

    Public Function CargaDesgloseRenta()
        ObjPlanillaBL.CargaDesgloseRenta()

    End Function


    ''' <summary>
    ''' Permite crear una planilla, carga los empleados asi como sus deducciones, facturas a rebajar
    ''' </summary>
    ''' <param name="FechaIni"></param>
    ''' <param name="FechaFin"></param>
    ''' <param name="Comentario"></param>
    ''' <param name="UsuarioCrea"></param>
    ''' <returns></returns>
    Public Function CreaPlanillaNueva(TipoPlanilla As Integer, FechaIni As String, FechaFin As String, Comentario As String, UsuarioCrea As String)

        ObjPlanillaBL.CreaPlanillaNueva(TipoPlanilla, FechaIni, FechaFin, Comentario, UsuarioCrea)
        ConfiguracionPlanillaNueva(Txb_id_Planilla.Text.Trim())
    End Function


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EmplAdelante.Click
        AdelanteAbajoEmpleado()
    End Sub
    Private Sub btn_EmplAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EmplAtras.Click
        AtrasArribaEmpleado()
    End Sub
    Public Function AtrasArribaEmpleado()
        Try


            If Txt_IdEmpleado.Text = "" Then
                Txt_IdEmpleado.Text = "0"
            End If
            Btn_PlanillaAtras.Enabled = True

            Dim ID = CInt(Txt_IdEmpleado.Text) - 1
            If ID >= 0 Then
                DTGV_Planilla.ClearSelection()
                DTGV_Planilla.Rows(ID).Selected = True
                ' Verificar si hay al menos una fila seleccionada
                If DTGV_Planilla.SelectedRows.Count > 0 Then
                    Dim filaSeleccionada As DataGridViewRow = DTGV_Planilla.SelectedRows(0)
                    ObtieneInfoEmpleadoPlanilla(filaSeleccionada)
                    filaSeleccionada.Selected = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Function AdelanteAbajoEmpleado()
        If Txt_IdEmpleado.Text = "" Then
            Txt_IdEmpleado.Text = "0"
        End If
        Btn_PlanillaAtras.Enabled = True

        Dim ID = CInt(Txt_IdEmpleado.Text) + 1
        If ID < DTGV_Planilla.Rows.Count Then
            DTGV_Planilla.ClearSelection()
            DTGV_Planilla.Rows(ID).Selected = True
            ' Verificar si hay al menos una fila seleccionada
            If DTGV_Planilla.SelectedRows.Count > 0 Then
                Dim filaSeleccionada As DataGridViewRow = DTGV_Planilla.SelectedRows(0)
                ObtieneInfoEmpleadoPlanilla(filaSeleccionada)
                filaSeleccionada.Selected = True
            End If


            DTGV_Planilla.FirstDisplayedScrollingRowIndex = ID
        Else
            MsgBox("Ha llegado al ultimo empleado")

        End If
    End Function

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PlanillaAdelante.Click
        Dim backupIdPlanilla As String = Txb_id_Planilla.Text
        Limpiar()
        If Txb_id_Planilla.Text = "" Then
            Txb_id_Planilla.Text = "0"
        End If
        Btn_PlanillaAtras.Enabled = True

        PlanillaExistente(CInt(backupIdPlanilla) + 1)

        'Dim Empleado As New DataTable
        'Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Planilla(CInt(Txb_id_Planilla.Text) + 1, Class_VariablesGlobales.SQL_Comman2)
        'NavegaPlanilla(Empleado)

    End Sub

    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PlanillaAtras.Click
        Dim backupIdPlanilla As String = Txb_id_Planilla.Text
        Limpiar()
        If Txb_id_Planilla.Text = "" Then
            Txb_id_Planilla.Text = "0"
        End If
        Btn_PlanillaAtras.Enabled = True
        PlanillaExistente(CInt(backupIdPlanilla) - 1)

        'Dim Empleado As New DataTable
        'Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Planilla(CInt(Txb_id_Planilla.Text) - 1, Class_VariablesGlobales.SQL_Comman2)
        'NavegaPlanilla(Empleado)

    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim TapPlanilla As Integer = 1
        Dim TapConfiguraciones As Integer = 2
        If (TabControl1.SelectedIndex = TapConfiguraciones) Then
            CargaDesgloseCCSS()
            CargaDesgloseRenta()
        End If

    End Sub
    Public Function Limpiar()
        Txb_id_Planilla.Text = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_ID_Planilla(Class_VariablesGlobales.SQL_Comman2)

        txtb_TotalPlanilla.Text = ""
        Txt_CedJuridica.Text = ""
        Txt_NombreEmpresa.Text = ""
        TxtBox_DescripcionPlanilla.Text = ""

        Lbl_EstadoPlanilla.Text = ""

        Lbl_EstadoPlanilla.Visible = False


        Txt_IdEmpleado.Text = ""
        Txb_CedulaEmpleado.Text = ""
        Txb_Puesto.Text = ""
        txtb_NombreEmpleado.Text = ""
        Txb_Salario.Text = "0"

        Txb_SalarioQuincenal.Text = "0"
        SalarioQuincenal = 0
        Txb_RutaImagen.Text = ""
        Txb_CodigoEmpleado.Text = ""
        TxtBox_DiasLaborados.Text = "0"

        Txb_TotalDeducciones.Text = "0"
        Txb_TotalValesPrestamos.Text = "0"
        Txb_TotalFaltantesLiquidacion.Text = "0"
        Txb_TotalFacturas.Text = "0"
        Txb_TotalCCSS.Text = "0"
        Txb_TotalRenta.Text = "0"
        Txb_TotalIncapacidades.Text = "0"
        TxtBox_SalarioFinal.Text = "0"
        SalarioFinal = 0

        Txtb_AguinaldoEmpleado.Text = "0"
        Txtb_CesantiaPreavisoEmpleado.Text = "0"
        TxtBox_Correo.Text = "0"

        DTP_FechaPlanillaDesde.Value = Now.Date
        DTP_FechaPlanillaHasta.Value = Now.Date
        DTGV_Planilla.DataSource = Nothing
        DGV_DesgloseCCSS.DataSource = Nothing
        DGV_DesgloseRenta.DataSource = Nothing
        Btn_CambiaEmpleadoAConfirmado.BackColor = Color.RoyalBlue
        Btn_CambiaEmpleadoAConfirmado.Text = "Listo"
        'TODO PONER UNA FOTO POR DEFECTO O LIMPIAR EL CONTROL DE LA FOTO
        PictureBox_FotoEmpleado.Image = My.Resources.SinFoto
        CambiaEstadoBotones(False)
    End Function

    Private Sub DGV_DesgloseCCSS_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
            If e.ColumnIndex = 3 Or e.ColumnIndex = 5 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

                ' Aplicar formato personalizado al valor de la celda de la columna de precios
                Dim precio As Double = CDbl(e.Value)
                e.Value = precio.ToString("C7") ' Aplicar formato de moneda
                e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGV_DesgloseRenta_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 4 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

                ' Aplicar formato personalizado al valor de la celda de la columna de precios
                Dim precio As Double = CDbl(e.Value)
                e.Value = precio.ToString("C7") ' Aplicar formato de moneda
                e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function CambiaEstadoBotones(Estado As Boolean)

        Btn_CambiaEmpleadoAConfirmado.Enabled = Estado
        btn_EmplAtras.Enabled = Estado
        Btn_EmplAdelante.Enabled = Estado

        If Class_VariablesGlobales.Obj_Funciones_SQL.ValidaExisteError(Txb_id_Planilla.Text.Trim(), Class_VariablesGlobales.SQL_Comman2) Then
            Btn_EnviarPlanilla.Enabled = True
        Else
            'Btn_EnviarPlanilla.Enabled = Estado
        End If

        Btn_AnulaPlanilla.Enabled = Estado
        Btn_AbreDetalleDeducciones.Enabled = Estado
        Btn_AbreDetalleValesPrestamos.Enabled = Estado
        Btn_AbreDetalleFaltanteLiquidacion.Enabled = Estado
        Btn_AbreDetalleFacturas.Enabled = Estado
        Btn_AbreDetalleCCSS.Enabled = Estado
        Btn_AbreDetalleRenta.Enabled = Estado
        Btn_AbreDetalleIncapacidades.Enabled = Estado
        Btn_ImprimirPlanilla.Enabled = Estado

        If Lbl_EstadoPlanilla.Text = "FINALIZADA" Then
            btn_ImprimeRepEmpleado.Visible = True
            btn_ImprimeRepEmpleado.Enabled = True
        Else
            btn_ImprimeRepEmpleado.Visible = False
        End If

    End Function
    Private Sub DTGV_Planilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DTGV_Planilla.CellContentClick
        Try
            ObtieneInfoEmpleadoPlanilla(DTGV_Planilla.CurrentRow)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DTGV_Planilla_KeyDown(sender As Object, e As KeyEventArgs) Handles DTGV_Planilla.KeyDown
        Try
            If e.KeyCode = Keys.Up Then
                AtrasArribaEmpleado()
            ElseIf e.KeyCode = Keys.Down Then
                AdelanteAbajoEmpleado()
            ElseIf e.KeyCode = Keys.Left Then
            ElseIf e.KeyCode = Keys.Right Then
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function ObtieneInfoEmpleadoPlanilla(filaSeleccionada As DataGridViewRow)
        Try


            Txb_CedulaEmpleado.Text = filaSeleccionada.Cells.Item(1).Value.ToString()
            txtb_NombreEmpleado.Text = filaSeleccionada.Cells.Item(2).Value.ToString()
            Txb_Puesto.Text = filaSeleccionada.Cells.Item(3).Value.ToString()
            Txb_Salario.Text = Convert.ToDecimal(filaSeleccionada.Cells.Item(4).Value).ToString("C2")
            Txb_SalarioQuincenal.Text = Convert.ToDecimal(filaSeleccionada.Cells.Item(5).Value).ToString("C2")
            SalarioQuincenal = Convert.ToDecimal(filaSeleccionada.Cells.Item(5).Value).ToString("C7")
            Txtb_AguinaldoEmpleado.Text = Convert.ToDecimal(filaSeleccionada.Cells.Item(6).Value).ToString("C2")
            Txt_IdEmpleado.Text = filaSeleccionada.Index
            Txb_id_Planilla.Text = filaSeleccionada.Cells.Item(10).Value.ToString()
            Txb_TotalRenta.Text = Convert.ToDecimal(filaSeleccionada.Cells.Item(11).Value).ToString("C2")
            TxtBox_Correo.Text = filaSeleccionada.Cells.Item(12).Value.ToString()
            Txb_CodigoEmpleado.Text = filaSeleccionada.Cells.Item(13).Value.ToString()
            TxtBox_CuentaDeducirPlanilla.Text = filaSeleccionada.Cells.Item(15).Value.ToString()
            TxtBox_DiasLaborados.Text = filaSeleccionada.Cells.Item(18).Value.ToString()
            Txtb_CesantiaPreavisoEmpleado.Text = Convert.ToDecimal(filaSeleccionada.Cells.Item(19).Value).ToString("C2")

            Btn_CambiaEmpleadoAConfirmado.Text = "Listo"
            Btn_CambiaEmpleadoAConfirmado.BackColor = Color.Green

            Txb_RutaImagen.Text = filaSeleccionada.Cells.Item(7).Value.ToString()
            Dim Adjunto As Object = filaSeleccionada.Cells.Item(8).Value.ToString()

            If Adjunto IsNot DBNull.Value And Adjunto <> "" Then
                Dim FotoEmpleadoBytes As Byte() = DirectCast(filaSeleccionada.Cells.Item(8).Value, Byte())

                ObjPlanillaBL.CargarAdjunto(FotoEmpleadoBytes, Txb_RutaImagen, PictureBox_FotoEmpleado)
            Else
                'TODO PONER UNA FOTO POR DEFECTO O LIMPIAR EL CONTROL DE LA FOTO
                PictureBox_FotoEmpleado.Image = My.Resources.SinFoto
            End If

            CargaTotalRebajos(Txb_id_Planilla.Text, Txb_CedulaEmpleado.Text)

        Catch ex As Exception
            MessageBox.Show("Error ObtieneInfoEmpleadoPlanilla " & ex.Message)


        End Try
    End Function

    Public Function CargaTotalRebajos(IdPlanilla As Integer, Cedula_Empleado As String)
        Try
            Dim TotalDeducciones As Double = Class_VariablesGlobales.Obj_Funciones_SQL.CargaTotalRebajos(IdPlanilla, Cedula_Empleado, 0)
            Dim TotalValesPrestamos As Double = Class_VariablesGlobales.Obj_Funciones_SQL.CargaTotalRebajos(IdPlanilla, Cedula_Empleado, 1)
            Dim TotalFaltantesLiquidacion As Double = Class_VariablesGlobales.Obj_Funciones_SQL.CargaTotalRebajos(IdPlanilla, Cedula_Empleado, 2)
            Dim TotalFacturas As Double = Class_VariablesGlobales.Obj_Funciones_SQL.CargaTotalRebajos(IdPlanilla, Cedula_Empleado, 3)
            Dim TotalCCSS As Double = Class_VariablesGlobales.Obj_Funciones_SQL.CargaTotalRebajos(IdPlanilla, Cedula_Empleado, 4)
            Dim TotalIncapacidades As Double = Class_VariablesGlobales.Obj_Funciones_SQL.CargaTotalRebajos(IdPlanilla, Cedula_Empleado, 5)
            Dim TotalRenta As Double = Class_VariablesGlobales.Obj_Funciones_SQL.CargaTotalRebajos(IdPlanilla, Cedula_Empleado, 6)
            Dim salario As Double = CDbl(SalarioQuincenal)

            salario -= TotalDeducciones
            salario -= TotalValesPrestamos
            salario -= TotalFaltantesLiquidacion
            salario -= TotalFacturas
            salario -= TotalCCSS
            salario += TotalIncapacidades
            salario -= TotalRenta

            If salario < 0 Then
                TxtBox_SalarioFinal.BackColor = Color.Red
                TxtBox_SalarioFinal.ForeColor = Color.White
            Else
                TxtBox_SalarioFinal.BackColor = Color.White
                TxtBox_SalarioFinal.ForeColor = Color.Black
            End If

            'Todo lo demás permanece igual
            'Da formato a valores para ser mostrados
            Txb_TotalDeducciones.Text = Convert.ToDecimal(TotalDeducciones).ToString("C2")
            Txb_TotalValesPrestamos.Text = Convert.ToDecimal(TotalValesPrestamos).ToString("C2")
            Txb_TotalFaltantesLiquidacion.Text = Convert.ToDecimal(TotalFaltantesLiquidacion).ToString("C2")
            Txb_TotalFacturas.Text = Convert.ToDecimal(TotalFacturas).ToString("C2")
            Txb_TotalCCSS.Text = Convert.ToDecimal(TotalCCSS).ToString("C2")
            Txb_TotalIncapacidades.Text = Convert.ToDecimal(TotalIncapacidades).ToString("C2")
            Txb_TotalRenta.Text = Convert.ToDecimal(TotalRenta).ToString("C2")
            TxtBox_SalarioFinal.Text = Convert.ToDecimal(salario).ToString("C2")
            SalarioFinal = Convert.ToDecimal(salario).ToString("C7")

            Dim TotalPlanilla As Double = CalcularTotalPlanilla(IdPlanilla)
            txtb_TotalPlanilla.Text = Convert.ToDecimal(TotalPlanilla).ToString("C2")

        Catch ex As Exception
            MsgBox("Error al obtener las CargaTotalRebajos [" & ex.Message & "]")
        End Try
    End Function

    Public Function MuestraDosDecimalesSinRedondear(Valor As Double)
        Return Math.Floor(Valor * 100) / 100
    End Function

    Public Function CalcularTotalPlanilla(IdPlanilla As Integer)
        Return Class_VariablesGlobales.Obj_Funciones_SQL.CalcularTotalPlanilla(IdPlanilla, Class_VariablesGlobales.SQL_Comman2)
    End Function

    Private Sub DTGV_Planilla_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DTGV_Planilla.CellFormatting
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 19 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) Then
            Try
                'Aplicar formato personalizado al valor de la celda de la columna de precios
                Dim precio As Double = CDbl(e.Value)
                e.Value = precio.ToString("C2") ' Aplicar formato de moneda
                e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btn_NuevaPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NuevaPlanilla.Click

        Dim IdPlanillas As Integer = ValidaExistenciaDePlanillaEnCreacion()
        If IdPlanillas <> 0 Then
            MsgBox("No puede crear una nueva planilla porque existe una planilla en proceso de creación \n Anule la planilla actual o finalice el proceso para crear una nueva planilla")
        Else
            Limpiar()
            Class_VariablesGlobales.frmPlanillaNueva = New PlanillaNueva
            Class_VariablesGlobales.frmPlanillaNueva.MdiParent = Principal
            Class_VariablesGlobales.frmPlanillaNueva.Show()
        End If
    End Sub

    Private Sub Btn_AbreDetalleDeducciones_Click(sender As Object, e As EventArgs) Handles Btn_AbreDetalleDeducciones.Click
        Class_VariablesGlobales.frmPlanilla_DetalleDeducciones = New Planilla_DetalleDeducciones
        Class_VariablesGlobales.frmPlanilla_DetalleDeducciones.MdiParent = Principal
        Class_VariablesGlobales.frmPlanilla_DetalleDeducciones.Show()
    End Sub

    Private Sub Btn_AbreDetalleValesPrestamos_Click(sender As Object, e As EventArgs) Handles Btn_AbreDetalleValesPrestamos.Click
        Class_VariablesGlobales.frmPlanilla_DetalleValesPrestamos = New Planilla_DetalleValesPrestamos
        Class_VariablesGlobales.frmPlanilla_DetalleValesPrestamos.MdiParent = Principal
        Class_VariablesGlobales.frmPlanilla_DetalleValesPrestamos.Show()
    End Sub

    Private Sub Btn_AbreDetalleFaltanteLiquidacion_Click(sender As Object, e As EventArgs) Handles Btn_AbreDetalleFaltanteLiquidacion.Click
        Class_VariablesGlobales.frmPlanilla_DetalleFaltantesLiquidacion = New Planilla_DetalleFaltantesLiquidacion
        Class_VariablesGlobales.frmPlanilla_DetalleFaltantesLiquidacion.MdiParent = Principal
        Class_VariablesGlobales.frmPlanilla_DetalleFaltantesLiquidacion.Show()
    End Sub

    Private Sub Btn_AbreDetalleFacturas_Click(sender As Object, e As EventArgs) Handles Btn_AbreDetalleFacturas.Click
        Class_VariablesGlobales.frmPlanilla_DetalleFacturas = New Planilla_DetalleFacturas
        Class_VariablesGlobales.frmPlanilla_DetalleFacturas.MdiParent = Principal
        Class_VariablesGlobales.frmPlanilla_DetalleFacturas.Show()
    End Sub

    Private Sub Btn_AbreDetalleCCSS_Click(sender As Object, e As EventArgs) Handles Btn_AbreDetalleCCSS.Click
        Class_VariablesGlobales.frmPlanilla_DetalleCCSS = New Planilla_DetalleCCSS
        Class_VariablesGlobales.frmPlanilla_DetalleCCSS.MdiParent = Principal
        Class_VariablesGlobales.frmPlanilla_DetalleCCSS.Show()
    End Sub

    Private Sub Btn_AbreDetalleRenta_Click(sender As Object, e As EventArgs) Handles Btn_AbreDetalleRenta.Click
        Class_VariablesGlobales.frmPlanilla_DetalleRenta = New Planilla_DetalleRenta
        Class_VariablesGlobales.frmPlanilla_DetalleRenta.MdiParent = Principal
        Class_VariablesGlobales.frmPlanilla_DetalleRenta.Show()
    End Sub

    Private Sub Btn_AnulaPlanilla_Click(sender As Object, e As EventArgs) Handles Btn_AnulaPlanilla.Click

        If Txb_id_Planilla.Text = "" Then
            MsgBox("Debe seleccionar o crear una planilla antes de anular")
            Exit Sub
        End If

        Dim Pregunta As Integer
        Pregunta = MsgBox("Si anula la planilla no podra reverzar este movimeinto ¿Esta Seguro que desea anular la planilla  [" & Txb_id_Planilla.Text & "]?.", vbYesNo + vbExclamation + vbDefaultButton2, "Anular Planilla")
        If Pregunta = vbYes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.AnulaPlanilla(Txb_id_Planilla.Text, Class_VariablesGlobales.SQL_Comman2)
            Limpiar()
        Else

        End If
        Pregunta = Nothing

    End Sub

    Private Sub btn_ImprimeRepEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ImprimeRepEmpleado.Click
        If Txb_CedulaEmpleado.Text.Trim().Equals("") Then
            MsgBox("Seleccione a un empleado")
            Exit Sub

        End If
        If MandaColillaPagoXCorreo(Txb_CedulaEmpleado.Text,
                                Txb_id_Planilla.Text,
                                TxtBox_Correo.Text) Then
            MsgBox("Colilla de pago enviada con exito")
        Else
            MsgBox("Hubo un error al enviar la colilla de pago", MsgBoxStyle.Critical)
        End If

        'PlanillaReport.Show()
        'EnviarColillaPago()
    End Sub

    Public Function MandaColillaPagoXCorreo(CedulaEmpleado As String, IdPlanilla As String, CorreoEmpleado As String)
        Try

            ' Crear una lista de destinatarios de correo electrónico
            Dim documentosDir As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            ' Nombre de la carpeta que quieres crear
            Dim carpetaColillasDePago As String = documentosDir & "\Planillas\" & IdPlanilla & "\ColillasDePago"
            Dim file As String = carpetaColillasDePago & "\" & CedulaEmpleado & ".PDF"
            Dim destinatarios As New List(Of String)()

            ' Si estamos en modo de depuración, añadir un correo de ejemplo (por ejemplo, "lurobaca@gmail.com")

            'destinatarios.Add("lurobaca@gmail.com")
            destinatarios.Add(CorreoEmpleado)

            ' Si no estamos en modo de depuración, añadir el correo del empleado

            Class_VariablesGlobales.Obj_MAIL.EnviarCorreo("Se adjunta su colilla de pago de la planilla [" & IdPlanilla & "] " & TxtBox_DescripcionPlanilla.Text, "Colilla de Pago", file, destinatarios)




            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarPlanila.Click
        Lista_Planillas.Show()


    End Sub
    Private Sub Btn_GuardarDeduccion_Click(sender As Object, e As EventArgs) Handles Btn_CambiaEmpleadoAConfirmado.Click
        Listo()

    End Sub

    Public Function Listo()

        If Txb_CedulaEmpleado.Text.Trim().Equals("") Then
            MsgBox("Seleccione a un empleado")
            Exit Function
        End If


        If TxtBox_SalarioFinal.Text.Trim().Equals("") = False And CDbl(TxtBox_SalarioFinal.Text.Trim()) < 0 Then
            MsgBox("El salario neto no puede ser negativo")
            Exit Function
        End If

        ' Limpiar los datos actuales del DataGridView
        DTGV_Planilla.DataSource = Nothing
        DTGV_Planilla.Rows.Clear()
        ' DTGV_Planilla.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaPlanillaEmpleado(Txb_id_Planilla.Text.Trim(), Txb_CedulaEmpleado.Text.Trim(), SalarioFinal, Class_VariablesGlobales.SQL_Comman2)

        DTGV_Planilla.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.CalculaSalarioFinal(Txb_id_Planilla.Text.Trim(), Txb_CedulaEmpleado.Text.Trim(), SalarioFinal, Class_VariablesGlobales.SQL_Comman2)


        AdelanteAbajoEmpleado()
    End Function
    ''' <summary>
    ''' Extra la informacion de la tabla planilla para validar 
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtieneInfoPlanilla(IdPlanilla As Integer)
        ObjPlanillaBL.ObtieneInfoPlanilla(IdPlanilla)

    End Function
    Public Function OrganizaColumnasPlanilla()
        Try


            DTGV_Planilla.Columns(2).Width = 250
            DTGV_Planilla.Columns(7).Visible = False
            DTGV_Planilla.Columns(8).Visible = False
            DTGV_Planilla.Columns(9).Visible = False
            DTGV_Planilla.Columns(10).Visible = False
            DTGV_Planilla.Columns(11).Visible = False
            DTGV_Planilla.Columns(12).Visible = False
            DTGV_Planilla.Columns(13).Visible = False
            DTGV_Planilla.Columns(14).Visible = False
            DTGV_Planilla.Columns(15).Visible = False
            DTGV_Planilla.Columns(16).Visible = False
            DTGV_Planilla.Columns(17).Visible = False
            DTGV_Planilla.Columns(18).Visible = False
            MarcaEstado()
            Dim TotalPlanilla As Double = CalcularTotalPlanilla(Txb_id_Planilla.Text())
            txtb_TotalPlanilla.Text = CStr(FormatCurrency(TotalPlanilla, 2))
        Catch ex As Exception

        End Try
    End Function

    Public Function NavegaPlanilla(ByVal Planila As DataTable)

        'Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.DataSource = Planila

        'Class_VariablesGlobales.Contador = 0
        'If Planila.Rows.Count > 0 Then
        '    While Class_VariablesGlobales.Contador < Planila.Rows.Count
        '        Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Ced_Empleado").ToString()
        '        Class_VariablesGlobales.frmPlanilla.txtb_NombreEmpleado.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("NombreEmpleado").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txb_Puesto.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Puesto").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txb_Salario.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Salario").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("SalarioQuincenal").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txb_TotalDeducciones.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("DEDUCION_DE_CELULAR").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txb_TotalFaltantesLiquidacion.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("FALTANTES_LIQ").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txb_TotalFacturas.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("FACTURAS").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txb_TotalCCSS.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Dedu_CCSS").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("id").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Ced_Juridica").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txt_NombreEmpresa.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Nombre").ToString()
        '        Class_VariablesGlobales.frmPlanilla.DTP_FechaIngreso.Value = Planila.Rows(Class_VariablesGlobales.Contador).Item("FechaINI").ToString()
        '        Class_VariablesGlobales.frmPlanilla.DTP_FechaSalida.Value = Planila.Rows(Class_VariablesGlobales.Contador).Item("FechaFIN").ToString()

        '        Class_VariablesGlobales.frmPlanilla.Txb_RutaImagen.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Foto").ToString()
        '        Class_VariablesGlobales.frmPlanilla.Txt_IdEmpleado.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("id_Empleado").ToString()
        '        Class_VariablesGlobales.Contador += 1
        '    End While
        'End If
    End Function

    Private Sub Btn_AbreDetalleIncapacidades_Click(sender As Object, e As EventArgs) Handles Btn_AbreDetalleIncapacidades.Click
        Class_VariablesGlobales.frmPlanilla_DetalleIncapacidades = New Planilla_DetalleIncapacidades
        Class_VariablesGlobales.frmPlanilla_DetalleIncapacidades.MdiParent = Principal
        Class_VariablesGlobales.frmPlanilla_DetalleIncapacidades.Show()
    End Sub

    Private Function Btn_EnviarPlanilla_Click(sender As Object, e As EventArgs) Handles Btn_EnviarPlanilla.Click

        If (ValidaQueTodoEmpleadoSeaChequeado() = False) Then Return False

        Class_VariablesGlobales.frmFinalizarPlanilla = New Planilla_Finalizar
        Class_VariablesGlobales.frmFinalizarPlanilla.MdiParent = Principal
        Class_VariablesGlobales.frmFinalizarPlanilla.Show()
    End Function

    Private Function Btn_ImprimirPlanilla_Click(sender As Object, e As EventArgs) Handles Btn_ImprimirPlanilla.Click

        If Lbl_EstadoPlanilla.Text <> "FINALIZADA" Then
            MessageBox.Show("Solo las planillas finalizadas se pueden imprimir")
            Return True
        End If

        If (ValidaQueTodoEmpleadoSeaChequeado() = False) Then Return False

        Class_VariablesGlobales.Planilla_IdPlanilla = Txb_id_Planilla.Text
        Class_VariablesGlobales.ObjfrmReporte = New frmReporte
        Class_VariablesGlobales.ObjfrmReporte.ImprimirPlanilla()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_AbrirArchivosPlanilla.Click

        Dim documentosDir As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ' Nombre de la carpeta que quieres crear
        Dim ruta As String = documentosDir & "\Planillas\" & Txb_id_Planilla.Text.Trim() & "\"

        ' Verifica si la ruta existe antes de intentar abrirla
        If System.IO.Directory.Exists(ruta) Then
            ' Abre la ruta en el explorador de archivos
            Process.Start("explorer.exe", ruta)
        Else
            MessageBox.Show("La ruta especificada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



    Private Sub Btn_Exportar_Click(sender As Object, e As EventArgs) Handles Btn_Exportar.Click

        Dim Pregunta As Integer

        Pregunta = MsgBox("¿Esta Seguro que desea exportar a excel la planilla  [" & Txb_id_Planilla.Text & "]?.", vbYesNo + vbExclamation + vbDefaultButton2, "Exportar planilla a excel")
        If Pregunta = vbYes Then
            Me.Enabled = False
            ' Cambiar el cursor a espera
            Me.Cursor = Cursors.WaitCursor

            Dim ObjExcel As New ExportarAExcell()
            ObjExcel.ExportarPlanillaAExcel()
            'exporta asiento

            ObjExcel = New ExportarAExcell()
            ObjExcel.ExportarAsientoContableAExcel()

            Me.Enabled = True
            'Restaurar el cursor predeterminado
            Me.Cursor = Cursors.Default
        Else

        End If
        Pregunta = Nothing

    End Sub


    Private Sub BuscarEnDataGridView(ByVal textoBusqueda As String)
        Try
            For Each fila As DataGridViewRow In DTGV_Planilla.Rows
                Dim celda As DataGridViewCell = fila.Cells(2)
                If Not celda.Value Is Nothing AndAlso celda.Value.ToString().Contains(textoBusqueda) Then
                    fila.Selected = True
                    DTGV_Planilla.CurrentCell = celda
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            ' Manejar cualquier excepción que ocurra durante la búsqueda aquí.
        End Try
    End Sub

    Private Sub Btn_BusarEmpleadoEnPlanilla_Click(sender As Object, e As EventArgs) Handles Btn_BusarEmpleadoEnPlanilla.Click
        BuscarEnDataGridView(TxtbBuscaEmpleadoDentroDePlanila.Text)
    End Sub

    Public Function ValidaQueTodoEmpleadoSeaChequeado()
        Dim TodosLosEmpleadosCheuqueado As Integer = Class_VariablesGlobales.Obj_Funciones_SQL.ValidaQueTodoEmpleadoSeaChequeado(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.SQL_Comman2)

        'Valida si ya todos los empleados esta revisados
        If TodosLosEmpleadosCheuqueado <> 0 Then
            MsgBox("Verifique que todos los empleados hayan sido revisados")
            Return False
        End If
        Return True
    End Function



    Public Function IsDevelopmentEnvironment() As Boolean
        Dim environment As String = ConfigurationManager.AppSettings("Environment")
        Return environment IsNot Nothing AndAlso environment.ToLower() = "development"
    End Function
End Class