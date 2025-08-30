using RestApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Presentacion : ContentPage
    {
        public Presentacion()
        {
            InitializeComponent();
            _ = animacion();
        }
        int iduser=0;
        private async Task animacion()
        {
            Logo.Opacity = 0;
            await Logo.FadeTo(1, 2000);
            await ProbarConexion();
            //Application.Current.MainPage =new NavigationPage(new Login());
        }
        private async Task ProbarConexion()
        {
            try
            {
                var funcion = new VMusuarios();
                iduser = await funcion.ComprobarConexion();
            }
            catch (Exception)
            {
                iduser = 0;
            }
            if (iduser > 0)
            {
                Application.Current.MainPage = new NavigationPage(new Login());
            }
            else
            {
                Application.Current.MainPage = (new PedidodeIp());
            }
        }
    }
}