Public Class Usuarios

    Private Sub Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Usuarios.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneUsuarios(Class_VariablesGlobales.SQL_Comman1)
        DGV_Usuarios.Columns("Password").Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click

        Dim Cambiar As String
        If cbx_Cambiar.Checked Then
            Cambiar = "1"
        Else
            Cambiar = "0"
        End If
        Class_VariablesGlobales.Obj_Funciones_SQL.INSERTA_Usuario(Class_VariablesGlobales.SQL_Comman1, txtb_Usuario.Text, txtb_Clave.Text, Cbx_Puestos.Text, txtb_Cedula.Text, txtb_Nombre.Text, Cambiar)
        Limpiar()

    End Sub



    Public Function Limpiar()
        txtb_Codigo.Text = ""
        txtb_Usuario.Text = ""
        txtb_Clave.Text = ""
        Cbx_Puestos.Text = ""
        txtb_Cedula.Text = ""
        txtb_Nombre.Text = ""

        txtb_Codigo.Enabled = False
        txtb_Usuario.Enabled = False
        txtb_Clave.Enabled = False
        Cbx_Puestos.Enabled = False
        txtb_Cedula.Enabled = False
        txtb_Nombre.Enabled = False
        btn_Guardar.Enabled = False
        btn_Modificar.Enabled = False
        Btn_Eliminar.Enabled = False

        cbx_Cambiar.Enabled = False
        cbx_Cambiar.Checked = False

        DGV_Usuarios.DataSource = New DataTable
        DGV_Usuarios.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneUsuarios(Class_VariablesGlobales.SQL_Comman1)
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Modificar.Click
        'ModificaUsuario(ByVal SQL_Comman As SqlCommand, ByVal Usuario As String, ByVal Password As String, ByVal Puesto As String, ByVal Cedula As String, ByVal Nombre As String, ByVal Codigo As String)

        Dim Cambiar As String
        If cbx_Cambiar.Checked Then
            Cambiar = "1"
        Else
            Cambiar = "0"
        End If

        Class_VariablesGlobales.Obj_Funciones_SQL.ModificaUsuario(Class_VariablesGlobales.SQL_Comman1, txtb_Usuario.Text, txtb_Clave.Text, Cbx_Puestos.Text, txtb_Cedula.Text, txtb_Nombre.Text, txtb_Codigo.Text, Cambiar)
        Limpiar()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Limpiar()
        txtb_Codigo.Enabled = True
        txtb_Usuario.Enabled = True
        txtb_Clave.Enabled = True
        Cbx_Puestos.Enabled = True
        txtb_Cedula.Enabled = True
        txtb_Nombre.Enabled = True
        cbx_Cambiar.Enabled = True
        btn_Guardar.Enabled = True
    End Sub

    Private Sub DGV_Usuarios_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Usuarios.CellClick
        btn_Modificar.Enabled = True
        Btn_Eliminar.Enabled = True


        txtb_Codigo.Text = DGV_Usuarios.Item(0, DGV_Usuarios.CurrentRow.Index).Value.ToString()
        txtb_Cedula.Text = DGV_Usuarios.Item(1, DGV_Usuarios.CurrentRow.Index).Value.ToString()
        txtb_Nombre.Text = DGV_Usuarios.Item(2, DGV_Usuarios.CurrentRow.Index).Value.ToString()
        Cbx_Puestos.Text = DGV_Usuarios.Item(3, DGV_Usuarios.CurrentRow.Index).Value.ToString()
        txtb_Usuario.Text = DGV_Usuarios.Item(4, DGV_Usuarios.CurrentRow.Index).Value.ToString()
        txtb_Clave.Text = DGV_Usuarios.Item(5, DGV_Usuarios.CurrentRow.Index).Value.ToString()


        txtb_Codigo.Enabled = True
        txtb_Cedula.Enabled = True
        txtb_Nombre.Enabled = True
        Cbx_Puestos.Enabled = True
        txtb_Usuario.Enabled = True
        txtb_Clave.Enabled = True
    End Sub
End Class