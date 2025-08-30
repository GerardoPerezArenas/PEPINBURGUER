using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestApp.VistaModelo;
using System.Data;
using RestApp.Modelo;

namespace RestApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mesas : ContentPage
    {
        public Mesas()
        {
            InitializeComponent();
            _ = dibujarSalones();

        }
        int idsalon=0;
        public static int idusuario;
        int idmesa;
        protected override async void OnAppearing()
        {
            await dibujarMesasPorSalon();
        }
        public async Task dibujarSalones()
        {
            VMsalon funcion = new VMsalon();
            var dt = await funcion.dibujarsalones();
            foreach (DataRow rdr in dt.Rows)
            {
                Button b = new Button();
                b.Text = rdr["Salon"].ToString();
                b.CommandParameter = rdr["Id_salon"].ToString();
                b.HeightRequest = 50;
                b.WidthRequest = 150;
                b.BackgroundColor = Color.FromRgb(39, 20, 2);
                b.BorderWidth = 2;
                b.CornerRadius = 5;
                b.BorderColor= Color.FromRgb(248, 133, 18);
                b.TextColor = Color.White;
                PanelSalones.Children.Add(b);
                b.Clicked += B_Clicked;
            }
        }
        
        private async void B_Clicked(object sender, EventArgs e)
        {
            idsalon = Convert.ToInt32(((Button)sender).CommandParameter);
            await dibujarMesasPorSalon();
        }
        public async Task dibujarMesasPorSalon()
        {
            PanelMesas.Children.Clear();
            Msalon parametros = new Msalon();
            VMmesas funcion = new VMmesas();
            parametros.Id_salon = idsalon;
            DataTable dt = await funcion.dibujarMesasPorSalon(parametros);

            foreach (DataRow rdr in dt.Rows)
            {
                string estado;
                Button b = new Button();
                b.Text = rdr["Mesa"].ToString();
                b.HeightRequest = 200;
                b.WidthRequest = 200;
                b.FontSize = 20;
                b.FontAttributes = FontAttributes.Bold;
                b.CommandParameter = rdr["Id_mesa"].ToString();
                estado = rdr["Estado_de_Disponibilidad"].ToString();
                if (estado == "LIBRE")
                {
                    b.BackgroundColor = Color.FromRgb(197, 255, 145);
                    b.TextColor = Color.Black;
                }
                else
                {
                    b.BackgroundColor = Color.FromRgb(255, 45, 54);
                    b.TextColor = Color.White;
                }
              
                Frame frameBoton = new Frame();
                frameBoton.Content = b;
                frameBoton.Margin = 5;
                frameBoton.Padding = -5;
                frameBoton.HeightRequest = b.HeightRequest;
                frameBoton.WidthRequest = b.WidthRequest;
                frameBoton.CornerRadius = 5;
                frameBoton.HasShadow = true;
                PanelMesas.Children.Add(frameBoton);
                b.Clicked += B_Clicked1;
            }
        }

        private void B_Clicked1(object sender, EventArgs e)
        {
            idmesa = Convert.ToInt32(((Button)sender).CommandParameter);
            Ventas.Idusuario = idusuario;
            Ventas.idmesa = idmesa;
            Navigation.PushAsync(new Ventas());
        }
    }
}