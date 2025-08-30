using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using Xamarin.Forms;

namespace RestApp.Servicio
{
   public  class CONEXIONMAESTRA
    {
        public static string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "connection.txt");
        static string parte1 = "Data source =";
        static string parte2 = ";Initial Catalog=BASEBRIRESTCSHARP;Integrated Security=false;User Id=buman;Password=softwarereal";
        public static string conexion
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("server_ip"))
                {
                    var ip = Application.Current.Properties["server_ip"].ToString();
                    return parte1 + ip + parte2;
                }
                if (File.Exists(ruta))
                {
                    return File.ReadAllText(ruta);
                }
                return string.Empty;
            }
        }
        public static SqlConnection conectar = new SqlConnection(conexion);

        public static void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
        public static void cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}

