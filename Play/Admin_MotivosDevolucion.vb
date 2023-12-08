Public Class Admin_MotivosDevolucion
    Private Sub Admin_MotivosDevolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_ListaMotivosDevolucion.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneMotivosDevolucion(Class_VariablesGlobales.SQL_Comman2)


        Dim Tbl As New DataTable
        Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBodegasDeSAP(Class_VariablesGlobales.SQL_Comman1)

        CBox_Bodegas.DataSource = Tbl
        CBox_Bodegas.DisplayMember = "Nombre"
        CBox_Bodegas.ValueMember = "Codigo"
        CBox_Bodegas.Text = "Seleccione una bodega"

        DGV_ListaMotivosDevolucion.Columns(0).Visible = False
        DGV_ListaMotivosDevolucion.Columns(1).Width = 150
        DGV_ListaMotivosDevolucion.Columns(2).Width = 50
    End Sub

    Private Sub DGV_ListaMotivosDevolucion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListaMotivosDevolucion.CellContentClick
        TxtBox_Codigo.Text = DGV_ListaMotivosDevolucion.Rows(e.RowIndex).Cells(0).Value
        TxtBox_Descripcion.Text = DGV_ListaMotivosDevolucion.Rows(e.RowIndex).Cells(1).Value
        CBox_Bodegas.SelectedValue = DGV_ListaMotivosDevolucion.Rows(e.RowIndex).Cells(2).Value


    End Sub

    Private Sub Btn_GuardarMotivoDevolucion_Click(sender As Object, e As EventArgs) Handles Btn_GuardarMotivoDevolucion.Click
        If TxtBox_Codigo.Text.Trim().Equals("") Then
            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaMotivoDevolucio(Class_VariablesGlobales.SQL_Comman1, TxtBox_Codigo.Text.Trim(), TxtBox_Descripcion.Text.Trim(), CBox_Bodegas.SelectedValue.Trim())
        Else
            Class_VariablesGlobales.Obj_Funciones_SQL.ModificaMotivoDevolucio(Class_VariablesGlobales.SQL_Comman1, TxtBox_Codigo.Text.Trim(), TxtBox_Descripcion.Text.Trim(), CBox_Bodegas.SelectedValue.Trim())
        End If
        limpiar()
    End Sub

    Private Sub limpiar()
        DGV_ListaMotivosDevolucion.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneMotivosDevolucion(Class_VariablesGlobales.SQL_Comman2)
        TxtBox_Codigo.Text = ""
        TxtBox_Descripcion.Text = ""
        CBox_Bodegas.Text = "Seleccione una bodega"
    End Sub

    Private Sub Btn_EliminarMotivoDevolucion_Click(sender As Object, e As EventArgs) Handles Btn_EliminarMotivoDevolucion.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaMotivoDevolucio(Class_VariablesGlobales.SQL_Comman1, TxtBox_Codigo.Text.Trim())
        limpiar()
    End Sub

    Private Sub Btn_NuevoMotivoDevolucion_Click(sender As Object, e As EventArgs) Handles Btn_NuevoMotivoDevolucion.Click
        limpiar()
    End Sub
End Class