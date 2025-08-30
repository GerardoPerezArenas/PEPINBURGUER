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
   public  class VMsalon
    {
        public async Task<DataTable> dibujarsalones()
        {
            var dt = new DataTable();
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var da = new SqlDataAdapter("Select * from SALON Where Estado = 'ACTIVO'", conn))
                    {
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
    }
}
