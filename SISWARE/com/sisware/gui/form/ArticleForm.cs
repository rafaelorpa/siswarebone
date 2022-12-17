using com.sisware.bean;
using com.sisware.logic;
using com.snapsoft.util;
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
    public partial class ArticleForm : Form
    {
        private ESubCategory subcategory;
        private readonly ArticleLogic articlelogic;
        private EArticle article;
        private EMeasure measure;
        private readonly MeasureLogic measurelogic;
        private bool band;
        private bool bandgen;
        private int userCode;
        public ArticleForm(int userCode)
        {
            InitializeComponent();
            subcategory = new ESubCategory();
            articlelogic = new ArticleLogic();
            article = new EArticle();
            measure = new EMeasure();
            measurelogic = new MeasureLogic();
            band = false;
            bandgen = false;
            this.userCode = userCode;
        }

        public void Load_Default()
        {
            DateTime date = DateTime.Today;
            labelDate.Text = Convert.ToString(date);
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            labelSubCategory.Text = subcategory.name;
            labelSubCategory2.Text= subcategory.name;
            Clear();
            ListMeasure();

            if (subcategory.name != null)
            {

                ListAll();
            }
            else
            {
                ListAll1();
            }
        }

        public void ListMeasure()
        {
            try
            {
                Logger.Instance.info("Mesaure List");
                List<EMeasure> measures = measurelogic.GetAll();
                if (measures.Count > 0 && measures != null)
                {
                    for (int i = 0; i < measures.Count; i++)
                    {
                        ComboBoxMeasure.Items.Add(measures[i].description);
                    }
                }
                else
                {
                    Logger.Instance.info("Not exists measures records");
                    MessageBox.Show("No existen unidades de medida registradas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void refresh(ESubCategory subcategoryn)
        {
            
            band = true;
            this.subcategory = subcategoryn;
        }

        private void Clear()
        {
            textboxName.Clear();
            ComboBoxMeasure.SelectedIndex=-1;

        }

        private void ListAll()
        {
            try
            {
                Logger.Instance.info("Article List");
                
                List<EArticle> articles = articlelogic.GetForSubCategory(subcategory.id);
                if (articles.Count > 0 && articles != null)
                {
                    dataGridViewArticle.AutoGenerateColumns = false;
                    dataGridViewArticle.DataSource = articles;
                    dataGridViewArticle.Columns["columnId"].Visible = false;
                    dataGridViewArticle.Columns["ColumnSubCategory"].Visible = false;
                    dataGridViewArticle.Columns["columnId"].DataPropertyName = "id";
                    dataGridViewArticle.Columns["columnDescription"].DataPropertyName = "description";
                    dataGridViewArticle.Columns["ColumnMeasureUnit"].DataPropertyName = "measure";
                    dataGridViewArticle.Columns["columnDate"].DataPropertyName = "date";
                    dataGridViewArticle.Columns["ColumnUserCode"].DataPropertyName = "userId";
                    dataGridViewArticle.Columns["ColumnSubCategory"].DataPropertyName = "subCategoryId";
                }
                else
                {
                    dataGridViewArticle.AutoGenerateColumns = false;
                    dataGridViewArticle.DataSource = articles;
                    dataGridViewArticle.Columns["columnId"].Visible = false;
                    dataGridViewArticle.Columns["ColumnSubCategory"].Visible = false;
                    dataGridViewArticle.Columns["ColumnUserCode"].Visible = false;
                    Logger.Instance.info("Not exists articles records");
                    MessageBox.Show("No existen Productos Registradas");
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
                Logger.Instance.info("Article List");
                band = false;
                List<EArticle> articles = articlelogic.GetAll();
                if (articles.Count > 0 && articles != null)
                {
                    dataGridViewArticle.AutoGenerateColumns = false;
                    dataGridViewArticle.DataSource = articles;
                    dataGridViewArticle.Columns["columnId"].Visible = false;
                    dataGridViewArticle.Columns["ColumnSubCategory"].Visible = false;
                    dataGridViewArticle.Columns["columnId"].DataPropertyName = "id";
                    dataGridViewArticle.Columns["columnDescription"].DataPropertyName = "description";
                    dataGridViewArticle.Columns["ColumnMeasureUnit"].DataPropertyName = "measure";
                    dataGridViewArticle.Columns["columnDate"].DataPropertyName = "date";
                    dataGridViewArticle.Columns["ColumnUserCode"].DataPropertyName = "userId";
                    dataGridViewArticle.Columns["ColumnSubCategory"].DataPropertyName = "subCategoryId";
                }
                else
                {
                    dataGridViewArticle.AutoGenerateColumns = false;
                    dataGridViewArticle.DataSource = articles;
                    dataGridViewArticle.Columns["columnId"].Visible = false;
                    dataGridViewArticle.Columns["ColumnSubCategory"].Visible = false;
                    dataGridViewArticle.Columns["ColumnUserCode"].Visible = false;
                    Logger.Instance.info("Not exists articles records");
                    MessageBox.Show("No existen Articulos Registradas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void ListAll2(List<EArticle> articles)
        {
            try
            {
                Logger.Instance.info("ArticleForm(search)");
                if (articles.Count > 0 && articles != null)
                {
                    dataGridViewArticle.AutoGenerateColumns = false;
                    dataGridViewArticle.DataSource = articles;
                    dataGridViewArticle.Columns["columnId"].Visible = false;
                    dataGridViewArticle.Columns["ColumnSubCategory"].Visible = false;
                    dataGridViewArticle.Columns["columnId"].DataPropertyName = "id";
                    dataGridViewArticle.Columns["columnDescription"].DataPropertyName = "description";
                    dataGridViewArticle.Columns["ColumnMeasureUnit"].DataPropertyName = "measure";
                    dataGridViewArticle.Columns["columnDate"].DataPropertyName = "date";
                    dataGridViewArticle.Columns["ColumnUserCode"].DataPropertyName = "userId";
                    dataGridViewArticle.Columns["ColumnSubCategory"].DataPropertyName = "subCategoryId";
                }
                else
                {
                    dataGridViewArticle.AutoGenerateColumns = false;
                    dataGridViewArticle.DataSource = articles;
                    dataGridViewArticle.Columns["columnId"].Visible = false;
                    dataGridViewArticle.Columns["ColumnSubCategory"].Visible = false;
                    dataGridViewArticle.Columns["ColumnUserCode"].Visible = false;
                    Logger.Instance.info("Not exists articles records");
                    MessageBox.Show("No existen Articulos Registradas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //Procedimiento para guardar Datos de un Productos
        private void Save()
        {
            try
            {
                Logger.Instance.info("Save article");
                if (article == null) article = new EArticle();
                article.description = textboxName.Text;
                article.date = Convert.ToDateTime(labelDate.Text);
                measure = measurelogic.GetForId1(ComboBoxMeasure.Text);
                article.measureId = measure.id;
                article.subCategoryId = this.subcategory.id;
                article.userId = this.userCode;
                                                
                articlelogic.Register(article);
                if (articlelogic.stringBuilder.Length != 0)
                {
                    MessageBox.Show(articlelogic.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    Logger.Instance.info("Sucessful subcategory save");
                    MessageBox.Show("Articulo registrada/actualizada con éxito");
                    if (band)
                    {
                        ListAll();
                    }
                    else
                    {
                        ListAll1();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.error(ex.Message);
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        //Procedimiento para Editar un Producto
        private void Edit()
        {
            
            SubCategoryLogic subcategoryLogic = new SubCategoryLogic(); 
            Logger.Instance.info("Edit sub category");
            if (dataGridViewArticle.CurrentRow != null)
            {
                
                article = (EArticle)dataGridViewArticle.CurrentRow.DataBoundItem;
                subcategory=subcategoryLogic.GetForId(article.subCategoryId);
                labelSubCategory2.Text = subcategory.name;
                textboxName.Text = article.description;
                labelDate.Text = Convert.ToString(article.date);
                ComboBoxMeasure.SelectedIndex = article.measureId;
                bandgen = false;
            }
            else
                MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Delete(int id)
        {
            try
            {
                articlelogic.Delete(id);
                MessageBox.Show("Producto eliminado satisfactoriamente");
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
                Clear();
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

        private void ArticleForm_Load(object sender, EventArgs e)
        {
            Load_Default();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (labelSubCategory.Text != "")
            {
                State(true);
                article = null;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Subcategoria");
                //categoryForm.Opacity = 0.95;
                //categoryForm.ShowDialog();
            }
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
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de borrar éste artículo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dataGridViewArticle.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dataGridViewArticle[0, dataGridViewArticle.CurrentCell.RowIndex].Value);
                    //MessageBox.Show("ID : " + id);
                    Delete(id);
                    band = false;
                }
                else
                    MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (labelSubCategory.Text != "")
            {
                ListAll2(articlelogic.search(subcategory.id, textBoxSearch.Text));
            }
            else
            {
                ListAll2(articlelogic.searchAll(textBoxSearch.Text));
            }
        }
    }
}
