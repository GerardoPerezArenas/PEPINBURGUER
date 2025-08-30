using RestApp.Modelo;
using RestApp.Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace RestApp.VistaModelo
{
    public  class VMgrupos
    {
        public async Task<List<Mgrupos>> mostrarGrupos()
        {
            var grupos = new List<Mgrupos>();
            try
            {
                var dt = new DataTable();
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var da = new SqlDataAdapter("mostrarGruposProd", conn))
                    {
                        da.Fill(dt);
                    }
                }
                foreach (DataRow rdr in dt.Rows)
                {
                    var parametros = new Mgrupos();
                    parametros.Grupo = rdr["Grupo"].ToString();
                    parametros.Idgrupo = Convert.ToInt32(rdr["Idline"]);
                    parametros.ColorHtml = rdr["ColorHtml"].ToString();
                    grupos.Add(parametros);
                }
                return grupos;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.StackTrace, "OK");
            }
            return null;
        }

    }
}
