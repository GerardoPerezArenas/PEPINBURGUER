using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Xamarin.Forms;
using RestApp.Modelo;
using RestApp.Servicio;
using System.Threading.Tasks;
namespace RestApp.VistaModelo
{
   public class VMproductos
    {
        public async Task<List<Mproductos>> MostrarProductos(int Idgrupo)
        {
            var productos = new List<Mproductos>();
            try
            {
                var dt = new DataTable();
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var da = new SqlDataAdapter("mostrar_Productos_por_grupo", conn))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@id_grupo", Idgrupo);
                        da.SelectCommand.Parameters.AddWithValue("@buscador", "");
                        da.Fill(dt);
                    }
                }
                foreach (DataRow rdr in dt.Rows)
                {
                    var parametros = new Mproductos();
                    parametros.Descripcion = rdr["Descripcion"].ToString();
                    parametros.Idproducto = Convert.ToInt32(rdr["Id_Producto1"]);
                    parametros.Precio = (rdr["Id_Producto1"]).ToString()+"|" + (rdr["Precio_de_venta"]).ToString();
                    parametros.ColorHtml = rdr["ColorHtml"].ToString();
                    parametros.ImpresoraDestino = rdr.Table.Columns.Contains("ImpresoraDestino") ? rdr["ImpresoraDestino"].ToString() : "";
                    productos.Add(parametros);
                }
                return productos;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            return null;
        }

        public async Task<List<Mproductos>> buscarProductos(string buscador)
        {
            var productos = new List<Mproductos>();
            try
            {
                var dt = new DataTable();
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var da = new SqlDataAdapter("buscarProductos", conn))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@buscador", buscador);
                        da.Fill(dt);
                    }
                }
                foreach (DataRow rdr in dt.Rows)
                {
                    var parametros = new Mproductos();
                    parametros.Descripcion = rdr["Descripcion"].ToString();
                    parametros.Idproducto = Convert.ToInt32(rdr["Id_Producto1"]);
                    parametros.Precio = (rdr["Id_Producto1"]).ToString() + "|" + (rdr["Precio_de_venta"]).ToString();
                    parametros.ColorHtml = rdr["ColorHtml"].ToString();
                    parametros.ImpresoraDestino = rdr.Table.Columns.Contains("ImpresoraDestino") ? rdr["ImpresoraDestino"].ToString() : "";
                    productos.Add(parametros);
                }
                return productos;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            return null;
        }

    }
}
