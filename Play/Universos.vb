Imports System.Text


Public Class Universos

    Dim Has As New Hashtable



    Private Sub Universos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'My.Computer.Registry.CurrentUser.OpenSubKey("SoftWare").OpenSubKey("Microsoft").OpenSubKey("Internet Explorer").OpenSubKey("Main").OpenSubKey("FeactureControl").OpenSubKey("FEACTURE_BROWSER_EMULATION").CreateSubKey("SincroCliente2.exe")
        '' Change MyTestKeyValue to This is a test value. 
        'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SincroCliente2.exe", "1101", "1101")

        Dim Dt As DataTable
        Dt = New DataTable

        Dt = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTE", "")

        Dim contardor As Integer = 0
        While contardor < Dt.Rows.Count
            ComboBox1.Items.Add(Dt.Rows(contardor).Item("Nombre").ToString)
            ComboBox1.Items.IndexOf(CInt(Dt.Rows(contardor).Item("CodAgente").ToString))

            Has.Add(Dt.Rows(contardor).Item("Nombre").ToString, CInt(Dt.Rows(contardor).Item("CodAgente").ToString))

            contardor += 1
        End While

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try

            Dim Tbl_Clientes As New DataTable
            Dim selectedIndex As Integer
            selectedIndex = ComboBox1.SelectedIndex
            Dim selectedItem As Object
            Dim Rutas_Unidicar() As String

            selectedItem = ComboBox1.SelectedItem

            ComboBox1.Items.GetEnumerator()
            Tbl_Clientes = Class_VariablesGlobales.Obj_Funciones_SQL.Obtieneclientes_X_Agente("GPS", Has(selectedItem.ToString()), Tbl_Clientes, Rutas_Unidicar, "", "", Class_VariablesGlobales.SQL_Comman1)
            DataGridView1.DataSource = Tbl_Clientes
            Tbl_Clientes = Nothing
            'MessageBox.Show("Selected Item Text: " & selectedItem.ToString() & Microsoft.VisualBasic.Constants.vbCrLf & _
            '                    "Index: " & ComboBox1.Items.IndexOf())

        Catch ex As Exception

        End Try
    End Sub



    Public Function MandarAlMapa(ByVal Cordenadas As String)
        Dim urlMaps As String
        'Concatenamos la dirección con el Textbox
        '10.3521984,-85.0448494 ,10.4521984,-85.1448494
        urlMaps = "http://maps.google.es/maps?q=" & Cordenadas & "&output=embed"
        'Creamos una variable direccion para que el WebBrowser lo pueda abrir puesto que no puede abrir directamente un string
        Dim direccion As New Uri(urlMaps)
        WebBrowser1.ScriptErrorsSuppressed = True
        'ASignamos como URL la direccion
        'WebBrowser1.DocumentText = "<html><head></head><body><iframe src='" & urlMaps & "' width='100%' height='100%' frameborder='0' style='border:0' allowfullscreen></iframe></body></html>"
        

       


    End Function


    Public Function MandarAlMapa2(ByVal Cordenadas As String)
        'Creamos variable para almacenar la url
        Dim urlMaps As String
        'Concatenamos la latitud y longitud (separada por una coma) con el resto
        urlMaps = "http://maps.google.es/maps?q=" & Cordenadas
        'Creamos una variable direccion para que el WebBrowser lo pueda abrir puesto que no puede abrir directamente un string
        Dim direccion As New Uri(urlMaps)
        WebBrowser1.ScriptErrorsSuppressed = True
        'ASignamos como URL la direccion
        WebBrowser1.Url = direccion
    End Function

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try

  
            Dim Cardcode As String = DataGridView1.CurrentRow.Cells.Item(0).Value()
            If DataGridView1.CurrentRow.Cells.Item(16).Value().ToString <> "" Then
                TxbBox.Text = DataGridView1.CurrentRow.Cells.Item(0).Value()
                TxbDescripcion.Text = DataGridView1.CurrentRow.Cells.Item(1).Value()

                Dim Latitud As String = DataGridView1.CurrentRow.Cells.Item(16).Value()
                Dim Longitud As String = DataGridView1.CurrentRow.Cells.Item(17).Value()
                MandarAlMapa2(Longitud & "," & Latitud)
            Else
                MsgBox("No hay cordenadas Registradas")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        'Creamos variable para almacenar la url
        Dim urlMaps As String
        'Concatenamos la dirección con el Textbox
        urlMaps = "https://maps.google.es/maps?q=40,-3"
        'Creamos una variable direccion para que el WebBrowser lo pueda abrir puesto que no puede abrir directamente un string
        Dim direccion As New Uri(urlMaps)
        'ASignamos como URL la direccion
        WebBrowser1.Url = direccion


    End Sub

 
End Class