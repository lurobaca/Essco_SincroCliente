Public Class Propiedades
    Private FechaLicencia As String
    Private frmDeposAgente As Admin_Depositos_Agentes
    Private frmDeposChofer As Admin_Depositos_Choferes
    'contructor
    Public Sub New(ByVal P_FechaLicencia As String, ByVal P_frmDeposAgente As Admin_Depositos_Agentes)
        Me.FechaLicencia = P_FechaLicencia
    End Sub


    'obtiene o enviar informacion
    Public Property Valida() As String
        Get
            Return Me.FechaLicencia
        End Get

        Set(ByVal Value As String)
            Me.FechaLicencia = Value
        End Set
    End Property

    Public Property FrmDepAg() As Admin_Depositos_Agentes
        Get
            Return Me.frmDeposAgente
        End Get

        Set(ByVal Value As Admin_Depositos_Agentes)
            Me.frmDeposAgente = Value
        End Set
    End Property


    Public Property FrmDepChofer() As Admin_Depositos_Choferes
        Get
            Return Me.frmDeposChofer
        End Get

        Set(ByVal Value As Admin_Depositos_Choferes)
            Me.frmDeposChofer = Value
        End Set
    End Property

End Class
