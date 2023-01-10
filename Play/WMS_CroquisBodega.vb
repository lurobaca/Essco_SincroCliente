Imports System.Threading
Imports Org.BouncyCastle.Security

Public Class WMS_CroquisBodega
    Dim Count_Columnas As Integer
    Dim Count_Filas As Integer

    Dim Top_Columnas As Integer = 20
    Dim Top_Filas As Integer = 20
    Dim valorCarga As Integer = 0

    Dim Width As Integer = 45
    Dim Height As Integer = 25

    Dim contbtn As Integer = 0
    Dim X As Integer = Width
    Dim Y As Integer = Height
    Dim btnnew As Button
    Dim DataColletion As New AutoCompleteStringCollection()
    Dim InfoArticulos As DataSet
    Dim carga As Integer = 0
    Dim colCarga As Integer = 0
    Dim cargaArticulos As Integer = 0
    Dim cargaAutoCompletar As Integer

#Region "Funciones"
    ''' <summary>
    ''' Obtiene el inventario y lo carga a la colección del auto completar.
    ''' </summary>
    Private Function ObtenerDatosPorPalabraClave()
        carga = 0
        InfoArticulos = New DataSet
        InfoArticulos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInventarioCroquis(Class_VariablesGlobales.SQL_Comman1)
        If InfoArticulos.Tables(0).Rows.Count > 0 Then
            cargaArticulos = 100 / InfoArticulos.Tables(0).Rows.Count
            pbCargaTxtBuscar.Value = 0
            pbCargaTxtBuscar.Visible = True
            For Each row As DataRow In InfoArticulos.Tables(0).Rows
                DataColletion.Add(InfoArticulos.Tables(0).Rows(carga).Item(colCarga).ToString())
                'pbCargaTxtBuscar.Value = pbCargaTxtBuscar.Value + cargaArticulos
                carga += 1
            Next
            pbCargaTxtBuscar.Value = 0
            pbCargaTxtBuscar.Visible = False
        End If

        Return DataColletion
    End Function
    ''' <summary>
    ''' Crea el método de autocompletar del campo txtBuscarArticulos
    ''' </summary>
    Private Sub cargaTxtAutoCompletar()
        txtBuscarArticulo.AutoCompleteMode = AutoCompleteMode.Suggest
        txtBuscarArticulo.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtBuscarArticulo.AutoCompleteCustomSource = ObtenerDatosPorPalabraClave()
    End Sub
