using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestApp.VistaModelo;
using RestApp.Modelo;
namespace RestApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Buscadorproductos : ContentPage
    {
        public Buscadorproductos()
        {
            InitializeComponent();
           
        }
        int idproducto;
        double precioventa;
        private async Task BuscarProductos()
        {
            var funcion = new VMproductos();
            var data = await funcion.buscarProductos(txtbuscar.Text);
            ListaProductos.ItemsSource = data;

        }

        private async void txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            await BuscarProductos();
        }

        private void btnproducto_Clicked(object sender, EventArgs e)
        {
            string cadena = (((Button)sender).CommandParameter).ToString();
            string[] separadas = cadena.Split('|');
            idproducto = Convert.ToInt32(separadas[0]);
            precioventa = Convert.ToDouble(separadas[1]);
            Ventas.idproducto = idproducto;
            Ventas.precioventa = precioventa;
            Ventas.estadoAutomatico = true;    
            Navigation.PopAsync();
        }

        private void btnvolver_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}