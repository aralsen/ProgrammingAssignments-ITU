using System;
using System.Windows.Forms;
using SuperMSoftware.Models;
using SuperMSoftware.SQLProcedures;

namespace SuperMSoftware
{
    public partial class SellerForm : Form
    {
        private EmployeeProcedures SellerSqlProcedures = new EmployeeProcedures();

        public SellerForm()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            SellerIDTextBox.Text = "";
            SellerNameTextBox.Text = "";
            SellerAgeTextBox.Text = "";
            SellerPhoneTextBox.Text = "";
            SellerPasswordTextBox.Text = "";
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

        private void SellerForm_Load(object sender, EventArgs e)
        {
            SellerDataGridView.DataSource = SellerSqlProcedures.GetAllSalespersons();
            ClearTextBoxes();
        }

        private void SellerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SellerIDTextBox.Text = SellerDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            SellerNameTextBox.Text = SellerDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            SellerAgeTextBox.Text = SellerDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            SellerPhoneTextBox.Text = SellerDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            SellerPasswordTextBox.Text = SellerDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            EmailTextBox.Text = SellerDataGridView.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                employees seller = new employees();
                seller.employee_id = int.Parse(SellerIDTextBox.Text);
                seller.name = SellerNameTextBox.Text;
                seller.age = int.Parse(SellerAgeTextBox.Text);
                seller.phone = SellerPhoneTextBox.Text;
                seller.password = SellerPasswordTextBox.Text;
                seller.email = EmailTextBox.Text;
                seller.job_id = 2;

                SellerSqlProcedures.AddEmployee(seller);
                MessageBox.Show("Seller added successfully");
                SellerForm_Load(sender, e);
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
                if (SellerIDTextBox.Text == "" || SellerNameTextBox.Text == "" || SellerAgeTextBox.Text == ""
                    || SellerPhoneTextBox.Text == "" || SellerPasswordTextBox.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    employees seller = new employees();
                    seller.employee_id = int.Parse(SellerIDTextBox.Text);
                    seller.name = SellerNameTextBox.Text;
                    seller.age = int.Parse(SellerAgeTextBox.Text);
                    seller.phone = SellerPhoneTextBox.Text;
                    seller.password = SellerPasswordTextBox.Text;
                    seller.email = EmailTextBox.Text;
                    seller.job_id = 2;

                    SellerSqlProcedures.UpdateEmployee(seller);
                    MessageBox.Show("Seller successfully updated");
                    SellerForm_Load(sender, e);
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
                if (SellerIDTextBox.Text == "")
                {
                    MessageBox.Show("Select Seller to delete");
                }
                else
                {
                    SellerSqlProcedures.DeleteEmployee(int.Parse(SellerIDTextBox.Text));
                    MessageBox.Show("Seller deleted successfully");
                    SellerForm_Load(sender, e);
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

        private void ManagersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerForm manager = new ManagerForm();
            manager.Show();
        }
    }
}
