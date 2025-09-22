using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using ControllerDEMO.logic;
using ControllerDEMO.form;
using System.Windows.Forms.VisualStyles;

namespace Gen3
{
    public partial class summerizer : Form
    {
        leaveTypeIDTest lID = new leaveTypeIDTest();
        ControllerDemo controller = new ControllerDemo();
        private string filepath;

        public summerizer(string filepathselected)
        {
            InitializeComponent();
            filepath = filepathselected;    
        }
        private async void FileExtract_btn_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> fields = new List<string>();

                if (!string.IsNullOrWhiteSpace(textBox13.Text)) fields.Add(textBox13.Text);
                if (!string.IsNullOrWhiteSpace(textBox14.Text)) fields.Add(textBox14.Text);
                if (!string.IsNullOrWhiteSpace(textBox15.Text)) fields.Add(textBox15.Text);
                if (!string.IsNullOrWhiteSpace(textBox1.Text)) fields.Add(textBox1.Text);
                if (!string.IsNullOrWhiteSpace(textBox2.Text)) fields.Add(textBox2.Text);
                if (!string.IsNullOrWhiteSpace(textBox3.Text)) fields.Add(textBox3.Text);

                string instruction = "Extract " + string.Join(", ", fields);

                using (var client = new HttpClient())
                using (var form = new MultipartFormDataContent())
                {
                    form.Add(new StringContent(instruction), "instruction");

                    string fileName;
                    HttpContent fileContent = controller.CreatePdfContent(filepath, out fileName);

                    // Make sure fileContent is valid
                    if (fileContent == null || string.IsNullOrEmpty(fileName))
                    {
                        MessageBox.Show("Failed to prepare the file for upload.");
                        return;
                    }

                    form.Add(fileContent, "file", fileName);
                    HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5000/extract", form);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Extraction successful:\n" );

                        textBox4.Text = result;
                    }
                    else
                    {
                        MessageBox.Show("Extraction failed:\n" + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
            }


        }
                 
        private void summerizer_Load(object sender, EventArgs e)
        {
            filepath_textBox2.Text = filepath;          
        }


    }
}
