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
    public partial class SearchProviderForm : Form
    {
        private EProvider provider;
        private readonly ProviderLogic providerlogic;
        public string nameprovider;
        public int codeProvider;
        public SearchProviderForm()
        {
            InitializeComponent();
            provider = new EProvider();
            providerlogic = new ProviderLogic();
        }


        private void ListAll()
        {
            try
            {
                Logger.Instance.info("Provider List");
                List<EProvider> providers = providerlogic.GetAll();
                if (providers.Count > 0 && providers != null)
                {
                    dataGridViewProvider.AutoGenerateColumns = false;
                    dataGridViewProvider.DataSource = providers;
                    dataGridViewProvider.Columns["columnId"].DataPropertyName = "id";
                    dataGridViewProvider.Columns["columnNit"].DataPropertyName = "nit";
                    dataGridViewProvider.Columns["columnName"].DataPropertyName = "name";
                    dataGridViewProvider.Columns["columnCategory"].DataPropertyName = "category";
                    dataGridViewProvider.Columns["columnAddress"].DataPropertyName = "address";
                    dataGridViewProvider.Columns["columnCity"].DataPropertyName = "city";

                }
                else
                {
                    Logger.Instance.info("Not exists provider records");
                    MessageBox.Show("No existen Proveedores Registrados");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void ListAll(List<EProvider> providers)
        {
            try
            {
                Logger.Instance.info("ProviderForm(search)");
                if (providers.Count > 0 && providers != null)
                {
                    dataGridViewProvider.AutoGenerateColumns = false;
                    dataGridViewProvider.DataSource = providers;
                    dataGridViewProvider.Columns["columnId"].DataPropertyName = "id";
                    dataGridViewProvider.Columns["columnNit"].DataPropertyName = "nit";
                    dataGridViewProvider.Columns["columnName"].DataPropertyName = "name";
                    dataGridViewProvider.Columns["columnCategory"].DataPropertyName = "category";
                    dataGridViewProvider.Columns["columnAddress"].DataPropertyName = "address";
                    dataGridViewProvider.Columns["columnCity"].DataPropertyName = "city";
                }
                else
                {
                    dataGridViewProvider.DataSource = providers;
                    Logger.Instance.info("Not exists provider records");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    

    private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (dataGridViewProvider.CurrentRow != null)
            {
                codeProvider = Convert.ToInt32(dataGridViewProvider[0, dataGridViewProvider.CurrentCell.RowIndex].Value);
                nameprovider = Convert.ToString(dataGridViewProvider[2, dataGridViewProvider.CurrentCell.RowIndex].Value);
                this.DialogResult = DialogResult.OK;
                //MessageBox.Show("ID : " + id);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
            }
                
        }

        private void SearchProviderForm_Load(object sender, EventArgs e)
        {
            this.textBoxSearch.Clear();
            ListAll();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ListAll(providerlogic.Search(textBoxSearch.Text));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
