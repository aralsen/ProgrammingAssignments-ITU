using System;
using System.Windows.Forms;
using SuperMSoftware.Models;
using SuperMSoftware.SQLProcedures;

namespace SuperMSoftware
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            CategoryIDTextBox.Text = "";
            CategoryNameTextBox.Text = "";
            CategoryDescriptionTextBox.Text = "";
        }

        private CategoryProcedures CategorySqlProcedure = new CategoryProcedures();
        private ProductProcedures ProductSqlProcedure = new ProductProcedures();

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                categories category = new categories();
                category.category_id = int.Parse(CategoryIDTextBox.Text);
                category.category_name = CategoryNameTextBox.Text;
                category.description = CategoryDescriptionTextBox.Text;

                CategorySqlProcedure.AddCategory(category);
                MessageBox.Show("Category Added Successfully");
                CategoryForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            CategoryDataGridView.DataSource = CategorySqlProcedure.GetAllCategories();
            ClearTextBoxes();
        }

        private void CategoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CategoryIDTextBox.Text = CategoryDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            CategoryNameTextBox.Text = CategoryDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            CategoryDescriptionTextBox.Text = CategoryDataGridView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductSqlProcedure.GetProductsByCategory(CategoryNameTextBox.Text).Count != 0)
                {
                    MessageBox.Show("There are some products under selected category. Before delete this category please delete these products.");
                }
                else
                {
                    if (CategoryIDTextBox.Text == "")
                    {
                        MessageBox.Show("Select a Category to delete");
                    }
                    else
                    {
                        CategorySqlProcedure.DeleteCategory(int.Parse(CategoryIDTextBox.Text));
                        MessageBox.Show("Category deleted successfully");
                        CategoryForm_Load(sender, e);
                    }
                }
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
                if (CategoryIDTextBox.Text == "" || CategoryNameTextBox.Text == "" || CategoryDescriptionTextBox.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    categories category = new categories();
                    category.category_id = int.Parse(CategoryIDTextBox.Text);
                    category.category_name = CategoryNameTextBox.Text;
                    category.description = CategoryDescriptionTextBox.Text;

                    CategorySqlProcedure.UpdateCategory(category);
                    MessageBox.Show("Category successfully updated");
                    CategoryForm_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void SellersButton_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
