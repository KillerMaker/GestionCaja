namespace GestionCaja
{
    partial class FrmEstudiante
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCarrera = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.mtxtFechaIngreso = new System.Windows.Forms.MaskedTextBox();
            this.mtxtCedula = new System.Windows.Forms.MaskedTextBox();
            this.mtxtFechaNac = new System.Windows.Forms.MaskedTextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblcarrera = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.cmbCampo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnActualizar2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estudiantesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeDocumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeServiciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDePagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modalidadesDePagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsername = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbCarrera);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.btnInsertar);
            this.groupBox1.Controls.Add(this.cmbGenero);
            this.groupBox1.Controls.Add(this.mtxtFechaIngreso);
            this.groupBox1.Controls.Add(this.mtxtCedula);
            this.groupBox1.Controls.Add(this.mtxtFechaNac);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblcarrera);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 454);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insercion de Datos del estudiante";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(327, 372);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(274, 281);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(136, 21);
            this.cmbEstado.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Estado";
            // 
            // cmbCarrera
            // 
            this.cmbCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarrera.FormattingEnabled = true;
            this.cmbCarrera.Items.AddRange(new object[] {
            "ISO",
            "INF",
            "INE",
            "IEL",
            "IND",
            "ADM",
            "ATH",
            "CDG",
            "CON",
            "DER",
            "DIN",
            "DIG",
            "FIN",
            "LES",
            "LIE",
            "LMS",
            "MER",
            "NIN",
            "PUB",
            "TAF"});
            this.cmbCarrera.Location = new System.Drawing.Point(362, 191);
            this.cmbCarrera.Name = "cmbCarrera";
            this.cmbCarrera.Size = new System.Drawing.Size(48, 21);
            this.cmbCarrera.TabIndex = 16;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new System.Drawing.Point(226, 372);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 15;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(120, 372);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 14;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cmbGenero.Location = new System.Drawing.Point(371, 111);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(39, 21);
            this.cmbGenero.TabIndex = 13;
            // 
            // mtxtFechaIngreso
            // 
            this.mtxtFechaIngreso.Location = new System.Drawing.Point(327, 235);
            this.mtxtFechaIngreso.Mask = "00/00/0000";
            this.mtxtFechaIngreso.Name = "mtxtFechaIngreso";
            this.mtxtFechaIngreso.Size = new System.Drawing.Size(83, 20);
            this.mtxtFechaIngreso.TabIndex = 12;
            this.mtxtFechaIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtFechaIngreso.ValidatingType = typeof(System.DateTime);
            // 
            // mtxtCedula
            // 
            this.mtxtCedula.Location = new System.Drawing.Point(327, 145);
            this.mtxtCedula.Mask = "000-0000000-0";
            this.mtxtCedula.Name = "mtxtCedula";
            this.mtxtCedula.Size = new System.Drawing.Size(83, 20);
            this.mtxtCedula.TabIndex = 10;
            this.mtxtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mtxtFechaNac
            // 
            this.mtxtFechaNac.Location = new System.Drawing.Point(327, 72);
            this.mtxtFechaNac.Mask = "00/00/0000";
            this.mtxtFechaNac.Name = "mtxtFechaNac";
            this.mtxtFechaNac.Size = new System.Drawing.Size(83, 20);
            this.mtxtFechaNac.TabIndex = 9;
            this.mtxtFechaNac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtFechaNac.ValidatingType = typeof(System.DateTime);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(149, 34);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(261, 20);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Fecha de ingreso";
            // 
            // lblcarrera
            // 
            this.lblcarrera.AutoSize = true;
            this.lblcarrera.Location = new System.Drawing.Point(7, 191);
            this.lblcarrera.Name = "lblcarrera";
            this.lblcarrera.Size = new System.Drawing.Size(41, 13);
            this.lblcarrera.TabIndex = 3;
            this.lblcarrera.Text = "Carrera";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cedula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Genero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de nacimiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtValor);
            this.groupBox2.Controls.Add(this.cmbCriterio);
            this.groupBox2.Controls.Add(this.cmbCampo);
            this.groupBox2.Location = new System.Drawing.Point(460, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 57);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barra de bisqueda";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(580, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(338, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Valor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(196, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Criterio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Campo";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(375, 25);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(185, 20);
            this.txtValor.TabIndex = 2;
            // 
            // cmbCriterio
            // 
            this.cmbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Items.AddRange(new object[] {
            "=",
            "!=",
            "<",
            ">",
            "<=",
            ">="});
            this.cmbCriterio.Location = new System.Drawing.Point(241, 25);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(75, 21);
            this.cmbCriterio.TabIndex = 1;
            // 
            // cmbCampo
            // 
            this.cmbCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCampo.FormattingEnabled = true;
            this.cmbCampo.Items.AddRange(new object[] {
            "IDENTIFICADOR",
            "NOMBRE",
            "FECHA_INGRESO",
            "FECHA_NACIMIENTO",
            "MATRICULA",
            "CARRERA",
            "GENERO",
            "ESTADO",
            "CEDULA",
            "TIPO_CLIENTE"});
            this.cmbCampo.Location = new System.Drawing.Point(52, 25);
            this.cmbCampo.Name = "cmbCampo";
            this.cmbCampo.Size = new System.Drawing.Size(123, 21);
            this.cmbCampo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExportar);
            this.groupBox3.Controls.Add(this.btnActualizar2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(460, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(676, 382);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tabla de datos";
            // 
            // btnActualizar2
            // 
            this.btnActualizar2.Location = new System.Drawing.Point(341, 337);
            this.btnActualizar2.Name = "btnActualizar2";
            this.btnActualizar2.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar2.TabIndex = 2;
            this.btnActualizar2.Text = "Actualizar";
            this.btnActualizar2.UseVisualStyleBackColor = true;
            this.btnActualizar2.Click += new System.EventHandler(this.btnActualizar2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(237, 337);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(664, 301);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.administracionToolStripMenuItem,
            this.mantenimientoToolStripMenuItem,
            this.ajustesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1163, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click_1);
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estudiantesToolStripMenuItem1,
            this.empleadoToolStripMenuItem1});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administracionToolStripMenuItem.Text = "Administracion";
            // 
            // estudiantesToolStripMenuItem1
            // 
            this.estudiantesToolStripMenuItem1.Name = "estudiantesToolStripMenuItem1";
            this.estudiantesToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.estudiantesToolStripMenuItem1.Text = "Estudiantes";
            this.estudiantesToolStripMenuItem1.Click += new System.EventHandler(this.estudiantesToolStripMenuItem1_Click_1);
            // 
            // empleadoToolStripMenuItem1
            // 
            this.empleadoToolStripMenuItem1.Name = "empleadoToolStripMenuItem1";
            this.empleadoToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.empleadoToolStripMenuItem1.Text = "Empleado";
            this.empleadoToolStripMenuItem1.Click += new System.EventHandler(this.empleadoToolStripMenuItem1_Click_1);
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposDeDocumentosToolStripMenuItem,
            this.tiposDeServiciosToolStripMenuItem,
            this.tiposDePagosToolStripMenuItem,
            this.modalidadesDePagosToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // tiposDeDocumentosToolStripMenuItem
            // 
            this.tiposDeDocumentosToolStripMenuItem.Name = "tiposDeDocumentosToolStripMenuItem";
            this.tiposDeDocumentosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.tiposDeDocumentosToolStripMenuItem.Text = "Tipos de Documentos";
            this.tiposDeDocumentosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeDocumentosToolStripMenuItem_Click_1);
            // 
            // tiposDeServiciosToolStripMenuItem
            // 
            this.tiposDeServiciosToolStripMenuItem.Name = "tiposDeServiciosToolStripMenuItem";
            this.tiposDeServiciosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.tiposDeServiciosToolStripMenuItem.Text = "Tipos de Servicios";
            this.tiposDeServiciosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeServiciosToolStripMenuItem_Click_1);
            // 
            // tiposDePagosToolStripMenuItem
            // 
            this.tiposDePagosToolStripMenuItem.Name = "tiposDePagosToolStripMenuItem";
            this.tiposDePagosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.tiposDePagosToolStripMenuItem.Text = "Tipos de Pagos";
            this.tiposDePagosToolStripMenuItem.Click += new System.EventHandler(this.tiposDePagosToolStripMenuItem_Click_1);
            // 
            // modalidadesDePagosToolStripMenuItem
            // 
            this.modalidadesDePagosToolStripMenuItem.Name = "modalidadesDePagosToolStripMenuItem";
            this.modalidadesDePagosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.modalidadesDePagosToolStripMenuItem.Text = "Modalidades de Pagos";
            this.modalidadesDePagosToolStripMenuItem.Click += new System.EventHandler(this.modalidadesDePagosToolStripMenuItem_Click);
            // 
            // ajustesToolStripMenuItem
            // 
            this.ajustesToolStripMenuItem.Name = "ajustesToolStripMenuItem";
            this.ajustesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.ajustesToolStripMenuItem.Text = "Ajustes";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(1011, 11);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Username";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1081, 11);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(70, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cerrar Sesion";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(451, 337);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 9;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // FrmEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 561);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmEstudiante";
            this.Text = "FrmEstudiante";
            this.Load += new System.EventHandler(this.FrmEstudiante_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.MaskedTextBox mtxtFechaIngreso;
        private System.Windows.Forms.MaskedTextBox mtxtCedula;
        private System.Windows.Forms.MaskedTextBox mtxtFechaNac;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblcarrera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.ComboBox cmbCampo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnActualizar2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbCarrera;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estudiantesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem empleadoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeDocumentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeServiciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDePagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajustesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripMenuItem modalidadesDePagosToolStripMenuItem;
        private System.Windows.Forms.Button btnExportar;
    }
}