Public Class AsientosContables



    Public id_Planilla As Integer
    Public Reference As String

    ' Constructor con parámetros
    Public Sub New(IDPlanilla As Integer, DescripcionPlanilla As String)
        id_Planilla = IDPlanilla
        Reference = DescripcionPlanilla
    End Sub

    ''' <summary>
    ''' Permite crea 1 solo asiento por planilla
    ''' </summary>
    ''' <returns></returns>
    Public Function CreaAsiento(ByRef ObjResultados As Resultados)

        'Crear una instancia del objeto Asiento
        Dim asiento As New DTO_Asientos.Asiento()
        asiento.Reference = Reference
        ObtenerAsientoPlanilla(asiento)


        ' Si no estamos en modo de depuración, añadir el correo del empleado
        Return Class_VariablesGlobales.obj_SAP.CreaAsiento(asiento, ObjResultados)


    End Function
    ''' <summary>
    ''' Obtiene la tabla con el asiento ya creado
    ''' </summary>
    ''' <param name="asiento"></param>
    ''' <returns></returns>
    Public Function ObtenerAsientoPlanilla(ByRef asiento As DTO_Asientos.Asiento)
        asiento.Detalle = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAsiento(id_Planilla, Class_VariablesGlobales.SQL_Comman2)
    End Function


    ''' <summary>
    ''' Obtiene el total en vales y prestamos por cada empleado y agrega el monton segun la cuenta contable asignada de cada empleado
    ''' </summary>
    ''' <param name="asiento"></param>
    ''' <returns></returns>
    Public Function AgregaCuentaEmpleadosValesPrestamos(ByRef asiento As DTO_Asientos.Asiento)
        Dim tbl_TotalValesPrestamosPorEmpleado As New DataTable
        tbl_TotalValesPrestamosPorEmpleado = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalValesPrestamosPorEmpleado(id_Planilla, Class_VariablesGlobales.SQL_Comman2)

        If tbl_TotalValesPrestamosPorEmpleado.Rows.Count > 0 Then

            ' Recorrer los registros utilizando un bucle For Each
            For Each row As DataRow In tbl_TotalValesPrestamosPorEmpleado.Rows
                Dim Linea_ValesPrestamosPorEmpleado As New DTO_Asientos.DetalleAsiento()
                Linea_ValesPrestamosPorEmpleado.AccountCode = CStr(row("CuentaContable"))
                Linea_ValesPrestamosPorEmpleado.Credit = CDbl(row("Saldo"))
                Linea_ValesPrestamosPorEmpleado.Debit = 0.0
                'asiento.Detalle.Add(Linea_ValesPrestamosPorEmpleado)
            Next

        End If
    End Function


End Class
