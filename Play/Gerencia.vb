Public Class Gerencia
    Private Sub Gerencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.Chart1.Series("Series1").Points.AddXY("Mark", 10)
            Me.Chart1.Series("Series1").Points.AddXY("Roberto", 25)
            Me.Chart1.Series("Series1").Points.AddXY("jose", 35)



            Me.Chart1.Series("Series2").Points.AddXY("Mark", 23)
            Me.Chart1.Series("Series2").Points.AddXY("Roberto", 44)
            Me.Chart1.Series("Series2").Points.AddXY("jose", 13)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub
End Class