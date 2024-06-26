Public Class DTO_Planilla

    ''' <summary>
    ''' En la fila 1 se detalla la información de la intensión de pago que está realizando la empresa.
    ''' </summary>
    Public Class DocPlanilla
        Public Property Fila1 As New DTO_Planilla.Fila1()

        Public Property Fila2 As New DTO_Planilla.Fila2()

        Public Property listaFila3 As New List(Of DTO_Planilla.Fila3)()
    End Class

    Public Class Fila1
        ''' <summary>
        ''' BP SALARIO: HD|31026887891.1|20220322|16101000100264957|CRC|593376376.14|781|780|1
        ''' BP PROVEEDORES :  HD|31026887891.3|20220322|16101000100264957|CRC|593376376.14|781|780|1
        ''' </summary>
        ''' <returns></returns>
        'Cédula de la empresa, mas 1, punto CONVENIO:31026887891.1 / 31026887891.3
        Public Property Encabezado As String
        'Cédula de la empresa, mas 1, punto CONVENIO:31026887891.1 / 31026887891.3
        Public Property CedulaEmpresa As String

        'Fecha de aplicación del archivo: 20220322 (año/mes/día)
        Public Property FechaAplicacion As Date

        'Cuenta cliente del patrono: 16101000100264957
        Public Property CuentaClientePatron As String

        'Moneda debitar: CRC
        Public Property MonedaDebitar As String

        'Monto total del débito, más el crédito: 593376376.14
        Public Property MontoTotalDebitoCredito As Double

        'Cantidad total de movimientos sistema (débito + créditos): 781
        Public Property CantidadTotalMovimientosSitema As String

        'Cantidad de créditos (pago a los funcionarios): 780
        Public Property CantidadTotalCreditos As String

        'Cantidad de débito siempre debe de ser: 1
        Public Property CantidadTotalDebitos As String
    End Class


    ''' <summary>
    ''' Esta fila será la que detalla la información de la empresa que realiza el pago. realizando el patrono.
    ''' </summary>
    Public Class Fila2
        ''' <summary>
        ''' BP SALARIO:
        '''DA|16101000100264957||||296688188.07||||544||EMPRESAPRUEBA|||||||||||EMPRESA PRUEBA|||3102688789|31026887891.1.1443753||
        '''BP PROVEEDORES : 
        '''DA|16101000100264957||||296688188.07||||544||EMPRESAPRUEBA|||||||||||EMPRESA PRUEBA|||3102688789|31026887891.3.1443753||
        ''' </summary>
        ''' <returns></returns>
        Public Property Encabezado As String
        Public Property CuentaClientePatrono As String
        Public Property MontoTotalDebito As String
        Public Property CodigoInvariable As String
        Public Property NombreEmpresa As String

        Public Property CedulaEmpresa As String

        Public Property CRRBILLINGCUSTOMER As String
    End Class

    ''' <summary>
    '''Se verá el detalla de los pagos que se les realizan a los colaboradores/proveedores.
    ''' </summary>
    Public Class Fila3
        ''' <summary>
        ''' BP SALARIO:
        ''' DA|16100011107150916||||374351.47||||545||NOMBRECOLABORADOR|||||||DESCRIPCION PAGO||||NOMBRE COLABORADOR|||401580007|31026887891.1.1114894||
        ''' BP PROVEEDOR : 
        ''' DA|16100011107150916||||374351.47||||545||NOMBREPROVEEDOR|||||||DESCRIPCION PAGO||||NOMBRE COLABORADOR|||401580007|31026887891.3.1114894||
        ''' </summary>
        ''' <returns></returns>
        Public Property Encabezado As String
        Public Property CuentaClienteColaborador As String
        Public Property MontoAcreditarSalario As Double
        Public Property CodigoInvariable As Double

        Public Property DescripcionPago As String
        Public Property CedulaEmpresa As String
        Public Property NombreColaborador As String
        Public Property CedulaColaborador As String
        Public Property CRRBILLINGCUSTOMER As String

    End Class
End Class
