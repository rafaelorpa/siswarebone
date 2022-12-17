using com.sisware.bean;
using com.sisware.dao;
using com.sisware.logic;
using com.snapsoft.util;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace com.sisware.gui.form
{
    public partial class SubCategoryForm : Form
    {
        private ECategory category;
        private ESubCategory subCategory;
        private readonly SubCategoryLogic subCategoryLogic;
        private ArticleForm articleForm;
        private int userCode;
        private Guna2Panel panelContainer;
        // private CategoryForm categoryForm;
        public SubCategoryForm(int userCode, Guna2Panel panelCont )
        {
            InitializeComponent();
            this.userCode = userCode;
            category = new ECategory(); 
            subCategory = new ESubCategory();
            articleForm = new ArticleForm(this.userCode);    
            subCategoryLogic = new SubCategoryLogic();
            panelContainer = panelCont;
           // categoryForm = new CategoryForm();

        }

        private void container(object _form)
        {

            if (panelContainer.Controls.Count > 0) panelContainer.Controls.Clear();

            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(fm);
            panelContainer.Tag = fm;
            fm.Show();

        }
        public void State(Boolean state)
        {
            if (state)
            {
                groupBox1.Enabled = true;
                groupBox1.Visible = true;
                //Size = new Size(1111, 800);
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox1.Visible = false;
                //Size = new Size(1111, 470);
            }
        }
        public void Load_Default()
        {
            DateTime date = DateTime.Today;
            labelDate.Text = Convert.ToString(date);
            State(false);

            labelCategory.Text = category.name;
            labelCategory2.Text = category.name;
            Clear();
            if (category.name != null)
            {

                ListAll();
            }
            else
            {
                ListAll1();
            }
        }
        public void refresh(ECategory category)
        {
            this.category = category;
        }

        private void Clear()
        {
            textboxName.Clear();
        }

        private void ListAll()
        {
            try
            {
                Logger.Instance.info("Category List");
                List<ESubCategory> categories = subCategoryLogic.GetForCategory(category.id);
                if (categories.Count > 0 && categories != null)
                {
                    dataGridViewSubCategory.AutoGenerateColumns = false;
                    dataGridViewSubCategory.DataSource = categories;
                    dataGridViewSubCategory.Columns["columnId"].Visible = false;
                    dataGridViewSubCategory.Columns["columnId"].DataPropertyName = "id";
                    dataGridViewSubCategory.Columns["columnName"].DataPropertyName = "name";
                    dataGridViewSubCategory.Columns["columnIdCategory"].DataPropertyName = "categoryId";
                    dataGridViewSubCategory.Columns["columnDate"].DataPropertyName = "date";
                }
                else
                {
                    dataGridViewSubCategory.AutoGenerateColumns = false;
                    dataGridViewSubCategory.DataSource = categories;
                    dataGridViewSubCategory.Columns["columnId"].Visible = false;
                    Logger.Instance.info("Not exists subcategory records");
                    MessageBox.Show("No existen SubCategorías Registradas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void ListAll1()
        {
            try
            {
                Logger.Instance.info("Category List");
                List<ESubCategory> categories = subCategoryLogic.GetAll();
                if (categories.Count > 0 && categories != null)
                {
                    dataGridViewSubCategory.AutoGenerateColumns = false;
                    dataGridViewSubCategory.DataSource = categories;
                    dataGridViewSubCategory.Columns["columnId"].Visible = false;
                    dataGridViewSubCategory.Columns["columnId"].DataPropertyName = "id";
                    dataGridViewSubCategory.Columns["columnName"].DataPropertyName = "name";
                    dataGridViewSubCategory.Columns["columnIdCategory"].DataPropertyName = "categoryId";
                    dataGridViewSubCategory.Columns["columnDate"].DataPropertyName = "date";
                }
                else
                {
                    dataGridViewSubCategory.AutoGenerateColumns = false;
                    dataGridViewSubCategory.DataSource = categories;
                    dataGridViewSubCategory.Columns["columnId"].Visible = false;
                    Logger.Instance.info("Not exists subcategory records");
                    MessageBox.Show("No existen SubCategorías Registradas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void ListAll(List<ESubCategory> categories)
        {
            try
            {
                Logger.Instance.info("SubCategoryForm(search)");
                if (categories.Count > 0 && categories != null)
                {
                    dataGridViewSubCategory.AutoGenerateColumns = false;
                    dataGridViewSubCategory.DataSource = categories;
                    dataGridViewSubCategory.Columns["columnId"].Visible = false;
                    dataGridViewSubCategory.Columns["columnId"].DataPropertyName = "id";
                    dataGridViewSubCategory.Columns["columnName"].DataPropertyName = "name";
                    dataGridViewSubCategory.Columns["columnIdCategory"].DataPropertyName = "categoryId";
                    dataGridViewSubCategory.Columns["columnDate"].DataPropertyName = "date";
                }
                else
                {
                    dataGridViewSubCategory.AutoGenerateColumns = false;
                    dataGridViewSubCategory.Columns["columnId"].Visible = false;
                    dataGridViewSubCategory.DataSource = categories;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Save()
        {
            try
            {

                Logger.Instance.info("Save subcategory");
                if (subCategory == null) subCategory = new ESubCategory();
                
                subCategory.name = textboxName.Text;
                subCategory.date = Convert.ToDateTime(labelDate.Text);
                subCategory.categoryId = this.category.id;
                subCategoryLogic.Register(subCategory);
                if (subCategoryLogic.stringBuilder.Length != 0)
                {
                    MessageBox.Show(subCategoryLogic.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    Logger.Instance.info("Sucessful subcategory save");
                    MessageBox.Show("Subcategoría registrada/actualizada con éxito");
                    ListAll();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.error(ex.Message);
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void Edit()
        {
            CategoryLogic categoryLogic = new CategoryLogic();
            Logger.Instance.info("Edit sub category");
            if (dataGridViewSubCategory.CurrentRow != null)
            {
                subCategory = (ESubCategory)dataGridViewSubCategory.CurrentRow.DataBoundItem;
                category =categoryLogic.GetForId(subCategory.id);
                labelCategory2.Text = category.name;
                textboxName.Text = subCategory.name;
                labelDate.Text = Convert.ToString(subCategory.date);
            }
            else
                MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Delete(int id)
        {
            try
            {
                subCategoryLogic.Delete(id);
                MessageBox.Show("Subcategoría eliminada satisfactoriamente");
                ListAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void SubCategoryForm_Load(object sender, EventArgs e)
        {
            this.Load_Default();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            
            if (labelCategory.Text != "")
            {
                State(true);
                subCategory = null;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Categoria");
                //categoryForm.Opacity = 0.95;
                //categoryForm.ShowDialog();
            }
           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
            State(false);
            Clear();
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            State(true);
            Edit();
            ListAll1();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de borrar ésta subcategoría?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dataGridViewSubCategory.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dataGridViewSubCategory[0, dataGridViewSubCategory.CurrentCell.RowIndex].Value);
                    MessageBox.Show("ID : " + id);
                    Delete(id);
                    
                }
                else
                    MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (labelCategory.Text != "")
            {
                ListAll(subCategoryLogic.search(category.id, textBoxSearch.Text));
            }
            else
            {
                ListAll(subCategoryLogic.searchAll(textBoxSearch.Text));
            }
            
        }

        private void buttonNewArticle_Click(object sender, EventArgs e)
        {
            Logger.Instance.info("Add article");
            if (dataGridViewSubCategory.CurrentRow != null)
            {
                subCategory = (ESubCategory)dataGridViewSubCategory.CurrentRow.DataBoundItem;
                articleForm.refresh(subCategory);
                container(articleForm);

            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
