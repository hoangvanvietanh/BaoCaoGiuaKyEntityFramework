using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EntityFramework.Services;
using EntityFramework.Model;
using System.Configuration;

namespace EntityFramework.View
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        private StudentServices userService = new StudentServices();

        public Home()
        {
            InitializeComponent();
            setButtonUpdateAndDelete(false);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'entityFrameworkDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.entityFrameworkDataSet.Students);
        }

        private void btnAddStudent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            userService.addStudent(getInfoStudent());
            loadData();
            LoadFormText();
        }

        private void btnUpdateStudent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (getInfoStudent().StudentID.ToString().Trim() != "")
            {
                userService.updateStudent(getInfoStudent());
            }
            loadData();
        }

        private void btnDeleteStudent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (getInfoStudent().StudentID.ToString().Trim() != "")
            {
                userService.delete(getInfoStudent().StudentID);
            }
            loadData();
            LoadFormText();
        }

        public void setValueForm(Student student)
        {
            txtPhoneNumber.Text = student.PhoneNumber;
            txtStudentID.Text = student.StudentID.ToString();
            txtFullName.Text = student.StudentName;
            txtEmail.Text = student.Email;
            cbGender.EditValue = student.StudentGender;
            txtAddress.Text = student.Address;
        }

        public Student getInfoStudent()
        {
            Student student = new Student();
            student.StudentID = Int32.Parse(txtStudentID.Text);
            student.StudentName = txtFullName.Text;
            student.Email = txtEmail.Text;
            student.PhoneNumber = txtPhoneNumber.Text;
            student.StudentGender = cbGender.EditValue.ToString();
            student.Address = txtAddress.Text;
            return student;
        }

        public void LoadFormText()
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtStudentID.Text = "";
            txtPhoneNumber.Text = "";
            cbGender.EditValue = "Nam";
            setButtonAdd(true);
            setButtonUpdateAndDelete(false);
            txtStudentID.ReadOnly = false;
        }

        public void loadData()
        {
            this.studentsTableAdapter.Fill(this.entityFrameworkDataSet.Students);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            setButtonAdd(false);
            setButtonUpdateAndDelete(true);
            txtStudentID.ReadOnly = true;
            Student student = new Student();
            student.StudentID = Int32.Parse(gridView1.Columns.View.GetFocusedRowCellValue("StudentID").ToString());
            student.StudentName = gridView1.Columns.View.GetFocusedRowCellValue("StudentName").ToString();
            student.Email = gridView1.Columns.View.GetFocusedRowCellValue("Email").ToString();
            student.PhoneNumber = gridView1.Columns.View.GetFocusedRowCellValue("PhoneNumber").ToString();
            student.StudentGender = gridView1.Columns.View.GetFocusedRowCellValue("StudentGender").ToString();
            student.Address = gridView1.Columns.View.GetFocusedRowCellValue("Address").ToString();
            setValueForm(student);
        }

        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadFormText();
        }

        public void setButtonUpdateAndDelete(bool status)
        {
            btnDeleteStudent.Enabled = status;
            btnUpdateStudent.Enabled = status;
        }

        public void setButtonAdd(bool status)
        {
            btnAddStudent.Enabled = status;
        }
    }
}