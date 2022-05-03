Public Class Planilla
    Public Obj_List_Empleados As New Planilla_List_Empleados
    Private Sub Planilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim contardor As Integer = 0
        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Empresa(Class_VariablesGlobales.SQL_Comman2)

        While contardor < tabla.Rows.Count
            Txt_CedJuridica.Text = tabla.Rows(contardor).Item("Cedula").ToString()
            Txt_Nombre.Text = tabla.Rows(contardor).Item("Nombre").ToString()
            contardor += 1
        End While

        Txb_id_Planilla.Text = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_ID_Planilla(Class_VariablesGlobales.SQL_Comman2)

        Obti_Planilla()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AplicarAumento.Show()


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EmplAdelante.Click
        If Txt_Id.Text = "" Then
            Txt_Id.Text = "0"
        End If
        Btn_Atras.Enabled = True

        Dim Empleado As New DataTable
        Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.NavegaEmpleados(CInt(Txt_Id.Text) + 1, Class_VariablesGlobales.SQL_Comman2)
        Navegar(Empleado)



    End Sub

    Private Sub btn_EmplAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EmplAtras.Click
        If Txt_Id.Text = "" Then
            Txt_Id.Text = "0"
        End If
        Btn_Atras.Enabled = True

        Dim Empleado As New DataTable
        Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.NavegaEmpleados(CInt(Txt_Id.Text) - 1, Class_VariablesGlobales.SQL_Comman2)
        Navegar(Empleado)
    End Sub


    Public Function Navegar(ByVal DGV_ListaEmpleado As DataTable)

        For Each row As DataRow In DGV_ListaEmpleado.Rows

            Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Cedula").ToString())
            Class_VariablesGlobales.frmPlanilla.txtb_NombreEmpleado.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Nombre").ToString())
            Class_VariablesGlobales.frmPlanilla.Txb_Puesto.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Puesto").ToString())
            Class_VariablesGlobales.frmPlanilla.Txb_Salario.Text = FormatCurrency(Trim(DGV_ListaEmpleado.Rows(0).Item("Salario").ToString()), 2)

            Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text = FormatCurrency(CDbl(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Salario.Text) / 2), 2)

            Class_VariablesGlobales.frmPlanilla.Txt_Id.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("id").ToString())
            Class_VariablesGlobales.frmPlanilla.Txtb_CodRuta.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("CodRuta").ToString())

            If Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString()) <> "" Then
                Class_VariablesGlobales.frmPlanilla.Txb_RutaImagen.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString())
                Class_VariablesGlobales.frmPlanilla.PictureBox1.Image = Image.FromFile(Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString()))
            Else
                Class_VariablesGlobales.frmPlanilla.PictureBox1.Image = Image.FromFile(" C:\Program Files (x86)\ESSCO\SINCRO\Planilla_Imagenes\SinFoto.png")
            End If

            Class_VariablesGlobales.frmPlanilla.Txb_CodigoEmpleado.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Codigo").ToString())
            Class_VariablesGlobales.frmPlanilla.txtb_CodigoCobroXFaltante.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("CodigoCobroXFaltante").ToString())

            If Class_VariablesGlobales.frmPlanilla.Txb_CodigoEmpleado.Text <> "" Then
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Facturas.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtineFacturasSaldo(Class_VariablesGlobales.frmPlanilla.Txb_CodigoEmpleado.Text, Class_VariablesGlobales.SQL_Comman2), 2)
            Else
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Facturas.Text = FormatCurrency(0, 2)
            End If


            Class_VariablesGlobales.frmPlanilla.Txb_Dedu_CCSS.Text = FormatCurrency((CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text) * CDbl(txtb_PorcCCSS.Text)) / 100, 2)


            If Class_VariablesGlobales.frmPlanilla.Txb_Puesto.Text = "AGENTE" Then

                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_FaltaLiq.Text = FormatCurrency((CDbl(Class_VariablesGlobales.Obj_Funciones_SQL.ObtineLiqSaldo(Class_VariablesGlobales.frmPlanilla.Txtb_CodRuta.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmPlanilla.DTP_FechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmPlanilla.DTP_FechaSalida.Value.Date), Class_VariablesGlobales.SQL_Comman2))), 2)
            Else
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_FaltaLiq.Text = FormatCurrency(0, 2)
            End If

            If Class_VariablesGlobales.frmPlanilla.txtb_CodigoCobroXFaltante.Text <> "" Then
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Faltante.Text = FormatCurrency((CDbl(Class_VariablesGlobales.Obj_Funciones_SQL.ObtineCobroXFaltante(Class_VariablesGlobales.frmPlanilla.txtb_CodigoCobroXFaltante.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmPlanilla.DTP_FechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmPlanilla.DTP_FechaSalida.Value.Date), Class_VariablesGlobales.SQL_Comman2))), 2)
            Else
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Faltante.Text = FormatCurrency(0, 2)
            End If




            Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))

            Dim tabla_DeduccionesFijas As DataTable = New DataTable
            Dim contardor As Integer = 0

            tabla_DeduccionesFijas = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Deducciones((Trim(Txb_CedulaEmpleado.Text)), Class_VariablesGlobales.SQL_Comman2)

            If tabla_DeduccionesFijas.Rows.Count > 0 Then
                While contardor < tabla_DeduccionesFijas.Rows.Count

                    If tabla_DeduccionesFijas.Rows(contardor).Item("Tipo").ToString() = "ADICIONAL" Then
                        Txb_Dedu_Adicional.Text = FormatCurrency(CDbl(tabla_DeduccionesFijas.Rows(contardor).Item("Monto").ToString()), 2)
                    End If

                    If tabla_DeduccionesFijas.Rows(contardor).Item("Tipo").ToString() = "DEB PERSONAL" Then
                        Txb_Dedu_Deb_Personal.Text = FormatCurrency(CDbl(tabla_DeduccionesFijas.Rows(contardor).Item("Monto").ToString()), 2)
                    End If

                    If tabla_DeduccionesFijas.Rows(contardor).Item("Tipo").ToString() = "DUCC CUOTA BP" Then
                        Txb_Dedu_Ducc_Cuota.Text = FormatCurrency(CDbl(tabla_DeduccionesFijas.Rows(contardor).Item("Monto").ToString()), 2)
                    End If

                    If tabla_DeduccionesFijas.Rows(contardor).Item("Tipo").ToString() = "DEDUCION DE CELULAR" Then
                        Txb_Dedu_Celular.Text = FormatCurrency(CDbl(tabla_DeduccionesFijas.Rows(contardor).Item("Monto").ToString()), 2)
                    End If

                    If tabla_DeduccionesFijas.Rows(contardor).Item("Tipo").ToString() = "EMBARGO" Then
                        Txb_Dedu_Embargo.Text = FormatCurrency(CDbl(tabla_DeduccionesFijas.Rows(contardor).Item("Monto").ToString()), 2)
                    End If

                    If tabla_DeduccionesFijas.Rows(contardor).Item("Tipo").ToString() = "COBROS PRESTAMO" Then
                        Txb_Dedu_Prestamo.Text = FormatCurrency(CDbl(tabla_DeduccionesFijas.Rows(contardor).Item("Monto").ToString()), 2)
                    End If


                    If tabla_DeduccionesFijas.Rows(contardor).Item("Tipo").ToString() = "OTROS" Then
                        Txb_Dedu_Otro.Text = FormatCurrency(CDbl(tabla_DeduccionesFijas.Rows(contardor).Item("Monto").ToString()), 2)
                    End If

                    contardor += 1
                End While
            End If
            tabla_DeduccionesFijas = Nothing


            If Txb_Dedu_Prestamo.Text = "0" Then
                Txb_Dedu_Prestamo.Text = FormatCurrency("0", 2)
            End If
            If Txb_Dedu_Adicional.Text = "0" Then
                Txb_Dedu_Adicional.Text = FormatCurrency("0", 2)
            End If
            If Txb_Dedu_Deb_Personal.Text = "0" Then
                Txb_Dedu_Deb_Personal.Text = FormatCurrency("0", 2)
            End If
            If Txb_Dedu_Ducc_Cuota.Text = "0" Then
                Txb_Dedu_Ducc_Cuota.Text = FormatCurrency("0", 2)
            End If
            If Txb_Dedu_Celular.Text = "0" Then
                Txb_Dedu_Celular.Text = FormatCurrency("0", 2)
            End If
            If Txb_Dedu_Embargo.Text = "0" Then
                Txb_Dedu_Embargo.Text = FormatCurrency("0", 2)
            End If
            If Txb_Dedu_Otro.Text = "0" Then
                Txb_Dedu_Otro.Text = FormatCurrency("0", 2)
            End If





        Next

        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaDuplicadoPlanilla(Txb_CedulaEmpleado.Text, Txb_id_Planilla.Text, Class_VariablesGlobales.SQL_Comman2) = False Then

            Btn_GuardarDeduccion.BackColor = Color.RoyalBlue
            Btn_GuardarDeduccion.Text = "Guardar"
        Else
            Btn_GuardarDeduccion.Text = "Actualizar"
            Btn_GuardarDeduccion.BackColor = Color.Green
        End If
        'Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text = DGV_ListaEmpleado.CurrentRow.Cells.Item(0).Value.ToString
    End Function

    Private Sub Btn_GuardaPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GuardaPlanilla.Click

        For Each row As DataGridViewRow In DTGV_Planilla.Rows
            If Trim(row.Cells.Item("id").Value) = "" = False Then

                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaPlanilla(Trim(row.Cells.Item("id").Value), Trim(row.Cells.Item("Ced_Juridica").Value), Trim(row.Cells.Item("Nombre").Value), _
                                                 Trim(row.Cells.Item("PorcCCSS").Value), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Trim(row.Cells.Item("FechaINI").Value)), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Trim(row.Cells.Item("FechaFIN").Value)), _
                                                  row.Cells.Item("Ced_Empleado").Value, row.Cells.Item("Puesto").Value, row.Cells.Item("NombreEmpleado").Value, _
                                                   row.Cells.Item("Salario").Value, row.Cells.Item("SalarioQuincenal").Value, row.Cells.Item("ADICIONAL").Value, _
                                                    row.Cells.Item("DEB_PERSONAL").Value, row.Cells.Item("DUCC_CUOTA_BP").Value, row.Cells.Item("DEDUCION_DE_CELULAR").Value, _
                                                     row.Cells.Item("EMBARGO").Value, row.Cells.Item("COBROS_PRESTAMO").Value, row.Cells.Item("FALTANTES_LIQ").Value, _
                                                      row.Cells.Item("FACTURAS").Value, row.Cells.Item("COBROS_X_FALTANTE").Value, row.Cells.Item("Dedu_CCSS").Value, 0, row.Cells.Item("SalarioFinal").Value, _
                                                       Trim(row.Cells.Item("Foto").Value), True, Class_VariablesGlobales.SQL_Comman2)

            End If
        Next

        Class_VariablesGlobales.Obj_Funciones_SQL.AUMENTA_ID_Planilla(CInt(Trim(Txb_id_Planilla.Text)) + 1, Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.Obj_Funciones_SQL.ELIMINA_Planilla_TEMP(CInt(Trim(Txb_id_Planilla.Text)), Class_VariablesGlobales.SQL_Comman2)
        Limpiar()

    End Sub

    Public Function Limpiar()
        Txb_id_Planilla.Text = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_ID_Planilla(Class_VariablesGlobales.SQL_Comman2)

        txtb_TotalPlanilla.Text = ""
        Txt_CedJuridica.Text = ""
        Txt_Nombre.Text = ""
        txtb_Aumento.Text = ""
        txtb_PorcCCSS.Text = ""
        Txt_Id.Text = ""
        Txb_CedulaEmpleado.Text = ""
        Txb_Puesto.Text = ""
        txtb_NombreEmpleado.Text = ""
        Txb_Salario.Text = ""
        Txb_SalarioQuincenal.Text = ""
        Txb_RutaImagen.Text = ""
        Txtb_CodRuta.Text = ""
        Txb_CodigoEmpleado.Text = ""
        txtb_CodigoCobroXFaltante.Text = ""
        Txb_Dedu_Adicional.Text = ""
        Txb_Dedu_Deb_Personal.Text = ""
        Txb_Dedu_Ducc_Cuota.Text = ""
        Txb_Dedu_Celular.Text = ""
        Txb_Dedu_Embargo.Text = ""
        Txb_Dedu_Prestamo.Text = ""
        Txb_Dedu_FaltaLiq.Text = ""
        Txb_Dedu_Facturas.Text = ""
        Txb_Dedu_Faltante.Text = ""
        Txb_Dedu_CCSS.Text = ""
        Txb_Dedu_Otro.Text = ""
        DTP_FechaIngreso.Value = Now.Date
        DTP_FechaSalida.Value = Now.Date
        DTGV_Planilla.DataSource = New DataTable
        Lbl_Salario.Text = "0"
        Btn_GuardarDeduccion.BackColor = Color.RoyalBlue
        Btn_GuardarDeduccion.Text = "Guardar"
    End Function

    Private Sub Txb_Dedu_Prestamo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_Prestamo.Leave
        Txb_Dedu_Prestamo.Text = FormatCurrency(Txb_Dedu_Prestamo.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub

    Private Sub Txb_Dedu_Adicional_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_Adicional.Leave
        Txb_Dedu_Adicional.Text = FormatCurrency(Txb_Dedu_Adicional.Text, 2)

        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))

    End Sub

    Private Sub Txb_Dedu_Deb_Personal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_Deb_Personal.Leave
        Txb_Dedu_Deb_Personal.Text = FormatCurrency(Txb_Dedu_Deb_Personal.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub

    Private Sub Txb_Dedu_Ducc_Cuota_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_Ducc_Cuota.Leave
        Txb_Dedu_Ducc_Cuota.Text = FormatCurrency(Txb_Dedu_Ducc_Cuota.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub

    Private Sub Txb_Dedu_Celular_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_Celular.Leave
        Txb_Dedu_Celular.Text = FormatCurrency(Txb_Dedu_Celular.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub

    Private Sub Txb_Dedu_Embargo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_Embargo.Leave
        Txb_Dedu_Embargo.Text = FormatCurrency(Txb_Dedu_Embargo.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub

    Private Sub Txb_Dedu_Otro_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_Otro.Leave
        Txb_Dedu_Otro.Text = FormatCurrency(Txb_Dedu_Otro.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub
    Private Sub Txb_Dedu_FaltaLiq_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_FaltaLiq.Leave
        Txb_Dedu_FaltaLiq.Text = FormatCurrency(Txb_Dedu_FaltaLiq.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub

    Private Sub Txb_Dedu_Facturas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_Facturas.Leave
        Txb_Dedu_Facturas.Text = FormatCurrency(Txb_Dedu_Facturas.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub

    Private Sub Txb_Dedu_Faltante_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_Faltante.Leave
        Txb_Dedu_Faltante.Text = FormatCurrency(Txb_Dedu_Faltante.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub

    Private Sub Txb_Dedu_CCSS_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Dedu_CCSS.Leave
        Txb_Dedu_CCSS.Text = FormatCurrency(Txb_Dedu_CCSS.Text, 2)
        Lbl_Salario.Text = Calcular(CDbl(Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text))
    End Sub

    Public Function Calcular(ByVal salario As Double)

        salario += CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Adicional.Text)

        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Deb_Personal.Text)
        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Ducc_Cuota.Text)
        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Celular.Text)
        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Embargo.Text)
        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_FaltaLiq.Text)
        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Facturas.Text)
        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Faltante.Text)
        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Prestamo.Text)
        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_CCSS.Text)
        salario -= CDbl(Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Otro.Text)



        Return FormatCurrency(CDbl(salario), 2)
    End Function



    Private Sub Btn_GuardarDeduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GuardarDeduccion.Click
        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaDuplicadoPlanilla(Txb_CedulaEmpleado.Text, Txb_id_Planilla.Text, Class_VariablesGlobales.SQL_Comman2) = False Then

            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaPlanilla_TEM(CInt(Trim(Txb_id_Planilla.Text)), Txt_CedJuridica.Text, Txt_Nombre.Text, txtb_PorcCCSS.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaSalida.Value.Date), Txb_CedulaEmpleado.Text, Txb_Puesto.Text, txtb_NombreEmpleado.Text, Txb_Salario.Text, Txb_SalarioQuincenal.Text, Txb_Dedu_Adicional.Text, Txb_Dedu_Deb_Personal.Text, Txb_Dedu_Ducc_Cuota.Text, Txb_Dedu_Celular.Text, Txb_Dedu_Embargo.Text, Txb_Dedu_Prestamo.Text, Txb_Dedu_FaltaLiq.Text, Txb_Dedu_Facturas.Text, Txb_Dedu_Faltante.Text, Txb_Dedu_CCSS.Text, Txb_Dedu_Otro.Text, CDbl(Lbl_Salario.Text), Txb_RutaImagen.Text, Txt_Id.Text, True, Class_VariablesGlobales.SQL_Comman2)

            Btn_GuardarDeduccion.Text = "Actualizar"
            Btn_GuardarDeduccion.BackColor = Color.Green
        Else
            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaPlanilla_TEM(CInt(Trim(Txb_id_Planilla.Text)), Txt_CedJuridica.Text, Txt_Nombre.Text, txtb_PorcCCSS.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaIngreso.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaSalida.Value.Date), Txb_CedulaEmpleado.Text, Txb_Puesto.Text, txtb_NombreEmpleado.Text, Txb_Salario.Text, Txb_SalarioQuincenal.Text, Txb_Dedu_Adicional.Text, Txb_Dedu_Deb_Personal.Text, Txb_Dedu_Ducc_Cuota.Text, Txb_Dedu_Celular.Text, Txb_Dedu_Embargo.Text, Txb_Dedu_Prestamo.Text, Txb_Dedu_FaltaLiq.Text, Txb_Dedu_Facturas.Text, Txb_Dedu_Faltante.Text, Txb_Dedu_CCSS.Text, Txb_Dedu_Otro.Text, CDbl(Lbl_Salario.Text), Txb_RutaImagen.Text, Txt_Id.Text, False, Class_VariablesGlobales.SQL_Comman2)
            'MsgBox("Empleado ya esta agregado en planilla")

        End If

        Obti_Planilla()
    End Sub

    Public Function Obti_Planilla()
        DTGV_Planilla.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Planilla_Temp(CInt(Trim(Txb_id_Planilla.Text)), Class_VariablesGlobales.SQL_Comman2)

        DTGV_Planilla.Columns(0).Width = 80
        DTGV_Planilla.Columns(1).Width = 200
        DTGV_Planilla.Columns(2).Width = 85
        DTGV_Planilla.Columns(3).Width = 85
        DTGV_Planilla.Columns(4).Width = 85
        DTGV_Planilla.Columns(5).Width = 85
        DTGV_Planilla.Columns(6).Width = 85
        DTGV_Planilla.Columns(7).Width = 85
        DTGV_Planilla.Columns(8).Width = 85
        DTGV_Planilla.Columns(9).Width = 85
        DTGV_Planilla.Columns(10).Width = 85
        DTGV_Planilla.Columns(11).Width = 85
        DTGV_Planilla.Columns(12).Width = 85
        DTGV_Planilla.Columns(13).Width = 85
        DTGV_Planilla.Columns(14).Visible = False
        DTGV_Planilla.Columns(15).Visible = False
        DTGV_Planilla.Columns(16).Visible = False
        DTGV_Planilla.Columns(17).Visible = False
        DTGV_Planilla.Columns(18).Visible = False
        DTGV_Planilla.Columns(19).Visible = False
        DTGV_Planilla.Columns(20).Visible = False
        DTGV_Planilla.Columns(21).Visible = False
        DTGV_Planilla.Columns(22).Visible = False
    End Function


    Private Sub DTGV_Planilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DTGV_Planilla.CellContentClick

        '[Ced_Empleado](" & _")
        '                  ",[NombreEmpleado]" & _
        '                  ",[Puesto]" & _
        '                  ",[Salario]" & _
        '                  ",[SalarioQuincenal]" & _
        '                  ",[ADICIONAL]" & _
        '                  ",[DEB_PERSONAL]" & _
        '                  ",[DUCC_CUOTA_BP]" & _
        '                  ",[DEDUCION_DE_CELULAR]" & _
        '                  ",[EMBARGO]" & _
        '                  ",[FALTANTES_LIQ]" & _
        '                  ",[FACTURAS]" & _
        '                  ",[COBROS_X_FALTANTE]" & _
        '                  ",[COBROS_PRESTAMO]" & _  
        '                  ",[Dedu_CCSS]" & _
        '                  ",[id],[Ced_Juridica],[Nombre],[FechaINI],[FechaFIN],[Comentario],[PorcCCSS],[Foto],id_Empleado


        Txb_CedulaEmpleado.Text = DTGV_Planilla.CurrentRow.Cells.Item(0).Value.ToString()
        txtb_NombreEmpleado.Text = DTGV_Planilla.CurrentRow.Cells.Item(1).Value.ToString()
        Txb_Puesto.Text = DTGV_Planilla.CurrentRow.Cells.Item(2).Value.ToString()


        Txb_Salario.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(3).Value.ToString(), 2)
        Txb_SalarioQuincenal.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(4).Value.ToString(), 2)

        Txb_Dedu_Adicional.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(5).Value.ToString(), 2)
        Txb_Dedu_Deb_Personal.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(6).Value.ToString(), 2)
        Txb_Dedu_Ducc_Cuota.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(7).Value.ToString(), 2)
        Txb_Dedu_Celular.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(8).Value.ToString(), 2)
        Txb_Dedu_Embargo.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(9).Value.ToString(), 2)
        Txb_Dedu_FaltaLiq.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(10).Value.ToString(), 2)
        Txb_Dedu_Facturas.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(11).Value.ToString(), 2)
        Txb_Dedu_Faltante.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(12).Value.ToString(), 2)
        Txb_Dedu_Prestamo.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(13).Value.ToString(), 2)
        Txb_Dedu_CCSS.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(14).Value.ToString(), 2)

        Txb_Dedu_Otro.Text = FormatCurrency(DTGV_Planilla.CurrentRow.Cells.Item(15).Value.ToString(), 2)
        Txb_RutaImagen.Text = DTGV_Planilla.CurrentRow.Cells.Item(22).Value.ToString()

        Txb_id_Planilla.Text = DTGV_Planilla.CurrentRow.Cells.Item(23).Value.ToString()

        If Trim(Txb_RutaImagen.Text) <> "" Then
            Class_VariablesGlobales.frmPlanilla.Txb_RutaImagen.Text = Trim(Txb_RutaImagen.Text)
            Class_VariablesGlobales.frmPlanilla.PictureBox1.Image = Image.FromFile(Trim(Txb_RutaImagen.Text))
        Else
            Class_VariablesGlobales.frmPlanilla.PictureBox1.Image = Image.FromFile(" C:\Program Files (x86)\ESSCO\SINCRO\Planilla_Imagenes\SinFoto.png")
        End If


        'Txb_CedulaEmpleado.Text = DTGV_Planilla.CurrentRow.Cells.Item(15).Value.ToString()
        'Txb_CedulaEmpleado.Text = DTGV_Planilla.CurrentRow.Cells.Item(16).Value.ToString()
        'Txb_CedulaEmpleado.Text = DTGV_Planilla.CurrentRow.Cells.Item(17).Value.ToString()
        'Txb_CedulaEmpleado.Text = DTGV_Planilla.CurrentRow.Cells.Item(18).Value.ToString()

        DTGV_Planilla.CurrentRow.Cells.Item(19).Value.ToString()
        Btn_GuardarDeduccion.Text = "Actualizar"
        Btn_GuardarDeduccion.BackColor = Color.Green
    End Sub

    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Lista_Planillas.Show()
    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        Btn_GuardaPlanilla.Text = "ACTUALIZAR"
        If Txb_id_Planilla.Text = "" Then
            Txb_id_Planilla.Text = "0"
        End If
        Btn_Atras.Enabled = True

        Dim Empleado As New DataTable
        Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Planilla(CInt(Txb_id_Planilla.Text) + 1, Class_VariablesGlobales.SQL_Comman2)
        NavegaPlanilla(Empleado)

    End Sub

    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click

        Btn_GuardaPlanilla.Text = "ACTUALIZAR"
        If Txb_id_Planilla.Text = "" Then
            Txb_id_Planilla.Text = "0"
        End If
        Btn_Atras.Enabled = True

        Dim Empleado As New DataTable
        Empleado = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Planilla(CInt(Txb_id_Planilla.Text) - 1, Class_VariablesGlobales.SQL_Comman2)
        NavegaPlanilla(Empleado)

    End Sub



    Public Function NavegaPlanilla(ByVal Planila As DataTable)

        Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.DataSource = Planila

        Class_VariablesGlobales.Contador = 0
        If Planila.Rows.Count > 0 Then
            While Class_VariablesGlobales.Contador < Planila.Rows.Count
                Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Ced_Empleado").ToString()
                Class_VariablesGlobales.frmPlanilla.txtb_NombreEmpleado.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("NombreEmpleado").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Puesto.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Puesto").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Salario.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Salario").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_SalarioQuincenal.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("SalarioQuincenal").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Adicional.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("ADICIONAL").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Deb_Personal.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("DEB_PERSONAL").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Ducc_Cuota.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("DUCC_CUOTA_BP").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Celular.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("DEDUCION_DE_CELULAR").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Embargo.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("EMBARGO").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_FaltaLiq.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("FALTANTES_LIQ").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Facturas.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("FACTURAS").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Faltante.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("COBROS_X_FALTANTE").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_Prestamo.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("COBROS_PRESTAMO").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_Dedu_CCSS.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Dedu_CCSS").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("id").ToString()
                Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Ced_Juridica").ToString()
                Class_VariablesGlobales.frmPlanilla.Txt_Nombre.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Nombre").ToString()
                Class_VariablesGlobales.frmPlanilla.DTP_FechaIngreso.Value = Planila.Rows(Class_VariablesGlobales.Contador).Item("FechaINI").ToString()
                Class_VariablesGlobales.frmPlanilla.DTP_FechaSalida.Value = Planila.Rows(Class_VariablesGlobales.Contador).Item("FechaFIN").ToString()
                Class_VariablesGlobales.frmPlanilla.txtb_PorcCCSS.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("PorcCCSS").ToString()
                Class_VariablesGlobales.frmPlanilla.Txb_RutaImagen.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("Foto").ToString()
                Class_VariablesGlobales.frmPlanilla.Txt_Id.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("id_Empleado").ToString()
                Class_VariablesGlobales.frmPlanilla.Lbl_Salario.Text = Planila.Rows(Class_VariablesGlobales.Contador).Item("SalarioFinal").ToString()
                Class_VariablesGlobales.Contador += 1
            End While
        End If
    End Function

    Private Sub btn_NuevaPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NuevaPlanilla.Click
        Btn_GuardaPlanilla.Text = "GUARDAR"
        Limpiar()

    End Sub

    Private Sub btn_ImprimeRepEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ImprimeRepEmpleado.Click
        PlanillaReport.Show()


    End Sub

    Private Sub btn_GoEmpleado_Click(sender As Object, e As EventArgs) Handles btn_GoEmpleado.Click
        Class_VariablesGlobales.frmEmpleados = New Planilla_Empleados
        Class_VariablesGlobales.frmEmpleados.MdiParent = Me
        Class_VariablesGlobales.frmEmpleados.Show()
    End Sub
End Class