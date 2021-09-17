using KioskoEntidad;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace KioskoDatos
{
    public class UsuariosDat
    {

        public IConfiguration Configuration;

        public Conexion objConexion;

        public List<UsuariosEnt> Listar()
        {
            objConexion = new Conexion();

            var usuarios = new List<UsuariosEnt>();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = objConexion.AsignarCadenaConexion();
                    con.Open();

                    var queryUsuario = new SqlCommand("SELECT IdUsuario, Correo, Clave FROM Usuarios", con);

                    using (var read = queryUsuario.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            var usuario = new UsuariosEnt()
                            {
                                IdUsuario = Convert.ToInt32(read["IdUsuario"].ToString()),
                                Correo = read["Correo"].ToString(),
                                Clave = read["Clave"].ToString()
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return usuarios;
        }

        public UsuariosEnt Obtener(int Id)
        {
            objConexion = new Conexion();
            var usuario = new UsuariosEnt();

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = objConexion.AsignarCadenaConexion();
                    con.Open();

                    var query = new SqlCommand("SELECT IdUsuario, Correo, Clave FROM Usuarios WHERE IdUsuario = @idUsuario", con);
                    query.Parameters.AddWithValue("@idUsuario", Id);

                    using (var read = query.ExecuteReader())
                    {
                        read.Read();
                        if (read.HasRows)
                        {
                            usuario.IdUsuario = Convert.ToInt32(read["IdUsuario"].ToString());
                            usuario.Correo = read["Correo"].ToString();
                            usuario.Clave = read["Clave"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return usuario;
        }

        public bool Registrar(UsuariosEnt usuario)
        {
            objConexion = new Conexion();
            bool blResultado = false;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = objConexion.AsignarCadenaConexion();
                    con.Open();

                    var query = new SqlCommand("INSERT INTO USUARIOS Values(@correo, @clave)", con);
                    query.Parameters.AddWithValue("@correo", usuario.Correo);
                    query.Parameters.AddWithValue("@clave", usuario.Clave);

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

        public bool Actualizar(UsuariosEnt usuario)
        {
            objConexion = new Conexion();
            bool blResultado = false;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = objConexion.AsignarCadenaConexion();
                    con.Open();

                    var query = new SqlCommand("UPDATE USUARIOS SET Correo=@correo, Clave=@clave WHERE IdUsuario=@idUsuario", con);
                    query.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
                    query.Parameters.AddWithValue("@correo", usuario.Correo);
                    query.Parameters.AddWithValue("@clave", usuario.Clave);
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

                    var query = new SqlCommand("DELETE FROM Usuarios WHERE IdUsuario = @idUsuario", con);
                    query.Parameters.AddWithValue("@idUsuario", Id);

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
