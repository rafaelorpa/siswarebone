using com.sisware.bean;
using com.sisware.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace com.sisware.gui.form
{
    public partial class UserForm : Form
    {
        //
        //
        //Creamos las instancias de la clase EUser y UserLogic
        private EUser _user;
        //private ERole _role;
        private readonly UserLogic _userlogic = new UserLogic();
        private readonly RoleLogic _rolelogic = new RoleLogic();

        public UserForm()
        {
            InitializeComponent();
            //CarryLevel();
        }

       /* private void CarryLevel()
        {
            try
            {
               
                List<ERole> roles = new List<ERole>();

                roles = _rolelogic.GetAllDescription();
                for(int i = 0; i < roles.Count; i++)
                {
                    ComboBoxLevel.Items.Add(roles[i].name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }*/

        //Guardamos un usuario nuevo
        private void Save()
        {
            try
            {
                if (_user == null) _user = new EUser();

                _user.ci = textBoxCI.Text;
                _user.firstName = textBoxFirstName.Text;
                _user.lastName = textBoxLastName.Text;
                _user.names = textBoxNames.Text;
                _user.user = textBoxUser.Text;
                _user.password = textBoxPassword.Text;
                _user.trace = textBoxTrace.Text;
                _user.date = Convert.ToDateTime(labelDate.Text);
                _user.role = ComboBoxLevel.Text;

                _userlogic.Register(_user);

                if (_userlogic.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_userlogic.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Usuario registrado/actualizado con éxito");

                    ListAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        //
       
        //Listamos todos los Usuarios registrados en el Sistema
        private void ListAll()
        {
            
            try
            {
                List<EUser> user =_userlogic.GetAll();
                if (user.Count > 0)
                {
                    dataGridViewUsers.AutoGenerateColumns = false;
                    dataGridViewUsers.DataSource = user;
                    dataGridViewUsers.Columns["columid"].DataPropertyName = "id";
                    dataGridViewUsers.Columns["columCI"].DataPropertyName = "ci";
                    dataGridViewUsers.Columns["columfirstName"].DataPropertyName = "firstName";
                    dataGridViewUsers.Columns["columlastName"].DataPropertyName = "lastName";
                    dataGridViewUsers.Columns["columnames"].DataPropertyName = "names";
                    
                    dataGridViewUsers.Columns["columuser"].DataPropertyName = "user";
                    dataGridViewUsers.Columns["columpassword"].DataPropertyName = "password";
                    dataGridViewUsers.Columns["columTrace"].DataPropertyName = "trace";
                    dataGridViewUsers.Columns["columdate"].DataPropertyName = "date";
                    dataGridViewUsers.Columns["columrole"].DataPropertyName = "role";
                    
                    
                }
                else
                    MessageBox.Show("No existen Usuarios Registrados");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        //Eliminamos un determinado usuario
        private void Delete(int id)
        {
            try
            {
                _userlogic.Delete(id);

                MessageBox.Show("Usuario eliminado satisfactoriamente");

                ListAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void PresentDate()
        {

            if (dataGridViewUsers.CurrentRow != null)
            {
                _user = (EUser)dataGridViewUsers.CurrentRow.DataBoundItem;
                textBoxCI.Text = _user.ci;
                textBoxFirstName.Text = _user.firstName;
                textBoxLastName.Text = _user.lastName;
                textBoxNames.Text = _user.names;
                textBoxUser.Text = _user.user;
                textBoxPassword.Text = _user.password;
                textBoxPasswordRepit.Text = _user.password;
                textBoxTrace.Text = _user.trace;
                ComboBoxLevel.Text =_user.role;
            }
            else
                MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Clear()
        {
            textBoxCI.Text = null;
            textBoxFirstName.Text = null;
            textBoxLastName.Text = null;
            textBoxNames.Text = null;
            textBoxUser.Text = null;
            textBoxPassword.Text = null;
            textBoxPasswordRepit.Text = null;
            textBoxTrace.Text = null;
            ComboBoxLevel.SelectedIndex = 0;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _user = null;
           State(true);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
                
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            Clear();
            ListAll();
            labelDate.Text = Convert.ToString(thisDay);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            this.State(true);
            PresentDate();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void GButtonNew_Click(object sender, EventArgs e)
        {
            _user = null;
            this.State(true);
        }
        public void State(Boolean state) 
        {
            if(state)
            {
                GPanelDatos.Enabled = true;
                GPanelDatos.Visible = true;
                Size = new Size(1111, 800);
            }
            else
            {
                GPanelDatos.Enabled = false;
                GPanelDatos.Visible = false;
                Size = new Size(1111, 470);
            }
        }

        private void GButtonEdit_Click(object sender, EventArgs e)
        {
            this.State(true);
            PresentDate();
        }

        private void GButtonErase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de borrar éste usuario?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dataGridViewUsers.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dataGridViewUsers[0, dataGridViewUsers.CurrentCell.RowIndex].Value);
                    MessageBox.Show("ID : " + id);
                    Delete(id);
                }
                else
                    MessageBox.Show("Debe seleccionar un registro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void GButtonSave_Click(object sender, EventArgs e)
        {
            string pass1, pass2;
            pass1 = textBoxPassword.Text;
            pass2 = textBoxPasswordRepit.Text;
            if (pass1 == pass2)
            {
                Save();
                this.State(false);
                Clear();
            }
            else
                MessageBox.Show("Los campos de contraseña estan incorrectos o son diferentes");
        }

        private void GButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        /*private List<string> GetDescriptionByIdRoles(List<int> idroles)
        {
            List<string> rolesNames=new List<String>();
            
            for(int i = 0; i <idroles.Count ; i++)
            {
                rolesNames.Add(_rolelogic.GetDescriptionById(Convert.ToInt32(idroles[i]));
            }
            return rolesNames;
                    
        }*/
    }
}

