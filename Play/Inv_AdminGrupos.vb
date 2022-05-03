Imports System.Data.Odbc
Imports System.Threading

Public Class GruposConteo
    Public dt As New DataTable()
    Public idrow As Integer

    Public trd1 As Thread

    Public Obj_VarGlobal As New Class_VariablesGlobales
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar.Click
        'Class_VariablesGlobales.LlamadoDesdeConte = True
        Class_VariablesGlobales.LlamadoDesde = "AdminGrupos"
        Lista_Proveedores.Show()






    End Sub

    Private Sub GruposConteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            ''--------------------------------------------------------------------------
            ''--------------------------- CONECTAR A MYSQL WEB  ------------------------------
            'Try
            '    If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
            '        Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
            '    End If

            'Catch ex As Exception
            '    Class_VariablesGlobales.MYSQ_Comman = New OdbcCommand
            '    Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
            'End Try
            Txb_CodInventario.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneIdInventario()
            dt.Columns.Add("Proveedor")
            dt.Columns.Add("Nombre")

            If Txb_CodInventario.Text = "0" Then
                MsgBox("No hay inventario disposibles, Puede ser por que no existe ningun inventario o por que los inventarios existentens estan cerrados " & vbCrLf & "Genere un inventario nuevo he intente nuevamente")
                Me.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        Try
            If Txtb_CodGrupo.Text = "" And Txtb_Acompanante.Text = "" And Txtb_Responsable.Text = "" And Txb_CodInventario.Text = "" Then
                MsgBox("Debe ingresar informacion")
            Else
                Label1.Visible = True
                'GroupBox7.Enabled = False
                'hilo de ejecucion constante
                trd1 = New Thread(AddressOf GuardaGrupo)
                trd1.IsBackground = Enabled
                'trd2.Priority = ThreadPriority.Highest
                CheckForIllegalCrossThreadCalls = False
                trd1.Start()
            End If
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN Btn_Guardar [ " & ex.Message & " ]")
        End Try
    End Sub


    Public Function GuardaGrupo()
        Try
            Dim CodProveedor As String
            Dim NameProveedor As String
            Dim ExisteGrupo As Boolean = False

            If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteGrupo(Txtb_CodGrupo.Text, Txb_CodInventario.Text) = True Then
                If Btn_Guardar.Text = "Guardar" Then
                    ExisteGrupo = True
                Else
                    ExisteGrupo = False
                End If
            End If

            If ExisteGrupo = True Then
                'Si el grupo ya existe y el boton dice Guardar indica que esta intentando crear otro grupo con el mismo codigo de uno existe
                'Si el grupo ya existe y el boton dice Modificar indica que se busco y eligio el grupo para ser modificado por lo que le permite seguir
                MsgBox("El grupo ya existe " & Txtb_CodGrupo.Text, MsgBoxStyle.Critical)
            Else
                ProgressBar1.Maximum = Dgv_Proveedores.Rows.Count
                ProgressBar1.Value = 0
                Class_VariablesGlobales.idInventario = Trim(Txb_CodInventario.Text)
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

                'Borra elgrupo existente y lo vuelve a crear con los datos nuevos
                'Class_VariablesGlobales.Obj_Funciones_SQL.BorraGrupoConteo(Txtb_CodGrupo.Text)



                'lo que hace es actualizar las lineas del inventario con el codigo del grupo el nombre del integrante y ayudante

                Dim cuenta As Integer = 0
                Dim Avance As Integer = 0
                Dim Conte As Integer = 1
                For Each dRow As DataGridViewRow In Dgv_Proveedores.Rows
                    ProgressBar1.Value = Avance
                    If dRow.Cells.Item("Proveedor").Value = "" Then
                        Exit For
                    End If
                    CodProveedor = dRow.Cells.Item("Proveedor").Value
                    NameProveedor = dRow.Cells.Item("Nombre").Value


                    'Debo verificar si ya existe el conteo 1 del articulo si ya existe entonces la casa comercial ya existia en el grupo
                    ' si no existe entonces se guarda 
                    If Class_VariablesGlobales.Obj_Funciones_SQL.ConpruebaProveedor(Txtb_CodGrupo.Text, CodProveedor, Txb_CodInventario.Text) Then

                        'MsgBox("El proveedor " & CodProveedor & " Ya existe en el grupo")


                        Else



                        Class_VariablesGlobales.Obj_Funciones_SQL.GuardaGrupoConteo(Txtb_CodGrupo.Text, Txtb_Responsable.Text, Txtb_Acompanante.Text, CodProveedor, NameProveedor, Txb_CodInventario.Text)
                        ' aqui deberia obtener la lista de los articulos a contar por el grupo , he insertar en la tabla
                        Dim Tbl As New DataTable
                        Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInvControl(CodProveedor, 0, 0, "", Class_VariablesGlobales.idInventario, False, False)

                        'Para agregar una casa a un grupo se debe verificar que si ya se existe el proveeodr con el grupo indicado


                        Conte = 1
                        'genera el conte 1 y el 2 que se cruzaran entre si
                        While Conte < 3

                            cuenta = 0
                            For Each row As DataRow In Tbl.Rows
                                Class_VariablesGlobales.Obj_Funciones_SQL.InsertConteo(Txtb_CodGrupo.Text, Tbl.Rows(cuenta).Item("Codigo").ToString(), Tbl.Rows(cuenta).Item("Descripcion").ToString(), Class_VariablesGlobales.idInventario, Conte, CodProveedor)
                                cuenta += 1
                            Next
                            Conte += 1
                        End While


                    End If
                    Avance += 1
                Next dRow
                If Btn_Guardar.Text = "Guardar" Then
                    'PRIMERO ELIMINA EL CONTEO ACTIVO Y LUEGO LO AGREGA,Esto no seria bueno hacerlo si lo que esta haciendo es agregando un proveedor ya que si lleva el conteo 3 este se eliminaria y luego solo se crearia el conteo 1 y 2 quedando el 3 sin acceso
                    Class_VariablesGlobales.Obj_Funciones_SQL.EliminaGrupo(Txtb_CodGrupo.Text)
                    'guarda el grupo y el conteo con el que podran acceder
                    Class_VariablesGlobales.Obj_Funciones_SQL.GuardaGrupo(Txtb_CodGrupo.Text, Class_VariablesGlobales.idInventario, False)
                    MsgBox("Grupo Creado exitosamente", MsgBoxStyle.Information)
                Else
                    MsgBox("Grupo Modificado exitosamente", MsgBoxStyle.Information)
                End If


                Limpiar()
                'Else
                '    MsgBox("Problema de conexion intente denuevo")
                'End If

            End If
        Catch ex As Exception
            MsgBox("ERROR GuardaGrupo : " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function


    Public Function AgregaProveedor(ByVal CodProveedor As String, ByVal NombrePRoveedor As String)

        Dim existe As Boolean = False


        For i As Integer = 0 To Dgv_Proveedores.Rows.Count - 1


            If Dgv_Proveedores.Item(0, i).Value = CodProveedor Then
                existe = True
        
            End If
        Next

        If existe = False Then
            Dim fil As DataRow = dt.NewRow()
            fil("Proveedor") = CodProveedor
            fil("Nombre") = NombrePRoveedor
            dt.Rows.Add(fil)
            Dgv_Proveedores.DataSource = dt
            fil = Nothing
        Else
            MsgBox("El codigo del proveedor ya existe en este grupo")
        End If

        existe = Nothing
    End Function

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Inv_ListaInventarios.Show()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Txb_CodInventario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_CodInventario.TextChanged

    End Sub

    Private Sub Txtb_CodGrupo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtb_CodGrupo.KeyPress
        If e.KeyChar.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




    End Sub

    Private Sub Dgv_Proveedores_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Proveedores.CellContentClick
        idrow = e.RowIndex

        Dim result1 As DialogResult = MessageBox.Show("Si borra el proveedor estara borrando todos los conteos hechos con este grupo\n Realmente eliminar el proveeedor del grupo?",
      "Important Question",
      MessageBoxButtons.YesNo)

        If result1 = DialogResult.Yes Then

            'Lo borramos de la base de datos
            Class_VariablesGlobales.Obj_Funciones_SQL.EliminaGrupoConteo(Txtb_CodGrupo.Text, Dgv_Proveedores.Item(0, CInt(Dgv_Proveedores.CurrentRow.Index)).Value, Txb_CodInventario.Text)

            'BORRA LO QUE SE TUVIERA CONTADO HASTA EL MOMENTO PARA EVITAR QUE SUME EN LAS DIFERENCIAS DE CONTEO 3
            Class_VariablesGlobales.Obj_Funciones_SQL.EliminaConteo(Txtb_CodGrupo.Text, Txb_CodInventario.Text, Dgv_Proveedores.Item(0, CInt(Dgv_Proveedores.CurrentRow.Index)).Value)
            'Lo borramos del Datagrid view 
            Dgv_Proveedores.Rows.Remove(Dgv_Proveedores.CurrentRow)
        End If
        If result1 = DialogResult.No Then


        End If


    End Sub


    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Class_VariablesGlobales.frmLista_GruposConteo = New Inv_Lista_GruposConteo
        Class_VariablesGlobales.frmLista_GruposConteo.MdiParent = Principal

        Class_VariablesGlobales.ListaGruposLlamadoDesde = "AdminGrupos"
        Class_VariablesGlobales.frmLista_GruposConteo.Show()



    End Sub

    Private Sub btn_Borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Borrar.Click
        Dim result As Integer = MessageBox.Show("Realmente desea eliminar el grupo?", "caption", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then

        ElseIf result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then



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

            Class_VariablesGlobales.Obj_Funciones_SQL.BorrarGrupos("")
            Class_VariablesGlobales.Obj_Funciones_SQL.ConteoActivo()
            Limpiar()
            MsgBox("Todos los Grupos se borraron con exito")

            'Else
            '    MsgBox("Problemas con la conexion intente nuevaente")
            'End If

        End If

    End Sub


    Public Function Limpiar()
        Try


            Txtb_CodGrupo.Focus()
            Btn_Guardar.Text = "Guardar"
            Txtb_CodGrupo.Text = ""
            Txtb_Acompanante.Text = ""
            Txtb_Responsable.Text = ""

            ' Dgv_Proveedores.DataSource = New DataTable




            Txtb_CodGrupo.Enabled = True
            ProgressBar1.Value = 0

            For i As Integer = 0 To Dgv_Proveedores.RowCount
                Dgv_Proveedores.Rows.Remove(Dgv_Proveedores.CurrentRow)
            Next

        Catch ex As Exception
            'MsgBox("ERROR en Limpiar " & ex.Message)
        End Try
    End Function

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Limpiar()
    End Sub

    Private Sub btn_borrarGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_borrarGrupo.Click

        Dim result As Integer = MessageBox.Show("Realmente desea eliminar el grupo?", "caption", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then

        ElseIf result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
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

            Class_VariablesGlobales.Obj_Funciones_SQL.BorraConteo(Txtb_CodGrupo.Text, Txb_CodInventario.Text)
            Class_VariablesGlobales.Obj_Funciones_SQL.BorraGrupoConteo(Txtb_CodGrupo.Text)
            Class_VariablesGlobales.Obj_Funciones_SQL.BorrarGrupos(Txtb_CodGrupo.Text)
            Class_VariablesGlobales.Obj_Funciones_SQL.ConteoActivo()
            Limpiar()
            MsgBox("El Grupo " & Txtb_CodGrupo.Text)

            'Else
            '    MsgBox("Problemas con la conexion intente nuevaente")
            'End If
        End If
    End Sub

    Private Sub Txtb_CodGrupo_TextChanged(sender As Object, e As EventArgs) Handles Txtb_CodGrupo.KeyPress
        Dim obj_valida As New ValidaDigitados

        obj_valida.SoloLetras(e)
        obj_valida = Nothing
    End Sub
End Class