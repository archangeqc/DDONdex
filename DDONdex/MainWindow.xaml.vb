Imports System.Data


Class MainWindow
    Dim materials As XElement

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        materials = XElement.Load("..\..\Data\Materials.xml")



        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub CbSearch_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CbSearch.SelectionChanged
        Dim query =
            From item In materials.<Materials>.<Item>
            Where item.<ID>.Value = CbSearch.SelectedValue
            Select item

        ValID.Text = query.<ID>.Value
        ValName.Text = query.<Name>.Value
        ValBazaar.Text = query.<Bazaar>.Value
    End Sub

    Public Delegate Function FilterSearch(obj As Object) As Boolean


    End Function

    Private Sub CbSearch_TextInput(sender As Object, e As TextCompositionEventArgs) Handles CbSearch.TextInput
        CbSearch.IsDropDownOpen = True
        CbSearch.ItemsSource =
           From item In materials.<Materials>.<Item>
           Where item.<ID>.Value.StartsWith(CbSearch.Text) Or item.<Name>.Value.ToLower.Contains(CbSearch.Text.ToLower)
           Select item.<ID>.Value, item.<Name>.Value, Display = item.<ID>.Value + " " + item.<Name>.Value
        CbSearch.DisplayMemberPath = "Display"
        CbSearch.SelectedValuePath = "ID"
        'CbSearch.Items.Filter

    End Sub

    Private Sub CbSearch_GotKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles CbSearch.GotKeyboardFocus
        CbSearch.IsDropDownOpen = True
    End Sub

    Private Sub CbSearch_LostKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles CbSearch.LostKeyboardFocus
        CbSearch.IsDropDownOpen = False
    End Sub

    Private Sub CbSearch_Loaded(sender As Object, e As RoutedEventArgs) Handles CbSearch.Loaded
        CbSearch.ItemsSource =
            From item In materials.<Materials>.<Item>
            Select item.<ID>.Value, item.<Name>.Value, Display = item.<ID>.Value + " " + item.<Name>.Value
        CbSearch.DisplayMemberPath = "Display"
        CbSearch.SelectedValuePath = "ID"
    End Sub

    Private Sub CbSearch_Initialized(sender As Object, e As EventArgs) Handles CbSearch.Initialized

    End Sub
End Class
