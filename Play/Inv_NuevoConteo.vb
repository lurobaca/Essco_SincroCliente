Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Threading

Public Class Inv_NuevoConteo
    Private trd1 As Thread

    Public Objt_GlobalVar As Class_VariablesGlobales
    Dim Obj_SQL_CONEXION_CONEXION As New CONEXION_TO_SQLSERVER
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Subir.Click


        Btn_Crear_Subir.Enabled = False
            '__________PROCESO 1_______________
            Timer_ProgresBar.Start()
            trd1 = Nothing
            trd1 = New Thread(AddressOf InventarioNuevo)
            trd1.IsBackground = Enabled
            trd1.Priority = ThreadPriority.AboveNormal
            trd1.Start()
            CheckForIllegalCrossThreadCalls = False

        'Else
        '    MsgBox("Problemas con la conexion intente nuevaente")

        'End If

    End Sub

    Public Function InventarioNuevo()


        Class_VariablesGlobales.Contador = 0
        Class_VariablesGlobales.DetalleCarga = ""
        ' If Class_VariablesGlobales.Obj_Funciones_MYSQL.SubeInveConteo(Txtb_Titulo.Text, Txtb_Comentario.Text) = 0 Then
        '    ProgBar.Minimum = 0
        '    ProgBar.Maximum = 1
        '    ProgBar.Value = 0
        '    MessageBox.Show("Carga Termino con exito")
        '    Btn_Sigt.Enabled = True
        'Else

        'End If
        If Class_VariablesGlobales.Obj_Funciones_SQL.SubeInveConteo(Txtb_Titulo.Text, Txtb_Comentario.Text) = 0 Then
            ProgBar.Minimum = 0
            ProgBar.Maximum = 1
            ProgBar.Value = 0
            MessageBox.Show("Carga Termino con exito")
            Btn_Sigt.Enabled = True
        Else

        End If


    End Function



    Private Sub NuevoConteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'obtiene datos de coneczion del archivo XML
        If (Class_VariablesGlobales.Obj_Clas_XML.ConexionSAP() = 1) Then
            Me.Close()
        Else
            'conecta  a SAP
            'oCompany = obj_SAP.ConectarSap()

        End If
    End Sub

    Private Sub Timer_ProgresBar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_ProgresBar.Tick
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


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sigt.Click

        Class_VariablesGlobales.frmGruposConteo = New GruposConteo
        Class_VariablesGlobales.frmGruposConteo.MdiParent = Principal
        Class_VariablesGlobales.frmGruposConteo.Show()


        Me.Close()

    End Sub
End Class