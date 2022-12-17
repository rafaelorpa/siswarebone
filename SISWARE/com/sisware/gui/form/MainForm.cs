
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.sisware.gui.form;
using com.sisware.gui.form.reporting;
using Microsoft.Win32;
using System.IO;
using com.snapsoft.util;
using com.sisware.logic;
using com.sisware.bean;
using System.Diagnostics;

namespace com.sisware.gui.form
{
    public partial class MainForm : Form
    {
        //private EmployeeForm employeeForm;
        private AboutForm aboutForm;
        private  CategoryForm categoryForm;
        private SubCategoryForm  subCategoryForm;
        private ProviderForm providerForm;
        private ArticleForm articleForm;
        private UserForm userForm;
        private InputForm inputForm;
        private OutputForm outputForm;
        //private EntityForm entityForm;
        private LoginForm loginForm;
        private BackUpForm bakupForm;
       // private ChangePasswordForm changePassword;
        public int userCode { get; set; }
        private BackUpLogic operation;
        private InventoryTempLogic invTempLogic;
        private InputLogic inputLogic;
        private InventoryLogic inventoryLogic;
        private HospitalForm hospitalForm;
        private InstrumentalistForm instrumentalistForm;
        private MedicalForm medicalForm;
        private PatientForm patientForm;
        //private SelectOutputForm selectOutputForm;
        //private SelectInputForm selectInputForm;

        public MainForm()
        {
            InitializeComponent();
            //employeeForm = new EmployeeForm();
            providerForm = new ProviderForm();
            userForm = new UserForm();
            

            //entityForm = new EntityForm();
            aboutForm = new AboutForm();
            bakupForm = new BackUpForm();
            operation = new BackUpLogic();
            
            this.hideSubMenu();
            //selectOutputForm = new SelectOutputForm();
            //selectInputForm = new SelectInputForm();
        }

        // File Menu

        private void MenuItemUsers_Click(object sender, EventArgs e)
        {
            container(userForm);
            //userForm.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Record Menu

        private void MenuItemEmployerRecord_Click(object sender, EventArgs e)
        {
           //employeeForm.ShowDialog();
        }

        private void MenuItemCategory_Click(object sender, EventArgs e)
        {
            //categoryForm.ShowDialog();
        }

        private void MenuItemProviderRecord_Click(object sender, EventArgs e)
        {
          // providerForm.ShowDialog();
        }

        private void MenuItemArticleRecord_Click(object sender, EventArgs e)
        {
           //articleForm.ShowDialog();
        }

        private void MenuItemInputRecord_Click(object sender, EventArgs e)
        {
            //inputForm = new InputForm(userCode);
            //inputForm.ShowDialog();
        }

        private void MenuItemOutPutRecord_Click(object sender, EventArgs e)
        {
            //outputForm.ShowDialog();
        }

        // Configuration Menu

        private void datosDeLaEntidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //entityForm.ShowDialog();
        }

        private void tipoDeCambioToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
        }

        // Help Menu
        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            aboutForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loginForm = new LoginForm();
            DialogResult res = loginForm.ShowDialog();
       
