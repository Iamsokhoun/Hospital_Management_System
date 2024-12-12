using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private bool ValideData()
        {
            return IsPresent(txtName, "UserName") &&
                   IsString(txtName, "UserName") &&
                   IsPresent(txtPassword, "Password");
                   
        }

        private bool IsString(TextBox textBox, string Name)
        {
            try
            {
                Convert.ToString(textBox);
                return true;
            }catch(FormatException)
            {
                MessageBox.Show(Name + " must be string value.", "Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBox.Focus();
                return false;
            }
        }

        private bool IsPresent(TextBox textBox, string Name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show("Please enter "+Name, "Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBox.Focus();
                return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string password = txtPassword.Text;
           
                if (ValideData())
                {
                    if (name == "admin" && password == "123") 
                    {
                        this.Hide();
                        frmHomeScreen homeScreen = new frmHomeScreen();
                        homeScreen.Show();
                    }else {
                        if (name != "admin")
                        {
                            MessageBox.Show("Invalided Name", "Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Invalided Password","Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }       
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar=chkShowPassword.Checked?'\0':'*';
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();
            register.Show();
            this.Hide();
        }
    }
}
