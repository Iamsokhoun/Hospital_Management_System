using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public static class Validation
    {
       
        public static bool IsPresent(TextBox textbox,string name)
        {
            if (textbox == null)
            {
                MessageBox.Show(name + " is a required field.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Focus();
                return false;
            }
            return true;
        }
        public static bool IsInteger(TextBox textbox,string name)
        {
            try
            {
                Convert.ToInt32(textbox.Text);
            } catch (FormatException ){
                MessageBox.Show(name + " must be an integer value.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Focus();
                return false;
            }
            return true;
        }
        public static bool IsItemSelect(ComboBox comboBox,String name)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show(name + " is a required field.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox.Focus();
                return false;
            }
            return true;
        }
        public static bool IsFloat(TextBox textBox,String name)
        {
            try
            {
                Convert.ToSingle(textBox.Text);
            } catch (FormatException)
            {
                MessageBox.Show(name + " must be a float number.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox.Focus();
                return false;
            }
            return true;
        }
        
       
    }
}
