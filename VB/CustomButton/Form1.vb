Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace CustomButton
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' load some demo data
			Dim TempXViewsPrinting As DevExpress.XtraGrid.Design.XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
			gridView1.OptionsSelection.MultiSelect = True

			gridControl1.UseEmbeddedNavigator = True
			AddHandler gridControl1.EmbeddedNavigator.ButtonClick, AddressOf gridControl1_EmbeddedNavigator_ButtonClick
			gridControl1.EmbeddedNavigator.Buttons.ImageList = imageCollection1
			Dim button As DevExpress.XtraEditors.NavigatorCustomButton
			button = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add()
			button.Tag = "copy"
			button.Hint = "Copy to clipboard"
			button.ImageIndex = 0
		End Sub

		Private Sub gridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
			If "copy".Equals(e.Button.Tag) Then
				If gridControl1.FocusedView IsNot Nothing Then
					gridControl1.FocusedView.CopyToClipboard()
					MessageBox.Show("Selected data has been copied to the Clipboard")
					e.Handled = True
				End If
			End If
		End Sub
	End Class
End Namespace