Public Class ReporteDeDevoluciones_Corregir

    Private Sub ReporteDeDevoluciones_Corregir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tctb_Codigo.Text = Class_VariablesGlobales.Desv_ItemCode

        txtb_Descripcion.Text = Class_VariablesGlobales.Desv_Descripcion
        txtb_Origen.Text = Class_VariablesGlobales.Desv_BodegaOrigen
        txtb_cantidad.Text = Class_VariablesGlobales.Desv_Cantidad
        cbx_Accion.Text = Class_VariablesGlobales.Desv_Accion

        If Class_VariablesGlobales.Desv_Accion = "CAMBIADO" Or Class_VariablesGlobales.Desv_Accion = "TRASLADO" Then
            txtb_cantidadMover.Enabled = True
            txtb_CodDestino.Enabled = True
            cbx_BodDestino.Enabled = True
        Else
            txtb_cantidadMover.Enabled = False
            txtb_CodDestino.Enabled = False
            cbx_BodDestino.Enabled = False
        End If



        txtb_cantidadMover.Text = Class_VariablesGlobales.Desv_CantMover
        txtb_CodDestino.Text = Class_VariablesGlobales.Desv_CodigoDestino
        cbx_BodDestino.Text = Class_VariablesGlobales.Desv_BodegaDestino


        'Completo()
        'M02-Facturado de mas
        'M99-Falta por chequear
        'M10-Producto Danado
        'M11-Producto Cambiado
        'M12-Faltante en bodega
        'M14-No salio de bodega
        'M20-Pronto a vencer
        'Otros()
        If Class_VariablesGlobales.Desv_BodegaDestino = "" Then

        End If


    End Sub

    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click




        Class_VariablesGlobales.Obj_Funciones_SQL.ModifRepDev(Class_VariablesGlobales.Obj_RepDevoluciones.txb_Numero.Text, tctb_Codigo.Text, txtb_Descripcion.Text, txtb_Origen.Text, txtb_cantidad.Text, cbx_Accion.Text, txtb_cantidadMover.Text, txtb_CodDestino.Text, cbx_BodDestino.Text, txtb_Origen.Text, Class_VariablesGlobales.SQL_Comman2)
        Class_VariablesGlobales.Obj_RepDevoluciones.Navegar(CInt(Class_VariablesGlobales.Obj_RepDevoluciones.txb_Numero.Text))
        Me.Close()

    End Sub

    Private Sub btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Buscar.Click
        ListaLineasInventario.Show()


    End Sub
End Class