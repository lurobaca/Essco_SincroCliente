Imports System.Data.SqlClient

Public Class BuscaFactura
    Dim TABLA As New DataTable
    Public Objt_GlobalVar As Class_VariablesGlobales


    Private Sub BuscaFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Objt_GlobalVar = New Class_VariablesGlobales
    End Sub


    Private Sub btn_BuscaAgente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaAgente.Click


        TABLA = Objt_GlobalVar.Obj_Funciones_SQL.ObtieneNumLiq(txtb_NumFactura.Text, Class_VariablesGlobales.SQL_Comman1)

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
                txtb_NumLiq.Text = CInt(TABLA.Rows(0).Item("NumLiq").ToString())
                txtb_IdReporte.Text = CInt(TABLA.Rows(0).Item("Consecutivo").ToString())
            Else
                MsgBox("La factura aparese en las Liquidacion [" & Liquidacion & "] y en el reporte [" & Consecutivo & "] Verifique y anule alguno de los 2 reportes")
            End If





        Else
            MsgBox("La factura no se encontro")
        End If
    End Sub

    Private Sub btn_GoToLiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GoToLiq.Click
        'obtendra los datos del numero de loquidacion y cargara los campos de la ventana de liquidacion de chofer


        Class_VariablesGlobales.LIQUIDANDO = "CHOFERES"
        Class_VariablesGlobales.frmLiqChof = New Liquidacion_Choferes
        Class_VariablesGlobales.frmLiqChof.MdiParent = Principal
        Class_VariablesGlobales.frmLiqChof.Show()
        Class_VariablesGlobales.frmLiqChof.Navegar(txtb_NumLiq.Text)

        ListaChoferes.Close()

        Me.Close()



    End Sub




    Private Sub txtb_NumLiq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_NumLiq.TextChanged
        btn_GoToLiq.Enabled = True


    End Sub

    Private Sub btn_GoReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GoReporte.Click
        Class_VariablesGlobales.Obj_Reporte_Facturas = New Reporte_Facturas
        Class_VariablesGlobales.Obj_Reporte_Facturas.MdiParent = Principal
        Class_VariablesGlobales.Obj_Reporte_Facturas.Show()

        Class_VariablesGlobales.Conse_Repcarga = txtb_IdReporte.Text
        CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.Conse_Repcarga)
        Me.Close()
    End Sub


    Private Sub txtb_IdReporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_IdReporte.TextChanged
        btn_GoReporte.Enabled = True
    End Sub

    Public Function CargaDetRepFacturas(ByVal SQL_Comman As SqlCommand, ByVal Conse_RepFacturas As String)
        Dim tabla As New DataTable
        Dim cont As Integer
        Dim TotalFaltante As Double
        Dim TotalPeso As Double
        Dim Total As Double
        Dim TotalGeneral As Double
        Dim Anulado As Boolean = False
        Dim Tipo As String = "CONTADO"

        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaDetRepFacturas(SQL_Comman, Conse_RepFacturas, Tipo)

        If tabla.Rows.Count > 0 Then
            For Each rowLocal As DataRow In tabla.Rows

                Total += CDbl(tabla.Rows(cont).Item("Total").ToString())
                'TotalGeneral += CDbl(tabla.Rows(cont).Item("DocTotal").ToString())
                cont += 1
            Next

            TotalGeneral += Total


            Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text = tabla.Rows(0).Item("Consecutivo").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Text = tabla.Rows(0).Item("NombreRuta").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Text = tabla.Rows(0).Item("FechaReporte").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Text = tabla.Rows(0).Item("Hora").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Text = tabla.Rows(0).Item("Fac_INI").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Text = tabla.Rows(0).Item("Fac_FIN").ToString()
            'Class_VariablesGlobales.Obj_Reporte_Facturas.lbl_Total.Text = Format(Val(Total), "currency")

            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalContado.Text = Format(Val(Total), "currency")

            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = False

            Dim Tbl As New DataTable
            Dim Chofer As String = ""
            If tabla.Rows(0).Item("Chofer").ToString() <> "" Then
                Chofer = tabla.Rows(0).Item("Chofer").ToString()
            End If

            'Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "CHOFER", Chofer)
            Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "CHOFER", Chofer)

            cont = 0
            For Each rowLocal As DataRow In Tbl.Rows
                If tabla.Rows(0).Item("Chofer").ToString() = Tbl.Rows(cont).Item("CodChofer").ToString() Then
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Text = Tbl.Rows(cont).Item("Nombre").ToString()
                End If
                cont += 1
            Next
            Chofer = Nothing

            Dim Ayudante As String = ""
            If tabla.Rows(0).Item("Ayudante").ToString() <> "Seleccione un Ayudante" Then
                Ayudante = tabla.Rows(0).Item("Ayudante").ToString()
            End If

            Tbl = New DataTable
            'Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "AYUDANTE", Ayudante)
            Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "AYUDANTE", Ayudante)
            cont = 0

            For Each rowLocal As DataRow In Tbl.Rows
                If tabla.Rows(0).Item("Chofer").ToString() = Tbl.Rows(cont).Item("CodChofer").ToString() Then
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Ayuda.Text = tabla.Rows(0).Item("Ayudante").ToString() = Tbl.Rows(cont).Item("Nombre").ToString()
                End If
                cont += 1
            Next
            Ayudante = Nothing

            Dim ConB1 As String = tabla.Rows(0).Item("ConB1").ToString()
            If ConB1 = "1" Then
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Checked = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Checked = True
            Else
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Checked = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Checked = False
            End If

            '[Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante]  

            If Tipo = "CONTADO" Then
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.DataSource = tabla
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(1).Width = 50
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(2).Width = 70
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(3).Width = 65
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(4).Width = 75
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(5).Width = 65
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(6).Width = 300
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(0).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(7).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(8).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(9).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(10).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(11).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(12).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(13).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(14).Visible = False
            End If

            If tabla.Rows(0).Item("Anulado").ToString() = "1" Then
                Anulado = True
            Else
                Anulado = False
            End If
        End If

        '***************************************************************************************************************

        Tipo = "CREDITO"
        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaDetRepFacturas(SQL_Comman, Conse_RepFacturas, Tipo)

        If tabla.Rows.Count > 0 Then
            Total = 0
            For Each rowLocal As DataRow In tabla.Rows

                Total += CDbl(tabla.Rows(cont).Item("Total").ToString())
                cont += 1
            Next

            TotalGeneral += Total


            Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text = tabla.Rows(0).Item("Consecutivo").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Text = tabla.Rows(0).Item("NombreRuta").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Text = tabla.Rows(0).Item("FechaReporte").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Text = tabla.Rows(0).Item("Hora").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Text = tabla.Rows(0).Item("Fac_INI").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Text = tabla.Rows(0).Item("Fac_FIN").ToString()
            'Class_VariablesGlobales.Obj_Reporte_Facturas.lbl_Total.Text = Format(Val(Total), "currency")

            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Text = Format(Val(Total), "currency")

            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = False

            Dim Tbl As New DataTable
            Dim Chofer As String = ""
            If tabla.Rows(0).Item("Chofer").ToString() <> "" Then
                Chofer = tabla.Rows(0).Item("Chofer").ToString()
            End If
            Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "CHOFER", Chofer)
            'Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "CHOFER", Chofer)

            cont = 0
            For Each rowLocal As DataRow In Tbl.Rows
                If tabla.Rows(0).Item("Chofer").ToString() = Tbl.Rows(cont).Item("CodChofer").ToString() Then
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Text = Tbl.Rows(cont).Item("Nombre").ToString()
                End If
                cont += 1
            Next
            Chofer = Nothing

            Dim Ayudante As String = ""
            If tabla.Rows(0).Item("Ayudante").ToString() <> "Seleccione un Ayudante" Then
                Ayudante = tabla.Rows(0).Item("Ayudante").ToString()
            End If

            Tbl = New DataTable
            ' Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "AYUDANTE", Ayudante)
            Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "AYUDANTE", Chofer)
            cont = 0

            For Each rowLocal As DataRow In Tbl.Rows
                If tabla.Rows(0).Item("Chofer").ToString() = Tbl.Rows(cont).Item("CodChofer").ToString() Then
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Ayuda.Text = tabla.Rows(0).Item("Ayudante").ToString() = Tbl.Rows(cont).Item("Nombre").ToString()
                End If
                cont += 1
            Next
            Ayudante = Nothing

            Dim ConB1 As String = tabla.Rows(0).Item("ConB1").ToString()
            If ConB1 = "1" Then
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Checked = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Checked = True
            Else
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Checked = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Checked = False
            End If









            If Tipo = "CREDITO" Then
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.DataSource = tabla
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(1).Width = 50
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(2).Width = 70
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(3).Width = 65
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(4).Width = 75
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(5).Width = 65
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(6).Width = 300
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(0).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(7).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(8).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(9).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(10).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(11).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(12).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(13).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(14).Visible = False
            End If


            If tabla.Rows(0).Item("Anulado").ToString() = "1" Then
                Anulado = True
            Else
                Anulado = False
            End If
        End If


        If Anulado = True Then
            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = False

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_eliminar.Visible = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Lbl_Anulado.Visible = True

            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = False
            'Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalContado.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Ayuda.Enabled = False
            'Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = False




        Else

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_eliminar.Visible = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Lbl_Anulado.Visible = False

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = True

            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Enabled = True


            Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = True
            'Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalContado.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Ayuda.Enabled = True
            'Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = True

        End If




        Class_VariablesGlobales.Obj_Reporte_Facturas.lbl_Total.Text = Format(Val(TotalGeneral), "currency")
        TotalGeneral = 0

        Me.Close()




    End Function

    Private Sub txtb_NumFactura_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_NumFactura.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True

            TABLA = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNumLiq(txtb_NumFactura.Text, Class_VariablesGlobales.SQL_Comman1)

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
                    txtb_NumLiq.Text = CInt(TABLA.Rows(0).Item("NumLiq").ToString())
                    txtb_IdReporte.Text = CInt(TABLA.Rows(0).Item("Consecutivo").ToString())
                Else
                    MsgBox("La factura aparese en las Liquidacion [" & Liquidacion & "] y en el reporte [" & Consecutivo & "] Verifique y anule alguno de los 2 reportes")
                End If






            Else
                MsgBox("La factura no se encontro")
            End If

        End If
    End Sub

End Class