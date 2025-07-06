using CapaDatos.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using System.IO;
using System.Diagnostics;

namespace CapaNegocio
{
    public class CL_Factura
    {
        private CL_InterfaceFactura obj_factura = new CL_InterfaceFactura();
        public string Tecnicos { get; set; }

        public CL_Factura()
        {
            Tecnicos = string.Empty;
        }
        public DataTable ObtenerFacturas()
        {
            return obj_factura.GetAllFacturas();
        }
        public DataTable ObtenerFacturasPorCedula(string cedulaCliente, int pagina, int facturasPorPagina)
        {
            return obj_factura.GetFacturasPorCedula(cedulaCliente, pagina, facturasPorPagina);
        }

        // Método para obtener el total de facturas
        public int ObtenerTotalFacturas(string cedulaCliente)
        {
            return obj_factura.ObtenerTotal(cedulaCliente);
        }

        // Método para obtener todas las facturas
        public DataTable ObtenerFacturas(string cedulaCliente)
        {
            return obj_factura.GetFactura(cedulaCliente);
        }

        public bool ExisteFactura(int idReparacion)
        {
            return obj_factura.ExisteFactura(idReparacion);
        }

        public bool ActualizarFactura(int idFactura, string nuevosTecnicos, string cedula_cliente, string nombre_cliente, string telefono_cliente, string email_cliente,
                                       string imei_celular, string descripcion_equipo, string estado, string descripcion_reparacion, decimal costo, string fecha_entrega)
        {
            // Llamada al método de la clase obj_factura que actualizará la factura
            return obj_factura.ActualizarFactura(idFactura, nuevosTecnicos, cedula_cliente, nombre_cliente, telefono_cliente, email_cliente,
                                                 imei_celular, descripcion_equipo, estado, descripcion_reparacion, costo, fecha_entrega);
        }



        public bool GenerarFactura(string cedulaCliente, int idEquipo)
        {
            return obj_factura.InsertarFactura(cedulaCliente, idEquipo);
        }

