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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace com.sisware.gui.form
{

    public partial class ProviderForm : Form
    {
        private EProvider provider;
        private readonly ProviderLogic providerLogic;
        public ProviderForm()
        {
            InitializeComponent();
            providerLogic = new ProviderLogic();
            provider =new EProvider();
        }

        private void Clear()
        {
            textBoxNit.Clear();
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxAddress.Clear();
            textBoxTelephone.Clear();
            textBoxCity.Clear();
            textBoxCountry.Clear();
            textBoxNames.Clear();
            textBoxContactPhone.Clear();
            textBoxContactEmail.Clear();
        }

        private void ListAll()
        {
            try
            {
                Logger.Instance.info("Category List");
                List<EProvider> providers = providerLogic.GetAll();
                if (providers.Count > 0 && providers != null)
                {
                    dataGridViewProvider.AutoGenerateColumns = false;
                    dataGridViewProvider.DataSource = providers;
                    dataGridViewProvider.Columns["columnId"].DataPropertyName = "id";
                    dataGridViewProvider.Columns["columnNit"].DataPropertyName = "nit";
                    dataGridViewProvider.Columns["columnName"].DataPropertyName = "name";
                    dataGridViewProvider.Columns["columnCategory"].DataPropertyName = "category";
                    dataGridViewProvider.Columns["columnAddress"].DataPropertyName = "address";
                    dataGridViewProvider.Columns["columnTelephone"].DataPropertyName = "telephone";
                    dataGridViewProvider.Columns["columnCity"].DataPropertyName = "city";
                    dataGridViewProvider.Columns["columnCountry"].DataPropertyName = "country";
                    dataGridViewProvider.Columns["columnContactName"].DataPropertyName = "contactName";
                    dataGridViewProvider.Columns["ColumnPhoneContact"].DataPropertyName = "phone";
                    dataGridViewProvider.Columns["ColumnEmail"].DataPropertyName = "email";
                    dataGridViewProvider.Columns["columnDate"].DataPropertyName = "date";
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
                    dataGridViewProvider.Columns["columnTelephone"].DataPropertyName = "telephone";
                    dataGridViewProvider.Columns["columnCity"].DataPropertyName = "city";
                    dataGridViewProvider.Columns["columnCountry"].DataPropertyName = "country";
                    dataGridViewProvider.Columns["columnContactName"].DataPropertyName = "contactName";
                    dataGridViewProvider.Columns["ColumnPhoneContact"].DataPropertyName = "phone";
                    dataGridViewProvider.Columns["ColumnEmail"].DataPropertyName = "email";
                    dataGridViewProvider.Columns["columnDate"].DataPropertyName = "date";
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

        private void Save()
        {
            try
            {
                Logger.Instance.info("Save provider");
                if (provider == null) provider = new EProvider();

                provider.nit = textBoxNit.Text;
                provider.name = textBoxName.Text;
                provider.category = textBoxCategory.Text;
                provider.address = textBoxAddress.Text;
                provider.telephone = GroupBoxProvider.Text;
                provider.city = textBoxCity.Text;
                provider.country = textBoxCountry.Text;
                provider.contactName = textBoxNames.Text;
                provider.phone = textBoxContactPhone.Text;
                provider.email = textBoxContactEmail.Text;
                provider.date = Convert.ToDateTime(labelDate.Text);

                providerLogic.Register(provider);
                if (providerLogic.stringBuilder.Length != 0)
                {
                    MessageBox.Show(providerLogic.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    Logger.Instance.info("Sucessful proveedor save");
                    MessageBox.Show("Proveedor registrado/actualizado con éxito");
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
            Logger.Instance.info("Edit provider");
            if (dataGridViewProvider.CurrentRow != null)
            {
                provider = (EProvider)dataGridViewProvider.CurrentRow.DataBoundItem;

                textBoxNit.Text = provider.nit;
                textBoxName.Text = provider.name;
                textBoxCategory.Text = provider.category;
                textBoxAddress.Text = provider.address;
                GroupBoxProvider.Text = provider.telephone;
                textBoxCity.Text = provider.city;
                textBoxCountry.Text = provider.country;
                textBoxNames.Text = provider.contactName;
                textBoxContactPhone.Text = provider.phone;
                textBoxContactEmail.Text = provider.email;
                labelDate.Text = Convert.ToString(provider.date);
            }
            else
                MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Delete(int id)
        {
            try
            {
                providerLogic.Delete(id);
                MessageBox.Show("Proveedor eliminado satisfactoriamente");
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
                GroupBoxProvider.Enabled = true;
                GroupBoxContactProvider.Enabled = true;
                GroupBoxProvider.Visible = true;
                GroupBoxContactProvider.Visible = true;
            }
            else
            {
                GroupBoxProvider.Enabled = false;
                GroupBoxContactProvider.Enabled = false;
                GroupBoxProvider.Visible = false;
                GroupBoxContactProvider.Visible = false;
            }
        }

        public void Load_Default()
        {
            DateTime date = DateTime.Today;
            labelDate.Text = Convert.ToString(date);
            GroupBoxContactProvider.Enabled = false;
            GroupBoxProvider.Enabled=false;
            GroupBoxContactProvider.Visible = false;
            GroupBoxProvider.Visible=false;
            Clear();
            ListAll();
          
        }
        private void buttonNew_Click(object sender, EventArgs e)
        {
            State(true);

        }

        private void ProviderForm_Load(object sender, EventArgs e)
        {
            Load_Default();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
            State(false);
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            State(true);
            Edit();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de borrar éste proveedor?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dataGridViewProvider.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dataGridViewProvider[0, dataGridViewProvider.CurrentCell.RowIndex].Value);
                    //MessageBox.Show("ID : " + id);
                    Delete(id);
                    //band = false;
                }
                else
                    MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ListAll(providerLogic.Search(textBoxSearch.Text));
        }
    }

}
