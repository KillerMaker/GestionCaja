namespace GestionCaja
{
    partial class FrmTipoServicio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estudiantesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeDocumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeServiciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDePagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnActualizar2 = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCampo = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.rtxtDescripcion = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.modalidadesDePagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(959, 24);
            this.menuStrip1.TabIndex = 1;
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
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnActualizar2);
            this.groupBox3.Controls.Add(this.btnEliminar);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(383, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(561, 245);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos";
            // 
            // btnActualizar2
            // 
            this.btnActualizar2.Location = new System.Drawing.Point(325, 214);
            this.btnActualizar2.Name = "btnActualizar2";
            this.btnActualizar2.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar2.TabIndex = 2;
            this.btnActualizar2.Text = "Actualizar";
            this.btnActualizar2.UseVisualStyleBackColor = true;
            this.btnActualizar2.Click += new System.EventHandler(this.btnActualizar2_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(171, 214);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(549, 179);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtValor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbCriterio);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbCampo);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Location = new System.Drawing.Point(383, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 51);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barra de Busqueda";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(334, 19);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(133, 20);
            this.txtValor.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Valor";
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
            this.cmbCriterio.Location = new System.Drawing.Point(214, 19);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(62, 21);
            this.cmbCriterio.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Citerio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Campo";
            // 
            // cmbCampo
            // 
            this.cmbCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCampo.FormattingEnabled = true;
            this.cmbCampo.Items.AddRange(new object[] {
            "ID_TIPO_SERVICIO",
            "DESCRIPCION",
            "ESTADO"});
            this.cmbCampo.Location = new System.Drawing.Point(52, 19);
            this.cmbCampo.Name = "cmbCampo";
            this.cmbCampo.Size = new System.Drawing.Size(105, 21);
            this.cmbCampo.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(480, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.btnInsertar);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.rtxtDescripcion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 302);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Tipo de Servicio";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(268, 256);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(176, 256);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(85, 256);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 4;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(85, 192);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(258, 21);
            this.cmbEstado.TabIndex = 3;
            // 
            // rtxtDescripcion
            // 
            this.rtxtDescripcion.Location = new System.Drawing.Point(85, 32);
            this.rtxtDescripcion.Name = "rtxtDescripcion";
            this.rtxtDescripcion.Size = new System.Drawing.Size(258, 129);
            this.rtxtDescripcion.TabIndex = 2;
            this.rtxtDescripcion.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(807, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 9;
            this.lblUsername.Text = "Username";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(877, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(70, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cerrar Sesion";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // modalidadesDePagosToolStripMenuItem
            // 
            this.modalidadesDePagosToolStripMenuItem.Name = "modalidadesDePagosToolStripMenuItem";
            this.modalidadesDePagosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.modalidadesDePagosToolStripMenuItem.Text = "Modalidades de Pagos";
            this.modalidadesDePagosToolStripMenuItem.Click += new System.EventHandler(this.modalidadesDePagosToolStripMenuItem_Click);
            // 
            // FrmTipoServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 450);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmTipoServicio";
            this.Text = "FrmServicio";
            this.Load += new System.EventHandler(this.FrmTipoServicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnActualizar2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCampo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.RichTextBox rtxtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripMenuItem modalidadesDePagosToolStripMenuItem;
    }
}