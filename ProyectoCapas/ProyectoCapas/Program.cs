
using CapaPresentacion;
/**
 * NOMBRE: 
 * CASTILLO MEREJILDO JOSHUA JAVIER
 * VERA CHUQUIMARCA LESLIE ARIANA
 * PARRA AGUAYO KEVIN
 * FECHA: 09/01/2025
 * VERSION: 2.0
 * PROGRAMACION ORIENTADA A EVENTOS
 * SOF-S-VE-5-10

 * 
 * 
 */
namespace ProyectoCapas
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
        }
    }
}