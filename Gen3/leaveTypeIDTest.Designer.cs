namespace ControllerDEMO.form
{
    partial class leaveTypeIDTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(leaveTypeIDTest));
            this.createbtn = new System.Windows.Forms.Button();
            this.displaybtn = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.savebtn = new System.Windows.Forms.Button();
            this.showID_txtbox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.choosePic_button = new System.Windows.Forms.Button();
            this.chooseFile_button = new System.Windows.Forms.Button();
            this.filepath_textBox = new System.Windows.Forms.TextBox();
            this.picture_path_txtbox = new System.Windows.Forms.TextBox();
            this.fileEdit_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // createbtn
            // 
            this.createbtn.Image = ((System.Drawing.Image)(resources.GetObject("createbtn.Image")));
            this.createbtn.Location = new System.Drawing.Point(31, 34);
            this.createbtn.Name = "createbtn";
            this.createbtn.Size = new System.Drawing.Size(75, 42);
            this.createbtn.TabIndex = 0;
            this.createbtn.UseVisualStyleBackColor = true;
            this.createbtn.Click += new System.EventHandler(this.createbtn_click);
            // 
            // displaybtn
            // 
            this.displaybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displaybtn.Image = ((System.Drawing.Image)(resources.GetObject("displaybtn.Image")));
            this.displaybtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.displaybtn.Location = new System.Drawing.Point(356, 284);
            this.displaybtn.Name = "displaybtn";
            this.displaybtn.Size = new System.Drawing.Size(117, 45);
            this.displaybtn.TabIndex = 1;
            this.displaybtn.Text = "DISPLAY";
            this.displaybtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.displaybtn.UseCompatibleTextRendering = true;
            this.displaybtn.UseVisualStyleBackColor = true;
            this.displaybtn.Click += new System.EventHandler(this.displaybtn_click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 335);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(763, 215);
            this.dataGridView.TabIndex = 2;
            // 
            // savebtn
            // 
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Image = ((System.Drawing.Image)(resources.GetObject("savebtn.Image")));
            this.savebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.savebtn.Location = new System.Drawing.Point(356, 198);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(117, 41);
            this.savebtn.TabIndex = 3;
            this.savebtn.Text = "SAVE";
            this.savebtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_click);
            // 
            // showID_txtbox
            // 
            this.showID_txtbox.Location = new System.Drawing.Point(142, 46);
            this.showID_txtbox.Name = "showID_txtbox";
            this.showID_txtbox.Size = new System.Drawing.Size(118, 20);
            this.showID_txtbox.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(576, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 123);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // choosePic_button
            // 
            this.choosePic_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosePic_button.Location = new System.Drawing.Point(449, 46);
            this.choosePic_button.Name = "choosePic_button";
            this.choosePic_button.Size = new System.Drawing.Size(100, 43);
            this.choosePic_button.TabIndex = 6;
            this.choosePic_button.Text = "choose Image ";
            this.choosePic_button.UseVisualStyleBackColor = true;
            this.choosePic_button.Click += new System.EventHandler(this.choosePic_button_Click);
            // 
            // chooseFile_button
            // 
            this.chooseFile_button.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFile_button.Image = ((System.Drawing.Image)(resources.GetObject("chooseFile_button.Image")));
            this.chooseFile_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chooseFile_button.Location = new System.Drawing.Point(12, 126);
            this.chooseFile_button.Name = "chooseFile_button";
            this.chooseFile_button.Size = new System.Drawing.Size(112, 58);
            this.chooseFile_button.TabIndex = 7;
            this.chooseFile_button.Text = "Choose File";
            this.chooseFile_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chooseFile_button.UseVisualStyleBackColor = true;
            this.chooseFile_button.Click += new System.EventHandler(this.chooseFile_button_Click);
            // 
            // filepath_textBox
            // 
            this.filepath_textBox.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filepath_textBox.Location = new System.Drawing.Point(130, 143);
            this.filepath_textBox.Multiline = true;
            this.filepath_textBox.Name = "filepath_textBox";
            this.filepath_textBox.Size = new System.Drawing.Size(185, 30);
            this.filepath_textBox.TabIndex = 8;
            this.filepath_textBox.Text = "File Path";
            this.filepath_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picture_path_txtbox
            // 
            this.picture_path_txtbox.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picture_path_txtbox.Location = new System.Drawing.Point(536, 143);
            this.picture_path_txtbox.Multiline = true;
            this.picture_path_txtbox.Name = "picture_path_txtbox";
            this.picture_path_txtbox.Size = new System.Drawing.Size(230, 29);
            this.picture_path_txtbox.TabIndex = 9;
            this.picture_path_txtbox.Text = "PICTURE PATH";
            this.picture_path_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fileEdit_btn
            // 
            this.fileEdit_btn.Location = new System.Drawing.Point(61, 216);
            this.fileEdit_btn.Name = "fileEdit_btn";
            this.fileEdit_btn.Size = new System.Drawing.Size(114, 41);
            this.fileEdit_btn.TabIndex = 10;
            this.fileEdit_btn.Text = "EDIT FILE";
            this.fileEdit_btn.UseVisualStyleBackColor = true;
            this.fileEdit_btn.Click += new System.EventHandler(this.fileEdit_btn_Click);
            // 
            // leaveTypeIDTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.fileEdit_btn);
            this.Controls.Add(this.picture_path_txtbox);
            this.Controls.Add(this.filepath_textBox);
            this.Controls.Add(this.chooseFile_button);
            this.Controls.Add(this.choosePic_button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.showID_txtbox);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.displaybtn);
            this.Controls.Add(this.createbtn);
            this.Name = "leaveTypeIDTest";
            this.Text = "leaveTypeIDTest";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createbtn;
        private System.Windows.Forms.Button displaybtn;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox showID_txtbox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button choosePic_button;
        private System.Windows.Forms.Button chooseFile_button;
        private System.Windows.Forms.TextBox filepath_textBox;
        private System.Windows.Forms.TextBox picture_path_txtbox;
        private System.Windows.Forms.Button fileEdit_btn;
    }
}