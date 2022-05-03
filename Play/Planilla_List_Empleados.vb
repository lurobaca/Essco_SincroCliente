Imports System.Net.WebRequestMethods
Imports System.IO



Public Class Planilla_List_Empleados

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
        DGV_ListaEmpleado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.BuscaEmpleado(Txb_Nombre.Text, "Nombre", Class_VariablesGlobales.SQL_Comman2)

    End Sub

    Private Sub Txb_Cedula_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Cedula.TextChanged
        DGV_ListaEmpleado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.BuscaEmpleado(Txb_Cedula.Text, "Cedula", Class_VariablesGlobales.SQL_Comman2)
    End Sub

    Private Sub List_Empleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_ListaEmpleado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.BuscaEmpleado(Txb_Nombre.Text, "", Class_VariablesGlobales.SQL_Comman2)
    End Sub

    Private Sub DGV_ListaEmpleado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_ListaEmpleado.CellContentClick
        Navegar(DGV_ListaEmpleado.DataSource)
    End Sub
    Public Function Navegar(ByVal DGV_ListaEmpleado As DataTable)

        For Each row As DataRow In DGV_ListaEmpleado.Rows

            Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Cedula").ToString())
            Class_VariablesGlobales.frmEmpleados.Txb_Nombre.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Nombre").ToString())
            Class_VariablesGlobales.frmEmpleados.Txb_Telefono1.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Telefono1").ToString())
            Class_VariablesGlobales.frmEmpleados.Txb_Telefono2.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Telefono2").ToString())
            Class_VariablesGlobales.frmEmpleados.CBox_Puesto.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Puesto").ToString())
            Class_VariablesGlobales.frmEmpleados.Txb_Salario.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Salario").ToString())
            Class_VariablesGlobales.frmEmpleados.DTP_FechaIngreso.Value = Trim(DGV_ListaEmpleado.Rows(0).Item("FechaIngreso").ToString())
            Class_VariablesGlobales.frmEmpleados.DTP_FechaSalida.Value = Trim(DGV_ListaEmpleado.Rows(0).Item("FechaFin").ToString())
            Class_VariablesGlobales.frmEmpleados.Txt_Id.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("id").ToString())
            'Class_VariablesGlobales.frmEmpleados.Txtb_CodRuta.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("CodRuta").ToString())
            Class_VariablesGlobales.frmEmpleados.txtb_Correo.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Correo").ToString())


            Dim Tiempo As Integer = DateDiff(DateInterval.Day, Class_VariablesGlobales.frmEmpleados.DTP_FechaIngreso.Value, Class_VariablesGlobales.frmEmpleados.DTP_FechaSalida.Value)
            Dim anos As Integer = Math.Floor(Tiempo / 365)
            Dim DiaRestante As Integer = Tiempo - (anos * 365)
            Dim meses As Integer = Math.Floor(DiaRestante / 30)
            DiaRestante = DiaRestante - (meses * 30)
            Dim dias As Integer = DiaRestante
            Class_VariablesGlobales.frmEmpleados.txtb_Anos.Text = anos
            Class_VariablesGlobales.frmEmpleados.txtb_Meses.Text = meses
            Class_VariablesGlobales.frmEmpleados.txtb_Dias.Text = DiaRestante


            Dim DiasVacaciones As Integer
            If meses > 1 Then
                DiasVacaciones = meses * 1
            End If

            If anos > 1 Then
                DiasVacaciones += anos * 14
            End If

            Class_VariablesGlobales.frmEmpleados.txtb_Vacaciones.Text = DiasVacaciones

            If Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString()) <> "" Then
                If IO.File.Exists(Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString())) <> "" Then
                    Class_VariablesGlobales.frmEmpleados.Txb_RutaImagen.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString())
                    Class_VariablesGlobales.frmEmpleados.PictureBox1.Image = Image.FromFile(Trim(DGV_ListaEmpleado.Rows(0).Item("Foto").ToString()))
                Else
                    Class_VariablesGlobales.frmEmpleados.PictureBox1.Image = Image.FromFile(Class_VariablesGlobales.RutaFotosPlanilla & "SinFoto.png")
                End If
            End If

            If Trim(DGV_ListaEmpleado.Rows(0).Item("Activo").ToString()) = "True" Then
                Class_VariablesGlobales.frmEmpleados.ChkB_Activo.Checked = True

            Else
                Class_VariablesGlobales.frmEmpleados.ChkB_Activo.Checked = False

            End If

            Class_VariablesGlobales.frmEmpleados.DTGV_Experiencia.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneExperiencia(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)
            Class_VariablesGlobales.frmEmpleados.DTGV_Educacion.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneEducacion(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)

            Class_VariablesGlobales.frmEmpleados.DGV_Deducciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDeducciones(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)

            Class_VariablesGlobales.frmEmpleados.Btn_Guardar.Text = "Actualizar"
            Class_VariablesGlobales.frmEmpleados.Txb_Codigo.Text = Trim(DGV_ListaEmpleado.Rows(0).Item("Codigo").ToString())
            Class_VariablesGlobales.frmEmpleados.DGV_Facturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtineFacturas(Class_VariablesGlobales.frmEmpleados.Txb_Codigo.Text, Class_VariablesGlobales.SQL_Comman2)

            Class_VariablesGlobales.frmEmpleados.DGV_VacacionesConsumidas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneVacacionesConsumidas(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.SQL_Comman2)

            If Class_VariablesGlobales.frmEmpleados.txtb_Vacaciones.Text <> "" And Class_VariablesGlobales.frmEmpleados.txtb_VCTotal.Text <> "" Then
                Class_VariablesGlobales.frmEmpleados.txtb_Pendientes.Text = CInt(Class_VariablesGlobales.frmEmpleados.txtb_Vacaciones.Text) - CInt(Class_VariablesGlobales.frmEmpleados.txtb_VCTotal.Text)
            End If

            Class_VariablesGlobales.frmEmpleados.Txb_Dedu_CCSS.Text = (CDbl(Class_VariablesGlobales.frmEmpleados.Txb_Salario.Text) * 9.34) / 100


            Me.Close()

        Next
        'Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text = DGV_ListaEmpleado.CurrentRow.Cells.Item(0).Value.ToString
    End Function
End Class