using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using Timer = System.Threading.Timer;
using System.Security.Policy;
namespace CapaPresentacion
{
    public partial class FrmSistema : Form
    {
        private bool isDarkMode = false; // Bandera para Modo Oscuro
        private Dictionary<string, string> keywords; // Diccionario para asociar palabras clave a formularios
        private Dictionary<string, Dictionary<string, string>> translations;

        public FrmSistema()
        {
            InitializeComponent();
            InitializeLanguageSupport();


            this.IsMdiContainer = true;
            keywords = new Dictionary<string, string>
            {
                { "clientes", "frmCliente" },
                { "registro de clientes", "frmCliente" },
                { "actualizacion de datos de clientes", "frmCliente" },
                { "eliminacion de clientes", "frmCliente" },
                { "todos los registros de clientes", "frmCliente" },
                { "consultar mis facturas", "frmCliente" },
                { "tecnicos", "frmTecnico" },
                { "registro de tecnicos", "frmTecnico" },
                { "actualizacion de datos de tecnicos", "frmTecnico" },
                { "eliminacion de tecnicos", "frmTecnico" },
                { "todos los registros de tecnicos", "frmTecnico" },
                { "consultar equipos asignados", "frmTecnico" },
                { "movil", "frmMovil" },
                { "equipo", "frmMovil" },
                { "equipos moviles", "frmMovil" },
                { "registrar equipos moviles", "frmMovil" },
                { "eliminacion de equipos", "frmMovil" },
                { "eliminacion de movil", "frmMovil" },
                { "reparacion", "frmReparaciones" },
                { "registrar reparacion", "frmReparaciones" },
                { "eliminar reparacion", "frmReparaciones" },
                { "actualizar reparacion", "frmReparaciones" },
                { "factura", "frmFactura" },
                { "historial de facturas", "frmFactura" },
                { "consulta de facturas", "frmFactura" },
                { "facturas de cliente", "frmFactura" },
                { "contactos", "Contacto" },
                { "desarrolladores", "Contacto" },

            };


        }
        private void FrmSistema_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            cbIdioma.Items.Add("Español");
            cbIdioma.Items.Add("Inglés");
            cbIdioma.Items.Add("Portugués");
            cbIdioma.SelectedIndex = 0; // Español por defecto
            cbIdioma.SelectedIndexChanged += cbIdioma_SelectedIndexChanged;




        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string text = searchBox.Text.ToLower(); // Vinculación con el searchBox

            if (keywords.ContainsKey(text))
            {
                string formName = keywords[text];
                AbrirFormulario(formName);

                // Limpiar el campo de búsqueda después de realizar la acción
                searchBox.Clear();
            }
            else
            {
                // Mostrar un mensaje con las palabras clave válidas
                var keywordList = string.Join(", ", keywords.Keys);
                MessageBox.Show($"No se encontró su búsqueda. Intente con alguna de las siguientes palabras clave: {keywordList}",
                                "Búsqueda sin resultados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Limpiar el campo de búsqueda en caso de no encontrar resultados
                searchBox.Clear();
            }
        }

