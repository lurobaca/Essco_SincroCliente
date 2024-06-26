Imports System.Configuration
Imports System.IO
Imports System.Text

Public Class Planilla_Empleados
    Public Obj_List_Empleados As New Planilla_List_Empleados
    Public Class_VariablesGlobales As New Class_VariablesGlobales
    Public Obj_Mformat As New MonedaFormat

    Private initializing As Boolean = False ' Variable para controlar la inicialización

    Public TapEducacionSeleccionado As Boolean = False
    Public TapVacacionesSeleccionado As Boolean = False
    Public TapFacturasSeleccionado As Boolean = False
    Public TapValesPrestamosSeleccionado As Boolean = False
    Public TapDeduccionesSeleccionado As Boolean = False
    Public TapIncapacidadesSeleccionado As Boolean = False
    Public TapAumentosSeleccionado As Boolean = False
    Public TapAdicionalesSeleccionado As Boolean = False

    Public TapPlanillasSeleccionado As Boolean = False
    Public TapLiquidacionSeleccionado As Boolean = False
    Public TapDiasAdicionalSeleccionado As Boolean = False



    Dim FotoDocumentoFirmadoVacaciones As Byte()
    Dim FotoDocumentoFirmadoValesPrestamos As Byte()
    Dim FotoDocumentoFirmadoIncapacidades As Byte()
    Dim FotoDocumentoFirmadoLiquidacion As Byte()
    Dim FotoEmpleadoBytes As Byte()



    Private Sub CkBx_Encurso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkBx_Encurso.CheckedChanged
        If CkBx_Encurso.Checked = True Then
            DTP_EFechaSalida.Enabled = False
        Else
            DTP_EFechaSalida.Enabled = True
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try


            'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            '    ' List files in the folder.

            '    PictureBox1.Image = Image.FromFile(FolderBrowserDialog1.SelectedPath)
            'End If

            If Txb_Cedula.Text <> "" Then

                If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)

                    PicBox_FotoEmpleado.Image = Image.FromFile(OpenFileDialog1.FileName)
                    Txb_RutaImagen.Text = Class_VariablesGlobales.RutaFotosPlanilla & Txb_Cedula.Text & ".jpg"
                    PicBox_FotoEmpleado.Image.Save(Class_VariablesGlobales.RutaFotosPlanilla & Txb_Cedula.Text & ".jpg", Drawing.Imaging.ImageFormat.Jpeg)

                    sr.Close()
                End If
            Else
                MessageBox.Show("Ingrese el numero de cedula")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function Button1_Click(sender As Object, e As EventArgs) Handles BtnAnular.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If


        Dim result As DialogResult = MessageBox.Show("Esta seguro que desea inactivar al empleado?",
                          "Alerta",
                          MessageBoxButtons.YesNo)

        If (result = DialogResult.Yes) Then
            'Cambia el estado del empleado
            Class_VariablesGlobales.Obj_Funciones_SQL.CambiaEstadoEmpleado(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, 1, Class_VariablesGlobales.SQL_Comman2)
            CambiaVisibilidadEmpleadoAnulado(False, 1)
        Else
        End If



    End Function

    ' Función para reemplazar caracteres especiales
    Function ReplaceSpecialCharacters(ByVal input As String) As String
        ' Diccionario de caracteres especiales y sus reemplazos
        Dim replacements As New Dictionary(Of Char, Char) From {
            {"á"c, "a"c}, {"é"c, "e"c}, {"í"c, "i"c}, {"ó"c, "o"c}, {"ú"c, "u"c},
            {"Á"c, "A"c}, {"É"c, "E"c}, {"Í"c, "I"c}, {"Ó"c, "O"c}, {"Ú"c, "U"c},
            {"ñ"c, "n"c}, {"Ñ"c, "N"c}
        }

        Dim result As New StringBuilder()

        ' Recorrer cada carácter de la cadena de entrada
        For Each ch As Char In input
            ' Si el carácter está en el diccionario de reemplazos, agregar el carácter reemplazado al resultado
            If replacements.ContainsKey(ch) Then
                result.Append(replacements(ch))
            Else
                ' Si el carácter es alfanumérico o espacio, agregarlo al resultado
                If Char.IsLetterOrDigit(ch) OrElse Char.IsWhiteSpace(ch) Then
                    result.Append(ch)
                End If
            End If
        Next

        Return result.ToString()
    End Function

    Private Function Btn_GuardarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click


        Dim estado As Integer = 0
        If Not ChkB_Activo.Checked Then
            estado = 1
        End If

        Txb_Nombre.Text = ReplaceSpecialCharacters(Txb_Nombre.Text)


        If Txb_Salario.Text.Trim() = "" Or CDbl(Txb_Salario.Text.Trim()) = 0 Or CDbl(Txb_Salario.Text.Trim()) < 1000 Then
            MessageBox.Show("Debe indicar un salario de almenos 1000.")
            Txb_Salario.Focus()
            Return True

        End If
        If TxtBox_CuentaContable.Text.Trim() <> "" Then
            If Class_VariablesGlobales.Obj_Funciones_SQL.ValidaExisteCuentaContable(TxtBox_CuentaContable.Text.Trim(), Class_VariablesGlobales.SQL_Comman2) = False Then
                MessageBox.Show("Debe indicar una cuenta contable que exista en el plan de cuentas de SAP.")
                TxtBox_CuentaContable.Focus()
                Return True
            End If
        End If

        If TxtBox_CuentaContable.Text.Length > 15 Then
            MessageBox.Show("La cuenta contable excede los 15 caracteres permitidos.")
            TxtBox_CuentaContable.Focus()
            Return True
        End If

        If Txb_CodigoCliente.Text.Trim() <> "" Then
            If Class_VariablesGlobales.Obj_Funciones_SQL.ValidaExisteCodigoCliente(Txb_CodigoCliente.Text.Trim(), Class_VariablesGlobales.SQL_Comman2) = False Then
                MessageBox.Show("Debe indicar un codigo de cliente que exista en SAP.")
                Txb_CodigoCliente.Focus()
                Return True
            End If
        End If

        If Txb_CodigoCliente.Text.Length > 15 Then
            MessageBox.Show("El codigo de cliente excede los 15 caracteres permitidos.")
            Txb_CodigoCliente.Focus()
            Return True
        End If

        ' Convierte la imagen en un arreglo de bytes
        If Txb_RutaImagen.Text <> "" And File.Exists(Txb_RutaImagen.Text) = True Then
            FotoEmpleadoBytes = File.ReadAllBytes(Txb_RutaImagen.Text)
        Else

            If Txb_RutaImagen.Text <> "" And File.Exists(Txb_RutaImagen.Text) = False Then
                MessageBox.Show("No se encontro la ruta de la imagen [" & Txb_RutaImagen.Text & "]")
            End If

            FotoEmpleadoBytes = ConvertirSinFotoaBytes()

        End If
        If Txb_Cedula.Text = "" Or Txb_Nombre.Text = "" Or Txb_Salario.Text = "" Or TxtCuentaBancaria.Text = "" Or TxtIdColaboradorBanco.Text = "" Or CmboBox_CategoriaEmpeado.Text = "" Then
            MessageBox.Show("Para guardar un empleado, es necesario proporcionar la cédula, nombre, salario, cuenta bancaria, ID del colaborador y la categoría del empleado.")
            Return True
        End If

        Dim ExisteEmpleado As Boolean = Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExisteEmpleado(Trim(Txt_Id.Text), Class_VariablesGlobales.SQL_Comman2)

        If ExisteEmpleado = False And Btn_Guardar.Text.Trim().Equals("Guardar") Then
            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaEmpleado(Txb_Cedula.Text, Txb_Nombre.Text, CBox_Puesto.Text, Txb_Telefono1.Text, Txb_Telefono2.Text, FotoEmpleadoBytes, CDbl(Txb_Salario.Text).ToString(), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaIngreso.Value.Date), Nothing, DTGV_Experiencia.DataSource, DTGV_Educacion.DataSource, estado, Txb_CodigoCliente.Text, Txtb_CodRuta.Text, txtb_Correo.Text, CInt(txtb_AnosLaborados.Text), CInt(txtb_MesesLaborados.Text), CInt(txtb_DiasLaborados.Text), CInt(txtb_DiasTotalesDeVacacionesGanadas.Text), CInt(txtb_DiasTotalesDeVacacionesConsumidas.Text), CInt(txtb_DiasTotalesDeVacacionesPendientes.Text), TxtCuentaBancaria.Text, TxtIdColaboradorBanco.Text, TxtBox_CuentaContable.Text, CmboBox_CategoriaEmpeado.Text, True, Class_VariablesGlobales.SQL_Comman2, Txt_Id.Text) = True Then
                MessageBox.Show("¡Empleado guardado correctamente!")
                LimpiarInfoEmpleado()
                Return True
            End If

        End If

        If ExisteEmpleado = True And Btn_Guardar.Text.Trim().Equals("Actualizar") Then

            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaEmpleado(Txb_Cedula.Text, Txb_Nombre.Text, CBox_Puesto.Text, Txb_Telefono1.Text, Txb_Telefono2.Text, FotoEmpleadoBytes, CDbl(Txb_Salario.Text).ToString(), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaIngreso.Value.Date), Nothing, DTGV_Experiencia.DataSource, DTGV_Educacion.DataSource, estado, Txb_CodigoCliente.Text, Txtb_CodRuta.Text, txtb_Correo.Text, txtb_AnosLaborados.Text, txtb_MesesLaborados.Text, txtb_DiasLaborados.Text, txtb_DiasTotalesDeVacacionesGanadas.Text, txtb_DiasTotalesDeVacacionesConsumidas.Text, txtb_DiasTotalesDeVacacionesPendientes.Text, TxtCuentaBancaria.Text, TxtIdColaboradorBanco.Text, TxtBox_CuentaContable.Text, CmboBox_CategoriaEmpeado.Text, False, Class_VariablesGlobales.SQL_Comman2, Txt_Id.Text) = True Then
                MessageBox.Show("¡Empleado guardado correctamente!")
                LimpiarInfoEmpleado()
            End If
        Else
            MessageBox.Show("La cédula del empleado no existe en nuestra base de datos.")
        End If



    End Function

    Public Function ConvertirSinFotoaBytes()

        Dim sinFoto As Bitmap = My.Resources.SinFoto
        Dim sinFotoBytes As Byte()

        ' Convertir la imagen a un arreglo de bytes
        Using stream As New MemoryStream()
            sinFoto.Save(stream, System.Drawing.Imaging.ImageFormat.Png) ' Puedes usar otro formato si lo prefieres
            sinFotoBytes = stream.ToArray()
        End Using

        Return sinFotoBytes
    End Function



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Txt_Id.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoEmpleado(Class_VariablesGlobales.SQL_Comman2)
        LimpiarInfoEmpleado()
    End Sub



