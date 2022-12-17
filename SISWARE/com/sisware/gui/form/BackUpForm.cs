using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using com.sisware.logic;
using com.snapsoft.util;

namespace com.sisware.gui.form
{
    public partial class BackUpForm : Form
    {

        public bool option;
        private BackUpLogic backUpLogic;
        public BackUpForm()
        {
            InitializeComponent();
            option = false;
            backUpLogic = new BackUpLogic();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (option)
            {
                if (folderBrowserDialogBackUp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBoxBackup.Text = folderBrowserDialogBackUp.SelectedPath;
                }
            }
            else
            {
                if (this.openFileDialogSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBoxRestore.Text = this.openFileDialogSelect.FileName;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
                if (option)
                {
                    if (textBoxBackup.Text != string.Empty)
                    {
                        try
                        {
                            //Create BackUp
                            DateTime date = DateTime.Now;
                            string fileName = "SISWARE_backup" + date.Day.ToString() + date.Month.ToString() + date.Year.ToString() + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + ".sql";
                            string path = textBoxBackup.Text;

                            backUpLogic.Export(path + "\\" + fileName);

                            if (File.Exists(path + "\\" + fileName))
                            {
                                MessageBox.Show("Copia de Seguridad realizada exitósamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Seleccione una ruta donde guardará la copia de seguridad.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    try
                    {
                        if (textBoxRestore.Text != string.Empty)
                        {
                            //Restore Backup
                            
                            string backUpfile = textBoxRestore.Text;
                            if (backUpfile.EndsWith(".sql"))
                            {
                                backUpLogic.Import(backUpfile);
                                MessageBox.Show("Copia de Seguridad restaurada exitósamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("El archivo no es correcto.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione el archivo para restaurar la base de datos.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        public void setOption(bool value)
        {
            this.option = value;
        }
        public void refresh()
        {
                if (option)
                {
                    groupBox1.Text = "Seleccione una ruta donde guardará la copia de seguridad:";
                    textBoxBackup.Visible = true;
                    textBoxRestore.Visible = false;
                }
                else
                {
                    groupBox1.Text = "Seleccione el archivo para restaurar la base de datos.";
                    textBoxBackup.Visible = false;
                    textBoxRestore.Visible = true;

                }
        }

        private void BackUpForm_Load(object sender, EventArgs e)
        {
            refresh();
        }

    }
}
