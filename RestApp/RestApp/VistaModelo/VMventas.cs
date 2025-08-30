using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RestApp.Modelo;
using RestApp.Servicio;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace RestApp.VistaModelo
{
  public class VMventas
    {
        private async Task<int> ObtenerIdCajaremota()
        {
            var funcion = new VMmovcaja();
            return await funcion.mostrarCajaRemota();
        }

        public async Task<int> mostrarIdventaMesa(Mventas parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("mostrarIdventaMesa", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_mesa", parametros.Idmesa);
                        var result = await cmd.ExecuteScalarAsync();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<bool> Insertar_ventas(Mventas parametros)
        {
            try
            {
                var idmovcajaRemota = await ObtenerIdCajaremota();
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("Insertar_ventas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fecha_venta", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Id_usuario", parametros.Idusuario);
                        cmd.Parameters.AddWithValue("@Nombrellevar", "-");
                        cmd.Parameters.AddWithValue("@Idmovcaja", idmovcajaRemota);
                        cmd.Parameters.AddWithValue("@Id_mesa", parametros.Idmesa);
                        cmd.Parameters.AddWithValue("@Numero_personas", 1);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return false;
            }
        }

        public async Task<bool> eliminarVenIncomMovil(Mventas parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("eliminarVenIncomMovil", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Idmesa", parametros.Idmesa);
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

        public async Task<bool> eliminarVenta(Mventas parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("eliminarVenta", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Idventa", parametros.Idventa);
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

        public async Task<bool> EditarEstadoVentasEspera(Mventas parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("EditarEstadoVentasEspera", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idventa", parametros.Idventa);
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
