
namespace SuperMSoftware
{
    partial class CategoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
            this.ProductsButton = new System.Windows.Forms.Button();
            this.SellersButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.LogoutLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CategoryIDTextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.CategoryNameTextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.CategoryDescriptionTextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ClearPropertiesButton = new System.Windows.Forms.Button();
            this.CategoryDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ManagersButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductsButton
            // 
            this.ProductsButton.BackColor = System.Drawing.Color.Goldenrod;
            this.ProductsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductsButton.FlatAppearance.BorderSize = 0;
            this.ProductsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.ProductsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.ProductsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductsButton.ForeColor = System.Drawing.Color.Black;
            this.ProductsButton.Location = new System.Drawing.Point(755, 13);
            this.ProductsButton.Margin = new System.Windows.Forms.Padding(4);
            this.ProductsButton.Name = "ProductsButton";
            this.ProductsButton.Size = new System.Drawing.Size(148, 57);
            this.ProductsButton.TabIndex = 5;
            this.ProductsButton.Text = "Products";
            this.ProductsButton.UseVisualStyleBackColor = false;
            this.ProductsButton.Click += new System.EventHandler(this.ProductsButton_Click);
            // 
            // SellersButton
            // 
            this.SellersButton.BackColor = System.Drawing.Color.Goldenrod;
            this.SellersButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SellersButton.FlatAppearance.BorderSize = 0;
            this.SellersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.SellersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.SellersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SellersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellersButton.ForeColor = System.Drawing.Color.Black;
            this.SellersButton.Location = new System.Drawing.Point(585, 13);
            this.SellersButton.Margin = new System.Windows.Forms.Padding(4);
            this.SellersButton.Name = "SellersButton";
            this.SellersButton.Size = new System.Drawing.Size(133, 57);
            this.SellersButton.TabIndex = 4;
            this.SellersButton.Text = "Sellers";
            this.SellersButton.UseVisualStyleBackColor = false;
            this.SellersButton.Click += new System.EventHandler(this.SellersButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.Black;
            this.ExitButton.Location = new System.Drawing.Point(1295, -6);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(28, 32);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "x";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LogoutLabel
            // 
            this.LogoutLabel.AutoSize = true;
            this.LogoutLabel.BackColor = System.Drawing.Color.Transparent;
            this.LogoutLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutLabel.ForeColor = System.Drawing.Color.Black;
            this.LogoutLabel.Location = new System.Drawing.Point(1200, -3);
            this.LogoutLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LogoutLabel.Name = "LogoutLabel";
            this.LogoutLabel.Size = new System.Drawing.Size(87, 29);
            this.LogoutLabel.TabIndex = 24;
            this.LogoutLabel.Text = "Logout";
            this.LogoutLabel.Click += new System.EventHandler(this.LogoutLabel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(857, 241);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // CategoryIDTextBox
            // 
            this.CategoryIDTextBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CategoryIDTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CategoryIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryIDTextBox.ForeColor = System.Drawing.Color.Gold;
            this.CategoryIDTextBox.HintForeColor = System.Drawing.Color.Empty;
            this.CategoryIDTextBox.HintText = "";
            this.CategoryIDTextBox.isPassword = false;
            this.CategoryIDTextBox.LineFocusedColor = System.Drawing.Color.Yellow;
            this.CategoryIDTextBox.LineIdleColor = System.Drawing.Color.Black;
            this.CategoryIDTextBox.LineMouseHoverColor = System.Drawing.Color.Yellow;
            this.CategoryIDTextBox.LineThickness = 4;
            this.CategoryIDTextBox.Location = new System.Drawing.Point(1055, 231);
            this.CategoryIDTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CategoryIDTextBox.Name = "CategoryIDTextBox";
            this.CategoryIDTextBox.Size = new System.Drawing.Size(209, 34);
            this.CategoryIDTextBox.TabIndex = 2;
            this.CategoryIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(857, 316);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "NAME";
            // 
            // CategoryNameTextBox
            // 
            this.CategoryNameTextBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CategoryNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CategoryNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryNameTextBox.ForeColor = System.Drawing.Color.Gold;
            this.CategoryNameTextBox.HintForeColor = System.Drawing.Color.Empty;
            this.CategoryNameTextBox.HintText = "";
            this.CategoryNameTextBox.isPassword = false;
            this.CategoryNameTextBox.LineFocusedColor = System.Drawing.Color.Yellow;
            this.CategoryNameTextBox.LineIdleColor = System.Drawing.Color.Black;
            this.CategoryNameTextBox.LineMouseHoverColor = System.Drawing.Color.Yellow;
            this.CategoryNameTextBox.LineThickness = 4;
            this.CategoryNameTextBox.Location = new System.Drawing.Point(1055, 306);
            this.CategoryNameTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CategoryNameTextBox.Name = "CategoryNameTextBox";
            this.CategoryNameTextBox.Size = new System.Drawing.Size(209, 34);
            this.CategoryNameTextBox.TabIndex = 4;
            this.CategoryNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(857, 382);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "DESCRIPTION";
            // 
            // CategoryDescriptionTextBox
            // 
            this.CategoryDescriptionTextBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CategoryDescriptionTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CategoryDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryDescriptionTextBox.ForeColor = System.Drawing.Color.Gold;
            this.CategoryDescriptionTextBox.HintForeColor = System.Drawing.Color.Empty;
            this.CategoryDescriptionTextBox.HintText = "";
            this.CategoryDescriptionTextBox.isPassword = false;
            this.CategoryDescriptionTextBox.LineFocusedColor = System.Drawing.Color.Yellow;
            this.CategoryDescriptionTextBox.LineIdleColor = System.Drawing.Color.Black;
            this.CategoryDescriptionTextBox.LineMouseHoverColor = System.Drawing.Color.Yellow;
            this.CategoryDescriptionTextBox.LineThickness = 4;
            this.CategoryDescriptionTextBox.Location = new System.Drawing.Point(1055, 372);
            this.CategoryDescriptionTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CategoryDescriptionTextBox.Name = "CategoryDescriptionTextBox";
            this.CategoryDescriptionTextBox.Size = new System.Drawing.Size(209, 34);
            this.CategoryDescriptionTextBox.TabIndex = 6;
            this.CategoryDescriptionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(848, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "MANAGE CATEGORIES";
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.Transparent;
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.Color.Black;
            this.AddButton.Location = new System.Drawing.Point(890, 495);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(107, 39);
            this.AddButton.TabIndex = 11;
            this.AddButton.Text = "ADD";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.Transparent;
            this.EditButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditButton.FlatAppearance.BorderSize = 0;
            this.EditButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.EditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.Color.Black;
            this.EditButton.Location = new System.Drawing.Point(1142, 495);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(112, 39);
            this.EditButton.TabIndex = 12;
            this.EditButton.Text = "EDIT";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.Black;
            this.DeleteButton.Location = new System.Drawing.Point(995, 566);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(151, 39);
            this.DeleteButton.TabIndex = 13;
            this.DeleteButton.Text = "DELETE";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ClearPropertiesButton
            // 
            this.ClearPropertiesButton.BackColor = System.Drawing.Color.Transparent;
            this.ClearPropertiesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearPropertiesButton.FlatAppearance.BorderSize = 0;
            this.ClearPropertiesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.ClearPropertiesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.ClearPropertiesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearPropertiesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearPropertiesButton.ForeColor = System.Drawing.Color.Black;
            this.ClearPropertiesButton.Location = new System.Drawing.Point(1170, 428);
            this.ClearPropertiesButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearPropertiesButton.Name = "ClearPropertiesButton";
            this.ClearPropertiesButton.Size = new System.Drawing.Size(101, 39);
            this.ClearPropertiesButton.TabIndex = 17;
            this.ClearPropertiesButton.Text = "Clear";
            this.ClearPropertiesButton.UseVisualStyleBackColor = false;
            this.ClearPropertiesButton.Click += new System.EventHandler(this.ClearPropertiesButton_Click);
            // 
            // CategoryDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(184)))));
            this.CategoryDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CategoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CategoryDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.CategoryDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CategoryDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.CategoryDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CategoryDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CategoryDataGridView.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(189)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CategoryDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.CategoryDataGridView.EnableHeadersVisualStyles = false;
            this.CategoryDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(218)))), ((int)(((byte)(171)))));
            this.CategoryDataGridView.Location = new System.Drawing.Point(27, 98);
            this.CategoryDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.CategoryDataGridView.Name = "CategoryDataGridView";
            this.CategoryDataGridView.RowHeadersVisible = false;
            this.CategoryDataGridView.RowHeadersWidth = 51;
            this.CategoryDataGridView.RowTemplate.Height = 28;
            this.CategoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CategoryDataGridView.Size = new System.Drawing.Size(804, 537);
            this.CategoryDataGridView.TabIndex = 28;
            this.CategoryDataGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Orange;
            this.CategoryDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(184)))));
            this.CategoryDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.CategoryDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.CategoryDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.CategoryDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.CategoryDataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.CategoryDataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(218)))), ((int)(((byte)(171)))));
            this.CategoryDataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.CategoryDataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.CategoryDataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.CategoryDataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.CategoryDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.CategoryDataGridView.ThemeStyle.HeaderStyle.Height = 30;
            this.CategoryDataGridView.ThemeStyle.ReadOnly = false;
            this.CategoryDataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(207)))));
            this.CategoryDataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.CategoryDataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CategoryDataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.CategoryDataGridView.ThemeStyle.RowsStyle.Height = 28;
            this.CategoryDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(189)))), ((int)(((byte)(97)))));
            this.CategoryDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.CategoryDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategoryDataGridView_CellContentClick);
            // 
            // ManagersButton
            // 
            this.ManagersButton.BackColor = System.Drawing.Color.Goldenrod;
            this.ManagersButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ManagersButton.FlatAppearance.BorderSize = 0;
            this.ManagersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.ManagersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.ManagersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManagersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.ManagersButton.ForeColor = System.Drawing.Color.Black;
            this.ManagersButton.Location = new System.Drawing.Point(941, 13);
            this.ManagersButton.Margin = new System.Windows.Forms.Padding(4);
            this.ManagersButton.Name = "ManagersButton";
            this.ManagersButton.Size = new System.Drawing.Size(172, 57);
            this.ManagersButton.TabIndex = 57;
            this.ManagersButton.Text = "Managers";
            this.ManagersButton.UseVisualStyleBackColor = false;
            this.ManagersButton.Click += new System.EventHandler(this.ManagersButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1330, 653);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ManagersButton);
            this.Controls.Add(this.CategoryDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearPropertiesButton);
            this.Controls.Add(this.LogoutLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ProductsButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SellersButton);
            this.Controls.Add(this.CategoryDescriptionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CategoryIDTextBox);
            this.Controls.Add(this.CategoryNameTextBox);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryForm";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion
        private System.Windows.Forms.Button ProductsButton;
        private System.Windows.Forms.Button SellersButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label LogoutLabel;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox CategoryIDTextBox;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox CategoryNameTextBox;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox CategoryDescriptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ClearPropertiesButton;
        private Guna.UI2.WinForms.Guna2DataGridView CategoryDataGridView;
        private System.Windows.Forms.Button ManagersButton;
    }
}