Public Class Unidad_A_Cajas

    Public Function Unidad_A_Cjs(ByVal Cantidad As Integer, ByVal Unidades_x_Caja As Integer)

        Dim Conversion(2) As String

        Dim TotalCajas As Integer
        Dim TotalUnidades As Integer
        Dim Cajas2 As String

        Dim UnidSoliAs As Integer
        Dim UnidXCjAs As Integer
        Dim Unidades As Double
        Dim valor As Double
        Dim UnidSoli2 As Double
        Dim UnidXCj2 As Double
        Dim UnidSoli As Integer
        Dim UnidXCj As Integer
        Dim Cajasdouble As Double
        Dim Cajasdouble2 As Double
        Dim UnidadesSolicitadas As String = Cantidad
        Dim UnidXCaja As String = Unidades_x_Caja

        valor = CDbl(UnidadesSolicitadas) / CDbl(UnidXCaja)
        UnidSoli = CInt(UnidadesSolicitadas)
        UnidXCj = CInt(UnidXCaja)
        'obtien las cajas como numero entero
        TotalCajas = Math.Floor(UnidSoli / UnidXCj)
        Cajasdouble2 = UnidSoli / UnidXCj
        'obtiene las cajas como numero con decimales
        UnidSoli2 = CDbl(UnidadesSolicitadas)
        UnidXCj2 = CDbl(UnidXCaja)
        valor = UnidSoli2 / UnidXCj2
        'combierte las cajas a numero double
        Cajasdouble = CDbl(TotalCajas)
        Unidades = (valor - Cajasdouble) * UnidXCj
        TotalUnidades = Math.Floor(Unidades)

  
        Conversion(0) = Math.Round(Cajasdouble2, 2)
        Conversion(1) = TotalUnidades
        Return Conversion
    End Function
End Class
