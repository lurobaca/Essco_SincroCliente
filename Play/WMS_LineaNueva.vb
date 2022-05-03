Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices

Public Class WMS_LineaNueva
    Private Sub WMS_LineaNueva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_LineasNuevas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLineasNuevas(Class_VariablesGlobales.SQL_Comman1)

    End Sub

    Private Sub DGV_LineasNuevas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_LineasNuevas.CellContentClick
        'Al selecciona la linea nueva se colocara la informacion en los campos del formularios Stock_Manager para que desde este modulo se agrguen los campos faltantes y luego solo se le de crear en SAP
        Class_VariablesGlobales.frmStock_Manager = New Stock_Manager
        Class_VariablesGlobales.frmStock_Manager.MdiParent = Principal



        '[Id],[ItemCode],[ItemName],[Pack],[Alterno],[UnitPrice],[FechaVence],[CodBarras],[Gramage]
        Class_VariablesGlobales.frmStock_Manager.lbl_LineaNueva.Text = "SI"
        Class_VariablesGlobales.frmStock_Manager.Txtb_IdArticuloNuevo.Text = DGV_LineasNuevas.CurrentRow.Cells.Item(0).Value
        Class_VariablesGlobales.frmStock_Manager.txtb_Descripcion.Text = DGV_LineasNuevas.CurrentRow.Cells.Item(2).Value
        Class_VariablesGlobales.frmStock_Manager.txtb_Empaque.Text = DGV_LineasNuevas.CurrentRow.Cells.Item(3).Value
        Class_VariablesGlobales.frmStock_Manager.txtb_CodAlterno.Text = DGV_LineasNuevas.CurrentRow.Cells.Item(4).Value
        Class_VariablesGlobales.frmStock_Manager.txtb_PrecioCosto.Text = DGV_LineasNuevas.CurrentRow.Cells.Item(5).Value
        Class_VariablesGlobales.frmStock_Manager.txtb_CodBarras.Text = DGV_LineasNuevas.CurrentRow.Cells.Item(7).Value
        Class_VariablesGlobales.frmStock_Manager.Txtb_Gramos.Text = DGV_LineasNuevas.CurrentRow.Cells.Item(8).Value



        Class_VariablesGlobales.frmStock_Manager.Show()

        Me.Close()

    End Sub
End Class