#Region "EXPERIENCIA"

    Public Function LimpiaExperiencia()
        Txt_ExperienciaCedulaEmpresa.Text = ""
        Txt_ExperienciaEmpresa.Text = ""
        Txt_ExperienciaExPuesto.Text = ""
        Txt_ExperienciaPersona.Text = ""
        Txt_ExperienciaTelefono.Text = ""
        DTP_ExperienciaExFechaIngreso.ResetText()
        DTP_ExperienciaExFechaSalida.ResetText()
        Txt_ExperienciaComentario.Text = ""
        DTGV_Experiencia.DataSource = New DataTable
        DTGV_Experiencia.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneExperiencia(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Btn_ExperienciaGuardar.Text = "Guardar"
    End Function

    Private Sub DTGV_Experiencia_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DTGV_Experiencia.CellContentClick
        Try


            Class_VariablesGlobales.frmEmpleados.Txt_ExperienciaEmpresa.Text = DTGV_Experiencia.CurrentRow.Cells.Item(0).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txt_ExperienciaExPuesto.Text = DTGV_Experiencia.CurrentRow.Cells.Item(1).Value.ToString
        Class_VariablesGlobales.frmEmpleados.DTP_ExperienciaExFechaIngreso.Text = DTGV_Experiencia.CurrentRow.Cells.Item(2).Value.ToString
        Class_VariablesGlobales.frmEmpleados.DTP_ExperienciaExFechaSalida.Text = DTGV_Experiencia.CurrentRow.Cells.Item(3).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txt_ExperienciaPersona.Text = DTGV_Experiencia.CurrentRow.Cells.Item(4).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txt_ExperienciaTelefono.Text = DTGV_Experiencia.CurrentRow.Cells.Item(5).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txt_ExperienciaComentario.Text = DTGV_Experiencia.CurrentRow.Cells.Item(6).Value.ToString
        Class_VariablesGlobales.frmEmpleados.Txt_ExperienciaCedulaEmpresa.Text = DTGV_Experiencia.CurrentRow.Cells.Item(7).Value.ToString
            Btn_ExperienciaGuardar.Text = "Actualizar"
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub Btn_ExNuevo_Click(sender As Object, e As EventArgs) Handles Btn_ExperienciaNuevo.Click
        LimpiaExperiencia()
    End Sub
    Private Function Btn_ExperienciaGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExperienciaGuardar.Click

        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        Dim ced As String = Txb_Cedula.Text

        If ValidaCamposExperiencia() = False Then
            MessageBox.Show("Verifique que todos los campos están lleno")
            Return True
        End If

        If Btn_ExperienciaGuardar.Text = "Guardar" Then
            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaExperiencia(Txb_Cedula.Text, Txt_ExperienciaCedulaEmpresa.Text, Txt_ExperienciaEmpresa.Text, Txt_ExperienciaExPuesto.Text, Txt_ExperienciaPersona.Text, Txt_ExperienciaTelefono.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ExperienciaExFechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ExperienciaExFechaSalida.Value.Date), Txt_ExperienciaComentario.Text, DTGV_Experiencia.DataSource, True, Class_VariablesGlobales.SQL_Comman2) = True Then
                LimpiaExperiencia()
                DTGV_Experiencia.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneExperiencia(ced, Class_VariablesGlobales.SQL_Comman2)
            End If
        Else
            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardaExperiencia(Txb_Cedula.Text, Txt_ExperienciaCedulaEmpresa.Text, Txt_ExperienciaEmpresa.Text, Txt_ExperienciaExPuesto.Text, Txt_ExperienciaPersona.Text, Txt_ExperienciaTelefono.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ExperienciaExFechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ExperienciaExFechaSalida.Value.Date), Txt_ExperienciaComentario.Text, DTGV_Experiencia.DataSource, False, Class_VariablesGlobales.SQL_Comman2) = True Then
                LimpiaExperiencia()
                DTGV_Experiencia.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneExperiencia(ced, Class_VariablesGlobales.SQL_Comman2)
            End If
        End If
    End Function
    Private Function Btn_ExEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExperienciaEliminar.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaExperiencia(Txb_Cedula.Text, Txt_ExperienciaEmpresa.Text, Class_VariablesGlobales.SQL_Comman2)
        LimpiaExperiencia()
        DTGV_Experiencia.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneExperiencia(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
    End Function
    Private Function ValidaCamposExperiencia()

        If (Txt_ExperienciaCedulaEmpresa.Text = "") Then
            Return False
        End If
        If (Txt_ExperienciaEmpresa.Text = "") Then
            Return False
        End If
        If (Txt_ExperienciaExPuesto.Text = "") Then
            Return False
        End If
        If (Txt_ExperienciaPersona.Text = "") Then
            Return False
        End If
        If (Txt_ExperienciaTelefono.Text = "") Then
            Return False
        End If

        If (Txt_ExperienciaComentario.Text = "") Then
            Return False
        End If

        Return True
    End Function


    Public Function ValidaExistenciaEmpleado()


        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExisteEmpleado(Trim(Txt_Id.Text), Class_VariablesGlobales.SQL_Comman2) = False Then
            MsgBox("Debe seleccionar un empleado")
            Return False
        Else

            Return True

        End If
    End Function

#End Region

#Region "EDUCACION"
    Private Sub Btn_EdNuevo_Click(sender As Object, e As EventArgs) Handles Btn_EducacionNuevo.Click
        LimpiaEducacion()
    End Sub
    Private Function Btn_EdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EducacionEliminar.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaEducacion(Trim(Txb_Cedula.Text), Txb_Institucion.Text, Class_VariablesGlobales.SQL_Comman2)
        LimpiaEducacion()
    End Function
    Private Function Btn_EdGuarda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EducacionGuarda.Click


        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        Dim ced As String = Txb_Cedula.Text

        If CkBx_Encurso.Checked = False And Now.Date < Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_EFechaSalida.Value.Date) Then
            MsgBox("La fecha de salida no puede ser mayor a la fecha actual")
            Return True
        End If

        If Btn_EducacionGuarda.Text = "Guardar" Then
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
    End Function
    Public Function LimpiaEducacion()
        Txb_Institucion.Text = ""
        DTP_EFechaIngreso.ResetText()
        DTP_EFechaSalida.ResetText()
        Txb_Titulo.Text = ""
        CBox_Grado.Text = ""
        CkBx_Encurso.Checked = False
        DTGV_Educacion.DataSource = New DataTable
        DTGV_Educacion.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneEducacion(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Btn_EducacionGuarda.Text = "Guardar"
    End Function

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

        Btn_EducacionGuarda.Text = "Actualizar"
    End Sub
#End Region

#Region "VACACIONES"
    Private Function Btn_AnularVacaciones_Click(sender As Object, e As EventArgs) Handles Btn_AnularVacaciones.Click

        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        If Class_VariablesGlobales.Obj_Funciones_SQL.VacacionesAnular(Trim(Txtb_ConsecutivoVacaciones.Text), 1, Class_VariablesGlobales.SQL_Comman2) Then
            MsgBox("Solicitud de vacaciones fue anulado")
            LimpiarVacaciones()
        End If
    End Function

    Public Function ImprimirSolicitudVacaciones()


        Class_VariablesGlobales.Planilla_ConsecutivoSolicitudVacaciones = Txtb_ConsecutivoVacaciones.Text
        Class_VariablesGlobales.IMPRIMIENDO = "SolicitudVacaciones"
        frmReporte.Show()
    End Function

    Private Function BtnImprimir_Vacaciones_Click(sender As Object, e As EventArgs) Handles BtnImprimir_Vacaciones.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExisteSolicitudVacaciones(Trim(Txtb_ConsecutivoVacaciones.Text), Class_VariablesGlobales.SQL_Comman2) Then
            ImprimirSolicitudVacaciones()
        Else
            MsgBox("Debe crear o seleccionar una solicitud antes de imprimir")
        End If


    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Btn_NuevoVacaciones.Click
        LimpiarVacaciones()
    End Sub

    Private Function Btn_VerVacacionesFirmado_Click(sender As Object, e As EventArgs) Handles Btn_VerVacacionesFirmado.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        VisualizarArchivo(FotoDocumentoFirmadoVacaciones, Txtb_RutaFotoDocumentoFirmadoVacaciones.Text)

    End Function

    Private Function Btn_AdjuntarVacacionesFirmado_Click(sender As Object, e As EventArgs) Handles Btn_AdjuntarVacacionesFirmado.Click

        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        OpenFileDialog1.Filter = "Archivos de Imagen y PDF|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf|Todos los archivos|*.*"
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            filePath = OpenFileDialog1.FileName
            Txtb_RutaFotoDocumentoFirmadoVacaciones.Text = filePath
        End If
    End Function

    Private Function Btn_DescargarVacacionesFirmado_Click(sender As Object, e As EventArgs) Handles Btn_DescargarVacacionesFirmado.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        If Txtb_RutaFotoDocumentoFirmadoVacaciones.Text.Equals("") Then
            MessageBox.Show("Debe adjuntar un documento para descargar.")
            Return False
        End If
        filePath = Txtb_RutaFotoDocumentoFirmadoVacaciones.Text


        ' Obtener la extensión del archivo original
        Dim extension As String = Path.GetExtension(filePath)
        If Not String.IsNullOrEmpty(filePath) Then
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = $"Archivos {extension}|*{extension}|Todos los archivos|*.*"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    File.Copy(filePath, saveFileDialog.FileName, True)
                    MessageBox.Show("Archivo descargado exitosamente.")
                Catch ex As Exception
                    MessageBox.Show("Error al descargar el archivo. " & ex.Message)
                End Try
            End If
        End If
    End Function

    Private Function ConvertirImagenABytes(ByVal imagen As Image) As Byte()
        Using stream As New MemoryStream()
            imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg) ' Puedes ajustar el formato de imagen según tus necesidades (Jpeg, Png, etc.)
            Return stream.ToArray()
        End Using
    End Function

    Private Sub DGV_VacacionesConsumidas_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_VacacionesConsumidas.CellContentClick

        Panel_AdjuntoVacaciones.Visible = True

        '[Consecutivo],[FechaIni] ,[FechaFin] ,[Dias],[Comentario],[Adjunto]
        Txtb_ConsecutivoVacaciones.Text = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(0).Value.ToString()
        DTP_FechaIniVacaciones.Value = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(1).Value.ToString()
        DTP_FechaFinVacaciones.Value = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(2).Value.ToString()
        Txb_DiasAConsumirVacaciones.Text = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(3).Value.ToString()
        txtb_comentario.Text = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(4).Value.ToString()

        Dim Adjunto As Object = DGV_VacacionesConsumidas.CurrentRow.Cells.Item(5).Value

        If Adjunto IsNot DBNull.Value Then
            FotoDocumentoFirmadoVacaciones = DirectCast(DGV_VacacionesConsumidas.CurrentRow.Cells.Item(5).Value, Byte())
            CargarAdjunto(FotoDocumentoFirmadoVacaciones, Txtb_RutaFotoDocumentoFirmadoVacaciones, PBox_Vacaciones)
        End If

        If DGV_VacacionesConsumidas.CurrentRow.Cells.Item(6).Value = "1" Then
            Lbl_AnuladoVacaciones.Visible = True
            Btn_AnularVacaciones.Enabled = False
            btn_GuardaVacaciones.Enabled = False
            Btn_AdjuntarVacacionesFirmado.Enabled = False
        Else
            Lbl_AnuladoVacaciones.Visible = False
            Btn_AnularVacaciones.Enabled = True
            btn_GuardaVacaciones.Enabled = True
            Btn_AdjuntarVacacionesFirmado.Enabled = True
        End If

        btn_GuardaVacaciones.Text = "Actualizar"
    End Sub

    Private Sub ValidateVarbinaryEqualsEmpty()
        ' Obtener el valor de un campo VARBINARY(MAX) en la fila seleccionada del DataGridView
        Dim rowIndex As Integer = DGV_VacacionesConsumidas.CurrentRow.Index
        Dim varbinaryData As Byte() = DirectCast(DGV_VacacionesConsumidas.CurrentRow.Cells.Item(5).Value, Byte())

        If varbinaryData IsNot Nothing AndAlso varbinaryData.SequenceEqual(New Byte() {}) Then
            ' El campo VARBINARY(MAX) es igual a {}
            MessageBox.Show("El campo VARBINARY(MAX) es igual a {}")
        Else
            ' El campo VARBINARY(MAX) no es igual a {}
            MessageBox.Show("El campo VARBINARY(MAX) no es igual a {}")
        End If
    End Sub

    Public Function CargarAdjunto(imageData As Byte(), Txtbox As TextBox, PBox_Adjunto As PictureBox)

        Try
            ' Si los datos de la imagen son válidos
            If imageData IsNot Nothing AndAlso imageData.Length > 0 Then
                ' Crea un flujo de memoria para almacenar los datos de la imagen
                Using stream As New MemoryStream(imageData)
                    'Carga la imagen en espacio temporal
                    Dim tempPath As String = Path.GetTempFileName()
                    File.WriteAllBytes(tempPath, imageData)
                    Txtbox.Text = tempPath

                    '' Carga la imagen desde el flujo de memoria
                    'Dim image As Image = Image.FromStream(stream)

                    '' Asigna la imagen al control PictureBox
                    'PBox_Adjunto.Image = image



                End Using
            Else

            End If

        Catch ex As Exception
            MessageBox.Show("Error al recuperar la imagen [ " & ex.Message & " ]")

        End Try

    End Function

    Private Sub VisualizarArchivo(archivo As Byte(), Path As String)
        If archivo IsNot Nothing AndAlso archivo.Length > 0 Then
            Process.Start(Path)
        Else
            MessageBox.Show("No se pudo recuperar el archivo.")
        End If
    End Sub

    Private Function EsArchivoPDF(archivo As Byte()) As Boolean
        Try
            ' Verifica si el archivo comienza con la firma típica de un archivo PDF
            Dim firmaPDF As Byte() = Encoding.ASCII.GetBytes("%PDF-")

            For i As Integer = 0 To firmaPDF.Length - 1
                If archivo(i) <> firmaPDF(i) Then
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            ' Maneja excepciones (puede ser útil para casos de archivos dañados o no válidos)
            Return False
        End Try
    End Function

    Private Function GuardarArchivoTemporal(archivo As Byte(), nombreArchivo As String) As String
        Dim tempPath As String = ""
        Try
            tempPath = Path.Combine(Path.GetTempPath(), nombreArchivo)
            File.WriteAllBytes(tempPath, archivo)
            Return tempPath
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return tempPath
    End Function

    Private Function ByteArrayAImagen(archivo As Byte()) As Image
        Using ms As New MemoryStream(archivo)
            Return Image.FromStream(ms)
        End Using
    End Function

    Public Function CalculaDiasLaboralesEntreFechas(fechaInicio As DateTime, fechaFin As DateTime)


        ' Verificar que la fecha de inicio sea anterior o igual a la fecha de fin
        If fechaInicio < fechaFin Or fechaInicio.ToShortDateString.Equals(fechaFin.ToShortDateString) Then
            ' Obtener la cantidad de dias laborales
            Return ObtenerDiasLaborales(fechaInicio, fechaFin)
        Else
            MessageBox.Show("La fecha de inicio debe ser anterior o igual a la fecha de fin.")
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Obtiene los dias de lunes a sabados entre 2 fechas
    ''' </summary>
    ''' <param name="fechaInicio"></param>
    ''' <param name="fechaFin"></param>
    ''' <returns></returns>
    Private Function ObtenerDiasLaborales(fechaInicio As DateTime, fechaFin As DateTime) As Integer
        Dim diasLaborales As Integer = 0

        ' Recorrer cada día entre las fechas seleccionadas
        Dim diaActual As DateTime = fechaInicio

        While diaActual <= fechaFin
            diasLaborales += 1
            ' Avanzar al siguiente día
            diaActual = diaActual.AddDays(1)
        End While

        Return diasLaborales
    End Function



    Private Function ValidaSaldoDisponiblesVacaciones()
        Dim Saldo As Double = 0
        If Txb_DiasAConsumirVacaciones.Text <> "" And txtb_DiasTotalesDeVacacionesPendientes.Text <> "" Then
            Saldo = CDbl(txtb_DiasTotalesDeVacacionesPendientes.Text) - CDbl(Txb_DiasAConsumirVacaciones.Text)
        End If

        If Saldo >= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function btn_GuardaVacaciones_Click_1(sender As Object, e As EventArgs) Handles btn_GuardaVacaciones.Click

        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        If btn_GuardaVacaciones.Text = "Guardar" And ValidaSaldoDisponiblesVacaciones() Then
            MsgBox("Los días disponibles de vacaciones no son suficientes")
            Return False
        End If

        If DTP_FechaIniVacaciones.Value < DTP_FechaIngreso.Value Then
            MsgBox("La fecha de inicio de las vacaciones no puede ser menor que la fecha de ingreso.")
            Return False
        End If

        ' Convierte la imagen en un arreglo de bytes
        If Txtb_RutaFotoDocumentoFirmadoVacaciones.Text <> "" Then
            FotoDocumentoFirmadoVacaciones = File.ReadAllBytes(Txtb_RutaFotoDocumentoFirmadoVacaciones.Text)
        End If

        Dim RegistroExiste As Boolean = Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExisteSolicitudVacaciones(Trim(Txtb_ConsecutivoVacaciones.Text), Class_VariablesGlobales.SQL_Comman2)

        Dim EstadoGuardado As Boolean = Class_VariablesGlobales.Obj_Funciones_SQL.GuardaVacacionesConsumidas(Trim(Txtb_ConsecutivoVacaciones.Text), Trim(Txb_Cedula.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaIniVacaciones.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaFinVacaciones.Value.Date), Txb_DiasAConsumirVacaciones.Text, txtb_comentario.Text, FotoDocumentoFirmadoVacaciones, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date), 0, RegistroExiste, Class_VariablesGlobales.SQL_Comman2)

        If EstadoGuardado Then
            DGV_VacacionesConsumidas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneVacacionesConsumidas(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
            txtb_DiasTotalesDeVacacionesGanadas.Text = CDbl(txtb_DiasTotalesDeVacacionesGanadas.Text) - CDbl(txtb_DiasTotalesDeVacacionesConsumidas.Text)

            Txt_MontoVacacionesPendientes.Text = (CDbl(Txb_Salario.Text) / 30) * CDbl(txtb_DiasTotalesDeVacacionesGanadas.Text)

            LimpiarVacaciones()
        End If

    End Function

    Public Function LimpiarVacaciones()

        Panel_AdjuntoVacaciones.Visible = False
        DTP_FechaIniVacaciones.Value = Now.Date
        DTP_FechaFinVacaciones.Value = Now.Date
        Txb_DiasAConsumirVacaciones.Text = ""
        Txtb_RutaFotoDocumentoFirmadoVacaciones.Text = ""
        FotoDocumentoFirmadoVacaciones = Nothing
        PBox_Vacaciones.Image = Nothing
        txtb_comentario.Text = ""
        DGV_VacacionesConsumidas.DataSource = New DataTable
        DGV_VacacionesConsumidas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneVacacionesConsumidas(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Txtb_ConsecutivoVacaciones.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoVacaciones(Class_VariablesGlobales.SQL_Comman2)

        Lbl_AnuladoVacaciones.Visible = False
        Btn_AnularVacaciones.Enabled = True
        btn_GuardaVacaciones.Enabled = True
        Btn_AdjuntarVacacionesFirmado.Enabled = True
        btn_GuardaVacaciones.Text = "Guardar"
        CalculaVacaciones()
    End Function

    Private Sub btn_DCEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaConsumoVacaciones(Trim(Txb_Cedula.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaIniVacaciones.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaFinVacaciones.Value.Date), Class_VariablesGlobales.SQL_Comman2)
        LimpiarVacaciones()
    End Sub

    Public Function CargarExperienciaLabora()
        Class_VariablesGlobales.frmEmpleados.DTGV_Experiencia.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneExperiencia(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
    End Function

    Public Function CargarEducacion()
        Class_VariablesGlobales.frmEmpleados.DTGV_Educacion.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneEducacion(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
    End Function

    Public Function CargarVacaciones()
        Try
            DGV_VacacionesConsumidas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneVacacionesConsumidas(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
            CalculaVacaciones()

            Dim ConsecutivoVacaciones = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoVacaciones(Class_VariablesGlobales.SQL_Comman2)

            Txtb_ConsecutivoVacaciones.Text = ConsecutivoVacaciones
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try


    End Function

    Public Function CargarFacturas()
        If Txb_CodigoCliente.Text <> "" Then

            DGV_Facturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtineFacturas(Txb_CodigoCliente.Text, Class_VariablesGlobales.SQL_Comman2)
            CalculaTotalFacturas()
        End If
    End Function

    Private Sub DGV_Facturas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_Facturas.CellFormatting
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

            ' Aplicar formato personalizado al valor de la celda de la columna de precios
            Dim precio As Double = CDbl(e.Value)
            e.Value = precio.ToString("C2") ' Aplicar formato de moneda
            e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

        End If
    End Sub

    Private Sub DGV_ValesPrestamos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_ValesPrestamos.CellFormatting
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 2 Or e.ColumnIndex = 3 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

            ' Aplicar formato personalizado al valor de la celda de la columna de precios
            Dim precio As Double = CDbl(e.Value)
            e.Value = precio.ToString("C2") ' Aplicar formato de moneda
            e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

        End If
    End Sub

    Private Sub DGV_Deducciones_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_Deducciones.CellFormatting
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 2 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

            ' Aplicar formato personalizado al valor de la celda de la columna de precios
            Dim precio As Double = CDbl(e.Value)
            e.Value = precio.ToString("C2") ' Aplicar formato de moneda
            e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

        End If
    End Sub

    Private Sub DGV_Aumentos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_Aumentos.CellFormatting
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

            ' Aplicar formato personalizado al valor de la celda de la columna de precios
            Dim precio As Double = CDbl(e.Value)
            e.Value = precio.ToString("C2") ' Aplicar formato de moneda
            e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

        End If
    End Sub

    Public Function CargarValesPrestamos()
        Class_VariablesGlobales.frmEmpleados.DGV_ValesPrestamos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneValesPrestamos(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Dim ConsecutivoValesPrestamos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoValesPrestamos(Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.frmEmpleados.txtb_ConsecutivoValePrestamo.Text = ConsecutivoValesPrestamos

        Class_VariablesGlobales.frmEmpleados.CalculaTotalValesPrestamos()
    End Function

    Public Function CargarDeducciones()
        Class_VariablesGlobales.frmEmpleados.DGV_Deducciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDeducciones(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.frmEmpleados.CalculaTotalDeducciones()

        Dim ConsecutivoDeducciones = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoDeducciones(Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.frmEmpleados.TxtBox_ConsecutivoDeducciones.Text = ConsecutivoDeducciones
    End Function

    Public Function CargarIncapacidades()
        Class_VariablesGlobales.frmEmpleados.DGV_Incapacidades.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneIncapacidades(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Dim ConsecutivoIncapacidades = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoIncapacidades(Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.frmEmpleados.Txtb_ConsecutivoIncapacidades.Text = ConsecutivoIncapacidades
    End Function

    Public Function CargarAdicionales()
    End Function

    Public Function CargarAumentos()
        Class_VariablesGlobales.frmEmpleados.DGV_Aumentos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAumentos(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
    End Function

    Public Function CargarAportesPatronales()

    End Function

    Public Function CargaPlanilla()
        Try
            Class_VariablesGlobales.frmEmpleados.DGV_Planillas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtienePlanillasXEmpleado(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)

            Txtb_PlanillaDiasLaborados6meses.Text = ObtieneDiasTrabajadosxMesXEmpleado(Txb_Cedula.Text).ToString()

            Txtb_PlanillasSalarioPromedio.Text = ObtieneSalarioBrutoSinDeduccionesPromedioXMesXEmpleado(Txb_Cedula.Text)
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Function
    Public Function CargaDiasAdiconales()
        Class_VariablesGlobales.frmEmpleados.DGV_DiasAdicionales.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDiasAdicionalesXEmpleado(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
    End Function
    Public Function CargarLiquidacion()
        Try

            Class_VariablesGlobales.frmEmpleados.CalculaPreaviso()
            'Valida si ya fue liquidado el empleado
            If LBL_LIQUIDADO.Visible = True Then
                'Obtiene la informacion de la liquidacion
                Dim TBL As New DataTable
                TBL = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidacion(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)

                If TBL IsNot Nothing Then
                    If TBL.Rows.Count Then
                        CBox_LiquidacionMotivoSalida.Text = TBL.Rows(0).Item("MotivoSalida")
                        'CBox_LiquidacionMotivoSalida.Text = TBL.Rows(0).Item("Preaviso")
                        TxtBox_MontoCesantia.Text = TBL.Rows(0).Item("Cesantia")
                        TxtBox_LiquidacionMontoAguinaldo.Text = TBL.Rows(0).Item("Aguinaldo")
                        CBox_LiquidacionMotivoSalida.Text = TBL.Rows(0).Item("Vacaciones")
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function CargarAguinaldo()
        Class_VariablesGlobales.frmEmpleados.CalculaAguinaldo()

    End Function

    Public Function CargarAmonestaciones()
        'todo. no esta en la cotizacion
    End Function

    Public Function CargarReconocimientos()
        'todo. no esta en la cotizacion
    End Function

    Public Function CalculaVacaciones()

        Try


            ' Obtiene las fechas seleccionadas de los DateTimePicker
            Dim fechaInicio As DateTime = DTP_FechaIngreso.Value
            Dim fechaFin As DateTime = DTP_FechaSalida.Value
            Dim diasTrabajados As Integer = DateDiff(DateInterval.Day, fechaInicio, fechaFin)
            Dim DiasVacacionesTotales As Double
            ' Calcula el número total de días de vacaciones
            Dim totalDiasVacaciones As Decimal = (diasTrabajados / 365) * 14
            Dim SalarioDiario As Double = 0
            Dim SalarioPromedio As Double = ObtieneSalarioBrutoSinDeduccionesPromedioXMesXEmpleado()

            If Txb_SalarioDiario.Text <> "" Then
                SalarioDiario = CDbl(Txb_SalarioDiario.Text)
            End If

            ' Muestra los resultados en un control TextBox

            If totalDiasVacaciones.ToString() <> "" Then
                Dim totalRedondeado As Double = Math.Round(totalDiasVacaciones, 2)
                txtb_DiasTotalesDeVacacionesGanadas.Text = totalRedondeado.ToString("F2")
            Else
                txtb_DiasTotalesDeVacacionesGanadas.Text = "0.0"
            End If




            Dim DiasConsumidos As Double = If(txtb_DiasTotalesDeVacacionesConsumidas.Text = "", 0, CDbl(txtb_DiasTotalesDeVacacionesConsumidas.Text))
            Dim VacacionesGanadas As Double = If(txtb_DiasTotalesDeVacacionesGanadas.Text = "", 0, CDbl(txtb_DiasTotalesDeVacacionesGanadas.Text))

            DiasVacacionesTotales = Math.Round(CDbl(VacacionesGanadas - DiasConsumidos), 2)

            txtb_DiasTotalesDeVacacionesPendientes.Text = DiasVacacionesTotales
            Txt_MontoVacacionesPendientes.Text = Obj_Mformat.FormatoMoneda(CDbl(DiasVacacionesTotales * SalarioDiario))

            TxtBos_LiquidacionDiasVacaciones.Text = DiasVacacionesTotales
            TxtBos_LiquidacionMontoVacaciones.Text = Obj_Mformat.FormatoMoneda(CDbl(DiasVacacionesTotales * SalarioDiario))

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Public Function CalcularDiasMesEnCurso()
        Try
            Dim fechaInicio As DateTime = DTP_FechaIngreso.Value
            Dim fechaFin As DateTime = DTP_FechaSalida.Value

        Catch ex As Exception

        End Try
    End Function

    Public Function CalcularMesesLaborados(FechaInicio As DateTime, FechaFinal As DateTime) As Integer
        Dim meses As Integer = 0

        ' Asegurarse de que la fecha de inicio sea menor o igual a la fecha final
        If FechaInicio <= FechaFinal Then
            ' Calcular el número de años entre las fechas
            Dim años As Integer = FechaFinal.Year - FechaInicio.Year

            ' Calcular el número de meses adicionales (después de los años completos)
            Dim mesesAdicionales As Integer = FechaFinal.Month - FechaInicio.Month

            ' Sumar los meses completos y los meses adicionales
            meses = años * 12 + mesesAdicionales
        End If

        Return meses
    End Function

    Public Function CalculaTiempoLaborado()
        Try
            ' Obtiene las fechas seleccionadas de los DateTimePicker
            Dim fechaInicio As DateTime = DTP_FechaIngreso.Value
            Dim fechaFin As DateTime = DTP_FechaSalida.Value

            ' Calcula la diferencia de fechas
            Dim diferencia As TimeSpan = fechaFin - fechaInicio

            ' Calcula los años, meses y días
            Dim años As Integer = diferencia.Days \ 365
            Dim meses As Integer = (diferencia.Days Mod 365) \ 30
            Dim dias As Integer = (diferencia.Days Mod 365) Mod 30

            ' Muestra los resultados en los TextBox correspondientes
            txtb_AnosLaborados.Text = años.ToString()
            txtb_MesesLaborados.Text = meses.ToString()
            txtb_DiasLaborados.Text = dias.ToString()


        Catch ex As Exception

        End Try
    End Function

    Private Sub txtb_Vacaciones_TextChanged(sender As Object, e As EventArgs) Handles txtb_DiasTotalesDeVacacionesGanadas.TextChanged


        If Txb_Cedula.Text <> "" Then
            Try


                Dim SalarioPromedio As Double = ObtieneSalarioBrutoSinDeduccionesPromedioXMesXEmpleado(Txb_Cedula.Text)

                If txtb_DiasTotalesDeVacacionesGanadas.Text <> "" And Txb_Salario.Text <> "" Then
                    Dim MontoVacaciones As Double = CDbl(txtb_DiasTotalesDeVacacionesGanadas.Text) * (SalarioPromedio / 30)
                    txtb_MontoVacacionesGanadas.Text = Obj_Mformat.FormatoMoneda(MontoVacaciones)
                Else
                    txtb_MontoVacacionesGanadas.Text = Obj_Mformat.FormatoMoneda(0)
                End If
            Catch ex As Exception

            End Try
        End If


    End Sub

    Private Sub txtb_VCTotal_TextChanged(sender As Object, e As EventArgs) Handles txtb_DiasTotalesDeVacacionesConsumidas.TextChanged

        If txtb_DiasTotalesDeVacacionesConsumidas.Text <> "" And Txb_Salario.Text <> "" Then
            Dim MontoVacaciones As Double = CDbl(txtb_DiasTotalesDeVacacionesConsumidas.Text) * (CDbl(Txb_Salario.Text) / 30)
            Txtb_MontoVacacionesConsumias.Text = Obj_Mformat.FormatoMoneda(MontoVacaciones)
        Else
            Txtb_MontoVacacionesConsumias.Text = Obj_Mformat.FormatoMoneda(0)
        End If


    End Sub

    Private Sub txtb_DiasTotalesDeVacacionesPendientes_TextChanged(sender As Object, e As EventArgs) Handles txtb_DiasTotalesDeVacacionesPendientes.TextChanged

        If txtb_DiasTotalesDeVacacionesPendientes.Text <> "" And Txb_Salario.Text <> "" Then
            Dim MontoVacaciones As Double = CDbl(txtb_DiasTotalesDeVacacionesPendientes.Text) * (CDbl(Txb_Salario.Text) / 30)
            Txt_MontoVacacionesPendientes.Text = Obj_Mformat.FormatoMoneda(MontoVacaciones)
        Else
            Txt_MontoVacacionesPendientes.Text = Obj_Mformat.FormatoMoneda(0)
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        Dim TapEducacion As Integer = 1
        Dim TapVacaciones As Integer = 2
        Dim TapFacturas As Integer = 3
        Dim TapValesPrestamos As Integer = 4
        Dim TapDeducciones As Integer = 5
        Dim TapIncapacidades As Integer = 6
        Dim TapAumentos As Integer = 7
        Dim TapPlanillas As Integer = 8
        Dim TapDiasAdicionales As Integer = 9
        Dim TapLiquidacion As Integer = 10
        Dim TapAdicionales As Integer = 11



        If (TabControl1.SelectedIndex = TapEducacion) Then
            TapEducacionSeleccionado = True
            CargarEducacion()
        Else
            TapEducacionSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapVacaciones) Then
            TapVacacionesSeleccionado = True
            CargarVacaciones()
        Else
            TapVacacionesSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapFacturas) Then
            TapFacturasSeleccionado = True
            CargarFacturas()
        Else
            TapFacturasSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapValesPrestamos) Then
            TapValesPrestamosSeleccionado = True
            CargarValesPrestamos()
        Else
            TapValesPrestamosSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapDeducciones) Then
            TapDeduccionesSeleccionado = True
            CargarDeducciones()
        Else
            TapDeduccionesSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapIncapacidades) Then
            TapIncapacidadesSeleccionado = True
            CargarIncapacidades()
        Else
            TapIncapacidadesSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapAumentos) Then
            TapAumentosSeleccionado = True
            CargarAumentos()
        Else
            TapAumentosSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapPlanillas) Then
            TapPlanillasSeleccionado = True
            CargaPlanilla()
        Else
            TapPlanillasSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapLiquidacion) Then
            TapLiquidacionSeleccionado = True
            CalculaLiquidacion()
        Else
            TapLiquidacionSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapDiasAdicionales) Then
            TapDiasAdicionalSeleccionado = True
            CargaDiasAdiconales()
        Else
            TapDiasAdicionalSeleccionado = False
        End If

        If (TabControl1.SelectedIndex = TapAdicionales) Then
            TapAdicionalesSeleccionado = True
            CargarAdicionales()
        Else
            TapAdicionalesSeleccionado = False
        End If

    End Sub

    Private Sub DTP_VCFechaFin_Leave(sender As Object, e As EventArgs) Handles DTP_FechaFinVacaciones.Leave
        If (TapVacacionesSeleccionado = True) Then
            Txb_DiasAConsumirVacaciones.Text = CalculaDiasLaboralesEntreFechas(DTP_FechaIniVacaciones.Value, DTP_FechaFinVacaciones.Value)

        End If
    End Sub

    Private Sub DTP_VCFechaIni_Leave(sender As Object, e As EventArgs) Handles DTP_FechaIniVacaciones.Leave
        If (TapVacacionesSeleccionado = True) Then
            Txb_DiasAConsumirVacaciones.Text = CalculaDiasLaboralesEntreFechas(DTP_FechaIniVacaciones.Value, DTP_FechaFinVacaciones.Value)
        End If
    End Sub
#End Region

#Region "FACTURAS"
    Public Function LimpiaFacturas()

        Txtb_TotalFactura.Text = "0"

        DGV_Facturas.DataSource = New DataTable
    End Function
    Public Function CalculaTotalFacturas()

        Dim Total As Double = 0
        For Each row As DataGridViewRow In DGV_Facturas.Rows
            If Trim(row.Cells.Item("Saldo").Value) <> "" Then

                Total = Total + CDbl(Trim(row.Cells.Item("Saldo").Value))
            End If
        Next

        Txtb_TotalFactura.Text = Obj_Mformat.FormatoMoneda(Total)
    End Function
#End Region

#Region "DEDUCCIONES"

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Btn_DeduccionesNuevo.Click
        LimpiaDeducciones()
    End Sub
    Public Function CalculaTotalDeducciones()

        Dim TotalDeducciones As Double = 0
        For Each row As DataGridViewRow In DGV_Deducciones.Rows
            If Trim(row.Cells.Item("Monto").Value) <> "" And Trim(row.Cells.Item("Estado").Value) <> "1" Then

                TotalDeducciones = TotalDeducciones + CDbl(Trim(row.Cells.Item("Monto").Value))
            End If
        Next
        Txtb_TotalDeducciones.Text = Obj_Mformat.FormatoMoneda(TotalDeducciones)
    End Function

    Public Function LimpiaDeducciones()
        CBx_DeduccionesCategoria.Text = ""
        Txb_DeduccionesMonto.Text = "0"
        txtb_PorcentajePrimerQuincena.Text = "0"
        txtb_PorcentajeSegundaQuincena.Text = "0"
        TxtB_DeduccionesDetalle.Text = ""
        DTP_DeduccionesFecha.Value = Now.Date
        Lbl_AnuladoDeducciones.Visible = False
        DGV_Deducciones.DataSource = New DataTable
        Btn_GuardarDeduccion.Text = "Guardar"
        btn_AnularDeduccion.Enabled = True
        Btn_GuardarDeduccion.Enabled = True
        DGV_Deducciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDeducciones(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Dim ConsecutivoDeducciones = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoDeducciones(Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.frmEmpleados.TxtBox_ConsecutivoDeducciones.Text = ConsecutivoDeducciones

        CalculaTotalDeducciones()
    End Function

    Private Function Btn_GuardarDeduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GuardarDeduccion.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        If ValidaPorcentajeDeduccion() = False Then
            MsgBox("La suma de los porcentajes deben dar 100")
            Return False
        End If

        If DTP_DeduccionesFecha.Value < DTP_FechaIngreso.Value Then
            MsgBox("La fecha de la deducción no puede ser menor que la fecha de ingreso.")
            Return False
        End If

        Dim RegistroExiste As Boolean = Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExisteDeduccion(Trim(TxtBox_ConsecutivoDeducciones.Text), Class_VariablesGlobales.SQL_Comman2)
        Dim AccionGuardar As Boolean = True

        If RegistroExiste Then

            If Btn_GuardarDeduccion.Text = "Actualizar" Then
                AccionGuardar = False

            Else
                AccionGuardar = True
                If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaDuplicadoDeduccionFija(Txb_Cedula.Text, CBx_DeduccionesCategoria.Text, Class_VariablesGlobales.SQL_Comman2) Then
                    MsgBox("Dedución ya existe")
                    Return True
                End If
            End If
        End If

        Class_VariablesGlobales.Obj_Funciones_SQL.GuardaDeducciones(TxtBox_ConsecutivoDeducciones.Text, Txb_Cedula.Text, CBx_DeduccionesCategoria.Text, Txb_DeduccionesMonto.Text, TxtB_DeduccionesDetalle.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_DeduccionesFecha.Text), 0, txtb_PorcentajePrimerQuincena.Text, txtb_PorcentajeSegundaQuincena.Text, AccionGuardar, Class_VariablesGlobales.SQL_Comman2)

        LimpiaDeducciones()

        CalculaTotalDeducciones()
        MsgBox("Registro guardado con exito")
    End Function
    Public Function ValidaPorcentajeDeduccion()
        If txtb_PorcentajePrimerQuincena.Text = "" Then

            txtb_PorcentajePrimerQuincena.Text = "0"
            Return False
        End If

        If txtb_PorcentajeSegundaQuincena.Text = "" Then

            txtb_PorcentajeSegundaQuincena.Text = "0"
            Return False
        End If

        Dim PrimerQuincena As Integer = CInt(txtb_PorcentajePrimerQuincena.Text)
        Dim SegundaQuincena As Integer = CInt(txtb_PorcentajeSegundaQuincena.Text)

        If (PrimerQuincena + SegundaQuincena) <> 100 Then
            Return False
        End If
        Return True
    End Function
    Private Sub DGV_Deducciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Deducciones.CellContentClick

        Try


            Class_VariablesGlobales.frmEmpleados.TxtBox_ConsecutivoDeducciones.Text = DGV_Deducciones.CurrentRow.Cells.Item(0).Value.ToString
            Class_VariablesGlobales.frmEmpleados.CBx_DeduccionesCategoria.Text = DGV_Deducciones.CurrentRow.Cells.Item(1).Value.ToString
            Class_VariablesGlobales.frmEmpleados.Txb_DeduccionesMonto.Text = DGV_Deducciones.CurrentRow.Cells.Item(2).Value.ToString
            Class_VariablesGlobales.frmEmpleados.TxtB_DeduccionesDetalle.Text = DGV_Deducciones.CurrentRow.Cells.Item(3).Value.ToString
            Class_VariablesGlobales.frmEmpleados.DTP_DeduccionesFecha.Text = DGV_Deducciones.CurrentRow.Cells.Item(4).Value.ToString
            Class_VariablesGlobales.frmEmpleados.txtb_PorcentajePrimerQuincena.Text = DGV_Deducciones.CurrentRow.Cells.Item(6).Value.ToString
            Class_VariablesGlobales.frmEmpleados.txtb_PorcentajeSegundaQuincena.Text = DGV_Deducciones.CurrentRow.Cells.Item(7).Value.ToString

            If DGV_Deducciones.CurrentRow.Cells.Item(5).Value.ToString = "1" Then
                Lbl_AnuladoDeducciones.Visible = True
                btn_AnularDeduccion.Enabled = False
                Btn_GuardarDeduccion.Enabled = False
            Else
                Lbl_AnuladoDeducciones.Visible = False
                btn_AnularDeduccion.Enabled = True
                Btn_GuardarDeduccion.Enabled = True
            End If

            Btn_GuardarDeduccion.Text = "Actualizar"
        Catch ex As Exception
            MessageBox.Show("$Error DGV_Deducciones_CellContentClick {ex.Message}")


        End Try
    End Sub

    Private Function btn_AnularDeduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AnularDeduccion.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        If Class_VariablesGlobales.Obj_Funciones_SQL.DeduccionesAnular(Trim(Txb_Cedula.Text), Trim(CBx_DeduccionesCategoria.Text), Class_VariablesGlobales.SQL_Comman2) Then
            MsgBox("Dedución anulada con exito")
            LimpiaDeducciones()
        End If
    End Function

#End Region

#Region "INCAPACIDADES"
    Private Function Btn_AnularIncapacidad_Click(sender As Object, e As EventArgs) Handles Btn_AnularIncapacidad.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        If Class_VariablesGlobales.Obj_Funciones_SQL.IncapacidadAnular(Txtb_ConsecutivoIncapacidades.Text, Class_VariablesGlobales.SQL_Comman2) Then
            MsgBox("Incapacidad fue anulado")
            LimpiaIncapacidades()
        End If

    End Function

    Private Function Btn_VerDocIncapacidades_Click(sender As Object, e As EventArgs) Handles Btn_VerDocIncapacidades.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        VisualizarArchivo(FotoDocumentoFirmadoIncapacidades, TxtB_RutaDocIncapacidades.Text)

    End Function

    Private Function Btn_DescargarIncapacidades_Click(sender As Object, e As EventArgs) Handles Btn_DescargarIncapacidades.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        If TxtB_RutaDocIncapacidades.Text.Equals("") Then
            MessageBox.Show("Debe adjuntar un documento para descargar.")
            Return False
        End If
        filePath = TxtB_RutaDocIncapacidades.Text
        ' Obtener la extensión del archivo original
        Dim extension As String = Path.GetExtension(filePath)
        If Not String.IsNullOrEmpty(filePath) Then
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = $"Archivos {extension}|*{extension}|Todos los archivos|*.*"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    File.Copy(filePath, saveFileDialog.FileName, True)
                    MessageBox.Show("Archivo descargado exitosamente.")
                Catch ex As Exception
                    MessageBox.Show("Error al descargar el archivo. " & ex.Message)
                End Try
            End If
        End If
    End Function

    Private Function Btn_AdjuntarIncapacidad_Click(sender As Object, e As EventArgs) Handles Btn_AdjuntarIncapacidad.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        OpenFileDialog1.Filter = "Archivos de Imagen y PDF|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf|Todos los archivos|*.*"
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            filePath = OpenFileDialog1.FileName
            TxtB_RutaDocIncapacidades.Text = filePath
        End If
    End Function

    Private Sub DGV_Incapacidades_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Incapacidades.CellContentClick
        Txtb_ConsecutivoIncapacidades.Text = DGV_Incapacidades.CurrentRow.Cells.Item(0).Value.ToString
        DTP_FechaInicioIncapacidad.Text = DGV_Incapacidades.CurrentRow.Cells.Item(1).Value.ToString
        DTP_FechaFinIncapacidad.Text = DGV_Incapacidades.CurrentRow.Cells.Item(2).Value.ToString
        TxtB_DiasIncapacidad.Text = DGV_Incapacidades.CurrentRow.Cells.Item(3).Value.ToString
        TxtB_NumBoleta.Text = DGV_Incapacidades.CurrentRow.Cells.Item(4).Value.ToString
        Txtb_DetalleIncapacidad.Text = DGV_Incapacidades.CurrentRow.Cells.Item(5).Value.ToString
        CBox_TipoIncapacidad.Text = DGV_Incapacidades.CurrentRow.Cells.Item(8).Value.ToString
        Btn_GuardarIncapacidad.Text = "Actualizar"

        Dim Adjunto As Object = DGV_Incapacidades.CurrentRow.Cells.Item(7).Value

        If Adjunto IsNot DBNull.Value Then
            FotoDocumentoFirmadoIncapacidades = DirectCast(DGV_Incapacidades.CurrentRow.Cells.Item(7).Value, Byte())

            ' Verificar si es un archivo PDF
            If EsArchivoPDF(FotoDocumentoFirmadoIncapacidades) Then
                TxtB_RutaDocIncapacidades.Text = GuardarArchivoTemporal(FotoDocumentoFirmadoIncapacidades, "temp.pdf")
            Else
                TxtB_RutaDocIncapacidades.Text = GuardarArchivoTemporal(FotoDocumentoFirmadoIncapacidades, "temp.png")
            End If

        End If

        If DGV_Incapacidades.CurrentRow.Cells.Item(9).Value.ToString() = "1" Then
            Lbl_AnuladoIncapacidad.Visible = True
            Btn_AnularIncapacidad.Enabled = False
            Btn_GuardarIncapacidad.Enabled = False
            Btn_AdjuntarIncapacidad.Enabled = False
        Else
            Lbl_AnuladoIncapacidad.Visible = False
            Btn_AnularIncapacidad.Enabled = True
            Btn_GuardarIncapacidad.Enabled = True
            Btn_AdjuntarIncapacidad.Enabled = True
        End If

    End Sub

    Private Sub DTP_FechaInicioIncapacidad_Leave_1(sender As Object, e As EventArgs) Handles DTP_FechaInicioIncapacidad.Leave
        TxtB_DiasIncapacidad.Text = CalculaDiasLaboralesEntreFechas(DTP_FechaInicioIncapacidad.Value, DTP_FechaFinIncapacidad.Value)
    End Sub

    Private Sub DTP_FechaFinIncapacidad_Leave(sender As Object, e As EventArgs) Handles DTP_FechaFinIncapacidad.Leave

        TxtB_DiasIncapacidad.Text = CalculaDiasLaboralesEntreFechas(DTP_FechaInicioIncapacidad.Value, DTP_FechaFinIncapacidad.Value)

    End Sub

    Public Function LimpiarDiasAdicionales()
        DTP_FechaDiaAdicional.Value = Now.Date
        Txtb_DiasAdicionalesPorcentaje.Text = "0"
        Txtb_Motivo.Text = "0"
        Lbl_DiasAdicionalAnulado.Visible = False
    End Function

    Public Function LimpiarLiquidacion()
        TxtB_RutaDocLiquidacion.Text = ""
        TxtB_TotalLiquidacion.Text = ""
        TxtBox_SalarioPendiente.Text = ""
        TxtBox_LiquidacionMontoAguinaldo.Text = ""
        TxtBox_MontoCesantia.Text = ""
        TxtBox_PreavisoDias.Text = ""
        TxtBox_PreavisoMonto.Text = ""
        TxtBos_LiquidacionDiasVacaciones.Text = ""
        TxtBos_LiquidacionMontoVacaciones.Text = ""
        TxtBox_SalarioPromedio.Text = ""
        DTP_FechaProyectadaSalida.Value = Now.Date
        CBox_LiquidacionMotivoSalida.Text = ""
    End Function
    Public Function LimpiaIncapacidades()
        Txtb_ConsecutivoIncapacidades.Text = ""
        DTP_FechaInicioIncapacidad.Value = Now.Date
        DTP_FechaFinIncapacidad.Value = Now.Date
        TxtB_DiasIncapacidad.Text = ""
        Txtb_DetalleIncapacidad.Text = ""
        TxtB_NumBoleta.Text = ""
        TxtB_RutaDocIncapacidades.Text = ""
        CBox_TipoIncapacidad.Text = ""
        Btn_GuardarIncapacidad.Text = "Guardar"
        PBox_Incapacidad.Image = Nothing
        DGV_Incapacidades.DataSource = New DataTable
        DGV_Incapacidades.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneIncapacidades(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Dim ConsecutivoIncapacidades = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoIncapacidades(Class_VariablesGlobales.SQL_Comman2)
        Lbl_AnuladoIncapacidad.Visible = False
        Btn_AnularIncapacidad.Enabled = True
        Btn_GuardarIncapacidad.Enabled = True
        Btn_AdjuntarIncapacidad.Enabled = True
        Txtb_ConsecutivoIncapacidades.Text = ConsecutivoIncapacidades
    End Function

    Private Function Btn_GuardarIncapacidad_Click(sender As Object, e As EventArgs) Handles Btn_GuardarIncapacidad.Click
        Try
            TxtB_DiasIncapacidad.Text = CalculaDiasLaboralesEntreFechas(DTP_FechaInicioIncapacidad.Value, DTP_FechaFinIncapacidad.Value)

            If ValidaExistenciaEmpleado() = False Then
                Return False
            End If

            ' Convierte la imagen en un arreglo de bytes
            If TxtB_RutaDocIncapacidades.Text <> "" Then
                FotoDocumentoFirmadoIncapacidades = File.ReadAllBytes(TxtB_RutaDocIncapacidades.Text)
            Else
                MsgBox("Debe seleccionar un documento de incapacidad antes de guardar")
                Return False
            End If

            If DTP_FechaInicioIncapacidad.Value < DTP_FechaIngreso.Value Then
                MsgBox("La fecha de incapacidad no puede ser menor que la fecha de ingreso.")
                Return False
            End If

            If Btn_GuardarIncapacidad.Text = "Guardar" Then
                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaIncapacidad(Txb_Cedula.Text, Txtb_ConsecutivoIncapacidades.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaInicioIncapacidad.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaFinIncapacidad.Value.Date), TxtB_DiasIncapacidad.Text, TxtB_NumBoleta.Text, Txtb_DetalleIncapacidad.Text, FotoDocumentoFirmadoIncapacidades, CBox_TipoIncapacidad.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date), 0, True, Class_VariablesGlobales.SQL_Comman2)
            Else
                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaIncapacidad(Txb_Cedula.Text, Txtb_ConsecutivoIncapacidades.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaInicioIncapacidad.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaFinIncapacidad.Value.Date), TxtB_DiasIncapacidad.Text, TxtB_NumBoleta.Text, Txtb_DetalleIncapacidad.Text, FotoDocumentoFirmadoIncapacidades, CBox_TipoIncapacidad.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date), 0, False, Class_VariablesGlobales.SQL_Comman2)
            End If

            LimpiaIncapacidades()

            MsgBox("Registro guardado con exito")
        Catch ex As Exception

        End Try

    End Function

    Private Sub Btn_NuevoIncapacidad_Click(sender As Object, e As EventArgs) Handles Btn_NuevoIncapacidad.Click
        LimpiaIncapacidades()
    End Sub

#End Region

#Region "ADICIONALES"
    Private Sub Btn_NuevoAdicionales_Click(sender As Object, e As EventArgs) Handles Btn_NuevoAdicionales.Click
        limpiarAdicionales()
    End Sub

    Private Function BtnAnularAdicional_Click(sender As Object, e As EventArgs) Handles BtnAnularAdicional.Click

        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        AnularAdicionales()

    End Function

    Private Sub Btn_GuardarAdicionales_Click(sender As Object, e As EventArgs) Handles Btn_GuardarAdicionales.Click
        GuardarAdicionales()
    End Sub

    Public Function limpiarAdicionales()
        CBox_TipoAdicional.Text = ""
        TxtBox_MontoAdicionales.Text = ""
        Btn_GuardarAdicionales.Text = "Guardar"
    End Function
    Public Function AnularAdicionales()
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        If Class_VariablesGlobales.Obj_Funciones_SQL.IncapacidadAnular(Txtb_ConsecutivoIncapacidades.Text, Class_VariablesGlobales.SQL_Comman2) Then
            MsgBox("Incapacidad fue anulado")
            limpiarAdicionales()
        End If

    End Function
    Public Function GuardarAdicionales()

        Try
            If ValidaExistenciaEmpleado() = False Then
                Return False
            End If

            If Btn_GuardarAdicionales.Text = "Guardar" Then
                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaAdicional(Txb_Cedula.Text, CBox_TipoAdicional.Text, TxtBox_MontoAdicionales.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date), 1, True, Class_VariablesGlobales.SQL_Comman2)
            Else
                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaAdicional(Txb_Cedula.Text, CBox_TipoAdicional.Text, TxtBox_MontoAdicionales.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date), 1, False, Class_VariablesGlobales.SQL_Comman2)
            End If

            limpiarAdicionales()

            MsgBox("Registro guardado con exito")
        Catch ex As Exception

        End Try

    End Function
    Private Sub DGV_Adicionales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Adicionales.CellContentClick
        CBox_TipoAdicional.Text = DGV_Adicionales.CurrentRow.Cells.Item(0).Value.ToString
        TxtBox_MontoAdicionales.Text = DGV_Adicionales.CurrentRow.Cells.Item(1).Value.ToString
        Btn_GuardarAdicionales.Text = "Actualizar"
    End Sub