        public (bool success, string message, string fileName) GenerarPDF(DataRow factura)
        {
            try
            {
                // Crear un documento PDF
                string nombreArchivo = $"Factura_{factura["id_factura"]}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                
                using (PdfWriter writer = new PdfWriter(nombreArchivo))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    // Título
                    Paragraph titulo = new Paragraph("FACTURA DE REPARACIÓN")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(16)
                        .SetBold()
                        .SetFontColor(ColorConstants.DARK_GRAY);
                    document.Add(titulo);

                    // Información empresa
                    Paragraph empresa = new Paragraph("SERVICIO TÉCNICO MÓVIL\nTel: (123) 456-7890 | Email: info@serviciotecnico.com")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(12);
                    document.Add(empresa);

                    document.Add(new Paragraph("\n"));

                    // Información de la factura
                    Table tablaFactura = new Table(2).UseAllAvailableWidth();
                    tablaFactura.AddCell(new Cell().Add(new Paragraph("Número de Factura:").SetBold()));
                    tablaFactura.AddCell(new Cell().Add(new Paragraph(factura["id_factura"].ToString())));
                    tablaFactura.AddCell(new Cell().Add(new Paragraph("Fecha:").SetBold()));
                    tablaFactura.AddCell(new Cell().Add(new Paragraph(DateTime.Now.ToString("dd/MM/yyyy"))));
                    document.Add(tablaFactura);

                    document.Add(new Paragraph("\n"));

                    // Información del cliente
                    Paragraph tituloCliente = new Paragraph("INFORMACIÓN DEL CLIENTE")
                        .SetBold()
                        .SetFontSize(14);
                    document.Add(tituloCliente);

                    Table tablaCliente = new Table(2).UseAllAvailableWidth();
                    tablaCliente.AddCell(new Cell().Add(new Paragraph("Cédula:").SetBold()));
                    tablaCliente.AddCell(new Cell().Add(new Paragraph(factura["cedula_cliente"].ToString())));
                    tablaCliente.AddCell(new Cell().Add(new Paragraph("Nombre:").SetBold()));
                    tablaCliente.AddCell(new Cell().Add(new Paragraph(factura["nombre_cliente"].ToString())));
                    tablaCliente.AddCell(new Cell().Add(new Paragraph("Teléfono:").SetBold()));
                    tablaCliente.AddCell(new Cell().Add(new Paragraph(factura["telefono_cliente"].ToString())));
                    tablaCliente.AddCell(new Cell().Add(new Paragraph("Email:").SetBold()));
                    tablaCliente.AddCell(new Cell().Add(new Paragraph(factura["email_cliente"].ToString())));
                    document.Add(tablaCliente);

                    document.Add(new Paragraph("\n"));

                    // Información del equipo
                    Paragraph tituloEquipo = new Paragraph("INFORMACIÓN DEL EQUIPO")
                        .SetBold()
                        .SetFontSize(14);
                    document.Add(tituloEquipo);

                    Table tablaEquipo = new Table(2).UseAllAvailableWidth();
                    tablaEquipo.AddCell(new Cell().Add(new Paragraph("IMEI:").SetBold()));
                    tablaEquipo.AddCell(new Cell().Add(new Paragraph(factura["imei_celular"].ToString())));
                    tablaEquipo.AddCell(new Cell().Add(new Paragraph("Descripción:").SetBold()));
                    tablaEquipo.AddCell(new Cell().Add(new Paragraph(factura["descripcion_equipo"].ToString())));
                    tablaEquipo.AddCell(new Cell().Add(new Paragraph("Estado:").SetBold()));
                    tablaEquipo.AddCell(new Cell().Add(new Paragraph(factura["estado"].ToString())));
                    document.Add(tablaEquipo);

                    document.Add(new Paragraph("\n"));

                    // Detalles de la reparación
                    Paragraph tituloReparacion = new Paragraph("DETALLES DE LA REPARACIÓN")
                        .SetBold()
                        .SetFontSize(14);
                    document.Add(tituloReparacion);

                    Table tablaReparacion = new Table(2).UseAllAvailableWidth();
                    tablaReparacion.AddCell(new Cell().Add(new Paragraph("Descripción:").SetBold()));
                    tablaReparacion.AddCell(new Cell().Add(new Paragraph(factura["descripcion_reparacion"].ToString())));

                    if (factura.Table.Columns.Contains("tecnicos"))
                    {
                        tablaReparacion.AddCell(new Cell().Add(new Paragraph("Técnico(s):").SetBold()));
                        tablaReparacion.AddCell(new Cell().Add(new Paragraph(factura["tecnicos"].ToString())));
                    }

                    tablaReparacion.AddCell(new Cell().Add(new Paragraph("Fecha de Entrega:").SetBold()));
                    tablaReparacion.AddCell(new Cell().Add(new Paragraph(factura["fecha_entrega"].ToString())));
                    document.Add(tablaReparacion);

                    document.Add(new Paragraph("\n"));

                    // Costo total
                    Paragraph costo = new Paragraph($"COSTO TOTAL: ${Convert.ToDecimal(factura["costo"]):F2}")
                        .SetBold()
                        .SetFontSize(16)
                        .SetTextAlignment(TextAlignment.CENTER);
                    document.Add(costo);

                    document.Add(new Paragraph("\n"));

                    // Pie de página
                    Paragraph footer = new Paragraph("¡Gracias por confiar en nuestro servicio!")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(12);
                    document.Add(footer);
                }

                return (true, "Factura PDF generada exitosamente.", nombreArchivo);
            }
            catch (Exception ex)
            {
                return (false, $"Error al generar el PDF: {ex.Message}", null);
            }
        }

        public (bool success, string message) AbrirPDF(string idFactura)
        {
            // Buscar cualquier archivo PDF de la factura
            string[] archivos = Directory.GetFiles(".", $"Factura_{idFactura}_*.pdf");
            
            if (archivos.Length > 0)
            {
                try
                {
                    System.Diagnostics.Process.Start(archivos[0]);
                    return (true, "PDF abierto exitosamente.");
                }
                catch (Exception ex)
                {
                    return (false, $"Error al abrir el PDF: {ex.Message}");
                }
            }
            else
            {
                return (false, "El archivo PDF no existe. Primero debe generar el reporte.");
            }
        }
    }
}