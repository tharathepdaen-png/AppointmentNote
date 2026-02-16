using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppointmentNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // เริ่มทำงานเมื่อโหลดฟอร์ม
        private void Form1_Load(object sender, EventArgs e)
        {
            // กำหนดค่าเริ่มต้นให้ ComboBox เพื่อไม่ให้ว่าง
            if (cboImportance.Items.Count > 0) cboImportance.SelectedIndex = 0; // เลือก Low
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0; // เลือก Planned
        }

        // ปุ่ม Add: ตรวจสอบและบันทึก
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Data Validation: ตรวจสอบค่าว่าง
            if (string.IsNullOrWhiteSpace(txtAppointmentID.Text) || string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("กรุณากรอก Appointment ID และ Subject ให้ครบถ้วน",
                                "ข้อผิดพลาด (Warning)",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // หยุดการทำงาน ไม่แสดงผลสรุป
            }

            // ดึงค่าจาก Form
            string id = txtAppointmentID.Text;
            string subject = txtSubject.Text;
            string importance = cboImportance.SelectedItem?.ToString() ?? "Low";
            string status = cboStatus.SelectedItem?.ToString() ?? "Planned";

            // เตรียมข้อความแสดงผล
            string resultMessage = "=== บันทึกข้อมูลสำเร็จ ===\n\n" +
                                   $"รหัสการนัดหมาย: {id}\n" +
                                   $"หัวข้อ: {subject}\n" +
                                   $"ความสำคัญ: {importance}\n" +
                                   $"สถานะ: {status}";

            // แสดง MessageBox
            MessageBox.Show(resultMessage, "รายละเอียดการนัดหมาย", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ปุ่ม Clear: ล้างข้อมูล
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAppointmentID.Clear();
            txtSubject.Clear();
            cboImportance.SelectedIndex = 0; // กลับไปค่าแรก
            cboStatus.SelectedIndex = 0;     // กลับไปค่าแรก
            txtAppointmentID.Focus();        // ให้เคอร์เซอร์ไปกระพริบที่ช่องแรก
        }

        // ปุ่ม Exit: ปิดโปรแกรม
        private void btnExit_Click(object sender, EventArgs e)
        {
            // ถามยืนยันก่อนปิด (Option เสริมเพื่อให้ดูสมบูรณ์ขึ้น)
            if (MessageBox.Show("ต้องการออกจากโปรแกรมใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}