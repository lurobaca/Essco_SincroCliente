Public Class DeduccionesAcreditaciones

    Private Sub ChkB_Hasta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkB_Hasta.CheckedChanged
        If ChkB_Hasta.Checked = True Then
            DTP_FechaLimite.Enabled = True
        Else

            DTP_FechaLimite.Enabled = False

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaDuplicadoDeduccionFija(Txb_Cedula.Text, Cbx_Tipo.Text, Class_VariablesGlobales.SQL_Comman2) = False Then
            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaDeduccionFija(Txb_Cedula.Text, txtb_Nombre.Text, Cbx_Tipo.Text, CDbl(Txtb_Monto.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaLimite.Value.Date), ChkB_Hasta.Checked, True, Class_VariablesGlobales.SQL_Comman2)
            DGV_Deducciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Deducciones(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
            Limpiar()
        Else
            MsgBox("ERROR ,El Gastos fijo ya existe")

        End If


    End Sub

    Private Sub Btn_EmplAdelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EmplAdelante.Click
        Dim Empleado As New DataTable
        Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.NavegaEmpleados(CInt(Txt_Id.Text) + 1, Class_VariablesGlobales.SQL_Comman2)
        Navegar(Empleado)
    End Sub

    Private Sub btn_EmplAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EmplAtras.Click
        Dim Empleado As New DataTable
        Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.NavegaEmpleados(CInt(Txt_Id.Text) - 1, Class_VariablesGlobales.SQL_Comman2)
        Navegar(Empleado)
    End Sub


    Public Function Navegar(ByVal DGV_ListaEmpleado As DataTable)

        For Each row As DataRow In DGV_ListaEmpleado.Rows
            Class_VariablesGlobales.frmDeduccionesAcreditaciones.Txt_Id.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("id").ToString())
            Class_VariablesGlobales.frmDeduccionesAcreditaciones.Txb_Cedula.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Cedula").ToString())
            Class_VariablesGlobales.frmDeduccionesAcreditaciones.txtb_Nombre.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Nombre").ToString())

            If Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString()) <> "" Then
                Class_VariablesGlobales.frmDeduccionesAcreditaciones.Txb_RutaImagen.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString())
                Class_VariablesGlobales.frmDeduccionesAcreditaciones.PictureBox1.Image = Image.FromFile(Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString()))
            Else
                Class_VariablesGlobales.frmDeduccionesAcreditaciones.PictureBox1.Image = Image.FromFile(" C:\Program Files (x86)\ESSCO\SINCRO\Planilla_Imagenes\SinFoto.png")
            End If
        Next
        DGV_Deducciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Deducciones(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)

        Limpiar()
    End Function

    Private Sub DGV_Deducciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Deducciones.CellContentClick

        Txtb_Monto.Text = DGV_Deducciones.CurrentRow.Cells.Item(2).Value.ToString()
        If DGV_Deducciones.CurrentRow.Cells.Item(3).Value.ToString() = "True" Then
            ChkB_Hasta.Checked = True
            DTP_FechaLimite.Enabled = True
        Else
            ChkB_Hasta.Checked = False
            DTP_FechaLimite.Enabled = False
        End If


        DTP_FechaLimite.Value = DGV_Deducciones.CurrentRow.Cells.Item(4).Value.ToString()
        Cbx_Tipo.Text = DGV_Deducciones.CurrentRow.Cells.Item(5).Value.ToString()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.ELIMINA_Deducciones(Txb_Cedula.Text, Cbx_Tipo.Text, Class_VariablesGlobales.SQL_Comman2)
        DGV_Deducciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Deducciones(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Limpiar()
    End Sub

    Public Function Limpiar()
        Txtb_Monto.Text = ""
        ChkB_Hasta.Checked = False
        DTP_FechaLimite.Enabled = False
        DTP_FechaLimite.Value = Now.Date
        Cbx_Tipo.Text = ""
    End Function
End Class