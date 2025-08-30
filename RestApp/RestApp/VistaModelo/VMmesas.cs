using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xamarin.Forms;
using System.Data.SqlClient;
using System.Data;
using RestApp.Servicio;
using RestApp.Modelo;
using System.Threading.Tasks;

namespace RestApp.VistaModelo
{
    public class VMmesas
    {
        public async Task<DataTable> dibujarMesasPorSalon(Msalon parametros)
        {
            var dt = new DataTable();
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var da = new SqlDataAdapter("mostrar_mesas_por_salon_ventas", conn))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@id_salon", parametros.Id_salon);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.StackTrace, "Ok");
            }
            return dt;
        }

        public async Task<bool> EditarEstadoMesaOcupado(Mmesas parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("EditarEstadoMesaOcupado", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Idmesa", parametros.Id_mesa);
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

        public async Task<bool> EditarEstadoMesaLibre(Mmesas parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("EditarEstadoMesaLibre", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Idmesa", parametros.Id_mesa);
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
