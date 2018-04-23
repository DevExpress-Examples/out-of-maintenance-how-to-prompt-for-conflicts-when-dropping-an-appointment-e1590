Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub schedulerControl1_AppointmentDrop(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.AppointmentDragEventArgs) Handles schedulerControl1.AppointmentDrop
			If IsIntersectingWithAnotherAppointment(e.EditedAppointment,e.NewAppointmentResourceIds) Then
			If MessageBox.Show("Drop Appointment","test",MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.No Then
				e.Allow = False
				e.Handled = True
			End If
			End If
		End Sub

		Private Function IsIntersectingWithAnotherAppointment(ByVal appointment As DevExpress.XtraScheduler.Appointment, ByVal resourceIdCollection As DevExpress.XtraScheduler.ResourceIdCollection) As Boolean
			Dim abc As AppointmentBaseCollection = schedulerStorage1.GetAppointments(appointment.Start,appointment.End)
			Return If(abc.Count>0, True, False)
		End Function
	End Class
End Namespace