#End Region

#Region "VALES PRESTAMOS"
    'Private Sub Btn_VerDocValePrestamos_Click(sender As Object, e As EventArgs) Handles Btn_VerDocValePrestamos.Click

    '    If TxtB_RutaDocValePrestamo.Text <> "" Then
    '        Process.Start(TxtB_RutaDocValePrestamo.Text)
    '    Else
    '        MsgBox("No hay ningun documento asociado")
    '    End If

    'End Sub
    'Private Sub Btb_AdjuntarValePrestamo_Click(sender As Object, e As EventArgs) Handles Btb_AdjuntarValePrestamo.Click
    '    OpenFileDialog1.Filter = "Archivos de Imagen y PDF|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf|Todos los archivos|*.*"


    '    If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
    '        'PBox_ValesPrestamos.Image = Image.FromFile(OpenFileDialog1.FileName)

    '        FotoDocumentoFirmadoValesPrestamos = ConvertirImagenABytes(PBox_ValesPrestamos.Image)
    '        Dim tempPath As String = Path.GetTempFileName()
    '        File.WriteAllBytes(tempPath, FotoDocumentoFirmadoValesPrestamos)

    '        TxtB_RutaDocValePrestamo.Text = tempPath

    '        sr.Close()
    '    End If
    'End Sub
    Private filePath As String = ""

    Private Sub Btb_AdjuntarValePrestamo_Click(sender As Object, e As EventArgs) Handles Btb_AdjuntarValePrestamo.Click
        OpenFileDialog1.Filter = "Archivos de Imagen y PDF|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf|Todos los archivos|*.*"
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            filePath = OpenFileDialog1.FileName
            TxtB_RutaDocValePrestamo.Text = filePath
        End If
    End Sub

    Private Sub Btn_Visualizar_Click(sender As Object, e As EventArgs) Handles Btn_VerDocValePrestamos.Click
        VisualizarArchivo(FotoDocumentoFirmadoValesPrestamos, TxtB_RutaDocValePrestamo.Text)
    End Sub

    Private Function Btn_Descargar_Click(sender As Object, e As EventArgs) Handles Btn_DescargarValesPrestamos.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        If TxtB_RutaDocValePrestamo.Text.Equals("") Then
            MessageBox.Show("Debe adjuntar un documento para descargar.")
            Return False
        End If
        filePath = TxtB_RutaDocValePrestamo.Text
        ' Obtener la extensión del archivo original
        Dim extension As String = Path.GetExtension(filePath)
        If Not String.IsNullOrEmpty(filePath) Then
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = $"Archivos {extension}|*{extension}|Todos los archivos|*.*"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    File.Copy(filePath, saveFileDialog.FileName, True)
                    MessageBox.Show("Archivo descargado exitosamente.")
                Catch ex As Exception
                    MessageBox.Show("Error al descargar el archivo. " & ex.Message)
                End Try
            End If
        End If
    End Function

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Btn_AnularValesPrestamos.Click
        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExisteSolicitudValesPrestamos(Trim(txtb_ConsecutivoValePrestamo.Text), Class_VariablesGlobales.SQL_Comman2) Then
            AnularValesPrestamos()
        Else
            MsgBox("Debe crear o seleccionar una solicitud antes de imprimir")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnImprimir_ValesPrestamos.Click
        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExisteSolicitudValesPrestamos(Trim(txtb_ConsecutivoValePrestamo.Text), Class_VariablesGlobales.SQL_Comman2) Then
            ImprimirSolicitudValesPrestamos()
        Else
            MsgBox("Debe crear o seleccionar una solicitud antes de imprimir")
        End If
    End Sub

    Public Function AnularValesPrestamos()
        If Class_VariablesGlobales.Obj_Funciones_SQL.ValesPrestamosAnular(Trim(txtb_ConsecutivoValePrestamo.Text), 1, Class_VariablesGlobales.SQL_Comman2) Then
            MsgBox("Solicitud de vales prestamos fue anulado")
            NuevoValePrestamo()
        End If
    End Function

    Public Function ImprimirSolicitudValesPrestamos()
        Class_VariablesGlobales.Planilla_ConsecutivoSolicitudValesPrestamos = txtb_ConsecutivoValePrestamo.Text
        Class_VariablesGlobales.IMPRIMIENDO = "SolicitudValePrestamo"
        frmReporte.Show()
    End Function

    Private Sub Txtb_Monto_Leave(sender As Object, e As EventArgs) Handles Txtb_MontoValePrestamo.Leave
        Txtb_SaldoValePrestamo.Text = Obj_Mformat.FormatoMoneda(Txtb_MontoValePrestamo.Text)
        Txtb_MontoValePrestamo.Text = Obj_Mformat.FormatoMoneda(Txtb_MontoValePrestamo.Text)
    End Sub

    Private Sub Txtb_Monto_TextChanged(sender As Object, e As EventArgs) Handles Txtb_MontoValePrestamo.TextChanged
        'Funcion para que solo se pueda escribir numeros en el textbox
        If Not IsNumeric(Txtb_MontoValePrestamo.Text) Then
            Txtb_MontoValePrestamo.Text = " "
        End If
    End Sub

    Public Function CalculaTotalValesPrestamos()

        Dim SaldoValesPrestamos As Double = 0
        For Each row As DataGridViewRow In DGV_ValesPrestamos.Rows
            If Trim(row.Cells.Item("Saldo").Value) <> "" And Trim(row.Cells.Item("Estado").Value) <> "1" Then

                SaldoValesPrestamos = SaldoValesPrestamos + CDbl(Trim(row.Cells.Item("Saldo").Value))
            End If
        Next

        TxtB_TotalValesPrestamos.Text = Obj_Mformat.FormatoMoneda(SaldoValesPrestamos)
    End Function

    Private Sub Btn_NuevoValePrestamo_Click(sender As Object, e As EventArgs) Handles Btn_NuevoValePrestamo.Click
        NuevoValePrestamo()
    End Sub

    Private Sub DGV_ValesPrestamos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ValesPrestamos.CellContentClick
        Panel_AdjuntosValesPrestamos.Visible = True
        txtb_ConsecutivoValePrestamo.Enabled = False
        DTP_FechaValePrestamo.Enabled = True
        Txtb_MontoValePrestamo.Enabled = True
        Txtb_SaldoValePrestamo.Enabled = True
        CBox_TipoValePrestamo.Enabled = True
        Txtb_DetalleValePrestamo.Enabled = True
        Btn_AnularValesPrestamos.Enabled = True
        btn_GuardarValePrestamo.Enabled = True


        txtb_ConsecutivoValePrestamo.Text = DGV_ValesPrestamos.CurrentRow.Cells.Item(0).Value.ToString
        DTP_FechaValePrestamo.Text = DGV_ValesPrestamos.CurrentRow.Cells.Item(1).Value.ToString
        Txtb_MontoValePrestamo.Text = DGV_ValesPrestamos.CurrentRow.Cells.Item(2).Value.ToString
        Txtb_SaldoValePrestamo.Text = DGV_ValesPrestamos.CurrentRow.Cells.Item(3).Value.ToString
        CBox_TipoValePrestamo.Text = DGV_ValesPrestamos.CurrentRow.Cells.Item(4).Value.ToString
        Txtb_DetalleValePrestamo.Text = DGV_ValesPrestamos.CurrentRow.Cells.Item(5).Value.ToString

        'Evita que el monto cambia si ya empezo a realizar pagos
        If Txtb_SaldoValePrestamo.Text <> Txtb_MontoValePrestamo.Text Then
            Txtb_MontoValePrestamo.Enabled = False
        Else
            Txtb_MontoValePrestamo.Enabled = True

        End If

        Dim Adjunto As Object = DGV_ValesPrestamos.CurrentRow.Cells.Item(6).Value
        Txtb_AbonoQuincenal.Text = DGV_ValesPrestamos.CurrentRow.Cells.Item(8).Value.ToString()
        If Adjunto IsNot DBNull.Value Then
            FotoDocumentoFirmadoValesPrestamos = DirectCast(DGV_ValesPrestamos.CurrentRow.Cells.Item(6).Value, Byte())

            ' Verificar si es un archivo PDF
            If EsArchivoPDF(FotoDocumentoFirmadoValesPrestamos) Then
                TxtB_RutaDocValePrestamo.Text = GuardarArchivoTemporal(FotoDocumentoFirmadoValesPrestamos, "temp.pdf")
            Else
                TxtB_RutaDocValePrestamo.Text = GuardarArchivoTemporal(FotoDocumentoFirmadoValesPrestamos, "temp.png")
            End If

        End If

        If DGV_ValesPrestamos.CurrentRow.Cells.Item(7).Value = "1" Then
            Lbl_AnuladoValesPrestamos.Text = "ANULADO"
            Lbl_AnuladoValesPrestamos.ForeColor = Color.Red
            Lbl_AnuladoValesPrestamos.Visible = True
            Btn_AnularValesPrestamos.Enabled = False
            btn_GuardarValePrestamo.Enabled = False
            Btb_AdjuntarValePrestamo.Enabled = False

        ElseIf DGV_ValesPrestamos.CurrentRow.Cells.Item(7).Value = "2" Then
            Lbl_AnuladoValesPrestamos.Text = "CANCELADO"
            Lbl_AnuladoValesPrestamos.ForeColor = Color.Green
            Lbl_AnuladoValesPrestamos.Visible = True
            Btn_AnularValesPrestamos.Enabled = False
            btn_GuardarValePrestamo.Enabled = False
            Btb_AdjuntarValePrestamo.Enabled = False

        Else
            Lbl_AnuladoValesPrestamos.Visible = False
            Btn_AnularValesPrestamos.Enabled = True
            btn_GuardarValePrestamo.Enabled = True
        End If

    End Sub

    Private Function btn_GuardarValePrestamo_Click(sender As Object, e As EventArgs) Handles btn_GuardarValePrestamo.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        If TxtBox_CuentaContable.Text = "" Then
            MsgBox("El empleado no tiene cuenta contable " & vbCrLf & " solicite la cuenta contable al contador")
            Return False
        End If
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        If ValidaCamposValesPrestamos() Then
            GuardaValesPrestamos()

            NuevoValePrestamo()

            MsgBox("Registro guardado correctamente")

        End If
    End Function

    Public Function LimpiaValesPrestamos()
        Panel_AdjuntosValesPrestamos.Visible = False
        txtb_ConsecutivoValePrestamo.Text = ""
        TxtB_RutaDocValePrestamo.Text = ""
        DTP_FechaValePrestamo.Value = Now.Date
        Txtb_MontoValePrestamo.Text = ""
        Txtb_SaldoValePrestamo.Text = ""
        Txtb_AbonoQuincenal.Text = ""
        CBox_TipoValePrestamo.Text = ""
        Txtb_DetalleValePrestamo.Text = ""
        PBox_ValesPrestamos.Image = Nothing
        DGV_ValesPrestamos.DataSource = New DataTable
        Btn_AnularValesPrestamos.Enabled = True
        btn_GuardarValePrestamo.Enabled = True
        Lbl_AnuladoValesPrestamos.Visible = False
        Txtb_MontoValePrestamo.Enabled = True
    End Function

    Public Function NuevoValePrestamo()
        LimpiaValesPrestamos()

        DGV_ValesPrestamos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneValesPrestamos(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Dim ConsecutivoValesPrestamos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoValesPrestamos(Class_VariablesGlobales.SQL_Comman2)

        txtb_ConsecutivoValePrestamo.Text = ConsecutivoValesPrestamos
        CalculaTotalValesPrestamos()
    End Function

    Public Function GuardaValesPrestamos()
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        ' Convierte la imagen en un arreglo de bytes
        If TxtB_RutaDocValePrestamo.Text <> "" Then
            FotoDocumentoFirmadoValesPrestamos = File.ReadAllBytes(TxtB_RutaDocValePrestamo.Text)
        End If

        Dim RegistroExiste As Boolean = Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExisteSolicitudValesPrestamos(Trim(txtb_ConsecutivoValePrestamo.Text), Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.Obj_Funciones_SQL.GuardaValesPrestamos(Trim(txtb_ConsecutivoValePrestamo.Text), Trim(Txb_Cedula.Text), Trim(Txb_Nombre.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date), Txtb_MontoValePrestamo.Text, Txtb_SaldoValePrestamo.Text, CBox_TipoValePrestamo.Text, Txtb_DetalleValePrestamo.Text, Trim(Txtb_AbonoQuincenal.Text), FotoDocumentoFirmadoValesPrestamos, 0, RegistroExiste, Class_VariablesGlobales.SQL_Comman2)

    End Function

    Public Function ValidaCamposValesPrestamos()
        If Trim(Txb_Cedula.Text) = "" Then
            MsgBox("Debe seleccinar un empleado")
            Return False
        End If

        If Trim(CBox_TipoValePrestamo.Text) = "" Then
            MsgBox("Debe indicar si es vale o prestamo un empleado")
            Return False
        End If

        If Trim(Txtb_MontoValePrestamo.Text) = "" Or Trim(Txtb_MontoValePrestamo.Text) = "0" Then
            MsgBox("Debe indicar el monto")
            Return False
        End If

        If DTP_FechaValePrestamo.Value < DTP_FechaIngreso.Value Then
            MsgBox("La fecha del vale no puede ser menor que la fecha de ingreso.")
            Return False
        End If
        Return True
    End Function

#End Region

#Region "AUMENTOS"
    Private Sub DGV_Aumentos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Aumentos.CellContentClick
        Btn_GuardarAumento.Enabled = False
        TBox_PorcentajeAumentos.Enabled = False
        '[Fecha],[PorcentajeAumento],[SalarioAnterior],[SalarioPosterior],[MontoAumento] 
        DTP_FechaAumentos.Text = DGV_Aumentos.CurrentRow.Cells.Item(0).Value.ToString()
        TBox_PorcentajeAumentos.Text = DGV_Aumentos.CurrentRow.Cells.Item(1).Value.ToString()
        TxtB_SalarioAnteriorAumento.Text = Obj_Mformat.FormatoMoneda(DGV_Aumentos.CurrentRow.Cells.Item(2).Value.ToString())
        TxtB_SalarioPosteriorAumento.Text = Obj_Mformat.FormatoMoneda(DGV_Aumentos.CurrentRow.Cells.Item(3).Value.ToString())
        TxtB_MontoAumento.Text = Obj_Mformat.FormatoMoneda(DGV_Aumentos.CurrentRow.Cells.Item(4).Value.ToString())
        TxtBox_MotivoAumento.Text = DGV_Aumentos.CurrentRow.Cells.Item(5).Value.ToString()


    End Sub
    Private Sub Btn_NuevoAumento_Click(sender As Object, e As EventArgs) Handles Btn_NuevoAumento.Click
        LimpiaAumento()
    End Sub
    Private Function Btn_GuardarAumento_Click(sender As Object, e As EventArgs) Handles Btn_GuardarAumento.Click

        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        If DTP_FechaAumentos.Value < DTP_FechaIngreso.Value Then
            MsgBox("La fecha del aumento no puede ser menor que la fecha de ingreso.")
            Return False
        End If

        If TxtB_SalarioPosteriorAumento.Text <> 0 Then
            Txb_Salario.Text = TxtB_SalarioPosteriorAumento.Text
        End If

        Dim Cedula_Empleado As String
        Dim SalarioAnterior As Double
        Dim SalarioPosterior As Double
        Dim Fecha As String
        Dim PorcentajeAumento As Double
        Dim MontoAumento As Double
        Dim MotivoAumento As String

        Cedula_Empleado = Trim(Txb_Cedula.Text)
        SalarioAnterior = CDbl(TxtB_SalarioAnteriorAumento.Text)
        SalarioPosterior = CDbl(TxtB_SalarioPosteriorAumento.Text)
        Fecha = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date.ToShortDateString())
        PorcentajeAumento = TBox_PorcentajeAumentos.Text
        MontoAumento = CDbl(TxtB_MontoAumento.Text)
        MotivoAumento = TxtBox_MotivoAumento.Text

        Class_VariablesGlobales.Obj_Funciones_SQL.RegistraActualizaSalarioEmpleado(Cedula_Empleado,
                                                                                                       SalarioAnterior,
                                                                                                       SalarioPosterior,
                                                                                                       Fecha,
                                                                                                       PorcentajeAumento,
                                                                                                       MontoAumento,
                                                                                                       MotivoAumento,
                                                                                                       Class_VariablesGlobales.Log_Usuario,
                                                                                                       Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaSalarioEmpleado(Trim(Txb_Cedula.Text), CDbl(Txb_Salario.Text), Class_VariablesGlobales.SQL_Comman2)

        LimpiaAumento()
    End Function

    Public Function LimpiaAumento()
        Btn_GuardarAumento.Enabled = True
        TBox_PorcentajeAumentos.Enabled = True
        DTP_FechaAumentos.Value = Now.Date
        TBox_PorcentajeAumentos.Text = "0"
        TxtB_MontoAumento.Text = "0"
        TxtB_SalarioAnteriorAumento.Text = "0"
        TxtB_SalarioPosteriorAumento.Text = "0"
        TxtBox_MotivoAumento.Text = ""

        DGV_Aumentos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAumentos(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)

    End Function

    Public Function LimpiaAquinaldo()
        Class_VariablesGlobales.frmEmpleados.CalculaAguinaldo()
    End Function
#End Region

#Region "ACCIONES GENERALES"
    Private Function Btn_Informe_Click(sender As Object, e As EventArgs) Handles Btn_Informe.Click

        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        ImprimirExpedienteEmpleado()

    End Function
    Public Function ImprimirExpedienteEmpleado()
        Class_VariablesGlobales.Planilla_CedulaEmpleado = Txb_Cedula.Text
        Class_VariablesGlobales.Planilla_CardCode = Txb_CodigoCliente.Text
        Class_VariablesGlobales.IMPRIMIENDO = "Expediente"
        frmReporte.Show()
    End Function

    Private Sub DTP_FechaIngreso_ValueChanged(sender As Object, e As EventArgs) Handles DTP_FechaIngreso.ValueChanged
        CalculaTiempoLaborado()
    End Sub

    Private Sub DTP_FechaSalida_ValueChanged(sender As Object, e As EventArgs) Handles DTP_FechaSalida.ValueChanged
        CalculaTiempoLaborado()
    End Sub

    Public Function LimpiarInfoEmpleado()
        Try
            initializing = True
            DTP_FechaIngreso.ResetText()
            DTP_FechaSalida.ResetText()
            DTGV_Educacion.DataSource = New DataTable
            TabControl1.Enabled = True
            DTP_FechaIngreso.Enabled = True

            Txt_Id.Text = "0"
            Txb_Cedula.Text = ""
            Txb_Nombre.Text = ""
            CBox_Puesto.Text = ""
            Txb_Telefono1.Text = ""
            Txb_Telefono2.Text = ""
            Txb_RutaImagen.Text = ""
            txtb_Correo.Text = ""
            TxtCuentaBancaria.Text = ""
            TxtIdColaboradorBanco.Text = ""
            TxtBox_CuentaContable.Text = ""
            CmboBox_CategoriaEmpeado.Text = ""
            Txb_CodigoCliente.Text = ""
            Txb_Salario.Text = "0"



            ChkB_Activo.Checked = True
            Btn_Guardar.Text = "Guardar"



            PicBox_FotoEmpleado.Image = My.Resources.SinFoto

            CambiaVisibilidadEmpleadoAnulado(True, 0)
        Catch ex As Exception

        End Try
    End Function

    Public Function CalculaTaps()
        LimpiaExperiencia()
        LimpiaEducacion()
        LimpiarVacaciones()
        LimpiaFacturas()
        LimpiaValesPrestamos()
        LimpiaDeducciones()
        LimpiaIncapacidades()
        LimpiarDiasAdicionales()
        LimpiaAumento()
        LimpiarLiquidacion()
        LimpiaAquinaldo() '

        'Class_VariablesGlobales.frmEmpleados.CargarExperienciaLabora()
        'Class_VariablesGlobales.frmEmpleados.CargarEducacion()
        'Class_VariablesGlobales.frmEmpleados.CargarVacaciones()
        'Class_VariablesGlobales.frmEmpleados.CargarFacturas()
        'Class_VariablesGlobales.frmEmpleados.CargarValesPrestamos()
        'Class_VariablesGlobales.frmEmpleados.CargarDeducciones()
        'Class_VariablesGlobales.frmEmpleados.CargarIncapacidades()
        'Class_VariablesGlobales.frmEmpleados.CargarAdicionales()
        'Class_VariablesGlobales.frmEmpleados.CargarAumentos()
        'Class_VariablesGlobales.frmEmpleados.CargarAportesPatronales()
        'Class_VariablesGlobales.frmEmpleados.CargarLiquidacion()
        'Class_VariablesGlobales.frmEmpleados.CargarAguinaldo()
    End Function


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscarEmpleado.Click

        Class_VariablesGlobales.Obj_List_Empleados = New Planilla_List_Empleados
        Class_VariablesGlobales.Obj_List_Empleados.LlamadoDesde = "PlanillaEmpleados"
        Class_VariablesGlobales.Obj_List_Empleados.MdiParent = Principal
        Class_VariablesGlobales.Obj_List_Empleados.Show()

    End Sub

    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click
        initializing = False
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
        initializing = True
    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        initializing = False
        If Txt_Id.Text = "" Then
            Txt_Id.Text = "0"
        End If
        Btn_Atras.Enabled = True

        Dim Empleado As New DataTable
        Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.NavegaEmpleados(CInt(Txt_Id.Text) + 1, Class_VariablesGlobales.SQL_Comman2)
        Obj_List_Empleados.Navegar(Empleado)
        initializing = True
    End Sub

    Private Sub CBox_Puesto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBox_Puesto.SelectedIndexChanged
        If CBox_Puesto.Text = "AGENTE" Then
            Txtb_CodRuta.Enabled = True

        Else
            Txtb_CodRuta.Enabled = False
            Txtb_CodRuta.Text = "0"
        End If
    End Sub

#End Region

#Region "LIQUIDACION"

    Private Function Btn_AdjuntarLiquidacion_Click(sender As Object, e As EventArgs) Handles Btn_AdjuntarLiquidacion.Click

        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        OpenFileDialog1.Filter = "Archivos de Imagen y PDF|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf|Todos los archivos|*.*"
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            filePath = OpenFileDialog1.FileName
            TxtB_RutaDocLiquidacion.Text = filePath


            ' Convierte la imagen en un arreglo de bytes
            If TxtB_RutaDocLiquidacion.Text <> "" Then
                FotoDocumentoFirmadoLiquidacion = File.ReadAllBytes(TxtB_RutaDocLiquidacion.Text)
            Else
                FotoDocumentoFirmadoLiquidacion = Nothing
                'MsgBox("Debe seleccionar un documento de liquidacion firmado  ")
            End If

            'Actualiza el adjunto en la planilla
            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaLiquidacion(CBox_LiquidacionMotivoSalida.Text, Trim(Txb_Cedula.Text), Trim(TxtBox_PreavisoMonto.Text), TxtBox_MontoCesantia.Text, TxtBox_LiquidacionMontoAguinaldo.Text, TxtBos_LiquidacionMontoVacaciones.Text, FotoDocumentoFirmadoLiquidacion, True, Class_VariablesGlobales.SQL_Comman2)

            MessageBox.Show("El adjunto se ha guardado con éxito")
        End If



    End Function
    Private Function Btn_VerAdjuntoLiquidacion_Click(sender As Object, e As EventArgs) Handles Btn_VerAdjuntoLiquidacion.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        VisualizarArchivo(FotoDocumentoFirmadoLiquidacion, TxtB_RutaDocLiquidacion.Text)
    End Function

    ''' <summary>
    ''' Esta opcion hace que el empleado deje de registrar dias laborados en caso de renuncar el dia de hoy
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Function btnCerrarEmpleado_Click(sender As Object, e As EventArgs) Handles btnCerrarEmpleado.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If

        If CBox_LiquidacionMotivoSalida.Text = "" Then
            MsgBox("Debe indicar el motivo de salida")
            Return False
        End If

        If DTP_FechaProyectadaSalida.Value < DTP_FechaIngreso.Value Then
            MsgBox("La fecha de la salida del empleado no puede ser menor que la fecha de ingreso.")
            Return False
        End If
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea dar por cerrado al empleado? Si cierra al empleado, no podrá revertir el movimiento e iniciará el proceso de liquidación laboral del empleado.",
                          "Alerta",
                          MessageBoxButtons.YesNo)

        ' Verificar la respuesta del usuario
        If result = DialogResult.No Then
            Return True
        End If

        'Se cambia el estado del empleado
        Class_VariablesGlobales.Obj_Funciones_SQL.CerrarEmpleado(Trim(Txb_Cedula.Text), 2, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaProyectadaSalida.Value.Date), Class_VariablesGlobales.SQL_Comman2)
        MessageBox.Show("El empleado se cerro con exito")

        Dim Empleado As New DataTable
        Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.NavegaEmpleados(CInt(Txt_Id.Text), Class_VariablesGlobales.SQL_Comman2)
        Obj_List_Empleados.Navegar(Empleado)
    End Function
    Function ValidarFechaSalida(ByVal fechaSalida As Date) As Boolean
        ' Obtener la fecha actual
        Dim fechaActual As Date = Date.Today

        ' Obtener el día del mes de la fecha de salida
        Dim diaSalida As Integer = fechaSalida.Day

        ' Obtener el último día del mes de la fecha de salida
        Dim ultimoDiaMesSalida As Date = New Date(fechaSalida.Year, fechaSalida.Month, Date.DaysInMonth(fechaSalida.Year, fechaSalida.Month))

        ' Verificar si la fecha de salida es menor a 15
        If diaSalida < 15 Or fechaActual < ultimoDiaMesSalida Then
            MsgBox("Debe esperar a que se realice el pago de la quincena antes de salir.", MsgBoxStyle.Information, "Mensaje")
            Return False
        End If

        ' Si ninguna de las condiciones anteriores se cumple, la fecha de salida es válida
        Return True
    End Function

    ''' <summary>
    ''' Ejecuta la liquidacion total del empleado ya con el pago del salario pendiente realizado mediante la planilla por ende todos los calculos esta completados
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Private Function Btn_GuardarLiquidacion_Click(sender As Object, e As EventArgs) Handles Btn_GuardarLiquidacion.Click
        Try

            If ValidaExistenciaEmpleado() = False Then
                Return False
            End If

            If CBox_LiquidacionMotivoSalida.Text = "" Then
                MsgBox("Debe indicar el motivo de salida")
                Return False
            End If

            If DTP_FechaProyectadaSalida.Value < DTP_FechaIngreso.Value Then
                MsgBox("La fecha de la salida del empleado no puede ser menor que la fecha de ingreso.")
                Return False
            End If

            If Not ValidarFechaSalida(DTP_FechaProyectadaSalida.Value) Then
                Return False
            End If

            Dim result As DialogResult = MessageBox.Show("Si guarda la liquidacion indica que el empleado sale de la empresa, esto bloqueara al empleado , Esta seguro que desea guardar la liquidacion?",
                              "Alerta",
                              MessageBoxButtons.YesNo)

            If result = DialogResult.No Then
                Return True
            End If

            ' Convierte la imagen en un arreglo de bytes
            If TxtB_RutaDocLiquidacion.Text <> "" Then
                FotoDocumentoFirmadoLiquidacion = File.ReadAllBytes(TxtB_RutaDocLiquidacion.Text)
            Else
                FotoDocumentoFirmadoLiquidacion = Nothing
                'MsgBox("Debe seleccionar un documento de liquidacion firmado  ")
            End If

            Dim cesantia As Double
            Dim Aguinaldo As Double
            Dim Vacaciones As Double

            If TxtBox_MontoCesantia.Text <> "" Then
                cesantia = CDbl(TxtBox_MontoCesantia.Text)
            End If
            If TxtBox_LiquidacionMontoAguinaldo.Text <> "" Then
                Aguinaldo = CDbl(TxtBox_LiquidacionMontoAguinaldo.Text)
            End If
            If TxtBos_LiquidacionMontoVacaciones.Text <> "" Then
                Vacaciones = CDbl(TxtBos_LiquidacionMontoVacaciones.Text)
            End If

            Dim Guardar As Boolean = Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExisteLiquidacion(Trim(Txb_Cedula.Text), Class_VariablesGlobales.SQL_Comman2)
            If Guardar = True Then
                If TxtB_RutaDocLiquidacion.Text = "" Then
                    MessageBox.Show("Debe imprimir y adjuntar el documento de la liquidacion firmado")
                    Return False
                End If

            End If

            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaLiquidacion(CBox_LiquidacionMotivoSalida.Text, Trim(Txb_Cedula.Text), Trim(TxtBox_PreavisoMonto.Text), TxtBox_MontoCesantia.Text, TxtBox_LiquidacionMontoAguinaldo.Text, TxtBos_LiquidacionMontoVacaciones.Text, FotoDocumentoFirmadoLiquidacion, Guardar, Class_VariablesGlobales.SQL_Comman2)

            'Se cambia el estado del empleado
            Class_VariablesGlobales.Obj_Funciones_SQL.CambiaEstadoALiquidadoEmpleado(Trim(Txb_Cedula.Text), 3, Class_VariablesGlobales.SQL_Comman2)

            MessageBox.Show("Liquidacion Guardada")
            Dim Empleado As New DataTable
            Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.NavegaEmpleados(CInt(Txt_Id.Text), Class_VariablesGlobales.SQL_Comman2)
            Obj_List_Empleados.Navegar(Empleado)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Function CalculaLiquidacion()
        Try
            If Txb_Cedula.Text = "" Then
                Return False
            End If


            CargaLiquidacionGuardada()
            CalculaPreaviso()
            CalculaCesantia()
            CalculaAguinaldo()
            CalculaVacaciones()
            CalculaSalarioPendiente()

            Dim MontoVacaciones As Double = 0
            Dim MontoPreaviso As Double = 0
            Dim MontoCesantia As Double = 0
            Dim MontoSalariosPendientes As Double = 0
            Dim MontoAguinaldo As Double = 0

            If TxtBos_LiquidacionMontoVacaciones.Text <> "" Then
                MontoVacaciones = CDbl(TxtBos_LiquidacionMontoVacaciones.Text)
            End If

            If TxtBox_PreavisoMonto.Text <> "" And CBox_LiquidacionMotivoSalida.Text <> "Despido" And CBox_LiquidacionMotivoSalida.Text <> "Despido sin Responsabilidad Patronal" Then
                MontoPreaviso = CDbl(TxtBox_PreavisoMonto.Text)
            End If

            If TxtBox_MontoCesantia.Text <> "" And CBox_LiquidacionMotivoSalida.Text <> "Despido" And CBox_LiquidacionMotivoSalida.Text <> "Despido sin Responsabilidad Patronal" Then
                MontoCesantia = CDbl(TxtBox_MontoCesantia.Text)
            End If

            If TxtBox_SalarioPendiente.Text <> "" Then
                MontoSalariosPendientes = CDbl(TxtBox_SalarioPendiente.Text)
            End If

            If TxtBox_LiquidacionMontoAguinaldo.Text <> "" Then
                MontoAguinaldo = CDbl(TxtBox_LiquidacionMontoAguinaldo.Text)
            End If

            TxtB_TotalLiquidacion.Text = Obj_Mformat.FormatoMoneda(MontoVacaciones + MontoPreaviso + MontoCesantia + MontoSalariosPendientes + MontoAguinaldo)


        Catch ex As Exception
            MsgBox("Error al calcular liquidacion [" & ex.Message & "]")
        End Try

    End Function

    Public Shared Function CalcularDiasLaboralesRestantesEnMesSegunFechaLimite(FechaProyectadaSalida As DateTime) As Integer
        Dim fechaActual As DateTime = DateTime.Today
        Dim ultimoDiaDelMes As Integer = FechaProyectadaSalida.Day
        Dim diasLaboralesRestantes As Integer = 1

        For dia As Integer = fechaActual.Day + 1 To ultimoDiaDelMes
            Dim fechaActualizada As DateTime = New DateTime(fechaActual.Year, fechaActual.Month, dia)

            ' Verificar si el día es sábado o domingo (fines de semana)
            'If fechaActualizada.DayOfWeek Then
            diasLaboralesRestantes += 1
            'End If
        Next

        Return diasLaboralesRestantes
    End Function
    Public Function ObtieneDiasTrabajadosxMesXEmpleado()
        Try
            Return Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDiasTrabajadosxMesXEmpleado(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Catch ex As Exception
        End Try
    End Function
    Public Function ObtieneSalarioBrutoSinDeduccionesPromedioXMesXEmpleado()
        Try
            Return Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneSalarioBrutoSinDeduccionesPromedioXMesXEmpleado(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function ObtenerFechaInicioMesActual() As DateTime
        Dim fechaActual As DateTime = DateTime.Today
        Dim fechaInicioMesActual As DateTime = New DateTime(fechaActual.Year, fechaActual.Month, 1)
        Return fechaInicioMesActual
    End Function
    Public Function CalculaSalarioPendiente()
        Try
            Dim DiasXTerminarMesEnCurso As Integer = 0

            Dim SalarioXDia As Double = 0

            DiasXTerminarMesEnCurso = CalcularDiasLaboralesRestantesEnMesSegunFechaLimite(DTP_FechaProyectadaSalida.Value)

            If Txb_SalarioDiario.Text <> "" Then
                SalarioXDia = CDbl(Txb_SalarioDiario.Text)
            End If

            TxtBox_SalarioPendiente.Text = Obj_Mformat.FormatoMoneda(DiasXTerminarMesEnCurso * SalarioXDia)

        Catch ex As Exception

        End Try
    End Function
    Public Function CalculaCesantia() As Decimal
        Try
            'Determina el tiempo de servicio: Calcula el número de meses completos que has trabajado para el empleador, 
            'desde el inicio hasta el final de tu relación laboral. No se cuentan los días, solo los meses completos.

            'Obtén el salario promedio: Suma los salarios mensuales recibidos durante los últimos 12 meses de trabajo y divide el resultado entre 12. 
            'Esto te dará el salario promedio mensual.

            'Calcula la cesantía: La cesantía equivale a una doceava parte (1/12) del salario promedio por cada mes completo de trabajo. 
            'Si tienes 3 meses completos o más, se cuenta como un mes completo. 
            'Si tienes menos de 3 meses completos, no se considera para el cálculo.Cesantía = (Salario promedio mensual) x (Meses completos trabajados)
            Dim MontoCesantia As Double = 0

            ' Verificar si se ha seleccionado una opción en el ComboBox
            If CBox_LiquidacionMotivoSalida.SelectedIndex <> -1 Then ' Se ha seleccionado una opción
                ' Obtener el índice seleccionado
                Dim indiceSeleccionado As Integer = CBox_LiquidacionMotivoSalida.SelectedIndex

                ' Validar el índice seleccionado
                If indiceSeleccionado <> 1 And indiceSeleccionado <> 2 Then ' Índice de la opción deseada
                    MontoCesantia = Class_VariablesGlobales.Obj_Funciones_SQL.CalcularCesantia(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
                End If
            ElseIf lbl_EstadoCerrado.Visible = True Then
                ' No se ha seleccionado ninguna opción
                ' Realiza aquí otras acciones o muestra un mensaje de advertencia
                MsgBox("Debe seleccionar una opción de salida del empleado.")
            End If


            TxtBox_MontoCesantia.Text = Obj_Mformat.FormatoMoneda(MontoCesantia)

        Catch ex As Exception
            MsgBox("Error al calcular Cesantia [" & ex.Message & "]")

        End Try
    End Function
    Public Function CalculaAguinaldo()

        'TODO. SE BUSCA USAR UN SP PARA HACER EL CALCULO DEL AGUINALDO
        'PARA HACER ESTE CALCULO SE DEBE TENER ALGUN METODO PARA SABER SI YA SE PAGO EL AGUINALDO
        'PARA CALCULARLO SE DEBE CONTEMPLAR LA SUMA DE LOS AGUINALDOS DE CADA PLANILLA SIN CONTEMPLAR LOS YA CANCELADOS
        'SE DEBE TENER ALGUN CONTROL HE HISTORICO DE LOS AGUINALDOS PAGADOS NO EL QUE SE CALCULA POR CADA PLANILLA SI NO EL QUE SE DA A FIN DE AÑO
        'EN EL SEGMENTO DE LIQUIDAR DEBE APARECER EL MONTO DEL AGUINALDO HASTA LA FECHA QUE NO A SIDO CANCELADO

        Dim MontoAguinaldo As Double = 0
        MontoAguinaldo = Class_VariablesGlobales.Obj_Funciones_SQL.CalcularAguinaldo(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        TxtBox_LiquidacionMontoAguinaldo.Text = Obj_Mformat.FormatoMoneda(MontoAguinaldo)

    End Function

    Public Function CargaLiquidacionGuardada()

        Dim TablLiquidacion As DataTable = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidacionLaboral(Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
        If TablLiquidacion IsNot Nothing Then
            If TablLiquidacion.Rows.Count > 0 Then
                CBox_LiquidacionMotivoSalida.Text = TablLiquidacion.Rows(0).Item("MotivoSalida")
                DTP_FechaProyectadaSalida.Text = DTP_FechaSalida.Value
            End If
        End If

    End Function
    Public Function CalculaPreaviso()
        Try

            If ChkBox_Preaviso.Checked Then

                Dim SalarioPromedio As Double = ObtieneSalarioBrutoSinDeduccionesPromedioXMesXEmpleado()
                If SalarioPromedio = 0 Then
                    SalarioPromedio = Txb_Salario.Text.Trim()
                End If

                Dim DiasPreaviso As Integer = 0
                DiasPreaviso = CalcularDiasPreaviso(DTP_FechaIngreso.Value, DTP_FechaSalida.Value)
                TxtBox_SalarioPromedio.Text = Obj_Mformat.FormatoMoneda(SalarioPromedio)
                TxtBox_PreavisoDias.Text = DiasPreaviso
                TxtBox_PreavisoMonto.Text = Obj_Mformat.FormatoMoneda((SalarioPromedio / 30) * DiasPreaviso)

            Else
                TxtBox_PreavisoDias.Text = 0
                TxtBox_PreavisoMonto.Text = 0
            End If
        Catch ex As Exception
            MsgBox("Error al calcular Preaviso [" & ex.Message & "]")
        End Try
    End Function

    ' Método para calcular los días de preaviso entre dos fechas
    Public Shared Function CalcularDiasPreaviso(fechaInicio As Date, fechaFin As Date) As Double
        ' Calcular el tiempo en años entre las dos fechas
        Dim tiempo As Double = DateDiff(DateInterval.Year, fechaInicio, fechaFin)

        ' Determinar los días de preaviso según el tiempo en años
        Select Case tiempo
            Case 0 To 0.25
                Return 0
            Case 0.25 To 0.5
                Return 7
            Case 0.5 To 1
                Return 15
            Case 1 To 1.5
                Return 30
            Case 1.5 To 2.5
                Return 30
            Case 2.5 To 3.5
                Return 30
            Case 3.5 To 4.5
                Return 30
            Case 4.5 To 5.5
                Return 30
            Case 5.5 To 6.5
                Return 30
            Case 6.5 To 7.5
                Return 30
            Case Else
                Return 30 ' Para años mayores a 7.5, se aplican 30 días de preaviso
        End Select
    End Function

    Private Sub ChkBox_Preaviso_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBox_Preaviso.CheckedChanged
        If TapLiquidacionSeleccionado = True Then

            CalculaLiquidacion()

        End If
    End Sub

    Private Sub Txb_Salario_TextChanged(sender As Object, e As EventArgs) Handles Txb_Salario.TextChanged
        Try
            If Txb_Salario.Text <> "" Then
                Txb_SalarioQuincenal.Text = Obj_Mformat.FormatoMoneda(CDbl(Txb_Salario.Text) / 2)
                Txb_SalarioDiario.Text = Obj_Mformat.FormatoMoneda(CDbl(Txb_Salario.Text) / 30)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DTP_FechaProyectadaSalida_ValueChanged(sender As Object, e As EventArgs) Handles DTP_FechaProyectadaSalida.ValueChanged
        If TapLiquidacionSeleccionado Then
            CargarLiquidacion()
        End If
    End Sub

    Private Sub Txb_DeduccionesMonto_Leave(sender As Object, e As EventArgs) Handles Txb_DeduccionesMonto.Leave
        Txb_DeduccionesMonto.Text = Obj_Mformat.FormatoMoneda(Txb_DeduccionesMonto.Text)
    End Sub

    Private Sub ChkB_Activo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkB_Activo.CheckedChanged

        '' Solo ejecutar el código si no estamos en la fase de inicialización
        'If initializing Then
        '    ' El código que deseas ejecutar cuando el estado del CheckBox cambia
        '    If ChkB_Activo.Checked Then
        '        DTP_FechaIngreso.Value = Now.Date()

        '        MsgBox("Se colocara como fecha de ingreso la fecha actual")

        '        'Cambia el estado del empleado
        '        Class_VariablesGlobales.Obj_Funciones_SQL.AnulaEmpleado(Txt_Id.Text, 0, Class_VariablesGlobales.SQL_Comman2)
        '        CambiaVisibilidadEmpleadoAnulado(True)
        '    Else

        '        Dim result As DialogResult = MessageBox.Show("Esta seguro que desea inactivar al empleado?",
        '                  "Alerta",
        '                  MessageBoxButtons.YesNo)

        '        If (result = DialogResult.Yes) Then
        '            'Cambia el estado del empleado
        '            Class_VariablesGlobales.Obj_Funciones_SQL.AnulaEmpleado(Txt_Id.Text, 1, Class_VariablesGlobales.SQL_Comman2)
        '            CambiaVisibilidadEmpleadoAnulado(False)
        '        Else
        '        End If
        '    End If
        'End If
    End Sub

    Public Function CambiaVisibilidadEmpleadoAnulado(Estado As Boolean, CodigoEstado As String)

        Btn_ExperienciaNuevo.Enabled = Estado
        Btn_ExperienciaEliminar.Enabled = Estado
        Btn_ExperienciaGuardar.Enabled = Estado

        Btn_EducacionNuevo.Enabled = Estado
        Btn_EducacionEliminar.Enabled = Estado
        Btn_EducacionGuarda.Enabled = Estado

        btn_GuardaVacaciones.Enabled = Estado
        Btn_AnularVacaciones.Enabled = Estado
        BtnImprimir_Vacaciones.Enabled = Estado
        Btn_NuevoVacaciones.Enabled = Estado

        Btn_NuevoValePrestamo.Enabled = Estado
        btnImprimir_ValesPrestamos.Enabled = Estado
        Btn_AnularValesPrestamos.Enabled = Estado
        btn_GuardarValePrestamo.Enabled = Estado

        Btn_DeduccionesNuevo.Enabled = Estado
        btn_AnularDeduccion.Enabled = Estado
        Btn_GuardarDeduccion.Enabled = Estado

        Btn_NuevoIncapacidad.Enabled = Estado
        Btn_AnularIncapacidad.Enabled = Estado
        Btn_GuardarIncapacidad.Enabled = Estado

        Btn_NuevoAumento.Enabled = Estado
        Btn_GuardarAumento.Enabled = Estado

        Btn_NuevoAdicionales.Enabled = Estado
        BtnAnularAdicional.Enabled = Estado
        Btn_GuardarAdicionales.Enabled = Estado

        BtnAnular.Enabled = Estado
        Btn_Guardar.Enabled = Estado

        Btn_AdjuntarLiquidacion.Enabled = Estado
        Btn_VerAdjuntoLiquidacion.Enabled = Estado
        Btn_DescargarLiquidacionFirmada.Enabled = Estado
        Btn_ImprimirLiquidacion.Enabled = Estado
        Btn_GuardarLiquidacion.Enabled = Estado

        Btn_DiasAdicionalNuevo.Enabled = Estado
        Btn_DiasAdicionalAnular.Enabled = Estado
        Btn_DiasAdicionalGuardar.Enabled = Estado

        Txb_Cedula.Enabled = Estado
        Txb_Nombre.Enabled = Estado
        Txb_Salario.Enabled = Estado
        txtb_Correo.Enabled = Estado
        TxtCuentaBancaria.Enabled = Estado
        TxtIdColaboradorBanco.Enabled = Estado
        TxtBox_CuentaContable.Enabled = Estado
        Txb_CodigoCliente.Enabled = Estado
        Txb_Telefono1.Enabled = Estado
        Txb_Telefono2.Enabled = Estado
        CBox_Puesto.Enabled = Estado
        CmboBox_CategoriaEmpeado.Enabled = Estado

        Btn_AdjuntarIncapacidad.Enabled = Estado
        Btn_VerDocIncapacidades.Enabled = Estado
        Btn_DescargarIncapacidades.Enabled = Estado

        If CodigoEstado = 0 Then
            LblAnulado.Visible = False
            LBL_LIQUIDADO.Visible = False
            lbl_EstadoCerrado.Visible = False
        ElseIf CodigoEstado = 1 Then
            LblAnulado.Visible = If(Estado = False, True, False)
            LBL_LIQUIDADO.Visible = False
            lbl_EstadoCerrado.Visible = False
        ElseIf CodigoEstado = 2 Then
            lbl_EstadoCerrado.Visible = True
            LblAnulado.Visible = False
            LBL_LIQUIDADO.Visible = False


            btnCerrarEmpleado.Visible = False

            Btn_GuardarLiquidacion.Enabled = True
            Btn_GuardarLiquidacion.Visible = True
        ElseIf CodigoEstado = 3 Then

            lbl_EstadoCerrado.Visible = False
            LblAnulado.Visible = False
            LBL_LIQUIDADO.Visible = True

            Btn_ImprimirLiquidacion.Enabled = True
            Btn_AdjuntarLiquidacion.Enabled = True
            Btn_VerAdjuntoLiquidacion.Enabled = True
            Btn_DescargarLiquidacionFirmada.Enabled = True
            Btn_ImprimirLiquidacion.Enabled = True
        End If

    End Function

    Private Sub Planilla_Empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiarInfoEmpleado()


        initializing = True
    End Sub



    Private Sub Txb_Salario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txb_Salario.KeyPress
        ' Verificar si la tecla presionada es un número, un punto o una tecla de control
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True ' Si no es un número ni un punto, no permitir que se escriba en el TextBox
        End If

        ' Verificar si ya hay un punto en el texto para evitar múltiples decimales
        If e.KeyChar = "." AndAlso DirectCast(sender, TextBox).Text.IndexOf(".") > -1 Then
            e.Handled = True ' Si ya hay un punto, no permitir otro
        End If
    End Sub

    Private Sub TBox_PorcentajeAumentos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBox_PorcentajeAumentos.KeyPress
        ' Verificar si la tecla presionada es un número, un punto o una tecla de control
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True ' Si no es un número ni un punto, no permitir que se escriba en el TextBox
        End If

        ' Verificar si ya hay un punto en el texto para evitar múltiples decimales
        If e.KeyChar = "." AndAlso DirectCast(sender, TextBox).Text.IndexOf(".") > -1 Then
            e.Handled = True ' Si ya hay un punto, no permitir otro
        End If
    End Sub

    Private Sub Txtb_MontoValePrestamo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtb_MontoValePrestamo.KeyPress
        ' Verificar si la tecla presionada es un número, un punto o una tecla de control
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True ' Si no es un número ni un punto, no permitir que se escriba en el TextBox
        End If

        ' Permitir solo un punto decimal en la entrada
        If e.KeyChar = "." AndAlso TryCast(sender, TextBox).Text.IndexOf(".") > -1 Then
            e.Handled = True ' Si ya hay un punto decimal en el TextBox, no permitir otro
        End If
    End Sub


    Private Sub Txtb_SegmentacionDeducciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtb_SegmentacionDeducciones.KeyPress
        ' Verificar si la tecla presionada es un número o una tecla de control
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Si no es un número, no permitir que se escriba en el TextBox
        End If
    End Sub

    Private Sub Txb_DeduccionesMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txb_DeduccionesMonto.KeyPress
        ' Verificar si la tecla presionada es un número, un punto o una tecla de control
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True ' Si no es un número ni un punto, no permitir que se escriba en el TextBox
        End If

        ' Permitir solo un punto decimal en la entrada
        If e.KeyChar = "." AndAlso TryCast(sender, TextBox).Text.IndexOf(".") > -1 Then
            e.Handled = True ' Si ya hay un punto decimal en el TextBox, no permitir otro
        End If

    End Sub

    Private Sub TxtBox_MontoAdicionales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBox_MontoAdicionales.KeyPress
        ' Verificar si la tecla presionada es un número o una tecla de control
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Si no es un número, no permitir que se escriba en el TextBox
        End If
    End Sub

    Private Sub TBox_PorcentajeAumentos_TextChanged(sender As Object, e As EventArgs) Handles TBox_PorcentajeAumentos.TextChanged
        Try


            Dim Salario As Double = 0
            Dim PorcentajeAumentos As Double = 0
            Dim MontoAumento As Double = 0
            Dim SalarioPosterior As Double = 0

            If (Txb_Salario.Text <> "") Then
                Salario = CDbl(Txb_Salario.Text)
            End If

            If (TBox_PorcentajeAumentos.Text <> "") Then
                PorcentajeAumentos = CDbl(TBox_PorcentajeAumentos.Text)
            End If

            MontoAumento = (Salario * PorcentajeAumentos) / 100
            SalarioPosterior = Salario + MontoAumento

            TxtB_MontoAumento.Text = Obj_Mformat.FormatoMoneda(MontoAumento)
            TxtB_SalarioAnteriorAumento.Text = Obj_Mformat.FormatoMoneda(Salario)
            TxtB_SalarioPosteriorAumento.Text = Obj_Mformat.FormatoMoneda(SalarioPosterior)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBox_LiquidacionMotivoSalida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_LiquidacionMotivoSalida.SelectedIndexChanged
        ' Obtener el índice seleccionado
        Dim indiceSeleccionado As Integer = CBox_LiquidacionMotivoSalida.SelectedIndex

        CalculaLiquidacion()

        ' Realizar acciones según la opción seleccionada
        Select Case indiceSeleccionado
            Case 0 ' Despido con Responsabilidad Patronal 
                ChkBox_Preaviso.Enabled = True
            Case 1 ' Despido sin Responsabilidad Patronal 
                TxtBox_MontoCesantia.Text = "0"
                ChkBox_Preaviso.Checked = False
                ChkBox_Preaviso.Enabled = False
            Case 2 ' Renuncia 
                TxtBox_MontoCesantia.Text = "0"
                ChkBox_Preaviso.Checked = False
                ChkBox_Preaviso.Enabled = False
            Case 3 ' Se acoje a la pension


        End Select


    End Sub

    Private Sub Btn_ImprimirLiquidacion_Click(sender As Object, e As EventArgs) Handles Btn_ImprimirLiquidacion.Click
        Class_VariablesGlobales.LiquidacionEmpleado = Txb_Cedula.Text
        Class_VariablesGlobales.IMPRIMIENDO = "Liquidacion"
        frmReporte.Show()
    End Sub

    Private Sub btn_HistorialAbonos_Click(sender As Object, e As EventArgs) Handles btn_HistorialAbonos.Click
        Class_VariablesGlobales.frmPlanillaEmpleado_HistorialAbonosVales = New PlanillaEmpleado_HistorialAbonosVales
        Class_VariablesGlobales.frmPlanillaEmpleado_HistorialAbonosVales.MdiParent = Principal
        Class_VariablesGlobales.frmPlanillaEmpleado_HistorialAbonosVales.Show()
    End Sub





    Private Function Btn_DiasAdicionalGuardar_Click(sender As Object, e As EventArgs) Handles Btn_DiasAdicionalGuardar.Click
        Try
            If ValidaExistenciaEmpleado() = False Then
                Return False
            End If

            If Txtb_DiasAdicionalesPorcentaje.Text <> "" AndAlso IsNumeric(Txtb_DiasAdicionalesPorcentaje.Text) Then
                Dim valor As Double = Double.Parse(Txtb_DiasAdicionalesPorcentaje.Text)
                If valor > 1 OrElse valor <= 0 Then
                    MsgBox("El porcentaje debe estar entre 0 y 1")
                    Return False
                ElseIf Math.Round(valor, 2) <> valor Then
                    MsgBox("El porcentaje no puede tener más de 2 decimales")
                    Return False
                End If
            Else
                MsgBox("Ingrese un valor numérico válido")
                Return False
            End If

            If Btn_DiasAdicionalGuardar.Text = "Guardar" Then
                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaDiasAdicional(Txb_Cedula.Text, Txtb_DiasAdicionalesPorcentaje.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaDiaAdicional.Value.Date), Txtb_Motivo.Text, True, Class_VariablesGlobales.SQL_Comman2)

            Else
                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaDiasAdicional(Txb_Cedula.Text, Txtb_DiasAdicionalesPorcentaje.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaDiaAdicional.Value.Date), Txtb_Motivo.Text, False, Class_VariablesGlobales.SQL_Comman2)
            End If

            LimpiaDiasAdicional()

            MsgBox("Registro guardado con exito")
        Catch ex As Exception

        End Try
    End Function

    Public Function LimpiaDiasAdicional()
        Txtb_Motivo.Text = ""
        Txtb_DiasAdicionalesPorcentaje.Text = ""
        Btn_DiasAdicionalGuardar.Text = "Guardar"
        DTP_FechaDiaAdicional.Value = Now.Date
        Lbl_DiasAdicionalAnulado.Visible = False
        CargaDiasAdiconales()
    End Function

    Private Function Btn_DiasAdicionalAnular_Click(sender As Object, e As EventArgs) Handles Btn_DiasAdicionalAnular.Click
        If ValidaExistenciaEmpleado() = False Then
            Return False
        End If
        If Class_VariablesGlobales.Obj_Funciones_SQL.DiasAdicionalAnular(Txb_Cedula.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaDiaAdicional.Value.Date), Class_VariablesGlobales.SQL_Comman2) Then
            MsgBox("Dia Adicional fue anulado")
            LimpiaDiasAdicional()
        End If
    End Function

    Private Sub DGV_DiasAdicionales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_DiasAdicionales.CellContentClick


        Btn_DiasAdicionalGuardar.Text = "Modificar"
        DTP_FechaDiaAdicional.Value = DGV_DiasAdicionales.CurrentRow.Cells.Item(0).Value.ToString()
        Txtb_Motivo.Text = DGV_DiasAdicionales.CurrentRow.Cells.Item(1).Value.ToString()
        Txtb_DiasAdicionalesPorcentaje.Text = DGV_DiasAdicionales.CurrentRow.Cells.Item(2).Value.ToString()
        If DGV_DiasAdicionales.CurrentRow.Cells.Item(3).Value.ToString() = "1" Then
            Lbl_DiasAdicionalAnulado.Visible = True
        Else
            Lbl_DiasAdicionalAnulado.Visible = False
        End If


    End Sub

    Private Sub Btn_DiasAdicionalNuevo_Click(sender As Object, e As EventArgs) Handles Btn_DiasAdicionalNuevo.Click
        LimpiaDiasAdicional()

    End Sub

    Private Sub Txtb_DiasAdicionalesPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtb_DiasAdicionalesPorcentaje.KeyPress
        ' Verificar si la tecla presionada es un número, un punto decimal o una tecla de control
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True ' Si no es un número ni un punto, no permitir que se escriba en el TextBox
        ElseIf e.KeyChar = "." AndAlso DirectCast(sender, TextBox).Text.Contains(".") Then
            ' Si ya hay un punto decimal en el TextBox, no permitir otro
            e.Handled = True
        ElseIf e.KeyChar <> "." AndAlso Char.IsDigit(e.KeyChar) Then
            ' Si es un dígito, verificar si el número resultante excede 1 o tiene más de dos decimales
            Dim textBoxText As String = DirectCast(sender, TextBox).Text
            Dim newText As String = textBoxText.Substring(0, DirectCast(sender, TextBox).SelectionStart) & e.KeyChar & textBoxText.Substring(DirectCast(sender, TextBox).SelectionStart + DirectCast(sender, TextBox).SelectionLength)
            If newText.Contains(".") Then
                Dim decimalPart As String = newText.Substring(newText.IndexOf(".") + 1)
                If decimalPart.Length > 2 Then
                    e.Handled = True ' Si tiene más de dos decimales, no permitir que se escriba
                Else
                    Dim number As Double = Convert.ToDouble(newText)
                    If number > 1 Then
                        e.Handled = True ' Si el número es mayor a 1, no permitir que se escriba
                    End If
                End If
            ElseIf newText.Length > 0 Then
                Dim number As Double = Convert.ToDouble(newText)
                If number > 1 Then
                    e.Handled = True ' Si el número es mayor a 1, no permitir que se escriba
                End If
            End If
        End If
    End Sub
    'NOTA :no borrar, evita error al navegar por el datagriview
    Private Sub DGV_Incapacidades_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGV_Incapacidades.DataError

    End Sub

    Private Sub DTGV_Experiencia_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DTGV_Experiencia.DataError

    End Sub

    Private Sub DTGV_Educacion_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DTGV_Educacion.DataError

    End Sub

    Private Sub DGV_VacacionesConsumidas_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGV_VacacionesConsumidas.DataError

    End Sub

    Private Sub DGV_ValesPrestamos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGV_ValesPrestamos.DataError

    End Sub

    Private Sub DGV_Deducciones_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGV_Deducciones.DataError

    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

    End Sub

    Private Sub CBx_DeduccionesCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBx_DeduccionesCategoria.SelectedIndexChanged

        If CBx_DeduccionesCategoria.Text = "Temporal" Then
            txtb_PorcentajePrimerQuincena.Enabled = False
            txtb_PorcentajeSegundaQuincena.Enabled = False
            txtb_PorcentajePrimerQuincena.Text = 0
            txtb_PorcentajeSegundaQuincena.Text = 100
        Else
            txtb_PorcentajePrimerQuincena.Enabled = True
            txtb_PorcentajeSegundaQuincena.Enabled = True
            txtb_PorcentajePrimerQuincena.Text = 0
            txtb_PorcentajeSegundaQuincena.Text = 0
        End If

    End Sub






















#End Region

End Class