Public Class PlanillaAsignaEmpleadoARuta
    Private Sub Btn_Asginar_Click(sender As Object, e As EventArgs) Handles Btn_Asginar.Click
        If String.IsNullOrWhiteSpace(CboBox_Empleados.Text) Or String.IsNullOrWhiteSpace(CboBox_Rutas.Text) Then
            MessageBox.Show("Debe indicar el empleado y ruta  ")
        Else

            'If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteAsignacion(Class_VariablesGlobales.SQL_Comman1, Trim(CboBox_Empleados.Text), Trim(CboBox_Rutas.Text)) = 0 Then
            InsertarAsginacionEmpleadoRuta()
                limpiar()
                'Else
                '    MessageBox.Show("La asignacion ya existe")
                'End If

            End If
    End Sub
    Public Function limpiar()
        CboBox_Empleados.Text=""
        CboBox_Rutas.Text = ""


        ' Obtener la fecha actual
        Dim fechaActual As DateTime = DateTime.Now

        ' Obtener la fecha inicial del mes
        Dim fechaInicial As DateTime = New DateTime(fechaActual.Year, fechaActual.Month, 1)

        ' Obtener la fecha final del mes
        Dim fechaFinal As DateTime = fechaInicial.AddMonths(1).AddDays(-1)

        DateTP_Inicial.Value = fechaInicial
        DateTP_Final.Value = fechaFinal

        ObtieneAsignaciones()


    End Function
    Public Function InsertarAsginacionEmpleadoRuta()

        Class_VariablesGlobales.Obj_Funciones_SQL.InsertaAsignacion(Class_VariablesGlobales.SQL_Comman1, Trim(CboBox_Empleados.Text), Trim(CboBox_Rutas.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date))


    End Function
    Public Function ObtieneAsignaciones()

        ' Obtener la fecha actual
        Dim fechaActual As DateTime = DateTime.Now

        ' Obtener la fecha inicial del mes
        Dim fechaInicial As DateTime = New DateTime(fechaActual.Year, fechaActual.Month, 1)

        ' Obtener la fecha final del mes
        Dim fechaFinal As DateTime = fechaInicial.AddMonths(1).AddDays(-1)
        DataGV_Asignaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAsignacion(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(fechaInicial), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(fechaFinal))

        DataGV_Asignaciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Function
    Private Sub PlanillaAsignaEmpleadoARuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Class_VariablesGlobales.SQL_Comman1 Is Nothing Then
            Class_VariablesGlobales.SQL_Comman1 = Class_VariablesGlobales.Obj_Funciones_SQL.Conectar()
        End If


        Dim tbl As New DataTable

        tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "CHOFER Y AYUDANTES", "")

        ' Agrega un ítem en la posición 0 con un texto específico (puedes ajustarlo según tus necesidades)
        Dim nuevoItem As DataRow = tbl.NewRow()
        nuevoItem("nombre") = "Seleccione un empleado"
        nuevoItem("Cedula") = DBNull.Value
        tbl.Rows.InsertAt(nuevoItem, 0)

        With CboBox_Empleados
            .DataSource = tbl
            .DisplayMember = "Nombre"
            .ValueMember = "Cedula"
        End With


        tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTE", "")
        ' Agrega un ítem en la posición 0 con un texto específico (puedes ajustarlo según tus necesidades)
        nuevoItem = tbl.NewRow()
        nuevoItem("nombre") = "Seleccione una ruta"
        nuevoItem("Cedula") = DBNull.Value
        tbl.Rows.InsertAt(nuevoItem, 0)
        With CboBox_Rutas
            .DataSource = tbl
            .DisplayMember = "CodAgente"
            .ValueMember = "CodAgente"
        End With

        limpiar()
    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        DataGV_Asignaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAsignacion(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTP_Inicial.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTP_Final.Value.Date))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_EliminaAsignacion.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "CHOFER Y AYUDANTES", "")
    End Sub

    Private Sub DataGV_Asignaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGV_Asignaciones.CellContentClick

        ' Verificar si la celda doble clicada es válida
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Obtener el valor de la celda de la columna 0 (cambiar según tus necesidades)
            Dim valorColumna0 As Object = DataGV_Asignaciones.Rows(e.RowIndex).Cells(0).Value

            CboBox_Empleados.Text = DataGV_Asignaciones.Rows(e.RowIndex).Cells(0).Value
            CboBox_Rutas.Text = DataGV_Asignaciones.Rows(e.RowIndex).Cells(1).Value
            DateTP_FechaAsignacion.Value = DataGV_Asignaciones.Rows(e.RowIndex).Cells(2).Value

        End If

    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        limpiar()
    End Sub
End Class