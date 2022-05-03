Public Class Math_Hacienda

    Public Obj_Funciones As New Class_funcionesSQL

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_ConsultaRegHacienda.Click
        Try
            btn_ConsultaRegHacienda.Enabled = False

            Dim Obj_Comunicacion As New Comunicacion
            'Obj_Comunicacion.ListaComprobantesEnHacienda("", Trim(txtb_Clave.Text).Substring(42, 8), "FE", Trim(txtb_Clave.Text))

            Dim Voffset As Integer = CInt(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneUltimoRegistroComprobanteENHACIENDA(Class_VariablesGlobales.SQL_Comman1))
            Dim Continuar As Boolean = True
            txtb_offset.Text = Voffset
            txtb_limit.Text = "50"

            While Continuar = True



                Continuar = Obj_Comunicacion.ListaComprobantesEnHacienda(Trim(txtb_offset.Text), Trim(txtb_limit.Text), Trim(txtb_CedEmisor.Text), "")

                Voffset += 50
            End While

            btn_ConsultaRegHacienda.Enabled = True
            MsgBox("El proceso de consultar comprobantes ha hacienda termino con exito")


            Obj_Comunicacion = Nothing
        Catch ex As Exception


        End Try

    End Sub

    Private Sub Math_Hacienda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtb_CedEmisor.Text = Obj_Funciones.OtieneCedula(Class_VariablesGlobales.SQL_Comman1)

        Class_VariablesGlobales.frmInv_Math_Hacienda.DataGV_Comprobantes.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ComprobanteENHACIENDA(Class_VariablesGlobales.SQL_Comman1)
        Dim Voffset As Integer = CInt(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneUltimoRegistroComprobanteENHACIENDA(Class_VariablesGlobales.SQL_Comman1))

        txtb_offset.Text = Voffset
        txtb_limit.Text = "50"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'CONSULTA COMPROBANTES QUE NO ESTAN EN HACIENDA

        Dim tabla As New DataTable
        Dim Total As Double
        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.Math_ENHACIENDA(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.ToShortDateString), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.ToShortDateString), CBox_Ver.Text)
        Class_VariablesGlobales.frmInv_Math_Hacienda.DataGV_Comprobantes.DataSource = tabla


        If tabla.Rows.Count > 0 Then

            For Each row As DataRow In tabla.Rows

                Total = Total + CDbl(tabla.Rows(0).Item("total"))

            Next

        End If

        txbt_Total.Text = FormatCurrency(Total, 2)


    End Sub
End Class