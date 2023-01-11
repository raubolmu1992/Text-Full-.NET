using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using model.entity;

namespace WebApi.Data
{
    public class estado
    {
        //Iniciamos la variable valestado en False;
        public static bool valestado = false;
        public static string valerror;
    }

    public class ProductosData
    {
       
        public static bool Registrar(Productos oEstudiantes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoProducto", oEstudiantes.TipoProducto);
                cmd.Parameters.AddWithValue("@CodigoUnico", oEstudiantes.CodigoUnico);
                cmd.Parameters.AddWithValue("@NombreProducto", oEstudiantes.NombreProducto);
                cmd.Parameters.AddWithValue("@Activo", oEstudiantes.Activo);
                cmd.Parameters.AddWithValue("@Cantidad", oEstudiantes.Cantidad);
                cmd.Parameters.AddWithValue("@Valor", oEstudiantes.Valor);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    // Validamos el estado de la ejecucion
                    estado.valestado = true;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();

                    return true;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();

                    return false;
                }
            }
        }

        //public static bool Modificar(Productos oEstudiantes)
        public static bool Modificar(Productos oEstudiantes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", oEstudiantes.IdProducto);
                cmd.Parameters.AddWithValue("@TipoProducto", oEstudiantes.TipoProducto);
                cmd.Parameters.AddWithValue("@CodigoUnico", oEstudiantes.CodigoUnico);
                cmd.Parameters.AddWithValue("@NombreProducto", oEstudiantes.NombreProducto);
                cmd.Parameters.AddWithValue("@Activo", oEstudiantes.Activo);
                cmd.Parameters.AddWithValue("@Cantidad", oEstudiantes.Cantidad);
                cmd.Parameters.AddWithValue("@Valor", oEstudiantes.Valor);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    // Validamos el estado de la ejecucion
                    estado.valestado = true;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return true;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return false;
                }
            }
        }

        public static List<Productos> Listar()
        {
            List<Productos> oListaUsuario = new List<Productos>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        int Total = 0;

                        while (dr.Read())
                        {
                            Total = Total + Convert.ToInt32(dr["Valor"]);

                            oListaUsuario.Add(new Productos()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                TipoProducto = dr["TipoProducto"].ToString(),
                                CodigoUnico = dr["CodigoUnico"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Activo = dr["Activo"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Valor = dr["Valor"].ToString(),
                                Total = Total

                            });
                        }
                    }

                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return oListaUsuario;
                }
            }
        }

        public static List<Productos> ListarId(int id)
        {
            List<Productos> oListaUsuario = new List<Productos>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        int Total = 0;

                        while (dr.Read())
                        {
                            Total = Total + Convert.ToInt32(dr["Valor"]);

                            oListaUsuario.Add(new Productos()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                TipoProducto = dr["TipoProducto"].ToString(),
                                CodigoUnico = dr["CodigoUnico"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Activo = dr["Activo"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Valor = dr["Valor"].ToString(),
                                Total = Total

                            });
                        }
                    }

                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return oListaUsuario;
                }
            }
        }

        public static Productos ObtenerProductos(int idcliente)
        {
            Productos oListaUsuario = new Productos();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idcliente);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario = new Productos()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                TipoProducto = dr["TipoProducto"].ToString(),
                                CodigoUnico = dr["CodigoUnico"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Activo = dr["Activo"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Valor = dr["Valor"].ToString(),

                            };
                        }
                    }

                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return oListaUsuario;
                }
            }
        }
        public static List<Productos> Obtener(int idcliente)
        {
            List<Productos> oListaUsuario = new List<Productos>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idcliente);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Productos()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                TipoProducto = dr["TipoProducto"].ToString(),
                                CodigoUnico = dr["CodigoUnico"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Activo = dr["Activo"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Valor = dr["Valor"].ToString(),

                            });
                        }

                    }

                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return oListaUsuario;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    // Validamos el estado de la ejecucion
                    estado.valestado = true;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return true;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return false;
                }
            }
        }

    }
}