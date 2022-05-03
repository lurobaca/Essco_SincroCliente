Imports System.Data.Odbc

Public Class Inv_Lista_GruposConteo
    Public Obj_VarGlobal As New Class_VariablesGlobales
    Public CodInventario As String
    Private Sub GruposConteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CodInventario = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneIdInventario()

        DataGridView1.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.GruposConteo(CodInventario, False)

        DGV_GrupoConteo.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.GruposConteo(CodInventario, True)


    End Sub

    Private Sub DGV_GrupoConteo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_GrupoConteo.CellContentClick
        'Class_VariablesGlobales.frmGruposConteo.Txb_CodInventario  = DGV_GrupoConteo.CurrentRow.Cells.Item(0).Value.ToString()


    End Sub

    Private Sub DGV_GrupoConteo_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_GrupoConteo.CellClick

        Try

            If Class_VariablesGlobales.ListaGruposLlamadoDesde = "AdminGrupos" Then



                Class_VariablesGlobales.frmGruposConteo.Limpiar()
                Class_VariablesGlobales.frmGruposConteo.Dgv_Proveedores.DataSource = Nothing
                Class_VariablesGlobales.frmGruposConteo.Txtb_CodGrupo.Text = DGV_GrupoConteo.CurrentRow.Cells.Item(0).Value.ToString()
                Class_VariablesGlobales.frmGruposConteo.Txtb_Responsable.Text = DGV_GrupoConteo.CurrentRow.Cells.Item(1).Value.ToString()
                Class_VariablesGlobales.frmGruposConteo.Txtb_Acompanante.Text = DGV_GrupoConteo.CurrentRow.Cells.Item(2).Value.ToString()
                'Class_VariablesGlobales.frmGruposConteo.Txtb_Responsable.Text = DGV_GrupoConteo.CurrentRow.Cells.Item(3).Value.ToString()
                'Class_VariablesGlobales.frmGruposConteo.Txtb_Responsable2.Text = DGV_GrupoConteo.CurrentRow.Cells.Item(4).Value.ToString()
                Class_VariablesGlobales.frmGruposConteo.Txb_CodInventario.Text = DGV_GrupoConteo.CurrentRow.Cells.Item(3).Value.ToString()
                Class_VariablesGlobales.frmGruposConteo.Txtb_CodGrupo.Enabled = False
                Class_VariablesGlobales.frmGruposConteo.Btn_Guardar.Text = "Modificar"

                '--------------------------------------------------------------------------
                '--------------------------- CONECTAR A MYSQL WEB  ------------------------------
                'Try
                '    If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                '        Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
                '    End If
                'Catch ex As Exception
                '    Class_VariablesGlobales.MYSQ_Comman = New OdbcCommand
                '    Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
                'End Try

                Dim tablas As New DataTable
                Dim cont As Integer = 0
                tablas = Class_VariablesGlobales.Obj_Funciones_SQL.OptieneCasaXGRupo(DGV_GrupoConteo.CurrentRow.Cells.Item(0).Value.ToString(), CodInventario)

                For Each row As DataRow In tablas.Rows
                    Class_VariablesGlobales.frmGruposConteo.AgregaProveedor(tablas.Rows(cont).Item("CodProveedor").ToString(), tablas.Rows(cont).Item("NombreProveedor").ToString())
                    cont += 1
                Next
                'Si ya tiene almenos 1 conteo generado entonces inabilita el grupo
                If Class_VariablesGlobales.Obj_Funciones_SQL.TieneConteos(DGV_GrupoConteo.CurrentRow.Cells.Item(0).Value.ToString()) Then
                    Class_VariablesGlobales.frmGruposConteo.Dgv_Proveedores.ReadOnly = True
                End If
            Else

                If Class_VariablesGlobales.frmCruzar.GBX1.Enabled = True Then
                    Class_VariablesGlobales.frmCruzar.txtb_G1.Text = DGV_GrupoConteo.CurrentRow.Cells.Item(0).Value.ToString()
                End If
                If Class_VariablesGlobales.frmCruzar.GBX3.Enabled = True Then
                    Class_VariablesGlobales.frmCruzar.txtb_Grupo2.Text = DGV_GrupoConteo.CurrentRow.Cells.Item(0).Value.ToString()
                End If
                Class_VariablesGlobales.frmCruzar.txtb_DifMayor.Focus()


            End If

            Me.Close()
        Catch ex As Exception
            MsgBox("Se produjo un error al recuperar el grupo , intentelo nuevamente")

        End Try
    End Sub




End Class