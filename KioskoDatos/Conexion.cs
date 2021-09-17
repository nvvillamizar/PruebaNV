using System;
using System.Data;
using System.Data.SqlClient;

namespace KioskoDatos
{
    public class Conexion
    {
        public Conexion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = AsignarCadenaConexion();
                    con.Open();
                    if (con.State != ConnectionState.Open)
                        throw new Exception("Error al conectar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AsignarCadenaConexion()
        {
            return "Server=PCNVILLAMIZAR\\SQLEXPRESS;Database=Kiosko;User Id=sa;Password=1234; Trusted_Connection=True; MultipleActiveResultSets=true;";
        }
    }
}
