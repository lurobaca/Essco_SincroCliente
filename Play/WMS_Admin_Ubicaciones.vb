Public Class WMS_Admin_Ubicaciones

#Region "Funciones"
    ''' <summary>
    '''Crea el código de barras a partir del código generado en el txtb_CodBarras
    ''' </summary>
    Private Sub imprimirCodigoBarras()

    End Sub
#End Region
    Private Sub Admin_Ubicaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CodBarras As String
        '2 primeros digitos para el numero de planta
        '2 segundos digitoss para el numero del rack
        '2 digitos para el numero de niveles

        txtb_id.Text = Class_VariablesGlobales.Obj_Funciones_SQL.obtieneTopIdUbicacion(Class_VariablesGlobales.SQL_Comman2)
        txtb_NumNiveles.Text = Class_VariablesGlobales.Obj_Funciones_SQL.obtieneNumNiveles(Class_VariablesGlobales.SQL_Comman2, txtb_Nombre.Text)

        If txtb_id.Text.Length = 1 Then
            txtb_id.Text = "0" & txtb_id.Text
        End If

        If txtb_Planta.Text.Length = 1 Then
            txtb_Planta.Text = "0" & txtb_Planta.Text
        End If

        If txtb_Rack.Text.Length = 1 Then
            txtb_Rack.Text = "0" & txtb_Rack.Text
        End If
        If txtb_Columna.Text.Length = 1 Then
            txtb_Columna.Text = "0" & txtb_Columna.Text
        End If

        CodBarras = txtb_Planta.Text & txtb_Rack.Text & txtb_Columna.Text & "00"


        txtb_CodBarras.Text = CodBarras.PadLeft(15, "0")
        txtb_NumNiveles.Focus()
        Try
            Dim filaDGV As Integer = 0
            Dim cantNiveles As Integer
            DGV_Niveles.Rows.Clear()
            If txtb_NumNiveles.Text <> "" Then
                cantNiveles = txtb_NumNiveles.Text
                Do
                    DGV_Niveles.Rows.Add()
                    DGV_Niveles.Rows(filaDGV).Cells(0).Value = cantNiveles
                    If cantNiveles > 9 Then
                        DGV_Niveles.Rows(filaDGV).Cells(1).Value = txtb_CodBarras.Text.Substring(1, txtb_CodBarras.Text.Length - 2) & cantNiveles
                    Else
                        DGV_Niveles.Rows(filaDGV).Cells(1).Value = txtb_CodBarras.Text.Substring(1, txtb_CodBarras.Text.Length - 1) & cantNiveles
                    End If
                    DGV_Niveles.Rows(filaDGV).Cells(2).Value = 0
                    filaDGV += 1
                    cantNiveles -= 1
                Loop Until filaDGV >= txtb_NumNiveles.Text
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        'Generara varios codigos de barra segun la informacion ingresada uno por cada nivel
        If txtb_NumNiveles.Text <> "0" Then


            'Se debe recorrer hasta alcansar todos los niveles ya que cada nivel tiene un codigo de barras distinto
            Dim Cont As Integer = 1
            Dim CodBarras As String
            Dim Estado As String = ""
            While Cont <= CInt(txtb_NumNiveles.Text)

                'Genera el codigo de barras de la ubiacion o sububicacion del rack o modulo indicado
                CodBarras = txtb_CodBarras.Text.Substring(0, txtb_CodBarras.Text.Length - 2)
                If Cont < 10 Then
                    CodBarras = CodBarras & "0" & Cont
                Else
                    CodBarras = CodBarras & Cont
                End If
                If Cont = 1 Then
                    Estado = "PICKING"
                Else
                    Estado = "ALMACENADO"
                End If



                'verifica si existe para gaurdar o actualizar

                If Class_VariablesGlobales.Obj_Funciones_SQL.obtieneIdUbicacion(Class_VariablesGlobales.SQL_Comman2, CodBarras) = "0" Then
                    Class_VariablesGlobales.Obj_Funciones_SQL.GuardaUbicaciones(Class_VariablesGlobales.SQL_Comman2, txtb_Nombre.Text, txtb_Planta.Text, txtb_Rack.Text, txtb_Columna.Text, Cont, CodBarras, txtb_Comentarios.Text, "", "", Estado)
                Else
                    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizarUbicaciones(Class_VariablesGlobales.SQL_Comman2, txtb_Nombre.Text, txtb_Planta.Text, txtb_Rack.Text, txtb_Columna.Text, Cont, CodBarras, txtb_Comentarios.Text, "", "", Estado)
                End If


            If txtb_Planta.Text = "01" Then
                Class_VariablesGlobales.frmCroquisBodega.Tap_Planta1.Controls(txtb_Nombre.Text).BackColor = Color.Green
            End If

            If txtb_Planta.Text = "02" Then
                    'Class_VariablesGlobales.frmCroquisBodega.Tap_Planta2.Controls(txtb_Nombre.Text).BackColor = Color.Green
                End If
                Cont += 1

            End While
            Me.Close()
        Else
            MsgBox("Debe indicar al menos 1 nivel")
        End If

    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click

        'No debe permitir eliminar una ubicacion si esta tiene registrada mercaderia

        Dim Pregunta As Integer
        Pregunta = MsgBox("Si elimina la ubicación se borrará del croquis " & vbCrLf & "¿Está Seguro que desea eliminar la ubicación?", vbYesNo + MsgBoxStyle.Critical + vbDefaultButton2, "ELIMINAR UBICACION")
        If Pregunta = vbYes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.EliminaUbicaciones(Class_VariablesGlobales.SQL_Comman2, txtb_Nombre.Text)


            If txtb_Planta.Text = "01" Then
                Class_VariablesGlobales.frmCroquisBodega.Tap_Planta1.Controls(txtb_Nombre.Text).BackColor = Color.White
            End If

            If txtb_Planta.Text = "02" Then
                'Class_VariablesGlobales.frmCroquisBodega.Tap_Planta2.Controls(txtb_Nombre.Text).BackColor = Color.White
            End If
        Else

        End If
        Me.Close()
    End Sub



    Private Sub txtb_NumNiveles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_NumNiveles.KeyPress
        'If Not IsNumeric(e.KeyChar) Or e.KeyChar = ChrW(8) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Class_VariablesGlobales.WMS_AdminUbicaciones_Codigo = txtb_Nombre.Text
        Class_VariablesGlobales.IMPRIMIENDO = "Ubicaciones"

        frmReporte.Show()
    End Sub

    Private Sub txtb_NumNiveles_TextChanged(sender As Object, e As EventArgs) Handles txtb_NumNiveles.TextChanged
        Try
            Dim filaDGV As Integer = 0
            Dim cantNiveles As Integer
            DGV_Niveles.Rows.Clear()
            If txtb_NumNiveles.Text <> "" Then
                cantNiveles = txtb_NumNiveles.Text
                Do
                    DGV_Niveles.Rows.Add()
                    DGV_Niveles.Rows(filaDGV).Cells(0).Value = cantNiveles
                    If cantNiveles > 9 Then
                        DGV_Niveles.Rows(filaDGV).Cells(1).Value = txtb_CodBarras.Text.Substring(1, txtb_CodBarras.Text.Length - 2) & cantNiveles
                    Else
                        DGV_Niveles.Rows(filaDGV).Cells(1).Value = txtb_CodBarras.Text.Substring(1, txtb_CodBarras.Text.Length - 1) & cantNiveles
                    End If
                    DGV_Niveles.Rows(filaDGV).Cells(2).Value = 0
                    filaDGV += 1
                    cantNiveles -= 1
                Loop Until filaDGV >= txtb_NumNiveles.Text
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class