#End Region

    Friend WithEvents btn As System.Windows.Forms.Button
    Friend WithEvents Etiqueta As System.Windows.Forms.Label
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WMS_NivelesEnRack.Show()

    End Sub


    Private Sub CroquisBodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        'debera marcar con algun color aquellos campos que ya estan configurados 


        'Dim trd1 As Thread
        'trd1 = Nothing
        'trd1 = New Thread(AddressOf CreaCorquis)
        'trd1.IsBackground = Enabled
        'trd1.Priority = ThreadPriority.AboveNormal
        'CheckForIllegalCrossThreadCalls = True
        'trd1.Start()
        CreaCorquis()

        'BackgroundWorker1.RunWorkerAsync()
    End Sub

    ''' <summary>
    '''crear croquis de bodega
    ''' </summary>
    Public Function CreaCorquis()
        'Creamos un vector de botones para luego agregarlos a la interfaz

        If Class_VariablesGlobales.Ubicaciones_Modo = "Diseno" Then
            Top_Columnas = Class_VariablesGlobales.WMS_Top_Columnas
            Top_Filas = Class_VariablesGlobales.WMS_Top_Filas
            valorCarga = 100 / (Top_Filas + 1)
            btnCambiarBodega.Text = "Cerrar Diseñador"
            Diseño()
        Else
            'Dim trd1 As Thread
            Top_Columnas = Class_VariablesGlobales.WMS_Top_Columnas
            Top_Filas = Class_VariablesGlobales.WMS_Top_Filas
            valorCarga = 100 / (Top_Filas + 1)
            btnCambiarBodega.Text = "Cerrar Vista"
            Visual()
            Principal.Cursor = Cursors.Default
            'trd1 = Nothing
            'trd1 = New Thread(AddressOf cargaTxtAutoCompletar)
            'trd1.IsBackground = Enabled
            'trd1.Priority = ThreadPriority.AboveNormal
            'CheckForIllegalCrossThreadCalls = False
            'trd1.Start()
            cargaAutoCompletar = 0
        End If





        'Class_VariablesGlobales.frmNotificacion_Cargando.Close()


    End Function

    Private Function Diseño()
        Do
            Class_VariablesGlobales.frmMantenimientoBodegas.pbCarga.Value = Class_VariablesGlobales.frmMantenimientoBodegas.pbCarga.Value + valorCarga

            Etiqueta = New System.Windows.Forms.Label
            Etiqueta.Location = New Point(0, Y)
            Etiqueta.Name = "Lbl_" & Count_Columnas & Count_Filas

            Etiqueta.Size = New Size(Width, Height)
            Etiqueta.TabIndex = 6
            Etiqueta.Text = "Rk#" & Count_Filas
            '            Etiqueta.Margin = New Padding(0, 0, 0, 0)
            'Etiqueta.UseVisualStyleBackColor = True
            Etiqueta.ForeColor = Color.Black
            Etiqueta.BackColor = Color.White
            Etiqueta.Cursor = System.Windows.Forms.Cursors.SizeAll
            'AddHandler Etiqueta.Click, AddressOf boton_click
            Tap_Planta1.Controls.Add(Etiqueta)
            Do
                If Count_Filas = 0 Then



                    Etiqueta = New System.Windows.Forms.Label
                    Etiqueta.Location = New Point(X, 0)
                    Etiqueta.Name = "Lbl_" & Count_Columnas & Count_Filas

                    Etiqueta.Size = New Size(Width, Height)
                    Etiqueta.TabIndex = 6
                    Etiqueta.Text = "Cl#" & Count_Columnas
                    '            Etiqueta.Margin = New Padding(0, 0, 0, 0)
                    'Etiqueta.UseVisualStyleBackColor = True
                    Etiqueta.ForeColor = Color.Black
                    Etiqueta.BackColor = Color.White
                    Etiqueta.Cursor = System.Windows.Forms.Cursors.SizeAll
                    'AddHandler Etiqueta.Click, AddressOf boton_click
                    Tap_Planta1.Controls.Add(Etiqueta)
                End If

                Dim Obj_sql As New Class_funcionesSQL
                Dim Existe As Boolean = CInt(Obj_sql.ExisteUbicacion(Class_VariablesGlobales.SQL_Comman2, "B" & Count_Columnas & "-" & Count_Filas & Class_VariablesGlobales.WMS_Codigo_Bodega))

                'Agregamos botones hacia la derecha hasta el top de columna lo indique
                btn = New System.Windows.Forms.Button
                btn.Location = New Point(X, Y)
                btn.Name = "B" & Count_Columnas & "-" & Count_Filas & Class_VariablesGlobales.WMS_Codigo_Bodega
                btn.Size = New Size(Width, Height)
                btn.TabIndex = 6
                btn.Text = ""
                btn.UseVisualStyleBackColor = True
                btn.ForeColor = Color.Black
                If Existe = True Then
                    btn.BackColor = Color.Green
                Else
                    btn.BackColor = Color.White
                End If
                btn.Cursor = System.Windows.Forms.Cursors.SizeAll
                AddHandler btn.Click, AddressOf boton_click
                Tap_Planta1.Controls.Add(btn)
                X += Width

                Count_Columnas += 1
            Loop Until Count_Columnas > Top_Columnas

            Y += Height
            X = Width
            Count_Columnas = 0
            Count_Filas += 1

        Loop Until Count_Filas > Top_Filas
        Class_VariablesGlobales.frmMantenimientoBodegas.pbCarga.Value = 100
    End Function
    Private Function Visual()
        Dim cuenta As Integer = 0
        Dim Obj_sql As New Class_funcionesSQL
        'Dim tbl_Croquis As New DataTable

        'tbl_Croquis = Obj_sql.Obtiene_Croquis(Class_VariablesGlobales.SQL_Comman2)

        'Top_Filas = CInt(tbl_Croquis.Rows(0).Item("Max_Rack").ToString())
        'Top_Columnas = CInt(tbl_Croquis.Rows(0).Item("Max_Columna").ToString())
        'Dim tbl_ubicaciones As New DataTable
        'tbl_ubicaciones = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_UbicacionesCR()
        'If tbl_ubicaciones.Rows.Count > 0 Then
        '    tablasLiq.Rows(0).Item("Fecha").ToString()

        'End If
        'antes de empezar a generar la matriz se verifica que cada posicion existan en la DB
        'o mejo aun consultamos la db los campos que se han almacenado y hacemos el recorrido asi hacemos una sola consulta a la base de datos

        Do
            Class_VariablesGlobales.frmVerBodegas.pbVerCarga.Value = Class_VariablesGlobales.frmVerBodegas.pbVerCarga.Value + valorCarga


            Etiqueta = New System.Windows.Forms.Label
            Etiqueta.Location = New Point(0, Y)
            Etiqueta.Name = "Lbl_" & Count_Columnas & Count_Filas

            Etiqueta.Size = New Size(Width, Height)
            Etiqueta.TabIndex = 6
            Etiqueta.Text = "Rk#" & Count_Filas
            '            Etiqueta.Margin = New Padding(0, 0, 0, 0)
            'Etiqueta.UseVisualStyleBackColor = True
            Etiqueta.ForeColor = Color.Black
            Etiqueta.BackColor = Color.White
            Etiqueta.Cursor = System.Windows.Forms.Cursors.SizeAll
            'AddHandler Etiqueta.Click, AddressOf boton_click
            Tap_Planta1.Controls.Add(Etiqueta)
            Do
                If Count_Filas = 0 Then



                    Etiqueta = New System.Windows.Forms.Label
                    Etiqueta.Location = New Point(X, 0)
                    Etiqueta.Name = "Lbl_" & Count_Columnas & Count_Filas

                    Etiqueta.Size = New Size(Width, Height)
                    Etiqueta.TabIndex = 6
                    Etiqueta.Text = "Cl#" & Count_Columnas
                    'Etiqueta.Margin = New Padding(0, 0, 0, 0)
                    'Etiqueta.UseVisualStyleBackColor = True
                    Etiqueta.ForeColor = Color.Black
                    Etiqueta.BackColor = Color.White
                    Etiqueta.Cursor = System.Windows.Forms.Cursors.SizeAll
                    'AddHandler Etiqueta.Click, AddressOf boton_click
                    Tap_Planta1.Controls.Add(Etiqueta)
                End If
                Dim Existe As Boolean = CInt(Obj_sql.ExisteUbicacion(Class_VariablesGlobales.SQL_Comman2, "B" & Count_Columnas & "-" & Count_Filas & Class_VariablesGlobales.WMS_Codigo_Bodega))
                If Existe = True Then


                    ' Dim Col_MaxxRack As Integer = CInt(Obj_sql.Obtiene_MaxColumnasXRack(Class_VariablesGlobales.SQL_Comman2, cuenta))

                    ' If Count_Columnas <= Col_MaxxRack And Count_Columnas <> 0 Then
                    'Col_MaxxRack = Nothing


                    'Agregamos bolones hacia la derecha hasta el top de columna lo indique
                    btn = New System.Windows.Forms.Button
                    btn.Location = New Point(X, Y)
                    btn.Name = "B" & Count_Columnas & "-" & Count_Filas & Class_VariablesGlobales.WMS_Codigo_Bodega
                    btn.Size = New Size(Width, Height)
                    btn.TabIndex = 6
                    btn.Text = ""
                    btn.UseVisualStyleBackColor = True
                    btn.ForeColor = Color.Black
                    btn.BackColor = Color.White

                    btn.Text = Obj_sql.Obtiene_Nivel(Class_VariablesGlobales.SQL_Comman2, btn.Name)

                    btn.Cursor = System.Windows.Forms.Cursors.SizeAll
                    AddHandler btn.Click, AddressOf boton_click
                    Tap_Planta1.Controls.Add(btn)
                    ' End If
                End If
                Existe = Nothing
                X += Width

                Count_Columnas += 1
            Loop Until Count_Columnas > Top_Columnas

            Y += Height
            X = Width
            Count_Columnas = 0
            Count_Filas += 1
            cuenta += 1

        Loop Until Count_Filas > Top_Filas
    End Function
    Private Sub boton_click(sender As Object, e As EventArgs) Handles btn.Click

        ClickBoton(CType(sender, System.Windows.Forms.Button).Name, CType(sender, System.Windows.Forms.Button).Text)
    End Sub

    Public Function ClickBoton(Nombre As String, Niveles As String)
        Try

            If Class_VariablesGlobales.Ubicaciones_Modo = "Diseno" Then
                Class_VariablesGlobales.frmAdmin_Ubicaciones = New WMS_Admin_Ubicaciones
                Class_VariablesGlobales.frmAdmin_Ubicaciones.MdiParent = Principal
                Class_VariablesGlobales.frmAdmin_Ubicaciones.Text = "Administrando ubicaciones [ " & Nombre & " ]"
                Class_VariablesGlobales.frmAdmin_Ubicaciones.txtb_Nombre.Text = Nombre
                Class_VariablesGlobales.frmAdmin_Ubicaciones.txtb_Columna.Text = Nombre.Substring(1, Nombre.IndexOf("-") - 1)
                Class_VariablesGlobales.frmAdmin_Ubicaciones.txtb_Rack.Text = Nombre.Substring(Nombre.IndexOf("-") + 1, Nombre.Length - Nombre.IndexOf("-") - 1)
                ' TabControl1.SelectedIndex Tap_Planta1
                Class_VariablesGlobales.frmAdmin_Ubicaciones.txtb_Planta.Text = tcPlantas.SelectedTab.Name.Substring(10, tcPlantas.SelectedTab.Name.Length - 10)

                Class_VariablesGlobales.frmAdmin_Ubicaciones.Show()
            Else
                'Modo Visual
                Class_VariablesGlobales.frmNivelesEnRack = New WMS_NivelesEnRack

                Class_VariablesGlobales.frmNivelesEnRack.MdiParent = Principal
                Class_VariablesGlobales.frmNivelesEnRack.Text = "Stock de la ubicacion [ " & Nombre & " ]"
                'Class_VariablesGlobales.frmAdmin_Ubicaciones.txtb_Nombre.Text = Nombre
                Class_VariablesGlobales.frmNivelesEnRack.Show()


                Dim contbtn As Integer = 1
                While contbtn <= CInt(Niveles)

                    If contbtn = 1 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N1.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N1.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N1.Enabled = True

                    End If

                    If contbtn = 2 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N2.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N2.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N2.Enabled = True
                    End If

                    If contbtn = 3 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N3.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N3.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N3.Enabled = True
                    End If

                    If contbtn = 4 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N4.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N4.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N4.Enabled = True
                    End If

                    If contbtn = 5 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N5.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N5.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N5.Enabled = True
                    End If

                    If contbtn = 6 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N6.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N6.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N6.Enabled = True
                    End If

                    If contbtn = 7 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N7.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N7.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N7.Enabled = True
                    End If

                    If contbtn = 8 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N8.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N8.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N8.Enabled = True
                    End If

                    If contbtn = 9 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N9.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N9.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N9.Enabled = True
                    End If

                    If contbtn = 10 Then
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N10.BackColor = Color.Green
                        'Class_VariablesGlobales.frmNivelesEnRack.txtb_N10.ForeColor = Color.White
                        Class_VariablesGlobales.frmNivelesEnRack.txtb_N10.Enabled = True
                    End If




                    contbtn += 1
                End While


            End If
        Catch ex As Exception

        End Try


    End Function
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        CreaCorquis()
    End Sub

    Private Sub CroquisBodega_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Class_VariablesGlobales.Ubicaciones_Modo = ""
    End Sub

    Private Sub btn_NuevaBodega_Click(sender As Object, e As EventArgs) Handles btn_NuevaBodega.Click
        Class_VariablesGlobales.Ubicaciones_Modo = ""
        Class_VariablesGlobales.frmMantenimientoBodegas = New WMS_MantenimientoBodegas
        Class_VariablesGlobales.frmMantenimientoBodegas.Text = "Mantenimiento de bodegas"
        Class_VariablesGlobales.frmMantenimientoBodegas.MdiParent = Principal

        Class_VariablesGlobales.frmMantenimientoBodegas.Show()

        Me.Close()
    End Sub

    Private Sub btnCambiarBodega_Click(sender As Object, e As EventArgs) Handles btnCambiarBodega.Click
        Class_VariablesGlobales.WMS_Abrir_Bodega = False
        Class_VariablesGlobales.Ubicaciones_Modo = ""
        Me.Close()
    End Sub

    Private Sub txtBuscarArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarArticulo.TextChanged
        DataColletion = New AutoCompleteStringCollection()
        If (cargaAutoCompletar = 0) Then
            cargaTxtAutoCompletar()
            cargaAutoCompletar = 1
        End If
        For Each Control In Me.Tap_Planta1.Controls
            If TypeOf Control Is Button Then
                Dim Btn As Button = CType(Control, Button)
                Btn.BackColor = Color.White
            End If
        Next
        If (txtBuscarArticulo.Text.Length > 2) Then

            Dim datosBusqueda As New DataSet
            Dim fila As Integer = 0
            datosBusqueda = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRacksDeBusqueda(Class_VariablesGlobales.SQL_Comman1, txtBuscarArticulo.Text)
            If datosBusqueda.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In datosBusqueda.Tables(0).Rows
                    For Each Control In Me.Tap_Planta1.Controls
                        'MsgBox(datosBusqueda.Tables(0).Rows(fila).Item(0).ToString, MsgBoxStyle.OkOnly)
                        If TypeOf Control Is Button Then
                            Dim Btn As Button = CType(Control, Button)
                            If Btn.Name.Equals(row.ItemArray(0)) Then
                                Btn.BackColor = Color.Green
                            End If
                        End If
                    Next
                    fila = +1
                Next
            End If
        End If
    End Sub
End Class