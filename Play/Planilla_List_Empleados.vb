Imports System.Net.WebRequestMethods
Imports System.IO



Public Class Planilla_List_Empleados
    Public Obj_Mformat As New MonedaFormat

    Public LlamadoDesde As String
    Public Function BuscarEmpleado(Pista As String, Busqueda As String)
        Try



            DGV_ListaEmpleado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.BuscaEmpleado(Pista, Busqueda, Class_VariablesGlobales.SQL_Comman2)

            'redimencionar columnas 
            DGV_ListaEmpleado.Columns(1).Width = 350 'Nombre
        Catch ex As Exception

        End Try
    End Function


    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Txb_Nombre.Enabled = True
            Txb_Cedula.Enabled = False
            Txb_Cedula.Text = ""
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            Txb_Nombre.Enabled = False
            Txb_Nombre.Text = ""
            Txb_Cedula.Enabled = True

        End If
    End Sub

    Private Sub Txb_Cedula_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txb_Cedula.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub

    Private Sub Txb_Nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Nombre.TextChanged
        BuscarEmpleado(Txb_Nombre.Text, "Nombre")
    End Sub

    Private Sub Txb_Cedula_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Cedula.TextChanged
        BuscarEmpleado(Txb_Cedula.Text, "Cedula")
    End Sub

    Private Sub List_Empleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarEmpleado(Txb_Nombre.Text, "")
    End Sub

    Private Function DGV_ListaEmpleado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_ListaEmpleado.CellContentClick
        Try

            If LlamadoDesde = "AdminAgentes" Then
                ObtieneInfoEmpleadofrmAdminAgente(DGV_ListaEmpleado.CurrentRow)
                Return True
            End If
            If LlamadoDesde = "PlanillaEmpleados" Then
                Dim tbl As New DataTable
                tbl = DataGridViewRowToDataTable(DGV_ListaEmpleado.CurrentRow)
                Navegar(tbl)
                Return True
            End If
            If LlamadoDesde = "LIQ_CHOFERES_CobrarA" Then
                ObtieneInfoEmpleadofrmLiqChoferes(DGV_ListaEmpleado.CurrentRow)
                Return True
            End If

            If LlamadoDesde = "" Then
                MessageBox.Show("No se detecto de donde fue llamada la ventana cierre el sistema he intentolo nuevamente")
            End If

        Catch ex As Exception

        End Try
    End Function
    Private Function DataGridViewRowToDataTable(ByVal currentRow As DataGridViewRow) As DataTable
        ' Verificar si la fila actual no es nula
        If currentRow IsNot Nothing Then
            ' Crear un nuevo DataTable
            Dim dataTable As New DataTable()

            ' Agregar columnas al DataTable para que coincidan con las columnas del DataGridView
            For Each cell As DataGridViewCell In currentRow.Cells
                dataTable.Columns.Add(cell.OwningColumn.Name)
            Next

            ' Crear una nueva fila en el DataTable y copiar los valores de la fila actual
            Dim newRow As DataRow = dataTable.NewRow()
            For Each cell As DataGridViewCell In currentRow.Cells
                newRow(cell.OwningColumn.Name) = cell.Value
            Next
            dataTable.Rows.Add(newRow)

            Return dataTable
        Else
            ' Si la fila actual es nula, devuelve un DataTable vacío
            Return New DataTable()
        End If
    End Function

    Public Function ObtieneInfoEmpleadofrmAdminAgente(filaSeleccionada As DataGridViewRow)
        Class_VariablesGlobales.Obj_from_AdminAgentes.txtb_Cedula.Text = Trim(filaSeleccionada.Cells.Item("Cedula").Value().ToString())
        Class_VariablesGlobales.Obj_from_AdminAgentes.txtb_Nombre.Text = Trim(filaSeleccionada.Cells.Item("Nombre").Value().ToString())
        Class_VariablesGlobales.Obj_from_AdminAgentes.txtb_telf.Text = Trim(filaSeleccionada.Cells.Item("Telefono1").Value().ToString())
        Class_VariablesGlobales.Obj_from_AdminAgentes.CBx_Puesto.Text = Trim(filaSeleccionada.Cells.Item("Puesto").Value().ToString())
        Class_VariablesGlobales.Obj_from_AdminAgentes.txtb_Correo.Text = Trim(filaSeleccionada.Cells.Item("Correo").Value().ToString())
        Me.Close()
    End Function

    Public Function ObtieneInfoEmpleadofrmLiqChoferes(filaSeleccionada As DataGridViewRow)
        Class_VariablesGlobales.frmLiqChof.Txtb_CedulaEmpleadoCobrarA.Text = Trim(filaSeleccionada.Cells.Item("Cedula").Value().ToString())
        Class_VariablesGlobales.frmLiqChof.Txtb_NombreEmpleadoCobrarA.Text = Trim(filaSeleccionada.Cells.Item("Nombre").Value().ToString())

        Me.Close()
    End Function



    ''' <summary>
    ''' esta funion y ObtieneInfoEmpleado son iguales solo que esta funciona para navegar entre empleados
    ''' </summary>
    ''' <param name="DGV_ListaEmpleado"></param>
    ''' <returns></returns>
    Public Function Navegar(ByVal DGV_ListaEmpleado As DataTable)
        Try

            Class_VariablesGlobales.frmEmpleados.TabControl1.Enabled = True
            Class_VariablesGlobales.frmEmpleados.LimpiarInfoEmpleado()

            For Each row As DataRow In DGV_ListaEmpleado.Rows

                Class_VariablesGlobales.frmEmpleados.Txt_Id.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("id").ToString())
                Class_VariablesGlobales.frmEmpleados.Txb_CodigoCliente.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Codigo").ToString())
                Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Cedula").ToString())
                Class_VariablesGlobales.frmEmpleados.Txb_Nombre.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Nombre").ToString())
                Class_VariablesGlobales.frmEmpleados.Txb_Telefono1.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Telefono1").ToString())
                Class_VariablesGlobales.frmEmpleados.Txb_Telefono2.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Telefono2").ToString())
                Class_VariablesGlobales.frmEmpleados.CBox_Puesto.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Puesto").ToString())
                Class_VariablesGlobales.frmEmpleados.Txb_Salario.Text = CStr(Obj_Mformat.FormatoMoneda(Trim(DGV_ListaEmpleado.Rows(0).Item("Salario").ToString())))

                Class_VariablesGlobales.frmEmpleados.TxtCuentaBancaria.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("CuentaBancaria").ToString())
                Class_VariablesGlobales.frmEmpleados.TxtIdColaboradorBanco.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("IdColaborador").ToString())
                Class_VariablesGlobales.frmEmpleados.TxtBox_CuentaContable.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("CuentaContable").ToString())
                Class_VariablesGlobales.frmEmpleados.CmboBox_CategoriaEmpeado.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("CategoriaEmpleado").ToString())

                If Class_VariablesGlobales.frmEmpleados.Txb_Salario.Text <> "" Then
                    Class_VariablesGlobales.frmEmpleados.Txb_SalarioQuincenal.Text = CStr(Obj_Mformat.FormatoMoneda(CDbl(Class_VariablesGlobales.frmEmpleados.Txb_Salario.Text) / 2))
                    Class_VariablesGlobales.frmEmpleados.Txb_SalarioDiario.Text = CStr(Obj_Mformat.FormatoMoneda(CDbl(Class_VariablesGlobales.frmEmpleados.Txb_Salario.Text) / 30))
                Else
                    Class_VariablesGlobales.frmEmpleados.Txb_SalarioQuincenal.Text = 0
                    Class_VariablesGlobales.frmEmpleados.Txb_SalarioDiario.Text = 0
                End If

                Class_VariablesGlobales.frmEmpleados.DTP_FechaIngreso.Value = Trim(DGV_ListaEmpleado.Rows(0).Item("FechaIngreso").ToString())
                Class_VariablesGlobales.frmEmpleados.DTP_FechaIngreso.Enabled = False

                If Trim(DGV_ListaEmpleado.Rows(0).Item("FechaFin").ToString()) = "" then
                  Class_VariablesGlobales.frmEmpleados.DTP_FechaSalida.Checked = False
                Else
                    Class_VariablesGlobales.frmEmpleados.DTP_FechaSalida.Value = Trim(DGV_ListaEmpleado.Rows(0).Item("FechaFin").ToString())

                    Class_VariablesGlobales.frmEmpleados.DTP_FechaProyectadaSalida.Value = Trim(DGV_ListaEmpleado.Rows(0).Item("FechaFin").ToString())

                End If

                Class_VariablesGlobales.frmEmpleados.txtb_Correo.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Correo").ToString())
                Class_VariablesGlobales.frmEmpleados.ChkB_Activo.Checked = If(Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "0", True, False)
                Class_VariablesGlobales.frmEmpleados.LblAnulado.Visible = If(Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "0", False, True)

                Class_VariablesGlobales.frmEmpleados.LBL_LIQUIDADO.Visible = If(Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "3", True, False)
                Class_VariablesGlobales.frmEmpleados.lbl_EstadoCerrado.Visible = If(Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "2", True, False)
                Class_VariablesGlobales.frmEmpleados.btnCerrarEmpleado.Visible = If(Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "0", True, False)
                Class_VariablesGlobales.frmEmpleados.Btn_GuardarLiquidacion.Visible = If(Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "2", True, False)
                Class_VariablesGlobales.frmEmpleados.DTP_FechaProyectadaSalida.Enabled = If(Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "1" OrElse Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "2" OrElse Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "3", False, True)
                Class_VariablesGlobales.frmEmpleados.CBox_LiquidacionMotivoSalida.Enabled = If(Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "3", False, True)



                Dim Estado = If(Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString()) = "0", True, False)

                Dim CodEstado As String = Trim(DGV_ListaEmpleado.Rows(0).Item("Estado").ToString())

                Class_VariablesGlobales.frmEmpleados.CambiaVisibilidadEmpleadoAnulado(Estado, CodEstado)
                Estado = Nothing
                Class_VariablesGlobales.frmEmpleados.Btn_Guardar.Text = "Actualizar"

                'If Class_VariablesGlobales.frmEmpleados.ChkB_Activo.Checked = True Then
                '    Class_VariablesGlobales.frmEmpleados.DTP_FechaSalida.Enabled = False
                'Else
                '    Class_VariablesGlobales.frmEmpleados.DTP_FechaSalida.Enabled = True
                '    Class_VariablesGlobales.frmEmpleados.DTP_FechaSalida.Value = Now.Date
                'End If

                Class_VariablesGlobales.frmEmpleados.CalculaTiempoLaborado()

                Dim Adjunto As Object = DGV_ListaEmpleado.Rows(0)("Foto")

                If Adjunto IsNot DBNull.Value Then
                    Try
                        Dim FotoEmpleadoBytes As Byte() = DirectCast(DGV_ListaEmpleado.Rows(0)("Foto"), Byte())

                        Class_VariablesGlobales.frmEmpleados.CargarAdjunto(FotoEmpleadoBytes, Class_VariablesGlobales.frmEmpleados.Txb_RutaImagen, Class_VariablesGlobales.frmEmpleados.PicBox_FotoEmpleado)

                    Catch ex As Exception

                    End Try
                Else
                    'TODO PONER UNA FOTO POR DEFECTO O LIMPIAR EL CONTROL DE LA FOTO
                    Class_VariablesGlobales.frmEmpleados.PicBox_FotoEmpleado.Image = My.Resources.SinFoto
                End If

                Class_VariablesGlobales.frmEmpleados.CalculaTaps()

                Me.Close()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function


End Class