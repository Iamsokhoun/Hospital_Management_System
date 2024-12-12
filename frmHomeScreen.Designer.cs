namespace Hospital_Management
{
    partial class frmHomeScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblExit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnBed = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRoom = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.userConDoctor1 = new Hospital_Management.UserConDoctor();
            this.userConPatient1 = new Hospital_Management.UserConPatient();
            this.userConRoom1 = new Hospital_Management.UserConRoom();
            this.userConBed1 = new Hospital_Management.UserConBed();
            this.userConPayment1 = new Hospital_Management.UserConPayment();
            this.userConDashboard1 = new Hospital_Management.UserConDashboard();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.lblExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1535, 52);
            this.panel1.TabIndex = 8;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(1504, 10);
            this.lblExit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(22, 22);
            this.lblExit.TabIndex = 10;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hospital Management System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Controls.Add(this.btnBed);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnRoom);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnPayment);
            this.panel2.Controls.Add(this.btnPatient);
            this.panel2.Controls.Add(this.btnDoctor);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 793);
            this.panel2.TabIndex = 9;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDashboard.FlatAppearance.BorderSize = 2;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::Hospital_Management.Properties.Resources.home_175__2_;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDashboard.Location = new System.Drawing.Point(13, 139);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(275, 52);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnBed
            // 
            this.btnBed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnBed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBed.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBed.FlatAppearance.BorderSize = 2;
            this.btnBed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnBed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnBed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBed.ForeColor = System.Drawing.Color.White;
            this.btnBed.Image = global::Hospital_Management.Properties.Resources.hotel_wake_up_service_outline_15726;
            this.btnBed.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBed.Location = new System.Drawing.Point(13, 493);
            this.btnBed.Margin = new System.Windows.Forms.Padding(4);
            this.btnBed.Name = "btnBed";
            this.btnBed.Size = new System.Drawing.Size(275, 52);
            this.btnBed.TabIndex = 4;
            this.btnBed.Text = "Bed Management";
            this.btnBed.UseVisualStyleBackColor = false;
            this.btnBed.Click += new System.EventHandler(this.btnBed_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.panel3.Location = new System.Drawing.Point(320, 742);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 100);
            this.panel3.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hospital_Management.Properties.Resources.skills_8818__1_;
            this.pictureBox1.Location = new System.Drawing.Point(118, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 78);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnRoom
            // 
            this.btnRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoom.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRoom.FlatAppearance.BorderSize = 2;
            this.btnRoom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnRoom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoom.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom.ForeColor = System.Drawing.Color.White;
            this.btnRoom.Image = global::Hospital_Management.Properties.Resources.hotel_room_yellow_key_15792;
            this.btnRoom.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRoom.Location = new System.Drawing.Point(13, 405);
            this.btnRoom.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Size = new System.Drawing.Size(275, 52);
            this.btnRoom.TabIndex = 3;
            this.btnRoom.Text = "Room Management";
            this.btnRoom.UseVisualStyleBackColor = false;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 2;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::Hospital_Management.Properties.Resources.sign_out_3299;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExit.Location = new System.Drawing.Point(13, 671);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(275, 52);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayment.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPayment.FlatAppearance.BorderSize = 2;
            this.btnPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Image = global::Hospital_Management.Properties.Resources.invoice_8856;
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPayment.Location = new System.Drawing.Point(13, 581);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(4);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(275, 52);
            this.btnPayment.TabIndex = 5;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnPatient
            // 
            this.btnPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPatient.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPatient.FlatAppearance.BorderSize = 2;
            this.btnPatient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnPatient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatient.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatient.ForeColor = System.Drawing.Color.White;
            this.btnPatient.Image = global::Hospital_Management.Properties.Resources.user_group_296;
            this.btnPatient.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPatient.Location = new System.Drawing.Point(13, 315);
            this.btnPatient.Margin = new System.Windows.Forms.Padding(4);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(275, 52);
            this.btnPatient.TabIndex = 2;
            this.btnPatient.Text = "Patient Management";
            this.btnPatient.UseVisualStyleBackColor = false;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoctor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDoctor.FlatAppearance.BorderSize = 2;
            this.btnDoctor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnDoctor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctor.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctor.ForeColor = System.Drawing.Color.White;
            this.btnDoctor.Image = global::Hospital_Management.Properties.Resources.doctor_284__1_;
            this.btnDoctor.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDoctor.Location = new System.Drawing.Point(13, 225);
            this.btnDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(275, 52);
            this.btnDoctor.TabIndex = 1;
            this.btnDoctor.Text = "Doctor Management";
            this.btnDoctor.UseVisualStyleBackColor = false;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(114, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Welcome ";
            // 
            // userConDoctor1
            // 
            this.userConDoctor1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userConDoctor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userConDoctor1.Location = new System.Drawing.Point(309, 52);
            this.userConDoctor1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.userConDoctor1.Name = "userConDoctor1";
            this.userConDoctor1.Size = new System.Drawing.Size(1226, 793);
            this.userConDoctor1.TabIndex = 14;
            // 
            // userConPatient1
            // 
            this.userConPatient1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userConPatient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userConPatient1.Location = new System.Drawing.Point(309, 52);
            this.userConPatient1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.userConPatient1.Name = "userConPatient1";
            this.userConPatient1.Size = new System.Drawing.Size(1226, 793);
            this.userConPatient1.TabIndex = 13;
            // 
            // userConRoom1
            // 
            this.userConRoom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userConRoom1.Location = new System.Drawing.Point(309, 52);
            this.userConRoom1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.userConRoom1.Name = "userConRoom1";
            this.userConRoom1.Size = new System.Drawing.Size(1226, 793);
            this.userConRoom1.TabIndex = 12;
            // 
            // userConBed1
            // 
            this.userConBed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userConBed1.Location = new System.Drawing.Point(309, 52);
            this.userConBed1.Margin = new System.Windows.Forms.Padding(6);
            this.userConBed1.Name = "userConBed1";
            this.userConBed1.Size = new System.Drawing.Size(1226, 793);
            this.userConBed1.TabIndex = 11;
            // 
            // userConPayment1
            // 
            this.userConPayment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userConPayment1.Location = new System.Drawing.Point(309, 52);
            this.userConPayment1.Margin = new System.Windows.Forms.Padding(4);
            this.userConPayment1.Name = "userConPayment1";
            this.userConPayment1.Size = new System.Drawing.Size(1226, 793);
            this.userConPayment1.TabIndex = 10;
            // 
            // userConDashboard1
            // 
            this.userConDashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userConDashboard1.Location = new System.Drawing.Point(309, 52);
            this.userConDashboard1.Margin = new System.Windows.Forms.Padding(4);
            this.userConDashboard1.Name = "userConDashboard1";
            this.userConDashboard1.Size = new System.Drawing.Size(1226, 793);
            this.userConDashboard1.TabIndex = 15;
            // 
            // frmHomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 845);
            this.Controls.Add(this.userConDashboard1);
            this.Controls.Add(this.userConDoctor1);
            this.Controls.Add(this.userConPatient1);
            this.Controls.Add(this.userConRoom1);
            this.Controls.Add(this.userConBed1);
            this.Controls.Add(this.userConPayment1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.frmHomeScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRoom;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBed;
        private System.Windows.Forms.Button btnDashboard;
        private UserConPayment userConPayment1;
        private UserConBed userConBed1;
        private UserConRoom userConRoom1;
        private UserConPatient userConPatient1;
        private UserConDoctor userConDoctor1;
        private UserConDashboard userConDashboard1;
    }
}