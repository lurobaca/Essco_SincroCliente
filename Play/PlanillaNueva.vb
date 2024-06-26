Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Microsoft.Office.Interop

Public Class PlanillaNueva

    Public ObjPlanilla As New ClassPlanilla
    Dim obj_Fecha As New FechaManager
    ' Declaración de un BackgroundWorker para realizar la consulta en segundo plano
    Private WithEvents backgroundWorker As New BackgroundWorker()



    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DTPFechaInicial.ValueChanged
        Txtb_DescripcionPlanilla.Text =
            ObjPlanilla.ObtenerDescripcion(DTPFechaInicial.Value.ToShortDateString,
                                           DTPFechaFinal.Value.ToShortDateString)
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DTPFechaFinal.ValueChanged
        Txtb_DescripcionPlanilla.Text =
            ObjPlanilla.ObtenerDescripcion(DTPFechaInicial.Value.ToShortDateString,
                                           DTPFechaFinal.Value.ToShortDateString)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_NuevaPlanilla.Click


        Timer_VerificaPasosCreacionPlanilla.Start()

        Me.Cursor = Cursors.WaitCursor
        Btn_Cancelar.Visible = False
        Btn_NuevaPlanilla.Visible = False

        Dim Hilo_CreaPlanillaNueva As Thread
        ''hilo de ejecucion constante
        Hilo_CreaPlanillaNueva = New Thread(AddressOf CreaPlanillaNueva)
        Hilo_CreaPlanillaNueva.IsBackground = Enabled
        Hilo_CreaPlanillaNueva.Priority = ThreadPriority.Highest
        Hilo_CreaPlanillaNueva.Start()
        CheckForIllegalCrossThreadCalls = False

    End Sub

    Public Function CargaPasosCreacionPlanilla()
        Dim TblPlanilla As New DataTable
        TblPlanilla = Class_VariablesGlobales.Obj_Funciones_SQL.CargaPasosCreacionPlanilla(Class_VariablesGlobales.SQL_Comman2)
        DGV_PasosGeneracionPlanilla.DataSource = TblPlanilla

        TblPlanilla = Nothing
    End Function

    Public Function CreaPlanillaNueva()

        Dim TipoPlanilla As Integer = 0
        'Valida el tipo de inversion
        If CBox_TipoPlanilla.Text = "Ordinaria" Then
            'Planilla ordinaria quincenal
            TipoPlanilla = 1

            Txtb_DescripcionPlanilla.Text = ObjPlanilla.ObtenerDescripcion(DTPFechaInicial.Value.ToShortDateString,
                                                                          DTPFechaFinal.Value.ToShortDateString)

        ElseIf CBox_TipoPlanilla.Text = "Aguinaldo" Then
            TipoPlanilla = 2
            'Valida si hay aguinaldos por pagar

            If Class_VariablesGlobales.Obj_Funciones_SQL.ValidaExistenciaDeAguinaldosPorPagar(Class_VariablesGlobales.SQL_Comman2) Then
                MessageBox.Show("No existen aguinaldos por agar, debe crear al menos una planilla ordinaria.")
                Return True
            End If

            'tomar como salario el monto de aguinaldo que aun no se a pagado,para regular cuales se han pagado y cuales no,se debe cambir el estado de la columna AguinaldoPagado en la tabla de planillaEmpleado
            'Solo se puede rebajar la pension alimentaria
        ElseIf CBox_TipoPlanilla.Text = "Comisiones" Then
            TipoPlanilla = 3
            If TxtBox_RutaArchivo.Text = "" Then
                'Al seleccionar este tipo me debe permitir adjuntar un excel con la cedula del empleado , nombre y el monto de comision esto se utilizaria como si fuera el salario y se le debe calcular la CCSS, y debe calcularse el aguinaldo
                MessageBox.Show("Debe seleccionar el archivo con las comisiones a pagar")
                Return True
            End If
        End If

        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaCargaPasosCreacionPlanilla(Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.frmPlanilla.CreaPlanillaNueva(TipoPlanilla, obj_Fecha.FormatoFechaSql(DTPFechaInicial.Value.ToShortDateString), obj_Fecha.FormatoFechaSql(DTPFechaFinal.Value.ToShortDateString), Txtb_DescripcionPlanilla.Text, Class_VariablesGlobales.Log_Usuario)

        Me.Cursor = Cursors.Default

        MessageBox.Show("Planilla creada con exito")
        Timer_VerificaPasosCreacionPlanilla.Stop()
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaCargaPasosCreacionPlanilla(Class_VariablesGlobales.SQL_Comman2)
        Me.Close()

    End Function

    Private Sub Timer_VerificaPasosCreacionPlanilla_Tick(sender As Object, e As EventArgs) Handles Timer_VerificaPasosCreacionPlanilla.Tick
        Try
            'Dim Hilo_VerificaPasosCreacionPlanilla As Thread
            '''hilo de ejecucion constante
            'Hilo_VerificaPasosCreacionPlanilla = New Thread(AddressOf CargaPasosCreacionPlanilla)
            'Hilo_VerificaPasosCreacionPlanilla.IsBackground = Enabled
            'Hilo_VerificaPasosCreacionPlanilla.Priority = ThreadPriority.Highest
            'Hilo_VerificaPasosCreacionPlanilla.Start()
            'CheckForIllegalCrossThreadCalls = False
            backgroundWorker = New BackgroundWorker()
            ' Configura el BackgroundWorker
            backgroundWorker.WorkerSupportsCancellation = False
            backgroundWorker.WorkerReportsProgress = False
            backgroundWorker.WorkerReportsProgress = True

            ' Verifica si el BackgroundWorker no está ocupado
            If Not backgroundWorker.IsBusy Then
                ' Inicia el BackgroundWorker para ejecutar la consulta SQL en segundo plano
                backgroundWorker.RunWorkerAsync()
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' Método que se ejecuta en el hilo principal para actualizar el DataGridView
    Private Sub ActualizarDataGridView(dataTable As DataTable)
        Try
            DGV_PasosGeneracionPlanilla.DataSource = dataTable
            DGV_PasosGeneracionPlanilla.Columns(0).Width = 400
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    ' Evento que se dispara cuando el trabajo en segundo plano está completo
    Private Sub backgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            MessageBox.Show("Error al ejecutar la consulta: " & e.Error.Message)
        Else
            ' El trabajo en segundo plano se completó con éxito, actualiza el DataGridView
            Dim resultado As DataTable = DirectCast(e.Result, DataTable)
            ActualizarDataGridView(resultado)
        End If
    End Sub
    Private Sub backgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles backgroundWorker.DoWork
        ' Llama al sub que ejecuta la consulta SQL aquí
        EjecutarConsultaSQL(backgroundWorker, e)
    End Sub

    ' Método que se ejecuta en segundo plano para ejecutar la consulta SQL
    Private Sub EjecutarConsultaSQL(backgroundWorker As BackgroundWorker, e As DoWorkEventArgs)
        '' Conexión a la base de datos
        'Dim connectionString As String = "TuCadenaDeConexion"
        'Using connection As New SqlConnection(connectionString)
        '    connection.Open()
        '    ' Consulta SQL
        '    Dim queryString As String = "SELECT * FROM TuTabla"
        '    Using command As New SqlCommand(queryString, connection)
        '        Dim dataTable As New DataTable()
        '        Dim dataAdapter As New SqlDataAdapter(command)
        '        dataAdapter.Fill(dataTable)

        '        ' Devuelve el resultado al hilo principal
        '        e.Result = dataTable
        '    End Using
        'End Using

        e.Result = Class_VariablesGlobales.Obj_Funciones_SQL.CargaPasosCreacionPlanilla(Class_VariablesGlobales.SQL_Comman2)
    End Sub

    Private Sub PlanillaNueva_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Método para configurar el estilo de la celda y ajustar automáticamente el tamaño de las columnas
        ConfigurarEstiloCelda()
        ObtieneFechas(CBox_TipoPlanilla.Text().Trim())
    End Sub
    Public Function ObtieneFechas(ByVal TipoPlanilla As String)
        ' Obtener la fecha actual
        Dim fechaActual As DateTime = DateTime.Today

        ' Definir la fecha de inicio y fin basándose en la fecha actual
        Dim fechaInicio As DateTime
        Dim fechaFin As DateTime

        If TipoPlanilla = "Aguinaldo" Then
            ' Calcular fecha de inicio para Aguinaldo (01 de diciembre del año anterior)
            fechaInicio = New DateTime(fechaActual.Year - 1, 12, 1)
            ' Calcular fecha final para Aguinaldo (30 de noviembre del año en curso)
            fechaFin = New DateTime(fechaActual.Year, 11, DateTime.DaysInMonth(fechaActual.Year, 11))

        Else
            If fechaActual.Day <= 15 Then
                ' Si estamos en la primera quincena del mes
                fechaInicio = New DateTime(fechaActual.Year, fechaActual.Month, 1)
                fechaFin = New DateTime(fechaActual.Year, fechaActual.Month, 15)
            Else
                ' Si estamos en la segunda quincena del mes
                fechaInicio = New DateTime(fechaActual.Year, fechaActual.Month, 16)
                fechaFin = New DateTime(fechaActual.Year, fechaActual.Month, DateTime.DaysInMonth(fechaActual.Year, fechaActual.Month))
            End If
        End If

        ' Asignar las fechas a los controles DatePicker
        DTPFechaInicial.Value = fechaInicio
        DTPFechaFinal.Value = fechaFin
    End Function

    Private Sub ConfigurarEstiloCelda()
        ' Cambiar el tamaño del texto en todas las celdas del DataGridView
        DGV_PasosGeneracionPlanilla.DefaultCellStyle.Font = New Font("Arial", 12)

        ' Ajustar automáticamente el tamaño de las columnas al contenido
        DGV_PasosGeneracionPlanilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub CBox_TipoPlanilla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_TipoPlanilla.SelectedIndexChanged


        If CBox_TipoPlanilla.Text = "Aguinaldo" Then
            Lbl_RutaArchivo.Visible = False

            TxtBox_RutaArchivo.Visible = False
            Btn_BuscarArchivo.Visible = False
            Txtb_DescripcionPlanilla.Text = "Planilla de Aguinaldo"

            DTPFechaInicial.Enabled = False
            DTPFechaFinal.Enabled = False
            Btn_NuevaPlanilla.Enabled = True

        End If

        If CBox_TipoPlanilla.Text = "Comisiones" Then
            Lbl_RutaArchivo.Visible = True

            TxtBox_RutaArchivo.Visible = True
            Btn_BuscarArchivo.Visible = True

            Txtb_DescripcionPlanilla.Text = "Planilla de Comisiones"

            DTPFechaInicial.Enabled = False
            DTPFechaFinal.Enabled = False

            Btn_NuevaPlanilla.Enabled = False
        End If

        If CBox_TipoPlanilla.Text = "Ordinaria" Then
            Lbl_RutaArchivo.Visible = False

            TxtBox_RutaArchivo.Visible = False
            Btn_BuscarArchivo.Visible = False
            Txtb_DescripcionPlanilla.Text = ""

            DTPFechaInicial.Enabled = True
            DTPFechaFinal.Enabled = True
            Btn_NuevaPlanilla.Enabled = True
        End If
        ObtieneFechas(CBox_TipoPlanilla.Text().Trim())
    End Sub

    Private Sub Btn_BuscarArchivo_Click(sender As Object, e As EventArgs) Handles Btn_BuscarArchivo.Click
        ' Abre el cuadro de diálogo para seleccionar un archivo de Excel
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos de Excel|*.xlsx;*.xls|Todos los archivos|*.*"
        openFileDialog.Title = "Seleccionar archivo de Excel"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Obtiene la ruta del archivo seleccionado
            Dim filePath As String = openFileDialog.FileName
            TxtBox_RutaArchivo.Text = filePath
            Btn_BuscarArchivo.Text = "Cargando..."
            ' Llama al método para leer y cargar los datos del archivo de Excel
            LeerArchivoExcel(filePath)


        End If
    End Sub

    Private Sub LeerArchivoExcel(filePath As String)
        ' Inicializa una aplicación de Excel
        Dim excelApp As New Excel.Application()
        Dim excelBook As Excel.Workbook = Nothing
        Dim excelSheet As Excel.Worksheet = Nothing

        Try
            ' Abre el libro de Excel
            excelBook = excelApp.Workbooks.Open(filePath)
            ' Obtiene la primera hoja de Excel
            excelSheet = DirectCast(excelBook.Sheets(1), Excel.Worksheet)
            Class_VariablesGlobales.Obj_Funciones_SQL.EliminaDatosDeComisiones(Class_VariablesGlobales.SQL_Comman2)
            ' Itera sobre las celdas con datos
            Dim fila As Integer = 1
            Do While Not String.IsNullOrEmpty(excelSheet.Cells(fila, 1).Value)
                ' Obtiene los valores de las celdas
                Dim Cedula As String = excelSheet.Cells(fila, 1).Value
                Dim Nombre As String = excelSheet.Cells(fila, 2).Value
                Dim Monto As String = excelSheet.Cells(fila, 3).Value

                Class_VariablesGlobales.Obj_Funciones_SQL.GuardarDatosDeComisiones(0, Cedula, Nombre, Monto, Class_VariablesGlobales.SQL_Comman2)

                fila += 1
            Loop
            Btn_NuevaPlanilla.Enabled = True
            Btn_BuscarArchivo.Text = "Buscar"
            MessageBox.Show("Datos de comisiones cargados con exito")
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo de Excel: " & ex.Message)

        Finally
            ' Cierra el libro de Excel y la aplicación de Excel
            If Not excelSheet Is Nothing Then
                Marshal.ReleaseComObject(excelSheet)
            End If

            If Not excelBook Is Nothing Then
                excelBook.Close(False)
                Marshal.ReleaseComObject(excelBook)
            End If

            If Not excelApp Is Nothing Then
                excelApp.Quit()
                Marshal.ReleaseComObject(excelApp)
            End If
        End Try
    End Sub


End Class