Public Class EditaRepCarga

    Private Sub EditaRepCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'bloquea la modificacion si un reporte esta anualdo
        If Class_VariablesGlobales.Obj_RepDCar.Lb_lAnulado.Visible = True Or Class_VariablesGlobales.Obj_RepDCar.Lb_Cerrado.Visible = True Then
            btn_Modificar.Enabled = False
        Else
            btn_Modificar.Enabled = True
        End If



        Dim tabla As New DataTable
        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.BuscaArticulo(Class_VariablesGlobales.CodArti, Class_VariablesGlobales.ConseRepCarga, Class_VariablesGlobales.SQL_Comman1)

        Txb_CodArti.Text = tabla.Rows(0).Item("ItemCode").ToString()
        Txb_Descripcion.Text = tabla.Rows(0).Item("Descripcion").ToString()
        Txb_Solicitado.Text = tabla.Rows(0).Item("Cantidad").ToString()





        txtb_SacadoX.Text = tabla.Rows(0).Item("Bodeguero").ToString()
        txtb_CheadoX.Text = tabla.Rows(0).Item("Chequeador").ToString()


        If tabla.Rows(0).Item("Sacado_Bodeguero").ToString() = "" Then
            txtb_Sacado.Text = "0"
        Else
            txtb_Sacado.Text = tabla.Rows(0).Item("Sacado_Bodeguero").ToString()
        End If

        If tabla.Rows(0).Item("Sacado_Chequeador").ToString() = "" Then
            txtb_ChSacado.Text = "0"
        Else
            txtb_ChSacado.Text = tabla.Rows(0).Item("Sacado_Chequeador").ToString()
        End If

        'Dim Unidades_x_Caja = tabla.Rows(0).Item("Unidades_x_Caja").ToString()
        'Dim Cajas As Double = CDbl(Txb_Solicitado.Text.Trim) / CDbl(Unidades_x_Caja.Trim)
        'Txb_Cj.Text = Math.Floor(Cajas)
        'Txb_Unidades.Text = CDbl(Txb_Solicitado.Text) - CDbl(Unidades_x_Caja)

        '------------------------------
        Dim TotalCajas As Integer
        Dim TotalUnidades As Integer
        Dim Cajas2 As String

        Dim UnidSoliAs As Integer
        Dim UnidXCjAs As Integer
        Dim Unidades As Double
        Dim valor As Double
        Dim UnidSoli2 As Double
        Dim UnidXCj2 As Double
        Dim UnidSoli As Integer
        Dim UnidXCj As Integer
        Dim Cajasdouble As Double
        Dim UnidadesSolicitadas As String = tabla.Rows(0).Item("Cantidad").ToString()
        Dim UnidXCaja As String = tabla.Rows(0).Item("Unidades_x_Caja").ToString()

        valor = CDbl(UnidadesSolicitadas) / CDbl(UnidXCaja)

        UnidSoli = CInt(UnidadesSolicitadas)
        UnidXCj = CInt(UnidXCaja)
        'obtien las cajas como numero entero
        TotalCajas = Math.Floor(UnidSoli / UnidXCj)
        'obtiene las cajas como numero con decimales
        UnidSoli2 = CDbl(UnidadesSolicitadas)
        UnidXCj2 = CDbl(UnidXCaja)
        valor = UnidSoli2 / UnidXCj2
        'combierte las cajas a numero double
        Cajasdouble = CDbl(TotalCajas)


        Unidades = (valor - Cajasdouble) * UnidXCj
        TotalUnidades = Math.Floor(Unidades)

        Txb_Cj.Text = TotalCajas
        Txb_Unidades.Text = TotalUnidades
        '-----------------------------------------------------------------------
        If tabla.Rows(0).Item("Faltante").ToString() = "" Then
            Txb_FaltanteBodeguero.Text = "0"
        Else
            Txb_FaltanteBodeguero.Text = tabla.Rows(0).Item("Faltante").ToString()
        End If


        cbx_MotivoBodeguero.Text = tabla.Rows(0).Item("Motivo").ToString()


        If tabla.Rows(0).Item("Faltante_Chequeador").ToString() = "" Then
            Txb_FaltanteChequeador.Text = "0"
        Else
            Txb_FaltanteChequeador.Text = tabla.Rows(0).Item("Faltante_Chequeador").ToString()
        End If



        cbx_MotivoChequeador.Text = tabla.Rows(0).Item("Motivo_Chequeador").ToString()


        If txtb_Sacado.Text = "0" Or txtb_ChSacado.Text = "0" Then
            btn_Modificar.Enabled = False


        End If



    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Salir.Click
        Me.Close()

    End Sub

    Private Sub btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Modificar.Click


        If Trim(txtb_ChSacado.Text) = "" Then
            txtb_ChSacado.Text = "0"
        End If
        If Trim(Txb_FaltanteChequeador.Text) = "" Then
            Txb_FaltanteChequeador.Text = "0"
        End If

        If Trim(txtb_Sacado.Text) = "" Then
            txtb_Sacado.Text = "0"
        End If
        If Trim(Txb_FaltanteBodeguero.Text) = "" Then
            Txb_FaltanteBodeguero.Text = "0"
        End If



        Dim Actualizar As Boolean = True

        If CInt(Trim(txtb_Sacado.Text)) > 0 Or CInt(Trim(Txb_FaltanteBodeguero.Text)) > 0 Then
            If (CInt(Trim(txtb_Sacado.Text)) + CInt(Trim(Txb_FaltanteBodeguero.Text))) <> CInt(Trim(Txb_Solicitado.Text)) Then
                Actualizar = True
                MsgBox("Verifique que lo sacado mas lo faltante del bodeguero sea igual  a lo solicitado", MsgBoxStyle.Critical, "Error de calculo")
            End If
        End If

        If CInt(Trim(txtb_ChSacado.Text)) > 0 Or CInt(Trim(Txb_FaltanteChequeador.Text)) > 0 Then
            If (CInt(Trim(txtb_ChSacado.Text)) + CInt(Trim(Txb_FaltanteChequeador.Text))) <> CInt(Trim(Txb_Solicitado.Text)) Then
                Actualizar = True
                MsgBox("Verifique que lo sacado mas lo faltante del Chequeador sea igual  a lo solicitado", MsgBoxStyle.Critical, "Error de calculo")
            End If
        End If



        If Txb_FaltanteChequeador.Text = "" Or Txb_FaltanteChequeador.Text = "0" Then
            cbx_MotivoChequeador.Text = ""
        End If

        If Txb_FaltanteBodeguero.Text = "" Or Txb_FaltanteBodeguero.Text = "0" Then
            cbx_MotivoBodeguero.Text = ""
        End If

        If Txb_FaltanteChequeador.Text <> "0" And cbx_MotivoChequeador.Text = "" Then
            MessageBox.Show("Debe indicar un motivo")
            cbx_MotivoChequeador.Focus()
            Actualizar = False

        End If


        If Txb_FaltanteBodeguero.Text <> "0" And cbx_MotivoBodeguero.Text = "" Then
            MessageBox.Show("Debe indicar un motivo")
            cbx_MotivoBodeguero.Focus()
            Actualizar = False
        End If



        If Actualizar = True Then



            'verifica que la suma de la cantidad mas el faltante den igual a lo solicitado
            'if CInt(Txb_Solicitado.Text)=
            '    CInt(Txb_FaltanteBodeguero.Text)
            '    CInt(Txb_FaltanteChequeador.Text)

            Class_VariablesGlobales.Obj_Funciones_SQL.ActualizarLineRepCarga(Class_VariablesGlobales.ConseRepCarga, Txb_CodArti.Text, Txb_Descripcion.Text, Txb_Solicitado.Text, Txb_FaltanteBodeguero.Text, cbx_MotivoBodeguero.Text, Txb_FaltanteChequeador.Text, cbx_MotivoChequeador.Text, txtb_ChSacado.Text, txtb_Sacado.Text, Class_VariablesGlobales.SQL_Comman1)

            Dim tabla As New DataTable
            Dim cont As Integer
            Dim Total As Double


            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("TODO", "0", Class_VariablesGlobales.ConseRepCarga, Class_VariablesGlobales.SQL_Comman1, "")

            For Each rowLocal As DataRow In tabla.Rows
                Total += CDbl(tabla.Rows(cont).Item("Total").ToString())

                cont += 1
            Next


            Class_VariablesGlobales.Obj_RepDCar.Cbx_Rutas.Text = tabla.Rows(0).Item("Ruta").ToString()
            Class_VariablesGlobales.Obj_RepDCar.dtp_FechaReporte.Text = tabla.Rows(0).Item("Fecha").ToString()
            Class_VariablesGlobales.Obj_RepDCar.TXB_Hora.Text = tabla.Rows(0).Item("Hora").ToString()
            Class_VariablesGlobales.Obj_RepDCar.txtb_FACINI.Text = tabla.Rows(0).Item("FacINI").ToString()
            Class_VariablesGlobales.Obj_RepDCar.txtb_FACFIN.Text = tabla.Rows(0).Item("FacFIN").ToString()

            Class_VariablesGlobales.Obj_RepDCar.lbl_TotalRuta.Text = Format(Val(Total), "currency")
            Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.DataSource = tabla
            Class_VariablesGlobales.Obj_RepDCar.txtb_FACINI.Enabled = False
            Class_VariablesGlobales.Obj_RepDCar.txtb_FACFIN.Enabled = False
            Class_VariablesGlobales.Obj_RepDCar.Cbx_Rutas.Enabled = False
            Class_VariablesGlobales.Obj_RepDCar.btn_cerrar.Visible = True

            If tabla.Rows(0).Item("Cerrado").ToString() = "1" Then
                Class_VariablesGlobales.Obj_RepDCar.btn_cerrar.Text = "CERRADO"
            Else
                Class_VariablesGlobales.Obj_RepDCar.btn_cerrar.Text = "CERRAR"
            End If



            Class_VariablesGlobales.Obj_ChequearRepCarga.Dtg_Chequeado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.LineaRepCachequeado(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.CheqRC_Consecutivo)
            Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalChequeo.Text = Format(Val(Class_VariablesGlobales.Obj_Funciones_SQL.SumaChequeadoRepCarga(Class_VariablesGlobales.CheqRC_Consecutivo, Class_VariablesGlobales.SQL_Comman2)), "currency")


            Dim TChequeado As Double = CDbl(Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalChequeo.Text)


            Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_Diferencia.Text = Format(Val(CDbl(Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalRuta.Text) - TChequeado), "currency")



            Me.Close()
        End If
    End Sub


    Private Sub Txb_FaltanteBodeguero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_FaltanteBodeguero.Leave
        txtb_Sacado.Text = CInt(Trim(Txb_Solicitado.Text)) - CInt(Trim(Txb_FaltanteBodeguero.Text))
    End Sub

    Private Sub Txb_FaltanteChequeador_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_FaltanteChequeador.Leave
        txtb_ChSacado.Text = CInt(Trim(Txb_Solicitado.Text)) - CInt(Trim(Txb_FaltanteChequeador.Text))
    End Sub
End Class