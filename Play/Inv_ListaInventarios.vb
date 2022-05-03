Imports System.Data.Odbc

Public Class Inv_ListaInventarios
    Public Obj_VarGlobal As New Class_VariablesGlobales
    Private Sub Dgv_Inventarios_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Inventarios.CellClick
        Me.Hide()
        Cursor = Cursors.WaitCursor


        Class_VariablesGlobales.frmControl.inactiva()

        Class_VariablesGlobales.frmControl.Lbl_Detaller.Text = "CONSULTANDO DATOS ESPERE...."
        If Class_VariablesGlobales.LlamadoDesdeCruces = True Then

            Class_VariablesGlobales.frmCruzar.Txb_CodInventario.Text = Dgv_Inventarios.CurrentRow.Cells.Item(0).Value.ToString()
            Class_VariablesGlobales.LlamadoDesdeCruces = False

        ElseIf Class_VariablesGlobales.LlamadoDesdeControl = True Then

            Me.Hide()
            Mensaje.Show()

            Class_VariablesGlobales.frmControl.Listar("", Dgv_Inventarios.CurrentRow.Cells.Item(0).Value.ToString())
            Class_VariablesGlobales.frmControl.txtb_IdInvetario.Text = Dgv_Inventarios.CurrentRow.Cells.Item(0).Value.ToString()
            If Dgv_Inventarios.CurrentRow.Cells.Item(4).Value.ToString() = "1" Then

                Class_VariablesGlobales.frmControl.inactiva()



            Else
                Class_VariablesGlobales.frmControl.activa()

            End If
            Class_VariablesGlobales.LlamadoDesdeControl = False
            Mensaje.Close()
        Else
            Class_VariablesGlobales.frmGruposConteo.Txb_CodInventario.Text = Dgv_Inventarios.CurrentRow.Cells.Item(0).Value.ToString()
        End If
        Class_VariablesGlobales.idInventario = Dgv_Inventarios.CurrentRow.Cells.Item(0).Value.ToString()

        Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub ListaInventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        'If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Open Then
        Dgv_Inventarios.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInventarios()
        'Else
        '    MsgBox("Problemas de conexion , Intente nuevamente")

        'End If


    End Sub


End Class