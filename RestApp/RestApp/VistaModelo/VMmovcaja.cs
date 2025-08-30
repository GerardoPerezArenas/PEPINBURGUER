using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RestApp.Servicio;
using System.Threading.Tasks;
namespace RestApp.VistaModelo
{
  public class VMmovcaja
    {
        public async Task<int> mostrarCajaRemota()
        {
            try
            {
                using (var conn = CONEXIONMAESTRA.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("mostrarMovCajaremota", conn))
                    {
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
    }
}
