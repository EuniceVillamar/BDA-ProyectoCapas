namespace CapaPresentacion
{
    partial class frmReparaciones
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvReparaciones = new DataGridView();
            btnActualizarEstado = new Button();
            btnEliminar = new Button();
            txtIdEquipo = new TextBox();
            cmbEstado = new ComboBox();
            lblIdEquipo = new Label();
            lblEstado = new Label();
            txtIdReparacion = new TextBox();
            lblIdReparacion = new Label();
            btnNuevo = new Button();
            btnGrabar = new Button();
            lblID = new Label();
            txtIdCliente = new TextBox();
            txtCosto = new TextBox();
            lblCosto = new Label();
            lblNovedad = new Label();
            txtFecha_entrega = new TextBox();
            txtFecha_ingreso = new TextBox();
            lblFecha_ingreso = new Label();
            lblFecha_ingreso2 = new Label();
            txtCedulaCliente = new TextBox();
            lblCedulaCliente = new Label();
            txtImeiCelular = new TextBox();
            lblImeiCelular = new Label();
            txtCedulaTecnico = new TextBox();
            lblIdTecnico = new Label();
            lblCedulaTecnico = new Label();
            groupBox1 = new GroupBox();
            btnMostrarFactura = new Button();
            groupBox2 = new GroupBox();
            lblDescripcionMovil = new Label();
            txtDescripcionMovil = new RichTextBox();
            cmbEquiposMoviles = new ComboBox();
            lblSeleccionarMovilExistente = new Label();
            txtFecha_ingreso2 = new TextBox();
            groupBox3 = new GroupBox();
            lblFechaEntrega = new Label();
            txtDescripcion = new RichTextBox();
            groupBox4 = new GroupBox();
            lblCedulaClienteExistente = new Label();
            lblTelefono = new Label();
            lblNombre = new Label();
            lblEmail = new Label();
            txtEmailCliente = new TextBox();
            txtTelefonoCliente = new TextBox();
            txtNombreCliente = new TextBox();
            cmbCedulaCliente = new ComboBox();
            lblCedulaCliente2 = new Label();
            txtCedulaCliente2 = new TextBox();
            groupBoxTecnico = new GroupBox();
            btnDesasignarTecnico = new Button();
            btnAgregarTecnico = new Button();
            btnSiguiente = new Button();
            dgvTecnicosAsignados = new DataGridView();
            btnAnterior = new Button();
            cmbCedulaTecnico = new ComboBox();
            lblCedulaTecnicoExistente = new Label();
            txtTelefonoTecnico = new TextBox();
            txtNombreTecnico = new TextBox();
            txtIdTecnico = new TextBox();
            lblEmailTecnico = new Label();
            txtEmailTecnico = new TextBox();
            lblTelefonoTecnico = new Label();
            lblNombreCompletoTecnico = new Label();
            groupBox6 = new GroupBox();
            label2 = new Label();
            txtPrecioServicio = new TextBox();
            btnInventario = new Button();
            label1 = new Label();
            cmbServicios = new ComboBox();
            lblIdRepuesto = new Label();
            lblTotalPagar = new Label();
            lblIVA = new Label();
            lblSubtotal = new Label();
            txtIdRepuesto = new TextBox();
            txtTotal = new TextBox();
            txtIVA = new TextBox();
            txtSubtotal = new TextBox();
            lblPrecio = new Label();
            lblCantidad = new Label();
            lblNombreRepuesto = new Label();
            btnEliminarRepuesto = new Button();
            btnNuevoRepuesto = new Button();
            btnGrabarRepuesto = new Button();
            dgvRepuestos = new DataGridView();
            txtCostoRepuesto = new TextBox();
            txtCantidad = new TextBox();
            txtDescripcionRepuesto = new TextBox();
            panel1 = new Panel();
            lblEncabezado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReparaciones).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBoxTecnico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicosAsignados).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            SuspendLayout();
            // 
            // dgvReparaciones
            // 
            dgvReparaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReparaciones.Location = new Point(18, 643);
            dgvReparaciones.Name = "dgvReparaciones";
            dgvReparaciones.RowTemplate.Height = 25;
            dgvReparaciones.Size = new Size(1275, 90);
            dgvReparaciones.TabIndex = 0;
            dgvReparaciones.CellContentClick += dgvReparaciones_SelectionChanged;
            // 
            // btnActualizarEstado
            // 
            btnActualizarEstado.Location = new Point(400, 20);
            btnActualizarEstado.Name = "btnActualizarEstado";
            btnActualizarEstado.Size = new Size(120, 30);
            btnActualizarEstado.TabIndex = 1;
            btnActualizarEstado.Text = "Actualizar Estado";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.Black;
            btnEliminar.Location = new Point(226, 22);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(107, 30);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtIdEquipo
            // 
            txtIdEquipo.Enabled = false;
            txtIdEquipo.Location = new Point(157, 75);
            txtIdEquipo.Name = "txtIdEquipo";
            txtIdEquipo.ReadOnly = true;
            txtIdEquipo.Size = new Size(101, 21);
            txtIdEquipo.TabIndex = 3;
            txtIdEquipo.TextChanged += txtIdEquipo_TextChanged;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "En revision", "Reparado", "En proceso" });
            cmbEstado.Location = new Point(412, 78);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(125, 23);
            cmbEstado.TabIndex = 4;
            // 
            // lblIdEquipo
            // 
            lblIdEquipo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdEquipo.Location = new Point(14, 78);
            lblIdEquipo.Name = "lblIdEquipo";
            lblIdEquipo.Size = new Size(72, 15);
            lblIdEquipo.TabIndex = 5;
            lblIdEquipo.Text = "ID Equipo:";
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEstado.Location = new Point(275, 81);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(71, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado:";
            // 
            // txtIdReparacion
            // 
            txtIdReparacion.Enabled = false;
            txtIdReparacion.Location = new Point(108, 19);
            txtIdReparacion.Name = "txtIdReparacion";
            txtIdReparacion.ReadOnly = true;
            txtIdReparacion.Size = new Size(143, 21);
            txtIdReparacion.TabIndex = 3;
            // 
            // lblIdReparacion
            // 
            lblIdReparacion.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdReparacion.Location = new Point(11, 19);
            lblIdReparacion.Name = "lblIdReparacion";
            lblIdReparacion.Size = new Size(91, 15);
            lblIdReparacion.TabIndex = 5;
            lblIdReparacion.Text = "ID Reparacion:";
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.White;
            btnNuevo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnNuevo.ForeColor = Color.Black;
            btnNuevo.Location = new Point(17, 21);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(89, 31);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.White;
            btnGrabar.Enabled = false;
            btnGrabar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGrabar.ForeColor = Color.Black;
            btnGrabar.Location = new Point(122, 21);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(88, 31);
            btnGrabar.TabIndex = 1;
            btnGrabar.Text = "Grabar";
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // lblID
            // 
            lblID.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblID.Location = new Point(16, 54);
            lblID.Name = "lblID";
            lblID.Size = new Size(70, 18);
            lblID.TabIndex = 5;
            lblID.Text = "ID Cliente:";
            // 
            // txtIdCliente
            // 
            txtIdCliente.Enabled = false;
            txtIdCliente.Location = new Point(120, 54);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.ReadOnly = true;
            txtIdCliente.Size = new Size(84, 21);
            txtIdCliente.TabIndex = 3;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(108, 44);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(143, 21);
            txtCosto.TabIndex = 3;
            // 
            // lblCosto
            // 
            lblCosto.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCosto.Location = new Point(11, 47);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(88, 18);
            lblCosto.TabIndex = 5;
            lblCosto.Text = "Total a pagar:";
            // 
            // lblNovedad
            // 
            lblNovedad.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNovedad.Location = new Point(11, 71);
            lblNovedad.Name = "lblNovedad";
            lblNovedad.Size = new Size(70, 18);
            lblNovedad.TabIndex = 5;
            lblNovedad.Text = "Novedad:";
            // 
            // txtFecha_entrega
            // 
            txtFecha_entrega.Location = new Point(386, 44);
            txtFecha_entrega.Name = "txtFecha_entrega";
            txtFecha_entrega.Size = new Size(107, 21);
            txtFecha_entrega.TabIndex = 3;
            txtFecha_entrega.KeyPress += txtFecha_entrega_KeyPress;
            // 
            // txtFecha_ingreso
            // 
            txtFecha_ingreso.Location = new Point(386, 16);
            txtFecha_ingreso.Name = "txtFecha_ingreso";
            txtFecha_ingreso.Size = new Size(107, 21);
            txtFecha_ingreso.TabIndex = 3;
            txtFecha_ingreso.KeyPress += txtFecha_ingreso_KeyPress;
            // 
            // lblFecha_ingreso
            // 
            lblFecha_ingreso.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblFecha_ingreso.Location = new Point(12, 139);
            lblFecha_ingreso.Name = "lblFecha_ingreso";
            lblFecha_ingreso.Size = new Size(101, 15);
            lblFecha_ingreso.TabIndex = 5;
            lblFecha_ingreso.Text = "Fecha de ingreso:";
            // 
            // lblFecha_ingreso2
            // 
            lblFecha_ingreso2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblFecha_ingreso2.Location = new Point(259, 24);
            lblFecha_ingreso2.Name = "lblFecha_ingreso2";
            lblFecha_ingreso2.Size = new Size(121, 15);
            lblFecha_ingreso2.TabIndex = 5;
            lblFecha_ingreso2.Text = "Fecha de ingreso:";
            // 
            // txtCedulaCliente
            // 
            txtCedulaCliente.Enabled = false;
            txtCedulaCliente.Location = new Point(412, 29);
            txtCedulaCliente.Name = "txtCedulaCliente";
            txtCedulaCliente.Size = new Size(125, 21);
            txtCedulaCliente.TabIndex = 14;
            // 
            // lblCedulaCliente
            // 
            lblCedulaCliente.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCedulaCliente.Location = new Point(306, 33);
            lblCedulaCliente.Name = "lblCedulaCliente";
            lblCedulaCliente.Size = new Size(100, 15);
            lblCedulaCliente.TabIndex = 0;
            lblCedulaCliente.Text = "Cedula de cliente";
            // 
            // txtImeiCelular
            // 
            txtImeiCelular.Enabled = false;
            txtImeiCelular.Location = new Point(157, 104);
            txtImeiCelular.Name = "txtImeiCelular";
            txtImeiCelular.Size = new Size(101, 21);
            txtImeiCelular.TabIndex = 13;
            // 
            // lblImeiCelular
            // 
            lblImeiCelular.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblImeiCelular.Location = new Point(16, 110);
            lblImeiCelular.Name = "lblImeiCelular";
            lblImeiCelular.Size = new Size(45, 17);
            lblImeiCelular.TabIndex = 12;
            lblImeiCelular.Text = "IMEI";
            // 
            // txtCedulaTecnico
            // 
            txtCedulaTecnico.Enabled = false;
            txtCedulaTecnico.Location = new Point(639, 78);
            txtCedulaTecnico.Name = "txtCedulaTecnico";
            txtCedulaTecnico.Size = new Size(114, 21);
            txtCedulaTecnico.TabIndex = 14;
            // 
            // lblIdTecnico
            // 
            lblIdTecnico.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdTecnico.Location = new Point(519, 49);
            lblIdTecnico.Name = "lblIdTecnico";
            lblIdTecnico.Size = new Size(87, 23);
            lblIdTecnico.TabIndex = 2;
            lblIdTecnico.Text = "ID del técnico";
            // 
            // lblCedulaTecnico
            // 
            lblCedulaTecnico.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCedulaTecnico.Location = new Point(519, 81);
            lblCedulaTecnico.Name = "lblCedulaTecnico";
            lblCedulaTecnico.Size = new Size(107, 15);
            lblCedulaTecnico.TabIndex = 1;
            lblCedulaTecnico.Text = "Cédula de técnico";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnMostrarFactura);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnGrabar);
            groupBox1.Controls.Add(btnNuevo);
            groupBox1.Location = new Point(809, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(472, 76);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // btnMostrarFactura
            // 
            btnMostrarFactura.BackColor = Color.White;
            btnMostrarFactura.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnMostrarFactura.ForeColor = Color.Black;
            btnMostrarFactura.Location = new Point(359, 21);
            btnMostrarFactura.Name = "btnMostrarFactura";
            btnMostrarFactura.Size = new Size(107, 33);
            btnMostrarFactura.TabIndex = 3;
            btnMostrarFactura.Text = "Mostrar factura";
            btnMostrarFactura.UseVisualStyleBackColor = false;
            btnMostrarFactura.Click += btnMostrarFactura_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblDescripcionMovil);
            groupBox2.Controls.Add(txtDescripcionMovil);
            groupBox2.Controls.Add(cmbEquiposMoviles);
            groupBox2.Controls.Add(lblSeleccionarMovilExistente);
            groupBox2.Controls.Add(txtFecha_ingreso2);
            groupBox2.Controls.Add(txtIdEquipo);
            groupBox2.Controls.Add(lblIdEquipo);
            groupBox2.Controls.Add(cmbEstado);
            groupBox2.Controls.Add(lblEstado);
            groupBox2.Controls.Add(lblCedulaCliente);
            groupBox2.Controls.Add(txtCedulaCliente);
            groupBox2.Controls.Add(txtImeiCelular);
            groupBox2.Controls.Add(lblImeiCelular);
            groupBox2.Controls.Add(lblFecha_ingreso);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(18, 176);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(764, 174);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos de movil";
            // 
            // lblDescripcionMovil
            // 
            lblDescripcionMovil.AutoSize = true;
            lblDescripcionMovil.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcionMovil.Location = new Point(275, 113);
            lblDescripcionMovil.Name = "lblDescripcionMovil";
            lblDescripcionMovil.Size = new Size(121, 15);
            lblDescripcionMovil.TabIndex = 30;
            lblDescripcionMovil.Text = "Descripcion de movil";
            // 
            // txtDescripcionMovil
            // 
            txtDescripcionMovil.Enabled = false;
            txtDescripcionMovil.Location = new Point(412, 113);
            txtDescripcionMovil.Name = "txtDescripcionMovil";
            txtDescripcionMovil.Size = new Size(217, 38);
            txtDescripcionMovil.TabIndex = 29;
            txtDescripcionMovil.Text = "";
            // 
            // cmbEquiposMoviles
            // 
            cmbEquiposMoviles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEquiposMoviles.FormattingEnabled = true;
            cmbEquiposMoviles.Location = new Point(204, 29);
            cmbEquiposMoviles.Name = "cmbEquiposMoviles";
            cmbEquiposMoviles.Size = new Size(82, 23);
            cmbEquiposMoviles.TabIndex = 27;
            cmbEquiposMoviles.SelectedIndexChanged += cmbEquiposMoviles_SelectedIndexChanged;
            // 
            // lblSeleccionarMovilExistente
            // 
            lblSeleccionarMovilExistente.AutoSize = true;
            lblSeleccionarMovilExistente.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSeleccionarMovilExistente.Location = new Point(7, 32);
            lblSeleccionarMovilExistente.Name = "lblSeleccionarMovilExistente";
            lblSeleccionarMovilExistente.Size = new Size(199, 15);
            lblSeleccionarMovilExistente.TabIndex = 15;
            lblSeleccionarMovilExistente.Text = "Seleccionar moviles del propietario";
            // 
            // txtFecha_ingreso2
            // 
            txtFecha_ingreso2.Enabled = false;
            txtFecha_ingreso2.Location = new Point(157, 136);
            txtFecha_ingreso2.Name = "txtFecha_ingreso2";
            txtFecha_ingreso2.Size = new Size(101, 21);
            txtFecha_ingreso2.TabIndex = 8;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblFechaEntrega);
            groupBox3.Controls.Add(txtDescripcion);
            groupBox3.Controls.Add(lblIdReparacion);
            groupBox3.Controls.Add(txtCosto);
            groupBox3.Controls.Add(lblNovedad);
            groupBox3.Controls.Add(txtFecha_entrega);
            groupBox3.Controls.Add(txtFecha_ingreso);
            groupBox3.Controls.Add(txtIdReparacion);
            groupBox3.Controls.Add(lblCosto);
            groupBox3.Controls.Add(lblFecha_ingreso2);
            groupBox3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(788, 494);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(505, 127);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Novedades";
            // 
            // lblFechaEntrega
            // 
            lblFechaEntrega.AutoSize = true;
            lblFechaEntrega.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaEntrega.Location = new Point(261, 49);
            lblFechaEntrega.Name = "lblFechaEntrega";
            lblFechaEntrega.Size = new Size(106, 15);
            lblFechaEntrega.TabIndex = 7;
            lblFechaEntrega.Text = "Fecha de entrega:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(108, 71);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(283, 45);
            txtDescripcion.TabIndex = 6;
            txtDescripcion.Text = "";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblCedulaClienteExistente);
            groupBox4.Controls.Add(lblTelefono);
            groupBox4.Controls.Add(lblNombre);
            groupBox4.Controls.Add(lblEmail);
            groupBox4.Controls.Add(txtEmailCliente);
            groupBox4.Controls.Add(txtTelefonoCliente);
            groupBox4.Controls.Add(txtNombreCliente);
            groupBox4.Controls.Add(cmbCedulaCliente);
            groupBox4.Controls.Add(lblCedulaCliente2);
            groupBox4.Controls.Add(lblID);
            groupBox4.Controls.Add(txtCedulaCliente2);
            groupBox4.Controls.Add(txtIdCliente);
            groupBox4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox4.Location = new Point(12, 47);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(770, 123);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Datos de cliente";
            // 
            // lblCedulaClienteExistente
            // 
            lblCedulaClienteExistente.AutoSize = true;
            lblCedulaClienteExistente.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCedulaClienteExistente.Location = new Point(17, 27);
            lblCedulaClienteExistente.Name = "lblCedulaClienteExistente";
            lblCedulaClienteExistente.Size = new Size(171, 15);
            lblCedulaClienteExistente.TabIndex = 24;
            lblCedulaClienteExistente.Text = "Seleccionar usuario existente:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefono.Location = new Point(295, 90);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(58, 15);
            lblTelefono.TabIndex = 23;
            lblTelefono.Text = "Telefono:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(295, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(55, 15);
            lblNombre.TabIndex = 22;
            lblNombre.Text = "Nombre:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.Location = new Point(558, 56);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(42, 15);
            lblEmail.TabIndex = 21;
            lblEmail.Text = "Email:";
            // 
            // txtEmailCliente
            // 
            txtEmailCliente.Enabled = false;
            txtEmailCliente.Location = new Point(603, 51);
            txtEmailCliente.Name = "txtEmailCliente";
            txtEmailCliente.Size = new Size(110, 21);
            txtEmailCliente.TabIndex = 20;
            // 
            // txtTelefonoCliente
            // 
            txtTelefonoCliente.Enabled = false;
            txtTelefonoCliente.Location = new Point(352, 86);
            txtTelefonoCliente.Name = "txtTelefonoCliente";
            txtTelefonoCliente.Size = new Size(135, 21);
            txtTelefonoCliente.TabIndex = 19;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Enabled = false;
            txtNombreCliente.Location = new Point(352, 54);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(135, 21);
            txtNombreCliente.TabIndex = 18;
            // 
            // cmbCedulaCliente
            // 
            cmbCedulaCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCedulaCliente.FormattingEnabled = true;
            cmbCedulaCliente.Location = new Point(189, 19);
            cmbCedulaCliente.Name = "cmbCedulaCliente";
            cmbCedulaCliente.Size = new Size(133, 23);
            cmbCedulaCliente.TabIndex = 17;
            cmbCedulaCliente.SelectedIndexChanged += cmbCedulaCliente_SelectedIndexChanged;
            // 
            // lblCedulaCliente2
            // 
            lblCedulaCliente2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCedulaCliente2.Location = new Point(14, 83);
            lblCedulaCliente2.Name = "lblCedulaCliente2";
            lblCedulaCliente2.Size = new Size(100, 23);
            lblCedulaCliente2.TabIndex = 15;
            lblCedulaCliente2.Text = "Cedula de cliente";
            // 
            // txtCedulaCliente2
            // 
            txtCedulaCliente2.Enabled = false;
            txtCedulaCliente2.Location = new Point(120, 83);
            txtCedulaCliente2.Name = "txtCedulaCliente2";
            txtCedulaCliente2.Size = new Size(84, 21);
            txtCedulaCliente2.TabIndex = 16;
            // 
            // groupBoxTecnico
            // 
            groupBoxTecnico.Controls.Add(btnDesasignarTecnico);
            groupBoxTecnico.Controls.Add(btnAgregarTecnico);
            groupBoxTecnico.Controls.Add(btnSiguiente);
            groupBoxTecnico.Controls.Add(dgvTecnicosAsignados);
            groupBoxTecnico.Controls.Add(btnAnterior);
            groupBoxTecnico.Controls.Add(cmbCedulaTecnico);
            groupBoxTecnico.Controls.Add(lblCedulaTecnicoExistente);
            groupBoxTecnico.Controls.Add(txtTelefonoTecnico);
            groupBoxTecnico.Controls.Add(txtNombreTecnico);
            groupBoxTecnico.Controls.Add(txtIdTecnico);
            groupBoxTecnico.Controls.Add(lblEmailTecnico);
            groupBoxTecnico.Controls.Add(txtEmailTecnico);
            groupBoxTecnico.Controls.Add(txtCedulaTecnico);
            groupBoxTecnico.Controls.Add(lblIdTecnico);
            groupBoxTecnico.Controls.Add(lblTelefonoTecnico);
            groupBoxTecnico.Controls.Add(lblNombreCompletoTecnico);
            groupBoxTecnico.Controls.Add(lblCedulaTecnico);
            groupBoxTecnico.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBoxTecnico.Location = new Point(12, 356);
            groupBoxTecnico.Name = "groupBoxTecnico";
            groupBoxTecnico.Size = new Size(770, 267);
            groupBoxTecnico.TabIndex = 11;
            groupBoxTecnico.TabStop = false;
            groupBoxTecnico.Text = "Datos de tecnico";
            // 
            // btnDesasignarTecnico
            // 
            btnDesasignarTecnico.BackColor = Color.White;
            btnDesasignarTecnico.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDesasignarTecnico.ForeColor = Color.Black;
            btnDesasignarTecnico.Location = new Point(188, 224);
            btnDesasignarTecnico.Name = "btnDesasignarTecnico";
            btnDesasignarTecnico.Size = new Size(76, 25);
            btnDesasignarTecnico.TabIndex = 27;
            btnDesasignarTecnico.Text = "Quitar ";
            btnDesasignarTecnico.UseVisualStyleBackColor = false;
            btnDesasignarTecnico.Click += btnDesasignarTecnico_Click;
            // 
            // btnAgregarTecnico
            // 
            btnAgregarTecnico.BackColor = Color.White;
            btnAgregarTecnico.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregarTecnico.ForeColor = Color.Black;
            btnAgregarTecnico.Location = new Point(94, 224);
            btnAgregarTecnico.Name = "btnAgregarTecnico";
            btnAgregarTecnico.Size = new Size(76, 23);
            btnAgregarTecnico.TabIndex = 26;
            btnAgregarTecnico.Text = "Agregar";
            btnAgregarTecnico.UseVisualStyleBackColor = false;
            btnAgregarTecnico.Click += btnAgregarTecnico_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackColor = Color.White;
            btnSiguiente.ForeColor = Color.Black;
            btnSiguiente.Location = new Point(281, 224);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(70, 27);
            btnSiguiente.TabIndex = 25;
            btnSiguiente.Text = "->";
            btnSiguiente.UseVisualStyleBackColor = false;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // dgvTecnicosAsignados
            // 
            dgvTecnicosAsignados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTecnicosAsignados.Enabled = false;
            dgvTecnicosAsignados.Location = new Point(6, 22);
            dgvTecnicosAsignados.Name = "dgvTecnicosAsignados";
            dgvTecnicosAsignados.ReadOnly = true;
            dgvTecnicosAsignados.RowTemplate.Height = 25;
            dgvTecnicosAsignados.Size = new Size(510, 194);
            dgvTecnicosAsignados.TabIndex = 0;
            dgvTecnicosAsignados.CellContentClick += dgvTecnicosAsignados_CellContentClick;
            // 
            // btnAnterior
            // 
            btnAnterior.BackColor = Color.White;
            btnAnterior.ForeColor = Color.Black;
            btnAnterior.Location = new Point(31, 224);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(57, 24);
            btnAnterior.TabIndex = 24;
            btnAnterior.Text = "<-";
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // cmbCedulaTecnico
            // 
            cmbCedulaTecnico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCedulaTecnico.FormattingEnabled = true;
            cmbCedulaTecnico.Location = new Point(638, 17);
            cmbCedulaTecnico.Name = "cmbCedulaTecnico";
            cmbCedulaTecnico.Size = new Size(100, 23);
            cmbCedulaTecnico.TabIndex = 16;
            cmbCedulaTecnico.SelectedIndexChanged += cmbCedulaTecnico_SelectedIndexChanged;
            // 
            // lblCedulaTecnicoExistente
            // 
            lblCedulaTecnicoExistente.AutoSize = true;
            lblCedulaTecnicoExistente.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCedulaTecnicoExistente.Location = new Point(522, 21);
            lblCedulaTecnicoExistente.Name = "lblCedulaTecnicoExistente";
            lblCedulaTecnicoExistente.Size = new Size(117, 15);
            lblCedulaTecnicoExistente.TabIndex = 23;
            lblCedulaTecnicoExistente.Text = "Seleccionar tecnico:";
            // 
            // txtTelefonoTecnico
            // 
            txtTelefonoTecnico.Enabled = false;
            txtTelefonoTecnico.Location = new Point(639, 138);
            txtTelefonoTecnico.Name = "txtTelefonoTecnico";
            txtTelefonoTecnico.Size = new Size(114, 21);
            txtTelefonoTecnico.TabIndex = 18;
            // 
            // txtNombreTecnico
            // 
            txtNombreTecnico.Enabled = false;
            txtNombreTecnico.Location = new Point(638, 107);
            txtNombreTecnico.Name = "txtNombreTecnico";
            txtNombreTecnico.Size = new Size(115, 21);
            txtNombreTecnico.TabIndex = 17;
            // 
            // txtIdTecnico
            // 
            txtIdTecnico.Enabled = false;
            txtIdTecnico.Location = new Point(639, 46);
            txtIdTecnico.Name = "txtIdTecnico";
            txtIdTecnico.ReadOnly = true;
            txtIdTecnico.Size = new Size(114, 21);
            txtIdTecnico.TabIndex = 15;
            // 
            // lblEmailTecnico
            // 
            lblEmailTecnico.AutoSize = true;
            lblEmailTecnico.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmailTecnico.Location = new Point(525, 169);
            lblEmailTecnico.Name = "lblEmailTecnico";
            lblEmailTecnico.Size = new Size(39, 15);
            lblEmailTecnico.TabIndex = 22;
            lblEmailTecnico.Text = "Email";
            // 
            // txtEmailTecnico
            // 
            txtEmailTecnico.Enabled = false;
            txtEmailTecnico.Location = new Point(639, 169);
            txtEmailTecnico.Name = "txtEmailTecnico";
            txtEmailTecnico.Size = new Size(114, 21);
            txtEmailTecnico.TabIndex = 19;
            // 
            // lblTelefonoTecnico
            // 
            lblTelefonoTecnico.AutoSize = true;
            lblTelefonoTecnico.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefonoTecnico.Location = new Point(522, 141);
            lblTelefonoTecnico.Name = "lblTelefonoTecnico";
            lblTelefonoTecnico.Size = new Size(55, 15);
            lblTelefonoTecnico.TabIndex = 21;
            lblTelefonoTecnico.Text = "Telefono";
            // 
            // lblNombreCompletoTecnico
            // 
            lblNombreCompletoTecnico.AutoSize = true;
            lblNombreCompletoTecnico.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreCompletoTecnico.Location = new Point(522, 110);
            lblNombreCompletoTecnico.Name = "lblNombreCompletoTecnico";
            lblNombreCompletoTecnico.Size = new Size(109, 15);
            lblNombreCompletoTecnico.TabIndex = 20;
            lblNombreCompletoTecnico.Text = "Nombre completo:";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label2);
            groupBox6.Controls.Add(txtPrecioServicio);
            groupBox6.Controls.Add(btnInventario);
            groupBox6.Controls.Add(label1);
            groupBox6.Controls.Add(cmbServicios);
            groupBox6.Controls.Add(lblIdRepuesto);
            groupBox6.Controls.Add(lblTotalPagar);
            groupBox6.Controls.Add(lblIVA);
            groupBox6.Controls.Add(lblSubtotal);
            groupBox6.Controls.Add(txtIdRepuesto);
            groupBox6.Controls.Add(txtTotal);
            groupBox6.Controls.Add(txtIVA);
            groupBox6.Controls.Add(txtSubtotal);
            groupBox6.Controls.Add(lblPrecio);
            groupBox6.Controls.Add(lblCantidad);
            groupBox6.Controls.Add(lblNombreRepuesto);
            groupBox6.Controls.Add(btnEliminarRepuesto);
            groupBox6.Controls.Add(btnNuevoRepuesto);
            groupBox6.Controls.Add(btnGrabarRepuesto);
            groupBox6.Controls.Add(dgvRepuestos);
            groupBox6.Controls.Add(txtCostoRepuesto);
            groupBox6.Controls.Add(txtCantidad);
            groupBox6.Controls.Add(txtDescripcionRepuesto);
            groupBox6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox6.Location = new Point(809, 129);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(472, 356);
            groupBox6.TabIndex = 12;
            groupBox6.TabStop = false;
            groupBox6.Text = "Datos de repuestos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 311);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 23;
            label2.Text = "Precio Servicio";
            // 
            // txtPrecioServicio
            // 
            txtPrecioServicio.Enabled = false;
            txtPrecioServicio.Location = new Point(365, 309);
            txtPrecioServicio.Name = "txtPrecioServicio";
            txtPrecioServicio.Size = new Size(100, 21);
            txtPrecioServicio.TabIndex = 22;
            // 
            // btnInventario
            // 
            btnInventario.Location = new Point(366, 121);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(87, 23);
            btnInventario.TabIndex = 21;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(253, 276);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 20;
            label1.Text = "Servicios";
            // 
            // cmbServicios
            // 
            cmbServicios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicios.FormattingEnabled = true;
            cmbServicios.Location = new Point(324, 273);
            cmbServicios.Name = "cmbServicios";
            cmbServicios.Size = new Size(142, 23);
            cmbServicios.TabIndex = 19;
            // 
            // lblIdRepuesto
            // 
            lblIdRepuesto.AutoSize = true;
            lblIdRepuesto.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdRepuesto.Location = new Point(12, 31);
            lblIdRepuesto.Name = "lblIdRepuesto";
            lblIdRepuesto.Size = new Size(23, 16);
            lblIdRepuesto.TabIndex = 18;
            lblIdRepuesto.Text = "ID:";
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalPagar.Location = new Point(12, 330);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(82, 15);
            lblTotalPagar.TabIndex = 17;
            lblTotalPagar.Text = "Total a pagar:";
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIVA.Location = new Point(18, 305);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(63, 15);
            lblIVA.TabIndex = 16;
            lblIVA.Text = "IVA (15%):";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubtotal.Location = new Point(18, 275);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(55, 15);
            lblSubtotal.TabIndex = 15;
            lblSubtotal.Text = "Subtotal:";
            // 
            // txtIdRepuesto
            // 
            txtIdRepuesto.Location = new Point(196, 27);
            txtIdRepuesto.Name = "txtIdRepuesto";
            txtIdRepuesto.ReadOnly = true;
            txtIdRepuesto.Size = new Size(125, 21);
            txtIdRepuesto.TabIndex = 14;
            // 
            // txtTotal
            // 
            txtTotal.Enabled = false;
            txtTotal.Location = new Point(99, 330);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(125, 21);
            txtTotal.TabIndex = 13;
            // 
            // txtIVA
            // 
            txtIVA.Enabled = false;
            txtIVA.Location = new Point(99, 302);
            txtIVA.Name = "txtIVA";
            txtIVA.ReadOnly = true;
            txtIVA.Size = new Size(125, 21);
            txtIVA.TabIndex = 12;
            // 
            // txtSubtotal
            // 
            txtSubtotal.Enabled = false;
            txtSubtotal.Location = new Point(99, 272);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(125, 21);
            txtSubtotal.TabIndex = 11;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrecio.Location = new Point(10, 122);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(49, 16);
            lblPrecio.TabIndex = 10;
            lblPrecio.Text = "Precio:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantidad.Location = new Point(10, 89);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(64, 16);
            lblCantidad.TabIndex = 9;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblNombreRepuesto
            // 
            lblNombreRepuesto.AutoSize = true;
            lblNombreRepuesto.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreRepuesto.Location = new Point(12, 59);
            lblNombreRepuesto.Name = "lblNombreRepuesto";
            lblNombreRepuesto.Size = new Size(59, 16);
            lblNombreRepuesto.TabIndex = 8;
            lblNombreRepuesto.Text = "Nombre:";
            // 
            // btnEliminarRepuesto
            // 
            btnEliminarRepuesto.Location = new Point(365, 88);
            btnEliminarRepuesto.Name = "btnEliminarRepuesto";
            btnEliminarRepuesto.Size = new Size(88, 25);
            btnEliminarRepuesto.TabIndex = 7;
            btnEliminarRepuesto.Text = "Eliminar";
            btnEliminarRepuesto.UseVisualStyleBackColor = true;
            btnEliminarRepuesto.Click += btnEliminarRepuesto_Click;
            // 
            // btnNuevoRepuesto
            // 
            btnNuevoRepuesto.Location = new Point(365, 21);
            btnNuevoRepuesto.Name = "btnNuevoRepuesto";
            btnNuevoRepuesto.RightToLeft = RightToLeft.Yes;
            btnNuevoRepuesto.Size = new Size(88, 32);
            btnNuevoRepuesto.TabIndex = 6;
            btnNuevoRepuesto.Text = "Nuevo repuesto";
            btnNuevoRepuesto.UseVisualStyleBackColor = true;
            btnNuevoRepuesto.Click += btnNuevoRepuesto_Click;
            // 
            // btnGrabarRepuesto
            // 
            btnGrabarRepuesto.Location = new Point(365, 56);
            btnGrabarRepuesto.Name = "btnGrabarRepuesto";
            btnGrabarRepuesto.Size = new Size(88, 26);
            btnGrabarRepuesto.TabIndex = 5;
            btnGrabarRepuesto.Text = "Añadir";
            btnGrabarRepuesto.UseVisualStyleBackColor = true;
            btnGrabarRepuesto.Click += btnGrabarRepuesto_Click;
            // 
            // dgvRepuestos
            // 
            dgvRepuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepuestos.Location = new Point(6, 154);
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.RowTemplate.Height = 25;
            dgvRepuestos.Size = new Size(460, 103);
            dgvRepuestos.TabIndex = 4;
            dgvRepuestos.SelectionChanged += dgvRepuestos_SelectionChanged;
            // 
            // txtCostoRepuesto
            // 
            txtCostoRepuesto.Location = new Point(195, 115);
            txtCostoRepuesto.Name = "txtCostoRepuesto";
            txtCostoRepuesto.Size = new Size(123, 21);
            txtCostoRepuesto.TabIndex = 3;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(195, 86);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(125, 21);
            txtCantidad.TabIndex = 2;
            // 
            // txtDescripcionRepuesto
            // 
            txtDescripcionRepuesto.Location = new Point(195, 55);
            txtDescripcionRepuesto.Name = "txtDescripcionRepuesto";
            txtDescripcionRepuesto.Size = new Size(124, 21);
            txtDescripcionRepuesto.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Location = new Point(-2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1283, 10);
            panel1.TabIndex = 13;
            // 
            // lblEncabezado
            // 
            lblEncabezado.Dock = DockStyle.Top;
            lblEncabezado.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblEncabezado.Location = new Point(0, 0);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(1293, 44);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.TextAlign = ContentAlignment.MiddleCenter;
            lblEncabezado.Visible = false;
            // 
            // frmReparaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1293, 781);
            Controls.Add(lblEncabezado);
            Controls.Add(panel1);
            Controls.Add(groupBox6);
            Controls.Add(groupBoxTecnico);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvReparaciones);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "frmReparaciones";
            Text = "Administracion gestiona las reparaciones de celulares";
            Load += frmReparaciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReparaciones).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBoxTecnico.ResumeLayout(false);
            groupBoxTecnico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicosAsignados).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dgvReparaciones;
        private Button btnActualizarEstado;
        private Button btnEliminar;
        private TextBox txtIdEquipo;
        private TextBox txtIdReparacion;
        private TextBox txtIdCliente;
        private ComboBox cmbEstado;
        private Label lblID;
        private Label lblIdEquipo;
        private Label lblEstado;
        private Label lblIdReparacion;
        private Label lblNovedad;
        private Label lblCosto;
        private Label lblFecha_ingreso;
        private Label lblFecha_ingreso2;
        private Button btnNuevo;
        private Button btnGrabar;
        private TextBox txtCosto;
        private TextBox txtIdTecnico;
        private Label lblIdTecnico;
        private Label lblCedulaTecnico;
        private TextBox txtCedulaTecnico;
        private TextBox txtFecha_ingreso;
        private TextBox txtFecha_entrega;
        private TextBox txtCedulaCliente;
        private TextBox txtImeiCelular;
        private Label lblCedulaCliente;
        private Label lblImeiCelular;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBoxTecnico;
        private Label lblCedulaCliente2;
        private TextBox txtCedulaCliente2;
        private Button btnMostrarFactura;
        private ComboBox cmbCedulaTecnico;
        private TextBox txtNombreTecnico;
        private TextBox txtTelefonoTecnico;
        private TextBox txtEmailTecnico;
        private Label lblNombreCompletoTecnico;
        private Label lblEmailTecnico;
        private Label lblTelefonoTecnico;
        private ComboBox cmbCedulaCliente;
        private Label lblEmail;
        private TextBox txtEmailCliente;
        private TextBox txtTelefonoCliente;
        private TextBox txtNombreCliente;
        private Label lblTelefono;
        private Label lblNombre;
        private RichTextBox txtDescripcion;
        private Label lblCedulaClienteExistente;
        private Label lblCedulaTecnicoExistente;
        private Label lblFechaEntrega;
        private TextBox txtFecha_ingreso2;
        private Label lblSeleccionarMovilExistente;
        private Button btnAgregarTecnico;
        private Button btnSiguiente;
        private Button btnAnterior;
        private DataGridView dgvTecnicosAsignados;
        private GroupBox groupBox6;
        private Panel panel1;
        private ComboBox cmbEquiposMoviles;
        private RichTextBox txtDescripcionMovil;
        private Label lblDescripcionMovil;
        private DataGridView dgvRepuestos;
        private TextBox txtCostoRepuesto;
        private TextBox txtCantidad;
        private TextBox txtDescripcionRepuesto;
        private Button btnEliminarRepuesto;
        private Button btnNuevoRepuesto;
        private Button btnGrabarRepuesto;
        private Label lblPrecio;
        private Label lblCantidad;
        private Label lblNombreRepuesto;
        private TextBox txtTotal;
        private TextBox txtIVA;
        private TextBox txtSubtotal;
        private TextBox txtIdRepuesto;
        private Label lblTotalPagar;
        private Label lblIVA;
        private Label lblSubtotal;
        private Label lblIdRepuesto;
        private Button btnDesasignarTecnico;
        private Label lblEncabezado;
        private Button btnInventario;
        private Label label1;
        private ComboBox cmbServicios;
        private TextBox txtPrecioServicio;
        private Label label2;
    }
}
