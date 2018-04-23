using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace WindowsApplication1 {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }

        private void schedulerControl1_AppointmentDrop(object sender,DevExpress.XtraScheduler.AppointmentDragEventArgs e) {
            if(IsIntersectingWithAnotherAppointment(e.EditedAppointment,e.NewAppointmentResourceIds)){
            if(MessageBox.Show("Drop Appointment","test",MessageBoxButtons.YesNo) == DialogResult.No) {
                e.Allow = false;
                e.Handled = true;
            }
            }
        }

        private bool IsIntersectingWithAnotherAppointment(DevExpress.XtraScheduler.Appointment appointment,DevExpress.XtraScheduler.ResourceIdCollection resourceIdCollection) {
            AppointmentBaseCollection abc = schedulerStorage1.GetAppointments(appointment.Start,appointment.End);
            return abc.Count>0? true:false;
        }
    }
}