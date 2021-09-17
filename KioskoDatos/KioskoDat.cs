using KioskoEntidad;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace KioskoDatos
{
    public class KioskoDat
    {
        public IConfiguration Configuration;

        public Conexion objConexion;

        public List<VKioskoEnt> Listar()
        {
            objConexion = new Conexion();

            var kioskos = new List<VKioskoEnt>();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = objConexion.AsignarCadenaConexion();
                    con.Open();

                    var queryKiosco = new SqlCommand("SELECT Id, Nombre, Descripcion, Estado, correo FROM V_kioscos", con);

                    using (var read = queryKiosco.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            var state = string.Empty;
                            switch (Convert.ToInt32(read["Estado"].ToString()))
                            {
                                case 1:
                                    state = "Activo";
                                    break;

                                case 2:
                                    state = "Cancelado";
                                    break;

                                case 3:
                                    state = "Suspendido";
                                    break;

                                default:
                                    state = "Sin estado";
                                    break;
                            }

                            var kiosko = new VKioskoEnt()
                            {
                                Id = Convert.ToInt32(read["Id"].ToString()),
                                Nombre = read["Nombre"].ToString(),
                                Descripcion = read["Descripcion"].ToString(),
                                Estado = state,
                                Correo = read["correo"].ToString(),
                            };

                            kioskos.Add(kiosko);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return kioskos;
        }

        public List<SelectListItem> listarEstadoKiosko()
        {

            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "Activo", Value = "1" });
            lst.Add(new SelectListItem() { Text = "Cancelado", Value = "2" });
            lst.Add(new SelectListItem() { Text = "Suspendido", Value = "3" });

            return lst;
        }

        public KioskoEnt Obtener(int Id)
        {
            objConexion = new Conexion();
            var kiosko = new KioskoEnt();

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = objConexion.AsignarCadenaConexion();
                    con.Open();

                    var query = new SqlCommand("SELECT Id, Nombre, Descripcion, Estado, IdUsuario FROM Kioskos WHERE Id = @Id", con);
                    query.Parameters.AddWithValue("@Id", Id);

                    using (var read = query.ExecuteReader())
                    {
                        read.Read();
                        if (read.HasRows)
                        {
                            kiosko.Id = Convert.ToInt32(read["Id"].ToString());

                            kiosko.Nombre = read["Nombre"].ToString();
                            kiosko.Descripcion = read["Descripcion"].ToString();
                            kiosko.Estado = Convert.ToInt32(read["Estado"].ToString());
                            kiosko.IdUsuario = Convert.ToInt32(read["IdUsuario"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return kiosko;
        }

        public bool Registrar(KioskoEnt kiosko)
        {
            objConexion = new Conexion();
            bool blResultado = false;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = objConexion.AsignarCadenaConexion();
                    con.Open();

                    var query = new SqlCommand("INSERT INTO KIOSKOS Values(@nombre, @descripcion, @estado, @idUsuario)", con);
                    query.Parameters.AddWithValue("@nombre", kiosko.Nombre);
                    query.Parameters.AddWithValue("@descripcion", kiosko.Descripcion);
                    query.Parameters.AddWithValue("@estado", kiosko.Estado);
                    query.Parameters.AddWithValue("@idUsuario", kiosko.IdUsuario);

                    query.ExecuteNonQuery();
                    blResultado = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return blResultado;
        }

        public bool Actualizar(KioskoEnt kiosko)
        {
            objConexion = new Conexion();
            bool blResultado = false;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = objConexion.AsignarCadenaConexion();
                    con.Open();

                    var query = new SqlCommand("UPDATE KIOSKOS SET Nombre=@nombre, Descripcion=@descripcion, Estado=@estado, IdUsuario=@idUsuario WHERE Id=@id", con);
                    query.Parameters.AddWithValue("@id", kiosko.Id);
                    query.Parameters.AddWithValue("@nombre", kiosko.Nombre);
                    query.Parameters.AddWithValue("@descripcion", kiosko.Descripcion);
                    query.Parameters.AddWithValue("@estado", kiosko.Estado);
                    query.Parameters.AddWithValue("@idUsuario", kiosko.IdUsuario);
                    query.ExecuteNonQuery();
                    blResultado = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return blResultado;
        }

        public bool Eliminar(int Id)
        {
            objConexion = new Conexion();
            bool blResultado = false;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = objConexion.AsignarCadenaConexion();
                    con.Open();

                    var query = new SqlCommand("DELETE FROM KIOSKO WHERE Id = @id", con);
                    query.Parameters.AddWithValue("@id", Id);

                    query.ExecuteNonQuery();
                    blResultado = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return blResultado;
        }
    }
}
