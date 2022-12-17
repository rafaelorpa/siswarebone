namespace com.sisware.gui.form
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.label1 = new System.Windows.Forms.Label();
            this.GPanelDatos = new Guna.UI.WinForms.GunaPanel();
            this.ComboBoxLevel = new Guna.UI.WinForms.GunaComboBox();
            this.GButtonSave = new Guna.UI.WinForms.GunaButton();
            this.labelDate = new System.Windows.Forms.Label();
            this.GButtonClear = new Guna.UI.WinForms.GunaButton();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxCI = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTrace = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxPasswordRepit = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxNames = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GButtonErase = new Guna.UI.WinForms.GunaButton();
            this.GButtonEdit = new Guna.UI.WinForms.GunaButton();
            this.GButtonNew = new Guna.UI.WinForms.GunaButton();
            this.dataGridViewUsers = new Guna.UI.WinForms.GunaDataGridView();
            this.Columid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumCI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columfirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columlastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columpassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumTrace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columrole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPanelDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Lista de Usuarios:";
            // 
            // GPanelDatos
            // 
            this.GPanelDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.GPanelDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GPanelDatos.Controls.Add(this.ComboBoxLevel);
            this.GPanelDatos.Controls.Add(this.GButtonSave);
            this.GPanelDatos.Controls.Add(this.labelDate);
            this.GPanelDatos.Controls.Add(this.GButtonClear);
            this.GPanelDatos.Controls.Add(this.textBoxLastName);
            this.GPanelDatos.Controls.Add(this.label12);
            this.GPanelDatos.Controls.Add(this.textBoxCI);
            this.GPanelDatos.Controls.Add(this.label11);
            this.GPanelDatos.Controls.Add(this.label10);
            this.GPanelDatos.Controls.Add(this.textBoxUser);
            this.GPanelDatos.Controls.Add(this.label9);
            this.GPanelDatos.Controls.Add(this.textBoxTrace);
            this.GPanelDatos.Controls.Add(this.textBoxFirstName);
            this.GPanelDatos.Controls.Add(this.textBoxPasswordRepit);
            this.GPanelDatos.Controls.Add(this.textBoxPassword);
            this.GPanelDatos.Controls.Add(this.textBoxNames);
            this.GPanelDatos.Controls.Add(this.label8);
            this.GPanelDatos.Controls.Add(this.label7);
            this.GPanelDatos.Controls.Add(this.label6);
            this.GPanelDatos.Controls.Add(this.label5);
            this.GPanelDatos.Controls.Add(this.label3);
            this.GPanelDatos.Controls.Add(this.label2);
            this.GPanelDatos.Enabled = false;
            this.GPanelDatos.Location = new System.Drawing.Point(12, 394);
            this.GPanelDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GPanelDatos.Name = "GPanelDatos";
            this.GPanelDatos.Size = new System.Drawing.Size(971, 251);
            this.GPanelDatos.TabIndex = 16;
            this.GPanelDatos.Visible = false;
            // 
            // ComboBoxLevel
            // 
            this.ComboBoxLevel.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxLevel.BaseColor = System.Drawing.Color.White;
            this.ComboBoxLevel.BorderColor = System.Drawing.Color.Silver;
            this.ComboBoxLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxLevel.FocusedColor = System.Drawing.Color.Empty;
            this.ComboBoxLevel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboBoxLevel.ForeColor = System.Drawing.Color.Black;
            this.ComboBoxLevel.FormattingEnabled = true;
            this.ComboBoxLevel.Items.AddRange(new object[] {
            "Administrador",
            "Usuario",
            "Invitado"});
            this.ComboBoxLevel.Location = new System.Drawing.Point(12, 161);
            this.ComboBoxLevel.Name = "ComboBoxLevel";
            this.ComboBoxLevel.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ComboBoxLevel.OnHoverItemForeColor = System.Drawing.Color.White;
            this.ComboBoxLevel.Size = new System.Drawing.Size(217, 31);
            this.ComboBoxLevel.TabIndex = 43;
            // 
            // GButtonSave
            // 
            this.GButtonSave.AnimationHoverSpeed = 0.07F;
            this.GButtonSave.AnimationSpeed = 0.03F;
            this.GButtonSave.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(176)))), ((int)(((byte)(197)))));
            this.GButtonSave.BorderColor = System.Drawing.Color.Black;
            this.GButtonSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.GButtonSave.FocusedColor = System.Drawing.Color.Empty;
            this.GButtonSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GButtonSave.ForeColor = System.Drawing.Color.White;
            this.GButtonSave.Image = global::SISWARE.Properties.Resources.user_check1;
            this.GButtonSave.ImageSize = new System.Drawing.Size(20, 20);
            this.GButtonSave.Location = new System.Drawing.Point(12, 197);
            this.GButtonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GButtonSave.Name = "GButtonSave";
            this.GButtonSave.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.GButtonSave.OnHoverBorderColor = System.Drawing.Color.Black;
            this.GButtonSave.OnHoverForeColor = System.Drawing.Color.White;
            this.GButtonSave.OnHoverImage = null;
            this.GButtonSave.OnPressedColor = System.Drawing.Color.Black;
            this.GButtonSave.Size = new System.Drawing.Size(113, 39);
            this.GButtonSave.TabIndex = 22;
            this.GButtonSave.Text = "Agregar";
            this.GButtonSave.Click += new System.EventHandler(this.GButtonSave_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(599, 29);
            this.labelDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(24, 16);
            this.labelDate.TabIndex = 42;
            this.labelDate.Text = "[...]";
            // 
            // GButtonClear
            // 
            this.GButtonClear.AnimationHoverSpeed = 0.07F;
            this.GButtonClear.AnimationSpeed = 0.03F;
            this.GButtonClear.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(176)))), ((int)(((byte)(197)))));
            this.GButtonClear.BorderColor = System.Drawing.Color.Black;
            this.GButtonClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.GButtonClear.FocusedColor = System.Drawing.Color.Empty;
            this.GButtonClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GButtonClear.ForeColor = System.Drawing.Color.White;
            this.GButtonClear.Image = global::SISWARE.Properties.Resources.Clear;
            this.GButtonClear.ImageSize = new System.Drawing.Size(20, 20);
            this.GButtonClear.Location = new System.Drawing.Point(131, 197);
            this.GButtonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GButtonClear.Name = "GButtonClear";
            this.GButtonClear.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.GButtonClear.OnHoverBorderColor = System.Drawing.Color.Black;
            this.GButtonClear.OnHoverForeColor = System.Drawing.Color.White;
            this.GButtonClear.OnHoverImage = null;
            this.GButtonClear.OnPressedColor = System.Drawing.Color.Black;
            this.GButtonClear.Size = new System.Drawing.Size(113, 39);
            this.GButtonClear.TabIndex = 21;
            this.GButtonClear.Text = "Limpiar";
            this.GButtonClear.Click += new System.EventHandler(this.GButtonClear_Click);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(302, 70);
            this.textBoxLastName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(291, 22);
            this.textBoxLastName.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 52);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 16);
            this.label12.TabIndex = 41;
            this.label12.Text = "Apellido Paterno:";
            // 
            // textBoxCI
            // 
            this.textBoxCI.Location = new System.Drawing.Point(302, 26);
            this.textBoxCI.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCI.Name = "textBoxCI";
            this.textBoxCI.Size = new System.Drawing.Size(183, 22);
            this.textBoxCI.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(302, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 16);
            this.label11.TabIndex = 40;
            this.label11.Text = "CI:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 16);
            this.label10.TabIndex = 39;
            this.label10.Text = "Usuario";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(14, 24);
            this.textBoxUser.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(175, 22);
            this.textBoxUser.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(598, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "Fecha:";
            // 
            // textBoxTrace
            // 
            this.textBoxTrace.Location = new System.Drawing.Point(602, 116);
            this.textBoxTrace.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTrace.Name = "textBoxTrace";
            this.textBoxTrace.Size = new System.Drawing.Size(165, 22);
            this.textBoxTrace.TabIndex = 36;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(14, 70);
            this.textBoxFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(279, 22);
            this.textBoxFirstName.TabIndex = 28;
            // 
            // textBoxPasswordRepit
            // 
            this.textBoxPasswordRepit.Location = new System.Drawing.Point(302, 116);
            this.textBoxPasswordRepit.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordRepit.Name = "textBoxPasswordRepit";
            this.textBoxPasswordRepit.PasswordChar = '*';
            this.textBoxPasswordRepit.Size = new System.Drawing.Size(207, 22);
            this.textBoxPasswordRepit.TabIndex = 35;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(14, 116);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(215, 22);
            this.textBoxPassword.TabIndex = 34;
            // 
            // textBoxNames
            // 
            this.textBoxNames.Location = new System.Drawing.Point(601, 70);
            this.textBoxNames.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNames.Name = "textBoxNames";
            this.textBoxNames.Size = new System.Drawing.Size(327, 22);
            this.textBoxNames.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(599, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "Indicio:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Repita Contraseña:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 96);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "Contraseña:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Permisos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Apellido Materno:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nombres:";
            // 
            // GButtonErase
            // 
            this.GButtonErase.AnimationHoverSpeed = 0.07F;
            this.GButtonErase.AnimationSpeed = 0.03F;
            this.GButtonErase.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(176)))), ((int)(((byte)(197)))));
            this.GButtonErase.BorderColor = System.Drawing.Color.Black;
            this.GButtonErase.DialogResult = System.Windows.Forms.DialogResult.None;
            this.GButtonErase.FocusedColor = System.Drawing.Color.Empty;
            this.GButtonErase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GButtonErase.ForeColor = System.Drawing.Color.White;
            this.GButtonErase.Image = global::SISWARE.Properties.Resources.user_xmark_solid;
            this.GButtonErase.ImageSize = new System.Drawing.Size(20, 20);
            this.GButtonErase.Location = new System.Drawing.Point(253, 351);
            this.GButtonErase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GButtonErase.Name = "GButtonErase";
            this.GButtonErase.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.GButtonErase.OnHoverBorderColor = System.Drawing.Color.Black;
            this.GButtonErase.OnHoverForeColor = System.Drawing.Color.White;
            this.GButtonErase.OnHoverImage = null;
            this.GButtonErase.OnPressedColor = System.Drawing.Color.Black;
            this.GButtonErase.Size = new System.Drawing.Size(113, 39);
            this.GButtonErase.TabIndex = 19;
            this.GButtonErase.Text = "Eliminar";
            this.GButtonErase.Click += new System.EventHandler(this.GButtonErase_Click);
            // 
            // GButtonEdit
            // 
            this.GButtonEdit.AnimationHoverSpeed = 0.07F;
            this.GButtonEdit.AnimationSpeed = 0.03F;
            this.GButtonEdit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(176)))), ((int)(((byte)(197)))));
            this.GButtonEdit.BorderColor = System.Drawing.Color.Black;
            this.GButtonEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.GButtonEdit.FocusedColor = System.Drawing.Color.Empty;
            this.GButtonEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GButtonEdit.ForeColor = System.Drawing.Color.White;
            this.GButtonEdit.Image = global::SISWARE.Properties.Resources.user_edit;
            this.GButtonEdit.ImageSize = new System.Drawing.Size(20, 20);
            this.GButtonEdit.Location = new System.Drawing.Point(134, 351);
            this.GButtonEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GButtonEdit.Name = "GButtonEdit";
            this.GButtonEdit.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.GButtonEdit.OnHoverBorderColor = System.Drawing.Color.Black;
            this.GButtonEdit.OnHoverForeColor = System.Drawing.Color.White;
            this.GButtonEdit.OnHoverImage = null;
            this.GButtonEdit.OnPressedColor = System.Drawing.Color.Black;
            this.GButtonEdit.Size = new System.Drawing.Size(113, 39);
            this.GButtonEdit.TabIndex = 18;
            this.GButtonEdit.Text = "Editar";
            this.GButtonEdit.Click += new System.EventHandler(this.GButtonEdit_Click);
            // 
            // GButtonNew
            // 
            this.GButtonNew.AnimationHoverSpeed = 0.07F;
            this.GButtonNew.AnimationSpeed = 0.03F;
            this.GButtonNew.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(176)))), ((int)(((byte)(197)))));
            this.GButtonNew.BorderColor = System.Drawing.Color.Black;
            this.GButtonNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.GButtonNew.FocusedColor = System.Drawing.Color.Empty;
            this.GButtonNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GButtonNew.ForeColor = System.Drawing.Color.White;
            this.GButtonNew.Image = global::SISWARE.Properties.Resources.user_new;
            this.GButtonNew.ImageSize = new System.Drawing.Size(20, 20);
            this.GButtonNew.Location = new System.Drawing.Point(12, 351);
            this.GButtonNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GButtonNew.Name = "GButtonNew";
            this.GButtonNew.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.GButtonNew.OnHoverBorderColor = System.Drawing.Color.Black;
            this.GButtonNew.OnHoverForeColor = System.Drawing.Color.White;
            this.GButtonNew.OnHoverImage = null;
            this.GButtonNew.OnPressedColor = System.Drawing.Color.Black;
            this.GButtonNew.Size = new System.Drawing.Size(113, 39);
            this.GButtonNew.TabIndex = 17;
            this.GButtonNew.Text = "Nuevo";
            this.GButtonNew.Click += new System.EventHandler(this.GButtonNew_Click);
            // 
            // dataGridViewUsers
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUsers.ColumnHeadersHeight = 52;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columid,
            this.ColumCI,
            this.Columfirstname,
            this.Columlastname,
            this.Columnames,
            this.Columuser,
            this.Columpassword,
            this.ColumTrace,
            this.Columdate,
            this.Columrole});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewUsers.EnableHeadersVisualStyles = false;
            this.dataGridViewUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridViewUsers.Location = new System.Drawing.Point(10, 28);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowHeadersVisible = false;
            this.dataGridViewUsers.RowHeadersWidth = 51;
            this.dataGridViewUsers.RowTemplate.Height = 24;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(973, 318);
            this.dataGridViewUsers.TabIndex = 21;
            this.dataGridViewUsers.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dataGridViewUsers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewUsers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewUsers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewUsers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridViewUsers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.dataGridViewUsers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewUsers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dataGridViewUsers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewUsers.ThemeStyle.HeaderStyle.Height = 52;
            this.dataGridViewUsers.ThemeStyle.ReadOnly = false;
            this.dataGridViewUsers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewUsers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewUsers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dataGridViewUsers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewUsers.ThemeStyle.RowsStyle.Height = 24;
            this.dataGridViewUsers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewUsers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Columid
            // 
            this.Columid.HeaderText = "ID";
            this.Columid.MinimumWidth = 6;
            this.Columid.Name = "Columid";
            this.Columid.Visible = false;
            // 
            // ColumCI
            // 
            this.ColumCI.HeaderText = "C.I.";
            this.ColumCI.MinimumWidth = 6;
            this.ColumCI.Name = "ColumCI";
            // 
            // Columfirstname
            // 
            this.Columfirstname.HeaderText = "Apellido Paterno";
            this.Columfirstname.MinimumWidth = 6;
            this.Columfirstname.Name = "Columfirstname";
            // 
            // Columlastname
            // 
            this.Columlastname.HeaderText = "Apellido Materno";
            this.Columlastname.MinimumWidth = 6;
            this.Columlastname.Name = "Columlastname";
            // 
            // Columnames
            // 
            this.Columnames.HeaderText = "Nombre(s)";
            this.Columnames.MinimumWidth = 6;
            this.Columnames.Name = "Columnames";
            // 
            // Columuser
            // 
            this.Columuser.HeaderText = "Usuario";
            this.Columuser.MinimumWidth = 6;
            this.Columuser.Name = "Columuser";
            // 
            // Columpassword
            // 
            this.Columpassword.HeaderText = "Password";
            this.Columpassword.MinimumWidth = 6;
            this.Columpassword.Name = "Columpassword";
            // 
            // ColumTrace
            // 
            this.ColumTrace.HeaderText = "Indicio";
            this.ColumTrace.MinimumWidth = 6;
            this.ColumTrace.Name = "ColumTrace";
            // 
            // Columdate
            // 
            this.Columdate.HeaderText = "Fecha";
            this.Columdate.MinimumWidth = 6;
            this.Columdate.Name = "Columdate";
            // 
            // Columrole
            // 
            this.Columrole.HeaderText = "Rol";
            this.Columrole.MinimumWidth = 6;
            this.Columrole.Name = "Columrole";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(994, 657);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.GButtonErase);
            this.Controls.Add(this.GButtonEdit);
            this.Controls.Add(this.GButtonNew);
            this.Controls.Add(this.GPanelDatos);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1110, 868);
            this.MinimumSize = new System.Drawing.Size(900, 448);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.GPanelDatos.ResumeLayout(false);
            this.GPanelDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaPanel GPanelDatos;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxCI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTrace;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxPasswordRepit;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxNames;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaButton GButtonNew;
        private Guna.UI.WinForms.GunaButton GButtonEdit;
        private Guna.UI.WinForms.GunaButton GButtonErase;
        private Guna.UI.WinForms.GunaButton GButtonSave;
        private Guna.UI.WinForms.GunaButton GButtonClear;
        private Guna.UI.WinForms.GunaDataGridView dataGridViewUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumCI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columfirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columlastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columpassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumTrace;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columrole;
        private Guna.UI.WinForms.GunaComboBox ComboBoxLevel;
    }
}