Public Class Lista_Planillas

    Private Sub Lista_Planillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_ListaPlanillas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.obtienePlanillas(Class_VariablesGlobales.SQL_Comman2)


    End Sub

    Private Sub DGV_ListaPlanillas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_ListaPlanillas.CellContentClick

        'debe jalar la planilla y guardarla en planilla tem para que el metodo guardar funcine

        Dim Tabla As New DataTable
        Tabla = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Planilla(CInt(Trim(DGV_ListaPlanillas.CurrentRow.Cells.Item(0).Value())), Class_VariablesGlobales.SQL_Comman2)
        Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.DataSource = Tabla

        If Tabla.Rows.Count > 0 Then
            While Class_VariablesGlobales.Contador < Tabla.Rows.Count
                Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("Ced_Empleado").ToString()
                Class_VariablesGlobales.frmPlanilla.txtb_NombreEmpleado.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("NombreEmpleado").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Puesto.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("Puesto").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Salario.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("Salario").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("SalarioQuincenal").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Adicional.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("ADICIONAL").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Deb_Personal.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("DEB_PERSONAL").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Ducc_Cuota.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("DUCC_CUOTA_BP").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Celular.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("DEDUCION_DE_CELULAR").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Embargo.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("EMBARGO").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_FaltaLiq.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("FALTANTES_LIQ").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Facturas.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("FACTURAS").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Faltante.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("COBROS_X_FALTANTE").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Prestamo.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("COBROS_PRESTAMO").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_CCSS.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("Dedu_CCSS").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("id").ToString()
                Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("Ced_Juridica").ToString()
                Class_VariablesGlobales.frmPlanilla.Txt_Nombre.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("Nombre").ToString()
                Class_VariablesGlobales.frmPlanilla.DTP_FechaIngreso.Value = Tabla.Rows(Class_VariablesGlobales.Contador).Item("FechaINI").ToString()
                Class_VariablesGlobales.frmPlanilla.DTP_FechaSalida.Value = Tabla.Rows(Class_VariablesGlobales.Contador).Item("FechaFIN").ToString()
                Class_VariablesGlobales.frmPlanilla.txtb_PorcCCSS.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("PorcCCSS").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_RutaImagen.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("Foto").ToString()
                Class_VariablesGlobales.frmPlanilla.Txt_Id.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("id_Empleado").ToString()
                Class_VariablesGlobales.frmPlanilla.Lbl_Salario.Text = Tabla.Rows(Class_VariablesGlobales.Contador).Item("SalarioFinal").ToString()
                Class_VariablesGlobales.Contador += 1
            End While
        End If


        Me.Close()

    End Sub
End Class