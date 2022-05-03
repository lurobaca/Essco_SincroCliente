Imports System.Data.Odbc
Imports System.Threading

Public Class Inv_Cruzar
    Private trd1 As Thread
    Public Obj_VarGlobal As New Class_VariablesGlobales
    Public Unificando As Boolean = False
    Public proceso As String = ""
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'aqui va a jalar el dato contado en C1 por el grupo 1 y el C2 por el grupo 2
        'si hay diferencias indica que va a recontar dejando en 1 el campo Reconteo de la tabla


    End Sub
    Private Sub btn_Ejecutar_Click(sender As Object, e As EventArgs) Handles btn_Ejecutar.Click
        If txtb_DifMayor.Text = "" Then

            MsgBox("NO HA DIGITADO EL MONTO DE DIFERENCIAS A OMITIR," & vbCrLf & " Debe indicar el monto a omitir de las diferencias o colocarle 0")
            txtb_DifMayor.Focus()
        Else

            If proceso = "Cruzara entre grupos" Then
                proceso = "Hara el cruce entre " & txtb_G1.Text & "1 y " & txtb_G1.Text & "2 omite diferencias >< a " & txtb_DifMayor.Text
            End If

            If proceso = "Unifica por proveedor" Then
                proceso = "Generara el grupo " & TXB_GrupoDif.Text & "4 y cruza contra sistema omite diferencias >< a " & txtb_DifMayor.Text
            End If
            If proceso = "Cruza contra sistema" Then
                proceso = "Cruza el grupo " & txtb_Grupo2.Text & " contra sistema omite diferencias >< a " & txtb_DifMayor.Text
            End If



            If txtb_DifMayor.Text = "0" Then
                Dim result1 As Integer = MessageBox.Show("El monto a omitir de sus diferencias es Cero (0)" & vbCrLf & " Realmente desea ejecutar el cruce?", "Alerta", MessageBoxButtons.YesNoCancel)
                If result1 = DialogResult.No Then
                ElseIf result1 = DialogResult.Yes Then

                    Dim result As Integer = MessageBox.Show(proceso & " , Esta seguro que desea ejecutar este proceso", "Alerta", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.No Then

                    ElseIf result = DialogResult.Yes Then

                        Ejecutar()
                    End If
                End If
            Else
                'Si no esta en 0 solo sigue el proceso con normalidad
                Dim result2 As Integer = MessageBox.Show(proceso & " , Esta seguro que desea ejecutar este proceso ", "Alerta", MessageBoxButtons.YesNoCancel)
                If result2 = DialogResult.No Then

                ElseIf result2 = DialogResult.Yes Then

                    Ejecutar()
                End If
            End If

        End If
    End Sub
    Public Function Ejecutar()
        '__________PROCESO 1_______________
        If GBX1.Enabled = True And GBX2.Enabled = False And GBX3.Enabled = False Then

            If txtb_G1.Text = "" Then
                MsgBox("Debe indicar el codigo del grupo")
                Exit Function
            Else
                'Verificar que los conteo 1 y 2 ya esten cerrados
                If Class_VariablesGlobales.Obj_Funciones_SQL.GrupoFinalizado(txtb_G1.Text, 1, Trim(Txb_CodInventario.Text)) = 1 And Class_VariablesGlobales.Obj_Funciones_SQL.GrupoFinalizado(txtb_G1.Text, 2, Trim(Txb_CodInventario.Text)) = 1 Then


                    Lbl_Cruzar.Text = txtb_G1.Text & " X " & txtb_G1.Text


                    Timer1.Start()
                    trd1 = Nothing
                    trd1 = New Thread(AddressOf CruzaEntreGrupos)
                    trd1.IsBackground = Enabled
                    trd1.Priority = ThreadPriority.AboveNormal
                    trd1.Start()
                    CheckForIllegalCrossThreadCalls = False

                    Panel1.Visible = True

                    Lbl_Cruzar.Text = ""

                Else
                    MsgBox("VERIFIQUE QUE EL COTEO 1 Y 2 ESTEN FINALIZADOS ANTES DE GENERAR EL CRUCE")
                End If

            End If


        End If

        '__________PROCESO 2_______________



        If GBX1.Enabled = False And GBX2.Enabled = True And GBX3.Enabled = False Then


            Dim Cruzar As Boolean = False
            If txb_CodProveedor.Text = "" Then
                MsgBox("Debe indicar el codigo del proveedor")
                btn_Proveedores.Focus()
                Exit Function
            End If
            If TXB_GrupoDif.Text = "" Then
                MsgBox("Debe indicar el codigo del nuevo grupo")
                TXB_GrupoDif.Focus()
                Exit Function
            End If

            If txtb_Responsable.Text = "" Then
                MsgBox("Debe indicar un responsable ")
                txtb_Responsable.Focus()
                Exit Function
            End If

            If txtb_DifMayor.Text = "0" Then
                Dim Pregunta As Integer
                Pregunta = MsgBox("No ha indicado ningun monto de diferencias para reducir la lista a contar " & vbCrLf & " ¿Realmente desea realizar la unificacion?.", vbYesNo + vbExclamation + vbDefaultButton2, "CRUCE SIN FILTRO")
                If Pregunta = vbYes Then
                    Cruzar = True
                Else
                    Cruzar = False
                    txtb_DifMayor.Focus()
                End If
            Else
                Cruzar = True
            End If

            'Verificar que el proveedor tenga grupo
            If Class_VariablesGlobales.Obj_Funciones_SQL.TieneGrupo(txb_CodProveedor.Text, Txb_CodInventario.Text) = True Then
                'Si tiene almenos 1 grupo asignado

                'EN ESTE PROCESO NO DEBE PERMITIR EJECUTARLO HASTA QUE TODOS LOS GRUPOS QUE CONTIENEN LA CASA COMERCIAL SELECCIONADA HALLAN FINALIZADO EL CONTEO 3
                'Cuenta los grupos que contienen al proveedor y suma los 1 que indincan como finalizdo si son iguales indica que todos los grupos finalizaron solo agarra grupos con 1 letra
                If Class_VariablesGlobales.Obj_Funciones_SQL.PuedeUnifica(txb_CodProveedor.Text) = True Then
                    Cruzar = True
                Else
                    Cruzar = False
                    MsgBox("Verifique que todos los grupos que contienen el proveedor [" & txb_CodProveedor.Text & " | " & txtb_NomProveedor.Text & "]  finalizaran el conteo [ 3 ] para realizar la unificacion " & TXB_GrupoDif.Text, MsgBoxStyle.Critical)
                End If

                If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteGrupo(TXB_GrupoDif.Text, Txb_CodInventario.Text) = True Then
                    Cruzar = False
                    MsgBox("El grupo ya existe " & TXB_GrupoDif.Text, MsgBoxStyle.Critical)
                End If
            Else
                'No tiene grupo asignado
                MsgBox("El Proveedor " & txb_CodProveedor.Text & " No esta asignado a ningun grupo", MsgBoxStyle.Critical)
                Cruzar = False
            End If



            If Cruzar = True Then
                'la idea es colocar el codigo del proveedor cuando ya todos los grupo que contiene el proveedor hallan llegado de reconteo
                'Year Crear_Pedido un nuevo grupo el cual sera el que se cruce contra sistema
                Unificando = True
                Dim TABLA As New DataTable
                'SE GENERA UN NUEVO GRUPO CON LA DIFERENCIAS DEL PROVEEDOR INDICADO
                'SE GENERA EL CONTEO 4 DEL GRUPO CON DIFERECIA

                'AGRUPA Y SUMA LOS CONTEOS 3 DE TODOS LOS GRUPOS QUE CONTENGAN LINEAS DE EL PROVEEDOR INDICADO
                TABLA = Class_VariablesGlobales.Obj_Funciones_SQL.Unifica(txb_CodProveedor.Text, Txb_CodInventario.Text.Trim)
                Class_VariablesGlobales.Obj_Funciones_SQL.CambiaAUnificado(Txb_CodInventario.Text.Trim, txb_CodProveedor.Text)

                GuardaGrupo(TABLA, 4)
                'AHORA COMPARARA CADA ARTICULO CONTRA EL STOCK DEL SISTEMA 
                'Activate O DESACTIVA EL RECONTEO DE LA LINEA EN EL CONTEO 4 DEL GRUPO NUEVO



            End If
        End If
        '__________PROCESO 3_______________
        If GBX1.Enabled = False And GBX2.Enabled = False And GBX3.Enabled = True Then

            Timer1.Start()
            trd1 = Nothing
            trd1 = New Thread(AddressOf CruzaContraSistema)
            trd1.IsBackground = Enabled
            trd1.Priority = ThreadPriority.AboveNormal
            trd1.Start()
            CheckForIllegalCrossThreadCalls = False

            Panel1.Visible = True




        End If
    End Function



    Public Function CruzaEntreGrupos()
        Try


            'Compara el C1 con el C2 los conteos que den diferente el campo RECONDENTEO tendra un 0 las lineas que den ajustadas tendran 1
            Dim TABLA As New DataTable
            Dim COTADOR As Integer

            Dim C1 As Integer = 0
            Dim C2 As Integer = 0
            Dim Costo As Double = 0
            Dim Stock As Integer = 0
            Dim DF As Integer = 0
            Dim DMF As Double = 0

            If Txb_CodInventario.Text <> "" Then
                If txtb_G1.Text <> "" Then
                    'primero se verifica que no se le alla hecho ya un cruce entre el grupo 1 Y 2 
                    If Class_VariablesGlobales.Obj_Funciones_SQL.CompruebaCruce(txtb_G1.Text, Trim(Txb_CodInventario.Text)) > 2 Then

                        MsgBox("El cruce ya se ejecuto intente con otro grupo")
                        btn_Ejecutar.Text = "Cruzar"
                        Timer1.Stop()
                        Lbl_Inicio.Text = "0"
                        Lbl_Fin.Text = "0"
                        ProgBar.Value = 0
                        Class_VariablesGlobales.Contador = 0
                    Else
                        ' AQUI DEBE CRUZAR LAS LINEAS LAS LINEAS DEL COTEO 1 Y 2
                        ' LAS LINEAS QUE NO VAN A RECONTEO SE LE COPIA EL COTEO DEL 1 Y 2 AL COTEO 3 Y SE PONE RECONTEO EN 1
                        ' LAS LINEAS QUE SI VAN A RECONTEO AGREGAN EL CONTEO 3 EN 0 Y DEJAN RECONTEO EN 0



                        'Obtiene el las casas comerciales segun el grupo
                        TABLA = Class_VariablesGlobales.Obj_Funciones_SQL.ComparaConteos(txtb_G1.Text, Txb_CodInventario.Text)
                        Lbl_Inicio.Text = "0"
                        Lbl_Fin.Text = TABLA.Rows.Count
                        ProgBar.Maximum = TABLA.Rows.Count
                        Class_VariablesGlobales.Contador = 0
                        If TABLA.Rows.Count > 0 Then
                            btn_Ejecutar.Text = "Procesando espere por favor...."
                            For Each row As DataRow In TABLA.Rows
                                Costo = 0
                                Stock = 0
                                DF = 0
                                DMF = 0
                                ' INSERTA EL CONTEO 3 DE LA LINEA INDEPENDIENTEMENTE QUE VAYA O NO A RECONTEO/MAS ADELANTE SI NO VA A RECONTEO SE QUITA DE LA LISTA
                                Class_VariablesGlobales.Obj_Funciones_SQL.InsertConteo(txtb_G1.Text, TABLA.Rows(COTADOR).Item("Codigo").ToString(), TABLA.Rows(COTADOR).Item("Descripcion").ToString(), Txb_CodInventario.Text, 3, TABLA.Rows(COTADOR).Item("CodProveedor").ToString())


                                If TABLA.Rows(COTADOR).Item("C1").ToString() = "" Then
                                    C1 = 0
                                Else
                                    C1 = CInt(TABLA.Rows(COTADOR).Item("C1").ToString())
                                End If
                                If TABLA.Rows(COTADOR).Item("C2").ToString() = "" Then
                                    C2 = 0
                                Else
                                    C2 = CInt(TABLA.Rows(COTADOR).Item("C2").ToString())
                                End If

                                'Calcula el monto de la diferencia entre C1 y C2
                                Costo = CDbl(Class_VariablesGlobales.Obj_Funciones_SQL.Costo(TABLA.Rows(COTADOR).Item("Codigo").ToString()))
                                Stock = CInt(Class_VariablesGlobales.Obj_Funciones_SQL.Stock(TABLA.Rows(COTADOR).Item("Codigo").ToString()))

                                'Si es igual compara contra sistema
                                If C1 = C2 Then

                                    DF = CInt(C1) - Stock
                                    DMF = Costo * DF
                                    Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Txb_CodInventario.Text, TABLA.Rows(COTADOR).Item("Codigo").ToString(), txtb_G1.Text, 3, C1)
                                    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaMontDifConte(Txb_CodInventario.Text, TABLA.Rows(COTADOR).Item("Codigo").ToString(), C1, DF, DMF)

                                Else
                                    'sino es igual
                                    DF = CInt(C1) - CInt(C2)
                                    DMF = Costo * DF
                                    'si el monto de la diferencia no esta entre los rangos entonces se quita de la lista por contar, del nuevo conteo
                                    If DMF >= CDbl(txtb_DifMayor.Text) Or DMF <= -CDbl(txtb_DifMayor.Text) Then
                                        '
                                        Class_VariablesGlobales.Obj_Funciones_SQL.Recuenta(Txb_CodInventario.Text, TABLA.Rows(COTADOR).Item("Codigo").ToString(), txtb_G1.Text, 3, C1)
                                        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaMontDifConte(Txb_CodInventario.Text, TABLA.Rows(COTADOR).Item("Codigo").ToString(), C1, DF, DMF)
                                    Else
                                        'contado y sistema es diferente asi como el monto de diferencia no cumple con el rango indicado
                                        Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Txb_CodInventario.Text, TABLA.Rows(COTADOR).Item("Codigo").ToString(), txtb_G1.Text, 3, C1)
                                        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaMontDifConte(Txb_CodInventario.Text, TABLA.Rows(COTADOR).Item("Codigo").ToString(), C1, DF, DMF)
                                    End If
                                End If



                                'si el conteo 1 y 2 son iguales quita de la lista
                                'o si el monto de la diferencia es menor o igual a 5mil o mayor o igial que -5000 lo quita de la lisa
                                'If C1 = C2 Then
                                '    'NO MANDA A RECONTAR Y COLOCA en conteo 3 el conte realizado ya que es igual del conteo 1 y 2 
                                '    Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Trim(Txb_CodInventario.Text), TABLA.Rows(COTADOR).Item("Codigo").ToString(), txtb_G1.Text, 3, C1)
                                '    'ACTUALIZA EL CF CON LA SUMA DE LOS CONTEOS
                                '    'falta el stock y el precio
                                '    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaMontDifConte(Txb_CodInventario.Text, TABLA.Rows(COTADOR).Item("Codigo").ToString(), C1, DF, DMF)
                                'ElseIf (DMF >= CDbl(txtb_DifMayor.Text) Or DMF <= -CDbl(txtb_DifMayor.Text)) Then
                                '    'NO MANDA A RECONTAR Y COLOCA en conteo 3 el conte realizado ya que es igual del conteo 1 y 2 
                                '    Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Trim(Txb_CodInventario.Text), TABLA.Rows(COTADOR).Item("Codigo").ToString(), txtb_G1.Text, 3, C1)
                                '    'ACTUALIZA EL CF CON LA SUMA DE LOS CONTEOS
                                '    'falta el stock y el precio
                                '    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaMontDifConte(Txb_CodInventario.Text, TABLA.Rows(COTADOR).Item("Codigo").ToString(), C1, DF, DMF)

                                'End If

                                'libera memoria
                                Costo = Nothing
                                Stock = Nothing
                                DF = Nothing
                                DMF = Nothing

                                Class_VariablesGlobales.DetalleCarga = TABLA.Rows(COTADOR).Item("Codigo").ToString()
                                COTADOR += 1
                                Class_VariablesGlobales.Contador += 1
                            Next
                        End If
                        'desactiva el acceso mediante A1 Y A2
                        Class_VariablesGlobales.Obj_Funciones_SQL.BloqueaAccesoGrupo(txtb_G1.Text, "C1", "1", "Borra", Trim(Txb_CodInventario.Text))
                        Class_VariablesGlobales.Obj_Funciones_SQL.BloqueaAccesoGrupo(txtb_G1.Text, "C2", "2", "Borra", Trim(Txb_CodInventario.Text))
                        Class_VariablesGlobales.Obj_Funciones_SQL.BloqueaAccesoGrupo(txtb_G1.Text, "C3", "3", "Inserta", Trim(Txb_CodInventario.Text))

                        txtb_G1.Text = ""
                        Timer1.Stop()
                        Lbl_Inicio.Text = "0"
                        Lbl_Fin.Text = "0"
                        ProgBar.Value = 0
                        Class_VariablesGlobales.Contador = 0


                        MsgBox("La comparacion se hizo correctamente puede ingresar con " & txtb_G1.Text & "3")

                    End If



                End If
            Else
                MsgBox("Selecciones el inventario")

            End If
        Catch ex As Exception


            MsgBox("ERROR EN CruzaEntreGrupos  " & ex.Message)
        End Try
    End Function
    Private Sub Cruzar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Txb_CodInventario.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneIdInventario()
        If Txb_CodInventario.Text = "0" Then
            MsgBox("No hay inventario disposibles, Puede ser por que no existe ningun inventario o por que los inventarios existentens estan cerrados " & vbCrLf & "Genere un inventario nuevo he intente nuevamente")
            Me.Close()

        End If
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Inv_ListaInventarios.Show()
        Class_VariablesGlobales.LlamadoDesdeCruces = True
    End Sub



    Public Function CruzaContraSistema()
        Dim ConteoActivo As String
        Dim DM As Double
        Dim D As Integer
        Dim CF As Integer
        'Compara los conteos apartir del 3 con el sistema 
        Try


            If Txb_CodInventario.Text <> "" Then
                If txtb_Grupo2.Text <> "" Then


                    'jala el conteo mayor ya que es el que recien acaban de terminar de contar por eso viene a ver las diferencias,Creo que tambien se podria jalar el conteo final ya que cada vez que digitan una cantidad esta actualiza el conteo final
                    ConteoActivo = Class_VariablesGlobales.Obj_Funciones_SQL.ConteoActivoDelGrupo(Trim(txtb_Grupo2.Text), Trim(Txb_CodInventario.Text))

                    If ConteoActivo = "" Then
                        MsgBox("Error , No hay Conteo activo")
                        Exit Function
                    End If

                    Dim COTADOR As Integer = 0
                    Dim TblConteo As New DataTable
                    'Obtiene el CF de la lista de articulos asignado al grupo para comparalo contra el stock
                    TblConteo = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInvConteo(ConteoActivo, Trim(Txb_CodInventario.Text), txtb_Grupo2.Text)

                    If TblConteo.Rows.Count > 0 Then
                        Lbl_Inicio.Text = "0"
                        Lbl_Fin.Text = TblConteo.Rows.Count
                        ProgBar.Maximum = TblConteo.Rows.Count
                        Class_VariablesGlobales.Contador = 0
                        For Each row As DataRow In TblConteo.Rows

                            'CREA EL CONTEO siguiente  DEL GRUPO UNIFICADO 
                            Class_VariablesGlobales.Obj_Funciones_SQL.InsertConteo(txtb_Grupo2.Text, TblConteo.Rows(COTADOR).Item("Codigo").ToString(), TblConteo.Rows(COTADOR).Item("Descripcion").ToString(), Class_VariablesGlobales.idInventario, CInt(ConteoActivo + 1), TblConteo.Rows(COTADOR).Item("CodProveedor").ToString())

                            'si lo contado es diferente a al inventario de sistema entra a verificar si la diferea cumple la condicion , si la cumple manda a reconteo si no no
                            If TblConteo.Rows(COTADOR).Item("Stock").ToString() <> TblConteo.Rows(COTADOR).Item("Conteo").ToString() Then

                                'si no se filtra por montos entonces solo manda recontar
                                If txtb_DifMayor.Text = "" Then
                                    txtb_DifMayor.Text = "0"
                                End If

                                ' si el monto de la diferencia esta entre el rango de filtro lo ponen o no como reconteo

                                CF = CInt(TblConteo.Rows(COTADOR).Item("Conteo").ToString())
                                D = CF - CInt(TblConteo.Rows(COTADOR).Item("Stock").ToString())
                                DM = CDbl(D * CDbl(TblConteo.Rows(COTADOR).Item("Costo").ToString()))


                                'si el monto de la diferencia no esta entre los rangos entonces se quita de la lista por contar, del nuevo conteo
                                If DM >= CDbl(txtb_DifMayor.Text) Or DM <= -CDbl(txtb_DifMayor.Text) Then
                                    '
                                    Class_VariablesGlobales.Obj_Funciones_SQL.Recuenta(Txb_CodInventario.Text, TblConteo.Rows(COTADOR).Item("Codigo").ToString(), txtb_Grupo2.Text, ConteoActivo + 1, CF)
                                Else
                                    'contado y sistema es diferente asi como el monto de diferencia no cumple con el rango indicado
                                    Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Txb_CodInventario.Text, TblConteo.Rows(COTADOR).Item("Codigo").ToString(), txtb_Grupo2.Text, ConteoActivo + 1, CF)
                                End If


                                '-****-*-
                                ' AQUI DEBE REVISARSE
                                '/**/*/*/*/*/

                            Else
                                'si lo contado es igual al estock
                                Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Txb_CodInventario.Text, TblConteo.Rows(COTADOR).Item("Codigo").ToString(), txtb_Grupo2.Text, ConteoActivo + 1, CF)
                            End If

                            'actualiza el monto de reconteo del coteo activo y del coteo final
                            '                            Obj_Funciones_MYSQL.ActualizaMontDifConte(Txb_CodInventario.Text, TblConteo.Rows(COTADOR).Item("Codigo").ToString(), ConteoActivo, D, DM, CF, D, DM)


                            Class_VariablesGlobales.DetalleCarga = TblConteo.Rows(COTADOR).Item("Codigo").ToString()

                            COTADOR += 1
                            Class_VariablesGlobales.Contador += 1
                            Lbl_Inicio.Text = COTADOR
                            ProgBar.Value = COTADOR
                        Next
                    End If

                    'inactiva el acceso al coteo que se esta evaluando
                    Class_VariablesGlobales.Obj_Funciones_SQL.BloqueaAccesoGrupo(txtb_Grupo2.Text, ConteoActivo, ConteoActivo, "Borra", Trim(Txb_CodInventario.Text))
                    'activa el acceso al siguiente conteo con las diferencias aplicadas
                    Class_VariablesGlobales.Obj_Funciones_SQL.BloqueaAccesoGrupo(txtb_Grupo2.Text, CStr(CInt(ConteoActivo + 1)), CStr(CInt(ConteoActivo + 1)), "Inserta", Trim(Txb_CodInventario.Text))






                    ' ConteoActivo
                    ' ese conteo lo compara contra stock de bodega 1
                    'desactiva el conteo que este activo y activa el siguiente si es el conteo 8 indicar que se finalizo los conteo
                Else
                    MsgBox("Indique un grupo")
                End If
            Else
                MsgBox("Selecciones el inventario")
            End If
            Timer1.Stop()
            Lbl_Inicio.Text = "0"
            Lbl_Fin.Text = "0"
            ProgBar.Value = 0
            Class_VariablesGlobales.Contador = 0
            MsgBox("La comparacion se hizo correctamente puede ingresar con " & txtb_Grupo2.Text & CStr(CInt(ConteoActivo) + 1))

            btn_Ejecutar.Text = "Cruzar"
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function

    Private Sub btn_CruzaUnidicaGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CruzaUnidicaGrupos.Click
        If Txb_CodInventario.Text <> "" Then
            If Txtb_Sector.Text <> "" Then
                If Txtb_Grupo.Text <> "" Then
                    'pone un codigo de grupo general por sector
                    Class_VariablesGlobales.Obj_Funciones_SQL.SectorGrupo(Txtb_Sector.Text, Txtb_Grupo.Text, Txb_CodInventario.Text)

                    MsgBox("Sele Asigno el Grupo [" & Txtb_Grupo.Text & "] al Sector [" & Txtb_Sector.Text & "] en el inventario [ " & Txb_CodInventario.Text & " ]")
                Else
                    MsgBox("Debe indicar el Grupo")

                End If

            Else
                MsgBox("Debe indicar el Sector")
            End If

        Else
            MsgBox("Debe indicar el Inventario")
        End If

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try

            'si es mayor o igual que el valor actual 
            If ProgBar.Value <= Class_VariablesGlobales.Contador Then

                Lbl_Inicio.Text = Class_VariablesGlobales.Contador
                Me.ProgBar.Value = Class_VariablesGlobales.Contador
                Lbl_Detaller.Text = Class_VariablesGlobales.DetalleCarga & "[ " & Now & " ]"

            End If

            If Class_VariablesGlobales.TotalLineas <> 0 And Class_VariablesGlobales.Entrar = True Then
                Class_VariablesGlobales.Entrar = False
                Lbl_Fin.Text = Class_VariablesGlobales.TotalLineas
                ProgBar.Maximum = Class_VariablesGlobales.TotalLineas
                ProgBar.Value = 0
                Lbl_Inicio.Text = "0"
            End If

            If Class_VariablesGlobales.ERRORES <> "" Then
                'ListBox_Errores.Items.Add(ERRORES)
                'istBox_Errores.Items.Insert(0, ERRORES)
                Class_VariablesGlobales.ERRORES = ""
            End If

        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR en Timer_ProgresBar_Tick [" & ex.Message & "]"
        End Try
    End Sub



    Public Function GuardaGrupo(ByVal TABLA As DataTable, NumConteo As Integer)

        'Primero verificamos si ya existe el codigo del grupo

        If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteGrupo(TXB_GrupoDif.Text, Txb_CodInventario.Text) = False Then
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

            ' If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Open Then
            'Borra elgrupo existente y lo vuelve a crear con los datos nuevos
            Class_VariablesGlobales.Obj_Funciones_SQL.BorraGrupoConteo(TXB_GrupoDif.Text)

            'lo que hace es actualizar las lineas del inventario con el codigo del grupo el nombre del integrante y ayudante
            Dim CodProveedor As String

            Dim cuenta As Integer = 0

            Dim Conte As Integer = 1

            CodProveedor = txb_CodProveedor.Text
            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaGrupoConteo(TXB_GrupoDif.Text, txtb_Responsable.Text, txtb_Responsable2.Text, txb_CodProveedor.Text, txtb_NomProveedor.Text, Txb_CodInventario.Text)
            ' aqui deberia obtener la lista de los articulos a contar por el grupo , he insertar en la tabla
            Dim Tbl As New DataTable
            Tbl = TABLA
            cuenta = 0
            ProgBar.Value = 0
            ProgBar.Maximum = Tbl.Rows.Count
            Lbl_Fin.Text = Tbl.Rows.Count

            Lbl_Inicio.Text = 0
            For Each row As DataRow In Tbl.Rows
                If Unificando = False Then
                    'Si solo esta creando un nuevo grupo de conteo generar el conteo 1 Y 2 para hacer cruces 
                    'CREA EL CONTEO 1  DEL GRUPO UNIFICADO DONDE CAERAN LAS SUMAS DE LOS COTEOS A3 Y B3
                    Class_VariablesGlobales.Obj_Funciones_SQL.InsertConteo(TXB_GrupoDif.Text, Tbl.Rows(cuenta).Item("CodArticulo").ToString(), Tbl.Rows(cuenta).Item("Descripcion").ToString(), Class_VariablesGlobales.idInventario, 1, CodProveedor)
                    'CREA EL CONTEO 2  DEL GRUPO UNIFICADO, DONDE CAERA EL RECONTEO DE LAS LINEAS CON DIFERENTES CONTRA SISTEMA
                    Class_VariablesGlobales.Obj_Funciones_SQL.InsertConteo(TXB_GrupoDif.Text, Tbl.Rows(cuenta).Item("CodArticulo").ToString(), Tbl.Rows(cuenta).Item("Descripcion").ToString(), Class_VariablesGlobales.idInventario, 2, CodProveedor)

                Else
                    'si esta unificando genera el conteo 4 ya que el proceso de unificar se lleva acabo luego del cruce entre el conteo 1 y 2 y luego de realizar el conteo de las diferencias de este cruce en el conteo 3 por lo que el nuevo grupo debe indicar con conteo 4 indicando que la linea se ha contado 4 veces, aparte para evitar que en el panel de control se sumen y muestren datos erroneos
                    Class_VariablesGlobales.Obj_Funciones_SQL.InsertConteo(TXB_GrupoDif.Text, Tbl.Rows(cuenta).Item("CodArticulo").ToString(), Tbl.Rows(cuenta).Item("Descripcion").ToString(), Class_VariablesGlobales.idInventario, 4, CodProveedor)

                End If

                'AHORA ACTUALIZA EL CONTEO CON LA SUMA DE LOS CONTEOS DE LOS GRUPOS
                Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaConteo(Class_VariablesGlobales.idInventario, Tbl.Rows(cuenta).Item("CodArticulo").ToString(), TXB_GrupoDif.Text, Tbl.Rows(cuenta).Item("Conteo").ToString(), 1)
                'AHORA VERIFICA QUE LA SUMA DE LOS CONTEOS SEA IGUAL AL STOCK SI NO ES IGUAL VA A RECONTEO EN EL CONTEO 2 DEL GRUPO NUEVO

                'ACTUALIZA EL CF CON LA SUMA DE LOS CONTEOS
                'falta el stock y el precio
                Dim Costo As Double = CDbl(Class_VariablesGlobales.Obj_Funciones_SQL.Costo(Tbl.Rows(cuenta).Item("CodArticulo").ToString()))
                Dim Stock As Integer = CInt(Class_VariablesGlobales.Obj_Funciones_SQL.Stock(Tbl.Rows(cuenta).Item("CodArticulo").ToString()))
                Dim DF As Integer = Stock - CInt(Tbl.Rows(cuenta).Item("Conteo").ToString())
                Dim DMF As Double = Costo * DF
                'ACTUALIZA EL CF del inventario
                Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaMontDifConte(Txb_CodInventario.Text, Tbl.Rows(cuenta).Item("CodArticulo").ToString(), Tbl.Rows(cuenta).Item("Conteo").ToString(), DF, DMF)



                'Obtiene el STOCK segun la linea  verifica si es diferente  al conteo.SI es diferente entra
                If (CInt(Trim(Class_VariablesGlobales.Obj_Funciones_SQL.Stock(Tbl.Rows(cuenta).Item("CodArticulo").ToString()))) <> CInt(Trim(Tbl.Rows(cuenta).Item("Conteo").ToString()))) Then
                    'si son diferente va a reconteo
                    'si no se filtra por montos entonces solo manda recontar
                    If txtb_DifMayor.Text = "" Then
                        txtb_DifMayor.Text = "0"
                    End If


                    ' si el monto de la diferencia esta entre el rango de filtro lo ponen o no como reconteo


                    'si el monto de la diferencia no esta entre los rangos entonces se quita de la lista por contar
                    If DMF >= CDbl(txtb_DifMayor.Text) Or DMF <= (CDbl(txtb_DifMayor.Text) * -1) Then
                        '
                        Class_VariablesGlobales.Obj_Funciones_SQL.Recuenta(Txb_CodInventario.Text,
                                                                            Tbl.Rows(cuenta).Item("CodArticulo").ToString(),
                                                                            TXB_GrupoDif.Text,
                                                                            CInt(NumConteo) + 1, Trim(Tbl.Rows(cuenta).Item("Conteo").ToString()))
                    Else
                        'contado y sistema es diferente asi como el monto de diferencia no cumple con el rango indicado
                        'DEBE OBTENEREL MAXIMO CONTEO HABILITADO DEL GRUPO
                        Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Class_VariablesGlobales.idInventario,
                                                                             Tbl.Rows(cuenta).Item("CodArticulo").ToString(), TXB_GrupoDif.Text, CInt(NumConteo), CInt(Trim(Tbl.Rows(cuenta).Item("Conteo").ToString())))
                    End If

                    Costo = Nothing
                    Stock = Nothing
                    DF = Nothing
                    DMF = Nothing

                Else

                    'si son iguales no va a reconteo y le asigna lo contado
                    Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Class_VariablesGlobales.idInventario, Tbl.Rows(cuenta).Item("CodArticulo").ToString(), TXB_GrupoDif.Text, CInt(NumConteo), CInt(Trim(Tbl.Rows(cuenta).Item("Conteo").ToString())))
                End If



                ''si lo contado es diferente a al inventario de sistema entra a verificar si la diferea cumple la condicion , si la cumple manda a reconteo si no no
                'If TblConteo.Rows(COTADOR).Item("Stock").ToString() <> TblConteo.Rows(COTADOR).Item("Conteo").ToString() Then

                '    'si no se filtra por montos entonces solo manda recontar
                '    If txtb_DifMayor.Text = "" Then
                '        txtb_DifMayor.Text = "0"
                '    End If


                '    ' si el monto de la diferencia esta entre el rango de filtro lo ponen o no como reconteo

                '    CF = CInt(TblConteo.Rows(COTADOR).Item("Conteo").ToString())
                '    d = CF - CInt(TblConteo.Rows(COTADOR).Item("Stock").ToString())
                '    DM = CDbl(d * CDbl(TblConteo.Rows(COTADOR).Item("Costo").ToString()))


                '    'si el monto de la diferencia no esta entre los rangos entonces se quita de la lista por contar
                '    If DM >= CDbl(txtb_DifMayor.Text) Or DM <= -CDbl(txtb_DifMayor.Text) Then
                '        '
                '        Class_VariablesGlobales.Obj_Funciones_SQL.Recuenta(Txb_CodInventario.Text, TblConteo.Rows(COTADOR).Item("Codigo").ToString(), txtb_Grupo2.Text, ConteoActivo + 1, CF)
                '    Else
                '        'contado y sistema es diferente asi como el monto de diferencia no cumple con el rango indicado
                '        Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Txb_CodInventario.Text, TblConteo.Rows(COTADOR).Item("Codigo").ToString(), txtb_Grupo2.Text, ConteoActivo + 1, CF)
                '    End If


                '    '-****-*-
                '    ' AQUI DEBE REVISARSE
                '    '/**/*/*/*/*/

                'Else
                '    'si lo contado es igual al estock
                '    Class_VariablesGlobales.Obj_Funciones_SQL.NoRecuenta(Txb_CodInventario.Text, TblConteo.Rows(COTADOR).Item("Codigo").ToString(), txtb_Grupo2.Text, ConteoActivo + 1, CF)
                'End If


                ProgBar.Value = cuenta
                cuenta += 1
                Lbl_Inicio.Text = cuenta
            Next


            If Unificando = False Then
                'guarda el grupo y el conteo con el que podran acceder
                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaGrupo(TXB_GrupoDif.Text, Class_VariablesGlobales.idInventario, Unificando)

            Else
                'guarda el grupo y el conteo con el que podran acceder
                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaGrupo(TXB_GrupoDif.Text, Class_VariablesGlobales.idInventario, Unificando)

            End If

            'inactiva el acceso al coteo enr evision
            Class_VariablesGlobales.Obj_Funciones_SQL.BloqueaAccesoGrupo(TXB_GrupoDif.Text, 1, 1, "Borra", Trim(Txb_CodInventario.Text))

            ProgBar.Value = 0
            'activa el acceso al siguiente conteo
            '  Obj_Funciones_MYSQL.BloqueaAccesoGrupo(TXB_GrupoDif.Text, CStr(CInt(2)), CStr(CInt(2)), "Inserta")


            'Else
            '    MsgBox("Problema de conexion intente denuevo")
            'End If
            MsgBox("Proceso de unificacion terminnado puede ingresar con [ " & TXB_GrupoDif.Text & "4 ]")
            Unificando = False
            txtb_NomProveedor.Text = ""
            txb_CodProveedor.Text = ""
            TXB_GrupoDif.Text = ""
            txtb_Responsable.Text = ""
            txtb_DifMayor.Text = "0"
        Else
            MsgBox("EL CODIGO DEL GRUPO YA EXISTE, INTENTELO NUEVAMENTE CON OTRO CODIGO DE GRUPO ")
            TXB_GrupoDif.Focus()
        End If
    End Function

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lbl_Cruzar.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GBX1.Enabled = True


        GBX2.Enabled = False

        GBX3.Enabled = False
        btn_Ejecutar.Enabled = True
        txtb_DifMayor.Text = "5000"
        proceso = "Cruzara entre grupos"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GBX1.Enabled = False


        GBX2.Enabled = True
        GroupBox1.Visible = True

        GBX3.Enabled = False
        btn_Ejecutar.Enabled = True
        txtb_DifMayor.Text = "15000"
        proceso = "Unifica por proveedor"
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        proceso = "Cruza contra sistema"
        GBX1.Enabled = False


        GBX2.Enabled = False

        GBX3.Enabled = True
        GroupBox1.Visible = True
        btn_Ejecutar.Enabled = True
        Try
            If CInt(txtb_Grupo2.Text.Substring(2, 1)) > 5 Then
                txtb_DifMayor.Text = "50000"
            Else
                txtb_DifMayor.Text = "25000"
            End If
        Catch ex As Exception

        End Try





    End Sub

    Private Sub btn_Proveedores_Click(sender As Object, e As EventArgs) Handles btn_Proveedores.Click
        Class_VariablesGlobales.LlamadoDesde = "Inv_Cruzar"
        'Aqui deberia solo listar los proveedores que aun no han sido unificados para evitar unificar en otro grupo
        Lista_Proveedores.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Solo mostrar los grupos que no tienen un conteo 3 registrado
        Class_VariablesGlobales.ListaGruposLlamadoDesde = "Inv_Cruzar1"
        ListaGrupos()
    End Sub

    Public Function ListaGrupos()
        Try



            Class_VariablesGlobales.frmLista_GruposConteo = New Inv_Lista_GruposConteo
            Class_VariablesGlobales.frmLista_GruposConteo.MdiParent = Principal
            Class_VariablesGlobales.frmLista_GruposConteo.Show()
            Class_VariablesGlobales.frmLista_GruposConteo.DataGridView1.Visible = False
            Class_VariablesGlobales.frmLista_GruposConteo.Label1.Visible = False
            Class_VariablesGlobales.frmLista_GruposConteo.DGV_GrupoConteo.Dock = DockStyle.Fill
        Catch ex As Exception

        End Try

    End Function

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Generamos un Flag para mostrar solo los grupos que tienen Conteo 3
        Class_VariablesGlobales.ListaGruposLlamadoDesde = "Inv_Cruzar2"
        ListaGrupos()
    End Sub

    Private Sub TXB_GrupoDif_TextChanged(sender As Object, e As EventArgs) Handles TXB_GrupoDif.KeyPress

        Dim obj_valida As New ValidaDigitados

        obj_valida.SoloLetras(e)
        obj_valida = Nothing
    End Sub

    Private Sub txtb_DifMayor_TextChanged(sender As Object, e As EventArgs) Handles txtb_DifMayor.KeyPress
        Dim obj_valida As New ValidaDigitados

        obj_valida.SoloNumeros(e)
        obj_valida = Nothing
    End Sub

    Private Sub Txb_CodInventario_TextChanged(sender As Object, e As EventArgs) Handles Txb_CodInventario.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class