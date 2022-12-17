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
    public partial class SearchArticleForm : Form
    {
        private ESearchArticle searchArticle;
        private ArticleLogic articleLogic;
        public int codeArticle;
        public string codeControlArticle;
        public string descriptionArticle;
        public string measureunitArticle;
        public SearchArticleForm()
        {
            InitializeComponent();
            searchArticle = new ESearchArticle();
            articleLogic = new ArticleLogic();

        }

        private void ListAll()
        {
            try
            {
                //dataGridViewSearchArticle.Rows.Clear();
                Logger.Instance.info("Article Search List");
                List<ESearchArticle> articles = articleLogic.GetAllArticles();
                if (articles.Count > 0 && articles != null)
                {
                    dataGridViewSearchArticle.AutoGenerateColumns = false;
                    dataGridViewSearchArticle.DataSource = articles;
                    dataGridViewSearchArticle.Columns["columnId"].Visible = false;
                    dataGridViewSearchArticle.Columns["columnId"].DataPropertyName = "articleId";
                    dataGridViewSearchArticle.Columns["columnDescription"].DataPropertyName = "articleDescription";
                    dataGridViewSearchArticle.Columns["ColumnMeasureUnit"].DataPropertyName = "articleMeasureUnit";
                }
                else
                {
                    dataGridViewSearchArticle.AutoGenerateColumns = false;
                    dataGridViewSearchArticle.DataSource = articles;
                    dataGridViewSearchArticle.Columns["columnId"].Visible = false;
                    Logger.Instance.info("Not exists articles records");
                    MessageBox.Show("No existen Articulos Registradas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void ListAllSearch(List<ESearchArticle> articles)
        {
            try
            {
                //dataGridViewSearchArticle.Rows.Clear();
                Logger.Instance.info("Article Search List");
                if (articles.Count > 0 && articles != null)
                {
                    dataGridViewSearchArticle.AutoGenerateColumns = false;
                    dataGridViewSearchArticle.DataSource = articles;
                    dataGridViewSearchArticle.Columns["columnId"].Visible = false;
                    dataGridViewSearchArticle.Columns["columnId"].DataPropertyName = "articleId";
                    dataGridViewSearchArticle.Columns["columnDescription"].DataPropertyName = "articleDescription";
                    dataGridViewSearchArticle.Columns["ColumnMeasureUnit"].DataPropertyName = "articleMeasureUnit";
                }
                else
                {
                    dataGridViewSearchArticle.AutoGenerateColumns = false;
                    dataGridViewSearchArticle.DataSource = articles;
                    dataGridViewSearchArticle.Columns["columnId"].Visible = false;
                    Logger.Instance.info("Not exists articles records");
                    MessageBox.Show("No existen Articulos Registradas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void SearchArticleForm_Load(object sender, EventArgs e)
        {
            ListAll();
            textBoxSearch.Clear();
            textBoxSearch.Focus();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ListAllSearch(articleLogic.SearchArticle(textBoxSearch.Text));

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (dataGridViewSearchArticle.CurrentRow != null)
            {
                codeArticle = Convert.ToInt32(dataGridViewSearchArticle[0, dataGridViewSearchArticle.CurrentCell.RowIndex].Value);
                descriptionArticle = Convert.ToString(dataGridViewSearchArticle[1, dataGridViewSearchArticle.CurrentCell.RowIndex].Value);
                measureunitArticle = Convert.ToString(dataGridViewSearchArticle[2, dataGridViewSearchArticle.CurrentCell.RowIndex].Value);
                //MessageBox.Show("ID : " + id);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