                if (res == DialogResult.OK)
                {
                    //recuperando la variable publica del LoginForm
                    this.EjecutarBat(@"..\..\com\sisware\gui\form\Archive\arrancarbd.bat");
                    this.EjecutarBat(@"..\..\SnapSoft-Technology\SISWAREBONE\arrancarbd.bat");
                    this.helpProvider1.HelpNamespace = @"..\..\SnapSoft-Technology\SISWAREBONE\SiswareManual.chm";
                    userCode = loginForm.codeUser; //asignamos al valor de CodeUser el dato de la variable
                    //outputForm = new OutputForm(userCode);
                    this.Enabled = true;
                    menuStrip1.Enabled = true;
                   
                    categoryForm = new CategoryForm(this.guna2Panel_container, this.userCode);
                    subCategoryForm = new SubCategoryForm(this.userCode, this.guna2Panel_container);
                    articleForm = new ArticleForm(this.userCode);
                    invTempLogic = new InventoryTempLogic();
                    inputLogic = new InputLogic();
                    inventoryLogic = new InventoryLogic();
                    inputForm = new InputForm(this.userCode);
                     hospitalForm = new HospitalForm();
                    instrumentalistForm = new InstrumentalistForm();
                    patientForm = new PatientForm();
                    medicalForm = new MedicalForm();
                    outputForm = new OutputForm();
                //changePassword = new ChangePasswordForm(userCode);
                //break;
                 }
                else
                {
                    this.Close();
                }
        }


        // Create backup
        private void MenuItemBackUp_Click(object sender, EventArgs e)
        {
            bakupForm.setOption(true);
            bakupForm.ShowDialog();
        }

        private void MenuItemRestore_Click(object sender, EventArgs e)
        {
            bakupForm.setOption(false);
            bakupForm.ShowDialog();
        }

        private void MenuItemPasswordEdit_Click(object sender, EventArgs e)
        {
            //changePassword.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Cierre de gestión
        /// </summary>
        private void CloseManagement()
        {
            if (MessageBox.Show("Está seguro de realizar el cierre de gestión?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Logger.Instance.info("MainForm(CloseManagement)");

                    RegistryKey myDocumentskey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders\");
                    String DEFAULT_FOLDER_NAME = "SnapSoft";
                    string filePath = (String)myDocumentskey.GetValue("Personal") + "\\" + DEFAULT_FOLDER_NAME;
                    DateTime date = DateTime.Now;
                    string fileName = "SISWARE_backup" + date.Day.ToString() + date.Month.ToString() + date.Year.ToString() + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + ".sql";

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    Logger.Instance.info("Create backup");
                    // Step 1: Export Data Base
                    operation.Export(filePath + "\\" + fileName);

                    if (File.Exists(filePath + "\\" + fileName))
                    {
                        // Step 2: Table sw_inventory_temp clean
                        Logger.Instance.info("Table sw_inventory_temp clean");
                        operation.TableClean("sw_inventory_temp");

                        // Step 3: Copy Inventary table to inventary table temp
                        Logger.Instance.info("Copy Inventary table to inventary table temp");

                        if (operation.CopyInventoryTable())
                        {
                            Logger.Instance.info("Table sw_output, sw_inventory, sw_input clean");
                            operation.TableClean("sw_output");
                            operation.TableClean("sw_inventory");
                            operation.TableClean("sw_input");

                            MessageBox.Show("Cierre de gestión realizada exitósamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.error(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
        }

       

        

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // OutputReportByControlCodeForm orf = new OutputReportByControlCodeForm();
          //  orf.ShowDialog();
            //selectOutputForm.ShowDialog();
        }

        private void MenuItemManagementClose_Click(object sender, EventArgs e)
        {
            CloseManagement();
        }

        private void MenuItemManagementOpen_Click(object sender, EventArgs e)
        {
            //UpdaterForm updateForm = new UpdaterForm(this.userCode);
            //updateForm.ShowDialog();
        }

        private void inventarioGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GetDateGeneralConsumptionForm generalConsumption = new GetDateGeneralConsumptionForm(2);
            //generalConsumption.ShowDialog();
        }

        private void consumoGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GetDateGeneralConsumptionForm generalConsumption = new GetDateGeneralConsumptionForm(1);
            //generalConsumption.ShowDialog();
        }

        private void numeroDeIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //selectInputForm.ShowDialog();
        }

        private void ingresosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralInputReportForm generalInputR = new GeneralInputReportForm();
            generalInputR.ShowDialog();
        }

        private void porNumeroDeSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //selectOutputForm.ShowDialog();
        }

        private void geeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralOutputReportForm generalOutputR = new GeneralOutputReportForm();
            generalOutputR.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralArticleReport generalArticleR = new GeneralArticleReport();
            generalArticleR.ShowDialog();
        }

        private void MenuManual_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EjecutarBat(string pathArchivoBat)
        {
            try
            {
                System.Diagnostics.Process[] procesos = System.Diagnostics.Process.GetProcesses();
                Process proceso = new Process();
                proceso.StartInfo.FileName = pathArchivoBat;
                bool resp = true;
                foreach (Process myProcess in procesos)
                {
                    if(myProcess.ProcessName == "xampp-control")
                    {
                      resp = false;
                        break;
                    }
                }
                if (resp)
                {
                    proceso.Start();
                    proceso.WaitForExit();
                }
                 //Espera a que termine la ejecución del archivo .bat
            }
            catch (Exception ex)
            {
                Logger.Instance.error("MainForm: (" + ex.Message + ")");
                MessageBox.Show(ex.Message);
            }

        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porSubCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ArticleKardexForm kardexForm = new ArticleKardexForm(1);
            //kardexForm.ShowDialog();
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralKardexReportForm generalKardex = new GeneralKardexReportForm();
            generalKardex.ShowDialog();
        }

        private void porProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ArticleKardexForm kardexForm = new ArticleKardexForm(2);
            //kardexForm.ShowDialog();
        }

        private void porProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ArticleKardexForm kardexForm = new ArticleKardexForm(3);
            //kardexForm.ShowDialog();
        }




        /*private void PasarDatosInventoryAOutput()
        {
            try
            {

                List<EInventory> inventories = inventoryLogic.GetAll();
                if (inventories.Count > 0 && inventories != null)
                {
                    
                    EOutput output = new EOutput();
                    OutputLogic outputLogic = new OutputLogic();
                    
                    
                    for(int i=0; i<inventories.Count; i++)
                    {
                        output.date=DateTime.Parse("2016-12-01");
                        output.hour = "04:04:21";
                        output.outputNumber = "000000";
                        output.quantity = 0;
                        output.userCode = 2;
                        output.employeeCode = 47;
                        output.inventaryCode = inventories[i].code;
                        output.articleCode = inventories[i].articleCode;
                        output.bsUnitPrice = inventories[i].bsUnitPrice;
                        output.ufvUnitPrice = inventories[i].ufvUnitPrice;
                        output.bsTotalPrice =0;
                        output.ufvTotalPrice = 0;
                        output.observation = "";
                        outputLogic.Register(output);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }*/

        private void porFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ArticleKardexForm kardexForm = new ArticleKardexForm(4);
            //kardexForm.ShowDialog();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }
        private void container(object _form)
        {

            if (guna2Panel_container.Controls.Count > 0) guna2Panel_container.Controls.Clear();

            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            guna2Panel_container.Controls.Add(fm);
            guna2Panel_container.Tag = fm;
            fm.Show();

        }
        private void hideSubMenu()
        {
            panelAlmacen.Visible = false;
            panelCompras.Visible = false;
            panelVentas.Visible = false;
            
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void guna2ButtonInico_Click(object sender, EventArgs e)
        {

        }

        private void guna2ButtonUser_Click(object sender, EventArgs e)
        {
            //showSubMenu(gunaPanelUser);
        }

        private void btnEqualizer_Click(object sender, EventArgs e)
        {

        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAlmacen);
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCompras);
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVentas);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            container(categoryForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            subCategoryForm.Load_Default();
            container(subCategoryForm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            container(articleForm);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCompras);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            container(providerForm);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            container(inputForm);
        }

        private void buttonPatient_Click(object sender, EventArgs e)
        {
            container(patientForm);
        }

        private void buttonHospital_Click(object sender, EventArgs e)
        {
            container(hospitalForm);
        }

        private void buttonIntrumentalist_Click(object sender, EventArgs e)
        {
            container(instrumentalistForm);
        }

        private void buttonMedical_Click(object sender, EventArgs e)
        {
            container(medicalForm);
        }

        private void buttonOutput1_Click(object sender, EventArgs e)
        {
            container(outputForm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CloseManagement();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchArticleForm searchArticle = new SearchArticleForm();
            container(searchArticle);
        }
        /*private Form activeForm = null;
private void openChildForm(Form childForm)
{
if (activeForm != null) activeForm.Close();
activeForm = childForm;
childForm.TopLevel = false;
childForm.FormBorderStyle = FormBorderStyle.None;
childForm.Dock = DockStyle.Fill;
panelChildForm.Controls.Add(childForm);
panelChildForm.Tag = childForm;
childForm.BringToFront();
childForm.Show();
}*/
    }
}
