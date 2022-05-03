Public Class Planilla_Empleados
    Public Obj_List_Empleados As New Planilla_List_Empleados
    Public Class_VariablesGlobales As New Class_VariablesGlobales
    Private Sub CkBx_Encurso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkBx_Encurso.CheckedChanged


        If CkBx_Encurso.Checked = True Then
            DTP_EFechaSalida.Enabled = False

        Else
            DTP_EFechaSalida.Enabled = True
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
        '    ' List files in the folder.

        '    PictureBox1.Image = Image.FromFile(FolderBrowserDialog1.SelectedPath)
        'End If

        If Txb_Cedula.Text <> "" Then

            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)

                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
                PictureBox1.Image.Save(Class_VariablesGlobales.RutaFotosPlanilla & Txb_Cedula.Text & ".jpg", Drawing.Imaging.ImageFormat.Jpeg)
                Txb_RutaImagen.Text = Class_VariablesGlobales.RutaFotosPlanilla & Txb_Cedula.Text & ".jpg"
                sr.Close()
            End If
        Else
            MessageBox.Show("Ingrese el numero de cedula")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click


        If Btn_Guardar.Text = "Guardar" Then
            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaEmpleado(Txt_Id.Text, Txb_Cedula.Text, Txb_Nombre.Text, CBox_Puesto.Text, Txb_Telefono1.Text, Txb_Telefono2.Text, Txb_RutaImagen.Text, Txb_Salario.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaSalida.Value.Date), DTGV_Experiencia.DataSource, DTGV_Educacion.DataSource, ChkB_Activo.Checked, Txb_Codigo.Text, Txtb_CodRuta.Text, txtb_Correo.Text, Txb_CodigoCobroXFaltante.Text, True, Class_VariablesGlobales.SQL_Comman2) = True Then
                MessageBox.Show("Empleado Guardado Correctamente")
                Limpiar()
            End If
        Else
            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaEmpleado(Txt_Id.Text, Txb_Cedula.Text, Txb_Nombre.Text, CBox_Puesto.Text, Txb_Telefono1.Text, Txb_Telefono2.Text, Txb_RutaImagen.Text, Txb_Salario.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaSalida.Value.Date), DTGV_Experiencia.DataSource, DTGV_Educacion.DataSource, ChkB_Activo.Checked, Txb_Codigo.Text, Txtb_CodRuta.Text, txtb_Correo.Text, Txb_CodigoCobroXFaltante.Text, False, Class_VariablesGlobales.SQL_Comman2) = True Then
                MessageBox.Show("Empleado Guardado Correctamente")
                Limpiar()
            End If
        End If




    End Sub



    Private Sub Btn_EdGuarda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EdGuarda.Click
        Dim ced As String = Txb_Cedula.Text
        If Btn_EdGuarda.Text = "Guardar" Then
            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaEducacion(Txb_Cedula.Text, Txb_Institucion.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_EFechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_EFechaSalida.Value.Date), Trim(CkBx_Encurso.Checked), Trim(CBox_Grado.Text), Txb_Titulo.Text, True, Class_VariablesGlobales.SQL_Comman2) = True Then

                DTGV_Educacion.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneEducacion(ced, Class_VariablesGlobales.SQL_Comman2)

                LimpiaEducacion()
            End If
        Else
            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaEducacion(Txb_Cedula.Text, Txb_Institucion.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_EFechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_EFechaSalida.Value.Date), Trim(CkBx_Encurso.Checked), Trim(CBox_Grado.Text), Txb_Titulo.Text, False, Class_VariablesGlobales.SQL_Comman2) = True Then
                DTGV_Educacion.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneEducacion(ced, Class_VariablesGlobales.SQL_Comman2)

                LimpiaEducacion()

            End If
        End If




    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Limpiar()
    End Sub

