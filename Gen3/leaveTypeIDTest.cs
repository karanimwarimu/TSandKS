using ControllerDEMO.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Gen3;

namespace ControllerDEMO.form
{
    public partial class leaveTypeIDTest : Form
    {
        private byte[] fileData;
        string filePathSelected;


        ControllerDemo controller = new ControllerDemo();
        public leaveTypeIDTest()
        {
            InitializeComponent();
        }

        private void createbtn_click(object sender, EventArgs e)
        {
            string showID = controller.generateCode();
            showID_txtbox.Text = showID;

        }

        private void savebtn_click(object sender, EventArgs e)
        {
            string showID = showID_txtbox.Text;
            controller.saveLeaveTypeID(showID);

            if(String.IsNullOrEmpty(showID))
            {
                MessageBox.Show("ID NOT GENERATED ,CANT SAVE ", " ERROR!! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("ID  SAVED ", " SAVED :) ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ///////

            if (string.IsNullOrEmpty(showID))
            {
                MessageBox.Show("Please enter Leave Type ID.");
                return;
            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select an image first.");
                return;
            }

            byte[] imageBytes = controller.ImageToByteArray(pictureBox1.Image);
            if (imageBytes == null || imageBytes.Length == 0)
            {
                MessageBox.Show("Image conversion failed. Please select a valid image.");
                return;
            }
            controller.saveLeaveTypeImage( showID , imageBytes);

            if (fileData == null)
            {
                MessageBox.Show("Please select a file to upload.");
                return;
            }

            controller.saveUploadedFile(showID, fileData);

            MessageBox.Show("file saved ", "success");
        }

        private void displaybtn_click(object sender, EventArgs e)
        {
           // try
            //{
                using (SqlConnection conn = new SqlConnection(controller.connectionString))
                {
                    conn.Open();
                    string sqlString = " SELECT * FROM EmployeeLeaveTypes ";

                    SqlDataAdapter adpt = new SqlDataAdapter(sqlString, conn);
                    DataTable dt = new DataTable(); 
                    adpt.Fill(dt);
                    dataGridView.DataSource = dt;
                }
           // }
           // catch( Exception ex) {
           // {
               // MessageBox.Show("error handling data ", " ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Information);

           // }
        }
      
        private void choosePic_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog()  == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);

                picture_path_txtbox.Text = ofd.FileName;
            }
        }

        private void chooseFile_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog offd = new OpenFileDialog();
            offd.Filter = "All Files|*.*";
            if (offd.ShowDialog() == DialogResult.OK)
            {
                filepath_textBox.Text = offd.FileName;
                 filePathSelected = filepath_textBox.Text;
                fileData = File.ReadAllBytes(filePathSelected);

            }
        }
     
        private void fileEdit_btn_Click(object sender, EventArgs e)
        { 
             
           summerizer sum = new summerizer(filePathSelected);
            sum.Show();
      
        }
    }
}
