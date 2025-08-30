using RestApp.Modelo;
using RestApp.Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace RestApp.VistaModelo
{
    public class VMusuarios
    {
        public async Task<DataTable> dibujarUsuarios()
        {
            var dt = new DataTable();
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var da = new SqlDataAdapter("Select * from Usuarios where Estado='ACTIVO'", conn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            return dt;
        }

        public async Task<int> validarUsuario(Musuarios parametros)
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("validarUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@password", parametros.Password);
                        cmd.Parameters.AddWithValue("@login", parametros.Login);
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

        public async Task<int> ComprobarConexion()
        {
            try
            {
                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "connection.txt");
                string text = File.ReadAllText(ruta);
                using (var conectar = new SqlConnection(text))
                {
                    await conectar.OpenAsync();
                    using (var da = new SqlCommand("Select Top 1 IdUsuario from Usuarios", conectar))
                    {
                        var result = await da.ExecuteScalarAsync();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
