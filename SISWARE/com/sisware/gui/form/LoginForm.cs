using com.sisware.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sisware.bean;
using com.snapsoft.util;

namespace com.sisware.gui.form
{
    public partial class LoginForm : Form
    {
        private UserLogic userlogic;
        private EUser user;
        public int codeUser;
       // private com.snapsoft.util.Segurity_ security;

        public LoginForm()
        {
            InitializeComponent();
            userlogic = new UserLogic();
            user = new EUser(); 
        }


        private bool CheckLogin(string nameUser, string passwordUser)
        {
            try
            {
                Logger.Instance.info("get in User");
                List<EUser> users = userlogic.CheckDateUser(nameUser,passwordUser);
                if (users.Count > 0 && users != null)
                {
                    codeUser = users[users.Count - 1].id;
                    return true;
                }
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                Logger.Instance.error(ex.Message);
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
                return false;
            }
            
        }


            

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            string nameUser = textBoxName.Text;
            string passwordUser = textBoxPassword.Text;

            //string s = com.snapsoft.util.Segurity_.encrypt("abcdef");


            if (CheckLogin(nameUser, passwordUser))
            {
                mainForm.userCode = codeUser;
                this.DialogResult = DialogResult.OK;
                //MessageBox.Show("Codigo de Usuario" , codeUser.ToString());
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("El usuario no esta Registrado o sus datos son incorrectos");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
