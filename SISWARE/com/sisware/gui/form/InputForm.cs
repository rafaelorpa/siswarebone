using com.sisware.bean;
using com.sisware.gui.form.reporting;
using com.sisware.logic;
using com.snapsoft.util;
using Guna.UI2.WinForms.Suite;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBox = Guna.UI2.WinForms.Suite.TextBox;

namespace com.sisware.gui.form
{
    public partial class InputForm : Form
    {
        private SearchProviderForm searchProviderForm;
        private InputLogic inputLogic;
        private EInput input;
        private EInventory inventory;
        private InventoryLogic inventoryLogic;
        private SearchArticleForm searchArticle;
        //private SearchInputForm searchInput;
        private int codeProvider = 0;
        private int codeUser = 0;
        private string inputNumber;
        private string valueLiteral;
        private EOutput output;
        private OutputLogic outputLogic;

        public InputForm(int codeUsern)
        {
            InitializeComponent();
            inputLogic = new InputLogic();
            searchProviderForm = new SearchProviderForm();
            inputLogic = new InputLogic();
            input = new EInput();
            inventory = new EInventory();
            inventoryLogic = new InventoryLogic();
            searchArticle = new SearchArticleForm();
            //searchInput = new SearchInputForm();
            codeUser = codeUsern;
            output = new EOutput();
            outputLogic = new OutputLogic();
        }

