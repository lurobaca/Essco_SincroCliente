Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ExportarAExcell


    Public Function LimpiaPedido(ByVal DGV As DataGridView)

        Dim Tbl_Pedido As New DataTable
        Tbl_Pedido.Columns.Add("Alterno")
        Tbl_Pedido.Columns.Add("ItemCode")
        Tbl_Pedido.Columns.Add("ItemName")
        Tbl_Pedido.Columns.Add("Pd_Unid")
        Tbl_Pedido.Columns.Add("Pd_CJs")
        Tbl_Pedido.Columns.Add("Pack")
        Tbl_Pedido.Columns.Add("Precio_Costo")
        For Each reg As DataGridViewRow In DGV.Rows
            If CDbl(reg.Cells(21).Value) <> 0 Then
                Dim Enc_dr As DataRow = Tbl_Pedido.NewRow
                Enc_dr("Alterno") = reg.Cells(5).Value
                Enc_dr("ItemCode") = reg.Cells(6).Value
                Enc_dr("ItemName") = reg.Cells(7).Value
                Enc_dr("Pd_Unid") = reg.Cells(21).Value
                Enc_dr("Pd_CJs") = reg.Cells(22).Value
                Enc_dr("Pack") = reg.Cells(9).Value
                Enc_dr("Precio_Costo") = reg.Cells(8).Value
                Tbl_Pedido.Rows.Add(Enc_dr)
                Tbl_Pedido.AcceptChanges()
            End If
        Next
        
        Return Tbl_Pedido ' luego de eliminar los pedido en cero devuelve la tabla para exportarla a excell
    End Function



    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String)

        Try

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)

            With objHojaExcel
                .Visible = Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                'Encabezado  
                .Range("A1:C1").Merge()
                .Range("A1:C1").Value = "ORDEN DE COMPRA"
                '.Range("A1:L1").Font.Bold = True
                '.Range("A1:L1").Font.Size = 15
                'Copete  
                .Range("A2:C2").Merge()
                .Range("A2:C2").Value = titulo
                '.Range("A2:L2").Font.Bold = True
                ' .Range("A2:L2").Font.Size = 12

                Const primeraLetra As Char = "A"
                Const primerNumero As Short = 3
                Dim Letra As Char, UltimaLetra As Char
                Dim Numero As Integer, UltimoNumero As Integer
                Dim cod_letra As Byte = Asc(primeraLetra) - 1
                Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
                Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
                'Establecer formatos de las columnas de la hija de cálculo  
                Dim strColumna As String = ""
                Dim LetraIzq As String = ""
                Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
                Letra = primeraLetra
                Numero = primerNumero
                Dim objCelda As Excel.Range

                'Recorre las columnas
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    'solo muestra las columnas con indice 1,7,21,22 
                    If c.Index = 5 Or c.Index = 7 Or c.Index = 21 Or c.Index = 22 Then


                        'If c.Visible Then 'Verifica si la columna es visitle
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If

                        strColumna = LetraIzq + Letra + Numero.ToString
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = c.HeaderText
                        ' objCelda.EntireColumn.Font.Size = 8
                        'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                        If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                            objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                        End If
                    End If
                    'End If
                Next

                Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
                objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
                UltimaLetra = Letra
                Dim UltimaLetraIzq As String = LetraIzq

                'CARGA DE DATOS  
                Dim i As Integer = Numero + 1

                For Each reg As DataGridViewRow In DataGridView1.Rows
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For Each c As DataGridViewColumn In DataGridView1.Columns

                        If c.Index = 5 Or c.Index = 7 Or c.Index = 21 Or c.Index = 22 Then



                            'If c.Visible Then
                            If Letra = "Z" Then
                                Letra = primeraLetra
                                cod_letra = Asc(primeraLetra)
                                cod_LetraIzq += 1
                                LetraIzq = Chr(cod_LetraIzq)
                            Else
                                cod_letra += 1
                                Letra = Chr(cod_letra)
                            End If
                            strColumna = LetraIzq + Letra
                            ' acá debería realizarse la carga  
                            If c.Index = 21 Or c.Index = 22 Then
                                If reg.Cells(c.Index).Value = 0 Then
                                    'borrar la fila
                                    'objHojaExcel.Rows(i).Delete()


                                Else
                                    .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", FormatNumber(reg.Cells(c.Index).Value, 2))
                                End If

                            Else
                                .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value) 'Le asigna el valor a la celda
                            End If

                            '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                            '.Range(strColumna + i, strColumna + i).In()  

                            'End If
                        End If
                    Next
                    Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                    objRangoReg.Rows.BorderAround()
                    objRangoReg.Select()
                    i += 1
                Next
                UltimoNumero = i

                'Dibujar las líneas de las columnas  
                LetraIzq = ""
                cod_LetraIzq = Asc("A")
                cod_letra = Asc(primeraLetra)
                Letra = primeraLetra
                For Each c As DataGridViewColumn In DataGridView1.Columns

                    If c.Index = 1 Or c.Index = 7 Or c.Index = 21 Or c.Index = 22 Then
                        If c.Visible Then
                            objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                            objCelda.BorderAround()
                            If Letra = "Z" Then
                                Letra = primeraLetra
                                cod_letra = Asc(primeraLetra)
                                LetraIzq = Chr(cod_LetraIzq)
                                cod_LetraIzq += 1
                            Else
                                cod_letra += 1
                                Letra = Chr(cod_letra)
                            End If
                        End If
                    End If
                Next

                'Dibujar el border exterior grueso  
                Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
                objRango.Select()
                objRango.Columns.AutoFit()
                objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)


            End With

            '------------ RECORREMOS LAS FILAS DEL ARCHIVO Y BORRAMOS LAS QUE TENGA PEDIDO EN 0

            '   objHojaExcel.Rows(i).Delete()

            'Indica la ruta donde se cuardara el archivo guardado
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
            'm_Excel.ActiveWorkbook.Save()
            m_Excel.ActiveWorkbook.SaveAs("M:\IMPORTACION\ORDENESDECOMPRA\Pedido_" & Now.Day & "_" & Now.Month & "_" & Now.Year & ".xls")
            m_Excel.ActiveWorkbook.Close(False)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ExportarDatosExcel2(ByVal Tbl_Pedido As DataTable, ByVal titulo As String)

        Try

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)

            With objHojaExcel
                .Visible = Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                'Encabezado  
                .Range("A1:C1").Merge()
                .Range("A1:C1").Value = "ORDEN DE COMPRA"
                '.Range("A1:L1").Font.Bold = True
                '.Range("A1:L1").Font.Size = 15
                'Copete  
                .Range("A2:C2").Merge()
                .Range("A2:C2").Value = titulo
                '.Range("A2:L2").Font.Bold = True
                ' .Range("A2:L2").Font.Size = 12

                Const primeraLetra As Char = "A"
                Const primerNumero As Short = 3
                Dim Letra As Char, UltimaLetra As Char
                Dim Numero As Integer, UltimoNumero As Integer
                Dim cod_letra As Byte = Asc(primeraLetra) - 1
                Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
                Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
                'Establecer formatos de las columnas de la hija de cálculo  
                Dim strColumna As String = ""
                Dim LetraIzq As String = ""
                Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
                Letra = primeraLetra
                Numero = primerNumero
                Dim objCelda As Excel.Range
                objCelda = .Range("A3", Type.Missing)
                objCelda.Value = "Alterno"

                objCelda = .Range("B3", Type.Missing)
                objCelda.Value = "Codigo"


                objCelda = .Range("C3", Type.Missing)
                objCelda.Value = "Descripcion"
                objCelda = .Range("D3", Type.Missing)
                objCelda.Value = "Costo"
                objCelda = .Range("E3", Type.Missing)
                objCelda.Value = "Pack"
                objCelda = .Range("F3", Type.Missing)
                objCelda.Value = "Pedido Unidades"
                objCelda = .Range("G3", Type.Missing)
                objCelda.Value = "Pedido Cajas"




                ''Recorre las columnas
                'For Each c As DataGridViewColumn In Tbl_Pedido.Columns
                '    'solo muestra las columnas con indice 1,7,21,22 
                '    'If c.Index = 5 Or c.Index = 7 Or c.Index = 21 Or c.Index = 22 Then


                '    'If c.Visible Then 'Verifica si la columna es visitle
                '    If Letra = "Z" Then
                '        Letra = primeraLetra
                '        cod_letra = Asc(primeraLetra)
                '        cod_LetraIzq += 1
                '        LetraIzq = Chr(cod_LetraIzq)
                '    Else
                '        cod_letra += 1
                '        Letra = Chr(cod_letra)
                '    End If

                '    strColumna = LetraIzq + Letra + Numero.ToString
                '    objCelda = .Range(strColumna, Type.Missing)
                '    objCelda.Value = c.HeaderText
                '    ' objCelda.EntireColumn.Font.Size = 8
                '    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                '    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                '        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                '    End If
                '    'End If
                '    'End If
                'Next

                Dim objRangoEncab As Excel.Range = .Range("A3", "E3")
                objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
                UltimaLetra = Letra
                Dim UltimaLetraIzq As String = LetraIzq

                'CARGA DE DATOS  
                Dim i As Integer = Numero + 1

                For Each row As DataRow In Tbl_Pedido.Rows
                    Dim CodBourne As String = CStr(row("ItemCode"))
                    Dim Alterno As String = CStr(row("Alterno"))
                    Dim ItemName As String = CStr(row("ItemName"))
                    Dim Pd_Unid As String = CStr(row("Pd_Unid"))
                    Dim Pd_CJs As String = CStr(row("Pd_CJs"))
                    Dim Pack As String = CStr(row("Pack"))
                    Dim Costo As String = CStr(row("Precio_Costo"))

                    .Cells(i, "A") = row("Alterno")
                    .Cells(i, "B") = row("ItemCode")
                    .Cells(i, "C") = row("ItemName")
                    .Cells(i, "D") = FormatNumber(row("Precio_Costo"), 2)
                    .Cells(i, "E") = FormatNumber(row("Pack"), 2)
                    .Cells(i, "F") = FormatNumber(row("Pd_Unid"), 2)
                    .Cells(i, "G") = FormatNumber(row("Pd_CJs"), 2)


                    Dim objRangoReg As Excel.Range = .Range("A" + i.ToString, "G" + i.ToString)
                    objRangoReg.Rows.BorderAround()
                    objRangoReg.Select()
                    i += 1

                Next

                'For Each reg As DataGridViewRow In Tbl_Pedido.Rows
                '    LetraIzq = ""
                '    cod_LetraIzq = Asc(primeraLetra) - 1
                '    Letra = primeraLetra
                '    cod_letra = Asc(primeraLetra) - 1
                '    For Each c As DataGridViewColumn In Tbl_Pedido.Columns

                '        'If c.Index = 5 Or c.Index = 7 Or c.Index = 21 Or c.Index = 22 Then



                '        'If c.Visible Then
                '        If Letra = "Z" Then
                '            Letra = primeraLetra
                '            cod_letra = Asc(primeraLetra)
                '            cod_LetraIzq += 1
                '            LetraIzq = Chr(cod_LetraIzq)
                '        Else
                '            cod_letra += 1
                '            Letra = Chr(cod_letra)
                '        End If
                '        strColumna = LetraIzq + Letra
                '        ' acá debería realizarse la carga  
                '        If c.Index = 21 Or c.Index = 22 Then
                '            If reg.Cells(c.Index).Value = 0 Then
                '                'borrar la fila
                '                'objHojaExcel.Rows(i).Delete()


                '            Else
                '                .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", FormatNumber(reg.Cells(c.Index).Value, 2))
                '            End If

                '        Else
                '            .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value) 'Le asigna el valor a la celda
                '        End If

                '        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                '        '.Range(strColumna + i, strColumna + i).In()  

                '        'End If
                '        'End If
                '    Next
                '    Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                '    objRangoReg.Rows.BorderAround()
                '    objRangoReg.Select()
                '    i += 1
                'Next
                UltimoNumero = i

                ''Dibujar las líneas de las columnas  
                'LetraIzq = ""
                'cod_LetraIzq = Asc("A")
                'cod_letra = Asc(primeraLetra)
                'Letra = primeraLetra
                'For Each c As DataGridViewColumn In Tbl_Pedido.Columns

                '    If c.Index = 1 Or c.Index = 7 Or c.Index = 21 Or c.Index = 22 Then
                '        If c.Visible Then
                '            objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                '            objCelda.BorderAround()
                '            If Letra = "Z" Then
                '                Letra = primeraLetra
                '                cod_letra = Asc(primeraLetra)
                '                LetraIzq = Chr(cod_LetraIzq)
                '                cod_LetraIzq += 1
                '            Else
                '                cod_letra += 1
                '                Letra = Chr(cod_letra)
                '            End If
                '        End If
                '    End If
                'Next

                'Dibujar el border exterior grueso  
                Dim objRango As Excel.Range = .Range("A3", "G1000")
                objRango.Select()
                objRango.Columns.AutoFit()
                objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)


            End With

            '------------ RECORREMOS LAS FILAS DEL ARCHIVO Y BORRAMOS LAS QUE TENGA PEDIDO EN 0

            '   objHojaExcel.Rows(i).Delete()

            'Indica la ruta donde se cuardara el archivo guardado
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
            'm_Excel.ActiveWorkbook.Save()
            'Crea la carpea del proveedor si no existe

            'comprobar si existe directorio


            Dim ruta As String = Class_VariablesGlobales.RutaExcellPedidos & titulo
            'Dim ruta As String = “C:\Users\Luis Roberto Bastos\Documents\pedidos\” & titulo
            If Directory.Exists(ruta) Then
                'la carpeta exise
                m_Excel.ActiveWorkbook.SaveAs(ruta & "\" & Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text & "_Fecha_" & Now.Day & "_" & Now.Month & "_" & Now.Year & ".xlsx")
            Else
                'no existe
                My.Computer.FileSystem.CreateDirectory(ruta)
                m_Excel.ActiveWorkbook.SaveAs(ruta & "\" & Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text & "_Fecha_" & Now.Day & "_" & Now.Month & "_" & Now.Year & ".xlsx")
            End If



            m_Excel.ActiveWorkbook.Close(True)
            'm_Excel.ActiveWindow.Close(True)
            'objLibroExcel.Close()
            m_Excel.Quit()

            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_Excel)
        Catch ex As Exception
            MsgBox("Error al exportar a excell ExportarDatosExcel2 " & ex.Message)
        End Try
    End Sub
    Public Function ExportToPDF(ByVal rpt As ReportDocument, ByVal Conseutivo As String, ByVal Path As String) As String


        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()

        Try


            'If Not Path.EndsWith("\") Then
            '    Path += "\"
            'End If

            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.
            'If File.Exists(Path & Clave) = False Then
            '    My.Computer.FileSystem.CreateDirectory(Path & Clave)
            'End If
            vFileName = Path & ".pdf"

            '  vFileName = Path & Conseutivo & "_Fecha_" & Now.Day & "_" & Now.Month & "_" & Now.Year & ".pdf"

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If

            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            '--------------- LIBERAMOS MEMORIAS-----------------
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing


        Catch ex As Exception

            MsgBox("Error al generar PDF " & ex.Message)
            'If File.Exists(vFileName) = False Then
            '    'vFileName = Nothing
            '    'diskOpts = Nothing
            '    'Path = Nothing
            '    ExportToPDF(rpt, Conseutivo, Path)
            'End If
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing

        End Try

        Return vFileName
    End Function

    Public Sub Exportar(ByVal Dgv As DataGridView, ByVal titulo As String)
        Try
            Class_VariablesGlobales.Contador = 0
            Dim app As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
            Dim workbook As Microsoft.Office.Interop.Excel._Workbook = app.Workbooks.Add(Type.Missing)
            Dim worksheet As Microsoft.Office.Interop.Excel._Worksheet = Nothing
            worksheet = workbook.Sheets("Hoja1")
            worksheet = workbook.ActiveSheet
            'Aca se agregan las cabeceras de nuestro datagrid.

            For i As Integer = 1 To Dgv.Columns.Count
                worksheet.Cells(1, i) = Dgv.Columns(i - 1).HeaderText
            Next

            If Dgv.Rows.Count > 0 Then


                'Aca se ingresa el detalle recorrera la tabla celda por celda
                Class_VariablesGlobales.frmControl.ProgBar.Maximum = Dgv.Rows.Count - 1
                Class_VariablesGlobales.frmControl.Lbl_Fin.Text = Dgv.Rows.Count - 1
                For i As Integer = 0 To Dgv.Rows.Count - 2
                    Class_VariablesGlobales.DetalleCarga = Dgv.Rows(i).Cells(5).Value.ToString()
                    Class_VariablesGlobales.Contador += 1
                    For j As Integer = 0 To Dgv.Columns.Count - 1

                        'Detecta cuando va por una columna que contiene monto en plata
                        If j = 9 Or j = 13 Or j = 14 Or j = 17 Or j = 20 Or j = 23 Or j = 26 Or j = 29 Or j = 32 Or j = 35 Or j = 38 Or j = 41 Or j = 44 Or j = 47 Or j = 50 Or j = 53 Or j = 56 Or j = 59 Or j = 62 Then
                            worksheet.Cells(i + 2, j + 1) = CDbl(Dgv.Rows(i).Cells(j).Value.ToString())
                        Else
                            'Detecta cuando pasa por el codigo y codigo de barras
                            If j = 5 Or j = 7 Then
                                worksheet.Cells(i + 2, j + 1).NumberFormat = "@"
                            End If

                            worksheet.Cells(i + 2, j + 1) = Dgv.Rows(i).Cells(j).Value.ToString()


                        End If


                    Next
                Next
                Class_VariablesGlobales.Contador = 0
                'Aca le damos el formato a nuestro excel

                worksheet.Rows.Item(1).Font.Bold = 1
                worksheet.Rows.Item(1).HorizontalAlignment = 3
                worksheet.Columns.AutoFit()
                worksheet.Columns.HorizontalAlignment = 2

                app.Visible = True
                app = Nothing
                workbook = Nothing
                worksheet = Nothing
                FileClose(1)
                GC.Collect()

                MsgBox("Exportacion termino correctamente")
                Class_VariablesGlobales.frmControl.ProgBar.Maximum = 0
                Class_VariablesGlobales.frmControl.Lbl_Fin.Text = 0
                Class_VariablesGlobales.frmControl.Lbl_Inicio.Text = 0
                Class_VariablesGlobales.DetalleCarga = "Exportacion termino correctamente"

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Public Sub ExportarComprobantesElectronicos(ByVal Dgv As DataTable, ByVal titulo As String)
        Try
            Class_VariablesGlobales.Contador = 0
            Dim app As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
            Dim workbook As Microsoft.Office.Interop.Excel._Workbook = app.Workbooks.Add(Type.Missing)
            Dim worksheet As Microsoft.Office.Interop.Excel._Worksheet = Nothing
            worksheet = workbook.Sheets("Hoja1")
            worksheet = workbook.ActiveSheet
            'Aca se agregan las cabeceras de nuestro datagrid.

            For i As Integer = 1 To Dgv.Columns.Count
                worksheet.Cells(1, i) = Dgv.Columns.Item(i - 1).ToString


            Next

            If Dgv.Rows.Count > 0 Then


                'Aca se ingresa el detalle recorrera la tabla celda por celda
                Class_VariablesGlobales.frmControl.ProgBar.Maximum = Dgv.Rows.Count - 1
                Class_VariablesGlobales.frmControl.Lbl_Fin.Text = Dgv.Rows.Count - 1
                For i As Integer = 0 To Dgv.Rows.Count - 2
                    Class_VariablesGlobales.DetalleCarga = Dgv.Rows(i).Item(5).ToString()
                    Class_VariablesGlobales.Contador += 1
                    For j As Integer = 0 To Dgv.Columns.Count - 1

                        'Detecta cuando va por una columna que contiene monto en plata
                        If j = 7 Or j = 8 Then
                            worksheet.Cells(i + 2, j + 1) = CDbl(Dgv.Rows(i).Item(j).ToString())
                        Else


                            worksheet.Cells(i + 2, j + 1) = Dgv.Rows(i).Item(j).ToString()


                        End If


                    Next
                Next
                Class_VariablesGlobales.Contador = 0
                'Aca le damos el formato a nuestro excel


                worksheet.Rows.Item(1).Font.Bold = 1
                worksheet.Rows.Item(1).HorizontalAlignment = 3
                worksheet.Columns.AutoFit()
                worksheet.Columns.HorizontalAlignment = 2

                app.Visible = True
                app = Nothing
                workbook = Nothing
                worksheet = Nothing
                FileClose(1)
                GC.Collect()

                MsgBox("Exportacion termino correctamente")
                Class_VariablesGlobales.frmControl.ProgBar.Maximum = 0
                Class_VariablesGlobales.frmControl.Lbl_Fin.Text = 0
                Class_VariablesGlobales.frmControl.Lbl_Inicio.Text = 0
                Class_VariablesGlobales.DetalleCarga = "Exportacion termino correctamente"

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub


    Public Sub ExportarPlantilla(ByVal Dgv As DataGridView, ByVal titulo As String)
        Try
            Class_VariablesGlobales.Contador = 0
            Dim app As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
            Dim workbook As Microsoft.Office.Interop.Excel._Workbook = app.Workbooks.Add(Type.Missing)
            Dim worksheet As Microsoft.Office.Interop.Excel._Worksheet = Nothing
            worksheet = workbook.Sheets("Hoja1")
            worksheet = workbook.ActiveSheet
            'Aca se agregan las cabeceras de nuestro datagrid.

            For i As Integer = 1 To Dgv.Columns.Count
                worksheet.Cells(1, i) = Dgv.Columns(i - 1).HeaderText
            Next


            'Aca se ingresa el detalle recorrera la tabla celda por celda
            Class_VariablesGlobales.frmControl.ProgBar.Maximum = Dgv.Rows.Count - 1
            Class_VariablesGlobales.frmControl.Lbl_Fin.Text = Dgv.Rows.Count - 1
            For i As Integer = 0 To Dgv.Rows.Count - 2
                Class_VariablesGlobales.DetalleCarga = Dgv.Rows(i).Cells(0).Value.ToString()
                Class_VariablesGlobales.Contador += 1
                For j As Integer = 0 To Dgv.Columns.Count - 1

                    '    'Detecta cuando va por una columna que contiene monto en plata
                    '    If j = 9 Or j = 13 Or j = 14 Or j = 17 Or j = 20 Or j = 23 Or j = 26 Or j = 29 Or j = 32 Or j = 35 Or j = 38 Or j = 41 Or j = 44 Or j = 47 Or j = 50 Or j = 53 Or j = 56 Or j = 59 Or j = 62 Then
                    '        worksheet.Cells(i + 2, j + 1) = CDbl(Dgv.Rows(i).Cells(j).Value.ToString())
                    '    Else
                    '        'Detecta cuando pasa por el codigo y codigo de barras
                    '        If j = 5 Or j = 7 Then
                    worksheet.Cells(i + 2, j + 1).NumberFormat = "@"
                    If j = 2 Then
                        worksheet.Cells(i + 2, j + 1) = "01"
                    Else
                        worksheet.Cells(i + 2, j + 1) = Dgv.Rows(i).Cells(j).Value.ToString()

                    End If


                    '        End If



                    '    End If


                Next
            Next
                Class_VariablesGlobales.Contador = 0
            'Aca le damos el formato a nuestro excel

            worksheet.Rows.Item(1).Font.Bold = 1
            worksheet.Rows.Item(1).HorizontalAlignment = 3
            worksheet.Columns.AutoFit()
            worksheet.Columns.HorizontalAlignment = 2

            app.Visible = True
            app = Nothing
            workbook = Nothing
            worksheet = Nothing
            FileClose(1)
            GC.Collect()

            MsgBox("Exportacion termino correctamente")
            Class_VariablesGlobales.frmControl.ProgBar.Maximum = 0
            Class_VariablesGlobales.frmControl.Lbl_Fin.Text = 0
            Class_VariablesGlobales.frmControl.Lbl_Inicio.Text = 0
            Class_VariablesGlobales.frmControl.Lbl_Detaller.Text = ""

            Class_VariablesGlobales.DetalleCarga = "Exportacion termino correctamente"


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub



    Public Function LeerExcell(ByVal Archivo As String)
        Dim oApp As Excel.Application ' Objeto Application
        Dim oWorkBook As Excel.Workbook ' Libro de trabajo
        ' Creamos una nueva instancia de Excel
        oApp = New Excel.Application
        ' Abro el libro de trabajo
        oWorkBook = oApp.Workbooks.Open(Archivo)

        ' Referencio la hoja llamada Hoja4
        Dim oSheet As Excel.Worksheet = _
        CType(oWorkBook.Sheets("Hoja1"), Excel.Worksheet)

        For Each row As DataRow In oSheet.Rows
            MsgBox(row(0)) 'columna1
            MsgBox(row(1)) 'columna 2
            MsgBox(row(2)) 'Columna 3
            MsgBox(row(3)) 'Columna 4
        Next

        ' Eliminamos las filas de la 1 a la 7
        oSheet.Range("1:7").Delete()
        ' Guardamos los cambios
        oWorkBook.Save()
        ' Cierro el libro
        oWorkBook.Close()
        ' Cerramos Excel
        oApp.Quit()
        oApp = Nothing
    End Function


    Private Function GetDataExcel(ByVal fileName As String, ByVal sheetName As String) As DataTable

        ' Comprobamos los parámetros.
        '
        If ((String.IsNullOrEmpty(fileName)) OrElse _
          (String.IsNullOrEmpty(sheetName))) Then _
          Throw New ArgumentNullException()

        Try
            Dim extension As String = IO.Path.GetExtension(fileName)

            Dim connString As String = "Data Source=" & fileName

            If (extension = ".xls") Then
                connString &= ";Provider=Microsoft.Jet.OLEDB.4.0;" & _
                       "Extended Properties='Excel 8.0;HDR=YES;IMEX=1'"

            ElseIf (extension = ".xlsx") Then
                connString &= ";Provider=Microsoft.ACE.OLEDB.12.0;" & _
                       "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'"
            Else
                Throw New ArgumentException( _
                  "La extensión " & extension & " del archivo no está permitida.")
            End If

            Using conexion As New OleDbConnection(connString)

                Dim sql As String = "SELECT * FROM [" & sheetName & "$]"
                Dim adaptador As New OleDbDataAdapter(sql, conexion)

                Dim dt As New DataTable("Excel")

                adaptador.Fill(dt)

                Return dt

            End Using

        Catch ex As Exception
            Throw

        End Try

    End Function

    '---------PARA LLAMAR A LA FUNCION GetDataExcel -------
    'Try
    '   Dim dt As DataTable = GetDataExcel("C:\Mis documentos\Libro1.xls", "Hoja1")
    '   quitafilasvacias(dt)
    '   DataGridView1.DataSource = dt
    ' Catch ex As Exception
    '   MessageBox.Show(ex.Message)
    ' End Try
    '---------PARA LLAMAR A LA FUNCION GetDataExcel -------
End Class
