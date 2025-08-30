using System;

using System.Collections.Generic;
using System.Text;
using RestApp.Modelo;
using System.Data;
using System.Data.SqlClient;
using Xamarin.Forms;
using RestApp.Servicio;
using System.Threading.Tasks;
namespace RestApp.VistaModelo
{
    public class VMdetalleventa
    {
        public async Task<bool> insertarDetalle_venta(Mdetalleventa parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("insertarDetalle_venta", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idventa", parametros.idventa);
                        cmd.Parameters.AddWithValue("@Id_producto", parametros.Id_producto);
                        cmd.Parameters.AddWithValue("@cantidad", parametros.cantidad);
                        cmd.Parameters.AddWithValue("@preciounitario", parametros.preciounitario);
                        cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                        cmd.Parameters.AddWithValue("@Costo", parametros.Costo);
                        cmd.Parameters.AddWithValue("@Estado_de_pago", parametros.Estado_de_pago);
                        cmd.Parameters.AddWithValue("@Donde_se_consumira", parametros.Donde_se_consumira);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Mdetalleventa>> MostrarDetalleVenta(Mdetalleventa parametrospedir)
        {
            var productos = new List<Mdetalleventa>();
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("mostrarDetalleVenta", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_mesa", parametrospedir.Idmesa);
                        cmd.Parameters.AddWithValue("@Idventa", parametrospedir.idventa);
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var parametros = new Mdetalleventa();
                                parametros.Producto = reader["Producto"].ToString();
                                parametros.Iddetalleventa = Convert.ToInt32(reader["iddetalle_venta"]);
                                parametros.Importe = Convert.ToDouble(reader["Importe"]);
                                parametros.Total += parametros.Importe;
                                parametros.ImpresoraDestino = reader["ImpresoraDestino"]?.ToString();
                                productos.Add(parametros);
                            }
                        }
                    }
                }
                return productos;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            return null;
        }

        public async Task<bool> eliminarDetalleventa(Mdetalleventa parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("eliminarDetalleventa", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Iddetalle", parametros.Iddetalleventa);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> editarenviadoDV(Mdetalleventa parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("editarAenviado", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Iddetalleventa", parametros.Iddetalleventa);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.StackTrace, "OK");
                return false;
            }
        }

    }
}
