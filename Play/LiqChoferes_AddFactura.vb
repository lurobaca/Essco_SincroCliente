Public Class LiqChoferes_AddFactura

  

    Private Sub LiqChoferes_AddFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'obtendra las facturas de credito del reporte de carga segun el rango de fecha y codigo de chofer
        'Obj_Funciones_SQL.ObtieneFacturas()


        Cargar()
    End Sub

    Public Function Cargar()
        Dgv_FacCredito.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFacturas(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), "CREDITO", Class_VariablesGlobales.NumLiqui_Chofer, Class_VariablesGlobales.frmLiqChof.ListV_Reportes)
        Dgv_FacContado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFacturas(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), "CONTADO", Class_VariablesGlobales.NumLiqui_Chofer, Class_VariablesGlobales.frmLiqChof.ListV_Reportes)
        txtb_Factura.Text = ""
        txtb_Factura.Focus()
    End Function


    'Private Sub BTN_CredToCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CredToCont.Click

    '    'si no esta creando una liq nueva esto quiere decir que esta editando una vieja por lo que cuando agregue el numero ed factura debera agregar el numero de liquidacion a la factura
    '    If Class_VariablesGlobales.CREANDO_LIQ_CHOFER = False Then


    '        Obj_Funciones_SQL.MostraFacturaEnLiq(Dgv_FacCredito.CurrentRow.Cells.Item(0).Value(), "1", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value), Class_VariablesGlobales.frmLiqChof.Txtb_RepFactura.Text, Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, Class_VariablesGlobales.SQL_Comman1)
    '    Else
    '        Obj_Funciones_SQL.MostraFacturaEnLiq(Dgv_FacCredito.CurrentRow.Cells.Item(0).Value(), "1", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value), Class_VariablesGlobales.frmLiqChof.Txtb_RepFactura.Text, "", Class_VariablesGlobales.SQL_Comman1)
    '    End If
    'End Sub

    'Private Sub BTN_ContToCred_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_ContToCred.Click
    '    Obj_Funciones_SQL.MostraFacturaEnLiq(Dgv_FacCredito.CurrentRow.Cells.Item(0).Value(), "0", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value), Class_VariablesGlobales.frmLiqChof.Txtb_RepFactura.Text, Class_VariablesGlobales.SQL_Comman1)
    'End Sub

    'Private Sub btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Agregar.Click
    '    Obj_Funciones_SQL.MostraFacturaEnLiq(Trim(txtb_Factura.Text), "1", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value), Class_VariablesGlobales.frmLiqChof.Txtb_RepFactura.Text, Class_VariablesGlobales.SQL_Comman1)
    '    'Mueve la factura de un reporte de carga viejo a otro nuevo

    '    Cargar()
    'End Sub

    Private Sub btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Eliminar.Click

        Class_VariablesGlobales.Obj_Funciones_SQL.MostraFacturaEnLiq(Trim(txtb_Factura.Text), "0", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value), "", "", Class_VariablesGlobales.SQL_Comman1)
        Cargar()
    End Sub

    Private Sub Dgv_FacContado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_FacContado.CellContentClick
        txtb_Factura.Text = Dgv_FacContado.CurrentRow.Cells.Item(0).Value()
    End Sub

    Private Sub LiqChoferes_AddFactura_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Class_VariablesGlobales.frmLiqChof.Cargar()

    End Sub

    Private Sub txtb_Factura_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Factura.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True

            AddFactura()



        End If

    End Sub




    Public Function AddFactura()

        Dim TABLA As New DataTable

        TABLA = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNumLiq(txtb_Factura.Text, Class_VariablesGlobales.SQL_Comman1)

        Dim Consecutivo As String
        Dim Liquidacion As String

        If TABLA.Rows.Count > 0 Then
            Dim cont As Integer = 0

            For Each rowLocal As DataRow In TABLA.Rows

                If TABLA.Rows(0).Item("NumLiq").ToString() <> "" Then
                    If cont > 0 Then
                        Liquidacion = Liquidacion & " , " & TABLA.Rows(cont).Item("NumLiq").ToString()
                    Else
                        Liquidacion = Liquidacion & TABLA.Rows(cont).Item("NumLiq").ToString()
                    End If


                    If cont > 0 Then
                        Consecutivo = Consecutivo & " , " & TABLA.Rows(cont).Item("Consecutivo").ToString()
                    Else
                        Consecutivo = Consecutivo & TABLA.Rows(cont).Item("Consecutivo").ToString()
                    End If
                End If
                cont += 1
            Next

            If cont = 1 Then
                'Mueve la factura de un reporte de carga viejo a otro nuevo
                'If Class_VariablesGlobales.CREANDO_LIQ_CHOFER = False Then
                Class_VariablesGlobales.Obj_Funciones_SQL.MostraFacturaEnLiq(txtb_Factura.Text, "1", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value), Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text, Class_VariablesGlobales.SQL_Comman1)
                'Else
                '    Obj_Funciones_SQL.MostraFacturaEnLiq(txtb_Factura.Text, "1", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value), "", Class_VariablesGlobales.SQL_Comman1)
                'End If

                Cargar()
            Else
                MsgBox("La factura aparese en las Liquidacion [" & Liquidacion & "] y en el reporte [" & Consecutivo & "] Verifique y anule alguno de los 2 reportes")
            End If



        End If

    End Function


    Private Sub btn_Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Agregar.Click
        AddFactura()
    End Sub

   
End Class