        private void AbrirFormulario(string formName)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == formName)
                {
                    frm.Activate();
                    return;
                }
            }

            try
            {
                var validKeywords = new List<string> { "frmCliente", "frmTecnico", "frmMovil", "frmReparaciones", "frmFactura", "Contacto" };

                if (validKeywords.Contains(formName))
                {
                    Form formToOpen = formName switch
                    {
                        "frmCliente" => new frmCliente { MdiParent = this },
                        "frmTecnico" => new frmTecnico { MdiParent = this },
                        "frmMovil" => new frmMovil { MdiParent = this },
                        "frmReparaciones" => new frmReparaciones { MdiParent = this },
                        "frmFactura" => SeleccionarCedulaYMostrarFactura(),
                        "Contacto" => MostrarDialogoContactos(),
                        _ => null
                    };

                    if (formToOpen != null)
                    {
                        // Calcular la posición centrada
                        int x = (this.ClientSize.Width - formToOpen.Width) / 2;
                        int y = (this.ClientSize.Height - formToOpen.Height) / 2;

                        formToOpen.StartPosition = FormStartPosition.Manual;
                        formToOpen.Location = new Point(x, y);

                        formToOpen.Show();
                    }
                    else
                    {
                        MessageBox.Show("El formulario fue abierto pero no se lo uso",
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("INTENTE CON OTRA PALABRA CLAVE PARA BUSCAR",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private Form SeleccionarCedulaYMostrarFactura()
        {
            using (var dialog = new frmSeleccionarCedula())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string cedulaSeleccionada = dialog.CedulaSeleccionada;

                    if (!string.IsNullOrEmpty(cedulaSeleccionada))
                    {
                        try
                        {
                            // Mostrar la factura pasando la cédula como parámetro
                            return new frmFactura(cedulaSeleccionada) { MdiParent = this };
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Message.Contains("No hay facturas asociadas a esta cédula"))
                            {
                                MessageBox.Show("No se encontraron facturas para la cédula seleccionada.", "Sin facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error al buscar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información para la cédula seleccionada.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            return null;
        }
        private Form MostrarDialogoContactos()
        {
            Form contactoDialog = new Form
            {
                Text = "Contactos",
                Size = new Size(400, 300)
            };

            string contactos =

                "UNIVERSIDAD DE GUAYAQUIL\n" +
                "FACULDAD CIENCIAS MATEMATICAS Y FISICA\n\n" +
                "PROJECT MANAGER\" \n" +
                "Email: natalia.cepedajar@ug.edu.ec\n\n" +

                "NATALIA CEPEDA \n" +
                "PROYECTO BASE DE DATOS AVANZADO \n" +
                "2024-2025 CII";

            Label lblContactos = new Label
            {
                Text = contactos,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            contactoDialog.Controls.Add(lblContactos);

            return contactoDialog;
        }

        private void mODOCLAROToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isDarkMode = false;
            AplicarTema();
        }

        private void mODOOSCUROToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isDarkMode = true;
            AplicarTema();
        }


        private void cERRARSESIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "¿Estás seguro de que deseas cerrar la sesión?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void cONTACTOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form contactoDialog = MostrarDialogoContactos();
            contactoDialog.ShowDialog();
            pictureBox2.Visible = false;
        }



        private void FrmSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CambiarTamanoFuente(Control control, float tamanoFuente)
        {
            if (tamanoFuente <= 0 || tamanoFuente > System.Single.MaxValue)
            {
                MessageBox.Show("El tamaño de la fuente debe ser mayor a 0 y menor al máximo permitido.",
                                "Tamaño de fuente inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (control is Label)
            {
                control.Font = new Font(control.Font.FontFamily, tamanoFuente, control.Font.Style);
            }

            foreach (Control childControl in control.Controls)
            {
                CambiarTamanoFuente(childControl, tamanoFuente);
            }
        }

        private void AplicarTamanoFuente(float tamanoFuente)
        {
            // Cambiar el tamaño de fuente de los Label en la ventana principal
            CambiarTamanoFuente(this, tamanoFuente);

            // Cambiar el tamaño de fuente en los formularios hijos (MDI)
            foreach (Form frm in this.MdiChildren)
            {
                CambiarTamanoFuente(frm, tamanoFuente);
            }
        }

        // Evento para aplicar el tamaño al cambiar el valor del TextBox
        private void txtTamanoFuente_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(txtTamanoFuente.Text, out float tamanoFuente))
            {
                AplicarTamanoFuente(tamanoFuente);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para el tamaño de la fuente.",
                                "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para aplicar el tamaño al cambiar el valor del TrackBar
        private void trackBarTamanoFuente_Scroll(object sender, EventArgs e)
        {
            float tamanoFuente = trackBarTamanoFuente.Value; // Valor actual de la barra deslizante
            txtTamanoFuente.Text = tamanoFuente.ToString(); // Actualizar el TextBox
            AplicarTamanoFuente(tamanoFuente);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnModoOscuro_Click(object sender, EventArgs e)
        {
            isDarkMode = true;
            AplicarTema();
        }

        private void btnModoClaro_Click(object sender, EventArgs e)
        {
            isDarkMode = false;
            AplicarTema();
        }




        private void AplicarTema()
        {
            // Cambiar el color de fondo de la ventana principal (frmSistema)
            this.BackColor = isDarkMode ? Color.Black : Color.White;

            // Cambiar el color de texto de los elementos del menú
            foreach (ToolStripMenuItem menuItem in menuStrip2.Items)
            {
                menuItem.ForeColor = isDarkMode ? Color.White : Color.Black;
            }

            // Cambiar el color de fondo y texto de cada formulario hijo (MDI) incluyendo el formulario actual
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmCliente || frm is frmTecnico || frm is frmMovil || frm is frmReparaciones)
                {
                    frm.BackColor = isDarkMode ? Color.Black : Color.White;

                    // Cambiar colores de Labels, GroupBox y otros controles
                    CambiarColoresControles(frm.Controls);
                }
            }

            // También se aplica al propio formulario (frmSistema)
            CambiarColoresControles(this.Controls);
        }

        private void CambiarColoresControles(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is Label lbl)
                {
                    // Cambiar el color de texto de los Labels
                    lbl.ForeColor = isDarkMode ? Color.White : Color.Black;
                    lbl.Font = new Font(lbl.Font, FontStyle.Bold); // Opcional: texto en negrita
                }
                else if (ctrl is GroupBox groupBox)
                {
                    // Cambiar el color de texto de los títulos de los GroupBox
                    groupBox.ForeColor = isDarkMode ? Color.White : Color.Black;

                    // Recorrer los controles internos del GroupBox
                    CambiarColoresControles(groupBox.Controls);
                }
                else if (ctrl is TextBox textBox)
                {
                    // Cambiar el fondo y texto de los TextBox
                    textBox.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
                    textBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (ctrl is ComboBox comboBox)
                {
                    // Cambiar el fondo y texto de los ComboBox
                    comboBox.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
                    comboBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                // Si el control contiene otros controles, llamamos recursivamente
                if (ctrl.HasChildren)
                {
                    CambiarColoresControles(ctrl.Controls);
                }
            }
        }

        private void InitializeLanguageSupport()
        {
            translations = new Dictionary<string, Dictionary<string, string>>
    {
        {
            "Español", new Dictionary<string, string>
            {

                { "lblTitulo", "Sistema de Gestión" },
                { "lblID", "ID Cliente" },
                { "lblNombre", "Nombre completo" },
                { "lblEmail", "Correo Electrónico" },
                { "lblTelefono", "Telefono" },
                { "lblOpciones", "Opciones" },
                { "lblEncabezado", "Encabezado Principal" },
                { "lblConsultarEstadoMovil", "Consultar estado de móvil" },
                { "lblCedulaCliente2", "Cédula" },
                { "lblCedulaCliente", "Cédula del Cliente" },
                { "lblIdTecnico", "ID Técnico" },
                { "lblCedulaTecnico", "Cédula del Técnico" },
                { "lblNombreCompletoTecnico", "Nombre completo del Técnico" },
                { "lblEmailTecnico", "Correo Técnico" },
                { "lblTelefonoTecnico", "Teléfono Técnico" },
                { "lblIdEquipo", "ID Equipo" },
                { "lblEstado", "Estado" },
                { "lblIdReparacion", "ID Reparación" },
                { "lblDescripcion", "Descripción" },
                { "lblCosto", "Costo" },
                { "lblNovedad", "Novedad" },
                { "lblFecha_ingreso", "Fecha de Ingreso" },
                { "lblFecha_ingreso2", "Fecha de Ingreso Adicional" },
                { "lblFechaEntrega", "Fecha de Entrega" },
                { "lblCedulaClienteExistente", "Cliente Existente" },
                { "lblCedulaTecnicoExistente", "Técnico Existente" },
                { "lblSeleccionarMovilExistente", "Seleccionar Móvil Existente" },
                { "lblDescripcionMovil", "Descripción del Móvil" },
                { "lblPrecio", "Precio" },
                { "lblCantidad", "Cantidad" },
                { "lblNombreRepuesto", "Nombre del Repuesto" },
                { "lblTotalPagar", "Total a Pagar" },
                { "lblCambiarTamanhoFuente", "Cambiar el tamaño de fuente" },
                { "lblIdiomas", "Idiomas" },
                { "lblIVA", "IVA" },

                { "btnModoOscuro", "Modo Oscuro" },
                { "btnModoClaro", "Modo Claro" },
                { "lblSubtotal", "Subtotal" },
                { "lblIdRepuesto", "ID Repuesto" },
                { "btnNuevo", "Nuevo" },
                { "btnEliminar", "Eliminar" },
                { "btnGrabar", "Grabar" },
                { "btnNuevoMovil", "Registrar movil" },
                  { "btnMostrarFactura", "Mostrar factura" },

                                  { "BtnNuevo", "Nuevo" },
                                { "BtnGrabar", "Grabar" },
                 { "btnActu", "Actualizar" },
                  { "BtnEliminar", "Eliminar" },
                                    { "btnNuevoRepuesto", "Nuevo" },
                                                { "btnEliminarRepuesto", "Eliminar" },
                { "btnGrabarRepuesto", "Añadir" },

                 { "btnAgregarTecnico", "Agregar" },
                                  { "btnDesasignarTecnico", "Quitar" },
                 { "btnBuscar", "Buscar" },


            }
        },
        {
            "Inglés", new Dictionary<string, string>
            {
                { "btnMostrarFactura", "Show invoice" },
                { "btnNuevoMovil", "New movile" },

                { "lblTitulo", "Management System" },
                { "lblID", "Client ID" },
                { "lblNombre", "Full Name" },
                { "lblEmail", "Email" },
                { "lblOpciones", "Options" },
                { "lblEncabezado", "Main Header" },
                { "lblConsultarEstadoMovil", "Check Mobile Status" },
                { "lblTelefono", "Phone" },
                { "lblCedulaCliente2", "ID Card" },
                { "lblCedulaCliente", "Client ID Card" },
                { "lblIdTecnico", "Technician ID" },
                { "lblCedulaTecnico", "Technician ID Card" },
                { "lblNombreCompletoTecnico", "Technician Full Name" },
                { "lblEmailTecnico", "Technician Email" },
                { "lblTelefonoTecnico", "Technician Phone" },
                { "lblIdEquipo", "Equipment ID" },
                { "lblEstado", "Status" },
                { "lblIdReparacion", "Repair ID" },
                { "lblDescripcion", "Description" },
                { "lblCosto", "Cost" },
                { "lblFecha_ingreso", "Entry Date" },
                { "lblFecha_ingreso2", "Additional Entry Date" },
                { "lblFechaEntrega", "Delivery Date" },
                { "lblCedulaClienteExistente", "Existing Client" },
                { "lblCedulaTecnicoExistente", "Existing Technician" },
                { "lblSeleccionarMovilExistente", "Select Existing Mobile" },
                { "lblDescripcionMovil", "Mobile Description" },
                { "lblPrecio", "Price" },
                { "lblCantidad", "Quantity" },
                { "lblNombreRepuesto", "Spare Part Name" },
                { "lblTotalPagar", "Total Payment" },
                { "lblIVA", "Tax (VAT)" },
                { "lblSubtotal", "Subtotal" },
                { "lblIdRepuesto", "Spare Part ID" },
                 { "lblCambiarTamanhoFuente", "Change font size" },
                 { "lblIdiomas", "Languages" },

                { "lblNovedad", "Novelty" },
                                { "btnNuevo", "New" },
                { "btnEliminar", "Delete" },
                { "btnGrabar", "Record" },
                { "btnModoOscuro", "Dark mode" },
                { "btnModoClaro", "Clear mode" },

               { "BtnNuevo", "New" },
                                { "BtnGrabar", "Keep" },
                 { "btnActu", "update" },
                  { "BtnEliminar", "Delete" },
                  { "btnNuevoRepuesto", "New" },
                                                { "btnEliminarRepuesto", "Delete" },
                { "btnGrabarRepuesto", "Add" },

                 { "btnAgregarTecnico", "Add" },
                  { "btnDesasignarTecnico", "Remove" },
                   { "btnBuscar", "Search" },




            }
        },
        {
            "Portugués", new Dictionary<string, string>
            {
                { "lblTitulo", "Sistema de Gestão" },
                { "lblID", "ID do Cliente" },
                { "lblNombre", "Nome completo" },
                { "lblEmail", "E-mail" },
                { "lblOpciones", "Opções" },
                { "lblEncabezado", "Cabeçalho Principal" },
                { "lblConsultarEstadoMovil", "Consultar estado do móvel" },
                { "lblCedulaCliente2", "Cédula" },
                { "lblCedulaCliente", "Cédula do Cliente" },
                { "lblIdTecnico", "ID do Técnico" },
                { "lblCedulaTecnico", "Cédula do Técnico" },
                { "lblNombreCompletoTecnico", "Nome completo do Técnico" },
                { "lblEmailTecnico", "E-mail do Técnico" },
                { "lblTelefonoTecnico", "Telefone do Técnico" },
                { "lblTelefono", "Telefone" },
                { "lblIdEquipo", "ID do Equipamento" },
                { "lblEstado", "Estado" },
                { "lblIdReparacion", "ID do Reparação" },
                { "lblDescripcion", "Descrição" },
                { "lblCosto", "Custo" },
                { "lblFecha_ingreso", "Data de Entrada" },
                { "lblFecha_ingreso2", "Data de Entrada Adicional" },
                { "lblFechaEntrega", "Data de Entrega" },
                { "lblCedulaClienteExistente", "Cliente Existente" },
                { "lblCedulaTecnicoExistente", "Técnico Existente" },
                { "lblSeleccionarMovilExistente", "Selecionar Móvel Existente" },
                { "lblDescripcionMovil", "Descrição do Móvel" },
                { "lblPrecio", "Preço" },
                                { "btnNuevo", "Novo" },

                                                { "btnEliminar", "Excluir" },
                { "btnGrabar", "Grabar" },
                { "btnModoOscuro", "Modo Escuro" },
                { "btnModoClaro", "Modo Claro" },
                { "lblCantidad", "Quantidade" },
                { "lblNombreRepuesto", "Nome da Peça de Reposição" },
                { "lblTotalPagar", "Total a Pagar" },
                { "lblIVA", "Imposto (IVA)" },
                { "lblSubtotal", "Subtotal" },
                 { "lblCambiarTamanhoFuente", " Alterar tamanho da fonte" },
                { "lblIdiomas", "Idiomas" },
                { "lblIdRepuesto", "ID da Peça de Reposição" },
                { "lblNovedad", "Novidade" },

                { "BtnNuevo", "Novo" },
                                { "BtnGrabar", "Grabar" },
                 { "btnActu", "Atualizar" },
                  { "BtnEliminar", "Eliminar" },
                 { "btnMostrarFactura", "mostrar fatura" },


                  { "btnNuevoRepuesto", "Novo" },

                                                { "btnEliminarRepuesto", "Excluir" },
                { "btnGrabarRepuesto", "Adicionar" },
                { "btnAgregarTecnico", "adicionar" },
                  { "btnDesasignarTecnico", "remover" },
                                     { "btnBuscar", "Pesquisar" },



            }
        }
    };
        }
        private void ApplyTranslationsToControls(Control.ControlCollection controls, Dictionary<string, string> languageStrings)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is Label label && languageStrings.ContainsKey(label.Name))
                {
                    label.Text = languageStrings[label.Name];
                }
                else if (ctrl is Button button && languageStrings.ContainsKey(button.Name))
                {
                    button.Text = languageStrings[button.Name];
                }

                if (ctrl.HasChildren)
                {
                    ApplyTranslationsToControls(ctrl.Controls, languageStrings);
                }
            }
        }
        private void ApplyTranslationsToAllForms(Dictionary<string, string> languageStrings)
        {
            ApplyTranslationsToControls(this.Controls, languageStrings);

            foreach (Form frm in this.MdiChildren)
            {
                ApplyTranslationsToControls(frm.Controls, languageStrings);
            }
        }
        private void cbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idiomaSeleccionado = cbIdioma.SelectedItem.ToString();

            if (translations.ContainsKey(idiomaSeleccionado))
            {
                var languageStrings = translations[idiomaSeleccionado];

                ApplyTranslationsToAllForms(languageStrings);
            }
            else
            {
                MessageBox.Show("Idioma no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirFormularioConProgressBar(string formName)
        {
            ProgressBar progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                Dock = DockStyle.Bottom,
                Height = 30,
                Value = 0
            };

            this.Controls.Add(progressBar);
            progressBar.BringToFront();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval = 2000 //2 segundos
            };

            timer.Tick += (s, e) =>
            {
                timer.Stop(); // Detenemos el timer
                this.Controls.Remove(progressBar); // Eliminamos la ProgressBar

                AbrirFormulario(formName);
            };

            timer.Start();
        }


        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioConProgressBar("frmCliente");
            pictureBox2.Visible = false;
        }

        private void rEPARACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioConProgressBar("frmReparaciones");
            pictureBox2.Visible = false;
        }

        private void tECNICOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularioConProgressBar("frmTecnico");
            pictureBox2.Visible = false;

        }

        private void mOVILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioConProgressBar("frmMovil");
            pictureBox2.Visible = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (pictureBox2.Visible)
            {
                pictureBox2.Visible = false; // Ocultar la imagen si ya está visible
            }
            else
            {
                pictureBox2.Visible = true; // Mostrar la imagen si no está visible
            }
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            /*
            string imagePath = @"Resources\logoz.png"; 
            pictureBox2.Image = Image.FromFile(imagePath); 
            */
            pictureBox2.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAccesibilidad_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /*
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Ruta relativa
            string imagePath = "Resources/informa.jpg";
            pictureBox2.Image = Image.FromFile(imagePath);

            this.Close();
        }
        */
        /*
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta relativa al directorio de salida
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "informa.jpg");

                // Verifica si el archivo existe
                if (File.Exists(imagePath))
                {
                    pictureBox2.Image = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show($"El archivo de imagen no se encontró en: {imagePath}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Opcional: Establece una imagen predeterminada o deja el PictureBox vacío
                    pictureBox2.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al cargar la imagen: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void flecha_Click(object sender, EventArgs e)
        {
            bool isVisible = menuStrip3.Visible || panel1.Visible; // Verifica si alguno está visible

            menuStrip3.Visible = !isVisible; // Alterna visibilidad del menuStrip3
            panel1.Visible = !isVisible;
        }

        private void menuStrip3_Click(object sender, EventArgs e)
        {

        }
    }



}



