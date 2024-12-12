using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Management
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtRegisterName.Text;
            string password = txtRegisterPassword.Text;

            if (ValideData())
            {
                if (name == "admin" && password == "12345678")
                {
                    this.Hide();
                    frmHomeScreen homeScreen = new frmHomeScreen();
                    homeScreen.Show();
                }
                else
                {
                    if (name != "admin")
                    {
                        MessageBox.Show("Invalided Name", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Invalided Password", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ValideData()
        {
            return IsPresent(txtRegisterName, "User Name") &&
                   IsString(txtRegisterName, "User Name") &&
                   IsPresent(txtRegisterPassword, "Password") &&
                   WithingRange(txtRegisterPassword, "Password",8);
        }

        private bool WithingRange(System.Windows.Forms.TextBox textBox, string Name,int min)
        {
            
            if (textBox.Text.Length < min)
            {
                MessageBox.Show(Name + " is too short.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                return false;
            }
            return true;
        }

        private bool IsString(System.Windows.Forms.TextBox textBox, string Name)
        {
            try
            {
                Convert.ToString(textBox);
                return true;
            }catch(FormatException)
            {
                MessageBox.Show(Name + " must be string value.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                return false;
            }
        }

        private bool IsPresent(System.Windows.Forms.TextBox textBox, string Name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show("Please enter " + Name,"Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox.Focus();
                return false;
            }
            return true;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            frmLogin loginForm=new frmLogin();
            loginForm.Show();
            this.Hide();
        }
    }
}