        private void LoadData()
        {
                labelTime.Text = DateTime.Now.ToString("hh:mm:ss");
                //labelExchangeRate.Text = exchangerate.ToString("0.000", CultureInfo.InvariantCulture);
                int codeRegistry = 0;
                int numberInput = 0;
                List<EInput> inputs = inputLogic.GetIdNumberId();
                try
                {
                    if (inputs.Count > 0 && inputs != null)
                    {
                        codeRegistry = (inputs[inputs.Count - 1].id) + 1;
                        numberInput = (Convert.ToInt32(inputs[inputs.Count - 1].inputNumber)) + 1;
                        labelNoRecord.Text = codeRegistry.ToString("000000");
                        labelNoInput.Text = numberInput.ToString("0000");
                    }
                    else
                    {
                        codeRegistry = codeRegistry + 1;
                        numberInput = numberInput + 1;
                        labelNoRecord.Text = codeRegistry.ToString("000000");
                        labelNoInput.Text = numberInput.ToString("0000");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
                    Logger.Instance.error(ex.ToString());
                }
         }
           

       


        

        private void SaveInputs()
        {
            try
            {
                Logger.Instance.info("Save Inputs");
                if ((codeProvider > 0) && (dataGridViewInputs.RowCount > 1))
                {
                    if (input == null) input = new EInput();
                    if (inventory == null) inventory = new EInventory();
                    //input.date = Convert.ToDateTime(labelDate.Text);
                    input.date = Convert.ToDateTime(this.DateTimePicker.Text);
                    input.hour = Convert.ToString(labelTime.Text);
                    input.inputNumber = Convert.ToString(labelNoInput.Text);
                    this.inputNumber = Convert.ToString(labelNoInput.Text);
                    input.observation = Convert.ToString(textBoxObservation.Text);
                    input.userId = codeUser;
                    input.providerId = codeProvider;

                    //Resiter of Inventary
                    inventory.userId = codeUser;

                    for (int i = 0; i < dataGridViewInputs.RowCount - 1; i++)
                    {
                        //Register of Input
                        int arCode = Convert.ToInt32(dataGridViewInputs[0, i].Value);
                        if (arCode > -1)
                        {
                            input.code= Convert.ToString(dataGridViewInputs[1, i].Value);
                            input.quantity = Convert.ToDouble(dataGridViewInputs[4, i].Value);
                            input.articleId = arCode;
                            int inputCode = Convert.ToInt32(dataGridViewInputs[5, i].Value);
                            /*if (inputCode > 0)
                            {
                                input.code = inputCode;
                                List<EInventory> inventoriess = inventoryLogic.GetByCode(arCode,inputCode);
                                if (inventoriess.Count > 0 && inventoriess != null)
                                    inventoryCode = inventoriess[inventoriess.Count - 1].code;
                            }*/
                            inputLogic.Register(input);

                            List<EInput> inputs = inputLogic.GetCodeInput();
                            if (inputs.Count > 0 && inputs != null)
                            {
                                inputCode = (inputs[inputs.Count - 1].id);
                            }
                            else
                            {
                                inputCode = 1;
                            }

                            //Register of Inventory
                            int lot = 0;

                            List<EInventory> inventories = inventoryLogic.GetLot(arCode);
                            if (inventories.Count > 0 && inventories != null)
                            {
                                lot = (inventories[inventories.Count - 1].lot) + 1;
                            }
                            else
                            {
                                lot = 1;
                            }
                            inventory.code = Convert.ToString(dataGridViewInputs[1, i].Value);
                            inventory.lot = lot;
                            inventory.quantity = Convert.ToDouble(dataGridViewInputs[4, i].Value);
                            inventory.residue = Convert.ToDouble(dataGridViewInputs[4, i].Value);
                            inventory.description = Convert.ToString(dataGridViewInputs[2, i].Value);
                            inventory.articleId = arCode;
                            inventory.inputId = inputCode;
                            inventoryLogic.Register(inventory);

                            
                        }
                    }
                    if (inputLogic.stringBuilder.Length != 0)
                    {
                        MessageBox.Show(inputLogic.stringBuilder.ToString(), "Para continuar:");
                    }
                    else
                    {
                        Logger.Instance.info("Sucessful Input save");
                        MessageBox.Show("Ingreso registrado con éxito");
                    }
                }
                else
                    MessageBox.Show("Faltan llenar datos");
            }
            catch (Exception ex)
            {
                Logger.Instance.error(ex.Message);
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void ClearAll()
        {
            labelTime.Text = "[...]";
            labelNoInput.Text = "[...]";
            labelNoRecord.Text = "[...]";
            textBoxProvider.Text = "";
            textBoxObservation.Text = "";

            dataGridViewInputs.Rows.Clear();
        }

        private void EnableComponents()
        {
            buttonSave.Enabled = true;
            DateTimePicker.Enabled = true;
            textBoxObservation.Enabled = true;
            buttonSelect.Enabled = true;
            buttonClean.Enabled = true;

        }

        private void NoEnableComponents()
        {
            buttonSave.Enabled = false;
            textBoxObservation.Enabled = false;
            buttonSelect.Enabled = false;
            dataGridViewInputs.Enabled = false;
            buttonClean.Enabled = false;
            buttonNew.Enabled = true;
            DateTimePicker.Enabled = false;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DialogResult res = searchProviderForm.ShowDialog(); //abrimos el formulario 2 como cuadro de dialogo modal

            if (res == DialogResult.OK)
            {
                //recuperando la variable publica del formulario 2
                textBoxProvider.Text = searchProviderForm.nameprovider; //asignamos al texbox el dato de la variable
                codeProvider = searchProviderForm.codeProvider;
                dataGridViewInputs.Enabled=true;
            }
        }

        private void dataGridViewInputs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                string quantityArt = "";
                //bool band = false;
                if (dataGridViewInputs.RowCount == 1)
                {
                    quantityArt = "0";
                }
                if (dataGridViewInputs.RowCount > 1)
                {
                    if (dataGridViewInputs.CurrentCell.RowIndex == 0)
                    {
                        quantityArt = Convert.ToString(dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex].Value);
                    }
                    else
                    {
                        quantityArt = Convert.ToString(dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex - 1].Value);
                    }
                }
                if (quantityArt != "")
                {
                    DialogResult res = searchArticle.ShowDialog(); //abrimos el formulario 2 como cuadro de dialogo modal

                    if (res == DialogResult.OK)
                    {
                        //recuperando la variable publica del formulario 2
                        //string codeControl = Convert.ToString(dataGridViewInputs[1, dataGridViewInputs.CurrentCell.RowIndex].Value);
                        
                            dataGridViewInputs[0, dataGridViewInputs.CurrentCell.RowIndex].Value = searchArticle.codeArticle;
                            dataGridViewInputs[2, dataGridViewInputs.CurrentCell.RowIndex].Value = searchArticle.descriptionArticle;
                            dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex].Value = searchArticle.measureunitArticle;
                            if (dataGridViewInputs.CurrentCell.RowIndex == 0)
                            {
                                this.dataGridViewInputs.CurrentCell = this.dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex];
                            }
                            else
                            {
                                this.dataGridViewInputs.CurrentCell = this.dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex - 1];
                            }
                        
                    }
                }
                else
                {
                    if (dataGridViewInputs.CurrentCell.RowIndex == 0)
                    {
                        this.dataGridViewInputs.CurrentCell = this.dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex];
                    }
                    else
                    {
                        this.dataGridViewInputs.CurrentCell = this.dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex - 1];
                        MessageBox.Show("debe introducir la Cantidad  para añadir un nuevo Valor");
                    }

                }
            }
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridViewInputs_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string descriptionArticle = Convert.ToString(dataGridViewInputs[2, dataGridViewInputs.CurrentCell.RowIndex].Value);
                if (descriptionArticle.Equals(""))
                {
                    MessageBox.Show("debe introducir el Producto");
                    this.dataGridViewInputs.CurrentCell = this.dataGridViewInputs[1, dataGridViewInputs.CurrentCell.RowIndex];
                    dataGridViewInputs.EndEdit();
                }

            }
            
        }

        private void dataGridViewInputs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string descriptionArticle = Convert.ToString(dataGridViewInputs[2, dataGridViewInputs.CurrentCell.RowIndex].Value);
            if (e.ColumnIndex == 3)
            {
                
                string quantityInputs = "";
                quantityInputs = Convert.ToString(dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex].Value);
                dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex].Value = quantityInputs.Replace(".", ",");
            }
        }

        private void dataGridViewInputs_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewInputs.CurrentCell.ColumnIndex == 3)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridViewInputs_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridViewInputs_KeyPress);
                    //txt.KeyPress -= new Kewpre(dataGridViewInputs_KeyDown);
                    //txt.KeyPress += new KeyPressEventHandler(dataGridViewInputs_KeyDown); 
                }
            }
        }

        private void dataGridViewInputs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridViewInputs.CurrentCell.ColumnIndex == 3)
            {
                if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 13 || e.KeyChar == 8 || e.KeyChar == 44 || e.KeyChar == 46 || e.KeyChar == 9)
                {

                    e.Handled = false;
                }
                else
                {
                    MessageBox.Show("Solo se permiten Numeros");
                    e.Handled = true;
                }

            }
        }

        private void dataGridViewInputs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.dataGridViewInputs.CurrentCell = this.dataGridViewInputs[3, dataGridViewInputs.CurrentCell.RowIndex];
            }
        }

        private void dataGridViewInputs_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewInputs.Enabled == false)
            {
                MessageBox.Show("Debe introducir al proveedor");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DateTime datenow = Convert.ToDateTime(this.DateTimePicker.Text);
            List<EInput> inputs = inputLogic.GetLastDateInput();
            if (inputs.Count > 0)
            {
                DateTime datelast = inputs[inputs.Count - 1].date;
                if (datenow >= datelast)
                {

                    if (dataGridViewInputs.RowCount > 1)
                    {
                        if (MessageBox.Show("Esta seguro que quiere guardar la entrada de Materiales", "Guardar Registro de Entrada", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SaveInputs();
                            NoEnableComponents();
                            buttonPrint.Enabled = true;

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se tiene ningun Producto Agregado");
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de Entrada debe ser mayor o igual al ultimo registro");
                }
            }
            else
            {
                if (dataGridViewInputs.RowCount > 1)
                {
                    SaveInputs();
                    NoEnableComponents();
                    buttonPrint.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se tiene ningun Producto Agregado");
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            InputPrintForm inputPrint = new InputPrintForm(this.inputNumber, this.valueLiteral);
            inputPrint.ShowDialog();
            ClearAll();
            buttonNew.Enabled = true;
        }
    }
}
