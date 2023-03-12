Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports SAPbobsCOM
Imports System.Threading

Public Class Principal

    Public Obj_Clas_XML As New Class_XML_Conexion

    Dim Obj_SQL_CONEXION_CONEXION As New CONEXION_TO_SQLSERVER



    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Inicializar()





    End Sub

    Public Sub ConnectarSAP()
        'Class_VariablesGlobales.oCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
    End Sub
    Public Function Inicializar()


        ShowInTaskbar = True
        'Me.Icon = My.Resources.SincroCliente
        VariablesGlobales.Obj_Log.Log("Inicio de sistema", "Otros")
        Dim trd1 As Thread
        If Obj_Clas_XML.LectorLicencias() = 0 Then
            'obtiene datos de conexion del archivo XML
            If (Obj_Clas_XML.ConexionSAP() = 1) Then
                Me.Close()
            Else
                CheckForIllegalCrossThreadCalls = False
                'conecta  a SAP
                trd1 = Nothing
                trd1 = New Thread(AddressOf ConnectarSAP)
                trd1.IsBackground = Visible
                trd1.Priority = ThreadPriority.AboveNormal
                trd1.Start()
                'End If
                'If Class_VariablesGlobales.oCompany.Connect() <> 0 Then
                Iniciar()
            End If
            'valida si ya ingresaron la infomracion del amepresa
            If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteEmpresa(Class_VariablesGlobales.SQL_Comman1) = False Then
                'abre ventana empresa
                Dim MDIForm As New Manager_Empresa
                MDIForm.MdiParent = Me
                MDIForm.MaximizeBox = True

                MDIForm.Show()

                MsgBox("Debe llenar la informacion de la empresa antes de iniciar", MsgBoxStyle.Information)

            End If


        Else
            Me.Close()

        End If
    End Function





    Public Function Iniciar()

        Try

            Class_VariablesGlobales.Obj_RepDCar = New ReportesDeCarga

            ToolStripMenuItem10.Visible = False

            ToolStripMenuItem11.Visible = False
            ToolStripMenuItem12.Visible = False
            ToolStripMenuItem13.Visible = False

            CerrarSesionToolStripMenuItem.Visible = True

            'Este es el usuario Manager
            If Class_VariablesGlobales.Puesto = "SuperUsuario" Then


                MostrarOcultarTodoMenu(True)



            End If
            If Class_VariablesGlobales.Puesto = "Manager" Then

                LiquidacionesToolStripMenuItem.Visible = True

                ContadoToolStripMenuItem.Visible = True
                FacturacionToolStripMenuItem.Visible = True
                AdministrarToolStripMenuItem.Visible = True
                LiquidacionesToolStripMenuItem.Visible = True
                ExportarToolStripMenuItem.Visible = True
                ReportesToolStripMenuItem.Visible = True
                FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Visible = True
                'SubMenus
                EstadoDeTransmisionesToolStripMenuItem.Visible = True
                AgentesToolStripMenuItem.Visible = True
                EmpresaToolStripMenuItem.Visible = True
                ClientesModificadosToolStripMenuItem.Visible = True
                InformacionToolStripMenuItem.Visible = True
                CreditoToolStripMenuItem.Visible = True

                BancosToolStripMenuItem.Visible = True
                ReporteDeFacturasToolStripMenuItem.Visible = True

            End If

            If Class_VariablesGlobales.Puesto = "Facturacion" Then
                FacturacionToolStripMenuItem.Visible = True
                AdministrarToolStripMenuItem.Visible = True


                AgentesToolStripMenuItem.Visible = True
                BodeguerosToolStripMenuItem.Visible = False

                ChoferesToolStripMenuItem.Visible = False
                RutasToolStripMenuItem.Visible = False
                UniversosToolStripMenuItem.Visible = False
                CambioInfoClienteToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False
                CamionesToolStripMenuItem.Visible = False
                ClientesModificadosToolStripMenuItem.Visible = True

                PlanillaToolStripMenuItem.Visible = False
                'LiquidacionesToolStripMenuItem.Visible = False
                ExportarToolStripMenuItem.Visible = True
                ReportesToolStripMenuItem.Visible = True
                BodegaToolStripMenuItem.Visible = False
                PlanillaToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False
                VentasToolStripMenuItem.Visible = False
                ToolStripMenuItem8.Visible = False
                LicenciasToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False
                ReportesDeCargaToolStripMenuItem.Visible = True
                ReporteDeFacturasToolStripMenuItem.Visible = True
                EmpresaToolStripMenuItem.Visible = False
            End If


            If Class_VariablesGlobales.Puesto = "Administracion" Then
                ContadoToolStripMenuItem.Visible = True
                FacturacionToolStripMenuItem.Visible = False
                AdministrarToolStripMenuItem.Visible = True
                PlanillaToolStripMenuItem.Visible = True
                'LiquidacionesToolStripMenuItem.Visible = True
                ExportarToolStripMenuItem.Visible = True
                ReportesToolStripMenuItem.Visible = True
                RevisarDepositosToolStripMenuItem.Visible = False
                FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Visible = True
                PlanillaToolStripMenuItem.Visible = True
                UsuariosToolStripMenuItem.Visible = False
                VentasToolStripMenuItem.Visible = False
                ToolStripMenuItem8.Visible = False
                LicenciasToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = True
                ReportesDeCargaToolStripMenuItem.Visible = False
                ReporteDeFacturasToolStripMenuItem.Visible = False
                EmpresaToolStripMenuItem.Visible = False
            End If
            If Class_VariablesGlobales.Puesto = "CuentasXCobrar" Then
                FacturacionToolStripMenuItem.Visible = True
                AdministrarToolStripMenuItem.Visible = True
                PlanillaToolStripMenuItem.Visible = False
                'LiquidacionesToolStripMenuItem.Visible = True
                ExportarToolStripMenuItem.Visible = True
                ReportesToolStripMenuItem.Visible = True
                RevisarDepositosToolStripMenuItem.Visible = False
                FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Visible = True
                UsuariosToolStripMenuItem.Visible = False
                VentasToolStripMenuItem.Visible = False
                ToolStripMenuItem8.Visible = False
                LicenciasToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False
                ReportesDeCargaToolStripMenuItem.Visible = False
                ReporteDeFacturasToolStripMenuItem.Visible = False
                EmpresaToolStripMenuItem.Visible = False
            End If
            If Class_VariablesGlobales.Puesto = "Bodega" Then
                'LiquidacionesToolStripMenuItem.Visible = False
                ExportarToolStripMenuItem.Visible = False
                PlanillaToolStripMenuItem.Visible = False
                ReportesToolStripMenuItem.Visible = False
                AdministrarToolStripMenuItem.Visible = True
                AgentesToolStripMenuItem.Visible = False
                EmpresaToolStripMenuItem.Visible = False
                RutasToolStripMenuItem.Visible = False
                UniversosToolStripMenuItem.Visible = False
                CambioInfoClienteToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False

                FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Visible = False

                FacturacionToolStripMenuItem.Visible = False
                PlanillaToolStripMenuItem.Visible = False
                VentasToolStripMenuItem.Visible = False
                ToolStripMenuItem8.Visible = False
                LicenciasToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False
                ReportesDeCargaToolStripMenuItem.Visible = True
                ReporteDeFacturasToolStripMenuItem.Visible = True
                EmpresaToolStripMenuItem.Visible = False
            End If


            If Class_VariablesGlobales.Puesto = "Contabilidad" Then

                BodegaToolStripMenuItem.Visible = False
                'LiquidacionesToolStripMenuItem.Visible = True
                PlanillaToolStripMenuItem.Visible = True
                ExportarToolStripMenuItem.Visible = True

                ReportesToolStripMenuItem.Visible = True
                AdministrarToolStripMenuItem.Visible = False
                AgentesToolStripMenuItem.Visible = False

                RutasToolStripMenuItem.Visible = False
                UniversosToolStripMenuItem.Visible = False
                CambioInfoClienteToolStripMenuItem.Visible = False
                FacturacionToolStripMenuItem.Visible = False
                PlanillaToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False
                FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Visible = True
                VentasToolStripMenuItem.Visible = False
                ToolStripMenuItem8.Visible = False
                LicenciasToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False
                ReportesDeCargaToolStripMenuItem.Visible = False
                ReporteDeFacturasToolStripMenuItem.Visible = False
                EmpresaToolStripMenuItem.Visible = False
            End If

            If Class_VariablesGlobales.Puesto = "Recepcion" Then


                'LiquidacionesToolStripMenuItem.Visible = True
                AdministrarToolStripMenuItem.Visible = True
                AgentesToolStripMenuItem.Visible = False


                RutasToolStripMenuItem.Visible = False
                UniversosToolStripMenuItem.Visible = False
                CambioInfoClienteToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False

                FacturacionToolStripMenuItem.Visible = True
                BodegaToolStripMenuItem.Visible = False

                ExportarToolStripMenuItem.Visible = True
                InventarioToolStripMenuItem.Visible = False

                ReportesToolStripMenuItem.Visible = True
                FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Visible = True

                CreditoToolStripMenuItem.Visible = False
                RevisarDepositosToolStripMenuItem.Visible = False
                PlanillaToolStripMenuItem.Visible = False
                VentasToolStripMenuItem.Visible = False
                ToolStripMenuItem8.Visible = False
                LicenciasToolStripMenuItem.Visible = False
                UsuariosToolStripMenuItem.Visible = False
                ReportesDeCargaToolStripMenuItem.Visible = False
                ReporteDeFacturasToolStripMenuItem.Visible = False
                EmpresaToolStripMenuItem.Visible = False
            End If

            Dim CNX_1 As New SqlConnection
            Try

                If Class_VariablesGlobales.SQL_Comman1.Connection.State = ConnectionState.Closed Then
                    CNX_1 = Obj_SQL_CONEXION_CONEXION.Conectar(Class_VariablesGlobales.XMLParamSQL_dababase, CNX_1)
                    Class_VariablesGlobales.SQL_Comman1.Connection = CNX_1
                End If
            Catch ex As Exception
                CNX_1 = Obj_SQL_CONEXION_CONEXION.Conectar(Class_VariablesGlobales.XMLParamSQL_dababase, CNX_1)
                Class_VariablesGlobales.SQL_Comman1.Connection = CNX_1
            End Try

        Catch ex As Exception
            MsgBox("Error en Principal funcion Iniciar() " & ex.Message)
        End Try

    End Function
    Private Sub EstadoDeTransmisionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoDeTransmisionesToolStripMenuItem.Click
        Dim MDIForm As New EstadoSubida
        MDIForm.MdiParent = Me
        MDIForm.Show()


    End Sub
    Private Sub AgentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgentesToolStripMenuItem.Click
        Dim MDIForm As New Admin_Agentes
        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub



    Private Sub ChoferesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChoferesToolStripMenuItem.Click
        'If Class_VariablesGlobales.NumLiqui = Nothing Then
        '    Class_VariablesGlobales.LIQUIDANDO = "CHOFERES"
        '    Class_VariablesGlobales.frmLiqAge = New Liquidacion_Agentes
        '    Class_VariablesGlobales.frmLiqAge.MdiParent = Me
        '    Class_VariablesGlobales.frmLiqAge.Show()

        'Else
        '    ToolStripStatusLabel1.Text = "Solo se permite una ventana abierta"

        '    Time_BorraError.Start()
        'End If

        Dim MDIForm As New Admin_Choferes
        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub

    Private Sub Principal_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Class_VariablesGlobales.Obj_Funciones_SQL.IndicaSesionActiva(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Id_Usuario, 0)
        LoginForm1.Close()

    End Sub

    Private Sub DepositosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub RutasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutasToolStripMenuItem.Click
        Dim MDIForm As New Admin_Rutas
        MDIForm.MdiParent = Me
        MDIForm.Show()


    End Sub

    Private Sub BodeguerosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BodeguerosToolStripMenuItem.Click
        Class_VariablesGlobales.Obj_Admin_Bodegueros = New Admin_Bodeguero
        Class_VariablesGlobales.Obj_Admin_Bodegueros.MdiParent = Me
        Class_VariablesGlobales.Obj_Admin_Bodegueros.Show()
    End Sub

    Private Sub EmpresaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpresaToolStripMenuItem.Click
        Dim MDIForm As New Manager_Empresa
        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub

    Private Sub UniversosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UniversosToolStripMenuItem.Click
        Dim MDIForm As New Universos
        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub

    Private Sub CambioInfoClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambioInfoClienteToolStripMenuItem.Click
        CambioInfoClientes.Show()
    End Sub

    Private Sub FaltantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FaltantesToolStripMenuItem.Click

        Class_VariablesGlobales.frmREPORTE = New Report_Faltantes
        Class_VariablesGlobales.frmREPORTE.MdiParent = Me
        Class_VariablesGlobales.frmREPORTE.Show()


    End Sub

    Private Sub UltimosConsecutivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltimosConsecutivosToolStripMenuItem.Click
        Dim MDIForm As New UltimosConsecutivos
        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub

    Private Sub InformacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformacionToolStripMenuItem.Click

        Class_VariablesGlobales.frmEnviar_Info_Seller = New Enviar_Info_Seller
        Class_VariablesGlobales.frmEnviar_Info_Seller.MdiParent = Me
        Class_VariablesGlobales.frmEnviar_Info_Seller.Show()


    End Sub

    Private Sub ReportesDeCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportesDeCargaToolStripMenuItem.Click
        Class_VariablesGlobales.Obj_RepDCar = New ReportesDeCarga
        Class_VariablesGlobales.Obj_RepDCar.MdiParent = Me
        Class_VariablesGlobales.Obj_RepDCar.Show()
    End Sub

    Private Sub DescuentosFijosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescuentosFijosToolStripMenuItem.Click
        Class_VariablesGlobales.frmDescuentosFijos = New DescFijos
        Class_VariablesGlobales.frmDescuentosFijos.MdiParent = Me
        Class_VariablesGlobales.frmDescuentosFijos.Show()

        'Class_VariablesGlobales.frmDescuentosFijos = New DescuentosFijos
        'Class_VariablesGlobales.frmDescuentosFijos.MdiParent = Me
        'Class_VariablesGlobales.frmDescuentosFijos.Show()

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()

        LoginForm1.Show()

    End Sub

    Private Sub ReporteDeCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeCargaToolStripMenuItem.Click

        Class_VariablesGlobales.Obj_RepDCar = New ReportesDeCarga
        Class_VariablesGlobales.Obj_RepDCar.MdiParent = Me
        Class_VariablesGlobales.Obj_RepDCar.Show()
    End Sub

    Private Sub ReporteDeDevolucionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeDevolucionesToolStripMenuItem.Click


        Class_VariablesGlobales.Obj_RepDevoluciones = New ReporteDeDevoluciones
        Class_VariablesGlobales.Obj_RepDevoluciones.MdiParent = Me
        Class_VariablesGlobales.Obj_RepDevoluciones.Show()


    End Sub

    Private Sub SistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SistemaToolStripMenuItem.Click
        Dim MDIForm As New AboutBox1

        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub

    Private Sub Time_BorraError_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Time_BorraError.Tick
        ToolStripStatusLabel1.Text = ""
        Time_BorraError.Stop()
        Me.LbL_Errorres.Text = ""

    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim MDIForm As New Usuarios

        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Hide()
        LoginForm1.Show()



    End Sub

    Private Sub RevisarDepositosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisarDepositosToolStripMenuItem.Click
        Dim MDIForm As New RevisaDepositos

        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub

    Private Sub ReporteDeFacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeFacturasToolStripMenuItem.Click
        If Class_VariablesGlobales.FrmReporteFacturas = "Abierto" Then
            MessageBox.Show("Por seguridad solo se permite abrir una vez esta ventana")
        Else
            Class_VariablesGlobales.FrmReporteFacturas = "Abierto"
            Class_VariablesGlobales.Obj_Reporte_Facturas = New Reporte_Facturas

            Class_VariablesGlobales.Obj_Reporte_Facturas.MdiParent = Me
            Class_VariablesGlobales.Obj_Reporte_Facturas.Show()
        End If

    End Sub


    Private Sub GastosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InformacionAPickingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformacionAPickingToolStripMenuItem.Click
        Dim MDIForm As New Enviar_Info_Picking
        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub

    Private Sub InformacionAEliverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformacionAEliverToolStripMenuItem.Click
        Dim MDIForm As New Enviar_Info_Deliver
        MDIForm.MdiParent = Me
        MDIForm.Show()
    End Sub

    Private Sub GastosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GastosToolStripMenuItem2.Click

        Class_VariablesGlobales.frmLiqAge = New Liquidacion_Agentes
        Class_VariablesGlobales.frmLiqAge.MdiParent = Me
        'Class_VariablesGlobales.frmLiqAge.Show()

        Class_VariablesGlobales.frmLiqAge.Hide()
        ListaChoferes.Close()
        Class_VariablesGlobales.LIQUIDANDO = "AGENTES"
        Class_VariablesGlobales.Gastos_llamadaDesde = "PRINCIPAL"
        Dim MDIForm As New Detalle_Gastos
        MDIForm.Width = 447
        MDIForm.MdiParent = Me
        MDIForm.Show()

    End Sub

    Private Sub DepositosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepositosToolStripMenuItem2.Click
        Class_VariablesGlobales.LIQUIDANDO = "AGENTES"
        Class_VariablesGlobales.frmLiqAge = New Liquidacion_Agentes
        Class_VariablesGlobales.frmLiqAge.MdiParent = Me
        'Class_VariablesGlobales.frmLiqAge.Show()

        Class_VariablesGlobales.frmLiqAge.Hide()
        ListaAgentes.Close()


        Class_VariablesGlobales.frmDeposAgente = New Admin_Depositos_Agentes
        Class_VariablesGlobales.frmDeposAgente.MdiParent = Me
        Class_VariablesGlobales.frmDeposAgente.Show()
        'Dim MDIForm As New Admin_Depositos
        'MDIForm.MdiParent = Me
        'MDIForm.Show()

    End Sub

    Private Sub CrearPedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearPedidoToolStripMenuItem.Click


        Class_VariablesGlobales.frmCreaPedido = New Pedido_Principal
            Class_VariablesGlobales.frmCreaPedido.MdiParent = Me
            Class_VariablesGlobales.frmCreaPedido.Show()


    End Sub

    Private Sub GastosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GastosToolStripMenuItem1.Click
        Class_VariablesGlobales.frmLiqChof = New Liquidacion_Choferes
        Class_VariablesGlobales.frmLiqChof.MdiParent = Me
        'Class_VariablesGlobales.frmLiqAge.Show()

        Class_VariablesGlobales.frmLiqChof.Hide()
        ListaChoferes.Close()
        Class_VariablesGlobales.LIQUIDANDO = "CHOFERES"
        Class_VariablesGlobales.Gastos_llamadaDesde = "PRINCIPAL"


        Class_VariablesGlobales.frmDetGastos_Choferes = New Detalle_Gastos_Choferes
        Class_VariablesGlobales.frmDetGastos_Choferes.Width = 447
        Class_VariablesGlobales.frmDetGastos_Choferes.MdiParent = Me
        Class_VariablesGlobales.frmDetGastos_Choferes.Show()


        'Dim MDIForm As New Detalle_Gastos_Choferes
        'MDIForm.Width = 447
        'MDIForm.MdiParent = Me
        'MDIForm.Show()
    End Sub

    Private Sub NuevaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaToolStripMenuItem.Click
        If Class_VariablesGlobales.NumLiqui = Nothing Then


            'Class_VariablesGlobales.MisPropiedades.FrmDepChofer = New Admin_Depositos_Choferes
            'Class_VariablesGlobales.MisPropiedades.FrmDepChofer.MdiParent = Me
            'Class_VariablesGlobales.MisPropiedades.FrmDepChofer.Show()
            'Class_VariablesGlobales.MisPropiedades.FrmDepChofer.Hide()


            Class_VariablesGlobales.LIQUIDANDO = "CHOFERES"

            Class_VariablesGlobales.frmLiqChof = New Liquidacion_Choferes
            Class_VariablesGlobales.frmLiqChof.MdiParent = Me
            Class_VariablesGlobales.frmLiqChof.Show()




        Else
            ToolStripStatusLabel1.Text = "Solo se permite una ventana abierta"

            Time_BorraError.Start()
        End If

        'Class_VariablesGlobales.frmLiqChof = New Liquidacion
        'Class_VariablesGlobales.frmLiqChof.MdiParent = Me
        'Class_VariablesGlobales.frmLiqChof.Show()

    End Sub

    Private Sub NuevaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaToolStripMenuItem1.Click
        If Class_VariablesGlobales.NumLiqui = Nothing Then

            Class_VariablesGlobales.MisPropiedades.FrmDepAg = New Admin_Depositos_Agentes
            Class_VariablesGlobales.MisPropiedades.FrmDepAg.MdiParent = Me
            Class_VariablesGlobales.MisPropiedades.FrmDepAg.Show()
            Class_VariablesGlobales.MisPropiedades.FrmDepAg.Hide()



            Class_VariablesGlobales.LIQUIDANDO = "AGENTES"
            Class_VariablesGlobales.frmLiqAge = New Liquidacion_Agentes
            Class_VariablesGlobales.frmLiqAge.MdiParent = Me
            Class_VariablesGlobales.frmLiqAge.Show()

        Else
            ToolStripStatusLabel1.Text = "Solo se permite una ventana abierta"

            Time_BorraError.Start()
        End If
    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionesToolStripMenuItem.Click
        Class_VariablesGlobales.frmDevoluciones = New Devoluciones
        Class_VariablesGlobales.frmDevoluciones.MdiParent = Me
        Class_VariablesGlobales.frmDevoluciones.Show()
    End Sub


    Private Sub DepositosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepositosToolStripMenuItem1.Click



        Class_VariablesGlobales.frmLiqChof = New Liquidacion_Choferes
        Class_VariablesGlobales.frmLiqChof.MdiParent = Me
        'Class_VariablesGlobales.frmLiqAge.Show()
        Class_VariablesGlobales.LIQUIDANDO = "CHOFERES"
        Class_VariablesGlobales.frmLiqChof.Hide()
        ListaChoferes.Close()


        Class_VariablesGlobales.frmDeposChofer = New Admin_Depositos_Choferes
        Class_VariablesGlobales.frmDeposChofer.MdiParent = Me
        Class_VariablesGlobales.frmDeposChofer.Show()
    End Sub

    Private Sub DevolucionesPendientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionesPendientesToolStripMenuItem.Click
        Class_VariablesGlobales.frmDevolucionesPendientes = New Devoluciones_Pendientes
        Class_VariablesGlobales.frmDevolucionesPendientes.MdiParent = Me
        Class_VariablesGlobales.frmDevolucionesPendientes.Show()
    End Sub

    Private Sub ChequearReporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChequearReporteToolStripMenuItem.Click

        Try
            Class_VariablesGlobales.ChequeadoBuscaRuta = True
            Dim MDIForm1 As New Rutas_RepCarga
            MDIForm1.MdiParent = Me
            MDIForm1.Show()





        Catch ex As Exception

        End Try


    End Sub

    Private Sub GruposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GruposToolStripMenuItem.Click


        Class_VariablesGlobales.frmNuevoConteo = New Inv_NuevoConteo
        Class_VariablesGlobales.frmNuevoConteo.MdiParent = Me
        Class_VariablesGlobales.frmNuevoConteo.Show()
    End Sub


    Private Sub GruposToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GruposToolStripMenuItem1.Click
        Class_VariablesGlobales.frmGruposConteo = New GruposConteo
        Class_VariablesGlobales.frmGruposConteo.MdiParent = Me
        Class_VariablesGlobales.frmGruposConteo.Show()
    End Sub



    Private Sub ControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlToolStripMenuItem.Click


        Class_VariablesGlobales.frmControl = New Inv_Control
        Class_VariablesGlobales.frmControl.MdiParent = Me
        Class_VariablesGlobales.frmControl.Show()

        Class_VariablesGlobales.frmControl.inactiva()
    End Sub

    Private Sub CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Class_VariablesGlobales.frmCruzar = New Inv_Cruzar
        Class_VariablesGlobales.frmCruzar.MdiParent = Me
        Class_VariablesGlobales.frmCruzar.Show()




    End Sub

    Private Sub ConteoActivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConteoActivoToolStripMenuItem.Click
        Inv_SeguridadConteoGrupos.Show()

    End Sub

    Private Sub FaltanteSobranteLiquidacionAgentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Click
        Class_VariablesGlobales.frmREPORTE = New Report_Faltantes
        Class_VariablesGlobales.frmREPORTE.MdiParent = Me
        Class_VariablesGlobales.frmREPORTE.Show()
    End Sub



    Private Sub FaltanteSobranteLiquidacionChoferesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FaltanteSobranteLiquidacionChoferesToolStripMenuItem.Click
        Class_VariablesGlobales.frmREPORTE_Choferes = New Report_Faltantes_Choferes
        Class_VariablesGlobales.frmREPORTE_Choferes.MdiParent = Me
        Class_VariablesGlobales.frmREPORTE_Choferes.Show()
    End Sub


    Private Sub ToolStripStatusLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetErrores.Click

    End Sub

    Private Sub CruzarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CruzarToolStripMenuItem.Click



        Class_VariablesGlobales.frmCruzar = New Inv_Cruzar
        Class_VariablesGlobales.frmCruzar.MdiParent = Me
        Class_VariablesGlobales.frmCruzar.Show()
    End Sub

    Private Sub UbicacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbicacionesToolStripMenuItem.Click



    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpleadosToolStripMenuItem.Click
        Class_VariablesGlobales.frmEmpleados = New Planilla_Empleados
        Class_VariablesGlobales.frmEmpleados.MdiParent = Me
        Class_VariablesGlobales.frmEmpleados.Show()
    End Sub

    Private Sub DeduccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeduccionesToolStripMenuItem.Click
        Class_VariablesGlobales.frmDeduccionesAcreditaciones = New DeduccionesAcreditaciones
        Class_VariablesGlobales.frmDeduccionesAcreditaciones.MdiParent = Me
        Class_VariablesGlobales.frmDeduccionesAcreditaciones.Show()
    End Sub

    Private Sub NuevaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaToolStripMenuItem2.Click
        Class_VariablesGlobales.frmPlanilla = New Planilla
        Class_VariablesGlobales.frmPlanilla.MdiParent = Me
        Class_VariablesGlobales.frmPlanilla.Show()
    End Sub

    Private Sub BuscarFacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarFacturaToolStripMenuItem.Click
        Class_VariablesGlobales.frmBuscaFactura = New BuscaFactura
        Class_VariablesGlobales.frmBuscaFactura.MdiParent = Me
        Class_VariablesGlobales.frmBuscaFactura.Show()
    End Sub

    Private Sub CamionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CamionesToolStripMenuItem.Click
        Class_VariablesGlobales.frmBuscaMantenimiento_Camiones = New Admin_Mantenimiento_Camiones
        Class_VariablesGlobales.frmBuscaMantenimiento_Camiones.MdiParent = Me
        Class_VariablesGlobales.frmBuscaMantenimiento_Camiones.Show()
    End Sub

    Private Sub ClientesModificadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesModificadosToolStripMenuItem.Click

        Class_VariablesGlobales.frmAdmin_ClientesModificados = New Admin_Clientes
        Class_VariablesGlobales.frmAdmin_ClientesModificados.MdiParent = Me
        Class_VariablesGlobales.frmAdmin_ClientesModificados.Show()

    End Sub

    Private Sub EstadoComprobantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoComprobantesToolStripMenuItem.Click
        Class_VariablesGlobales.frmLista_Admin_EstadoComprobantes = New Admin_EstadoComprobantes
        Class_VariablesGlobales.frmLista_Admin_EstadoComprobantes.MdiParent = Me
        Class_VariablesGlobales.frmLista_Admin_EstadoComprobantes.Show()
    End Sub

    Private Sub AceptaRechazaFacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AceptaRechazaFacturasToolStripMenuItem.Click
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza = New Acepta_Rechaza
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.MdiParent = Me
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Show()
    End Sub

    Private Sub DiseñarToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AsignarToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub DiseñarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DiseñarToolStripMenuItem1.Click
        'diseñara la bodega es decir eligira los botones que de forma a como actualmente estan puertos los campos en la bodega ya sea en racks o a piso
        'de esta manera se usa un diseño generico y no hay que estar cambiandolo por codigo


        If Class_VariablesGlobales.Ubicaciones_Modo = "" Then
            Class_VariablesGlobales.Ubicaciones_Modo = "Diseno"
            Class_VariablesGlobales.frmMantenimientoBodegas = New WMS_MantenimientoBodegas
            Class_VariablesGlobales.frmMantenimientoBodegas.Text = "Mantenimiento de Bodegas | Modo Diseño de la bodega"
            Class_VariablesGlobales.frmMantenimientoBodegas.MdiParent = Me
            Class_VariablesGlobales.frmMantenimientoBodegas.Show()
        Else
            MsgBox("No se pueden ver las ubicaciones hasta que cierre el Modo Diseño")
        End If
    End Sub

    Private Sub VerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerToolStripMenuItem.Click
        If Class_VariablesGlobales.Ubicaciones_Modo = "" Then
            Class_VariablesGlobales.Ubicaciones_Modo = "Visual"

            Class_VariablesGlobales.frmVerBodegas = New WMS_VerBodegas
            Class_VariablesGlobales.frmVerBodegas.Text = "Modo Visual de la bodega"
            Class_VariablesGlobales.frmVerBodegas.MdiParent = Me
            Class_VariablesGlobales.frmVerBodegas.Show()
        Else
            MsgBox("No se pueden ver las ubicaciones hasta que cierre el Modo Diseño")
        End If
    End Sub

    Private Sub RecepcionToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ManagerDeArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click

        Class_VariablesGlobales.frmStock_Manager = New Stock_Manager
        Class_VariablesGlobales.frmStock_Manager.MdiParent = Me
        Class_VariablesGlobales.frmStock_Manager.Show()
    End Sub

    Private Sub OfertasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OfertasToolStripMenuItem.Click
        'La idea seria un modulo donde se puede agregar 2 lineas y convertirlas en una sola
    End Sub

    Private Sub DescuentosPorPeriodoYCantidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescuentosPorPeriodoYCantidadToolStripMenuItem.Click
        'Permitir crear un descuento a x cantidad de lineas por un periodo de tiempo o por una cantidad especifica ejemplo viernes negro
    End Sub



    Private Sub InventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioToolStripMenuItem.Click
        'Class_VariablesGlobales.frmStock_Categorizaciones = New Stock_Categorizaciones
        'Class_VariablesGlobales.frmStock_Categorizaciones.MdiParent = Me
        'Class_VariablesGlobales.frmStock_Categorizaciones.Show()
    End Sub

    Private Sub InventarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click

    End Sub



    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub DesicionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesicionesToolStripMenuItem.Click
        Gerencia.Show()
    End Sub

    Private Sub MathHaciendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MathHaciendaToolStripMenuItem.Click


        Class_VariablesGlobales.frmInv_Math_Hacienda = New Math_Hacienda
        Class_VariablesGlobales.frmInv_Math_Hacienda.MdiParent = Me
        Class_VariablesGlobales.frmInv_Math_Hacienda.Show()
    End Sub

    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click

    End Sub

    Private Sub ConteoRealizadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConteoRealizadosToolStripMenuItem.Click

        Class_VariablesGlobales.frmInv_ConteosRealizados = New Inv_ConteosRealizados
        Class_VariablesGlobales.frmInv_ConteosRealizados.MdiParent = Me
        Class_VariablesGlobales.frmInv_ConteosRealizados.Show()


    End Sub
    Private Sub FacturacionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem1.Click
        If Class_VariablesGlobales.VentanaComprobantesAbierta = False Then
            Class_VariablesGlobales.VentanaComprobantesAbierta = True

            Class_VariablesGlobales.ComprobanteACrear = "Factura"

            Class_VariablesGlobales.frmFacturacion = New Facturacion
            Class_VariablesGlobales.frmFacturacion.MdiParent = Me
            Class_VariablesGlobales.frmFacturacion.Show()
        End If
    End Sub
    Private Sub NotasDeCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotasDeCreditoToolStripMenuItem.Click
        If Class_VariablesGlobales.VentanaComprobantesAbierta = False Then
            Class_VariablesGlobales.VentanaComprobantesAbierta = True

            Class_VariablesGlobales.ComprobanteACrear = "NotaDeCredito"
            Class_VariablesGlobales.frmFacturacion = New Facturacion
            Class_VariablesGlobales.frmFacturacion.MdiParent = Me
            Class_VariablesGlobales.frmFacturacion.Show()
        End If
    End Sub

    Private Sub NotasDeDebitoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotasDeDebitoToolStripMenuItem.Click
        If Class_VariablesGlobales.VentanaComprobantesAbierta = False Then
            Class_VariablesGlobales.VentanaComprobantesAbierta = True
            Class_VariablesGlobales.ComprobanteACrear = "NotasDebito"
            Class_VariablesGlobales.frmFacturacion = New Facturacion
            Class_VariablesGlobales.frmFacturacion.MdiParent = Me
            Class_VariablesGlobales.frmFacturacion.Show()
        End If
    End Sub

    Private Sub OrdenDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDeCompraToolStripMenuItem.Click
        If Class_VariablesGlobales.VentanaComprobantesAbierta = False Then
            Class_VariablesGlobales.VentanaComprobantesAbierta = True

            Class_VariablesGlobales.ComprobanteACrear = "Proforma"

            Class_VariablesGlobales.frmFacturacion = New Facturacion
            Class_VariablesGlobales.frmFacturacion.MdiParent = Me
            Class_VariablesGlobales.frmFacturacion.Show()
        End If
    End Sub

    Private Sub LineasNuevasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LineasNuevasToolStripMenuItem.Click
        Class_VariablesGlobales.frmInv_WMS_LineaNueva = New WMS_LineaNueva
        Class_VariablesGlobales.frmInv_WMS_LineaNueva.MdiParent = Me
        Class_VariablesGlobales.frmInv_WMS_LineaNueva.Show()
    End Sub

    Private Sub LicenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LicenciasToolStripMenuItem.Click
        Class_VariablesGlobales.frmInv_MantenimientoLicencias = New MantenimientoLicencias
        Class_VariablesGlobales.frmInv_MantenimientoLicencias.MdiParent = Me
        Class_VariablesGlobales.frmInv_MantenimientoLicencias.Show()
    End Sub

    Private Sub ChequeoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequeoToolStripMenuItem.Click
        Class_VariablesGlobales.frmWMS_PedidosChequeados = New WMS_PedidosChequeados

        Class_VariablesGlobales.frmWMS_PedidosChequeados.MdiParent = Me
        Class_VariablesGlobales.frmWMS_PedidosChequeados.Show()
    End Sub

    Private Sub BancosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BancosToolStripMenuItem.Click
        Class_VariablesGlobales.frmWMS_BancosEssco = New Admin_Bancos

        Class_VariablesGlobales.frmWMS_BancosEssco.MdiParent = Me
        Class_VariablesGlobales.frmWMS_BancosEssco.Show()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click

        Dim Pregunta As Integer
        Pregunta = MsgBox("¿Esta Seguro que desea cerrar la sesión del usuario " & Class_VariablesGlobales.Log_Usuario & "?.", vbYesNo + vbExclamation + vbDefaultButton2, "Cerrar Sesión")
        If Pregunta = vbYes Then

            MostrarOcultarTodoMenu(False)
            Class_VariablesGlobales.Obj_Funciones_SQL.RegistrarInicioSesion(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Log_Usuario, Class_VariablesGlobales.IP, Class_VariablesGlobales.UsuarioWindows, "Cerro Sesión")
            VariablesGlobales.CerroSesion = True
            Class_VariablesGlobales.Obj_Funciones_SQL.IndicaSesionActiva(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Id_Usuario, 0)
            LoginForm1.Show()
            Me.Hide()
        Else

        End If

        Pregunta = Nothing


    End Sub

    Public Function MostrarOcultarTodoMenu(ByVal ver As Boolean)
        For Each item As System.Windows.Forms.ToolStripMenuItem In MenuStrip1.Items
            item.Visible = ver

            For Each SubItems As System.Windows.Forms.ToolStripMenuItem In item.DropDownItems
                SubItems.Visible = ver
            Next
        Next
    End Function
End Class