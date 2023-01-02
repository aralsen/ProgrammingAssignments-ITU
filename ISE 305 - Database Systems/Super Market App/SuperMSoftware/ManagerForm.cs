using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMSoftware.Models;
using SuperMSoftware.SQLProcedures;

namespace SuperMSoftware
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private EmployeeProcedures ManagerSqlProcedure = new EmployeeProcedures();

        private void ClearTextBoxes()
        {
            IDTextBox.Text = "";
            NameTextBox.Text = "";
            AgeTextBox.Text = "";
            PhoneTextBox.Text = "";
            PasswordTextBox.Text = "";
            EmailTextBox.Text = "";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void CategoriesButton_Click(object sender, EventArgs e)
        {
            CategoryForm category = new CategoryForm();
            category.Show();
            this.Hide();
        }

        private void SellersButton_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            ManagerDataGridView.DataSource = ManagerSqlProcedure.GetAllManagers();
            ClearTextBoxes();
        }

        private void ManagerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IDTextBox.Text = ManagerDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            NameTextBox.Text = ManagerDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            AgeTextBox.Text = ManagerDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            PhoneTextBox.Text = ManagerDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            EmailTextBox.Text = ManagerDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            PasswordTextBox.Text = ManagerDataGridView.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                employees manager = new employees();
                manager.employee_id = int.Parse(IDTextBox.Text);
                manager.name = NameTextBox.Text;
                manager.age = int.Parse(AgeTextBox.Text);
                manager.phone = PhoneTextBox.Text;
                manager.password = PasswordTextBox.Text;
                manager.email = EmailTextBox.Text;
                manager.job_id = 1;

                ManagerSqlProcedure.AddEmployee(manager);
                MessageBox.Show("Manager added successfully");
                ManagerForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IDTextBox.Text == "" || NameTextBox.Text == "" || AgeTextBox.Text == "" ||
                    PhoneTextBox.Text == "" || PasswordTextBox.Text == "")
                {
                    MessageBox.Show("Missing Information!");
                }
                else
                {
                    employees manager = new employees();
                    manager.employee_id = int.Parse(IDTextBox.Text);
                    manager.name = NameTextBox.Text;
                    manager.age = int.Parse(AgeTextBox.Text);
                    manager.phone = PhoneTextBox.Text;
                    manager.password = PasswordTextBox.Text;
                    manager.email = EmailTextBox.Text;
                    manager.job_id = 1;

                    ManagerSqlProcedure.UpdateEmployee(manager);
                    MessageBox.Show("Manager successfully updated");
                    ManagerForm_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IDTextBox.Text == "")
                {
                    MessageBox.Show("Select Manager to delete!");
                }
                else
                {
                    ManagerSqlProcedure.DeleteEmployee(int.Parse(IDTextBox.Text));
                    MessageBox.Show("Manager deleted successfully!");
                    ManagerForm_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearPropertiesButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void LogoutLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