#Region "EXPERIENCIA"
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExGuardar.Click
        Dim ced As String = Txb_Cedula.Text
        If Btn_ExGuardar.Text = "Guardar" Then
            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaExperiencia(Txb_Cedula.Text, Txb_Empresa.Text, Txb_ExPuesto.Text, Txb_Persona.Text, Txb_Telefono.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ExFechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ExFechaSalida.Value.Date), Txb_Comentario.Text, DTGV_Experiencia.DataSource, True, Class_VariablesGlobales.SQL_Comman2) = True Then
                LimpiaExperiencia()
                DTGV_Experiencia.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneExperiencia(ced, Class_VariablesGlobales.SQL_Comman2)
            End If
        Else
            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaExperiencia(Txb_Cedula.Text, Txb_Empresa.Text, Txb_ExPuesto.Text, Txb_Persona.Text, Txb_Telefono.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ExFechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ExFechaSalida.Value.Date), Txb_Comentario.Text, DTGV_Experiencia.DataSource, False, Class_VariablesGlobales.SQL_Comman2) = True Then
                LimpiaExperiencia()
                DTGV_Experiencia.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneExperiencia(ced, Class_VariablesGlobales.SQL_Comman2)
            End If
        End If



    End Sub
    Private Sub Btn_ExEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExEliminar.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaExperiencia(Txb_Cedula.Text, Txb_Empresa.Text, Class_VariablesGlobales.SQL_Comman2)
        LimpiaExperiencia()
        DTGV_Experiencia.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneExperiencia(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
    End Sub
#End Region



    Private Sub ChkB_Activo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkB_Activo.CheckedChanged

        If ChkB_Activo.Checked = True Then
            DTP_FechaSalida.Enabled = False

        Else
            DTP_FechaSalida.Enabled = True
        End If


    End Sub

    Private Sub Btn_ExNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExNuevo.Click

    End Sub


    Public Function LimpiaExperiencia()
        Txb_Empresa.Text = ""
        Txb_ExPuesto.Text = ""
        Txb_Persona.Text = ""
        Txb_Telefono.Text = ""
        DTP_ExFechaIngreso.ResetText()
        DTP_ExFechaSalida.ResetText()
        Txb_Comentario.Text = ""
        DTGV_Experiencia.DataSource = New DataTable
        Btn_ExGuardar.Text = "Guardar"
    End Function

    Public Function LimpiaDeducciones()
        Txb_Cedula.Text = ""
        'Cbx_CategoriaDeduccion.Text = ""
        Txb_Dedu_Adicional.Text = ""
        Txb_Dedu_CCSS.Text = ""
        DGV_Deducciones.DataSource = New DataTable
    End Function
    Public Function LimpiaEducacion()
        Txb_Institucion.Text = ""
        DTP_EFechaIngreso.ResetText()
        DTP_EFechaIngreso.ResetText()
        Txb_Titulo.Text = ""
        CBox_Grado.Text = ""
        CkBx_Encurso.Checked = False
    End Function

    Public Function Limpiar()

        LimpiaExperiencia()
        LimpiaEducacion()

        DTP_FechaIngreso.ResetText()
        DTP_FechaSalida.ResetText()
        DTGV_Educacion.DataSource = New DataTable
        Txb_Cedula.Text = ""
        Txb_Nombre.Text = ""
        CBox_Puesto.Text = ""
        Txb_Telefono1.Text = ""
        Txb_Telefono2.Text = ""
        Txb_RutaImagen.Text = ""
        txtb_Correo.Text = ""
        Txb_CodigoCobroXFaltante.Text = ""
        Txb_Codigo.Text = ""
        Txb_Salario.Text = ""
        PictureBox1.Image = Image.FromFile(Class_VariablesGlobales.RutaFotosPlanilla & "SinFoto.png")
        ChkB_Activo.Checked = False
        Btn_Guardar.Text = "Guardar"
    End Function




    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Planilla_List_Empleados.Show()
    End Sub



    Private Sub DTGV_Experiencia_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DTGV_Experiencia.CellContentClick
        Class_VariablesGlobales.frmEmpleados.Txb_Empresa.Text = DTGV_Experiencia.CurrentRow.Cells.Item(0).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txb_ExPuesto.Text = DTGV_Experiencia.CurrentRow.Cells.Item(1).Value.ToString
        Class_VariablesGlobales.frmEmpleados.DTP_ExFechaIngreso.Text = DTGV_Experiencia.CurrentRow.Cells.Item(2).Value.ToString
        Class_VariablesGlobales.frmEmpleados.DTP_ExFechaIngreso.Text = DTGV_Experiencia.CurrentRow.Cells.Item(3).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txb_Persona.Text = DTGV_Experiencia.CurrentRow.Cells.Item(4).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txb_Telefono.Text = DTGV_Experiencia.CurrentRow.Cells.Item(5).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txb_Comentario.Text = DTGV_Experiencia.CurrentRow.Cells.Item(6).Value.ToString

        Btn_ExGuardar.Text = "Actualizar"
    End Sub

    Private Sub DTGV_Educacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DTGV_Educacion.CellContentClick
        Class_VariablesGlobales.frmEmpleados.Txb_Institucion.Text = DTGV_Educacion.CurrentRow.Cells.Item(0).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txb_Titulo.Text = DTGV_Educacion.CurrentRow.Cells.Item(1).Value.ToString


        Class_VariablesGlobales.frmEmpleados.DTP_EFechaIngreso.Value = DTGV_Educacion.CurrentRow.Cells.Item(2).Value.ToString
        Class_VariablesGlobales.frmEmpleados.DTP_EFechaSalida.Value = DTGV_Educacion.CurrentRow.Cells.Item(3).Value.ToString

        If DTGV_Educacion.CurrentRow.Cells.Item(4).Value.ToString = "True" Then
            Class_VariablesGlobales.frmEmpleados.CkBx_Encurso.Checked = True
        Else
            Class_VariablesGlobales.frmEmpleados.CkBx_Encurso.Checked = False
        End If
        Class_VariablesGlobales.frmEmpleados.CBox_Grado.Text = DTGV_Educacion.CurrentRow.Cells.Item(5).Value.ToString



        Btn_EdGuarda.Text = "Actualizar"
    End Sub



    Private Sub Empleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_GuardarDeduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GuardarDeduccion.Click
        'If Btn_GuardarDeduccion.Text = "Guardar" Then
        '    Obj_Funciones_SQL.GuardaDeducciones(Txb_Cedula.Text, Cbx_CategoriaDeduccion.Text, Txb_MontoDeduccion.Text, txb_DescripcionDeduccion.Text, True, Class_VariablesGlobales.SQL_Comman2)
        'Else
        '    Obj_Funciones_SQL.GuardaDeducciones(Txb_Cedula.Text, Cbx_CategoriaDeduccion.Text, Txb_MontoDeduccion.Text, txb_DescripcionDeduccion.Text, True, Class_VariablesGlobales.SQL_Comman2)
        'End If
        'LimpiaDeducciones()
        'DGV_Deducciones.DataSource = Obj_Funciones_SQL.ObtieneDeducciones(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)




    End Sub

    Private Sub DGV_Deducciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Deducciones.CellContentClick
        'Class_VariablesGlobales.frmEmpleados.Cbx_CategoriaDeduccion.Text = DGV_Deducciones.CurrentRow.Cells.Item(0).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txb_Dedu_Adicional.Text = DGV_Deducciones.CurrentRow.Cells.Item(1).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txb_Dedu_CCSS.Text = DGV_Deducciones.CurrentRow.Cells.Item(2).Value.ToString

    End Sub

    Private Sub btn_EliminarDeduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EliminarDeduccion.Click
        Dim c As String = Txb_Cedula.Text
        'Obj_Funciones_SQL.EliminarDeducciones(Txb_Cedula.Text, Cbx_CategoriaDeduccion.Text, Class_VariablesGlobales.SQL_Comman2)
        LimpiaDeducciones()
        DGV_Deducciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDeducciones(c, Class_VariablesGlobales.SQL_Comman2)
    End Sub


    Private Sub btn_GuardaVacaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GuardaVacaciones.Click

        If btn_GuardaVacaciones.Text = "Actualizar" Then
            Class_VariablesGlobales.Obj_Funciones_SQL.VacacionesConsumidas(Trim(Txb_Cedula.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_VCFechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_VCFechaFin.Value.Date), Txb_VCDias.Text, txtb_comentario.Text, False, Class_VariablesGlobales.SQL_Comman2)
        Else
            Class_VariablesGlobales.Obj_Funciones_SQL.VacacionesConsumidas(Trim(Txb_Cedula.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_VCFechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_VCFechaFin.Value.Date), Txb_VCDias.Text, txtb_comentario.Text, True, Class_VariablesGlobales.SQL_Comman2)
        End If


        DGV_VacacionesConsumidas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneVacacionesConsumidas(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        txtb_Pendientes.Text = CInt(txtb_Vacaciones.Text) - CInt(txtb_VCTotal.Text)
        LimpiarVacaciones()


    End Sub

    Private Sub DTP_VCFechaIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_VCFechaIni.ValueChanged
        Dim Dias As Integer = DateDiff(DateInterval.Day, DTP_VCFechaIni.Value, DTP_VCFechaFin.Value)
        Txb_VCDias.Text = Dias
    End Sub

    Private Sub DTP_VCFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_VCFechaFin.ValueChanged
        Dim Dias As Integer = DateDiff(DateInterval.Day, DTP_VCFechaIni.Value, DTP_VCFechaFin.Value)
        Txb_VCDias.Text = Dias
    End Sub

    Private Sub DGV_VacacionesConsumidas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_VacacionesConsumidas.CellContentClick
        DTP_VCFechaIni.Value = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(0).Value.ToString()
        DTP_VCFechaFin.Value = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(1).Value.ToString()
        Txb_VCDias.Text = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(2).Value.ToString()
        txtb_comentario.Text = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(3).Value.ToString()

        btn_GuardaVacaciones.Text = "Actualizar"
    End Sub

    Public Function LimpiarVacaciones()
        DTP_VCFechaIni.Value = Now.Date
        DTP_VCFechaFin.Value = Now.Date
        Txb_VCDias.Text = ""
        txtb_comentario.Text = ""
        btn_GuardaVacaciones.Text = "Guardar"
    End Function

    Private Sub btn_DCEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DCEliminar.Click

        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaConsumoVacaciones(Trim(Txb_Cedula.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_VCFechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_VCFechaFin.Value.Date), Class_VariablesGlobales.SQL_Comman2)
        LimpiarVacaciones()
        DGV_VacacionesConsumidas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneVacacionesConsumidas(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)



    End Sub


    Private Sub Btn_EdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EdEliminar.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaEducacion(Trim(Txb_Cedula.Text), Txb_Institucion.Text, Class_VariablesGlobales.SQL_Comman2)
        LimpiaEducacion()
        DTGV_Educacion.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneEducacion(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
    End Sub


    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click
        If Txt_Id.Text = "" Then
            Txt_Id.Text = "0"
        End If

        If CInt(Txt_Id.Text) = 0 Then
            Btn_Atras.Enabled = False


        Else
            Dim Empleado As New DataTable
            Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.NavegaEmpleados(CInt(Txt_Id.Text) - 1, Class_VariablesGlobales.SQL_Comman2)
            Obj_List_Empleados.Navegar(Empleado)
        End If

    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        If Txt_Id.Text = "" Then
            Txt_Id.Text = "0"
        End If
        Btn_Atras.Enabled = True

        Dim Empleado As New DataTable
        Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.NavegaEmpleados(CInt(Txt_Id.Text) + 1, Class_VariablesGlobales.SQL_Comman2)
        Obj_List_Empleados.Navegar(Empleado)
    End Sub

    Private Sub CBox_Puesto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBox_Puesto.SelectedIndexChanged
        If CBox_Puesto.Text = "AGENTE" Then
            Txtb_CodRuta.Enabled = True

        Else
            Txtb_CodRuta.Enabled = False
            Txtb_CodRuta.Text = "0"
        End If
    End Sub

   
    Private Sub Txb_Cedula_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txb_Cedula.KeyPress

    End Sub
End Class