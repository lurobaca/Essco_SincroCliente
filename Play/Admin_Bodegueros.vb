Imports System.Threading
Imports System.IO

Public Class Admin_Bodegueros
    Public dt As New DataTable()
    Public fila As Integer

    Public trd1 As Thread



    Private Sub Admin_Bodegueros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If Class_VariablesGlobales.Puesto = "Bodega" Then
            GroupBox1.Enabled = False
        End If


        If txb_Nombre.Text <> "" Then
            btn_agregarBod.Text = "Guardar"
        Else
            btn_agregarBod.Text = "Nuevo"
        End If

        'columnas
        dt.Columns.Add("Sector")
        dt.Columns.Add("Sin_chequear")
        dt.Columns.Add("chequeado")

        Dim Nombre As String
        Dim User As String
        Dim clave As String
        Dim puesto As String

        If Trim(Class_VariablesGlobales.UserBod) <> "" Then

            Dim tbl_DatosUser As New DataTable
            Dim cont As Integer = 0
            tbl_DatosUser = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_UN_Bodeguero(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.UserBod)

            For Each row As DataRow In tbl_DatosUser.Rows
                Nombre = tbl_DatosUser.Rows(cont).Item("Nombre").ToString()
                User = tbl_DatosUser.Rows(cont).Item("Usuario").ToString()
                clave = tbl_DatosUser.Rows(cont).Item("Clave").ToString()
                puesto = tbl_DatosUser.Rows(cont).Item("Puesto").ToString()

                Dim fil As DataRow = dt.NewRow()
                fil("Sector") = tbl_DatosUser.Rows(cont).Item("Sector").ToString()
                fil("chequeado") = tbl_DatosUser.Rows(cont).Item("Chequeado").ToString()
                fil("Sin_chequear") = tbl_DatosUser.Rows(cont).Item("SinChequear").ToString()

                dt.Rows.Add(fil)
                fil = Nothing
                cont += 1
            Next

            txb_Nombre.Text = Nombre
            txb_User.Text = User
            txb_clave.Text = clave
            cbx_puesto.Text = puesto
            dgv_sectores.DataSource = dt
        End If

        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregarBod.Click
        If btn_agregarBod.Text = "Nuevo" Then
            Limpiar()
        Else


            'Recorre las filas del datagridview
            For Each dRow As DataGridViewRow In dgv_sectores.Rows
                If dRow.Cells.Item("sector").Value = "" Then
                    Exit For
                End If
                'Class_VariablesGlobales.Obj_Funciones_SQL.AgregarBodeguero(Class_VariablesGlobales.SQL_Comman2, txb_Nombre.Text, txb_User.Text, txb_clave.Text, cbx_puesto.Text, dRow.Cells.Item("sector").Value, dRow.Cells.Item("sin_chequear").Value, dRow.Cells.Item("chequeado").Value)
            Next dRow
            txb_Nombre.Text = ""
            txb_User.Text = ""
            txb_clave.Text = ""
            cbx_puesto.Text = ""
            txb_sector.Text = ""
            txb_chequeado.Text = ""
            txb_sinchequear.Text = ""

            Dim dtlimpia As New DataTable()
            dgv_sectores.DataSource = dtlimpia
            dt = New DataTable
            dt.Columns.Add("Sector")
            dt.Columns.Add("Sin_chequear")
            dt.Columns.Add("chequeado")
        End If
    End Sub

    Private Sub btn_sector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sector.Click

        Dim row As DataRow = dt.NewRow()
        row("Sector") = txb_sector.Text
        row("chequeado") = txb_chequeado.Text
        row("Sin_chequear") = txb_sinchequear.Text

        dt.Rows.Add(row)

        'enlazas datatable a griedview
        dgv_sectores.DataSource = dt
        txb_sector.Text = ""
        txb_chequeado.Text = ""
        txb_sinchequear.Text = ""

    End Sub




    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        dgv_sectores.Rows.RemoveAt(dgv_sectores.CurrentRow.Index)
        txb_sector.Text = ""
        txb_chequeado.Text = ""
        txb_sinchequear.Text = ""
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()

    End Sub

    Private Sub btn_buscarBod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscarBod.Click
        Me.Close()


        Dim MDIForm As New buscaBodeguero
        MDIForm.MdiParent = Principal
        MDIForm.Show()
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click


        dgv_sectores.Rows.RemoveAt(dgv_sectores.CurrentRow.Index)

        Dim row As DataRow = dt.NewRow()
        row("Sector") = txb_sector.Text
        row("chequeado") = txb_chequeado.Text
        row("Sin_chequear") = txb_sinchequear.Text

        dt.Rows.Add(row)

        'enlazas datatable a griedview
        dgv_sectores.DataSource = dt

        txb_sector.Text = ""
        txb_chequeado.Text = ""
        txb_sinchequear.Text = ""
        btn_sector.Enabled = True
    End Sub



    Private Sub btn_actualizarBod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizarBod.Click

        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaBodeguero(Class_VariablesGlobales.SQL_Comman2, Trim(txb_User.Text))

        'Recorre las filas del datagridview
        For Each dRow As DataGridViewRow In dgv_sectores.Rows
            If dRow.Cells.Item("sector").Value = "" Then
                Exit For
            End If
            'Class_VariablesGlobales.Obj_Funciones_SQL.AgregarBodeguero(Class_VariablesGlobales.SQL_Comman2, txb_Nombre.Text, txb_User.Text, txb_clave.Text, cbx_puesto.Text, dRow.Cells.Item("sector").Value, dRow.Cells.Item("sin_chequear").Value, dRow.Cells.Item("chequeado").Value)
        Next dRow
        txb_Nombre.Text = ""
        txb_User.Text = ""
        txb_clave.Text = ""
        cbx_puesto.Text = ""
        txb_sector.Text = ""
        txb_chequeado.Text = ""
        txb_sinchequear.Text = ""

        Dim dtlimpia As New DataTable()
        dgv_sectores.DataSource = dtlimpia
        dt = New DataTable
        dt.Columns.Add("Sector")
        dt.Columns.Add("Sin_chequear")
        dt.Columns.Add("chequeado")


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaBodeguero(Class_VariablesGlobales.SQL_Comman2, Trim(txb_User.Text))

        Limpiar()

    End Sub

    Private Sub btn_ftpBod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ftpBod.Click
        Try

            btn_ftpBod.Enabled = False


            'hilo de ejecucion constante
            trd1 = New Thread(AddressOf FuncionEn_BackGroud)
            trd1.IsBackground = Enabled
            'trd2.Priority = ThreadPriority.Highest
            CheckForIllegalCrossThreadCalls = False
            trd1.Start()





        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_generar_Click [ " & ex.Message & " ]")
        End Try
    End Sub


    Public Function FuncionEn_BackGroud()
        Try
            If Trim(txb_User.Text) <> "" Then
                Dim tbl_Bodeguero As New DataTable

                tbl_Bodeguero = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_UN_Bodeguero(Class_VariablesGlobales.SQL_Comman2, txb_User.Text)

                Class_VariablesGlobales.Obj_Creaarchivo.CreaArchivoBodegueros(tbl_Bodeguero, "")
                btn_ftpBod.Enabled = True

                MessageBox.Show("Enviado a FTP correctamente")
                Me.Close()
            Else
                MessageBox.Show("Busque al bodeguero primero")


            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub txb_Nombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txb_Nombre.KeyPress
        If txb_Nombre.Text <> "" Then
            btn_agregarBod.Text = "Guardar"
        Else
            btn_agregarBod.Text = "Nuevo"
        End If
    End Sub

    Public Function Limpiar()
        Try


            txb_Nombre.Text = ""
            txb_User.Text = ""
            txb_clave.Text = ""
            cbx_puesto.Text = ""
            txb_sector.Text = ""
            txb_chequeado.Text = ""
            txb_sinchequear.Text = ""
            Class_VariablesGlobales.UserBod = ""
            Dim tabla As New DataTable
            tabla = Nothing

            dgv_sectores.DataSource = tabla



            'dt = New DataTable
            'dt.Columns.Add("Sector")
            'dt.Columns.Add("Sin_chequear")
            'dt.Columns.Add("chequeado")
        Catch ex As Exception

        End Try
    End Function


    Private Sub dgv_sectores_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_sectores.CellClick
        btn_sector.Enabled = False

        txb_sector.Text = dgv_sectores.Item(0, dgv_sectores.CurrentRow.Index).Value.ToString()
        txb_sinchequear.Text = dgv_sectores.Item(1, dgv_sectores.CurrentRow.Index).Value.ToString()
        txb_chequeado.Text = dgv_sectores.Item(2, dgv_sectores.CurrentRow.Index).Value.ToString()
        btn_actualizar.Visible = True
    End Sub
End Class