using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Odeeev.entity;

namespace Odeeev
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            String path = "";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }

            bool isExistsFile = File.Exists(path);

            if (isExistsFile)
            {
                String[] lines = File.ReadAllLines(path);


                List<Student> studentList = new List<Student>();

                foreach (String line in lines)
                {
                    Student student = Student.parse(line);
                    studentList.Add(student);
                }

                FillStudentListView(studentList);
            }
            else
            {
                MessageBox.Show("Dosya Yolu Bulunamadı");
            }


            

        
        }

        private void FillStudentListView(List<Student> studentList)
        {
            foreach(Student student in studentList)
            {
                ListViewItem lvi = studentListView.Items.Add(student.Number+"");

               
                    lvi.BackColor = student.IsPass ? Color.Green : Color.Red;
                
                
                

                lvi.SubItems.Add(student.VisaNote+"");
                lvi.SubItems.Add(student.FinalNote + "");
                lvi.SubItems.Add(student.GetNoteAvg()+"");
                lvi.SubItems.Add(student.IsPass + "");
                lvi.SubItems.Add(student.LetterNote + "");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentListView.View = View.Details;
            studentListView.Columns.Add("Student Number");
            studentListView.Columns.Add("Visa Note");
            studentListView.Columns.Add("Final Note");
            studentListView.Columns.Add("Avg");
            studentListView.Columns.Add("Is Pass");
            studentListView.Columns.Add("Letter");

        }
    }
}
