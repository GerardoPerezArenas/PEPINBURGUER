using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidodeIp : ContentPage
    {
        public PedidodeIp()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("server_ip"))
            {
                Application.Current.MainPage = new NavigationPage(new Login());
            }
        }
        string ruta;
        string cadena_de_conexion;
        string parte1 = "Data source =";
        string parte2 = ";Initial Catalog=BASEBRIRESTCSHARP;Integrated Security=false;User Id=buman;Password=softwarereal";
        int Idusuario;

        private void btnconectar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtconexion.Text))
            {
                probarconexion();
                ValidarConexion();
            }
            else
            {
                DisplayAlert("Ingrese la conexion", "Sin datos", "OK");
            }
        }
        private async void ValidarConexion()
        {
            if (Idusuario > 0)
            {
                await crear_archivo();
                await DisplayAlert("!Listo!", "Vuelva a abrir la aplicacion", "OK");
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
            else
            {
                await DisplayAlert("Sin conexion", "No se logro conectar al servidor", "OK");
            }
        }
        private async Task crear_archivo()
        {
            var nuevaIp = txtconexion.Text;
            if (Application.Current.Properties.ContainsKey("server_ip") &&
                Application.Current.Properties["server_ip"].ToString() == nuevaIp)
            {
                return;
            }

            Application.Current.Properties["server_ip"] = nuevaIp;
            await Application.Current.SavePropertiesAsync();

            ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "connection.txt");
            try
            {
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                using (var sw = File.CreateText(ruta))
                {
                    sw.WriteLine(parte1 + nuevaIp + parte2);
                }
            }
            catch (Exception)
            {
            }

        }
        private void probarconexion()
        {

            cadena_de_conexion = parte1 + txtconexion.Text + parte2;
            try
            {
                SqlConnection conexionManual = new SqlConnection(cadena_de_conexion);
                conexionManual.Open();
                SqlCommand cmd = new SqlCommand("Select Top 1 IdUsuario from Usuarios", conexionManual);
                Idusuario = Convert.ToInt32(cmd.ExecuteScalar());
                conexionManual.Close();
            }
            catch (Exception)
            {
                Idusuario = 0;
            }
        }

    }
}