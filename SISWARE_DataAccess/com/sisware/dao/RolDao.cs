using com.sisware.bean;
using com.sisware.dao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;


namespace com.sisware.dao
{
    public class RolDao
    {
        public void Insert(ERole role)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_role (ro_description, ro_name) VALUES (@description, @name)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@description", role.descripcion);
                    cmd.Parameters.AddWithValue("@name", role.name);
                    cmd.ExecuteNonQuery();
                }

            }


        }
        /// <summary>
        /// Devuelve una lista de Roles ordenados alfabeticamente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>Rafael Ortuño Paredes</autor>
        public List<ERole> GetAll()
        {
            List<ERole> roles = new List<ERole>();

            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_role ORDER BY ro_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {

                    var dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EUser para llenar sus propiedades
                        ERole role = new ERole
                        {
                            id = Convert.ToInt32(dataReader["ro_id"]),
                            descripcion = Convert.ToString(dataReader["ro_description"]),
                            name = Convert.ToString(dataReader["ro_name"]),
                         };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        roles.Add(role);
                    }

                }
            }
            return roles;

        }


        public ERole GetByid(int roleId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_role WHERE ro_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", roleId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        ERole user = new ERole
                        {
                            id = Convert.ToInt32(dataReader["ro_id"]),
                            descripcion = Convert.ToString(dataReader["ro_description"]),
                            name = Convert.ToString(dataReader["ro_name"]),
                        };

                        return user;
                    }
                }
            }

            return null;
        }

        public void Update(ERole role)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_role SET ro_description = @description, ro_name = @name WHERE ro_id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@description", role.descripcion);
                    cmd.Parameters.AddWithValue("@name", role.name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int roleId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_role WHERE ro_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", roleId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<ERole> GetAllDescription()
        {
            List<ERole> roles = new List<ERole>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT ro_name FROM ss_role ORDER BY ro_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ERole entity = new ERole
                        {
                            name = Convert.ToString(dataReader["ro_name"]),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        roles.Add(entity);
                    }
                }
            }
            return roles ;
        }
        public List<ERole> GetIdByDescription(string name)
        {
            List<ERole> roles = new List<ERole>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT ro_id FROM ss_role WHERE ro_name = @nameRole";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@nameRole", name);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ERole entity = new ERole
                        {
                            id = Convert.ToInt32(dataReader["ro_id"]),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        roles.Add(entity);
                    }
                }
            }
            return roles;
        }
        public List<ERole> GetDescriptionById(int idRole)
        {
            List<ERole> roles = new List<ERole>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT ro_name FROM ss_role WHERE ro_id = @idRol";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@idRole", idRole);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ERole entity = new ERole
                        {
                            name = Convert.ToString(dataReader["ro_name"]),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        roles.Add(entity);
                    }
                }
            }
            return roles;
        }
    }
}
