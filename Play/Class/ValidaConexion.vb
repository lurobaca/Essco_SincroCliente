﻿Public Class ValidaConexion
    Public Function IsConnectionAvailable() As Boolean
        Try


            ' Returns True if connection is available 
            ' Replace www.yoursite.com with a site that 
            ' is guaranteed to be online - perhaps your 
            ' corporate site, or microsoft.com 
            Dim objUrl As New System.Uri("http://www.google.com/")
            'Dim objUrl As New System.Uri("https://api.comprobanteselectronicos.go.cr/")
            ' Setup WebRequest 
            Dim objWebReq As System.Net.WebRequest
            objWebReq = System.Net.WebRequest.Create(objUrl)
            Dim objResp As System.Net.WebResponse
            Try
                ' Attempt to get response and return True 
                objResp = objWebReq.GetResponse
                objResp.Close()
                objWebReq = Nothing
                objUrl = Nothing
                objResp = Nothing
                Return True
            Catch ex As Exception
                ' Error, exit and return False 
                objWebReq = Nothing
                Return False
            End Try
        Catch ex As Exception
            MsgBox("ERROR en IsConnectionAvailable " & ex.Message)
        End Try
    End Function

End Class
