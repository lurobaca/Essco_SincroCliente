Imports System.Data.SqlClient

Public Class List_RepFacturas_LiqChofer

    Private Sub List_RepFacturas_LiqChofer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES" Then
                ComboBox1.Text = "Sin Liquidar"
            Else
                ComboBox1.Text = "Todos"
            End If

            DGV_RepFacturas.Columns(0).Width = 50
            DGV_RepFacturas.Columns(1).Width = 100
            DGV_RepFacturas.Columns(2).Width = 150
            DGV_RepFacturas.Columns(3).Width = 150
            DGV_RepFacturas.Columns(0).Width = 50
            DGV_RepFacturas.Columns(1).Width = 100
            DGV_RepFacturas.Columns(2).Width = 150
            DGV_RepFacturas.Columns(3).Width = 150

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGV_RepFacturas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_RepFacturas.CellContentClick

        DGV_RepFacturas.Rows(DGV_RepFacturas.CurrentRow.Index).Selected = True
        'aqui deberiamos ponerle el mismo numero de liquidacion a los reportes que se seleccionen con el fin de que puedan ser jalados todos al mismo tiempo

        'If Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES" Then
        '    Class_VariablesGlobales.frmLiqChof.Txtb_RepFactura.Text = DGV_RepFacturas.Item(0, DGV_RepFacturas.CurrentRow.Index).Value.ToString()
        '    Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Focus()
        '    Me.Close()
        'Else
        '    Class_VariablesGlobales.Conse_Repcarga = DGV_RepFacturas.Item(0, DGV_RepFacturas.CurrentRow.Index).Value.ToString()

        '    CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.Conse_Repcarga)
        'End If
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

                Total += CDbl(tabla.Rows(cont).Item("DocTotal").ToString())
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

                Total += CDbl(tabla.Rows(cont).Item("DocTotal").ToString())
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

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = True

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_eliminar.Visible = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Lbl_Anulado.Visible = False

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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Buscar()
    End Sub

    Public Function Buscar()
        Try
            Dim Anu As String = "0"
            If ComboBox1.Text = "Todos" Then
                Anu = ""
            End If
            If ComboBox1.Text = "Activos" Then
                Anu = "0"
            End If
            If ComboBox1.Text = "Inactivos" Then
                Anu = "1"
            End If

            If ComboBox1.Text = "Sin Liquidar" Then
                Anu = "2"
            End If

            If Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES" Then
                DGV_RepFacturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepFacturas(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "0", Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text, Anu)
            Else
                DGV_RepFacturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepFacturas(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "0", "", Anu)
            End If

            DGV_RepFacturas.Columns(0).Width = 50
            DGV_RepFacturas.Columns(1).Width = 100
            DGV_RepFacturas.Columns(2).Width = 150
            DGV_RepFacturas.Columns(3).Width = 150

        Catch ex As Exception
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregarRep.Click

        Dim NumReportes As String
        Dim NumReps As String
        Dim Contador As Integer
        Dim FechaReporte As String
        Dim cont As Integer = 0

        ''QUITA TODOS LOS REPORTES
        For x = 0 To Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Count - 1
            Class_VariablesGlobales.Obj_Funciones_SQL.UnificaRepFacturas("", Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items(x).Text, "", Class_VariablesGlobales.SQL_Comman1)
            Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.RemoveByKey(x)
        Next

        For Contador = 0 To DGV_RepFacturas.RowCount - 1



            If DGV_RepFacturas(0, Contador).Selected Then

                'SI EL REPORTE SELECCIONADO EXISTE EN EL LISTVIEW DE REPORTE , ENTONCES LO ELIMINA PARA VOLVERLO A AGREGAR
                'RECORRE LOS ITEMS DEL LISTVIEW Y VERIFICA QUE NO EXISTA EL DATO SELECCIONADO

                For x = 0 To Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Count - 1
                    If DGV_RepFacturas(0, Contador).Value = Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items(x).Text Then
                        Class_VariablesGlobales.Obj_Funciones_SQL.UnificaRepFacturas("", Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items(x).Text, "", Class_VariablesGlobales.SQL_Comman1)
                        Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.RemoveByKey(x)
                    End If
                Next



                'If DGV_RepFacturas.Rows(Contador).Selected Then
                If NumReps = "" Then
                    NumReps = DGV_RepFacturas(0, Contador).Value
                    NumReportes = DGV_RepFacturas(0, Contador).Value

                Else

                    NumReps = NumReps & " , " & DGV_RepFacturas(0, Contador).Value
                    NumReportes = DGV_RepFacturas(0, Contador).Value
                End If

                FechaReporte = DGV_RepFacturas(1, Contador).Value()


                Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Add(DGV_RepFacturas(0, Contador).Value)


                Class_VariablesGlobales.Obj_Funciones_SQL.UnificaRepFacturas("", NumReportes, Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, Class_VariablesGlobales.SQL_Comman1)

            Else

            End If



            cont += 1
            'End If
        Next Contador

        Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Value = FechaReporte
        Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Value = Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Value.AddDays(1)




        If cont > 1 Then
            Class_VariablesGlobales.RepFActurasUnidicado = True
        Else
            Class_VariablesGlobales.RepFActurasUnidicado = False

        End If

        'SE DEBE ASIGNAR EL NUMERO DE LIQUIDACION A LOS REPORTES DE FACTURAS SELECCIONADOS PARA QUE SE PUEDAN MOSTRAR EN LA LIQUIDACION




        If Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES" Then

            'Dim Rep As String = ""
            'For x = 0 To NumReps.Length - 1

            '    If NumReps.Chars(x) = "," Then
            '        Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Add(Rep)
            '        Rep = ""
            '    ElseIf NumReps.Chars(x) <> " " Then
            '        Rep = Rep & (NumReps.Chars(x))

            '    End If

            'Next
            'Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Add(Rep)
            'Rep = Nothing


            Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Focus()
            Me.Close()
        Else
            Class_VariablesGlobales.Conse_Repcarga = DGV_RepFacturas.Item(0, DGV_RepFacturas.CurrentRow.Index).Value.ToString()

            CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.Conse_Repcarga)
        End If
        If Class_VariablesGlobales.frmLiqChof.btn_Guardar.Text = "GUARDAR" Then
            Class_VariablesGlobales.CREANDO_LIQ_CHOFER = True
        Else

        End If


        Class_VariablesGlobales.frmLiqChof.Cargar()
    End Sub



    Private Sub List_RepFacturas_LiqChofer_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'For x = 0 To Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Count - 1



        '    Obj_Funciones_SQL.UnificaRepFacturas(Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items(x).Name, "", Class_VariablesGlobales.SQL_Comman1)

        '    Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.RemoveByKey(x)

        'Next


        Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Focus()
        'CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, "")


    End Sub

    Private Sub dtp_FechaReporte_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_FechaReporte.ValueChanged
        Buscar()
    End Sub
End Class