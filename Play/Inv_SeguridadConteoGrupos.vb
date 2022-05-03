Imports System.Data.Odbc

Public Class Inv_SeguridadConteoGrupos
    Public Obj_VarGlobal As New Class_VariablesGlobales
    Public CodInventario As String
    Private Sub SeguridadConteoGrupos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        CodInventario = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneIdInventario()
        Txb_CodInventario.Text = CodInventario

        Dgv_Gconteo.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConteosActivosGrupos(Trim(CodInventario))
        Dim conteo As Integer
        For i As Integer = 0 To Dgv_Gconteo.RowCount - 2
            If Dgv_Gconteo("Finalizado", i).Value.ToString() = "1" Then
                Dgv_Gconteo.Rows(conteo).DefaultCellStyle.BackColor = Color.DarkGreen
                Dgv_Gconteo.Rows(conteo).DefaultCellStyle.ForeColor = Color.White
            End If

            conteo += 1
        Next



        'Dgv_Gconteo.Columns(0).Width = 130
        'Dgv_Gconteo.Columns(1).Width = 25
        'Dgv_Gconteo.Columns(2).Width = 25
        'Dgv_Gconteo.Columns(3).Width = 25
        'Dgv_Gconteo.Columns(4).Width = 25
        'Dgv_Gconteo.Columns(5).Width = 25
        'Dgv_Gconteo.Columns(6).Width = 25
        'Dgv_Gconteo.Columns(7).Width = 25
        'Dgv_Gconteo.Columns(8).Width = 25
    End Sub



    Private Sub Dgv_Gconteo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Gconteo.CellDoubleClick
        Dim Grupo As String = Dgv_Gconteo.Item(0, CInt(Dgv_Gconteo.CurrentRow.Index)).Value
        Dim Conteo As String = Dgv_Gconteo.Item(1, CInt(Dgv_Gconteo.CurrentRow.Index)).Value

        Dim result1 As DialogResult = MessageBox.Show("Desea Activar el grupo  " & Grupo & Conteo, "Important Question",
      MessageBoxButtons.YesNo)

        If result1 = DialogResult.Yes Then
            'Activa conteo

            Class_VariablesGlobales.Obj_Funciones_SQL.ActivaConteo(Grupo, Conteo, Trim(Txb_CodInventario.Text))

            Dgv_Gconteo.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            Dgv_Gconteo.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black

        End If
        If result1 = DialogResult.No Then


        End If
        Grupo = Nothing
        Conteo = Nothing
    End Sub
End Class