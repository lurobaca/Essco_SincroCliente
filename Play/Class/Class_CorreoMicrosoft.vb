Imports Microsoft.Office.Interop

Public Class Class_CorreoMicrosoft

    'Public Function Lista()
    '    'Declare Objects of Outlook using Outlook._Application interface
    '    Dim objOutlook As Outlook._Application
    '    'Outlook Namespace will be current session
    '    Dim objNS As Outlook._NameSpace
    '    Try
    '        'Initialise objects created in Form Load
    '        objOutlook = New Outlook.Application()
    '        objNS = objOutlook.Session

    '        'Get the Contact folder
    '        Dim objAddressList As Outlook.MAPIFolder
    '        objAddressList = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)

    '        'Get all the contacts
    '        Dim objItems As Outlook.Items = objAddressList.Items
    '        Dim objContact As Outlook.ContactItem

    '        'Loop through all contacts and add to combo box
    '        For j = 1 To objItems.Count
    '            Try
    '                objContact = objItems(j)
    '                Class_VariablesGlobales.frmCreaPedido.ComboBox2.Items.Add(objContact.FullName)
    '            Catch ex As Exception

    '            End Try


    '        Next

    '        'clear memory
    '        objContact = Nothing
    '        objItems = Nothing
    '        objAddressList = Nothing
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Function

    Public Function AccessContacts(ByVal findLastName As String)
        'Declare Objects of Outlook using Outlook._Application interface
        Dim objOutlook As Outlook._Application
        'Outlook Namespace will be current session
        Dim objNS As Outlook._NameSpace
        'Initialise objects created in Form Load
        objOutlook = New Outlook.Application()
        objNS = objOutlook.Session
        Dim folderContacts As Outlook.MAPIFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
        Dim searchFolder As Outlook.Items = folderContacts.Items
        Dim counter As Integer = 0

        For Each foundContact As Outlook.ContactItem In searchFolder
            Try
                If foundContact.FirstName.Contains(findLastName) <> Nothing Then
                    foundContact.Display(False)
                    counter = counter + 1
                End If
            Catch ex As Exception

            End Try


        Next

        MessageBox.Show("You have " & counter & " contacts with last names that contain " & findLastName & ".")
        Return 0
    End Function


    'Public Function getcontactos()
    '    Try


    '        Dim iContact As Outlook.ContactItem
    '        Dim iFolder As Outlook.MAPIFolder
    '        Dim iNameSpace As Outlook.NameSpace
    '        Dim iOutlook As New Outlook.ApplicationClass

    '        iNameSpace = iOutlook.GetNamespace(«MAPI»)

    '        iFolder = iNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)

    '        'Me.lvContactos.Items.Clear()
    '        For Each iContact In iFolder.Items
    '            Dim itm As New ListViewItem
    '            itm.Text = iContact.FirstName
    '            itm.SubItems.Add(iContact.LastName)
    '            If Not IsNothing(iContact.Email1Address) Then
    '                If iContact.Email1Address.Trim.Length > 0 Then
    '                    itm.SubItems.Add(iContact.Email1Address)
    '                    '           Me.lvContactos.Items.Add(itm)
    '                End If
    '            End If
    '        Next
    '        'Me.sbDetalles.Panels(0).Text = «Contactos: » & Me.lvContactos.Items.Count
    '    Catch ex As Exception
    '        'MsgBox(ex.Message, MsgBoxStyle.Critical, «Envío de correos»)
    '    End Try
    'End Function

    'Private Sub ShowContactsFolderAsInitialAddressList()

    '    Dim addrLists As Outlook.AddressLists
    '    Dim contactsFolder As Outlook.Folder =
    '        CType(Application.Session.GetDefaultFolder(
    '        Outlook.OlDefaultFolders.olFolderContacts),
    '        Outlook.Folder)
    '    addrLists = Application.Session.AddressLists
    '    For Each addrList As Outlook.AddressList In addrLists
    '        Dim testFolder As Outlook.Folder =
    '        CType(addrList.GetContactsFolder(), Outlook.Folder)
    '        If Not (testFolder Is Nothing) Then
    '            ' Test to determine if Folder returned
    '            ' by GetContactsFolder has same EntryID
    '            ' as default Contacts folder.
    '            If (Application.Session.CompareEntryIDs(
    '                contactsFolder.EntryID, testFolder.EntryID)) Then
    '                Dim snd As Outlook.SelectNamesDialog =
    '                    Application.Session.GetSelectNamesDialog()
    '                snd.InitialAddressList = addrList
    '                snd.Display()
    '            End If
    '        End If
    '    Next
    'End Sub

    'Public Function FindContactEmailByName(ByVal firstName As String, ByVal lastName As String)
    '    Dim outlookNameSpace As Outlook.[NameSpace] = Me.Application.GetNamespace("MAPI")
    '    Dim contactsFolder As Outlook.MAPIFolder = outlookNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts)
    '    Dim contactItems As Outlook.Items = contactsFolder.Items

    '    Try
    '        Dim contact As Outlook.ContactItem = CType(contactItems.Find(String.Format("[FirstName]='{0}' and " & "[LastName]='{1}'", firstName, lastName)), Outlook.ContactItem)

    '        If contact IsNot Nothing Then
    '            contact.Display(True)
    '        Else
    '            MessageBox.Show("The contact information was not found.")
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return 0
    'End Function



    'Private Sub AccessContacts(ByVal findLastName As String)
    '    Dim folderContacts As Outlook.MAPIFolder = Me.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
    '    Dim searchFolder As Outlook.Items = folderContacts.Items
    '    Dim counter As Integer = 0

    '    For Each foundContact As Outlook.ContactItem In searchFolder

    '        If foundContact.LastName.Contains(findLastName) Then
    '            foundContact.Display(False)
    '            counter = counter + 1
    '        End If
    '    Next

    '    MessageBox.Show("You have " & counter & " contacts with last names that contain " & findLastName & ".")
    'End Sub

End Class
