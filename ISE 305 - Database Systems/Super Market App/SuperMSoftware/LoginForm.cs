using System;
using System.Windows.Forms;
using SuperMSoftware.SQLProcedures;

namespace SuperMSoftware
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private LoginProcedures LoginSqlProcedure = new LoginProcedures();
        public static String sellerName = "";

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearLabel_Click(object sender, EventArgs e)
        {
            UserNameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("Username or password is missing!");
            }
            else
            {
                if (RoleComboBox.SelectedIndex > -1)
                {
                    String userName = UserNameTextBox.Text;
                    String userPassword = PasswordTextBox.Text.ToString();
                    
                    if (RoleComboBox.SelectedItem.ToString() == "MANAGER")
                    {
                        if (LoginSqlProcedure.GetManagerUser(userName, userPassword).Rows[0][0].ToString() == "1")
                        {
                            ProductForm product = new ProductForm();
                            product.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("You are not a Manager or please type correct Username and Password!");
                        }
                    }
                    else
                    {
                        if (LoginSqlProcedure.GetSellerUser(userName, userPassword).Rows[0][0].ToString() == "1")
                        {
                            sellerName = UserNameTextBox.Text;
                            SellingForm selling = new SellingForm();
                            selling.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("You are not a Seller or please type valid user name or password!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select a role!");
                }
            }
        }

        private void PasswordTextBox_OnValueChanged(object sender, EventArgs e)
        {
            PasswordTextBox.isPassword = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}