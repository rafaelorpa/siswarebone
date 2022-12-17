namespace com.sisware.gui.form
{
    partial class SearchProviderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchProviderForm));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.dataGridViewProvider = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxSearch = new Bunifu.UI.WinForms.BunifuTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAccept = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.buttonCancel = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProvider
            // 
            this.dataGridViewProvider.AllowUserToAddRows = false;
            this.dataGridViewProvider.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewProvider.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProvider.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProvider.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dataGridViewProvider.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProvider.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewProvider.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProvider.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProvider.ColumnHeadersHeight = 40;
            this.dataGridViewProvider.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnNit,
            this.ColumnName,
            this.ColumnCategory,
            this.ColumnAddress,
            this.ColumnCity});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProvider.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewProvider.EnableHeadersVisualStyles = false;
            this.dataGridViewProvider.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dataGridViewProvider.Location = new System.Drawing.Point(13, 51);
            this.dataGridViewProvider.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewProvider.Name = "dataGridViewProvider";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProvider.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewProvider.RowHeadersVisible = false;
            this.dataGridViewProvider.RowHeadersWidth = 51;
            this.dataGridViewProvider.RowTemplate.DividerHeight = 5;
            this.dataGridViewProvider.RowTemplate.Height = 40;
            this.dataGridViewProvider.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProvider.Size = new System.Drawing.Size(834, 478);
            this.dataGridViewProvider.TabIndex = 59;
            this.dataGridViewProvider.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dataGridViewProvider.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewProvider.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewProvider.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewProvider.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewProvider.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewProvider.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dataGridViewProvider.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dataGridViewProvider.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dataGridViewProvider.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewProvider.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dataGridViewProvider.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewProvider.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewProvider.ThemeStyle.HeaderStyle.Height = 40;
            this.dataGridViewProvider.ThemeStyle.ReadOnly = false;
            this.dataGridViewProvider.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewProvider.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewProvider.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dataGridViewProvider.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewProvider.ThemeStyle.RowsStyle.Height = 40;
            this.dataGridViewProvider.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dataGridViewProvider.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.FillWeight = 40.60914F;
            this.ColumnId.HeaderText = "ID";
            this.ColumnId.MinimumWidth = 6;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            this.ColumnId.Width = 10;
            // 
            // ColumnNit
            // 
            this.ColumnNit.FillWeight = 99.49239F;
            this.ColumnNit.HeaderText = "NIT";
            this.ColumnNit.MinimumWidth = 6;
            this.ColumnNit.Name = "ColumnNit";
            // 
            // ColumnName
            // 
            this.ColumnName.FillWeight = 99.49239F;
            this.ColumnName.HeaderText = "Nombre";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.HeaderText = "Categoria";
            this.ColumnCategory.MinimumWidth = 6;
            this.ColumnCategory.Name = "ColumnCategory";
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.HeaderText = "Direccion";
            this.ColumnAddress.MinimumWidth = 6;
            this.ColumnAddress.Name = "ColumnAddress";
            // 
            // ColumnCity
            // 
            this.ColumnCity.HeaderText = "Ciudad";
            this.ColumnCity.MinimumWidth = 6;
            this.ColumnCity.Name = "ColumnCity";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.AcceptsReturn = false;
            this.textBoxSearch.AcceptsTab = false;
            this.textBoxSearch.AnimationSpeed = 200;
            this.textBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textBoxSearch.AutoSizeHeight = true;
            this.textBoxSearch.BackColor = System.Drawing.Color.Transparent;
            this.textBoxSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textBoxSearch.BackgroundImage")));
            this.textBoxSearch.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.textBoxSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.textBoxSearch.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.textBoxSearch.BorderColorIdle = System.Drawing.Color.Silver;
            this.textBoxSearch.BorderRadius = 10;
            this.textBoxSearch.BorderThickness = 1;
            this.textBoxSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSearch.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.textBoxSearch.DefaultText = "";
            this.textBoxSearch.FillColor = System.Drawing.Color.White;
            this.textBoxSearch.HideSelection = true;
            this.textBoxSearch.IconLeft = null;
            this.textBoxSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSearch.IconPadding = 10;
            this.textBoxSearch.IconRight = null;
            this.textBoxSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSearch.Lines = new string[0];
            this.textBoxSearch.Location = new System.Drawing.Point(429, 12);
            this.textBoxSearch.MaxLength = 32767;
            this.textBoxSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.textBoxSearch.Modified = false;
            this.textBoxSearch.Multiline = false;
            this.textBoxSearch.Name = "textBoxSearch";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.textBoxSearch.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.textBoxSearch.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.textBoxSearch.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.textBoxSearch.OnIdleState = stateProperties4;
            this.textBoxSearch.Padding = new System.Windows.Forms.Padding(3);
            this.textBoxSearch.PasswordChar = '\0';
            this.textBoxSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.textBoxSearch.PlaceholderText = "Buscar por nombre de Proveedor";
            this.textBoxSearch.ReadOnly = false;
            this.textBoxSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxSearch.SelectedText = "";
            this.textBoxSearch.SelectionLength = 0;
            this.textBoxSearch.SelectionStart = 0;
            this.textBoxSearch.ShortcutsEnabled = true;
            this.textBoxSearch.Size = new System.Drawing.Size(418, 32);
            this.textBoxSearch.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.textBoxSearch.TabIndex = 58;
            this.textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxSearch.TextMarginBottom = 0;
            this.textBoxSearch.TextMarginLeft = 3;
            this.textBoxSearch.TextMarginTop = 1;
            this.textBoxSearch.TextPlaceholder = "Buscar por nombre de Proveedor";
            this.textBoxSearch.UseSystemPasswordChar = false;
            this.textBoxSearch.WordWrap = true;
            this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(363, 21);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 57;
            this.label9.Text = "Buscar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "Lista de Proveedores:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.AllowAnimations = true;
            this.buttonAccept.AllowMouseEffects = true;
            this.buttonAccept.AllowToggling = false;
            this.buttonAccept.AnimationSpeed = 200;
            this.buttonAccept.AutoGenerateColors = false;
            this.buttonAccept.AutoRoundBorders = false;
            this.buttonAccept.AutoSizeLeftIcon = true;
            this.buttonAccept.AutoSizeRightIcon = true;
            this.buttonAccept.BackColor = System.Drawing.Color.Transparent;
            this.buttonAccept.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.buttonAccept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAccept.BackgroundImage")));
            this.buttonAccept.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonAccept.ButtonText = "Aceptar";
            this.buttonAccept.ButtonTextMarginLeft = 0;
            this.buttonAccept.ColorContrastOnClick = 45;
            this.buttonAccept.ColorContrastOnHover = 45;
            this.buttonAccept.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.buttonAccept.CustomizableEdges = borderEdges1;
            this.buttonAccept.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonAccept.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonAccept.DisabledFillColor = System.Drawing.Color.Empty;
            this.buttonAccept.DisabledForecolor = System.Drawing.Color.Empty;
            this.buttonAccept.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.buttonAccept.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccept.ForeColor = System.Drawing.Color.White;
            this.buttonAccept.IconLeft = global::SISWARE.Properties.Resources.Clear;
            this.buttonAccept.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAccept.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.buttonAccept.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.buttonAccept.IconMarginLeft = 11;
            this.buttonAccept.IconPadding = 10;
            this.buttonAccept.IconRight = null;
            this.buttonAccept.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAccept.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.buttonAccept.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.buttonAccept.IconSize = 25;
            this.buttonAccept.IdleBorderColor = System.Drawing.Color.Empty;
            this.buttonAccept.IdleBorderRadius = 0;
            this.buttonAccept.IdleBorderThickness = 0;
            this.buttonAccept.IdleFillColor = System.Drawing.Color.Empty;
            this.buttonAccept.IdleIconLeftImage = global::SISWARE.Properties.Resources.Clear;
            this.buttonAccept.IdleIconRightImage = null;
            this.buttonAccept.IndicateFocus = false;
            this.buttonAccept.Location = new System.Drawing.Point(13, 536);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonAccept.OnDisabledState.BorderRadius = 1;
            this.buttonAccept.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonAccept.OnDisabledState.BorderThickness = 1;
            this.buttonAccept.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonAccept.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.buttonAccept.OnDisabledState.IconLeftImage = null;
            this.buttonAccept.OnDisabledState.IconRightImage = null;
            this.buttonAccept.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(153)))), ((int)(((byte)(183)))));
            this.buttonAccept.onHoverState.BorderRadius = 1;
            this.buttonAccept.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonAccept.onHoverState.BorderThickness = 1;
            this.buttonAccept.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.buttonAccept.onHoverState.ForeColor = System.Drawing.Color.White;
            this.buttonAccept.onHoverState.IconLeftImage = null;
            this.buttonAccept.onHoverState.IconRightImage = null;
            this.buttonAccept.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(153)))), ((int)(((byte)(183)))));
            this.buttonAccept.OnIdleState.BorderRadius = 1;
            this.buttonAccept.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonAccept.OnIdleState.BorderThickness = 1;
            this.buttonAccept.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(157)))), ((int)(((byte)(184)))));
            this.buttonAccept.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.buttonAccept.OnIdleState.IconLeftImage = global::SISWARE.Properties.Resources.Clear;
            this.buttonAccept.OnIdleState.IconRightImage = null;
            this.buttonAccept.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.buttonAccept.OnPressedState.BorderRadius = 1;
            this.buttonAccept.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonAccept.OnPressedState.BorderThickness = 1;
            this.buttonAccept.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.buttonAccept.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.buttonAccept.OnPressedState.IconLeftImage = null;
            this.buttonAccept.OnPressedState.IconRightImage = null;
            this.buttonAccept.Size = new System.Drawing.Size(120, 38);
            this.buttonAccept.TabIndex = 61;
            this.buttonAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonAccept.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonAccept.TextMarginLeft = 0;
            this.buttonAccept.TextPadding = new System.Windows.Forms.Padding(0);
            this.buttonAccept.UseDefaultRadiusAndThickness = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AllowAnimations = true;
            this.buttonCancel.AllowMouseEffects = true;
            this.buttonCancel.AllowToggling = false;
            this.buttonCancel.AnimationSpeed = 200;
            this.buttonCancel.AutoGenerateColors = false;
            this.buttonCancel.AutoRoundBorders = false;
            this.buttonCancel.AutoSizeLeftIcon = true;
            this.buttonCancel.AutoSizeRightIcon = true;
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.buttonCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancel.BackgroundImage")));
            this.buttonCancel.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonCancel.ButtonText = "Cancelar";
            this.buttonCancel.ButtonTextMarginLeft = 0;
            this.buttonCancel.ColorContrastOnClick = 45;
            this.buttonCancel.ColorContrastOnHover = 45;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.buttonCancel.CustomizableEdges = borderEdges2;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonCancel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonCancel.DisabledFillColor = System.Drawing.Color.Empty;
            this.buttonCancel.DisabledForecolor = System.Drawing.Color.Empty;
            this.buttonCancel.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.buttonCancel.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.IconLeft = global::SISWARE.Properties.Resources.cancel;
            this.buttonCancel.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.buttonCancel.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.buttonCancel.IconMarginLeft = 11;
            this.buttonCancel.IconPadding = 10;
            this.buttonCancel.IconRight = null;
            this.buttonCancel.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.buttonCancel.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.buttonCancel.IconSize = 25;
            this.buttonCancel.IdleBorderColor = System.Drawing.Color.Empty;
            this.buttonCancel.IdleBorderRadius = 0;
            this.buttonCancel.IdleBorderThickness = 0;
            this.buttonCancel.IdleFillColor = System.Drawing.Color.Empty;
            this.buttonCancel.IdleIconLeftImage = global::SISWARE.Properties.Resources.cancel;
            this.buttonCancel.IdleIconRightImage = null;
            this.buttonCancel.IndicateFocus = false;
            this.buttonCancel.Location = new System.Drawing.Point(722, 536);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonCancel.OnDisabledState.BorderRadius = 1;
            this.buttonCancel.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonCancel.OnDisabledState.BorderThickness = 1;
            this.buttonCancel.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonCancel.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.buttonCancel.OnDisabledState.IconLeftImage = null;
            this.buttonCancel.OnDisabledState.IconRightImage = null;
            this.buttonCancel.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(153)))), ((int)(((byte)(183)))));
            this.buttonCancel.onHoverState.BorderRadius = 1;
            this.buttonCancel.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonCancel.onHoverState.BorderThickness = 1;
            this.buttonCancel.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.buttonCancel.onHoverState.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.onHoverState.IconLeftImage = null;
            this.buttonCancel.onHoverState.IconRightImage = null;
            this.buttonCancel.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(153)))), ((int)(((byte)(183)))));
            this.buttonCancel.OnIdleState.BorderRadius = 1;
            this.buttonCancel.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonCancel.OnIdleState.BorderThickness = 1;
            this.buttonCancel.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(157)))), ((int)(((byte)(184)))));
            this.buttonCancel.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.OnIdleState.IconLeftImage = global::SISWARE.Properties.Resources.cancel;
            this.buttonCancel.OnIdleState.IconRightImage = null;
            this.buttonCancel.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.buttonCancel.OnPressedState.BorderRadius = 1;
            this.buttonCancel.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonCancel.OnPressedState.BorderThickness = 1;
            this.buttonCancel.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.buttonCancel.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.OnPressedState.IconLeftImage = null;
            this.buttonCancel.OnPressedState.IconRightImage = null;
            this.buttonCancel.Size = new System.Drawing.Size(120, 38);
            this.buttonCancel.TabIndex = 60;
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCancel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonCancel.TextMarginLeft = 0;
            this.buttonCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.buttonCancel.UseDefaultRadiusAndThickness = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SearchProviderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 579);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.dataGridViewProvider);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Name = "SearchProviderForm";
            this.Text = "SearchProviderForm";
            this.Load += new System.EventHandler(this.SearchProviderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewProvider;
        private Bunifu.UI.WinForms.BunifuTextBox textBoxSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCity;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton buttonAccept;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton buttonCancel;
    }
}