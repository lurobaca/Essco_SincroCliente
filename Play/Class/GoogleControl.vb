'Using the control
Public Class Form1
    Private GoogleControl1 As GoogleControl
    Sub New()
        ' This call is required by the Windows Form Designer.
        'InitializeComponent()
        '' Add any initialization after the InitializeComponent() call.
        'GoogleControl1 = New GoogleControl
        'GoogleControl1.Dock = DockStyle.Fill
        'Me.Controls.Add(GoogleControl1)
    End Sub
End Class
'The Control
'The class needs to be marked as com visible so the
'script in the GoogleMap.htm can call some of the subs.
<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
Public Class GoogleControl : Inherits UserControl
    Private WebBrowser1 As WebBrowser
    Private StatusStrip1 As StatusStrip
    Private StatusButtonDelete As ToolStripButton
    Private StatusLabelLatLng As ToolStripStatusLabel
    Private InitialZoom As Integer
    Private InitialLatitude As Double
    Private InitialLongitude As Double
    Private InitialMapType As GoogleMapType
    'I use this enum to store the current map
    'type into the application's settings.
    'So when the user closes the map on Satellite
    'mode it will be on Satellite mode the next 
    'time they open it.
    Public Enum GoogleMapType
        None
        RoadMap
        Terrain
        Hybrid
        Satellite
    End Enum
    Sub New()
        MyBase.New()
        WebBrowser1 = New WebBrowser
        StatusStrip1 = New StatusStrip
        StatusButtonDelete = New ToolStripButton
        StatusLabelLatLng = New ToolStripStatusLabel
        WebBrowser1.Dock = DockStyle.Fill
        WebBrowser1.AllowWebBrowserDrop = False
        WebBrowser1.IsWebBrowserContextMenuEnabled = False
        WebBrowser1.WebBrowserShortcutsEnabled = False
        WebBrowser1.ObjectForScripting = Me
        WebBrowser1.ScriptErrorsSuppressed = False
        AddHandler WebBrowser1.DocumentCompleted, AddressOf WebBrowser1_DocumentCompleted
        StatusStrip1.Dock = DockStyle.Bottom
        StatusStrip1.Items.Add(StatusButtonDelete)
        StatusStrip1.Items.Add(StatusLabelLatLng)
        StatusButtonDelete.Text = "Delete Markers"
        AddHandler StatusButtonDelete.Click, AddressOf StatusButtonDelete_Click
        Me.Controls.Add(WebBrowser1)
        Me.Controls.Add(StatusStrip1)
        'The default map settings.
        InitialZoom = 4
        InitialLatitude = 38
        InitialLongitude = -96.5
        InitialMapType = GoogleMapType.RoadMap
    End Sub
    Sub New(ByVal zoom As Integer, ByVal lat As Double, ByVal lng As Double, ByVal mapType As GoogleMapType)
        'This constructor could be used to start the map with different values
        'other than the default settings.
        Me.New()
        InitialZoom = zoom
        InitialLatitude = lat
        InitialLongitude = lng
        InitialMapType = mapType
    End Sub
    Private Sub GoogleControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Load the htm doc into the webrowser.
        'When it completes, intialize the map.
        WebBrowser1.DocumentText = My.Computer.FileSystem.ReadAllText("GoogleMap.htm")
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        'Initialize the google map with the initial settings.
        'The Initialize script function takes four parameters.
        'zoom, lat, lng, maptype.  Call the script passing the
        'parameters in.
        WebBrowser1.Document.InvokeScript("Initialize", New Object() {InitialZoom, InitialLatitude, InitialLongitude, CInt(InitialMapType)})
    End Sub
    Public Sub Map_MouseMove(ByVal lat As Double, ByVal lng As Double)
        'Called from the GoogleMap.htm script when ever the mouse is moved.
        StatusLabelLatLng.Text = "lat/lng: " & CStr(Math.Round(lat, 4)) & " , " & CStr(Math.Round(lng, 4))
    End Sub
    Public Sub Map_Click(ByVal lat As Double, ByVal lng As Double)
        'Add a marker to the map.
        Dim MarkerName As String = InputBox("Enter a Marker Name", "New Marker")
        If Not String.IsNullOrEmpty(MarkerName) Then
            'The script function AddMarker takes three parameters
            'name,lat,lng.  Call the script passing the parameters in.
            WebBrowser1.Document.InvokeScript("AddMarker", New Object() {MarkerName, lat, lng})
        End If
    End Sub
    Public Sub Map_Idle()
        'Would be a good place to load your own custom markers
        'from data source
    End Sub
    Private Sub StatusButtonDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Call the DeleteMarkers script in the htm doc.
        WebBrowser1.Document.InvokeScript("DeleteMarkers")
    End Sub
End Class