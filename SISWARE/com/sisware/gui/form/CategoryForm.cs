using com.sisware.bean;
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

namespace com.sisware.gui.form
{
    public partial class CategoryForm : Form
    {
        private SubCategoryForm subCategoryForm;
        private ECategory category;
        private readonly CategoryLogic categoryLogic;
        private Guna2Panel panelContainer;
        public CategoryForm(Guna2Panel panelCont, int codeUser)
        {

            InitializeComponent();
            category = new ECategory();
            categoryLogic = new CategoryLogic();
            subCategoryForm = new SubCategoryForm(codeUser, panelCont);
            this.panelContainer = panelCont;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            labelDate.Text = Convert.ToString(date);
            groupBox1.Enabled = false;
            Clear();
            ListAll();
        }

        private void Clear()
        {
            TexboxName.Clear();
        }

       

        private void ListAll()
        {
            try
            {
                Logger.Instance.info("Category List");
                List<ECategory> categories = categoryLogic.GetAll();
                if (categories.Count > 0 && categories != null)
                {
                    dataGridViewCategory.AutoGenerateColumns = false;
                    dataGridViewCategory.DataSource = categories;
                    dataGridViewCategory.Columns["columIdCategory"].DataPropertyName = "id";
                    dataGridViewCategory.Columns["columNameCategory"].DataPropertyName = "name";
                    dataGridViewCategory.Columns["columDateCategory"].DataPropertyName = "date";
                }
                else
                {
                    Logger.Instance.info("Not exists category records");
                    MessageBox.Show("No existen Categorías Registradas");
                    dataGridViewCategory.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ListAll(List<ECategory> categories)
        {
            try
            {
                Logger.Instance.info("CategoryForm(search)");
                if (categories.Count > 0 && categories != null)
                {
                    dataGridViewCategory.AutoGenerateColumns = false;
                    dataGridViewCategory.DataSource = categories;
                    dataGridViewCategory.Columns["columIdCategory"].DataPropertyName = "id";
                    dataGridViewCategory.Columns["columNameCategory"].DataPropertyName = "name";
                    dataGridViewCategory.Columns["columDateCategory"].DataPropertyName = "date";
                }
                else
                {
                    dataGridViewCategory.DataSource = categories;
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
                Logger.Instance.info("Save category");
                if (category == null) category = new ECategory();
                category.name = TexboxName.Text;
                category.date = Convert.ToDateTime(labelDate.Text);
                categoryLogic.Register(category);
                if (categoryLogic.stringBuilder.Length != 0)
                {
                    MessageBox.Show(categoryLogic.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    Logger.Instance.info("Sucessful category save");
                    MessageBox.Show("Categoría registrada/actualizada con éxito");
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
            Logger.Instance.info("Edit category");
            if (dataGridViewCategory.CurrentRow != null)
            {
                category = (ECategory)dataGridViewCategory.CurrentRow.DataBoundItem;
                TexboxName.Text = category.name;
                labelDate.Text = Convert.ToString(category.date);
            }
            else
                MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Delete(int id)
        {
            try
            {
                categoryLogic.Delete(id);
                MessageBox.Show("Categoría eliminada satisfactoriamente");
                ListAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
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

        private void buttonNew_Click(object sender, EventArgs e)
        {
            category = null;
            this.State(true);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            
            Edit();
            ListAll();
            State(true);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
            State(false);
            Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Está seguro de borrar ésta categoría?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dataGridViewCategory.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dataGridViewCategory[0, dataGridViewCategory.CurrentCell.RowIndex].Value);
                    MessageBox.Show("ID : " + id);
                    Delete(id);
                   
                }
                else
                    MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void bunifuTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            ListAll(categoryLogic.search(textBoxSearch.Text));
        }

        private void buttonNewSubCategory_Click(object sender, EventArgs e)
        {
            
            Logger.Instance.info("Add subcategory");
            if (dataGridViewCategory.CurrentRow != null)
            {
                category = (ECategory)dataGridViewCategory.CurrentRow.DataBoundItem;
                subCategoryForm.refresh(category);
                container(subCategoryForm);
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
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
    }
}
