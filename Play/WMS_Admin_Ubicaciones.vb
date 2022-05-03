Public Class WMS_Admin_Ubicaciones


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
                Class_VariablesGlobales.frmCroquisBodega.Tap_Planta2.Controls(txtb_Nombre.Text).BackColor = Color.Green
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
        Pregunta = MsgBox("Si elimina la ubicacion se borrara el croquis " & vbCrLf & "Esta Seguro que desea elimina la ubicacion?", vbYesNo + MsgBoxStyle.Critical + vbDefaultButton2, "ELIMINAR UBICACION")
        If Pregunta = vbYes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.EliminaUbicaciones(Class_VariablesGlobales.SQL_Comman2, txtb_Nombre.Text)


            If txtb_Planta.Text = "01" Then
                Class_VariablesGlobales.frmCroquisBodega.Tap_Planta1.Controls(txtb_Nombre.Text).BackColor = Color.White
            End If

            If txtb_Planta.Text = "02" Then
                Class_VariablesGlobales.frmCroquisBodega.Tap_Planta2.Controls(txtb_Nombre.Text).BackColor = Color.White
            End If
        Else

        End If
        Me.Close()
    End Sub

    Private Sub txtb_NumNiveles_TextChanged(sender As Object, e As EventArgs) Handles txtb_NumNiveles.TextChanged
        Try


            If CInt(txtb_NumNiveles.Text) >= 1 Then
                txtb_N1.Text = txtb_CodBarras.Text.Substring(1, txtb_CodBarras.Text.Length - 1) & "1"
            End If

            If CInt(txtb_NumNiveles.Text) >= 2 Then
                txtb_N2.Text = txtb_CodBarras.Text.Substring(2, txtb_CodBarras.Text.Length - 1) & "1"
            End If

            If CInt(txtb_NumNiveles.Text) >= 3 Then
                txtb_N3.Text = txtb_CodBarras.Text.Substring(3, txtb_CodBarras.Text.Length - 1) & "1"
            End If

            If CInt(txtb_NumNiveles.Text) >= 4 Then
                txtb_N4.Text = txtb_CodBarras.Text.Substring(4, txtb_CodBarras.Text.Length - 1) & "1"
            End If

            If CInt(txtb_NumNiveles.Text) >= 5 Then
                txtb_N5.Text = txtb_CodBarras.Text.Substring(5, txtb_CodBarras.Text.Length - 1) & "1"
            End If

            If CInt(txtb_NumNiveles.Text) >= 6 Then
                txtb_N6.Text = txtb_CodBarras.Text.Substring(6, txtb_CodBarras.Text.Length - 1) & "1"
            End If

            If CInt(txtb_NumNiveles.Text) >= 7 Then
                txtb_N7.Text = txtb_CodBarras.Text.Substring(7, txtb_CodBarras.Text.Length - 1) & "1"
            End If

            If CInt(txtb_NumNiveles.Text) >= 8 Then
                txtb_N8.Text = txtb_CodBarras.Text.Substring(8, txtb_CodBarras.Text.Length - 1) & "1"
            End If

            If CInt(txtb_NumNiveles.Text) >= 9 Then
                txtb_N9.Text = txtb_CodBarras.Text.Substring(9, txtb_CodBarras.Text.Length - 1) & "1"
            End If

            If CInt(txtb_NumNiveles.Text) >= 10 Then
                txtb_N10.Text = txtb_CodBarras.Text.Substring(10, txtb_CodBarras.Text.Length - 1) & "1"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtb_NumNiveles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_NumNiveles.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Class_VariablesGlobales.WMS_AdminUbicaciones_Codigo = txtb_CodBarras.Text
        Class_VariablesGlobales.IMPRIMIENDO = "Ubicaciones"

        frmReporte.Show()
    End Sub
End Class