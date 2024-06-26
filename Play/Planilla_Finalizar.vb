Imports System.Threading
Imports SincroCliente.DTO_Planilla
Imports SincroCliente.EstructuraTxTBanco

Public Class Planilla_Finalizar
    Dim trd1 As Thread
    ' Método para configurar el estilo de la celda y ajustar automáticamente el tamaño de las columnas
    Private Sub ConfigurarEstiloCelda()
        ' Cambiar el tamaño del texto en todas las celdas del DataGridView
        DGV_Resultado.DefaultCellStyle.Font = New Font("Arial", 12)

        ' Ajustar automáticamente el tamaño de las columnas al contenido
        DGV_Resultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub
    Private Sub EnviandoPlanilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConfigurarEstiloCelda()
        DGV_Resultado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneResultados(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text)
        AplicaColorAFilaConError()
    End Sub

    Public Function Ejecutar()
        Try
            Dim PlanillaFinalizada As Boolean = True

            Dim ObjResultados As New Resultados
            ObjResultados.Mensajes = New Resultados.MensajesPasos()

            ObjResultados.IdPlanilla = Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text.Trim()

            'Valida si ya todos los empleados esta revisados
            If ValidaQueTodoEmpleadoSeaChequeado() <> 0 Then
                MsgBox("Verifique que todos los empleados hayan sido revisados")
                Return False
            End If

            ObjResultados.ListaMensajesPasos = New List(Of Resultados.MensajesPasos)()
            ObjResultados.ListaMensajesSap = New List(Of Resultados.MensajesSap)()

            If ValidaPasoExitoso(1, ObjResultados.IdPlanilla.Trim()) Then
                If FuncionGeneraTxt(ObjResultados) Then
                    PlanillaFinalizada = False
                End If

            End If

            If ValidaPasoExitoso(2, ObjResultados.IdPlanilla.Trim()) Then
                If FuncionEnviarColillaPago(ObjResultados) Then
                    PlanillaFinalizada = False
                End If
            End If

            If ValidaPasoExitoso(3, ObjResultados.IdPlanilla.Trim()) Then
                If FuncionCreaRecibos(ObjResultados) Then
                    PlanillaFinalizada = False
                End If
            End If

            If ValidaPasoExitoso(4, ObjResultados.IdPlanilla.Trim()) Then
                If FuncionCreaAsientos(ObjResultados) Then
                    'Si da error no sera motivo para que la planilla se finalice ya que se podra crear manualmente
                    PlanillaFinalizada = False
                End If
            End If

            If ValidaPasoExitoso(5, ObjResultados.IdPlanilla.Trim()) Then
                If FuncionCreaAbonosAValesPrestamos(ObjResultados) Then
                    PlanillaFinalizada = False
                End If
            End If

            If PlanillaFinalizada = True Then
                If FuncionFinalizarPlanilla(ObjResultados, PlanillaFinalizada) Then
                    Class_VariablesGlobales.frmPlanilla.Limpiar()
                    Class_VariablesGlobales.frmPlanilla.PlanillaExistente(CInt(ObjResultados.IdPlanilla.Trim()))

                End If
            End If

            Lbl_Proceso.Text = ""
            btn_Ejecutar.Enabled = True
            RegistraObtieneEstado(ObjResultados)


            MsgBox("El proceso termino")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function FuncionGeneraTxt(ByVal ObjResultados As Resultados)
        Dim HayError As Boolean = False

        Lbl_Proceso.Text = "Espere por favor. Se están generando la plantilla para el banco ....."
        If Class_VariablesGlobales.Obj_Creaarchivo.Crear_PlanillaTxt2() Then
            ObjResultados.Mensajes.NumPaso = 1
            ObjResultados.Mensajes.Estado = "SUBIDO"
            ObjResultados.Mensajes.Descripcion = "Archivo del banco generado con exito"
        Else
            ObjResultados.Mensajes.NumPaso = 1
            ObjResultados.Mensajes.Estado = "ERROR"
            ObjResultados.Mensajes.Descripcion = "Archivo del banco No se genero"
            HayError = True
        End If

        RegistraObtieneEstado(ObjResultados)
        Return HayError
    End Function

    Public Function FuncionEnviarColillaPago(ByVal ObjResultados As Resultados)
        Dim HayError As Boolean = False
        Lbl_Proceso.Text = "Espere por favor. Se están enviando los comprobantes de pago de cada empleado ....."
        If EnviarColillaPago() Then
            ObjResultados.Mensajes.NumPaso = 2
            ObjResultados.Mensajes.Estado = "SUBIDO"
            ObjResultados.Mensajes.Descripcion = "Colillas de pago enviadas con exito"

        Else
            ObjResultados.Mensajes.NumPaso = 2
            ObjResultados.Mensajes.Estado = "ERROR"
            ObjResultados.Mensajes.Descripcion = "Colillas de pago enviadas con exito"
            HayError = True
        End If

        RegistraObtieneEstado(ObjResultados)
        Return HayError
    End Function

    Public Function FuncionFinalizarPlanilla(ByVal ObjResultados As Resultados, PlanillaFinalizada As Boolean)
        Dim retorno As Boolean = False
        Lbl_Proceso.Text = "Espere por favor. Se están finalizando la planilla ....."
        If FinalizarPlanilla(PlanillaFinalizada) Then
            ObjResultados.Mensajes.NumPaso = 5
            ObjResultados.Mensajes.Estado = "SUBIDO"
            ObjResultados.Mensajes.Descripcion = "El estado de la planilla a cambiado a Finalizado con exito"

            Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.ForeColor = Color.Green
            Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.Text = "FINALIZADA"
            Class_VariablesGlobales.frmPlanilla.Lbl_EstadoPlanilla.Visible = True
            Class_VariablesGlobales.frmPlanilla.btn_ImprimeRepEmpleado.Visible = True
            retorno = True
        Else
            ObjResultados.Mensajes.NumPaso = 5
            ObjResultados.Mensajes.Estado = "ERROR"
            ObjResultados.Mensajes.Descripcion = "El estado de la planilla No se cambio"
            retorno = False
        End If

        RegistraObtieneEstado(ObjResultados)
        Return retorno
    End Function

    Public Function FuncionCreaRecibos(ByVal ObjResultados As Resultados)
        Dim HayError As Boolean = False
        Lbl_Proceso.Text = "Espere por favor. Se están creando los recibos de dinero en SAP de cada empleado ....."
        If ObtieneFacturasYContruyeEstructuraDeReciboDeDinero(ObjResultados) Then
            ObjResultados.Mensajes.NumPaso = 3
            ObjResultados.Mensajes.Estado = "SUBIDO"
            ObjResultados.Mensajes.Descripcion = "Recibos de dinero creados con exito en Sap"
        Else
            ObjResultados.Mensajes.NumPaso = 3
            ObjResultados.Mensajes.Estado = "ERROR"
            ObjResultados.Mensajes.Descripcion = "Hubo un error al crear 1 o varios recibos de dinero en SAP"
            HayError = True
        End If

        RegistraObtieneEstado(ObjResultados)
        Return HayError
    End Function
    Public Function FuncionCreaAsientos(ByVal ObjResultados As Resultados)
        Dim HayError As Boolean = False
        Try




            Dim Obj_AsientosContables As New AsientosContables(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text.Trim(), Class_VariablesGlobales.frmPlanilla.TxtBox_DescripcionPlanilla.Text)

            Lbl_Proceso.Text = "Espere por favor. Se está creando el asiento contable de la planilla en SAP ....."
            If Obj_AsientosContables.CreaAsiento(ObjResultados) Then
                ObjResultados.Mensajes.NumPaso = 4
                ObjResultados.Mensajes.Estado = "SUBIDO"
                ObjResultados.Mensajes.Descripcion = "Asiento de Diarios creado en SAP"
            Else
                ObjResultados.Mensajes.NumPaso = 4
                ObjResultados.Mensajes.Estado = "ERROR"
                ObjResultados.Mensajes.Descripcion = "Hubo un error al crear asiento de diario en SAP"
                HayError = True
            End If
            RegistraObtieneEstado(ObjResultados)
            Return HayError

        Catch ex As Exception
            MessageBox.Show(ex.Message)

            Return trd1
        End Try
    End Function

    Public Function FuncionCreaAbonosAValesPrestamos(ByVal ObjResultados As Resultados)
        Dim HayError As Boolean = False
        Lbl_Proceso.Text = "Espere por favor. Se está creando los abonos a vales y prestamos ....."
        If CreaAbonosValesPrestamos(ObjResultados) Then
            ObjResultados.Mensajes.NumPaso = 5
            ObjResultados.Mensajes.Estado = "SUBIDO"
            ObjResultados.Mensajes.Descripcion = "Abonos a vales y prestamos creados con exito"
        Else
            ObjResultados.Mensajes.NumPaso = 5
            ObjResultados.Mensajes.Estado = "ERROR"
            ObjResultados.Mensajes.Descripcion = "Hubo un error al crear abono de vales y pretamos"
            HayError = True
        End If
        Return HayError
    End Function



    Public Function ValidaQueTodoEmpleadoSeaChequeado()
        Return Class_VariablesGlobales.Obj_Funciones_SQL.ValidaQueTodoEmpleadoSeaChequeado(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.SQL_Comman2)
    End Function

    ''' <summary>
    ''' Valida si el paso ya fue ejecutado y esta en estado exitoso si no lo esta permite volver a entrar a ejecutarlo
    ''' </summary>
    ''' <param name="NumPaso"></param>
    ''' <param name="IdPlanilla"></param>
    ''' <returns></returns>
    Public Function ValidaPasoExitoso(NumPaso As Integer, IdPlanilla As Integer)
        Return Class_VariablesGlobales.Obj_Funciones_SQL.ValidaPasoExitoso(IdPlanilla, NumPaso, Class_VariablesGlobales.SQL_Comman2)
    End Function
    ''' <summary>
    ''' Genera el archivo txt que se manda al banco
    ''' </summary>
    ''' <returns></returns>
    ''' 
    Public Function GenerarTxt()

        Try

            Dim _planilla As New DocPlanilla()

            With _planilla.Fila1
                .Encabezado = "HD"
                .CedulaEmpresa = Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text
                .FechaAplicacion = Now.Date.ToString()
                .CuentaClientePatron = Class_VariablesGlobales.frmPlanilla.TxtBox_CuentaDeducirPlanilla.Text
                .MonedaDebitar = "CRC"
                .MontoTotalDebitoCredito = Class_VariablesGlobales.frmPlanilla.txtb_TotalPlanilla.Text
                .CantidadTotalMovimientosSitema = Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows.Count + 1
                .CantidadTotalCreditos = Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows.Count
                .CantidadTotalDebitos = 1
            End With

            With _planilla.Fila2
                .Encabezado = "DA"
                .CuentaClientePatrono = Class_VariablesGlobales.frmPlanilla.TxtBox_CuentaDeducirPlanilla.Text
                .MontoTotalDebito = Class_VariablesGlobales.frmPlanilla.txtb_TotalPlanilla.Text
                .CodigoInvariable = "544"
                .NombreEmpresa = Class_VariablesGlobales.frmPlanilla.Txt_NombreEmpresa.Text
                .CedulaEmpresa = Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text
                .CRRBILLINGCUSTOMER = Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text & "1" & "1537704"
            End With

            ' Crear una lista para almacenar las instancias de Fila3

            'Recorre la lista de empleados de la planilla para obtener la info a pagar de cada uno
            For Each row As DataGridViewRow In Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows
                If Trim(row.Cells.Item("id").Value) = "" = False Then
                    ' Cargar datos en instancias de Fila3 y agregarlas a la lista
                    Dim Fila3 As New DTO_Planilla.Fila3()
                    With Fila3
                        .Encabezado = "DA"
                        .CuentaClienteColaborador = row.Cells.Item("CuentaBancaria").Value().ToString()
                        .MontoAcreditarSalario = CDbl(row.Cells.Item("Salario_Final").Value().ToString())
                        .CodigoInvariable = "545"
                        .DescripcionPago = Class_VariablesGlobales.frmPlanilla.TxtBox_DescripcionPlanilla.Text
                        .CedulaEmpresa = Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text
                        .NombreColaborador = row.Cells.Item("Nombre").Value().ToString()
                        .CedulaColaborador = row.Cells.Item("Cedula").Value().ToString()
                        .CRRBILLINGCUSTOMER = Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text & "1" & row.Cells.Item("IdColaborador").Value().ToString()
                    End With
                    ' Asignar más valores a las propiedades de fila3_1...
                    _planilla.listaFila3.Add(Fila3)
                End If
            Next

            Class_VariablesGlobales.Obj_Creaarchivo.Crear_PlanillaTxt(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, _planilla)
            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function


    ''' <summary>
    ''' Recorre la lista de empleados y les genera y manda la colilla de pago
    ''' </summary>
    ''' <returns></returns>
    Public Function EnviarColillaPago()
        Try
            ProgBar_EnvioPlanilla.Value = 0
            ProgBar_EnvioPlanilla.Maximum = Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows.Count
            Lbl_Fin.Text = Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows.Count
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows
                Lbl_Inicio.Text = cont
                ProgBar_EnvioPlanilla.Value = cont
                Lbl_Empleado.Text = row.Cells.Item("Nombre").Value().ToString()
                cont += 1
                'Crear PDF de colilla de pago del empleado en especifico
                Class_VariablesGlobales.IMPRIMIENDO = "ColillaPlanilla"

                Class_VariablesGlobales.Planilla_Cedula = row.Cells.Item("Cedula").Value().ToString()
                Class_VariablesGlobales.Planilla_IdPlanilla = row.Cells.Item("Id_Planilla").Value().ToString()
                Class_VariablesGlobales.ObjfrmReporte = New frmReporte
                Class_VariablesGlobales.ObjfrmReporte.ImprimirColilla()

                Class_VariablesGlobales.frmPlanilla.MandaColillaPagoXCorreo(row.Cells.Item("Cedula").Value().ToString(),
                                        row.Cells.Item("Id_Planilla").Value().ToString(),
                                        row.Cells.Item("Correo").Value().ToString())

            Next



            Return True

        Catch ex As Exception
        End Try

    End Function

    Public Function RegistraObtieneEstado(ByVal ObjResultados As Resultados)
        Try


            Dim Estado As String
            Dim Guardar As Boolean = True

            Estado = Class_VariablesGlobales.Obj_Funciones_SQL.ValidaExistePasoMensajeRegistrado(ObjResultados, Class_VariablesGlobales.SQL_Comman2)
            If Estado.Equals("ERROR") Then
                Guardar = False
            End If
            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaResultadoFinalizacionPlanilla(ObjResultados, Guardar)



            ' Actualizar el DataGridView en el hilo principal
            Me.Invoke(Sub()
                          ' Actualizar el DataGridView con los nuevos datos
                          DGV_Resultado.DataSource = Nothing
                          DGV_Resultado.DataSource = New DataTable
                          DGV_Resultado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneResultados(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text)
                      End Sub)

            AplicaColorAFilaConError()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)


        End Try
    End Function

    Private Sub AplicaColorAFilaConError()
        For Each fila As DataGridViewRow In DGV_Resultado.Rows
            ' Obtén el valor de la celda en la columna "Acciones"
            Dim valorAccion As String = Convert.ToString(fila.Cells("Estado").Value)

            ' Verifica si el valor contiene la palabra "Error"
            If valorAccion.Contains("Error") Then
                ' Aplica el color rojo a toda la fila
                fila.DefaultCellStyle.ForeColor = Color.White
                fila.DefaultCellStyle.BackColor = Color.Red
                fila.DefaultCellStyle.SelectionBackColor = Color.Red ' Necesario para que el color se aplique correctamente

            End If
            If valorAccion.Contains("Éxito") Then
                ' Aplica el color rojo a toda la fila
                fila.DefaultCellStyle.ForeColor = Color.Black
                fila.DefaultCellStyle.BackColor = Color.White
                fila.DefaultCellStyle.SelectionBackColor = Color.White ' Necesario para que el color se aplique correctamente

            End If
        Next
    End Sub

    ''' <summary>
    ''' Permite ponerle un estado a los elementos de la planilla de finalizado 
    ''' ademas coloca un estado en los elementos a deducior vinculados al empleado que empediran que se le vuelvan a cobrar
    ''' </summary>
    ''' <returns></returns>
    Public Function FinalizarPlanilla(PlanillaFinalizada As Boolean)
        Return Class_VariablesGlobales.Obj_Funciones_SQL.FinalizaPlanilla(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, 2, PlanillaFinalizada, Class_VariablesGlobales.SQL_Comman2)

    End Function

    ''' <summary>
    ''' Permite obtener todas las facturas que se tomaron encuenta en la planilla y por cada empleado se hara un recibo
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtieneFacturasYContruyeEstructuraDeReciboDeDinero(ByRef ObjResultados As Resultados)
        Try

            Dim TblFactura As New DataTable

            Dim BackupCardCode As String = ""
            Dim CrearEnSap As Boolean = False
            Dim CashSum As Double = 0
            Dim CardCode As String = ""
            Dim DocNum As String = ""
            Dim DocDate As String = ""
            Dim Id_Planilla As String = ""

            ProgBar_EnvioPlanilla.Value = 0
            ProgBar_EnvioPlanilla.Maximum = Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows.Count
            Lbl_Fin.Text = Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows.Count
            Dim cont As Integer = 0

            'Recorre los empleados y a cada uno busca las facturas a cancelar
            For Each row As DataGridViewRow In Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows
                Lbl_Inicio.Text = cont
                ProgBar_EnvioPlanilla.Value = cont
                Lbl_Empleado.Text = row.Cells.Item("Nombre").Value().ToString()
                cont += 1
                CashSum = 0
                Dim ObjReciboDinero As New DTO_ReciboDinero.ReciboDinero()
                TblFactura = (Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFacturasACancelarXEmpleado(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Trim(row.Cells.Item("Codigo").Value), row.Cells.Item("Cedula").Value().ToString(), Class_VariablesGlobales.SQL_Comman2))
                ' Verificar si TblFactura tiene datos
                If TblFactura IsNot Nothing AndAlso TblFactura.Rows.Count > 0 Then

                    'Recorre las facturas para agregarlas al recibo del empleado
                    For Each rowFacturas As DataRow In TblFactura.Rows

                        ' Crear instancias de objetos DetalleRecibo y agregarlos a la lista Detalle
                        Dim detalle As New DTO_ReciboDinero.DetalleRecibo()
                        detalle.DocNum = rowFacturas("DocNum").ToString()
                        detalle.NumFac = rowFacturas("DocNum").ToString()
                        detalle.DocEntry = rowFacturas("DocEntry").ToString()
                        detalle.SumApplied = rowFacturas("DocSaldo").ToString()
                        detalle.TransferSum = "0"
                        detalle.CashSum = rowFacturas("DocSaldo").ToString()
                        detalle.CheckNumber = "0"
                        detalle.CheckSum = "0"
                        detalle.BankCodeCheque = ""
                        detalle.BankCodeTranferencia = ""
                        detalle.PostFechaCheque = ""
                        ObjReciboDinero.Detalle.Add(detalle)

                        CashSum = CashSum + CDbl(rowFacturas("DocSaldo").ToString())

                    Next

                    ObjReciboDinero.Encabezado.CardCode = Trim(row.Cells.Item("Codigo").Value())
                    ObjReciboDinero.Encabezado.CashSum = CashSum
                    ObjReciboDinero.Encabezado.SalesPersonCode = "01"
                    ObjReciboDinero.Encabezado.IdPlanilla = Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text.Trim()
                    'inserta el ultimo recibo creado

                    Class_VariablesGlobales.obj_SAP.InsertarPago(ObjReciboDinero, ObjResultados)

                End If

            Next

            Lbl_Inicio.Text = 0
            ProgBar_EnvioPlanilla.Value = 0
            Lbl_Empleado.Text = ""
            ProgBar_EnvioPlanilla.Maximum = 0

            If ObjResultados.ListaMensajesSap.Any(Function(mensaje) mensaje.Estado = "ERROR") Then
                ' La lista contiene al menos un mensaje con el estado "Exito"
                Return False
            Else
                ' La lista no contiene mensajes con el estado "Exito"
                Return True
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function CreaAbonosValesPrestamos(ByRef ObjResultados As Resultados)
        Try
            Class_VariablesGlobales.Obj_Funciones_SQL.CreaAbonoValesPrestamos(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text,
                                                                              Class_VariablesGlobales.SQL_Comman2)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btn_Ejecutar_Click(sender As Object, e As EventArgs) Handles btn_Ejecutar.Click

        Try
            btn_Ejecutar.Enabled = False

            trd1 = New Thread(AddressOf Ejecutar)
            trd1.IsBackground = Enabled
            trd1.Priority = ThreadPriority.Highest
            trd1.Start()
            CheckForIllegalCrossThreadCalls = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DGV_Resultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGV_Resultado.DataError
        ' Manejo personalizado del error
        MessageBox.Show($"Se produjo un error al cargar los datos en la fila {e.RowIndex}, columna {e.ColumnIndex}. Detalles: {e.Exception.Message}")
        ' Puedes manejar el error de otra manera, como asignar un valor predeterminado o dejar el campo en blanco
        ' Por ejemplo:
        ' DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""

        'DGV_Resultado.DataSource = Nothing
        'DGV_Resultado.Rows.Clear()
        'DGV_Resultado.Columns.Clear()

        'ConfigurarEstiloCelda()
        'DGV_Resultado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneResultados(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text)
        'AplicaColorAFilaConError()
    End Sub
End Class