using RestApp.Modelo;
using RestApp.VistaModelo;
using RestApp.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;

namespace RestApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ventas : ContentPage
    {
        public Ventas()
        {
            InitializeComponent();
            _ = mostrarGrupos();
            _ = EliVentasIncompMovil();
            _ = VerificarVentas();

            if (Application.Current.Properties.ContainsKey("ImpresoraBebidas"))
            {
                txtImpresoraBebidas.Text = Application.Current.Properties["ImpresoraBebidas"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("ImpresoraComidas"))
            {
                txtImpresoraComidas.Text = Application.Current.Properties["ImpresoraComidas"].ToString();
            }
        }

        protected override async void OnAppearing()
        {
            if (estadoAutomatico == true)
            {
                await InsertarVentas();
                await Mostrardetalleventa();
                estadoAutomatico = false;
            }
        }

        public static bool estadoAutomatico = false;

        private async Task VerificarVentas()
        {
            var funcion = new VMventas();
            var parametros = new Mventas();
            parametros.Idmesa = idmesa;
            idventa = await funcion.mostrarIdventaMesa(parametros);
            if (idventa > 0)
            {
                ventagenerada = "VENTA GENERADA";
                btnCerrarMesa.IsVisible = true;
                await Mostrardetalleventa();
            }
            else
            {
                ventagenerada = "VENTA NUEVA";
                btnCerrarMesa.IsVisible = false;
            }
        }

        private async Task EliVentasIncompMovil()
        {
            var funcion = new VMventas();
            var parametros = new Mventas();
            parametros.Idmesa = idmesa;
            await funcion.eliminarVenIncomMovil(parametros);
        }

        int idgrupo;
        public static int Idusuario;
        public static int idmesa;
        public static int idproducto;
        public static double precioventa;
        string ventagenerada;
        int idventa;
        double total = 0;
        int iddetalleventa;
        int contadorDventa = 0;

        private void btnBuscar_Clicked(object sender, EventArgs e)
        {
            estadoAutomatico = false;
            Navigation.PushAsync(new Buscadorproductos());
        }

        private void btnmesas_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnenviar_Clicked(object sender, EventArgs e)
        {
            if (total > 0)
            {
                PrinterService.ImpresoraBebidas = txtImpresoraBebidas.Text;
                PrinterService.ImpresoraComidas = txtImpresoraComidas.Text;
                Application.Current.Properties["ImpresoraBebidas"] = PrinterService.ImpresoraBebidas;
                Application.Current.Properties["ImpresoraComidas"] = PrinterService.ImpresoraComidas;
                await Application.Current.SavePropertiesAsync();
                bool enviado = await EnviarAImpresoras();
                if (enviado)
                {
                    await EditarEstadoVentasEspera();
                    await EditardetalleventaAenviado();
                    await DisplayAlert("Enviado", "Pedido enviado", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo enviar el pedido", "OK");
                }
            }
        }

        private async void btnCerrarMesa_Clicked(object sender, EventArgs e)
        {
            bool confirmacion = await DisplayAlert("Cerrar mesa", "¿Desea cerrar la mesa?", "Sí", "No");
            if (confirmacion)
            {
                await eliminarVenta();
                await LiberarMesa();
                await Navigation.PopAsync();
            }
        }

        private async Task<bool> EnviarAImpresoras()
        {
            var funciondetalle = new VMdetalleventa();
            var parametrosDetalle = new Mdetalleventa();
            parametrosDetalle.idventa = idventa;
            parametrosDetalle.Idmesa = idmesa;
            var detalles = await funciondetalle.MostrarDetalleVenta(parametrosDetalle);

            var grupos = new Dictionary<string, List<Mdetalleventa>>();

            foreach (var det in detalles)
            {
                var destino = det.ImpresoraDestino ?? string.Empty;
                if (!grupos.ContainsKey(destino))
                {
                    grupos[destino] = new List<Mdetalleventa>();
                }
                grupos[destino].Add(det);
            }

            var servicio = new PrinterService();
            foreach (var grupo in grupos)
            {
                var sb = new StringBuilder();
                foreach (var det in grupo.Value)
                {
                    sb.AppendLine(det.Producto);
                }

                string ip = string.Empty;
                if (grupo.Key == "BEBIDAS")
                {
                    ip = PrinterService.ImpresoraBebidas;
                }
                else if (grupo.Key == "COMIDAS")
                {
                    ip = PrinterService.ImpresoraComidas;
                }
                else
                {
                    ip = grupo.Key;
                }

                if (!string.IsNullOrEmpty(ip))
                {
                    var ok = await servicio.SendText(ip, sb.ToString());
                    if (!ok)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private async Task EditardetalleventaAenviado()
        {
            var funcionmostrar = new VMdetalleventa();
            var parametrosmostrar = new Mdetalleventa();
            parametrosmostrar.idventa = idventa;
            parametrosmostrar.Idmesa = idmesa;
            var dt = await funcionmostrar.MostrarDetalleVenta(parametrosmostrar);

            var funcion = new VMdetalleventa();
            var parametros = new Mdetalleventa();
            foreach (var rdr in dt)
            {
                iddetalleventa = Convert.ToInt32(rdr.Iddetalleventa);
                parametros.Iddetalleventa = iddetalleventa;
                await funcion.editarenviadoDV(parametros);
            }
        }

        private async Task EditarEstadoVentasEspera()
        {
            var funcion = new VMventas();
            var parametros = new Mventas();
            parametros.Idventa = idventa;
            await funcion.EditarEstadoVentasEspera(parametros);
        }

        private async Task EditarEstadoMesaOcupado()
        {
            var funcion = new VMmesas();
            var parametros = new Mmesas();
            parametros.Id_mesa = idmesa;
            await funcion.EditarEstadoMesaOcupado(parametros);
        }

        private async Task mostrarGrupos()
        {
            var funcion = new VMgrupos();
            var data = await funcion.mostrarGrupos();
            Listagrupos.ItemsSource = data;
        }

        private async Task MostrarProductos()
        {
            var funcion = new VMproductos();
            var data = await funcion.MostrarProductos(idgrupo);
            ListaProductos.ItemsSource = data;
        }

        private async void btnGrupo_Clicked(object sender, EventArgs e)
        {
            idgrupo = Convert.ToInt32(((Button)sender).CommandParameter);
            await MostrarProductos();
        }

        private async void btnproducto_Clicked(object sender, EventArgs e)
        {
            string cadena = (((Button)sender).CommandParameter).ToString();
            string[] separadas = cadena.Split('|');
            idproducto = Convert.ToInt32(separadas[0]);
            precioventa = Convert.ToDouble(separadas[1]);

            await InsertarVentas();
        }

        private async Task InsertarVentas()
        {
            if (ventagenerada == "VENTA NUEVA")
            {
                var funcion = new VMventas();
                var parametros = new Mventas();
                parametros.Idusuario = Idusuario;
                parametros.Idmesa = idmesa;
                if (await funcion.Insertar_ventas(parametros) == true)
                {
                    await EditarEstadoMesaOcupado();
                    await VerificarVentas();
                }
            }
            if (ventagenerada == "VENTA GENERADA")
            {
                await insertarDetalleventa();
            }
        }

        private async Task insertarDetalleventa()
        {
            var funcion = new VMdetalleventa();
            var parametros = new Mdetalleventa();
            parametros.idventa = idventa;
            parametros.Id_producto = idproducto;
            parametros.cantidad = 1;
            parametros.preciounitario = precioventa;
            parametros.Estado = "PENDIENTE";
            parametros.Costo = 0;
            parametros.Estado_de_pago = "DEBE";
            parametros.Donde_se_consumira = "LOCAL";
            await funcion.insertarDetalle_venta(parametros);
            await Mostrardetalleventa();
        }

        private async Task Mostrardetalleventa()
        {
            var funcion = new VMdetalleventa();
            var parametros = new Mdetalleventa();

            parametros.idventa = idventa;
            parametros.Idmesa = idmesa;
            var data = await funcion.MostrarDetalleVenta(parametros);
            listaDetalleVenta.ItemsSource = data;

            contadorDventa = data.Count;
            total = 0;
            foreach (var item in data)
            {
                total += item.Importe;
            }
            lblTotal.Text = total.ToString();
        }

        private async Task eliminarVenta()
        {
            var funcion = new VMventas();
            var parametros = new Mventas();
            parametros.Idventa = idventa;
            await funcion.eliminarVenta(parametros);
        }

        private async Task LiberarMesa()
        {
            var funcion = new VMmesas();
            var parametros = new Mmesas();
            parametros.Id_mesa = idmesa;
            await funcion.EditarEstadoMesaLibre(parametros);
        }

        private async void btnBorrarDV1_Invoked(object sender, EventArgs e)
        {
            iddetalleventa = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
            await EliminarDetalleventa();
        }

        private async Task EliminarDetalleventa()
        {
            var funcion = new VMdetalleventa();
            var parametros = new Mdetalleventa();
            parametros.Iddetalleventa = iddetalleventa;
            await funcion.eliminarDetalleventa(parametros);
            await Mostrardetalleventa();

            if (contadorDventa == 0)
            {
                await eliminarVenta();
                await LiberarMesa();
                await VerificarVentas();
            }
        }

        private async void btnBorrarDV2_Invoked(object sender, EventArgs e)
        {
            iddetalleventa = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
            await EliminarDetalleventa();
        }
    }
}
