Imports System.Net.Http

Public Class TokenHacienda

    Public Property accessToken As String
    Public Property refreshToken As String

    'Public Sub GetTokenHacienda(usuario As String, password As String)
    '    Try
    '        accessToken = ""
    '        refreshToken = ""

    '        Dim IDP_CLIENT_ID = VariablesGlobales.IDP_CLIENT_ID
    '        Dim IDP_URI = VariablesGlobales.IDP_URI

    '        Dim http As HttpClient = New HttpClient
    '        Dim param = New List(Of KeyValuePair(Of String, String))()
    '        param.Add(New KeyValuePair(Of String, String)("client_id", IDP_CLIENT_ID))
    '        param.Add(New KeyValuePair(Of String, String)("grant_type", "password"))
    '        param.Add(New KeyValuePair(Of String, String)("username", usuario))
    '        param.Add(New KeyValuePair(Of String, String)("password", password))
    '        Dim content As FormUrlEncodedContent = New FormUrlEncodedContent(param)

    '        Dim response As HttpResponseMessage = http.PostAsync(IDP_URI, content).Result
    '        Dim res As String = response.Content.ReadAsStringAsync.Result
    '        Dim tk As Token = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(res)
    '        If response.StatusCode <> Net.HttpStatusCode.OK Then
    '            Throw New Exception("Error: " + response.GetHashCode)
    '        End If

    '        accessToken = tk.access_token
    '        refreshToken = tk.refresh_token

    '    Catch e As Exception
    '        Throw
    '    End Try
    'End Sub


    Public Sub GetTokenHacienda(usuario As String, password As String, Tipo As String, CodSeguridad As String, refresh As Boolean)

        Dim IDP_CLIENT_ID
        Dim IDP_URI
        Dim http As HttpClient
        Dim param
        Dim content As FormUrlEncodedContent
        Dim response As New HttpResponseMessage
        Dim res As String
        Dim tk As New Token
        Dim Obj_Funciones As New Class_funcionesSQL
        Try
            accessToken = ""
            refreshToken = ""

            'PRODUCCION
            'IDP_CLIENT_ID = "api-prod"
            'PRUEBAS
            ' IDP_CLIENT_ID = "api-stag"

            IDP_CLIENT_ID = VariablesGlobales.IDP_CLIENT_ID

            'PRODUCCION
            'IDP_URI =!https://idp.comprobanteselectronicos.go.cr/auth/realms/rut/protocol/openid-connect/token"

            'PRUEBAS
            'IDP_URI = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token"

            IDP_URI = VariablesGlobales.IDP_URI

            http = New HttpClient
            param = New List(Of KeyValuePair(Of String, String))()
            '******************************* json para refrescar Token **********************************************
            '{ "grant_type": "refresh_token", "client_id": "YOUR_CLIENT_ID", "client_secret": "YOUR_CLIENT_SECRET", "refresh_token": "YOUR_REFRESH_TOKEN" }'
            '******************************* json para obtener un Token nuevo **********************************************
            '{ "grant_type": "password", "client_id": "YOUR_CLIENT_ID", "client_secret": "YOUR_CLIENT_SECRET" }'

            If refresh = True Then 'si loque quiere es refrescar el token entra

                param.Add(New KeyValuePair(Of String, String)("grant_type", "refresh_token")) '
                param.Add(New KeyValuePair(Of String, String)("refresh_token", VariablesGlobales.TOKEN_REFRESH)) '
            Else
                param.Add(New KeyValuePair(Of String, String)("grant_type", "password")) '
            End If

            param.Add(New KeyValuePair(Of String, String)("client_id", IDP_CLIENT_ID))
            param.Add(New KeyValuePair(Of String, String)("username", usuario))
            param.Add(New KeyValuePair(Of String, String)("password", password))
            content = New FormUrlEncodedContent(param)
            Dim Reintento As Integer = 0
            Do
                response = http.PostAsync(IDP_URI, content).Result
                res = response.Content.ReadAsStringAsync.Result
                tk = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(res)

                If response.StatusCode <> Net.HttpStatusCode.OK Then
                    'Throw New Exception("Error: " + response.GetHashCode)
                    VariablesGlobales.Obj_Log.Log("ERROR GetTokenHacienda Reintento : " & Reintento & " StatusCode: [" & response.StatusCode & " ] [" & CodSeguridad & "] ", Tipo)
                    Reintento += 1
                End If
            Loop While Reintento < 4 And response.StatusCode <> Net.HttpStatusCode.OK 'reintenta siempre que reintento sea menor a 4 y el estado sea diferente de OK

            accessToken = tk.access_token 'hasta 5min
            refreshToken = tk.refresh_token 'hace un refresh para alargar la vida del token hasta 10 horas

            VariablesGlobales.TOKEN_REFRESH = refreshToken
            VariablesGlobales.TOKEN = accessToken
        Catch ex As Exception
            Dim Respuesta As String = ""
            Try
                Respuesta = res.Substring(370, 62)
            Catch ex2 As Exception

            End Try
            IDP_CLIENT_ID = Nothing
            IDP_URI = Nothing
            http = Nothing
            param = Nothing
            content = Nothing
            response = Nothing
            res = Nothing
            tk = Nothing

            VariablesGlobales.Obj_Log.Log("ERROR GetTokenHacienda [" & ex.Message & " ] [" & CodSeguridad & "] [" & Respuesta & "] ", Tipo)
            If Tipo = "FE" Then

                'VariablesGlobales.Obj_TestFactura.List_FE.Items.Insert(0, "ERROR en GetTokenHacienda  [ " & ex.Message & "] Factura[" & CodSeguridad & "] [" & Respuesta & "] [ " & Now & " ]")
            ElseIf Tipo = "NC" Then

                'VariablesGlobales.Obj_TestFactura.List_NC.Items.Insert(0, "ERROR en GetTokenHacienda  [ " & ex.Message & " ] Nota Credito[" & CodSeguridad & "] [" & Respuesta & "] [ " & Now & " ]")
            ElseIf Tipo = "ND" Then

                'VariablesGlobales.Obj_TestFactura.List_ND.Items.Insert(0, "ERROR en GetTokenHacienda  [ " & ex.Message & " ] Nota Debito[" & CodSeguridad & "] [" & Respuesta & "] [ " & Now & " ]")
            ElseIf Tipo = "TE" Then

                'VariablesGlobales.Obj_TestFactura.List_TE.Items.Insert(0, "ERROR EN GetTokenHacienda  [ " & ex.Message & " ] [" & Respuesta & "]")
            Else
                MsgBox("ERROR en GetTokenHacienda [ " & ex.Message & " ] comprobante[" & CodSeguridad & "] [" & Respuesta & "]")
            End If
            Dim obj_Fecha As New FechaManager
            'reintenta obtener el toquen
            '  GetTokenHacienda(usuario, password, Tipo, CodSeguridad)
            'Aqui actualizar los estado  del comprobante
            Obj_Funciones.ActualizaEstado(CodSeguridad, "TimeOut", obj_Fecha.FormatoFechaSql(Date.Now), "Error al obtener token [ " & Respuesta & " ]", Tipo)
            Obj_Funciones = Nothing
            Respuesta = Nothing
            obj_Fecha = Nothing

        End Try
    End Sub

End Class
